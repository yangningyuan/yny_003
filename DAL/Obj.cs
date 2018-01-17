using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
using System.Collections.Generic;

namespace yny_003.DAL
{
    /// <summary>
    /// 数据访问类:Obj
    /// </summary>
    public partial class Obj
    {
        public Obj()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(yny_003.Model.Obj model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Obj(");
            strSql.Append("Name,Person,StateDate,EndDate,ImpUnit,FundID,TheNumID,DepartID,Money,Remark,Spart,Spart1,State,IsDelete)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Person,@StateDate,@EndDate,@ImpUnit,@FundID,@TheNumID,@DepartID,@Money,@Remark,@Spart,@Spart1,@State,@IsDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@Person", SqlDbType.VarChar,50),
                    new SqlParameter("@StateDate", SqlDbType.DateTime),
                    new SqlParameter("@EndDate", SqlDbType.DateTime),
                    new SqlParameter("@ImpUnit", SqlDbType.VarChar,100),
                    new SqlParameter("@FundID", SqlDbType.Int,4),
                    new SqlParameter("@TheNumID", SqlDbType.VarChar,100),
                    new SqlParameter("@DepartID", SqlDbType.Int,4),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@Remark", SqlDbType.Text),
                    new SqlParameter("@Spart", SqlDbType.VarChar,150),
                    new SqlParameter("@Spart1", SqlDbType.VarChar,150),
                    new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@IsDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Person;
            parameters[2].Value = model.StateDate;
            parameters[3].Value = model.EndDate;
            parameters[4].Value = model.ImpUnit;
            parameters[5].Value = model.FundID;
            parameters[6].Value = model.TheNumID;
            parameters[7].Value = model.DepartID;
            parameters[8].Value = model.Money;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.Spart;
            parameters[11].Value = model.Spart1;
            parameters[12].Value = model.State;
            parameters[13].Value = model.IsDelete;

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
        public static bool Update(yny_003.Model.Obj model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Obj set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Person=@Person,");
            strSql.Append("StateDate=@StateDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("ImpUnit=@ImpUnit,");
            strSql.Append("FundID=@FundID,");
            strSql.Append("TheNumID=@TheNumID,");
            strSql.Append("DepartID=@DepartID,");
            strSql.Append("Money=@Money,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Spart=@Spart,");
            strSql.Append("Spart1=@Spart1,");
            strSql.Append("State=@State,");
            strSql.Append("IsDelete=@IsDelete");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@Person", SqlDbType.VarChar,50),
                    new SqlParameter("@StateDate", SqlDbType.DateTime),
                    new SqlParameter("@EndDate", SqlDbType.DateTime),
                    new SqlParameter("@ImpUnit", SqlDbType.VarChar,100),
                    new SqlParameter("@FundID", SqlDbType.Int,4),
                    new SqlParameter("@TheNumID", SqlDbType.VarChar,100),
                    new SqlParameter("@DepartID", SqlDbType.Int,4),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@Remark", SqlDbType.Text),
                    new SqlParameter("@Spart", SqlDbType.VarChar,150),
                    new SqlParameter("@Spart1", SqlDbType.VarChar,150),
                    new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@IsDelete", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Person;
            parameters[2].Value = model.StateDate;
            parameters[3].Value = model.EndDate;
            parameters[4].Value = model.ImpUnit;
            parameters[5].Value = model.FundID;
            parameters[6].Value = model.TheNumID;
            parameters[7].Value = model.DepartID;
            parameters[8].Value = model.Money;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.Spart;
            parameters[11].Value = model.Spart1;
            parameters[12].Value = model.State;
            parameters[13].Value = model.IsDelete;
            parameters[14].Value = model.ID;

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
        public static bool DeleteObj(string IDList)
        {
            if (Convert.ToInt32(DAL.CommonBase.GetSingle("select COUNT(*) from ObjSub where ObjID in(" + IDList + ") and IsDelete=0;")) > 0)
                return false;
            string sb = "update Obj set IsDelete=1 where ID in (" + IDList + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Obj ");
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
            strSql.Append("delete from Obj ");
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
        public static yny_003.Model.Obj GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Person,StateDate,EndDate,ImpUnit,FundID,TheNumID,DepartID,Money,Remark,Spart,Spart1,State,IsDelete from Obj ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            yny_003.Model.Obj model = new yny_003.Model.Obj();
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
            return DAL.CommonBase.GetTable("Obj", "ID", "StateDate desc,ID asc", strWhere, pageIndex, pageSize, out count);
        }
        public static List<Model.Obj> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Obj> list = new List<Model.Obj>();

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
        public static yny_003.Model.Obj DataRowToModel(DataRow row)
        {
            yny_003.Model.Obj model = new yny_003.Model.Obj();
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
                if (row["StateDate"] != null && row["StateDate"].ToString() != "")
                {
                    model.StateDate = DateTime.Parse(row["StateDate"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["ImpUnit"] != null)
                {
                    model.ImpUnit = row["ImpUnit"].ToString();
                }
                if (row["FundID"] != null && row["FundID"].ToString() != "")
                {
                    model.FundID = int.Parse(row["FundID"].ToString());
                }
                if (row["TheNumID"] != null)
                {
                    model.TheNumID = row["TheNumID"].ToString();
                }
                if (row["DepartID"] != null && row["DepartID"].ToString() != "")
                {
                    model.DepartID = int.Parse(row["DepartID"].ToString());
                }
                if (row["Money"] != null && row["Money"].ToString() != "")
                {
                    model.Money = decimal.Parse(row["Money"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Spart"] != null)
                {
                    model.Spart = row["Spart"].ToString();
                }
                if (row["Spart1"] != null)
                {
                    model.Spart1 = row["Spart1"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(row["IsDelete"].ToString());
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
            strSql.Append("select ID,Name,Person,StateDate,EndDate,ImpUnit,FundID,TheNumID,DepartID,Money,Remark,Spart,Spart1,State,IsDelete ");
            strSql.Append(" FROM Obj ");
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
            strSql.Append(" ID,Name,Person,StateDate,EndDate,ImpUnit,FundID,TheNumID,DepartID,Money,Remark,Spart,Spart1,State,IsDelete ");
            strSql.Append(" FROM Obj ");
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
            strSql.Append("select count(1) FROM Obj ");
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
            strSql.Append(")AS Row, T.*  from Obj T ");
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
			parameters[0].Value = "Obj";
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

