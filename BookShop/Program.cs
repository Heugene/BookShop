using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace BookShop
{
    internal class Program
    {
        static Distributor distributor = new Distributor("КнигоПринт", "Винників майдан, 49 - Євпаторія, CT / 40363", "+380965358222");
        static BookShop MyShop = new BookShop("Безодня", "Нижанківського майдан, 5 - Миколаїв, LA / 52084", "+380506618619", 1.2m, distributor, 10000);
        static bool Bankrupt = false;

        static void SetBankrupt(string msg)
        {
            if (MyShop.Balance < MyShop.Distributor.OwnedLiterature.Select(x => x.Price).Min())
            {
                Bankrupt = true;
            }
            Console.WriteLine(msg);
        }

        static void MainMenuShow()
        {
            int menuChoice = 0;

            Console.Clear();
            Console.WriteLine(
                "ГОЛОВНЕ МЕНЮ\n" +
                "1 - Перегляд інформації про магазин\n" +
                "2 - Перегляд інформації про постачальника\n" +
                "3 - Продати книгу клієнту\n" +
                "4 - Замовити партію книг у постачальника\n" +
                "5 - Постачальник: додати книгу в асортимент\n" +
                "6 - Постачальник: вилучити книгу з асортименту\n" +
                "7 - Перегляд інформації про книгу\n" +
                "0 - Вийти з програми\n" +
                "\nВведіть номер пункту меню для вибору: "
                );
            if (!Bankrupt)
            {
                if (int.TryParse(Console.ReadLine(), out menuChoice))
                {
                    switch (menuChoice)
                    {
                        case 0:
                            { Environment.Exit(0); }
                            break;
                        case 1:
                            {
                                MenuShopInfo();
                                MainMenuShow();
                            }
                            break;
                        case 2:
                            {
                                MenuDistributorInfo();
                                MainMenuShow();
                            }
                            break;
                        case 3:
                            {
                                MenuBookSell();
                                MainMenuShow();
                            }
                            break;
                        case 4:
                            {
                                MenuOrderBooks();
                                MainMenuShow();
                            }
                            break;
                        case 5:
                            {
                                MenuPublishBook();
                                MainMenuShow();
                            }
                            break;
                        case 6:
                            {
                                MenuRetireBook();
                                MainMenuShow();
                            }
                            break;
                        case 7:
                            {
                                MenuViewBookInfo();
                                MainMenuShow();
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Введіть корректний номер пункту!");
                                Console.WriteLine("Натисність будь-яку клавішу для продовження...");
                                Console.ReadKey();
                                MainMenuShow();
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введіть корректний номер пункту!");
                    Console.WriteLine("Натисність будь-яку клавішу для продовження...");
                    Console.ReadKey();
                    MainMenuShow();
                }
            }
            else
            {
                Console.WriteLine("Ваш магазин збанкрутував, ви можете тільки вийти з програми");
                Console.WriteLine("Натисність будь-яку клавішу для продовження...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public static void MenuShopInfo()
        {
            Console.Clear();
            Console.WriteLine(MyShop.Info());
            Console.WriteLine();
            Console.WriteLine("Натисність будь-яку клавішу для продовження...");
            Console.ReadKey();
            return;
        }

        public static void MenuDistributorInfo()
        {
            Console.Clear();
            Console.WriteLine(distributor.Info());
            Console.WriteLine();
            Console.WriteLine("Натисність будь-яку клавішу для продовження...");
            Console.ReadKey();
            return;
        }

        public static void MenuBookSell()
        {
            Console.Clear();
            Console.WriteLine("Введіть ПІБ клієнта");
            string customerName = Console.ReadLine();
            Console.WriteLine("Введіть назву книги чи ISBN");
            string book = Console.ReadLine();
            if (MyShop.OwnedLiterature.Any(x => x.ISBN == book || x.Name == book))
            {
                if (MyShop.Customers.Any(x => x.Name == customerName))
                {
                    MyShop.Sell(MyShop.OwnedLiterature.Where(x => x.ISBN == book || x.Name == book).First(), MyShop.Customers.Where(x => x.Name == customerName).FirstOrDefault());
                }
                else
                {
                    MyShop.Customers.Add(new Customer(customerName));
                    MyShop.Sell(MyShop.OwnedLiterature.Where(x => x.ISBN == book || x.Name == book).First(), MyShop.Customers.Where(x => x.Name == customerName).FirstOrDefault());
                }
            }
            else
            {
                Console.WriteLine("Вказану книгу не знайдено");
            }
            Console.WriteLine();
            Console.WriteLine("Натисність будь-яку клавішу для продовження...");
            Console.ReadKey();
        }

        private static void OnBookSelling(IBookOwner NewOwner, string message)
        {
            Console.WriteLine(message);
        }

        private static void OnBookSold(Book Item, string message)
        {
            Console.WriteLine(message);
        }

        public static void MenuOrderBooks()
        {
            Console.Clear();
            Console.WriteLine("Введіть назву книги чи ISBN");
            string book = Console.ReadLine();
            if (MyShop.Distributor.OwnedLiterature.Any(x => x.ISBN == book || x.Name == book))
            {
                int quantity = 0;
                Book bookOrdered = MyShop.Distributor.OwnedLiterature.Where(x => x.ISBN == book || x.Name == book).First();
                Console.WriteLine("Введіть кількість для замовлення");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                    {
                        break;
                    }
                }
                if (!MyShop.OrderBook(bookOrdered, quantity))
                {
                    Console.WriteLine("Помилка замовлення");
                }
                
            }
            else
            {
                Console.WriteLine("Вказану книгу не знайдено в асортименті постачальника");
            }
            Console.WriteLine();
            Console.WriteLine("Натисність будь-яку клавішу для продовження...");
            Console.ReadKey();
        }

        public static void MenuPublishBook()
        {
            Console.Clear();
            LitType type;
            string name;
            string author;
            int year;
            string isbn;
            List<string> genres = new List<string>();
            int pagesCount;
            bool colourful;
            decimal price;

            Console.WriteLine("Введіть тип літератури: 0 - книга, 1 - артбук, 2 - комікс");
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "0" || input == "1" || input == "2")
                {
                    type = (LitType)int.Parse(input);
                    break;
                }
            }
            input = "";

            Console.WriteLine("Введіть назву книжки");
            name = Console.ReadLine();
            Console.WriteLine("Введіть автора");
            author = Console.ReadLine();

            Console.WriteLine("Введіть рік видання");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    break;
                }
            }

            Console.WriteLine("Введіть ISBN");
            isbn = Console.ReadLine();

            Console.WriteLine("Введіть перелік жанрів, кожний жанр на новому рядку, кінець введення - 0");
            while (true)
            {
                input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                }
                else
                {
                    genres.Add(input);
                }
            }
            input = "";


            Console.WriteLine("Введіть кількість сторінок");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out pagesCount) && pagesCount > 0)
                {
                    break;
                }
            }

            int choice;
            Console.WriteLine("Чи видання кольорове? 1 - так, 0 - ні");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 0))
                {
                    if (choice == 0)
                    {
                        colourful = false;
                    }
                    else
                    {
                        colourful = true;
                    }
                    break;
                }
            }

            Console.WriteLine("Введіть ціну");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out price) && price > 0)
                {
                    break;
                }
            }

            Book newBook = new Book(type, name, author, year, isbn, genres.ToArray(), pagesCount, colourful, price);
            Console.WriteLine("Успішно була додана книга:");
            newBook.Print();
            Console.WriteLine();

            MyShop.Distributor.PublishBook(newBook);

            Console.WriteLine();
            Console.WriteLine("Натисність будь-яку клавішу для продовження...");
            Console.ReadKey();
        }

        public static void MenuRetireBook()
        {
            Console.Clear();
            Console.WriteLine("Введіть назву книги чи ISBN");
            string book = Console.ReadLine();
            if (MyShop.Distributor.OwnedLiterature.Any(x => x.ISBN == book || x.Name == book))
            {
                Book bookToRetire = MyShop.Distributor.OwnedLiterature.Where(x => x.ISBN == book || x.Name == book).First();
                if (MyShop.Distributor.RetireBook(bookToRetire))
                {
                    Console.WriteLine("Вказану книгу було знято з виробництва!");
                }
                else
                {
                    Console.WriteLine("Помилка зняття з виробництва!");
                }
            }
            else
            {
                Console.WriteLine("Вказану книгу не знайдено в асортименті постачальника");
            }

            Console.WriteLine("Натисність будь-яку клавішу для продовження...");
            Console.ReadKey();
            MainMenuShow();
        }

        public static void MenuViewBookInfo()
        {
            Console.Clear();
            Console.WriteLine("Введіть назву книги чи ISBN");
            string book = Console.ReadLine();
            Book bookToView = null;
            if (MyShop.Distributor.OwnedLiterature.Any(x => x.ISBN == book || x.Name == book))
            {
                bookToView = MyShop.Distributor.OwnedLiterature.Where(x => x.ISBN == book || x.Name == book).First();
            }
            else if (MyShop.OwnedLiterature.Any(x => x.ISBN == book || x.Name == book))
            {
                bookToView = MyShop.OwnedLiterature.Where(x => x.ISBN == book || x.Name == book).First();
            }
            else
            {
                Console.WriteLine("Вказану книгу не знайдено ні в асортименті постачальника, ні в асортименті магазину");
                Console.WriteLine("Натисність будь-яку клавішу для продовження...");
                Console.ReadKey();
                MainMenuShow();
            }
            bookToView.Print();
            Console.WriteLine("Натисність будь-яку клавішу для продовження...");
            Console.ReadKey();
            MainMenuShow();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Book testBook1 = new Book(LitType.ArtBook, "Crying Suns artbook", "Alt Shift", 2021, "978-1-9172-2147-4", new string[] { "Sci-Fi", "Adventures" }, 83, true, 299.99M);
            Book testBook2 = new Book(LitType.Book, "Warhammer 40k Horus Rising: The seeds of heresy are sown", "Dan Abnett", 2006, "978-1-84970-382-6", new string[] { "Sci-Fi", "Adventures", "Thriller",  }, 440, true, 479.99M);
            Book testBook3 = new Book(LitType.Book, "From blood and ash", "Jennifer L. Armentrout", 2023, "978-617-548-148-6", new string[] { "Fantasy", "Romance", "New Adult", "Vampires", "Fiction", "Paranormal" }, 627, true, 450);
            Book testBook4 = new Book(LitType.Book, "The love hypothesis", "Ali Hazelwood", 2021, "978-059-333-682-3", new string[] { "Fiction", "Contemporary Romance", "Adult" }, 384, false, 410);
            Book testBook5 = new Book(LitType.Book, "The Cruel Prince", "Holly Black", 2020, "978-966-982-063-1", new string[] { "Fiction", "Fantasy", "Romance", "Magic", "Adult" }, 400, false, 350);
            Book testBook6 = new Book(LitType.Comix, "Katarsis", "Tory Yumino and Lisa Cloud", 2022, "978-617-7782-31-4", new string[] { "Fiction", "Fantasy", "Romance", "Magic", "Fairy Tale" }, 248, false, 290);
            Book testBook7 = new Book(LitType.Comix, "Solo Leveling", "Chugong", 2023, "978-617-7984-41-1", new string[] { "Action" }, 350, true, 429);
            Book testBook8 = new Book(LitType.Book, "Iron Widow", "Xiran Jay Zhao", 2021, "978-073-526-993-4", new string[] { "Fiction", "Fantasy", "Romance", "Sci-Fi", "Adult", "Queer", "LGBT" }, 391, false, 620);


            MyShop.Distributor.PublishBook(testBook1);
            MyShop.Distributor.PublishBook(testBook2);
            MyShop.BooksOrdered += Console.WriteLine;
            MyShop.Bomzh += SetBankrupt;
            MyShop.Distributor.BooksProvided += Console.WriteLine;
            MyShop.BookSelling += OnBookSelling;
            MyShop.BookSold += OnBookSold;

            MainMenuShow();
            Console.WriteLine("Hello, World!");
        }
    }
}