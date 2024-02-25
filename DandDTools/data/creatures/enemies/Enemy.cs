using System.Diagnostics.CodeAnalysis;
public class Enemy: Creature {
    public required float Challenge { get; init; }

    [SetsRequiredMembers]
    public Enemy(
        string name,
        string species,
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
        List<DamageType>? resistances = null,
        List<DamageType>? immunites = null,
        List<Conditions>? conditionImmunities = null,
        List<PassiveAbilityList.PassiveAbility>? passiveAbilities = null,
        List<Weapon>? attacks = null,
        ICombatParticipant.Turn? turn = null
    ):base(
        name: name,
        species: species,
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
        attacks: attacks,
        turn: turn
        ) {
        Challenge = challenge;
    }
    public void Attack(int index) {
        Weapon weapon = Attacks[index];
        if(!Attacks.Contains(weapon)) throw new ArgumentException($"{Name} cannot use weapon {weapon}, {Name} does not have that weapon!");
        List<(DamageType type, int count)> damage = weapon.RollDamage();
        foreach((DamageType type, int count) in damage) {
            Console.WriteLine($"Deals {count} {type} damage!");
        }
    }

    public void Attack(string name) {
        if(Attacks.Count < 1) throw new InvalidOperationException($"{Name} cannot attack!");
        Weapon? weapon = null;
        foreach(Weapon wpn in Attacks) {
            if(wpn.Name == name) {
                weapon = wpn;
                break;
            }
        }
        if(weapon == null) throw new ArgumentException($"{Name} does not have {name}");
        List<(DamageType type, int count)> damage = weapon.RollDamage();
        foreach((DamageType type, int count) in damage) {
            Console.WriteLine($"Deals {count} {type} damage!");
        }
    }
}