using System;
using System.Data;
using System.Collections.Generic;
using yny_003.Model;
namespace yny_003.BLL
{
    /// <summary>
    /// ObjSub
    /// </summary>
    public partial class ObjSub
    {
        
        public ObjSub()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(yny_003.Model.ObjSub model)
        {
            return DAL.ObjSub.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_003.Model.ObjSub model)
        {
            return DAL.ObjSub.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {

            return DAL.ObjSub.Delete(ID);
        }
        public static object DeleteObjSub(string IDList)
        {
            if (DAL.ObjSub.DeleteObjSub(IDList))
                return "操作成功";
            return "操作失败";
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_003.Model.ObjSub GetModel(int ID)
        {

            return DAL.ObjSub.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.ObjSub.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.ObjSub.GetList(Top, strWhere, filedOrder);
        }
        public static List<Model.ObjSub> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.ObjSub.GetList(strWhere, pageIndex, pageSize, out count);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.ObjSub> GetModelList(string strWhere)
        {
            DataSet ds = DAL.ObjSub.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.ObjSub> DataTableToList(DataTable dt)
        {
            List<yny_003.Model.ObjSub> modelList = new List<yny_003.Model.ObjSub>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yny_003.Model.ObjSub model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DAL.ObjSub.DataRowToModel(dt.Rows[n]);
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
            return DAL.ObjSub.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return DAL.ObjSub.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return DAL.ObjSub.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

