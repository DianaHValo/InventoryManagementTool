using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace InventoryManager
{
    class Device
    {
        public int id { get; set; }
        public string itemName { get; set; }
        public string itemModel { get; set; }
        public string itemLocation { get; set; }
        public string itemStatus { get; set; }
        public string inventoryNum { get; set; }


        public string returnAllDevices()
        {
            return null;
        }
    }
}
