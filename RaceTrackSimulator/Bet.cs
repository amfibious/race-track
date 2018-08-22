using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RaceTrackSimulator
{
    class Bet           //This is the object that the player uses to represent bets in the application
    {
        public int amount; // The amount of cash that was bet
        public int dog; // The number of the dog the bet is on
        public Player bettor; // The guy who placed the bet

        public string getDescription()
        {
            string description;
            if (bettor.cash >= amount)
                {
                    description = bettor.name + " bets $" + amount + " on dog #" + dog;    // Return a string that says who placed the bet, how much
                    bettor.myLabel.BackColor = Color.GreenYellow;                                    // cash was bet, and which dog was bet on
                    return description;                                                     // ("Joe bets 8 on dog #4"). If the amount is zero, no bet
                }
                else                                                                             // was placed. ("Joe hasn't placed a bet").
                {                                                                    
                    description = "Not enough cash to place $" + amount;
                    bettor.myLabel.BackColor = Color.Transparent;
                    return description;        
                }
                                                                                
                      
        }
        public int payOut(int winner)
        {
            if (bettor.cash >= amount)
            {
                if (dog == winner) // The parameter is the winner of the race. if the dog won,
                {                   // return the amount bet. Otherwise, return the negative of the amount bet.
                    return amount;
                }
                else
                {
                    return -amount;
                }
            }
            else return 0;

        }
    }
}
