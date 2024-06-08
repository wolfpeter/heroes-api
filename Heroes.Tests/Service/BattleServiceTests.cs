using Heroes.Model.Heroes;
using Heroes.Service;

namespace Heroes.Tests.Service;

[TestClass]
public class BattleServiceTests
{
    private BattleService _battleService;
    
    [TestInitialize]
    public void Setup()
    {
        _battleService = new BattleService();
    }
    
    [TestMethod]
    public void Archer_Attacks_Archer_Kills_Defender()
    {
        var attacker = new Archer();
        var defender = new Archer();

        var result = _battleService.Battle(attacker, defender);

        Assert.AreEqual(0, defender.Health, "Defender should have 0 health.");
        Assert.IsTrue(result.Contains("meghalt"), "Result should indicate that defender died.");
    }
}