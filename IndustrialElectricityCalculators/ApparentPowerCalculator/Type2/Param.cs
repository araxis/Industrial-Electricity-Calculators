using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ApparentPowerCalculator.Type2;

public record Param(Power Power, CosPhi CosPhi):IParam<ApparentPower>;