//author: Rebecca Vessal
//Instructor: Professor Whittington
//Date: 12/8/10 - 1/22/10
//
//Tank.cs
//
//Represents a Tank in the game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MileStone4
{
    class Tank
    {
        //Declare the necessary attributes for a Tank
        private int health;
        private int locationX;
        private int locationY;
        private int direction;
        private int playerID;
        private bool deadStatus;
        private int hits;
        private bool canFire;
        private bool changeDirection;
        //Default constructor for Tank
        public Tank()
        {
            //Set reasonable default values for the Tank attributes
            health = GameConstants.MAX_LIVES;
            locationX = 0;
            locationY = 0;
            direction = 1;
            playerID = 1;
            deadStatus = false;
            hits = 0;
            canFire = true;

        }
        public Tank(int locationX, int locationY, int direction, int playerID)
        {
            health = GameConstants.MAX_LIVES;
            //Prevent the local variable shadowing the attributes by using the this.
            this.locationX = locationX;
            this.locationY = locationY;
            this.direction = direction;
            this.playerID = playerID;
            deadStatus = false;
            hits = 0;
            canFire = true;
        }
        
        //Create properties that will get and set the tank attribtues
        //Property for getting and setting health
        public int Health
        {
            get { return health; }
            //Tanks start out with 2 hitpoints
            set 
            {
                health = GameConstants.MAX_LIVES;
            }

        }
        //Property for getting and setting the x-coordinate location of the Tank 
        public int LocationX
        {
            get { return locationX; }
            //Create if and else statements to allow only valid moves
            set
            {
                if (value<0)
                {
                    locationX = 0;
                }
                else
                {
                    locationX = value;
                }
                
                
            }

        }
        //Property for getting and setting the y-coordinate location of the Tank 
        public int LocationY
        {
            get { return locationY; }
            //Create if and else statements to allow only valid moves
            set
            {
                if (value < 0)
                {
                    locationY = 0;
                }
                else
                {
                    locationY = value;
                }
                
            }

        }
        //Property for getting and setting the direction of the Tank
        public int Direction
        {
            get { return direction; }
            set
            {
                //Create a switch statement for direction
                switch (value)
                {
                    //If the direction value is 0, then the tank is facing up
                    case 0:
                    {
                        if (direction != value)
                        {
                            changeDirection = true;
                        }
                        direction = value;
                        break;
                    }
                    //If the direction value is 1, then the tank is facing to the right
                    case 1:
                    {
                        if (direction != value)
                        {
                            changeDirection = true;
                        }
                        direction = value;
                        break;
                    }
                    //If the direction value is 2, then the tank is facing down
                    case 2:
                    {
                        if (direction != value)
                        {
                            changeDirection = true;
                        }
                        direction = value;
                        break;
                    }
                    //If the direction value is 3, then the tank is facing to the left
                    case 3:
                    {
                        if (direction != value)
                        {
                            changeDirection = true;
                        }
                        direction = value;
                        break;
                    }
                    //If the user inputs an invalid direction value, then have the tank face up
                    default:
                    {
                        direction = 0;
                        break;
                    }
                }
            }
        }
        //Property for getting and setting the hit attribute of Tank
        public int Hits
        {
            get { return hits; }
            set
            {
                //hits value must be in between 1 and 2 inclusive in order to be considered a valid hit
                /*if (value<=2  && value>0)
                {
                    hits = value;
                }*/
                hits = value;
            }
        }
        //Keep track of which Player owns the Tank
        public int PlayerID
        {
            get { return playerID; }
            set 
            { 
                //player value must be in between 1 and 2 inclusive since there are only 2 players in this game
                if (value > 0 && value< 3)
                {
                    playerID = value;
                }
                
            }
        }
        //Property for getting and setting the dead or alive status of the Tank
        public bool DeadStatus
        {
            get { return deadStatus; }
            set 
            {
                deadStatus = false;
            }
        }
        //Property for getting and setting the canFire capability of the Tank
        public bool CanFire
        {
            get { return canFire; }
            set 
            {
                canFire = value;
            }
        }
        //Create a property for Tank change direction
        public bool ChangeDirection
        {
            get { return changeDirection; }
            set
            {
                changeDirection = value;
            }
        }

        //Create a takeHit method that adjusts the health value as the tank gets hit
        public int takeHit(int hit)
        {
            if (health > 0 && health < 3)
            {
                //Subtract the health from the hit received
                health -= hit;
            }
            return health;
        }
        //Create a hit method that increments the number of hits a tank has received
        public int increaseHit(int damage)
        {
            if (health>0 && health <3)
            {
                //Increment the hits based on the user's input of damage
                hits += damage;
            }
            return hits;
        }
        //Create a isDead method that returns a boolean value indicating if the tank is dead or not
        public bool isDead()
        {

            if (health <= 0)
            {
                deadStatus = true;
                canFire = false;
                Console.WriteLine("Tank" + playerID +  " is dead");
            }
            else
            {
                deadStatus = false;
                canFire = true;
                Console.WriteLine("Tank is not dead");
            }
            return false;
        }
        
        //Create another move method
        public void move(ConsoleKey[] keyPressed1)
        {
            //If player 1
            if (playerID == 1)
            {
                for (int i = 0; i < keyPressed1.Length; i++)
                {
                    //Console.WriteLine(keyPressed1[i]);

                    //If player 1 presses W then the tank 
                    //should move 2 spaces up
                    if (keyPressed1[i] == ConsoleKey.W)
                    {
                        if (locationY >= 0 && locationY <= GameConstants.GAME_HEIGHT)
                        {
                            //Move 2 spaces to the right
                            locationY = locationY + GameConstants.TANK_SPEED;
                            //Since the tank is moving down, change the direction to down
                            direction = 0;
                        }
                    }
                    //If player 1 presses D then the tank 
                    //should move 2 to the right
                    if (keyPressed1[i] == ConsoleKey.D)
                    {
                        if (locationX >= 0 && locationX <= GameConstants.GAME_WIDTH)
                        {
                            //Move 2 spaces to the right
                            locationX = locationX + GameConstants.TANK_SPEED;
                            //Since the tank is moving to the right change the direction to right
                            direction = 1;
                        }
                    }
                    //If player 1 presses S then the tank 
                    //should move 2 spaces down
                    if (keyPressed1[i] == ConsoleKey.S)
                    {
                        if (locationY >= 1 && locationY <= GameConstants.GAME_HEIGHT)
                        {
                            //Move 2 spaces up 
                            locationY = locationY - GameConstants.TANK_SPEED;
                            //Since the tank is moving up change the direction to up
                            direction = 2;
                        }
                    }
                    //If player 1 presses S then the tank 
                    //should move 2 spaces to the left
                    if (keyPressed1[i] == ConsoleKey.A)
                    {
                        if (locationX > 1 && locationX <= GameConstants.GAME_WIDTH)
                        {
                            //Move 2 spaces to the left
                            locationX = locationX - GameConstants.TANK_SPEED;
                            //Since the tank is moving to the right, change the direction to the left
                            direction = 3;

                        }
                    }
                }
            }
            if(playerID == 2)
            {
                for (int i = 0; i < keyPressed1.Length; i++)
                {

                    //If player 2 presses I then the tank
                    //moves 2 spaces up
                    if (keyPressed1[i] == ConsoleKey.I)
                    {
                        if (locationY >= 0 && locationY <= GameConstants.GAME_HEIGHT)
                        {
                            //Move 2 spaces up
                            locationY = locationY + GameConstants.TANK_SPEED;
                            //Change direction to up
                            direction = 0;
                        }
                    }
                    //If player 2 presses L then the tank
                    //moves 2 spaces to the right
                    if (keyPressed1[i] == ConsoleKey.L)
                    {
                        if (locationX >= 0 && locationX <= GameConstants.GAME_WIDTH)
                        {
                            //Move 2 spaces to the right
                            locationX = locationX + GameConstants.TANK_SPEED;
                            //Change direction to right
                            direction = 1;
                        }
                    }
                    //If player 2 presses K then the tank 
                    //should move 2 spaces down
                    if (keyPressed1[i] == ConsoleKey.K)
                    {
                        if (locationY >= 1 && locationY <= GameConstants.GAME_HEIGHT)
                        {
                            //Move 2 spaces up 
                            locationY = locationY - GameConstants.TANK_SPEED;
                            //Change the direction to down
                            direction = 2;
                        }
                    }
                    //If player 2 presses J then the tank
                    //moves 2 spaces to the left
                    if (keyPressed1[i] == ConsoleKey.J)
                    {
                        if (locationX > 1 && locationX <= GameConstants.GAME_WIDTH)
                        {
                            //Move 2 spaces to the left
                            locationX = locationX - GameConstants.TANK_SPEED;
                            //Change direction to left
                            direction = 3;
                        }
                    }
                }

            }
            
        }
        //Create a moveTank method that will move the tank based on
        //the keys that the players input
        public void moveTank(ConsoleKey[] keyPressed2)
        {
            switch (direction)
            {
                //If the tank is facing up
                case 0:
                {
                    //Call the move method that 
                    //will move the tank based on the key inputs
                    //and which player it is
                    move(keyPressed2);
                    break;
                }
                //If the tank is facing right
                case 1:
                {
                    //Call the move method that 
                    //will move the tank based on the key inputs
                    //and which player it is
                    move(keyPressed2);
                    break;
                }
                //If the tank is facing down
                case 2:
                {
                    //Call the move method that 
                    //will move the tank based on the key inputs
                    //and which player it is
                    move(keyPressed2);
                    break;
                }
                //If the tank is facing left
                case 3:
                {
                    //Call the move method that 
                    //will move the tank based on the key inputs
                    //and which player it is
                    move(keyPressed2);
                    break;
                }
            }
        }        

        //Override the ToString method to list the attributes
        public override String ToString()
        {
            return "Tank - " +
                "\tPlayer ID: " + playerID + 
                "\tHealth:  " + health + 
                "\tDirection:  " + direction + 
                "\tLocation:  " + locationX +"," + locationY +
                 "\tHits: " + hits + 
                 "\tCan Fire: " +  canFire + 
                 "\tDead:  " + deadStatus;

        }

       

    }
}
