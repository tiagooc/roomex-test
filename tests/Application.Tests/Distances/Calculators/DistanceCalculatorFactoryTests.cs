namespace Application.Tests.Distances.Calculators;

using Application.Distances;
using Application.Distances.Calculators;
using FluentAssertions;
using Xunit;

public class DistanceCalculatorFactoryTests
{
    [Fact]
    public void Create_GeodesicMethod_ShouldReturnGeodesicDistanceCalculator()
    {
        // Arrange
        var factory = new DistanceCalculatorFactory();

        // Act
        var calculator = factory.Create(Method.Geodesic);

        // Assert
        calculator.Should().BeOfType<GeodesicDistanceCalculator>();
    }

    [Fact]
    public void Create_UnknownMethod_ShouldReturnGeodesicDistanceCalculator()
    {
        // Arrange
        const int dummyEnumIndex = 12345;
        var factory = new DistanceCalculatorFactory();

        // Act
        var calculator = factory.Create((Method)dummyEnumIndex);

        // Assert
        calculator.Should().BeOfType<GeodesicDistanceCalculator>();
    }
}