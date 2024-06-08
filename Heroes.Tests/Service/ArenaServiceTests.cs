using Heroes.Model.Arena;
using Heroes.Model.Heroes;
using Heroes.Service;

namespace Heroes.Tests.Service;

[TestClass]
public class ArenaServiceTests
{
    private BattleService _battleService;

    [TestInitialize]
    public void Setup()
    {
        _battleService = new BattleService();
    }
    
    [TestMethod]
    public void Arena_AddHero_IncreasesCount()
    {
        var arena = new Arena(_battleService);
        var hero = new Archer();

        arena.AddHero(hero);

        Assert.AreEqual(1, arena.Heroes.Count);
    }

    [TestMethod]
    public void Arena_Battle()
    {
        var arena = new Arena(_battleService);

        var cavalry = new Cavalry();
        var archer = new Archer();
        var swordsman = new Swordsman();
        
        arena.AddHero(cavalry);
        arena.AddHero(archer);
        arena.AddHero(swordsman);

        arena.BattleRound();
        
        var heroes = new List<Hero> { cavalry, archer, swordsman };
        int lessHealthCount = heroes.Count(hero => hero.Health < hero.InitialHealth);
        int equalHealthCount = heroes.Count(hero => hero.Health == hero.InitialHealth);

        Assert.AreEqual(2, lessHealthCount);
        Assert.AreEqual(1, equalHealthCount);
    }
}