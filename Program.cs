using Patterns.BehavioralPatterns.Iterator;
using Patterns.BehavioralPatterns.TemplateMethod;
using Patterns.CreationalPatterns.FactoryMethod;
using Patterns.StructuralPatterns.Adapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Factory Method
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

            // Template method
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
            // Console.ReadLine();

            Console.WriteLine("------------------- School");

            School school = new School();
            University university = new University();
            College college = new College();

            school.Learn();
            university.Learn();
            college.Learn();

            // Adapter
            // ------------------- Travel
            Console.WriteLine("------------------- Travel");

            // Путешественник
            Driver driver = new Driver();

            // Машина
            Auto auto = new Auto();

            // Отправляемся в путешествие
            driver.Travel(auto);

            // Встретились пески, надо использовать верблюда
            Camel camel = new Camel();

            // Используем адаптер
            ITransport camelToTransportAdapter = new CamelToTransportAdapter(camel);

            // Продолжаем путь по пескам пустыни
            driver.Travel(camelToTransportAdapter);

            // Iterator
            // ------------------- Iterator
            Console.WriteLine("------------------- Iterator");

            Aggregate aggregate = new ConcreteAggregate();

            Iterator iterator = aggregate.CreateIterator();

            /*
            object item = iterator.First();
            while(!iterator.IsDone())
            {
                item = iterator.Next();
            }
            */

            Console.WriteLine("------------------- Iterator Books");

            var library = new Library();
            var reader = new Reader();
            reader.SeeBooks(library);

            Console.WriteLine("------------------- Iterator Words");

            // Клиентский код может знать или не знать о Конкретном Итераторе
            // или классах Коллекций, в зависимости от уровня косвенности,
            // который вы хотите сохранить в своей программе.
            var collection = new BehavioralPatterns.Iterator.Words.WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("Straight traversal:");

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nReverse traversal:");

            collection.ReverseDirection();

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }
    }
}