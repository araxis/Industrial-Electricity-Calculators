using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.CurrentCalculator.Type2;

public record Param(ApparentPower ApparentPower, Voltage Voltage, PowerSystem System) : IParam<Current>;