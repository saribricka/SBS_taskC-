using SBS_CSharpTask.Model.Product;
using SBS_CSharpTask.Model.ExternalFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBS_CSharpTask.Controller.Product
{
    public class ItemControllerImpl : ItemController
    {

        private Item item;
        private string barcode, name;
        private int quantity;
        private double price;
        private ItemCategory category;

        private FileStrategy file = new FileItemImpl();


        public bool addItem(Item newItem)
        {
            if (!exists(newItem.GetBarcode()))
            {
                file.writeInFile(newItem.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteItem(string barcode)
        {
            if (exists(barcode))
            {
                file.deleteLine(barcode);
                return true;
            }
            return false;
        }

        public List<int> fromOneToQuantity(Item item)
        {
            List<int> qtys = new List<int>();
            int quantity = item.GetQuantity();
            for (int i = 1; i <= quantity; i++)
            {
                qtys.Add(i);
            }
            return qtys;
        }

        public List<string> getAllId()
        {
            List<string> ls = file.getAllId();
            return ls;
        }

        public void recalculateQuantity(string barcode, int nSold)
        {
            Item i = searchItem(barcode);
            int oldQty = i.GetQuantity();
            int newQty = oldQty - nSold;

            Item itemToUpdate = new ItemImpl(i.GetBarcode(), i.GetName(), newQty, i.GetUnitPrice(), i.GetCategory());
            updateItem(itemToUpdate);
        }

        public Item searchItem(string barcode)
        {
            string itemLine = file.searchInFile(barcode.ToLower());
            if (!string.IsNullOrEmpty(itemLine))
            {
                Item i = composeItem(itemLine);
                return i;
            }
            else
            {
                return null;
            }
        }

        public List<string> showUnsold()
        {
            List<string> ides = getAllId();
            List<string> rows = new List<string>();
            foreach (string id in ides)
            {
                Item i = searchItem(id);

                string barcode = i.GetBarcode();
                string name = i.GetName();
                ItemCategory cat = i.GetCategory();
                int qty = i.GetQuantity();
                double price = i.GetUnitPrice();

                string row = barcode + "\t" + name + "\t" + cat + "\t" + qty + "\t" + price + "\n";
                rows.Add(row);
            }
            return rows;
        }

        public void updateItem(Item updatedItem)
        {
            var id = updatedItem.GetBarcode();
            if (exists(id))
            {
                deleteItem(id);
            }
            addItem(updatedItem);
        }

        private Item composeItem(string itemLine)
        {
            string[] data = itemLine.Split(";");

            barcode = data[0];
            name = data[1];
            int.TryParse(data[2], out quantity);
            double.TryParse(data[3], out price);
            Enum.TryParse(data[4].ToUpper(), out category);

            item = new ItemImpl(barcode, name, quantity, price, category);

            return item;
        }

        private bool exists(string barcode)
        {
            try
            {
                string itemLine = file.searchInFile(barcode.ToLower());
                if (!string.IsNullOrEmpty(itemLine))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
