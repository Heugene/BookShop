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
            Comix comix = new Comix("TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", 342, true, 199.99M);
            Distributor distributor = new Distributor("aboba", "amogus", "92380483084034");
            BookShop.BookShop shop = new BookShop.BookShop("aboba", "amogus", "92380483084034", 1.2M, distributor, initialBalance);
            comix.ChangeOwner(distributor);

            //act
            distributor.Sell(comix, shop);

            //assert
            Assert.IsTrue(!distributor.OwnedLiterature.Contains(comix) && shop.OwnedLiterature.Contains(comix) && shop.Balance == initialBalance - comix.Price);
        }
    }
}