using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type3;

public record Param(ReactivePower ReactivePower, CosPhi CosPhi):IResultParam<Power>;

public class Calculator:BaseCalculator<Param,Power>
{
    protected override Result<Power> Calc(Param command)
    {
        var (reactivePower,cosPhi) = command;

        Watt powerValueInWatt = reactivePower.ToVAr() /cosPhi.TanPhi;
 
        return powerValueInWatt;
    }
}