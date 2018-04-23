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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using System.Windows.Interactivity;
using DevExpress.Data.Filtering.Helpers;
using System.ComponentModel;
using DevExpress.Data.Filtering;

namespace TreeListFilter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            treeList.ItemsSource = Stuff.GetStuff();
            treeListView1.ExpandAllNodes();
            Dispatcher.BeginInvoke(new Action(() =>
            {
                treeListView1.CollapseAllNodes();
            }));
        }

        private void treeList_FilterChanged(object sender, RoutedEventArgs e)
        {
            treeListView1.ExpandAllNodes();
        }
    }

    #region Data
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public List<Employee> Employees { get; set; }
        public Employee()
        {
            Employees = new List<Employee>();
        }
    }

    public static class Stuff
    {
        public static List<Employee> GetStuff()
        {
            List<Employee> stuff = new List<Employee>();
            stuff.Add(new Employee() { Name = "Gregory S. Price", Department = "", Position = "President" });
            stuff.Add(new Employee() { Name = "Irma R. Marshall", Department = "Marketing", Position = "Vice President" });
            stuff.Add(new Employee() { Name = "John C. Powell", Department = "Operations", Position = "Vice President" });
            stuff.Add(new Employee() { Name = "Christian P. Laclair", Department = "Production", Position = "Vice President" });
            stuff.Add(new Employee() { Name = "Karen J. Kelly", Department = "Finance", Position = "Vice President" });

            stuff.First().Employees.Add(new Employee() { Name = "Brian C. Cowling", Department = "Marketing", Position = "Manager" });
            stuff.First().Employees.First().Employees.Add(new Employee() { Name = "Thomas C. Dawson", Department = "Marketing", Position = "Manager" });
            stuff.First().Employees.First().Employees.Add(new Employee() { Name = "Angel M. Wilson", Department = "Marketing", Position = "Manager" });
            stuff.First().Employees.First().Employees.Add(new Employee() { Name = "Bryan R. Henderson", Department = "Marketing", Position = "Manager" });
            return stuff;
        }
    }
    #endregion
}