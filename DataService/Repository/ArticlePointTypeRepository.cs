using DataService.Entity;
using DataService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface IArticlePointTypeRepository : IRepository<ArticlePointType> { }
    public class ArticlePointTypeRepository : Repository<ArticlePointType>, IArticlePointTypeRepository
    {
    }
}
