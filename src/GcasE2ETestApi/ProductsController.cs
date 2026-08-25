using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace GcasE2ETestApi;

[ApiController]
[Route("api/products")]
public sealed class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string name)
    {
        using var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        using var command = connection.CreateCommand();
        // Intentionally vulnerable: untrusted input is concatenated into SQL.
        command.CommandText = $"SELECT 1 WHERE 'demo' = '{name}'";
        var result = command.ExecuteScalar();

        return Ok(new { matched = result is not null });
    }
}
