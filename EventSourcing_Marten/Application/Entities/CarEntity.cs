using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class CarEntity
    {
        public Guid Id { get; set; }

        public Location? InitialPosition { get; set; }

        public Location CurrentPosition { get; set; }

        public int Traveled { get; set; }
    }
}
