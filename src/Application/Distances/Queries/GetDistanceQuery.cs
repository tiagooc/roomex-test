namespace Application.Distances.Queries;

using System.Diagnostics.CodeAnalysis;
using MediatR;
using Unit = Unit;

[ExcludeFromCodeCoverage]
public class GetDistanceQuery : IRequest<double>
{
    public Point PointA { get; set; }

    public Point PointB { get; set; }

    public Method Method { get; set; }

    public Unit Unit { get; set; }

    public GetDistanceQuery(
        Point pointA,
        Point pointB,
        Method method,
        Unit unit)
    {
        PointA = pointA;
        PointB = pointB;
        Method = method;
        Unit = unit;
    }
}