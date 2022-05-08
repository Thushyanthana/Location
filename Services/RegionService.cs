using Location.Entity;
using Location.Repositories;
using Location.ResponseReuestModels;
using Location.ResponseReuestModels.Request;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _iregionRepository;
        private readonly ICreateGeometry _icreateGeometryservice;
        public RegionService(IRegionRepository iregionRepository, ICreateGeometry icreateGeometryservice)
        {
            _iregionRepository = iregionRepository;
            _icreateGeometryservice = icreateGeometryservice;
        }

        public async Task<Geometry> CreateRegion(RegionModel regionModal)
        {
            try
            {
                var polygon = await _icreateGeometryservice.CreatePolygon(regionModal.RegionArea).ConfigureAwait(true);
                var regionType = regionModal.RegionType;

                Region regions = new Region();
                regions.RegionArea = polygon;
                regions.RegionName = regionModal.RegionName;
                regions.RegionTypes = regionType;

                var result = await _iregionRepository.CreateRegion(regions).ConfigureAwait(true);

                return polygon;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Region>> getAllRegionsRepo()
        {
            var regions = await _iregionRepository.getAllRegions();
            return regions;
        }


    public async Task<Boolean>   findPointRegionRepo(CoordinateModel coordinate)
        {
            var x = await _iregionRepository.findPointRegion(coordinate);
            if (x.Equals(true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
