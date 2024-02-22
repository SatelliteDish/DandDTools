using System.ComponentModel;

public class Encounter {
    List<IHasInitiative> _particpants;
    public List<IHasInitiative> Participants {
        get => _particpants;
        set => _particpants = value;
    }

    public Encounter(List<IHasInitiative> participants) {
        Participants = participants;
    }
    public void Start() {
        foreach(IHasInitiative participant in Participants) {
            participant.RollInitiative();
        }
        bool inProgress = true;
        while(inProgress) {
            foreach(IHasInitiative participant in Participants) {
                Console.WriteLine(participant.Initiative);
            }
            inProgress = false;
        }

    }
    /*//Bubble Sort
    public void SortParticipantsByInitiative() {
        for(int i = 0; i < Participants.Count - 1; i++) {
            for(int j = 0; j < Participants.Count - i - 1; j++) {
                IHasInitiative current = Participants[i];
                IHasInitiative next = Participants[i+1]?? current;
                if() {
                    
                }
            }
        }
    }*/
} 