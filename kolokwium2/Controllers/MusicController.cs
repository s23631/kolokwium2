using kolokwium2.DAL;
using kolokwium2.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MusicController : ControllerBase
{
    private readonly DbService _dbService;

    public MusicController(DbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public IActionResult GetMusician(int id)
    {
        var artist = _dbService.GetMusician(id);
        return Ok(artist);
    }
    
    [HttpDelete]
    public IActionResult DeleteMusician(int id)
    {
        try
        {
            _dbService.DeleteMusician(id);
            return Ok();
            
        } catch (NotOnAlbumException e)
        {
            return BadRequest(e.Message);
        }
    }
}