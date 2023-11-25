namespace Application.Distances;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class DistanceDto
{
    public double Distance { get; set; }

    public DistanceDto(double distance)
    {
        Distance = distance;
    }
}