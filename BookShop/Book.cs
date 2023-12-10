using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Book : ICloneable
    {
        public LitType LitType { get; private set; }
        public string Name {  get; private set; }
        public string Author { get; private set; }
        public int YearPublished { get; private set; }
        public string ISBN { get; private set; }
        public string[] Genres { get; private set; }
        public int PagesCount { get; private set; }
        public bool Colourful { get; private set; }
        public decimal Price { get; private set; }
        public IBookOwner Owner { get; private set; }


        public void ChangeOwner(IBookOwner bookOwner)
        {
            throw new NotImplementedException();
        }

        public string Info()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Book(LitType litType, string name, string author, int yearPublished, string isbn, string[] genres, int pagesCount, bool Colourful, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
