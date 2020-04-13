using System;

namespace Patterns.StructuralPatterns.Adapter
{
    interface ITransport
    {
        void Drive();
    }

    interface IAnimal
    {
        void Move();
    }

    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет по дороге");
        }
    }

    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Верблюд идет по пескам пустыни");
        }
    }

    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }

    class CamelToTransportAdapter : ITransport
    {
        Camel Camel { get; set; }

        public CamelToTransportAdapter(Camel camel)
        {
            Camel = camel;
        }

        public void Drive()
        {
            Camel.Move();
        }
    }
}
