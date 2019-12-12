//Developed By Keaton Dalquist to simulate and test the Martingale betting strategy
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Betting
{
    class Start
    {
        
        static void Main(string[] args)
        {
            //CONFIG
            int globalYears = 10;
            int globalDays = 250;
            int globalBalance = 100000;
            int globalBet = 100;
            int globalTurnsPerDay = 240;
            //How to bet?
            //Bet Only on Red
            bool onlyRed = true;
            //Bet Only on Black
            bool onlyBlac = false;
            //Bet on the previous Winner
            bool betprev = false;
            //Bet randomly
            bool random = false;
            //Bet switching between red and black
            bool betSwitch = false;
            //Reference Classes
            //Class that does daily betting
            Simulate sim = new Simulate();
            //Class that reads files in current directory
            readFiles rf = new readFiles();
            //Class that filters files in current directory for files ending in .xlsx or .csv
            filterClass fil = new filterClass();
            //Find first excel object in files array
            string[] files = rf.Main();
            //Filter file list to only contain .xlsx/.csv files
            files = fil.filter(files);
            //Setup Excel Objects
            Excel.Application ExcelApp;
            Excel._Workbook ExcelWorkbook;
            Excel._Worksheet ExcelSheet;
            //Initilize ExcelApp
            ExcelApp = new Excel.Application();
            //Open First Excel file
            ExcelWorkbook = ExcelApp.Workbooks.Open(files[0]);
            //Set Active Sheet
            ExcelSheet = ExcelWorkbook.Sheets[1];
            ExcelApp.Visible = true;
            //Setup YEAR For Loop
            int years = globalYears;
            int yearsRows = 2;
            for(int index = 0;index<years; years++)
            {
                //Setup DAYS For Loop
                int days = globalDays;
                int daysRows = 2;
                int bet = globalBet;
                int balance = globalBalance;
                int wins=0, loses=0, highestbet=0;
                int betTurns = globalTurnsPerDay;
                int betColor = 0;
                Random rnd = new Random();
                for (int counter = 0;counter<days; counter++)
                {   
					int daysCols = 2;
					//Determine bet
                    if (random)
                        betColor = rnd.Next(0, 2);
                    else if (onlyRed)
                        betColor = 0;
                    else if (onlyBlac)
                        betColor = 1;
                    //Run simulation for day
                    bool success = sim.dailyBet(betColor, bet, ref balance, ref wins, ref loses, ref highestbet, betTurns);
                    //Set active sheet to current year
                    ExcelSheet = ExcelWorkbook.Sheets[counter + 2];
                    //populate the days stats
					if(success) {
						ExcelSheet.Cells[daysRows, daysCols] = "Success";
					    ExcelSheet.get_Range(ExcelSheet.Cells[daysRows, daysCols], ExcelSheet.Cells[daysRows, daysCols]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
					}
					else {
						ExcelSheet.Cells[daysRows, daysCols] = "Fail";
						ExcelSheet.get_Range(ExcelSheet.Cells[daysRows, daysCols], ExcelSheet.Cells[daysRows, daysCols]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
					}
					daysCols++;
					ExcelSheet.Cells[daysRows, daysCols] = balance;
					daysCols++;
					ExcelSheet.Cells[daysRows, daysCols] = wins;
					daysCols++;
					ExcelSheet.Cells[daysRows, daysCols] = loses;
					daysRows++;
                }
                //Set active sheet to year panel
                ExcelSheet = ExcelWorkbook.Sheets[1];
                int yearsCols = 2;
                if (balance > globalBalance)
                {
                    ExcelSheet.Cells[yearsRows, yearsCols] = "Success";
                    ExcelSheet.get_Range(ExcelSheet.Cells[yearsRows, yearsCols], ExcelSheet.Cells[yearsRows, yearsCols]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                }
                else
                {
                    ExcelSheet.Cells[yearsRows, yearsCols] = "Fail";
                    ExcelSheet.get_Range(ExcelSheet.Cells[yearsRows, yearsCols], ExcelSheet.Cells[yearsRows, yearsCols]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                }
                yearsCols++;
                ExcelSheet.Cells[yearsRows, yearsCols] = balance;
                yearsCols++;
                ExcelSheet.Cells[yearsRows, yearsCols] = wins;
                yearsCols++;
                ExcelSheet.Cells[yearsRows, yearsCols] = loses;
                yearsRows++;

            }
        }
    }
}
