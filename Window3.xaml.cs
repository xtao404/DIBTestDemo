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
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
         

         public string Company_code;     
       // public string Select_item;    
        public ObservableCollection<Facility> Items { get;set; }     
        private delegate void ThreadDelegate(); //申明一个专用来调用更改线程函数的委托     
      public DispatcherTimer ShowTimer;     
        public Window3()
        {
            InitializeComponent();
        }

        private void dataGrid1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid1.CurrentCell.Column != null && dataGrid1.CurrentCell.Column.Header != null)
            {
                string facility_type = (dataGrid1.Columns[1].GetCellContent(dataGrid1.CurrentCell.Item) as TextBlock).Text;
                string head = dataGrid1.CurrentCell.Column.Header.ToString();  
            }     
        }
        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            DataGridRow row = FindVisualParent<DataGridRow>(sender as Expander);
            row.DetailsVisibility = System.Windows.Visibility.Visible;
        }
        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            DataGridRow row = FindVisualParent<DataGridRow>(sender as Expander);
            row.DetailsVisibility = System.Windows.Visibility.Collapsed;
        }
        public T FindVisualParent<T>(DependencyObject child) where T : DependencyObject    
        {    
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);    
            if (parentObject == null) return null;     
            T parent = parentObject as T;     
            if (parent != null)    
                return parent;     
            else
                return FindVisualParent<T>(parentObject);    
        }
        public T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
          {
              if (parent != null)
              {
                  for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                  {
                      var child = VisualTreeHelper.GetChild(parent, i) as DependencyObject;
                      string controlName = child.GetValue(Control.NameProperty) as string;
                      if (controlName == name)
                      {
                          return child as T;
                      }
                      else
                      {
                          T result = FindVisualChildByName<T>(child, name);
                          if (result != null)
                              return result;
                      }
                  }
              }
              return null;
          }     
        private void dataGrid2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DataGridRow dgr = (DataGridRow)dataGrid1.ItemContainerGenerator.ContainerFromIndex(this.dataGrid1.SelectedIndex);    
            DataGrid dg= FindVisualChildByName<DataGrid>(dgr, "dataGrid2") as DataGrid;   
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Items = new ObservableCollection<Facility>();
           // DataSet dsFacility =new DataSet();// new BLL.DSP_FACILITY_USE().GetFacility_status_Sum(Company_code);
         //   DataSet dsFacilityDetail = new DataSet();//new BLL.DSP_FACILITY_USE().GetFacility_UseStatus(Company_code);
           // int count = dsFacility.Tables[0].Rows.Count;
            DataTable dt = CreateDataTable();
            DataTable dt1 = CreateDataTable1();
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Items.Add(new Facility(Company_code, i, dt, dt1));
            }
            dataGrid1.Items.Clear();
            dataGrid1.ItemsSource = Items;
            dataGrid1.Items.Refresh();
            dataGrid1.SelectedValuePath = "facility_type";   
        }
      
        private DataTable CreateDataTable1()
        {
            DataTable dt = new DataTable("Datas");
            DataColumn[] columns = new DataColumn[]{
               new DataColumn("facility_type"),new DataColumn("building_code"),
                 new DataColumn("floor"),new DataColumn("dept_code"),
                 new DataColumn("dept_name"),new DataColumn("count_all"),
               new DataColumn("count_no"),new DataColumn("count_yes")
           };
            dt.Columns.AddRange(columns);
            for (int i = 0; i < 1; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "ye";
                dr[1] = "guang" + i;
                dr[2] = "li" + i + 10;
                dr[3] = "猴王" + i;
                dr[4] = "li" + i + 10;
                dr[5] = "猴王1" + i;
                dr[6] = "gui" + i + 10;
                dr[7] = "fang" + i + 10;
                dt.Rows.Add(dr);
            }
            return dt;
        } 
        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable("Datas");
            DataColumn[] columns = new DataColumn[]{
               new DataColumn("Facility_type"),new DataColumn("Building_code"),
                 new DataColumn("Floor"),new DataColumn("Dept_code"),
                 new DataColumn("Count_all"),new DataColumn("Count_no"),
               new DataColumn("Count_yes")
           };
            dt.Columns.AddRange(columns);
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "ye";
                dr[1] = "guang" + i;
                dr[2] = "li"+i + 10;
                dr[3] = "猴王" + i;
                dr[4] = "li"+i + 10;
                dr[5] = "猴王1" + i;
                dr[6] = "gui"+i + 10;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
    public class Facility
    {
        public string Facility_type { get; set; }
        public string Building_code { get; set; }
        public string Floor { get; set; }
        public string Dept_code { get; set; }
        public string Count_all { get; set; }
        public string Count_no { get; set; }
        public string Count_yes { get; set; }
        public ObservableCollection<Facility_Detail> Details { get; set; }
        public Facility(string company_code, int row_index, DataTable dsfacilitySum, DataTable dsFacilityDetail)
        {
            Facility_type = dsfacilitySum.Rows[row_index]["facility_type"].ToString();
            Count_all = dsfacilitySum.Rows[row_index]["count_all"].ToString();
            Count_no = dsfacilitySum.Rows[row_index]["count_no"].ToString();
            Count_yes = dsfacilitySum.Rows[row_index]["count_yes"].ToString();
            Details = new ObservableCollection<Facility_Detail>();
            //详细信息     
            System.Data.DataTable dtDetail = new System.Data.DataTable();
            DataRow[] rowDetail = dsFacilityDetail.Select("facility_type='" + Facility_type + "'");
            dtDetail = dsFacilityDetail.Clone();    
             foreach (DataRow dr in rowDetail)     
             {     
                Details.Add(new Facility_Detail()     
                {     
                    facility_type = Facility_type,     
                    building_code = dr["building_code"].ToString(),    
                    floor = dr["floor"].ToString(),    
                    dept_code = dr["dept_code"].ToString(),    
                    dept_name = dr["dept_name"].ToString(),    
                    count_all = dr["count_all"].ToString(),    
                    count_no = dr["count_no"].ToString(),    
                    count_yes = dr["count_yes"].ToString()    
                });     
             }     

        }
    
    }

    public class Facility_Detail    
    {  //定义属性  
        public string facility_type {get; set; }    
        public string building_code {get; set; }    
        public string floor { get; set; }    
        public string dept_code {get; set; }    
        public string dept_name {get; set; }    
        public string count_all {get; set; }    
        public string count_no {get; set; }    
        public string count_yes {get; set; }    
    }    

}
