class Program {

    static void Main(string[] args) {
        List<DamageData> damageDatas = new List<DamageData>();
        Random rng = new Random();
        damageDatas.Add(new DamageData(1,6,DamageData.DamageType.Piercing, rng));
        damageDatas.Add(new DamageData(1,8,DamageData.DamageType.Fire, rng));
        MeleeWeapon weapon = new MeleeWeapon(name: "Shortsword",damages: damageDatas, modifier: 1, WeaponType.Martial);
        weapon.RollDamage();
    }
}