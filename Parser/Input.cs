using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2.Parser
{
    public class Input 
    {
        public string InputData;

        public void FileRead()
        {
            try
            {
                using (StreamReader reader = new StreamReader("test.txt"))
                {
                    InputData = reader.ReadToEnd();
                }
            }
            catch(FileNotFoundException e)
            {
                InputData = "File not found";
              
            }
            catch(Exception e)
            {
                InputData = e.Message;
             
            }
        }

    


    }
}
