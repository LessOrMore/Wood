using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodModel
{
    public class MenuInfoModel
    {
        public Int64 MenuID { get; set; }
        public Int64 ParentMenuID { get;set; }
        public string MenuName{get;set;}
        public string Icon { get; set; }
        public string Url { get; set; }
        public Int64 OrderID { get; set; }

        public int Flag { get; set; }

    }
}
