<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="List_Expenses.ascx.vb" Inherits="Peppertree.Solutions.NuTask.List_Expenses" %>
<%@ Register TagPrefix="dnnweb" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>


<dnnweb:DnnAjaxPanel ID="ctlAjax" runat="server" LoadingPanelID="ctlLoading">

        <asp:Panel ID="pnlFilter" runat="server">
        


            <table cellpadding="0" cellspacing="0" class="NuTask_FilterTable">
                <tr>
                    <td class="NuTask_FilterLabel">
                        <dnn:Label ID="lblExpenseFilterByType" runat="server" />
                    </td>
                    <td class="NuTask_FilterControl">
                        <dnnweb:DnnComboBox ID="drpFilter" runat="server" AutoPostBack="true">
                            <Items>
                                <dnn:DnnComboBoxItem Text="All" Value="all" />
                                <dnn:DnnComboBoxItem Text="Project" Value="project" />
                                <dnn:DnnComboBoxItem Text="Task" Value="task" />
                            </Items>
                        </dnnweb:DnnComboBox>                    
                    </td>
                    <td class="NuTask_FilterLabel">
                        <dnn:Label ID="lblExpenseFilterByCategory" runat="server" />
                    </td>
                   <td class="NuTask_FilterControl">
                        <dnnweb:DnnComboBox ID="drpCategories" runat="server" AutoPostBack="true">
                        </dnnweb:DnnComboBox>                     
                    </td>
                </tr>
            </table>

        </asp:Panel>

        <dnnweb:DnnGrid ID="grdExpenses" runat="server">
            
            <MasterTableView AutoGenerateColumns="false" AllowSorting="true" DataKeyNames="ExpenseId" ClientDataKeyNames="ExpenseId">
                <Columns>
                    <dnn:DnnGridBoundColumn HeaderText="Title" DataField="Title"></dnn:DnnGridBoundColumn>
                    <dnn:DnnGridBoundColumn HeaderText="Task" DataField="TaskTitle"></dnn:DnnGridBoundColumn>
                    <dnn:DnnGridBoundColumn HeaderText="Category" DataField="CategoryName" AllowSorting="true"></dnn:DnnGridBoundColumn>
                    <dnn:DnnGridBoundColumn HeaderText="ExpenseDate" DataField="ExpenseDate" AllowSorting="true" DataFormatString="{0:D}"></dnn:DnnGridBoundColumn>
                    <dnn:DnnGridBoundColumn HeaderText="Amount" DataField="Amount" AllowSorting="true" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right"></dnn:DnnGridBoundColumn>
                    <dnn:DnnGridTemplateColumn>
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# EditUrl("ExpenseId", Databinder.Eval(Container.DataItem, "ExpenseId"), "EditExpense") %>' Text='<%# LocalizeString("EditExpense") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </dnn:DnnGridTemplateColumn>
                </Columns>               
            </MasterTableView>

        </dnnweb:DnnGrid>

            <table cellpadding="0" cellspacing="0" class="NuTask_TotalTable">
                <tr>
                    <td class="NuTask_Label NormalBold">
                        <asp:Literal ID="lblExpenseTotal" runat="server"></asp:Literal>
                    </td>
                    <td class="NuTask_Value NormalBold">
                        <asp:Literal ID="lblExpenseTotalValue" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>

        <ul class="dnnActions dnnClear" id="pnlGridActions" runat="server">
            <li>
                <asp:HyperLink ID="lnkAddExpense" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdAddExpense" />
            </li>
        </ul>

</dnnweb:DnnAjaxPanel>

<dnnweb:DnnAjaxLoadingPanel ID="ctlLoading" runat="server" Skin="Default"></dnnweb:DnnAjaxLoadingPanel>
