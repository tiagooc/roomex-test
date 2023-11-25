namespace Application.Tests.Distances.Converters;

using Application.Distances.Converters;
using FluentAssertions;
using Xunit;

public class MetricConverterTests
{
    private readonly MetricConverter _metricConverter = new();

    [Theory]
    [InlineData(0, 0)]
    [InlineData(100, 100)]
    [InlineData(42.5, 42.5)]
    [InlineData(2.364, 2.37)]
    [InlineData(2.3, 2.3)]
    public void Convert_ShouldReturnCorrectDistanceInMiles(double distanceInKm, double expectedDistanceInMiles)
    {
        // Act
        var convertedDistance = _metricConverter.Convert(distanceInKm);

        // Assert
        convertedDistance.Should().Be(expectedDistanceInMiles);
    }
}