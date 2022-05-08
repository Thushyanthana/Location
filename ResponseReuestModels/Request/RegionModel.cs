using Location.Entity.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Location.ResponseReuestModels.Request
{
    public class RegionModel
    {
        [Required]
        [JsonProperty("RegionType")]
        public RegionType RegionType { get; set; }

        [Required]
        [JsonProperty("RegionName")]
        public string RegionName { get; set; }

        [Required]
        [JsonProperty("RegionArea")]
        public RegionArea RegionArea { get; set; }
    }

    public class RegionArea
    {
        [JsonProperty("Coordinates")]
        public MyCoordinate[] Coordinates { get; set; }
    }

    public class MyCoordinate
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("z")]
        public string Z { get; set; }
    }
}
