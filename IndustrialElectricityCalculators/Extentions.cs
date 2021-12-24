using IndustrialElectricityUnits;
using static System.Math;
namespace IndustrialElectricityCalculators;

public static class Extentions
{
    public static double PhaseCoefficient(this PowerSystem system)
    {
        if (system == PowerSystem.SinglePhase) return 1;
        return Sqrt(3);
    }
}