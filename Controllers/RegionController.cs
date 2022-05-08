using Location.Entity;
using Location.ResponseReuestModels;
using Location.ResponseReuestModels.Request;
using Location.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _IRegionService;

        public RegionController(IRegionService IRegionService)
        {
            _IRegionService = IRegionService;
        }

        [HttpPost]
        //x-longlatitude ,y-latitude
        public async Task<IActionResult> CreateRegion(RegionModel region)
        {
            try
            {
                var regionCreated = await _IRegionService.CreateRegion(region).ConfigureAwait(true);
                return Ok(regionCreated);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("Coordinate/{lat}/{lon}")]
        public async Task<string> findRegion(double lat,double lon)
        {
            CoordinateModel coordinateModel = new CoordinateModel();
            coordinateModel.lat = lat;
            coordinateModel.lon = lon;
            var y = await  _IRegionService.findPointRegionRepo(coordinateModel);
            if (y.Equals(true))
            {
                return "Successfully find the Region";
            }
            else
            {
                return "Failed to find the Region";
            }
              
        }

        [HttpGet("Regions")]
        public async Task<List<Region>> getAllRegionsService()
        {
            var regions =await  _IRegionService.getAllRegionsRepo();
            return regions;
        }

    }
}
