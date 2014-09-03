<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="frmTask.ascx.vb" Inherits="Peppertree.Solutions.NuTask.frmTask" %>
<%@ Register TagPrefix="dnnweb" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>


<dnnweb:DnnAjaxPanel ID="ctlAjax" runat="server" LoadingPanelID="ctlLoading">
    
    <div class="dnnForm dnnClear" id="nutaskFrmTask">
            
        <ul class="dnnAdminTabNav dnnClear">
            <li><a href="#vwBasicValues"><asp:Literal ID="tabBasicValues" runat="server"></asp:Literal></a></li>
            <li><a href="#vwFinacialValues"><asp:Literal ID="tabFinacialValues" runat="server"></asp:Literal></a></li>
            <li><a href="#vwTimingValues"><asp:Literal ID="tabTimingValues" runat="server"></asp:Literal></a></li>
        </ul>

        <div class="dnnClear" id="vwBasicValues">
            
            <fieldset>

                <asp:Panel id="pnlError" runat="server" Visible="false" CssClass="dnnFormMessage dnnFormError">
                    <asp:Literal ID="lblError" runat="server"></asp:Literal>
                </asp:Panel>

                <div class="dnnFormItem">
                    <dnn:label id="lblTaskName" runat="server" controlname="txtTaskName" CssClass="dnnFormRequired" />
                    <asp:TextBox ID="txtTaskName" runat="server" MaxLength="128" />
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblTaskDescription" runat="server" controlname="txtTaskDescription" />
                    <asp:TextBox ID="txtTaskDescription" runat="server" TextMode="MultiLine" />
                </div>

                <div id="pnlProject" runat="server" class="dnnFormItem">
                    <dnn:label id="lblProject" runat="server" controlname="txtTaskName" CssClass="dnnFormRequired" />
                    <dnn:DnnComboBox ID="drpProjects" runat="server" AutoPostBack="true" />
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblCategory" runat="server" controlname="drpCategories" CssClass="dnnFormRequired" />
                    <dnn:DnnComboBox ID="drpCategories" runat="server" AutoPostBack="false" AllowCustomText="true" />
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblStatus" runat="server" controlname="drpStatus" CssClass="dnnFormRequired" />
                    <dnn:DnnComboBox ID="drpStatus" runat="server" AutoPostBack="false" />
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblAssignedTo" runat="server" controlname="drpAssignedTo" />
                    <dnn:DnnComboBox ID="drpUsers" runat="server" AutoPostBack="false" />
                </div>

            </fieldset>
            
        </div>

        <div class="dnnClear" id="vwFinacialValues">
            
            <fieldset>

                <div class="dnnFormItem">
                    <dnn:label id="lblAllocatedBudget" runat="server" controlname="txtAllocatedBudget" />
                    <asp:TextBox ID="txtAllocatedBudget" runat="server" MaxLength="128" />
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblAllocatedExpenses" runat="server" controlname="txtAllocatedExpenses" />
                    <asp:TextBox ID="txtAllocatedExpenses" runat="server" MaxLength="128" Enabled="false" />
                </div>

            </fieldset>

        </div>

        <div class="dnnClear" id="vwTimingValues">

            <fieldset>

                <div class="dnnFormItem">
                    <dnn:label id="lblDueDate" runat="server" controlname="ctlDueDate" />
                    <dnn:DnnDatePicker ID="ctlDueDate" runat="server"/>
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblStartDate" runat="server" controlname="ctlStartDate" />
                    <dnn:DnnDatePicker ID="ctlStartDate" runat="server"/>
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblEndDate" runat="server" controlname="ctlEndDate" />
                    <dnn:DnnDatePicker ID="ctlEndDate" runat="server"/>
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblEstimatedTime" runat="server" controlname="txtEstimatedTime" />
                    <asp:TextBox ID="txtEstimatedTime" runat="server" MaxLength="128" />
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblEstimatedTimeUnit" runat="server" controlname="txtEstimatedTime" />
                    <dnn:DnnComboBox ID="drpEstimatedTimeUnit" runat="server" AutoPostBack="false" />
                </div>

            </fieldset>

        </div>

    </div>

        <ul class="dnnActions dnnClear" id="pnlTaskFormActions" runat="server">
            <li>
                <asp:LinkButton ID="cmdUpdateTask" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdUpdate" /></li>
            <li>
                <asp:LinkButton ID="cmdDeleteTask" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdDelete" /></li>
            <li>
                <asp:HyperLink ID="lnkCancelEdit" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdCancel" />
            </li>
        </ul>

</dnnweb:DnnAjaxPanel>

<dnnweb:DnnAjaxLoadingPanel ID="ctlLoading" runat="server" Skin="Default"></dnnweb:DnnAjaxLoadingPanel>

<script language="javascript" type="text/javascript">
    /*globals jQuery, window, Sys */
    (function ($, Sys) {
        function setupNuTaskForm() {
            $('#nutaskFrmTask').dnnTabs();
        }
        $(document).ready(function () {
            setupNuTaskForm();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                setupNuTaskForm();
            });
        });
    } (jQuery, window.Sys));
</script>