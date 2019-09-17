using ATV_Allowance.ViewModel;
using DataService.Entity;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Services
{
    public interface IArticleService
    {
        void AddArticle(Article article);
        List<ArticleViewModel> GetArticle(int typeId, DateTime fromDate, DateTime toDate, int employeeId);
        List<ArticleEmployeeViewModel> GetArticleEmployee(int articleId);
        void AddLArticleEmployeeTS(ArticleEmployeeViewModel model);
        void UpdateArticleEmployeeTS(ArticleEmployeeViewModel model);
        void UpdateArticle(ArticleViewModel model);
        void RemoveArticleEmployee(ArticleEmployeeViewModel model);
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

        // Tin thời sự
        public void AddLArticleEmployeeTS(ArticleEmployeeViewModel model) 
        {
            var existed = articleEmployeeRepository.GetMany(e => e.ArticleId == model.ArticleId && e.EmployeeId == model.EmployeeId).FirstOrDefault();
            if (existed != null)
            {
                model.Id = existed.Id;
                UpdateArticleEmployeeTS(model);
            }
            else
            {
                ArticleEmployee articleEmp = new ArticleEmployee()
                {
                    ArticleId = model.ArticleId,
                    EmployeeId = model.EmployeeId
                };
                articleEmp.Point = new List<Point>
            {
                new Point
                {
                    Type = PointType_ThoiSu.Tin,
                    Point1 = model.Tin
                },
                new Point
                {
                    Type = PointType_ThoiSu.PS,
                    Point1 = model.PS
                },
                new Point
                {
                    Type = PointType_ThoiSu.QTin,
                    Point1 = model.QTin
                },
                new Point
                {
                    Type = PointType_ThoiSu.QPs,
                    Point1 = model.QPs
                }
            };
                articleEmployeeRepository.Add(articleEmp);
            }                     
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
                                .GetMany(t => t.ArticleEmployeeId == artEmp.Id)                                
                                .Select(t => new PointViewModel { Code = t.PointType.Code , Point = t.Point1 })
                                .ToList();
                object boxedObject = RuntimeHelpers.GetObjectValue(artEmp);

                foreach (var point in points)
                {
                    artEmp.GetType().GetProperty(point.Code).SetValue(boxedObject, point.Point);
                }
            }
            return artEmps;
        }

        public void RemoveArticleEmployee(ArticleEmployeeViewModel model)
        {
            var listPoints = pointRepository.GetMany(t => t.ArticleEmployeeId == model.Id).ToList();
            foreach (var point in listPoints)
            {
                pointRepository.Delete(point);
            }
            var articleEmployee = articleEmployeeRepository.GetById(model.Id);
            if (articleEmployee != null)
            {
                articleEmployeeRepository.Delete(articleEmployee);
            }            
        }

        public void UpdateArticle(ArticleViewModel model)
        {
            Article article = articleRepository.GetById(model.Id);
            article.Title = model.Title;
            articleRepository.Update(article);
        }

        //public int Tin { get; set; }
        //public int PS { get; set; }
        //public int QTin { get; set; }
        //public int QPs { get; set; }
        public void UpdateArticleEmployeeTS(ArticleEmployeeViewModel model)
        {
            var articleEmp = articleEmployeeRepository.GetById(model.Id);    
            if (articleEmp != null) // DELETED 
            {
                articleEmp.Point.First(t => t.Type == PointType_ThoiSu.Tin).Point1 = model.Tin;
                articleEmp.Point.First(t => t.Type == PointType_ThoiSu.PS).Point1 = model.PS;
                articleEmp.Point.First(t => t.Type == PointType_ThoiSu.QTin).Point1 = model.QTin;
                articleEmp.Point.First(t => t.Type == PointType_ThoiSu.QPs).Point1 = model.QPs;
                articleEmployeeRepository.Update(articleEmp);
            }            
        }
    }
}
