using Microsoft.AspNetCore.Mvc.Testing;

namespace GcasE2ETestApi.Tests;

public sealed class HealthTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public HealthTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Health_endpoint_returns_ok()
    {
        using var response = await _client.GetAsync("/api/health");
        response.EnsureSuccessStatusCode();
    }
}
