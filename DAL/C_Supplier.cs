/**  版本信息模板在安装目录下，可自行修改。
* C_Supplier.cs
*
* 功 能： N/A
* 类 名： C_Supplier
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/19 21:15:29   N/A    初版
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
namespace yny_003.DAL
{
	/// <summary>
	/// 数据访问类:C_Supplier
	/// </summary>
	public partial class C_Supplier
	{
		public C_Supplier()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "C_Supplier"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Supplier");
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
		public int Add(yny_003.Model.C_Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Supplier(");
			strSql.Append("Type,Name,SHCode,UserCode,ZQDate,ZZValue,TelName,Tel,Address,Remark,QCMoney,OverMoney,IsDelete,CreateDate,Spare1,Spare2,Spare3)");
			strSql.Append(" values (");
			strSql.Append("@Type,@Name,@SHCode,@UserCode,@ZQDate,@ZZValue,@TelName,@Tel,@Address,@Remark,@QCMoney,@OverMoney,@IsDelete,@CreateDate,@Spare1,@Spare2,@Spare3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@SHCode", SqlDbType.VarChar,50),
					new SqlParameter("@UserCode", SqlDbType.VarChar,50),
					new SqlParameter("@ZQDate", SqlDbType.Int,4),
					new SqlParameter("@ZZValue", SqlDbType.VarChar,250),
					new SqlParameter("@TelName", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@QCMoney", SqlDbType.Decimal,9),
					new SqlParameter("@OverMoney", SqlDbType.Decimal,9),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Spare1", SqlDbType.VarChar,250),
					new SqlParameter("@Spare2", SqlDbType.VarChar,250),
					new SqlParameter("@Spare3", SqlDbType.VarChar,250)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.SHCode;
			parameters[3].Value = model.UserCode;
			parameters[4].Value = model.ZQDate;
			parameters[5].Value = model.ZZValue;
			parameters[6].Value = model.TelName;
			parameters[7].Value = model.Tel;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.Remark;
			parameters[10].Value = model.QCMoney;
			parameters[11].Value = model.OverMoney;
			parameters[12].Value = model.IsDelete;
			parameters[13].Value = model.CreateDate;
			parameters[14].Value = model.Spare1;
			parameters[15].Value = model.Spare2;
			parameters[16].Value = model.Spare3;

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
		public bool Update(yny_003.Model.C_Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Supplier set ");
			strSql.Append("Type=@Type,");
			strSql.Append("Name=@Name,");
			strSql.Append("SHCode=@SHCode,");
			strSql.Append("UserCode=@UserCode,");
			strSql.Append("ZQDate=@ZQDate,");
			strSql.Append("ZZValue=@ZZValue,");
			strSql.Append("TelName=@TelName,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Address=@Address,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("QCMoney=@QCMoney,");
			strSql.Append("OverMoney=@OverMoney,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("Spare1=@Spare1,");
			strSql.Append("Spare2=@Spare2,");
			strSql.Append("Spare3=@Spare3");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@SHCode", SqlDbType.VarChar,50),
					new SqlParameter("@UserCode", SqlDbType.VarChar,50),
					new SqlParameter("@ZQDate", SqlDbType.Int,4),
					new SqlParameter("@ZZValue", SqlDbType.VarChar,250),
					new SqlParameter("@TelName", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@QCMoney", SqlDbType.Decimal,9),
					new SqlParameter("@OverMoney", SqlDbType.Decimal,9),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Spare1", SqlDbType.VarChar,250),
					new SqlParameter("@Spare2", SqlDbType.VarChar,250),
					new SqlParameter("@Spare3", SqlDbType.VarChar,250),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.SHCode;
			parameters[3].Value = model.UserCode;
			parameters[4].Value = model.ZQDate;
			parameters[5].Value = model.ZZValue;
			parameters[6].Value = model.TelName;
			parameters[7].Value = model.Tel;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.Remark;
			parameters[10].Value = model.QCMoney;
			parameters[11].Value = model.OverMoney;
			parameters[12].Value = model.IsDelete;
			parameters[13].Value = model.CreateDate;
			parameters[14].Value = model.Spare1;
			parameters[15].Value = model.Spare2;
			parameters[16].Value = model.Spare3;
			parameters[17].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Supplier ");
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Supplier ");
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
		public yny_003.Model.C_Supplier GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Type,Name,SHCode,UserCode,ZQDate,ZZValue,TelName,Tel,Address,Remark,QCMoney,OverMoney,IsDelete,CreateDate,Spare1,Spare2,Spare3 from C_Supplier ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			yny_003.Model.C_Supplier model=new yny_003.Model.C_Supplier();
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
		/// 得到一个对象实体
		/// </summary>
		public yny_003.Model.C_Supplier DataRowToModel(DataRow row)
		{
			yny_003.Model.C_Supplier model=new yny_003.Model.C_Supplier();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["SHCode"]!=null)
				{
					model.SHCode=row["SHCode"].ToString();
				}
				if(row["UserCode"]!=null)
				{
					model.UserCode=row["UserCode"].ToString();
				}
				if(row["ZQDate"]!=null && row["ZQDate"].ToString()!="")
				{
					model.ZQDate=int.Parse(row["ZQDate"].ToString());
				}
				if(row["ZZValue"]!=null)
				{
					model.ZZValue=row["ZZValue"].ToString();
				}
				if(row["TelName"]!=null)
				{
					model.TelName=row["TelName"].ToString();
				}
				if(row["Tel"]!=null)
				{
					model.Tel=row["Tel"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["QCMoney"]!=null && row["QCMoney"].ToString()!="")
				{
					model.QCMoney=decimal.Parse(row["QCMoney"].ToString());
				}
				if(row["OverMoney"]!=null && row["OverMoney"].ToString()!="")
				{
					model.OverMoney=decimal.Parse(row["OverMoney"].ToString());
				}
				if(row["IsDelete"]!=null && row["IsDelete"].ToString()!="")
				{
					model.IsDelete=int.Parse(row["IsDelete"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["Spare1"]!=null)
				{
					model.Spare1=row["Spare1"].ToString();
				}
				if(row["Spare2"]!=null)
				{
					model.Spare2=row["Spare2"].ToString();
				}
				if(row["Spare3"]!=null)
				{
					model.Spare3=row["Spare3"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Type,Name,SHCode,UserCode,ZQDate,ZZValue,TelName,Tel,Address,Remark,QCMoney,OverMoney,IsDelete,CreateDate,Spare1,Spare2,Spare3 ");
			strSql.Append(" FROM C_Supplier ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,Type,Name,SHCode,UserCode,ZQDate,ZZValue,TelName,Tel,Address,Remark,QCMoney,OverMoney,IsDelete,CreateDate,Spare1,Spare2,Spare3 ");
			strSql.Append(" FROM C_Supplier ");
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
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM C_Supplier ");
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
			strSql.Append(")AS Row, T.*  from C_Supplier T ");
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
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
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
			parameters[0].Value = "C_Supplier";
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

