<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="frmExpense.ascx.vb" Inherits="Peppertree.Solutions.NuTask.frmExpense" %>
<%@ Register TagPrefix="dnnweb" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>

<dnnweb:DnnAjaxPanel ID="ctlAjax" runat="server" LoadingPanelID="ctlLoading">


        <div class="dnnForm dnnClear" id="Div1">
            <fieldset>            

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

                <div class="dnnFormItem">
                    <dnn:label id="lblExpenseText" runat="server" controlname="txtExpenseText" CssClass="dnnFormRequired" />
                    <asp:TextBox ID="txtExpenseText" runat="server" MaxLength="128" />
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblExpenseDate" runat="server" controlname="ctlExpenseDate" CssClass="dnnFormRequired" />
                    <dnn:DnnDatePicker ID="ctlExpenseDate" runat="server"/>
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblExpenseCategory" runat="server" controlname="cboExpenseTypes" CssClass="dnnFormRequired" />                    
                    <dnn:DnnComboBox ID="drpExpenseCategory" runat="server" AutoPostBack="false" AllowCustomText="true" />
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblExpenseAmount" runat="server" controlname="txtExpenseAmount" CssClass="dnnFormRequired" />
                    <asp:TextBox ID="txtExpenseAmount" runat="server" MaxLength="128" />
                </div>

                <div class="dnnFormItem">
                    <dnn:label id="lblExpenseReceiptNumber" runat="server" controlname="txtExpenseReceiptNumber" />
                    <asp:TextBox ID="txtExpenseReceiptNumber" runat="server" MaxLength="128" />
                </div>

            </fieldset>
        </div>

        <ul class="dnnActions dnnClear" id="pnlExpenseFormActions" runat="server">
            <li>
                <asp:LinkButton ID="cmdUpdate" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdUpdateExpense" /></li>
            <li>
                <asp:LinkButton ID="cmdDelete" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdDeleteExpense" CausesValidation="False" /></li>
            <li>
                <asp:HyperLink ID="lnkCancel" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdCancel" />
            </li>
        </ul>

</dnnweb:DnnAjaxPanel>

<dnnweb:DnnAjaxLoadingPanel ID="ctlLoading" runat="server" Skin="Default"></dnnweb:DnnAjaxLoadingPanel>