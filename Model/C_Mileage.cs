/**  版本信息模板在安装目录下，可自行修改。
* C_Mileage.cs
*
* 功 能： N/A
* 类 名： C_Mileage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/2/24 11:30:15   N/A    初版
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
	/// C_Mileage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_Mileage
	{
		public C_Mileage()
		{}
		#region Model
		private int _id;
		private string _siji1;
		private string _siji2;
		private string _carcode;
		private int? _mileage;
		private int? _oid;
		private int? _type;
		private DateTime? _createdate= DateTime.Now;
		private string _spare;
		private string _spare2;
		/// <summary>
		/// 差值
		/// </summary>
		public int DiffCount { get; set; }
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
		public string SIJI1
		{
			set{ _siji1=value;}
			get{return _siji1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SIJI2
		{
			set{ _siji2=value;}
			get{return _siji2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CarCode
		{
			set{ _carcode=value;}
			get{return _carcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Mileage
		{
			set{ _mileage=value;}
			get{return _mileage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Oid
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 0，确认车辆  1，交车
		/// </summary>
		public int? Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
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
		/// 
		/// </summary>
		public string Spare2
		{
			set{ _spare2=value;}
			get{return _spare2;}
		}
		#endregion Model

	}
}

