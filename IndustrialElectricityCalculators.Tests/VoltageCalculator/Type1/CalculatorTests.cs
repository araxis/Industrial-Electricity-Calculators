using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.VoltageCalculator.Type1;
using IndustrialElectricityUnits;
using Moq;
using SimpleResult;
using Xunit;

namespace IndustrialElectricityCalculators.Tests.VoltageCalculator.Type1;

[Trait("Category","Voltage")]
public class CalculatorTests
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
        Param inputParam = new(It.IsAny<Power>(),0.A(),.9,It.IsAny<PowerSystem>());
        var sut = new Calculator();

        var result =await sut.Calc(inputParam,default);

        result.Should().BeOfType<Result<Voltage>>().Which.IsFailure.Should().Be(true);
    }

    [Fact]
    public async Task CalcMethodReturnFailResultIfCosPhiBe0()
    {
        Param inputParam = new(It.IsAny<Power>(),10.A(),0,It.IsAny<PowerSystem>());
        var sut = new Calculator();

        var result =await sut.Calc(inputParam,default);

        result.Should().BeOfType<Result<Voltage>>().Which.IsFailure.Should().Be(true);
    }

    [Fact]
    public async Task CalcMethodReturnSucceedResultForSinglePhaseSystem()
    {
        Param inputParam = new(150.W(),7.A(),.9,PowerSystem.SinglePhase);
        var expected = 23.81.V();
        var sut = new Calculator();

        var result =await sut.Calc(inputParam,default);

        result.Should().BeOfType<Result<Voltage>>()
            .Which.GetOrDefault().Value.Should()
            .BeApproximately(expected.Value, .1);
    }

    [Fact]
    public async Task CalcMethodReturnSucceedResultForThreePhaseSystem()
    {
        Param inputParam = new(150.W(),7.A(),.9,PowerSystem.ThreePhase);
        var expected = 13.746.V();
        var sut = new Calculator();

        var result =await sut.Calc(inputParam,default);

        result.Should().BeOfType<Result<Voltage>>()
            .Which.GetOrDefault().Value.Should()
            .BeApproximately(expected.Value, .1);
    }

}