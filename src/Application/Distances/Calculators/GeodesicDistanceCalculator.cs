namespace Application.Distances.Calculators;

public class GeodesicDistanceCalculator : IDistanceCalculator
{
    private const double EarthRadiusKm = 6371.0;

    public double GetDistance(Point pointA, Point pointB)
    {
        var a = ToRadians(90 - pointB.Latitude);
        var b = ToRadians(90 - pointA.Latitude);
        var delta = ToRadians(pointA.Longitude - pointB.Longitude);

        var cosP = Math.Cos(a) * Math.Cos(b) + Math.Sin(a) * Math.Sin(b) * Math.Cos(delta);
        var distance = EarthRadiusKm * Math.Acos(cosP);

        return distance;
    }

    private static double ToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }
}