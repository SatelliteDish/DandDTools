public interface ICombatParticipant: IHasName {
    public int Initiative { get; set; }
    public void RollInitiative();
    public delegate void Turn();
    public Turn TakeTurn { get; set; }  
}