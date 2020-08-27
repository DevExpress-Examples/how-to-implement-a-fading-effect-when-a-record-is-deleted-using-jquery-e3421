<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to implement a fading effect when a record is deleted using jQuery</title>
	<script src="Scripts/jquery-1.6.1.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		var row = null;

		function grid_jQueryInit(s, e) {
			$("a.deleteLink").click(function () {
				$("#lbl").css("color", "green").text('Deleting...');

				var index = this.id.substring(3); // "lnk" length
				$(this).parents(".dxgvDataRow").fadeOut("slow", function () {
					row = $(this);
					grid.DeleteRow(index);
				});
			});
		}

		function grid_OnCallbackError(s, e) {
			$("#lbl").css("color", "red").text(e.message);
			e.handled = true;

			if (row != null) {
				$(row).fadeIn("fast");
				row = null;
			}
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" ClientInstanceName="grid"
			KeyFieldName="Id" OnDataBinding="grid_DataBinding" OnRowDeleting="grid_RowDeleting"
			Width="300px">
			<Columns>
				<dx:GridViewDataTextColumn VisibleIndex="0">
					<DataItemTemplate>
						<a id='lnk<%#Container.VisibleIndex%>' class="deleteLink" href="javascript:void(0);">
							Delete</a>
					</DataItemTemplate>
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="1">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataDateColumn FieldName="CurrentDate" VisibleIndex="3">
				</dx:GridViewDataDateColumn>
			</Columns>
			<SettingsLoadingPanel Mode="ShowOnStatusBar" />
			<Templates>
				<StatusBar>
					<label id="lbl" />
				</StatusBar>
			</Templates>
			<ClientSideEvents Init="grid_jQueryInit" EndCallback="grid_jQueryInit" CallbackError="grid_OnCallbackError" />
		</dx:ASPxGridView>
	</div>
	</form>
</body>
</html>