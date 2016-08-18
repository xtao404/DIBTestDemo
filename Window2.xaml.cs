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
using System.Collections.ObjectModel;
using System.Data;
using System.ComponentModel;

namespace WpfApplication1
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {   List<Student> infoList;
        public Window2()
        {
            InitializeComponent();
          
            Binding(12, 1);
        }
       
        private void Binding(int number, int currentSize)
        {
            infoList = new List<Student>(){
                new Student{ zs = "chifan1" , it = "chifan " ,  ja = "Desc1 "},
                new Student{ zs = "chifan2" , it = "chifan " ,  ja = "Desc2"}, 
                new Student{ zs = "chifan3" , it = "chifan " ,  ja = "Desc3 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc4"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc5 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc6"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc7 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc8 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc9"}, 
                    new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc9"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc10 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc11"}, 
                 new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc12 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc13 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc14"}, 
                    new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc9"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc10 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc11"}, 
                 new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc12 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc13 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc14"},     
                     new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc9"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc10 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc11"}, 
                 new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc12 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc13 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc14"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc10 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc11"}, 
                 new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc12 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc13 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc14"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc15 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc16"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc17 "}
            };
            int count = infoList.Count;          //获取记录总数   
            int pageSize = 0;            //pageSize表示总页数   
            if (count % number == 0)
            {
                pageSize = count / number;
            }
            else
            {
                pageSize = count / number + 1;
            }
            tbkTotal.Text = pageSize.ToString();

            tbkCurrentsize.Text = currentSize.ToString();
            infoList = infoList.Take(number * currentSize).Skip(number * (currentSize - 1)).ToList();   //刷选第currentSize页要显示的记录集   
            dataGrid1.ItemsSource = infoList;        //重新绑定dataGrid1   
            
        }
        const int Num = 12;
        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            int currentsize = int.Parse(tbkCurrentsize.Text); //获取当前页数   
            int a = currentsize-1;
            if (a == 1)
            {
                shouye.IsEnabled = false;
                btnUp.IsEnabled = false;
                btnNext.IsEnabled = true;
                moye.IsEnabled = true;
            }
             if (currentsize > 1)
            {
                Binding(Num, a);   //调用分页方法   
            }
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int total = int.Parse(tbkTotal.Text); //总页数   
            int currentsize = int.Parse(tbkCurrentsize.Text); //当前页数   
            int a = currentsize + 1;
            if (currentsize < total)
            {
                Binding(Num, a);   //调用分页方法   
            }
            if (a == total)
            {
                btnNext.IsEnabled = false;
                moye.IsEnabled = false;
                shouye.IsEnabled = true;
                btnUp.IsEnabled = true;
            }
        }
        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            int pageNum = int.Parse(tbxPageNum.Text);
            int total = int.Parse(tbkTotal.Text); //总页数   
            if (pageNum >= 1 && pageNum <= total)
            {
                Binding(Num, pageNum);     //调用分页方法   
            }
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
        private void shouye_Click(object sender, RoutedEventArgs e)
        {
            Binding(Num, 1);
            shouye.IsEnabled = false;
            btnUp.IsEnabled = false;
            btnNext.IsEnabled = true;
            moye.IsEnabled = true;
        }
        private void moye_Click(object sender, RoutedEventArgs e)
        {
            int total = int.Parse(tbkTotal.Text); //总页数   
            Binding(Num, total);
            btnNext.IsEnabled = false;
            moye.IsEnabled = false;
            shouye.IsEnabled = true;
            btnUp.IsEnabled = true;
        }
        private void tbxPageNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }    
    }
    public class Student
    {
        public string zs { get; set; }
        public string ja { get; set; }
        public string it { get; set; }
        public static ObservableCollection<Student> Students { get; set; }
    }
    public class Employee
    {
        public string Name { set; get; }
        public int EmpID { set; get; }
    }
    public class EmployeeArr : ObservableCollection<Employee>
    {
        public EmployeeArr()
        {
            
                 List < Student > infoList = new List<Student>(){
                new Student{ zs = "chifan1" , it = "chifan " ,  ja = "Desc1 "},
                new Student{ zs = "chifan2" , it = "chifan " ,  ja = "Desc2"}, 
                new Student{ zs = "chifan3" , it = "chifan " ,  ja = "Desc3 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc4"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc5 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc6"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc7 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc8 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc9"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc9"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc10 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc11"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc12 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc13 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc14"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc9"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc10 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc11"}, 
                 new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc12 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc13 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc14"},     
                     new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc9"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc10 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc11"}, 
                 new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc12 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc13 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc14"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc10 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc11"}, 
                 new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc12 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc13 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc14"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc15 "},
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc16"}, 
                new Student{ zs = "chifan" , it = "chifan " ,  ja = "Desc17 "}
            };
                 int pageSize = 0;            //pageSize表示总页数   
                 if (infoList.Count % 12 == 0)
                 {
                     pageSize = infoList.Count / 12;
                 }
                 else
                 {
                     pageSize = infoList.Count / 12 + 1;
                 }
               
                 for (int i = 1; i <= pageSize; i++)
          {
                this.Add(new Employee { EmpID = i, Name = i.ToString() });
          }
           
        }
    }  
}
