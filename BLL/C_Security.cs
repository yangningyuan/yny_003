/**  版本信息模板在安装目录下，可自行修改。
* C_Security.cs
*
* 功 能： N/A
* 类 名： C_Security
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/19 21:15:28   N/A    初版
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
	/// C_Security
	/// </summary>
	public partial class C_Security
	{
		private readonly yny_003.DAL.C_Security dal=new yny_003.DAL.C_Security();
		public C_Security()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return DAL.C_Security.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return DAL.C_Security.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(yny_003.Model.C_Security model)
		{
			return DAL.C_Security.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(yny_003.Model.C_Security model)
		{
			return DAL.C_Security.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return DAL.C_Security.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return DAL.C_Security.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public yny_003.Model.C_Security GetModel(int ID)
		{
			
			return DAL.C_Security.GetModel(ID);
		}

		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return DAL.C_Security.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.C_Security.GetList(Top,strWhere,filedOrder);
		}
		public static List<Model.C_Security> GetList(string strWhere, int pageIndex, int pageSize, out int count)
		{
			return DAL.C_Security.GetList(strWhere, pageIndex, pageSize, out count);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<yny_003.Model.C_Security> GetModelList(string strWhere)
		{
			DataSet ds = DAL.C_Security.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<yny_003.Model.C_Security> DataTableToList(DataTable dt)
		{
			List<yny_003.Model.C_Security> modelList = new List<yny_003.Model.C_Security>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				yny_003.Model.C_Security model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = DAL.C_Security.DataRowToModel(dt.Rows[n]);
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
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return DAL.C_Security.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return DAL.C_Security.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

