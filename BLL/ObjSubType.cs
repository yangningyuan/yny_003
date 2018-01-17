using System;
using System.Data;
using System.Collections.Generic;
using yny_003.Model;
namespace yny_003.BLL
{
    /// <summary>
    /// ObjSubType
    /// </summary>
    public partial class ObjSubType
    {
        
        public ObjSubType()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(yny_003.Model.ObjSubType model)
        {
            return DAL.ObjSubType.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_003.Model.ObjSubType model)
        {
            return DAL.ObjSubType.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {

            return DAL.ObjSubType.Delete(ID);
        }

        public static object DeleteObjSubType(string IDList)
        {
            if (DAL.ObjSubType.DeleteObjSubType(IDList))
                return "操作成功";
            return "操作失败";
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_003.Model.ObjSubType GetModel(int ID)
        {

            return DAL.ObjSubType.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.ObjSubType.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.ObjSubType.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.ObjSubType> GetModelList(string strWhere)
        {
            DataSet ds = DAL.ObjSubType.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public static List<Model.ObjSubType> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.ObjSubType.GetList(strWhere, pageIndex, pageSize, out count);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.ObjSubType> DataTableToList(DataTable dt)
        {
            List<yny_003.Model.ObjSubType> modelList = new List<yny_003.Model.ObjSubType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yny_003.Model.ObjSubType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DAL.ObjSubType.DataRowToModel(dt.Rows[n]);
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
            return DAL.ObjSubType.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return DAL.ObjSubType.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return DAL.ObjSubType.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

