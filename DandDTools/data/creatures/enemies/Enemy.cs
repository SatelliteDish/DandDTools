public class Enemy: Creature {
    float _challenge;

    public Enemy(
        string name,
        int hp,
        int ac,
        int speed,
        CreatureSize size,
        CreatureType type,
        StatData stats,
        StatData savingThrows,
        float challenge,
        Dictionary<SenseType, int> senses,
        List<LanguageType> languages,
        List<DamageType> resistances = null,
        List<DamageType> immunites = null,
        List<Conditions> conditionImmunities = null,
        List<PassiveAbilityList.PassiveAbility> passiveAbilities = null,
        Dictionary<Weapon,int> attacks = null
    ):base(name: name, hp: hp, ac:ac, speed: speed, size: size, type: type, stats: stats, savingThrows: savingThrows, senses: senses, languages: languages, resistances: resistances, immunites: immunites, conditionImmunities: conditionImmunities, passiveAbilities: passiveAbilities) {
        _challenge = challenge;
    }
}