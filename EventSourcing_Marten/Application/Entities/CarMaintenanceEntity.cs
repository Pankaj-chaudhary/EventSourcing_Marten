using Marten.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public sealed class CarMaintenaceEntity
    {
        [Identity]
        public Guid CarId { get; set; }

        public List<MaintenaceEntity> MaintainacePlanTodo { get; set; } = new List<MaintenaceEntity>();
    }

    public sealed class MaintenaceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }

    }
}
