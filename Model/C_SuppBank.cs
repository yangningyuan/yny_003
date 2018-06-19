/**  版本信息模板在安装目录下，可自行修改。
* C_SuppBank.cs
*
* 功 能： N/A
* 类 名： C_SuppBank
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/18 17:17:05   N/A    初版
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
	/// C_SuppBank:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_SuppBank
	{
		public C_SuppBank()
		{}
		#region Model
		private int _id;
		private string _accountname;
		private decimal _money;
		private string _cardname;
		private string _bankname;
		private string _spare;
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
		public string AccountName
		{
			set{ _accountname=value;}
			get{return _accountname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardName
		{
			set{ _cardname=value;}
			get{return _cardname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankName
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spare
		{
			set{ _spare=value;}
			get{return _spare;}
		}
		#endregion Model

	}
}

