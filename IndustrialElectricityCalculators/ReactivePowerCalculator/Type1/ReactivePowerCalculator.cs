using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ReactivePowerCalculator.Type1;

public class Calculator :SyncCalculator<Param,ReactivePower>
{
    protected override ReactivePower Calc(Param param)
    {

        Guard.Against.Null(param, nameof(param));

        var (current,voltage,cosPhi,system) = param;

        var sinPhi = cosPhi.SinPhi;
        VoltAmpereReactive reactivePower = voltage * current.ToA() * system.PhaseCoefficient() * sinPhi;
        return reactivePower;
    }
}