using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lesson1.Threads
{
    public class FibonachiThread
    {
        public static void FibonachiPrint10()
        {
            int result = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(result);
                tmp = result;
                result = b;
                b += tmp;

            }

        }
        
        public static void Run()
        {
            Thread thread = new Thread(FibonachiPrint10);
            thread.IsBackground = true;
            thread.Start();
            thread.IsBackground = false;
            //thread.Abort();
        }

    }
    
}
