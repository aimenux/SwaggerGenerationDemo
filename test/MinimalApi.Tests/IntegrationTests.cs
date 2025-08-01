using System.Net;
using AwesomeAssertions;
using ControllerApi.Tests;

namespace MinimalApi.Tests;

public class IntegrationTests
{
    [Theory]
    [InlineData("api/v1/todos")]
    [InlineData("api/v1/todos?category=sports")]
    [InlineData("api/v1/todos?category=health")]
    [InlineData("api/v2/todos")]
    [InlineData("api/v2/todos?category=sports")]
    [InlineData("api/v2/todos?category=health")]
    public async Task Should_Get_Todos_Returns_200(string route)
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData("api/v2/todos/1")]
    [InlineData("api/v2/todos/2")]
    public async Task Should_Get_Todo_Returns_200(string route)
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData("api/v1/todos/1")]
    [InlineData("api/v1/todos/2")]
    public async Task Should_Get_Todo_Returns_404(string route)
    {
        // arrange
        await using var fixture = new IntegrationTestsFactory();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        responseBody.Should().BeNullOrWhiteSpace();
    }
}