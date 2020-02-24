using DataService.Entity;
using DataService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface IDeductionRepository: IRepository<Deduction>
    {
        void UpdateRange(IList<DataService.Entity.Deduction> entities);
    }

    public class DeductionRepository : Repository<Deduction>, IDeductionRepository
    {
        public void UpdateRange(IList<Deduction> entities)
        {
            var list = dbSet.Select(e => e).ToList();
            foreach (var item in entities)
            {
                var currItem = list.Where(e => e.Id == item.Id).FirstOrDefault();
                if (currItem != null)
                {                    
                    currItem.ArticleTypeId = item.ArticleTypeId;
                    currItem.DeductionTypeId = item.DeductionTypeId;
                    currItem.DeductionValue = item.DeductionValue;
                    currItem.EmployeeId = item.EmployeeId;
                    currItem.Month = item.Month;
                    currItem.Year = item.Year;                    
                }
                else
                {
                    dbSet.Add(item);
                }
            }

            context.SaveChanges();
        }
    }
}
