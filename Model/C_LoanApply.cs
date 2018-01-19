/**  版本信息模板在安装目录下，可自行修改。
* C_LoanApply.cs
*
* 功 能： N/A
* 类 名： C_LoanApply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/19 21:15:28   N/A    初版
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
	/// C_LoanApply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_LoanApply
	{
		public C_LoanApply()
		{}
		#region Model
		private int _id;
		private decimal _money;
		private decimal _realmoney;
		private DateTime _caretedate= DateTime.Now;
		private DateTime _realdate;
		private string _applymid;
		private string _spmid;
		private string _fftype;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 金额
		/// </summary>
		public decimal Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 实际金额
		/// </summary>
		public decimal RealMoney
		{
			set{ _realmoney=value;}
			get{return _realmoney;}
		}
		/// <summary>
		/// 借款时间
		/// </summary>
		public DateTime CareteDate
		{
			set{ _caretedate=value;}
			get{return _caretedate;}
		}
		/// <summary>
		/// 实际借款时间
		/// </summary>
		public DateTime RealDate
		{
			set{ _realdate=value;}
			get{return _realdate;}
		}
		/// <summary>
		/// 申请人
		/// </summary>
		public string ApplyMID
		{
			set{ _applymid=value;}
			get{return _applymid;}
		}
		/// <summary>
		/// 审批人
		/// </summary>
		public string SPMID
		{
			set{ _spmid=value;}
			get{return _spmid;}
		}
		/// <summary>
		/// 借款发放方式
		/// </summary>
		public string FFType
		{
			set{ _fftype=value;}
			get{return _fftype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

