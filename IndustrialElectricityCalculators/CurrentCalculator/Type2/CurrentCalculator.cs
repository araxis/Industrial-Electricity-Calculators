using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.CurrentCalculator.Type2;

public class CurrentCalculator:SyncCalculator<Param,Current>
{
    protected override Current Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));
       var (power,voltage,system) = param;
        
        Ampere current = power.ToVA() / (voltage *   system.PhaseCoefficient());

        return current;
    }
}