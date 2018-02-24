/**  版本信息模板在安装目录下，可自行修改。
* C_Mileage.cs
*
* 功 能： N/A
* 类 名： C_Mileage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/2/24 11:30:15   N/A    初版
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
	/// 数据访问类:C_Mileage
	/// </summary>
	public partial class C_Mileage
	{
		public C_Mileage()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public static int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "C_Mileage"); 
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Mileage");
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
        public static int Add(yny_003.Model.C_Mileage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Mileage(");
			strSql.Append("SIJI1,SIJI2,CarCode,Mileage,Oid,Type,CreateDate,Spare,Spare2,DiffCount)");
			strSql.Append(" values (");
			strSql.Append("@SIJI1,@SIJI2,@CarCode,@Mileage,@Oid,@Type,@CreateDate,@Spare,@Spare2,@DiffCount)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SIJI1", SqlDbType.VarChar,50),
					new SqlParameter("@SIJI2", SqlDbType.VarChar,50),
					new SqlParameter("@CarCode", SqlDbType.VarChar,50),
					new SqlParameter("@Mileage", SqlDbType.Int,4),
					new SqlParameter("@Oid", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Spare", SqlDbType.VarChar,50),
					new SqlParameter("@Spare2", SqlDbType.VarChar,50),new SqlParameter("@DiffCount", SqlDbType.Int,4)};
			parameters[0].Value = model.SIJI1;
			parameters[1].Value = model.SIJI2;
			parameters[2].Value = model.CarCode;
			parameters[3].Value = model.Mileage;
			parameters[4].Value = model.Oid;
			parameters[5].Value = model.Type;
			parameters[6].Value = model.CreateDate;
			parameters[7].Value = model.Spare;
			parameters[8].Value = model.Spare2;
			parameters[9].Value = model.DiffCount;

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
        public static bool Update(yny_003.Model.C_Mileage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Mileage set ");
			strSql.Append("SIJI1=@SIJI1,");
			strSql.Append("SIJI2=@SIJI2,");
			strSql.Append("CarCode=@CarCode,");
			strSql.Append("Mileage=@Mileage,");
			strSql.Append("Oid=@Oid,");
			strSql.Append("Type=@Type,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("Spare=@Spare,");
			strSql.Append("Spare2=@Spare2,");
			strSql.Append("DiffCount=@DiffCount");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@SIJI1", SqlDbType.VarChar,50),
					new SqlParameter("@SIJI2", SqlDbType.VarChar,50),
					new SqlParameter("@CarCode", SqlDbType.VarChar,50),
					new SqlParameter("@Mileage", SqlDbType.Int,4),
					new SqlParameter("@Oid", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Spare", SqlDbType.VarChar,50),
					new SqlParameter("@Spare2", SqlDbType.VarChar,50),
					new SqlParameter("@DiffCount", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.SIJI1;
			parameters[1].Value = model.SIJI2;
			parameters[2].Value = model.CarCode;
			parameters[3].Value = model.Mileage;
			parameters[4].Value = model.Oid;
			parameters[5].Value = model.Type;
			parameters[6].Value = model.CreateDate;
			parameters[7].Value = model.Spare;
			parameters[8].Value = model.Spare2;
			parameters[9].Value = model.DiffCount;
			parameters[10].Value = model.ID;

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
			strSql.Append("delete from C_Mileage ");
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
			strSql.Append("delete from C_Mileage ");
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
		public static Model.C_Mileage GetModelBywhere(string where)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 ID,SIJI1,SIJI2,CarCode,Mileage,Oid,Type,CreateDate,Spare,Spare2,DiffCount from C_Mileage ");
			strSql.Append(" where "+where);
			
			yny_003.Model.C_Mileage model = new yny_003.Model.C_Mileage();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
			if (ds.Tables[0].Rows.Count > 0)
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
		public static yny_003.Model.C_Mileage GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SIJI1,SIJI2,CarCode,Mileage,Oid,Type,CreateDate,Spare,Spare2,DiffCount from C_Mileage ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			yny_003.Model.C_Mileage model=new yny_003.Model.C_Mileage();
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
        public static yny_003.Model.C_Mileage DataRowToModel(DataRow row)
		{
			yny_003.Model.C_Mileage model=new yny_003.Model.C_Mileage();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["SIJI1"]!=null)
				{
					model.SIJI1=row["SIJI1"].ToString();
				}
				if(row["SIJI2"]!=null)
				{
					model.SIJI2=row["SIJI2"].ToString();
				}
				if(row["CarCode"]!=null)
				{
					model.CarCode=row["CarCode"].ToString();
				}
				if(row["Mileage"]!=null && row["Mileage"].ToString()!="")
				{
					model.Mileage=int.Parse(row["Mileage"].ToString());
				}
				if(row["Oid"]!=null && row["Oid"].ToString()!="")
				{
					model.Oid=int.Parse(row["Oid"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["Spare"]!=null)
				{
					model.Spare=row["Spare"].ToString();
				}
				if(row["Spare2"]!=null)
				{
					model.Spare2=row["Spare2"].ToString();
				}
				if (row["DiffCount"] != null && row["DiffCount"].ToString() != "")
				{
					model.DiffCount = int.Parse(row["DiffCount"].ToString());
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
			strSql.Append("select ID,SIJI1,SIJI2,CarCode,Mileage,Oid,Type,CreateDate,Spare,Spare2,DiffCount ");
			strSql.Append(" FROM C_Mileage ");
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
			strSql.Append(" ID,SIJI1,SIJI2,CarCode,Mileage,Oid,Type,CreateDate,Spare,Spare2,DiffCount ");
			strSql.Append(" FROM C_Mileage ");
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
			strSql.Append("select count(1) FROM C_Mileage ");
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
			strSql.Append(")AS Row, T.*  from C_Mileage T ");
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
			parameters[0].Value = "C_Mileage";
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

