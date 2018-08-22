using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RaceTrackSimulator
{
    class Player
    {
        public string name;  // The player's name
        public int cash;    // How much cash  the player has
        public Bet myBet;   // An instance of Bet() that has the players bet
            // The last two fields are the player’s GUI controls on the form
        public RadioButton myRadioButton;   // My RadioButton
        public Label myLabel;               // My Label

        public bool placeBet(int amt, int dg)
        {
            // Place a new bet and store it in my bet field
            // Return true if the guy had enough money to bet
            myBet = new Bet() { amount = amt, dog = dg, bettor = this };
            if (cash >= amt)
            {
                return true;
                }
                else
            {
                return false;
                }
        }

        public void updateLabels()
        {
            if (myBet != null)
            {
                myLabel.Text = myBet.getDescription();
                myRadioButton.Text = name + " has $" + cash;
                // Set my label to my bet's description, and the label on my
                // radio button to show my cash ('Joe has 43 bucks')
            }
            else
            {
                myLabel.BackColor = Color.Transparent;
            }
        }

        public void clearBet()
        {
            // Reset my bet so it is zero
            myBet = null;
            updateLabels();
        }

        public void collect(int winner)
        { // Ask my bet to pay out
            cash += myBet.payOut(winner);
        }

        public int getCash()
        {
            return cash;
        }
        public void setCash(int money)
        {
            cash = money;
        }
    }
}
