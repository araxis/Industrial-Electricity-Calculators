using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ApparentPowerCalculator.Type3;

public record Param(ReactivePower ReactivePower, CosPhi CosPhi):IParam<ApparentPower>;