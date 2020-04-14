/*
 * https://metanit.com/sharp/patterns/3.5.php
 * https://bool.dev/blog/detail/pattern-iterator-iterator
 * https://refactoring.guru/ru/design-patterns/iterator
 */

using System.Collections;

namespace Patterns.BehavioralPatterns.Iterator
{
    /// <summary>
    /// Определяет интерфейс для обхода составных объектов. Аналог IEnumerator.
    /// </summary>
    internal abstract class Iterator
    {
        public abstract object First();

        public abstract object Next();

        public abstract bool IsDone();

        public abstract object CurrentItem();
    }

    /// <summary>
    /// Определяет интерфейс для создания объекта-итератора. Аналог IEnumerable.
    /// </summary>
    internal abstract class Aggregate
    {
        public abstract Iterator CreateIterator();

        public abstract int Count { get; protected set; }
        public abstract object this[int index] { get; set; }
    }

    /// <summary>
    /// Конкретная реализация итератора для обхода объекта Aggregate.
    /// Для фиксации индекса текущего перебираемого элемента использует целочисленную переменную _current.
    /// </summary>
    internal class ConcreteIterator : Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current;

        public ConcreteIterator(Aggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object ret = null;

            _current++;

            if (_current < _aggregate.Count)
            {
                ret = _aggregate[_current];
            }

            return ret;
        }

        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }

    /// <summary>
    /// Конкретная реализация Aggregate. Хранит элементы, которые надо будет перебирать.
    /// </summary>
    internal class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList _items = new ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public override int Count
        {
            get { return _items.Count; }
            protected set { }
        }

        public override object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }
}