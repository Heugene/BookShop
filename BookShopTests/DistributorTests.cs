using BookShop;
using System.Net;

namespace BookShopTests
{
    [TestClass]
    public class DistributorTests
    {
        [TestMethod]
        public void Sell_Valid()
        {
            //arrange
            int initialBalance = 10000;
            Book comix = new Book(LitType.Comix, "TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", new string[] { "horror", "adventure" }, 342, true, 199.99M);
            Distributor distributor = new Distributor("aboba", "amogus", "92380483084034");
            BookShop.BookShop shop = new BookShop.BookShop("aboba", "amogus", "92380483084034", 1.2M, distributor, initialBalance);
            comix.ChangeOwner(distributor);

            //act
            distributor.Sell(comix, shop);

            //assert
            Assert.IsTrue(!distributor.OwnedLiterature.Contains(comix) && shop.OwnedLiterature.Contains(comix) && shop.Balance == initialBalance - comix.Price);
        }

        [TestMethod]
        public void PublishBook_Valid()
        {
            //arrange
            Book comix = new Book(LitType.Comix, "TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", new string[] { "horror", "adventure" }, 342, true, 199.99M);
            Distributor distributor = new Distributor("aboba", "amogus", "92380483084034");

            //act
            distributor.PublishBook(comix);

            //assert
            Assert.IsTrue(distributor.OwnedLiterature.Contains(comix));
        }

        [TestMethod]
        public void RetireBook_Valid()
        {
            //arrange
            Book comix = new Book(LitType.Comix, "TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", new string[] { "horror", "adventure" }, 342, true, 199.99M);
            Distributor distributor = new Distributor("aboba", "amogus", "92380483084034");
            distributor.PublishBook(comix);

            //act
            distributor.RetireBook(comix);

            //assert
            Assert.IsFalse(distributor.OwnedLiterature.Contains(comix));
        }
    }
}