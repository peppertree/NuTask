Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Security.Roles
Imports Telerik.Web.UI

Namespace Peppertree.Solutions.NuTask
    Public Class vwTask
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

                If TaskId <> Null.NullInteger Then
                    BindTask()
                    BindNotes()
                Else
                    Response.Redirect(NavigateURL(TabId))
                End If

            End If

        End Sub

        Private Sub cmdDeleteTask_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDeleteTask.Click
            DeleteTask()
            Response.Redirect(NavigateURL(TabId))
        End Sub

        Private Sub grdTaskExpenses_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles grdTaskExpenses.NeedDataSource
            BindExpenses()
        End Sub

#End Region

#Region "Private Methods"

        Private Sub SetupForm()

            lnkEditTask.Visible = (Request.IsAuthenticated = True)
            lnkAddExpense.Visible = (Request.IsAuthenticated = True)
            cmdDeleteTask.Visible = (Request.IsAuthenticated = True)
            lnkAddNote.Visible = (Request.IsAuthenticated = True)
            grdTaskExpenses.MasterTableView.NoMasterRecordsText = LocalizeString("NoExpensesFound")

            lblExpenseTotal.Text = LocalizeString("lblExpenseTotal")
            lblViewTask_Notes.Text = LocalizeString("lblViewTask_Notes")
            tabTask.Text = LocalizeString("tabTask")
            tabExpenses.Text = LocalizeString("tabExpenses")

            lnkEditTask.NavigateUrl = EditUrl("TaskId", TaskId.ToString, KEY_EDITTASK)
            lnkAddExpense.NavigateUrl = EditUrl("TaskId", TaskId.ToString, KEY_EDITEXPENSE)
            lnkAddNote.NavigateUrl = EditUrl("TaskId", TaskId.ToString, KEY_EDITNOTE)
            lnkCancel.NavigateUrl = NavigateURL(TabId)


        End Sub

        Private Sub BindTask()

            If TaskId <> Null.NullInteger Then

                Dim objTask As TaskInfo = TaskController.Get(TaskId)
                If Not objTask Is Nothing Then

                    lblTaskValue_Title.Text = objTask.Title
                    lblTaskValue_Category.Text = objTask.CategoryName
                    lblTaskValue_Description.Text = objTask.Descrition
                    lblTaskValue_Status.Text = objTask.StatusName
                    lblTaskValue_CreatedBy.Text = objTask.CreatedByName
                    lblTaskValue_CreatedDate.Text = objTask.CreatedDate.ToString
                    lblTaskValue_AmountAllowance.Text = objTask.AllocatedBudget.ToString("C")
                    'value taken from BindExpenses, more accurate...:-(
                    'lblTaskValue_AmountSpent.Text = objTask.AllocatedExpenses.ToString("C")

                    If objTask.AssignedDate = Null.NullDate Then
                        lblTaskValue_AssignedDate.Text = "-"
                    Else
                        lblTaskValue_AssignedDate.Text = objTask.AssignedDate.ToString
                    End If

                    If objTask.DateStart = Null.NullDate Then
                        lblTaskValue_StartDate.Text = "-"
                    Else
                        lblTaskValue_StartDate.Text = objTask.DateStart.ToShortDateString
                    End If

                    If objTask.DateEnd = Null.NullDate Then
                        lblTaskValue_EndDate.Text = "-"
                    Else
                        lblTaskValue_EndDate.Text = objTask.DateEnd.ToShortDateString
                    End If

                    If objTask.DueDate = Null.NullDate Then
                        lblTaskValue_DueDate.Text = "-"
                    Else
                        lblTaskValue_DueDate.Text = objTask.DueDate.ToShortDateString
                    End If


                    lblTaskValue_EstimatedTime.Text = objTask.EstimatedTime.ToString
                    Select Case objTask.EstimatedTimeUnit
                        Case "h"
                            lblTaskValue_EstimatedTime.Text += " " & LocalizeString("Hours.Text")
                        Case "d"
                            lblTaskValue_EstimatedTime.Text += " " & LocalizeString("Days.Text")
                        Case "w"
                            lblTaskValue_EstimatedTime.Text += " " & LocalizeString("Weeks.Text")
                        Case "m"
                            lblTaskValue_EstimatedTime.Text += " " & LocalizeString("Months.Text")
                    End Select

                    If String.IsNullOrEmpty(objTask.AssignedToName) Then
                        lblTaskValue_AssignedTo.Text = "-"
                    Else
                        lblTaskValue_AssignedTo.Text = objTask.AssignedToName
                    End If

                End If
            End If

        End Sub

        Private Sub DeleteTask()

            TaskController.Delete(TaskId)

        End Sub

        Private Sub BindNotes()

            Dim lstNotes As New List(Of NoteInfo)
            lstNotes = NoteController.ListByTaskId(TaskId)

            If lstNotes.Count > 0 Then
                rptNotes.DataSource = lstNotes
                rptNotes.DataBind()
                rptNotes.Visible = True
            Else
                rptNotes.Visible = False
            End If

        End Sub

        Private Sub BindExpenses()

            Dim lstExpenses As New List(Of ExpenseInfo)
            Dim lstView As New List(Of ExpenseInfo)
            lstExpenses = ExpenseController.ListByTaskId(TaskId)

            Dim dblTotal As Decimal = CDec(0.0)

            For Each objExpense As ExpenseInfo In lstExpenses

                dblTotal += objExpense.Amount

            Next

            grdTaskExpenses.DataSource = lstExpenses
            lblTaskExpenseTotalValue.Text = dblTotal.ToString("C")
            lblTaskValue_AmountSpent.Text = dblTotal.ToString("C")

        End Sub

#End Region

    End Class
End Namespace
