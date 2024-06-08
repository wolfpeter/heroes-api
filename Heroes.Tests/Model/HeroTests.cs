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
    
    [TestMethod]
    public void Hero_Initialization_Cavalry()
    {
        var calvary = new Cavalry();
        
        Assert.IsTrue(!string.IsNullOrEmpty(calvary.Name));
        Assert.AreEqual(HeroType.Cavalry, calvary.Type);
        Assert.AreEqual(150, calvary.Health);
    }
    
    [TestMethod]
    public void Hero_Initialization_Swordsman()
    {
        var swordsman = new Swordsman();
        
        Assert.IsTrue(!string.IsNullOrEmpty(swordsman.Name));
        Assert.AreEqual(HeroType.Swordsman, swordsman.Type);
        Assert.AreEqual(120, swordsman.Health);
    }
}