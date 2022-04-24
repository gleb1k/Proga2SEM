using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventTasks.PowerStation
{
    public class PowerStationRunner
    {
        public static void Run()
        {
            PowerStation pw = new PowerStation("Чернобыльская АЭС", 100);
            var ff = new Firefighters("Казанское депо", 20);
            var moes = new MoES("Служба спасения #1", 30);

            moes.Subscribe(pw);

            ff.Subscribe(pw);

            pw.CheckTemperature();

            
        }
    }
}
