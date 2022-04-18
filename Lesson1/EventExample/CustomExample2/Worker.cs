using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventExample.CustomExample2
{
    public class Worker
    {
        public string Name { get; }
        public Worker(string name)
        {
            Name = name;
        }

        public Action<Worker, GoVacationParams> GoVacationDelegate;
        
        public void InitVacation(DateTime from, DateTime to, bool isAdm)
        {
            var param = new GoVacationParams(from, to, isAdm);
            if (GoVacationDelegate != null)
                GoVacationDelegate(this, param);
        }
    }
}
