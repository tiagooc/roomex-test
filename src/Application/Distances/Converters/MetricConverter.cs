namespace Application.Distances.Converters;

public class MetricConverter : IDistanceUnitConverter
{
    public double Convert(double distance)
    {
        // Distance already in km
        return Math.Ceiling(distance * 100) / 100;
    }
}