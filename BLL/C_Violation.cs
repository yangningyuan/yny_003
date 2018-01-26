/**  版本信息模板在安装目录下，可自行修改。
* C_Violation.cs
*
* 功 能： N/A
* 类 名： C_Violation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/26 16:00:18   N/A    初版
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
namespace yny_003.BLL
{
	/// <summary>
	/// C_Violation
	/// </summary>
	public partial class C_Violation
	{
		
		public C_Violation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public static int GetMaxId()
		{
			return DAL.C_Violation.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int ID)
		{
			return DAL.C_Violation.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(yny_003.Model.C_Violation model)
		{
			return DAL.C_Violation.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(yny_003.Model.C_Violation model)
		{
			return DAL.C_Violation.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int ID)
		{
			
			return DAL.C_Violation.Delete(ID);
		}
	
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static yny_003.Model.C_Violation GetModel(int ID)
		{
			
			return DAL.C_Violation.GetModel(ID);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.C_Violation.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.C_Violation.GetList(Top,strWhere,filedOrder);
		}
        public static List<Model.C_Violation> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.C_Violation.GetList(strWhere, pageIndex, pageSize, out count);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_003.Model.C_Violation> GetModelList(string strWhere)
		{
			DataSet ds = DAL.C_Violation.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<yny_003.Model.C_Violation> DataTableToList(DataTable dt)
		{
			List<yny_003.Model.C_Violation> modelList = new List<yny_003.Model.C_Violation>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				yny_003.Model.C_Violation model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = DAL.C_Violation.DataRowToModel(dt.Rows[n]);
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
			return DAL.C_Violation.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return DAL.C_Violation.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public static DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return DAL.C_Violation.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

