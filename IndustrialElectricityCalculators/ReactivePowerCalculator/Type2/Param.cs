using CalculatorEngine;
using IndustrialElectricityUnits;
using SimpleResult;

namespace IndustrialElectricityCalculators.ReactivePowerCalculator.Type2;

public record Param(Power ActivePower, ApparentPower ApparentPower):IParam<Result<ReactivePower>>;