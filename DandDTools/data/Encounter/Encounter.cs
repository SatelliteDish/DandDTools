using System.ComponentModel;

public class Encounter {
    public List<ICombatParticipant> Participants { get; set; }

    public Encounter(List<ICombatParticipant> participants) {
        Participants = participants;
    }
    public void Start() {
        foreach(ICombatParticipant participant in Participants) {
            participant.RollInitiative();
        }
        SortParticipantsByInitiative();
        bool inProgress = true;
        while(inProgress) {
            foreach(ICombatParticipant participant in Participants) {
                Console.WriteLine($"{participant.Name} got {participant.Initiative}");
                participant.TakeTurn();
                Console.WriteLine("-------------------------------");
            }
            inProgress = false;
        }

    }
    //Bubble Sort
    public void SortParticipantsByInitiative() {
        for(int i = 0; i < Participants.Count - 1; i++) {
            for(int j = 0; j < Participants.Count - 1; j++) {
                ICombatParticipant current = Participants[j];
                ICombatParticipant next = Participants[j+1];
                if(current.Initiative > next.Initiative) {
                    ICombatParticipant temp = current;
                    Participants[j] = next;
                    Participants[j + 1] = temp;
                }
            }
        }
    }
} 