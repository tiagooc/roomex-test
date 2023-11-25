namespace Application.Tests.Distances.Queries;

using Application.Distances;
using Application.Distances.Calculators;
using Application.Distances.Converters;
using Application.Distances.Queries;
using FluentAssertions;
using Moq;
using Xunit;

public class GetDistanceQueryHandlerTests
{
    [Fact]
    public async Task Handle_ValidQueryWithMetric_ShouldReturnCorrectConvertedDistance()
    {
        // Arrange
        const double expectedDistance = 123.45;
        const double expectedConvertedDistance = 76.708;

        var distanceCalculatorMock = new Mock<IDistanceCalculator>();
        distanceCalculatorMock
            .Setup(x => x.GetDistance(It.IsAny<Point>(), It.IsAny<Point>()))
            .Returns(expectedDistance);

        var distanceCalculatorFactoryMock = new Mock<IDistanceCalculatorFactory>();
        distanceCalculatorFactoryMock
            .Setup(x => x.Create(It.IsAny<Method>()))
            .Returns(distanceCalculatorMock.Object);

        var distanceUnitConverterMock = new Mock<IDistanceUnitConverter>();
        distanceUnitConverterMock
            .Setup(x => x.Convert(expectedDistance)).Returns(expectedConvertedDistance);

        var distanceUnitConverterFactoryMock = new Mock<IDistanceUnitConverterFactory>();
        distanceUnitConverterFactoryMock
            .Setup(factory => factory.Create(It.IsAny<Unit>()))
            .Returns(distanceUnitConverterMock.Object);

        var handler = new GetDistanceQueryHandler(
            distanceCalculatorFactoryMock.Object,
            distanceUnitConverterFactoryMock.Object);

        var query = new GetDistanceQuery(
            new Point(0, 0),
            new Point(1, 1),
            Method.Geodesic,
            Unit.Metric);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().Be(expectedConvertedDistance);
        distanceCalculatorMock
            .Verify(calculator => calculator.GetDistance(query.PointA, query.PointB), Times.Once);
        distanceUnitConverterMock
            .Verify(converter => converter.Convert(It.IsAny<double>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ValidQueryWithImperial_ShouldReturnCorrectDistance()
    {
        // Arrange
        const double expectedDistance = 123.45;

        var distanceCalculatorMock = new Mock<IDistanceCalculator>();
        distanceCalculatorMock
            .Setup(x => x.GetDistance(It.IsAny<Point>(), It.IsAny<Point>()))
            .Returns(expectedDistance);

        var distanceCalculatorFactoryMock = new Mock<IDistanceCalculatorFactory>();
        distanceCalculatorFactoryMock
            .Setup(x => x.Create(It.IsAny<Method>()))
            .Returns(distanceCalculatorMock.Object);

        var distanceUnitConverterMock = new Mock<IDistanceUnitConverter>();
        distanceUnitConverterMock
            .Setup(x => x.Convert(expectedDistance))
            .Returns(expectedDistance);

        var distanceUnitConverterFactoryMock = new Mock<IDistanceUnitConverterFactory>();
        distanceUnitConverterFactoryMock
            .Setup(factory => factory.Create(It.IsAny<Unit>()))
            .Returns(distanceUnitConverterMock.Object);

        var handler = new GetDistanceQueryHandler(
            distanceCalculatorFactoryMock.Object,
            distanceUnitConverterFactoryMock.Object);

        var query = new GetDistanceQuery(
            new Point(0, 0),
            new Point(1, 1),
            Method.Geodesic,
            Unit.Imperial);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().Be(expectedDistance);
        distanceCalculatorMock
            .Verify(calculator => calculator.GetDistance(query.PointA, query.PointB), Times.Once);
        distanceUnitConverterMock
            .Verify(converter => converter.Convert(It.IsAny<double>()), Times.Once);
    }
}