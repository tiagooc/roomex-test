namespace Application.Distances;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class Point
{
    public readonly double Latitude;

    public readonly double Longitude;

    public Point(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}