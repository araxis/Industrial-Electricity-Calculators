using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ApparentPowerCalculator.Type1;
public record Param(Voltage Voltage, Current Current, PowerSystem System):IResultParam<ApparentPower>;
public class Calculator:BaseCalculator<Param,ApparentPower>
{
    protected override Result<ApparentPower> Calc(Param param)
    {

        var (voltage, current, system) = param;

        VoltAmpere result = voltage * current.ToA() * system.PhaseCoefficient();
        return result;
    }
}