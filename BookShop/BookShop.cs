using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class BookShop: Organization, IBookOwner, IBookSeller
    {
        public delegate void TyBomzh(string message);
        public delegate void BookSellingHandler(IBookOwner NewOwner, string message);
        public delegate void BookSoldHandler(Book Item, string message);
        public event BookSellingHandler BookSelling;
        public event BookSoldHandler BookSold;

        public decimal ProfitFactor { get; private set; } = 1.2M;
        public Distributor Distributor { get; private set; }
        public List<Customer> Customers { get; private set; }
        public List<Book> OwnedLiterature { get; set; }
        public Action<string> BooksOrdered { get; set; } 
        public TyBomzh Bomzh { get; set; }

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
            if (OwnedLiterature.Contains(Item))
            {
                BookSelling?.Invoke(NewOwner, $"Книга {Item.Name} продається покупцеві! {(NewOwner as Customer)?.Name}");
                Balance += Item.Price * ProfitFactor;
                NewOwner.OwnedLiterature.Add(Item);
                Item.ChangeOwner(NewOwner);
                OwnedLiterature.Remove(Item);
                BookSold?.Invoke(Item, $"Книга {Item.Name} продана!");
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool OrderBook(Book Item, int Quanity)
        {
            if (Distributor.OwnedLiterature.Contains(Item))
            {
                if (Balance >= Item.Price * Quanity)
                {
                    for (int i = 0; i < Quanity; i++)
                    {
                        Balance -= Item.Price;
                        Distributor.Sell(Item, this);
                    }
                    BooksOrdered?.Invoke("Партія успішно замовлена!");
                    return true;
                }
                else
                {
                    Bomzh?.Invoke("Недостатньо коштів для замовлення!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override string Info()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Book shop '{Name}'");
            result.AppendLine($"Address: {Address}");
            result.AppendLine($"Phone: {Phone}");
            result.AppendLine($"Balance {Balance}");
            result.AppendLine($"Profit factor: {ProfitFactor}");
            result.AppendLine($"Distributor: '{Distributor.Name}'");
            result.AppendLine($"Assortiment: ");
            foreach (var item in OwnedLiterature.GroupBy(n => n.Name, p => p.Price * ProfitFactor).Select(c => new { book = c.Key, price = c.FirstOrDefault(), count = c.Count() }))
            {
                result.AppendLine(" "+item.book+" "+item.count + " " + item.price);
            };
            result.AppendLine("Customers:");
            foreach (Customer customer in Customers)
            {
                result.AppendLine(customer.Name);
            }
            return result.ToString();
        }
    }
}
