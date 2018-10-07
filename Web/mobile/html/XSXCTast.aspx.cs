using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class XSXCTast : BasePage
    {
        protected string tcode = "";
        protected Model.C_CarTast CTModel = null;
        protected Model.C_Supplier SuppModel = null;
        protected Model.OrderDetail OdModel = null;
        protected Model.Goods Good = null;
        protected override void SetPowerZone()
        {
            tcode = Request.QueryString["tcode"];
            CTModel = BLL.C_CarTast.GetModelname(tcode);
            SuppModel = BLL.C_Supplier.GetModel(Convert.ToInt32(CTModel.SupplierName));
            if (!string.IsNullOrEmpty(CTModel.OCode))
            {
                OdModel = BLL.OrderDetail.GetList(" ordercode='" + CTModel.OCode + "'; ").FirstOrDefault();
                Good = BLL.Goods.GetModel(OdModel.GId);
            }



            txtGood.DataSource = BLL.Goods.GetList(" IsDeleted = 0 order by GID");
            txtGood.DataTextField = "GName";
            txtGood.DataValueField = "GID";
            txtGood.DataBind();
            txtGood.Items.Insert(0, "--请选择--");

            SupplierName.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0 and (Spare3 is null or Spare3='')   and Type=1 order by ID");
            SupplierName.DataTextField = "Name";
            SupplierName.DataValueField = "ID";
            SupplierName.DataBind();
            SupplierName.Items.Insert(0, "--请选择--");
            SupplierName2.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0 and (Spare3 is null or Spare3='')   and Type=2  order by ID");
            SupplierName2.DataTextField = "Name";
            SupplierName2.DataValueField = "ID";
            SupplierName2.DataBind();
            SupplierName2.Items.Insert(0, "--请选择--");
            SupplierName3.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0 and (Spare3 is null or Spare3='')   order by ID");
            SupplierName3.DataTextField = "Name";
            SupplierName3.DataValueField = "ID";
            SupplierName3.DataBind();
            SupplierName3.Items.Insert(0, "--请选择--");

            Name.Value = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                ocode.Value = Request.QueryString["oid"];
                oid.Value = Request.QueryString["oid"];
            }
            else {

            }
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Model.C_CarTast ct = BLL.C_CarTast.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                Name.Value = ct.Name;

                sid.Value = ct.SupplierName;
                if (ct.TType == 1)
                {
                    SupplierName.Value = ct.SupplierName;
                }
                else if (ct.TType == 2)
                {
                    SupplierName2.Value = ct.SupplierName;
                }
                else {
                    SupplierName3.Value = ct.SupplierName;
                }
                SupplierAddress.Value = ct.SupplierAddress;

                Model.OrderDetail od = BLL.OrderDetail.GetModelCode(ct.OCode);
                if (od != null)
                {
                    txtGood.Value = od.GId.ToString();
                    txtGoodCount.Value = od.GCount.ToString();
                    txtGoodPrice.Value = od.BuyPrice.ToString();
                }
            }
        }

        protected override void SetValue(string id)
        {
            Model.C_CarTast c = BLL.C_CarTast.GetModel(int.Parse(id));
            Name.Value = c.Name;
            TType.Value = c.TType.ToString();
            SupplierName.Value = c.SupplierName;
            SupplierName2.Value = c.SupplierName;
            SupplierName3.Value = c.SupplierName;

            SupplierAddress.Value = c.SupplierAddress;
            SupplierTelName.Value = c.SupplierTelName;
            SupplierTel.Value = c.SupplierTel;

            uploadurl.Value = c.BDImg.ToString();
            Spare1.Value = c.Spare1.ToString();
            ocode.Value = c.OCode;
            fid.Value = c.ID.ToString();
            oid.Value = c.OCode.ToString();
            ComDate.Value = c.ComDate.ToString();
            txtProt.Value = c.Prot.ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                ocode.Value = Request.QueryString["oid"];
            }
        }

        protected object obj = new object();
        protected override string btnModify_Click()
        {
            lock (obj)
            {
                try
                {
                    Model.C_CarTast c = null;
                    if (string.IsNullOrEmpty(Request.Form["fid"]))
                    {
                        c = new Model.C_CarTast();
                    }
                    else {
                        c = BLL.C_CarTast.GetModel(Convert.ToInt32(Request.Form["fid"]));
                    }
                    c.Name = Request.Form["Name"];
                    c.TType = int.Parse(Request.Form["TType"]);
                    if (c.TType == 1)
                    {
                        c.SupplierName = Request.Form["SupplierName"];
                    }
                    else if (c.TType == 2)
                    {
                        c.SupplierName = Request.Form["SupplierName2"];
                    }
                    else {
                        c.SupplierName = Request.Form["SupplierName3"];
                    }

                    c.SupplierAddress = Request.Form["SupplierAddress"];
                    c.SupplierTelName = Request.Form["SupplierTelName"];
                    c.SupplierTel = Request.Form["SupplierTel"];
                    c.BDImg = Request.Form["uploadurl"];
                    //c.OCode = Request.Form["ocode"];
                    c.Spare1 = Request.Form["Spare1"];
                    c.Prot = Convert.ToInt32(Request.Form["txtProt"]);
                    c.ComDate = DateTime.Parse(Request.Form["ComDate"]);

                    string zcCode = Request.Form["zcCode"];
                    Model.C_CarTast carTast = BLL.C_CarTast.GetModelname(zcCode);
                    if (carTast == null)
                        return "未查询到装车单";
                    if (carTast.XSMID != TModel.MID)
                        return "此装车单无权限";

                    Hashtable MyHs = new Hashtable();

                    if (c.TType != 3)//不是空车才能生成商品订单
                    {
                        #region 生成商品订单
                        string code = "";
                        string goodid = Request.Form["txtGood"];
                        Model.Goods go = BLL.Goods.GetModel(goodid);
                        if (go == null)
                            return "此商品找不到";

                        if (!string.IsNullOrEmpty(goodid))
                        {
                            decimal goodcount = 0;
                            decimal goodprice = 0;
                            try
                            {
                                goodcount = Convert.ToDecimal(Request.Form["txtGoodCount"]);
                                goodprice = Convert.ToDecimal(Request.Form["txtGoodPrice"]);
                            }
                            catch (Exception e)
                            {
                                return e.Message;
                            }
                            //先生成订单主表
                            Model.Order order = new Model.Order();
                            DateTime dt = DateTime.Now;
                            code = dt.ToString("yyyyMMddHHmmssfff");// dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + dt.Millisecond.ToString();
                            order.Code = code;
                            order.ReceiveId = 0;
                            order.CreatedBy = TModel.MID;
                            order.CreatedTime = DateTime.Now;
                            //order.GoodCount
                            decimal count = goodcount; decimal totalMoney = goodcount * goodprice;
                            string error = string.Empty;

                            //生成订单明细表
                            Model.OrderDetail od = new Model.OrderDetail();
                            od.BuyPrice = goodprice;
                            od.Code = GetGuid();
                            od.CreatedBy = TModel.MID;
                            od.CreatedTime = DateTime.Now;
                            od.GCount = count;
                            od.GId = Convert.ToInt32(goodid);
                            //查看库存数量是否足够，不够的话暂时不能提交订单

                            od.IsDeleted = false;
                            od.OrderCode = order.Code;
                            od.Status = 1;
                            od.TotalMoney = od.GCount * od.BuyPrice;
                            totalMoney += od.TotalMoney;
                            BLL.OrderDetail.Insert(od, MyHs);

                            order.GoodCount = count;
                            order.IsDeleted = false;
                            order.MID = c.SupplierName;
                            order.OrderTime = DateTime.Now;
                            order.TotalPrice = totalMoney;
                            order.DisCountTotalPrice = order.TotalPrice;// * BLL.Configuration.Model.E_GWDiscount;

                            order.ExpressCompany = c.Name;
                            order.Status = 2;
                            c.OCode = order.Code;
                            BLL.Order.Insert(order, MyHs);

                            if (!string.IsNullOrEmpty(error))
                            {
                                return error;
                            }
                        }
                        #endregion
                    }

                    c.TState = -1;
                    c.XSMID = TModel.MID;
                    c.TCode = zcCode;
                    int ncount = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from C_CarTast where Name='" + c.Name + "';"));
                    if (ncount > 0)
                        return "订单号重复，请刷新重试";

                    //int tid = BLL.C_CarTast.Add(c);
                    BLL.C_CarTast.Add(c, MyHs);
                    //if (tid > 0)
                    //{
                    //car.Spare1 = tid.ToString();
                    //BLL.C_Car.Update(car, MyHs);
                    //if (car2 != null)
                    //{
                    //	car.Spare1 = tid.ToString();
                    //	BLL.C_Car.Update(car2, MyHs);
                    //}
                    //}
                    //else {
                    //	return "任务添加失败";
                    //}
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        return "添加成功";
                    }
                    else {
                        return "添加失败";
                    }

                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }
    }
}