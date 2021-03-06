using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using IndustrialElectricityCalculators.ApparentPowerCalculator.Type3;
using IndustrialElectricityUnits;
using Moq;
using Xunit;


namespace IndustrialElectricityCalculators.Tests.ApparentPowerCalculator.Type3
{
    [Trait("Category","Active Power")]
    public class ApparentPowerCalculatorTests
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
        [InlineData(150,.86,293.948)]
        [InlineData(50,.85,94.916)]
        public async Task CanCalcApparent(double VAr,  double cosPhi,double expectedValue)
        {
            var inputParam = new Param(VAr.VAr(), cosPhi);
            var expected = expectedValue.VA();

            var result = await new Calculator().Calc(inputParam,default);
            var apparentPower = result.GetOrDefault();

            using var scope = new AssertionScope();
            apparentPower.Symbol
                .Should()
                .Be(expected.Symbol);
            apparentPower.Value
                .Should()
                .BeApproximately(expected.Value,.1);
        }

      
    }
}