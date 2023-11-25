namespace Application.Tests.Distances.Converters;

using Application.Distances.Converters;
using FluentAssertions;
using Xunit;

public class ImperialConverterTests
{
    private readonly ImperialConverter _imperialConverter = new();


    [Theory]
    [InlineData(0, 0)]
    [InlineData(100, 62.14)]
    [InlineData(42.5, 26.41)]
    [InlineData(2.364, 1.47)]
    [InlineData(2.3, 1.43)]
    public void Convert_ShouldReturnCorrectRoundedDistance(double distanceInKm, double expectedDistanceInMiles)
    {
        // Act
        var convertedDistance = _imperialConverter.Convert(distanceInKm);

        // Assert
        convertedDistance.Should().Be(expectedDistanceInMiles);
    }
}