public class Enemy: Creature {
    float _challenge;
    public float Challenge {
        get => _challenge;
        init => _challenge = value;
    }
    int _attackEnergy;

    public int AttackEnergy {
        get => _attackEnergy;
        set => _attackEnergy = value;
    }

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
        _challenge = challenge;
        _attackEnergy = attackEnergy;
    }
    public void Attack(Weapon weapon) {
        if(!Attacks.ContainsKey(weapon)) throw new ArgumentException($"{Name} cannot use weapon {weapon}, {Name} does not have that weapon!");
        if(AttackEnergy < Attacks[weapon]) {
            Console.WriteLine("Cannot attack, out of energy!");
            return;
        }
        List<(DamageType type, int count)> damage = weapon.RollDamage();
        foreach((DamageType type, int count) in damage) {
            Console.WriteLine($"Deals {count} {type} damage!");
        }
    }

}