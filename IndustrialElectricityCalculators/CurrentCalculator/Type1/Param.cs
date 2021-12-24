using Ardalis.GuardClauses;
using CalculatorEngine;
using IndustrialElectricityUnits;

namespace IndustrialElectricityCalculators.CurrentCalculator.Type1;

public record Param : IParam<Current>
{
    private readonly Power _power ;
    private readonly Voltage _voltage ;
    private readonly CosPhi _cosPhi ;
    private readonly Efficiency _efficiency ;
    private readonly PowerSystem _system;

    public Param(Power power, Voltage voltage, CosPhi cosPhi, Efficiency efficiency, PowerSystem system)
    {
        _power = Guard.Against.Null(power,nameof(power));
        _voltage = Guard.Against.Null(voltage,nameof(voltage));
        _cosPhi = Guard.Against.Null(cosPhi,nameof(cosPhi));
        _efficiency = Guard.Against.Null(efficiency,nameof(Efficiency));
        _system = Guard.Against.Null(system,nameof(system));
    }

    public Power Power
    {
        get => _power;
        init => _power = Guard.Against.Null(value,nameof(Power));
    }

    public Voltage Voltage
    {
        get => _voltage;
        init => _voltage = Guard.Against.Null(value,nameof(Voltage));
    }

    public CosPhi CosPhi
    {
        get => _cosPhi;
        init => _cosPhi = Guard.Against.Null(value,nameof(CosPhi));
    }

    public Efficiency Efficiency
    {
        get => _efficiency;
        init => _efficiency = Guard.Against.Null(value,nameof(Efficiency));
    }

    public PowerSystem System
    {
        get => _system;
        init => _system = Guard.Against.Null(value,nameof(System));
    }

    public void Deconstruct(out Power power, out Voltage voltage, out CosPhi cosPhi, out Efficiency efficiency, out PowerSystem system)
    {
        power = _power;
        voltage = _voltage;
        cosPhi = _cosPhi;
        efficiency = _efficiency;
        system = _system;
    }
}