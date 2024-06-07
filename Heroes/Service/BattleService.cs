using Heroes.Model.Heroes;

namespace Heroes.Service;

public class BattleService : IBattleService
{
    private readonly Random _random = new Random();
    
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
            return $"{attacker.Name}({attacker.Type}) => {defender.Name}({defender.Type}): {defender.Name} meghalt.";
        }
        
        if (defender is Cavalry)
        {
            if (_random.NextDouble() <= 0.4)
            {
                defender.Health = 0;
                return $"{attacker.Name}({attacker.Type}) => {defender.Name}({defender.Type}): {defender.Name} meghalt.";
            }
            else
            {
                return $"{attacker.Name}({attacker.Type}) => {defender.Name}({defender.Type}): {defender.Name} jól védekezett.";
            }
        }
        
        if (defender is Swordsman)
        {
            defender.Health = 0;
            return $"{attacker.Name}({attacker.Type}) => {defender.Name}({defender.Type}): {defender.Name} meghalt.";
        }
        
        return "Érvénytelen támadás!";
    }

    public string CavalryAttack(Cavalry attacker, Hero defender)
    {
        if (defender is Archer or Swordsman or Cavalry)
        {
            defender.Health = 0;
            return $"{attacker.Name}({attacker.Type}) => {defender.Name}({defender.Type}): {defender.Name} meghalt.";
        }
        
        return "Érvénytelen támadás!";
    }

    public string SwordsmanAttack(Swordsman attacker, Hero defender)
    {
        if (defender is Archer or Swordsman)
        {
            defender.Health = 0;
            return $"{attacker.Name}({attacker.Type}) => {defender.Name}({defender.Type}): {defender.Name} meghalt.";
        }
        
        if (defender is Cavalry)
        {
            return $"{attacker.Name}({attacker.Type}) => {defender.Name}({defender.Type}). {defender.Name} lóháton gyorsabb volt.";
        }
        
        return "Érvénytelen támadás!";
    }
}