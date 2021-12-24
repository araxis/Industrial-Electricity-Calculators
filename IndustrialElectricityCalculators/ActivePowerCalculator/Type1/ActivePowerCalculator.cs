using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type1;

public class ActivePowerCalculator:SyncCalculator<Param,Power>
{
    protected override Power Calc(Param command)
    {
        var (voltage,current,cosPhi,system) = command;

        Watt powerValueInWatt = system.PhaseCoefficient() * voltage * current.ToA() * cosPhi ;

        return powerValueInWatt;
    }
}