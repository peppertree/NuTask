<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="vwTask.ascx.vb" Inherits="Peppertree.Solutions.NuTask.vwTask" %>
<%@ Register TagPrefix="dnnweb" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>

<dnnweb:DnnAjaxPanel ID="ctlAjax" runat="server" LoadingPanelID="ctlLoading">
    
    <h2 class="nutaskhead"><asp:Literal ID="lblTaskValue_Title" runat="server"></asp:Literal></h2>
    
    <asp:Panel ID="pnlTaskView" runat="server">
        
        <table cellpadding="0" cellspacing="0" style="width:100%">
            <tr>

                <td style="vertical-align:top; width:50%;padding-right: 30px;">

                    <div id="nutaskTask" class="dnnForm dnnClear" >

                        <ul class="dnnAdminTabNav dnnClear">
                            <li><a href="#vwCommon"><asp:Literal ID="tabTask" runat="server"></asp:Literal></a></li>
                            <li><a href="#vwExpenses"><asp:Literal ID="tabExpenses" runat="server"></asp:Literal></a></li>
                        </ul>

                        <div class="dnnClear" id="vwCommon">
                    
                            <div class="nutaskplain description dnnClear">
                                <p>
                                    <asp:Literal ID="lblTaskValue_Description" runat="server"></asp:Literal>
                                </p>                        
                            </div>

                            <div class="notescontainer dnnClear">
                            
                                <h3 class="nutask_noteshead"><asp:Literal ID="lblViewTask_Notes" runat="server"></asp:Literal></h3>

                                <asp:Repeater ID="rptNotes" runat="server">
                                    <HeaderTemplate><ul></HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <span class="nutask_noteauthor"><%# DataBinder.Eval(Container.DataItem, "CreatedByName")%>:</span>
                                            <div class="nutask_noteitem"><%# DataBinder.Eval(Container.DataItem, "Entry")%></div>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate></ul></FooterTemplate>
                                </asp:Repeater>

                            </div>

                        </div>

                        <div class="dnnClear" id="vwExpenses">

                            <dnnweb:DnnGrid ID="grdTaskExpenses" runat="server">
            
                                <MasterTableView AutoGenerateColumns="false" AllowSorting="true" DataKeyNames="ExpenseId" ClientDataKeyNames="ExpenseId">
                                    <Columns>
                                        <dnn:DnnGridBoundColumn HeaderText="Title" DataField="Title"></dnn:DnnGridBoundColumn>
                                        <dnn:DnnGridBoundColumn HeaderText="Category" DataField="CategoryName" AllowSorting="true"></dnn:DnnGridBoundColumn>
                                        <dnn:DnnGridBoundColumn HeaderText="ExpenseDate" DataField="ExpenseDate" AllowSorting="true" DataFormatString="{0:d}"></dnn:DnnGridBoundColumn>
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
                                        <asp:Literal ID="lblTaskExpenseTotalValue" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </table>

                        </div>

                    </div>
                </td>

                <td style="vertical-align:top; width:50%;">

                    <div class="nutaskbox help dnnClear">

                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_Category" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_Category" runat="server"></asp:Literal></div>
                        </div>

                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_Status" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_Status" runat="server"></asp:Literal></div>
                        </div>

                    </div>

                    <div class="nutaskbox financial dnnClear">
                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_AmountAllowance" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_AmountAllowance" runat="server"></asp:Literal></div>
                        </div>
                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_AmountSpent" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_AmountSpent" runat="server"></asp:Literal></div>
                        </div>                  
                    </div>

                    <div class="nutaskbox timing dnnClear">

                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_EstimatedTime" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_EstimatedTime" runat="server"></asp:Literal></div>
                        </div>
                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_DueDate" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_DueDate" runat="server"></asp:Literal></div>
                        </div>
                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_StartDate" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_StartDate" runat="server"></asp:Literal></div>
                        </div>
                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_EndDate" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_EndDate" runat="server"></asp:Literal></div>
                        </div>
                                               
                    </div>

                    <div class="nutaskbox people dnnClear">
                   
                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_AssignedTo" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_AssignedTo" runat="server"></asp:Literal></div>
                        </div>
                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_AssignedDate" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_AssignedDate" runat="server"></asp:Literal></div>
                        </div>
                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_CreatedBy" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_CreatedBy" runat="server"></asp:Literal></div>
                        </div>
                        <div class="dnnFormItem">
                            <dnn:label id="lblViewTask_CreatedDate" runat="server" />
                            <div class="dnnLabel"><asp:Literal ID="lblTaskValue_CreatedDate" runat="server"></asp:Literal></div>
                        </div>

                    </div>

                    <ul class="dnnActions dnnClear dnnRight" runat="server">
                        <li>
                            <asp:HyperLink ID="lnkAddExpense" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdAddExpense" />
                        </li>
                        <li>
                            <asp:HyperLink ID="lnkAddNote" runat="server" CssClass="dnnPrimaryAction" resourcekey="cmdAddNote" />
                        </li>
                        <li>
                            <asp:HyperLink ID="lnkEditTask" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdEditTask" />
                        </li>
                        <li>
                            <asp:LinkButton ID="cmdDeleteTask" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdDeleteTask" />
                        </li>
                        <li>
                            <asp:HyperLink ID="lnkCancel" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdCancel" />
                        </li>

                    </ul>

                </td>

            </tr>
        </table>

    </asp:Panel>

    <asp:Panel ID="pnlTaskForm" runat="server">
    
    </asp:Panel>

</dnnweb:DnnAjaxPanel>

<dnnweb:DnnAjaxLoadingPanel ID="ctlLoading" runat="server" Skin="Default"></dnnweb:DnnAjaxLoadingPanel>

<script language="javascript" type="text/javascript">
    /*globals jQuery, window, Sys */
    (function ($, Sys) {
        function setupTaskView() {
            $('#nutaskTask').dnnTabs();
        }
        $(document).ready(function () {
            setupTaskView();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                setupTaskView();
            });
        });
    } (jQuery, window.Sys));
</script>