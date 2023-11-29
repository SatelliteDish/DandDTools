class MeleeWeapon: Weapon {
    bool _finesse, _reach, _thrown, _versatile;
    public bool Finesse {
        get => _finesse;
        init => _finesse = value;
    }
    public bool Reach {
        get => _reach;
        init => _reach = value;
    }
    public bool Thrown {
        get => _thrown;
        init => _thrown = value;
    }
    public bool Versatile {
        get => _versatile;
        init => _versatile = value;
    }
    public MeleeWeapon(
        string name,
        List<DamageData> damages,
        int modifier,
        WeaponType type,
        bool reach = false,
        bool thrown = false,
        bool finesse = false,
        bool versatile = false,
        bool heavy = false,
        bool light = false,
        bool special = false,
        bool twoHanded = false
    ):base(name: name, damages: damages, modifier: modifier, type: type, heavy: heavy, light: light, special: special, twoHanded: twoHanded) {
        Reach = reach;
        Thrown = thrown;
        Finesse = finesse;
        Versatile = versatile;
    }
    public static MeleeWeapon Shortsword(Random rng, int modifier = 0) {
        List<DamageData> damages = new List<DamageData>();
        damages.Add(new DamageData(1,6,DamageData.DamageType.Piercing,rng));
        return new MeleeWeapon(
            name: "Shortsword",
            damages: damages,
            modifier: modifier,
            type: WeaponType.Martial,
            finesse: true,
            light: true
            );
    }
}