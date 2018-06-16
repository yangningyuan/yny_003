/**  版本信息模板在安装目录下，可自行修改。
* SubAccount.cs
*
* 功 能： N/A
* 类 名： SubAccount
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/16 19:14:13   N/A    初版
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
	/// SubAccount
	/// </summary>
	public partial class SubAccount
	{
		private readonly yny_003.DAL.SubAccount dal=new yny_003.DAL.SubAccount();
		public SubAccount()
		{}
        #region  BasicMethod

      

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int ID)
		{
			return DAL.SubAccount.Exists(ID);
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int  Add(yny_003.Model.SubAccount model)
		{
			return DAL.SubAccount.Add(model);
		}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Add(yny_003.Model.SubAccount model,Hashtable MyHs)
        {
            return DAL.SubAccount.Add(model,MyHs);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_003.Model.SubAccount model)
		{
			return DAL.SubAccount.Update(model);
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(yny_003.Model.SubAccount model, Hashtable MyHs)
        {
            return DAL.SubAccount.Update(model,MyHs);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
		{
			
			return DAL.SubAccount.Delete(ID);
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteList(string IDlist )
		{
			return DAL.SubAccount.DeleteList(IDlist );
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_003.Model.SubAccount GetModel(int ID)
		{
			
			return DAL.SubAccount.GetModel(ID);
		}

        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
		{
			return DAL.SubAccount.GetList(strWhere);
		}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.SubAccount.GetList(Top,strWhere,filedOrder);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.SubAccount> GetModelList(string strWhere)
		{
			DataSet ds = DAL.SubAccount.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        public static List<Model.SubAccount> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.SubAccount.GetList(strWhere, pageIndex, pageSize, out count);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.SubAccount> DataTableToList(DataTable dt)
		{
			List<yny_003.Model.SubAccount> modelList = new List<yny_003.Model.SubAccount>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				yny_003.Model.SubAccount model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = DAL.SubAccount.DataRowToModel(dt.Rows[n]);
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
			return DAL.SubAccount.GetRecordCount(strWhere);
		}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return DAL.SubAccount.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

