using Components;
using Components.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Damselfly.Components
{
    public class UsageDatabase : Dictionary<SearchItemType, Dictionary<string, UsageRecord>>
    {
        private static string _usageFile = PathHelper.GetExecutingPath("usage.json");

        private Dictionary<string, Dictionary<string, UsageRecord>> ToSerializable()
        {
            return this.ToDictionary(
                x => x.Key.ToString(), 
                x => x.Value
                    .Where(y => y.Value.HitCount > 0)
                    .ToDictionary(y => y.Key, y => y.Value));
        }

        private static UsageDatabase FromSerializable(Dictionary<string, Dictionary<string, UsageRecord>> table)
        {
            var db = new UsageDatabase();

            foreach (var k in table)
            {
                db.Add((SearchItemType)Enum.Parse(typeof(SearchItemType), k.Key), k.Value);
            }

            return db;
        }

        public void Save()
        {
            JsonSerializer.SerializeToFile(_usageFile, ToSerializable());
        }

        public static UsageDatabase Load()
        {
            if (File.Exists(_usageFile))
            {
                var t = JsonSerializer.DeserializeFile<Dictionary<string, Dictionary<string, UsageRecord>>>(
                    _usageFile);

                return t != null ? FromSerializable(t) : new UsageDatabase();
            }
            else
            {
                return new UsageDatabase();
            }            
        }

        public UsageRecord GetRecord(SearchItemType type, string name)
        {
            return this.GetOrCreate(type).GetOrCreate(name);
        }
    }
}
