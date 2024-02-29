# D&D Combat Helper
Currently this is a command line utility, but I would like to add a UI one day. The goal is to take care of some of more straightfoward aspects to DMing a combat encounter to allow the DM to focus more time and attention on the more complex and creative aspects of the game.

## Current Features
- Tracks all the enemies and players in an encounter
- Calls for each creature to take their turn in proper initiative orderit
- Removes dead creatures as targets
- Rolls HP, initiative, attack rolls, and damage rolls for each enemy.

## To-Do
- Add spells
- Add more enemies
- Have players be read from JSON files, allowing the values to be saved
- Make encounters end when all enemies or players are dead
- Add armour
- Add overloads to the enemy constructors to allow other parts of enemies to be customized ie. weapons

## How To Use
Create a new `Encounter` object, and you have to pass the constructor a `List<ICombatParticipant>`, then call the `Start()` method on the `Encounter`. When you run the program, it will prompt you to enter each players initiative. This allows all the players at the table to still roll the dice themselves. The same thing happens with the attacking phase, for players you will simply be asked to assign damage to any number of targets. Each `Enemy` has their entries copied over from the Monster Manual directly, including their turn structure. You will be shown a numbered list of your options each turn, just enter the number of the choice you would like to make and then combat will proceed. 