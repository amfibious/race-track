using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceTrackSimulator
{
    public partial class Form1 : Form
    {
        Player[] players = new Player[3];
        GreyHound[] dogs = new GreyHound[4];
        public Form1()
        {
            InitializeComponent();
            players[0] = new Player() { name = "Dayo", cash = 50, myLabel = label2, myRadioButton = radioButton1 };
            players[1] = new Player() { name = "Chidi", cash = 50, myLabel = label3, myRadioButton = radioButton2 };
            players[2] = new Player() { name = "Sammy", cash = 50, myLabel = label4, myRadioButton = radioButton3 };
            dogs[0] = new GreyHound() { startingPosition = 1, myPictureBox = pictureBox2 };
            dogs[1] = new GreyHound() { startingPosition = 2, myPictureBox = pictureBox3 };
            dogs[2] = new GreyHound() { startingPosition = 3, myPictureBox = pictureBox4 };
            dogs[3] = new GreyHound() { startingPosition = 4, myPictureBox = pictureBox5 };
            Random Randomizer = new Random();
            dogs[0].randomizer = Randomizer;
            dogs[1].randomizer = Randomizer;
            dogs[2].randomizer = Randomizer;
            dogs[3].randomizer = Randomizer;
            radioButton1.Text = players[0].name;
            radioButton2.Text = players[1].name;
            radioButton3.Text = players[2].name;
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                players[0].placeBet((int)numericUpDown2.Value, (int)numericUpDown1.Value);
                label7.Text = players[0].name;
                players[0].updateLabels();
            }
            else if (radioButton2.Checked)
            {
                players[1].placeBet((int)numericUpDown2.Value, (int)numericUpDown1.Value);
                players[1].updateLabels();
            }
            else if (radioButton3.Checked)
            {
                players[2].placeBet((int)numericUpDown2.Value, (int)numericUpDown1.Value);
                players[2].updateLabels();
            }
       
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            Bet myBet = new Bet();
            // if (!dogs[0].run() || !dogs[1].run() || !dogs[2].run() || !dogs[3].run()) return;
            // else
            // {

            dogs[0].takeStartingPosition(27);
            dogs[1].takeStartingPosition(27);
            dogs[2].takeStartingPosition(27);
            dogs[3].takeStartingPosition(27);
            label9.Text = "All bets: double-or-nothing";

            //change the picture boxes to animated gif images

            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            this.pictureBox2.Image = global::RaceTrackSimulator.Properties.Resources.ezgif_com_rotate;
            this.pictureBox3.Image = global::RaceTrackSimulator.Properties.Resources.ezgif_com_rotate_1;
            this.pictureBox4.Image = global::RaceTrackSimulator.Properties.Resources.ezgif_com_rotate_2;
            this.pictureBox5.Image = global::RaceTrackSimulator.Properties.Resources.ezgif_com_crop3;


            while (!dogs[0].run() && !dogs[1].run() && !dogs[2].run() && !dogs[3].run())
                {
                // for (int c = 0; c <= dogs[0].racetrackLength; c++)
                // {
                Application.DoEvents();
                        System.Threading.Thread.Sleep(1);
                        // if (dogs[0].location < dogs[0].racetrackLength) 
                        dogs[0].run();
                        // if (dogs[1].location < dogs[1].racetrackLength) 
                        dogs[1].run();
                        // if (dogs[2].location < dogs[2].racetrackLength) 
                        dogs[2].run();
                        // if (dogs[3].location < dogs[3].racetrackLength) 
                        dogs[3].run();
                   // }
                }

            /* change the images on the picture boxes to a static one as a dog wins*/
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            pictureBox5.Enabled = false;

            int winner = 0;
                if (dogs[0].run()) winner = 1;
                if (dogs[1].run()) winner = 2;
                if (dogs[2].run()) winner = 3;
                if (dogs[3].run()) winner = 4;

                label9.Text = "We have a Winner!!! \n Dog #" + winner + " Wins! ";
            if (players[0].myBet != null)
            {
                players[0].collect(winner);
                players[0].updateLabels();
            }
            if (players[1].myBet != null)
            {
                players[1].collect(winner);
                players[1].updateLabels();
            }
            if (players[2].myBet != null)
            {
                players[2].collect(winner);
                players[2].updateLabels();
            }
            button1.Enabled = true;
            button2.Enabled = true;
           // }   
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                label7.Text = players[0].name;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
                label7.Text = players[1].name;
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        { 
                label7.Text = players[2].name;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            players[0].myLabel.Text = "Bet cleared!";
            players[0].clearBet();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            players[1].myLabel.Text = "Bet cleared!";
            players[1].clearBet();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            players[2].myLabel.Text = "Bet cleared!";
            players[2].clearBet();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* make the picture boxes static as the form loads*/
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            pictureBox5.Enabled = false;
        }
    }
}
