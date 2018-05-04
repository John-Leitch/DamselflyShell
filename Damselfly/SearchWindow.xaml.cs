using Damselfly.ViewModels;
using System.Windows;

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
            
            _searchViewModel = new SearchViewModel(this, QueryTextBox, SearchItemListBox);
            _searchViewModel.Init();

            Loaded += SearchWindow_Loaded;
            PreviewKeyDown += _searchViewModel.Control_PreviewKeyDown;
            IsVisibleChanged += _searchViewModel.Control_IsVisibleChanged;
            DataContext = _searchViewModel;
        }

        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    _handle = ((HwndSource)PresentationSource.FromVisual(this)).Handle;
        //}

        void SearchWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _searchViewModel.Control_IsVisibleChanged(sender, new DependencyPropertyChangedEventArgs());
        }
    }
}
