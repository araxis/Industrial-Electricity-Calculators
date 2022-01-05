using Ardalis.GuardClauses;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.VoltageCalculator.Type3;

public record Param(ReactivePower ReactivePower, Current Current, CosPhi CosPhi,PowerSystem System):IResultParam<Voltage>;
public class Calculator:BaseCalculator<Param,Voltage>
{
    protected override Result<Voltage> Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));

        var (reactivePower, current, cosPhi,system) = param;

        if (current <= 0.A())
            return new CalculationException("Current vale must be greater than 0");

        Voltage voltage = reactivePower.ToVAr() / (cosPhi.SinPhi *current.ToAmpere() *  system.PhaseCoefficient()) ;

        return voltage;
    }
}