using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// GoodsExcel 的摘要说明
    /// </summary>
    public class GoodsExcel : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {

            base.ProcessRequest(context);
            string strWhere = "'1'='1'  AND isdeleted=0 ";


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
                    TState = " and TState in(-1,0) ";
                }
            }

            int count;
            List<Model.Goods> ListMember = BLL.Goods.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].GID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].GName + "~");
                sb.Append(GetGoodsCountByOCode(SQL2, 1, ListMember[i].GID, TState) + "~");
                sb.Append(GetGoodsCountByOCode(SQL2, 2, ListMember[i].GID, TState) + "");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }

        protected static decimal GetGoodsCountByOCode(string SQL, int Type, int gid, string SQL2)
        {
            decimal count = 0;
            count = Convert.ToDecimal(BLL.CommonBase.GetSingle(" SELECT  ISNULL( SUM(RECOUNT),0) FROM OrderDetail WHERE gid=" + gid + " and OrderCode IN( SELECT OCODE FROM C_CarTast WHERE 1=1  " + SQL + " and TType=" + Type + " " + SQL2 + " )"));
            return count;
        }
    }
}