using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RaceTrackSimulator
{
    class GreyHound
    {
        public int startingPosition; // Where my PictureBox starts      == dog no
        public int racetrackLength = 826; // How long the racetrack is        == myPictureBox.Length
        public PictureBox myPictureBox = null; // My PictureBox object  
        public int location = 0; // My Location on the racetrack
        public Random randomizer; // An instance of Random
        public bool run()
        {
            // Move forward either 1, 2, 3 or 4 spaces at random
            // Update the position of my PictureBox on the form
            int distance = 5;
            Point p = myPictureBox.Location;
            p.X += randomizer.Next(distance);
                myPictureBox.Location = p;
                location = p.X;
            if (location < racetrackLength)
                return false;
            else
                return true;
            // Return true if I won the race
        }
        public void takeStartingPosition(int p1)
        {
            Point p = myPictureBox.Location;
            p.X = p1;
            myPictureBox.Location = p; // Reset my location to the start line
        }
    }
}
