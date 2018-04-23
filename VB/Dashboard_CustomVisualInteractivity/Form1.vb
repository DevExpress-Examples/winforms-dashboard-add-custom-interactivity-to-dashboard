Imports DevExpress.DashboardWin
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPivotGrid
Imports DevExpress.DashboardCommon
Imports System.Windows.Forms
Imports DevExpress.DashboardCommon.ViewerData
Imports DevExpress.DataAccess
Namespace Dashboard_CustomVisualInteractivity
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            Me.salesPersonTableAdapter.Fill(Me.nwindDataSet.SalesPerson)

            dashboardViewer1.LoadDashboard("..\..\Data\Dashboard.xml")
        End Sub

        Private Sub dashboardViewer1_DashboardItemVisualInteractivity(ByVal sender As Object, _
                                     ByVal e As DashboardItemVisualInteractivityEventArgs) _
                                 Handles dashboardViewer1.DashboardItemVisualInteractivity
            If e.DashboardItemName = "gridDashboardItem1" Then
                e.SelectionMode = DashboardSelectionMode.Multiple
                e.SetDefaultSelection(e.Data.GetAxisPoints(DashboardDataAxisNames.DefaultAxis)(0))
            End If
            If e.DashboardItemName = "chartDashboardItem1" Then
                e.TargetAxes.Add(DashboardDataAxisNames.ChartArgumentAxis)
                e.TargetAxes.Add(DashboardDataAxisNames.ChartSeriesAxis)
                e.EnableHighlighting = True
            End If
        End Sub

        Private Sub dashboardViewer1_DashboardItemSelectionChanged(ByVal sender As Object, _
                                     ByVal e As DashboardItemSelectionChangedEventArgs) _
                                 Handles dashboardViewer1.DashboardItemSelectionChanged
            pivotGridControl1.BeginUpdate()
            fieldCategoryName1.FilterValues.FilterType = PivotFilterType.Included
            fieldCategoryName1.FilterValues.Clear()
            For Each selectedElement As AxisPointTuple In e.CurrentSelection
                Dim category As String = selectedElement.GetAxisPoint().DimensionValue.Value.ToString()
                fieldCategoryName1.FilterValues.Add(category)
            Next selectedElement
            pivotGridControl1.EndUpdate()
        End Sub

        Private Sub dashboardViewer1_DashboardItemClick(ByVal sender As Object, _
                                     ByVal e As DashboardItemMouseActionEventArgs) _
                                 Handles dashboardViewer1.DashboardItemClick
            If e.DashboardItemName = "chartDashboardItem1" AndAlso e.GetAxisPoint() IsNot Nothing Then
                Dim form As New XtraForm()
                form.Text = e.GetAxisPoint(DashboardDataAxisNames.ChartArgumentAxis).
                    DimensionValue.Value.ToString() & " - " & _
                    e.GetAxisPoint(DashboardDataAxisNames.ChartSeriesAxis).
                    DimensionValue.Value.ToString()
                Dim grid As New DataGrid()
                grid.Parent = form
                grid.Dock = DockStyle.Fill
                grid.DataSource = e.GetUnderlyingData()
                form.ShowDialog()
                form.Dispose()
            End If
        End Sub

        Private Sub dashboardViewer1_DataLoading(ByVal sender As Object, _
                                     ByVal e As DataLoadingEventArgs) _
                                 Handles dashboardViewer1.DataLoading
            If e.DataSourceComponentName = "dataSource1" Then
                e.Data = Me.nwindDataSet.SalesPerson
            End If
        End Sub
    End Class
End Namespace
