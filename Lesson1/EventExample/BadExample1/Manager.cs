using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventExample.BadExample1
{
    /// <summary>
    /// Руководитель
    /// </summary>
    public class Manager
    {
        public string Name;
        public Manager(string name)
        {
            Name = name;
        }
        public void SetReplace( Worker w, DateTime from, DateTime to)
        {
            Console.WriteLine($"Тут находим замену работнику {w.Name}");
        }
    }
}
