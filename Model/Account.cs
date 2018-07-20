/**  版本信息模板在安装目录下，可自行修改。
* Account.cs
*
* 功 能： N/A
* 类 名： Account
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/3 21:53:09   N/A    初版
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
	/// Account:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Account
	{
		public Account()
		{}
		#region Model
		private int _id;
		private int _cid;
		private string _cname;
		private int _atype=0;
		private int _supplierid;
		private string _suppliername;
		private decimal _totalmoney;
		private decimal _remoney;
		private DateTime _createdate= DateTime.Now;
		private int _astutas=0;
		private string _spare;
		private string _spare2;
		private int? _spare3;
		private DateTime _comdate;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CName
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 0装车(付款单) 1卸车（收款单）
		/// </summary>
		public int AType
		{
			set{ _atype=value;}
			get{return _atype;}
		}
		/// <summary>
		/// 客户ID
		/// </summary>
		public int SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SupplierName
		{
			set{ _suppliername=value;}
			get{return _suppliername;}
		}
		/// <summary>
		/// 总款项
		/// </summary>
		public decimal TotalMoney
		{
			set{ _totalmoney=value;}
			get{return _totalmoney;}
		}
		/// <summary>
		/// 已收付款项
		/// </summary>
		public decimal ReMoney
		{
			set{ _remoney=value;}
			get{return _remoney;}
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
		public int AStutas
		{
			set{ _astutas=value;}
			get{return _astutas;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spare
		{
			set{ _spare=value;}
			get{return _spare;}
		}
		/// <summary>
		///  修改备注
		/// </summary>
		public string Spare2
		{
			set{ _spare2=value;}
			get{return _spare2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Spare3
		{
			set{ _spare3=value;}
			get{return _spare3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime comDate
		{
			set{ _comdate=value;}
			get{return _comdate;}
		}
		#endregion Model

	}
}

