Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Security.Roles
Imports Telerik.Web.UI

Namespace Peppertree.Solutions.NuTask
    Public Class List_Tasks
        Inherits NuTaskBase


#Region "Private Members"

#End Region

#Region "Event Handlers"

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            jQuery.RequestDnnPluginsRegistration()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            SetupForm()

            If Not Page.IsPostBack Then
                BindProject()
            End If

        End Sub

        Protected Sub grdTasks_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles grdTasks.NeedDataSource

            Dim ctrl As New TaskController
            Dim tasks As New List(Of TaskInfo)
            tasks = ctrl.ListByProject(Me.ProjectId)
            grdTasks.DataSource = tasks

        End Sub

        Sub ctlAjax_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles ctlAjax.AjaxRequest

            Dim strArgs As String = e.Argument

            Dim cmd As String = strArgs.Split(Char.Parse("|"))(0)
            Dim arg As String = strArgs.Split(Char.Parse("|"))(1)

            Select Case cmd.ToLower
                Case "task_show"
                    Response.Redirect(NavigateURL(TabId, "", "View=" & KEY_VIEWTASK, "TaskId=" & arg))
            End Select

        End Sub

#End Region

#Region "Private Methods"

        Private Sub BindProject()

            If ProjectId <> Null.NullInteger Then

                Dim objProject As ProjectInfo = ProjectController.Get(ProjectId)
                If Not objProject Is Nothing Then

                    lblProjectTitle.Text = objProject.ProjectName
                    lblProjectDescription.Text = objProject.Description
                    lblProjectBudgetValue.Text = objProject.AllocatedBudget.ToString("C")

                    lblProjectDueDateValue.Text = objProject.DueDate.ToShortDateString
                    

                    Dim dblTaskExpenses As Decimal = CDec(0.0)
                    Dim dblProjectExpenses As Decimal = CDec(0.0)
                    Dim dblAllExpenses As Decimal = CDec(0.0)

                    Dim lstExpenses As New List(Of ExpenseInfo)
                    lstExpenses = ExpenseController.ListByProject(ProjectId)

                    For Each objExpense As ExpenseInfo In lstExpenses
                        If objExpense.TaskId = Null.NullInteger Then
                            dblProjectExpenses += objExpense.Amount
                        Else
                            dblTaskExpenses += objExpense.Amount
                        End If
                        dblAllExpenses += objExpense.Amount
                    Next

                    Dim dblBalance As Decimal = objProject.AllocatedBudget - dblAllExpenses
                    Dim dblTasksBudget As Decimal = CDec(0.0)

                    For Each objTask As TaskInfo In TaskController.ListByProject(ProjectId)

                        Dim dblBudget As Decimal = objTask.AllocatedBudget
                        Dim dblSpent As Decimal = CDec(0.0)

                        Dim taskExpenses As List(Of ExpenseInfo) = ExpenseController.ListByTaskId(objTask.TaskId)
                        For Each taskExpense As ExpenseInfo In taskExpenses
                            dblSpent += taskExpense.Amount
                        Next

                        If objTask.StatusId = 1 Or objTask.StatusId = 2 Or objTask.StatusId = 3 Or objTask.StatusId = 8 Then
                            If dblBudget >= dblSpent Then
                                dblTasksBudget += dblBudget
                            Else
                                dblTasksBudget += dblSpent
                            End If
                        Else
                            dblTasksBudget += dblSpent
                        End If
                    Next

                    dblTasksBudget = dblTasksBudget - dblTaskExpenses - dblProjectExpenses

                    lblProjectExpensesValue.Text = dblProjectExpenses.ToString("C")
                    lblTaskExpensesValue.Text = dblTaskExpenses.ToString("C")
                    lblExpensesAllValue.Text = dblAllExpenses.ToString("C")
                    lblBalanceValue.Text = dblBalance.ToString("C")
                    lblTaskBudgetValue.Text = dblTasksBudget.ToString("C")

                    If dblAllExpenses > objProject.AllocatedBudget Then
                        lblExpensesAllValue.CssClass = "NuTaskExceedLabel"
                        lblBalanceValue.CssClass = "NuTaskExceedLabel"
                    Else
                        lblExpensesAllValue.CssClass = "NuTaskInRangeLabel"
                        lblBalanceValue.CssClass = "NuTaskInRangeLabel"
                    End If

                    If objProject.DueDate < Date.Now Then
                        lblProjectDueDateValue.CssClass = "NuTaskExceedLabel"
                    Else
                        lblProjectDueDateValue.CssClass = "NuTaskInRangeLabel"
                    End If

                    If (dblProjectExpenses + dblTaskExpenses) <= dblTasksBudget AndAlso dblTasksBudget <= objProject.AllocatedBudget Then
                        lblTaskBudgetValue.CssClass = "NuTaskInRangeLabel"
                    Else
                        lblTaskBudgetValue.CssClass = "NuTaskExceedLabel"
                    End If


                End If
            Else
                pnlProject.Visible = False
            End If

        End Sub

        Private Sub SetupForm()

            grdTasks.MasterTableView.NoMasterRecordsText = Localization.GetString("NoRecordsFound.Text", LocalResourceFile)
            pnlGridActions.Visible = (Request.IsAuthenticated = True)

            lnkAddExpense.NavigateUrl = EditUrl(KEY_EDITEXPENSE)
            lnkAddNote.NavigateUrl = EditUrl(KEY_EDITNOTE)
            lnkAddTask.NavigateUrl = EditUrl(KEY_EDITTASK)

            lnkExpensesAll.Text = LocalizeString("lblExpensesAll")
            lblProjectBudget.Text = LocalizeString("lblProjectBudget")
            lblProjectDueDate.Text = LocalizeString("lblProjectDueDate")
            lnkProjectExpenses.Text = LocalizeString("lblProjectExpenses")
            lnkTaskExpenses.Text = LocalizeString("lblTaskExpenses")
            lblBalance.Text = LocalizeString("lblBalance")
            lblTaskBudget.Text = LocalizeString("lblTaskBudget")
            lnkExpensesAll.NavigateUrl = NavigateURL(TabId, "", "View=" & KEY_LISTEXPENSES, "Mode=All")
            lnkProjectExpenses.NavigateUrl = NavigateURL(TabId, "", "View=" & KEY_LISTEXPENSES, "Mode=Project")
            lnkTaskExpenses.NavigateUrl = NavigateURL(TabId, "", "View=" & KEY_LISTEXPENSES, "Mode=Task")
        End Sub




#End Region

    End Class
End Namespace
