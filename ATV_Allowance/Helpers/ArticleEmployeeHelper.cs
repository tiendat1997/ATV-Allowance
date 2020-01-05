using ATV_Allowance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Helpers
{
    public static class ArticleEmployeeHelper
    {
        public static ArticleEmployeeViewModel MapToViewModel(int articleyTypeId, object dataBoundItem)
        {
            ArticleEmployeeViewModel data = null;
            switch (articleyTypeId)
            {
                case Common.Constants.ArticleType.THOI_SU:
                    data = (ArticleEmployeeThoiSuHangNgayViewModel)dataBoundItem;
                    break;
                case Common.Constants.ArticleType.PV_TTNM:
                    data = (ArticleEmployeeThongTinNgayMoiViewModel)dataBoundItem;
                    break;
                case Common.Constants.ArticleType.PHAT_THANH:
                    data = (ArticleEmployeePhatThanhViewModel)dataBoundItem;
                    break;
                case Common.Constants.ArticleType.PHAT_THANH_TT:
                    data = (ArticleEmployeePhatThanhTTViewModel)dataBoundItem;
                    break;
                case Common.Constants.ArticleType.BIENSOAN_TTNM:
                    data = (ArticleEmployeeBSTTNMViewModel)dataBoundItem;
                    break;
                case Common.Constants.ArticleType.KHOIHK_TTNM:
                    data = (ArticleEmployeeHauKyViewModel)dataBoundItem;
                    break;
                default:
                    break;
            }
            return data;
        }
        public static System.ComponentModel.IBindingList MapToBindingList(int articleType, IList<ArticleEmployeeViewModel> list)
        {
            System.ComponentModel.IBindingList bindList = null;            
            switch (articleType)
            {
                case Common.Constants.ArticleType.THOI_SU:
                    var tsModel = list.Select(t => (ArticleEmployeeThoiSuHangNgayViewModel)t).ToList();
                    bindList = new System.ComponentModel.BindingList<ArticleEmployeeThoiSuHangNgayViewModel>(tsModel);                   
                    break;
                case Common.Constants.ArticleType.PV_TTNM:
                    var ttnmModel = list.Select(t => (ArticleEmployeeThongTinNgayMoiViewModel)t).ToList();
                    bindList = new System.ComponentModel.BindingList<ArticleEmployeeThongTinNgayMoiViewModel>(ttnmModel);
                    break;
                case Common.Constants.ArticleType.PHAT_THANH:
                    var ptModel = list.Select(t => (ArticleEmployeePhatThanhViewModel)t).ToList();
                    bindList = new System.ComponentModel.BindingList<ArticleEmployeePhatThanhViewModel>(ptModel);
                    break;
                case Common.Constants.ArticleType.PHAT_THANH_TT:
                    var ptttModel = list.Select(t => (ArticleEmployeePhatThanhTTViewModel)t).ToList();
                    bindList = new System.ComponentModel.BindingList<ArticleEmployeePhatThanhTTViewModel>(ptttModel);
                    break;
                case Common.Constants.ArticleType.BIENSOAN_TTNM:
                    var bsttnmModel = list.Select(t => (ArticleEmployeeBSTTNMViewModel)t).ToList();
                    bindList = new System.ComponentModel.BindingList<ArticleEmployeeBSTTNMViewModel>(bsttnmModel);
                    break;
                case Common.Constants.ArticleType.KHOIHK_TTNM:
                    var hkModel = list.Select(t => (ArticleEmployeeHauKyViewModel)t).ToList();
                    bindList = new System.ComponentModel.BindingList<ArticleEmployeeHauKyViewModel>(hkModel);
                    break;
                default:
                    break;
            }
            return bindList;
        }
    }
}
