using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.ActivePowerCalculator.Type2;
using IndustrialElectricityUnits;
using Moq;
using Xunit;
using Type1Calc =IndustrialElectricityCalculators.ActivePowerCalculator.Type2;

namespace IndustrialElectricityCalculators.Tests.ActivePowerCalculator.Type2
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
        [InlineData(150,.86,129)]
        [InlineData(50,.85,42.5)]
        public async Task CanCalcActivePower(double va,  double cosPhi,double resultWatt)
        {
            var inputParam = new Param(va.VA(), cosPhi);
            var result = await new Type1Calc.ActivePowerCalculator().Calc(inputParam,default);

            result.Should().BeOfType<Watt>().Which.Value.Should().BeApproximately(resultWatt,.1);
        }

      
    }
}