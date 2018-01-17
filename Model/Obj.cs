using System;
namespace yny_003.Model
{
    /// <summary>
    /// Obj:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Obj
    {
        public Obj()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _person;
        private DateTime _statedate = DateTime.Now;
        private DateTime _enddate;
        private string _impunit;
        private int _fundid;
        private string _thenumid;
        private int _departid;
        private decimal _money;
        private string _remark;
        private string _spart;
        private string _spart1;
        private int _state = 0;
        private int _isdelete = 0;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 项目名称
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
        /// 开始时间
        /// </summary>
        public DateTime StateDate
        {
            set { _statedate = value; }
            get { return _statedate; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 实施单位
        /// </summary>
        public string ImpUnit
        {
            set { _impunit = value; }
            get { return _impunit; }
        }
        /// <summary>
        /// 经费来源
        /// </summary>
        public int FundID
        {
            set { _fundid = value; }
            get { return _fundid; }
        }
        /// <summary>
        /// 批复文号
        /// </summary>
        public string TheNumID
        {
            set { _thenumid = value; }
            get { return _thenumid; }
        }
        /// <summary>
        /// 批复部门
        /// </summary>
        public int DepartID
        {
            set { _departid = value; }
            get { return _departid; }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spart
        {
            set { _spart = value; }
            get { return _spart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spart1
        {
            set { _spart1 = value; }
            get { return _spart1; }
        }
        /// <summary>
        /// 0未完成1已完成
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 0未删除1删除
        /// </summary>
        public int IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

