using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Distributor: IBookOwner, IBookSeller
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public decimal Balance { get; private set; } = 0;
        public List<ProtoBook> OwnedLiterature { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Distributor(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public void Sell(ProtoBook Item, IBookOwner NewOwner)
        {
            throw new NotImplementedException();
        }
    }
}
