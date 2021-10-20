using System;
using System.IO;

namespace Project_PokerCards.Data
{
   public class FileReader
    {
        public string FilePath { get; set; }
        public FileReader()
        {
            //string fileDic = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "");
           

            
            FilePath = "C:\\TestData\\poker-hands.txt";
                // fileDic + "Data\\poker-hands.txt";
            Console.WriteLine(FilePath);
        }

        /// <summary>
        /// Reads Input from the file using the file path given in arguments
        /// </summary>
        /// <returns></returns>
        public bool IfExists()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    Console.WriteLine("File exists...");
                }
                else
                {
                    Console.WriteLine("File does not exist in the current directory!");
                }
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                {
                    throw new Exception("File could not be found on the specified path.");
                }
                else
                {
                    throw new Exception("Error occured in reading data from the file. Please ensure the format is correct and as expected.");
                }

            }
            return true;
            
        }
    }
}
