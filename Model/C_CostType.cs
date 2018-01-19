/**  版本信息模板在安装目录下，可自行修改。
* C_CostType.cs
*
* 功 能： N/A
* 类 名： C_CostType
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
	/// C_CostType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_CostType
	{
		public C_CostType()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _details;
		private int _xemoney;
		private DateTime _createdate= DateTime.Now;
		private int _isdelete;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 费用说明
		/// </summary>
		public string Details
		{
			set{ _details=value;}
			get{return _details;}
		}
		/// <summary>
		/// 0为不限制
		/// </summary>
		public int XEMoney
		{
			set{ _xemoney=value;}
			get{return _xemoney;}
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
		public int IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

