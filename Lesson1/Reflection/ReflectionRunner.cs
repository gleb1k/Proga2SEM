using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Lesson1.Reflection
{
    public class ReflectionRunner
    {
        public static void Run()
        {
            //Поработаем с типом Type
            var t1 = typeof(Int32);
            Type t2 = 5.GetType();
            var i = 5;
            Type t3 = i.GetType();

            //Assembly assembly = Assembly.LoadFrom(@"C:\Users\Gleb\Desktop\Прога\glebik107-dz-5241bca481ef\2SEM\Proga2SEM\Lesson1\obj\Debug\net5.0\Lesson1.dll");
            
        }
    }
}
