using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
//author: Rebecca Vessal
//Instructor: Professor Whittington
//Date: 2/13/11
//
//TankGame.cs
//
//TankGame.cs contains the code for the TankGameForm that is essentially the form in which the players play the
//tank game.
namespace MileStone4
{
    public partial class TankGameForm : Form
    {
        //Create a player 1 object
        Player player1;
        //Create a player 2 object
        Player player2;
        //Create a String attribute to hold the first player name
        String firstPlayerName;
        //Create a String attribute to hold the second player name
        String secondPlayerName;
        //Create a String attribute to hold the map file name
        String mapFileName;
        //Create an attribute for collection of tanks list
        List<Tank> collectionOfTanks;
        //Create an attribute for collection of walls list
        List<Wall> collectionOfWalls;
        //Create an attribute for collection of bullets list
        List<Bullet> collectionOfBullets = new List<Bullet>();
        //Create an attribute for the list of buttons
        List<Button> collectionOfButtons = new List<Button>();
        //Create a list of objects that are represented by buttons
        //that have collided with one object
        List<Button> objectCollided = new List<Button>();
        //Create a counter to keep track of collisions occured
        //int checkCollision;
        //Create a boolean variable to keep track of collisions occured
        //Set collsion to true only when a collsion occured
        bool collision = false;
        //Create separate boolean variables for objects to detect collisions
        //If tank 1 collides with something then set this variable to true
        bool tank1Collision = false;
        //If tank 2 collides with something then set this variable to true
        bool tank2Collision = false;
        //If bullet 1 collides with something then set this variable to true
        bool bullet1Collision = false;
        //If bullet 2 collides with something then set this variable to true
        bool bullet2Collision = false;
      
        
        //Create an attribute for the list of tank direction image buttons
        //List<Button> collectionOfTankDirectionButtons = new List<Button>();
        //Create an attribute for the button
        //Button imageButton;
        public TankGameForm()
        {
            InitializeComponent();
            
        }
        
