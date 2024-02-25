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
    public List<DamageData> Damages { get; init; }
    public Weapon (
            string name,
            List<DamageData> damages,
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
    public List<(DamageType type, int count)> RollDamage() {
        List<(DamageType type, int count)> result = new List<(DamageType type, int count)>(); 
        foreach(DamageData damageData in Damages) {
            Damage damage = damageData.GetDamage();
            result.Add((type: damage.type, count: damage.count + Modifier));
        }
        return result;
    }
}