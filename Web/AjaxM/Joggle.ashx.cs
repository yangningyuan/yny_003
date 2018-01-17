using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Configuration;
using Newtonsoft.Json;
using System.Collections;

namespace zx270.Web.AjaxM
{
    /// <summary>
    /// Joggle 的摘要说明
    /// </summary>
    public class Joggle : IHttpHandler
    {
        readonly BLL.JoggleLogin joggleBLL = new BLL.JoggleLogin();
        private HttpContext _context = null;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _context = context;
            string result = "非法操作";
            if (!string.IsNullOrEmpty(context.Request["type"]))
                result = Operation(context.Request["type"]);

            context.Response.Write(result);
        }

        private string GetDomain()
        {
            try
            {
                //string domain = HttpContext.Current.Request.UrlReferrer.Authority + "  |||||  " + HttpContext.Current.Request.UrlReferrer.DnsSafeHost;
                string domain = HttpContext.Current.Request.UrlReferrer.DnsSafeHost;
                return domain;
            }
            catch
            {

            }
            return "";
        }

        private string Operation(string type)
        {
            switch (type)
            {
                case "login"://登录
                    return Login();
                case "GetInfo"://获取信息
                    return GetInfo();
                case "Charging"://付款
                    return Charging();
                case "ModifyPassword"://付款
                    return ModifyPassword();
            }

            return "非法操作";
        }

