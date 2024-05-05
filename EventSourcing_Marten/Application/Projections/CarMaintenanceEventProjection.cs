using Application.Entities;
using Application.Models;
using Marten.Events.Projections;
using Marten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Projections
{
    public class CarMaintenanceEventProjection : EventProjection
    {
        public async Task Project(CarMaintenanceEvent evt, IDocumentOperations ops)
        {
            var doc = await ops.LoadAsync<CarMaintenaceEntity>(evt.CarId);
            doc ??= new()
            {
                CarId = evt.CarId,
            };

            var todo = doc.MaintainacePlanTodo.SingleOrDefault(x => x.Id == evt.Id);
            if (todo == null)
            {
                doc.MaintainacePlanTodo.Add(new MaintenaceEntity
                {
                    Id = evt.Id,
                    Name = evt.Name,
                    Description = evt.Description,
                });
            }
            else
            {
                todo.Checked = evt.Checked;
            }

            ops.Store(doc);
        }

        public async Task Project(RemoveCarMaintenance evt, IDocumentOperations ops)
        {
            var doc = await ops.LoadAsync<CarMaintenaceEntity>(evt.CarId);

            doc.MaintainacePlanTodo.RemoveAll(x => x.Id == evt.Id);

            ops.Store(doc);
        }

    }
}