        //Create a parameterized constructor to initialize the attributes
        public TankGameForm(String firstPlayerName, String secondPlayerName, String mapFileName)
        {
            //Make TankGame form appear
            InitializeComponent();
            //Use this class to prevent shadowing local variables
            this.firstPlayerName = firstPlayerName;
            this.secondPlayerName = secondPlayerName;
            this.mapFileName = mapFileName;
            //Initialize player 1 and 2
            player1 = new Player();
            player2 = new Player();
            
            //Set the form size to 800 pixels wide and 600 pixels tall
            //Create a Size object that will contain the right size for the Tank Game form
            Size dimensionsOfTankGameForm = new Size(GameConstants.GAME_WIDTH, GameConstants.GAME_HEIGHT);
            //Set the size of the Tank Game form to this size
            Size = dimensionsOfTankGameForm;

            //Set the Title property to Tank Game
            Text = "Tank Game";
            //Create a MapFile object
            MapFile map;
            //Create a bool variable to keep track of whether an exception occured or not
            //bool mapExist = true;
            //Use try and catch to prevent exceptions of loading a non-existant map file
            try
            {
                //Create a MapFile object
                map = new MapFile(mapFileName);
                //Call the loadData method of MapFile to get the data to be used in the creation of the game map
                map.LoadData(mapFileName);
                
            }
            catch (Exception e)
            {
                //Set mapExist to false since the user entered an invalid map file that does not exist
                //mapExist = false;
                //Load the basicmap file if exception occurs
                //Create a MapFile object
                map = new MapFile("basicmap.txt");
                //Call the loadData method of MapFile to get the data to be used in the creation of the game map
                map.LoadData("basicmap.txt");
            }
            
            //Call the start method of the timer to start the timer
            timer1.Start();
            //Grab 2 tank objects from MapFile object and store them into a Tank list
            collectionOfTanks = map.Tanks;
            //Get 2 tanks from the collection and keep them as separate attributes
            /*
            Tank tank1 = collectionOfTanks[0];
            Tank tank2 = collectionOfTanks[1];
            */
            //Grab all of the wall objects from MapFile object and store them in a Wall list
            collectionOfWalls = map.Walls;
            //Load different images of 1st tank depending on its direction as stated by the data in the map file
            switch (collectionOfTanks[0].Direction)
            {
                //Load the image for 1st tank if it is facing up
                case 0:
                    {
                        loadImages("GreenTank0.jpg", collectionOfTanks[0].LocationX, collectionOfTanks[0].LocationY);
                        break;
                    }
                //Load the image for 1st tank if it is facing right
                case 1:
                    {
                        loadImages("GreenTank1.jpg", collectionOfTanks[0].LocationX, collectionOfTanks[0].LocationY);
                        break;
                    }
                //Load the image for 1st tank if it is facing down
                case 2:
                    {
                        loadImages("GreenTank2.jpg", collectionOfTanks[0].LocationX, collectionOfTanks[0].LocationY);
                        break;
                    }
                //Load the image for 1st tank if it is facing left
                case 3:
                    {
                        loadImages("GreenTank3.jpg", collectionOfTanks[0].LocationX, collectionOfTanks[0].LocationY);
                        break;
                    }
            }
            //Load different images of 2nd tank depending on its direction as stated by the data in the map file
            switch (collectionOfTanks[1].Direction)
            {
                //Load the image for 2nd tank if it is facing up
                case 0:
                    {
                        loadImages("RedTank0.jpg", collectionOfTanks[1].LocationX, collectionOfTanks[1].LocationY);
                        break;
                    }
                //Load the image for 2nd tank if it is facing right
                case 1:
                    {
                        loadImages("RedTank1.jpg", collectionOfTanks[1].LocationX, collectionOfTanks[1].LocationY);
                        break;
                    }
                //Load the image for 2nd tank if it is facing down
                case 2:
                    {
                        loadImages("RedTank2.jpg", collectionOfTanks[1].LocationX, collectionOfTanks[1].LocationY);
                        break;
                    }
                //Load the image for 2nd tank if it is facing left
                case 3:
                    {
                        loadImages("RedTank3.jpg", collectionOfTanks[1].LocationX, collectionOfTanks[1].LocationY);
                        break;
                    }
            }
        
            //Load the image of the walls and add them to the form
            for (int i = 0; i <= 5; i++)
            {
                loadImages("Wall.jpg", collectionOfWalls[i].LocationX, collectionOfWalls[i].LocationY);
            }
            //Create 2 bullet objects
            Bullet bullet1 = new Bullet();
            Bullet bullet2 = new Bullet();
            //Add them to the list collectionOfBullets
            collectionOfBullets.Add(bullet1);
            collectionOfBullets.Add(bullet2);
            //Go through a loop to set the coordinates of the bullets
            //and load a picture of them onto a button that will be added to the form
            for (int j = 0; j <= 1; j++)
            {
                if (j == 0)
                {
                    //Set the coordinates of the bullets
                    collectionOfBullets[j].LocationX = -100;
                    collectionOfBullets[j].LocationY = -100;
                    //Load image of the bullet for tank 1 and add it to the form
                    loadBulletImages("Bullet.png", collectionOfBullets[j].LocationX, collectionOfBullets[j].LocationY);
                }
                if (j == 1)
                {
                    //Set the coordinates of the bullets
                    collectionOfBullets[j].LocationX = 900;
                    collectionOfBullets[j].LocationY = -100;
                    //Load image of the bullet for tank 1 and add it to the form
                    loadBulletImages("Bullet.png", collectionOfBullets[j].LocationX, collectionOfBullets[j].LocationY);
                }
            }
            //Make the form as the active component
            this.Select();
            
        }
        //Create a method that will load images that are 60 by 60 pixels and add them to the form
        private void loadImages(String nameOfImage, int locationX, int locationY)
        {
            //Load the image as a Bitmap object
            Bitmap imageBitmap = new Bitmap(nameOfImage);
            //Create a Button object
            Button imageButton = new Button();
            //Set height and width to 60 by 60
            imageButton.Height = 60;
            imageButton.Width = 60;
            //Set Image property of button to the loaded image file
            imageButton.Image = imageBitmap;
            //Set the location of the Tank button
            imageButton.Location = new Point(locationX, locationY);
            
                /*
                switch (name)
                {
                    case 0:
                        {
                            imageButton.Text = "Tank 1";
                            break;
                        }
                    case 1:
                        {
                            imageButton.Text = "Tank 2";
                            break;
                        }
                    case 2:
                        {
                            imageButton.Text = "Wall 1";
                            break;
                        }
                    case 3:
                        {
                            imageButton.Text = "Wall 2";
                            break;
                        }
                    case 4:
                        {
                            imageButton.Text = "Wall 3";
                            break;
                        }
                    case 5:
                        {
                            imageButton.Text = "Wall 4";
                            break;
                        }
                    case 6:
                        {
                            imageButton.Text = "Wall 5";
                            break;
                        }
                    case 7:
                        {
                            imageButton.Text = "Wall 6";
                            break;
                        }

                }
                name++;*/
            //Add button to the form 
            Controls.Add(imageButton);
            //Add button to button list
            collectionOfButtons.Add(imageButton);
            
            //Make the button appear on the screen
            this.Refresh();
        }
        //Create a method that will load the bullet images and add them to the form
        private void loadBulletImages(String nameOfImage, int locationX, int locationY)
        {
            //Load the image as a Bitmap object
            Bitmap imageBitmap = new Bitmap(nameOfImage);
            //Create a Button object
            Button imageButton = new Button();
            //Set height and width to 32 by 32
            imageButton.Height = 32;
            imageButton.Width = 32;
            //Set Image property of button to the loaded image file
            imageButton.Image = imageBitmap;
            //Set the location of the Tank button
            imageButton.Location = new Point(locationX, locationY);
            //Add button to the form 
            Controls.Add(imageButton);
            //Add button to button list
            collectionOfButtons.Add(imageButton);
            //Make the button appear on the screen
            this.Refresh();
        }
        /*
        //Create a method that will load different direction of tank images that are 60 by 60 pixels and add them to the form
        public void changeTankDirectionImages(String nameOfImage, int locationX, int locationY)
        {
            //Load the image as a Bitmap object
            Bitmap imageBitmap = new Bitmap(nameOfImage);
            //Create a Button object
            Button imageButton = new Button();
            //Set height and width to 60 by 60
            imageButton.Height = 60;
            imageButton.Width = 60;
            //Set Image property of button to the loaded image file
            imageButton.Image = imageBitmap;
            //Set the location of the Tank button
            imageButton.Location = new Point(locationX, locationY);
            //Add button to the form 
            Controls.Add(imageButton);
            //Add button to button list
            collectionOfTankDirectionButtons.Add(imageButton);
            //Make the button appear on the screen
            this.Refresh();
        }
        */
        /*
        //Create a method that will delete buttons with images on them that are 60 by 60 pixels from the form
        public void deleteImages(String nameOfImage, int locationX, int locationY)
        {
            //Load the image as a Bitmap object
            Bitmap imageBitmap = new Bitmap(nameOfImage);
            //Create a Button object
            Button imageButton = new Button();
            //Set height and width to 60 by 60
            imageButton.Height = 60;
            imageButton.Width = 60;
            //Set Image property of button to the loaded image file
            imageButton.Image = imageBitmap;
            //Set the location of the Tank button
            imageButton.Location = new Point(locationX, locationY);
            //Add button to the form 
            Controls.Remove(imageButton);
            //Make the button appear on the screen
            this.Refresh();
        }
        */
        
