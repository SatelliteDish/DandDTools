public sealed class PassiveAbilityList {
    public sealed class PassiveAbility {
        string _name;
        string _description;
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
    public PassiveAbility NimbleEscape(int range = 10) {
        return new PassiveAbility(
            name: "Nimble Escape",
            description: $"This creature can take the disengage or hide action as a bonus action on each of it's turns."
        );
    }
}