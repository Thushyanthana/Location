using Location.Entity;
using Location.ResponseReuestModels;
using Location.ResponseReuestModels.Request;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Services
{
    public interface IRegionService
    {
 Task<Geometry> CreateRegion(RegionModel regionModal);
        Task<Boolean> findPointRegionRepo(CoordinateModel coordinate);

        Task<List<Region>> getAllRegionsRepo();
    }
}
