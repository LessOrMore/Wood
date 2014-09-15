using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodData;

namespace WoodBuss
{
    public class ProductTypeBuss
    {
        ProductTypeData dal = DataFactory.Instance.ProductTypeData;
        public List<WoodModel.ProductTypeModel> GetTypeList(Dictionary<string, string> param, ref int rowCount, ref string errMsg)
        {
            try
            {
                string sqlWhere = string.Empty;
                string pageWhere = string.Empty;
                CreateWhere(ref sqlWhere, ref pageWhere, param);
                return dal.GetTypeList(pageWhere, sqlWhere, ref rowCount);
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return null;
            }
        }

        private void CreateWhere(ref string sqlWhere, ref string pageWhere, Dictionary<string, string> whereParam)
        {
            if (whereParam == null || whereParam.Count < 1)
            {
                return;
            }

            int endRow = 0;
            int startRow = 0;
            sqlWhere = "where 1=1";
            foreach (KeyValuePair<string, string> param in whereParam)
            {
                if (param.Key == "StartRows")
                {
                    startRow = Convert.ToInt32(param.Value);
                }
                else if (param.Key == "EndRows")
                {
                    endRow = Convert.ToInt32(param.Value);
                }
                else
                {
                    sqlWhere += String.Format(" and {0} like '%{1}%'", param.Key, param.Value);
                }
            }
            pageWhere = string.Format(" limit {0} offset {1}",endRow-startRow,startRow);
        }

        public List<WoodModel.ProductTypeModel> GetTypeList(string parentTypeID, ref string errMsg)
        {
            try
            {
                return dal.GetTypeList(parentTypeID);
            }
            catch (Exception e) 
            {
                errMsg = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 添加产品类别
        /// </summary>
        /// <param name="typeModel"></param>
        /// <param name="errMsg"></param>
        public void AddProductType(WoodModel.ProductTypeModel typeModel, ref string errMsg)
        {
            try
            {
                dal.AddProductType(typeModel);
            }
            catch(Exception e)
            {
                errMsg = e.Message;
            }
        }
        /// <summary>
        /// 编辑产品类别
        /// </summary>
        /// <param name="typeModel"></param>
        /// <param name="errMsg"></param>
        public void EidtProductType(WoodModel.ProductTypeModel typeModel, ref string errMsg)
        {
            try
            {
                dal.EditProductType(typeModel);
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
        }
    }
}
