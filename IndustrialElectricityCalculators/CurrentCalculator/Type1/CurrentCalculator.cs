using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.CurrentCalculator.Type1;

public class CurrentCalculator:SyncCalculator<Param,Current>
{
    protected override Current Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));

       var (power,voltage,cosPhi,efficiency,system) = param;
        
        Ampere current = power.ToWatt() / (voltage * cosPhi * efficiency * system.PhaseCoefficient());

        return current;
    }
}