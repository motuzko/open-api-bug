using System.Runtime.Serialization;

namespace Demo.Models.Models;

public enum MarginType
{
    [EnumMember(Value = "Initial")] Initial = 1,

    [EnumMember(Value = "Maintenance")] Maintenance = 2
}