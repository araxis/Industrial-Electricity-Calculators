using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.VoltageCalculator.Type1;

public record Param(Power Power, Current Current, CosPhi CosPhi, PowerSystem System) : IParam<Result<Voltage>>;
public class Calculator : SyncCalculator<Param, Result<Voltage>>
{
    protected override Result<Voltage> Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));

        var (power, current, cosPhi, system) = param;

        if (current <= 0.A())
            return new CalculationException("Current vale must be greater than 0");

        if (cosPhi <= 0)
            return new CalculationException("CosPhi vale must be greater than 0");

        Voltage voltage = power.ToWatt() / (cosPhi * system.PhaseCoefficient() * current.ToAmpere());
        return voltage;
    }


}