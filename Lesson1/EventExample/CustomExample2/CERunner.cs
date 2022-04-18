using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.EventExample.CustomExample2
{
    public class CERunner
    {
        public void Run()
        {
            //создадим менеджера 
            var m1 = new Manager("Первый манагер");
            //Созздаем фин отдел
            var fd = new FinDepartment();

            var worker1 = new Worker("Первый работник");

            //подписок нет. вызовем выход в отпуск у работника
            
            worker1.InitVacation(new DateTime(2022, 03, 1), new DateTime(2022, 03, 14), false);

            //подписываю менеджера на сотрудник
            //чтобы отслеживать выход в отпуск
            m1.Subscribe(worker1);

            //фин отдел подписывается на сотрудника 
            fd.Subscribe(worker1);
            worker1.InitVacation(new DateTime(2022, 04, 3), new DateTime(2022, 04, 17), false);
        }
    }
}
