using global::Components.Aphid.Parser;
using global::Components.Aphid.Interpreter;


namespace Damselfly.ViewModels
{
    using global::Components.Aphid.Lexer;
    using global::Components.Aphid.Parser;
    using System.Collections.Generic;
    
    public static partial class AphidCompilerResources
    {
        public static List<AphidExpression> ByteCode_cdd2a092a6a30fcd295314341aca114a()
        {
            return             new List<AphidExpression>
            {
                new FunctionExpression(
                    new List<AphidExpression>
                    {
                    },
                    new List<AphidExpression>
                    {
                        new IdentifierExpression(
                            "ViewModel",
                            new List<IdentifierExpression>
                            {
                            }
                        ),
                        new UnaryOperatorExpression(
                            AphidTokenType.usingKeyword,
                            new BinaryOperatorExpression(
                                new IdentifierExpression(
                                    "Damselfly",
                                    new List<IdentifierExpression>
                                    {
                                    }
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "Components",
                                    new List<IdentifierExpression>
                                    {
                                    }
                                )
                            ),
                            false
                        ),
                        new UnaryOperatorExpression(
                            AphidTokenType.usingKeyword,
                            new BinaryOperatorExpression(
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Damselfly",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "Components",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    )
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "Search",
                                    new List<IdentifierExpression>
                                    {
                                    }
                                )
                            ),
                            false
                        ),
                        new UnaryOperatorExpression(
                            AphidTokenType.usingKeyword,
                            new BinaryOperatorExpression(
                                new IdentifierExpression(
                                    "System",
                                    new List<IdentifierExpression>
                                    {
                                    }
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "Windows",
                                    new List<IdentifierExpression>
                                    {
                                    }
                                )
                            ),
                            false
                        ),
                        new UnaryOperatorExpression(
                            AphidTokenType.usingKeyword,
                            new BinaryOperatorExpression(
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "System",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "Windows",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    )
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "Controls",
                                    new List<IdentifierExpression>
                                    {
                                    }
                                )
                            ),
                            false
                        ),
                        new UnaryOperatorExpression(
                            AphidTokenType.usingKeyword,
                            new BinaryOperatorExpression(
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "System",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "Windows",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    )
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "Media",
                                    new List<IdentifierExpression>
                                    {
                                    }
                                )
                            ),
                            false
                        ),
                        new UnaryOperatorExpression(
                            AphidTokenType.usingKeyword,
                            new BinaryOperatorExpression(
                                new BinaryOperatorExpression(
                                    new BinaryOperatorExpression(
                                        new IdentifierExpression(
                                            "System",
                                            new List<IdentifierExpression>
                                            {
                                            }
                                        ),
                                        AphidTokenType.MemberOperator,
                                        new IdentifierExpression(
                                            "Windows",
                                            new List<IdentifierExpression>
                                            {
                                            }
                                        )
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "Media",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    )
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "Animation",
                                    new List<IdentifierExpression>
                                    {
                                    }
                                )
                            ),
                            false
                        ),
                        new BinaryOperatorExpression(
                            new IdentifierExpression(
                                "Damselfly",
                                new List<IdentifierExpression>
                                {
                                }
                            ),
                            AphidTokenType.MemberOperator,
                            new IdentifierExpression(
                                "ViewModels",
                                new List<IdentifierExpression>
                                {
                                }
                            )
                        ),
                        new ObjectExpression(
                            new List<BinaryOperatorExpression>
                            {
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Window",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "SearchWindow",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "Window",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "SearchWindow",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "QueryTextBox",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "TextBox",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "QueryTextBox",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "TextBox",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Search",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "StartSearch",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "Search",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "StartSearch",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "StatusFadeIn",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "Storyboard",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "StatusFadeIn",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "Storyboard",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "StatusFadeOut",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "StatusFadeOut",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "IsHandled",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "bool",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "IsHandled",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "bool",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Query",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "string",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "Query",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "string",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "QueryError",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "QueryError",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Output",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "Output",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Status",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "Status",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "StatusVisibility",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "Visibility",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "StatusVisibility",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "Visibility",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "SelectedMatch",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "SearchItem",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "SelectedMatch",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "SearchItem",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                            },
                            new IdentifierExpression(
                                "SearchViewModel",
                                new List<IdentifierExpression>
                                {
                                    new IdentifierExpression(
                                        "class",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                }
                            )
                        ),
                        new ObjectExpression(
                            new List<BinaryOperatorExpression>
                            {
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "SearchItemSource",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "ImageSource",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "SearchItemSource",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "ImageSource",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Type",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "SearchItemType",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "Type",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "SearchItemType",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "ItemPath",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "string",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "ItemPath",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "string",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Name",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "Name",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Usage",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "UsageRecord",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    ),
                                    AphidTokenType.ColonOperator,
                                    new IdentifierExpression(
                                        "Usage",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "UsageRecord",
                                                new List<IdentifierExpression>
                                                {
                                                }
                                            ),
                                        }
                                    )
                                ),
                            },
                            new IdentifierExpression(
                                "SearchItem",
                                new List<IdentifierExpression>
                                {
                                    new IdentifierExpression(
                                        "class",
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                }
                            )
                        ),
                    }
                ),
            }
