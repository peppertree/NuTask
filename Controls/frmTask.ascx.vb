Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Security.Roles
Imports Telerik.Web.UI

Namespace Peppertree.Solutions.NuTask
    Public Class frmTask
        Inherits NuTaskBase


#Region "Private Members"


#End Region

#Region "Event Handlers"

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            jQuery.RequestDnnPluginsRegistration()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            lnkCancelEdit.NavigateUrl = NavigateURL(TabId)
            Localize()
            SetupForm()

            If Not Page.IsPostBack Then

                BindProjects()
                BindCategories()
                BindTaskStatusList()
                BindAssignees()
                BindEstimatedTimeUnits()

                If TaskId <> Null.NullInteger Then
                    BindTask()
                End If

            End If

        End Sub

        Private Sub cmdDeleteTask_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDeleteTask.Click
            DeleteTask()
            Response.Redirect(NavigateURL(TabId))
        End Sub

        Private Sub cmdUpdateTask_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdateTask.Click

            Dim UpdatedTaskId As Integer = Null.NullInteger
            UpdateTask(UpdatedTaskId)

            If UpdatedTaskId <> Null.NullInteger Then
                Response.Redirect(NavigateURL(TabId, "", "View=" & KEY_VIEWTASK, "TaskId=" & UpdatedTaskId.ToString))
            End If

        End Sub

        Private Sub drpProjects_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles drpProjects.SelectedIndexChanged
            BindCategories()
            BindTaskStatusList()
            BindAssignees()            
        End Sub

#End Region

