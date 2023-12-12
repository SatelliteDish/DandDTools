public class EnemyList {
    public readonly Random rng = new Random();
    public readonly PassiveAbilityList passiveAbilities = new PassiveAbilityList();
    public readonly WeaponList weapons = new WeaponList();
    public Enemy Goblin(string name) {
        return new Enemy(
            name: name,
            hp: rng.Next(2,13),
            ac: 15,
            speed: 30,
            size: CreatureSize.Small,
            type: CreatureType.Humanoid,
            stats: new StatData(
                strength: 8,
                dexterity: 14,
                constitution: 10,
                intelligence: 10,
                wisdom: 8,
                charisma: 8
            ),
            savingThrows: new StatData(
                strength: 0,
                dexterity: 0,
                constitution: 0,
                intelligence: 0,
                wisdom: 0,
                charisma: 0
            ),
            challenge: .25f,
            senses: new Dictionary<SenseType, int> {{SenseType.Darkvision, 60},{SenseType.PassivePerception, 9}},
            languages: new List<LanguageType>{LanguageType.Common,LanguageType.Goblin},
            passiveAbilities: new List<PassiveAbilityList.PassiveAbility>{passiveAbilities.NimbleEscape()},
            attacks: new Dictionary<Weapon, int> {{weapons.Scimitar(),1},{weapons.Shortbow(),1}},
            attackEnergy: 1
        );
    }
}