using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityCalculators.VoltageCalculator.Type2;
using IndustrialElectricityUnits;
using Moq;
using SimpleResult;
using Xunit;

namespace IndustrialElectricityCalculators.Tests.VoltageCalculator.Type2;

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
        Param inputParam = new(It.IsAny<ApparentPower>(),0.A());
        var sut = new Calculator();

        var result =await sut.Calc(inputParam,default);

        result.Should().BeOfType<Result<Voltage>>().Which.IsFailure.Should().Be(true);
    }

    [Fact]
    public async Task CalcMethodReturnSucceedResult()
    {
        Param inputParam = new(120.VA(),12.A());
        var expected = 10.V();
        var sut = new Calculator();

        var result =await sut.Calc(inputParam,default);

        result.Should().BeOfType<Result<Voltage>>()
            .Which.GetOrDefault().Value.Should()
            .BeApproximately(expected.Value, .1);
    }
}