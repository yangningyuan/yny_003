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
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Collections.Generic;
using System.Collections;

namespace yny_003.DAL
{
	/// <summary>
	/// 数据访问类:Account
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
		return DbHelperSQL.GetMaxID("ID", "Account"); 
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Account");
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
        public static int Add(yny_003.Model.Account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Account(");
			strSql.Append("CID,CName,AType,SupplierID,SupplierName,TotalMoney,ReMoney,CreateDate,AStutas,Spare,Spare2,Spare3,comDate)");
			strSql.Append(" values (");
			strSql.Append("@CID,@CName,@AType,@SupplierID,@SupplierName,@TotalMoney,@ReMoney,@CreateDate,@AStutas,@Spare,@Spare2,@Spare3,@comDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@AType", SqlDbType.Int,4),
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@SupplierName", SqlDbType.VarChar,250),
					new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@ReMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@AStutas", SqlDbType.Int,4),
					new SqlParameter("@Spare", SqlDbType.VarChar,50),
					new SqlParameter("@Spare2", SqlDbType.VarChar,50),
					new SqlParameter("@Spare3", SqlDbType.Int,4),
					new SqlParameter("@comDate", SqlDbType.DateTime)};
			parameters[0].Value = model.CID;
			parameters[1].Value = model.CName;
			parameters[2].Value = model.AType;
			parameters[3].Value = model.SupplierID;
			parameters[4].Value = model.SupplierName;
			parameters[5].Value = model.TotalMoney;
			parameters[6].Value = model.ReMoney;
			parameters[7].Value = model.CreateDate;
			parameters[8].Value = model.AStutas;
			parameters[9].Value = model.Spare;
			parameters[10].Value = model.Spare2;
			parameters[11].Value = model.Spare3;
			parameters[12].Value = model.comDate;

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
        /// 增加一条数据
        /// </summary>
        public static Hashtable Add(yny_003.Model.Account model,Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Account(");
            strSql.Append("CID,CName,AType,SupplierID,SupplierName,TotalMoney,ReMoney,CreateDate,AStutas,Spare,Spare2,Spare3,comDate)");
            strSql.Append(" values (");
            strSql.Append("@CID,@CName,@AType,@SupplierID,@SupplierName,@TotalMoney,@ReMoney,@CreateDate,@AStutas,@Spare,@Spare2,@Spare3,@comDate)");
            strSql.AppendFormat(" ;select '{0}'", guid);
            SqlParameter[] parameters = {
                    new SqlParameter("@CID", SqlDbType.Int,4),
                    new SqlParameter("@CName", SqlDbType.VarChar,50),
                    new SqlParameter("@AType", SqlDbType.Int,4),
                    new SqlParameter("@SupplierID", SqlDbType.Int,4),
                    new SqlParameter("@SupplierName", SqlDbType.VarChar,250),
                    new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@ReMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@AStutas", SqlDbType.Int,4),
                    new SqlParameter("@Spare", SqlDbType.VarChar,50),
                    new SqlParameter("@Spare2", SqlDbType.VarChar,50),
                    new SqlParameter("@Spare3", SqlDbType.Int,4),
                    new SqlParameter("@comDate", SqlDbType.DateTime)};
            parameters[0].Value = model.CID;
            parameters[1].Value = model.CName;
            parameters[2].Value = model.AType;
            parameters[3].Value = model.SupplierID;
            parameters[4].Value = model.SupplierName;
            parameters[5].Value = model.TotalMoney;
            parameters[6].Value = model.ReMoney;
            parameters[7].Value = model.CreateDate;
            parameters[8].Value = model.AStutas;
            parameters[9].Value = model.Spare;
            parameters[10].Value = model.Spare2;
            parameters[11].Value = model.Spare3;
            parameters[12].Value = model.comDate;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_003.Model.Account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Account set ");
			strSql.Append("CID=@CID,");
			strSql.Append("CName=@CName,");
			strSql.Append("AType=@AType,");
			strSql.Append("SupplierID=@SupplierID,");
			strSql.Append("SupplierName=@SupplierName,");
			strSql.Append("TotalMoney=@TotalMoney,");
			strSql.Append("ReMoney=@ReMoney,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("AStutas=@AStutas,");
			strSql.Append("Spare=@Spare,");
			strSql.Append("Spare2=@Spare2,");
			strSql.Append("Spare3=@Spare3,");
			strSql.Append("comDate=@comDate");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@AType", SqlDbType.Int,4),
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@SupplierName", SqlDbType.VarChar,250),
					new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@ReMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@AStutas", SqlDbType.Int,4),
					new SqlParameter("@Spare", SqlDbType.VarChar,50),
					new SqlParameter("@Spare2", SqlDbType.VarChar,50),
					new SqlParameter("@Spare3", SqlDbType.Int,4),
					new SqlParameter("@comDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.CID;
			parameters[1].Value = model.CName;
			parameters[2].Value = model.AType;
			parameters[3].Value = model.SupplierID;
			parameters[4].Value = model.SupplierName;
			parameters[5].Value = model.TotalMoney;
			parameters[6].Value = model.ReMoney;
			parameters[7].Value = model.CreateDate;
			parameters[8].Value = model.AStutas;
			parameters[9].Value = model.Spare;
			parameters[10].Value = model.Spare2;
			parameters[11].Value = model.Spare3;
			parameters[12].Value = model.comDate;
			parameters[13].Value = model.ID;

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
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(yny_003.Model.Account model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Account set ");
            strSql.Append("CID=@CID,");
            strSql.Append("CName=@CName,");
            strSql.Append("AType=@AType,");
            strSql.Append("SupplierID=@SupplierID,");
            strSql.Append("SupplierName=@SupplierName,");
            strSql.Append("TotalMoney=@TotalMoney,");
            strSql.Append("ReMoney=@ReMoney,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("AStutas=@AStutas,");
            strSql.Append("Spare=@Spare,");
            strSql.Append("Spare2=@Spare2,");
            strSql.Append("Spare3=@Spare3,");
            strSql.Append("comDate=@comDate");
            strSql.Append(" where ID=@ID");
            strSql.AppendFormat(" ;select '{0}'", guid);
            SqlParameter[] parameters = {
                    new SqlParameter("@CID", SqlDbType.Int,4),
                    new SqlParameter("@CName", SqlDbType.VarChar,50),
                    new SqlParameter("@AType", SqlDbType.Int,4),
                    new SqlParameter("@SupplierID", SqlDbType.Int,4),
                    new SqlParameter("@SupplierName", SqlDbType.VarChar,250),
                    new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@ReMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@AStutas", SqlDbType.Int,4),
                    new SqlParameter("@Spare", SqlDbType.VarChar,50),
                    new SqlParameter("@Spare2", SqlDbType.VarChar,50),
                    new SqlParameter("@Spare3", SqlDbType.Int,4),
                    new SqlParameter("@comDate", SqlDbType.DateTime),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CID;
            parameters[1].Value = model.CName;
            parameters[2].Value = model.AType;
            parameters[3].Value = model.SupplierID;
            parameters[4].Value = model.SupplierName;
            parameters[5].Value = model.TotalMoney;
            parameters[6].Value = model.ReMoney;
            parameters[7].Value = model.CreateDate;
            parameters[8].Value = model.AStutas;
            parameters[9].Value = model.Spare;
            parameters[10].Value = model.Spare2;
            parameters[11].Value = model.Spare3;
            parameters[12].Value = model.comDate;
            parameters[13].Value = model.ID;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Account ");
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
			strSql.Append("delete from Account ");
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
        public static yny_003.Model.Account GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CID,CName,AType,SupplierID,SupplierName,TotalMoney,ReMoney,CreateDate,AStutas,Spare,Spare2,Spare3,comDate from Account ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			yny_003.Model.Account model=new yny_003.Model.Account();
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
        public static yny_003.Model.Account GetModelName(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CID,CName,AType,SupplierID,SupplierName,TotalMoney,ReMoney,CreateDate,AStutas,Spare,Spare2,Spare3,comDate from Account ");
            strSql.Append(" where CName=@CName");
            SqlParameter[] parameters = {
                    new SqlParameter("@CName", SqlDbType.VarChar,50)
            };
            parameters[0].Value = ID;

            yny_003.Model.Account model = new yny_003.Model.Account();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        public static yny_003.Model.Account DataRowToModel(DataRow row)
		{
			yny_003.Model.Account model=new yny_003.Model.Account();
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
				if(row["CName"]!=null)
				{
					model.CName=row["CName"].ToString();
				}
				if(row["AType"]!=null && row["AType"].ToString()!="")
				{
					model.AType=int.Parse(row["AType"].ToString());
				}
				if(row["SupplierID"]!=null && row["SupplierID"].ToString()!="")
				{
					model.SupplierID=int.Parse(row["SupplierID"].ToString());
				}
				if(row["SupplierName"]!=null)
				{
					model.SupplierName=row["SupplierName"].ToString();
				}
				if(row["TotalMoney"]!=null && row["TotalMoney"].ToString()!="")
				{
					model.TotalMoney=decimal.Parse(row["TotalMoney"].ToString());
				}
				if(row["ReMoney"]!=null && row["ReMoney"].ToString()!="")
				{
					model.ReMoney=decimal.Parse(row["ReMoney"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["AStutas"]!=null && row["AStutas"].ToString()!="")
				{
					model.AStutas=int.Parse(row["AStutas"].ToString());
				}
				if(row["Spare"]!=null)
				{
					model.Spare=row["Spare"].ToString();
				}
				if(row["Spare2"]!=null)
				{
					model.Spare2=row["Spare2"].ToString();
				}
				if(row["Spare3"]!=null && row["Spare3"].ToString()!="")
				{
					model.Spare3=int.Parse(row["Spare3"].ToString());
				}
				if(row["comDate"]!=null && row["comDate"].ToString()!="")
				{
					model.comDate=DateTime.Parse(row["comDate"].ToString());
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
			strSql.Append("select ID,CID,CName,AType,SupplierID,SupplierName,TotalMoney,ReMoney,CreateDate,AStutas,Spare,Spare2,Spare3,comDate ");
			strSql.Append(" FROM Account ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.CommonBase.GetTable("Account", "ID", "ID desc", strWhere, pageIndex, pageSize, out count);
        }
        public static List<Model.Account> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Account> list = new List<Model.Account>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
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
			strSql.Append(" ID,CID,CName,AType,SupplierID,SupplierName,TotalMoney,ReMoney,CreateDate,AStutas,Spare,Spare2,Spare3,comDate ");
			strSql.Append(" FROM Account ");
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
			strSql.Append("select count(1) FROM Account ");
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
			strSql.Append(")AS Row, T.*  from Account T ");
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
			parameters[0].Value = "Account";
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

