using Components.Json;
using Damselfly.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Damselfly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public partial class SearchWindow : Window
    {
        public SearchViewModel SearchViewModel { get; private set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public SearchWindow()
        {
            InitializeComponent();
            Top = SystemParameters.PrimaryScreenHeight - Height - 40;
            Left = 0;
            SearchItemListBox.Loaded += SearchItemListBox_Loaded;
        }

        void SearchItemListBox_Loaded(object sender, RoutedEventArgs e)
        {
            SearchViewModel = new SearchViewModel(
                this,
                QueryTextBox,
                SearchItemListBox,
                (ScrollViewer)VisualTreeHelper.GetChild(
                    VisualTreeHelper.GetChild(SearchItemListBox, 0),
                    0));

            SearchViewModel.Init();
            PreviewKeyDown += SearchViewModel.Control_PreviewKeyDown;
            IsVisibleChanged += SearchViewModel.Control_IsVisibleChanged;
            DataContext = SearchViewModel;
        }
    }
}
