using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.ActivePowerCalculator.Type2;
using IndustrialElectricityUnits;
using Moq;
using SimpleResult;
using Xunit;

namespace IndustrialElectricityCalculators.Tests.ActivePowerCalculator.Type2
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
        [InlineData(150,.86,129)]
        [InlineData(50,.85,42.5)]
        public async Task CanCalcActivePower(double va,  double cosPhi,double resultWatt)
        {
            var inputParam = new Param(va.VA(), cosPhi);
            var result = await new Calculator().Calc(inputParam,default);

            result.Should().BeOfType<Result<Power>>()
                .Which
                .GetOrDefault().Value
                .Should().BeApproximately(resultWatt,.1);
        }

      
    }
}