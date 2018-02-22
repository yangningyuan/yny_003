/**  版本信息模板在安装目录下，可自行修改。
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
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
using System.Collections.Generic;

namespace yny_003.DAL
{
	/// <summary>
	/// 数据访问类:C_CostDetalis
	/// </summary>
	public  partial class C_CostDetalis
	{
		public  C_CostDetalis()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public static int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "C_CostDetalis"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_CostDetalis");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(yny_003.Model.C_CostDetalis model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_CostDetalis(");
			strSql.Append("CID,CostMoney,CostImgUrl,CareteDate,IsDelete,MID,Remark)");
			strSql.Append(" values (");
			strSql.Append("@CID,@CostMoney,@CostImgUrl,@CareteDate,@IsDelete,@MID,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4),
					new SqlParameter("@CostMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CostImgUrl", SqlDbType.VarChar,150),
					new SqlParameter("@CareteDate", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@MID", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50)
					};
			parameters[0].Value = model.CID;
			parameters[1].Value = model.CostMoney;
			parameters[2].Value = model.CostImgUrl;
			parameters[3].Value = model.CareteDate;
			parameters[4].Value = model.IsDelete;
			parameters[5].Value = model.MID;
			parameters[6].Value = model.Remark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(yny_003.Model.C_CostDetalis model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_CostDetalis set ");
			strSql.Append("CID=@CID,");
			strSql.Append("CostMoney=@CostMoney,");
			strSql.Append("CostImgUrl=@CostImgUrl,");
			strSql.Append("CareteDate=@CareteDate,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("MID=@MID,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4),
					new SqlParameter("@CostMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CostImgUrl", SqlDbType.VarChar,150),
					new SqlParameter("@CareteDate", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@MID", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.CID;
			parameters[1].Value = model.CostMoney;
			parameters[2].Value = model.CostImgUrl;
			parameters[3].Value = model.CareteDate;
			parameters[4].Value = model.IsDelete;
			parameters[5].Value = model.MID;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_CostDetalis ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public static bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_CostDetalis ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static yny_003.Model.C_CostDetalis GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CID,CostMoney,CostImgUrl,CareteDate,IsDelete,MID,Remark from C_CostDetalis ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			yny_003.Model.C_CostDetalis model=new yny_003.Model.C_CostDetalis();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
		{
			return DAL.CommonBase.GetTable("C_CostDetalis", "ID", "ID asc", strWhere, pageIndex, pageSize, out count);
		}
		public static List<Model.C_CostDetalis> GetList(string strWhere, int pageIndex, int pageSize, out int count)
		{
			List<Model.C_CostDetalis> list = new List<Model.C_CostDetalis>();

			DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
			for (int i = 0; i < table.Rows.Count; i++)
			{
				list.Add(DataRowToModel(table.Rows[i]));
			}

			return list;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static yny_003.Model.C_CostDetalis DataRowToModel(DataRow row)
		{
			yny_003.Model.C_CostDetalis model=new yny_003.Model.C_CostDetalis();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["CID"]!=null && row["CID"].ToString()!="")
				{
					model.CID=int.Parse(row["CID"].ToString());
				}
				if(row["CostMoney"]!=null && row["CostMoney"].ToString()!="")
				{
					model.CostMoney=decimal.Parse(row["CostMoney"].ToString());
				}
				if(row["CostImgUrl"]!=null)
				{
					model.CostImgUrl=row["CostImgUrl"].ToString();
				}
				if(row["CareteDate"]!=null && row["CareteDate"].ToString()!="")
				{
					model.CareteDate=DateTime.Parse(row["CareteDate"].ToString());
				}
				if(row["IsDelete"]!=null && row["IsDelete"].ToString()!="")
				{
					model.IsDelete=int.Parse(row["IsDelete"].ToString());
				}
				if (row["MID"] != null)
				{
					model.MID = row["MID"].ToString();
				}
				if (row["Remark"] != null)
				{
					model.Remark = row["Remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,CID,CostMoney,CostImgUrl,CareteDate,IsDelete,MID,Remark ");
			strSql.Append(" FROM C_CostDetalis ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,CID,CostMoney,CostImgUrl,CareteDate,IsDelete,MID,Remark ");
			strSql.Append(" FROM C_CostDetalis ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public static int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_CostDetalis ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from C_CostDetalis T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public static DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "C_CostDetalis";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

