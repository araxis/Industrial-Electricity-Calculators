using CalculatorEngine;
using IndustrialElectricityUnits;
using Microsoft.Extensions.DependencyInjection;
using SimpleResult;

namespace IndustrialElectricityCalculators.ActivePowerCalculator;


public static class Extensions
{
    public static Task<Power> CalcActivePower(this ICalcEngine calculator,Voltage voltage,Current current, PowerSystem powerSystem, CosPhi cosPhi)
    {
        var param =  new Type1.Param(voltage, current, cosPhi, powerSystem);
        return calculator.Calc(param);
    }
    public static Task<Power> CalcActivePower(this ICalcEngine calculator,ApparentPower apparentPower, CosPhi cosPhi)
    {
        var param = new Type2.Param(apparentPower,cosPhi);
        return calculator.Calc(param);
    }
    public static Task<Power> CalcActivePower(this ICalcEngine calculator,ReactivePower reactivePower, CosPhi cosPhi)
    {
        var param =  new Type3.Param(reactivePower,cosPhi);
        return calculator.Calc(param);
    }
    public static Task<Result<Power>> CalcActivePower(this ICalcEngine calculator, ApparentPower apparentPower,ReactivePower reactivePower)
    {
        var param =  new Type4.Param(apparentPower,reactivePower);
        return calculator.Calc(param);
    }

    public static IServiceCollection AddActivePowerCalculators(this IServiceCollection services)
    {
        return services.InstallCalculators(typeof(Extensions).Assembly);
    }
}