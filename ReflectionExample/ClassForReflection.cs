using System;
using System.Reflection;

namespace ReflectionExample
{
    public class ClassForReflection
    {
        public ClassForReflection()
        {
            Console.WriteLine("Вызвался конструктор без параметров");
        }

        public ClassForReflection(int prm)
        {
            Console.WriteLine($"Вызвался конструктор с числовым параметром {prm}");
        }

        internal ClassForReflection(string prm)
        {
            Console.WriteLine($"Вызвался непубличный конструктор со строковым параметром {prm}");
        }

        public void DoSmth()
        {
            Console.WriteLine("Вызвался метод без параметров и без возвращаемого значения");
        }

        public void DoSmthWithPrm(string prm)
        {
            Console.WriteLine($"Вызвался метод со строковым параметром {prm}" +
                $" и без возвращаемого значения");
        }

        public int DoSmthWithPrmAndResult(string prm)
        {
            var result = (int)(DateTime.Now.Ticks % 1000);
            Console.WriteLine($"Вызвался метод со строковым параметром {prm}" +
                $" и c возвращаемым значением {result}");
            return result;
        }

        protected int DoSmthWithPrmAndResultProtected(int prm)
        {
            var result = (int)(DateTime.Now.Ticks % 1000);
            Console.WriteLine($"Вызвался метод с целочисленным параметром {prm}" +
                $" и c возвращаемым значением {result}");
            return result;
        }

        protected static void DoStaticMethod()
        {
            Console.WriteLine($"Вызвался непубличный статичный метод ");
        }

        public string PublicField = "Public Field";

        private string privateField = "Private Field";

        protected static int staticField = 5;

        public int PublicProperty { get; set; } = 4;
        private int privateProperty { get; set; } = 13;
        public static int staticProperty { get; set; } = 44;

        public event EventHandler<EventArgs> TestEvent;

        public int[] IntArray = new int[] { 1, 2, 4 };
    }
}
