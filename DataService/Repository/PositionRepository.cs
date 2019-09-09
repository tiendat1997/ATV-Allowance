using DataService.Entity;
using DataService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface IPositionRepository : IRepository<Position>
    {

    }
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository()
        {

        }
    }
}
