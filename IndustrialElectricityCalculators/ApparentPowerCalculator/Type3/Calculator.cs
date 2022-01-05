using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ApparentPowerCalculator.Type3;

public record Param(ReactivePower ReactivePower, CosPhi CosPhi):IResultParam<ApparentPower>;
public class Calculator:BaseCalculator<Param,ApparentPower>
{
    protected override Result<ApparentPower> Calc(Param param)
    {
        Guard.Against.Null(param, nameof(param));
        
        var (reactivePower, cosPhi) = param;

        VoltAmpere voltAmpere = reactivePower.ToVAr() / cosPhi.SinPhi;
        return voltAmpere;
    }
}