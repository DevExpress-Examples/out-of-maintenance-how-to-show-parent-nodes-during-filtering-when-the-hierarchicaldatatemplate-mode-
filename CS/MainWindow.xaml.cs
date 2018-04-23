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

        private void treeListView1_CustomNodeFilter_1(object sender, DevExpress.Xpf.Grid.TreeList.TreeListNodeFilterEventArgs e)
        {
            CriteriaOperator filter = ((TreeListView)sender).DataControl.FilterCriteria;
            if (CriteriaOperator.ReferenceEquals(filter, null))
                return;
            if (IsNodeVisible(e.Node, filter) || IsChildNodeVisible(e.Node, filter))
            {
                MakeNodeVisible(e.Node);
                e.Visible = true;
            }
            else
                e.Visible = false;
            e.Handled = true;
        }
        public bool IsChildNodeVisible(TreeListNode node, CriteriaOperator filter)
        {
            foreach (TreeListNode n in node.Nodes)
            {
                if (IsNodeVisible(n, filter))
                    return true;
                else if (IsChildNodeVisible(n, filter))
                    return true;
            }
            return false;
        }
        public bool IsNodeVisible(TreeListNode node, CriteriaOperator filter)
        {
            ExpressionEvaluator ee = new ExpressionEvaluator(TypeDescriptor.GetProperties(node.Content.GetType()), filter, false);
            return ee.Fit(node.Content);
        }
        public void MakeNodeVisible(TreeListNode node)
        {
            if (node.ParentNode == null)
                return;
            node.ParentNode.IsExpanded = true;
            MakeNodeVisible(node.ParentNode);
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