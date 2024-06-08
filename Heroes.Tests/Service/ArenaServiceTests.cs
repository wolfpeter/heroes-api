using Heroes.Model.Arena;
using Heroes.Model.Heroes;

namespace Heroes.Tests.Service;

[TestClass]
public class ArenaServiceTests
{
    [TestMethod]
    public void Arena_AddHero_IncreasesCount()
    {
        var arena = new Arena();
        var hero = new Archer();

        arena.AddHero(hero);

        Assert.AreEqual(1, arena.Heroes.Count);
    }
}