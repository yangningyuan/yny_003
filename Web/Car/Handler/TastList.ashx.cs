using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// TastList 的摘要说明
    /// </summary>
    public class TastList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1'   ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and IsDelete='" + context.Request["tState"] + "'";
            }
            if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            {
                strWhere += " and Name like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            }
            if (!string.IsNullOrEmpty(context.Request["SupplierName"]))
            {
                strWhere += " and SupplierName in (select ID from C_Supplier where Name like '%" + context.Request["SupplierName"] + "%')";
            }
            if (!string.IsNullOrEmpty(context.Request["coststate"]))
            {
                strWhere += " and TState in(" + context.Request["coststate"] + ") ";
            }
            if (!string.IsNullOrEmpty(context.Request["TType"]))
            {
                strWhere += " and TType='" + context.Request["TType"] + "' ";
            }

            if (!string.IsNullOrEmpty(context.Request["SHType"]))
            {
                strWhere += " and SHInt='" + context.Request["SHType"] + "' ";
            }

            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and CreateDate>='" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and CreateDate<='" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["startDate2"]))
            {
                strWhere += " and ComDate>='" + context.Request["startDate2"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate2"]))
            {
                strWhere += " and ComDate<='" + context.Request["endDate2"] + " 23:59:59' ";
            }

            if (!string.IsNullOrEmpty(context.Request["CarSJ1"]))
            {
                //strWhere += " and CarSJ1 in(select MID from Member where RoleCode='SiJi' and MName like '%" + context.Request["CarSJ1"] + "%' AND FMID='1' AND IsClock=0 AND IsClose=0) ";
                strWhere += " and CarSJ1 ='" + context.Request["CarSJ1"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["CarSJ2"]))
            {
                //strWhere += " and CarSJ2 in(select MID from Member where RoleCode='SiJi' and MName like '%" + context.Request["CarSJ2"] + "%' AND FMID in('2','3') AND IsClock=0 AND IsClose=0) ";
                strWhere += " and CarSJ2 ='" + context.Request["CarSJ2"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["Spare2"]))
            {
                strWhere += " and Spare2 like '%" + context.Request["Spare2"] + "%' ";
            }
            if (!string.IsNullOrEmpty(context.Request["CSpare2"]))
            {
                strWhere += " and OCode in(select OrderCode from OrderDetail where GId in(select GID from Goods where GName='"+ context.Request["CSpare2"] + "')) ";
            }

            decimal GCount = Convert.ToDecimal(BLL.CommonBase.GetSingle(" select ISNULL(SUM(GCount),0) from OrderDetail where OrderCode in(select OCode from C_CarTast where "+ strWhere + " )"));
            decimal ReCount = Convert.ToDecimal(BLL.CommonBase.GetSingle(" select ISNULL(SUM(ReCount),0) from OrderDetail where OrderCode in(select OCode from C_CarTast where " + strWhere + " )"));

            int count;
            List<Model.C_CarTast> ListNotice = BLL.C_CarTast.GetList(strWhere, pageIndex, 15, out count);

            decimal sum1 = 0;
            decimal sum2 = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                if (i == 0)
                {
                    sb.Append((i + 1) + (pageIndex - 1) * 15 + "<input type=\"hidden\" id=\"Sum1\" value='" + GCount + "' /><input type=\"hidden\" id=\"Sum2\" value='" + ReCount + "' />~");
                }
                else {
                    sb.Append((i + 1) + (pageIndex - 1) * 15 + "~");
                }
                
                sb.Append(ListNotice[i].Name + "~");
                sb.Append(Model.C_CarTast.typename(ListNotice[i].TType) + "~");
                //sb.Append(ListNotice[i].Prot + "~");
                //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                sb.Append(BLL.C_Supplier.GetModel(Convert.ToInt32(ListNotice[i].SupplierName)).Name + "~");
                //sb.Append(ListNotice[i].SupplierTel + "~");

                sb.Append(ListNotice[i].Spare2 + "~");
                sb.Append(ListNotice[i].CSpare2 + "~");
                string goodsname = "";
                string goodscount = "";
                string goodsrecount = "";
                string goodsprice = "";
                Model.Goods goods = new Model.Goods();
                if (!string.IsNullOrEmpty(ListNotice[i].OCode)) //装车  卸车
                {
                    List<Model.OrderDetail> odlist = BLL.OrderDetail.GetList(" ordercode='" + ListNotice[i].OCode.ToString() + "'; ");
                    foreach (Model.OrderDetail item in odlist)
                    {
                        goods = BLL.Goods.GetModel(item.GId);
                        goodsname = goods.GName;
                        goodscount = item.GCount.ToString();
                        goodsrecount = item.ReCount.ToString();
                        goodsprice = item.BuyPrice.ToString();
                    }
                }
                sb.Append(goodsname + "~");
                sb.Append(goodscount + "~");
                sb.Append(goodsrecount + "~");
                if (!string.IsNullOrEmpty(goodscount))
                {
                    sum1 = sum1 + Convert.ToDecimal(goodscount);
                }
                if (!string.IsNullOrEmpty(goodsrecount))
                {
                    sum2 = sum2 + Convert.ToDecimal(goodsrecount);
                }
                //sb.Append(BLL.C_CostType.GetModel(ListNotice[i].CostType).Name + "~");
                sb.Append((ListNotice[i].CreateDate) + "~");
                sb.Append((ListNotice[i].ComDate) + "~");
                sb.Append((Model.C_CarTast.statename(ListNotice[i].TState)) + "~");
                sb.Append((ListNotice[i].SHInt==1?"已审核":"未审核") + "~");
                //装车
                if (ListNotice[i].TType == 1)
                {
                    sb.Append("<div class=\"pay btn btn-danger\" onclick=\"subxiechedan('"+ ListNotice[i].Name+"')\" style ='background-color:cornflowerblue;'> 卸车列表</div>");
                }
                if (ListNotice[i].TState != 2 && TModel.Role.IsAdmin)
                {
                    sb.Append("<div class=\"pay btn btn-danger\" onclick=\"celTast('" + ListNotice[i].ID + "')\">取消任务</div>");
                    //sb.Append("<div class=\"pay btn btn-success\" onclick=\"callhtml('/Car/ModifyTast.aspx?id=" +ListNotice[i].ID +"','修改任务');onclickMenu()\">修改任务</div>");
                }
                else if (ListNotice[i].TState == -1 && TModel.Role.DiaoDu)
                {
                    sb.Append("<div class=\"pay btn btn-success\" onclick=\"callhtml('/Car/DDTast.aspx?id=" + ListNotice[i].ID + "','调度');onclickMenu()\">调度</div>");
                    //sb.Append("<div class=\"pay btn btn-success\" onclick=\"callhtml('/Car/ModifyTast.aspx?id=" +ListNotice[i].ID +"','修改任务');onclickMenu()\">修改任务</div>");
                }
                if (ListNotice[i].TState == 1)
                {
                    sb.Append("<div class=\"pay btn btn-success\" onclick=\"SetBJTast('" + ListNotice[i].ID + "')\">错误标记</div>");
                }
                if (ListNotice[i].TState == -2)
                {
                    sb.Append("<div class=\"pay btn btn-danger\" onclick=\"SetCelTast('" + ListNotice[i].ID + "')\">取消标记</div>");
                }

                if (ListNotice[i].SHInt == 0)
                {
                    sb.Append("<div class=\"pay btn btn-danger\"  style ='background-color:cornflowerblue;' onclick=\"SHTast('" + ListNotice[i].ID + "')\">审核</div>");
                }

                sb.Append("≌");
                sb.Append("≠");
                ////数量
                sb.Append("10");
                sb.Append("≠");
                //内容(买家信息

                Model.Member mc1= BLL.Member.GetModelByMID(ListNotice[i].CarSJ1);
                Model.Member mc2 = BLL.Member.GetModelByMID(ListNotice[i].CarSJ2);


                sb.Append("供应商地址:" + ListNotice[i].SupplierAddress);
                sb.Append("<br/>主司机:" +(mc1!=null?mc1.MName:"") );
                sb.Append("<br/>押运员:" + (mc2 != null ? mc2.MName : ""));

                if (!string.IsNullOrEmpty(ListNotice[i].OCode)) //装车  卸车
                {
                    sb.Append("<br/>商品订单:" + ListNotice[i].OCode);
                    if(goods!=null)
                    {
                        sb.Append("<br/>实际数量:" + goodsrecount + goods.Unit);
                        sb.Append("<br/>价格:" + goodsprice);
                        sb.Append(string.Format("<br/><span style='color:black; font-size:16px;'>{0}</span>&nbsp;&nbsp;&nbsp;<span style='color:red; font-size:20px;'>{1}</span><span style='color:green;'>{2}</span>", goods.GName, goodscount, goods.Unit));
                    }
                }
                sb.Append("<br/>磅单图片:<img src='" + ListNotice[i].BDImg + "' width='5%' />");
                sb.Append("≌");


                if (ListNotice.Count == i + 1)
                {
                    sb.Append("~");
                    sb.Append("~");
                    sb.Append("<strong style='color:red;'>本页合计<strong>~");
                    sb.Append("~");
                    sb.Append("~");
                    sb.Append("~");
                    sb.Append("~");
                    sb.Append("~");
                    sb.Append("<strong style='color:red;'>" +sum1 + "</strong>~");
                    sb.Append("<strong style='color:red;'>" + sum2 + "</strong>~");
                    sb.Append("~");
                    sb.Append("~");
                    sb.Append("≌");
                    sb.Append("≠");
                }
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}