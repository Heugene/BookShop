using BookShop;

namespace BookShopTests
{
    [TestClass]
    public class ComixTests
    {
        [TestMethod]
        public void Read_Valid()
        {
            //arrange
            Comix comix = new Comix("TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", 342, true, 199.99M);

            //act
            string result = comix.Read();

            //assert
            Assert.AreEqual(result, $"Ммм, який веселий цей комікс, {comix.Name}!");
        }

        [TestMethod]
        public void ChangeOwner_Valid()
        {
            //arrange
            Comix comix = new Comix("TestTitle", "TestAuthor", 2012, "978-3-16-148410-0", 342, true, 199.99M);
            IBookOwner owner = new Distributor("test", "test", "928349283043");

            //act
            comix.ChangeOwner(owner);

            //assert
            Assert.IsTrue(comix.Owner == owner);
        }
    }
}