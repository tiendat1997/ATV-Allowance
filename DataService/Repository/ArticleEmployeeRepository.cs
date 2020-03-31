using DataService.Entity;
using DataService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface IArticleEmployeeRepository : IRepository<ArticleEmployee>
    {
        List<ArticleEmployee> GetManyIncludeEmployee(Expression<Func<ArticleEmployee, bool>> where);
    }
    public class ArticleEmployeeRepository : Repository<ArticleEmployee>, IArticleEmployeeRepository
    {
        public List<ArticleEmployee> GetManyIncludeEmployee(Expression<Func<ArticleEmployee, bool>> where)
        {
            return dbSet.Where(where).Include(e => e.Employee).ToList();
        }
    }
}
