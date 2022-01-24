using SBS_CSharpTask.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBS_CSharpTask.controller
{
    interface ItemController
    {
		/// Add an item to database.
		Boolean addItem(Item newItem);

		/// Search on the database a substring equal to the arg and return all the line.
		Item searchItem(String barcode);

		/// If the barcode is already in the database, it updates the item.
		/// If not, it creates a new item.
		void updateItem(Item updatedItem);

		/// Delete the item with the corresponding barcode.
		Boolean deleteItem(String barcode);

		/// Get the id of every item contained in the database.
		HashSet<string> getAllId();

		/// Get quantity and all the numbers from one to argument.
		HashSet<int> fromOneToQuantity(Item item);

		/// For the sold item, calculate unsold stocks.		 
		void recalculateQuantity(String barcode, int nSold);

		/// Show all the stock.
		HashSet<string> showUnsold();
	}
}
