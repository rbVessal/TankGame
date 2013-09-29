namespace MileStone4
{
    partial class Winner
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
            this.winnerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.playAgainButton = new System.Windows.Forms.Button();
            this.nopeButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // winnerTextBox
            // 
            this.winnerTextBox.Location = new System.Drawing.Point(108, 44);
            this.winnerTextBox.Name = "winnerTextBox";
            this.winnerTextBox.ReadOnly = true;
            this.winnerTextBox.Size = new System.Drawing.Size(135, 20);
            this.winnerTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "The winner is: ";
            // 
            // playAgainButton
            // 
            this.playAgainButton.Location = new System.Drawing.Point(29, 209);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(75, 28);
            this.playAgainButton.TabIndex = 2;
            this.playAgainButton.Text = "Yes";
            this.playAgainButton.UseVisualStyleBackColor = true;
            this.playAgainButton.Click += new System.EventHandler(this.playAgainButton_Click);
            // 
            // nopeButton
            // 
            this.nopeButton.Location = new System.Drawing.Point(168, 209);
            this.nopeButton.Name = "nopeButton";
            this.nopeButton.Size = new System.Drawing.Size(75, 28);
            this.nopeButton.TabIndex = 3;
            this.nopeButton.Text = "No";
            this.nopeButton.UseVisualStyleBackColor = true;
            this.nopeButton.Click += new System.EventHandler(this.nopeButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 183);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Play again?";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Winner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.nopeButton);
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.winnerTextBox);
            this.Name = "Winner";
            this.Text = "Winner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox winnerTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button playAgainButton;
        private System.Windows.Forms.Button nopeButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}