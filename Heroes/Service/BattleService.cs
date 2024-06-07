using Heroes.Model.Heroes;

namespace Heroes.Service;

public class BattleService : IBattleService
{
    private Random _random = new Random();
    
    public string Battle(Hero attacker, Hero defender)
    {
        return attacker switch
        {
            Archer archer => ArcherAttack(archer, defender),
            Cavalry cavalry => CavalryAttack(cavalry, defender),
            Swordsman swordsman => SwordsmanAttack(swordsman, defender),
            _ => "No battle..."
        };
    }

    public string ArcherAttack(Archer attacker, Hero defender)
    {
        if (defender is Archer)
        {
            defender.Health = 0;
            return $"{attacker.Type} => {defender.Type}. {defender.Type} meghalt.";
        }
        
        if (defender is Cavalry)
        {
            if (_random.NextDouble() <= 0.4)
            {
                defender.Health = 0;
                return $"{attacker.Type} => {defender.Type}. {defender.Type} meghalt.";
            }
            else
            {
                return $"{attacker.Type} => {defender.Type}. {defender.Type} jól védekezett.";
            }
        }
        
        if (defender is Swordsman)
        {
            defender.Health = 0;
            return $"{attacker.Type} => {defender.Type}. {defender.Type} meghalt.";
        }
        
        return "Érvénytelen támadás!";
    }

    public string CavalryAttack(Cavalry attacker, Hero defender)
    {
        if (defender is Archer or Swordsman or Cavalry)
        {
            defender.Health = 0;
            return $"{attacker.Type} => {defender.Type}. {defender.Type} meghalt.";
        }
        
        return "Érvénytelen támadás!";
    }

    public string SwordsmanAttack(Swordsman attacker, Hero defender)
    {
        if (defender is Archer or Swordsman)
        {
            defender.Health = 0;
            return $"{attacker.Type} => {defender.Type}. {defender.Type} meghalt.";
        }
        
        if (defender is Cavalry)
        {
            return $"{attacker.Type} => {defender.Type}. Nem történt semmi.";
        }
        
        return "Érvénytelen támadás!";
    }
}