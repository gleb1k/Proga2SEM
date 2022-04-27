using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventTasks.Mail
{
    /// <summary>
    /// параметры сообщения
    /// </summary>
    internal class NewMailEventArgs :EventArgs
    {
        private readonly string mFrom, mTo, subject;

        public NewMailEventArgs(string mFrom, string mTo, string subject)
        {
            this.mFrom = mFrom;
            this.mTo = mTo;
            this.subject = subject;
        }
        /// <summary>
        /// От кого сообщение
        /// </summary>
        public string MailFrom { get { return mFrom; } }
        /// <summary>
        /// Кому сообщение
        /// </summary>
        public string MailTo { get { return mTo; } }
        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get { return subject; } }
    }
}
