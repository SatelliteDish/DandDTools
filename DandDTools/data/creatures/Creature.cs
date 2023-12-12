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
public class Creature {
    string _name;
    public string Name {
        get => _name;
        init => _name = value;
    }
    string _species;
    public string Species {
        get => _species;
        set => _species = value;
    }
    int _hp, _ac, _speed;
    public int HP {
        get => _hp;
        set => _hp = value;
    }
    public bool IsAlive {
        get => _hp > 0;
    }
    public int AC {
        get => _ac;
        set => _ac = value;
    }
    public int Speed {
        get => _speed;
        set => _speed = value;
    }
    CreatureSize _size;
    public CreatureSize Size {
        get => _size;
        set => _size = value;
    }
    CreatureType _type;
    public CreatureType Type {
        get => _type;
        init => _type = value;
    }
    StatData _stats;
    public StatData Stats {
        get => _stats;
        init => _stats = value;
    }
    StatData _savingThrows;
    public StatData SavingThrows {
        get => _savingThrows;
        init => _savingThrows = value;
    }
    List<DamageType> _resistances;
    public List<DamageType> Resistances {
        get => _resistances;
        init => _resistances = value;
    }
    List<DamageType> _immunitites;
    public List<DamageType> Immunities {
        get => _immunitites;
        init => _immunitites = value;
    }
    List<Conditions> _conditionImmunities;
    public List<Conditions> ConditionImmunites {
        get => _conditionImmunities;
        init => _conditionImmunities = value;
    }
    Dictionary<SenseType,int> _senses;
    public Dictionary<SenseType, int> Senses {
        get => _senses;
        init => _senses = value;
    }
    List<LanguageType> _languages;
    public List<LanguageType> Languages {
        get => _languages;
        init => _languages = value;
    }
    List<PassiveAbilityList.PassiveAbility> _passiveAbilities;
    public List<PassiveAbilityList.PassiveAbility> PassiveAbilities {
        get => _passiveAbilities;
        init => _passiveAbilities = value;
    }
    Dictionary<Weapon,int> _attacks;
    public Dictionary<Weapon,int> Attacks {
        get => _attacks;
        init => _attacks = value;
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
    }
}