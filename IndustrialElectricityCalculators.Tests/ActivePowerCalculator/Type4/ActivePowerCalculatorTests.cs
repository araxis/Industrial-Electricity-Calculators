using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.ActivePowerCalculator.Type4;
using IndustrialElectricityUnits;
using Xunit;
using Type1Calc =IndustrialElectricityCalculators.ActivePowerCalculator.Type4;

namespace IndustrialElectricityCalculators.Tests.ActivePowerCalculator.Type4
{
    [Trait("Category","Active Power")]
    public class ActivePowerCalculatorTests
    {
     

        [Fact]
        public async Task CanCalcActivePower()
        {
            var inputParam = new Param(150.VA(),50.VAr());
          
            var expectedResult = 141.421.W();
            var result = await new Type1Calc.ActivePowerCalculator().Calc(inputParam,default);

            result.GetOrDefault().Should().BeOfType<Watt>().Which.Value.Should().BeApproximately(expectedResult.Value,.1);
        }

        [Fact]
        public async Task ReturnExceptionResultIfVArGreaterThanVa()
        {
            var inputParam = new Param(50.VA(), 70.VAr());
            var result = await new Type1Calc.ActivePowerCalculator().Calc(inputParam, default);
            result.ExceptionOrNull().Should().NotBeNull();

  
        }


    }
}