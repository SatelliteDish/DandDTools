public class StatData {
    int _strength, _dexterity, _constitution, _intelligence, _wisdom, _charisma;
    public int Strength {
        get => _strength;
        init => _strength = value;
    }
    public int Dexterity {
        get => _dexterity;
        init => _dexterity = value;
    }
    public int Constitution {
        get => _constitution;
        init => _constitution = value;
    }
    public int Intelligence {
        get => _intelligence;
        init => _intelligence = value;
    }
    public int Wisdom {
        get => _wisdom;
        init => _wisdom = value;
    }
    public int Charisma {
        get => _charisma;
        init => _charisma = value;
    }
    public StatData(
        int strength = 0,
        int dexterity = 0,
        int constitution = 0,
        int intelligence = 0,
        int wisdom = 0,
        int charisma = 0
    ) {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
    }
    public static int StatScoreToModifier(int stat) {
        return (stat - 10)/2; 
    }
}