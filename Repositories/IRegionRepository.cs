using Location.Entity;
using Location.ResponseReuestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Repositories
{
  public  interface IRegionRepository
    {
        Task<Region> CreateRegion(Region regions);
        Task<Boolean> findPointRegion(CoordinateModel coordinate);
        Task<List<Region>> getAllRegions();
    }
}
