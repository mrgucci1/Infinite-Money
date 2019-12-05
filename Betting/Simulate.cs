using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting
{
    class Simulate
    {
        //RETURNS SUCCESS IF YOU MAKE IT THROUGH ALL TURNS FOR THE DAY (250)
        //RETURNS FAIL IF YOUR BET EXCEEDS YOUR BALANCE
        public bool dailyBet(int bet,ref int balance, ref int wins, ref int loses, ref int highestbet, int betTurns)
        {
            Random rnd = new Random();
            int beginBet = bet;
                for (int i = 0; i < betTurns; i++)
                {
                    if (balance < bet)
                    {
                        return false;
                    }
                    // creates a number between 0 and 1, if 0 its red, if 1 its black
                    int drawColor = rnd.Next(0, 2);
                    //creates random number between 0-14, if it strikes 14, then the color this turn is green
                    int green = rnd.Next(0, 15);
                    //check if win, win only if placed bet equals draw bet, AUTO LOSE ON GREEN
                    if (drawColor == bet && green != 14)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You Win! Reseting bet");
                        //add winnings to balance
                        balance = balance + bet;
                        //reset to betting start
                        bet = beginBet;
                        wins++;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You Lost, Doubling Bet");
                        balance = balance - bet;
                        bet = bet * 2;
                        loses++;
                        Console.ResetColor();
                    }
                    if (bet >= highestbet)
                        highestbet = bet;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Turn: {i} Done");
                Console.ResetColor();
            }
            return true;
        }
    }
}
