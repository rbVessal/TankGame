//author: Rebecca Vessal
//Instructor: Professor Whittington
//Date: 12/8/10 - 12/16/10
//
//Player.cs
//
//Represents a Player in the game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MileStone4
{
    class Player
    {
        //Declare the neccessary attributes for the Player
        private String playerName;
        private int tanksLost;
        private Tank tank;
                
        //Create default constructor
        public Player()
        {
            //Assign reasonable default values to the Player attributes
            playerName = "Bob";
            tanksLost = 0;
        }
        //Create a parameterized constructor
        public Player(Tank tank1, String playerName, int tanksLost)
        {
            //Use the this method to prevent the local variables from shadowing the attributes
            tank = tank1;
            this.playerName = playerName;
            this.tanksLost = tanksLost;            
            
        }

        //Create Properties for Player attributes
        //Property for getting and setting the playerName attribute
        public String PlayerName
        {
            get { return playerName; }
            set 
            {
                playerName = value;
            }
        }
        //Property for getting and setting the tanksLost attribute
        public int TanksLost
        {
            get { return tanksLost; }
            set
            {
                //if (value > -1 && value < 5)
                //{
                    tanksLost = value;
                //}
                               
            }
        }

        
        //Track how many tanks they have lost
        public void lostTank()
        {
            /*if (tanksLost > -1 && tanksLost < 4)
            {
                tanksLost++;
            }*/
            tanksLost++;

        }
        //Tell which player has lost the game first
        //A player must lose 5 tanks in order to lose the game
        public void Lose()
        {
            if (tank.PlayerID == 1 && tanksLost == 4)
            {
                Console.WriteLine("All of player's 1 tanks are gone." + "\nPlayer 1 lost.");
            }
            if (tank.PlayerID == 2 && tanksLost == 4)
            {
                Console.WriteLine("All of player's 2 tanks are gone." + "\nPlayer 2 lost.");
            }
        }

        //Create a ToString method that lists out the Player attributes and their values
        public override String ToString()
        {
            return "Name:  " + playerName +
                "\tId:  " + tank.PlayerID +
                "\tTanks Lost:  " + tanksLost;
        }
    }
}
