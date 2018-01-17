using System;
using System.Data;
using System.Collections.Generic;
using yny_003.Model;
namespace yny_003.BLL
{
    /// <summary>
    /// FundType
    /// </summary>
    public partial class FundType
    {
        
        public FundType()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(yny_003.Model.FundType model)
        {
            return DAL.FundType.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_003.Model.FundType model)
        {
            return DAL.FundType.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {

            return DAL.FundType.Delete(ID);
        }
        public static object DeleteFundType(string IDList)
        {
            if (DAL.FundType.DeleteFundType(IDList))
                return "操作成功";
            return "操作失败";
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_003.Model.FundType GetModel(int ID)
        {

            return DAL.FundType.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.FundType.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.FundType.GetList(Top, strWhere, filedOrder);
        }
        public static List<Model.FundType> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.FundType.GetList(strWhere, pageIndex, pageSize, out count);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.FundType> GetModelList(string strWhere)
        {
            DataSet ds = DAL.FundType.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.FundType> DataTableToList(DataTable dt)
        {
            List<yny_003.Model.FundType> modelList = new List<yny_003.Model.FundType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yny_003.Model.FundType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DAL.FundType.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static int GetRecordCount(string strWhere)
        {
            return DAL.FundType.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return DAL.FundType.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return DAL.FundType.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

