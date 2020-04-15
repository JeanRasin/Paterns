using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Patterns.BehavioralPatterns.Prototype
{
    internal interface IFigure
    {
        IFigure Clone();

        IFigure CloneMemberwise();

        void GetInfo();
    }

    internal class Rectangle : IFigure
    {
        private readonly int width;
        private readonly int height;

        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public IFigure Clone()
        {
            return new Rectangle(width, height);
        }

        // Фреймворк .NET предлагает функционал для копирования в виде метода MemberwiseClone().
        public IFigure CloneMemberwise()
        {
            // В то же время надо учитывать, что метод MemberwiseClone() осуществляет неполное копирование - то есть копирование значимых типов.
            return this.MemberwiseClone() as IFigure;
        }

        public void GetInfo()
        {
            Console.WriteLine("Прямоугольник длиной {0} и шириной {1}", height, width);
        }
    }

    internal class Circle : IFigure
    {
        private readonly int radius;

        public Circle(int r)
        {
            radius = r;
        }

        public IFigure Clone()
        {
            return new Circle(radius);
        }

        // Фреймворк .NET предлагает функционал для копирования в виде метода MemberwiseClone().
        public IFigure CloneMemberwise()
        {
            return this.MemberwiseClone() as IFigure;
        }

        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0}", radius);
        }
    }

    [Serializable] // Для глубоко копирования.
    internal class Point
    {
        public int X { get; set; }

        public int Y { get; set; }
    }

    [Serializable]
    internal class Circle2 : IFigure
    {
        private int radius;
        public Point Point { get; set; }

        public Circle2(int r, int x, int y)
        {
            radius = r;
            Point = new Point { X = x, Y = y };
        }

        public IFigure Clone()
        {
            return new Circle2(radius, Point.X, Point.Y);
        }

        public IFigure CloneMemberwise()
        {
            return this.MemberwiseClone() as IFigure;
        }

        public object DeepCopy()
        {
            // Бинарная сериализация.
            object figure = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                figure = binFormatter.Deserialize(tempStream);
            }
            return figure;
        }

        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0} и центром в точке ({1}, {2})", radius, Point.X, Point.Y);
        }
    }
}