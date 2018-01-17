using System;
namespace yny_003.Model
{
    /// <summary>
    /// ObjSub:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ObjSub
    {
        public ObjSub()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _person;
        private int _subtype;
        private decimal _money;
        private DateTime _createdate = DateTime.Now;
        private decimal _czfloat;
        private int _isdelete = 0;
        private string _remark;
        private string _spare;
        private string _spare1;
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ObjID { get; set; }
        /// <summary>
        /// 已用
        /// </summary>
        public decimal ReMoney { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Person
        {
            set { _person = value; }
            get { return _person; }
        }
        /// <summary>
        /// 子项类别
        /// </summary>
        public int SubType
        {
            set { _subtype = value; }
            get { return _subtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CZFloat
        {
            set { _czfloat = value; }
            get { return _czfloat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spare
        {
            set { _spare = value; }
            get { return _spare; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spare1
        {
            set { _spare1 = value; }
            get { return _spare1; }
        }
        #endregion Model

    }
}

