using DataService.Entity;
using DataService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface ICriteriaRepository : IRepository<Criteria>
    {
        List<Criteria> GetIncludeCriteriaValue(int articleTypeId);
    }

    public class CriteriaRepository : Repository<Criteria>, ICriteriaRepository
    {
        public List<Criteria> GetIncludeCriteriaValue(int articleTypeId)
        {
            var result = context.Criteria.Where(c => c.ArticleTypeId == articleTypeId).Include(a => a.CriteriaValue).Select(a => a).ToList();
            return result;
        }
    }
}
