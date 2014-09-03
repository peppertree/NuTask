Namespace Peppertree.Solutions.NuTask

    Public Class ExpenseInfo

        Implements DotNetNuke.Entities.Modules.IHydratable

#Region "Private Members"
        Private _expenseId As Int32
        Private _categoryId As Int32
        Private _CategoryName As String
        Private _projectId As Int32
        Private _ProjectName As String
        Private _taskId As Int32 = Null.NullInteger
        Private _TaskTitle As String
        Private _expenseDate As DateTime
        Private _title As String
        Private _amount As Decimal
        Private _receiptNo As String
        Private _imageUrl As String
#End Region

#Region "Constructors"

        Public Sub New()
        End Sub

#End Region

#Region "Public Properties"
        Public Property ExpenseId() As Int32
            Get
                Return _expenseId
            End Get
            Set(ByVal Value As Int32)
                _expenseId = Value
            End Set
        End Property


        Public ReadOnly Property CategoryName() As String
            Get
                Return _CategoryName
            End Get
        End Property

        Public Property CategoryId() As Int32
            Get
                Return _categoryId
            End Get
            Set(ByVal Value As Int32)
                _categoryId = Value
            End Set
        End Property


        Public ReadOnly Property ProjectName() As String
            Get
                Return _ProjectName
            End Get
        End Property

        Public Property ProjectId() As Int32
            Get
                Return _projectId
            End Get
            Set(ByVal Value As Int32)
                _projectId = Value
            End Set
        End Property


        Public ReadOnly Property TaskTitle() As String
            Get
                Return _TaskTitle
            End Get
        End Property

        Public Property TaskId() As Int32
            Get
                Return _taskId
            End Get
            Set(ByVal Value As Int32)
                _taskId = Value
            End Set
        End Property



        Public Property ExpenseDate() As DateTime
            Get
                Return _expenseDate
            End Get
            Set(ByVal Value As DateTime)
                _expenseDate = Value
            End Set
        End Property



        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal Value As String)
                _title = Value
            End Set
        End Property



        Public Property Amount() As Decimal
            Get
                Return _amount
            End Get
            Set(ByVal Value As Decimal)
                _amount = Value
            End Set
        End Property



        Public Property ReceiptNo() As String
            Get
                Return _receiptNo
            End Get
            Set(ByVal Value As String)
                _receiptNo = Value
            End Set
        End Property



        Public Property ImageUrl() As String
            Get
                Return _imageUrl
            End Get
            Set(ByVal Value As String)
                _imageUrl = Value
            End Set
        End Property

        Public Sub Fill(ByVal dr As System.Data.IDataReader) Implements DotNetNuke.Entities.Modules.IHydratable.Fill

            Try
                _CategoryName = Convert.ToString(dr("CategoryName"))
            Catch
            End Try

            Try
                CategoryId = Convert.ToInt32(dr("CategoryId"))
            Catch
            End Try

            Try
                _ProjectName = Convert.ToString(dr("ProjectName"))
            Catch
            End Try

            Try
                ProjectId = Convert.ToInt32(dr("ProjectId"))
            Catch
            End Try

            Try
                _TaskTitle = Convert.ToString(dr("TaskTitle"))
            Catch
            End Try

            Try
                TaskId = Convert.ToInt32(dr("TaskId"))
            Catch
            End Try


            Try
                ExpenseDate = Convert.ToDateTime(dr("ExpenseDate"))
            Catch
            End Try


            Try
                Title = Convert.ToString(dr("Title"))
            Catch
            End Try


            Try
                Amount = Convert.Todecimal(dr("Amount"))
            Catch
            End Try


            Try
                ReceiptNo = Convert.ToString(dr("ReceiptNo"))
            Catch
            End Try


            Try
                ImageUrl = Convert.ToString(dr("ImageUrl"))
            Catch
            End Try
            Try
                ExpenseId = Convert.ToInt32(dr("ExpenseId"))
            Catch
            End Try
        End Sub

        Public Property KeyID() As Integer Implements DotNetNuke.Entities.Modules.IHydratable.KeyID
            Get
                Return _expenseId
            End Get
            Set(ByVal value As Integer)
                _expenseId = Value
            End Set
        End Property
