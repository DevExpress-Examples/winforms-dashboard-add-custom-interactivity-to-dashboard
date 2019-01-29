Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardCommon.ViewerData
Imports DevExpress.DashboardWin
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPivotGrid
Imports System.Windows.Forms

Namespace Dashboard_CustomVisualInteractivity
	Partial Public Class Form1
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
			AddHandler dashboardViewer1.DataLoading, AddressOf dashboardViewer1_DataLoading
			AddHandler dashboardViewer1.DashboardItemClick, AddressOf dashboardViewer1_DashboardItemClick
			AddHandler dashboardViewer1.DashboardItemVisualInteractivity, AddressOf dashboardViewer1_DashboardItemVisualInteractivity
			AddHandler dashboardViewer1.DashboardItemSelectionChanged, AddressOf dashboardViewer1_DashboardItemSelectionChanged

			salesPersonTableAdapter.Fill(nwindDataSet.SalesPerson)

			dashboardViewer1.LoadDashboard("Data\Dashboard.xml")
		End Sub

		Private Sub dashboardViewer1_DashboardItemVisualInteractivity(ByVal sender As Object, ByVal e As DashboardItemVisualInteractivityEventArgs)
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

		Private Sub dashboardViewer1_DashboardItemSelectionChanged(ByVal sender As Object, ByVal e As DashboardItemSelectionChangedEventArgs)
			pivotGridControl1.BeginUpdate()
			fieldCategoryName1.FilterValues.FilterType = PivotFilterType.Included
			fieldCategoryName1.FilterValues.Clear()
			For Each selectedElement As AxisPointTuple In e.CurrentSelection
				Dim category As String = selectedElement.GetAxisPoint().DimensionValue.Value.ToString()
				fieldCategoryName1.FilterValues.Add(category)
			Next selectedElement
			pivotGridControl1.EndUpdate()
		End Sub

		Private Sub dashboardViewer1_DashboardItemClick(ByVal sender As Object, ByVal e As DashboardItemMouseActionEventArgs)
			If e.DashboardItemName = "chartDashboardItem1" AndAlso e.GetAxisPoint() IsNot Nothing Then
				Dim form As New XtraForm()
				form.Text = e.GetAxisPoint(DashboardDataAxisNames.ChartArgumentAxis).DimensionValue.Value.ToString() & " - " & e.GetAxisPoint(DashboardDataAxisNames.ChartSeriesAxis).DimensionValue.Value.ToString()
				Dim grid As New DataGrid()
				grid.Parent = form
				grid.Dock = DockStyle.Fill
				grid.DataSource = e.GetUnderlyingData()
				form.ShowDialog()
				form.Dispose()
			End If
		End Sub

		Private Sub dashboardViewer1_DataLoading(ByVal sender As Object, ByVal e As DataLoadingEventArgs)
			If e.DataSourceComponentName = "dataSource1" Then
				e.Data = nwindDataSet.SalesPerson
			End If
		End Sub
	End Class
End Namespace
