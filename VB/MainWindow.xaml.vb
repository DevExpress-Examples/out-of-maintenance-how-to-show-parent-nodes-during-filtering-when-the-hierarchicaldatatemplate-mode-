Imports Microsoft.VisualBasic
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
			Dispatcher.BeginInvoke(New Action(Function() AnonymousMethod1()))
		End Sub
		
		Private Function AnonymousMethod1() As Boolean
			treeListView1.CollapseAllNodes()
			Return True
		End Function

		Private Sub treeListView1_CustomNodeFilter_1(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.TreeList.TreeListNodeFilterEventArgs)
			Dim filter As CriteriaOperator = (CType(sender, TreeListView)).DataControl.FilterCriteria
			If CriteriaOperator.ReferenceEquals(filter, Nothing) Then
				Return
			End If
			If IsNodeVisible(e.Node, filter) OrElse IsChildNodeVisible(e.Node, filter) Then
				MakeNodeVisible(e.Node)
				e.Visible = True
			Else
				e.Visible = False
			End If
			e.Handled = True
		End Sub
		Public Function IsChildNodeVisible(ByVal node As TreeListNode, ByVal filter As CriteriaOperator) As Boolean
			For Each n As TreeListNode In node.Nodes
				If IsNodeVisible(n, filter) Then
					Return True
				ElseIf IsChildNodeVisible(n, filter) Then
					Return True
				End If
			Next n
			Return False
		End Function
		Public Function IsNodeVisible(ByVal node As TreeListNode, ByVal filter As CriteriaOperator) As Boolean
			Dim ee As New ExpressionEvaluator(TypeDescriptor.GetProperties(node.Content.GetType()), filter, False)
			Return ee.Fit(node.Content)
		End Function
		Public Sub MakeNodeVisible(ByVal node As TreeListNode)
			If node.ParentNode Is Nothing Then
				Return
			End If
			node.ParentNode.IsExpanded = True
			MakeNodeVisible(node.ParentNode)
		End Sub
	End Class

	#Region "Data"
	Public Class Employee
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privatePosition As String
		Public Property Position() As String
			Get
				Return privatePosition
			End Get
			Set(ByVal value As String)
				privatePosition = value
			End Set
		End Property
		Private privateDepartment As String
		Public Property Department() As String
			Get
				Return privateDepartment
			End Get
			Set(ByVal value As String)
				privateDepartment = value
			End Set
		End Property
		Private privateEmployees As List(Of Employee)
		Public Property Employees() As List(Of Employee)
			Get
				Return privateEmployees
			End Get
			Set(ByVal value As List(Of Employee))
				privateEmployees = value
			End Set
		End Property
		Public Sub New()
			Employees = New List(Of Employee)()
		End Sub
	End Class

	Public NotInheritable Class Stuff
		Private Sub New()
		End Sub
		Public Shared Function GetStuff() As List(Of Employee)
			Dim stuff As New List(Of Employee)()
			stuff.Add(New Employee() With {.Name = "Gregory S. Price", .Department = "", .Position = "President"})
			stuff.Add(New Employee() With {.Name = "Irma R. Marshall", .Department = "Marketing", .Position = "Vice President"})
			stuff.Add(New Employee() With {.Name = "John C. Powell", .Department = "Operations", .Position = "Vice President"})
			stuff.Add(New Employee() With {.Name = "Christian P. Laclair", .Department = "Production", .Position = "Vice President"})
			stuff.Add(New Employee() With {.Name = "Karen J. Kelly", .Department = "Finance", .Position = "Vice President"})

			stuff.First().Employees.Add(New Employee() With {.Name = "Brian C. Cowling", .Department = "Marketing", .Position = "Manager"})
			stuff.First().Employees.First().Employees.Add(New Employee() With {.Name = "Thomas C. Dawson", .Department = "Marketing", .Position = "Manager"})
			stuff.First().Employees.First().Employees.Add(New Employee() With {.Name = "Angel M. Wilson", .Department = "Marketing", .Position = "Manager"})
			stuff.First().Employees.First().Employees.Add(New Employee() With {.Name = "Bryan R. Henderson", .Department = "Marketing", .Position = "Manager"})
			Return stuff
		End Function
	End Class
	#End Region
End Namespace