#End Region

    End Class

    Public Class ExpenseCategoryInfo

        Implements DotNetNuke.Entities.Modules.IHydratable

#Region "Private Members"
        Private _categoryId As Int32
        Private _projectId As Int32
        Private _ProjectName As String
        Private _title As String
        Private _viewOrder As Int32
#End Region

#Region "Constructors"

        Public Sub New()
        End Sub

#End Region

#Region "Public Properties"
        Public Property CategoryId() As Int32
            Get
                Return _categoryId
            End Get
            Set(ByVal Value As Int32)
                _categoryId = Value
            End Set
        End Property


        Public ReadOnly Property ProjectName() As String
            Get
                Return _ProjectName
            End Get
        End Property

        Public Property ProjectId() As Int32
            Get
                Return _projectId
            End Get
            Set(ByVal Value As Int32)
                _projectId = Value
            End Set
        End Property



        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal Value As String)
                _title = Value
            End Set
        End Property



        Public Property ViewOrder() As Int32
            Get
                Return _viewOrder
            End Get
            Set(ByVal Value As Int32)
                _viewOrder = Value
            End Set
        End Property

        Public Sub Fill(ByVal dr As System.Data.IDataReader) Implements DotNetNuke.Entities.Modules.IHydratable.Fill

            Try
                _ProjectName = Convert.ToString(dr("ProjectName"))
            Catch
            End Try

            Try
                ProjectId = Convert.ToInt32(dr("ProjectId"))
            Catch
            End Try


            Try
                Title = Convert.ToString(dr("Title"))
            Catch
            End Try


            Try
                ViewOrder = Convert.ToInt32(dr("ViewOrder"))
            Catch
            End Try
            Try
                CategoryId = Convert.ToInt32(dr("CategoryId"))
            Catch
            End Try
        End Sub

        Public Property KeyID() As Integer Implements DotNetNuke.Entities.Modules.IHydratable.KeyID
            Get
                Return _categoryId
            End Get
            Set(ByVal value As Integer)
                _categoryId = Value
            End Set
        End Property
#End Region

    End Class

    Public Class LogInfo

        Implements DotNetNuke.Entities.Modules.IHydratable

#Region "Private Members"
        Private _logEntryId As Int32
        Private _projectId As Int32
        Private _taskId As Int32
        Private _noteId As Int32
        Private _expenseId As Int32
        Private _logDate As DateTime
        Private _logType As String
        Private _logEntry As String
#End Region

#Region "Constructors"

        Public Sub New()
        End Sub

#End Region