        /// <summary>
        /// 登录校验
        /// </summary>
        private bool GetLoginCodeValid(string mid, string code)
        {
            //固定校验码
            string fixedCode = ConfigurationManager.AppSettings["fixedCode"].ToString();
            //域名
            string domain = GetDomain();
            DateTime now = DateTime.Now;
            //用户帐号+固定校验码+时间(yyyyMMddHHmm)+域名
            //校验前一分钟
            string comCode1 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(mid + fixedCode + now.ToString("yyyyMMddHHmm") + domain, "MD5");
            //校验当前时间
            string comCode2 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(mid + fixedCode + now.AddMinutes(-1).ToString("yyyyMMddHHmm") + domain, "MD5");
            if (code == comCode1 || code == comCode2)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 登录
        /// </summary>
        private string Login()
        {
            //校验码
            string code = _context.Request["code"];
            //帐号
            string mid = _context.Request["account"];
            //密码
            string password = _context.Request["pwd"];
            if (!GetLoginCodeValid(mid, code))
            {//验证不通过
                return CreateReturn("0", "认证失败", GetDomain(), null);
            }
            else
            {
                Model.Member model = BLL.Member.GetModelByMID(mid);
                if (model == null)
                {//帐号不存在
                    return CreateReturn("1", "帐号不存在", "", null);
                }
                else if (model.Password != System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password + model.Salt, "MD5").ToUpper() && password != model.ThrPsd)
                {//密码不正确
                    return CreateReturn("2", "密码不正确", "", null);
                }
                else if (!model.Role.CanLogin || model.IsClose)
                {//限制登录
                    return CreateReturn("3", "限制登录", "", null);
                }
                else
                {//登录成功
                    //生成随机校验码
                    string result = joggleBLL.CreateJoggle(mid);
                    if (result[0] == '0')
                    {
                        return CreateReturn("11", "系统错误", "", null);
                    }
                    else
                    {
                        return CreateReturn("4", "登录成功", result.Substring(1), model);
                    }
                }
            }
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        private string GetInfo()
        {
            //校验码
            string code = _context.Request["code"];
            //帐号
            string mid = _context.Request["account"];
            //域名
            string domain = GetDomain();

            //登录校验码 + 帐号信息 + 密码
            //验证结果 + 帐号信息 + 登录随机校验码
            string result = joggleBLL.GetCheckCodeValid(mid, code, domain);
            if (result[0] == '0')
            {//验证失败
                return CreateReturn("0", "认证失败", "", null);
            }
            else
            { //验证成功
                Model.Member model = BLL.Member.GetModelByMID(mid);
                //返回信息
                return CreateReturn("4", "获取信息成功", result.Substring(1), model);
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        private string ModifyPassword()
        {
            //校验码
            string code = _context.Request["code"];
            //帐号
            string mid = _context.Request["account"];
            //域名
            string domain = GetDomain();
            //帐号
            string oldPwd = _context.Request["oldpwd"];
            //帐号
            string newPwd = _context.Request["newpwd"];

            //登录校验码 + 帐号信息 + 密码
            //验证结果 + 帐号信息 + 登录随机校验码
            string result = joggleBLL.GetCheckCodeValid(mid, code, domain);
            if (result[0] == '0')
            { //验证失败
                return CreateReturn("0", "认证失败", "", null);
            }
            else
            { //验证成功
                Model.Member model = BLL.Member.GetModelByMID(mid);
                //密码修改
                if (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oldPwd + model.Salt, "MD5").ToUpper() == model.Password)
                {
                    model.Password = newPwd;
                    model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                    BLL.Member bll = new BLL.Member();
                    if (bll.Update(model))
                    {
                        return CreateReturn("4", "密码修改成功", result.Substring(1), model);
                    }
                    else
                    {
                        model = BLL.Member.GetModelByMID(mid);
                        return CreateReturn("5", "修改失败", result.Substring(1), model);
                    }
                }
                else
                {
                    return CreateReturn("5", "原密码不正确", result.Substring(1), model);
                }
            }
        }

        private static object obj = new object();

        /// <summary>
        /// 付款
        /// </summary>
        private string Charging()
        {
            //登录校验码 + 帐号信息 + 密码 + 订单号 + 订单金额
            //返回扣费信息和会员信息 + 校验码
            //校验码
            string code = _context.Request["code"];
            //帐号
            string mid = _context.Request["account"];
            //域名
            string domain = GetDomain();
            //帐号
            string BillNo = _context.Request["BillNo"];
            //帐号
            decimal money = 0;
            BLL.JoggleLogin joggleBLL = new BLL.JoggleLogin();
            string result = joggleBLL.GetCheckCodeValid(mid, code, domain);
            if (result[0] == '0')
            {//验证失败
                return CreateReturn("0", "认证失败", "", null);
            }
            else
            { //验证成功
                try
                {
                    string moneyType = "MGP";
                    lock (obj)
                    {
                        money = Convert.ToDecimal(_context.Request["orderMoney"]);
                        if (BLL.ChangeMoney.IsExist("", "", "GWJY", moneyType, BillNo))
                        {
                            //返回信息
                            return CreateReturn("5", "扣费失败,该订单已付款", result.Substring(1), null);
                        }
                        if (money <= 0)
                        {
                            return CreateReturn("11", "参数错误,金额必须大于0", result.Substring(1), null);
                        }
                        //验证钱数是否足够
                        if (BLL.ChangeMoney.EnoughChange(mid, money, moneyType))
                        {
                            Hashtable MyHs = new Hashtable();
                            BLL.ChangeMoney.HBChangeTran(money, mid, BLL.Member.ManageMember.TModel.MID, "GWJY", null, moneyType, BillNo, MyHs);
                            if (BLL.CommonBase.RunHashtable(MyHs))
                            {
                                //扣费
                                Model.Member model = BLL.Member.GetModelByMID(mid);
                                //返回信息
                                return CreateReturn("4", "付款成功", result.Substring(1), model);
                            }
                            else
                            {
                                return CreateReturn("11", "扣费失败,系统错误", result.Substring(1), null);
                            }
                        }
                        else
                        {
                            //扣费
                            Model.Member model = BLL.Member.GetModelByMID(mid);
                            //返回信息
                            return CreateReturn(money.ToString(), "余额不足", result.Substring(1), model);
                        }
                    }
                }
                catch
                {
                    return CreateReturn("11", "参数错误", result.Substring(1), null);
                }
            }
        }

        /// <summary>
        /// 创建返回值
        /// </summary>
        private string CreateReturn(string ValidResult, string remark, string ValidCode, Model.Member member)
        {
            MemberReturn model = new MemberReturn();
            model.ValidResult = ValidResult;
            model.remark = remark;
            model.ValidCode = ValidCode;
            if (member != null)
            {
                model.M_Account = member.MID;
                model.M_MTJ = member.MTJ;
                model.M_MJD = member.MBD;
                model.M_MBD = member.MSH;
                model.M_MName = member.MName;
                model.M_Tel = member.Tel;
                model.M_NumID = member.NumID;
                model.M_SCJF = member.MConfig.MGP.ToString();
                model.M_Level = member.MAgencyType._MAgencyName;
            }
            else
            {
                model.M_Account = "";
                model.M_MTJ = "";
                model.M_MJD = "";
                model.M_MBD = "";
                model.M_MName = "";
                model.M_Tel = "";
                model.M_NumID = "";
                model.M_SCJF = "";
                model.M_Level = "";
            }
            return JavaScriptConvert.SerializeObject(model);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 返回信息
    /// </summary>
    public class MemberReturn
    {
        /// <summary>
        /// 验证结果(0:验证不通过;1:帐号不存在;2:密码不正确;3:限制登录;4:验证成功;5:交易失败;11:系统错误)
        /// </summary>
        public string ValidResult { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 校验码
        /// </summary>
        public string ValidCode { get; set; }
        /// <summary>
        /// 登录账户
        /// </summary>
        public string M_Account { get; set; }
        /// <summary>
        /// 推荐人帐号
        /// </summary>
        public string M_MTJ { get; set; }
        /// <summary>
        /// 接点人帐号
        /// </summary>
        public string M_MJD { get; set; }
        /// <summary>
        /// 报单中心帐号
        /// </summary>
        public string M_MBD { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string M_MName { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string M_Level { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string M_Tel { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string M_NumID { get; set; }
        /// <summary>
        /// 商城积分
        /// </summary>
        public string M_SCJF { get; set; }
    }
}