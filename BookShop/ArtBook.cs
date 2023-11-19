using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Artbook: ProtoBook
    {
        static Artbook()
        {
            LitType = "ArtBook";
        }

        public Artbook(string name, string author, int yearPublished, string isbn, int pagesCount, bool Colourful, decimal price) : base(name, author, yearPublished, isbn, pagesCount, Colourful, price)
        {
        }

        public Artbook(Artbook clone) : base(clone) { }
    }
}
