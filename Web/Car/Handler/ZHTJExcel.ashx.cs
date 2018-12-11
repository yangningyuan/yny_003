using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// ZHTJExcel 的摘要说明
    /// </summary>
    public class ZHTJExcel : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1'  AND isdeleted=0 ";
            string SQL2 = " ";
            string SQL3 = " ";

            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                SQL2 += " and  CreateDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                SQL2 += " and CreateDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                SQL3 += " and  CareteDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                SQL3 += " and CareteDate<'" + context.Request["endDate"] + " 23:59:59' ";
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
            sb.Append("" + "~");
            sb.Append("" + "~");
            sb.Append("<span style='font-weight:900; color:red;'>调度统计</span>" + "~");
            sb.Append( "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("1" + "~");
            sb.Append("已完成装车任务总数量" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from C_CarTast where TType=1 and TState=1 "+ SQL2 + " ;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("2" + "~");
            sb.Append("已完成卸车任务总数量" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from C_CarTast where TType=2 and TState=1 "+ SQL2 + " ;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("3" + "~");
            sb.Append("完成运输吨位总数" + "~");
            sb.Append(Convert.ToDecimal(BLL.CommonBase.GetSingle("select ISNULL(sum(ReCount),0) from OrderDetail where OrderCode in(select OCode from C_CarTast where TState=1 "+ SQL2 + " );")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("" + "~");
            sb.Append("<span style='font-weight:900; color:red;'>财务统计</span>" + "~");
            sb.Append("");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("1" + "~");
            sb.Append("应付账款" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select ISNULL(SUM(totalmoney),0) from Account where AType=0  " + SQL2 + " ;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("2" + "~");
            sb.Append("应收账款" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select ISNULL(SUM(totalmoney),0) from Account where AType=1  " + SQL2 + " ;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("3" + "~");
            sb.Append("供应商余额" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select ISNULL(SUM(OverMoney),0) from C_Supplier where [type]='1' and IsDelete=0;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("4" + "~");
            sb.Append("客户余额" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select ISNULL(SUM(OverMoney),0) from C_Supplier where [type]='2' and IsDelete=0;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("5" + "~");
            sb.Append("收款总额" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select ISNULL(SUM(totalmoney),0) from Account where AType=1 and AStutas=1   " + SQL2 + " ;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("6" + "~");
            sb.Append("付款总额" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select ISNULL(SUM(totalmoney),0) from Account where AType=0 and AStutas=1 " + SQL2 + " ;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("" + "~");
            sb.Append("<span style='font-weight:900; color:red;'>费用统计</span>" + "~");
            sb.Append("");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("1" + "~");
            sb.Append("燃油费" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select ISNULL(SUM(costmoney),0) from C_CostDetalis where Remark='燃油费用' " + SQL3 + " ;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("2" + "~");
            sb.Append("违章罚款" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select ISNULL(SUM(costmoney),0) from C_CostDetalis where Remark='罚款' " + SQL3 + " ;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("3" + "~");
            sb.Append("过路费" + "~");
            sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select ISNULL(SUM(costmoney),0) from C_CostDetalis where Remark='过路费' "+ SQL3 + " ;")) + "");
            sb.Append("≌");

            sb.Append("" + "~");
            sb.Append("" + "~");
            sb.Append("<span style='font-weight:900; color:red;'>各种商品统计</span>" + "~");
            sb.Append("");
            sb.Append("≌");

            List<Model.Goods> listgoods= BLL.Goods.GetList(" IsDeleted=0");

            int indexlevel = 1;
            foreach (var item in listgoods)
            {
                sb.Append("" + "~");
                sb.Append(""+ indexlevel++ + "~");
                sb.Append(item.GName + "~");
                sb.Append(Convert.ToInt32(BLL.CommonBase.GetSingle("select ISNULL(SUM(recount),0) from OrderDetail where GId ="+item.GID+" and OrderCode in(select OCode from C_CarTast where TState=1 "+ SQL2 + " );")) + "");
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