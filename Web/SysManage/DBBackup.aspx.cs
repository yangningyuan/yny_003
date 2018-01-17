using DBBackup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json;

namespace zx270.Web.SysManage
{
    public partial class DBBackup : BasePage
    {

        public IEnumerable<BackupItem> BackupItems;

        protected override void SetPowerZone()
        {
            BackupItems = SMOHelper.GetBackups();
        }

        public string Opt_GetList()
        {
            var backups = SMOHelper.GetBackups();
            totalCount = backups.Count();
            int idx = 0;
            var list = backups.Skip((PageIndex - 1) * PageSize).Take(PageSize).Select(item => new
            {
                ID = ++idx,
                BackupName = item.BackupName,
                BackupTime = item.BackupTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                Size = item.GetSizeStr(),
                Remark = item.Remark
            });
            return JavaScriptConvert.SerializeObject(new { PageData = list.ToList(), TotalPage = TotalPage() });
        }


        /// <summary>
        /// 备份系统
        /// </summary>
        /// <returns></returns>
        public string Opt_Backup()
        {
            if (!IsAdmin)
            {
                return "没有权限";
            }

            string backupName = Request["BackupName"];
            string remark = Request["remark"];

            SMOHelper.Backup(backupName, remark);

            BLL.OperationRecordBLL.Add(TModel.MID, ChangeType.O_BFWZ, "备份网站");

            return "操作成功";
        }

        public string Opt_R_emove()
        {
            if (!IsAdmin)
            {
                return "没有权限";
            }

            string backupName = Request["backupName"];
            SMOHelper.DeleteBackup(backupName);
            return "操作成功";
        }


        public string Opt_Restore()
        {
            if (!IsAdmin)
            {
                return "没有权限";
            }

            string backupName = Request["backupName"];
            SMOHelper.Restore(backupName);
            return "操作成功";
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <returns></returns>
        public string Opt_DownloadFile()
        {
            if (!IsAdmin)
            {
                return "没有权限";
            }
            string BackupName = Request["BackupName"];

            var backupItem = SMOHelper.GetBackups().First(item => item.IsDeleted == false && item.BackupName == BackupName);
            if (backupItem == null || !File.Exists(backupItem.BackupFullPath))
            {
                return "参数异常";
            }

            using (FileStream fs = new FileStream(backupItem.BackupFullPath, FileMode.Open))
            {
                const long ChunkSize = 102400;//100K 每次读取文件，只读取100Ｋ，这样可以缓解服务器的压力
                byte[] buffer = new byte[ChunkSize];

                long dataLengthToRead = fs.Length;//获取下载的文件总大小
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(BackupName + ".bak"));
                while (dataLengthToRead > 0 && Response.IsClientConnected)
                {
                    int lengthRead = fs.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
                    Response.OutputStream.Write(buffer, 0, lengthRead);
                    Response.Flush();
                    dataLengthToRead = dataLengthToRead - lengthRead;
                }
            }
            return "";
        }

        public string Opt_RestoreBackup()
        {
            try
            {
                var filePath = Request["FullPath"];
                SMOHelper.RestoreFile(filePath);
                return "还原成功";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}