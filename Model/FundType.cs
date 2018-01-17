using System;
namespace yny_003.Model
{
    /// <summary>
    /// FundType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class FundType
    {
        public FundType()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _remark;
        /// <summary>
        /// 经费来源ID
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

