using CalculatorEngine;
using IndustrialElectricityUnits;
using Microsoft.Extensions.DependencyInjection;
using SimpleResult;

namespace IndustrialElectricityCalculators.ApparentPowerCalculator;


public static class Extensions
{
    public static Task<Result<ApparentPower>> CalcApparentPower(this ICalcEngine calcEngine,Voltage voltage, Current current, PowerSystem system)
    {
        var param= new Type1.Param(voltage,current,system);
        return calcEngine.Calc(param);
    }

    public static Task<Result<ApparentPower>> CalcApparentPower(this ICalcEngine calcEngine,Power power, CosPhi cosPhi)
    {
        var param= new Type2.Param(power,cosPhi);
        return calcEngine.Calc(param);
    }

    public static Task<Result<ApparentPower>> CalcApparentPower(this ICalcEngine calcEngine,ReactivePower reactivePower, CosPhi cosPhi)
    {
        var param= new Type3.Param(reactivePower,cosPhi);
        return calcEngine.Calc(param);
    }


   
    
}