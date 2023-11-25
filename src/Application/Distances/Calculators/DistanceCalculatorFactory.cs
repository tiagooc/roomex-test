namespace Application.Distances.Calculators;

public class DistanceCalculatorFactory : IDistanceCalculatorFactory
{
    public IDistanceCalculator Create(Method method)
    {
        return method switch
        {
            Method.Geodesic => new GeodesicDistanceCalculator(),
            _ => new GeodesicDistanceCalculator()
        };
    }
}