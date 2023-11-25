namespace Application.Distances.Queries;

using Calculators;
using Converters;
using MediatR;

public class GetDistanceQueryHandler : IRequestHandler<GetDistanceQuery, double>
{
    private readonly IDistanceCalculatorFactory _distanceCalculatorFactory;
    private readonly IDistanceUnitConverterFactory _distanceUnitConverterFactory;

    public GetDistanceQueryHandler(
        IDistanceCalculatorFactory distanceCalculatorFactory,
        IDistanceUnitConverterFactory distanceUnitConverterFactory)
    {
        _distanceCalculatorFactory = distanceCalculatorFactory;
        _distanceUnitConverterFactory = distanceUnitConverterFactory;
    }

    public Task<double> Handle(GetDistanceQuery request, CancellationToken cancellationToken)
    {
        var distanceCalculator = _distanceCalculatorFactory.Create(request.Method);

        var distance = distanceCalculator.GetDistance(request.PointA, request.PointB);

        var distanceUnitConverter = _distanceUnitConverterFactory.Create(request.Unit);

        var convertedDistance = distanceUnitConverter.Convert(distance);

        return Task.FromResult(convertedDistance);
    }
}