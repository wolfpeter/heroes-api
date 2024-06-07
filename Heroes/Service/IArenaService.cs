namespace Heroes.Service;

public interface IArenaService
{
    Guid GenerateHeroes(int numberOfHeroes);
    List<string> BattleInArena(Guid arenaId, IBattleService battleService);
}