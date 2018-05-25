using Components.Json;
using Damselfly.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Damselfly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private SearchViewModel _searchViewModel;

        public SearchWindow()
        {
            InitializeComponent();
            Top = SystemParameters.PrimaryScreenHeight - Height - 40;
            Left = 0;
            SearchItemListBox.Loaded += SearchItemListBox_Loaded;
        }

        void SearchItemListBox_Loaded(object sender, RoutedEventArgs e)
        {
            _searchViewModel = new SearchViewModel(
                this,
                QueryTextBox,
                SearchItemListBox,
                (ScrollViewer)VisualTreeHelper.GetChild(
                    VisualTreeHelper.GetChild(SearchItemListBox, 0),
                    0));

            _searchViewModel.Init();
            PreviewKeyDown += _searchViewModel.Control_PreviewKeyDown;
            IsVisibleChanged += _searchViewModel.Control_IsVisibleChanged;
            DataContext = _searchViewModel;
        }
    }
}
