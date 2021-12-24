using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ApparentPowerCalculator.Type3;

public class Calculator:SyncCalculator<Param,ApparentPower>
{
    protected override ApparentPower Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));

       

        var (reactivePower, cosPhi) = param;

        VoltAmpere voltAmpere = reactivePower.ToVAr() / cosPhi.SinPhi;
        return voltAmpere;
    }
}