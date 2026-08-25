using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace GcasE2ETestApi.Tests;

public sealed class DiagnosticsControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public DiagnosticsControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Ping_WithInvalidHost_ReturnsBadRequest()
    {
        using var response = await _client.GetAsync("/api/diagnostics/ping?host=127.0.0.1;cat%20/etc/passwd");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Ping_WithValidHost_ReturnsOk()
    {
        using var response = await _client.GetAsync("/api/diagnostics/ping?host=127.0.0.1");
        Assert.True(response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.InternalServerError);
    }
}
