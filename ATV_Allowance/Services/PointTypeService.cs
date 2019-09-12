using ATV_Allowance.ViewModel;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Services
{
    public interface IPointTypeService
    {
        List<PointTypeViewModel> GetPointType(int articleTypeId);
    }
    public class PointTypeService : IPointTypeService
    {
        private readonly IArticlePointTypeRepository articlePointTypeRepository;
        public PointTypeService()
        {
            articlePointTypeRepository = new ArticlePointTypeRepository();
        }
        public List<PointTypeViewModel> GetPointType(int articleTypeId)
        {
            var list = articlePointTypeRepository.GetMany(a => a.ArticleTypeId.Equals(articleTypeId))
                    .Select(t => new PointTypeViewModel
                    {
                        Id = t.PointTypeId,
                        Code = t.PointType.Code,
                        Name = t.PointType.Name
                    }).ToList();                        
            return list;
        }
    }
}
