/*
 * https://metanit.com/sharp/patterns/4.2.php
 * https://bool.dev/blog/detail/strukturnye-patterny-adapter-csharp
 * https://refactoring.guru/ru/design-patterns/adapter
 */

namespace Patterns.StructuralPatterns.Adapter
{
    /// <summary>
    /// Класс, к которому надо адаптировать другой класс.
    /// Представляет объекты, которые используются клиентом.
    /// </summary>
    internal class Target
    {
        public virtual void Request()
        { }
    }

    /// <summary>
    /// Использует объекты Target для реализации своих задач.
    /// </summary>
    internal class Client
    {
        public void Request(Target target)
        {
            target.Request();
        }
    }

    /// <summary>
    /// Адаптируемый класс.
    /// </summary>
    internal class Adaptee
    {
        public void SpecificRequest()
        { }
    }

    /// <summary>
    /// Адаптер.
    /// </summary>
    internal class Adater : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }
}