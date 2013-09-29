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
//Date: 2/10/11 - 2/20/11
//
//Form1.cs
//
//Represents the form in which the players input their name and the map file name
namespace MileStone4
{
    public partial class PlayerInfoForm : Form
    {
        /*
        //Create a String attribute to hold the first player name
        private String firstPlayerName;
        //Create a String attribute to hold the second player name
        private String secondPlayerName;
        //Create a String attribute to hold the map file name
        private String mapName;
        */
        public PlayerInfoForm()
        {
            InitializeComponent();
        }
        
        //Generate the click method for clearButton by clicking on it twice
        private void clearButton_Click(object sender, EventArgs e)
        {
            //Set all of the textboxes text to empty quotes 
            //in order to delete the old data
            firstPlayerNameTextBox.Text = "";
            secondPlayerNameTextBox.Text = "";
            nameOfMapFileTextBox.Text = "";
        }
        //Create a method that will send the data to the second form
        private void doneButton_Click(object sender, EventArgs e)
        {
            //If users fail to input data into the text field after pressing the clear button,
            //assign a default value for each of the name and the map file name
            
            //Assign a default value for player one name if user fails to input name
            //for player 1
            if (firstPlayerNameTextBox.Text == "")
            {

                firstPlayerNameTextBox.Text = "Roy";
            }
            //Assign a default value for player two name if user fails to input name
            //for player 2
            if (secondPlayerNameTextBox.Text == "")
            {
                secondPlayerNameTextBox.Text = "Marth";
            }
            //Assign a default map file name value if user fails to input a 
            //map file name
            if (nameOfMapFileTextBox.Text == "")
            {
                nameOfMapFileTextBox.Text = "simplemap.txt";
            }
            
            //Create an object of the second form, TankGame, with its parameterized constructor
            //Enter the text from the textboxes as the parameters for the parameterized constructor
            TankGameForm tankGame1 = new TankGameForm(firstPlayerNameTextBox.Text, secondPlayerNameTextBox.Text, nameOfMapFileTextBox.Text);
            //Call the ShowDialog method from TankGame object
            tankGame1.ShowDialog();
            //Call the Dispose to clean up when you are done with second form
            tankGame1.Dispose();
            //Call the Dispose method of the first form, Form1, 
            //to complete clean up when you are done with game
            Dispose();
        }
        
    }
}
