using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Location.Entity.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RegionType
    {
        polygon = 1,
        circle = 2,
    }
}
