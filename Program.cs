using Patterns.BehavioralPatterns.Iterator;
using Patterns.BehavioralPatterns.Prototype;
using Patterns.BehavioralPatterns.State;
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

            // State
            // ------------------- State
            Console.WriteLine("------------------- State");

            var context = new Context(new StateA());
            context.Request(); // Переход в состояние StateB
            context.Request();  // Переход в состояние StateA

            var water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();

            // Prototype
            // ------------------- Prototype
            Console.WriteLine("------------------- Prototype");

            Prototype prototype = new ConcretePrototype1(5);
            Prototype clone = prototype.Clone();
            prototype = new ConcretePrototype2(7);
            clone = prototype.Clone();

            // --- Circle
            IFigure rectangle = new Rectangle(100, 300);
            IFigure rectangleClone = rectangle.Clone();
            IFigure rectangleMemberwiseClone = rectangle.CloneMemberwise();
            rectangleMemberwiseClone.GetInfo();
            rectangle.GetInfo();
            rectangleClone.GetInfo();

            IFigure circle = new Circle(152);
            IFigure circleClone = circle.Clone();
            circle.GetInfo();
            circleClone.GetInfo();

            // Shallow Copy
            Console.WriteLine("--- Shallow Copy");
            var figure = new Circle2(30, 50, 60);
            var cloneFigure = figure.CloneMemberwise() as Circle2;
            figure.Point.X = 100;
            figure.GetInfo();
            cloneFigure.GetInfo();

            // Deep Copy
            Console.WriteLine("--- Deep Copy");
            var figure2 = new Circle2(30, 50, 60);
            var cloneFigure2 = figure2.DeepCopy() as Circle2;
            figure2.Point.X = 100;
            figure2.GetInfo();
            cloneFigure2.GetInfo();

            // Proxy
            // ------------------- Proxy
            Console.WriteLine("------------------- Proxy");

            var client = new BehavioralPatterns.Proxy.RealProxy.Client();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            var realSubject = new BehavioralPatterns.Proxy.RealProxy.RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();
            Console.WriteLine("Client: Executing the same client code with a proxy:");
            var proxy = new BehavioralPatterns.Proxy.RealProxy.Proxy(realSubject);
            client.ClientCode(proxy);
        }
    }
}