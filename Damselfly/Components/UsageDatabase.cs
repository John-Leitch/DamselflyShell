using Components;
using Components.Json;
using Damselfly.Components.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using RecordTable = System.Collections.Generic.Dictionary<
    string,
    System.Collections.Generic.Dictionary<string, Damselfly.Components.UsageRecord>>;

namespace Damselfly.Components
{
    public class UsageDatabase
    {
        private Dictionary<SearchItemType, Dictionary<string, UsageRecord>> _dict;

        private static readonly object _sync = new object();

        private static readonly string _usageFile = PathHelper.GetExecutingPath("usage.json");

        public static UsageDatabase Instance { get; private set; }

        public UsageDatabase(
             Dictionary<SearchItemType, Dictionary<string, UsageRecord>> dict)
        {
            lock (_sync)
            {
                _dict = dict;

                if (Instance != null)
                {
                    throw new InvalidOperationException(
                        "Only one instance of UsageDatabase permitted.");
                }

                Instance = this;
            }
        }

        public void Save() => File.WriteAllBytes(_usageFile, Utf8Json.JsonSerializer.Serialize(_dict));

        public static UsageDatabase Load()
        {
            if (FileSystemCache.FileExists(_usageFile))
            {
                using (var s = File.OpenRead(_usageFile))
                {
                    return new UsageDatabase(
                        Utf8Json.JsonSerializer.Deserialize<Dictionary<SearchItemType, Dictionary<string, UsageRecord>>>(s));
                }
            }

            return new UsageDatabase(new Dictionary<SearchItemType, Dictionary<string, UsageRecord>>());
        }

        public bool TryGetValue(SearchItemType key, out Dictionary<string, UsageRecord> value) =>
            _dict.TryGetValue(key, out value);

        public Dictionary<string, UsageRecord> GetOrAdd(SearchItemType type) => _dict.GetOrAdd(type);

        public UsageRecord GetRecord(SearchItemType type, string name)
        {
            lock (_sync)
            {
                return _dict.GetOrAdd(type).GetOrAdd(name);
            }
        }
    }
}
