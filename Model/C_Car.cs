/**  版本信息模板在安装目录下，可自行修改。
* C_Car.cs
*
* 功 能： N/A
* 类 名： C_Car
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/19 21:15:26   N/A    初版
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
	/// C_Car:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_Car
	{
		public C_Car()
		{}
		#region Model
		private int _id;
		private string _pzcode;
		private string _cartype;
		private string _carbrand;
		private string _carengine;
		private string _carcjcode;
		private string _carxszcode;
		private decimal _cardw;
		private string _rytype;
		private DateTime _bxdate;
		private DateTime _yyzdate;
		private DateTime _bydate;
		private DateTime _gjydate;
		private DateTime _aqfdate;
		private int _carzlc;
		private string _remark;
		private int _isdelete;
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
		/// 
		/// </summary>
		public string PZCode
		{
			set{ _pzcode=value;}
			get{return _pzcode;}
		}
		/// <summary>
		/// 车型
		/// </summary>
		public string CarType
		{
			set{ _cartype=value;}
			get{return _cartype;}
		}
		/// <summary>
		/// 品牌
		/// </summary>
		public string CarBrand
		{
			set{ _carbrand=value;}
			get{return _carbrand;}
		}
		/// <summary>
		/// 发动机号
		/// </summary>
		public string CarEngine
		{
			set{ _carengine=value;}
			get{return _carengine;}
		}
		/// <summary>
		/// 车架号
		/// </summary>
		public string CarCJCode
		{
			set{ _carcjcode=value;}
			get{return _carcjcode;}
		}
		/// <summary>
		/// 行驶证号
		/// </summary>
		public string CarXSZCode
		{
			set{ _carxszcode=value;}
			get{return _carxszcode;}
		}
		/// <summary>
		/// 吨位
		/// </summary>
		public decimal CarDW
		{
			set{ _cardw=value;}
			get{return _cardw;}
		}
		/// <summary>
		/// 燃油类型
		/// </summary>
		public string RYType
		{
			set{ _rytype=value;}
			get{return _rytype;}
		}
		/// <summary>
		/// 保险到期时间
		/// </summary>
		public DateTime BXDate
		{
			set{ _bxdate=value;}
			get{return _bxdate;}
		}
		/// <summary>
		/// 营运证号到期时间
		/// </summary>
		public DateTime YYZDate
		{
			set{ _yyzdate=value;}
			get{return _yyzdate;}
		}
		/// <summary>
		/// 保养到期时间
		/// </summary>
		public DateTime BYDate
		{
			set{ _bydate=value;}
			get{return _bydate;}
		}
		/// <summary>
		/// 罐检验到期时间
		/// </summary>
		public DateTime GJYDate
		{
			set{ _gjydate=value;}
			get{return _gjydate;}
		}
		/// <summary>
		/// 安全阀检验到期日期
		/// </summary>
		public DateTime AQFDate
		{
			set{ _aqfdate=value;}
			get{return _aqfdate;}
		}
		/// <summary>
		/// 总里程
		/// </summary>
		public int CarZLC
		{
			set{ _carzlc=value;}
			get{return _carzlc;}
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

