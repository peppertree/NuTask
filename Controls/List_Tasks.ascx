<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="List_Tasks.ascx.vb" Inherits="Peppertree.Solutions.NuTask.List_Tasks" %>
<%@ Register TagPrefix="dnnweb" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>


<dnnweb:DnnScriptBlock ID="ctlScripts" runat="server">
    
    <script type="text/javascript">

        function SelectTask(sender, args) {
            var id = args.getDataKeyValue("TaskId");
            $find("<%= ctlAjax.ClientId %>").ajaxRequest('task_show|' + id);
        }
    </script>

</dnnweb:DnnScriptBlock>
<dnnweb:DnnAjaxPanel ID="ctlAjax" runat="server" LoadingPanelID="ctlLoading">

    <asp:Panel ID="pnlProject" runat="server" CssClass="dnnClear">

        <div class="dnnLeft">
            <h2><asp:Literal ID="lblProjectTitle" runat="server"></asp:Literal></h2>
            <p><asp:Literal ID="lblProjectDescription" runat="server"></asp:Literal></p>
            <p><asp:Literal ID="lblProjectDueDate" runat="server"></asp:Literal> <asp:Label ID="lblProjectDueDateValue" runat="server"></asp:Label></p>
        </div>

        <div class="dnnRight">
            
 

            <table cellpadding="0" cellspacing="0" class="NuTask_ProjectSummary">
                <tr>
                    <td><asp:Literal ID="lblProjectBudget" runat="server"></asp:Literal></td>
                    <td><asp:Label ID="lblProjectBudgetValue" runat="server"></asp:Label></td>
                    <td><asp:Literal ID="lblTaskBudget" runat="server"></asp:Literal></td>
                    <td><asp:Label ID="lblTaskBudgetValue" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:HyperLink ID="lnkProjectExpenses" runat="server"></asp:HyperLink></td>
                    <td><asp:Label ID="lblProjectExpensesValue" runat="server"></asp:Label></td>
                    <td><asp:Hyperlink ID="lnkTaskExpenses" runat="server"></asp:Hyperlink></td>
                    <td><asp:Label ID="lblTaskExpensesValue" runat="server"></asp:Label></td>
                </tr>
                </table>
                <table cellpadding="0" cellspacing="0" class="NuTask_ProjectSummary">
                <tr>
                    <td class="nutask_sum"><asp:HyperLink ID="lnkExpensesAll" runat="server"></asp:HyperLink></td>
                    <td><asp:Label ID="lblExpensesAllValue" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="nutask_balance"><asp:Literal ID="lblBalance" runat="server"></asp:Literal></td>
                    <td class="nutask_balance"><asp:Label ID="lblBalanceValue" runat="server"></asp:Label></td>
                </tr>

            </table>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlTaskGrid" runat="server">

        <dnnweb:DnnGrid ID="grdTasks" runat="server" AllowPaging="true" PageSize="50">
            
            <MasterTableView AutoGenerateColumns="false" AllowSorting="true" DataKeyNames="TaskId" ClientDataKeyNames="TaskId" TableLayout="Auto" AllowPaging="true" PageSize="50">
                <Columns>
                    <dnn:DnnGridBoundColumn HeaderText="TaskName" DataField="Title"></dnn:DnnGridBoundColumn>
                    <dnn:DnnGridBoundColumn HeaderText="Category" DataField="CategoryName" AllowSorting="true"></dnn:DnnGridBoundColumn>
                    <dnn:DnnGridBoundColumn HeaderText="Allowance" DataField="AllocatedBudget" AllowSorting="true" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right"></dnn:DnnGridBoundColumn>
                    <dnn:DnnGridBoundColumn HeaderText="Spent" DataField="AllocatedExpenses" AllowSorting="true" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right"></dnn:DnnGridBoundColumn>
                    <dnn:DnnGridBoundColumn HeaderText="Status" DataField="StatusName" AllowSorting="true"></dnn:DnnGridBoundColumn>
                </Columns>               
            </MasterTableView>

            <ClientSettings>
                <ClientEvents OnRowDblClick="SelectTask" />
                <Scrolling UseStaticHeaders="false" AllowScroll="false" ScrollHeight="0" />
            </ClientSettings>

        </dnnweb:DnnGrid>

        <ul class="dnnActions dnnClear" id="pnlGridActions" runat="server">
            <li>
                <asp:HyperLink ID="lnkAddTask" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdAddTask" />
            </li>
            <li>
                <asp:HyperLink ID="lnkAddNote" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdAddNote" />
            </li>
            <li>
                <asp:HyperLink ID="lnkAddExpense" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdAddExpense" />
            </li>
        </ul>
        
    </asp:Panel>

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