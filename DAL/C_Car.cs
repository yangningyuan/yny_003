/**  版本信息模板在安装目录下，可自行修改。
* C_Car.cs
*
* 功 能： N/A
* 类 名： C_Car
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/19 21:15:26   N/A    初版
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
using yny_003.Model;
using System.Collections;

namespace yny_003.DAL
{
	/// <summary>
	/// 数据访问类:C_Car
	/// </summary>
	public  partial class C_Car
	{
		public  C_Car()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public static int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "C_Car"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from C_Car");
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
		public static int Add(yny_003.Model.C_Car model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into C_Car(");
			strSql.Append("PZCode,CarType,CarBrand,CarEngine,CarCJCode,CarXSZCode,CarDW,RYType,BXDate,YYZDate,BYDate,GJYDate,AQFDate,CarZLC,Remark,IsDelete,CreateDate,Spare1,Spare2,Spare3,CType,JQXDate,SZXDate,CYXDate,CLRHDate,CLJJPDDate,YSJZ)");
			strSql.Append(" values (");
			strSql.Append("@PZCode,@CarType,@CarBrand,@CarEngine,@CarCJCode,@CarXSZCode,@CarDW,@RYType,@BXDate,@YYZDate,@BYDate,@GJYDate,@AQFDate,@CarZLC,@Remark,@IsDelete,@CreateDate,@Spare1,@Spare2,@Spare3,@CType,@JQXDate,@SZXDate,@CYXDate,@CLRHDate,@CLJJPDDate,@YSJZ)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PZCode", SqlDbType.VarChar,50),
					new SqlParameter("@CarType", SqlDbType.VarChar,50),
					new SqlParameter("@CarBrand", SqlDbType.VarChar,50),
					new SqlParameter("@CarEngine", SqlDbType.VarChar,50),
					new SqlParameter("@CarCJCode", SqlDbType.VarChar,50),
					new SqlParameter("@CarXSZCode", SqlDbType.VarChar,50),
					new SqlParameter("@CarDW", SqlDbType.Decimal,9),
					new SqlParameter("@RYType", SqlDbType.VarChar,10),
					new SqlParameter("@BXDate", SqlDbType.DateTime),
					new SqlParameter("@YYZDate", SqlDbType.DateTime),
					new SqlParameter("@BYDate", SqlDbType.DateTime),
					new SqlParameter("@GJYDate", SqlDbType.DateTime),
					new SqlParameter("@AQFDate", SqlDbType.DateTime),
					new SqlParameter("@CarZLC", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,250),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Spare1", SqlDbType.VarChar,250),
					new SqlParameter("@Spare2", SqlDbType.VarChar,250),
					new SqlParameter("@Spare3", SqlDbType.VarChar,250),new SqlParameter("@CType", SqlDbType.VarChar,50),
                    new SqlParameter("@JQXDate", SqlDbType.DateTime),
                    new SqlParameter("@SZXDate", SqlDbType.DateTime),
                    new SqlParameter("@CYXDate", SqlDbType.DateTime),
                    new SqlParameter("@CLRHDate", SqlDbType.DateTime),
                    new SqlParameter("@CLJJPDDate", SqlDbType.DateTime),
                    new SqlParameter("@YSJZ", SqlDbType.VarChar,50)
            };
			parameters[0].Value = model.PZCode;
			parameters[1].Value = model.CarType;
			parameters[2].Value = model.CarBrand;
			parameters[3].Value = model.CarEngine;
			parameters[4].Value = model.CarCJCode;
			parameters[5].Value = model.CarXSZCode;
			parameters[6].Value = model.CarDW;
			parameters[7].Value = model.RYType;
			parameters[8].Value = model.BXDate;
			parameters[9].Value = model.YYZDate;
			parameters[10].Value = model.BYDate;
			parameters[11].Value = model.GJYDate;
			parameters[12].Value = model.AQFDate;
			parameters[13].Value = model.CarZLC;
			parameters[14].Value = model.Remark;
			parameters[15].Value = model.IsDelete;
			parameters[16].Value = model.CreateDate;
			parameters[17].Value = model.Spare1;
			parameters[18].Value = model.Spare2;
			parameters[19].Value = model.Spare3;
            parameters[20].Value = model.CType;

            parameters[21].Value = model.JQXDate;
            parameters[22].Value = model.SZXDate;
            parameters[23].Value = model.CYXDate;
            parameters[24].Value = model.CLRHDate;
            parameters[25].Value = model.CLJJPDDate;
            parameters[26].Value = model.YSJZ;

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
        public static bool Update(yny_003.Model.C_Car model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update C_Car set ");
			strSql.Append("PZCode=@PZCode,");
			strSql.Append("CarType=@CarType,");
			strSql.Append("CarBrand=@CarBrand,");
			strSql.Append("CarEngine=@CarEngine,");
			strSql.Append("CarCJCode=@CarCJCode,");
			strSql.Append("CarXSZCode=@CarXSZCode,");
			strSql.Append("CarDW=@CarDW,");
			strSql.Append("RYType=@RYType,");
			strSql.Append("BXDate=@BXDate,");
			strSql.Append("YYZDate=@YYZDate,");
			strSql.Append("BYDate=@BYDate,");
			strSql.Append("GJYDate=@GJYDate,");
			strSql.Append("AQFDate=@AQFDate,");
			strSql.Append("CarZLC=@CarZLC,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("Spare1=@Spare1,");
			strSql.Append("Spare2=@Spare2,");
			strSql.Append("Spare3=@Spare3,");
            strSql.Append("CType=@CType,");

            strSql.Append("JQXDate=@JQXDate,");
            strSql.Append("SZXDate=@SZXDate,");
            strSql.Append("CYXDate=@CYXDate,");
            strSql.Append("CLRHDate=@CLRHDate,");
            strSql.Append("CLJJPDDate=@CLJJPDDate, ");
            strSql.Append("YSJZ=@YSJZ ");
            strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@PZCode", SqlDbType.VarChar,50),
					new SqlParameter("@CarType", SqlDbType.VarChar,50),
					new SqlParameter("@CarBrand", SqlDbType.VarChar,50),
					new SqlParameter("@CarEngine", SqlDbType.VarChar,50),
					new SqlParameter("@CarCJCode", SqlDbType.VarChar,50),
					new SqlParameter("@CarXSZCode", SqlDbType.VarChar,50),
					new SqlParameter("@CarDW", SqlDbType.Decimal,9),
					new SqlParameter("@RYType", SqlDbType.VarChar,10),
					new SqlParameter("@BXDate", SqlDbType.DateTime),
					new SqlParameter("@YYZDate", SqlDbType.DateTime),
					new SqlParameter("@BYDate", SqlDbType.DateTime),
					new SqlParameter("@GJYDate", SqlDbType.DateTime),
					new SqlParameter("@AQFDate", SqlDbType.DateTime),
					new SqlParameter("@CarZLC", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,250),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Spare1", SqlDbType.VarChar,250),
					new SqlParameter("@Spare2", SqlDbType.VarChar,250),
					new SqlParameter("@Spare3", SqlDbType.VarChar,250),
                    new SqlParameter("@CType", SqlDbType.VarChar,50),
                    new SqlParameter("@JQXDate", SqlDbType.DateTime),
                    new SqlParameter("@SZXDate", SqlDbType.DateTime),
                    new SqlParameter("@CYXDate", SqlDbType.DateTime),
                    new SqlParameter("@CLRHDate", SqlDbType.DateTime),
                    new SqlParameter("@CLJJPDDate", SqlDbType.DateTime),
                    new SqlParameter("@YSJZ", SqlDbType.VarChar,50),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.PZCode;
			parameters[1].Value = model.CarType;
			parameters[2].Value = model.CarBrand;
			parameters[3].Value = model.CarEngine;
			parameters[4].Value = model.CarCJCode;
			parameters[5].Value = model.CarXSZCode;
			parameters[6].Value = model.CarDW;
			parameters[7].Value = model.RYType;
			parameters[8].Value = model.BXDate;
			parameters[9].Value = model.YYZDate;
			parameters[10].Value = model.BYDate;
			parameters[11].Value = model.GJYDate;
			parameters[12].Value = model.AQFDate;
			parameters[13].Value = model.CarZLC;
			parameters[14].Value = model.Remark;
			parameters[15].Value = model.IsDelete;
			parameters[16].Value = model.CreateDate;
			parameters[17].Value = model.Spare1;
			parameters[18].Value = model.Spare2;
			parameters[19].Value = model.Spare3;
            parameters[20].Value = model.CType;

            parameters[21].Value = model.JQXDate;
            parameters[22].Value = model.SZXDate;
            parameters[23].Value = model.CYXDate;
            parameters[24].Value = model.CLRHDate;
            parameters[25].Value = model.CLJJPDDate;
            parameters[26].Value = model.YSJZ;


            parameters[27].Value = model.ID;

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
        public static Hashtable Update(yny_003.Model.C_Car model,Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update C_Car set ");
            strSql.Append("PZCode=@PZCode,");
            strSql.Append("CarType=@CarType,");
            strSql.Append("CarBrand=@CarBrand,");
            strSql.Append("CarEngine=@CarEngine,");
            strSql.Append("CarCJCode=@CarCJCode,");
            strSql.Append("CarXSZCode=@CarXSZCode,");
            strSql.Append("CarDW=@CarDW,");
            strSql.Append("RYType=@RYType,");
            strSql.Append("BXDate=@BXDate,");
            strSql.Append("YYZDate=@YYZDate,");
            strSql.Append("BYDate=@BYDate,");
            strSql.Append("GJYDate=@GJYDate,");
            strSql.Append("AQFDate=@AQFDate,");
            strSql.Append("CarZLC=@CarZLC,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("Spare1=@Spare1,");
            strSql.Append("Spare2=@Spare2,");
            strSql.Append("Spare3=@Spare3,");
            strSql.Append("CType=@CType,");
            strSql.Append("JQXDate=@JQXDate,");
            strSql.Append("SZXDate=@SZXDate,");
            strSql.Append("CYXDate=@CYXDate,");
            strSql.Append("CLRHDate=@CLRHDate,");
            strSql.Append("CLJJPDDate=@CLJJPDDate, ");
            strSql.Append("YSJZ=@YSJZ ");
            strSql.Append(" where ID=@ID");
            strSql.AppendFormat(" ;select '{0}'", guid);
            SqlParameter[] parameters = {
                    new SqlParameter("@PZCode", SqlDbType.VarChar,50),
                    new SqlParameter("@CarType", SqlDbType.VarChar,50),
                    new SqlParameter("@CarBrand", SqlDbType.VarChar,50),
                    new SqlParameter("@CarEngine", SqlDbType.VarChar,50),
                    new SqlParameter("@CarCJCode", SqlDbType.VarChar,50),
                    new SqlParameter("@CarXSZCode", SqlDbType.VarChar,50),
                    new SqlParameter("@CarDW", SqlDbType.Decimal,9),
                    new SqlParameter("@RYType", SqlDbType.VarChar,10),
                    new SqlParameter("@BXDate", SqlDbType.DateTime),
                    new SqlParameter("@YYZDate", SqlDbType.DateTime),
                    new SqlParameter("@BYDate", SqlDbType.DateTime),
                    new SqlParameter("@GJYDate", SqlDbType.DateTime),
                    new SqlParameter("@AQFDate", SqlDbType.DateTime),
                    new SqlParameter("@CarZLC", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.VarChar,250),
                    new SqlParameter("@IsDelete", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@Spare1", SqlDbType.VarChar,250),
                    new SqlParameter("@Spare2", SqlDbType.VarChar,250),
                    new SqlParameter("@Spare3", SqlDbType.VarChar,250),
                    new SqlParameter("@CType", SqlDbType.VarChar,50),
                     new SqlParameter("@JQXDate", SqlDbType.DateTime),
                    new SqlParameter("@SZXDate", SqlDbType.DateTime),
                    new SqlParameter("@CYXDate", SqlDbType.DateTime),
                    new SqlParameter("@CLRHDate", SqlDbType.DateTime),
                    new SqlParameter("@CLJJPDDate", SqlDbType.DateTime),
                    new SqlParameter("@YSJZ", SqlDbType.VarChar,50),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.PZCode;
            parameters[1].Value = model.CarType;
            parameters[2].Value = model.CarBrand;
            parameters[3].Value = model.CarEngine;
            parameters[4].Value = model.CarCJCode;
            parameters[5].Value = model.CarXSZCode;
            parameters[6].Value = model.CarDW;
            parameters[7].Value = model.RYType;
            parameters[8].Value = model.BXDate;
            parameters[9].Value = model.YYZDate;
            parameters[10].Value = model.BYDate;
            parameters[11].Value = model.GJYDate;
            parameters[12].Value = model.AQFDate;
            parameters[13].Value = model.CarZLC;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.IsDelete;
            parameters[16].Value = model.CreateDate;
            parameters[17].Value = model.Spare1;
            parameters[18].Value = model.Spare2;
            parameters[19].Value = model.Spare3;
            parameters[20].Value = model.CType;
            parameters[21].Value = model.JQXDate;
            parameters[22].Value = model.SZXDate;
            parameters[23].Value = model.CYXDate;
            parameters[24].Value = model.CLRHDate;
            parameters[25].Value = model.CLJJPDDate;
            parameters[26].Value = model.YSJZ;
            parameters[27].Value = model.ID;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from C_Car ");
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
			strSql.Append("delete from C_Car ");
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
		public static yny_003.Model.C_Car GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,PZCode,CarType,CarBrand,CarEngine,CarCJCode,CarXSZCode,CarDW,RYType,BXDate,YYZDate,BYDate,GJYDate,AQFDate,CarZLC,Remark,IsDelete,CreateDate,Spare1,Spare2,Spare3,CType,JQXDate,SZXDate,CYXDate,CLRHDate,CLJJPDDate,YSJZ from C_Car ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			yny_003.Model.C_Car model=new yny_003.Model.C_Car();
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
		public static yny_003.Model.C_Car GetModelByCode(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,PZCode,CarType,CarBrand,CarEngine,CarCJCode,CarXSZCode,CarDW,RYType,BXDate,YYZDate,BYDate,GJYDate,AQFDate,CarZLC,Remark,IsDelete,CreateDate,Spare1,Spare2,Spare3,CType,JQXDate,SZXDate,CYXDate,CLRHDate,CLJJPDDate,YSJZ from C_Car ");
            strSql.Append(" where PZCode=@PZCode");
            SqlParameter[] parameters = {
                    new SqlParameter("@PZCode", SqlDbType.VarChar,50)
            };
            parameters[0].Value = code;

            //yny_003.Model.C_Car model = new yny_003.Model.C_Car();
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
			return DAL.CommonBase.GetTable("C_Car", "ID", "ID asc", strWhere, pageIndex, pageSize, out count);
		}
		public static List<Model.C_Car> GetList(string strWhere, int pageIndex, int pageSize, out int count)
		{
			List<Model.C_Car> list = new List<Model.C_Car>();

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
		public static yny_003.Model.C_Car DataRowToModel(DataRow row)
		{
			yny_003.Model.C_Car model=new yny_003.Model.C_Car();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PZCode"]!=null)
				{
					model.PZCode=row["PZCode"].ToString();
				}
				if(row["CarType"]!=null)
				{
					model.CarType=row["CarType"].ToString();
				}
				if(row["CarBrand"]!=null)
				{
					model.CarBrand=row["CarBrand"].ToString();
				}
				if(row["CarEngine"]!=null)
				{
					model.CarEngine=row["CarEngine"].ToString();
				}
				if(row["CarCJCode"]!=null)
				{
					model.CarCJCode=row["CarCJCode"].ToString();
				}
				if(row["CarXSZCode"]!=null)
				{
					model.CarXSZCode=row["CarXSZCode"].ToString();
				}
				if(row["CarDW"]!=null && row["CarDW"].ToString()!="")
				{
					model.CarDW=decimal.Parse(row["CarDW"].ToString());
				}
				if(row["RYType"]!=null)
				{
					model.RYType=row["RYType"].ToString();
				}
				if(row["BXDate"]!=null && row["BXDate"].ToString()!="")
				{
					model.BXDate=DateTime.Parse(row["BXDate"].ToString());
				}
				if(row["YYZDate"]!=null && row["YYZDate"].ToString()!="")
				{
					model.YYZDate=DateTime.Parse(row["YYZDate"].ToString());
				}
				if(row["BYDate"]!=null && row["BYDate"].ToString()!="")
				{
					model.BYDate=DateTime.Parse(row["BYDate"].ToString());
				}
				if(row["GJYDate"]!=null && row["GJYDate"].ToString()!="")
				{
					model.GJYDate=DateTime.Parse(row["GJYDate"].ToString());
				}
				if(row["AQFDate"]!=null && row["AQFDate"].ToString()!="")
				{
					model.AQFDate=DateTime.Parse(row["AQFDate"].ToString());
				}
				if(row["CarZLC"]!=null && row["CarZLC"].ToString()!="")
				{
					model.CarZLC=int.Parse(row["CarZLC"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
                if (row["CType"] != null)
                {
                    model.CType = row["CType"].ToString();
                }
                if (row["JQXDate"] != null && row["JQXDate"].ToString() != "")
                {
                    model.JQXDate = DateTime.Parse(row["JQXDate"].ToString());
                }
                if (row["SZXDate"] != null && row["SZXDate"].ToString() != "")
                {
                    model.SZXDate = DateTime.Parse(row["SZXDate"].ToString());
                }
                if (row["CYXDate"] != null && row["CYXDate"].ToString() != "")
                {
                    model.CYXDate = DateTime.Parse(row["CYXDate"].ToString());
                }
                if (row["CLRHDate"] != null && row["CLRHDate"].ToString() != "")
                {
                    model.CLRHDate = DateTime.Parse(row["CLRHDate"].ToString());
                }
                if (row["CLJJPDDate"] != null && row["CLJJPDDate"].ToString() != "")
                {
                    model.CLJJPDDate = DateTime.Parse(row["CLJJPDDate"].ToString());
                }
                if (row["YSJZ"] != null)
                {
                    model.YSJZ = row["YSJZ"].ToString();
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
			strSql.Append("select ID,PZCode,CarType,CarBrand,CarEngine,CarCJCode,CarXSZCode,CarDW,RYType,BXDate,YYZDate,BYDate,GJYDate,AQFDate,CarZLC,Remark,IsDelete,CreateDate,Spare1,Spare2,Spare3,CType,JQXDate,SZXDate,CYXDate,CLRHDate,CLJJPDDate,YSJZ ");
			strSql.Append(" FROM C_Car ");
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
			strSql.Append(" ID,PZCode,CarType,CarBrand,CarEngine,CarCJCode,CarXSZCode,CarDW,RYType,BXDate,YYZDate,BYDate,GJYDate,AQFDate,CarZLC,Remark,IsDelete,CreateDate,Spare1,Spare2,Spare3,CType,JQXDate,SZXDate,CYXDate,CLRHDate,CLJJPDDate,YSJZ ");
			strSql.Append(" FROM C_Car ");
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
			strSql.Append("select count(1) FROM C_Car ");
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
			strSql.Append(")AS Row, T.*  from C_Car T ");
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
			parameters[0].Value = "C_Car";
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

