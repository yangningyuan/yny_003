/**  版本信息模板在安装目录下，可自行修改。
* SubAccount.cs
*
* 功 能： N/A
* 类 名： SubAccount
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/16 19:14:13   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace yny_003.Model
{
    /// <summary>
    /// SubAccount:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SubAccount
    {
        public SubAccount()
        { }
        #region Model
        public DateTime CreateDate { get; set; }

        private int _id;
        private string _acode;
        private decimal _paymoney;
        private int _suppid;
        private string _suppname;
        private int _supptype = 1;
        private int _jztype = 1;
        private string _username;
        private string _bankname;
        private string _bankcard;
        private string _spare;
        private string _spare2;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ACode
        {
            set { _acode = value; }
            get { return _acode; }
        }
        /// <summary>
        /// 本次付款金额
        /// </summary>
        public decimal PayMoney
        {
            set { _paymoney = value; }
            get { return _paymoney; }
        }
        /// <summary>
        /// 客户ID
        /// </summary>
        public int SuppID
        {
            set { _suppid = value; }
            get { return _suppid; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string SuppName
        {
            set { _suppname = value; }
            get { return _suppname; }
        }
        /// <summary>
        /// 1供应商 2客户
        /// </summary>
        public int SuppType
        {
            set { _supptype = value; }
            get { return _supptype; }
        }
        /// <summary>
        /// 1 余额付款 2.卡付，3余额+卡付，优先余额
        /// </summary>
        public int JZType
        {
            set { _jztype = value; }
            get { return _jztype; }
        }
        /// <summary>
        /// 经办人
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankCard
        {
            set { _bankcard = value; }
            get { return _bankcard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spare
        {
            set { _spare = value; }
            get { return _spare; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string Spare2
        {
            set { _spare2 = value; }
            get { return _spare2; }
        }
        /// <summary>
        /// 余额付款
        /// </summary>
        public decimal Balance { get; set; }
        #endregion Model

    }
}

