using OptionsPattern.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPattern.Configuration;

namespace OptionsPattern.Controllers;

[ApiController]
public class PlayerController(
    IOptions<PlayerSettings> options, 
    IOptionsSnapshot<PlayerSettings> optionsSnapshot,
    IOptionsMonitor<PlayerSettings> optionsMonitor) : ControllerBase
{
    // IOptionsSnapshot and IOptionsMonitor have support for reloading configuration values
    // Differences:
    // IOptionsSnapshot is configured as a scoped service, which means it could be created once per HTTP request
    // IOptionsMonitor is configured as a singleton service, the current value is always the latest configuration value
    
    // options: IOptions was registered in Program.cs as a Singleton service when the application starts
    [HttpGet(ApiEndpoint.Players.Get)]
    [ProducesResponseType(typeof(IOptions<PlayerSettings>), StatusCodes.Status200OK)]
    public IActionResult GetPlayerSettings()
    {
        return Ok(options.Value);
    }

    [HttpGet(ApiEndpoint.Players.GetHealth)]
    [ProducesResponseType(typeof(IOptions<PlayerSettings>), StatusCodes.Status200OK)]
    public IActionResult GetPlayerHealthSettings()
    {
        return Ok(new { Health = options.Value.Health });
    }
    
    // optionsSnapshot: IOptionsSnapshot was registered as a Scoped service when the application starts
    [HttpGet(ApiEndpoint.Players.GetSnapshot)]
    [ProducesResponseType(typeof(IOptionsSnapshot<PlayerSettings>), StatusCodes.Status200OK)]
    public IActionResult GetPlayerSettingsSnapshot()
    {
        return Ok(optionsSnapshot.Value);
    }    
    
    // optionsMonitor: IOptionsMonitor was registered as a Singleton service when the application starts
    [HttpGet(ApiEndpoint.Players.GetMonitor)]
    [ProducesResponseType(typeof(IOptionsMonitor<PlayerSettings>), StatusCodes.Status200OK)]
    public IActionResult GetPlayerSettingsMonitor()
    {
        return Ok(optionsMonitor.CurrentValue);
    }  
}