using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// SiJi2ListExcel 的摘要说明
    /// </summary>
    public class SiJi2ListExcel : BaseHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}