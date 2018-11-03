using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceHashBot
{
    static class DesyncController
    {
        private const string FileName = "DesyncData.txt";

        private static string GetAppPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        private static string GetFilePath()
        {
            return Path.Combine(GetAppPath(), FileName);
        }


        public static List<string> GetAll()
        {
            List<string> result = new List<string>();
            String readString = "";

            if (File.Exists(GetFilePath()))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(GetFilePath()))
                    {
                        readString = sr.ReadToEnd();
                        Console.WriteLine(readString);
                    }
                }
                catch (Exception e)
                {
                    /*Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);*/
                    return result;
                }
            }
                
            while (readString.Length > 0)
            {
                int space = readString.IndexOf(" ");
                string line = readString.Substring(0, space);
                result.Add(line);
                readString = readString.Remove(0, space + 1);
            }            
            return result;
        }

        public static void Add(string input1, string input2)
        {
            if (!File.Exists(GetFilePath()))
                File.Create(GetFilePath()).Close();            

            try
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(GetFilePath(), true))
                {
                    file.Write(input1 + ":" + input2 + " ");
                }
            }
            catch(Exception Ex)
            {
                /*Console.WriteLine(Ex);*/
            }
            CleanUp();
        }

        public static void CleanUp()
        {
            List<string> Desyncs = GetAll();
        }

        public static void Delete()
        {
            if (File.Exists(GetFilePath()))
                File.Delete(GetFilePath());
        }
    }
}
