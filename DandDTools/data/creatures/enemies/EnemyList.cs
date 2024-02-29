using System.Runtime.CompilerServices;

public class EnemyList {
    public readonly PassiveAbilityList passiveAbilities = new PassiveAbilityList();
    public readonly WeaponList weapons = new WeaponList();
    public Enemy Goblin(string name) {
        Enemy gob =  new Enemy(
            name: name,
            species: "Goblin",
            maxHP: Dice.Roll(2,Dice.Type.D6),
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
            proficiency: 2,
            languages: new List<LanguageType>{LanguageType.Common,LanguageType.Goblin},
            passiveAbilities: new List<PassiveAbilityList.PassiveAbility>{passiveAbilities.NimbleEscape()},
            attacks: new List<Weapon> {
                weapons.Scimitar(),
                weapons.Shortbow()
            }
        );
        gob.TakeTurn = delegate () {
                if(gob.Targets.Count == 0 | gob.Attacks.Count == 0) {
                    Console.WriteLine("Cannot Attack!");
                    return;
                }
                Console.WriteLine("Choose your attack:");
                for(int i = 0; i < gob.Attacks.Count; i++) {
                    Console.WriteLine($"{i + 1}: {gob.Attacks[i].Name}");
                }
                int attack;
                while(true) {
                    try {
                        attack = Convert.ToInt32(Console.ReadLine()) - 1;
                    } catch { continue; }
                    if(attack < 0 | attack > gob.Attacks.Count - 1) continue;
                    break;
                }
                Console.WriteLine("Choose your target:");
                for(int i = 0; i < gob.Targets.Count; i++) {
                    Console.WriteLine($"{i + 1}: {gob.Targets[i].Name}");
                }
                int target;
                while(true) {
                    try {
                        target = Convert.ToInt32(Console.ReadLine()) - 1;
                    } catch { continue; }
                    if(target < 0 | target > gob.Targets.Count - 1) continue;
                    break;
                }
                gob.Attack(attack, gob.Targets[target]);
        };
        return gob;
    }
    public Enemy Bugbear(string name) {
        Enemy bug =  new Enemy(
            name: name,
            species: "Bugbear",
            maxHP: Dice.Roll(5,Dice.Type.D8) + 5,
            ac: 16,
            speed: 30,
            size: CreatureSize.Medium,
            type: CreatureType.Humanoid,
            stats: new StatData(
                strength: 15,
                dexterity: 14,
                constitution: 13,
                intelligence: 8,
                wisdom: 11,
                charisma: 9
            ),
            savingThrows: new StatData(
                strength: 0,
                dexterity: 0,
                constitution: 0,
                intelligence: 0,
                wisdom: 0,
                charisma: 0
            ),
            challenge: 1f,
            senses: new Dictionary<SenseType, int> {{SenseType.Darkvision, 60},{SenseType.PassivePerception, 10}},
            proficiency: 2,
            languages: new List<LanguageType>{LanguageType.Common,LanguageType.Goblin},
            passiveAbilities: new List<PassiveAbilityList.PassiveAbility>{
                passiveAbilities.Brute("Bugbear"),
                passiveAbilities.SupriseAttack("Bugbear"),                
            },
            attacks: new List<Weapon> {
                weapons.Morningstar(),
                weapons.Javelin()
            }
        );
        bug.TakeTurn = delegate () {
                if(bug.Targets.Count == 0 | bug.Attacks.Count == 0) {
                    Console.WriteLine("Cannot Attack!");
                    return;
                }
                Console.WriteLine("Choose your attack:");
                for(int i = 0; i < bug.Attacks.Count; i++) {
                    Console.WriteLine($"{i + 1}: {bug.Attacks[i].Name}");
                }
                int attack;
                while(true) {
                    try {
                        attack = Convert.ToInt32(Console.ReadLine()) - 1;
                    } catch { continue; }
                    if(attack < 0 | attack > bug.Attacks.Count - 1) continue;
                    break;
                }
                Console.WriteLine("Choose your target:");
                for(int i = 0; i < bug.Targets.Count; i++) {
                    Console.WriteLine($"{i + 1}: {bug.Targets[i].Name}");
                }
                int target;
                while(true) {
                    try {
                        target = Convert.ToInt32(Console.ReadLine()) - 1;
                    } catch { continue; }
                    if(target < 0 | target > bug.Targets.Count - 1) continue;
                    break;
                }
                bug.Attack(attack, bug.Targets[target]);
        };
        return bug;
    }
}