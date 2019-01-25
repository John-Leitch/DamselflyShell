using Components.External;
using Components.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Components.Json.JsonSerializer;

namespace Components
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class JsonRepository<TEntities> : IRepository<TEntities>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        protected virtual string ScriptFile =>
            $"{PathSanitizer.SanitizeName(typeof(TEntities).ToString(), '$')}.json";

        private bool ScriptFileExists() => File.Exists(ScriptFile);

        public TEntities Load()
        {
            if (!ScriptFileExists())
            {
                return default(TEntities);
            }

            return DeserializeFile<TEntities>(ScriptFile);
        }

        public void Save(TEntities entities) => SerializeToFile(ScriptFile, entities);
    }
}