;
        }
    }
}

namespace Damselfly.ViewModels
{
    using Damselfly.Components;
    using Damselfly.Components.Search;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    public partial class SearchViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        private SearchWindow _Window;

        public SearchWindow Window
        {
            get
            {
                return _Window;
            }
            set
            {
                WindowChanging?.Invoke(this, System.EventArgs.Empty);
                _Window = value;
                WindowChanged?.Invoke(this, System.EventArgs.Empty);
                OnWindowChangedInternal();
                OnWindowChanged();
                InvokePropertyChanged("Window");
            }
        }

        private TextBox _QueryTextBox;

        public TextBox QueryTextBox
        {
            get
            {
                return _QueryTextBox;
            }
            set
            {
                QueryTextBoxChanging?.Invoke(this, System.EventArgs.Empty);
                _QueryTextBox = value;
                QueryTextBoxChanged?.Invoke(this, System.EventArgs.Empty);
                OnQueryTextBoxChangedInternal();
                OnQueryTextBoxChanged();
                InvokePropertyChanged("QueryTextBox");
            }
        }

        private StartSearch _Search;

        public StartSearch Search
        {
            get
            {
                return _Search;
            }
            set
            {
                SearchChanging?.Invoke(this, System.EventArgs.Empty);
                _Search = value;
                SearchChanged?.Invoke(this, System.EventArgs.Empty);
                OnSearchChangedInternal();
                OnSearchChanged();
                InvokePropertyChanged("Search");
            }
        }

        private Storyboard _StatusFadeIn;

        public Storyboard StatusFadeIn
        {
            get
            {
                return _StatusFadeIn;
            }
            set
            {
                StatusFadeInChanging?.Invoke(this, System.EventArgs.Empty);
                _StatusFadeIn = value;
                StatusFadeInChanged?.Invoke(this, System.EventArgs.Empty);
                OnStatusFadeInChangedInternal();
                OnStatusFadeInChanged();
                InvokePropertyChanged("StatusFadeIn");
            }
        }

        private Storyboard _StatusFadeOut;

        public Storyboard StatusFadeOut
        {
            get
            {
                return _StatusFadeOut;
            }
            set
            {
                StatusFadeOutChanging?.Invoke(this, System.EventArgs.Empty);
                _StatusFadeOut = value;
                StatusFadeOutChanged?.Invoke(this, System.EventArgs.Empty);
                OnStatusFadeOutChangedInternal();
                OnStatusFadeOutChanged();
                InvokePropertyChanged("StatusFadeOut");
            }
        }

        private bool _IsHandled;

        public bool IsHandled
        {
            get
            {
                return _IsHandled;
            }
            set
            {
                IsHandledChanging?.Invoke(this, System.EventArgs.Empty);
                _IsHandled = value;
                IsHandledChanged?.Invoke(this, System.EventArgs.Empty);
                OnIsHandledChangedInternal();
                OnIsHandledChanged();
                InvokePropertyChanged("IsHandled");
            }
        }

        private string _Query;

