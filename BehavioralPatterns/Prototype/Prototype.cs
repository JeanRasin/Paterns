/*
 * https://metanit.com/sharp/patterns/2.4.php
 * https://refactoring.guru/ru/design-patterns/prototype
 * https://bool.dev/blog/detail/porozhdayushchie-patterny-prototype-sharp
 */

namespace Patterns.BehavioralPatterns.Prototype
{
    internal abstract class Prototype
    {
        public int Id { get; private set; }

        public Prototype(int id)
        {
            Id = id;
        }

        public abstract Prototype Clone();
    }

    internal class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }

    internal class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype2(Id);
        }
    }
}