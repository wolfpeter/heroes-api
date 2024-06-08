using Heroes.Model.Heroes;
using Heroes.Service;

namespace Heroes.Model.Arena;

public class Arena
{
    public Guid Id { get; set; }
    public List<Hero> Heroes { get; set; }
    
    private readonly IBattleService _battleService;
    private readonly Random _random = new Random();

    public Arena(IBattleService battleService)
    {
        _battleService = battleService;
        Id = Guid.NewGuid();
        Heroes = new List<Hero>();
    }

    public void AddHero(Hero hero)
    {
        Heroes.Add(hero);
    }

    public Hero GetRandomHero()
    {
        return Heroes[_random.Next(Heroes.Count)];
    }

    public string BattleRound()
    {
        var attacker = GetRandomHero();
        var defender = GetRandomHero();

        while (attacker == defender)
        {
            attacker = GetRandomHero();
            defender = GetRandomHero();
        }

        var battleResult = _battleService.Battle(attacker, defender);

        attacker.ReduceHealth();
        defender.ReduceHealth();

        battleResult += $" Életerők a csata után: {attacker.Name} <{attacker.Health}>, {defender.Name} <{defender.Health}>";

        foreach (var hero in Heroes.Where(h => h != attacker && h != defender))
        {
            hero.Recover();
        }

        Heroes.RemoveAll(h => h.Health < h.InitialHealth / 4);

        return battleResult;
    }

    public bool HasWinner()
    {
        return Heroes.Count <= 1;
    }
}