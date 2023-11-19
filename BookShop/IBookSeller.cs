using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public interface IBookSeller
    {
        public List<ProtoBook> OwnedLiterature {get; set;}
    }
}
