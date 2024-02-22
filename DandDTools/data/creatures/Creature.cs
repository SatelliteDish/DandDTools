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
public abstract class Creature: IHasInitiative {
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
    public readonly List<Weapon> weapons;
    Dictionary<Weapon,int> _attacks;
    public Dictionary<Weapon,int> Attacks {
        get => _attacks;
        init {
                _attacks = value;
                weapons = new List<Weapon>(value.Keys);
            }
    }
    public Creature(
        string name,
        int hp,
        int ac,
        int speed,
        CreatureSize size,
        CreatureType type,
        StatData stats,
        StatData savingThrows,
        Dictionary<SenseType, int> senses,
        List<LanguageType> languages,
        List<DamageType> resistances = default,
        List<DamageType> immunites = null,
        List<Conditions> conditionImmunities = null,
        List<PassiveAbilityList.PassiveAbility> passiveAbilities = null,
        Dictionary<Weapon,int> attacks = null
    ) {
        Name = name;
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
        Attacks = attacks?? new Dictionary<Weapon, int>();
        Initiative = 0;
    }
    public void RollInitiative() {
        Initiative = Dice.Roll(Dice.Type.D20);
    }
}