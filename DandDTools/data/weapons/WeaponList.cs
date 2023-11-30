public sealed class WeaponList {
    private static WeaponList instance;
    private static readonly object padlock = new object();
    public readonly Random rng = new Random();

    private WeaponList() {}
    public static WeaponList Instance {
        get {
            lock(padlock) {
                if(instance == null) {
                    instance = new WeaponList();
                }
                return instance;
            }
        }
    }
    public MeleeWeapon Club(int modifier = 0) {
        return new MeleeWeapon(
            name: "Club",
            damages: new List<DamageData> {
                new DamageData(1, 4, DamageType.Bludgeoning, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            light: true
        );
    }
    public MeleeWeapon Dagger(int modifier = 0) {
        return new MeleeWeapon(
            name: "Dagger",
            damages: new List<DamageData> {
                new DamageData(1, 4, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            light: true,
            finesse: true,
            thrown: true,
            minThrowRange: 20,
            maxThrowRange: 60
        );
    }
    public MeleeWeapon Greatclub(int modifier = 0) {
        return new MeleeWeapon(
            name: "Greatclub",
            damages: new List<DamageData> {
                new DamageData(1, 8, DamageType.Bludgeoning, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            twoHanded: true
        );
    }
    public MeleeWeapon Handaxe(int modifier = 0) {
        return new MeleeWeapon(
            name: "Handaxe",
            damages: new List<DamageData> {
                new DamageData(1, 6, DamageType.Bludgeoning, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            light: true,
            thrown: true,
            minThrowRange: 20,
            maxThrowRange: 60
        );
    }
    public MeleeWeapon Javelin(int modifier = 0) {
        return new MeleeWeapon(
            name: "Javelin",
            damages: new List<DamageData> {
                new DamageData(1, 6, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            thrown: true,
            minThrowRange: 30,
            maxThrowRange: 120
        );
    }
    public MeleeWeapon LightHammer(int modifier = 0) {
        return new MeleeWeapon(
            name: "Light Hammer",
            damages: new List<DamageData> {
                new DamageData(1, 4, DamageType.Bludgeoning, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            light: true,
            thrown: true,
            minThrowRange: 20,
            maxThrowRange: 60
        );
    }
    public MeleeWeapon Mace(int modifier = 0) {
        return new MeleeWeapon(
            name: "Mace",
            damages: new List<DamageData> {
                new DamageData(1, 6, DamageType.Bludgeoning, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple
        );
    }
    public MeleeWeapon Quarterstaff(int modifier = 0) {
        return new MeleeWeapon(
            name: "Quarterstaff",
            damages: new List<DamageData> {
                new DamageData(1, 6, DamageType.Bludgeoning, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            versatile: true,
            versatileDamage: new DamageData(_min: 1, _max: 8, _type: DamageType.Bludgeoning, _rng: rng)
        );
    }
    public MeleeWeapon Sickle(int modifier = 0) {
        return new MeleeWeapon(
            name: "Sickle",
            damages: new List<DamageData> {
                new DamageData(1, 4, DamageType.Slashing, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            light: true
        );
    }
    public MeleeWeapon Spear(int modifier = 0) {
        return new MeleeWeapon(
            name: "Spear",
            damages: new List<DamageData> {
                new DamageData(1, 6, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            thrown: true,
            minThrowRange: 20,
            maxThrowRange: 60,
            versatile: true,
            versatileDamage: new DamageData(_min: 1, _max: 8, DamageType.Piercing, _rng: rng)
        );
    }
    public RangedWeapon LightCrossbow(int modifier = 0) {
        return new RangedWeapon(
            name: "Light Crossbow",
            damages: new List<DamageData> {
                new DamageData(1, 8, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            twoHanded: true,
            loading: true,
            ammunition: true,
            normalRange: 80,
            maxRange: 320
        );
    }
    public RangedWeapon Dart(int modifier = 0) {
        return new RangedWeapon(
            name: "Dart",
            damages: new List<DamageData> {
                new DamageData(1, 4, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            ammunition: true,
            finesse: true,
            normalRange: 80,
            maxRange: 320
        );
    }
    public RangedWeapon Shortbow(int modifier = 0) {
        return new RangedWeapon(
            name: "Shortbow",
            damages: new List<DamageData> {
                new DamageData(1, 6, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            twoHanded: true,
            loading: true,
            ammunition: true,
            normalRange: 80,
            maxRange: 320
        );
    }
    public RangedWeapon Sling(int modifier = 0) {
        return new RangedWeapon(
            name: "Sling",
            damages: new List<DamageData> {
                new DamageData(1, 4, DamageType.Bludgeoning, rng)
            },
            modifier: modifier,
            type: WeaponType.Simple,
            ammunition: true,
            normalRange: 30,
            maxRange: 120
        );
    }
    public MeleeWeapon Battleaxe(int modifier = 0) {
        return new MeleeWeapon(
            name: "Battleaxe",
            damages: new List<DamageData> {
                new DamageData(1,8,DamageType.Slashing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            versatile: true,
            versatileDamage: new DamageData(1,10,DamageType.Slashing,rng)
        );
    }
    public MeleeWeapon Flail(int modifier = 0) {
        return new MeleeWeapon(
            name: "Flail",
            damages: new List<DamageData> {
                new DamageData(1,8,DamageType.Bludgeoning,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial
        );
    }
    public MeleeWeapon Glaive(int modifier = 0) {
        return new MeleeWeapon(
            name: "Glaive",
            damages: new List<DamageData> {
                new DamageData(1,10,DamageType.Slashing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            heavy: true,
            reach: true,
            twoHanded: true
        );
    }
    public MeleeWeapon Greataxe(int modifier = 0) {
        return new MeleeWeapon(
            name: "Greataxe",
            damages: new List<DamageData> {
                new DamageData(1,12,DamageType.Slashing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            heavy: true,
            twoHanded: true
        );
    }
    public MeleeWeapon Greatsword(int modifier = 0) {
        return new MeleeWeapon(
            name: "Greatsword",
            damages: new List<DamageData> {
                new DamageData(2,12,DamageType.Slashing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            heavy: true,
            twoHanded: true
        );
    }
    public MeleeWeapon Halberd(int modifier = 0) {
        return new MeleeWeapon(
            name: "Halberd",
            damages: new List<DamageData> {
                new DamageData(1,10,DamageType.Slashing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            heavy: true,
            reach: true,
            twoHanded: true
        );
    }
    public MeleeWeapon Lance(int modifier = 0) {
        return new MeleeWeapon(
            name: "Lance",
            damages: new List<DamageData> {
                new DamageData(1,12,DamageType.Piercing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            reach: true,
            special: true
        );
    }
    public MeleeWeapon Longsword(int modifier = 0) {
        return new MeleeWeapon(
            name: "Longsword",
            damages: new List<DamageData> {
                new DamageData(1,8,DamageType.Slashing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            versatile: true,
            versatileDamage: new DamageData(1,10,DamageType.Slashing,rng)
        );
    }
    public MeleeWeapon Maul(int modifier = 0) {
        return new MeleeWeapon(
            name: "Maul",
            damages: new List<DamageData> {
                new DamageData(2,12,DamageType.Bludgeoning,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            heavy: true,
            twoHanded: true
        );
    }
    public MeleeWeapon Morningstar(int modifier = 0) {
        return new MeleeWeapon(
            name: "Morningstar",
            damages: new List<DamageData> {
                new DamageData(1,8,DamageType.Piercing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial
        );
    }
    public MeleeWeapon Pike(int modifier = 0) {
        return new MeleeWeapon(
            name: "Pike",
            damages: new List<DamageData> {
                new DamageData(1,10,DamageType.Piercing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            heavy: true,
            reach: true,
            twoHanded: true
        );
    }
    public MeleeWeapon Rapier(int modifier = 0) {
        return new MeleeWeapon(
            name: "Rapier",
            damages: new List<DamageData> {
                new DamageData(1,8,DamageType.Piercing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            finesse: true
        );
    }
    public MeleeWeapon Scimitar(int modifier = 0) {
        return new MeleeWeapon(
            name: "Scimitar",
            damages: new List<DamageData> {
                new DamageData(1,6,DamageType.Slashing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            finesse: true,
            light: true
        );
    }
    public MeleeWeapon Shortsword(int modifier = 0) {
        return new MeleeWeapon(
            name: "Shortsword",
            damages: new List<DamageData> {
                new DamageData(1,6,DamageType.Piercing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            finesse: true,
            light: true
        );
    }
    public MeleeWeapon Trident(int modifier = 0) {
        return new MeleeWeapon(
            name: "Trident",
            damages: new List<DamageData> {
                new DamageData(1,6,DamageType.Piercing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            thrown: true,
            minThrowRange: 20,
            maxThrowRange: 60,
            versatile: true,
            versatileDamage: new DamageData(1,8,DamageType.Piercing,rng)
        );
    }
    public MeleeWeapon WarPick(int modifier = 0) {
        return new MeleeWeapon(
            name: "War Pick",
            damages: new List<DamageData> {
                new DamageData(1,8,DamageType.Piercing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial
        );
    }
    public MeleeWeapon Warhammer(int modifier = 0) {
        return new MeleeWeapon(
            name: "Morningstar",
            damages: new List<DamageData> {
                new DamageData(1,8,DamageType.Bludgeoning,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            versatile: true,
            versatileDamage: new DamageData(1,10,DamageType.Bludgeoning, rng)
        );
    }
    public MeleeWeapon Whip(int modifier = 0) {
        return new MeleeWeapon(
            name: "Whip",
            damages: new List<DamageData> {
                new DamageData(1,4,DamageType.Slashing,rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            finesse: true,
            reach: true
        );
    }
    public RangedWeapon Blowgun(int modifier = 0) {
        return new RangedWeapon(
            name: "Blowgun",
            damages: new List<DamageData> {
                new DamageData(1, 1, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            loading: true,
            ammunition: true,
            normalRange: 25,
            maxRange: 100
        );
    }
    public RangedWeapon HandCrossbow(int modifier = 0) {
        return new RangedWeapon(
            name: "Hand Crossbow",
            damages: new List<DamageData> {
                new DamageData(1, 6, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            light: true,
            loading: true,
            ammunition: true,
            normalRange: 30,
            maxRange: 120
        );
    }
    public RangedWeapon HeavyCrossbow(int modifier = 0) {
        return new RangedWeapon(
            name: "Heavy Crossbow",
            damages: new List<DamageData> {
                new DamageData(1, 10, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            heavy: true,
            loading: true,
            twoHanded: true,
            ammunition: true,
            normalRange: 100,
            maxRange: 400
        );
    }
    public RangedWeapon Longbow(int modifier = 0) {
        return new RangedWeapon(
            name: "Longbow",
            damages: new List<DamageData> {
                new DamageData(1, 8, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            heavy: true,
            twoHanded: true,
            ammunition: true,
            normalRange: 150,
            maxRange: 600
        );
    }
    public RangedWeapon Net(int modifier = 0) {
        return new RangedWeapon(
            name: "Net",
            damages: new List<DamageData> {
                new DamageData(0, 0, DamageType.Piercing, rng)
            },
            modifier: modifier,
            type: WeaponType.Martial,
            special: true,
            normalRange: 5,
            maxRange: 15
        );
    }
}