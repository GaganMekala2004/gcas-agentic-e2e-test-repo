using Microsoft.AspNetCore.Mvc;

namespace GcasE2ETestApi;

[ApiController]
[Route("api/search")]
public sealed class SearchController : ControllerBase
{
    [HttpGet]
    [Produces("text/html")]
    public ContentResult Search([FromQuery] string q)
    {
        // Intentionally vulnerable: user input is reflected without encoding.
        return Content($"<html><body><h1>Search results for {q}</h1></body></html>", "text/html");
    }
}
