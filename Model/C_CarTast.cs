/**  版本信息模板在安装目录下，可自行修改。
* C_CarTast.cs
*
* 功 能： N/A
* 类 名： C_CarTast
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
	/// C_CarTast:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_CarTast
	{
		public C_CarTast()
		{}
		#region Model
		private int _id;
		private string _name;
		private int _ttype;
		private string _suppliername;
		private string _supplieraddress;
		private string _suppliertelname;
		private string _suppliertel;
		private int _carid;
		private string _carsj1;
		private string _carsj2;
		private int _costtype;
		private string _bdimg;
		private int _tstate;
		private int _isdelete;
		private string _spare1;
		private string _spare2;
		/// <summary>
		/// 商品订单号
		/// </summary>
        public string OCode { get; set; }

		public DateTime CreateDate { get; set; }
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
		/// 任务类型 1.装车 2.卸车 3.空车   装车任务填写供应商名称，卸车任务填写客户名称
		/// </summary>
		public int TType
		{
			set{ _ttype=value;}
			get{return _ttype;}
		}
		public static string typename (int count)
		{
			switch (count)
			{
				case 1:
					return "装车";
				case 2:
					return "卸车";
				case 3:
					return "空车";
			}
			return "";
		}
		
		/// <summary>
		/// 供应商或客户
		/// </summary>
		public string SupplierName
		{
			set{ _suppliername=value;}
			get{return _suppliername;}
		}
		/// <summary>
		/// 供应商地址
		/// </summary>
		public string SupplierAddress
		{
			set{ _supplieraddress=value;}
			get{return _supplieraddress;}
		}
		/// <summary>
		/// 供应商联系人
		/// </summary>
		public string SupplierTelName
		{
			set{ _suppliertelname=value;}
			get{return _suppliertelname;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string SupplierTel
		{
			set{ _suppliertel=value;}
			get{return _suppliertel;}
		}
		/// <summary>
		/// 派遣车辆ID
		/// </summary>
		public int CarID
		{
			set{ _carid=value;}
			get{return _carid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CarSJ1
		{
			set{ _carsj1=value;}
			get{return _carsj1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CarSJ2
		{
			set{ _carsj2=value;}
			get{return _carsj2;}
		}
		/// <summary>
		/// 费用类型 连表CostType
		/// </summary>
		public int CostType
		{
			set{ _costtype=value;}
			get{return _costtype;}
		}
		/// <summary>
		/// 磅单图片
		/// </summary>
		public string BDImg
		{
			set{ _bdimg=value;}
			get{return _bdimg;}
		}
		/// <summary>
		/// 任务状态 0未完成  1完成
		/// </summary>
		public int TState
		{
			set{ _tstate=value;}
			get{return _tstate;}
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
		/// 备注
		/// </summary>
		public string Spare1
		{
			set{ _spare1=value;}
			get{return _spare1;}
		}
		/// <summary>
		/// 车辆牌照
		/// </summary>
		public string Spare2
		{
			set{ _spare2=value;}
			get{return _spare2;}
		}
		#endregion Model

	}
}

