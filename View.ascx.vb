Imports DotNetNuke.Entities.Modules

Namespace Peppertree.Solutions.NuTask

    Partial Class View
        Inherits NuTaskBase

#Region "Private Members"

        Private _controltoload As String = ""

#End Region

#Region "Event Handlers"

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            DotNetNuke.Framework.AJAX.RegisterScriptManager()
            ReadQueryString()
            LoadControlType()
        End Sub

#End Region

#Region "Private Methods"

        Private Sub ReadQueryString()

            _controltoload = Me.TemplateSourceDirectory & "/Controls/List_Tasks.ascx"

            If Not Request.QueryString("View") Is Nothing Then
                Select Case Request.QueryString("View")
                    Case KEY_LISTEXPENSES
                        _controltoload = Me.TemplateSourceDirectory & "/Controls/List_Expenses.ascx"
                    Case KEY_LISTPROJECTS
                        _controltoload = Me.TemplateSourceDirectory & "/Controls/List_Projects.ascx"
                    Case KEY_LISTTASKS
                        _controltoload = Me.TemplateSourceDirectory & "/Controls/List_Tasks.ascx"
                    Case KEY_EDITTASK
                        _controltoload = Me.TemplateSourceDirectory & "/Controls/frmTask.ascx"
                    Case KEY_EDITNOTE
                        _controltoload = Me.TemplateSourceDirectory & "/Controls/frmNote.ascx"
                    Case KEY_EDITEXPENSE
                        _controltoload = Me.TemplateSourceDirectory & "/Controls/frmExpense.ascx"
                    Case KEY_EDITPROJECT
                        _controltoload = Me.TemplateSourceDirectory & "/Controls/frmProject.ascx"
                    Case KEY_VIEWTASK
                        _controltoload = Me.TemplateSourceDirectory & "/Controls/vwTask.ascx"
                    Case Else
                        _controltoload = Me.TemplateSourceDirectory & "/Controls/List_Tasks.ascx"
                End Select
            End If

        End Sub

        Private Sub LoadControlType()

            Dim objPortalModuleBase As NuTaskBase = CType(Me.LoadControl(_controltoload), NuTaskBase)
            objPortalModuleBase.ModuleConfiguration = Me.ModuleConfiguration
            objPortalModuleBase.ID = System.IO.Path.GetFileNameWithoutExtension(_controltoload)
            ' Load the appropriate control
            '
            plhControls.Controls.Add(objPortalModuleBase)

        End Sub

#End Region


    End Class

End Namespace
