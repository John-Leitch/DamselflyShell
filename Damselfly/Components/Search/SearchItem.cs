using Components;
using System;
using System.Diagnostics;
using System.Drawing;
using ST = Damselfly.Components.Search.SearchItemType;
using SI = Damselfly.ViewModels.SearchItem;
using Img = System.Windows.Media.ImageSource;
using static Damselfly.Components.IconLoader;
using static Damselfly.Components.UsageDatabase;
using Damselfly.Components;
using Damselfly.Components.Search;
using Damselfly.Components.Naming;

namespace Damselfly.ViewModels
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public partial class SearchItem
    {
        public SearchItem()
        {
            
        }

        public SearchItem(string name, string itemPath, ST type, UsageRecord usage)
        {
            Name = name;
            ItemPath = itemPath;
            Type = type;
            Usage = usage;
        }

        public SearchItem(string name, string itemPath, ST type)
            : this(name, itemPath, type, Instance.GetRecord(type, itemPath ?? name))
        {
        }

        public SearchItem(string name, ST type)
            : this(name, name, type, Instance.GetRecord(type, name))
        {
            if (type == ST.Command)
            {
                throw new InvalidOperationException(
                    "Command type should not have path set");
            }
        }


        //private Img _searchItemSource;

        //public Img SearchItemSource
        //{
        //    get => _searchItemSource ?? DefaultImage.Value;
        //    set => SetProperty(ref _searchItemSource, value);
        //}

        //private ST _type;

        //public ST Type
        //{
        //    get => _type;
        //    set
        //    {
        //        _type = value;
        //        QueueLoad();
        //    }
        //}

        //private string _itemPath;

        //public string ItemPath
        //{
        //    get => _itemPath;
        //    set
        //    {
        //        _itemPath = value;
        //        QueueLoad();
        //    }
        //}

        //private string _name;

        //public string Name
        //{
        //    get => _name;
        //    set
        //    {
        //        _name = value;
        //        QueueLoad();
        //    }
        //}

        partial void OnTypeChanged() => QueueLoad();

        partial void OnItemPathChanged() => QueueLoad();

        partial void OnNameChanged() => QueueLoad();

        //public UsageRecord Usage { get; set; }

        private void QueueLoad() =>
            ImageSourceBackgroundWorker.LoadAsync(
                ItemPath,
                Name,
                Type,
                x => SearchItemSource = x);

        public string GetCommand()
        {
            switch (Type)
            {
                case ST.File:
                case ST.StartMenu:
                case ST.Directory:
                    return ItemPath;

                default:
                    return Name;
            }
        }

        public override string ToString() => $"{Type.ToString()}, {Name}, {ItemPath}";
    }
}
