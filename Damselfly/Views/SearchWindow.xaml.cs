using Components;
using Components.External;
using Damselfly.ViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Damselfly
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public partial class SearchWindow : Window, IAutoSingleton<SearchWindow>
    {
        public SearchViewModel SearchViewModel { get; private set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public SearchWindow()
        {
            this.Init();            
            InitializeComponent();
            
        }

        private void SearchItemListBox_Loaded(object sender, RoutedEventArgs e)
        {
            SearchViewModel = new SearchViewModel(
                this,
                QueryTextBox,
                SearchItemListBox,
                (ScrollViewer)VisualTreeHelper.GetChild(
                    VisualTreeHelper.GetChild(SearchItemListBox, 0),
                    0))
                {
                    StatusFadeIn = ((Storyboard)FindResource("StatusFadeIn")),
                    StatusFadeOut = ((Storyboard)FindResource("StatusFadeOut"))
                };

            SearchViewModel.Init();
            PreviewKeyDown += SearchViewModel.Control_PreviewKeyDown;
            IsVisibleChanged += SearchViewModel.Control_IsVisibleChanged;
            DataContext = SearchViewModel;
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            Top = SystemParameters.PrimaryScreenHeight - Height - 30;
            Left = 0;
        }
    }
}
