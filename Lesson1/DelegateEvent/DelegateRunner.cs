using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.DelegateEvent
{
    public class DelegateRunner
    {

        //создаём тип делегата, который не принимает входящих параметров и не возвращает результат 
        public delegate void Message();

        public delegate int SingleCalc(int x);

        public int PlusOne(int y)
        {
            return y + 1;
        }

        public int ModFive(int z)
        {
            return z % 5;
        }

        public delegate void GetOp(char op);
        public void Run()
        {
            //экземпляр делегата 
            Message msgHello = WriteHello;
            //написать имя делегата и круглые скобки
            msgHello();
            // через Invoke
            msgHello.Invoke();

            //--------------------

            //способ создания 1
            SingleCalc d1; //null
            d1 = PlusOne;

            //способ создания 2
            var d11 = new SingleCalc(PlusOne);

            //вызов способ 1
            int a = 5;
            a = d1(a); //a = d1(5) => a = PlusOne(5);

            //вызов способ 2
            a = d1.Invoke(a);

            //меняем значение
            d1 = ModFive;
            a = d1(a);

            //Создание цепочки делегатов 
            //(1 переменная смотрит на несколько функций)
            d1 += PlusOne;
            d1 += ModFive ;
            d1 += PlusOne;
            a = d1(a);

            //удаление из цепочки делегатов
            d1 -= PlusOne;
            a = d1(a);

            //еще один способ создание цепочки
            SingleCalc d2 = PlusOne;
            SingleCalc d22 = ModFive;
            SingleCalc d222 = d2 + d22;
            a = d222(a);

            //1)анонимный метод 
            SingleCalc d3 = delegate (int x)
            {
                return x + 2;
            };
            a = d3(a);
            //аналог ModFive
            SingleCalc d33 = delegate (int x) { return x % 5; };
            a = d33(a);
            d33 = delegate (int x) { return x % 6; };
            a = d33(a);

            //лямбда выражения
            SingleCalc lamPlusOne = (int x) => { return x + 1; };
            Message lamHello = () => { Console.WriteLine("Hello!!!"); };

            //Встроенные делегаты Function
            var d5 = new Func<int, int>(PlusOne);
            var d55 = new Func<int, string, string>(
                (int x, string s) =>
                {
                    x = x + 3;
                    s = s + x.ToString();
                    return s;
                });
            var d555 = new Func<string>(() => DateTime.Now.ToShortDateString());

            //встроенный делегат Action
            var d6 = new Action(()
                => Console.WriteLine(DateTime.Now.ToShortDateString()));
            var d66 = new Action<int, int, string>(
                (int x, int y, string s) =>
                {
                    x += y;
                    Console.WriteLine(x + s);
                });



        }
        //функция, которая по входящему параметру и возвращаемому значению соответствует типу делегата message
        public void WriteHello()
        {
            Console.WriteLine("Hello");
        }

        public void GettingOp(char op)
        {

        }

    }
}
