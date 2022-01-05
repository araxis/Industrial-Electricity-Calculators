using CalculatorEngine;
using IndustrialElectricityUnits;
using Microsoft.Extensions.DependencyInjection;
using static System.Math;


namespace IndustrialElectricityCalculators;

public static class Extentions
{
    public static double PhaseCoefficient(this PowerSystem system)
    {
        if (system == PowerSystem.SinglePhase) return 1;
        return Sqrt(3);
    }

    public static IServiceCollection AddIndustrialElectricityCalculators(this IServiceCollection services)
    {
        return services.InstallCalculators(typeof(Extensions).Assembly);
    }
}