using System;
using System.Collections.Generic;
using System.Text;

namespace SBS_CSharpTask.Model.Product
{
    public interface Item
    {
		/// Get name of selected interface object.
		string GetName();

		///Get barcode of selected item.
		string GetBarcode();


		/// Get quantity of selected item.
		int GetQuantity();

		///Get unit price of selected item.
		double GetUnitPrice();

		///Get category of selected item.
		ItemCategory GetCategory();

		/// <summary>
		/// Method called by writer to write the object on the database (in this case, a txt file)
		/// </summary> 
		string ToString();
	}	
}
