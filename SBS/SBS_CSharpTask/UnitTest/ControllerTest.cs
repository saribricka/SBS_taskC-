using Microsoft.VisualStudio.TestTools.UnitTesting;
using SBS_CSharpTask.Controller.Product;
using SBS_CSharpTask.Model.Product;

namespace UnitTest
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void AddSearchTest()
        {
            ItemController controller = new ItemControllerImpl();
            Item banana = new ItemImpl("p17j", "banana", 50, 0.15, ItemCategory.FRUITS);

            controller.addItem(banana);

            Item bananaCheck = controller.searchItem(banana.GetBarcode());

            Assert.IsTrue(banana.GetName().Equals(bananaCheck.GetName()));

        }

        [TestMethod]
        public void UpdateDeleteTest()
        {
            ItemController controller = new ItemControllerImpl();
            Item kiwi = new ItemImpl("lvqk", "kiwi", 20, 0.20, ItemCategory.FRUITS);

            controller.addItem(kiwi);

            kiwi = new ItemImpl("lvqk", "kiwi", 50, 0.15, ItemCategory.FRUITS);

            controller.updateItem(kiwi);

            Item kiwiCheck = controller.searchItem(kiwi.GetBarcode());

            Assert.IsTrue(kiwi.GetQuantity().Equals(kiwiCheck.GetQuantity()));
            Assert.IsTrue(kiwi.GetUnitPrice().Equals(kiwiCheck.GetUnitPrice()));

        }
    }
}