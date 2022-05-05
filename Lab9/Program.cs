using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext context = new AppContext();
            context.Database.EnsureCreated();

            //Console.WriteLine(context.Books.Find(1));
            IQueryable<Book> books = from book in context.Books
            where book.EditionYear > 2019
            select book;

            Console.WriteLine(string.Join("\n",books));

            var list = from book in context.Books
            join author in context.Authors
            on book.AuthorId equals author.Id
            where book.EditionYear > 2019
            select new { Name = author.Name, Title = book.Title };

            Console.WriteLine(string.Join("\n", list));


            list = context.Authors.Join(
                context.Books.Where(b=>b.EditionYear>2019),
                a=>a.Id,
                b=>b.AuthorId,
                (a,b)=> new {Name = a.Name, Title = b.Title }
                );
            Console.WriteLine(string.Join("\n", list));

            var numbers = context.BookCopies.Join(
                context.Books,
                c => c.BookID,
                b => b.Id,
                (c, b) => new { Title = b.Title, UniqueNumber = c.UniqueNumber }
                );
            Console.WriteLine(string.Join("\n", numbers));

            string xml = 
                "<books>" +
                    "<book>"+
                        "<Id>1</Id>" +
                        "<Title>C#</Title>" +
                    "</book>" +
                    "<book>" +
                        "<Id>2</Id>" +
                        "<Title>ASP.NET</Title>" +
                    "</book>" +
                "</books>";
            XDocument doc = XDocument.Parse(xml);
            var booksID = doc.Elements("books").Elements("book").Select(x=>new {ID=x.Elements("Id").First().Value,Title=x.Elements("Title").First().Value });

            foreach (var item in booksID)
            {
                Console.WriteLine(item);
            }
            WebClient client = new WebClient();
            client.Headers.Add("Accept", "application/xml");
            XDocument walutyString = XDocument.Parse(client.DownloadString("http://api.nbp.pl/api/exchangerates/tables/C"));
            var waluty = walutyString.Elements("ArrayOfExchangeRatesTable").Elements("ExchangeRatesTable").Elements("Rates").Elements("Rate").Select(x=>new { Currency = x.Element("Currency").Value,Ask=x.Element("Ask").Value,Bid=x.Element("Bid").Value });
            foreach (var item in waluty)
            {
                Console.WriteLine(item);
            }
        }
    }
    //zarejestruj ecje w kontekście
    public record BookCopy
    {
        public int Id { get; set; }
        public int BookID { get; set; }
        public string UniqueNumber {get;set;}

    }

    public record Book{
        public int Id { get; set; }
        public string Title { get; set; }
        public int EditionYear { get; set; }
        public int AuthorId { get; set; }
    }

    public record Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class AppContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DATASOURCE=d:\\database\\base.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books").HasData(
                new Book() { Id=1,AuthorId=1,EditionYear=2020,Title="C#"},
                new Book() { Id=2,AuthorId=1,EditionYear=2019,Title="ASP.NET"},
                new Book() { Id=3,AuthorId=2,EditionYear=2018,Title="Data Structures"},
                new Book() { Id=4,AuthorId=2,EditionYear=2017,Title="Web Application"}
            );

            modelBuilder.Entity<Author>().ToTable("Authors").HasData(
                new Author() { Id = 1, Name="John Doe" },
                new Author() { Id = 2, Name="Jhin Doe" }
            );

            modelBuilder.Entity<BookCopy>().ToTable("BookCopies").HasData(
                new BookCopy() { Id = 1, BookID = 1,UniqueNumber="AAA111" },
                new BookCopy() { Id = 2, BookID = 1,UniqueNumber="BBB222" }
            );
        }
    }

}
