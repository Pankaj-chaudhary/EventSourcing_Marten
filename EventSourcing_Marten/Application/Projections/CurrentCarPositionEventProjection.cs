using Application.Models;
using Marten.Events.Projections;
using Marten.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities;

namespace Application.Projections
{

    public class CurrentCarPositionEventProjection : EventProjection
    {
        public CurrentCarPositionEventProjection()
        {
            ProjectionName = "CarActualLocation";
        }


        public CurrentCarPosition Create(UpdateLocationRequest lastLocation, IEvent e)
        {
            if(lastLocation.Longitude == 10)
            {
                throw new Exception("Intentional exception to test async");
            }
            return new CurrentCarPosition(e.Id, new Location(lastLocation.Longitude, lastLocation.Latitute));
        }
    }
}
