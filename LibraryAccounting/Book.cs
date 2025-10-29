using System;

namespace LibraryAccounting
{
    public class Book : IComparable<Book>
    {
        public string Author { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public int Copies { get; set; }

        public Book() { }

        public Book(string author, int year, string title, int copies)
        {
            Author = author;
            Year = year;
            Title = title;
            Copies = copies;
        }

        public int CompareTo(Book other)
        {
            return Author.CompareTo(other.Author);
        }

        public override string ToString()
        {
            return $"{Author} \"{Title}\" ({Year}) - {Copies} шт.";
        }
    }
}