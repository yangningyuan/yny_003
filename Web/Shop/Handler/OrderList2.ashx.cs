using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace yny_003.Web.Shop.Handler
{
    /// <summary>
    /// OrderList2 的摘要说明
    /// </summary>
    public class OrderList2 : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            string strWhere = " IsDeleted=0 ";
            if (!memberModel.Role.Super)
            {
                strWhere += " and MID='" + memberModel.MID + "'";
            }
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and Status = " + context.Request["tState"] + " ";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                if (memberModel.Role.Super)
                {
                    strWhere += string.Format(" and ( MID='{0}' ) ", (context.Request["mKey"]));
                }
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and CreatedTime>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and CreatedTime<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            int count;
            List<Model.Order> List = BLL.Order.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].Id + "~");
                sb.Append(List[i].Code + "~");
                sb.Append(List[i].MID + "~");
                sb.Append(List[i].TotalPrice + "~");
                //sb.Append((List[i].DisCountTotalPrice).ToFixedString() + "~");
                sb.Append(List[i].GoodCount + "~");
                sb.Append(List[i].OrderTime.ToString("yyyy-MM-dd HH:mm") + "~");
                int status = List[i].Status;
                string resu = string.Empty;
                switch (status)
                {
                    case 1:
                        resu = "已打包待调度~";
                        if (List[i].MID == memberModel.MID)
                        {
                            resu += "<input type='button' value='调度' class='btn btn-success btn-sm' onclick='payOrder2(" + List[i].Id + ")' />";
                        }
                        break;
                    case 2:
                        resu = "已调度未完成~";
                        //if (memberModel.Role.Super)
                        //{
                        //    resu += "<input type='button' value='发货' class='btn btn-success btn-sm' onclick='sendOrder(" + List[i].Id + ")' />";
                        //}
                        break;
                    //case 3:
                    //    resu = "已发货&nbsp;&nbsp;<span class='seeExpress' onclick='seeExpress(" + List[i].Id + ")'>查看物流</span>~";
                    //    if (List[i].MID == memberModel.MID)
                    //    {
                    //        resu += "<input type='button' value='确认收货' class='btn btn-success btn-sm' onclick='receiveOrder(" + List[i].Id + ")' />";
                    //    }
                    //    break;
                    case 4:
                        resu = "已完成~";
                        break;
                }
                sb.Append(resu);
                sb.Append("<input type='button' value='查看详情' class='btn btn-success btn-sm' onclick='ShowOrder(" + List[i].Id + ")' />");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}