using Microsoft.VisualStudio.TestTools.UnitTesting;
using SBS_CSharpTask.Model.ExternalFile;
using SBS_CSharpTask.Model.Product;

namespace UnitTest
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void CreationTest()
        {
            Item lievito = new ItemImpl("045a", "lievito alimentare", 50, 8.50, ItemCategory.BIO);
            Item crunchy = new ItemImpl("7kw3", "cruncy veg cioccolato", 80, 4.30, ItemCategory.SNACKS);

            Assert.IsTrue(lievito.GetBarcode().Equals("045a"));
            Assert.IsTrue(crunchy.GetName().Equals("cruncy veg cioccolato"));
            Assert.IsTrue(lievito.GetCategory().Equals(ItemCategory.BIO));
            Assert.IsTrue(crunchy.GetQuantity().Equals(80));
            Assert.IsTrue(lievito.GetUnitPrice().Equals(8.50));
        }

        [TestMethod]
        public void writingTest()
        {
            FileStrategy file = new FileItemImpl();
            Assert.IsTrue(file.createFile());

            Item ammorbidente = new ItemImpl("aa89", "ammorbidente cruelty-free", 35, 7.60, ItemCategory.CLEANING);

            Assert.IsTrue(file.writeInFile(ammorbidente.ToString()));

        }
    }
}
