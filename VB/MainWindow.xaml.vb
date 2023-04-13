Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows

Namespace TreeListFilter

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.treeList.ItemsSource = GetStaff()
            Me.treeListView1.ExpandAllNodes()
            Dispatcher.BeginInvoke(New Action(Sub() Me.treeListView1.CollapseAllNodes()))
        End Sub

        Private Sub treeList_FilterChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.treeListView1.ExpandAllNodes()
        End Sub
    End Class

    Public Class Employee

        Public Property Name As String

        Public Property Position As String

        Public Property Department As String

        Public Property Employees As List(Of Employee)

        Public Sub New()
            Employees = New List(Of Employee)()
        End Sub
    End Class

    Public Module Employees

        Public Function GetStaff() As List(Of Employee)
            Dim staff As List(Of Employee) = New List(Of Employee)()
            staff.Add(New Employee() With {.Name = "Gregory S. Price", .Department = "", .Position = "President"})
            staff.Add(New Employee() With {.Name = "Irma R. Marshall", .Department = "Marketing", .Position = "Vice President"})
            staff.Add(New Employee() With {.Name = "John C. Powell", .Department = "Operations", .Position = "Vice President"})
            staff.Add(New Employee() With {.Name = "Christian P. Laclair", .Department = "Production", .Position = "Vice President"})
            staff.Add(New Employee() With {.Name = "Karen J. Kelly", .Department = "Finance", .Position = "Vice President"})
            Enumerable.First(staff).Employees.Add(New Employee() With {.Name = "Brian C. Cowling", .Department = "Marketing", .Position = "Manager"})
            Enumerable.First(Enumerable.First(staff).Employees).Employees.Add(New Employee() With {.Name = "Thomas C. Dawson", .Department = "Marketing", .Position = "Manager"})
            Enumerable.First(Enumerable.First(staff).Employees).Employees.Add(New Employee() With {.Name = "Angel M. Wilson", .Department = "Marketing", .Position = "Manager"})
            Enumerable.First(Enumerable.First(staff).Employees).Employees.Add(New Employee() With {.Name = "Bryan R. Henderson", .Department = "Marketing", .Position = "Manager"})
            Return staff
        End Function
    End Module
End Namespace
