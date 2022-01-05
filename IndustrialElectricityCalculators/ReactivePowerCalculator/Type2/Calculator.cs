using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ReactivePowerCalculator.Type2;

public record Param(Power ActivePower, ApparentPower ApparentPower):IResultParam<ReactivePower>;
public class Calculator:BaseCalculator<Param,ReactivePower>
{
    protected override Result<ReactivePower> Calc(Param param)
    {
        var (activePower,reactivePower) = param;
        
        var apparentPowerInVa = (reactivePower ^ 2).ToVA();
        var activePowerInW = (activePower ^ 2).ToWatt();

        if ( apparentPowerInVa < activePowerInW)
            return new CalculationException("VA value must be greater W value");

        VoltAmpereReactive powerInVar = Math.Sqrt(apparentPowerInVa - activePowerInW);
 
        return powerInVar;
    }
}