using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Threads
{
    public class ArraySumma
    {
        static void Run()
        {
            int[] array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Task<int> myTask = new Task<int>(() => ArraySum(array));
            myTask.Start();
            Console.WriteLine(myTask.Result);
        }
        static int ArraySum(int[] array)
        {
            int l = array.Length;
            int sum = 0;
            int count = 0;
            for (int i = 0; i < l; i = i + count)
            {
                sum += array[i];
                count += 1;
            }
            return sum;
        }
    }
}
