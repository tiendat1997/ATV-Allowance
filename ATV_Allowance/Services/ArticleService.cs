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
        List<ArticleViewModel> GetComboArticle(List<int> typeIds, DateTime fromDate, DateTime toDate, int employeeId);
        List<ArticleViewModel> GetArticle(int typeId, DateTime fromDate, DateTime toDate, int employeeId);
        List<ArticleEmployeeViewModel> GetArticleEmployee(int articleId);
        void AddArticleEmployeeTS(ArticleEmployeeViewModel model);
        void AddArticleEmployeePT(ArticleEmployeeViewModel model);
        void AddArticleEmployeePTTT(ArticleEmployeeViewModel model);
        void UpdateArticleEmployeeTS(ArticleEmployeeViewModel model);
        void UpdateArticleEmployeePT(ArticleEmployeeViewModel model);
        void UpdateArticleEmployeePTTT(ArticleEmployeeViewModel model);
        void RemoveArticleEmployee(ArticleEmployeeViewModel model);
        void UpdateArticle(ArticleViewModel model);
        void RemoveArticle(ArticleViewModel model);
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
        public void AddArticleEmployeeTS(ArticleEmployeeViewModel model)
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
                        .GetMany(t => t.IsActive == true
                                && (typeId == 0 || t.TypeId == typeId)
                                && (fromDate == null || t.Date >= fromDate)
                                && (toDate == null || t.Date <= toDate))
                                .Select(t => new ArticleViewModel
                                {
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
                        .Select(t => new ArticleEmployeeViewModel
                        {
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

        public void RemoveArticle(ArticleViewModel model)
        {
            var entity = articleRepository.GetById(model.Id);
            if (entity != null)
            {
                entity.IsActive = false;
                articleRepository.Update(entity);
            }
        }

        public void RemoveArticleEmployee(ArticleEmployeeViewModel model)
        {
            var existed = articleEmployeeRepository.GetMany(e => e.ArticleId == model.ArticleId && e.EmployeeId == model.EmployeeId).FirstOrDefault();
            if (existed != null)
            {
                int articleEmpId = existed.Id;
                var listPoints = pointRepository.GetMany(t => t.ArticleEmployeeId == articleEmpId).ToList();
                foreach (var point in listPoints)
                {
                    pointRepository.Delete(point);
                }
                var articleEmployee = articleEmployeeRepository.GetById(articleEmpId);
                if (articleEmployee != null)
                {
                    articleEmployeeRepository.Delete(articleEmployee);
                }
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

        //public int Tin { get; set; }     
        //public int Pv_Pb { get; set; }
        //public int Tlt { get; set; }
        //public int Sd { get; set; }
        //public int Cd_Cm { get; set; }
        //public int Bai { get; set; }        
        public void UpdateArticleEmployeePT(ArticleEmployeeViewModel model)
        {
            var articleEmp = articleEmployeeRepository.GetById(model.Id);
            if (articleEmp != null) // DELETED 
            {
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Tin).Point1 = model.Tin;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Pv_Pb).Point1 = model.Pv_Pb;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Tlt).Point1 = model.Tlt;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Sd).Point1 = model.Sd;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Cd_Cm).Point1 = model.Cd_Cm;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Bai).Point1 = model.Bai;
                articleEmployeeRepository.Update(articleEmp);
            }
        }

        public void AddArticleEmployeePT(ArticleEmployeeViewModel model)
        {
            var existed = articleEmployeeRepository.GetMany(e => e.ArticleId == model.ArticleId && e.EmployeeId == model.EmployeeId).FirstOrDefault();
            if (existed != null)
            {
                model.Id = existed.Id;
                UpdateArticleEmployeePT(model);
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
                        Type = PointType_PhatThanh.Tin,
                        Point1 = model.Tin
                    },
                    new Point
                    {
                        Type = PointType_PhatThanh.Cd_Cm,
                        Point1 = model.Cd_Cm
                    },
                    new Point
                    {
                        Type = PointType_PhatThanh.Pv_Pb,
                        Point1 = model.Pv_Pb
                    },
                    new Point
                    {
                        Type = PointType_PhatThanh.Sd,
                        Point1 = model.Sd
                    },new Point
                    {
                        Type = PointType_PhatThanh.Bai,
                        Point1 = model.Bai
                    },new Point
                    {
                        Type = PointType_PhatThanh.Tlt,
                        Point1 = model.Tlt
                    },
                };
                articleEmployeeRepository.Add(articleEmp);
            }
        }

        public void AddArticleEmployeePTTT(ArticleEmployeeViewModel model)
        {
            var existed = articleEmployeeRepository.GetMany(e => e.ArticleId == model.ArticleId && e.EmployeeId == model.EmployeeId).FirstOrDefault();
            if (existed != null)
            {
                model.Id = existed.Id;
                UpdateArticleEmployeePTTT(model);
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
                        Type = PointType_PhatThanhTT.Tin,
                        Point1 = model.Tin
                    },
                    new Point
                    {
                        Type = PointType_PhatThanhTT.Bs_DCT,
                        Point1 = model.Bs_DCT
                    },
                    new Point
                    {
                        Type = PointType_PhatThanhTT.Bt_Dd,
                        Point1 = model.Bt_Dd
                    },
                    new Point
                    {
                        Type = PointType_PhatThanhTT.CDe,
                        Point1 = model.CDe
                    },new Point
                    {
                        Type = PointType_PhatThanhTT.Pv_Pb,
                        Point1 = model.Pv_Pb
                    },new Point
                    {
                        Type = PointType_PhatThanhTT.TTh_Gnh,
                        Point1 = model.TTh_Gnh
                    },
                };
                articleEmployeeRepository.Add(articleEmp);
            }
        }

        public void UpdateArticleEmployeePTTT(ArticleEmployeeViewModel model)
        {
            var articleEmp = articleEmployeeRepository.GetById(model.Id);
            if (articleEmp != null) // DELETED 
            {
                articleEmp.Point.First(t => t.Type == PointType_PhatThanhTT.Tin).Point1 = model.Tin;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanhTT.Pv_Pb).Point1 = model.Pv_Pb;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanhTT.Bs_DCT).Point1 = model.Bs_DCT;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanhTT.Bt_Dd).Point1 = model.Bt_Dd;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanhTT.CDe).Point1 = model.CDe;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanhTT.TTh_Gnh).Point1 = model.TTh_Gnh;
                articleEmployeeRepository.Update(articleEmp);
            }
        }

        public List<ArticleViewModel> GetComboArticle(List<int> typeIds, DateTime fromDate, DateTime toDate, int employeeId)
        {
            var articles = articleRepository
                        .GetMany(t => t.IsActive == true
                                && (!typeIds.Any() || typeIds.Contains(t.TypeId))
                                && (fromDate == null || t.Date >= fromDate)
                                && (toDate == null || t.Date <= toDate)
                                && (employeeId == 0 || t.ArticleEmployee.Any(e => e.EmployeeId == employeeId)))
                                .Select(t => new ArticleViewModel
                                {
                                    Id = t.Id,
                                    Date = t.Date.ToShortDateString(),
                                    Code = t.ArticleType.Code,
                                    Title = t.Title,
                                    TypeId = t.TypeId
                                })
                                .OrderBy(t => t.Title)
                                .ToList();
            return articles;
        }       
    }
}
