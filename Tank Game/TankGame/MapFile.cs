using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//author: Rebecca Vessal
//Instructor: Professor Whittington
//Date: 1/30/11 - 2/5/11
//
//MapFile.cs
//
//MapFile.cs makes sure that the file exists and if it does then it loads the data in that file
//into the tank and wall objects
namespace MileStone4
{
    class MapFile
    {
        //Create an attribute that will hold a collection of tank objects
        private List<Tank> tanks;
        //Create an attribute that will hold a collection of wall objects
        private List<Wall> walls;
        //Create an attribute for the name of the map file
        private String nameOfMap;

        //Create a parameterized constructor that will accept the file name and see if it exists
        public MapFile(String name)
        {
            //Initialize the lists
            tanks = new List<Tank>();
            walls = new List<Wall>();
            //Set the name of map file to the file name passed through the paraemters of the parameterized constructor
            nameOfMap = name;
            try
            {
                //Create an instance of reader and read the file
                StreamReader reader = new StreamReader(nameOfMap);
            }
            catch (FileNotFoundException fe)
            {
                //Create an Exception object and throw it so that FileNotFoundException is caught in the TankGame class
                Exception exception = new Exception();
                throw exception;
                
            }

        }

        //Create a method that will download the data from the file and apply it to the tanks
        public void LoadData(String name)
        {
            //Create a bool that will keep track of whether the file can be open or not            
            bool fileCanOpen = true;
            try
            {

                //Open and read the file with StreamReader
                StreamReader numberReader = new StreamReader(name);

            }
            //Throw an exception if the file cannot be opened
            catch (FileNotFoundException notOpen)
            {
                //If file cannot be open set fileCan Open to false
                fileCanOpen = false;
                //Print out error message
                Console.WriteLine(notOpen.Message);
            }
            //If file can be open then continue
            if (fileCanOpen == true)
            {
                //Open and read the file with StreamReader
                StreamReader numberReader = new StreamReader(name);
                //Create a counter to keep track of how many lines were read
                int numberOfTanks = 0;
                //Read the 1st 2 lines and apply those data to the Tank
                for (int i = 0; i < 2; i++)
                {
                    //First read the lines as strings
                    //Get the first line and store it in a string variable
                    String tankInfoLine = numberReader.ReadLine();
                    //Separate the x location, y location, and direction of tank data from each other
                    String[] tankInfo = tankInfoLine.Split(',');
                    //Convert String into an int
                    int xLocation = int.Parse(tankInfo[0]);
                    int yLocation = int.Parse(tankInfo[1]);
                    int direction = int.Parse(tankInfo[2]);
                    //Increment the counter of numberOfTanks
                    numberOfTanks++;
                    switch (numberOfTanks)
                    {
                        //There will be 2 Tank objects
                        case 1:
                            {
                                //Pass the data read from the file to the tank parameter
                                Tank tank1 = new Tank(xLocation, yLocation, direction, 1);
                                //Add tank1 to the list of Tanks
                                tanks.Add(tank1);
                                break;
                            }
                        case 2:
                            {
                                //Fill in the parameters of tank2 with data read from the file
                                Tank tank2 = new Tank(xLocation, yLocation, direction, 2);
                                //Add tank2 to the list of Tanks
                                tanks.Add(tank2);
                                break;
                            }
                    }

                }
                /*foreach (Tank tank in tanks)
                {
                    Console.WriteLine(tank + "\n");
                }*/
                String getInfo = "";
                int numberOfWalls = 0;
                while (getInfo != null)
                {

                    //Get the next line of string
                    getInfo = numberReader.ReadLine();
                    if (getInfo != null)
                    {
                        //Separate the data from the line of string
                        //and store it into a string array
                        String[] wallInfo = getInfo.Split(',');
                        //Convert the string into int
                        int xWallLocation = int.Parse(wallInfo[0]);
                        int yWallLocation = int.Parse(wallInfo[1]);
                        //Increase the counter of numberOfWalls
                        numberOfWalls++;

                        switch (numberOfWalls)
                        {
                            case 1:
                                {
                                    //Fill in the wall object parameters with the data read from the file
                                    Wall wall1 = new Wall(xWallLocation, yWallLocation);
                                    //If the wall do not extend to the outside of the board then add it to the wall list
                                    if (xWallLocation <= GameConstants.GAME_WIDTH || yWallLocation <= GameConstants.GAME_HEIGHT)
                                    {
                                        //Add the wall to the list
                                        walls.Add(wall1);
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    //Fill in the wall object parameters with the data read from the file
                                    Wall wall2 = new Wall(xWallLocation, yWallLocation);
                                    //If the wall do not extend to the outside of the board then add it to the wall list
                                    if (xWallLocation <= GameConstants.GAME_WIDTH || yWallLocation <= GameConstants.GAME_HEIGHT)
                                    {
                                        //Add the wall to the list
                                        walls.Add(wall2);
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    //Fill in the wall object parameters with the data read from the file
                                    Wall wall3 = new Wall(xWallLocation, yWallLocation);
                                    //If the wall do not extend to the outside of the board then add it to the wall list
                                    if (xWallLocation <= GameConstants.GAME_WIDTH || yWallLocation <= GameConstants.GAME_HEIGHT)
                                    {
                                        //Add the wall to the list
                                        walls.Add(wall3);
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    //Fill in the wall object parameters with the data read from the file
                                    Wall wall4 = new Wall(xWallLocation, yWallLocation);
                                    //If the wall do not extend to the outside of the board then add it to the wall list
                                    if (xWallLocation <= GameConstants.GAME_WIDTH || yWallLocation <= GameConstants.GAME_HEIGHT)
                                    {
                                        //Add the wall to the list
                                        walls.Add(wall4);
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    //Fill in the wall object parameters with the data read from the file
                                    Wall wall5 = new Wall(xWallLocation, yWallLocation);
                                    //If the wall do not extend to the outside of the board then add it to the wall list
                                    if (xWallLocation <= GameConstants.GAME_WIDTH || yWallLocation <= GameConstants.GAME_HEIGHT)
                                    {
                                        //Add the wall to the list
                                        walls.Add(wall5);
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    //Fill in the wall object parameters with the data read from the file
                                    Wall wall6 = new Wall(xWallLocation, yWallLocation);
                                    //If the wall do not extend to the outside of the board then add it to the wall list
                                    if (xWallLocation <= GameConstants.GAME_WIDTH || yWallLocation <= GameConstants.GAME_HEIGHT)
                                    {
                                        //Add the wall to the list
                                        walls.Add(wall6);
                                    }
                                    break;
                                }

                        }
                    }

                }

                /*foreach (Wall wall in walls)
                {
                    Console.WriteLine(wall + "\n");
                }*/
            }

        }

        //Create property for the Tank list to get Tank values
        public List<Tank> Tanks
        {
            get { return tanks; }

        }
        //Create property for the Wall list to get Wall values
        public List<Wall> Walls
        {
            get { return walls; }
        }
    }
}