using System.Diagnostics.CodeAnalysis;
public class StatData {
    public required int Strength { get; set; }
    public required int Dexterity { get; set; }
    public required int Constitution { get; set; }
    public required int Intelligence { get; set; }
    public required int Wisdom { get; set; }
    public required int Charisma { get; set; }
    [SetsRequiredMembers]
    public StatData(
        int strength = 0,
        int dexterity = 0,
        int constitution = 0,
        int intelligence = 0,
        int wisdom = 0,
        int charisma = 0
    ) {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
    }
    public static int StatScoreToModifier(int stat) {
        return (stat - 10)/2; 
    }
}