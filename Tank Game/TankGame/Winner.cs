using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//author: Rebecca Vessal
//Instructor: Professor Whittington
//Date: 2/20/11
//
//Winner.cs
//
//Represents the form that tells which player own
namespace MileStone4
{
    public partial class Winner : Form
    {
        public Winner()
        {
            InitializeComponent();
            winnerTextBox.Text = "";
        }
        public Winner(String winner, int playerNum)
        {
            InitializeComponent();
            winnerTextBox.Text = winner;
            //If player 1 then display his or her tank
            if (playerNum == 1)
            {
                loadImages("GreenTank0.jpg", 108 , 100);
            }
            //If player 2 then display his or her tank
            if (playerNum == 2)
            {
                loadImages("RedTank0.jpg", 108, 100);
            }
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
            //Add button to the form 
            Controls.Add(imageButton);
            //Make the button appear on the screen
            this.Refresh();
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            //Create an object of the second form, TankGame, with its parameterized constructor
            //Enter the text from the textboxes as the parameters for the parameterized constructor
            PlayerInfoForm form = new PlayerInfoForm();
            //Call the ShowDialog method from TankGame object
            form.ShowDialog();
            //Call the Dispose to clean up when you are done with second form
            form.Dispose();
        }

        private void nopeButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
