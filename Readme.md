<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
<!-- default file list end -->
# How to show parent nodes during filtering when the HierarchicalDataTemplate mode is used


<p>When the HierarchicalDataTemplate mode is used, the TreeListView creates child nodes only when you expand a parent node for the first time. So, the required step in this scenario is to expand all nodes to forcibly create them. To show parent nodes when child nodes are not filtered out, set the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfGridTreeListView_FilterModetopic">TreeListView.FilterMode</a> property to "Extended".<br /><br /><em>For versions prior to 14.2:</em><br />By default, if a child node meets filter criteria but the parent node doesn't, the parent node is hidden. To change this behavior, it is necessary to handle the CustomNodeFilter event and implement filtering logic manually. To check whether or not a node meets filter criteria, use the ExpressionEvaluator.Fit method.</p>

<br/>


