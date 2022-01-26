using SBS_CSharpTask.Model.Product;
using SBS_CSharpTask.Model.ExternalFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBS_CSharpTask.Controller.Product
{
    public interface ItemController
    {
		/// Add an item to database.
		bool addItem(Item newItem);

		/// Search on the database a substring equal to the arg and return all the line.
		Item searchItem(string barcode);

		/// If the barcode is already in the database, it updates the item.
		/// If not, it creates a new item.
		void updateItem(Item updatedItem);

		/// Delete the item with the corresponding barcode.
		bool deleteItem(string barcode);

		/// Get the id of every item contained in the database.
		List<string> getAllId();

		/// Get quantity and all the numbers from one to argument.
		List<int> fromOneToQuantity(Item item);

		/// For the sold item, calculate unsold stocks.		 
		void recalculateQuantity(string barcode, int nSold);

		/// Show all the stock.
		List<string> showUnsold();
	}
}
