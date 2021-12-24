using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ApparentPowerCalculator.Type2;

public class Calculator:SyncCalculator<Param,ApparentPower>
{
    protected override ApparentPower Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));

        var (power, cosPhi) = param;

        Guard.Against.Null(power, nameof(power));
        Guard.Against.Null(cosPhi, nameof(cosPhi));
        VoltAmpere voltAmpere = power.ToWatt() / cosPhi;
        return voltAmpere;
    }
}