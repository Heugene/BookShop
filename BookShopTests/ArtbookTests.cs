using BookShop;

namespace BookShopTests
{
    [TestClass]
    public class ArtbookTests
    {
        [TestMethod]
        public void Read_Valid()
        {
            //arrange
            Artbook artbook = new Artbook("TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", 342, true, 199.99M);

            //act
            string result = artbook.Read();

            //assert
            Assert.AreEqual(result, $"Ммм, який гарний цей артбук, {artbook.Name}!");
        }

        [TestMethod]
        public void ChangeOwner_Valid()
        {
            //arrange
            Artbook artbook = new Artbook("TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", 342, true, 199.99M);
            IBookOwner owner = new Distributor("test", "test", "928349283043");

            //act
            artbook.ChangeOwner(owner);

            //assert
            Assert.IsTrue(artbook.Owner == owner);
        }
    }
}