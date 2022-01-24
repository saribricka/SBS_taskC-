using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SBS_CSharpTask.model
{
    class ItemImpl : Item
    {

        //private static char ATTR_SEP = File;
        private string barcode;
        private string productName;
        private int quantity;
        private double unitPrice;
        private ItemCategory category;

        public ItemImpl(string barcode, string productName, int quantity, double unitPrice, ItemCategory category)
        {
            this.barcode = barcode;
            this.productName = productName;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
            this.category = category;
        }

        public string getBarcode()
        {
            return this.barcode;
        }

        public ItemCategory getCategory()
        {
            return this.category;
        }

        public string getName()
        {
            return this.productName;
        }

        public int getQuantity()
        {
            return this.quantity;
        }

        public double getUnitPrice()
        {
            return this.unitPrice;
        }
    }
}
