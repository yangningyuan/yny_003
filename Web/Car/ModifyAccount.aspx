<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyAccount.aspx.cs" Inherits="yny_003.Web.Car.ModifyAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改结账单据</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
   
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <input type="hidden" id="fid" runat="server" />
                <input type="hidden" id="oid" runat="server" />
                <input type="hidden" id="type" runat="server" />
                <table cellpadding="0" cellspacing="0">
                    <tr style="display: none;">
                        <td width="15%" align="right"><input runat="server" id="Hidden1" type="hidden" />
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="ocode" class="normal_input" runat="server" readonly="readonly" style="width: 30%;" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td width="15%" align="right">单据号<input runat="server" id="lbID" type="hidden" />
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="CName" class="normal_input" readonly="readonly" runat="server" style="width: 30%;" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">客户或供应商<input runat="server" id="Hidden2" type="hidden" />
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="SuppName" class="normal_input" readonly="readonly" runat="server" style="width: 30%;" />
                        </td>
                    </tr>
                    


                  
                    <tr>
                        <td colspan="2">
                            <b style="margin-left: 5%;">商品信息</b>
                        </td>
                    </tr>

                    <tr>
                        <td width="15%" align="right">选择货物商品
                        </td>
                        <td width="75%" style="height: 40px;">
                          <input id="GoodName" class="normal_input" readonly="readonly" runat="server" style="width: 30%;" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">填写数量
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="txtGoodCount" class="normal_input" runat="server" style="width: 10%;" />
                          
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">填写价格
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="txtGoodPrice" class="normal_input" runat="server" style="width: 10%;" />
                            
                        </td>
                    </tr>
                
                    <tr>
                        <td align="right">更改备注
                        </td>
                        <td style="padding: 15px;">
                            <input id="Remark" class="normal_input" runat="server" style="width: 80%;"   />
                        </td>
                    </tr>
                
                    <tr>
                        <td width="15%" align="right"></td>
                        <td width="75%" align="left">

                            <input type="button" class="normal_btnok" value="修改" runat="server" onclick="checkChange();" />

                            <input type="button" class="normal_btnok" value="返回" runat="server" onclick="ReChange();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
       
                function checkChange() {
                    //if ($('#txtName').val() == '') {
                    //    v5.error('经费项目名称不能为空', '1', 'ture');
                    //} else {
                    ActionModel("Car/ModifyAccount.aspx?Action=Modify", $('#form1').serialize());
                    //}
                }

                function ReChange()
                {
                    var type = $("#type").val();
                   
                    if (type == "1") {
                        callhtml('/Car/AccountDownList.aspx', '收款单列表'); onclickMenu()
                    } else {
                        callhtml('/Car/AccountUPList.aspx', '付款单列表'); onclickMenu()
                    }
                    
                }
               
    </script>
</body>
</html>
