Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Security.Roles
Imports Telerik.Web.UI

Namespace Peppertree.Solutions.NuTask
    Public Class frmExpense
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

                BindCategories()
                BindProjects()
                BindTasks()

                If TaskId <> Null.NullInteger Then
                    drpTasks.SelectedValue = TaskId.ToString
                End If

                ctlExpenseDate.SelectedDate = Date.Now

                If ExpenseId <> Null.NullInteger Then
                    BindExpense()
                End If

            End If

        End Sub

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
            DeleteExpense()
            Response.Redirect(NavigateURL(TabId, "", "View=" & KEY_VIEWTASK, "TaskId=" & Convert.ToInt32(drpTasks.SelectedValue)))
        End Sub

        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

            Dim UpdatedExpenseId As Integer = Null.NullInteger
            UpdateExpense(UpdatedExpenseId)

            If UpdatedExpenseId <> Null.NullInteger Then
                Response.Redirect(NavigateURL(TabId, "", "View=" & KEY_VIEWTASK, "TaskId=" & Convert.ToInt32(drpTasks.SelectedValue)))
            End If

        End Sub

        Private Sub drpProjects_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles drpProjects.SelectedIndexChanged
            BindTasks()
        End Sub

#End Region

#Region "Private Methods"

        Public Sub BindCategories()

            Dim ctrl As New ExpenseCategoryController
            drpExpenseCategory.DataTextField = "Title"
            drpExpenseCategory.DataValueField = "CategoryId"
            drpExpenseCategory.DataSource = ctrl.ListByProject(ProjectId)
            drpExpenseCategory.DataBind()

            drpExpenseCategory.Text = Localization.GetString("EnterOrSelect", LocalResourceFile)

        End Sub

        Private Sub SetupForm()

            pnlSelectProject.Visible = (ProjectId = Null.NullInteger)
            cmdDelete.Visible = (ExpenseId <> Null.NullInteger)

            If TaskId <> Null.NullInteger Then
                lnkCancel.NavigateUrl = NavigateURL(TabId, "", "View=" & KEY_VIEWTASK, "TaskId=" & TaskId.ToString)
            Else
                lnkCancel.NavigateUrl = NavigateURL(TabId)
            End If

        End Sub

        Private Sub UpdateExpense(ByRef UpdatedExpenseId As Integer)

            Dim ExpenseText As String = txtExpenseText.Text
            If String.IsNullOrEmpty(ExpenseText) Then
                pnlError.Visible = True
                lblError.Text = LocalizeString("valExpenseText.ErrorMessage")
                Exit Sub
            End If

            Dim ExpenseDate As DateTime = ctlExpenseDate.DbSelectedDate
            If ctlExpenseDate.DbSelectedDate Is Nothing Then
                pnlError.Visible = True
                lblError.Text = LocalizeString("valExpenseDate.ErrorMessage")
                Exit Sub
            End If

            Dim ExpenseAmount As Decimal = Null.NullDecimal
            If Decimal.TryParse(txtExpenseAmount.Text, ExpenseAmount) = False Then
                pnlError.Visible = True
                lblError.Text = LocalizeString("valExpenseAmount.ErrorMessage")
                Exit Sub
            End If

            Dim ExpenseCategoryId As Integer = GetSelectedCategoryId()
            If ExpenseCategoryId = Null.NullInteger Then
                pnlError.Visible = True
                lblError.Text = LocalizeString("valExpenseCategory.ErrorMessage")
                Exit Sub
            End If

            Dim objExpense As ExpenseInfo = Nothing

            If ExpenseId <> Null.NullInteger Then
                objExpense = ExpenseController.Get(ExpenseId)
            Else
                objExpense = New ExpenseInfo
            End If

            objExpense.Amount = ExpenseAmount

            objExpense.Title = ExpenseText
            objExpense.CategoryId = ExpenseCategoryId
            objExpense.ExpenseDate = ExpenseDate
            objExpense.ImageUrl = ""
            objExpense.ProjectId = ProjectId
            objExpense.ReceiptNo = txtExpenseReceiptNumber.Text
            objExpense.TaskId = GetSelectedTaskId()

            Try

                If ExpenseId <> Null.NullInteger Then
                    ExpenseController.Update(objExpense)
                    UpdatedExpenseId = objExpense.ExpenseId
                Else
                    UpdatedExpenseId = ExpenseController.Add(objExpense)
                End If


                Dim lstTasks As List(Of TaskInfo) = TaskController.ListByProject(ProjectId)
                For Each objTask As TaskInfo In lstTasks

                    objTask.AllocatedExpenses = CDec(0.0)
                    Dim lstExpenses As List(Of ExpenseInfo) = ExpenseController.ListByTaskId(objTask.TaskId)
                    For Each chkExpense As ExpenseInfo In lstExpenses
                        objTask.AllocatedExpenses += chkExpense.Amount
                    Next
                    TaskController.Update(objTask)

                Next

            Catch ex As Exception
                pnlError.Visible = True
                lblError.Text = String.Format(LocalizeString("ExpenseUpdate.Error"), ex.Message)
                Exit Sub
            End Try

        End Sub

        Private Sub DeleteExpense()

            If ExpenseId <> Null.NullInteger Then
                ExpenseController.Delete(ExpenseId)
            End If

        End Sub

        Private Sub BindExpense()

            Dim objExpense As ExpenseInfo = Nothing
            Dim ctrl As New ExpenseController
            If ExpenseId <> Null.NullInteger Then
                objExpense = ctrl.Get(ExpenseId)
                If Not objExpense Is Nothing Then
                    txtExpenseText.Text = objExpense.Title
                    drpExpenseCategory.SelectedValue = objExpense.CategoryId.ToString
                    ctlExpenseDate.SelectedDate = objExpense.ExpenseDate
                    drpTasks.SelectedValue = objExpense.TaskId
                    txtExpenseAmount.Text = objExpense.Amount.ToString("f2")
                    txtExpenseReceiptNumber.Text = objExpense.ReceiptNo
                End If
            End If

        End Sub

        Private Sub BindTasks()

            drpTasks.DataTextField = "Title"
            drpTasks.DataValueField = "TaskId"

            If ProjectId <> Null.NullInteger Then
                drpTasks.DataSource = TaskController.ListByProject(ProjectId)
            Else
                drpTasks.DataSource = TaskController.ListByProject(Convert.ToInt32(drpProjects.SelectedValue))
            End If

            drpTasks.DataBind()
            drpTasks.Items.Insert(0, New RadComboBoxItem(LocalizeString("SelectOrEmpty"), "-1"))
        End Sub

        Private Sub BindProjects()

            drpProjects.DataTextField = "ProjectName"
            drpProjects.DataValueField = "ProjectId"
            drpProjects.DataSource = ProjectController.ListByPortals(PortalId)
            drpProjects.DataBind()

        End Sub

        Private Function GetSelectedTaskId() As Integer

            If drpTasks.SelectedIndex = Null.NullInteger AndAlso drpTasks.Text <> Localization.GetString("EnterOrSelect", LocalResourceFile) Then
                Return CreateTask()
            End If

            If drpTasks.SelectedIndex <> Null.NullInteger Then
                Return Convert.ToInt32(drpTasks.SelectedValue)
            End If

            Return Null.NullInteger

        End Function

        Private Function CreateTask() As Integer

            Dim strText As String = drpTasks.Text

            For Each objItem As RadComboBoxItem In drpTasks.Items
                If objItem.Text.ToLower = strText.ToLower Then
                    Return Convert.ToInt32(objItem.Value)
                End If
            Next

            Dim objTask As New TaskInfo
            objTask.CreatedBy = UserId
            objTask.CreatedDate = Date.Now
            objTask.AssignedTo = UserId
            objTask.AssignedDate = Date.Now
            objTask.AllocatedBudget = CDec(0.0)
            objTask.AllocatedExpenses = CDec(0.0)
            objTask.CategoryId = DefaultTaskCategoryId
            objTask.EstimatedTime = DefaultEstimatedTime
            objTask.EstimatedTimeUnit = DefaultEstimatedTimeUnit            
            objTask.StatusId = DefaultTaskStatusId
            objTask.Title = strText
            objTask.Descrition = Null.NullString
            objTask.DateEnd = Null.NullDate
            objTask.DateStart = Null.NullDate
            objTask.DueDate = Null.NullDate

            If ProjectId <> Null.NullInteger Then
                objTask.ProjectId = ProjectId
            Else
                objTask.ProjectId = Convert.ToInt32(drpProjects.SelectedValue)
            End If

            Dim id As Integer = Null.NullInteger
            id = New TaskController().Add(objTask)

            If id > 0 Then
                Return id
            End If

            Return Null.NullInteger

        End Function

        Private Function GetSelectedCategoryId() As Integer

            If drpExpenseCategory.SelectedIndex = Null.NullInteger AndAlso drpExpenseCategory.Text <> Localization.GetString("EnterOrSelect", LocalResourceFile) Then
                Return CreateCategory()
            End If

            If drpExpenseCategory.SelectedIndex <> Null.NullInteger Then
                Return Convert.ToInt32(drpExpenseCategory.SelectedValue)
            End If

            Return Null.NullInteger

        End Function

        Private Function CreateCategory() As Integer

            Dim strText As String = drpExpenseCategory.Text

            For Each objItem As RadComboBoxItem In drpExpenseCategory.Items
                If objItem.Text.ToLower = strText.ToLower Then
                    Return Convert.ToInt32(objItem.Value)
                End If
            Next

            Dim id As Integer = Null.NullInteger

            Dim objCategory As New ExpenseCategoryInfo
            objCategory.Title = strText
            objCategory.ProjectId = ProjectId
            objCategory.ViewOrder = 1
            id = New ExpenseCategoryController().Add(objCategory)

            If id > 0 Then
                Return id
            End If

            Return Null.NullInteger

        End Function

#End Region

    End Class
End Namespace
