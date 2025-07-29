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
    public async Task Should_Get_Todos(string route)
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
}