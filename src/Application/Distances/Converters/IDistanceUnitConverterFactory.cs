namespace Application.Distances.Converters;

public interface IDistanceUnitConverterFactory
{
    IDistanceUnitConverter Create(Unit unit);
}