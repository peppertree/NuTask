Imports DotNetNuke.Data
Imports DotNetNuke.Framework
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace Peppertree.Solutions.NuTask

    <DataObject(True)> _
    Public Class ExpenseController

#Region "Private Methods"
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
#End Region

#Region "Public Methods"

        Public Function [Get](ByVal expenseId As Integer) As ExpenseInfo

            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Expense_Get", expenseId), GetType(ExpenseInfo)), ExpenseInfo)

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [List]() As List(Of ExpenseInfo)

            Return CBO.FillCollection(Of ExpenseInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Expense_List"), IDataReader))

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByExpenseCategory](ByVal CategoryId As Integer) As List(Of ExpenseInfo)

            Return CBO.FillCollection(Of ExpenseInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Expense_ListByExpenseCategory", CategoryId), IDataReader))

        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByProject](ByVal ProjectId As Integer) As List(Of ExpenseInfo)

            Return CBO.FillCollection(Of ExpenseInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Expense_ListByProject", ProjectId), IDataReader))

        End Function


        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByTaskId](ByVal TaskId As Integer) As List(Of ExpenseInfo)

            Return CBO.FillCollection(Of ExpenseInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Expense_ListByTaskId", TaskId), IDataReader))

        End Function



        <DataObjectMethod(DataObjectMethodType.Insert, True)> _
        Public Function Add(ByVal objExpenseInfo As ExpenseInfo) As Integer

            Return DotNetNuke.Data.DataProvider.Instance().ExecuteScalar(Of Integer)("NuTask_Expense_Add", GetNull(objExpenseInfo.CategoryId), GetNull(objExpenseInfo.ProjectId), GetNull(objExpenseInfo.TaskId), GetNull(objExpenseInfo.ExpenseDate), GetNull(objExpenseInfo.Title), GetNull(objExpenseInfo.Amount), GetNull(objExpenseInfo.ReceiptNo), GetNull(objExpenseInfo.ImageUrl))

        End Function

        <DataObjectMethod(DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal objExpenseInfo As ExpenseInfo)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_Expense_Update", GetNull(objExpenseInfo.ExpenseId), GetNull(objExpenseInfo.CategoryId), GetNull(objExpenseInfo.ProjectId), GetNull(objExpenseInfo.TaskId), GetNull(objExpenseInfo.ExpenseDate), GetNull(objExpenseInfo.Title), GetNull(objExpenseInfo.Amount), GetNull(objExpenseInfo.ReceiptNo), GetNull(objExpenseInfo.ImageUrl))

        End Sub

        <DataObjectMethod(DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal ExpenseId As Integer)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_Expense_Delete", ExpenseId)

        End Sub

#End Region

    End Class

    <DataObject(True)> _
    Public Class ExpenseCategoryController

#Region "Private Methods"
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
#End Region

#Region "Public Methods"

        Public Function [Get](ByVal categoryId As Integer) As ExpenseCategoryInfo

            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_ExpenseCategory_Get", categoryId), GetType(ExpenseCategoryInfo)), ExpenseCategoryInfo)

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [List]() As List(Of ExpenseCategoryInfo)

            Return CBO.FillCollection(Of ExpenseCategoryInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_ExpenseCategory_List"), IDataReader))

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByProject](ByVal ProjectId As Integer) As List(Of ExpenseCategoryInfo)

            Return CBO.FillCollection(Of ExpenseCategoryInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_ExpenseCategory_ListByProject", ProjectId), IDataReader))

        End Function



        <DataObjectMethod(DataObjectMethodType.Insert, True)> _
        Public Function Add(ByVal objExpenseCategoryInfo As ExpenseCategoryInfo) As Integer

            Return DotNetNuke.Data.DataProvider.Instance().ExecuteScalar(Of Integer)("NuTask_ExpenseCategory_Add", GetNull(objExpenseCategoryInfo.ProjectId), GetNull(objExpenseCategoryInfo.Title), GetNull(objExpenseCategoryInfo.ViewOrder))

        End Function

        <DataObjectMethod(DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal objExpenseCategoryInfo As ExpenseCategoryInfo)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_ExpenseCategory_Update", GetNull(objExpenseCategoryInfo.CategoryId), GetNull(objExpenseCategoryInfo.ProjectId), GetNull(objExpenseCategoryInfo.Title), GetNull(objExpenseCategoryInfo.ViewOrder))

        End Sub

        <DataObjectMethod(DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal CategoryId As Integer)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_ExpenseCategory_Delete", CategoryId)

        End Sub

#End Region

    End Class

    <DataObject(True)> _
    Public Class LogController

#Region "Private Methods"
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
#End Region

#Region "Public Methods"

        Public Function [Get](ByVal logEntryId As Integer) As LogInfo

            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Log_Get", logEntryId), GetType(LogInfo)), LogInfo)

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [List]() As List(Of LogInfo)

            Return CBO.FillCollection(Of LogInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Log_List"), IDataReader))

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByProject](ByVal ProjectId As Integer) As List(Of LogInfo)

            Return CBO.FillCollection(Of LogInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Log_ListByProject", ProjectId), IDataReader))

        End Function


        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByTaskId](ByVal TaskId As Integer) As List(Of LogInfo)

            Return CBO.FillCollection(Of LogInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Log_ListByTaskId", TaskId), IDataReader))

        End Function


        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByNoteId](ByVal NoteId As Integer) As List(Of LogInfo)

            Return CBO.FillCollection(Of LogInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Log_ListByNoteId", NoteId), IDataReader))

        End Function


        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByExpenseId](ByVal ExpenseId As Integer) As List(Of LogInfo)

            Return CBO.FillCollection(Of LogInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Log_ListByExpenseId", ExpenseId), IDataReader))

        End Function



        <DataObjectMethod(DataObjectMethodType.Insert, True)> _
        Public Function Add(ByVal objLogInfo As LogInfo) As Integer

            Return DotNetNuke.Data.DataProvider.Instance().ExecuteScalar(Of Integer)("NuTask_Log_Add", GetNull(objLogInfo.ProjectId), GetNull(objLogInfo.TaskId), GetNull(objLogInfo.NoteId), GetNull(objLogInfo.ExpenseId), GetNull(objLogInfo.LogDate), GetNull(objLogInfo.LogType), GetNull(objLogInfo.LogEntry))

        End Function

        <DataObjectMethod(DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal objLogInfo As LogInfo)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_Log_Update", GetNull(objLogInfo.LogEntryId), GetNull(objLogInfo.ProjectId), GetNull(objLogInfo.TaskId), GetNull(objLogInfo.NoteId), GetNull(objLogInfo.ExpenseId), GetNull(objLogInfo.LogDate), GetNull(objLogInfo.LogType), GetNull(objLogInfo.LogEntry))

        End Sub

        <DataObjectMethod(DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal LogEntryId As Integer)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_Log_Delete", LogEntryId)

        End Sub

#End Region

    End Class

    <DataObject(True)> _
    Public Class NoteController

#Region "Private Methods"
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
#End Region

#Region "Public Methods"

        Public Function [Get](ByVal noteId As Integer) As NoteInfo

            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Note_Get", noteId), GetType(NoteInfo)), NoteInfo)

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [List]() As List(Of NoteInfo)

            Return CBO.FillCollection(Of NoteInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Note_List"), IDataReader))

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByProject](ByVal ProjectId As Integer) As List(Of NoteInfo)

            Return CBO.FillCollection(Of NoteInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Note_ListByProject", ProjectId), IDataReader))

        End Function


        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByTaskId](ByVal TaskId As Integer) As List(Of NoteInfo)

            Return CBO.FillCollection(Of NoteInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Note_ListByTaskId", TaskId), IDataReader))

        End Function



        <DataObjectMethod(DataObjectMethodType.Insert, True)> _
        Public Function Add(ByVal objNoteInfo As NoteInfo) As Integer

            Return DotNetNuke.Data.DataProvider.Instance().ExecuteScalar(Of Integer)("NuTask_Note_Add", GetNull(objNoteInfo.ProjectId), GetNull(objNoteInfo.TaskId), GetNull(objNoteInfo.CreatedBy), GetNull(objNoteInfo.CreatedDate), GetNull(objNoteInfo.Entry))

        End Function

        <DataObjectMethod(DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal objNoteInfo As NoteInfo)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_Note_Update", GetNull(objNoteInfo.NoteId), GetNull(objNoteInfo.ProjectId), GetNull(objNoteInfo.TaskId), GetNull(objNoteInfo.CreatedBy), GetNull(objNoteInfo.CreatedDate), GetNull(objNoteInfo.Entry))

        End Sub

        <DataObjectMethod(DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal NoteId As Integer)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_Note_Delete", NoteId)

        End Sub

#End Region

    End Class

    <DataObject(True)> _
    Public Class ProjectController

#Region "Private Methods"
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
#End Region

#Region "Public Methods"

        Public Function [Get](ByVal projectId As Integer) As ProjectInfo

            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Project_Get", projectId), GetType(ProjectInfo)), ProjectInfo)

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [List]() As List(Of ProjectInfo)

            Return CBO.FillCollection(Of ProjectInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Project_List"), IDataReader))

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByPortals](ByVal PortalId As Integer) As List(Of ProjectInfo)

            Return CBO.FillCollection(Of ProjectInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Project_ListByPortals", PortalId), IDataReader))

        End Function



        <DataObjectMethod(DataObjectMethodType.Insert, True)> _
        Public Function Add(ByVal objProjectInfo As ProjectInfo) As Integer

            Return DotNetNuke.Data.DataProvider.Instance().ExecuteScalar(Of Integer)("NuTask_Project_Add", GetNull(objProjectInfo.PortalId), GetNull(objProjectInfo.ProjectName), GetNull(objProjectInfo.Description), GetNull(objProjectInfo.AllocatedBudget), GetNull(objProjectInfo.DueDate), GetNull(objProjectInfo.MemberRole))

        End Function

        <DataObjectMethod(DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal objProjectInfo As ProjectInfo)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_Project_Update", GetNull(objProjectInfo.ProjectId), GetNull(objProjectInfo.PortalId), GetNull(objProjectInfo.ProjectName), GetNull(objProjectInfo.Description), GetNull(objProjectInfo.AllocatedBudget), GetNull(objProjectInfo.DueDate), GetNull(objProjectInfo.MemberRole))

        End Sub

        <DataObjectMethod(DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal ProjectId As Integer)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_Project_Delete", ProjectId)

        End Sub

#End Region

    End Class

    <DataObject(True)> _
    Public Class TaskController

#Region "Private Methods"
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
#End Region

#Region "Public Methods"

        Public Function [Get](ByVal taskId As Integer) As TaskInfo

            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_Get", taskId), GetType(TaskInfo)), TaskInfo)

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [List]() As List(Of TaskInfo)

            Return CBO.FillCollection(Of TaskInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_List"), IDataReader))

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByProject](ByVal ProjectId As Integer) As List(Of TaskInfo)

            Return CBO.FillCollection(Of TaskInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_ListByProject", ProjectId), IDataReader))

        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByTaskCategory](ByVal CategoryId As Integer) As List(Of TaskInfo)

            Return CBO.FillCollection(Of TaskInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_ListByTaskCategory", CategoryId), IDataReader))

        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByTaskStatus](ByVal StatusId As Integer) As List(Of TaskInfo)

            Return CBO.FillCollection(Of TaskInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_ListByTaskStatus", StatusId), IDataReader))

        End Function


        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByCreatedBy](ByVal CreatedBy As Integer) As List(Of TaskInfo)

            Return CBO.FillCollection(Of TaskInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_ListByCreatedBy", CreatedBy), IDataReader))

        End Function


        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByAssignedTo](ByVal AssignedTo As Integer) As List(Of TaskInfo)

            Return CBO.FillCollection(Of TaskInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_ListByAssignedTo", AssignedTo), IDataReader))

        End Function


        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByDateStart](ByVal DateStart As Integer) As List(Of TaskInfo)

            Return CBO.FillCollection(Of TaskInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_ListByDateStart", DateStart), IDataReader))

        End Function


        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByDateEnd](ByVal DateEnd As Integer) As List(Of TaskInfo)

            Return CBO.FillCollection(Of TaskInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_ListByDateEnd", DateEnd), IDataReader))

        End Function


        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByDueDate](ByVal DueDate As Integer) As List(Of TaskInfo)

            Return CBO.FillCollection(Of TaskInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_ListByDueDate", DueDate), IDataReader))

        End Function



        <DataObjectMethod(DataObjectMethodType.Insert, True)> _
        Public Function Add(ByVal objTaskInfo As TaskInfo) As Integer

            Return DotNetNuke.Data.DataProvider.Instance().ExecuteScalar(Of Integer)("NuTask_Task_Add", GetNull(objTaskInfo.ProjectId), GetNull(objTaskInfo.CategoryId), GetNull(objTaskInfo.StatusId), GetNull(objTaskInfo.CreatedBy), GetNull(objTaskInfo.CreatedDate), GetNull(objTaskInfo.AssignedTo), GetNull(objTaskInfo.AssignedDate), GetNull(objTaskInfo.Title), GetNull(objTaskInfo.Descrition), GetNull(objTaskInfo.EstimatedTime), GetNull(objTaskInfo.EstimatedTimeUnit), GetNull(objTaskInfo.DateStart), GetNull(objTaskInfo.DateEnd), GetNull(objTaskInfo.DueDate), GetNull(objTaskInfo.AllocatedBudget), GetNull(objTaskInfo.AllocatedExpenses))

        End Function

        <DataObjectMethod(DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal objTaskInfo As TaskInfo)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_Task_Update", GetNull(objTaskInfo.TaskId), GetNull(objTaskInfo.ProjectId), GetNull(objTaskInfo.CategoryId), GetNull(objTaskInfo.StatusId), GetNull(objTaskInfo.CreatedBy), GetNull(objTaskInfo.CreatedDate), GetNull(objTaskInfo.AssignedTo), GetNull(objTaskInfo.AssignedDate), GetNull(objTaskInfo.Title), GetNull(objTaskInfo.Descrition), GetNull(objTaskInfo.EstimatedTime), GetNull(objTaskInfo.EstimatedTimeUnit), GetNull(objTaskInfo.DateStart), GetNull(objTaskInfo.DateEnd), GetNull(objTaskInfo.DueDate), GetNull(objTaskInfo.AllocatedBudget), GetNull(objTaskInfo.AllocatedExpenses))

        End Sub

        <DataObjectMethod(DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal TaskId As Integer)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_Task_Delete", TaskId)

        End Sub

#End Region

    End Class

    <DataObject(True)> _
    Public Class TaskCategoryController

#Region "Private Methods"
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
#End Region

#Region "Public Methods"

        Public Function [Get](ByVal categoryId As Integer) As TaskCategoryInfo

            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_TaskCategory_Get", categoryId), GetType(TaskCategoryInfo)), TaskCategoryInfo)

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [List]() As List(Of TaskCategoryInfo)

            Return CBO.FillCollection(Of TaskCategoryInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_TaskCategory_List"), IDataReader))

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByProject](ByVal ProjectId As Integer) As List(Of TaskCategoryInfo)

            Return CBO.FillCollection(Of TaskCategoryInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_TaskCategory_ListByProject", ProjectId), IDataReader))

        End Function



        <DataObjectMethod(DataObjectMethodType.Insert, True)> _
        Public Function Add(ByVal objTaskCategoryInfo As TaskCategoryInfo) As Integer

            Return DotNetNuke.Data.DataProvider.Instance().ExecuteScalar(Of Integer)("NuTask_TaskCategory_Add", GetNull(objTaskCategoryInfo.ProjectId), GetNull(objTaskCategoryInfo.Title), GetNull(objTaskCategoryInfo.ViewOrder))

        End Function

        <DataObjectMethod(DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal objTaskCategoryInfo As TaskCategoryInfo)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_TaskCategory_Update", GetNull(objTaskCategoryInfo.CategoryId), GetNull(objTaskCategoryInfo.ProjectId), GetNull(objTaskCategoryInfo.Title), GetNull(objTaskCategoryInfo.ViewOrder))

        End Sub

        <DataObjectMethod(DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal CategoryId As Integer)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_TaskCategory_Delete", CategoryId)

        End Sub

#End Region

    End Class

    <DataObject(True)> _
    Public Class TaskStatusController

#Region "Private Methods"
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
#End Region

#Region "Public Methods"

        Public Function [Get](ByVal statusId As Integer) As TaskStatusInfo

            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_TaskStatus_Get", statusId), GetType(TaskStatusInfo)), TaskStatusInfo)

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [List]() As List(Of TaskStatusInfo)

            Return CBO.FillCollection(Of TaskStatusInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_TaskStatus_List"), IDataReader))

        End Function

        <DataObjectMethod(DataObjectMethodType.Select, True)> _
        Public Function [ListByProject](ByVal ProjectId As Integer) As List(Of TaskStatusInfo)

            Return CBO.FillCollection(Of TaskStatusInfo)(CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_TaskStatus_ListByProject", ProjectId), IDataReader))

        End Function



        <DataObjectMethod(DataObjectMethodType.Insert, True)> _
        Public Function Add(ByVal objTaskStatusInfo As TaskStatusInfo) As Integer

            Return DotNetNuke.Data.DataProvider.Instance().ExecuteScalar(Of Integer)("NuTask_TaskStatus_Add", GetNull(objTaskStatusInfo.ProjectId), GetNull(objTaskStatusInfo.StatusName), GetNull(objTaskStatusInfo.IsActiveStatus), GetNull(objTaskStatusInfo.IsClosedStatus), GetNull(objTaskStatusInfo.ViewOrder))

        End Function

        <DataObjectMethod(DataObjectMethodType.Update, True)> _
        Public Sub Update(ByVal objTaskStatusInfo As TaskStatusInfo)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_TaskStatus_Update", GetNull(objTaskStatusInfo.StatusId), GetNull(objTaskStatusInfo.ProjectId), GetNull(objTaskStatusInfo.StatusName), GetNull(objTaskStatusInfo.IsActiveStatus), GetNull(objTaskStatusInfo.IsClosedStatus), GetNull(objTaskStatusInfo.ViewOrder))

        End Sub

        <DataObjectMethod(DataObjectMethodType.Delete, True)> _
        Public Sub Delete(ByVal StatusId As Integer)

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuTask_TaskStatus_Delete", StatusId)

        End Sub

#End Region

    End Class



End Namespace