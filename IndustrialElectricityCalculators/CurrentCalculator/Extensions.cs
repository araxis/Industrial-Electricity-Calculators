using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.CurrentCalculator;

public static class Extensions
{
 

    public static Task<Result<Current>> CalcCurrent(this ICalcEngine calcEngine,Power power, Voltage voltage, CosPhi cosPhi, Efficiency efficiency, PowerSystem system)
    {
        var param = new Type1.Param(power, voltage, cosPhi, efficiency, system);
        return calcEngine.Calc(param);
    }

    public static Task<Result<Current>> CalcCurrent(this ICalcEngine calcEngine,ApparentPower power, Voltage voltage, PowerSystem system)
    {
        var param = new Type2.Param(power, voltage,system);
        return calcEngine.Calc(param);
    }

   
}