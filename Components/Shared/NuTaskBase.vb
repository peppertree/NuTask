Imports DotNetNuke.Entities.Modules

Namespace Peppertree.Solutions.NuTask
    Public Class NuTaskBase
        Inherits PortalModuleBase

#Region "Private Members"

        Private _TaskController As TaskController = Nothing
        Private _ExpenseController As ExpenseController = Nothing
        Private _NoteController As NoteController = Nothing
        Private _LogController As LogController = Nothing
        Private _ProjectController As ProjectController = Nothing

#End Region

#Region "Constants"

        Public Const KEY_VIEWTASK As String = "Task"

        Public Const KEY_LISTTASKS As String = "Tasks"
        Public Const KEY_LISTEXPENSES As String = "Expenses"
        Public Const KEY_LISTPROJECTS As String = "Projects"

        Public Const KEY_EDITTASK As String = "EditTask"
        Public Const KEY_EDITNOTE As String = "EditNote"
        Public Const KEY_EDITEXPENSE As String = "EditExpense"
        Public Const KEY_EDITPROJECT As String = "EditProject"

#End Region

#Region "Common Properties"

        Public ReadOnly Property ProjectId As Integer
            Get
                Dim _projectid As Integer = 1

                If Settings.Contains("ProjectId") Then
                    _projectid = CType(Settings("ProjectId"), Integer)
                End If

                If Not Request.QueryString("ProjectId") Is Nothing Then
                    _projectid = CType(Request.QueryString("ProjectId"), Integer)
                End If

                Return _projectid

            End Get
        End Property

        Public ReadOnly Property TaskId As Integer
            Get
                Dim _taskid As Integer = Null.NullInteger

                If Not Request.QueryString("TaskId") Is Nothing Then
                    _taskid = CType(Request.QueryString("TaskId"), Integer)
                End If

                Return _taskid

            End Get
        End Property

        Public ReadOnly Property NoteId As Integer
            Get
                Dim _noteid As Integer = Null.NullInteger

                If Not Request.QueryString("NoteId") Is Nothing Then
                    _noteid = CType(Request.QueryString("NoteId"), Integer)
                End If

                Return _noteid

            End Get
        End Property

        Public ReadOnly Property ExpenseId As Integer
            Get
                Dim _expenseid As Integer = Null.NullInteger

                If Not Request.QueryString("ExpenseId") Is Nothing Then
                    _expenseid = CType(Request.QueryString("ExpenseId"), Integer)
                End If

                Return _expenseid

            End Get
        End Property

#End Region

#Region "Helpers"

        Protected ReadOnly Property ProjectController As ProjectController
            Get
                If _ProjectController Is Nothing Then
                    _ProjectController = New ProjectController
                End If
                Return _ProjectController
            End Get

        End Property

        Protected ReadOnly Property TaskController As TaskController
            Get
                If _TaskController Is Nothing Then
                    _TaskController = New TaskController
                End If
                Return _TaskController
            End Get
        End Property

        Protected ReadOnly Property ExpenseController As ExpenseController
            Get
                If _ExpenseController Is Nothing Then
                    _ExpenseController = New ExpenseController
                End If
                Return _ExpenseController
            End Get
        End Property

        Protected ReadOnly Property NoteController As NoteController
            Get
                If _NoteController Is Nothing Then
                    _NoteController = New NoteController
                End If
                Return _NoteController
            End Get
        End Property

        Protected ReadOnly Property LogController As LogController
            Get
                If _LogController Is Nothing Then
                    _LogController = New LogController
                End If
                Return _LogController
            End Get
        End Property

#End Region

#Region "Defaults"

        Private _DefaultTaskCategoryId As Integer = 1
        Private _DefaultEstimatedTimeUnit As String = "d"
        Private _DefaultEstimatedTime As Integer = 1
        Private _DefaultTaskStatusId As Integer = 1

        Public Property DefaultTaskStatusId As Integer
            Get
                Return _DefaultTaskStatusId
            End Get
            Set(ByVal value As Integer)
                _DefaultTaskStatusId = value
            End Set

        End Property
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

        Public Property DefaultTaskCategoryId As Integer
            Get
                Return _DefaultTaskCategoryId
            End Get
            Set(ByVal value As Integer)
                _DefaultTaskCategoryId = value
            End Set
        End Property

#End Region

    End Class
End Namespace

