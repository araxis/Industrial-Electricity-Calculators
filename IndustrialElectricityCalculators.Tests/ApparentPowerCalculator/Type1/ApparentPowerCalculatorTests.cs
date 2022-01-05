using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.ApparentPowerCalculator.Type1;
using IndustrialElectricityUnits;
using SimpleResult;
using Xunit;

namespace IndustrialElectricityCalculators.Tests.ApparentPowerCalculator.Type1
{
    [Trait("Category","Apparent Power")]
    public class ApparentPowerCalculatorTests
    {

        [Theory]
        [InlineData(415,15,10782)]
        [InlineData(380,50,32909)]
        public async Task CanCalcThreePhaseSystemApparentPower(double voltage,double ampere,double resultWatt)
        {
            var inputParam = new Param(voltage,ampere.A(), PowerSystem.ThreePhase);
            var result = await new Calculator().Calc(inputParam,default);

            result.Should()
                .BeOfType<Result<ApparentPower>>()
                .Which
                .GetOrDefault().Value
                .Should()
                .BeApproximately(resultWatt,.1);
        }

        [Theory]
        [InlineData(415, 15, 6225)]
        [InlineData(380, 50, 19000)]
        public async Task CanCalcOnePhaseSystemApparentPower(double voltage, double ampere, double resultWatt)
        {
            var inputParam = new Param(voltage, ampere.A(),  PowerSystem.SinglePhase);

            var result = await new Calculator().Calc(inputParam, default);

            result.Should()
                .BeOfType<Result<ApparentPower>>()
                .Which.
                GetOrDefault().Value
                .Should()
                .BeApproximately(resultWatt, .1);
        }
    }
}