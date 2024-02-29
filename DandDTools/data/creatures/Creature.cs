using System.Collections;

public enum SenseType {
    Blindsight,
    Darkvision,
    PassivePerception,
    Tremorsense,
    Truesight
}
public enum LanguageType {
    Common,
    Dwarvish,
    Elvish,
    Giant,
    Gnomish,
    Goblin,
    Halfling,
    Orc,
    Abyssal,
    Celestial,
    Draconic,
    DeepSpeech,
    Infernal,
    Primordial,
    Sylvan,
    Undercommon,
    Telepathy
}
public enum CreatureType {
    Abberation,
    Beast,
    Celestial,
    Construct,
    Dragon,
    Elemental,
    Fey,
    Fiend,
    Giant,
    Humanoid,
    Monstrosity,
    Ooze,
    Plant,
    Undead
}
public abstract class Creature: ICombatParticipant, IDamageable {
    public string Name { get; init; }
    public int Initiative { get; set; }
    public int MaxHP { get; set; }
    public int HP { 
        get => _hp;
        set {
            _hp = value;
            if(_hp < 1) {
                hasDied(this);    
            };
        }
    }
    int _hp = 0;
    public bool IsAlive {
        get => HP > 0;
    }
    public int AC { get; set; }
    public int Speed { get; set; }
    public CreatureSize Size { get; set; }
    public CreatureType Type { get; init; }
    public StatData Stats { get; init; }
    public StatData SavingThrows { get; init; }
    public List<DamageType> Resistances { get; init; }
    public List<DamageType> Immunities { get; init; }
    public List<Conditions> ConditionImmunities { get; init; }
    public Dictionary<SenseType, int> Senses { get; init; }
    public List<LanguageType> Languages { get; init; }
    public List<PassiveAbilityList.PassiveAbility> PassiveAbilities { get; init; }
    public delegate void Turn();
    public ICombatParticipant.Turn TakeTurn { get; set; }
    public delegate void HasDiedHandler(Creature creature);
    public event HasDiedHandler hasDied;
    public List<Weapon> Attacks { get; set; }
    public List<IDamageable> Targets { get; set; }
    public int ProficiencyBonus { get; set; }

    public Creature(
        string name,
        int maxHP,
        int ac,
        int speed,
        CreatureSize size,
        CreatureType type,
        StatData stats,
        StatData savingThrows,
        Dictionary<SenseType, int> senses,
        List<LanguageType> languages,
        int proficiency,
        List<DamageType>? resistances = null,
        List<DamageType>? immunites = null,
        List<Conditions>? conditionImmunities = null,
        List<PassiveAbilityList.PassiveAbility>? passiveAbilities = null,
        List<Weapon>? attacks = null,
        ICombatParticipant.Turn? turn = null,
        List<IDamageable>? targets = null
    ) {
        Name = name;
        MaxHP = maxHP;
        HP = MaxHP;
        AC = ac;
        Speed = speed;
        Size = size;
        Type = type;
        Stats = stats;
        SavingThrows = savingThrows;
        Senses = senses;
        Languages = languages;
        Resistances = resistances?? new List<DamageType>();
        Immunities = immunites?? new List<DamageType>();
        ConditionImmunities = conditionImmunities?? new List<Conditions>();
        PassiveAbilities = passiveAbilities?? new List<PassiveAbilityList.PassiveAbility>();
        Targets = targets?? new List<IDamageable>();
        Attacks = attacks?? new List<Weapon>();
        Initiative = 0;
        ProficiencyBonus = proficiency;
        TakeTurn = turn?? delegate() { Console.WriteLine("Not Implimented!"); };
        foreach(PassiveAbilityList.PassiveAbility ability in PassiveAbilities) {
            if(ability.Name == "Brute") {
                foreach(Weapon wpn in Attacks) {
                    if(wpn is MeleeWeapon) {
                        MeleeWeapon? melee = wpn as MeleeWeapon;
                        melee.UsedByBrute = true;
                    }
                }
            }
        }
    }
    public virtual void RollInitiative() {
        Console.WriteLine($"RollInitiative on {GetType()} not implimented!");
    }

    public void Attack(int index, IDamageable target) {
        Weapon weapon = Attacks[index];
        if(!Attacks.Contains(weapon)) throw new ArgumentException($"{Name} cannot use weapon {weapon}, {Name} does not have that weapon!");
        Attack(weapon, target);
    }

    public void Attack(string name, IDamageable target) {
        if(Attacks.Count < 1) throw new InvalidOperationException($"{Name} cannot attack!");
        Weapon? weapon = null;
        foreach(Weapon wpn in Attacks) {
            if(wpn.Name == name) {
                weapon = wpn;
                break;
            }
        }
        if(weapon == null) throw new ArgumentException($"{Name} does not have {name}");
        Attack(weapon, target);
    }
    private void Attack(Weapon wpn, IDamageable trgt) {
        if(!Attacks.Contains(wpn)) throw new InvalidOperationException($"{Name} does not have weapon {wpn}. How did you get this?");
        if(Targets.Count < 1) {
            Console.WriteLine("No targets to attack!");
            return;
        }
        List<(DamageType type, int count)> dmg = wpn.RollDamage();
        int statModifier = StatData.StatScoreToModifier(Stats.Strength);
        if(wpn.Finesse | wpn is RangedWeapon) {
            statModifier = StatData.StatScoreToModifier(Stats.Dexterity);
        }
        int toHit = Dice.Roll(Dice.Type.D20) + wpn.Modifier + statModifier + ProficiencyBonus;
        if(toHit >= trgt.AC) {
            foreach((DamageType type, int count) in dmg) {
                Console.WriteLine($"Deals {count} {type} damage to {trgt.Name}!");
                trgt.HP -= count; 
            }
        } else {
            Console.WriteLine($"Missed!");
        } 
    }
}