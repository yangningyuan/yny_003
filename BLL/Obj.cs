using System;
using System.Data;
using System.Collections.Generic;
using yny_003.Model;
namespace yny_003.BLL
{
    /// <summary>
    /// Obj
    /// </summary>
    public partial class Obj
    {
        
        public Obj()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(yny_003.Model.Obj model)
        {
            return DAL.Obj.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_003.Model.Obj model)
        {
            return DAL.Obj.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {

            return DAL.Obj.Delete(ID);
        }

        public static object DeleteObj(string IDList)
        {
            if (DAL.Obj.DeleteObj(IDList))
                return "操作成功";
            return "操作失败";
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_003.Model.Obj GetModel(int ID)
        {

            return DAL.Obj.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Obj.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Obj.GetList(Top, strWhere, filedOrder);
        }

        public static List<Model.Obj> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Obj.GetList(strWhere, pageIndex, pageSize, out count);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.Obj> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Obj.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.Obj> DataTableToList(DataTable dt)
        {
            List<yny_003.Model.Obj> modelList = new List<yny_003.Model.Obj>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yny_003.Model.Obj model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DAL.Obj.DataRowToModel(dt.Rows[n]);
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
            return DAL.Obj.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return DAL.Obj.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return DAL.Obj..GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

