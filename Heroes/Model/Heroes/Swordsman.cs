using Heroes.Model.Enum;

namespace Heroes.Model.Heroes;

public class Swordsman : Hero
{
    public override HeroType Type => HeroType.Swordsman;
    public override int InitialHealth => 120;

    public Swordsman()
    {
        Health = InitialHealth;
    }
}