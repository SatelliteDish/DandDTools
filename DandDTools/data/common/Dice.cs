public class Dice {
    public enum Type {
        D4,
        D6,
        D8,
        D10,
        D12,
        D20,
        D100
    }
    public static int Roll(Type dice) {
        int result = dice switch {
            Type.D4 => Dice.RollD4(),
        };
        return result;
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
    public static int Roll12() {
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