using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventTasks.Mail
{
    internal class MailRunner
    {
        public void Run()
        {
            var mm = new MailManager();
            mm.SimulateNewMail("Рената", "Абрамский", "Контрольная");
            
            var pager = new Pager();

            pager.Subscribe(mm);

            mm.SimulateNewMail("Рената","Тагир","Домашка");
            var fax = new Fax();
            fax.Subscribe(mm);
            pager.UnSubscribe(mm);
            mm.SimulateNewMail("Глеб","Тимур","мемас");
        }
    }
}
