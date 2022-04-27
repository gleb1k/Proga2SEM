using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventTasks.Mail
{
    internal sealed class Fax
    {
        public void Subscribe(MailManager mm)
        {
            mm.NewMail += PrintMail;
        }
        public void UnSubscribe(MailManager mm)
        {
            mm.NewMail -= PrintMail;
        }
        private void PrintMail(object sender, NewMailEventArgs e)
        {
            Console.WriteLine($"Cообщение от {e.MailFrom}, для {e.MailTo}, c темой {e.Subject}");
        }
    }
}
