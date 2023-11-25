namespace Application.Tests.Distances.Calculators;

using Application.Distances;
using Application.Distances.Calculators;
using FluentAssertions;
using Xunit;

public class GeodesicDistanceCalculatorTests
{
    [Fact]
    public void GetDistance_SamePoint_ShouldReturnZero()
    {
        // Arrange
        var calculator = new GeodesicDistanceCalculator();
        var point = new Point(0, 0);

        // Act
        var distance = calculator.GetDistance(point, point);

        // Assert
        distance.Should().Be(0);
    }

    [Theory]
    [InlineData(0, 0, 1, 1, 157.2493812719255)]
    [InlineData(53.30, -6.40, 41.40, -81.40, 5530.9080739127685)]
    [InlineData(25, 25, 30, -30, 5402.466879761687)]
    public void GetDistance_DifferentPoints_ShouldCalculateDistance(
        double latitudeA,
        double longitudeA,
        double latitudeB,
        double longitudeB,
        double expectedDistance)
    {
        // Arrange
        var calculator = new GeodesicDistanceCalculator();
        var pointA = new Point(latitudeA, longitudeA);
        var pointB = new Point(latitudeB, longitudeB);

        // Act
        var distance = calculator.GetDistance(pointA, pointB);

        // Assert
        distance.Should().Be(expectedDistance);
    }
}