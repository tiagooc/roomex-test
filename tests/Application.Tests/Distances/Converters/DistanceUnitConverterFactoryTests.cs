namespace Application.Tests.Distances.Converters;

using Application.Distances;
using Application.Distances.Converters;
using FluentAssertions;
using Xunit;

public class DistanceUnitConverterFactoryTests
{
    private readonly DistanceUnitConverterFactory _converterFactory = new();

    [Theory]
    [InlineData(Unit.Metric, typeof(MetricConverter))]
    [InlineData(Unit.Imperial, typeof(ImperialConverter))]
    public void Create_ShouldReturnCorrectConverter(Unit unit, Type expectedConverterType)
    {
        // Act
        var converter = _converterFactory.Create(unit);

        // Assert
        converter.Should().BeOfType(expectedConverterType);
    }

    [Fact]
    public void Create_UnknownUnit_ShouldThrowArgumentException()
    {
        // Arrange
        const Unit unknownUnit = (Unit)123456;

        // Act & Assert
        _converterFactory
            .Invoking(factory => factory.Create(unknownUnit))
            .Should().Throw<ArgumentException>()
            .WithMessage("Invalid unit specified");
    }
}