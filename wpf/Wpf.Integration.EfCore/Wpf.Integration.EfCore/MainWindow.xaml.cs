using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using Wpf.Integration.EfCore.Context;
using Wpf.Integration.EfCore.Models;

namespace Wpf.Integration.EfCore;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ProductContext _productContext = new();

    private readonly CollectionViewSource _categoryViewSource;

    public MainWindow()
    {
        InitializeComponent();
        _categoryViewSource = (CollectionViewSource)FindResource("CategoryViewSource");
    }

    /// <summary>
    /// 窗体加载时查询所有产品类别信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LoadCategories(object sender, RoutedEventArgs e)
    {
        // 确保数据库已创建
        _productContext.Database.EnsureCreated();

        // 查询所有产品类别信息
        _productContext.Categories.Load();

        // 绑定到数据源
        _categoryViewSource.Source = _productContext.Categories
            .Local
            .ToObservableCollection();
    }

    /// <summary>
    /// 窗体关闭时释放资源
    /// </summary>
    /// <param name="e"></param>
    protected override void OnClosing(CancelEventArgs e)
    {
        // 释放数据库上下文资源
        _productContext.Dispose();
        base.OnClosing(e);
    }

    /// <summary>
    /// 保存产品信息
    /// </summary>
    /// <param name="sender">事件触发源</param>
    /// <param name="e">事件参数</param>
    private void SaveProducts(object sender, RoutedEventArgs e)
    {
        // 保存修改
        _productContext.SaveChanges();

        // 强制让 DataGrid 控件刷新数据到最新值
        CategoryDataGrid.Items.Refresh();
        ProductsDataGrid.Items.Refresh();
    }

    private void EditCategory(object sender, RoutedEventArgs e)
    {
        if (CategoryDataGrid.SelectedItem is not Category category)
        {
            return;
        }

        Console.WriteLine($"Selected Item: {category}");

        category.Name = "New Category";
    }
}