        //Create a method that will process the keys
        private void processTankDirectionKeys(String tankDirectionImage, int playerNum)
        {
            //Create a Bitmap object with the tank direction image
            Bitmap tankImage = new Bitmap(tankDirectionImage);
            //Set that button to new image that has a different tank direction
            collectionOfButtons[playerNum].Image = tankImage;
            //Get previous direction
            //previousDirectionOfTank = collectionOfBullets[playerNum].Direction;
            
        }
        //Create a method that will move the bullet near the muzzle of the respective tank
        private void moveBulletNearTank(int playerNum, int bulletNum)
        {
            //If the tank is facing to the up have the bullet on its top side
            if (collectionOfTanks[playerNum].Direction == 0)
            {
                //Only decrease the y location of the bullet since it's on the top side of tank
                //Take the image size of the tank into consideration
                collectionOfButtons[bulletNum].Location = new Point(collectionOfButtons[playerNum].Location.X, collectionOfButtons[playerNum].Location.Y - 32);
                //If player 1's tank
                if (playerNum == 0)
                {
                    //Set its bullet direction to up
                    collectionOfBullets[0].Direction = 0;
                }
                //If player 2's tank
                if (playerNum == 1)
                { 
                    //Set its bullet direction to up
                    collectionOfBullets[1].Direction = 0;
                }

            }
            //If the tank is facing to the right have the bullet on its right side
            if (collectionOfTanks[playerNum].Direction == 1)
            {
                //Only increase the x location of the bullet since it's on the right side
                //Take the image size of the tank into consideration
                collectionOfButtons[bulletNum].Location = new Point(collectionOfButtons[playerNum].Location.X + 61, collectionOfButtons[playerNum].Location.Y);
                //If player 1's tank
                if (playerNum == 0)
                {
                    //Set its bullet direction to the right
                    collectionOfBullets[0].Direction = 1;
                }
                //If player 2's tank
                if (playerNum == 1)
                {
                    //Set its bullet direction to the right
                    collectionOfBullets[1].Direction = 1;
                }
            }
            //If the tank is facing to the down have the bullet on its bottom side
            if (collectionOfTanks[playerNum].Direction == 2)
            {
                //Only increase the y location of the bullet since it's on the bottom side
                //Take the image size of the tank into consideration
                collectionOfButtons[bulletNum].Location = new Point(collectionOfButtons[playerNum].Location.X, collectionOfButtons[playerNum].Location.Y + 61);
                //If player 1's tank
                if (playerNum == 0)
                {
                    //Set its bullet direction to down
                    collectionOfBullets[0].Direction = 2;
                }
                //If player 2's tank
                if (playerNum == 1)
                {
                    //Set its bullet direction to down
                    collectionOfBullets[1].Direction = 2;
                }
            }

            //If the tank is facing left have the bullet on its left side
            if (collectionOfTanks[playerNum].Direction == 3)
            {
                //Only decrease the x location of the bullet since it's on the left side
                //Take the image size of the tank into consideration
                collectionOfButtons[bulletNum].Location = new Point(collectionOfButtons[playerNum].Location.X - 32, collectionOfButtons[playerNum].Location.Y);
                //If player 1's tank
                if (playerNum == 0)
                {
                    //Set its bullet direction to left
                    collectionOfBullets[0].Direction = 3;
                }
                //If player 2's tank
                if (playerNum == 1)
                {
                    //Set its bullet direction to left
                    collectionOfBullets[1].Direction = 3;
                }
            }
        }
        //Create an attribute that will hold the key input from the user
        //List<Keys> keyInput = new List<Keys>();
        //Add a keydown event to the form
        private void TankGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Keep processing keys until the player stopped inputting key values
            switch (e.KeyCode)
            {
                //Cases in which the players are moving their tanks
                //If first player pressed W key
                case Keys.W:
                {
                    //Call the processTankDirectionKeys method to process the key and change the direction of the Tank
                    //to up
                    processTankDirectionKeys("GreenTank0.jpg", 0);
                    //Set the direction of the actual tank
                    collectionOfTanks[0].Direction = 0;
                    //Add the key to the keyInput list
                    //keyInput.Add(Keys.W);
                    break;
                }
                //If first player pressed the D key
                case Keys.D:
                {
                    //Call the processTankDirectionKeys to process the key that will change the tank direction
                    //to right
                    processTankDirectionKeys("GreenTank1.jpg", 0);
                    //Set the direction of the actual tank
                    collectionOfTanks[0].Direction = 1;
                    //Add the key to the keyInput list
                    //keyInput.Add(Keys.D);
                    break;
                }
                //If first player pressed the S key
                case Keys.S:
                {
                    //Call the processTankDirectionKeys to process the key that will change the tank direction
                    //to down
                    processTankDirectionKeys("GreenTank2.jpg", 0);
                    //Set the direction of the actual tank
                    collectionOfTanks[0].Direction = 2;
                    //Add the key to the keyInput list
                    //keyInput.Add(Keys.S);
                    break;
                }
                //If first player pressed the A key
                case Keys.A:
                {
                    //Call the processTankDirectionKeys to process the key that will change the tank direction
                    //to the left
                    processTankDirectionKeys("GreenTank3.jpg", 0);
                    //Set the direction of the actual tank
                    collectionOfTanks[0].Direction = 3;
                    //Add the key to the keyInput list
                    //keyInput.Add(Keys.A);
                    break;
                }
                //If second player pressed the I key
                case Keys.I:
                {
                    //Call the processTankDirectionKeys to process the key that will change player 2's tank direction
                    //to up
                    processTankDirectionKeys("RedTank0.jpg", 1);
                    //Set the direction of the actual tank
                    collectionOfTanks[1].Direction = 0;
                    //Add the key to the keyInput list
                    //keyInput.Add(Keys.I);
                    break;
                }
                //If second player pressed the L key
                case Keys.L:
                {
                    //Call the processTankDirectionKeys to process the key that will change player 2's tank direction
                    //to right
                    processTankDirectionKeys("RedTank1.jpg", 1);
                    //Set the direction of the actual tank
                    collectionOfTanks[1].Direction = 1;
                    //Add the key to the keyInput list
                    //keyInput.Add(Keys.L);
                    break;
                }
                //If second player pressed the K key
                case Keys.K:
                {
                    //Call the processTankDirectionKeys to process the key that will change player 2's tank direction
                    //to down
                    processTankDirectionKeys("RedTank2.jpg", 1);
                    //Set the direction of the actual tank
                    collectionOfTanks[1].Direction = 2;
                    //Add the key to the keyInput list
                    //keyInput.Add(Keys.K);
                    break;
                }
                //If second player pressed the J key
                case Keys.J:
                {
                    //Call the processTankDirectionKeys to process the key that will change player 2's tank direction
                    //to the left
                    processTankDirectionKeys("RedTank3.jpg", 1);
                    //Set the direction of the actual tank
                    collectionOfTanks[1].Direction = 3;
                    //Add the key to the keyInput list
                    //keyInput.Add(Keys.J);
                    break;
                }

                //Cases in which the players fire bullets
                //Player 2 input F to fire bullet
                case Keys.F:
                {
                    //Make sure that player 1 can fire a bullet first
                    if (collectionOfTanks[0].CanFire == true)
                    {
                        //Call the method for moving the bullet nearby the muzzle of the tank
                        //Move the bullet nearby player 1's tank
                        moveBulletNearTank(0, 8);
                    }
                    //Set canFire attribute of Tank 1 to be false
                    collectionOfTanks[0].CanFire = false;
                    //Add the key to the keyInput list
                    //keyInput.Add(Keys.F);
                    break;
                }
                //Player 2 input H to fire bullet
                case Keys.H:
                {
                    //Make sure that player 2's tank can fire a bullet first
                    if (collectionOfTanks[1].CanFire == true)
                    {
                        //Call the method for moving the bullet nearby the muzzle of the tank
                        //Move the bullet nearby player 2's tank
                        moveBulletNearTank(1, 9);
                    }
                    //Set canFire attribute of Tank 2 to false
                    collectionOfTanks[1].CanFire = false;
                    //Add the key to the keyInput list
                    //keyInput.Add(Keys.H);
                    break;
                }
                    
            }

            
        }
        
