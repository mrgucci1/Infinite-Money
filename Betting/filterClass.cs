
using System.Linq;
using System.Data;


namespace Betting
{
    class filterClass
    {
        public string[] filter(string[] files)
        {
            //counter for new filtered array
            int counter = 0;
            //new array to store all filtered filed
            string[] filteredFiles = new string[files.Length];
            //loop through all files, only keeping .csv files
            for(int i = 0;i < files.Length;i++)
            {
                if(files[i].Contains(".csv") || files[i].Contains(".xlsx"))
                {
                    filteredFiles[counter] = files[i];
                    counter++;
                }
            }
            //remove null or whitespace from array
            filteredFiles = filteredFiles.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            return filteredFiles;
        }
    }
}
