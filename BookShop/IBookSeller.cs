using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public interface IBookSeller
    {
        public void Sell(ProtoBook Item, IBookOwner NewOwner);
    }
}
