using BookShop;

namespace BookShopTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void ChangeOwner_Valid()
        {
            //arrange
            Book book = new Book(LitType.Book, "TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", new string[] { "horror", "adventure" }, 342, true, 199.99M);
            IBookOwner owner = new Distributor("test", "test", "928349283043");

            //act
            book.ChangeOwner(owner);

            //assert
            Assert.IsTrue(book.Owner == owner);
        }
    }
}