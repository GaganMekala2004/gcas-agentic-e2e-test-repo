using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GcasE2ETestApi;

[ApiController]
[Route("api/diagnostics")]
public sealed class DiagnosticsController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping([FromQuery] string host)
    {
        if (string.IsNullOrWhiteSpace(host) ||
            (!System.Net.IPAddress.TryParse(host, out _) && Uri.CheckHostName(host) != UriHostNameType.Dns))
        {
            return BadRequest("Invalid host target");
        }

        var startInfo = new ProcessStartInfo
        {
            FileName = "ping",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        startInfo.ArgumentList.Add("-c");
        startInfo.ArgumentList.Add("1");
        startInfo.ArgumentList.Add(host);

        using var process = Process.Start(startInfo);
        var output = process?.StandardOutput.ReadToEnd() ?? string.Empty;
        process?.WaitForExit();

        return Ok(new { output });
    }
}
