using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_003.Model
{
    public class Roles
    {
        public string RType { get; set; }
        public string RName { get; set; }
        public bool CMessage { get; set; }//是否可修改其权限
        public bool IsAdmin { get; set; }//是否是管理员
        public bool CanSH { get; set; }//是否有审核权限
        public bool CanLogin { get; set; }//是否可以登录
        public bool VState { get; set; }
        public bool Super { get; set; }//超级管理员
        public bool XingZheng { set; get; }//行政权限
        public bool CaiWu { set; get; }//财务权限
        public bool KeFu { set; get; }//客服权限

		public bool YunYing { get; set; }//运营
        public bool XiaoShou { get; set; }
		public bool DiaoDu { get; set; }//调度
		public bool SiJi { get; set; }//司机
        public bool XiaoShou { get; set; }//销售
        public string RColor { get; set; }
        public List<Model.RolePowers> PowersList { get; set; }
    }
}
