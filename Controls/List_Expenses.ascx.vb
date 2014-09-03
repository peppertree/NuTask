Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Security.Roles
Imports Telerik.Web.UI

Namespace Peppertree.Solutions.NuTask
    Public Class List_Expenses
        Inherits NuTaskBase

#Region "Private Members"
        Private _mode As String = "all"
        Private _filter As Integer = Null.NullInteger
#End Region

#Region "Event Handlers"

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            SetupForm()

            If Not Page.IsPostBack Then

                BindCategories()

                If Not Request.QueryString("Mode") Is Nothing Then
                    _mode = Request.QueryString("Mode")
                End If

                If Not Request.QueryString("Filter") Is Nothing Then
                    Integer.TryParse(Request.QueryString("Filter"), _filter)
                End If

                If _filter <> Null.NullInteger Then
                    drpCategories.SelectedValue = _filter
                End If
                drpFilter.SelectedValue = _mode.ToLower

            End If

        End Sub

        Private Sub drpFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles drpFilter.SelectedIndexChanged

            _mode = drpFilter.SelectedValue
            grdExpenses.Rebind()

        End Sub

        Private Sub drpCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles drpCategories.SelectedIndexChanged

            Integer.TryParse(drpCategories.SelectedValue, _filter)
            grdExpenses.Rebind()

        End Sub

        Private Sub grdExpenses_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles grdExpenses.NeedDataSource
            BindData()
        End Sub

#End Region

#Region "Private Methods"

        Private Sub SetupForm()

            lnkAddExpense.NavigateUrl = EditUrl(KEY_EDITEXPENSE)

            drpFilter.Items.FindItemByValue("all").Text = LocalizeString("ExpenseFilter_All")
            drpFilter.Items.FindItemByValue("project").Text = LocalizeString("ExpenseFilter_Project")
            drpFilter.Items.FindItemByValue("task").Text = LocalizeString("ExpenseFilter_Task")

            lblExpenseTotal.Text = LocalizeString("lblExpenseTotal")
        End Sub

        Public Sub BindCategories()

            Dim ctrl As New ExpenseCategoryController
            drpCategories.DataTextField = "Title"
            drpCategories.DataValueField = "CategoryId"
            drpCategories.DataSource = ctrl.ListByProject(ProjectId)
            drpCategories.DataBind()

            drpCategories.Items.Insert(0, New RadComboBoxItem(Localization.GetString("AllCategories", LocalResourceFile), "-1"))

        End Sub

        Private Sub BindData()

            Dim lstExpenses As New List(Of ExpenseInfo)
            Dim lstView As New List(Of ExpenseInfo)
            lstExpenses = ExpenseController.ListByProject(ProjectId)

            Dim dblTotal As Decimal = CDec(0.0)

            For Each objExpense As ExpenseInfo In lstExpenses
                Select Case _mode.ToLower
                    Case "all"

                        If _filter <> Null.NullInteger Then
                            If objExpense.CategoryId = _filter Then
                                lstView.Add(objExpense)
                                dblTotal += objExpense.Amount
                            End If
                        Else
                            lstView.Add(objExpense)
                            dblTotal += objExpense.Amount
                        End If

                    Case "task"
                        If objExpense.TaskId <> Null.NullInteger Then
                            If _filter <> Null.NullInteger Then
                                If objExpense.CategoryId = _filter Then
                                    lstView.Add(objExpense)
                                    dblTotal += objExpense.Amount
                                End If
                            Else
                                lstView.Add(objExpense)
                                dblTotal += objExpense.Amount
                            End If                           
                        End If
                    Case "project"
                        If objExpense.TaskId = Null.NullInteger Then
                            If _filter <> Null.NullInteger Then
                                If objExpense.CategoryId = _filter Then
                                    lstView.Add(objExpense)
                                    dblTotal += objExpense.Amount
                                End If
                            Else
                                lstView.Add(objExpense)
                                dblTotal += objExpense.Amount
                            End If
                        End If
                End Select
            Next

            grdExpenses.DataSource = lstView
            lblExpenseTotalValue.Text = dblTotal.ToString("C")

        End Sub

#End Region




    End Class
End Namespace
