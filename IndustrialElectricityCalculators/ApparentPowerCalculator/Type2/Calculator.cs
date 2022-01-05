using Ardalis.GuardClauses;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ApparentPowerCalculator.Type2;

public record Param(Power Power, CosPhi CosPhi):IResultParam<ApparentPower>;
public class Calculator:BaseCalculator<Param,ApparentPower>
{
    protected override Result<ApparentPower> Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));

        var (power, cosPhi) = param;

        VoltAmpere voltAmpere = power.ToWatt() / cosPhi;
        return voltAmpere;
    }
}