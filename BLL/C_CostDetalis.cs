﻿/**  版本信息模板在安装目录下，可自行修改。
* C_CostDetalis.cs
*
* 功 能： N/A
* 类 名： C_CostDetalis
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/19 21:15:27   N/A    初版
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
	/// C_CostDetalis
	/// </summary>
	public  partial class C_CostDetalis
	{
		private readonly yny_003.DAL.C_CostDetalis dal=new yny_003.DAL.C_CostDetalis();
		public  C_CostDetalis()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public static int GetMaxId()
		{
			return DAL.C_CostDetalis.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int ID)
		{
			return DAL.C_CostDetalis.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(yny_003.Model.C_CostDetalis model)
		{
			return DAL.C_CostDetalis.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(yny_003.Model.C_CostDetalis model)
		{
			return DAL.C_CostDetalis.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int ID)
		{
			
			return DAL.C_CostDetalis.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string IDlist )
		{
			return DAL.C_CostDetalis.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static yny_003.Model.C_CostDetalis GetModel(int ID)
		{
			
			return DAL.C_CostDetalis.GetModel(ID);
		}

		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.C_CostDetalis.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.C_CostDetalis.GetList(Top,strWhere,filedOrder);
		}
		public static List<Model.C_CostDetalis> GetList(string strWhere, int pageIndex, int pageSize, out int count)
		{
			return DAL.C_CostDetalis.GetList(strWhere, pageIndex, pageSize, out count);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<yny_003.Model.C_CostDetalis> GetModelList(string strWhere)
		{
			DataSet ds = DAL.C_CostDetalis.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<yny_003.Model.C_CostDetalis> DataTableToList(DataTable dt)
		{
			List<yny_003.Model.C_CostDetalis> modelList = new List<yny_003.Model.C_CostDetalis>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				yny_003.Model.C_CostDetalis model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = DAL.C_CostDetalis.DataRowToModel(dt.Rows[n]);
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
			return DAL.C_CostDetalis.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return DAL.C_CostDetalis.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public static DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

