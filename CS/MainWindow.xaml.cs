using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace TreeListFilter {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            treeList.ItemsSource = Employees.GetStaff();
            treeListView1.ExpandAllNodes();
            Dispatcher.BeginInvoke(new Action(() => {
                treeListView1.CollapseAllNodes();
            }));
        }
        private void treeList_FilterChanged(object sender, RoutedEventArgs e) {
            treeListView1.ExpandAllNodes();
        }
    }
    public class Employee {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public List<Employee> Employees { get; set; }
        public Employee() {
            Employees = new List<Employee>();
        }
    }

    public static class Employees {
        public static List<Employee> GetStaff() {
            List<Employee> staff = new List<Employee>();
            staff.Add(new Employee() { Name = "Gregory S. Price", Department = "", Position = "President" });
            staff.Add(new Employee() { Name = "Irma R. Marshall", Department = "Marketing", Position = "Vice President" });
            staff.Add(new Employee() { Name = "John C. Powell", Department = "Operations", Position = "Vice President" });
            staff.Add(new Employee() { Name = "Christian P. Laclair", Department = "Production", Position = "Vice President" });
            staff.Add(new Employee() { Name = "Karen J. Kelly", Department = "Finance", Position = "Vice President" });

            staff.First().Employees.Add(new Employee() { Name = "Brian C. Cowling", Department = "Marketing", Position = "Manager" });
            staff.First().Employees.First().Employees.Add(new Employee() { Name = "Thomas C. Dawson", Department = "Marketing", Position = "Manager" });
            staff.First().Employees.First().Employees.Add(new Employee() { Name = "Angel M. Wilson", Department = "Marketing", Position = "Manager" });
            staff.First().Employees.First().Employees.Add(new Employee() { Name = "Bryan R. Henderson", Department = "Marketing", Position = "Manager" });
            return staff;
        }
    }
}
