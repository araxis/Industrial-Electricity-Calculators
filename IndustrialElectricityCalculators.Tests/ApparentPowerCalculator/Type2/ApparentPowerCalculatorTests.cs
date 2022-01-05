using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using IndustrialElectricityCalculators.ApparentPowerCalculator.Type2;
using IndustrialElectricityUnits;
using Moq;
using SimpleResult;
using Xunit;

namespace IndustrialElectricityCalculators.Tests.ApparentPowerCalculator.Type2
{
    [Trait("Category","Apparent Power")]
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
        [InlineData(150,.86,174.419)]
        [InlineData(50,.85,58.824)]
        public async Task CanCalcApparentPower(double watt,  double cosPhi,double resultValue)
        {
            var inputParam = new Param(watt.W(), cosPhi);
            var expected = resultValue.VA();


            var result = await new Calculator().Calc(inputParam, default);
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