using ATV_Allowance.ViewModel;
using DataService.Entity;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Services
{
    public interface IArticleService
    {
        void AddArticle(Article article);
        List<ArticleViewModel> GetArticle(int typeId, DateTime fromDate, DateTime toDate, int employeeId);
        List<ArticleEmployeeViewModel> GetArticleEmployee(int articleId);
    }
    public class ArticleService : IArticleService
    {
        private readonly IArticleEmployeeRepository articleEmployeeRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IPointRepository pointRepository;       
        public ArticleService()
        {
            articleRepository = new ArticleRepository();
            articleEmployeeRepository = new ArticleEmployeeRepository();
            pointRepository = new PointRepository();
        }

        public void AddArticle(Article article)
        {
            articleRepository.Add(article);
        }

        public List<ArticleViewModel> GetArticle(int typeId, DateTime fromDate, DateTime toDate, int employeeId)
        {
            var articles = articleRepository
                        .GetMany(t => (typeId <= 0 || t.TypeId.Equals(typeId))
                                && (fromDate == null || t.Date >= fromDate)
                                && (toDate == null || t.Date <= toDate)
                                )
                                .Select(t => new ArticleViewModel {
                                    Id = t.Id,
                                    Date = t.Date.ToShortDateString(),
                                    Title = t.Title,
                                    TypeId = t.TypeId 
                                }).ToList();            
            return articles;
        }

        public List<ArticleEmployeeViewModel> GetArticleEmployee(int articleId)
        {
            var artEmps = articleEmployeeRepository
                        .GetMany(e => e.ArticleId == articleId)
                        .Select(t => new ArticleEmployeeViewModel {
                            Id = t.Id,
                            EmployeeId = t.Employee.Id,
                            Code = t.Employee.Code,
                            Name = t.Employee.Name,
                            Position = t.Employee.Position.Code,
                            Organization = t.Employee.Organization.Name
                        }).ToList();

            foreach (var artEmp in artEmps)
            {
                var points = pointRepository
                                .GetMany(t => t.ArticleEmployeeId.Equals(artEmp.Id))
                                .Select(t => new PointViewModel { Code = t.PointType.Code, Point = t.Point1 })
                                .ToList();
                object boxedObject = RuntimeHelpers.GetObjectValue(artEmp);

                foreach (var point in points)
                {
                    artEmp.GetType().GetProperty(point.Code).SetValue(boxedObject, point.Point);                    
                }
            }
            return artEmps;
        }
    }
}
