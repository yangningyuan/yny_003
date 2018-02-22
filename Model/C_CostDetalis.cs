/**  版本信息模板在安装目录下，可自行修改。
* C_CostDetalis.cs
*
* 功 能： N/A
* 类 名： C_CostDetalis
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/19 21:15:27   N/A    初版
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
	/// C_CostDetalis:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_CostDetalis
	{
		public C_CostDetalis()
		{}
		#region Model
		private int _id;
		private int _cid;
		private decimal _costmoney;
		private string _costimgurl;
		private DateTime _caretedate= DateTime.Now;
		private int _isdelete=0;

		public string MID { get; set; }
		public string Remark { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 任务调度表ID
		/// </summary>
		public int CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 产生费用
		/// </summary>
		public decimal CostMoney
		{
			set{ _costmoney=value;}
			get{return _costmoney;}
		}
		/// <summary>
		/// 上传单据
		/// </summary>
		public string CostImgUrl
		{
			set{ _costimgurl=value;}
			get{return _costimgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CareteDate
		{
			set{ _caretedate=value;}
			get{return _caretedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

