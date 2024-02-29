public class PlayerClass {
    public enum ClassType {
        Artificer,
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wizard
    }
    public ClassType Class { get; init; }
    public int Level { get; set; }
    public PlayerClass(ClassType playerClass, int level = 1) {
        Class = playerClass;
        Level = level;
    }
}