public enum WeaponType {
    Simple,
    Martial
}

public class Weapon {
    public string Name { get; init; }
    public int Modifier { get; init; }
    public WeaponType Type { get; init; }
    public bool Finesse { get; init; }
    public bool Heavy { get; init; }
    public bool Light { get; init; }
    public bool Special { get; init; }
    public bool TwoHanded { get; init; }
    public List<(int,DamageData)> Damages { get; init; }
    public Weapon (
            string name,
            List<(int,DamageData)> damages,
            int modifier,
            WeaponType type,
            bool finesse = false,
            bool heavy = false,
            bool light = false,
            bool special = false,
            bool twoHanded = false
        ) {
        Name = name;
        Damages = damages;
        Modifier = modifier;
        Type = type;
        Finesse = finesse;
        Heavy = heavy;
        Light = light;
        Special = special;
        TwoHanded = twoHanded;
    }
    public List<(DamageType, int)> RollDamage() {
        List<(DamageType, int)> result = new List<(DamageType, int)>(); 
        foreach((int count, DamageData damageData) in Damages) {
            Console.WriteLine($"Rolling {count} {damageData}");
            for(int i = 0; i < count; i++) {
                Damage damage = damageData.GetDamage();
                result.Add((damage.type,damage.count + Modifier));
            }
        }
        return result;
    }
}