using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.ReactivePowerCalculator.Type2;
using IndustrialElectricityUnits;
using Xunit;

namespace IndustrialElectricityCalculators.Tests.ReactivePowerCalculator.Type2
{
    [Trait("Category","Reactive Power")]
    public class CalculatorTests
    {
     

        [Fact]
        public async Task CanCalcReactivePower()
        {
            var inputParam = new Param(50.W(),150.VA());
          
            var expectedResult = 141.421.VAr();
            var result = await new Calculator().Calc(inputParam,default);

            result.GetOrDefault().Should().BeOfType<VoltAmpereReactive>()
                .Which
                .Value.Should().BeApproximately(expectedResult.Value,.1);
        }

        [Fact]
        public async Task ReturnExceptionResultIfVArGreaterThanVa()
        {
            var inputParam = new Param(50.W(), 30.VA());
            var result = await new Calculator().Calc(inputParam, default);
            result.ExceptionOrNull().Should().NotBeNull();


        }


    }
}