using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.CreationalPatterns.FactoryMethod
{
    /// <summary>
    /// Базовый класс для любой валюты.
    /// </summary>
    public abstract class MoneyBase
    {
        /// <summary>
        /// Название валюты.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Символ валюты.
        /// </summary>
        public string Symbol { get; protected set; }

        /// <summary>
        /// Создать новый экземпляр валюты.
        /// </summary>
        /// <param name="name"> Название валюты. </param>
        /// <param name="symbol"> Символ валюты. </param>
        public MoneyBase(string name, string symbol)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            // Устанавливаем значения.
            Name = name;
            Symbol = symbol;
        }

        /// <summary>
        /// Приведение объекта к строке. 
        /// </summary>
        /// <returns> Название валюты. </returns>
        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// Базовый класс для устройств печати денег.
    /// </summary>
    public abstract class CashMachineBase
    {
        /// <summary>
        /// Название устройства.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Создать новый экземпляр устройства печати денег.
        /// </summary>
        /// <param name="name"> Название. </param>
        public CashMachineBase(string name)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            // Устанавливаем значение.
            Name = name;
        }

        /// <summary>
        /// Напечатать новую партию денег.
        /// </summary>
        /// <param name="pageCount"> Количество листов бумаги для денег. </param>
        /// <returns> Напечатанные деньги. </returns>
        public abstract MoneyBase[] Create(int pageCount);

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Название. </returns>
        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// Российский рубль.
    /// </summary>
    public class Ruble : MoneyBase
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Номинал валюты.
        /// </summary>
        public int Denomination { get; private set; }

        /// <summary>
        /// Создать новый экземпляр рубля.
        /// </summary>
        /// <param name="denomination"> Номинал валюты. </param>
        public Ruble(int denomination)
            : base("Российский рубль", "₽")
        {
            // Проверяем входные данные на корректность.
            if (denomination <= 0)
            {
                throw new ArgumentException("Номинал валюты должен быть больше нуля.", nameof(denomination));
            }

            // Создаем генератор случайных чисел.
            var rnd = new Random();

            // Устанавливаем значения.
            Number = rnd.Next(1000000, 9999999);
            Denomination = denomination;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Информация о купюре. </returns>
        public override string ToString()
        {
            return $"{Name} {Number} номиналом {Denomination}{Symbol}";
        }
    }

    /// <summary>
    /// Американский доллар.
    /// </summary>
    public class Dollar : MoneyBase
    {
        /// <summary>
        /// Уникальный код.
        /// </summary>
        public Guid Number { get; private set; }

        /// <summary>
        /// Номинал валюты.
        /// </summary>
        public int Volume { get; private set; }

        /// <summary>
        /// Создать новый экземпляр американского доллара.
        /// </summary>
        /// <param name="volume"> Номинал. </param>
        public Dollar(int volume)
            : base("American dollar", "$")
        {
            // Проверяем входные данные на корректность.
            if (volume <= 0)
            {
                throw new ArgumentException("Номинал валюты должен быть больше нуля.", nameof(volume));
            }

            Number = Guid.NewGuid();
            Volume = volume;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Информация о купюре. </returns>
        public override string ToString()
        {
            return $"{Name} {Number} номиналом {Volume}{Symbol}";
        }
    }

    /// <summary>
    /// Евро.
    /// </summary>
    public class Euro : MoneyBase
    {
        /// <summary>
        /// Уникальный код.
        /// </summary>
        public Guid Number { get; private set; }

        /// <summary>
        /// Номинал валюты.
        /// </summary>
        public int Par { get; private set; }

        public Euro(int par)
            : base("Euro", "€")
        {
            // Проверяем входные данные на корректность.
            if (par <= 0)
            {
                throw new ArgumentException("Номинал валюты должен быть больше нуля.", nameof(par));
            }

            Number = Guid.NewGuid();
            Par = par;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Информация о купюре. </returns>
        public override string ToString()
        {
            return $"{Name} {Number} номиналом {Par}{Symbol}";
        }
    }

    /// <summary>
    /// Устройство для печати российских рублей.
    /// </summary>
    public class RubleCashMachine : CashMachineBase
    {
        /// <summary>
        /// Количество купюр на одном листе бумаги.
        /// </summary>
        private readonly int _countOnPage = 64;

        /// <summary>
        /// Номинал купюры.
        /// </summary>
        private int _denomination;

        /// <summary>
        /// Возможные номиналы валюты.
        /// </summary>
        private int[] _correntDenomination = { 50, 100, 200, 500, 1000, 2000, 5000 };

        /// <summary>
        /// Создать новый экземпляр устройства для печати российских рублей.
        /// </summary>
        /// <param name="denomination"> Номинал. </param>
        public RubleCashMachine(int denomination = 1000)
            : base("Устройство для печати российских рублей")
        {
            // Проверяем входные данные на корректность.
            if (denomination <= 0)
            {
                throw new ArgumentException("Номинал валюты должен быть больше нуля.", nameof(denomination));
            }

            if (!_correntDenomination.Contains(denomination))
            {
                throw new ArgumentException($"Некорректный номинал валюты.", nameof(denomination));
            }

            // Устанавливаем значение.
            _denomination = denomination;
        }

        /// <inheritdoc />
        public override MoneyBase[] Create(int pageCount)
        {
            // Подсчитываем количество денег, которое должно быть напечатано.
            var count = _countOnPage * pageCount;

            // Создаем коллекцию для сохранения денег.
            var money = new List<MoneyBase>();

            // Создаем деньги и добавляем в коллекцию.
            for (var i = 0; i < count; i++)
            {
                var ruble = new Ruble(_denomination);
                money.Add(ruble);
            }

            // Возвращаем готовые деньги.
            return money.ToArray();
        }
    }

    public class DollarCashMachine : CashMachineBase
    {
        /// <summary>
        /// Номинал купюры.
        /// </summary>
        private int _denomination;

        /// <summary>
        /// Создать новый экземпляр устройства для печати американских долларов.
        /// </summary>
        /// <param name="denomination"> Номинал. </param>
        public DollarCashMachine(int denomination = 100)
            : base("Устройство для печати американских долларов")
        {
            // Проверяем входные данные на корректность.
            if (denomination <= 0)
            {
                throw new ArgumentException("Номинал валюты должен быть больше нуля.", nameof(denomination));
            }

            // Возможные номиналы валюты.
            var correntDenomination = new int[] { 5, 10, 50, 100, 500, 1000 };

            // Проверяем корректность номинала.
            if (!correntDenomination.Contains(denomination))
            {
                throw new ArgumentException($"Некорректный номинал валюты.", nameof(denomination));
            }

            // Устанавливаем значение.
            _denomination = denomination;
        }

        /// <inheritdoc />
        public override MoneyBase[] Create(int pageCount)
        {
            // Количество купюр на одном листе бумаги.
            var countOnPage = 50;

            // Подсчитываем количество денег, которое должно быть напечатано.
            var count = countOnPage * pageCount;

            // Создаем коллекцию для сохранения денег.
            var money = new List<MoneyBase>();

            // Создаем деньги и добавляем в коллекцию.
            for (var i = 0; i < count; i++)
            {
                var dollar = new Dollar(_denomination);
                money.Add(dollar);
            }

            // Возвращаем готовые деньги.
            return money.ToArray();
        }
    }

    public class EuroCashMachine : CashMachineBase
    {
        /// <summary>
        /// Номинал купюры.
        /// </summary>
        private int _denomination;

        /// <summary>
        /// Создать новый экземпляр устройства для печати американских долларов.
        /// </summary>
        /// <param name="denomination"> Номинал. </param>
        public EuroCashMachine(int denomination = 100)
            : base("Устройство для печати евро")
        {
            // Проверяем входные данные на корректность.
            if (denomination <= 0)
            {
                throw new ArgumentException("Номинал валюты должен быть больше нуля", nameof(denomination));
            }

            // Возможные номиналы валюты.
            var correntDenomination = new int[] { 5, 10, 20, 50, 100, 200, 500 };

            // Проверяем корректность номинала.
            if (!correntDenomination.Contains(denomination))
            {
                throw new ArgumentException("Некорректный номинал валюты.", nameof(denomination));
            }

            // Устанавливаем значение.
            _denomination = denomination;
        }

        /// <inheritdoc />
        public override MoneyBase[] Create(int pageCount)
        {
            // Количество купюр на одном листе бумаги.
            var countOnPage = 50;

            // Подсчитываем количество денег, которое должно быть напечатано.
            var count = countOnPage * pageCount;

            // Создаем коллекцию для сохранения денег.
            var money = new List<MoneyBase>();

            // Создаем деньги и добавляем в коллекцию.
            for (var i = 0; i < count; i++)
            {
                var euro = new Euro(_denomination);
                money.Add(euro);
            }

            // Возвращаем готовые деньги.
            return money.ToArray();
        }
    }
}
