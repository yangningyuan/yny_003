using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// CarExcelList 的摘要说明
    /// </summary>
    public class CarExcelList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and IsDelete='" + context.Request["tState"] + "'";
            }
            if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            {
                strWhere += " and PZCode like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            }

            string SQL2 = " ";

            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                SQL2 += " and  CreateDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                SQL2 += " and CreateDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            string TState = "";
            if (!string.IsNullOrEmpty(context.Request["TType"]))
            {
                if (context.Request["TType"] == "1")
                {
                    TState = " and TState=1 ";
                }
                else {
                    TState = " and TState in(-1,0,2) ";
                }
            }
            int count;
            List<Model.C_Car> ListNotice = BLL.C_Car.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListNotice[i].PZCode + "~");
                sb.Append(ListNotice[i].CarType + "~");
                //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                sb.Append(GetCountByCPCode(SQL2,ListNotice[i].PZCode,1, TState) + "~");
                sb.Append(GetCountByCPCode(SQL2, ListNotice[i].PZCode, 2, TState) + "");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="CPCode">车牌</param>
        /// <param name="Type">1，装车  2，卸车</param>
        /// <returns></returns>
        protected static int GetCountByCPCode(string SQL,string CPCode,int Type,string SQL2)
        {
            int count = 0;
            if (Type == 1)
            {
                count = Convert.ToInt32(BLL.CommonBase.GetSingle("SELECT Count(*) FROM C_CarTast WHERE 1=1 and TType="+Type+" " + SQL + " and (Spare2='" + CPCode + "' or CSpare2='" + CPCode + "') "+SQL2+"  "));
            }
            else {
                count = Convert.ToInt32(BLL.CommonBase.GetSingle("SELECT Count(*) FROM C_CarTast WHERE 1=1 and TType="+Type+" " + SQL + " and (Spare2='" + CPCode + "' or CSpare2='" + CPCode + "') "+SQL2+" "));
            }

            return count;
        }
    }
}