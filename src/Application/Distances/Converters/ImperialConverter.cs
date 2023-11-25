namespace Application.Distances.Converters;

public class ImperialConverter : IDistanceUnitConverter
{
    public double Convert(double distance)
    {
        // 1 kilometer = 0.621371192 miles
        return Math.Ceiling(distance * 0.621371192 * 100) / 100;
    }
}