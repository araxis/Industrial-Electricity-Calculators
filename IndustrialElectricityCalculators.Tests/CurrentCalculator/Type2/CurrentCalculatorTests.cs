using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.CurrentCalculator.Type2;
using IndustrialElectricityUnits;
using Moq;
using Xunit;
using Type2Calc =IndustrialElectricityCalculators.CurrentCalculator.Type2;

namespace IndustrialElectricityCalculators.Tests.CurrentCalculator.Type2
{
    [Trait("Category","current")]
    public class CurrentCalculatorTests
    {
        [Fact]
        public void CalcMethodNotAllowNullParameter()
        {
            Param inputParam = null;

            var sut = new Type2Calc.CurrentCalculator();

            var result =async ()=>await sut.Calc(inputParam,It.IsAny<CancellationToken>());
            result.Should().ThrowAsync<ArgumentNullException>();
        }

        [Theory]
        [InlineData(15,415,20.86)]
        [InlineData(50,380,75.96)]
        public async Task CanCalcThreePhaseSystemCurrent(double kVA, double voltage,double resultAmpere)
        {
            var inputParam = new Param(new KiloVoltAmpere(kVA), voltage,PowerSystem.ThreePhase);
            var result = await new Type2Calc.CurrentCalculator().Calc(inputParam,default);

            result.Should().BeOfType<Ampere>().Which.Value.Should().BeApproximately(resultAmpere,.1);
        }

        [Theory]
        [InlineData(15, 415,36.14)]
        [InlineData(50, 380, 131.57)]
        public async Task CanCalcOnePhaseSystemCurrent(double kVA, double voltage, double resultAmpere)
        {
            var inputParam = new Param(new KiloVoltAmpere(kVA), voltage, PowerSystem.SinglePhase);

            var result = await new Type2Calc.CurrentCalculator().Calc(inputParam, default);

            result.Should().BeOfType<Ampere>().Which.Value.Should().BeApproximately(resultAmpere, .1);
        }
    }
}