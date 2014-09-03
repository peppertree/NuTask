<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="frmNote.ascx.vb" Inherits="Peppertree.Solutions.NuTask.frmNote" %>
<%@ Register TagPrefix="dnnweb" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>

<dnnweb:DnnScriptBlock ID="ctlScripts" runat="server">
    <script type="text/javascript">
    function SelectTask(sender, args){
        var id = args.getDataKeyValue("TaskId");
        $find("<%= ctlAjax.ClientId %>").ajaxRequest('task_show|' + id);
    }
    </script>
</dnnweb:DnnScriptBlock>
<dnnweb:DnnAjaxPanel ID="ctlAjax" runat="server" LoadingPanelID="ctlLoading">

    <asp:Panel id="pnlError" runat="server" Visible="false" CssClass="dnnFormMessage dnnFormError">
        <asp:Literal ID="lblError" runat="server"></asp:Literal>
    </asp:Panel>

    <div id="pnlSelectProject" runat="server" class="dnnFormItem">
        <dnn:label id="lblSelectProject" runat="server" controlname="txtTaskName" CssClass="dnnFormRequired" />
        <dnn:DnnComboBox ID="drpProjects" runat="server" AutoPostBack="true" />
    </div>

    <div id="pnlSelectTask" runat="server" class="dnnFormItem">
        <dnn:label id="lblSelectTask" runat="server" controlname="drpTasks" CssClass="dnnFormRequired" />
        <dnn:DnnComboBox ID="drpTasks" runat="server" AutoPostBack="false" />
    </div>

    <div class="dnnFormItem" style="margin-top: 20px;">
        <dnn:label id="lblNote" runat="server" controlname="txtTaskName" CssClass="dnnFormRequired" />
        <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" Width="410px" Height="60px" />
    </div>

    <ul class="dnnActions dnnClear">
        <li>
            <asp:LinkButton ID="cmdAddNote" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdAddNote" />
        </li>
        <li>
            <asp:HyperLink ID="lnkCancel" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdCancel"></asp:HyperLink>
        </li>
    </ul>

</dnnweb:DnnAjaxPanel>

<dnnweb:DnnAjaxLoadingPanel ID="ctlLoading" runat="server" Skin="Default"></dnnweb:DnnAjaxLoadingPanel>

<script language="javascript" type="text/javascript">
    /*globals jQuery, window, Sys */
    (function ($, Sys) {
        function setupNuTaskForm() {
            $('#nutaskFrmTask').dnnPanels();
        }
        $(document).ready(function () {
            setupNuTaskForm();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                setupNuTaskForm();
            });
        });
    } (jQuery, window.Sys));
</script>