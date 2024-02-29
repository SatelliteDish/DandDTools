using System.ComponentModel.DataAnnotations;

public class Dice {
    public enum Type {
        D1,
        D4,
        D6,
        D8,
        D10,
        D12,
        D20,
        D100
    }
    public static int Roll(int count, Type dice) {
        int total = 0;
        for(int i = 0; i < count; i++) {
            total += Roll(dice);
        }
        return total;
    }
    public static int Roll(Type dice) {
        int result = dice switch {
            Type.D1 => 1,
            Type.D4 => RollD4(),
            Type.D6 => RollD6(),
            Type.D8 => RollD8(),
            Type.D10 => RollD10(),
            Type.D12 => RollD12(),
            Type.D20 => RollD20(),
            Type.D100 => RollD100(),
            _ => throw new ArgumentException("Error, Please supply a valid dice type!"),
        };
        return result;
    }
    public static int Roll(int max, int min = 1) {
        Random rng = new Random();
        return rng.Next(minValue: min, maxValue: max + 1);
    }
    public static int RollD4() {
        Random rng = new Random();
        return rng.Next(1,5);
    }
    public static int RollD6() {
        Random rng = new Random();
        return rng.Next(1,7);
    }
    public static int RollD8() {
        Random rng = new Random();
        return rng.Next(1,9);
    }
    public static int RollD10() {
        Random rng = new Random();
        return rng.Next(1,11);
    }
    public static int RollD12() {
        Random rng = new Random();
        return rng.Next(1,13);
    }
    public static int RollD20() {
        Random rng = new Random();
        return rng.Next(1,21);
    }
    public static int RollD100() {
        Random rng = new Random();
        return rng.Next(1,101);
    }
}