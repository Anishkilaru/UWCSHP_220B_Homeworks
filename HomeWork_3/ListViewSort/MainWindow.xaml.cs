using ListViewSort.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListViewSort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CollectionView view;
        public MainWindow()
        {
            InitializeComponent();
            List<User> items = new List<User>();
            items.Add(new User { Name = "Dave", Password = "1DavePwd" });
            items.Add(new User() { Name = "Steve", Password = "2StevePwd" });
            items.Add(new User() { Name = "Lisa", Password = "3LisaPwd" });
            uxList.ItemsSource = items;
            uxList.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ListView_OnColumnClick));
            view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
        }

        private void ListView_OnColumnClick(Object o,RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            String headerName=headerClicked.Column.Header.ToString();
            view.SortDescriptions.Clear();

            if(headerName.Equals("Name"))
            {
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
            }

        }
    }
}
