using Location.ResponseReuestModels.Request;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Services
{
  public  interface ICreateGeometry
    {
        Task<Geometry> CreatePolygon(RegionArea regionArea);
    }
}
