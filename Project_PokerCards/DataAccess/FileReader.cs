using System;
using System.IO;

namespace Project_PokerCards.DataAccess
{
    public class FileReader
    {
        public string FilePath { get; set; }
        public FileReader()
        {
            //string fileDic = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "");
            FilePath = "C:\\TestData\\poker-hands.txt";
            // fileDic + "Data\\poker-hands.txt";
            Console.WriteLine("Input File path: "+FilePath);
        }

        /// <summary>
        /// Reads Input from the file using the file path given in arguments
        /// </summary>
        /// <returns>bool value</returns>
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
            catch (FormatException e)
            {
                Console.WriteLine("File could not open with this format." + e.Message);
                return false;
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("File could not be found on the specified path."+ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured in reading data from the file. Please ensure the format is correct and as expected."+ex.Message);
                return false;
            }
            return true;
        }
    }
}
