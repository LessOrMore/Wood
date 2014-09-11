using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WoodModel;
using WoodDBUtility;
using WoodComman;

namespace WoodData
{
    public class ProductTypeData
    {
        public List<ProductTypeModel> GetTypeList(string pageWhere, string sqlWhere,ref Int32 rowCount)
        {
            string sql = string.Format(@"select TypeID,ParentTypeID,TypeName,TypeCode,TypeOrder,TypeLevel from Wood_ProductType {0} {1};",sqlWhere,pageWhere);
            sql += string.Format(@"select Count(*) from Wood_ProductType {0}",sqlWhere);
            DataSet ds = SQLiteHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 2)
                return null;

            rowCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            List<ProductTypeModel> modelList = ConvertHelper<ProductTypeModel>.ConvertToList(ds.Tables[0]);
            return modelList;
        }
    }
}
