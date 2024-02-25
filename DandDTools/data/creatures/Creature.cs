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
public abstract class Creature: ICombatParticipant {
    public string Name { get; init; }
    public string Species { get; set; }
    public int Initiative { get; set; }
    public int HP { get; set; }
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
    public List<Conditions> ConditionImmunites { get; init; }
    public Dictionary<SenseType, int> Senses { get; init; }
    public List<LanguageType> Languages { get; init; }
    public List<PassiveAbilityList.PassiveAbility> PassiveAbilities { get; init; }
    public delegate void Turn();
    public ICombatParticipant.Turn TakeTurn { get; set; }
    public List<Weapon> Attacks { get; set; }

    public Creature(
        string name,
        string species,
        int hp,
        int ac,
        int speed,
        CreatureSize size,
        CreatureType type,
        StatData stats,
        StatData savingThrows,
        Dictionary<SenseType, int> senses,
        List<LanguageType> languages,
        List<DamageType>? resistances = null,
        List<DamageType>? immunites = null,
        List<Conditions>? conditionImmunities = null,
        List<PassiveAbilityList.PassiveAbility>? passiveAbilities = null,
        List<Weapon>? attacks = null,
        ICombatParticipant.Turn? turn = null
    ) {
        Name = name;
        Species = species;
        HP = hp;
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
        ConditionImmunites = conditionImmunities?? new List<Conditions>();
        PassiveAbilities = passiveAbilities?? new List<PassiveAbilityList.PassiveAbility>();
        Attacks = attacks?? new List<Weapon>();
        Initiative = 0;
        TakeTurn = turn?? delegate() { Console.WriteLine("Not Implimented!"); };
    }
    public void RollInitiative() {
        Initiative = Dice.Roll(Dice.Type.D20);
    }
}