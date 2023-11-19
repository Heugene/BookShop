using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public abstract class ProtoBook
    {
        public static string LitType;
        public string Name {  get; private set; }
        public string Author { get; private set; }
        public int YearPublished { get; private set; }
        public string ISBN { get; private set; }
        public int PagesCount { get; private set; }
        public bool Colourful { get; private set; }
        public decimal Price { get; private set; }

        public string Read()
        {
            throw new NotImplementedException();
        }

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

        public ProtoBook(string name, string author, int yearPublished, string isbn, int pagesCount, bool Colourful, decimal price)
        {
            throw new NotImplementedException();
        }

        public ProtoBook(ProtoBook Clone)
        {
            throw new NotImplementedException();
        }
    }
}
