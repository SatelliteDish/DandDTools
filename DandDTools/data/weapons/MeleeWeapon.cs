public class MeleeWeapon: Weapon {
    int _minThrowRange, _maxThrowRange;
    public int MinThrowRange {
        get {
            if(!Thrown) {
                throw new InvalidOperationException("Tried to get throw range of a non-throwable weapon!");
            }
            return _minThrowRange;
        }
        init => _minThrowRange = value;
    }
    public int MaxThrowRange {
        get {
            if(!Thrown) throw new InvalidOperationException("Tried to get throw range of a non-throwable weapon!");
            if(_maxThrowRange < _minThrowRange) throw new ArgumentException($"MinThrowRange and MaxThrowRange incorrectly set! MinThrowRange:{_minThrowRange}, MaxThrowRange:{_maxThrowRange}");
            return _maxThrowRange;
        }
        init => _maxThrowRange = value;
    }
    DamageData? _versatileDamage;
    public DamageData VersatileDamage {
        get {
            if(!Versatile) throw new InvalidOperationException("Tried to access veratile damage without being versatile!");
            return _versatileDamage;
        }
        init => _versatileDamage = value;
    }
    public bool CurrentlyVersatile {
        get {
            if(!Versatile) throw new InvalidOperationException("Tried to check if currently versatile on a non versatile weapon!");
            return _currentlyVersatile;
        }
        set {
            if(!Versatile) throw new InvalidOperationException("Tried to change current verstility on a non veratile weapon!");
        }
    }
    bool _reach, _thrown, _versatile,_currentlyVersatile;
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
        int minThrowRange = 0,
        int maxThrowRange = 0,
        bool finesse = false,
        bool versatile = false,
        DamageData? versatileDamage = null,
        bool heavy = false,
        bool light = false,
        bool special = false,
        bool twoHanded = false
    ):base(name: name, damages: damages, modifier: modifier, type: type,finesse: finesse, heavy: heavy, light: light, special: special, twoHanded: twoHanded) {
        Reach = reach;
        Thrown = thrown;
        Versatile = versatile;
        if(Thrown) {
            if(maxThrowRange == 0) throw new ArgumentException("Failed to set max throw range on throwable weapon!", "maxThrowRange");
            if(maxThrowRange < minThrowRange) throw new ArgumentException("Max throw range was set to less than the minimum!", "maxThrowRange, minThrowRange");
            MinThrowRange = minThrowRange;
            MaxThrowRange = maxThrowRange;
        }
        if(versatile) {
            VersatileDamage = versatileDamage?? throw new ArgumentException("Error, failed to set versatile damage on versatile weapon","versatileDamage");
        }
    }
}