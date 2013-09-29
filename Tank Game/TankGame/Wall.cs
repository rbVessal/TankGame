//author: Rebecca Vessal
//Instructor: Professor Whittington
//Date: 12/8/10 - 12/16/10
//
//Wall.cs
//
//Represents a Wall in the game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MileStone4
{
    class Wall
    {
        private int locationX;
        private int locationY;
        //Create default constructor
        public Wall()
        {
            //Set the wall attributes to reasaonble values
            locationX = 40;
            locationY = 40;
        }
        //Create a parameterized constructor
        public Wall(int locationX, int locationY)
        {
            //Use the this method to prevent the local variables from shadowing the attributes
            this.locationX = locationX;
            this.locationY = locationY;
        }

        //Create Properties for Wall attributes
        //Property for setting and getting the x-coordinate location of the wall
        public int LocationX
        {
            get { return locationX; }
            set
            {
                //The x-coordinate of the wall cannot be negative
                if (value >= 0)
                {
                    locationX = value;
                }
            }

        }
        //Property for setting and getting the y-coordinate location of the wall
        public int LocationY
        {
            get { return locationY; }
            set
            {
                //The y-coordinate of the wall cannot be negative
                if (value >= 0)
                {
                    locationY = value;
                }
            }
        }
        //Create a ToString method that will list the Wall attributes and their values
        public override String ToString()
        {
            return "Location of Wall:  " + locationX + "," + locationY;
        }
    }
}
