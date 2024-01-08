uusing System;
using System.IO;
using System.Reflection.PortableExecutable;
class Program
{
    static void Main(string[] args)
    {
        string fileName = "Inventory.txt";
        string filePath = "C:\\repo\\vending-machine";
        string fileWhatever = Path.Combine(filePath, fileName);
        try
        {
            using (var sr = new StreamReader(fileWhatever))
            {
                string contents = sr.ReadToEnd();
                string[] items = contents.Split('|');
                foreach (string item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
    }
}



