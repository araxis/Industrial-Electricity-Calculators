using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.ActivePowerCalculator.Type1;
using IndustrialElectricityUnits;
using Moq;
using Xunit;
using Type1Calc =IndustrialElectricityCalculators.ActivePowerCalculator.Type1;

namespace IndustrialElectricityCalculators.Tests.ActivePowerCalculator.Type1
{
    [Trait("Category","Active Power")]
    public class ActivePowerCalculatorTests
    {
        [Fact]

        public void CalcMethodNotAllowNullParameter()
        {
            Param inputParam = null;

            var sut = new Type1Calc.ActivePowerCalculator();

            var result =async ()=>await sut.Calc(inputParam,It.IsAny<CancellationToken>());
            result.Should().ThrowAsync<ArgumentNullException>();
        }

        [Theory]
        [InlineData(415,15,.86,9272.5)]
        [InlineData(380,50,.85,27972.6)]
        public async Task CanCalcThreePhaseSystemActivePower(double voltage,double ampere,  double cosPhi,double resultWatt)
        {
            var inputParam = new Param(voltage,ampere.A(), cosPhi,PowerSystem.ThreePhase);
            var result = await new Type1Calc.ActivePowerCalculator().Calc(inputParam,default);

            result.Should().BeOfType<Watt>().Which.Value.Should().BeApproximately(resultWatt,.1);
        }

        [Theory]
        [InlineData(415, 15, .86,5353.5)]
        [InlineData(380, 50, .85, 16150)]
        public async Task CanCalcOnePhaseSystemActivePower(double voltage,double ampere,  double cosPhi,double resultWatt)
        {
            var inputParam = new Param(voltage,ampere.A(), cosPhi,PowerSystem.SinglePhase);

            var result = await new Type1Calc.ActivePowerCalculator().Calc(inputParam, default);

            result.Should().BeOfType<Watt>().Which.Value.Should().BeApproximately(resultWatt, .1);
        }
    }
}