/**  版本信息模板在安装目录下，可自行修改。
* AccountDetails.cs
*
* 功 能： N/A
* 类 名： AccountDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/3 21:53:08   N/A    初版
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

namespace yny_003.DAL
{
	/// <summary>
	/// 数据访问类:AccountDetails
	/// </summary>
	public partial class AccountDetails
	{
		public AccountDetails()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public static int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "AccountDetails"); 
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AccountDetails");
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
        public static int Add(yny_003.Model.AccountDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AccountDetails(");
			strSql.Append("AID,CName,TotalMoney,ReMoney,PayMoney,CreateDate,Spare,Spare1)");
			strSql.Append(" values (");
			strSql.Append("@AID,@CName,@TotalMoney,@ReMoney,@PayMoney,@CreateDate,@Spare,@Spare1)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@ReMoney", SqlDbType.Decimal,9),
					new SqlParameter("@PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Spare", SqlDbType.VarChar,250),
					new SqlParameter("@Spare1", SqlDbType.VarChar,250)};
			parameters[0].Value = model.AID;
			parameters[1].Value = model.CName;
			parameters[2].Value = model.TotalMoney;
			parameters[3].Value = model.ReMoney;
			parameters[4].Value = model.PayMoney;
			parameters[5].Value = model.CreateDate;
			parameters[6].Value = model.Spare;
			parameters[7].Value = model.Spare1;

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
        public static Hashtable Add(yny_003.Model.AccountDetails model,Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AccountDetails(");
            strSql.Append("AID,CName,TotalMoney,ReMoney,PayMoney,CreateDate,Spare,Spare1)");
            strSql.Append(" values (");
            strSql.Append("@AID,@CName,@TotalMoney,@ReMoney,@PayMoney,@CreateDate,@Spare,@Spare1)");
            strSql.AppendFormat(" ;select '{0}'", guid);
            SqlParameter[] parameters = {
                    new SqlParameter("@AID", SqlDbType.Int,4),
                    new SqlParameter("@CName", SqlDbType.VarChar,50),
                    new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@ReMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@PayMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@Spare", SqlDbType.VarChar,250),
                    new SqlParameter("@Spare1", SqlDbType.VarChar,250)};
            parameters[0].Value = model.AID;
            parameters[1].Value = model.CName;
            parameters[2].Value = model.TotalMoney;
            parameters[3].Value = model.ReMoney;
            parameters[4].Value = model.PayMoney;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.Spare;
            parameters[7].Value = model.Spare1;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_003.Model.AccountDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AccountDetails set ");
			strSql.Append("AID=@AID,");
			strSql.Append("CName=@CName,");
			strSql.Append("TotalMoney=@TotalMoney,");
			strSql.Append("ReMoney=@ReMoney,");
			strSql.Append("PayMoney=@PayMoney,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("Spare=@Spare,");
			strSql.Append("Spare1=@Spare1");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@ReMoney", SqlDbType.Decimal,9),
					new SqlParameter("@PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Spare", SqlDbType.VarChar,250),
					new SqlParameter("@Spare1", SqlDbType.VarChar,250),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.AID;
			parameters[1].Value = model.CName;
			parameters[2].Value = model.TotalMoney;
			parameters[3].Value = model.ReMoney;
			parameters[4].Value = model.PayMoney;
			parameters[5].Value = model.CreateDate;
			parameters[6].Value = model.Spare;
			parameters[7].Value = model.Spare1;
			parameters[8].Value = model.ID;

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
        public static Hashtable Update(yny_003.Model.AccountDetails model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AccountDetails set ");
            strSql.Append("AID=@AID,");
            strSql.Append("CName=@CName,");
            strSql.Append("TotalMoney=@TotalMoney,");
            strSql.Append("ReMoney=@ReMoney,");
            strSql.Append("PayMoney=@PayMoney,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("Spare=@Spare,");
            strSql.Append("Spare1=@Spare1");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@AID", SqlDbType.Int,4),
                    new SqlParameter("@CName", SqlDbType.VarChar,50),
                    new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@ReMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@PayMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@Spare", SqlDbType.VarChar,250),
                    new SqlParameter("@Spare1", SqlDbType.VarChar,250),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.AID;
            parameters[1].Value = model.CName;
            parameters[2].Value = model.TotalMoney;
            parameters[3].Value = model.ReMoney;
            parameters[4].Value = model.PayMoney;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.Spare;
            parameters[7].Value = model.Spare1;
            parameters[8].Value = model.ID;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AccountDetails ");
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
			strSql.Append("delete from AccountDetails ");
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
        public static yny_003.Model.AccountDetails GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,AID,CName,TotalMoney,ReMoney,PayMoney,CreateDate,Spare,Spare1 from AccountDetails ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			yny_003.Model.AccountDetails model=new yny_003.Model.AccountDetails();
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
        public static yny_003.Model.AccountDetails DataRowToModel(DataRow row)
		{
			yny_003.Model.AccountDetails model=new yny_003.Model.AccountDetails();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["AID"]!=null && row["AID"].ToString()!="")
				{
					model.AID=int.Parse(row["AID"].ToString());
				}
				if(row["CName"]!=null)
				{
					model.CName=row["CName"].ToString();
				}
				if(row["TotalMoney"]!=null && row["TotalMoney"].ToString()!="")
				{
					model.TotalMoney=decimal.Parse(row["TotalMoney"].ToString());
				}
				if(row["ReMoney"]!=null && row["ReMoney"].ToString()!="")
				{
					model.ReMoney=decimal.Parse(row["ReMoney"].ToString());
				}
				if(row["PayMoney"]!=null && row["PayMoney"].ToString()!="")
				{
					model.PayMoney=decimal.Parse(row["PayMoney"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["Spare"]!=null)
				{
					model.Spare=row["Spare"].ToString();
				}
				if(row["Spare1"]!=null)
				{
					model.Spare1=row["Spare1"].ToString();
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
			strSql.Append("select ID,AID,CName,TotalMoney,ReMoney,PayMoney,CreateDate,Spare,Spare1 ");
			strSql.Append(" FROM AccountDetails ");
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
			strSql.Append(" ID,AID,CName,TotalMoney,ReMoney,PayMoney,CreateDate,Spare,Spare1 ");
			strSql.Append(" FROM AccountDetails ");
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
			strSql.Append("select count(1) FROM AccountDetails ");
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
			strSql.Append(")AS Row, T.*  from AccountDetails T ");
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
			parameters[0].Value = "AccountDetails";
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

