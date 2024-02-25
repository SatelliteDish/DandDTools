using System.Data.Common;

public class Player: Creature {
    public string Race { get; init; }
    public Player(
        string name,
        string race,
        int hp,
        int maxHP,
        int ac,
        int speed,
        int proficiency,
        CreatureSize size,
        CreatureType type,
        StatData stats,
        StatData savingThrows,
        Dictionary<SenseType, int> senses,
        List<LanguageType> languages,
        List<DamageType>? resistances = null,
        List<DamageType>? immunites = null,
        List<Conditions>? conditionImmunities = null,
        List<PassiveAbilityList.PassiveAbility>? passiveAbilities = null,
        List<Weapon>? attacks = null
    ):base(
        name: name,
        maxHP: maxHP,
        ac: ac,
        speed: speed,
        size: size,
        type: type,
        stats: stats,
        savingThrows: savingThrows,
        senses: senses,
        languages: languages,
        proficiency: proficiency,
        resistances: resistances,
        immunites: immunites,
        conditionImmunities: conditionImmunities,
        passiveAbilities: passiveAbilities,
        attacks: attacks,
        turn: null
    ) {
        Race = race;
        HP = hp;
        TakeTurn = _TakeTurn;
    }

    public override void RollInitiative() {
        int initiative = -1;
        while(initiative == -1) {
            try {
                Console.WriteLine($"Enter {Name}'s Initiative:");
                initiative = Convert.ToInt32(Console.ReadLine());
            } catch {}
        }
        Initiative = initiative;
    }
    void _TakeTurn() {
        while(true){
            Console.WriteLine($"Who does {Name} attack? Type exit to finish");
            for(int i = 0; i < Targets.Count; i++) {
                Console.WriteLine($"{i+1}. {Targets[i].Name}");
            }
            int choice = -1;
            while(choice < 0 | choice > Targets.Count - 1) {
                string temp = Console.ReadLine();
                if(temp == "exit") return;
                try {
                    choice = Convert.ToInt32(temp) - 1;
                } catch {}
            }
            IDamageable target = Targets[choice];
            Console.WriteLine("How much damage?");
            int damage = -1;
            while(damage == -1) {
                try {
                    damage = Convert.ToInt32(Console.ReadLine());
                } catch {}
            }
            target.HP -= damage;
        }
    }
}