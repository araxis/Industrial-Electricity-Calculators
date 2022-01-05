using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.ActivePowerCalculator.Type1;
using IndustrialElectricityUnits;
using Moq;
using SimpleResult;
using Xunit;

namespace IndustrialElectricityCalculators.Tests.ActivePowerCalculator.Type1
{
    [Trait("Category","Active Power")]
    public class ActivePowerCalculatorTests
    {
        [Fact]
        public void CalcMethodNotAllowNullParameter()
        {
            Param inputParam = null;

            var sut = new Calculator();

            var result =async ()=>await sut.Calc(inputParam,It.IsAny<CancellationToken>());
            result.Should().ThrowAsync<ArgumentNullException>();
        }

        [Theory]
        [InlineData(415,15,.86,9272.5)]
        [InlineData(380,50,.85,27972.6)]
        public async Task CanCalcThreePhaseSystemActivePower(double voltage,double ampere,  double cosPhi,double resultWatt)
        {
            var inputParam = new Param(voltage,ampere.A(), cosPhi,PowerSystem.ThreePhase);
            var expected = resultWatt.W();

            var result = await new Calculator().Calc(inputParam,default);
            var watt = result.GetOrDefault();

            watt.Unit.Should().Be(expected.Unit);
            watt.Value.Should().BeApproximately(watt.Value, .1);

        
        }

        [Theory]
        [InlineData(415, 15, .86,5353.5)]
        [InlineData(380, 50, .85, 16150)]
        public async Task CanCalcOnePhaseSystemActivePower(double voltage,double ampere,  double cosPhi,double resultWatt)
        {
            var inputParam = new Param(voltage,ampere.A(), cosPhi,PowerSystem.SinglePhase);

            var result = await new Calculator().Calc(inputParam, default);

            result.Should().BeOfType<Result<Power>>()
                .Which
                .GetOrDefault().Value
                .Should()
                .BeApproximately(resultWatt, .1);
        }
    }
}