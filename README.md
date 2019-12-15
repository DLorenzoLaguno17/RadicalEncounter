Radical Encounter is a God Game in which the player is in charge of a group of activists that are defending their little village against a series of different enemy soldiers which will try to
subdue your fellow citizens and friends. Those evil soldiers are going to attack them and also damage the buildings and the
infrastructure of the place, so you will have both to assist the people and repair the patrimony, all with the help of the resources you will acquire by slaining and saving your comrades. 

Check out our [GitHub repository](https://github.com/DLorenzoLaguno17/RadicalEncounter) or [download](https://github.com/DLorenzoLaguno17/RadicalEncounter/releases) the last version of Radical Encounter!

# Index
* [About the game](#about-the-game)
    * [Characters](#characters)
      * [Activists](#activists)
      * [Military](#military)
      * [Citizens](#citizens)
    * [Areas](#areas)
      * [Camp](#camp)
      * [Urban center](#urban-center)
      * [Outskirts](#outskirts)
    * [Game mechanics](#game-mechanics)
* [Credits](#credits)
    * [Authors of the game](#authors-of-the-game)    
    * [Music](#music)    
    * [Sound effects](#sound-effects)
* [License](#license)

# About the game

## Characters

### Activists
The activist agents are the defenders of the place. They will patrol around certain zones of the map, watching for possible threads. If they see a soldier attacking a citizen they will come in their aid, but if they are badly hurt they will retire to the ase camp to get healed from their wounds.

![Map](https://github.com/DLorenzoLaguno17/RadicalEncounter/blob/master/Images/A_BT.PNG?raw=true)

*Activists' behaviour tree*

### Military
The soldiers are the wicked men attacking the village. Their main objective is to arrive to the center of the town, but if they have an encounter with the citizens they will defenitely pursue and attack them. Besides, the military has a high chance of start attacking the different buildings of the map as they go through its streets, harming them and even burning them down.

<p align="center">
  <img src="https://github.com/DLorenzoLaguno17/RadicalEncounter/blob/master/Images/M_BT.PNG?raw=true" alt="Military BT" width="900" height="300">
</p>

*Military's behaviour tree*

### Citizens
The villagers are simple people trying to live a normal live. They will try to have a walk around the streets of their lovely town, but in case they see an enemy they will flee. Besides, if the player needs to repair a building, the two of them nearest to it will have to aproach in order to repair it. There is also a small chance for them to join the activists at the end of every day.

<p align="center">
  <img src="https://github.com/DLorenzoLaguno17/RadicalEncounter/blob/master/Images/C_BT.PNG?raw=true" alt="Citizen BT" width="450" height="500">
</p>

*Citizens' behaviour tree*

## Areas
### Camp
The camp is the safest area of the town. In it, there are all the hospital tents and the majority of the activist forces, and it is the most important place if they want to survive. It must be kept safe from the enemy at all cost.

### Urban center
The urban center is where most of the action is developed, and there is where all three different types of characters interact with each other.

### Outskirts
The outskirts are from where all the enemies will enter the city. There are two different accesses, one of the north of the city and the other at its south.

<p align="center">
  <img src="https://github.com/DLorenzoLaguno17/RadicalEncounter/blob/master/Images/Map.png?raw=true" alt="Map" width="900" height="600">
</p>

*Radical Encounter's map*

## Game mechanics
The game consists on resisting a certain number of waves of enemies, and the player succeds if it does not get the camp destroyed, manages to mantain at least one activist alive until the last day and the buildings of the town does not go below five. At the moment one of those conditions fails, the player looses. Each wave there are more enemies and that increases the difficulty as the game goes by. 

Each type of character spawns following its own rules. First, as previousaly stated, the soldiers spawn in a higher number each wave. Second, the player starts with five activists, and there will not appear more of them unless they are recruited. To end, the game starts with five citizens, and each round spawn more or less of them depending on how remained from the last one and how much buildings are still standing.

Furthermore, the player interaction with the game consists basically in two different actions:

The first one is **repairing a building**. Since the military may destroy different copnstructions and will wreak havoc through the place, the user will be able to command a couple of activists to repair a building. For that, they must click on a building and then click repair, and the nearest citizen to that building will perform that task.

The second action is **recruiting another activist**. Due to the continuous waves of enemies, there will be needed a source of people to defense the town, so the player will be able of recruiting activists that will ally to the cause by an specific amount of money.

The player can also move the camera:
* A - Move it clockwise.
* D - Move it counterclockwise.

# Credits

## Authors of the game
This game has been developed by two third course students of the  [Bachelor's Degree in Video Games by UPC at CITM](https://www.citm.upc.edu/ing/estudis/graus-videojocs/), [Daniel Lorenzo](https://www.linkedin.com/in/daniel-lorenzo-laguno-a2ab35180/) & [Jacobo Galofre](https://www.linkedin.com/in/jgalofre/).

<p align="center">
  <img src="https://github.com/DLorenzoLaguno17/RadicalEncounter/blob/master/Images/Members.PNG?raw=true" alt="Members" width="450" height="320">
</p>

*At the left Jacobo Galofre, at the right, Daniel Lorenzo*

## Music
Game theme from https://filmmusic.io 
"Prelude and action" by [Kevin MacLeod](https://incompetech.com)
License: CC BY (http://creativecommons.org/licenses/by/4.0/)

Menu theme from https://filmmusic.io 
"Dangerous" by [Kevin MacLeod](https://incompetech.com)
License: CC BY (http://creativecommons.org/licenses/by/4.0/)

## Sound effects
All the sound effects used in Radical Encounter have been taken from different videogames:
* Soldier hurt: Minecraft.
* Activist / citizen hurt: Super Smash Bros (from Link).
* You lost: Dark Souls.
* You resisted: Civilization VI.

# License

    MIT License
    Copyright (c) 2019 Dani Lorenzo & Jacobo Galofre

    Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
    documentation files (the "Software"), to deal in the Software without restriction, including without limitation
    the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
    and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all copies or substantial portions 
    of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
    TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
    CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
    DEALINGS IN THE SOFTWARE.

Go [back to top](#index).
