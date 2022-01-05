using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type4;

public record Param(ApparentPower ApparentPower, ReactivePower ReactivePower):IResultParam<Power>;

public class Calculator:BaseCalculator<Param,Power>
{
    protected override Result<Power> Calc(Param param)
    {
        var (apparentPower,reactivePower) = param;
        
        var reactivePowerInVar = (reactivePower ^ 2).ToVAr();
        var apparentPowerInVa = (apparentPower ^ 2).ToVA();

        if (apparentPowerInVa < reactivePowerInVar)
            return new CalculationException("VA value must be greater VAr value");

        Watt powerInWatt = Math.Sqrt(apparentPowerInVa - reactivePowerInVar);
 
        return powerInWatt;
    }
}