using ATV_Allowance.Common;
using ATV_Allowance.Common.Actions;
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
        List<ArticleEmployeeViewModel> GetArticleEmployee(int articleId, int articleType);
        void AddArticleEmployeeTS(ArticleEmployeeViewModel model);
        void AddArticleEmployeeTTNM(ArticleEmployeeViewModel model);
        void AddArticleEmployeePT(ArticleEmployeeViewModel model);
        void AddArticleEmployeePTTT(ArticleEmployeeViewModel model);
        void AddArticleEmployeeBSTTNM(ArticleEmployeeViewModel model); // BSTTNM: Bien soan thong tin ngay moi
        void AddArticleEmployeeHKTTNM(ArticleEmployeeViewModel model); // HKTTNM: Khoi hau ky Bien soan thong tin ngay moi
        void UpdateArticleEmployeeTS(ArticleEmployeeViewModel model);
        void UpdateArticleEmployeeTTNM(ArticleEmployeeViewModel model);
        void UpdateArticleEmployeePT(ArticleEmployeeViewModel model);
        void UpdateArticleEmployeePTTT(ArticleEmployeeViewModel model);
        void UpdateArticleEmployeeBSTTNM(ArticleEmployeeViewModel model); // BSTTNM: Bien soan thong tin ngay moi
        void UpdateArticleEmployeeHKTTNM(ArticleEmployeeViewModel model); // HKTTNM: Khoi hau ky Bien soan thong tin ngay moi
        void RemoveArticleEmployee(ArticleEmployeeViewModel model);
        void UpdateArticle(ArticleViewModel model);
        void RemoveArticle(ArticleViewModel model);

        void AddArticleEmployee(ArticleEmployeeViewModel articleEmployee, ArticleViewModel article);
        void UpdateArticleEmployee(ArticleEmployeeViewModel articleEmployee, ArticleViewModel article);
        ArticleEmployeeViewModel GetDefaultArticleEmployeeViewModel(int articleType);
    }
    public class ArticleService : IArticleService
    {
        private readonly IArticleEmployeeRepository articleEmployeeRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IPointRepository pointRepository;
        private readonly IAppLogger _logger;

        public ArticleService()
        {
            _logger = new AppLogger();
            articleRepository = new ArticleRepository();
            articleEmployeeRepository = new ArticleEmployeeRepository();
            pointRepository = new PointRepository();
        }

        public void AddArticle(Article article)
        {
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Message = string.Format(AppActions.Article_Add, article.Title),
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.CREATE
            };
            try
            {
                articleRepository.Add(article);
            }
            catch (Exception ex)
            {
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
                throw ex;
            }
            finally
            {
                _logger.LogBusiness(actionLog);
            }
        }

        // Tin thời sự
        public void AddArticleEmployeeTS(ArticleEmployeeViewModel data)
        {
            ArticleEmployeeThoiSuHangNgayViewModel model = (ArticleEmployeeThoiSuHangNgayViewModel)data;
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
        public ArticleEmployeeViewModel GetDefaultArticleEmployeeViewModel(int articleType)
        {
            ArticleEmployeeViewModel model = null;
            switch (articleType)
            {
                case Common.Constants.ArticleType.THOI_SU:
                    model = new ArticleEmployeeThoiSuHangNgayViewModel();
                    break;
                case Common.Constants.ArticleType.PV_TTNM:
                    model = new ArticleEmployeeThongTinNgayMoiViewModel();
                    break;
                case Common.Constants.ArticleType.PHAT_THANH:
                    model = new ArticleEmployeePhatThanhViewModel();                  
                    break;
                case Common.Constants.ArticleType.PHAT_THANH_TT:
                    model = new ArticleEmployeePhatThanhTTViewModel();
                    break;
                case Common.Constants.ArticleType.BIENSOAN_TTNM:
                    model = new ArticleEmployeeBSTTNMViewModel();
                    break;
                case Common.Constants.ArticleType.KHOIHK_TTNM:
                    model = new ArticleEmployeeHauKyViewModel();
                    break;
                default:
                    break;
            }
            return model;
        }

        private ArticleEmployeeViewModel ArticleEmployeeMapper(ArticleEmployee entity, int articleType)
        {
            ArticleEmployeeViewModel model = null;
            switch (articleType)
            {
                case Common.Constants.ArticleType.THOI_SU:
                    model = new ArticleEmployeeThoiSuHangNgayViewModel
                    {
                        Id = entity.Id,
                        EmployeeId = entity.Employee.Id,
                        EmployeeCode = entity.Employee.Code,
                        Name = entity.Employee.Name,
                        Position = entity.Employee.Position.Code,
                        //Organization = entity.Employee.Organization.Name
                        Organization = entity.Employee.Organization
                    };
                    break;
                case Common.Constants.ArticleType.PV_TTNM:
                    model = new ArticleEmployeeThongTinNgayMoiViewModel
                    {
                        Id = entity.Id,
                        EmployeeId = entity.Employee.Id,
                        EmployeeCode = entity.Employee.Code,
                        Name = entity.Employee.Name,
                        Position = entity.Employee.Position.Code,
                        //Organization = entity.Employee.Organization.Name
                        Organization = entity.Employee.Organization
                    };
                    break;
                case Common.Constants.ArticleType.PHAT_THANH:
                    model = new ArticleEmployeePhatThanhViewModel
                    {
                        Id = entity.Id,
                        EmployeeId = entity.Employee.Id,
                        EmployeeCode = entity.Employee.Code,
                        Name = entity.Employee.Name,
                        Position = entity.Employee.Position.Code,
                        //Organization = entity.Employee.Organization.Name
                        Organization = entity.Employee.Organization
                    };
                    break;
                case Common.Constants.ArticleType.PHAT_THANH_TT:
                    model = new ArticleEmployeePhatThanhTTViewModel
                    {
                        Id = entity.Id,
                        EmployeeId = entity.Employee.Id,
                        EmployeeCode = entity.Employee.Code,
                        Name = entity.Employee.Name,
                        Position = entity.Employee.Position.Code,
                        //Organization = entity.Employee.Organization.Name
                        Organization = entity.Employee.Organization
                    };
                    break;
                case Common.Constants.ArticleType.BIENSOAN_TTNM:
                    model = new ArticleEmployeeBSTTNMViewModel
                    {
                        Id = entity.Id,
                        EmployeeId = entity.Employee.Id,
                        EmployeeCode = entity.Employee.Code,
                        Name = entity.Employee.Name,
                        Position = entity.Employee.Position.Code,
                        //Organization = entity.Employee.Organization.Name
                        Organization = entity.Employee.Organization
                    };
                    break;
                case Common.Constants.ArticleType.KHOIHK_TTNM:
                    model = new ArticleEmployeeHauKyViewModel
                    {
                        Id = entity.Id,
                        EmployeeId = entity.Employee.Id,
                        EmployeeCode = entity.Employee.Code,
                        Name = entity.Employee.Name,
                        Position = entity.Employee.Position.Code,
                        //Organization = entity.Employee.Organization.Name
                        Organization = entity.Employee.Organization
                    };
                    break;
                default:
                    break;
            }
            return model;
        }
        public List<ArticleEmployeeViewModel> GetArticleEmployee(int articleId, int articleType)
        {
            var artEmps = articleEmployeeRepository                        
                        .GetManyIncludeEmployee(e => e.ArticleId == articleId)                        
                        .Select(t => ArticleEmployeeMapper(t, articleType)).ToList();

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
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Message = string.Format(AppActions.Article_Update, model.Id),
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.CREATE
            };
            try
            {
                Article article = articleRepository.GetById(model.Id);
                article.Title = model.Title;
                articleRepository.Update(article);
            }
            catch (Exception ex)
            {
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
                throw ex;
            }
            finally
            {
                _logger.LogBusiness(actionLog);
            }
        }

        //public int Tin { get; set; }
        //public int PS { get; set; }
        //public int QTin { get; set; }
        //public int QPs { get; set; }
        public void UpdateArticleEmployeeTS(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeeThoiSuHangNgayViewModel)data;
            var articleEmp = articleEmployeeRepository.GetById(model.Id);
            if (articleEmp != null) 
            {
                articleEmp.EmployeeId = data.EmployeeId;
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
        public void UpdateArticleEmployeePT(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeePhatThanhViewModel)data;
            var articleEmp = articleEmployeeRepository.GetById(model.Id);
            if (articleEmp != null) // DELETED 
            {
                articleEmp.EmployeeId = data.EmployeeId;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Tin).Point1 = model.Tin;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Pv_Pb).Point1 = model.Pv_Pb;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Tlt).Point1 = model.Tlt;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Sd).Point1 = model.Sd;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Cd_Cm).Point1 = model.Cd_Cm;
                articleEmp.Point.First(t => t.Type == PointType_PhatThanh.Bai).Point1 = model.Bai;
                articleEmployeeRepository.Update(articleEmp);
            }
        }

        public void AddArticleEmployeePT(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeePhatThanhViewModel) data;
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

        public void AddArticleEmployeePTTT(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeePhatThanhTTViewModel)data;
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

        public void UpdateArticleEmployeePTTT(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeePhatThanhTTViewModel)data;
            var articleEmp = articleEmployeeRepository.GetById(model.Id);
            if (articleEmp != null) // DELETED 
            {
                articleEmp.EmployeeId = data.EmployeeId;
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

        public void AddArticleEmployeeTTNM(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeeThongTinNgayMoiViewModel)data;
            var existed = articleEmployeeRepository.GetMany(e => e.ArticleId == model.ArticleId && e.EmployeeId == model.EmployeeId).FirstOrDefault();
            if (existed != null)
            {
                model.Id = existed.Id;
                UpdateArticleEmployeeTTNM(model);
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
                    Type = PointType_TTNM.Tin,
                    Point1 = model.Tin
                },
                new Point
                {
                    Type = PointType_TTNM.PS,
                    Point1 = model.PS
                },
                new Point
                {
                    Type = PointType_TTNM.QTin,
                    Point1 = model.QTin
                },
                new Point
                {
                    Type = PointType_TTNM.QPs,
                    Point1 = model.QPs
                },
                new Point
                {
                    Type = PointType_TTNM.Tl_tin,
                    Point1 = model.Tl_Tin
                },
                  new Point
                {
                    Type = PointType_TTNM.Thop,
                    Point1 = model.Thop
                },
            };
                articleEmployeeRepository.Add(articleEmp);
            }
        }

        public void UpdateArticleEmployeeTTNM(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeeThongTinNgayMoiViewModel)data;
            var articleEmp = articleEmployeeRepository.GetById(model.Id);
            if (articleEmp != null) // DELETED 
            {
                articleEmp.EmployeeId = data.EmployeeId;
                articleEmp.Point.First(t => t.Type == PointType_TTNM.Tin).Point1 = model.Tin;
                articleEmp.Point.First(t => t.Type == PointType_TTNM.PS).Point1 = model.PS;
                articleEmp.Point.First(t => t.Type == PointType_TTNM.QTin).Point1 = model.QTin;
                articleEmp.Point.First(t => t.Type == PointType_TTNM.QPs).Point1 = model.QPs;
                articleEmp.Point.First(t => t.Type == PointType_TTNM.Tl_tin).Point1 = model.Tl_Tin;
                articleEmp.Point.First(t => t.Type == PointType_TTNM.Thop).Point1 = model.Thop;
                articleEmployeeRepository.Update(articleEmp);
            }
        }

        public void AddArticleEmployeeBSTTNM(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeeBSTTNMViewModel)data;
            var existed = articleEmployeeRepository.GetMany(e => e.ArticleId == model.ArticleId && e.EmployeeId == model.EmployeeId).FirstOrDefault();
            if (existed != null)
            {
                model.Id = existed.Id;
                UpdateArticleEmployeeBSTTNM(model);
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
                    Type = PointType_BIENSOAN_TTNM.Bs_TTN,
                    Point1 = model.Bs_TTN
                },
                new Point
                {
                    Type = PointType_BIENSOAN_TTNM.Bs_Sapo,
                    Point1 = model.Bs_Sapo
                },
                new Point
                {
                    Type = PointType_BIENSOAN_TTNM.Bt_Duyet,
                    Point1 = model.Bt_Duyet
                },
                new Point
                {
                    Type = PointType_BIENSOAN_TTNM.KThinh,
                    Point1 = model.KThinh
                },
                new Point
                {
                    Type = PointType_BIENSOAN_TTNM.TFile,
                    Point1 = model.TFile
                }
            };
                articleEmployeeRepository.Add(articleEmp);
            }
        }

        public void AddArticleEmployeeHKTTNM(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeeHauKyViewModel)data;
            var existed = articleEmployeeRepository.GetMany(e => e.ArticleId == model.ArticleId && e.EmployeeId == model.EmployeeId).FirstOrDefault();
            if (existed != null)
            {
                model.Id = existed.Id;
                UpdateArticleEmployeeHKTTNM(model);
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
                    Type = PointType_HAUKY_TTNM.DCT,
                    Point1 = model.DCT
                },
                new Point
                {
                    Type = PointType_HAUKY_TTNM.KTD,
                    Point1 = model.KTD
                },
                new Point
                {
                    Type = PointType_HAUKY_TTNM.KT_TH,
                    Point1 = model.KT_TH
                },
                new Point
                {
                    Type = PointType_HAUKY_TTNM.TCT,
                    Point1 = model.TCT
                }
            };
                articleEmployeeRepository.Add(articleEmp);
            }
        }

        public void UpdateArticleEmployeeBSTTNM(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeeBSTTNMViewModel)data;
            var articleEmp = articleEmployeeRepository.GetById(model.Id);
            if (articleEmp != null) // DELETED 
            {
                articleEmp.EmployeeId = data.EmployeeId;
                articleEmp.Point.First(t => t.Type == PointType_BIENSOAN_TTNM.Bs_TTN).Point1 = model.Bs_TTN;
                articleEmp.Point.First(t => t.Type == PointType_BIENSOAN_TTNM.Bs_Sapo).Point1 = model.Bs_Sapo;
                articleEmp.Point.First(t => t.Type == PointType_BIENSOAN_TTNM.Bt_Duyet).Point1 = model.Bt_Duyet;
                articleEmp.Point.First(t => t.Type == PointType_BIENSOAN_TTNM.KThinh).Point1 = model.KThinh;
                articleEmp.Point.First(t => t.Type == PointType_BIENSOAN_TTNM.TFile).Point1 = model.TFile;
                articleEmployeeRepository.Update(articleEmp);
            }
        }

        public void UpdateArticleEmployeeHKTTNM(ArticleEmployeeViewModel data)
        {
            var model = (ArticleEmployeeHauKyViewModel)data;
            var articleEmp = articleEmployeeRepository.GetById(model.Id);
            if (articleEmp != null) // DELETED 
            {
                articleEmp.EmployeeId = data.EmployeeId;
                articleEmp.Point.First(t => t.Type == PointType_HAUKY_TTNM.DCT).Point1 = model.DCT;
                articleEmp.Point.First(t => t.Type == PointType_HAUKY_TTNM.KTD).Point1 = model.KTD;
                articleEmp.Point.First(t => t.Type == PointType_HAUKY_TTNM.KT_TH).Point1 = model.KT_TH;
                articleEmp.Point.First(t => t.Type == PointType_HAUKY_TTNM.TCT).Point1 = model.TCT;
                articleEmployeeRepository.Update(articleEmp);
            }
        }

        public void AddArticleEmployee(ArticleEmployeeViewModel articleEmployee, ArticleViewModel article)
        {
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Message = string.Format(AppActions.ArticleEmployee_Add, articleEmployee.EmployeeCode, article.Id),
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.CREATE
            };

            try
            {
                articleEmployee.ArticleId = article.Id;
                int articleTypeId = article.TypeId;
                if (articleTypeId == Constants.ArticleType.THOI_SU)
                {
                    actionLog.Message += " [THOI_SU]";
                    AddArticleEmployeeTS(articleEmployee);
                }
                else if (articleTypeId == Constants.ArticleType.PV_TTNM)
                {
                    actionLog.Message += " [PV_TTNM]";
                    AddArticleEmployeeTTNM(articleEmployee);
                }
                else if (articleTypeId == Constants.ArticleType.BIENSOAN_TTNM)
                {
                    actionLog.Message += " [BIENSOAN_TTNM]";
                    AddArticleEmployeeBSTTNM(articleEmployee);
                }
                else if (articleTypeId == Constants.ArticleType.KHOIHK_TTNM)
                {
                    actionLog.Message += " [KHOIHK_TTNM]";
                    AddArticleEmployeeHKTTNM(articleEmployee);
                }
                else if (articleTypeId == Constants.ArticleType.PHAT_THANH)
                {
                    actionLog.Message += " [PHAT_THANH]";
                    AddArticleEmployeePT(articleEmployee);
                }
                else if (articleTypeId == Constants.ArticleType.PHAT_THANH_TT)
                {
                    actionLog.Message += " [PHAT_THANH_TT]";
                    AddArticleEmployeePTTT(articleEmployee);
                }
            }
            catch (Exception ex)
            {
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
                throw ex;
            }
            finally
            {
                _logger.LogBusiness(actionLog);
            }
        }

        public void UpdateArticleEmployee(ArticleEmployeeViewModel articleEmployee, ArticleViewModel article)
        {
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Message = string.Format(AppActions.ArticleEmployee_Update, articleEmployee.EmployeeCode, article.Id),
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.CREATE
            };
            try
            {
                int articleTypeId = article.TypeId;
                if (articleTypeId == Constants.ArticleType.THOI_SU)
                {
                    actionLog.Message += " [THOI_SU]";
                    UpdateArticleEmployeeTS(articleEmployee);
                }
                else if (articleTypeId == Constants.ArticleType.PV_TTNM)
                {
                    actionLog.Message += " [PV_TTNM]";
                    UpdateArticleEmployeeTTNM(articleEmployee);
                }
                else if (articleTypeId == Constants.ArticleType.BIENSOAN_TTNM)
                {
                    actionLog.Message += " [BIENSOAN_TTNM]";
                    UpdateArticleEmployeeBSTTNM(articleEmployee);
                }
                else if (articleTypeId == Constants.ArticleType.KHOIHK_TTNM)
                {
                    actionLog.Message += " [KHOIHK_TTNM]";
                    UpdateArticleEmployeeHKTTNM(articleEmployee);
                }
                else if (articleTypeId == Constants.ArticleType.PHAT_THANH)
                {
                    actionLog.Message += " [PHAT_THANH]";
                    UpdateArticleEmployeePT(articleEmployee);
                }
                else if (articleTypeId == Constants.ArticleType.PHAT_THANH_TT)
                {
                    actionLog.Message += " [PHAT_THANH_TT]";
                    UpdateArticleEmployeePTTT(articleEmployee);
                }
            }
            catch (Exception ex)
            {
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
                throw ex;
            }
            finally
            {
                _logger.LogBusiness(actionLog);
            }
        }
    }
}
