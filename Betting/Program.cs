//Developed By Keaton Dalquist to simulate and test the Martingale betting strategy
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Betting
{
    class Start
    {
        
        static void Main(string[] args)
        {
            //CONFIG
            int globalYears = 10;
            int globalDays = 250;
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
            ExcelSheet = ExcelWorkbook.Sheets[0];
            //Setup YEAR For Loop
            int years = globalYears;
            for(int index = 0;index<years;years++)
            {
                //Setup DAYS For Loop
                int days = globalDays;
                for (int counter = 0;counter<days;counter++)
                {

                }
            }
        }
    }
}
