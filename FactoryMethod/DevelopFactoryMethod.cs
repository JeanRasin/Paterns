/*
 * https://metanit.com/sharp/patterns/2.1.php
 * https://bool.dev/blog/detail/porozhdayushchie-patterny-fabrichnyy-metod
 * https://shwanoff.ru/factory-method
 * https://refactoring.guru/ru/design-patterns/factory-method/csharp/example
 */

using System;

namespace Patterns.FactoryMethod
{
    /// <summary>
    /// Product - house
    /// </summary>
    public abstract class House { }

    /// <summary>
    /// Concrete product - panel
    /// </summary>   
    public class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }

    /// <summary>
    /// Concrete product - wood
    /// </summary>    
    public class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }

    /// <summary>
    /// Concrete product - brick
    /// </summary>
    public class BrickHouse : House
    {
        public BrickHouse()
        {
            Console.WriteLine("Кирпичный дом построен");
        }
    }

    /// <summary>
    /// Creator - developer
    /// </summary>
    public abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Factory method - Create
        /// </summary>
        /// <returns></returns>        
        abstract public House Create();
    }

    /// <summary>
    /// Creator developer - panel
    /// </summary>
    public class DeveloperPanel : Developer
    {
        public DeveloperPanel(string name) : base(name)
        {

        }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    /// <summary>
    /// Creator developer - wood
    /// </summary>
    public class DeveloperWood : Developer
    {
        public DeveloperWood(string name) : base(name)
        {

        }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    /// <summary>
    /// Creator developer - brick
    /// </summary>
    public class DeveloperBrick : Developer
    {
        public DeveloperBrick(string name) : base(name)
        {

        }

        public override House Create()
        {
            return new BrickHouse();
        }
    }
}
