 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson1.EventTasks.Mail
{
    internal  class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;
        /// <summary>
        /// Симуляция события
        /// </summary>
        public void SimulateNewMail(string from, string to, string sbj)
        {
            var args = new NewMailEventArgs(from, to, sbj);
            OnNewMail(args);
        }
        /// <summary>
        /// Обработка события
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnNewMail(NewMailEventArgs args)
        {
            //Это для потокобезопасности
            EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail);
            if (temp != null)
                temp(this, args);

        }
    }
}
