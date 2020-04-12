using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.FactoryMethod
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
