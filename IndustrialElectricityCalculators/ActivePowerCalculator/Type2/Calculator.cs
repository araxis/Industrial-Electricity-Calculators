using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type2;
public record Param(ApparentPower ApparentPower, CosPhi CosPhi):IResultParam<Power>;
public class Calculator:BaseCalculator<Param,Power>
{
    protected override Result<Power> Calc(Param param)
    {
        var (apparentPower,cosPhi) = param;

        Watt powerValueInWatt = apparentPower.ToVA() * cosPhi;
        return powerValueInWatt;
    }
}