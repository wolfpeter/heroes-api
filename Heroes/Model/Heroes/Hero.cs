using Heroes.Model.Enum;

namespace Heroes.Model.Heroes;

public abstract class Hero
{
    private List<string> Names =
    [
        "Ádám", "Balázs", "Csaba", "Dávid", "Eszter", "Ferenc", "Gábor", "Hanna", "István", "János",
        "Katalin", "László", "Mária", "Norbert", "Olga", "Péter", "Róbert", "Szilvia", "Tamás", "Zoltán"
    ];
    
    private Random _random = new Random();
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public abstract HeroType Type { get; }
    public abstract int InitialHealth { get; }

    protected Hero()
    {
        Id = Guid.NewGuid();
        Name = Names[_random.Next(Names.Count)];;
    }

    public void Recover()
    {
        Health = Math.Min(Health + 10, InitialHealth);
    }

    public void ReduceHealth()
    {
        Health /= 2;
    }
}