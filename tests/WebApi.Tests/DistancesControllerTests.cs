namespace WebApi.Tests;

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Distances;
using Application.Distances.Queries;
using Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class DistancesControllerTests
{
    [Fact]
    public async Task GetDistance_ValidInput_ShouldReturnOkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var loggerMock = new Mock<ILogger<DistancesController>>();

        var controller = new DistancesController(mediatorMock.Object, loggerMock.Object);

        // Act
        var result = await controller.GetDistance(
            0,
            0,
            1,
            1,
            null,
            null,
            CancellationToken.None);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult?.Value.Should().NotBeNull();
        okResult?.Value.Should().BeAssignableTo<DistanceDto>();
    }

    [Fact]
    public async Task GetDistance_WhenExceptionThrown_ShouldReturnInternalServerErrorResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        mediatorMock
            .Setup(m => m.Send(
                It.IsAny<GetDistanceQuery>(),
                It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Dummy exception"));

        var loggerMock = new Mock<ILogger<DistancesController>>();

        var controller = new DistancesController(mediatorMock.Object, loggerMock.Object);

        // Act
        var result = await controller.GetDistance(
            0,
            0,
            1,
            1,
            null,
            null,
            CancellationToken.None);

        // Assert
        result.Should().BeOfType<StatusCodeResult>();
        var objectResult = result as StatusCodeResult;
        objectResult?.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
    }
}