class Program {

    static void Main(string[] args) {
        WeaponList weaponList = WeaponList.Instance;
        MeleeWeapon weapon = weaponList.Shortsword();
        RangedWeapon rangedWeapon = weaponList.Longbow();
        weapon.RollDamage();
        rangedWeapon.RollDamage();
        Console.WriteLine($"name is {rangedWeapon.Name} and range is {rangedWeapon.NormalRange}-{rangedWeapon.MaxRange}");
    }
}