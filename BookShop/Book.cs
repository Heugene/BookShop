using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Book : ProtoBook
    {
        static Book()
        {
            LitType = "Book";
        }

        public Book(string name, string author, int yearPublished, string isbn, int pagesCount, bool Colourful, decimal price) : base(name, author, yearPublished, isbn, pagesCount, Colourful, price)
        {
        }
    }
}
