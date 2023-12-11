using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Book : ICloneable
    {
        public LitType LitType { get; private set; }
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int YearPublished { get; private set; }
        public string ISBN { get; private set; }
        public string[] Genres { get; private set; }
        public int PagesCount { get; private set; }
        public bool Colourful { get; private set; }
        public decimal Price { get; private set; }
        public IBookOwner? Owner { get; private set; }


        public void ChangeOwner(IBookOwner newOwner)
        {
            this.Owner = newOwner;
        }

        public string Info()
        {
            StringBuilder result = new StringBuilder(
                $"{LitType} '{Name}'" +
                $"\nAuthor: {Author}" +
                $"\nYear: {YearPublished}" +
                $"\nISBN {ISBN}" +
                $"\nGenres:\n");
            foreach (string genre in Genres)
            {
                result.AppendLine(" " + genre + ";");
            }
            result.Append(
                $"\nPages: {PagesCount}" +
                $"\nColourful: {(Colourful ? "Yes" : "No")}" +
                $"\nPrice: {Price}");
            result.AppendLine();
            if (!(Owner == null))
            {
                switch (Owner.GetType().Name)
                {
                    case "Distributor":
                        { result.AppendLine($"Owner: {(Owner as Distributor).Name}"); }
                        break;
                    case "BookShop":
                        { result.AppendLine($"Owner: {(Owner as BookShop).Name}"); }
                        break;
                    case "Customer":
                        { result.AppendLine($"Owner: {(Owner as Customer).Name}"); }
                        break;
                }
            }
            else
            {
                result.AppendLine($"Owner: None");
            }
            return result.ToString();    
        }

        public void Print()
        {
            Console.WriteLine(Info());
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Book(LitType litType, string name, string author, int yearPublished, string isbn, string[] genres, int pagesCount, bool colourful, decimal price)
        {
            this.LitType = litType;
            this.Name = name;
            this.Author = author;
            this.YearPublished = yearPublished;
            this.ISBN = isbn;
            this.Genres = genres;
            this.PagesCount = pagesCount;
            this.Colourful = colourful;
            this.Price = price;

        }
    }
}