#Region "Public Properties"
        Public Property LogEntryId() As Int32
            Get
                Return _logEntryId
            End Get
            Set(ByVal Value As Int32)
                _logEntryId = Value
            End Set
        End Property



        Public Property ProjectId() As Int32
            Get
                Return _projectId
            End Get
            Set(ByVal Value As Int32)
                _projectId = Value
            End Set
        End Property



        Public Property TaskId() As Int32
            Get
                Return _taskId
            End Get
            Set(ByVal Value As Int32)
                _taskId = Value
            End Set
        End Property



        Public Property NoteId() As Int32
            Get
                Return _noteId
            End Get
            Set(ByVal Value As Int32)
                _noteId = Value
            End Set
        End Property



        Public Property ExpenseId() As Int32
            Get
                Return _expenseId
            End Get
            Set(ByVal Value As Int32)
                _expenseId = Value
            End Set
        End Property



        Public Property LogDate() As DateTime
            Get
                Return _logDate
            End Get
            Set(ByVal Value As DateTime)
                _logDate = Value
            End Set
        End Property



        Public Property LogType() As String
            Get
                Return _logType
            End Get
            Set(ByVal Value As String)
                _logType = Value
            End Set
        End Property



        Public Property LogEntry() As String
            Get
                Return _logEntry
            End Get
            Set(ByVal Value As String)
                _logEntry = Value
            End Set
        End Property

        Public Sub Fill(ByVal dr As System.Data.IDataReader) Implements DotNetNuke.Entities.Modules.IHydratable.Fill


            Try
                ProjectId = Convert.ToInt32(dr("ProjectId"))
            Catch
            End Try


            Try
                TaskId = Convert.ToInt32(dr("TaskId"))
            Catch
            End Try


            Try
                NoteId = Convert.ToInt32(dr("NoteId"))
            Catch
            End Try


            Try
                ExpenseId = Convert.ToInt32(dr("ExpenseId"))
            Catch
            End Try


            Try
                LogDate = Convert.ToDateTime(dr("LogDate"))
            Catch
            End Try


            Try
                LogType = Convert.ToString(dr("LogType"))
            Catch
            End Try


            Try
                LogEntry = Convert.ToString(dr("LogEntry"))
            Catch
            End Try
            Try
                LogEntryId = Convert.ToInt32(dr("LogEntryId"))
            Catch
            End Try
        End Sub

        Public Property KeyID() As Integer Implements DotNetNuke.Entities.Modules.IHydratable.KeyID
            Get
                Return _logEntryId
            End Get
            Set(ByVal value As Integer)
                _logEntryId = Value
            End Set
        End Property
#End Region

    End Class

    Public Class NoteInfo

        Implements DotNetNuke.Entities.Modules.IHydratable

#Region "Private Members"
        Private _noteId As Int32
        Private _projectId As Int32
        Private _ProjectName As String
        Private _taskId As Int32 = Null.NullInteger
        Private _TaskTitle As String
        Private _createdBy As Int32
        Private _CreatedByName As String
        Private _createdDate As DateTime
        Private _entry As String
#End Region

#Region "Constructors"

        Public Sub New()
        End Sub

#End Region

#Region "Public Properties"
        Public Property NoteId() As Int32
            Get
                Return _noteId
            End Get
            Set(ByVal Value As Int32)
                _noteId = Value
            End Set
        End Property


        Public ReadOnly Property ProjectName() As String
            Get
                Return _ProjectName
            End Get
        End Property

        Public Property ProjectId() As Int32
            Get
                Return _projectId
            End Get
            Set(ByVal Value As Int32)
                _projectId = Value
            End Set
        End Property


        Public ReadOnly Property TaskTitle() As String
            Get
                Return _TaskTitle
            End Get
        End Property

        Public Property TaskId() As Int32
            Get
                Return _taskId
            End Get
            Set(ByVal Value As Int32)
                _taskId = Value
            End Set
        End Property


        Public ReadOnly Property CreatedByName() As String
            Get
                Return _CreatedByName
            End Get
        End Property

        Public Property CreatedBy() As Int32
            Get
                Return _createdBy
            End Get
            Set(ByVal Value As Int32)
                _createdBy = Value
            End Set
        End Property



        Public Property CreatedDate() As DateTime
            Get
                Return _createdDate
            End Get
            Set(ByVal Value As DateTime)
                _createdDate = Value
            End Set
        End Property



        Public Property Entry() As String
            Get
                Return _entry
            End Get
            Set(ByVal Value As String)
                _entry = Value
            End Set
        End Property

        Public Sub Fill(ByVal dr As System.Data.IDataReader) Implements DotNetNuke.Entities.Modules.IHydratable.Fill

            Try
                _ProjectName = Convert.ToString(dr("ProjectName"))
            Catch
            End Try

            Try
                ProjectId = Convert.ToInt32(dr("ProjectId"))
            Catch
            End Try

            Try
                _TaskTitle = Convert.ToString(dr("TaskTitle"))
            Catch
            End Try

            Try
                TaskId = Convert.ToInt32(dr("TaskId"))
            Catch
            End Try

            Try
                _CreatedByName = Convert.ToString(dr("CreatedByName"))
            Catch
            End Try

            Try
                CreatedBy = Convert.ToInt32(dr("CreatedBy"))
            Catch
            End Try


            Try
                CreatedDate = Convert.ToDateTime(dr("CreatedDate"))
            Catch
            End Try


            Try
                Entry = Convert.ToString(dr("Entry"))
            Catch
            End Try
            Try
                NoteId = Convert.ToInt32(dr("NoteId"))
            Catch
            End Try
        End Sub

        Public Property KeyID() As Integer Implements DotNetNuke.Entities.Modules.IHydratable.KeyID
            Get
                Return _noteId
            End Get
            Set(ByVal value As Integer)
                _noteId = Value
            End Set
        End Property
