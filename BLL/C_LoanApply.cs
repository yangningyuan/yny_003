/**  版本信息模板在安装目录下，可自行修改。
* C_LoanApply.cs
*
* 功 能： N/A
* 类 名： C_LoanApply
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
	/// C_LoanApply
	/// </summary>
	public partial class C_LoanApply
	{
		private readonly yny_003.DAL.C_LoanApply dal=new yny_003.DAL.C_LoanApply();
		public C_LoanApply()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return DAL.C_LoanApply.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return DAL.C_LoanApply.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(yny_003.Model.C_LoanApply model)
		{
			return DAL.C_LoanApply.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(yny_003.Model.C_LoanApply model)
		{
			return DAL.C_LoanApply.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return DAL.C_LoanApply.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return DAL.C_LoanApply.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public yny_003.Model.C_LoanApply GetModel(int ID)
		{
			
			return DAL.C_LoanApply.GetModel(ID);
		}

		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return DAL.C_LoanApply.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.C_LoanApply.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<yny_003.Model.C_LoanApply> GetModelList(string strWhere)
		{
			DataSet ds = DAL.C_LoanApply.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<yny_003.Model.C_LoanApply> DataTableToList(DataTable dt)
		{
			List<yny_003.Model.C_LoanApply> modelList = new List<yny_003.Model.C_LoanApply>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				yny_003.Model.C_LoanApply model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = DAL.C_LoanApply.DataRowToModel(dt.Rows[n]);
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
			return DAL.C_LoanApply.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return DAL.C_LoanApply.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