#Region "Private Methods"

        Private Sub SetupForm()
            pnlProject.Visible = (ProjectId = Null.NullInteger)
        End Sub

        Private Sub Localize()

            tabBasicValues.Text = LocalizeString("tabBasicValues")
            tabFinacialValues.Text = LocalizeString("tabFinacialValues")
            tabTimingValues.Text = LocalizeString("tabTimingValues")

        End Sub

        Private Sub BindTask()

            Dim objTask As TaskInfo = Nothing

            If TaskId <> Null.NullInteger Then
                objTask = TaskController.Get(TaskId)
                If Not objTask Is Nothing Then
                    drpProjects.SelectedValue = objTask.ProjectId.ToString
                    drpCategories.SelectedValue = objTask.CategoryId.ToString
                    drpStatus.SelectedValue = objTask.StatusId.ToString
                    drpUsers.SelectedValue = objTask.AssignedTo.ToString
                    If objTask.DateStart <> Null.NullDate Then
                        ctlStartDate.SelectedDate = objTask.DateStart
                    End If
                    If objTask.DateEnd <> Null.NullDate Then
                        ctlEndDate.SelectedDate = objTask.DateEnd
                    End If
                    If objTask.DueDate <> Null.NullDate Then
                        ctlDueDate.SelectedDate = objTask.DueDate
                    End If
                    txtAllocatedBudget.Text = Convert.ToString(objTask.AllocatedBudget)
                    txtAllocatedExpenses.Text = Convert.ToString(objTask.AllocatedExpenses)
                    txtTaskDescription.Text = objTask.Descrition
                    txtTaskName.Text = objTask.Title
                    txtEstimatedTime.Text = objTask.EstimatedTime
                    drpEstimatedTimeUnit.SelectedValue = objTask.EstimatedTimeUnit
                End If
            End If

        End Sub

        Private Sub BindCategories()

            Dim ctrl As New TaskCategoryController
            drpCategories.DataTextField = "Title"
            drpCategories.DataValueField = "CategoryId"
            drpCategories.DataSource = ctrl.ListByProject(ProjectId)
            drpCategories.DataBind()
            drpCategories.Text = LocalizeString("EnterOrSelect")

        End Sub

        Private Sub BindProjects()

            drpProjects.DataTextField = "ProjectName"
            drpProjects.DataValueField = "ProjectId"
            drpProjects.DataSource = ProjectController.ListByPortals(PortalId)
            drpProjects.DataBind()

        End Sub

        Private Sub BindTaskStatusList()

            Dim ctrl As New TaskStatusController
            drpStatus.DataTextField = "StatusName"
            drpStatus.DataValueField = "StatusId"
            drpStatus.DataSource = ctrl.ListByProject(ProjectId)
            drpStatus.DataBind()

        End Sub

        Private Sub BindEstimatedTimeUnits()

            drpEstimatedTimeUnit.Items.Clear()
            drpEstimatedTimeUnit.Items.Add(New Telerik.Web.UI.RadComboBoxItem(LocalizeString("Hours.Text"), "h"))
            drpEstimatedTimeUnit.Items.Add(New Telerik.Web.UI.RadComboBoxItem(LocalizeString("Days.Text"), "d"))
            drpEstimatedTimeUnit.Items.Add(New Telerik.Web.UI.RadComboBoxItem(LocalizeString("Weeks.Text"), "w"))
            drpEstimatedTimeUnit.Items.Add(New Telerik.Web.UI.RadComboBoxItem(LocalizeString("Months.Text"), "m"))

        End Sub

        Private Sub BindAssignees()

            Dim objProject As ProjectInfo    
            objProject = ProjectController.Get(ProjectId)

            Dim ctrl As New RoleController
            drpUsers.DataTextField = "DisplayName"
            drpUsers.DataValueField = "UserId"
            drpUsers.DataSource = ctrl.GetUsersByRoleName(PortalId, objProject.MemberRole)
            drpUsers.DataBind()
            drpUsers.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem(LocalizeString("SelectOrEmpty"), "-1"))

        End Sub

        Private Sub UpdateTask(ByRef UpdatedTaskId As Integer)

            Dim TaskTitle As String = txtTaskName.Text
            If String.IsNullOrEmpty(TaskTitle) Then
                pnlError.Visible = True
                lblError.Text = LocalizeString("valTaskName.ErrorMessage")
                Exit Sub
            End If

            Dim TaskCategory As Integer = GetSelectedCategoryId()
            If TaskCategory = Null.NullInteger Then
                pnlError.Visible = True
                lblError.Text = LocalizeString("valTaskCategory.ErrorMessage")
                Exit Sub
            End If

            Dim objTask As TaskInfo = Nothing

            If TaskId <> Null.NullInteger Then
                objTask = TaskController.Get(TaskId)

                If drpUsers.SelectedIndex = 0 Then
                    objTask.AssignedTo = Null.NullInteger
                    objTask.AssignedDate = Null.NullDate
                Else
                    objTask.AssignedTo = Convert.ToInt32(drpUsers.SelectedValue)
                    objTask.AssignedDate = Date.Now
                End If

            Else
                objTask = New TaskInfo
                objTask.CreatedBy = UserInfo.UserID
                objTask.CreatedDate = Date.Now

                If drpUsers.SelectedIndex > 0 Then
                    objTask.AssignedTo = Convert.ToInt32(drpUsers.SelectedValue)
                    objTask.AssignedDate = Date.Now
                Else
                    objTask.AssignedTo = Null.NullInteger
                    objTask.AssignedDate = Null.NullDate
                End If

            End If

            If Decimal.TryParse(txtAllocatedBudget.Text, objTask.AllocatedBudget) = False Then
                objTask.AllocatedBudget = Null.NullDecimal
            End If

            If ctlDueDate.IsEmpty = False Then
                objTask.DueDate = ctlDueDate.DbSelectedDate
            End If

            If ctlEndDate.IsEmpty = False Then
                objTask.DateEnd = ctlEndDate.DbSelectedDate
            End If

            If ctlStartDate.IsEmpty = False Then
                objTask.DateStart = ctlStartDate.DbSelectedDate
            End If

            If Decimal.TryParse(txtEstimatedTime.Text, objTask.EstimatedTime) Then
                objTask.EstimatedTimeUnit = drpEstimatedTimeUnit.SelectedValue
            Else
                objTask.EstimatedTimeUnit = Null.NullString
                objTask.EstimatedTime = Null.NullDecimal
            End If

            If ProjectId <> Null.NullInteger Then
                objTask.ProjectId = ProjectId
            Else
                objTask.ProjectId = Convert.ToInt32(drpProjects.SelectedValue)
            End If

            objTask.CategoryId = TaskCategory
            objTask.StatusId = Convert.ToInt32(drpStatus.SelectedValue)
            objTask.Title = txtTaskName.Text
            objTask.Descrition = txtTaskDescription.Text

            Try

                If TaskId <> Null.NullInteger AndAlso Not objTask Is Nothing Then
                    TaskController.Update(objTask)
                    UpdatedTaskId = TaskId
                Else
                    UpdatedTaskId = TaskController.Add(objTask)
                End If

            Catch ex As Exception
                pnlError.Visible = True
                lblError.Text = String.Format(LocalizeString("TaskUpdate.Error"), ex.Message)
                Exit Sub
            End Try


        End Sub

        Private Sub DeleteTask()
            If TaskId <> Null.NullInteger Then
                TaskController.Delete(TaskId)
            End If
        End Sub

        Private Function GetSelectedCategoryId() As Integer

            If drpCategories.SelectedIndex = Null.NullInteger AndAlso drpCategories.Text <> Localization.GetString("EnterOrSelect", LocalResourceFile) Then
                Return CreateCategory()
            End If

            If drpCategories.SelectedIndex <> Null.NullInteger Then
                Return Convert.ToInt32(drpCategories.SelectedValue)
            End If

            Return Null.NullInteger

        End Function

        Private Function CreateCategory() As Integer

            Dim strText As String = drpCategories.Text

            For Each objItem As RadComboBoxItem In drpCategories.Items
                If objItem.Text.ToLower = strText.ToLower Then
                    Return Convert.ToInt32(objItem.Value)
                End If
            Next

            Dim id As Integer = Null.NullInteger

            Dim objCategory As New TaskCategoryInfo
            objCategory.Title = strText
            objCategory.ProjectId = ProjectId
            objCategory.ViewOrder = 1
            id = New TaskCategoryController().Add(objCategory)

            If id > 0 Then
                Return id
            End If

            Return Null.NullInteger

        End Function

#End Region

    End Class
End Namespace
