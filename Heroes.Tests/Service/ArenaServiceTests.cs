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
}