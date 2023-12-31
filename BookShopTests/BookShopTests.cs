﻿using BookShop;
using System.Net;

namespace BookShopTests
{
    [TestClass]
    public class BookShopTests
    {
        [TestMethod]
        public void Sell_Valid()
        {
            //arrange
            int initialBalance = 10000;
            Book artbook = new Book(LitType.ArtBook, "TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", new string[] { "horror", "adventure" }, 342, true, 199.99M);
            Distributor distributor = new Distributor("aboba", "amogus", "92380483084034");
            BookShop.BookShop shop = new BookShop.BookShop("aboba", "amogus", "92380483084034", 1.2M, distributor, initialBalance);
            Customer customer = new Customer("Petro");
            distributor.PublishBook(artbook);
            distributor.Sell(artbook, shop);

            //act
            shop.Sell(shop.OwnedLiterature.First(), customer);

            //assert
            Assert.IsTrue(!shop.OwnedLiterature.Contains(artbook) && customer.OwnedLiterature.Any(x => x.ISBN == artbook.ISBN) && shop.Balance == initialBalance + artbook.Price * shop.ProfitFactor);
        }

        [TestMethod]
        public void Sell_Fail()
        {
            //arrange
            int initialBalance = 10000;
            Book artbook = new Book(LitType.ArtBook, "TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", new string[] { "horror", "adventure" }, 342, true, 199.99M);
            Distributor distributor = new Distributor("aboba", "amogus", "92380483084034");
            BookShop.BookShop shop = new BookShop.BookShop("aboba", "amogus", "92380483084034", 1.2M, distributor, initialBalance);
            Customer customer = new Customer("Petro");
            distributor.PublishBook(artbook);
            distributor.Sell(artbook, shop);

            //act
            //assert
            Assert.ThrowsException<ArgumentException>(() => shop.Sell(artbook, customer));
        }

        [TestMethod]
        public void OrderBook_Success()
        {
            //arrange
            int initialBalance = 10000;
            Book artbook = new Book(LitType.ArtBook, "TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", new string[] { "horror", "adventure" }, 342, true, 199.99M);
            Distributor distributor = new Distributor("aboba", "amogus", "92380483084034");
            BookShop.BookShop shop = new BookShop.BookShop("aboba", "amogus", "92380483084034", 1.2M, distributor, initialBalance);
            distributor.PublishBook(artbook);

            //act
            bool result = shop.OrderBook(artbook, 10);

            //assert
            Assert.IsTrue(result && shop.OwnedLiterature.FindAll(X => X.ISBN == "978-3-16-148410-0").Count == 10);
        }

        [TestMethod]
        public void OrderBook_Fail()
        {
            //arrange
            int initialBalance = 1000;
            Book artbook = new Book(LitType.ArtBook, "TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", new string[] { "horror", "adventure" }, 342, true, 199.99M);
            Distributor distributor = new Distributor("aboba", "amogus", "92380483084034");
            BookShop.BookShop shop = new BookShop.BookShop("aboba", "amogus", "92380483084034", 1.2M, distributor, initialBalance);
            distributor.PublishBook(artbook);

            //act
            bool result = shop.OrderBook(artbook, 10);

            //assert
            Assert.IsFalse(result);
        }
    }
}