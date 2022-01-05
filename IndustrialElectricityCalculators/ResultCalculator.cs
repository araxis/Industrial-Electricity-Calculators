using CalculatorEngine;
using SimpleResult;

namespace IndustrialElectricityCalculators;

public interface IResultParam<T>:IParam<Result<T>> {}

public abstract class BaseCalculator<TParam, TResult> : SyncCalculator<TParam, Result<TResult>> where TParam : IParam<Result<TResult>>
{
    protected abstract override Result<TResult> Calc(TParam param);
}

