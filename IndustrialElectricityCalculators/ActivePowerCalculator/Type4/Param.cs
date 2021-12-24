using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ActivePowerCalculator.Type4;

public record Param(ApparentPower ApparentPower, ReactivePower ReactivePower):IParam<Result<Power>>;