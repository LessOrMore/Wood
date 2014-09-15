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

        public List<ProductTypeModel> GetTypeList(string parentTypeID)
        {
            string sql = "select TypeID,ParentTypeID,TypeName,TypeCode,TypeOrder,TypeLevel from Wood_ProductType where parentTypeID ='"+parentTypeID+"'";
            DataSet ds = SQLiteHelper.Query(sql);
            if(ds==null || ds.Tables.Count<1){return null;}
            List<ProductTypeModel> modelList = ConvertHelper<ProductTypeModel>.ConvertToList(ds.Tables[0]);
            return modelList;
        }

        public void AddProductType(ProductTypeModel typeModel)
        {
            string sql = string.Format(@"insert into Wood_ProductType (ParentTypeID,TypeName,TypeCode,TypeOrder,TypeLevel) values ({0},'{1}','{2}',{3},{4})
            ",typeModel.ParentTypeID,typeModel.TypeName,typeModel.TypeCode,typeModel.TypeOrder,typeModel.TypeLevel);
            SQLiteHelper.ExecuteSql(sql);
        }

        public void EditProductType(ProductTypeModel typeModel)
        {
            string sql = string.Format(@"update Wood_ProductType set ParentTypeID={0},TypeName='{1}',
                TypeCode='{2}',TypeOrder={3},TypeLevel={4} where TypeID = {5}",typeModel.ParentTypeID,typeModel.TypeName,typeModel.TypeCode
                                                                              ,typeModel.TypeOrder,typeModel.TypeLevel);
            SQLiteHelper.ExecuteSql(sql);
        }
    }
}
