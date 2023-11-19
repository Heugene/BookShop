using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class BookShop: IBookOwner, IBookSeller
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public decimal ProfitFactor { get; private set; } = 1.2M;
        public Distributor Distributor { get; private set; }
        public List<Customer> Customers { get; private set; }
        public decimal Balance { get; private set; }
        public List<ProtoBook> OwnedLiterature { get; set; }

        public BookShop(string name, string address, string phone, decimal profitFactor, Distributor distributor, decimal StartBalance)
        {
            Name = name;
            Address = address;
            Phone = phone;
            ProfitFactor = profitFactor;
            Distributor = distributor;
            Balance = StartBalance;
            OwnedLiterature = new List<ProtoBook>();
            Customers = new List<Customer>();
        }

        public void Sell(ProtoBook Item, IBookOwner NewOwner)
        {
            throw new NotImplementedException();
        }
    }
}
