using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.CurrentCalculator.Type2;

public record Param(ApparentPower ApparentPower, Voltage Voltage, PowerSystem System) : IResultParam<Current>;
public class CurrentCalculator:BaseCalculator<Param,Current>
{
    protected override Result<Current> Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));
       var (power,voltage,system) = param;
        
        Ampere current = power.ToVA() / (voltage *   system.PhaseCoefficient());

        return current;
    }
}