#End Region

    End Class

    Public Class ProjectInfo

        Implements DotNetNuke.Entities.Modules.IHydratable

#Region "Private Members"
        Private _projectId As Int32
        Private _portalId As Int32
        Private _projectName As String
        Private _description As String
        Private _allocatedBudget As Decimal
        Private _dueDate As DateTime
        Private _memberRole As String
#End Region

#Region "Constructors"

        Public Sub New()
        End Sub

#End Region

#Region "Public Properties"
        Public Property ProjectId() As Int32
            Get
                Return _projectId
            End Get
            Set(ByVal Value As Int32)
                _projectId = Value
            End Set
        End Property



        Public Property PortalId() As Int32
            Get
                Return _portalId
            End Get
            Set(ByVal Value As Int32)
                _portalId = Value
            End Set
        End Property



        Public Property ProjectName() As String
            Get
                Return _projectName
            End Get
            Set(ByVal Value As String)
                _projectName = Value
            End Set
        End Property



        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property



        Public Property AllocatedBudget() As Decimal
            Get
                Return _allocatedBudget
            End Get
            Set(ByVal Value As Decimal)
                _allocatedBudget = Value
            End Set
        End Property



        Public Property DueDate() As DateTime
            Get
                Return _dueDate
            End Get
            Set(ByVal Value As DateTime)
                _dueDate = Value
            End Set
        End Property



        Public Property MemberRole() As String
            Get
                Return _memberRole
            End Get
            Set(ByVal Value As String)
                _memberRole = Value
            End Set
        End Property

        Public Sub Fill(ByVal dr As System.Data.IDataReader) Implements DotNetNuke.Entities.Modules.IHydratable.Fill


            Try
                PortalId = Convert.ToInt32(dr("PortalId"))
            Catch
            End Try


            Try
                ProjectName = Convert.ToString(dr("ProjectName"))
            Catch
            End Try


            Try
                Description = Convert.ToString(dr("Description"))
            Catch
            End Try


            Try
                AllocatedBudget = Convert.Todecimal(dr("AllocatedBudget"))
            Catch
            End Try


            Try
                DueDate = Convert.ToDateTime(dr("DueDate"))
            Catch
            End Try


            Try
                MemberRole = Convert.ToString(dr("MemberRole"))
            Catch
            End Try
            Try
                ProjectId = Convert.ToInt32(dr("ProjectId"))
            Catch
            End Try
        End Sub

        Public Property KeyID() As Integer Implements DotNetNuke.Entities.Modules.IHydratable.KeyID
            Get
                Return _projectId
            End Get
            Set(ByVal value As Integer)
                _projectId = Value
            End Set
        End Property
#End Region

    End Class

    Public Class TaskInfo

        Implements DotNetNuke.Entities.Modules.IHydratable

