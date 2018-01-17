<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperationRecord.aspx.cs" Inherits="zx270.Web.SysManage.OperationRecord" %>

<%@ Import Namespace="zx270" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<style>
		#query_form * {
			vertical-align: middle;
		}
	</style>
	<script type="text/x-jquery-tmpl" id="OperationRecordTmpl">
		<tr>
			<td>${ID}</td>
			<td>${MID}</td>
			<td>${Level}</td>
			<td>${Role}</td>
			<td>${Time}</td>
			<td>${OperationType}</td>
			<td>${Operation}</td>
		</tr>
	</script>
</head>
<body>
	<div>
		<div data-pagination="pagination" id="query_form" data-ajaxform="true" data-action="/SysManage/OperationRecord.aspx?Opt=GetList" data-beforesubmit="getPaginationData(context); return true;" data-success="onPaginationSuccess(result,formID)" data-resulttype="json">
			<label>操作者：</label>
			<input type="text" name="MID" />
			<label>角色：</label>
			<select name="RoleCode" data-submit="true">
				<option value="">全部</option>
				<%foreach (var item in this.Roles)
					{ %>
				<option value="<%=item.RType %>"><%=item.RName %></option>
				<%} %>
			</select>
			<label>级别：</label>
			<select name="LevelCode" data-submit="true">
				<option value="">全部</option>
				<%foreach (var item in Config.SHMoneyList.Values)
					{ %>
				<%if (item._MAgencyName == "未激活会员") continue; %>
				<option value="<%=item.MAgencyType %>"><%=item._MAgencyName %></option>
				<%} %>
			</select>
			<label>操作类型：</label>
			<select name="TypeCode" data-submit="true">
				<option value="">所有</option>
				<%foreach (ChangeType ct in Enum.GetValues(typeof(ChangeType)).Cast<ChangeType>().Where(item => item.ToString().StartsWith("O_")))
					{ %>
				<option value="<%=ct.ToString() %>"><%=ct.Name() %></option>
				<%} %>
			</select>
			<label>开始时间:</label>
			<input type="text" name="StartTime" id="startDate" placeholder="开始时间" onfocus="if (value =='开始日期'){value =''}" class="daycash_input" style="width: 120px;" onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
			<label>结束时间:</label>
			<input type="text" name="EndTime" id="endDate" placeholder="结束时间" onfocus="if (value =='截止日期'){value =''}" class="daycash_input" style="width: 120px;" onclick="WdatePicker({ minDate: '#F{$dp.$D(\'startDate\')}' })" />
			<input type="button" class="btn btn-success" value="查询" data-submit="true" />
		</div>
		<div>
			<table class="table table-bordered table-striped table-hover table-condensed">
				<thead>
					<tr>
						<th>序号</th>
						<th>操作者</th>
						<th>级别</th>
						<th>角色</th>
						<th>操作时间</th>
						<th>操作类型</th>
						<th>操作</th>
					</tr>
				</thead>
				<tbody id="OperationRecordContainer">
				</tbody>
			</table>
			<div id="pagination" data-pagesize="20" data-pageindex="1" data-tmpl="OperationRecordTmpl" data-container="OperationRecordContainer"></div>
		</div>
	</div>
</body>
</html>
