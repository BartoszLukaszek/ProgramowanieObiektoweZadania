﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab5
{
    public record Book(string Tittle,string Author, string Isbn);
    class Library: IEnumerable<Book>
    {
        internal Book[] _books = { 
            new Book("C#","Freeman","123"),
            new Book("ASP.NET","Freeman","332"),
            null,
            null,
            new Book("Java","Bloch","321"),
            null,

        };

        public Book this[string isbn]
        {
            get 
            {
                foreach (Book book in _books)
                {
                    if (book.Isbn.Equals(isbn))
                    {
                        return book;
                    }
                }
                return null;
            }
        }

        public Book this[int index]
        {
            get
            {
                return _books[index - 1];
            }
            set
            {
                _books[index - 1] = value;
            }
        }
        public IEnumerator<Book> GetEnumerator()
        {
            //return new BookEnumerator(this);
            foreach (Book book in _books)
            {
                if(book != null)
                {
                    yield return book;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Team: IEnumerable<string>
    {
        public string Leader;
        public string ScrumMaster;
        public string Developer;

        public IEnumerator<string> GetEnumerator()
        {
            yield return Leader; //wartość zwrócona przy pierwszym wywołaniu movenext()
            yield return ScrumMaster; //..               drugim
            yield return Developer;//..                  trzecim
            for (int i = 0; i < 5; i++)
            {
                yield return "Vacat";
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class BookEnumerator : IEnumerator<Book>
    {
        private Library _library;
        int index = -1;
        public BookEnumerator(Library library)
        {
           _library = library;
        }


        public Book Current
        {
            get
            {
                while (_library._books[index] == null && index < _library._books.Length-1)
                {
                    index++;
                }
                return _library._books[index];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
           return ++index < _library._books.Length;
        }

        public void Reset()
        {
            
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Library books = new Library();
            IEnumerator<Book> enumerator = books.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            for(var e = books.GetEnumerator(); e.MoveNext();)
            {
                Console.WriteLine(e.Current);
            }

            foreach (Book item in books)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Team team = new Team() { Leader="Leader",ScrumMaster="ScrumMaster",Developer="Developer"};
            foreach (var item in team)
            {
                Console.WriteLine(item);
            }

            
            Console.WriteLine(books["123"]);
            books[3] = new Book("HTML", "Freeman", "744");
            Console.WriteLine(string.Join(", ",books));
        }
    }
}
