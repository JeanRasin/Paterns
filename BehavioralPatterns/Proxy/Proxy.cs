/*
 * https://refactoring.guru/ru/design-patterns/proxy
 * https://bool.dev/blog/detail/strukturnye-patterny-zamestitel-c
 * https://metanit.com/sharp/patterns/4.5.php
 */

namespace Patterns.BehavioralPatterns.Proxy
{
    internal abstract class Subject
    {
        public abstract void Request();
    }

    internal class RealSubject : Subject
    {
        public override void Request()
        {
            // Work.
        }
    }

    internal class Proxy : Subject
    {
        private RealSubject realSubject;

        public override void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }

            realSubject.Request();
        }
    }
}