using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type1;

public record Param(Voltage Voltage,Current Current, CosPhi CosPhi, PowerSystem PowerSystem):IParam<Power>;