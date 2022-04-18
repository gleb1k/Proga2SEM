using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventExample.CustomExample2
{
    public class Manager
    {
        public string Name { get;  }

        public Manager(string name)
        {
            Name = name;

        }
        protected void FindReplacement (Worker w, GoVacationParams param)
        {
            //происходит поиск замены\
            Console.WriteLine($"Происхоидит поиск замены менеджером {Name} для сотруднкиа {w.Name} уходящего в {param.IsAdmin} отпуск" +
                $"в период с {param.From.ToShortDateString()} по {param.To.ToShortDateString()}");
        }
        /// <summary>
        /// Подписаться
        /// </summary>
        /// <param name="w"></param>
        public void Subscribe (Worker w)
        {
            w.GoVacationDelegate += FindReplacement;
        }
        /// <summary>
        /// атписаться
        /// </summary>
        /// <param name="w"></param>
        public void UnSubscribe(Worker w)
        {
            w.GoVacationDelegate -= FindReplacement;
        }
    }
}
