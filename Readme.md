<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Dashboard_CustomVisualInteractivity/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_CustomVisualInteractivity/Form1.vb))
<!-- default file list end -->
# WinForms Dashboard Viewer - How to Implement Custom Interactivity


This example shows how to add a custom interactivity to a dashboard loaded in the [WinForms Dashboard Viewer](https://docs.devexpress.com/Dashboard/117122/winforms-dashboard/winforms-viewer):
- A user can select records in the [Grid](https://docs.devexpress.com/Dashboard/15150) dashboard item to filter data in the external [Pivot Grid](https://docs.devexpress.com/WindowsForms/3409) control. 
- When a user clicks the chart series, the [Data Grid](https://docs.devexpress.com/WindowsForms/3455/controls-and-libraries/data-grid) control displays the corresponding underlying data.

![screenshot](https://github.com/DevExpress-Examples/how-to-add-custom-interactivity-to-a-dashboard-displayed-in-the-winforms-viewer-t189795/blob/18.2.4%2B/images/screenshot.png)

To accomplish this, handle the following events:

* [DashboardViewer.DashboardItemVisualInteractivity](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DashboardItemVisualInteractivity) event allows you to implement a custom [Master Filtering](https://docs.devexpress.com/Dashboard/116912).

* [DashboardViewer.DashboardItemSelectionChanged](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DashboardItemSelectionChanged) event allows you to filter data in the external [PivotGridControl](https://docs.devexpress.com/WindowsForms/3409) with the records selected in the [Grid](https://docs.devexpress.com/Dashboard/15150) dashboard item.

* [DashboardViewer.DashboardItemSelectionChanged](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DashboardItemSelectionChanged) event allows you to obtain underlying data when the user clicks the chart series.


This example operates with the [MultiDimensionalData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.ViewerData.MultiDimensionalData) API. For more information on the **MultiDimensionalData** concept, refer to the following document: [Obtain Underlying and Displayed Data](https://docs.devexpress.com/Dashboard/17269/winforms-dashboard/winforms-viewer/obtaining-underlying-and-displayed-data).

## Documentation

- [DashboardViewer.DashboardItemSelectionChanged](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DashboardItemSelectionChanged)
- [DashboardViewer.DashboardItemVisualInteractivity](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DashboardItemVisualInteractivity)
- [Obtain Underlying and Displayed Data](https://docs.devexpress.com/Dashboard/17269/winforms-dashboard/winforms-viewer/obtaining-underlying-and-displayed-data)

## More Examples 

* [How to: Obtain a Dashboard Item's Client Data in the WinForms Viewer](https://github.com/DevExpress-Examples/how-to-obtain-a-dashboard-items-client-data-in-the-winforms-viewer-t140553)
* [How to: Calculate and Display Totals for the Hidden Measure](https://github.com/DevExpress-Examples/winforms-dashboard-how-to-display-hidden-field-totals)
* [How to: Display the Total Value above each Pie Chart in the WinForms Viewer](https://github.com/DevExpress-Examples/how-to-display-the-total-value-above-each-pie-chart)
* [How to: Customize the Data Inspector Dialog](https://github.com/DevExpress-Examples/winforms-dashboard-data-inspector-customization)