#Region "Private Members"
        Private _taskId As Int32
        Private _projectId As Int32
        Private _ProjectName As String
        Private _categoryId As Int32
        Private _CategoryName As String
        Private _statusId As Int32
        Private _StatusName As String
        Private _createdBy As Int32
        Private _CreatedByName As String
        Private _createdDate As DateTime
        Private _assignedTo As Int32
        Private _AssignedToName As String
        Private _assignedDate As DateTime
        Private _title As String
        Private _descrition As String
        Private _estimatedTime As Decimal
        Private _estimatedTimeUnit As String
        Private _dateStart As DateTime
        Private _dateEnd As DateTime
        Private _dueDate As DateTime
        Private _allocatedBudget As Decimal = CDec(0.0)
        Private _allocatedExpenses As Decimal = CDec(0.0)
#End Region

#Region "Constructors"

        Public Sub New()
        End Sub

#End Region

#Region "Public Properties"

        Public Property TaskId() As Int32
            Get
                Return _taskId
            End Get
            Set(ByVal Value As Int32)
                _taskId = Value
            End Set
        End Property

        Public ReadOnly Property ProjectName() As String
            Get
                Return _ProjectName
            End Get
        End Property

        Public Property ProjectId() As Int32
            Get
                Return _projectId
            End Get
            Set(ByVal Value As Int32)
                _projectId = Value
            End Set
        End Property

        Public ReadOnly Property CategoryName() As String
            Get
                Return _CategoryName
            End Get
        End Property

        Public Property CategoryId() As Int32
            Get
                Return _categoryId
            End Get
            Set(ByVal Value As Int32)
                _categoryId = Value
            End Set
        End Property


        Public ReadOnly Property StatusName() As String
            Get
                Return _StatusName
            End Get
        End Property

        Public Property StatusId() As Int32
            Get
                Return _statusId
            End Get
            Set(ByVal Value As Int32)
                _statusId = Value
            End Set
        End Property


        Public ReadOnly Property CreatedByName() As String
            Get
                Return _CreatedByName
            End Get
        End Property

        Public Property CreatedBy() As Int32
            Get
                Return _createdBy
            End Get
            Set(ByVal Value As Int32)
                _createdBy = Value
            End Set
        End Property



        Public Property CreatedDate() As DateTime
            Get
                Return _createdDate
            End Get
            Set(ByVal Value As DateTime)
                _createdDate = Value
            End Set
        End Property


        Public ReadOnly Property AssignedToName() As String
            Get
                Return _AssignedToName
            End Get
        End Property

        Public Property AssignedTo() As Int32
            Get
                Return _assignedTo
            End Get
            Set(ByVal Value As Int32)
                _assignedTo = Value
            End Set
        End Property



        Public Property AssignedDate() As DateTime
            Get
                Return _assignedDate
            End Get
            Set(ByVal Value As DateTime)
                _assignedDate = Value
            End Set
        End Property



        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal Value As String)
                _title = Value
            End Set
        End Property



        Public Property Descrition() As String
            Get
                Return _descrition
            End Get
            Set(ByVal Value As String)
                _descrition = Value
            End Set
        End Property



        Public Property EstimatedTime() As Decimal
            Get
                Return _estimatedTime
            End Get
            Set(ByVal Value As Decimal)
                _estimatedTime = Value
            End Set
        End Property



        Public Property EstimatedTimeUnit() As String
            Get
                Return _estimatedTimeUnit
            End Get
            Set(ByVal Value As String)
                _estimatedTimeUnit = Value
            End Set
        End Property



        Public Property DateStart() As DateTime
            Get
                Return _dateStart
            End Get
            Set(ByVal Value As DateTime)
                _dateStart = Value
            End Set
        End Property



        Public Property DateEnd() As DateTime
            Get
                Return _dateEnd
            End Get
            Set(ByVal Value As DateTime)
                _dateEnd = Value
            End Set
        End Property



        Public Property DueDate() As DateTime
            Get
                Return _dueDate
            End Get
            Set(ByVal Value As DateTime)
                _dueDate = Value
            End Set
        End Property



        Public Property AllocatedBudget() As Decimal
            Get
                Return _allocatedBudget
            End Get
            Set(ByVal Value As Decimal)
                _allocatedBudget = Value
            End Set
        End Property



        Public Property AllocatedExpenses() As Decimal
            Get
                Return _allocatedExpenses
            End Get
            Set(ByVal Value As Decimal)
                _allocatedExpenses = Value
            End Set
        End Property

        Public Sub Fill(ByVal dr As System.Data.IDataReader) Implements DotNetNuke.Entities.Modules.IHydratable.Fill

            Try
                _ProjectName = Convert.ToString(dr("ProjectName"))
            Catch
            End Try

            Try
                ProjectId = Convert.ToInt32(dr("ProjectId"))
            Catch
            End Try

            Try
                _CategoryName = Convert.ToString(dr("CategoryName"))
            Catch
            End Try

            Try
                CategoryId = Convert.ToInt32(dr("CategoryId"))
            Catch
            End Try

            Try
                _StatusName = Convert.ToString(dr("StatusName"))
            Catch
            End Try

            Try
                StatusId = Convert.ToInt32(dr("StatusId"))
            Catch
            End Try

            Try
                _CreatedByName = Convert.ToString(dr("CreatedByName"))
            Catch
            End Try

            Try
                CreatedBy = Convert.ToInt32(dr("CreatedBy"))
            Catch
            End Try


            Try
                CreatedDate = Convert.ToDateTime(dr("CreatedDate"))
            Catch
            End Try

            Try
                _AssignedToName = Convert.ToString(dr("AssignedToName"))
            Catch
            End Try

            Try
                AssignedTo = Convert.ToInt32(dr("AssignedTo"))
            Catch
            End Try


            Try
                AssignedDate = Convert.ToDateTime(dr("AssignedDate"))
            Catch
            End Try


            Try
                Title = Convert.ToString(dr("Title"))
            Catch
            End Try


            Try
                Descrition = Convert.ToString(dr("Descrition"))
            Catch
            End Try


            Try
                EstimatedTime = Convert.ToDecimal(dr("EstimatedTime"))
            Catch
            End Try


            Try
                EstimatedTimeUnit = Convert.ToString(dr("EstimatedTimeUnit"))
            Catch
            End Try


            Try
                DateStart = Convert.ToDateTime(dr("DateStart"))
            Catch
            End Try


            Try
                DateEnd = Convert.ToDateTime(dr("DateEnd"))
            Catch
            End Try


            Try
                DueDate = Convert.ToDateTime(dr("DueDate"))
            Catch
            End Try


            Try
                AllocatedBudget = Convert.ToDecimal(dr("AllocatedBudget"))
            Catch
            End Try


            Try
                AllocatedExpenses = Convert.ToDecimal(dr("AllocatedExpenses"))
            Catch
            End Try
            Try
                TaskId = Convert.ToInt32(dr("TaskId"))
            Catch
            End Try
        End Sub

        Public Property KeyID() As Integer Implements DotNetNuke.Entities.Modules.IHydratable.KeyID
            Get
                Return _taskId
            End Get
            Set(ByVal value As Integer)
                _taskId = value
            End Set
        End Property
