using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.ViewerData;
using DevExpress.DashboardWin;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using System.Windows.Forms;

namespace Dashboard_CustomVisualInteractivity
{
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
            dashboardViewer1.DataLoading += dashboardViewer1_DataLoading;
            dashboardViewer1.DashboardItemClick += dashboardViewer1_DashboardItemClick;
            dashboardViewer1.DashboardItemVisualInteractivity += dashboardViewer1_DashboardItemVisualInteractivity;
            dashboardViewer1.DashboardItemSelectionChanged += dashboardViewer1_DashboardItemSelectionChanged;

            salesPersonTableAdapter.Fill(nwindDataSet.SalesPerson);
            
            dashboardViewer1.LoadDashboard("Data\\Dashboard.xml");
        }

        private void dashboardViewer1_DashboardItemVisualInteractivity(object sender, 
            DashboardItemVisualInteractivityEventArgs e) {
            if (e.DashboardItemName == "gridDashboardItem1") {
                e.SelectionMode = DashboardSelectionMode.Multiple;
                e.SetDefaultSelection(e.Data.GetAxisPoints(DashboardDataAxisNames.DefaultAxis)[0]);
            }
            if (e.DashboardItemName == "chartDashboardItem1") {
                e.TargetAxes.Add(DashboardDataAxisNames.ChartArgumentAxis);
                e.TargetAxes.Add(DashboardDataAxisNames.ChartSeriesAxis);
                e.EnableHighlighting = true;
            }
        }

        private void dashboardViewer1_DashboardItemSelectionChanged(object sender, 
            DashboardItemSelectionChangedEventArgs e) {
            pivotGridControl1.BeginUpdate();
            fieldCategoryName1.FilterValues.FilterType = PivotFilterType.Included;
            fieldCategoryName1.FilterValues.Clear();
            foreach (AxisPointTuple selectedElement in e.CurrentSelection) {
                string category = selectedElement.GetAxisPoint().DimensionValue.Value.ToString();
                fieldCategoryName1.FilterValues.Add(category);
            }
            pivotGridControl1.EndUpdate();
        }

        private void dashboardViewer1_DashboardItemClick(object sender, 
            DashboardItemMouseActionEventArgs e) {
            if (e.DashboardItemName == "chartDashboardItem1" && e.GetAxisPoint() != null) {
                XtraForm form = new XtraForm();
                form.Text = e.GetAxisPoint(DashboardDataAxisNames.ChartArgumentAxis).
                    DimensionValue.Value.ToString() + " - " +
                    e.GetAxisPoint(DashboardDataAxisNames.ChartSeriesAxis).
                    DimensionValue.Value.ToString();
                DataGrid grid = new DataGrid();
                grid.Parent = form; grid.Dock = DockStyle.Fill;
                grid.DataSource = e.GetUnderlyingData();
                form.ShowDialog();
                form.Dispose();
            }
        }

        private void dashboardViewer1_DataLoading(object sender, DataLoadingEventArgs e) {
            if (e.DataSourceComponentName == "dataSource1") {
                e.Data = nwindDataSet.SalesPerson;
            }
        }
    }
}
