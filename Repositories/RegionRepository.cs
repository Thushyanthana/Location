using Location.DatabaseContext;
using Location.Entity;
using Location.ResponseReuestModels;
using Location.ResponseReuestModels.Request;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Repositories
{

    public class RegionRepository : IRegionRepository
    {
        private readonly LocationDBContext DBContext;
        public RegionRepository(LocationDBContext locationDBContext)
        {
            DBContext = locationDBContext;
        }

        public async Task<Region> CreateRegion(Region regions)
        {
            var result = DBContext.Regions.Add(regions);
            await DBContext.SaveChangesAsync().ConfigureAwait(true);
            return result.Entity;
        }

        public async Task<List<Region>> getAllRegions()
            {
            var Regions = await DBContext.Regions.ToListAsync();
            return Regions;
            }

        public async Task<Boolean> findPointRegion(CoordinateModel coordinate)
        {
            Coordinate regionCoordinate = new Coordinate();
            regionCoordinate.X = coordinate.lat;
            regionCoordinate.Y = coordinate.lon;


            Point customerLocation = new NetTopologySuite.Geometries.Point(coordinate.lat, coordinate.lon)
            {
                SRID = 4326
            };

            var region = await DBContext.Regions.FirstOrDefaultAsync(p => p.RegionArea.Intersects(customerLocation) || p.RegionArea.Contains(customerLocation) );

           // var point = new Point(regionCoordinate);

            //var region = await DBContext.Regions.ToListAsync();

            
            
                if (region!=null)
                {
                    return true ;
                }
                else
                {
                    return false;
                }
            
            //return "Region is there" + coordinate;
        }


    }
}
