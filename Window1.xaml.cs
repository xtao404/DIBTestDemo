using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
           // dataPager.TotalCount = 20;
            if (DataGrid.View is GridView)
            {
                GridView g = DataGrid.View as GridView;
                GridViewColumn gvc1 = new GridViewColumn();
                gvc1.Header = "目标语言";
                gvc1.DisplayMemberBinding = new Binding("it");
                gvc1.Width = 150;
                g.Columns.Add(gvc1);
                GridViewColumn gvc = new GridViewColumn();
                gvc.Header = "源语言";
                gvc.DisplayMemberBinding = new Binding("zs");
                gvc.Width = 150;
                g.Columns.Add(gvc);
                GridViewColumn gvc2 = new GridViewColumn();
                gvc2.Header = "记忆库";
                gvc2.DisplayMemberBinding = new Binding("ja");
                gvc2.Width = 150;
                g.Columns.Add(gvc2);

            }
            DataTable dt= CreateDataTable();
            DataGrid.DataContext = dt.DefaultView;
            
            dataPager.TotalCount = dt.Rows.Count;

        }
        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable("Datas");
            DataColumn[] columns = new DataColumn[]{
               new DataColumn("it"),new DataColumn("zs"),new DataColumn("ja")
           };
            dt.Columns.AddRange(columns);
            for (int i = 0; i < 20; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i;
                dr[1] = "猴王" + i;
                dr[2] = i + 10;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
