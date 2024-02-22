class Program {

    static void Main(string[] args) {
        EnemyList enemyList = new EnemyList();
        List<IHasInitiative> creatures = new List<IHasInitiative> {enemyList.Goblin("Gob"),enemyList.Goblin("Lin"),enemyList.Goblin("Goblin"),enemyList.Goblin("Obli")};
        Encounter encounter = new Encounter(creatures);
        encounter.Start();
    }
}