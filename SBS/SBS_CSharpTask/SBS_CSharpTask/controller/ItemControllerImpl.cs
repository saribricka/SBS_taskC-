using SBS_CSharpTask.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBS_CSharpTask.controller
{
    class ItemControllerImpl : ItemController
    {
        public bool addItem(Item newItem)
        {
            throw new NotImplementedException();
        }

        public bool deleteItem(string barcode)
        {
            throw new NotImplementedException();
        }

        public HashSet<int> fromOneToQuantity(Item item)
        {
            throw new NotImplementedException();
        }

        public HashSet<string> getAllId()
        {
            throw new NotImplementedException();
        }

        public void recalculateQuantity(string barcode, int nSold)
        {
            throw new NotImplementedException();
        }

        public Item searchItem(string barcode)
        {
            throw new NotImplementedException();
        }

        public HashSet<string> showUnsold()
        {
            throw new NotImplementedException();
        }

        public void updateItem(Item updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