        //Create a private method that will move the tanks that will move based on its current direction
        private void tankMovement(int playerNum)
        {
            
            //See which direction the tank is facing
            switch (collectionOfTanks[playerNum].Direction)
            {
                //If tank's direction is up
                case 0:
                {
                    //If bullet is still on board then move it
                    if (collectionOfButtons[playerNum].Location.Y <= GameConstants.GAME_HEIGHT
                        && collectionOfButtons[playerNum].Location.Y >= 0)
                    {
                        //Move the tank button up by the TANK_SPEED constant
                        collectionOfButtons[playerNum].Location = new Point(collectionOfButtons[playerNum].Location.X,
                            collectionOfButtons[playerNum].Location.Y - GameConstants.TANK_SPEED);
                    }
                        
                    break;
                }
                //If tank's direction is right
                case 1:
                {
                    //If the tank is not going off of the board then move it
                    if (collectionOfButtons[playerNum].Location.X + 60 <= GameConstants.GAME_WIDTH &&
                        collectionOfButtons[playerNum].Location.X + 60 >= 0)
                    {
                        //Move the tank button right by the TANK_SPEED constant
                        collectionOfButtons[playerNum].Location = new Point(collectionOfButtons[playerNum].Location.X + GameConstants.TANK_SPEED,
                            collectionOfButtons[playerNum].Location.Y);
                    }
                    break;
                }
                //If tank's direction is down
                case 2:
                {
                    //If the tank is not going off of the board then move it
                    if (collectionOfButtons[playerNum].Location.Y + 60 <= GameConstants.GAME_HEIGHT &&
                        collectionOfButtons[playerNum].Location.Y + 60 >= 0)
                    {
                        //Move the tank button down by the TANK_SPEED constant
                        collectionOfButtons[playerNum].Location = new Point(collectionOfButtons[playerNum].Location.X,
                            collectionOfButtons[playerNum].Location.Y + GameConstants.TANK_SPEED);
                    }
                    break;
                }
                //If tank's direction is left
                case 3:
                {
                    //If the tank does not go off of the board then move it
                    if (collectionOfButtons[playerNum].Location.X <= GameConstants.GAME_WIDTH &&
                        collectionOfButtons[playerNum].Location.X >= 0)
                    {
                        //Move the tank button left by the TANK_SPEED constant
                        collectionOfButtons[playerNum].Location = new Point(collectionOfButtons[playerNum].Location.X - GameConstants.TANK_SPEED,
                            collectionOfButtons[playerNum].Location.Y);
                    }
                    break;
                }
            }
            
        }

