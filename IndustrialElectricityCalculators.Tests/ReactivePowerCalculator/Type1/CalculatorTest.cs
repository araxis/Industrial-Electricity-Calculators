using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.ReactivePowerCalculator.Type1;
using IndustrialElectricityUnits;
using Moq;
using Xunit;

namespace IndustrialElectricityCalculators.Tests.ReactivePowerCalculator.Type1;

[Trait("Category","Reactive Power")]
public class CalculatorTest
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
    [InlineData(15,415,.86,5502)]
    [InlineData(50,380,.85,17335.87)]
    public async Task CanCalcThreePhaseSystemCurrent(double ampere, double voltage,double cosPhi,double expected)
    {
        var inputParam = new Param(ampere.A(), voltage,cosPhi,PowerSystem.ThreePhase);
        var result = await new Calculator().Calc(inputParam,default);

        result.Should().BeOfType<VoltAmpereReactive>().Which.Value.Should().BeApproximately(expected,.1);
    }

    [Theory]
    [InlineData(15,415,.86,3176.58)]
    [InlineData(50,380,.85,10008.87)]
    public async Task CanCalcOnePhaseSystemCurrent(double ampere, double voltage,double cosPhi,double expected)
    {
        var inputParam = new Param(ampere.A(), voltage,cosPhi,PowerSystem.SinglePhase);
        var result = await new Calculator().Calc(inputParam,default);

        result.Should().BeOfType<VoltAmpereReactive>().Which.Value.Should().BeApproximately(expected,.1);
    }
}