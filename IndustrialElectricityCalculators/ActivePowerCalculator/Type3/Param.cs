using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type3;

public record Param(ReactivePower ReactivePower, CosPhi CosPhi):IParam<Power>;