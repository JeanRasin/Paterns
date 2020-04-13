using System;

namespace Patterns.BehavioralPatterns.TemplateMethod
{
    /// <summary>
    /// Также надо отметить ситуацию с наследованием базового класса.
    /// Например, у нас может быть ситуация, когда базовый класс Education сам наследует
    /// метод Learn от другого класса
    /// </summary>
    internal abstract class Learning
    {
        public abstract void Learn();
    }

    internal abstract class Education : Learning
    {
        /// <summary>
        /// Template method.
        /// </summary>
        public sealed override void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }

        public abstract void Enter();

        public abstract void Study();

        public virtual void PassExams()
        {
            Console.WriteLine("Сдаем выпускные экзамены");
        }

        public abstract void GetDocument();
    }

    internal class School : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Идем в первый класс");
        }

        public override void Study()
        {
            Console.WriteLine("Посещаем уроки, делаем домашние задания");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Получаем аттестат о среднем образовании");
        }
    }

    internal class University : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Сдаем вступительные экзамены и поступаем в ВУЗ");
        }

        public override void Study()
        {
            Console.WriteLine("Посещаем лекции");
            Console.WriteLine("Проходим практику");
        }

        public override void PassExams()
        {
            Console.WriteLine("Сдаем экзамен по специальности");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Получаем диплом о высшем образовании");
        }
    }

    internal class College : Education
    {
        /// <summary>
        /// Реализация шаблонного метода не будет иметь смысла.
        /// </summary>
        public new void Learn()
        {
            Console.WriteLine("Не хочу учиться");
        }

        public override void Enter()
        {
            Console.WriteLine("Сдаем вступительные экзамены и поступаем в колледж");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Получаем диплом о среднем образовании");
        }

        public override void Study()
        {
            Console.WriteLine("Посещаем лекции");
            Console.WriteLine("Проходим практику");
        }
    }
}