using Components.Json;
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

        protected override List<SearchItem> LoadItems() =>
            File.Exists(_cmdFile) ?
                JsonSerializer
                    .DeserializeFile<string[]>(_cmdFile)
                    .Distinct()
                    .Select(SearchItem.FromCommand)
                    .ToList():
                new List<SearchItem>();

        public override void Save() =>
            JsonSerializer.SerializeToFile(
                _cmdFile,
                GetItems().Distinct().Select(x => x.Name));
    }
}
