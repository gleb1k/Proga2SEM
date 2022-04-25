using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventTasks.Mail
{
    internal class Pager
    {
        public void Subscribe(MailManager mm)
        {
            mm.NewMail += Show;
        }
        public void UnSubscribe(MailManager mm)
        {
            mm.NewMail -= Show;
        }
        private void Show(object sender, NewMailEventArgs e)
        {
            Console.WriteLine($"Вам пришло сообщение c темой {e.Subject}");
        }
    }
}
