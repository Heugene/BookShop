using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Customer : IBookOwner
    {
        public string Name { get; private set; }

        public List<ProtoBook> OwnedLiterature { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Customer(string name)
        {
            this.Name = name;
            OwnedLiterature = new List<ProtoBook>();
        }
    }
}
