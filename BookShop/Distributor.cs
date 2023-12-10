using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Distributor: Organization, IBookOwner, IBookSeller
    {
        public List<Book> OwnedLiterature { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Distributor(string name, string address, string phone) : base(name, address, phone)
        {
            OwnedLiterature = new List<Book>();
        }

        public void Sell(Book Item, IBookOwner NewOwner)
        {
            throw new NotImplementedException();
        }

        public void PublishBook(Book newBook)
        {
            throw new NotImplementedException();
        }

        public void RetireBook(Book book)
        {
            throw new NotImplementedException();
        }

    }
}
