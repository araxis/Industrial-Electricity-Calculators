using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type4;



public class ActivePowerCalculator:SyncCalculator<Param,Result<Power>>
{
    protected override Result<Power> Calc(Param param)
    {
        var (apparentPower,reactivePower) = param;
        
        var reactivePowerInVar = (reactivePower ^ 2).ToVAr();
        var apparentPowerInVa = (apparentPower ^ 2).ToVA();

        if (apparentPowerInVa < reactivePowerInVar)
            return new WrongParametersException("VA value must be greater VAr value");

        Watt powerInWatt = Math.Sqrt(apparentPowerInVa - reactivePowerInVar);
 
        return powerInWatt;
    }
}