using System;
using Lesson1.CustomList;
using Lesson1.LinQ;
using Lesson1.Trees;
using Lesson1.DelegateEvent;
using Lesson1.EventExample;
using Lesson1.EventExample.CustomExample2;
using Lesson1.EventExample.GoodExample;
using Lesson1.EventTasks.PowerStation;
using Lesson1.EventTasks.Mail;
using Lesson1.Reflection;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            ////CustomListRunner.Run();

            //Console.WriteLine("-----------------------------------------------");

            //CustomLinkedListRunner.Run();

            ////var cList = new CustomCountList<double>();
            ////cList.Add(1);
            ////cList.Add(2);
            ////Console.WriteLine(cList.SummaOfAllElements());

            //CustomArrayListRunner.Run();

            //LinqRunner.Run();
            //LinkTaskRunner.Run();

            //TreeRunner.Run();

            //DelegateRunner dr = new DelegateRunner();
            //dr.Run();

            //var ceRun = new CERunner();
            //ceRun.Run();

            //var geRun = new GoodExampleRunner();
            //geRun.Run();

            //PowerStationRunner.Run();

            ReflectionRunner.Run();
        }
    }
}

