using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventTasks.PowerStation
{
    /// <summary>
    /// МЧС. Ministry of Emergency Situations
    /// </summary>
    public class MoES
    {
        /// <summary>
        /// Название отделения
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Кол-во людей в отделении
        /// </summary>
        public int Amount { get;}
        public MoES(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
        protected void Work(object o,EventArgs args)
        {
            if (o is PowerStation)
            {
                var powerStation = (PowerStation)o;
                Console.WriteLine();
                Console.WriteLine($"Отделение спасательной службы \"{Name}\" в количестве {Amount} человек \n" +
                    $"спасает людей на станции \"{powerStation.Name}\" с температурой {powerStation.Temperature} ");
                Console.WriteLine("Все люди были спасены");
            }
        }
        public void Subscribe(PowerStation pw)
        {
            pw.FireEvent += Work;   
        }
        public void UnSubscribe(PowerStation pw)
        {
            pw.FireEvent -= Work;
        }
    }
}
