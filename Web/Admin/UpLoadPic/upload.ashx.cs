using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace yny_003.Web.Admin
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest req = context.Request;
            //System.IO.Stream stream = req.InputStream;
            //StreamReader reader = new StreamReader(stream);
            //string read = reader.ReadToEnd();
            string address = req.Form["address"];
            string addressx=address.Substring(23);
            string dummyData = addressx.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
            if (dummyData.Length % 4 > 0)
            {
                dummyData = dummyData.PadRight(dummyData.Length + 4 - dummyData.Length % 4, '=');
            }
            
            byte[] bt = Convert.FromBase64String(dummyData);

            string fileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();//年月
            string ImageFilePath = "/Image" + "/" + fileName;
            if (System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(ImageFilePath)) == false)//如果不存在就创建文件夹
            {
                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(ImageFilePath));
            }
            string imgname = System.DateTime.Now.ToString("yyyyHHddHHmmss");
            string ImagePath = HttpContext.Current.Server.MapPath(ImageFilePath) + "/" + imgname;//定义图片名称
            File.WriteAllBytes(ImagePath+".png", bt);

            context.Response.Write(ImageFilePath+"/"+ imgname + ".png");
            //System.IO.MemoryStream stream = new System.IO.MemoryStream(bt);
            //Bitmap bitmap = new Bitmap(stream);
            //bitmap.Save("/images/frgttggt.png",);

            //byte[] arr2 = Convert.FromBase64String(UserPhoto);
            //using (MemoryStream ms2 = new MemoryStream(arr2))
            //{
            //    System.Drawing.Bitmap bmp2 = new System.Drawing.Bitmap(ms2);
            //    bmp2.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    bmp2.Dispose();
            //}

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