using Heroes.Model.Enum;

namespace Heroes.Model.Heroes;

public class Archer : Hero
{
    public override HeroType Type => HeroType.Archer;
    public override int InitialHealth => 100;

    public Archer()
    {
        Health = InitialHealth;
    }
}