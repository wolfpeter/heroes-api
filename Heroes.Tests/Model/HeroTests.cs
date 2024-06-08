using Heroes.Model.Enum;
using Heroes.Model.Heroes;

namespace Heroes.Tests.Model;

[TestClass]
public class HeroTests
{
    [TestMethod]
    public void Hero_Initialization_Archer()
    {
        var archer = new Archer();
        
        Assert.IsTrue(!string.IsNullOrEmpty(archer.Name));
        Assert.AreEqual(HeroType.Archer, archer.Type);
        Assert.AreEqual(100, archer.Health);
    }
}