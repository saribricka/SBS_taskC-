using System;
using System.Collections.Generic;
using System.Text;

namespace SBS_CSharpTask.model
{
    interface Item
    {
		/// Get name of selected interface object.
		string getName();

		///Get barcode of selected item.
		string getBarcode();


		/// Get quantity of selected item.
		int getQuantity();

		///Get unit price of selected item.
		double getUnitPrice();

		///Get category of selected item.
		ItemCategory getCategory();
	}

	enum ItemCategory
    {
		BIO,
		VEGETABLES,
		FRUITS,
		CANNING,
		SAUCE,
		SNACKS,
		BAKERY,
		CLEANING,
		BEVERAGE,
		SPICE,
		GRAIN,
		DIARY
	}
}
