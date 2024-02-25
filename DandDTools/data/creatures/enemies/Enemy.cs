using System.Diagnostics.CodeAnalysis;
public class Enemy: Creature {
    public required float Challenge { get; init; }
    public string Species { get; set; }

    [SetsRequiredMembers]
    public Enemy(
        string name,
        string species,
        int maxHP,
        int ac,
        int speed,
        CreatureSize size,
        CreatureType type,
        StatData stats,
        StatData savingThrows,
        float challenge,
        Dictionary<SenseType, int> senses,
        int proficiency,
        List<LanguageType> languages,
        List<DamageType>? resistances = null,
        List<DamageType>? immunites = null,
        List<Conditions>? conditionImmunities = null,
        List<PassiveAbilityList.PassiveAbility>? passiveAbilities = null,
        List<Weapon>? attacks = null,
        ICombatParticipant.Turn? turn = null
    ):base(
        name: name,
        maxHP: maxHP,
        ac:ac,
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
        turn: turn
        ) {
        Challenge = challenge;
        Species = species;
    }
}