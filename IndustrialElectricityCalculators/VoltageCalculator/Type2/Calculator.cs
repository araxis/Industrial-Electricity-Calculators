using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.VoltageCalculator.Type2;

public record Param(ApparentPower ApparentPower, Current Current) : IResultParam<Voltage>;

public class Calculator : BaseCalculator<Param, Voltage>
{
    protected override Result<Voltage> Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));

        var (apparentPower, current) = param;

        if (current <= 0.A())
            return new CalculationException("Current vale must be greater than 0");

        Voltage voltage = apparentPower.ToVA() / current.ToAmpere();
        return voltage;

    }
}