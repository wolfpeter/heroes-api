using Heroes.Model.Heroes;
using Heroes.Service;

namespace Heroes.Model.Arena;

public class Arena
{
    public Guid Id { get; set; }
    public List<Hero> Heroes { get; set; }
    
    private readonly Random _random = new Random();

    public Arena()
    {
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

    public string BattleRound(IBattleService battleService)
    {
        var attacker = GetRandomHero();
        var defender = GetRandomHero();

        while (attacker == defender)
        {
            attacker = GetRandomHero();
            defender = GetRandomHero();
        }

        var battleResult = battleService.Battle(attacker, defender);

        attacker.ReduceHealth();
        defender.ReduceHealth();

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