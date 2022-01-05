using Ardalis.GuardClauses;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.CurrentCalculator.Type1;
public record Param(Power Power, Voltage Voltage, CosPhi CosPhi, Efficiency Efficiency, PowerSystem System) : IResultParam<Current>
{
   
}
public class CurrentCalculator:BaseCalculator<Param,Current>
{
    protected override Result<Current> Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));

       var (power,voltage,cosPhi,efficiency,system) = param;
        
        Ampere current = power.ToWatt() / (voltage * cosPhi * efficiency * system.PhaseCoefficient());

        return current;
    }
}