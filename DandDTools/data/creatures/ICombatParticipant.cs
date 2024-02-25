public interface ICombatParticipant {
    public string Name { get; init; }
    public int Initiative { get; set; }
    public void RollInitiative();
    public delegate void Turn();
    public Turn TakeTurn { get; set; }  
}