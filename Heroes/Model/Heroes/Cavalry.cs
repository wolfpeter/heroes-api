using Heroes.Model.Enum;

namespace Heroes.Model.Heroes;

public class Cavalry : Hero
{
    public override HeroType Type => HeroType.Cavalry;
    public override int InitialHealth => 150;

    public Cavalry()
    {
        Health = InitialHealth;
    }
}