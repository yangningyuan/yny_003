/**  版本信息模板在安装目录下，可自行修改。
* C_CarTast.cs
*
* 功 能： N/A
* 类 名： C_CarTast
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
using System.Collections;

namespace yny_003.DAL
{
	/// <summary>
	/// 数据访问类:C_CarTast
	/// </summary>
	public  partial class C_CarTast
	{
		public  C_CarTast()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public static int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "C_CarTast"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_CarTast");
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
		public static int Add(yny_003.Model.C_CarTast model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_CarTast(");
			strSql.Append("Name,TType,SupplierName,SupplierAddress,SupplierTelName,SupplierTel,CarID,CarSJ1,CarSJ2,CostType,BDImg,TState,IsDelete,Spare1,Spare2,OCode,CSpare2,ComDate)");
			strSql.Append(" values (");
			strSql.Append("@Name,@TType,@SupplierName,@SupplierAddress,@SupplierTelName,@SupplierTel,@CarID,@CarSJ1,@CarSJ2,@CostType,@BDImg,@TState,@IsDelete,@Spare1,@Spare2,@OCode,@CSpare2,@ComDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,150),
					new SqlParameter("@TType", SqlDbType.Int,4),
					new SqlParameter("@SupplierName", SqlDbType.VarChar,50),
					new SqlParameter("@SupplierAddress", SqlDbType.VarChar,150),
					new SqlParameter("@SupplierTelName", SqlDbType.VarChar,50),
					new SqlParameter("@SupplierTel", SqlDbType.VarChar,50),
					new SqlParameter("@CarID", SqlDbType.Int,4),
					new SqlParameter("@CarSJ1", SqlDbType.VarChar,50),
					new SqlParameter("@CarSJ2", SqlDbType.VarChar,50),
					new SqlParameter("@CostType", SqlDbType.Int,4),
					new SqlParameter("@BDImg", SqlDbType.VarChar,250),
					new SqlParameter("@TState", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@Spare1", SqlDbType.VarChar,250),
					new SqlParameter("@Spare2", SqlDbType.VarChar,250),
					//new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@OCode", SqlDbType.VarChar,50),
                    new SqlParameter("@CSpare2", SqlDbType.VarChar,50),
					new SqlParameter("@ComDate", SqlDbType.DateTime)
					};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.TType;
			parameters[2].Value = model.SupplierName;
			parameters[3].Value = model.SupplierAddress;
			parameters[4].Value = model.SupplierTelName;
			parameters[5].Value = model.SupplierTel;
			parameters[6].Value = model.CarID;
			parameters[7].Value = model.CarSJ1;
			parameters[8].Value = model.CarSJ2;
			parameters[9].Value = model.CostType;
			parameters[10].Value = model.BDImg;
			parameters[11].Value = model.TState;
			parameters[12].Value = model.IsDelete;
			parameters[13].Value = model.Spare1;
			parameters[14].Value = model.Spare2;
			//parameters[15].Value = model.CreateDate;
			parameters[15].Value = model.OCode;
            parameters[16].Value = model.CSpare2;
			parameters[17].Value = model.ComDate;

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
		public static Hashtable Add(yny_003.Model.C_CarTast model,Hashtable MyHs)
		{
			string guid = Guid.NewGuid().ToString();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into C_CarTast(");
			strSql.Append("Name,TType,SupplierName,SupplierAddress,SupplierTelName,SupplierTel,CarID,CarSJ1,CarSJ2,CostType,BDImg,TState,IsDelete,Spare1,Spare2,OCode,CSpare2,ComDate)");
			strSql.Append(" values (");
			strSql.Append("@Name,@TType,@SupplierName,@SupplierAddress,@SupplierTelName,@SupplierTel,@CarID,@CarSJ1,@CarSJ2,@CostType,@BDImg,@TState,@IsDelete,@Spare1,@Spare2,@OCode,@CSpare2,@ComDate)");
			strSql.AppendFormat(" ;select '{0}'", guid);
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,150),
					new SqlParameter("@TType", SqlDbType.Int,4),
					new SqlParameter("@SupplierName", SqlDbType.VarChar,50),
					new SqlParameter("@SupplierAddress", SqlDbType.VarChar,150),
					new SqlParameter("@SupplierTelName", SqlDbType.VarChar,50),
					new SqlParameter("@SupplierTel", SqlDbType.VarChar,50),
					new SqlParameter("@CarID", SqlDbType.Int,4),
					new SqlParameter("@CarSJ1", SqlDbType.VarChar,50),
					new SqlParameter("@CarSJ2", SqlDbType.VarChar,50),
					new SqlParameter("@CostType", SqlDbType.Int,4),
					new SqlParameter("@BDImg", SqlDbType.VarChar,250),
					new SqlParameter("@TState", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@Spare1", SqlDbType.VarChar,250),
					new SqlParameter("@Spare2", SqlDbType.VarChar,250),
					//new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@OCode", SqlDbType.VarChar,50),
                    new SqlParameter("@CSpare2", SqlDbType.VarChar,50),
					new SqlParameter("@ComDate", SqlDbType.DateTime)
					};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.TType;
			parameters[2].Value = model.SupplierName;
			parameters[3].Value = model.SupplierAddress;
			parameters[4].Value = model.SupplierTelName;
			parameters[5].Value = model.SupplierTel;
			parameters[6].Value = model.CarID;
			parameters[7].Value = model.CarSJ1;
			parameters[8].Value = model.CarSJ2;
			parameters[9].Value = model.CostType;
			parameters[10].Value = model.BDImg;
			parameters[11].Value = model.TState;
			parameters[12].Value = model.IsDelete;
			parameters[13].Value = model.Spare1;
			parameters[14].Value = model.Spare2;
			//parameters[15].Value = model.CreateDate;
			parameters[15].Value = model.OCode;
            parameters[16].Value = model.CSpare2;
			parameters[17].Value = model.ComDate;
			MyHs.Add(strSql.ToString(), parameters);
			return MyHs;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(yny_003.Model.C_CarTast model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_CarTast set ");
			strSql.Append("Name=@Name,");
			strSql.Append("TType=@TType,");
			strSql.Append("SupplierName=@SupplierName,");
			strSql.Append("SupplierAddress=@SupplierAddress,");
			strSql.Append("SupplierTelName=@SupplierTelName,");
			strSql.Append("SupplierTel=@SupplierTel,");
			strSql.Append("CarID=@CarID,");
			strSql.Append("CarSJ1=@CarSJ1,");
			strSql.Append("CarSJ2=@CarSJ2,");
			strSql.Append("CostType=@CostType,");
			strSql.Append("BDImg=@BDImg,");
			strSql.Append("TState=@TState,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("Spare1=@Spare1,");
			strSql.Append("Spare2=@Spare2,");
			//strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("OCode=@OCode,");
            strSql.Append("CSpare2=@CSpare2,");
			strSql.Append("ComDate=@ComDate");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,150),
					new SqlParameter("@TType", SqlDbType.Int,4),
					new SqlParameter("@SupplierName", SqlDbType.VarChar,50),
					new SqlParameter("@SupplierAddress", SqlDbType.VarChar,150),
					new SqlParameter("@SupplierTelName", SqlDbType.VarChar,50),
					new SqlParameter("@SupplierTel", SqlDbType.VarChar,50),
					new SqlParameter("@CarID", SqlDbType.Int,4),
					new SqlParameter("@CarSJ1", SqlDbType.VarChar,50),
					new SqlParameter("@CarSJ2", SqlDbType.VarChar,50),
					new SqlParameter("@CostType", SqlDbType.Int,4),
					new SqlParameter("@BDImg", SqlDbType.VarChar,250),
					new SqlParameter("@TState", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@Spare1", SqlDbType.VarChar,250),
					new SqlParameter("@Spare2", SqlDbType.VarChar,250),
					//new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@OCode", SqlDbType.VarChar,50),
                    new SqlParameter("@CSpare2", SqlDbType.VarChar,50),
					new SqlParameter("@ComDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.TType;
			parameters[2].Value = model.SupplierName;
			parameters[3].Value = model.SupplierAddress;
			parameters[4].Value = model.SupplierTelName;
			parameters[5].Value = model.SupplierTel;
			parameters[6].Value = model.CarID;
			parameters[7].Value = model.CarSJ1;
			parameters[8].Value = model.CarSJ2;
			parameters[9].Value = model.CostType;
			parameters[10].Value = model.BDImg;
			parameters[11].Value = model.TState;
			parameters[12].Value = model.IsDelete;
			parameters[13].Value = model.Spare1;
			parameters[14].Value = model.Spare2;
			//parameters[15].Value = model.CreateDate;
			parameters[15].Value = model.OCode;
            parameters[16].Value = model.CSpare2;
			parameters[17].Value = model.ComDate;
			parameters[18].Value = model.ID;

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
		public static Hashtable Update(yny_003.Model.C_CarTast model,Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_CarTast set ");
            strSql.Append("Name=@Name,");
            strSql.Append("TType=@TType,");
            strSql.Append("SupplierName=@SupplierName,");
            strSql.Append("SupplierAddress=@SupplierAddress,");
            strSql.Append("SupplierTelName=@SupplierTelName,");
            strSql.Append("SupplierTel=@SupplierTel,");
            strSql.Append("CarID=@CarID,");
            strSql.Append("CarSJ1=@CarSJ1,");
            strSql.Append("CarSJ2=@CarSJ2,");
            strSql.Append("CostType=@CostType,");
            strSql.Append("BDImg=@BDImg,");
            strSql.Append("TState=@TState,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("Spare1=@Spare1,");
            strSql.Append("Spare2=@Spare2,");
            //strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("OCode=@OCode,");
            strSql.Append("CSpare2=@CSpare2,");
			strSql.Append("ComDate=@ComDate");
			strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.VarChar,150),
                    new SqlParameter("@TType", SqlDbType.Int,4),
                    new SqlParameter("@SupplierName", SqlDbType.VarChar,50),
                    new SqlParameter("@SupplierAddress", SqlDbType.VarChar,150),
                    new SqlParameter("@SupplierTelName", SqlDbType.VarChar,50),
                    new SqlParameter("@SupplierTel", SqlDbType.VarChar,50),
                    new SqlParameter("@CarID", SqlDbType.Int,4),
                    new SqlParameter("@CarSJ1", SqlDbType.VarChar,50),
                    new SqlParameter("@CarSJ2", SqlDbType.VarChar,50),
                    new SqlParameter("@CostType", SqlDbType.Int,4),
                    new SqlParameter("@BDImg", SqlDbType.VarChar,250),
                    new SqlParameter("@TState", SqlDbType.Int,4),
                    new SqlParameter("@IsDelete", SqlDbType.Int,4),
                    new SqlParameter("@Spare1", SqlDbType.VarChar,250),
                    new SqlParameter("@Spare2", SqlDbType.VarChar,250),
					//new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@OCode", SqlDbType.VarChar,50),
                    new SqlParameter("@CSpare2", SqlDbType.VarChar,50),
					new SqlParameter("@ComDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.TType;
            parameters[2].Value = model.SupplierName;
            parameters[3].Value = model.SupplierAddress;
            parameters[4].Value = model.SupplierTelName;
            parameters[5].Value = model.SupplierTel;
            parameters[6].Value = model.CarID;
            parameters[7].Value = model.CarSJ1;
            parameters[8].Value = model.CarSJ2;
            parameters[9].Value = model.CostType;
            parameters[10].Value = model.BDImg;
            parameters[11].Value = model.TState;
            parameters[12].Value = model.IsDelete;
            parameters[13].Value = model.Spare1;
            parameters[14].Value = model.Spare2;
            //parameters[15].Value = model.CreateDate;
            parameters[15].Value = model.OCode;
            parameters[16].Value = model.CSpare2;
			parameters[17].Value = model.ComDate;
			parameters[18].Value = model.ID;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_CarTast ");
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
			strSql.Append("delete from C_CarTast ");
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
		public static Model.C_CarTast GetModelBySJ(string mid)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 ID,Name,TType,SupplierName,SupplierAddress,SupplierTelName,SupplierTel,CarID,CarSJ1,CarSJ2,CostType,BDImg,TState,IsDelete,Spare1,Spare2,CreateDate,OCode,CSpare2,ComDate from C_CarTast ");
			strSql.AppendFormat(" where (CarSJ1='{0}' or CarSJ2='{0}') and  TState=0;", mid);
			

			yny_003.Model.C_CarTast model = new yny_003.Model.C_CarTast();
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
		public static yny_003.Model.C_CarTast GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,TType,SupplierName,SupplierAddress,SupplierTelName,SupplierTel,CarID,CarSJ1,CarSJ2,CostType,BDImg,TState,IsDelete,Spare1,Spare2,CreateDate,OCode,CSpare2,ComDate from C_CarTast ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			yny_003.Model.C_CarTast model=new yny_003.Model.C_CarTast();
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
		public static yny_003.Model.C_CarTast GetModel(string code)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 ID,Name,TType,SupplierName,SupplierAddress,SupplierTelName,SupplierTel,CarID,CarSJ1,CarSJ2,CostType,BDImg,TState,IsDelete,Spare1,Spare2,CreateDate,OCode,CSpare2,ComDate from C_CarTast ");
			strSql.Append(" where OCode=@OCode");
			SqlParameter[] parameters = {
					new SqlParameter("@OCode", SqlDbType.VarChar,50)
			};
			parameters[0].Value = code;

			yny_003.Model.C_CarTast model = new yny_003.Model.C_CarTast();
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
		/// 获得数据列表
		/// </summary>
		public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
		{
			return DAL.CommonBase.GetTable("C_CarTast", "ID", "ID asc", strWhere, pageIndex, pageSize, out count);
		}
		public static List<Model.C_CarTast> GetList(string strWhere, int pageIndex, int pageSize, out int count)
		{
			List<Model.C_CarTast> list = new List<Model.C_CarTast>();

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
		public static yny_003.Model.C_CarTast DataRowToModel(DataRow row)
		{
			yny_003.Model.C_CarTast model=new yny_003.Model.C_CarTast();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["TType"]!=null && row["TType"].ToString()!="")
				{
					model.TType=int.Parse(row["TType"].ToString());
				}
				if(row["SupplierName"]!=null)
				{
					model.SupplierName=row["SupplierName"].ToString();
				}
				if(row["SupplierAddress"]!=null)
				{
					model.SupplierAddress=row["SupplierAddress"].ToString();
				}
				if(row["SupplierTelName"]!=null)
				{
					model.SupplierTelName=row["SupplierTelName"].ToString();
				}
				if(row["SupplierTel"]!=null)
				{
					model.SupplierTel=row["SupplierTel"].ToString();
				}
				if(row["CarID"]!=null && row["CarID"].ToString()!="")
				{
					model.CarID=int.Parse(row["CarID"].ToString());
				}
				if(row["CarSJ1"]!=null)
				{
					model.CarSJ1=row["CarSJ1"].ToString();
				}
				if(row["CarSJ2"]!=null)
				{
					model.CarSJ2=row["CarSJ2"].ToString();
				}
				if(row["CostType"]!=null && row["CostType"].ToString()!="")
				{
					model.CostType=int.Parse(row["CostType"].ToString());
				}
				if(row["BDImg"]!=null)
				{
					model.BDImg=row["BDImg"].ToString();
				}
				if(row["TState"]!=null && row["TState"].ToString()!="")
				{
					model.TState=int.Parse(row["TState"].ToString());
				}
				if(row["IsDelete"]!=null && row["IsDelete"].ToString()!="")
				{
					model.IsDelete=int.Parse(row["IsDelete"].ToString());
				}
				if(row["Spare1"]!=null)
				{
					model.Spare1=row["Spare1"].ToString();
				}
				if(row["Spare2"]!=null)
				{
					model.Spare2=row["Spare2"].ToString();
				}
                if (row["CreateDate"] != null)
                {
                    model.CreateDate = DateTime.Parse( row["CreateDate"].ToString());
                }
				if (row["OCode"] != null)
				{
					model.OCode =row["OCode"].ToString();
				}
                if (row["CSpare2"] != null)
                {
                    model.CSpare2 = row["CSpare2"].ToString();
                }
				if (row["ComDate"] != null)
				{
					model.ComDate = DateTime.Parse(row["ComDate"].ToString());
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
			strSql.Append("select ID,Name,TType,SupplierName,SupplierAddress,SupplierTelName,SupplierTel,CarID,CarSJ1,CarSJ2,CostType,BDImg,TState,IsDelete,Spare1,Spare2,CreateDate,OCode,CSpare2,ComDate ");
			strSql.Append(" FROM C_CarTast ");
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
			strSql.Append(" ID,Name,TType,SupplierName,SupplierAddress,SupplierTelName,SupplierTel,CarID,CarSJ1,CarSJ2,CostType,BDImg,TState,IsDelete,Spare1,Spare2,CreateDate,OCode,CSpare2,ComDate ");
			strSql.Append(" FROM C_CarTast ");
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
			strSql.Append("select count(1) FROM C_CarTast ");
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
			strSql.Append(")AS Row, T.*  from C_CarTast T ");
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
			parameters[0].Value = "C_CarTast";
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

