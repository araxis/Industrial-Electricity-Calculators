using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ReactivePowerCalculator.Type2;

public class Calculator:SyncCalculator<Param,Result<ReactivePower>>
{
    protected override Result<ReactivePower> Calc(Param param)
    {
        var (activePower,reactivePower) = param;
        
        var apparentPowerInVa = (reactivePower ^ 2).ToVA();
        var activePowerInW = (activePower ^ 2).ToWatt();

        if ( apparentPowerInVa < activePowerInW)
            return new WrongParametersException("VA value must be greater W value");

        VoltAmpereReactive powerInVar = Math.Sqrt(apparentPowerInVa - activePowerInW);
 
        return powerInVar;
    }
}