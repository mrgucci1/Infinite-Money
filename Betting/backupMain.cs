using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting
{
    class Program
    {

        static void Main(string[] args)
        {
            int globalbet = 5;
            int globalamountturns = 100;
            int gloablturns = 100;
            int failure = 0;
            int success = 0;
            int[] balancearray = new int[globalamountturns];
            int[] winsarray = new int[globalamountturns];
            int[] losesarray = new int[globalamountturns];
            int[] winflag = new int[globalamountturns];
            int[] endingBet = new int[globalamountturns];
            string[] time = new string[globalamountturns];
            Random rnd = new Random();
            for (int x = 0; x < globalamountturns; x++)
            {
                int bet = globalbet;
                int balance = 200;
                int wins = 0;
                int loses = 0;
                int lowestbalance = 100000;
                int highestbet = 100;
                int minutes = 0;
                int hours = 0;
                int days = 0;
                int years = 0;

                for (int i = 0; i < gloablturns; i++)
                {
                    if (balance < bet)
                    {

                        balancearray[x] = balance;
                        winsarray[x] = wins;
                        losesarray[x] = loses;
                        winflag[x] = 0;
                        endingBet[x] = bet;
                        failure++;
                        time[x] = $"Time passed: {years} years, {days} days, {hours} hours, {minutes} minutes";
                        Console.ResetColor();
                        break;
                    }
                    /*
                    if (balance < 0)
                    {
                        balancearray[x] = balance;
                        winsarray[x] = wins;
                        losesarray[x] = loses;
                        winflag[x] = 0;
                        failure++;
                        break;
                    }*/
                    if (i == (gloablturns - 1))
                    {
                        balancearray[x] = balance;
                        winsarray[x] = wins;
                        losesarray[x] = loses;
                        winflag[x] = 1;
                        endingBet[x] = bet;
                        time[x] = $"Time passed: {years} years, {days} days, {hours} hours, {minutes} minutes";
                        success++;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Current Balance: {balance}");
                    Console.WriteLine($"Current Bet: {bet}");
                    Console.WriteLine($"Wins: {wins}");
                    Console.WriteLine($"Loses: {loses}");
                    Console.WriteLine($"Highest Bet: {highestbet}");
                    Console.WriteLine($"Lowest Balance: {lowestbalance}");
                    Console.WriteLine($"Time passed: {years} years, {days} days, {hours} hours, {minutes} minutes");
                    Console.ResetColor();
                    int redblack = rnd.Next(0, 2);  // creates a number between 0 and 1, if 0 its red, if black i 
                    Console.WriteLine(redblack);
                    int green = rnd.Next(0, 15);
                    Console.WriteLine(green);
                    int betcolor = 3; //initial
                    int previous = 1;
                    //betcolor = 0; //always choose red
                    //betcolor = 1; //always choose black
                    betcolor = previous; //chose previous color
                                         //betcolor = rnd.Next(0, 2);   // creates a number between 0 and 1

                    betcolor = 0;
                    Console.WriteLine(betcolor);
                    string betstringcolor = "green";
                    string drawncolor = "green";
                    if (betcolor == 0)
                        betstringcolor = "Red";
                    else
                        betstringcolor = "Black";

                    if (green == 14)
                        drawncolor = "Green";
                    else if (redblack == 0)
                        drawncolor = "Red";
                    else
                        drawncolor = "Black";
                    bool win = false;
                    Console.WriteLine($"{bet} Placed on {betstringcolor}");
                    Console.WriteLine($"The color was {drawncolor}");
                    if (redblack == betcolor && green != 14)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You Win! Reseting bet");
                        balance = balance + bet;
                        bet = globalbet;
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
                    previous = redblack;
                    if (bet >= highestbet)
                        highestbet = bet;
                    if (balance <= lowestbalance)
                        lowestbalance = balance;

                    //handle time
                    minutes = minutes + 2;
                    if (minutes == 60)
                    {
                        minutes = 0;
                        hours++;
                    }
                    if (hours == 24)
                    {
                        hours = 0;
                        days++;
                    }
                    if (days == 365)
                    {
                        days = 0;
                        years++;
                    }
                }

            }
            for (int i = 0; i < globalamountturns; i++)
            {
                string win = "initial";
                if (winflag[i] == 1)
                    win = "Win";
                else
                    win = "Lose";
                if (win == "Lose")
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("====================================");
                Console.WriteLine($"Turn Number: {i}");
                Console.WriteLine($"Win or Lose? {win}");
                Console.WriteLine($"Ending Balance: {balancearray[i]}");
                Console.WriteLine($"Ending Wins: {winsarray[i]}");
                Console.WriteLine($"Ending Loses: {losesarray[i]}");
                Console.WriteLine($"Ending Loses: {endingBet[i]}");
                Console.WriteLine($"Time passed: {time[i]}");
                Console.WriteLine("====================================");
                Console.ResetColor();
            }
            Console.WriteLine($"AVG Ending Balance: {balancearray.Average()}");
            Console.WriteLine($"Ending Wins: {winsarray.Average()}");
            Console.WriteLine($"Ending Loses: {losesarray.Average()}");
            Console.WriteLine("====================================");
            Console.WriteLine($"Total Success: {success}");
            Console.WriteLine($"Total Failure: {failure}");
            Console.ReadLine();
        }
    }
}
