using ATV_Allowance.ViewModel;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Services
{
    public interface IArticleService
    {
        List<ArticleViewModel> GetArticle(int typeId, DateTime fromDate, DateTime toDate, int employeeId);
    }
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;
        public ArticleService()
        {
            articleRepository = new ArticleRepository();
        }

        public List<ArticleViewModel> GetArticle(int typeId, DateTime fromDate, DateTime toDate, int employeeId)
        {
            var articles = articleRepository
                        .GetMany(t => (typeId <= 0 || t.TypeId.Equals(typeId))
                                && (fromDate == null || t.Date >= fromDate)
                                && (toDate == null || t.Date <= toDate))
                                .Select(t => new ArticleViewModel {
                                    Id = t.Id,
                                    Date = t.Date.ToShortDateString(),
                                    Title = t.Title,
                                    TypeId = t.TypeId 
                                }).ToList();

            //(employeeId <= 0 || t.ArticleEmployee.Any(e => e.EmployeeId.Equals(employeeId))
            return articles;
        }
    }
}
