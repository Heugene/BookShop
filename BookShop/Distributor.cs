using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Distributor: Organization, IBookOwner, IBookSeller
    {
        public List<Book> OwnedLiterature { get; set; }
        public Action<string> BooksProvided { get; set; }

        public Distributor(string name, string address, string phone) : base(name, address, phone)
        {
            OwnedLiterature = new List<Book>();
        }

        public void Sell(Book Item, IBookOwner NewOwner)
        {
            if (OwnedLiterature.Contains(Item))
            {
                Balance += Item.Price;
                Book newBook = (Book)Item.Clone();
                NewOwner.OwnedLiterature.Add(newBook);
                newBook.ChangeOwner(NewOwner);
                BooksProvided?.Invoke($"Книга '{Item.Name}' успішно замовлена!");
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void PublishBook(Book newBook)
        {
            OwnedLiterature.Add(newBook);
            newBook.ChangeOwner(this);
        }

        public bool RetireBook(Book book)
        {
            if (OwnedLiterature.Contains(book))
            {
                OwnedLiterature.Remove(book);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string Info()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Distributor '{Name}'");
            result.AppendLine($"Address: {Address}");
            result.AppendLine($"Phone: {Phone}");
            result.AppendLine($"Balance {Balance}");
            result.AppendLine($"Assortiment: ");
            foreach (var item in OwnedLiterature.GroupBy(n => n.Name, p => p.Price).Select(c => new { book = c.Key, price = c.FirstOrDefault(), count = c.Count() }))
            {
                result.AppendLine(" " + item.book + " " + item.count + " " + item.price);
            };
            return result.ToString();
        }

    }
}
