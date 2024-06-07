using Heroes.Service;
using Microsoft.AspNetCore.Mvc;

namespace Heroes.Controller;

[ApiController]
[Route("api/[controller]")]
public class ArenaController : ControllerBase
{
    private readonly IArenaService _arenaService;
    private readonly IBattleService _battleService;

    public ArenaController(IArenaService arenaService, IBattleService battleService)
    {
        _arenaService = arenaService;
        _battleService = battleService;
    }

    [HttpPost("generate")]
    public IActionResult GenerateHeroes([FromQuery] int numberOfHeroes)
    {
        return Ok(_arenaService.GenerateHeroes(numberOfHeroes));
    }

    [HttpPost("battle/{arenaId}")]
    public IActionResult Battle(Guid arenaId)
    {
        return Ok(_arenaService.BattleInArena(arenaId, _battleService));
    }
}