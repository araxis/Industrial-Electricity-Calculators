using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.ApparentPowerCalculator.Type2;
using IndustrialElectricityUnits;
using Moq;
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
        public async Task CanCalcActivePower(double watt,  double cosPhi,double resultWatt)
        {
            var inputParam = new Param(watt.W(), cosPhi);
            var result = await new Calculator().Calc(inputParam,default);

            result.Should().BeOfType<VoltAmpere>().Which.Value.Should().BeApproximately(resultWatt,.1);
        }

      
    }
}