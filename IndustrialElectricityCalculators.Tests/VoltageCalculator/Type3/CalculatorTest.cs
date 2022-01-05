using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.VoltageCalculator.Type3;
using IndustrialElectricityUnits;
using Moq;
using SimpleResult;
using Xunit;

namespace IndustrialElectricityCalculators.Tests.VoltageCalculator.Type3;

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


    [Fact]
    public async Task CalcMethodReturnFailResultIfCurrentBe0A()
    {
        Param inputParam = new(It.IsAny<ReactivePower>(),0.A(),It.IsAny<CosPhi>(),It.IsAny<PowerSystem>());
        var sut = new Calculator();

        var result =await sut.Calc(inputParam,default);

        result.Should().BeOfType<Result<Voltage>>().Which.IsFailure.Should().Be(true);
    }

    [Fact]
    public async Task CalcMethodReturnSucceedResult()
    {
        Param inputParam = new(120.VAr(),12.A(),.9,PowerSystem.ThreePhase);
        var expected = 13.245.V();
        var sut = new Calculator();

        var result =await sut.Calc(inputParam,default);

        result.Should().BeOfType<Result<Voltage>>()
            .Which.GetOrDefault().Value.Should()
            .BeApproximately(expected.Value, .1);
    }
}