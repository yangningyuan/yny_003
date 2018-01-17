<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBBackup.aspx.cs" Inherits="zx270.Web.SysManage.DBBackup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        #dbBackupQueryBar * {
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript">
        function showBackForm() {
            $('#txtBackupName').val();
            $('#txtRemark').val();
            layer.open({
                type: 1,
                content: $('#backupDB_form'),
                area: ['400px', '300px']
            })
        }

        function beforeBackup(context) {
            var txtBackupName = $.trim($('#txtBackupName').val());
            if (txtBackupName == '') {
                layer.alert('请输入备份名称');
                return;
            }

            //verifypsd(function () {
            layer.load(2);
            context.submit();
            //})
        }

        function onBackupSuccess(result) {
            layer.closeAll();
            layer.alert(result, function () {
                layer.closeAll();
                if (result.indexOf('成功') != -1) {
                    callhtml('SysManage/DBBackup.aspx');
                }
            });
        }

        function restoreBackup(backupName) {
            verifypsd(function () {
                layer.load(2);
                $.post('SysManage/DBBackup.aspx', { backupName: backupName, opt: 'restore' }, function (result) {
                    layer.closeAll();
                    layer.alert(result);
                }, 'text');
            });
        }

        function deleteBackup(backupName) {
            verifypsd(function () {
                $.post('SysManage/DBBackup.aspx', { backupName: backupName, opt: 'R_emove' }, function (result) {
                    layer.alert(result, function () {
                        layer.closeAll();
                        if (result.indexOf('成功') != -1) {
                            callhtml('SysManage/DBBackup.aspx');
                        }
                    });
                }, 'text');
            });
        }

        var uploadState = 0;
        function uploadBackupFile() {
            if (uploadState != 0) {
                return;
            }
            FileUploader.GetFile(function () {
                uploadState = 1;
                this.Upload({
                    url: 'WebUpload/UploadFile.ashx',
                    onFailed: function () {
                        uploadState = 0;
                        layer.alert('上传失败')
                        $('#filePicker').val('上传失败');
                    },
                    onSuccess: function (result) {
                        result = JSON.parse(result);
                        if (result.Result) {
                            layer.alert('上传成功');
                            $('#filePicker').val('上传成功，正在还原数据库');
                            $.post('SysManage/DBBackup.aspx?Opt=RestoreBackup', { FullPath: result.Msg }, function (result) {
                                layer.alert(result);
                                if (result.indexOf('成功') != -1) {
                                    $('#filePicker').val('还原成功');
                                } else {
                                    $('#filePicker').val('还原失败');
                                }
                                uploadState = 0;
                            }, 'text');
                        } else {
                            layer.alert('上传失败');
                            $('#filePicker').val('上传失败');
                            uploadState = 0;
                        }
                    },
                    onProgress: function (progress) {
                        console.log('正在上传');
                        $('#filePicker').val('正在上传：' + progress.fileProgress);
                    }
                });
            });
        }

        setTimeout(function () {
            ajaxForm.submit('dbBackupQueryBar');
        }, 100);
    </script>
    <script type="text/x-jquery-tmpl" id="BackupsTmpl">
        <tr>
            <td>${ID}</td>
            <td>${BackupName}</td>
            <td>${BackupTime}</td>
            <td>${Size}</td>
            <td>${Remark}</td>
            <td>
                <input type="button" value="还原为此备份" class="btn btn-warning" onclick="restoreBackup('${BackupName}')" />
                <input type="button" value="删除" class="btn btn-danger" onclick="deleteBackup('${BackupName}')" />
                <a href="SysManage/DBBackup.aspx?Opt=DownloadFile&BackupName=${BackupName}" class="btn btn-info">下载</a>
            </td>
        </tr>
    </script>
</head>
<body>
    <div style="display: none" id="backupDB_form" data-ajaxform="true" data-action="SysManage/DBBackup.aspx" data-success="onBackupSuccess(result);" data-beforesubmit="beforeBackup(context)">
        <input type="hidden" value="backup" name="opt" />
        <table class="table table-bordered table-condensed table-hover">
            <tr>
                <td style="text-align: right;">备份名称：</td>
                <td>
                    <input type="text" maxlength="30" placeholder="备份的名称" name="backupName" id="txtBackupName" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">备注：</td>
                <td>
                    <textarea maxlength="50" placeholder="备注" style="height: 100px;" name="remark" id="txtRemark"></textarea>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <input type="button" class="btn btn-success" data-submit="true" value="备份" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <h3 class="h3 text-center" style="margin-top: 20px; margin-bottom: 20px; font-family: 微软雅黑; font-size: 30px; color: black">备份、还原网站</h3>
        <pre style="font-family: 微软雅黑,宋体; font-size: 18px; color: black;">注意：尽量不要还原<span style="color:red; font-weight:bold" class="font-weight">时间过长</span>的备份。尽量不要在白天还原备份。</pre>
        <div>
            <div></div>
            <div>
                <div style="height: 30px; border: 1px solid black" id="uploadingFile"></div>
                <input style="margin-left: 50px;" type="button" id="filePicker" value="还原备份" class="btn btn-primary" onclick="uploadBackupFile()" />
                <div id="backupsList">
                </div>
            </div>
        </div>
        <div>
            <div id="dbBackupQueryBar" data-ajaxform="true" data-action="SysManage/DBBackup.aspx?Opt=GetList" data-resulttype="json" data-pagination="BackupsPagination" data-beforesubmit="getPaginationData(context); return true;" data-success="onPaginationSuccess(result,formID);">
                <input type="button" style="margin-left: 50px;" value="备份系统" class="btn btn-success" onclick="showBackForm()" />
            </div>
            <table class="table table-bordered table-condensed table-hover">
                <thead>
                    <tr>
                        <th>序号</th>
                        <th>备份名称</th>
                        <th>备份时间</th>
                        <th>大小</th>
                        <th>备注</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody id="BackupsContainer"></tbody>
            </table>
            <div id="BackupsPagination" data-tmpl="BackupsTmpl" data-container="BackupsContainer" data-pagesize="20" data-pageindex="1"></div>
        </div>
    </div>
</body>
</html>
