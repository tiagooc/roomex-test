namespace Application.Distances.Converters;

public class DistanceUnitConverterFactory : IDistanceUnitConverterFactory
{
    public IDistanceUnitConverter Create(Unit unit)
    {
        return unit switch
        {
            Unit.Metric => new MetricConverter(),
            Unit.Imperial => new ImperialConverter(),
            _ => throw new ArgumentException("Invalid unit specified")
        };
    }
}