        public string Query
        {
            get
            {
                return _Query;
            }
            set
            {
                QueryChanging?.Invoke(this, System.EventArgs.Empty);
                _Query = value;
                QueryChanged?.Invoke(this, System.EventArgs.Empty);
                OnQueryChangedInternal();
                OnQueryChanged();
                InvokePropertyChanged("Query");
            }
        }

        private string _QueryError;

        public string QueryError
        {
            get
            {
                return _QueryError;
            }
            set
            {
                QueryErrorChanging?.Invoke(this, System.EventArgs.Empty);
                _QueryError = value;
                QueryErrorChanged?.Invoke(this, System.EventArgs.Empty);
                OnQueryErrorChangedInternal();
                OnQueryErrorChanged();
                InvokePropertyChanged("QueryError");
            }
        }

        private string _Output;

        public string Output
        {
            get
            {
                return _Output;
            }
            set
            {
                OutputChanging?.Invoke(this, System.EventArgs.Empty);
                _Output = value;
                OutputChanged?.Invoke(this, System.EventArgs.Empty);
                OnOutputChangedInternal();
                OnOutputChanged();
                InvokePropertyChanged("Output");
            }
        }

        private string _Status;

        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                StatusChanging?.Invoke(this, System.EventArgs.Empty);
                _Status = value;
                StatusChanged?.Invoke(this, System.EventArgs.Empty);
                OnStatusChangedInternal();
                OnStatusChanged();
                InvokePropertyChanged("Status");
            }
        }

        private Visibility _StatusVisibility;

        public Visibility StatusVisibility
        {
            get
            {
                return _StatusVisibility;
            }
            set
            {
                StatusVisibilityChanging?.Invoke(this, System.EventArgs.Empty);
                _StatusVisibility = value;
                StatusVisibilityChanged?.Invoke(this, System.EventArgs.Empty);
                OnStatusVisibilityChangedInternal();
                OnStatusVisibilityChanged();
                InvokePropertyChanged("StatusVisibility");
            }
        }

        private SearchItem _SelectedMatch;

        public SearchItem SelectedMatch
        {
            get
            {
                return _SelectedMatch;
            }
            set
            {
                SelectedMatchChanging?.Invoke(this, System.EventArgs.Empty);
                _SelectedMatch = value;
                SelectedMatchChanged?.Invoke(this, System.EventArgs.Empty);
                OnSelectedMatchChangedInternal();
                OnSelectedMatchChanged();
                InvokePropertyChanged("SelectedMatch");
            }
        }

        public event System.EventHandler WindowChanging, WindowChanged;
        partial void OnWindowChanged();
        private void OnWindowChangedInternal()
        {
        }
        
        public event System.EventHandler QueryTextBoxChanging, QueryTextBoxChanged;
        partial void OnQueryTextBoxChanged();
        private void OnQueryTextBoxChangedInternal()
        {
        }
        
        public event System.EventHandler SearchChanging, SearchChanged;
        partial void OnSearchChanged();
        private void OnSearchChangedInternal()
        {
        }
        
        public event System.EventHandler StatusFadeInChanging, StatusFadeInChanged;
        partial void OnStatusFadeInChanged();
        private void OnStatusFadeInChangedInternal()
        {
        }
        
        public event System.EventHandler StatusFadeOutChanging, StatusFadeOutChanged;
        partial void OnStatusFadeOutChanged();
        private void OnStatusFadeOutChangedInternal()
        {
        }
        
        public event System.EventHandler IsHandledChanging, IsHandledChanged;
        partial void OnIsHandledChanged();
        private void OnIsHandledChangedInternal()
        {
        }
        
        public event System.EventHandler QueryChanging, QueryChanged;
        partial void OnQueryChanged();
        private void OnQueryChangedInternal()
        {
        }
        
        public event System.EventHandler QueryErrorChanging, QueryErrorChanged;
        partial void OnQueryErrorChanged();
        private void OnQueryErrorChangedInternal()
        {
        }
        
        public event System.EventHandler OutputChanging, OutputChanged;
        partial void OnOutputChanged();
        private void OnOutputChangedInternal()
        {
        }
        
        public event System.EventHandler StatusChanging, StatusChanged;
        partial void OnStatusChanged();
        private void OnStatusChangedInternal()
        {
        }
        
        public event System.EventHandler StatusVisibilityChanging, StatusVisibilityChanged;
        partial void OnStatusVisibilityChanged();
        private void OnStatusVisibilityChangedInternal()
        {
        }
        
        public event System.EventHandler SelectedMatchChanging, SelectedMatchChanged;
        partial void OnSelectedMatchChanged();
        private void OnSelectedMatchChangedInternal()
        {
        }
        

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void InvokePropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName] string callerName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(callerName));
            }
        }

        protected void SetProperty<T>(
            ref T property,
            T value,
            [System.Runtime.CompilerServices.CallerMemberName] string callerName = null)
        {
            property = value;
            InvokePropertyChanged(callerName);
        }
    }

    public partial class SearchItem : System.ComponentModel.INotifyPropertyChanged
    {
        private ImageSource _SearchItemSource;

        public ImageSource SearchItemSource
        {
            get
            {
                return _SearchItemSource;
            }
            set
            {
                SearchItemSourceChanging?.Invoke(this, System.EventArgs.Empty);
                _SearchItemSource = value;
                SearchItemSourceChanged?.Invoke(this, System.EventArgs.Empty);
                OnSearchItemSourceChangedInternal();
                OnSearchItemSourceChanged();
                InvokePropertyChanged("SearchItemSource");
            }
        }

        private SearchItemType _Type;

        public SearchItemType Type
        {
            get
            {
                return _Type;
            }
            set
            {
                TypeChanging?.Invoke(this, System.EventArgs.Empty);
                _Type = value;
                TypeChanged?.Invoke(this, System.EventArgs.Empty);
                OnTypeChangedInternal();
                OnTypeChanged();
                InvokePropertyChanged("Type");
            }
        }

        private string _ItemPath;

        public string ItemPath
        {
            get
            {
                return _ItemPath;
            }
            set
            {
                ItemPathChanging?.Invoke(this, System.EventArgs.Empty);
                _ItemPath = value;
                ItemPathChanged?.Invoke(this, System.EventArgs.Empty);
                OnItemPathChangedInternal();
                OnItemPathChanged();
                InvokePropertyChanged("ItemPath");
            }
        }

        private string _Name;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                NameChanging?.Invoke(this, System.EventArgs.Empty);
                _Name = value;
                NameChanged?.Invoke(this, System.EventArgs.Empty);
                OnNameChangedInternal();
                OnNameChanged();
                InvokePropertyChanged("Name");
            }
        }

        private UsageRecord _Usage;

        public UsageRecord Usage
        {
            get
            {
                return _Usage;
            }
            set
            {
                UsageChanging?.Invoke(this, System.EventArgs.Empty);
                _Usage = value;
                UsageChanged?.Invoke(this, System.EventArgs.Empty);
                OnUsageChangedInternal();
                OnUsageChanged();
                InvokePropertyChanged("Usage");
            }
        }

        public event System.EventHandler SearchItemSourceChanging, SearchItemSourceChanged;
        partial void OnSearchItemSourceChanged();
        private void OnSearchItemSourceChangedInternal()
        {
        }
        
        public event System.EventHandler TypeChanging, TypeChanged;
        partial void OnTypeChanged();
        private void OnTypeChangedInternal()
        {
        }
        
        public event System.EventHandler ItemPathChanging, ItemPathChanged;
        partial void OnItemPathChanged();
        private void OnItemPathChangedInternal()
        {
        }
        
        public event System.EventHandler NameChanging, NameChanged;
        partial void OnNameChanged();
        private void OnNameChangedInternal()
        {
        }
        
        public event System.EventHandler UsageChanging, UsageChanged;
        partial void OnUsageChanged();
        private void OnUsageChangedInternal()
        {
        }
        

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void InvokePropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName] string callerName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(callerName));
            }
        }

        protected void SetProperty<T>(
            ref T property,
            T value,
            [System.Runtime.CompilerServices.CallerMemberName] string callerName = null)
        {
            property = value;
            InvokePropertyChanged(callerName);
        }
    }

}

