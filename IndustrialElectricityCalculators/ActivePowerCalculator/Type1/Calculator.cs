using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type1;

public record Param(Voltage Voltage,Current Current, CosPhi CosPhi, PowerSystem PowerSystem):IResultParam<Power>;
public class Calculator : BaseCalculator<Param, Power>
{
    protected override Result<Power> Calc(Param command)
    {
        var (voltage,current,cosPhi,system) = command;

        Watt powerValueInWatt = system.PhaseCoefficient() * voltage * current.ToA() * cosPhi ;

        return powerValueInWatt;
    }
}