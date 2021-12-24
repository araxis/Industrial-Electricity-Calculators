using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ReactivePowerCalculator.Type1;

public record Param(Current Current, Voltage Voltage, CosPhi CosPhi, PowerSystem System):IParam<ReactivePower>;