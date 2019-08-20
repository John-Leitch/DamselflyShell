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
            _Name = name;
            _ItemPath = itemPath;
            _Type = type;
            _Usage = usage;
            QueueLoad(force: true);
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

        partial void OnTypeChanged() => QueueLoad();

        partial void OnItemPathChanged() => QueueLoad();

        partial void OnNameChanged() => QueueLoad();

        //public UsageRecord Usage { get; set; }

        private void QueueLoad(bool force = false)
        {
            //if (!force && !IsDefaultOrError(SearchItemSource))
            //{
            //    return;
            //}

            ImageSourceBackgroundWorker.LoadAsync(
                ItemPath,
                Name,
                Type,
                x =>
                {
                    //if (SearchItemSource == null || IsDefaultOrError(SearchItemSource))

                    //if (x != ErrorImage.Value ||
                    //SearchItemSource == null ||
                    //SearchItemSource == DefaultImage.Value)
                    //{
                        SearchItemSource = x;
                    //}
                });
        }

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
