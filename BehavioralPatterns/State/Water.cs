using System;

namespace Patterns.BehavioralPatterns.State
{
    internal interface IWaterState
    {
        void Heat(Water water);

        void Frost(Water water);
    }

    // context
    internal class Water
    {
        public IWaterState State { get; set; }

        public Water(IWaterState state)
        {
            State = state;
        }

        public void Heat()
        {
            State.Heat(this);
        }

        public void Frost()
        {
            State.Frost(this);
        }
    }

    internal class SolidWaterState : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("Превращаем лед в жидкость");
            water.State = new LiquidWaterState();
        }

        public void Heat(Water water)
        {
            Console.WriteLine("Продолжаем заморозку льда");
        }
    }

    internal class LiquidWaterState : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("Превращаем жидкость в пар");
            water.State = new GasWaterState();
        }

        public void Heat(Water water)
        {
            Console.WriteLine("Превращаем жидкость в лед");
            water.State = new SolidWaterState();
        }
    }

    internal class GasWaterState : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("Повышаем температуру водяного пара");
        }

        public void Heat(Water water)
        {
            Console.WriteLine("Превращаем водяной пар в жидкость");
            water.State = new LiquidWaterState();
        }
    }
}