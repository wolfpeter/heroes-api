using Heroes.Model.Heroes;

namespace Heroes.Service;

public interface IBattleService
{
    string Battle(Hero attacker, Hero defender);

    string ArcherAttack(Archer attacker, Hero defender);
    string CavalryAttack(Cavalry attacker, Hero defender);
    string SwordsmanAttack(Swordsman attacker, Hero defender);
}