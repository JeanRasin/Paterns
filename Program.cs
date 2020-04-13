using Patterns.BehavioralPatterns.TemplateMethod;
using Patterns.CreationalPatterns.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // ------------------- Develop 
            Console.WriteLine("------------------- Develop");

            Developer dev1 = new DeveloperPanel("ООО ПанельСтрой");
            House house1 = dev1.Create();

            Developer dev2 = new DeveloperWood("ООО Опушка");
            House house2 = dev2.Create();

            Developer dev3 = new DeveloperBrick("ООО КирпичСтрой");
            House house3 = dev3.Create();

            // List

            var developArray = new List<Developer>
            {
                new DeveloperPanel("ООО ПанельСтрой"),
                new DeveloperWood("ООО Опушка"),
                new DeveloperBrick("ООО КирпичСтрой")
            };

            foreach (var dev in developArray)
            {
                dev.Create();
            }


            // ------------------- Money
            Console.WriteLine("------------------- Money");

            // Устанавливаем кодировку чтобы корректно отобразился символ рубля.
            Console.OutputEncoding = Encoding.Unicode;

            // Создаем коллекцию устройств для печати денег.
            // Обратите внимание, что мы можем хранить их все в одной коллекции.
            var machines = new List<CashMachineBase>
            {
                new RubleCashMachine(),
                new DollarCashMachine(),
                new EuroCashMachine()
            };

            // Создаем коллекцию для хранения денег.
            // Опять таки здесь могут храниться любые классы, унаследованные от MoneyBase.
            var money = new List<MoneyBase>();

            // Генератор случайных числе.
            var rnd = new Random();

            // По очереди запускаем устройства для печати денег.
            foreach (var machine in machines)
            {
                // Случайное количество листов для разнообразия.
                var pageCount = rnd.Next(1, 3);

                // Вызываем фабричный метод для создания валюты.
                var newMoney = machine.Create(pageCount);

                // Добавляем созданную валюту в общую коллекцию.
                money.AddRange(newMoney);
            }

            // Выводим данные о деньгах на экран.
            foreach (var note in money)
            {
                Console.WriteLine(note);
            }

            //Console.ReadLine();

            // ------------------- Pie
            Console.WriteLine("------------------- Pie");

            PieBase applePie = new ApplePie();
            PieBase meatPie = new MeatPie();

            // Готовим мясной пирог.
            Console.WriteLine(meatPie);
            meatPie.Cook();
           // Console.ReadLine();

            // Готовим яблочный пирог.
            Console.WriteLine(applePie);
            applePie.Cook();
            Console.ReadLine();
        }
    }
}