        //Create a private method that will move the bullets
        private void bulletMovement(int playerNum, int bulletNum)
        {
            //Check to see which way the bullet is facing
            switch (collectionOfBullets[playerNum].Direction)
            {
                //If bullet's direction is up
                case 0:
                {
                    //If the bullet is not going off of the board then move it
                    if (collectionOfButtons[bulletNum].Location.Y <= GameConstants.GAME_HEIGHT
                        && collectionOfButtons[bulletNum].Location.Y >= 0)
                    {
                        //Move the bullet button up by the BULLET_SPEED constant
                        collectionOfButtons[bulletNum].Location = new Point(collectionOfButtons[bulletNum].Location.X,
                            collectionOfButtons[bulletNum].Location.Y - GameConstants.BULLET_SPEED);
                    }
                    //If bullet is going off of the board then move it back to -100, 100
                    //Set its direction to 0
                    //Set the canFire property of corresponding tank to true
                    else
                    {
                        if (bulletNum == 8)
                        {
                            //Move it back to -100, -100
                            collectionOfButtons[bulletNum].Location = new Point(-100, -100);
                        }
                        if (bulletNum == 9)
                        {
                            //Move it back to -100, -100
                            collectionOfButtons[bulletNum].Location = new Point(900, -100);
                        }
                        //Set its direction back to 0
                        collectionOfBullets[playerNum].Direction = 0;
                        //Set canFire of corresponding tank to true
                        collectionOfTanks[playerNum].CanFire = true;

                    }
                    break;
                }
                //If bullet's direction is right
                case 1:
                {
                    //If the bullet is not going off of the board then move it
                    if (collectionOfButtons[bulletNum].Location.X + 32 <= GameConstants.GAME_WIDTH &&
                        collectionOfButtons[bulletNum].Location.X + 32 >= 0)
                    {
                        //Move the bullet button right by the BULLET_SPEED constant
                        collectionOfButtons[bulletNum].Location = new Point(collectionOfButtons[bulletNum].Location.X + GameConstants.BULLET_SPEED,
                            collectionOfButtons[bulletNum].Location.Y);
                    }
                    //If bullet is going off of the board then move it back to -100, 100
                    //Set its direction to 0
                    //Set the canFire property of corresponding tank to true
                    else
                    {
                        //Move it back to -100, -100
                        collectionOfButtons[bulletNum].Location = new Point(-100, -100);
                        //Set its direction back to 0
                        collectionOfBullets[playerNum].Direction = 0;
                        //Set canFire of corresponding tank to true
                        collectionOfTanks[playerNum].CanFire = true;

                    }
                    break;
                }
                //If bullet's direction is down
                case 2:
                {
                    //If the bullet is not going off of the board then move it
                    if (collectionOfButtons[bulletNum].Location.Y + 32 <= GameConstants.GAME_HEIGHT &&
                        collectionOfButtons[bulletNum].Location.Y + 32 >= 0)
                    {
                        //Move the tank button down by the BULLET_SPEED constant
                        collectionOfButtons[bulletNum].Location = new Point(collectionOfButtons[bulletNum].Location.X,
                            collectionOfButtons[bulletNum].Location.Y + GameConstants.BULLET_SPEED);
                    }
                    //If bullet is going off of the board then move it back to -100, 100
                    //Set its direction to 0
                    //Set the canFire property of corresponding tank to true
                    else
                    {
                        //Move it back to -100, -100
                        collectionOfButtons[bulletNum].Location = new Point(-100, -100);
                        //Set its direction back to 0
                        collectionOfBullets[playerNum].Direction = 0;
                        //Set canFire of corresponding tank to true
                        collectionOfTanks[playerNum].CanFire = true;

                    }
                    break;
                }
                //If bullet's direction is left
                case 3:
                {
                    //If the tank does not go off of the board then move it
                    if (collectionOfButtons[bulletNum].Location.X <= GameConstants.GAME_WIDTH &&
                        collectionOfButtons[bulletNum].Location.X >= 0)
                    {
                        //Move the tank button left by the TANK_SPEED constant
                        collectionOfButtons[bulletNum].Location = new Point(collectionOfButtons[bulletNum].Location.X - GameConstants.BULLET_SPEED,
                            collectionOfButtons[bulletNum].Location.Y);
                    }
                    //If bullet is going off of the board then move it back to -100, 100
                    //Set its direction to 0
                    //Set the canFire property of corresponding tank to true
                    else
                    {
                        //Move it back to -100, -100
                        collectionOfButtons[bulletNum].Location = new Point(-100, -100);
                        //Set its direction back to 0
                        collectionOfBullets[playerNum].Direction = 0;
                        //Set canFire of corresponding tank to true
                        collectionOfTanks[playerNum].CanFire = true;

                    }
                    break;
                }
            }
        }
        //Create variables for top, left, right, and bottom
        int top;
        int left;
        int right;
        int bottom;
        //Create methods that will calculate the top, right, left, and bottom of the objects
        //Create a method that will calculate the top, right, left, and bottom of tank
        private void calculateTankDimensions(int num)
        {
            //Set top to y coordinate of tank1
            top = collectionOfButtons[num].Location.Y;
            //Set left to x coordinate of tank1
            left = collectionOfButtons[num].Location.X;
            //Set right to height of Tank object image and x coordinate of tank1
            right = GameConstants.IMAGE_HEIGHT + collectionOfButtons[num].Location.X-1;
            //Set bottom to width of Tank object image and y coordinate of tank1
            bottom = GameConstants.IMAGE_WIDTH + collectionOfButtons[num].Location.Y-1;
        }
        //Create a method that will calculate the top, right, left, and bottom of wall
        private void calculateWallDimensions(int num)
        {
            //Set Top1 to y coordinate of tank1
            top = collectionOfButtons[num].Location.Y;
            //Console.WriteLine(top1);
            //Set Left1 to x coordinate of tank1
            left = collectionOfButtons[num].Location.X;
            //Set Right1 to height of Tank object image and x coordinate of wall
            right = GameConstants.IMAGE_HEIGHT + collectionOfButtons[num].Location.X-1;
            //Set bottom1 to width of Tank object image and y coordinate of wall
            bottom = GameConstants.IMAGE_WIDTH + collectionOfButtons[num].Location.Y-1;
        }
        //Create a method that will calcuate the top, right, left, and bottom of bullet
        private void calculateBulletDimensions(int num)
        {
            //Set Top1 to y coordinate of tank1
            top = collectionOfButtons[num].Location.Y;
            //Console.WriteLine(top1);
            //Set Left1 to x coordinate of tank1
            left = collectionOfButtons[num].Location.X;
            //Set Right1 to height of Bullet object image and x coordinate of bullet
            right = GameConstants.BULLET_HEIGHT + collectionOfButtons[num].Location.X-1;
            //Set bottom1 to width of Bullet object image and y coordinate of bullet
            bottom = GameConstants.BULLET_WIDTH + collectionOfButtons[num].Location.Y-1;
        }
        //Create a method that will calculate the top1, right1, left1, and bottom1 of tank
        private void calculateAltTankDimensions(int playerNum)
        {
            //Set Top1 to y coordinate of tank
            top1 = collectionOfButtons[playerNum].Location.Y;
            //Console.WriteLine(top1);
            //Set Left1 to x coordinate of tank
            left1 = collectionOfButtons[playerNum].Location.X;
            //Set Right1 to height of Tank object image and x coordinate of tank
            right1 = GameConstants.IMAGE_WIDTH + collectionOfButtons[playerNum].Location.X-1;
            //Set bottom1 to width of Tank object image and y coordinate of tank
            bottom1 = GameConstants.IMAGE_HEIGHT + collectionOfButtons[playerNum].Location.Y-1;
        }
        //Create a method that will calcuate the top1, right1, left1, and bottom of bullet
        private void calculateAltBulletDimensions(int bulletNum)
        {
            //Set Top1 to y coordinate of tank2
            top1 = collectionOfButtons[bulletNum].Location.Y;
            //Console.WriteLine(top1);
            //Set Left1 to x coordinate of tank2
            left1 = collectionOfButtons[bulletNum].Location.X;
            //Set Right1 to height of Tank object image and x coordinate of tank2
            right1 = GameConstants.BULLET_WIDTH + collectionOfButtons[bulletNum].Location.X-1;
            //Set bottom1 to width of Tank object image and y coordinate of tank2
            bottom1 = GameConstants.BULLET_HEIGHT + collectionOfButtons[bulletNum].Location.Y-1;
        }
        
