/**  版本信息模板在安装目录下，可自行修改。
* C_Supplier.cs
*
* 功 能： N/A
* 类 名： C_Supplier
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/19 21:15:29   N/A    初版
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
	/// C_Supplier:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_Supplier
	{
		public C_Supplier()
		{}
		#region Model
		private int _id;
		private int _type;
		private string _name;
		private string _shcode;
		private string _usercode;
		private int _zqdate;
		private string _zzvalue;
		private string _telname;
		private string _tel;
		private string _address;
		private string _remark;
		private decimal _qcmoney;
		private decimal _overmoney;
		private int _isdelete=0;
		private DateTime _createdate= DateTime.Now;
		private string _spare1;
		private string _spare2;
		private string _spare3;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 1供应商资料 2为客户资料
		/// </summary>
		public int Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 税号
		/// </summary>
		public string SHCode
		{
			set{ _shcode=value;}
			get{return _shcode;}
		}
		/// <summary>
		/// 账号
		/// </summary>
		public string UserCode
		{
			set{ _usercode=value;}
			get{return _usercode;}
		}
		/// <summary>
		/// 结账周期
		/// </summary>
		public int ZQDate
		{
			set{ _zqdate=value;}
			get{return _zqdate;}
		}
		/// <summary>
		/// 资质
		/// </summary>
		public string ZZValue
		{
			set{ _zzvalue=value;}
			get{return _zzvalue;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string TelName
		{
			set{ _telname=value;}
			get{return _telname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 期初金额
		/// </summary>
		public decimal QCMoney
		{
			set{ _qcmoney=value;}
			get{return _qcmoney;}
		}
		/// <summary>
		/// 欠款额度
		/// </summary>
		public decimal OverMoney
		{
			set{ _overmoney=value;}
			get{return _overmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spare1
		{
			set{ _spare1=value;}
			get{return _spare1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spare2
		{
			set{ _spare2=value;}
			get{return _spare2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spare3
		{
			set{ _spare3=value;}
			get{return _spare3;}
		}
		#endregion Model

	}
}

