using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventExample.CustomExample2
{
    /// <summary>
    /// Параметры отпуска
    /// </summary>
    public class GoVacationParams
    {
        private DateTime from;
        private DateTime to;
        //является ли отпуск неоплачиваемым
        private bool isAdmin;

        public DateTime From { get { return from; } }
        public DateTime To { get { return to; } }
        public string IsAdmin { get {
                return isAdmin ?
                  "Административный" : "Неоплачиваемый";
                } } 
        public GoVacationParams(DateTime from, DateTime to, bool isAdm = false)
        {
            this.from = from;
            this.to = to;
            isAdmin = isAdm;
        }
    }
}