        //Initialize top, left, right, and bottom
        int top1 = 0;
        int left1 = 0;
        int right1 = 0;
        int bottom1 = 0;
        //Copy and paste the collides method from previous work
        //Make changes so that it detects button collisions
        public List<Button> collides(Button button)
        {
            if (collision == true)
            {
                //int collisionCount = objectCollided.Count;
                while (objectCollided.Count > 0)
                {
                    
                    //Empty out objectCollided list first
                    //for (int i = 0; i < objectCollided.Count; i++)
                    //{
                        objectCollided.RemoveRange(0,objectCollided.Count);
                    //}
                   
                }
                //Console.WriteLine(objectCollided.Count);
            }
            //List<Button> colButton = new List<Button>();
            //objectCollided = null;
            //If the button tested is tank 1
            if (button == collectionOfButtons[0])
            {
                //Calculate the top1, bottom1, right1, and left1 of tank1
                calculateAltTankDimensions(0);
                //Check to see if tank 1 collides with anything
                collisionDetection(1, 2, 3, 4, 5, 6, 7, 9, button);
            }
            //collectionOfButtons[1].Name = "tank 2";
            //If button tested is tank 2
            if (button.Equals(collectionOfButtons[1]))
            { 
                //Calculate the top1, buttom1, right1, and left1 of tank 2
                calculateAltTankDimensions(1);
                //Check to see if tank 2 collides with anything
                collisionDetection(0, 2, 3, 4, 5, 6, 7, 8, button);
            }
            if (collectionOfTanks[0].CanFire == false)
            {
                //If button tested is bullet 1
                if (button == collectionOfButtons[8])
                {
                    //Calculate the top1, bottom1, right1, and left1 of bullet 1
                    calculateAltBulletDimensions(8);
                    //Check to see if bullet 1 collides with anything
                    collisionDetection(1, 2, 3, 4, 5, 6, 7, 9, button);
                }
            }
            //If button tested is bullet 2
            if (button == collectionOfButtons[9])
            { 
                //Calculate the top1, botom1, right1, and left1 of bullet 2
                calculateAltBulletDimensions(9);
                //Check to see if bullet 2 collides with anything
                collisionDetection(0, 2, 3, 4, 5, 6, 7, 8, button);
            }
            //Reset button
            //button = null;
            //Return the list of objects collided with each other
            return objectCollided;

        }
        //Create a method that will check an object button against everything
        private void collisionDetection(int tankNum, int wallNum1, int wallNum2,
            int wallNum3, int wallNum4, int wallNum5, int wallNum6, int bulletNum, 
            Button button)
        {
            //Check to see if it collides with anything
            foreach (Button otherButtons in collectionOfButtons)
            {
                //If otherbutton is tank
                if (otherButtons == collectionOfButtons[tankNum])
                {
                    //Calculate the top, bottom, left, and right of tank
                    calculateTankDimensions(tankNum);
                    //Situations in which no collisions occur
                    if (bottom1 < top || top1 > bottom
                            || right1 < left || left1 > right)
                    {

                    }
                    else
                    {
                        //Set collision to true
                        collision = true;
                        //If button is tank 1
                        if (button == collectionOfButtons[0])
                        { 
                            //Set tank1Collision to true
                            tank1Collision = true;
                        }
                        //If button is tank 2
                        if (button == collectionOfButtons[1])
                        { 
                            //Set tank2Collison to true
                            tank2Collision = true;
                        }
                        //If button is bullet 1
                        if (button == collectionOfButtons[8])
                        { 
                            //Set bullet1Collision to true
                            bullet1Collision = true;
                            //Update the number of hits on tank 2
                            collectionOfTanks[1].Hits++;

                           
                        }
                        //If button is bullet 2
                        if (button == collectionOfButtons[9])
                        { 
                            //Set bullet2Collision to true
                            bullet2Collision = true;
                            //Update the number of hits on tank1
                            collectionOfTanks[0].Hits++;
                   
                        }

                        //Set tank1 collision to true
                        //tank1Collision = true;
                        //Add tank 1 to collision list
                        objectCollided.Add(button);
                        //Add tank 2 to collision list
                        objectCollided.Add(collectionOfButtons[tankNum]);
                    }
                }
                //If otherbutton is wall 1
                if (otherButtons == collectionOfButtons[wallNum1])
                {
                    //Call the method to detect wall collisions
                    wallCollisions(wallNum1, button);

                }
                //If otherbutton is wall 2
                if (otherButtons == collectionOfButtons[wallNum2])
                {
                    //Call the method to detect wall collisions
                    wallCollisions(wallNum2, button);

                }
                //If otherbutton is wall 3
                if (otherButtons == collectionOfButtons[wallNum3])
                {
                    //Call the method to detect wall collisions
                    wallCollisions(wallNum3, button);

                }
                //If otherbutton is wall 4
                if (otherButtons == collectionOfButtons[wallNum4])
                {
                    //Call the method to detect wall collisions
                    wallCollisions(wallNum4, button);

                }
                //If otherbutton is wall 5
                if (otherButtons == collectionOfButtons[wallNum5])
                {
                    //Call the method to detect wall collisions
                    wallCollisions(wallNum5, button);

                }
                //If otherButton is wall 6
                if (otherButtons == collectionOfButtons[wallNum6])
                {
                    //Call the method to detect wall collisions
                    wallCollisions(wallNum6, button);

                }
                //If otherButton is bullet
                if (otherButtons == collectionOfButtons[bulletNum])
                {
                    //Calculate the bullet top, bottom, right. left
                    calculateBulletDimensions(bulletNum);
                    //Situations in which collisions don't occur
                    if (bottom1 < top || top1 > bottom
                            || right1 < left || left1 > right)
                    {

                    }
                    else
                    {
                        //Set collision to true
                        collision = true;
                        //If button is tank 1
                        if (button == collectionOfButtons[0])
                        {
                            //Set tank1Collision to true
                            tank1Collision = true;
                        }
                        //If button is tank 2
                        if (button == collectionOfButtons[1])
                        {
                            //Set tank2Collison to true
                            tank2Collision = true;
                        }
                        //If button is bullet 1
                        if (button == collectionOfButtons[8])
                        {
                            //Set bullet1Collision to true
                            bullet1Collision = true;
                
                        }
                        //If button is bullet 2
                        if (button == collectionOfButtons[9])
                        {
                            //Set bullet2Collision to true
                            bullet2Collision = true;
                           
                        }
                        //Set tank1 collision to true
                        //tank1Collision = true;
                        //Add tank 1 to collision list
                        objectCollided.Add(button);
                        //Add tank 2 to collision list
                        objectCollided.Add(collectionOfButtons[bulletNum]);
                    }


                }
            }
        }
        
