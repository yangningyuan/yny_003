/**  版本信息模板在安装目录下，可自行修改。
* C_Error.cs
*
* 功 能： N/A
* 类 名： C_Error
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/26 16:00:17   N/A    初版
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
	/// C_Error:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_Error
	{
		public C_Error()
		{}
		#region Model
		private int _id;
		private string _mid;
		private string _carcode;
		private string _etype;
		private string _edetails;
		private string _address;
		private string _imgurl;
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
		/// 
		/// </summary>
		public string MID
		{
			set{ _mid=value;}
			get{return _mid;}
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
		public string EType
		{
			set{ _etype=value;}
			get{return _etype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EDetails
		{
			set{ _edetails=value;}
			get{return _edetails;}
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
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
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

