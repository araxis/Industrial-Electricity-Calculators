using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ReactivePowerCalculator;

public static class Extensions
{
    public static Task<Result<ReactivePower>> CalcReactivePower(this ICalcEngine calcEngine,Current current, Voltage voltage, CosPhi cosPhi, PowerSystem system)
    {
        var param = new Type1.Param(current,voltage,cosPhi,system);
        return calcEngine.Calc(param);
    }

    public static Task<Result<ReactivePower>> CalcReactivePower(this ICalcEngine calcEngine,Power activePower, ApparentPower apparentPower)
    {
        var param = new Type2.Param(activePower,apparentPower);
        return calcEngine.Calc(param);
    }
}