using System;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.Windows;

namespace SfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            sfDataGrid.RowDragDropController.Drop += RowDragDropController_Drop;
        }

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
    }
}
         
   

