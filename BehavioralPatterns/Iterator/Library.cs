using System;

namespace Patterns.BehavioralPatterns.Iterator
{
    internal interface IBookIterator
    {
        bool HasNext();

        Book Next();
    }

    internal interface IBookNumerable
    {
        IBookIterator CreateNumerator();

        int Count { get; }
        Book this[int index] { get; }
    }

    internal class Book
    {
        public string Name { get; set; }
    }

    // Aggregate.
    internal class Library : IBookNumerable
    {
        private readonly Book[] _books;

        public Library()
        {
            _books = new Book[]
                {
                   new Book {Name="Война и мир"},
                   new Book {Name="Отцы и дети"},
                   new Book {Name="Вишневый сад"}
                };
        }

        public int Count { get { return _books.Length; } }

        public Book this[int index] { get { return _books[index]; } }

        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }
    }

    internal class LibraryNumerator : IBookIterator
    {
        private readonly IBookNumerable _aggregate;
        private int _index = 0;

        public LibraryNumerator(IBookNumerable aggregate)
        {
            _aggregate = aggregate;
        }

        public bool HasNext()
        {
            return _index < _aggregate.Count;
        }

        public Book Next()
        {
            return _aggregate[_index++];
        }
    }

    internal class Reader
    {
        public void SeeBooks(Library library)
        {
            IBookIterator iterator = library.CreateNumerator();

            while (iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }
}