using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.ApparentPowerCalculator.Type1;

public record Param(Voltage Voltage, Current Current, PowerSystem System):IParam<ApparentPower>;