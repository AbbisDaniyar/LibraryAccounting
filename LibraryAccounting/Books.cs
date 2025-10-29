using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAccounting
{
    internal class Books : IComparable<Books>
    {
        public string Author { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public int Copies { get; set; }

        public Books(string author, int year, string title, int copies) {
            Author = author;
            Year = year;
            Title = title;
            Copies = copies;
        }

        public int CompareTo(Books other)
        {
            return Author.CompareTo(other.Author);
        }

        public override string ToString()
        {
            return $"{Author} \"{Title}\" ({Year}) - {Copies} шт.";
        }
    }
}
