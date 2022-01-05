using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.CurrentCalculator.Type1;
using IndustrialElectricityUnits;
using Moq;
using Xunit;
using Type1Calc =IndustrialElectricityCalculators.CurrentCalculator.Type1;

namespace IndustrialElectricityCalculators.Tests.CurrentCalculator.Type1
{
    [Trait("Category","current")]
    public class CurrentCalculatorTests
    {
        [Fact]
        public void CalcMethodNotAllowNullParameter()
        {
            Param inputParam = null;

            var sut = new Type1Calc.CurrentCalculator();

            var result =async ()=>await sut.Calc(inputParam,It.IsAny<CancellationToken>());
            result.Should().ThrowAsync<ArgumentNullException>();
        }

        [Theory]
        [InlineData(15,415,.86,95,25.54)]
        [InlineData(50,380,.85,90,99.3)]
        public async Task CanCalcThreePhaseSystemCurrent(double kw, double voltage, double coaPhi, double efficiency,double resultAmpere)
        {
            var inputParam = new Param(kw.Kw(),voltage,coaPhi,efficiency,PowerSystem.ThreePhase);
            var result = await new Type1Calc.CurrentCalculator().Calc(inputParam,default);
            var resultValue = result.GetOrDefault();
            resultValue.Should()
                .BeOfType<Ampere>()
                .Which
                .Value.Should()
                .BeApproximately(resultAmpere,.1);
        }

        [Theory]
        [InlineData(15,415,.86,95,44.24)]
        [InlineData(50,380,.85,90,172)]
        public async Task CanCalcOnePhaseSystemCurrent(double kw, double voltage, double coaPhi, double efficiency,double resultAmpere)
        {
            var inputParam = new Param(kw.Kw(),voltage,coaPhi,efficiency,PowerSystem.SinglePhase);

            var result = await new Type1Calc.CurrentCalculator().Calc(inputParam,default);

            var resultValue = result.GetOrDefault();
            resultValue.Should()
                .BeOfType<Ampere>()
                .Which
                .Value.Should()
                .BeApproximately(resultAmpere,.1);
        }
    }
}