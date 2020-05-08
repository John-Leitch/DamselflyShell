using Components.Json;
using Damselfly.ViewModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Damselfly.Components.Search
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class CommandSearchSource : SearchSource
    {
        private readonly string _cmdFile = PathHelper.GetExecutingPath("commands.json");

        public override bool IsCommandRepository => true;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        protected override ConcurrentBag<SearchItem> LoadItems() =>
            File.Exists(_cmdFile) ?
                new ConcurrentBag<SearchItem>(
                    JsonSerializer
                        .DeserializeFile<string[]>(_cmdFile)
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .SelectMany(SearchItemBuilder.ManyFromCommand)) :
                new ConcurrentBag<SearchItem>();

        public override void Save() =>
            JsonSerializer.SerializeToFile(
                _cmdFile,
                GetItems().Distinct().Select(x => x.Name));
    }
}
