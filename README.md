# How to get the target record when drop the row in WPF DataGrid(SfDataGrid)?	

## About the sample

This example illustrates how to get the target record when drop the row in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid)?

[WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid) does not provide the direct support to get the target record which is going to drop. You can get the target record which is going to drop by using [SfDataGrid.RowDragDropController.Drop](https://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.GridRowDragDropController~Drop_EV.html) event.

```C#
sfDataGrid.RowDragDropController.Drop += RowDragDropController_Drop;

private void RowDragDropController_Drop(object sender, GridRowDropEventArgs e)
{
            var droppedIndex = (int)e.TargetRecord;

            var rowIndex = this.sfDataGrid.ResolveToRowIndex(droppedIndex);

            NodeEntry recordEntry = null;

            if (this.sfDataGrid.View.TopLevelGroup != null)
                recordEntry = this.sfDataGrid.View.TopLevelGroup.DisplayElements[this.sfDataGrid.ResolveToRecordIndex(rowIndex)];            
            else
                recordEntry = this.sfDataGrid.View.Records[this.sfDataGrid.ResolveToRecordIndex(rowIndex)];

            var targetRecord = ((recordEntry as RecordEntry).Data as OrderInfo);
            
            txtDisplayRecord.Text = "OrderId : " + targetRecord.OrderID + "\nCustomerID : " + targetRecord.CustomerID + "\nCustomerName : " + targetRecord.CustomerName + "\nCountry : " + targetRecord.Country + "\nUnitPrice : " + targetRecord.UnitPrice + "\nRow Index :" + droppedIndex;
}

```

KB article - [How to get the target record when drop the row in WPF DataGrid(SfDataGrid)?](https://www.syncfusion.com/kb/11377/how-to-get-the-target-record-when-drop-the-row-in-wpf-datagrid-sfdatagrid)

## Requirements to run the demo
Visual Studio 2015 and above versions
