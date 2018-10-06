using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// SiJi1ListExcel 的摘要说明
    /// </summary>
    public class SiJi1ListExcel : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {

            base.ProcessRequest(context);
            string strWhere = "'1'='1'  AND ROLECODE='SiJi' ";

            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", (context.Request["mKey"]));
            }
            if (!string.IsNullOrEmpty(context.Request["SiJiType"]))
            {
                strWhere += string.Format(" and FMID={0} ", (context.Request["SiJiType"]));
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
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].MID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].MID + "~");
                sb.Append(ListMember[i].MName + "~");
                sb.Append(GetCountByCPCode(SQL2, ListMember[i].MID,1, TState) + "~");
                sb.Append(GetCountByCPCode(SQL2, ListMember[i].MID,2, TState) + "");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="CPCode">车牌</param>
        /// <param name="Type">1，装车  2，卸车</param>
        /// <returns></returns>
        protected static int GetCountByCPCode(string SQL, string CPCode,int Type, string SQL2)
        {
            int count = 0;

            count = Convert.ToInt32(BLL.CommonBase.GetSingle("SELECT Count(*) FROM C_CarTast WHERE 1=1  " + SQL + " and (CarSJ1='" + CPCode + "' or CarSJ2='" + CPCode + "') and TType="+Type+ " " + SQL2 + " "));

            return count;
        }
    }
}