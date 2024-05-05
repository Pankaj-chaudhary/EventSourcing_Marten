using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public record UpdateLocationRequest
    {
        public required int Latitute { get; init; }
        public required int Longitude { get; init; }

    }
}
