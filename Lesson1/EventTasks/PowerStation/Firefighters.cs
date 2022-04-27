using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventTasks.PowerStation
{
    public class Firefighters
    {
        /// <summary>
        /// Название отделения
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Кол-во людей в отделении
        /// </summary>
        public int Amount { get; }
        public Firefighters (string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        protected void Work(object o, EventArgs args)
        {
            if (o is PowerStation)
            {
                var powerStation = (PowerStation)o;
                Console.WriteLine();
                Console.WriteLine($"Пожарное депо \"{Name}\" в количестве {Amount} человек \n" +
                    $"тушит станцию \"{powerStation.Name}\" с температурой {powerStation.Temperature} ");
                powerStation.Temperature = 100;
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
