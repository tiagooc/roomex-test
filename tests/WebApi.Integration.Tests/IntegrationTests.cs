namespace WebApi.Integration.Tests;

using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public IntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetDistance_WithValidDefaultsRequest_ReturnsOk()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/distances/53.297975/-6.372663/41.385101/-81.440440");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Be("{\"distance\":5536.34}");
    }
    
    [Fact]
    public async Task GetDistance_WithValidMetricRequest_ReturnsOk()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/distances/53.297975/-6.372663/41.385101/-81.440440?unit=0");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Be("{\"distance\":5536.34}");
    }

    [Fact]
    public async Task GetDistance_WithValidImperialRequest_ReturnsOk()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/distances/53.297975/-6.372663/41.385101/-81.440440?unit=1");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Be("{\"distance\":3440.13}");
    }

    [Fact]
    public async Task GetDistance_WithInvalidQuery_ReturnsBadRequest()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/distances/53.297975/-6.372663/41.385101/-81.440440?unit=12345");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}