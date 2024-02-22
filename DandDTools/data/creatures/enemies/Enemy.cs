using System.Diagnostics.CodeAnalysis;
public class Enemy: Creature {
    public required float Challenge { get; init; }
    int maxAttackEnergy = 0;

    public int AttackEnergy { get; set; }

    [SetsRequiredMembers]
    public Enemy(
        string name,
        int hp,
        int ac,
        int speed,
        CreatureSize size,
        CreatureType type,
        StatData stats,
        StatData savingThrows,
        float challenge,
        Dictionary<SenseType, int> senses,
        List<LanguageType> languages,
        List<DamageType> resistances = null,
        List<DamageType> immunites = null,
        List<Conditions> conditionImmunities = null,
        List<PassiveAbilityList.PassiveAbility> passiveAbilities = null,
        Dictionary<Weapon,int> attacks = null,
        int attackEnergy = 0
    ):base(
        name: name,
        hp: hp,
        ac:ac,
        speed: speed,
        size: size,
        type: type,
        stats: stats,
        savingThrows: savingThrows,
        senses: senses,
        languages: languages,
        resistances: resistances,
        immunites: immunites,
        conditionImmunities: conditionImmunities,
        passiveAbilities: passiveAbilities,
        attacks: attacks
        ) {
        Challenge = challenge;
        maxAttackEnergy = attackEnergy;
        AttackEnergy = attackEnergy;
    }
    public void Attack(int index) {
        Weapon weapon = weapons[index];
        if(!Attacks.ContainsKey(weapon)) throw new ArgumentException($"{Name} cannot use weapon {weapon}, {Name} does not have that weapon!");
        if(AttackEnergy < Attacks[weapon]) {
            Console.WriteLine("Cannot attack, out of energy!");
            return;
        }
        AttackEnergy -= Attacks[weapon];
        List<(DamageType type, int count)> damage = weapon.RollDamage();
        foreach((DamageType type, int count) in damage) {
            Console.WriteLine($"Deals {count} {type} damage!");
        }
    }

    public void Attack(string name) {
        if(weapons.Count < 1) throw new InvalidOperationException($"{Name} cannot attack!");
        Weapon weapon = null;
        foreach(Weapon wpn in weapons) {
            if(wpn.Name == name) {
                weapon = wpn;
                break;
            }
        }
        if(weapon == null) throw new ArgumentException($"{Name} does not have {name}");
        AttackEnergy -= Attacks[weapon];
        List<(DamageType type, int count)> damage = weapon.RollDamage();
        foreach((DamageType type, int count) in damage) {
            Console.WriteLine($"Deals {count} {type} damage!");
        }
    }
}