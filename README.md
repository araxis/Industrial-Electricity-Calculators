# Industrial-Electricity-Calculators
[![.NET](https://github.com/araxis/Industrial-Electricity-Calculators/actions/workflows/dotnet.yml/badge.svg)](https://github.com/araxis/Industrial-Electricity-Calculators/actions/workflows/dotnet.yml)
[![NuGet](https://img.shields.io/nuget/vpre/Arax.Calculators.IEC.svg)](https://www.nuget.org/packages/Arax.Calculators.IEC)
[![NuGet](https://img.shields.io/nuget/dt/Arax.Calculators.IEC.svg)](https://www.nuget.org/packages/Arax.Calculators.IEC) 

this library contains Industrial Electricity related calculators.

it is implemented based on [CalculatorEngine](https://github.com/araxis/CalculatorEngine).

### Installing IEC

You should install [IEC with NuGet](https://www.nuget.org/packages/Arax.Calculators.IEC):

    Install-Package Arax.Calculators.IEC
    
Or via the .NET Core command line interface:

    dotnet add package Arax.Calculators.IEC

## Add to ServiceCollection

```csharp
   //add CalcEngine
   builder.Services.AddCalculator();

   //to add calculators 
   builder.Services.AddIndustrialElectricityCalculators();
```
## Use: inject ICalcEngine & use
 ```csharp
  private readonly ICalcEngine _calcEngine;
  ...
    private async Task<Result<Current>> CalcCurrent()
    {
        var power = 12.W();
        var voltage = 415;
        var cosPhi = .9;
        var efficiency = 90;
        var powerSystem = PowerSystem.ThreePhase;
        return await _calcEngine.CalcCurrent(power, voltage, cosPhi, efficiency, powerSystem);
    }
 ```
## Calculators

*   Active Power ( x4 )
*   Apparent Power ( x3 )
*   Reactive Power ( x2 )
*   Current ( x2 )
*   Voltage ( x3)
