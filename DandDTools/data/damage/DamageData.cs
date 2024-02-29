using System.Data.Common;

public enum DamageType {
        Acid, Bludgeoning, Cold, Fire, Force, Lightning, Necrotic, Piercing, Poison, Psychic, Radiant, Slashing, Thunder
    }
public class DamageData {
    Dice.Type dice;
    Random rng;
    DamageType type;
    public DamageData(Dice.Type _dice, DamageType _type, Random _rng) {
        dice = _dice;
        rng = _rng;
        type = _type;
    }
    public Damage GetDamage() {
        return new Damage(Dice.Roll(dice),type);
    }
}
public record Damage(int count, DamageType type);