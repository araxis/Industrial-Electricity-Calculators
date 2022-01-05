using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using IndustrialElectricityUnits;
using Moq;
using Xunit;
using  IndustrialElectricityCalculators.ActivePowerCalculator.Type3;
using SimpleResult;

namespace IndustrialElectricityCalculators.Tests.ActivePowerCalculator.Type3;

[Trait("Category", "Active Power")]
public class ActivePowerCalculatorTests
{
    [Fact]
    public void CalcMethodNotAllowNullParameter()
    {
        Param inputParam = null;

        var sut = new Calculator();

        var result = async () => await sut.Calc(inputParam, It.IsAny<CancellationToken>());
        result.Should().ThrowAsync<ArgumentNullException>();
    }

    [Theory]
    [InlineData(150, .86, 252.795)]
    [InlineData(50, .85, 80.678)]
    public async Task CanCalcActivePower(double VAr, double cosPhi, double resultWatt)
    {
        var inputParam = new Param(VAr.VAr(), cosPhi);
        var result = await new Calculator().Calc(inputParam, default);

        result.Should()
            .BeOfType<Result<Power>>()
            .Which
            .GetOrDefault().Value
            .Should()
            .BeApproximately(resultWatt, .1);
    }
}