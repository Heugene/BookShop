using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    internal class ArtBook: ProtoBook
    {
        static ArtBook()
        {
            LitType = "ArtBook";
        }

        public ArtBook(string name, string author, int yearPublished, string isbn, int pagesCount, bool Colourful, decimal price) : base(name, author, yearPublished, isbn, pagesCount, Colourful, price)
        {
        }
    }
}
