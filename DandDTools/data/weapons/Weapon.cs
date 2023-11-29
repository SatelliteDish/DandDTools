using System.Dynamic;

public enum WeaponType {
    Simple,
    Martial
}

class Weapon {
    string _name;
    public string Name {
        get =>  _name;
        init => _name = value;
    }
    int _modifier = 0;
    public int Modifier {
        get => _modifier;
        init => _modifier = value;
    }
    bool _heavy, _light, _special, _twoHanded;
    public bool Heavy {
        get => _heavy;
        init => _heavy = value;
    }
    public bool Light {
        get => _light;
        init => _light = value;
    }
    public bool Special {
        get => _special;
        init => _special = value;
    }
    public bool TwoHanded {
        get => _twoHanded;
        init => _twoHanded = value;
    }
    List<DamageData> _damages;
    public List<DamageData> Damages {
        get => _damages;
        init => _damages = value; 
    }
    public Weapon (
            string name,
            List<DamageData> damages,
            int modifier,
            WeaponType type,
            bool heavy = false,
            bool light = false,
            bool special = false,
            bool twoHanded = false
        ) {
        Name = name;
        Damages = damages;
        Modifier = modifier;
        Heavy = heavy;
        Light = light;
        Special = special;
        TwoHanded = twoHanded;
    }
    public void RollDamage() {
        foreach(DamageData damageData in Damages) {
            Damage damage = damageData.GetDamage();
            Console.WriteLine($"{ damage.count } + { Modifier } points of { damage.type } damage!");
        }
    }
}