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
    public DamageData? VersatileDamage {
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
            _currentlyVersatile = value;
        }
    }
    bool _currentlyVersatile, _usedByBrute = false;
    public bool UsedByBrute {
        get => _usedByBrute;
        set {
            if(value == _usedByBrute) { return; }
            if(value == true) {
                Console.WriteLine($"{Name} Used by brute!");
                for(int i = 0; i < Damages.Count; i++) {
                    (int,DamageData) current = Damages[i];
                    Damages[i] = (current.Item1+1,current.Item2);
                }
            } else {
                for(int i = 0; i < Damages.Count; i++) {
                    Console.WriteLine($"{Name} no longer used by brute!");
                    (int,DamageData) current = Damages[i];
                    Damages[i] = (current.Item1-1,current.Item2);
                }
            }
            _usedByBrute = value;
        }
    }
    public bool Reach { get; init; }
    public bool Thrown { get; init; }
    public bool Versatile { get; init; }
    
    public MeleeWeapon(
        string name,
        List<(int count,DamageData damage)> damages,
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
        bool twoHanded = false,
        bool usedByBrute = false
    ):base(name: name, damages: damages, modifier: modifier, type: type,finesse: finesse, heavy: heavy, light: light, special: special, twoHanded: twoHanded) {
        Reach = reach;
        Thrown = thrown;
        Versatile = versatile;
        UsedByBrute = usedByBrute;
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