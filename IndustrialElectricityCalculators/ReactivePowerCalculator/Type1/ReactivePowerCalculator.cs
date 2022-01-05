using Ardalis.GuardClauses;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ReactivePowerCalculator.Type1;

public record Param(Current Current, Voltage Voltage, CosPhi CosPhi, PowerSystem System):IResultParam<ReactivePower>;
public class Calculator :BaseCalculator<Param,ReactivePower>
{
    protected override Result<ReactivePower> Calc(Param param)
    {

        Guard.Against.Null(param, nameof(param));

        var (current,voltage,cosPhi,system) = param;

        var sinPhi = cosPhi.SinPhi;
        VoltAmpereReactive reactivePower = voltage * current.ToA() * system.PhaseCoefficient() * sinPhi;
        return reactivePower;
    }
}