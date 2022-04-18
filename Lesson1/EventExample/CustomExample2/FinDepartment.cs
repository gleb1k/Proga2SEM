using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventExample.CustomExample2
{
    public class FinDepartment
    {
        protected void CalcSalary(Worker w, GoVacationParams param)
        {
            Console.WriteLine($"Происхоидит вычисление для сотруднкиа {w.Name} уходящего в {param.IsAdmin} отпуск" +
                $"в период с {param.From.ToShortDateString()} по {param.To.ToShortDateString()}");
        }
        public void Subscribe (Worker w)
        {
            w.GoVacationDelegate += CalcSalary;
        }
        public void UnSubscribe(Worker w)
        {
            w.GoVacationDelegate -= CalcSalary;
        }
    }
}
