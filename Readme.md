<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Dashboard_CustomVisualInteractivity/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_CustomVisualInteractivity/Form1.vb))
<!-- default file list end -->
# How to Implement Custom Interactivity in WinForms DashboardViewer


This example demonstrates how to add a custom interactivity to a dashboard loaded in the [WinForms Dashboard Viewer](http://docs.devexpress.com/15348).

To accomplish this, handle the following events:

* [DashboardViewer.DashboardItemVisualInteractivity](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DashboardItemVisualInteractivity) event allows you to implement a custom [Master Filtering](https://docs.devexpress.com/Dashboard/116912).

* [DashboardViewer.DashboardItemSelectionChanged](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DashboardItemSelectionChanged) event allows you to filter data in the external [PivotGridControl](https://docs.devexpress.com/WindowsForms/3409) with the records selected in the [Grid dashboard item](https://docs.devexpress.com/Dashboard/15150).

* [DashboardViewer.DashboardItemSelectionChanged](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DashboardItemSelectionChanged) event allows you to obtain underlying data when the user clicks the chart series.

> This example operates with the [MultiDimensionalData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.ViewerData.MultiDimensionalData) API. For more information on the **MultiDimensionalData** concept refer to the [Obtaining Underlying and Displayed Data](https://docs.devexpress.com/Dashboard/17269) document.

![screenshot](https://github.com/DevExpress-Examples/how-to-add-custom-interactivity-to-a-dashboard-displayed-in-the-winforms-viewer-t189795/blob/18.2.4%2B/images/screenshot.png)
