using System.Data.Common;

public class DamageData {
    public enum DamageType {
        Acid, Bludgeoning, Cold, Fire, Force, Lightning, Necrotic, Piercing, Poison, Psychic, Radiant, Slashing, Thunder
    }
    int min, max;
    Random rng;
    DamageType type;
    public DamageData(int _min, int _max, DamageType _type, Random _rng) {
        min = _min;
        max = _max;
        rng = _rng;
        type = _type;
    }
    public Damage GetDamage() {
        return new Damage(rng.Next(min, max+1),type);
    }
}
public record Damage(int count, DamageData.DamageType type);