        //Create a method to detect wall collisons
        private void wallCollisions(int wallNum, Button button)
        {
            //Calculate the top, bottom, left, and right of wall 1
            calculateWallDimensions(wallNum);
            //calculateAltTankDimensions(0);
            //Situations in which no collisions occur
            if (bottom1 < top || top1 > bottom
                    || right1 < left || left1 > right)
            {

            }
            else
            {
                //Set collision to true
                collision = true;
                //If button is tank 1
                if (button == collectionOfButtons[0])
                {
                    //Set tank1Collision to true
                    tank1Collision = true;
                    
                }
                //If button is tank 2
                if (button == collectionOfButtons[1])
                {
                    //Set tank2Collison to true
                    tank2Collision = true;
                }
                //If button is bullet 1
                if (button == collectionOfButtons[8])
                {
                    //Set bullet1Collision to true
                    bullet1Collision = true;
                    
                }
                //If button is bullet 2
                if (button == collectionOfButtons[9])
                {
                    //Set bullet2Collision to true
                    bullet2Collision = true;
                    
                }
                //Set tank1 collision to true
                //tank1Collision = true;
                //Add test object to collision list
                objectCollided.Add(button);
                //Add wall 1 to collision list
                objectCollided.Add(collectionOfButtons[wallNum]);
            }
        }
        //Create a random object
        Random randomNum = new Random();
        //Create a respawn method
        private void respawn()
        {
            //Create a random number in between 0 to 740
            int randomLocationX = randomNum.Next(0,740);
            //Create a random number in between 0 to 540
            int randomLocationY = randomNum.Next(0,540);
            if(collectionOfTanks[0].Hits == 2)
            {
                //Update the number of tanks destoryed in respective player object
                player1.lostTank();
                //If player has not lost of all their tanks then respawn again
                if (player1.TanksLost>0 && player1.TanksLost<=4)
                {
                    //Change the location of tank1 to a random location
                    collectionOfButtons[0].Location = new Point(randomLocationX, randomLocationY);
                    //Reset hits back to 0
                    collectionOfTanks[0].Hits = 0;
                    //Set tank1Collision to false
                    tank1Collision = false;
                    collides(collectionOfButtons[0]);
                    //If tank collides with something on respawn again
                    while (tank1Collision == true)
                    {
                        //Create a random number in between 0 to 740
                        randomLocationX = randomNum.Next(0, 740);
                        //Create a random number in between 0 to 540
                        randomLocationY = randomNum.Next(0, 540);
                        collectionOfButtons[0].Location = new Point(randomLocationX, randomLocationY);
                        tank1Collision = false;
                        collides(collectionOfButtons[0]);
                    }
                }
                
                
            }
            if (collectionOfTanks[1].Hits == 2)
            {
                //Update the number of tanks destoryed in respective player object
                player2.lostTank();
                //If player hasn't lost all of their tanks then respawn
                if (player2.TanksLost>0 && player2.TanksLost<=4)
                {
                    //Change the location of tank2 to a random location
                    collectionOfButtons[1].Location = new Point(randomLocationX, randomLocationY);
                    //Reset hits back to 0
                    collectionOfTanks[1].Hits = 0;
                    //set tank2Collision to false
                    tank2Collision = false;
                    collides(collectionOfButtons[1]);
                    //If tank collides with something on respawn again
                    while (tank2Collision == true)
                    {
                        //Create a random number in between 0 to 740
                        randomLocationX = randomNum.Next(0, 740);
                        //Create a random number in between 0 to 540
                        randomLocationY = randomNum.Next(0, 540);
                        collectionOfButtons[1].Location = new Point(randomLocationX, randomLocationY);
                        tank2Collision = false;
                        collides(collectionOfButtons[1]);
                    }
                }
                
            }
        }
        //Tell which player has lost the game first
        //A player must lose 5 tanks in order to lose the game
        public void Lose()
        {
            //Stop the timer
            timer1.Stop();
            
            if (player1.TanksLost == 5)
            {
                //Create an object of the Winner form with its parameterized constructor
                //Enter the text from the textboxes as the parameters for the parameterized constructor
                Winner winner = new Winner(secondPlayerName, 2);
                //Call the ShowDialog method from Winner form object
                winner.ShowDialog();
                //Call the Dispose to clean up when you are done with winner form
                winner.Dispose();
                Dispose();
            }
            if (player2.TanksLost == 5)
            {
                //Create an object of the Winner form with its parameterized constructor
                //Enter the text from the textboxes as the parameters for the parameterized constructor
                Winner winner = new Winner(firstPlayerName, 1);
                //Call the ShowDialog method from Winner form object
                winner.ShowDialog();
                //Call the Dispose to clean up when you are done with winner form
                winner.Dispose();
                Dispose();
            }
        }
        //Add a Tick event to the form
        private void timer1_Tick(object sender, EventArgs e)
        {
      
            //Checking for collisons
            //Go through the button list
            foreach (Button button in collectionOfButtons)
            {
                //Check to see if the button is tank1
                if (button == collectionOfButtons[0])
                {

                    //Tank 1 as test object
                    objectCollided = collides(collectionOfButtons[0]);
                    if (tank1Collision == true)
                    {
                        //Check to see if collision occured with tank1
                        if (objectCollided.Contains(collectionOfButtons[0]))
                        {
                            //If tank direction is right
                            if (collectionOfTanks[0].Direction == 1)
                            {
                                //Move the tank 1 pixel back to the left
                                collectionOfButtons[0].Location = new Point(collectionOfButtons[0].Location.X - 1, collectionOfButtons[0].Location.Y);
                            }
                            //If tank direction is left
                            if (collectionOfTanks[0].Direction == 3)
                            {
                                //Move the tank 1 pixel back to the right
                                collectionOfButtons[0].Location = new Point(collectionOfButtons[0].Location.X + 1, collectionOfButtons[0].Location.Y);
                            }
                            //If tank direction is up
                            if (collectionOfTanks[0].Direction == 0)
                            {
                                //Move the tank 1 pixel back down
                                collectionOfButtons[0].Location = new Point(collectionOfButtons[0].Location.X, collectionOfButtons[0].Location.Y + 1);
                            }
                            //If tank direction is down
                            if (collectionOfTanks[0].Direction == 2)
                            {
                                //Move the tank 1 pixel back up
                                collectionOfButtons[0].Location = new Point(collectionOfButtons[0].Location.X, collectionOfButtons[0].Location.Y - 1);
                            }

                        }
                        //If the tank direction changes then allow movement
                        if (collectionOfTanks[0].ChangeDirection == true)
                        {
                            //collides(collectionOfButtons[0]);
                            if (objectCollided.Contains(collectionOfButtons[0]))
                            {

                            }

                            else
                            {
                                tank1Collision = false;
                                tankMovement(0);
                            }

                            //Set changeDirection of tank to false
                            collectionOfTanks[0].ChangeDirection = false;

                        }

                    }
                }   
                //If collideButtons is tank2 then stop tank 2's movement
                if (button.Equals(collectionOfButtons[1]))
                {
                    //Tank 2 as test object
                    objectCollided = collides(collectionOfButtons[1]);
                    if (tank2Collision == true)
                    {
                        //Check to see if collision occured with tank2
                        if (objectCollided.Contains(collectionOfButtons[1]))
                        {
                            //If tank direction is right
                            if (collectionOfTanks[1].Direction == 1)
                            {
                                //Move the tank 1 pixel back to the left
                                collectionOfButtons[1].Location = new Point(collectionOfButtons[1].Location.X - 1,
                                    collectionOfButtons[1].Location.Y);
                            }
                            
                            //If tank direction is left
                            if (collectionOfTanks[1].Direction == 3)
                            {
                                //Move the tank 1 pixel back to the right
                                collectionOfButtons[1].Location = new Point(collectionOfButtons[1].Location.X + 1,
                                    collectionOfButtons[1].Location.Y);
                            }
                            //If tank direction is up
                            if (collectionOfTanks[1].Direction == 0)
                            {
                                //Move the tank 1 pixel back down
                                collectionOfButtons[1].Location = new Point(collectionOfButtons[1].Location.X,
                                    collectionOfButtons[1].Location.Y + 1);
                            }
                            //If tank direction is down
                            if (collectionOfTanks[1].Direction == 2)
                            {
                                //Move the tank 1 pixel back up
                                collectionOfButtons[1].Location = new Point(collectionOfButtons[1].Location.X,
                                    collectionOfButtons[1].Location.Y - 1);
                            }

                        }
                            //If the tank direction changes then allow movement
                            if (collectionOfTanks[1].ChangeDirection == true)
                            {
                                //If there is still a collision then don't allow it to move
                                if (objectCollided.Contains(collectionOfButtons[1]))
                                {

                                }
                                //If there are no collisions then move it
                                else
                                {
                                    tank2Collision = false;
                                    tankMovement(1);
                                }

                                //Set changeDirection of tank to false
                                collectionOfTanks[1].ChangeDirection = false;

                            }

                        }
                    
                }
                    
                //If collideButtons is bullet1 then stop bullet 1's movement
                if (button == collectionOfButtons[8])
                {
                    //Call bullet collision
                    collides(collectionOfButtons[8]);
                    if (collectionOfTanks[0].CanFire == false)
                    {

                        if (bullet1Collision == true)
                        {
                            //Move it back to -100, -100
                            collectionOfButtons[8].Location = new Point(-100, -100);
                            //Set its direction back to 0
                            collectionOfBullets[0].Direction = 0;
                            //Set canFire of corresponding tank to true
                            collectionOfTanks[0].CanFire = true;
                            //Set bullet1Collision false
                            bullet1Collision = false;
                        }
                    }
                }
                
                
                //If bullet 2 collided with anything then don't move it
                if (button == collectionOfButtons[9])
                {
                    //Check to see if there are any collisions for bullet 2
                    collides(collectionOfButtons[9]);
                    if (bullet2Collision == true)
                    {
                        //Move it back to -100, -100
                        collectionOfButtons[9].Location = new Point(900, -100);
                        //Set its direction back to 0
                        collectionOfBullets[1].Direction = 0;
                        //Set canFire of corresponding tank to true
                        collectionOfTanks[1].CanFire = true;
                        //Set bullet2Collision to false
                        bullet2Collision = false;
                    }
                }
                /*
                //Otherwise move bullet 2
                else
                {
                    //Make sure a bullet has been fired first from tank 2
                    if (collectionOfTanks[1].CanFire == false)
                    {
                        //Move tank 2's bullet
                        //1- player 2's tank
                        //9 - location of tank 2's bullet in the collection of buttons list
                        bulletMovement(1, 9);
                    }
                }*/

                
            }
            //Call the respawn method
            respawn();
            
            if (tank1Collision == false && tank2Collision == true)
            { 
                //Move tank 1
                tankMovement(0);
            }
            if (tank1Collision == true && tank2Collision == false)
            { 
                //Move tank 2
                tankMovement(1);
            }
            //Situation in which no collisions occur
            if (objectCollided.Count == 0)
            {
                if (tank1Collision == false)
                {
                    //Move player 1's tank
                    tankMovement(0);
                }
                if (tank2Collision == false)
                {
                    //Move player 2's tank
                    tankMovement(1);
                }
                //Make sure a bullet has been fired first from tank 1
                if (collectionOfTanks[0].CanFire == false)
                {
                    //Move tank 1's bullet
                    //0 - player 1's tank
                    //8 - location of tank 1's bullet in the collection of buttons list
                    bulletMovement(0, 8);
                }
                //Make sure a bullet has been fired first from tank 2
                if (collectionOfTanks[1].CanFire == false)
                {
                    //Move tank 2's bullet
                    //1- player 2's tank
                    //9 - location of tank 2's bullet in the collection of buttons list
                    bulletMovement(1, 9);
                }
            }
            //Call the lose method if either player lost
            if (player1.TanksLost == 5 || player2.TanksLost == 5)
            {
                Lose();
            }

        }
        
    }

}
