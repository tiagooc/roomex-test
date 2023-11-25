namespace Application.Distances.Calculators;

public interface IDistanceCalculatorFactory
{
    IDistanceCalculator Create(Method method);
}