#End Region

    End Class

    Public Class TaskCategoryInfo

        Implements DotNetNuke.Entities.Modules.IHydratable

#Region "Private Members"
        Private _categoryId As Int32
        Private _projectId As Int32
        Private _ProjectName As String
        Private _title As String
        Private _viewOrder As Int32
#End Region

#Region "Constructors"

        Public Sub New()
        End Sub

#End Region

#Region "Public Properties"
        Public Property CategoryId() As Int32
            Get
                Return _categoryId
            End Get
            Set(ByVal Value As Int32)
                _categoryId = Value
            End Set
        End Property


        Public ReadOnly Property ProjectName() As String
            Get
                Return _ProjectName
            End Get
        End Property

        Public Property ProjectId() As Int32
            Get
                Return _projectId
            End Get
            Set(ByVal Value As Int32)
                _projectId = Value
            End Set
        End Property



        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal Value As String)
                _title = Value
            End Set
        End Property



        Public Property ViewOrder() As Int32
            Get
                Return _viewOrder
            End Get
            Set(ByVal Value As Int32)
                _viewOrder = Value
            End Set
        End Property

        Public Sub Fill(ByVal dr As System.Data.IDataReader) Implements DotNetNuke.Entities.Modules.IHydratable.Fill

            Try
                _ProjectName = Convert.ToString(dr("ProjectName"))
            Catch
            End Try

            Try
                ProjectId = Convert.ToInt32(dr("ProjectId"))
            Catch
            End Try


            Try
                Title = Convert.ToString(dr("Title"))
            Catch
            End Try


            Try
                ViewOrder = Convert.ToInt32(dr("ViewOrder"))
            Catch
            End Try
            Try
                CategoryId = Convert.ToInt32(dr("CategoryId"))
            Catch
            End Try
        End Sub

        Public Property KeyID() As Integer Implements DotNetNuke.Entities.Modules.IHydratable.KeyID
            Get
                Return _categoryId
            End Get
            Set(ByVal value As Integer)
                _categoryId = Value
            End Set
        End Property
