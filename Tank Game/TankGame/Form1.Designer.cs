namespace MileStone4
{
    partial class PlayerInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.player1Name = new System.Windows.Forms.Label();
            this.player2Name = new System.Windows.Forms.Label();
            this.mapFileName = new System.Windows.Forms.Label();
            this.firstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.secondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.nameOfMapFileTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // player1Name
            // 
            this.player1Name.AutoSize = true;
            this.player1Name.Location = new System.Drawing.Point(48, 13);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(82, 13);
            this.player1Name.TabIndex = 0;
            this.player1Name.Text = "Player 1 Name: ";
            // 
            // player2Name
            // 
            this.player2Name.AutoSize = true;
            this.player2Name.Location = new System.Drawing.Point(48, 43);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(79, 13);
            this.player2Name.TabIndex = 1;
            this.player2Name.Text = "Player 2 Name:";
            // 
            // mapFileName
            // 
            this.mapFileName.AutoSize = true;
            this.mapFileName.Location = new System.Drawing.Point(46, 73);
            this.mapFileName.Name = "mapFileName";
            this.mapFileName.Size = new System.Drawing.Size(96, 13);
            this.mapFileName.TabIndex = 2;
            this.mapFileName.Text = "Name of Map File: ";
            // 
            // firstPlayerNameTextBox
            // 
            this.firstPlayerNameTextBox.Location = new System.Drawing.Point(148, 11);
            this.firstPlayerNameTextBox.Name = "firstPlayerNameTextBox";
            this.firstPlayerNameTextBox.Size = new System.Drawing.Size(233, 20);
            this.firstPlayerNameTextBox.TabIndex = 3;
            // 
            // secondPlayerNameTextBox
            // 
            this.secondPlayerNameTextBox.Location = new System.Drawing.Point(148, 40);
            this.secondPlayerNameTextBox.Name = "secondPlayerNameTextBox";
            this.secondPlayerNameTextBox.Size = new System.Drawing.Size(233, 20);
            this.secondPlayerNameTextBox.TabIndex = 4;
            // 
            // nameOfMapFileTextBox
            // 
            this.nameOfMapFileTextBox.Location = new System.Drawing.Point(148, 66);
            this.nameOfMapFileTextBox.Name = "nameOfMapFileTextBox";
            this.nameOfMapFileTextBox.Size = new System.Drawing.Size(233, 20);
            this.nameOfMapFileTextBox.TabIndex = 5;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(422, 9);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(422, 66);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 8;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // PlayerInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 111);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.nameOfMapFileTextBox);
            this.Controls.Add(this.secondPlayerNameTextBox);
            this.Controls.Add(this.firstPlayerNameTextBox);
            this.Controls.Add(this.mapFileName);
            this.Controls.Add(this.player2Name);
            this.Controls.Add(this.player1Name);
            this.Name = "PlayerInfoForm";
            this.Text = "Player Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label player1Name;
        private System.Windows.Forms.Label player2Name;
        private System.Windows.Forms.Label mapFileName;
        private System.Windows.Forms.TextBox firstPlayerNameTextBox;
        private System.Windows.Forms.TextBox secondPlayerNameTextBox;
        private System.Windows.Forms.TextBox nameOfMapFileTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button doneButton;
    }
}

