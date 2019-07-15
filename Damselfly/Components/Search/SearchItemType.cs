using System.Runtime.Serialization;

namespace Damselfly.Components.Search
{
    [DataContract]
    public enum SearchItemType
    {
        [EnumMember(Value = "0")]
        StartMenu = 0,
        [EnumMember(Value = "1")]
        Directory = 1,
        [EnumMember(Value = "2")]
        File = 2,
        [EnumMember(Value = "3")]
        Command = 3
    }
}
