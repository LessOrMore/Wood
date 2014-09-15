using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodModel
{
    public class ProductTypeModel
    {
        public Int64 TypeID { get; set; }
        public Int64 ParentTypeID { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public Int64 TypeOrder { get; set; }
        public Int64 TypeLevel { get; set; }
        public Int64 Flag { get; set; }
        public string ErrMsg { get; set; }
    }
}
