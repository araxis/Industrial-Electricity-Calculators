using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type3;



public class ActivePowerCalculator:SyncCalculator<Param,Power>
{
    protected override Power Calc(Param command)
    {
        var (reactivePower,cosPhi) = command;

        Watt powerValueInWatt = reactivePower.ToVAr() /cosPhi.TanPhi;
 
        return powerValueInWatt;
    }
}