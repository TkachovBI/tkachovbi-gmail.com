using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WPFFinalproject.Classes
{
    public  class Logging
    {
        public  void Error(string message)
        {
            if (!Directory.Exists("LogSys"))
            {
                Directory.CreateDirectory("LogSys");
                if (!File.Exists("LogSys/ErrorLogs.txt"))
                {
                    StreamWriter streamWriter = new StreamWriter("LogSys/ErrorLogs.txt");
                }

                File.WriteAllText("LogSys/ErrorLogs.txt", $"{DateTime.Now}" + "\t" + message);
            }
            else
            {
                if (!File.Exists("LogSys/ErrorLogs.txt"))
                {
                    StreamWriter streamWriter = new StreamWriter("LogSys/ErrorLogs.txt");
                }

                File.WriteAllText("LogSys/ErrorLogs.txt", $"{DateTime.Now}" + "\t" + message);
            }
            
        }

        public  void Fatal(string massege)
        {
            if (!Directory.Exists("LogSys"))
            {
                Directory.CreateDirectory("LogSys");
                if (!File.Exists("LogSys/FatalLogs.txt"))
                {
                    StreamWriter streamWriter = new StreamWriter("LogSys/FatalLogs.txt");
                }

                File.WriteAllText("LogSys/FatalLogs.txt", $"{DateTime.Now}" + "\t" + massege);
            }
            else
            {
                if (!File.Exists("LogSys/FatalLogs.txt"))
                {
                    StreamWriter streamWriter = new StreamWriter("LogSys/FatalLogs.txt");
                }

                File.WriteAllText("LogSys/FatalLogs.txt", $"{DateTime.Now}" + "\t" + massege);
            }
            
        }

        public void Debug(string massege)
        {

            if (!Directory.Exists("LogSys"))
            {
                Directory.CreateDirectory("LogSys");
                if (!File.Exists("LogSys/DebugLogs.txt"))
                {
                    StreamWriter streamWriter = new StreamWriter("LogSys/DebugLogs.txt");
                }

                File.WriteAllText("LogSys/DebugLogs.txt", $"{DateTime.Now}: " + massege);
            }
            else
            {
                if (!File.Exists("LogSys/DebugLogs.txt"))
                {
                    StreamWriter streamWriter = new StreamWriter("LogSys/DebugLogs.txt");
                }

                File.WriteAllText("LogSys/DebugLogs.txt", $"{DateTime.Now}" + "\t" + massege);
            }
           
        }
    }
}
