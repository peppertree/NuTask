Imports DotNetNuke.Entities.Modules

Namespace Peppertree.Solutions.NuTask
    Public Class Helpers

        Public Shared Function GetTasksBudget(ByVal ProjectId) As Decimal

            Dim dec As Decimal = CDec(0.0)
            Dim dr As IDataReader = CType(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("NuTask_Task_SumBudget", ProjectId), IDataReader)
            While dr.Read
                dec = Convert.ToDecimal(dr("AllocatedBudget"))
            End While
            dr.Close()
            dr.Dispose()

            Return dec

        End Function

    End Class
End Namespace

