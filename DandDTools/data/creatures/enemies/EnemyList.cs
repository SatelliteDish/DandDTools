using System.Runtime.CompilerServices;

public class EnemyList {
    public readonly Random rng = new Random();
    public readonly PassiveAbilityList passiveAbilities = new PassiveAbilityList();
    public readonly WeaponList weapons = new WeaponList();
    public Enemy Goblin(string name) {
        Enemy gob =  new Enemy(
            name: name,
            species: "Goblin",
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
            attacks: new List<Weapon> {
                weapons.Scimitar(),
                weapons.Shortbow()
            }
        );
        gob.TakeTurn = delegate () {
                Console.WriteLine("Choose your attack:");
                for(int i = 0; i < gob.Attacks.Count; i++) {
                    Console.WriteLine($"{i + 1}: {gob.Attacks[i].Name}");
                }
                int choice;
                while(true) {
                    try {
                        choice = Convert.ToInt32(Console.ReadLine()) - 1;
                    } catch { continue; }
                    if(choice < 0 | choice > gob.Attacks.Count - 1) continue;
                    break;
                }
                gob.Attack(choice);
        };
        return gob;
    }
}