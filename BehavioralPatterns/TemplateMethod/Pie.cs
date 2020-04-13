using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.BehavioralPatterns.TemplateMethod
{
    /// <summary>
    /// Базовый класс пирога.
    /// </summary>
    public abstract class PieBase
    {
        /// <summary>
        /// Приготовить пирог.
        /// </summary>
        public void Cook()
        {
            CreateDough();
            CreateFilling();
            Fry();
        }

        /// <summary>
        /// Замешать тесто.
        /// </summary>
        protected abstract void CreateDough();

        /// <summary>
        /// Приготовить начинку.
        /// </summary>
        protected abstract void CreateFilling();

        /// <summary>
        /// Запечь пирог в духовке.
        /// </summary>
        protected abstract void Fry();
    }

    public class ApplePie : PieBase
    {
        /// <inheritdoc />
        protected override void CreateDough()
        {
            Console.WriteLine("Используем слоеное тесто.");
        }

        /// <inheritdoc />
        protected override void CreateFilling()
        {
            Console.WriteLine("Используем яблочную начинку.");
        }

        /// <inheritdoc />
        protected override void Fry()
        {
            Console.WriteLine("Запекаем в духовке при температуре 180 градусов в течении 30 минут.");
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Тип пирога. </returns>
        public override string ToString()
        {
            return "Яблочный пирог";
        }
    }

    public class MeatPie : PieBase
    {
        /// <inheritdoc />
        protected override void CreateDough()
        {
            Console.WriteLine("Используем дрожжевое тесто.");
        }

        /// <inheritdoc />
        protected override void CreateFilling()
        {
            Console.WriteLine("Используем мясную начинку.");
        }

        /// <inheritdoc />
        protected override void Fry()
        {
            Console.WriteLine("Запекаем в духовке при температуре 210 градусов в течении 50 минут.");
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Тип пирога. </returns>
        public override string ToString()
        {
            return "Мясной пирог";
        }
    }
}
