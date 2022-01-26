using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SBS_CSharpTask.Model.Product
{
    public class ItemImpl : Item
    {
        private readonly string ATTR_SEP = ";";
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

        public string GetBarcode()
        {
            return this.barcode;
        }

        public ItemCategory GetCategory()
        {
            return this.category;
        }

        public string GetName()
        {
            return this.productName;
        }

        public int GetQuantity()
        {
            return this.quantity;
        }

        public double GetUnitPrice()
        {
            return this.unitPrice;
        }

        public string ToString()
        {
            string s = this.barcode + ATTR_SEP + this.productName + ATTR_SEP + this.quantity
                    + ATTR_SEP + this.unitPrice + ATTR_SEP + this.category;
            return s.ToLower();
        }

    }
}