#End Region

    End Class

    Public Class TaskStatusInfo

        Implements DotNetNuke.Entities.Modules.IHydratable

#Region "Private Members"
        Private _statusId As Int32
        Private _projectId As Int32
        Private _ProjectName As String
        Private _statusName As String
        Private _isActiveStatus As Boolean
        Private _isClosedStatus As Boolean
        Private _viewOrder As Int32
#End Region

#Region "Constructors"

        Public Sub New()
        End Sub

#End Region

#Region "Public Properties"
        Public Property StatusId() As Int32
            Get
                Return _statusId
            End Get
            Set(ByVal Value As Int32)
                _statusId = Value
            End Set
        End Property


        Public ReadOnly Property ProjectName() As String
            Get
                Return _ProjectName
            End Get
        End Property

        Public Property ProjectId() As Int32
            Get
                Return _projectId
            End Get
            Set(ByVal Value As Int32)
                _projectId = Value
            End Set
        End Property



        Public Property StatusName() As String
            Get
                Return _statusName
            End Get
            Set(ByVal Value As String)
                _statusName = Value
            End Set
        End Property



        Public Property IsActiveStatus() As Boolean
            Get
                Return _isActiveStatus
            End Get
            Set(ByVal Value As Boolean)
                _isActiveStatus = Value
            End Set
        End Property



        Public Property IsClosedStatus() As Boolean
            Get
                Return _isClosedStatus
            End Get
            Set(ByVal Value As Boolean)
                _isClosedStatus = Value
            End Set
        End Property



        Public Property ViewOrder() As Int32
            Get
                Return _viewOrder
            End Get
            Set(ByVal Value As Int32)
                _viewOrder = Value
            End Set
        End Property

        Public Sub Fill(ByVal dr As System.Data.IDataReader) Implements DotNetNuke.Entities.Modules.IHydratable.Fill

            Try
                _ProjectName = Convert.ToString(dr("ProjectName"))
            Catch
            End Try

            Try
                ProjectId = Convert.ToInt32(dr("ProjectId"))
            Catch
            End Try


            Try
                StatusName = Convert.ToString(dr("StatusName"))
            Catch
            End Try


            Try
                IsActiveStatus = Convert.ToBoolean(dr("IsActiveStatus"))
            Catch
            End Try


            Try
                IsClosedStatus = Convert.ToBoolean(dr("IsClosedStatus"))
            Catch
            End Try


            Try
                ViewOrder = Convert.ToInt32(dr("ViewOrder"))
            Catch
            End Try
            Try
                StatusId = Convert.ToInt32(dr("StatusId"))
            Catch
            End Try
        End Sub

        Public Property KeyID() As Integer Implements DotNetNuke.Entities.Modules.IHydratable.KeyID
            Get
                Return _statusId
            End Get
            Set(ByVal value As Integer)
                _statusId = Value
            End Set
        End Property
#End Region

    End Class


End Namespace