using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class BookShop: Organization, IBookOwner, IBookSeller
    {
        public decimal ProfitFactor { get; private set; } = 1.2M;
        public Distributor Distributor { get; private set; }
        public List<Customer> Customers { get; private set; }
        public List<Book> OwnedLiterature { get; set; }

        public BookShop(string name, string address, string phone, decimal profitFactor, Distributor distributor, decimal StartBalance) : base (name, address, phone)
        {
            ProfitFactor = profitFactor;
            Distributor = distributor;
            Balance = StartBalance;
            OwnedLiterature = new List<Book>();
            Customers = new List<Customer>();
        }

        public void Sell(Book Item, IBookOwner NewOwner)
        {
            throw new NotImplementedException();
        }

        public bool OrderBook(Book item, int Quanity)
        { 
            throw new NotImplementedException(); 
        }
    }
}
