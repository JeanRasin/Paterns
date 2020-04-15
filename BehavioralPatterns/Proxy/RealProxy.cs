using System;

namespace Patterns.BehavioralPatterns.Proxy.RealProxy
{
    internal interface ISubject
    {
        void Reauest();
    }

    internal class RealSubject : ISubject
    {
        public void Reauest()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    internal class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            _realSubject = realSubject;
        }

        public void Reauest()
        {
            if (CheckAccess())
            {
                _realSubject = new RealSubject();
                _realSubject.Reauest();

                LogAccess();
            }
        }

        public bool CheckAccess()
        {
            // Некоторые реальные проверки должны проходить здесь.
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");

            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }

    internal class Client
    {
        public void ClientCode(ISubject subject)
        {
            subject.Reauest();
        }
    }
}