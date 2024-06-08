using Heroes.Model.Arena;
using Heroes.Model.Enum;
using Heroes.Model.Heroes;

namespace Heroes.Service;

public class ArenaService : IArenaService
{
    private readonly IBattleService _battleService;
    private readonly Dictionary<Guid, Arena> _arenas = new();
    private readonly Random _random = new();

    private readonly int _numberOfHeroTypes = Enum.GetNames(typeof(HeroType)).Length;

    public ArenaService(IBattleService battleService)
    {
        _battleService = battleService;
    }

    public Guid GenerateHeroes(int numberOfHeroes)
    {
        var arena = new Arena(_battleService);
        for (int i = 0; i < numberOfHeroes; i++)
        {
            var heroType = _random.Next(_numberOfHeroTypes);
            Hero hero;
            
            switch (heroType)
            {
                case 0:
                    hero = new Archer();
                    break;
                case 1:
                    hero = new Cavalry();
                    break;
                case 2:
                    hero = new Swordsman();
                    break;
                default:
                    throw new InvalidOperationException("Invalid hero type!");
            }
            
            arena.AddHero(hero);
        }
        _arenas[arena.Id] = arena;
        
        return arena.Id;
    }

    public List<string> BattleInArena(Guid arenaId)
    {
        if (!_arenas.TryGetValue(arenaId, out var arena))
        {
            return new List<string>{ "Nem létező aréna!" };
        }

        var history = new List<string>();
        
        while (!arena.HasWinner())
        {
            var result = arena.BattleRound();
            history.Add($"{history.Count + 1}. forduló: {result}");
        }

        history.Add(arena.Heroes.Count == 1
            ? $"{arena.Heroes.First().Name}<{arena.Heroes.First().Health}> dicsőséges győzelmet aratott!"
            : "Az utolsó csatát senki nem élte túl.");

        return history;
    }
}
