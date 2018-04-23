Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports System.Windows.Interactivity
Imports DevExpress.Data.Filtering.Helpers
Imports System.ComponentModel
Imports DevExpress.Data.Filtering

Namespace TreeListFilter
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            treeList.ItemsSource = Stuff.GetStuff()
            treeListView1.ExpandAllNodes()
            Dispatcher.BeginInvoke(New Action(Sub() treeListView1.CollapseAllNodes()))
        End Sub

        Private Sub treeList_FilterChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            treeListView1.ExpandAllNodes()
        End Sub
    End Class

    #Region "Data"
    Public Class Employee
        Public Property Name() As String
        Public Property Position() As String
        Public Property Department() As String
        Public Property Employees() As List(Of Employee)
        Public Sub New()
            Employees = New List(Of Employee)()
        End Sub
    End Class

    Public NotInheritable Class Stuff

        Private Sub New()
        End Sub

        Public Shared Function GetStuff() As List(Of Employee)

            Dim stuff_Renamed As New List(Of Employee)()
            stuff_Renamed.Add(New Employee() With {.Name = "Gregory S. Price", .Department = "", .Position = "President"})
            stuff_Renamed.Add(New Employee() With {.Name = "Irma R. Marshall", .Department = "Marketing", .Position = "Vice President"})
            stuff_Renamed.Add(New Employee() With {.Name = "John C. Powell", .Department = "Operations", .Position = "Vice President"})
            stuff_Renamed.Add(New Employee() With {.Name = "Christian P. Laclair", .Department = "Production", .Position = "Vice President"})
            stuff_Renamed.Add(New Employee() With {.Name = "Karen J. Kelly", .Department = "Finance", .Position = "Vice President"})

            stuff_Renamed.First().Employees.Add(New Employee() With {.Name = "Brian C. Cowling", .Department = "Marketing", .Position = "Manager"})
            stuff_Renamed.First().Employees.First().Employees.Add(New Employee() With {.Name = "Thomas C. Dawson", .Department = "Marketing", .Position = "Manager"})
            stuff_Renamed.First().Employees.First().Employees.Add(New Employee() With {.Name = "Angel M. Wilson", .Department = "Marketing", .Position = "Manager"})
            stuff_Renamed.First().Employees.First().Employees.Add(New Employee() With {.Name = "Bryan R. Henderson", .Department = "Marketing", .Position = "Manager"})
            Return stuff_Renamed
        End Function
    End Class
    #End Region
End Namespace