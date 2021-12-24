namespace IndustrialElectricityCalculators;

public class WrongParametersException : Exception
{
    public WrongParametersException():base()
    {
        
    }
    public WrongParametersException(string message) : base(message)
    {
    }
}