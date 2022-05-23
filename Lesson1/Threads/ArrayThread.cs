using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lesson1.Threads
{
    public class ArrayThread
    {
        static readonly object _lock = new object();

        public int[] result = new int[10];

        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public int i = 0;
        public void Run()
        {
            while (i < arr.Length)
            {
                Thread a = new Thread(Task2);
                a.Name = "1";
                a.Start();
                Thread b = new Thread(Task2);
                b.Name = "2";
                b.Start();
                Thread c = new Thread(Task2);
                c.Name = "3";
                c.Start();
            }
        }
        public void Task2()
        {
            lock (_lock)
            {
                if (i < arr.Length)
                {
                    result[i] = arr[i] * arr[i];
                    i += 1;
                    Console.WriteLine($"Текущий поток {Thread.CurrentThread.Name} Выполняет операцию над переменной {arr[i - 1]}");
                }
            }

        }
    }
}
