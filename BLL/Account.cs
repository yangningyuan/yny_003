/**  版本信息模板在安装目录下，可自行修改。
* Account.cs
*
* 功 能： N/A
* 类 名： Account
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/3 21:53:09   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;

using yny_003.Model;
using System.Collections;

namespace yny_003.BLL
{
	/// <summary>
	/// Account
	/// </summary>
	public partial class Account
	{
		
		public Account()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public static int GetMaxId()
		{
			return DAL.Account.GetMaxId();
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int ID)
		{
			return DAL.Account.Exists(ID);
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int  Add(yny_003.Model.Account model)
		{
			return DAL.Account.Add(model);
		}

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public static Hashtable Add(yny_003.Model.Account model, Hashtable MyHs)
        {
            return DAL.Account.Add(model, MyHs);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_003.Model.Account model)
		{
			return DAL.Account.Update(model);
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(yny_003.Model.Account model, Hashtable MyHs)
        {
            return DAL.Account.Update(model, MyHs);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
		{
			
			return DAL.Account.Delete(ID);
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteList(string IDlist )
		{
			return DAL.Account.DeleteList(IDlist );
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_003.Model.Account GetModel(int ID)
		{
			
			return DAL.Account.GetModel(ID);
		}

    

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
		{
			return DAL.Account.GetList(strWhere);
		}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.Account.GetList(Top,strWhere,filedOrder);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.Account> GetModelList(string strWhere)
		{
			DataSet ds = DAL.Account.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        public static List<Model.Account> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Account.GetList(strWhere, pageIndex, pageSize, out count);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.Account> DataTableToList(DataTable dt)
		{
			List<yny_003.Model.Account> modelList = new List<yny_003.Model.Account>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				yny_003.Model.Account model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = DAL.Account.DataRowToModel(dt.Rows[n]);
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
			return DAL.Account.GetRecordCount(strWhere);
		}
    
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

