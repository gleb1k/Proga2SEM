using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson1.EventTasks.PowerStation
{
    public class PowerStation
    {
        public string Name { get;set; }
        public int Temperature { get; set; }
        public PowerStation(string name, int temp)
        {
            Name = name;
            Temperature = temp;
        }

        public event EventHandler FireEvent;
        public void Fire()
        {
            //int i = 0;
            while (true)
            {
                //Timer timer = new Timer(); как сделать таймер?
                Thread.Sleep(1000);
                Temperature = Temperature + 5;
                if (Temperature >= 120)
                    if (FireEvent != null)
                        FireEvent(this, EventArgs.Empty);
                //i++;
                
            }
            //Console.WriteLine("Cтанция нестабильна. Работа станции прекращается. :с");
        }
    }
}
