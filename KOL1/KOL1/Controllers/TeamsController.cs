using KOL1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KOL1.Controllers;

[Route("api/teams")]
[ApiController]
public class TeamsController : ControllerBase
{
    private ITeamsRepository _teamsRepository;

    public TeamsController(ITeamsRepository teamsRepository)
    {
        _teamsRepository = teamsRepository;
    }

    [HttpGet("{idChampionship:int}")]
    public IActionResult GetTeams(int idChampionship)
    {
        return Ok(_teamsRepository.GetTeams(idChampionship));
    }
    
    [HttpPut]
    public IActionResult AddPlayerToTeam(int idPlayer, int idTeam)
    {
        //var affectedCount = _teamsRepository.AddPlayerToTeam(idPlayer, idTeam);
        //return StatusCode(StatusCodes.Status204NoContent);
        return Ok("Rows affected: " + _teamsRepository.AddPlayerToTeam(idPlayer, idTeam));
    }
}