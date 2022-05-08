using Location.ResponseReuestModels.Request;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Services
{
    public class CreateGeometry : ICreateGeometry
    {
     public async  Task<Geometry> CreatePolygon(RegionArea regionArea)
        {
            List<Coordinate> regionCoordinate = new List<Coordinate>();
            foreach(var item in regionArea.Coordinates)
            {
                regionCoordinate.Add(new Coordinate { X = item.X, Y = item.Y });
            }
            regionCoordinate.Reverse();

            GeometryFactory geometryFactory = new GeometryFactory();
            
            Geometry PolygonCreate = geometryFactory.CreatePolygon(regionCoordinate.ToArray());
           
            PolygonCreate.SRID = 4326;
            if (!PolygonCreate.IsValid)
            {
                throw new Exception("Requested polygon not valid");
            }

            return PolygonCreate;
        }



    }
}
