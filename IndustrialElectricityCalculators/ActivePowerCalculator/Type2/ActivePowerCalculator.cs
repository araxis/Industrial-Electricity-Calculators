using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type2;

public class ActivePowerCalculator:SyncCalculator<Param,Power>
{
    protected override Power Calc(Param param)
    {
        var (apparentPower,cosPhi) = param;

        Watt powerValueInWatt = apparentPower.ToVA() * cosPhi;
        return powerValueInWatt;
    }
}