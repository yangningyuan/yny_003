/**  版本信息模板在安装目录下，可自行修改。
* C_Security.cs
*
* 功 能： N/A
* 类 名： C_Security
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
	/// C_Security:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_Security
	{
		public C_Security()
		{}
		#region Model
		private int _id;
		private int _carid;
		private string _jcmid;
		private string _jctype;
		private DateTime _createdate= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 车辆ID
		/// </summary>
		public int CarID
		{
			set{ _carid=value;}
			get{return _carid;}
		}
		/// <summary>
		/// 安全检查司机
		/// </summary>
		public string JCMID
		{
			set{ _jcmid=value;}
			get{return _jcmid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JCType
		{
			set{ _jctype=value;}
			get{return _jctype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

