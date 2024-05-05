using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class CarAggregateEntity
    {
        public Guid Id { get; set; }

        public Location? InitialPosition { get; set; }

        public Location CurrentPosition { get; set; }

        public int Traveled { get; set; }

        public void Apply(UpdateLocationRequest e)
        {
            if (InitialPosition == null)
                InitialPosition = new Location(e.Latitute, e.Longitude);

            CurrentPosition = new Location(e.Latitute, e.Longitude);
            Traveled += e.Longitude; //just a sample traveled calculation
        }
    }
}
