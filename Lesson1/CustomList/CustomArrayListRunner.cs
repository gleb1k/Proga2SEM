using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.CustomList
{
    class CustomArrayListRunner
    {
        public static void Run()
        {
            CustomArrayList<int> arrayList = new CustomArrayList<int>(new int[] { 5, 7, 7, 7, 8, 8, 8 });
            arrayList.WriteToConsole();
            arrayList.RemoveAll(7);
            arrayList.WriteToConsole();
            arrayList.RemoveAll(8);
            arrayList.WriteToConsole();
            //arrayList.Reverse();
            //arrayList.WriteToConsole();
        }

    }
}
