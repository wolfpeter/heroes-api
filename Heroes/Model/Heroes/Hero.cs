using Heroes.Model.Enum;

namespace Heroes.Model.Heroes;

public abstract class Hero
{
    public Guid Id { get; set; }
    public int Health { get; set; }
    public abstract HeroType Type { get; }
    public abstract int InitialHealth { get; }
    
    public Hero()
    {
        Id = Guid.NewGuid();
    }

    public bool IsAlive => Health > 0;

    public void Recover()
    {
        Health = Math.Min(Health + 10, InitialHealth);
    }

    public void ReduceHealth()
    {
        Health /= 2;
    }
}