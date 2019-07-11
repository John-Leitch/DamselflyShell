using Components;
using Components.Json;
using Damselfly.Components.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using RecordTable = System.Collections.Generic.Dictionary<
    string,
    System.Collections.Generic.Dictionary<string, Damselfly.Components.UsageRecord>>;

namespace Damselfly.Components
{
    [Serializable]
    public class UsageDatabase : Dictionary<SearchItemType, Dictionary<string, UsageRecord>>
    {
        private static readonly object _sync = new object();

        private static readonly string _usageFile = PathHelper.GetExecutingPath("usage.json");

        public static UsageDatabase Instance { get; private set; }

        public UsageDatabase()
        {
            lock (_sync)
            {
                if (Instance != null)
                {
                    throw new InvalidOperationException(
                        "Only one instance of UsageDatabase permitted.");
                }

                Instance = this;
            }
        }

        private RecordTable ToSerializable() =>
            this.ToDictionary(
                x => x.Key.ToString(),
                x => x.Value
                    .Where(y => y.Value.HitCount > 0)
                    .OrderByDescending(y => y.Value.HitCount)
                    .ThenBy(y => y.Key)
                    .ToDictionary(y => y.Key, y => y.Value));

        public void Save() => JsonSerializer.SerializeToFile(_usageFile, ToSerializable());

        public static UsageDatabase Load()
        {
            if (FileSystemCache.FileExists(_usageFile))
            {
                var t = JsonSerializer.DeserializeFile<RecordTable>(_usageFile);

                return t != null ? FromSerializable(t) : new UsageDatabase();
            }

            return new UsageDatabase();
        }

        public UsageRecord GetRecord(SearchItemType type, string name)
        {
            lock (_sync)
            {
                return this.GetOrAdd(type).GetOrAdd(name);
            }
        }

        private static UsageDatabase FromSerializable(RecordTable table)
        {
            var db = new UsageDatabase();

            foreach (var k in table)
            {
                db.Add((SearchItemType)Enum.Parse(typeof(SearchItemType), k.Key), k.Value);
            }

            return db;
        }
    }
}
