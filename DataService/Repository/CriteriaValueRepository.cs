using DataService.Entity;
using DataService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface ICriteriaValueRepository: IRepository<CriteriaValue>
    {
        void DeleteCriteriaValues(List<int> ids);
    }

    public class CriteriaValueRepository : Repository<CriteriaValue>, ICriteriaValueRepository
    {
        public void DeleteCriteriaValues(List<int> ids)
        {
            var values = context.CriteriaValue.Where(v => ids.Contains(v.Id)).ToList();
            foreach (var item in values)
            {
                context.CriteriaValue.Remove(item);
            }
            context.SaveChanges();
        }
    }
}
