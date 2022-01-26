using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SBS_CSharpTask.Model.ExternalFile
{
    public class FileItemImpl : FileStrategy
    {

        private static readonly string ITEM_FILE = "Item.txt";    
        private List<string> list = new List<string>();

        public bool createFile()
        {
            try
            {
                if (!File.Exists(ITEM_FILE))
                {
                    string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + ITEM_FILE;
                    File.Create(filePath).Dispose();
                }               
                return true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public List<string> fileReader()
        {
            if (createFile())
            {
                StreamReader reader = new StreamReader(ITEM_FILE);
                String line;
                list.Clear();
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        list.Add(line);
                    }
                }
                reader.Close();                
                return list;
            } 
            else
            {
                return null;
            }     
        }

        public bool deleteLine(string target)
        {
            try
            {
                var tempFile = Path.GetTempFileName();
                var linesToKeep = File.ReadAllLines(ITEM_FILE).Where(l => !l.Contains(target.ToLower()));

                File.WriteAllLines(tempFile, linesToKeep);

                File.Delete(ITEM_FILE);
                File.Move(tempFile, ITEM_FILE);
                return true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool emptyFile()
        {
            createFile();
            try {
                StreamWriter writer = new StreamWriter(ITEM_FILE);
                writer.WriteLine();
                writer.Close();
                return true;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public List<string> getAllId()
        {
            List<string> ides = new List<string>();
            List<string> lines = fileReader();
            string id;

            foreach (string line in lines)
            {
                string[] data = line.Split(";");
                id = data[0];
                ides.Add(id);
            }
            return ides;
        }

        public string searchInFile(string target)
        {
            try
            {
                createFile();
                List<string> lines = fileReader();
                foreach (string line in lines)
                {
                    string[] data = line.Split(";");
                    string barcode = data[0];
                    if (barcode.Contains(target.ToLower()))
                    {
                        return line;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        
        public bool writeInFile(string objectToString)
        {
            try
            {
                createFile();
                StreamWriter writer = new StreamWriter(ITEM_FILE, true);
                writer.WriteLine(objectToString);
                //writer.Write(objectToString);
                writer.Flush();
                writer.Close();
                return true;
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }                       
        }
    }
}
