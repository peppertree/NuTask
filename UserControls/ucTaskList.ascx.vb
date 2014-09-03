
Namespace Peppertree.Solutions.NuTask.UserControls
    Public Class ucTaskList
        Inherits System.Web.UI.UserControl


#Region "Private Members"

        Private _ProjectId As Integer = Null.NullInteger
        Private _TaskId As Integer = Null.NullInteger
        Private _DefaultUserId As Integer = Null.NullInteger
        Private _DefaultAssignedTo As Integer = Null.NullInteger
        Private _DefaultAssignedDate As DateTime = Null.NullDate
        Private _DefaultCategoryId As Integer = Null.NullInteger
        Private _DefaultStatusId As Integer = Null.NullInteger
        Private _DefaultEstimatedTime As Integer = 1
        Private _DefaultEstimatedTimeUnit As String = "d"

        Private ReadOnly Property LocalResourceFile
            Get
                Return "~/Desktopmodules/NuTask/App_LocalResources/SharedResources.ascx"
            End Get
        End Property

#End Region

#Region "Public Members"

        Public Property DefaultEstimatedTimeUnit As String
            Get
                Return _DefaultEstimatedTimeUnit
            End Get
            Set(ByVal value As String)
                _DefaultEstimatedTimeUnit = value
            End Set
        End Property

        Public Property DefaultEstimatedTime As Integer
            Get
                Return _DefaultEstimatedTime
            End Get
            Set(ByVal value As Integer)
                _DefaultEstimatedTime = value
            End Set
        End Property

        Public Property DefaultStatusId As Integer
            Get
                Return _DefaultStatusId
            End Get
            Set(ByVal value As Integer)
                _DefaultStatusId = value
            End Set
        End Property

        Public Property DefaultCategoryId As Integer
            Get
                Return _DefaultCategoryId
            End Get
            Set(ByVal value As Integer)
                _DefaultCategoryId = value
            End Set
        End Property

        Public Property DefaultUserId As Integer
            Get
                Return _DefaultUserId
            End Get
            Set(ByVal value As Integer)
                _DefaultUserId = value
            End Set
        End Property

        Public Property DefaultAssignedTo As Integer
            Get
                Return _DefaultAssignedTo
            End Get
            Set(ByVal value As Integer)
                _DefaultAssignedTo = value
            End Set
        End Property

        Public Property DefaultAssignedDate As DateTime
            Get
                Return _DefaultAssignedDate
            End Get
            Set(ByVal value As DateTime)
                _DefaultAssignedDate = value
            End Set
        End Property

        Public Property ProjectId As Integer
            Get
                Return _ProjectId
            End Get
            Set(ByVal value As Integer)
                _ProjectId = value
            End Set
        End Property

        Public Property TaskId As Integer
            Get

                Return _TaskId

            End Get
            Set(ByVal value As Integer)
                _TaskId = value
            End Set
        End Property

        Public ReadOnly Property TaskName
            Get
                Return ""
            End Get
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
