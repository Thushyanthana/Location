using Location.Entity.Enum;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Entity
{
    public class Region
    {
        [Key]
        public Guid Id { get; set; }
        public RegionType RegionTypes { get; set; }

        public string RegionName { get; set; }

        public Geometry RegionArea { get; set; }
    }
}
