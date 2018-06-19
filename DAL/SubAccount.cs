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
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Collections;
using System.Collections.Generic;

namespace yny_003.DAL
{
	/// <summary>
	/// 数据访问类:SubAccount
	/// </summary>
	public partial class SubAccount
	{
		public SubAccount()
		{}
		#region  BasicMethod

		
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SubAccount");
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
        public static int Add(yny_003.Model.SubAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SubAccount(");
			strSql.Append("ACode,PayMoney,SuppID,SuppName,SuppType,JZType,UserName,BankName,BankCard,Spare,Spare2,Balance)");
			strSql.Append(" values (");
			strSql.Append("@ACode,@PayMoney,@SuppID,@SuppName,@SuppType,@JZType,@UserName,@BankName,@BankCard,@Spare,@Spare2,@Balance)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ACode", SqlDbType.VarChar,50),
					new SqlParameter("@PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SuppID", SqlDbType.Int,4),
					new SqlParameter("@SuppName", SqlDbType.VarChar,50),
					new SqlParameter("@SuppType", SqlDbType.Int,4),
					new SqlParameter("@JZType", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankCard", SqlDbType.VarChar,50),
					new SqlParameter("@Spare", SqlDbType.VarChar,50),
					new SqlParameter("@Spare2", SqlDbType.VarChar,50),
            new SqlParameter("@Balance", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ACode;
			parameters[1].Value = model.PayMoney;
			parameters[2].Value = model.SuppID;
			parameters[3].Value = model.SuppName;
			parameters[4].Value = model.SuppType;
			parameters[5].Value = model.JZType;
			parameters[6].Value = model.UserName;
			parameters[7].Value = model.BankName;
			parameters[8].Value = model.BankCard;
			parameters[9].Value = model.Spare;
			parameters[10].Value = model.Spare2;
            parameters[11].Value = model.Balance;

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
        public static Hashtable Add(yny_003.Model.SubAccount model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SubAccount(");
            strSql.Append("ACode,PayMoney,SuppID,SuppName,SuppType,JZType,UserName,BankName,BankCard,Spare,Spare2,Balance)");
            strSql.Append(" values (");
            strSql.Append("@ACode,@PayMoney,@SuppID,@SuppName,@SuppType,@JZType,@UserName,@BankName,@BankCard,@Spare,@Spare2,@Balance)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ACode", SqlDbType.VarChar,50),
                    new SqlParameter("@PayMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@SuppID", SqlDbType.Int,4),
                    new SqlParameter("@SuppName", SqlDbType.VarChar,50),
                    new SqlParameter("@SuppType", SqlDbType.Int,4),
                    new SqlParameter("@JZType", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@BankName", SqlDbType.VarChar,50),
                    new SqlParameter("@BankCard", SqlDbType.VarChar,50),
                    new SqlParameter("@Spare", SqlDbType.VarChar,50),
                    new SqlParameter("@Spare2", SqlDbType.VarChar,50),new SqlParameter("@Balance", SqlDbType.Decimal,9)};
            parameters[0].Value = model.ACode;
            parameters[1].Value = model.PayMoney;
            parameters[2].Value = model.SuppID;
            parameters[3].Value = model.SuppName;
            parameters[4].Value = model.SuppType;
            parameters[5].Value = model.JZType;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.BankName;
            parameters[8].Value = model.BankCard;
            parameters[9].Value = model.Spare;
            parameters[10].Value = model.Spare2;
            parameters[11].Value = model.Balance;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_003.Model.SubAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SubAccount set ");
			strSql.Append("ACode=@ACode,");
			strSql.Append("PayMoney=@PayMoney,");
			strSql.Append("SuppID=@SuppID,");
			strSql.Append("SuppName=@SuppName,");
			strSql.Append("SuppType=@SuppType,");
			strSql.Append("JZType=@JZType,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("BankName=@BankName,");
			strSql.Append("BankCard=@BankCard,");
			strSql.Append("Spare=@Spare,");
			strSql.Append("Spare2=@Spare2,");
            strSql.Append("Balance=@Balance");
            strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ACode", SqlDbType.VarChar,50),
					new SqlParameter("@PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SuppID", SqlDbType.Int,4),
					new SqlParameter("@SuppName", SqlDbType.VarChar,50),
					new SqlParameter("@SuppType", SqlDbType.Int,4),
					new SqlParameter("@JZType", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankCard", SqlDbType.VarChar,50),
					new SqlParameter("@Spare", SqlDbType.VarChar,50),
					new SqlParameter("@Spare2", SqlDbType.VarChar,50),
                    new SqlParameter("@Balance", SqlDbType.Decimal,9),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ACode;
			parameters[1].Value = model.PayMoney;
			parameters[2].Value = model.SuppID;
			parameters[3].Value = model.SuppName;
			parameters[4].Value = model.SuppType;
			parameters[5].Value = model.JZType;
			parameters[6].Value = model.UserName;
			parameters[7].Value = model.BankName;
			parameters[8].Value = model.BankCard;
			parameters[9].Value = model.Spare;
			parameters[10].Value = model.Spare2;
            parameters[11].Value = model.Balance;
            parameters[12].Value = model.ID;

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
        public static Hashtable Update(yny_003.Model.SubAccount model,Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SubAccount set ");
            strSql.Append("ACode=@ACode,");
            strSql.Append("PayMoney=@PayMoney,");
            strSql.Append("SuppID=@SuppID,");
            strSql.Append("SuppName=@SuppName,");
            strSql.Append("SuppType=@SuppType,");
            strSql.Append("JZType=@JZType,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankCard=@BankCard,");
            strSql.Append("Spare=@Spare,");
            strSql.Append("Spare2=@Spare2,");
            strSql.Append("Balance=@Balance");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ACode", SqlDbType.VarChar,50),
                    new SqlParameter("@PayMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@SuppID", SqlDbType.Int,4),
                    new SqlParameter("@SuppName", SqlDbType.VarChar,50),
                    new SqlParameter("@SuppType", SqlDbType.Int,4),
                    new SqlParameter("@JZType", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@BankName", SqlDbType.VarChar,50),
                    new SqlParameter("@BankCard", SqlDbType.VarChar,50),
                    new SqlParameter("@Spare", SqlDbType.VarChar,50),
                    new SqlParameter("@Spare2", SqlDbType.VarChar,50),
                     new SqlParameter("@Balance", SqlDbType.Decimal,9),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ACode;
            parameters[1].Value = model.PayMoney;
            parameters[2].Value = model.SuppID;
            parameters[3].Value = model.SuppName;
            parameters[4].Value = model.SuppType;
            parameters[5].Value = model.JZType;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.BankName;
            parameters[8].Value = model.BankCard;
            parameters[9].Value = model.Spare;
            parameters[10].Value = model.Spare2;
            parameters[11].Value = model.Balance;
            parameters[12].Value = model.ID;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SubAccount ");
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
			strSql.Append("delete from SubAccount ");
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
        public static yny_003.Model.SubAccount GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ACode,PayMoney,SuppID,SuppName,SuppType,JZType,UserName,BankName,BankCard,Spare,Spare2,CreateDate,Balance from SubAccount ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			yny_003.Model.SubAccount model=new yny_003.Model.SubAccount();
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
        public static yny_003.Model.SubAccount DataRowToModel(DataRow row)
		{
			yny_003.Model.SubAccount model=new yny_003.Model.SubAccount();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ACode"]!=null)
				{
					model.ACode=row["ACode"].ToString();
				}
				if(row["PayMoney"]!=null && row["PayMoney"].ToString()!="")
				{
					model.PayMoney=decimal.Parse(row["PayMoney"].ToString());
				}
                if (row["Balance"] != null && row["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(row["Balance"].ToString());
                }
                if (row["SuppID"]!=null && row["SuppID"].ToString()!="")
				{
					model.SuppID=int.Parse(row["SuppID"].ToString());
				}
				if(row["SuppName"]!=null)
				{
					model.SuppName=row["SuppName"].ToString();
				}
				if(row["SuppType"]!=null && row["SuppType"].ToString()!="")
				{
					model.SuppType=int.Parse(row["SuppType"].ToString());
				}
				if(row["JZType"]!=null && row["JZType"].ToString()!="")
				{
					model.JZType=int.Parse(row["JZType"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["BankName"]!=null)
				{
					model.BankName=row["BankName"].ToString();
				}
				if(row["BankCard"]!=null)
				{
					model.BankCard=row["BankCard"].ToString();
				}
				if(row["Spare"]!=null)
				{
					model.Spare=row["Spare"].ToString();
				}
				if(row["Spare2"]!=null)
				{
					model.Spare2=row["Spare2"].ToString();
				}
              
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
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
			strSql.Append("select ID,ACode,PayMoney,SuppID,SuppName,SuppType,JZType,UserName,BankName,BankCard,Spare,Spare2,CreateDate,Balance ");
			strSql.Append(" FROM SubAccount ");
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
            return DAL.CommonBase.GetTable("SubAccount", "ID", "ID desc", strWhere, pageIndex, pageSize, out count);
        }
        public static List<Model.SubAccount> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.SubAccount> list = new List<Model.SubAccount>();

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
			strSql.Append(" ID,ACode,PayMoney,SuppID,SuppName,SuppType,JZType,UserName,BankName,BankCard,Spare,Spare2,CreateDate,Balance ");
			strSql.Append(" FROM SubAccount ");
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
			strSql.Append("select count(1) FROM SubAccount ");
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
			strSql.Append(")AS Row, T.*  from SubAccount T ");
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
			parameters[0].Value = "SubAccount";
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

