namespace Application.Distances.Calculators;

public interface IDistanceCalculator
{
    double GetDistance(Point pointA, Point pointB);
}