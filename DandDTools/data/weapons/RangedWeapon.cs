public class RangedWeapon: Weapon {
    int _normalRange, _maxRange;
    bool _ammunition, _loading;
    public int NormalRange {
        get => _normalRange;
        init => _normalRange = value;
    }
    public int MaxRange {
        get => _maxRange;
        init => _maxRange = value;
    }
    public bool Ammuntion {
        get => _ammunition;
        init => _ammunition = value;
    }
    public bool Loading {
        get => _loading;
        init => _loading = value;
    }
    public RangedWeapon(
            string name,
            List<DamageData> damages,
            int modifier,
            WeaponType type,
            int normalRange,
            int maxRange,
            bool ammunition = false,
            bool finesse = false,
            bool loading = false,
            bool heavy = false,
            bool light = false,
            bool special = false,
            bool twoHanded = false
        ):base(name: name, damages: damages, modifier: modifier, type: type, finesse: finesse, heavy: heavy, light: light, special: special, twoHanded: twoHanded) {
        NormalRange = normalRange;
        MaxRange = maxRange;
        Ammuntion = ammunition;
        Loading = loading;
    }
}