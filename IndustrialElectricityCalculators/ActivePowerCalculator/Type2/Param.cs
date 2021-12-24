using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type2;

public record Param(ApparentPower ApparentPower, CosPhi CosPhi):IParam<Power>;