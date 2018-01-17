using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
using System.Collections.Generic;

namespace yny_003.DAL
{
    /// <summary>
    /// 数据访问类:ObjSub
    /// </summary>
    public partial class ObjSub
    {
        public ObjSub()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(yny_003.Model.ObjSub model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ObjSub(");
            strSql.Append("Name,Person,SubType,Money,CreateDate,CZFloat,IsDelete,Remark,Spare,Spare1,ReMoney,ObjID)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Person,@SubType,@Money,@CreateDate,@CZFloat,@IsDelete,@Remark,@Spare,@Spare1,@ReMoney,@ObjID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@Person", SqlDbType.VarChar,50),
                    new SqlParameter("@SubType", SqlDbType.Int,4),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CZFloat", SqlDbType.Decimal,9),
                    new SqlParameter("@IsDelete", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.Text),
                    new SqlParameter("@Spare", SqlDbType.VarChar,50),
                    new SqlParameter("@Spare1", SqlDbType.VarChar,50),new SqlParameter("@ReMoney", SqlDbType.Decimal,9),new SqlParameter("@ObjID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Person;
            parameters[2].Value = model.SubType;
            parameters[3].Value = model.Money;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.CZFloat;
            parameters[6].Value = model.IsDelete;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.Spare;
            parameters[9].Value = model.Spare1;
            parameters[10].Value = model.ReMoney;
            parameters[11].Value = model.ObjID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_003.Model.ObjSub model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ObjSub set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Person=@Person,");
            strSql.Append("SubType=@SubType,");
            strSql.Append("Money=@Money,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("CZFloat=@CZFloat,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Spare=@Spare,");
            strSql.Append("Spare1=@Spare1,");
            strSql.Append("ReMoney=@ReMoney, ");
            strSql.Append("ObjID=@ObjID ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@Person", SqlDbType.VarChar,50),
                    new SqlParameter("@SubType", SqlDbType.Int,4),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CZFloat", SqlDbType.Decimal,9),
                    new SqlParameter("@IsDelete", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.Text),
                    new SqlParameter("@Spare", SqlDbType.VarChar,50),
                    new SqlParameter("@Spare1", SqlDbType.VarChar,50),
                    new SqlParameter("@ReMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@ObjID", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Person;
            parameters[2].Value = model.SubType;
            parameters[3].Value = model.Money;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.CZFloat;
            parameters[6].Value = model.IsDelete;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.Spare;
            parameters[9].Value = model.Spare1;
            parameters[10].Value = model.ReMoney;
            parameters[11].Value = model.ObjID;
            parameters[12].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DeleteObjSub(string IDList)
        {
            string sb = "update ObjSub set IsDelete=1 where ID in (" + IDList + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ObjSub ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public static bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ObjSub ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public static yny_003.Model.ObjSub GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Person,SubType,Money,CreateDate,CZFloat,IsDelete,Remark,Spare,Spare1,ReMoney,ObjID from ObjSub ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            yny_003.Model.ObjSub model = new yny_003.Model.ObjSub();
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
            return DAL.CommonBase.GetTable("ObjSub", "ID", "ID asc", strWhere, pageIndex, pageSize, out count);
        }
        public static List<Model.ObjSub> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.ObjSub> list = new List<Model.ObjSub>();

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
        public static yny_003.Model.ObjSub DataRowToModel(DataRow row)
        {
            yny_003.Model.ObjSub model = new yny_003.Model.ObjSub();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Person"] != null)
                {
                    model.Person = row["Person"].ToString();
                }
                if (row["SubType"] != null && row["SubType"].ToString() != "")
                {
                    model.SubType = int.Parse(row["SubType"].ToString());
                }
                if (row["Money"] != null && row["Money"].ToString() != "")
                {
                    model.Money = decimal.Parse(row["Money"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["CZFloat"] != null && row["CZFloat"].ToString() != "")
                {
                    model.CZFloat = decimal.Parse(row["CZFloat"].ToString());
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(row["IsDelete"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Spare"] != null)
                {
                    model.Spare = row["Spare"].ToString();
                }
                if (row["Spare1"] != null)
                {
                    model.Spare1 = row["Spare1"].ToString();
                }
                if (row["ReMoney"] != null && row["ReMoney"].ToString() != "")
                {
                    model.ReMoney = decimal.Parse(row["ReMoney"].ToString());
                }
                if (row["ObjID"] != null && row["ObjID"].ToString() != "")
                {
                    model.ObjID = int.Parse(row["ObjID"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Name,Person,SubType,Money,CreateDate,CZFloat,IsDelete,Remark,Spare,Spare1,ReMoney,ObjID ");
            strSql.Append(" FROM ObjSub ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,Name,Person,SubType,Money,CreateDate,CZFloat,IsDelete,Remark,Spare,Spare1,ReMoney,ObjID ");
            strSql.Append(" FROM ObjSub ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public static int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ObjSub ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from ObjSub T ");
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
			parameters[0].Value = "ObjSub";
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

