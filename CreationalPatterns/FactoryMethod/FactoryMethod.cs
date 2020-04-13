/*
 * https://metanit.com/sharp/patterns/2.1.php
 * https://bool.dev/blog/detail/porozhdayushchie-patterny-fabrichnyy-metod
 * https://shwanoff.ru/factory-method
 * https://refactoring.guru/ru/design-patterns/factory-method/csharp/example
 */

namespace Patterns.CreationalPatterns.FactoryMethod
{
    public abstract class Product
    {
    }

    public class CurrentProductA : Product
    {
    }

    public class CurrentProductB : Product
    {
    }

    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    public class CurentCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new CurrentProductA();
        }
    }

    public class CurrentCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new CurrentProductB();
        }
    }
}