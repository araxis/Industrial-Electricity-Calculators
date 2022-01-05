using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.ActivePowerCalculator.Type4;
using IndustrialElectricityUnits;
using SimpleResult;
using Xunit;

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
            var result = await new Calculator().Calc(inputParam,default);

           
            result.Should()
                .BeOfType<Result<Power>>()
                .Which
                .GetOrDefault().Value
                .Should()
                .BeApproximately(expectedResult, .1);
        }

        [Fact]
        public async Task ReturnExceptionResultIfVArGreaterThanVa()
        {
            var inputParam = new Param(50.VA(), 70.VAr());
            var result = await new Calculator().Calc(inputParam, default);
            result.ExceptionOrNull().Should().NotBeNull();

  
        }


    }
}