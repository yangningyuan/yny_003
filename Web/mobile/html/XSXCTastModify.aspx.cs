using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class XSXCTastModify :BasePage
    {

        //装车信息
        protected string tcode = "";
        protected Model.C_CarTast CTModel = new Model.C_CarTast();
        protected Model.C_Supplier SuppModel = new Model.C_Supplier();
        protected Model.OrderDetail OdModel = new Model.OrderDetail();
        protected Model.Goods Good = new Model.Goods();
        protected List<CarTast> XCList = new List<CarTast>();

        protected override void SetPowerZone()
        {
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




                //装车信息
                if (ct.TType != 1)
                {
                    xcView.Visible = false;
                    tcode = ct.TCode;
                    CTModel = BLL.C_CarTast.GetModelname(tcode);
                    if (CTModel != null)
                    {
                        SuppModel = BLL.C_Supplier.GetModel(Convert.ToInt32(CTModel.SupplierName));
                        if (!string.IsNullOrEmpty(CTModel.OCode))
                        {
                            OdModel = BLL.OrderDetail.GetList(" ordercode='" + CTModel.OCode + "'; ").FirstOrDefault();
                            Good = BLL.Goods.GetModel(OdModel.GId);
                        }
                    }
                }
                else {
                    zcView.Visible = false;
                    List<Model.C_CarTast> carList = BLL.C_CarTast.GetModelList(" TCode='" + ct.Name + "' ");
                    foreach (var item in carList)
                    {
                        CarTast cModel = new CarTast();
                        cModel.Code = item.Name;
                        cModel.Supp = BLL.C_Supplier.GetModel(Convert.ToInt32(item.SupplierName)).Name;
                        Model.OrderDetail XCod = BLL.OrderDetail.GetModelCode(item.OCode);
                        if (XCod != null)
                        {
                            cModel.Count = XCod.GCount;
                            cModel.ReCount = XCod.ReCount;
                            cModel.GoodName = BLL.Goods.GetModel(Convert.ToInt32(XCod.GId)).GName;
                        }
                        cModel.CreateTime = item.CreateDate;
                        XCList.Add(cModel);
                    }
                }

            }
            //ocode.Disabled = true;
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
    }
}