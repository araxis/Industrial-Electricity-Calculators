using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ApparentPowerCalculator.Type1;

public class Calculator:SyncCalculator<Param,ApparentPower>
{
    protected override ApparentPower Calc(Param param)
    {

        var (voltage, current, system) = param;

        VoltAmpere result = voltage * current.ToA() * system.PhaseCoefficient();
        return result;
    }
}