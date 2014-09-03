Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Security.Roles
Imports Telerik.Web.UI

Namespace Peppertree.Solutions.NuTask
    Public Class frmNote
        Inherits NuTaskBase

#Region "Event Handlers"

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            SetupForm()


            If Not Page.IsPostBack Then

                BindProjects()
                BindTasks()

                If NoteId <> Null.NullInteger Then
                    BindNote()
                End If

            End If

        End Sub

        Private Sub cmdAddNote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddNote.Click
            Dim UpdatedTaskId As Integer = Null.NullInteger

            UpdateNote(UpdatedTaskId)

            If UpdatedTaskId <> Null.NullInteger Then
                Response.Redirect(NavigateURL(TabId, "", "View=" & KEY_VIEWTASK, "TaskId=" & UpdatedTaskId.ToString))
            End If

        End Sub

        Private Sub drpProjects_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles drpProjects.SelectedIndexChanged
            BindTasks()
        End Sub

#End Region

#Region "Private Methods"

        Private Sub SetupForm()

            pnlSelectProject.Visible = (ProjectId = Null.NullInteger)
            pnlSelectTask.Visible = (TaskId = Null.NullInteger)

            Dim cancelurl As String = NavigateURL(TabId)
            If TaskId <> Null.NullInteger Then
                cancelurl = NavigateURL(TabId, "", "View=" & KEY_VIEWTASK, "TaskId=" & TaskId.ToString)
            End If
            lnkCancel.NavigateUrl = cancelurl

        End Sub

        Private Sub BindProjects()

            drpProjects.DataTextField = "ProjectName"
            drpProjects.DataValueField = "ProjectId"
            drpProjects.DataSource = ProjectController.ListByPortals(PortalId)
            drpProjects.DataBind()

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
            drpTasks.Items.Insert(0, New RadComboBoxItem(LocalizeString("SelectTask"), "-1"))

        End Sub

        Private Sub BindNote()

        End Sub

        Private Sub UpdateNote(ByRef UpdatedTaskId As Integer)

            pnlError.Visible = False

            If txtNote.Text.Trim.Length = 0 Then
                pnlError.Visible = True
                lblError.Text = LocalizeString("valNote.ErrorMessage")
                Exit Sub
            End If

            If drpTasks.SelectedIndex = 0 AndAlso TaskId = Null.NullInteger Then
                pnlError.Visible = True
                lblError.Text = LocalizeString("valSelectTask.ErrorMessage")
                Exit Sub
            End If

            Dim objNote As NoteInfo = Nothing

            If NoteId <> Null.NullInteger Then
                objNote = NoteController.Get(NoteId)
            Else
                objNote = New NoteInfo
                objNote.CreatedBy = UserInfo.UserID
                objNote.CreatedDate = Date.Now
            End If

            If ProjectId <> Null.NullInteger Then
                objNote.ProjectId = ProjectId
            Else
                objNote.ProjectId = Convert.ToInt32(drpProjects.SelectedValue)
            End If

            If TaskId <> Null.NullInteger Then
                objNote.TaskId = TaskId
            Else
                If drpTasks.SelectedIndex <> Null.NullInteger Then
                    objNote.TaskId = Convert.ToInt32(drpTasks.SelectedValue)
                End If
            End If

            If txtNote.Text.Trim.Length > 0 Then
                objNote.Entry = txtNote.Text.Trim

                If NoteId <> Null.NullInteger Then
                    NoteController.Update(objNote)                    
                Else
                    NoteController.Add(objNote)
                End If

            End If

            UpdatedTaskId = objNote.TaskId

        End Sub

#End Region

    End Class
End Namespace
