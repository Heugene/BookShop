using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public abstract class Organization
    {
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string Phone { get; protected set; }
        public decimal Balance { get; protected set; }

        public Organization(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Balance = 0;
        }

        public string Info()
        {
            return "---";
        }
    }
}
