//author: Rebecca Vessal
//Instructor: Professor Whittington
//Date: 12/8/10 - 1/22/10
//
//Bullet.cs
//
//Represents a bullet from a Tank in the game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MileStone4
{
    class Bullet
    {
        //Declare Bullet attributes
        private Tank tank;
        private int locationX;
        private int locationY;
        private int speed;
        private int direction;
        private bool isActive;
       
        //Create a default constructor
        public Bullet()
        { 
            //Set the attributes to reasonable values
            locationX = 0;
            locationY = 0;
            speed = GameConstants.BULLET_SPEED;
            direction = 0;
            isActive = false;
        }
        //Create a parameterized constructor
        public Bullet(Tank tank1, int locationX, int locationY, int direction, bool isActive)
        {
            //Assign tank to tank1 so that each bullet has a tank associated with it
            tank = tank1;
            //Assign speed to a constant of 8 pixels
            speed = GameConstants.BULLET_SPEED;
            //Use the this method to prevent local variables from shadowing the attributes
            this.locationX = locationX;
            this.locationY = locationY;
            this.direction = direction;
            this.isActive = isActive;
        }

        //Create Properties for Bullet attributes
        //Property for setting and getting the x-coordinate location of the bullet
        public int LocationX
        {
            get { return locationX; }
            set 
            {
                
                locationX = value;
                
            }

        }
        //Property for setting and getting the y-coordinate location of the bullet
        public int LocationY
        {
            get { return locationY; }
            set 
            {
                
                locationY = value;
                
            }
        }
        //Property for getting and setting the bullet's speed
        public int Speed
        {
            get { return speed; }
            //Since the bullet fixed speed is 8, the speed will always be 8 and cannot be changed
            set 
            {
                speed = GameConstants.BULLET_SPEED;
            }
        }
        //Property for getting and setting the direction of the bullet
        public int Direction
        {
            get { return direction; }
            //There are 4 possible directions for the bullet
            //0 - up
            //1 - right
            //2 - down
            //3 - left
            set 
            {
                switch (value)
                {
                    //Up
                    case 0:
                    {
                        direction = value;
                        break;
                    }
                    //Right
                    case 1:
                    {
                        direction = value;
                        break;
                    }
                    //Down
                    case 2:
                    {
                        direction = value;
                        break;
                    }
                    //Left
                    case 3:
                    {
                        direction = value;
                        break;
                    }
                    default:
                    {
                        direction = 0;
                        break;
                    }

                }
            }
        }
        //Property for getting and setting the whether the bullet is there or not
        public bool IsActive
        {
            get { return isActive; }
            set 
            {
                isActive = value;
            }
        }
        //Move the bullet in respective to direction
        public void move(int direction)
        {
           
            //Up
            if (direction == 0)
            {
                locationY += speed;
                //Change bullet direction to up
                Direction = 0;
            }
            //Right
            else if (direction == 1)
            {
                locationX += speed;
                //Change bullet direction to right
                Direction = 1;
            }
            //Down
            else if (direction == 2)
            {
                //To ensure the bullet is not in a negative location
                if (locationY >= 1)
                {
                    locationY -= speed;
                }
                //Change bullet direction to down
                Direction = 2;
            }
            //Left
            else if (direction == 3)
            {
                //To ensure that the bullet is not in a negative location
                if (LocationX >= 1)
                {
                    locationX -= speed;
                    //Change bullet direction to left
                    Direction = 3;
                }
            }
            
            
        }
        //Create a ToString method that will list out the Bullet attributes and their values
        public override String ToString()
        {
            return "Tank#: " + tank.PlayerID + "\nBullet - Location:  " + locationX + "," + locationY +
                " Direction:  " + direction +
                " Speed:  " + speed +
                " Is Active:  " + isActive;
        }

    }
}
