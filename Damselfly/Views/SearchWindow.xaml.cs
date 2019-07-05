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
    public partial class SearchWindow : Window
    {
        public SearchViewModel SearchViewModel { get; private set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public SearchWindow()
        {
            InitializeComponent();
            Loaded += SearchWindow_Loaded;
            this.GotFocus += (o, e) =>
            {
                Top = SystemParameters.PrimaryScreenHeight - Height - 30;
                Left = 0;
            };

            Top = SystemParameters.PrimaryScreenHeight - Height - 30;
            Left = 0;
            SearchItemListBox.Loaded += SearchItemListBox_Loaded;
        }

        private void SearchWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            
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
    }
}
