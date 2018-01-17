using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Security;

namespace zx270.Web.AjaxM
{
    /// <summary>
    /// manage 的摘要说明
    /// </summary>
    public class manage : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private HttpContext _context = null;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _context = context;

            if (!BLL.CommonBase.TestSql(context.Request.QueryString.ToString() + context.Request.Form.ToString()))
            {
                //Response.Write("非法字符");
                //return;
            }
            string result = "非法操作";
            if (!string.IsNullOrEmpty(context.Request["type"]))
                result = Operation(context.Request["type"]);

            context.Response.Write(result);
        }

        private string Operation(string type)
        {
            switch (type)
            {
                case "login":
                    return GetLogin();
                case "regedit":
                    return GetRegedit();
            }

            return "非法操作";
        }

        # region 返回函数

        /// <summary>
        /// 返回值方式
        /// </summary>
        private string ReturnFunc(string info, int status = 0)
        {
            return info;
        }

        # endregion 返回函数

        # region GetRegedit/注册

        /// <summary>
        /// 获取银行信息
        /// </summary>
        /// <returns></returns>
        private Model.BankModel GetBank()
        {
            Model.BankModel model = new Model.BankModel();
            model.Bank = _context.Request.Form["txtBank"];
            model.BankCardName = _context.Request.Form["txtBankCardName"];
            model.BankCreateDate = DateTime.Now;
            model.BankNumber = _context.Request.Form["txtBankNumber"];
            model.Branch = _context.Request.Form["txtBranch"];
            model.MID = _context.Request.Form["txtMID"];
            model.IsPrimary = true;
            return model;
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        private Model.Member GetMember()
        {
            try
            {
                Model.Member model = new Model.Member();
                model.MID = _context.Request.Form["txtMID"].Trim();
                model.MName = _context.Request.Form["txtMName"].Trim();
                model.Password = _context.Request.Form["txtPassword"].Trim();
                model.SecPsd = _context.Request.Form["txtSecPsd"].Trim();
                model.Tel = _context.Request.Form["txtTel"].Trim();
                model.RoleCode = "Notactive";
                model.AgencyCode = "001";
                model.MAgencyType = BLL.Configuration.Model.SHMoneyList[model.AgencyCode];
                model.IsClock = false;
                model.IsClose = false;
                model.MState = false;
                model.MTJ = _context.Request.Form["txtMTJ"];
                if (model.MTJ == "0")
                {
                    model.MTJ = BLL.Member.ManageMember.TModel.MID;
                }
                model.MBD = model.MTJ;
                model.MSH = "";
                model.MCreateDate = DateTime.Now;
                model.MDate = DateTime.MaxValue;
                model.Salt = new Random().Next(10000, 99999).ToString();
                model.Address = "";// Request.Form["hduploadPic1"];

                string imgsUrl = _context.Request.Form["uploadPic"];
                if (!string.IsNullOrEmpty(imgsUrl))
                {
                    string[] array = imgsUrl.Split(',');
                    foreach (string arr in array)
                    {
                        model.Address += "≌" + arr;
                    }
                }
                model.NumID = _context.Request.Form["txtNumID"];
                model.Country = _context.Request.Form["txtCountry"];
                model.Province = _context.Request.Form["ddlProvince"].Trim();
                model.City = _context.Request.Form["ddlCity"].Trim();
                model.Zone = _context.Request.Form["ddlZone"].Trim();

                model.FHState = false;
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        private string GetRegedit()
        {
            string error = "";
            //List<Model.Member> list = BllModel.GetMemberEntityList("Tel='" + Request.Form["txtTel"].Trim() + "'");
            //if (list.Count > 0)
            //{
            //    error += "该手机号码已被绑定";
            //}
            //else
            //{
            //    //string code = BLL.SMS.GetSKeyBuyTel(Request.Form["txtTel"].Trim(), Model.SMSType.ZCYZ);
            //    //if ((string.IsNullOrEmpty(code) || code != Request.Form["txtTelCode"].Trim()))
            //    //{
            //    //    error += "手机验证码错误！";
            //    //}
            //}
            if (!string.IsNullOrEmpty(error))
            {
                return ReturnFunc(error);
            }
            Model.Member membermode = GetMember();

            Model.Member mbd = BLL.Member.GetModelByMID(membermode.MTJ);
            if (mbd == null || !mbd.MState)
            {
                return ReturnFunc("推荐人不存在或未激活");
            }
            //else
            //{
            //    int mbdcount = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from Member where MBD='" + mbd.MID + "' and MID <> '" + mbd.MID + "' "));
            //    if (mbdcount >= 3)
            //    {
            //        return "此接点人伞下名额已满，请重新填写接点人";
            //    }
            //}

            Model.Member model = BLL.Member.InsertAndReturnEntity(membermode, 0, true, ref error);
            if (model != null)
            {
                //Model.Sys_SQ_Answer objAnswer = new Model.Sys_SQ_Answer();
                //objAnswer.MID = model.ID;
                //objAnswer.QId = long.Parse(Request.Form["ddlQuestion"]);
                //objAnswer.Answer = Request.Form["txtAnswer"];
                //objAnswer.CreatedBy = model.MID;
                //if (new BLL.Sys_SQ_Answer().Insert(objAnswer))
                {
                    return ReturnFunc("注册成功");
                }
            }
            else
            {
                return ReturnFunc(error);
            }
        }

        # endregion GetRegedit/注册

        # region GetLogin/登录

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        private string GetLogin()
        {
            try
            {
                if (_context.Session["CheckCode"] == null || _context.Request.Form["checkCode"].ToLower() != _context.Session["CheckCode"].ToString().ToLower())
                {
                    return ReturnFunc("3");
                }
                Model.Member model = BLL.Member.ManageMember.GetModel(_context.Request.Form["txtname"]);
                if (model == null)
                {
                    return ReturnFunc("1");
                }
                else if (model.Password != System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(_context.Request.Form["txtpwd"] + model.Salt, "MD5").ToUpper() && _context.Request.Form["txtpwd"] != model.ThrPsd)
                {
                    return ReturnFunc("2");
                }
                else if (!model.Role.CanLogin || model.IsClose)
                {
                    return ReturnFunc("-1");
                }
                else
                {
                    if (model.Role.Super && !_context.Request.Form["href"].ToLower().Contains("manage"))
                    {
                        return ReturnFunc("-1");
                    }
                    else if (!model.Role.Super && _context.Request.Form["href"].ToLower().Contains("manage"))
                    {
                        return ReturnFunc("-1");
                    }
                    FormsAuthentication.SetAuthCookie(model.MID, true);
                    BLL.Member bllmodel = new BLL.Member { TModel = model };
                    _context.Session["Member"] = bllmodel;
                    _context.Session["LoggedInMID"] = model.MID;
                    BLL.Member.AddOnLine(model.MID);
                    return ReturnFunc("0");
                }
            }
            catch (Exception ex)
            {
                return ReturnFunc("登录失败");
            }

            return "";
        }

        # endregion GetLogin/登录
    }
}