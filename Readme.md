<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128657918/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5216)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
<!-- default file list end -->
# How to show parent nodes during filtering when the HierarchicalDataTemplate mode is used


<p>When the HierarchicalDataTemplate mode is used, the TreeListView creates child nodes only when you expand a parent node for the first time. So, the required step in this scenario is to expand all nodes to forcibly create them. To show parent nodes when child nodes are not filtered out, set the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfGridTreeListView_FilterModetopic">TreeListView.FilterMode</a> property to "Extended".<br /><br /><em>For versions prior to 14.2:</em><br />By default, if a child node meets filter criteria but the parent node doesn't, the parent node is hidden. To change this behavior, it is necessary to handle the CustomNodeFilter event and implement filtering logic manually. To check whether or not a node meets filter criteria, use the ExpressionEvaluator.Fit method.</p>

<br/>


