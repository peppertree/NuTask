
Namespace Peppertree.Solutions.NuTask.UserControls
    Public Class ucExpenseCategory
        Inherits System.Web.UI.UserControl


#Region "Private Members"

        Private _ProjectId As Integer = Null.NullInteger
        Private _CategoryId As Integer = Null.NullInteger

        Private ReadOnly Property LocalResourceFile
            Get
                Return "~/Desktopmodules/NuTask/App_LocalResources/SharedResources.ascx"
            End Get
        End Property

#End Region

#Region "Public Members"

        Public Property ProjectId As Integer
            Get
                Return _ProjectId
            End Get
            Set(ByVal value As Integer)
                _ProjectId = value
            End Set
        End Property


#End Region

#Region "Event Handlers"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        End Sub

#End Region

#Region "Private Methods"





#End Region


    End Class
End Namespace
