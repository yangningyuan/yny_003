using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class DDTast : BasePage
    {
        protected override void SetPowerZone()
        {
            Spare2.DataSource = BLL.C_Car.GetList(" IsDelete = 0 and CType='牵引车' order by ID");
            Spare2.DataTextField = "PZCode";
            Spare2.DataValueField = "PZCode";
            Spare2.DataBind();

            CSpare2.DataSource = BLL.C_Car.GetList(" IsDelete = 0 and CType='挂车' order by ID");
            CSpare2.DataTextField = "PZCode";
            CSpare2.DataValueField = "PZCode";
            CSpare2.DataBind();
            ListItem lt = new ListItem();
            lt.Value = "";
            lt.Text = "空项";
            CSpare2.Items.Insert(0, lt);

            CarSJ1.DataSource = BLL.Member.ManageMember.GetMemberEntityList("  RoleCode='SiJi' AND FMID='1' AND IsClock=0 AND IsClose=0  order by ID");
            CarSJ1.DataTextField = "MName";
            CarSJ1.DataValueField = "MID";
            CarSJ1.DataBind();
            CarSJ1.Items.Insert(0, "--请选择--");

            CarSJ2.DataSource = BLL.Member.ManageMember.GetMemberEntityList("  RoleCode='SiJi' AND FMID IN('2','3') AND IsClock=0 AND IsClose=0  order by ID");
            CarSJ2.DataTextField = "MName";
            CarSJ2.DataValueField = "MID";
            CarSJ2.DataBind();
            CarSJ2.Items.Insert(0, "--请选择--");
            if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                ocode.Value = Request.QueryString["oid"];
                oid.Value = Request.QueryString["oid"];

            }
        }


        protected override string btnModify_Click()
        {
            //Model.C_CarTast c = new Model.C_CarTast();
            Model.C_CarTast c = BLL.C_CarTast.GetModel(int.Parse(Request.Form["fid"]));
            c.Name = Request.Form["Name"];
            c.TType = int.Parse(Request.Form["TType"]);


            c.Spare2 = Request.Form["Spare2"];
            c.CSpare2 = Request.Form["CSpare2"];
            c.CarSJ1 = Request.Form["CarSJ1"];
            c.CarSJ2 = Request.Form["CarSJ2"];
           
            c.ComDate = DateTime.Parse(Request.Form["ComDate"]);

            #region 司机车辆验证
            Model.C_Car car = BLL.C_Car.GetModelByCode(c.Spare2);
            Model.C_Car car2 = null;
            if (car == null)
                return "此牵引车不存在，请正确输入车辆牌照";
            //if (!string.IsNullOrEmpty(car.Spare1))
            //	return "此牵引车任务未完成，请选择别的车辆";
            if (!string.IsNullOrEmpty(c.CSpare2))
            {
                car2 = BLL.C_Car.GetModelByCode(c.CSpare2);
                if (car2 == null)
                    return "此挂车不存在，请正确输入车辆牌照";
                //if (!string.IsNullOrEmpty(car2.Spare1))
                //	return "此挂车任务未完成，请选择别的车辆";
            }

            Model.Member siji1 = BLL.Member.GetModelByMID(c.CarSJ1);
            if (siji1 != null)
            {
                if (siji1.FMID != "1")
                    return "此司机不是主司机";
            }
            else
                return "主司机不存在";
            Model.Member siji2 = BLL.Member.GetModelByMID(c.CarSJ2);
            if (siji2 != null)
            {
                if (siji2.FMID != "2" && siji2.FMID != "3")
                    return "此司机不是副司机";
            }
            else
                return "副司机不存在";
            #endregion

            c.TState = 0;
            c.DDMID = TModel.MID;
            if (BLL.C_CarTast.Update(c))
            {
                return "调度成功";
            }
            else {
                return "调度失败";
            }
        }


        protected override void SetValue(string id)
        {
            Model.C_CarTast c = BLL.C_CarTast.GetModel(int.Parse(id));
            Name.Value = c.Name;
            TType.Value = c.TType.ToString();

            Spare2.Value = c.Spare2.ToString();
            CSpare2.Value = c.CSpare2.ToString();
            CarSJ1.Value = c.CarSJ1.ToString();
            CarSJ2.Value = c.CarSJ2.ToString();


            ocode.Value = c.OCode;
            fid.Value = c.ID.ToString();
            oid.Value = c.OCode.ToString();
            ComDate.Value = c.ComDate.ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                ocode.Value = Request.QueryString["oid"];
            }
            if (c.TState != -1)
            {
                subview.Visible = false;
            }
        }
    }
}