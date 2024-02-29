public sealed class PassiveAbilityList {
    public sealed class PassiveAbility {
        string _name = "";
        string _description = "";
        public string Name {
            get => _name;
            init => _name = value;
        }
        public string Description {
            get => _description;
            init => _description = value;
        }
        public PassiveAbility(string name, string description) {
            Name = name;
            Description = description;
        }
    }
    public PassiveAbility MagicResistance() {
        return new PassiveAbility(
            name: "Magic Resistance",
            description: "This creature has advantage against saving throws against spells and other magical effects."
        );
    }
    public PassiveAbility Stench(int range = 10) {
        return new PassiveAbility(
            name: "Stench",
            description: $"Any creature that starts it's turn within {range} of this creature must succeed on a DC 14 Constitution saving throw or be poisoned until the start of it's next turn. On a success the effected creature is immune to the stench for 24 hours."
        );
    }
    public PassiveAbility NimbleEscape() {
        return new PassiveAbility(
            name: "Nimble Escape",
            description: $"This creature can take the disengage or hide action as a bonus action on each of it's turns."
        );
    }
    public PassiveAbility Brute(string species) {
        return new PassiveAbility (
            name: "Brute",
            description: $"A melee weapon deals one extra die of it's damage when the ${species} hits with it."
        );
    }
    public PassiveAbility SupriseAttack(string species) {
        return new PassiveAbility(
            name: "Surpise Attack",
            description: $"If the {species} surprises a creature and hits it with an attack during the first round of combat, the target takes an extra 2d6 damage from the attack."
        );
    }
}