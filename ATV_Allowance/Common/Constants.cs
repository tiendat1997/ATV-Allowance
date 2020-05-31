using System.Collections.Generic;

namespace ATV_Allowance.Common
{
    public static class Constants
    {
        public static class CommonStatus
        {
            public static int ACTIVE = 1;
            public static int DISABLE = 0;
            public static int DELETE = -1;
            //Contract
            public static int CANCEL = -2;
        }

        public static class CommonMessage
        {
            public static string INVALID_LOGIN = "Thông tin đăng nhâp không đúng";
            public static string UNAUTHORIZED = "Không có quyền truy cập";
            public static string ALREADY_LOGIN = "Tài khoản hiện đang được đăng nhập";

            public static string APPLICATION_IS_RUNNING = "Ứng dụng đang chạy";
            public static string CUSTOMER_NOTFOUND = "Không tìm thấy thông tin khách hàng";
            public static string ADD_SUCESSFULLY = "Thêm mới thành công";
            public static string EDIT_SUCESSFULLY = "Cập nhật thành công";
            public static string DELETE_SUCESSFULLY = "Xóa thành công";
            public static string UPDATE_SUCESSFULLY = "Cập nhật thành công";
            public static string CANCEL_SUCESSFULLY = "Cập nhật thành công";

            public static string CONFIRM_DELETE = "Có phải bạn muốn xóa thông tin này ?";

            public static string USED_CODE = "Mã đã được sử dụng";
            public static string USED_CODE_LENGTH = "Thời điểm có (Mã, Thời lượng) này đã được tạo";

            public static string EXISTED_PRODUCT_IN_CONTRACT = "Sản phẩm đã được tạo trong hợp đồng";
            public static string EXISTED_PRODUCT_SCHEDULE = "Sản phẩm đã được tạo lịch vào (Thời điểm phát, Ngày chiếu) này";
        }

        public static class ADGVEmployeeText
        {
            public static string Code = "Mã NV";
            public static string Name = "Họ và tên";
            public static string Position = "Chức danh";
            public static string AbbrPosition = "Ch/D";
            public static string Organization = "Đơn vị";
            public static string Title = "Ghi chú";
        }

        public static class ADGVReportHeader
        {
            public static string Name = "Họ và tên";
            public static string Organization = "Đơn vị";
            public static string SoTin = "Tin";
            public static string DiemTin = "D_Tin";
            public static string SoBai = "Bai";
            public static string DiemBai = "D_Bai";
            public static string SoPsu = "PS";
            public static string DiemPsu = "D_PS";
            public static string DiemQTin = "D_QTin";
            public static string DiemQPsu = "D_QPsu";
            public static string Cong = "Cộng";
            public static string TruChiTieu = "Trừ chỉ tiêu";
            public static string TangGiam = "Tăng + Giảm - 10%";
            public static string TongCong = "Tổng cộng";
            public static string ThanhTien = "Thành tiền";
            public static string SL_TT = "TTh_Gnh";
            public static string D_TT = "D_TTh_Gnh";
            public static string SL_CD = "Cd_Cm";
            public static string D_CD = "D_Cd_Cm";
            public static string SL_PV = "Pv_Pb";
            public static string D_PV = "D_Pv_Pb";
            public static string SL_BS = "Bs_DCT";
            public static string D_BS = "D_Bs_DCT";
            public static string SL_BT = "Bt_Dd";
            public static string D_BT = "D_Bt_Dd";
            public static string SL_TLT = "Tlt";
            public static string D_TLT = "D_Tlt";
            public static string SL_SD = "Sd";
            public static string D_SD = "D_Sd";
            public static string Diem = "Đ";
            public static string TotalPoint = "Tổng Đ";
            public static string TotalCost = "Thành tiền";

            //report "thong tin ngay moi"
            public static string SoQTin = "QTin";
            public static string SoQPsu = "QPsu";
            public static string SoTHop = "Thop";

            //report "bien soan thong tin ngay moi"
            public static string SoBs_TTN = "Bs_TTN";
            public static string SoBs_Sapo = "Bs_Sapo/Tỉnh";
            public static string SoKThinh = "KThinh";
            public static string SoTFile = "TFile";
            public static string SoBt_Duyet = "Bt_Duyet Sa/Tối";

            //report "khoi hau ky thong tin ngay moi"
            public static string SoDCT = "DCT";
            public static string SoKTD = "KTD Sa/Tối";
            public static string SoTCT = "TCT Sa";
            public static string SoKT_TH = "KT_TH";

        }
        public static class ADGVArticleText
        {
            public static string Title = "Tin";
            public static string Date = "Ngày";
            public static string Type = "Loại"; // Loại tin
        }

        public static class ADGVOrganizationText
        {
            public static string Name = "Tên Đơn Vị";
        }

        public static class BusinessLogType
        {
            public const string LOGIN = "Login";
            public const string LOGOUT = "Logout";
            public const string CREATE = "Create";
            public const string DELETE = "Delete";
            public const string UPDATE = "Update";
            public const string EXPORT_DATA = "ExportData";
        }

        public static class SystemLogType
        {
            public static int Exception = 1;
            public static int Backup = 2;
        }

        public static class CRUDStatusCode
        {
            public static int ERROR = 0;
            public static int SUCCESS = 1;
            public static int EXISTED = 2;
        }

        public static class EmployeeRole
        {
            public static int PV = 1;
            public static int BTV = 2;
            public static int PTV = 3;
            public static int CTV = 4;
            public static int KTD = 5;

        }

        public static class Unit
        {
            public static int None = 0;
            public static int Percent = 1;
            public static int Point = 2;
            public static int Person = 3;
            public static int Vnd = 4;
            public static int Days = 5;

        }

        public enum PointType
        {
            Tin = 1,
            Bai = 2,
            PV = 3,
            Tlt = 4,
            SD = 5,
            CD_CM = 6
        }

        public static class PointType_ThoiSu
        {
            public static int Tin = 1;
            public static int PS = 2;
            public static int QTin = 3;
            public static int QPs = 4;
        }

        public static class PointType_TTNM
        {
            public static int Tin = 1;
            public static int PS = 2;
            public static int QTin = 3;
            public static int QPs = 4;
            public static int Tl_tin = 14;
            public static int Thop = 15;
        }
        public static class PointType_BIENSOAN_TTNM
        {
            public static int Bs_TTN = 16;
            public static int Bs_Sapo = 17;
            public static int KThinh = 18;
            public static int TFile = 19;
            public static int Bt_Duyet = 20;
        }
        public static class PointType_HAUKY_TTNM
        {
            public static int DCT = 21;
            public static int KTD = 22;
            public static int TCT = 23;
            public static int KT_TH = 24;
        }
        public static class PointType_PhatThanh
        {
            public static int Tin = 1;
            public static int Pv_Pb = 5;
            public static int Tlt = 6;
            public static int Sd = 7;
            public static int Cd_Cm = 8;
            public static int Bai = 9;
        }
        public static class PointType_PhatThanhTT
        {
            public static int Tin = 1;
            public static int TTh_Gnh = 10;
            public static int CDe = 11;
            public static int Pv_Pb = 5;
            public static int Bs_DCT = 12;
            public static int Bt_Dd = 13;
        }

        #region Controls
        public static class ControlsAttribute
        {
            public static int TEXTBOX_WIDTH_SMALL = 100;
            public static int TEXTBOX_WIDTH_NORMAL = 140;
            public static int TEXTBOX_HEIGHT = 26;

            public static int GV_WIDTH_SMALL = 50;
            public static int GV_WIDTH_SEEM = 100;
            public static int GV_WIDTH_NORMAL = 150;
            public static int GV_WIDTH_MEDIUM = 170;
            public static int GV_WIDTH_LARGE = 250;
            public static int GV_WIDTH_LARGE_X = 500;
            public static int GV_WIDTH_LARGE_XX = 650;
        }
        #endregion

        public static class ArticleType
        {
            public const int PHAT_THANH = 1;
            public const int PHAT_THANH_TT = 2;
            public const int THOI_SU = 3;
            public const int PV_TTNM = 4;
            public const int BIENSOAN_TTNM = 5;
            public const int KHOIHK_TTNM = 6;
        }
        public static class ArticleTypeGroup
        {
            public static List<ArticleGroup> DROPDOWN_VALUE = new List<ArticleGroup>()
        {
            new ArticleGroup { Name = "Nhóm tin truyền hình", GroupIds = new List<int> { 3, 4 } }, // Thời sự , Thông tin ngày mới,
            new ArticleGroup { Name = "Nhóm tin phát thanh", GroupIds = new List<int> { 1, 2 } }, // Phát thanh, Phát thanh trực tiếp    
            new ArticleGroup { Name = "Biên soạn ttnm", GroupIds = new List<int> { 5, 6 } } // Biên soạn ttnm, Khối hậu kỳ    
        };
        }
        public class ArticleGroup
        {
            public string Name { get; set; }
            public List<int> GroupIds { get; set; }
        }

        public static class Tempate
        {
            public static string TS = "TemplateTS";
            public static string PT = "TemplatePT";
            public static string PTTT = "TemplatePTTT";
            public static string TTNM = "TemplateTTCS";
            public static string BSTTNM = "TemplateBSTTCS";
            public static string TSKHK = "TemplateTS_KHK";
        }

        public static class TS_COL
        {
            public static int STT = 1;
            public static int HO_TEN = 2;
            public static int DON_VI = 3;
            public static int TIN = 4;
            public static int TIN_DIEM = 5;
            public static int PHSU = 6;
            public static int PHSU_DIEM = 7;
            public static int QTIN = 8;
            public static int QTIN_DIEM = 9;
            public static int QPSU = 10;
            public static int QPSU_DIEM = 11;
            public static int CONG = 12;
            public static int TRUCHITIEU = 13;
            public static int TANGGIAM = 14;
            public static int TONGCONG = 15;
            public static int THANHTIEN = 16;
        }

        public static class PT_COL
        {
            public static int STT = 1;
            public static int HO_TEN = 2;
            public static int DON_VI = 3;
            public static int SL_TIN = 4;
            public static int D_TIN = 5;
            public static int SL_BAI = 6;
            public static int D_BAI = 7;
            public static int SL_CD = 8;
            public static int D_CD = 9;
            public static int SL_PV = 10;
            public static int D_PV = 11;
            public static int SL_TLT = 12;
            public static int D_TLT = 13;
            public static int SL_SD = 14;
            public static int D_SD = 15;
            public static int TRUCHITIEU = 16;
            public static int TONGDIEM = 17;
            public static int TANGGIAM = 18;
            public static int THANHTIEN = 19;

            public static string GetBBTHeader(double BBTPercent)
                => $"Ban biên tập {BBTPercent}%";
        }
        public static class PTTT_COL
        {
            public static int STT = 1;
            public static int HO_TEN = 2;
            public static int DON_VI = 3;
            public static int SL_TIN = 4;
            public static int D_TIN = 5;
            public static int SL_TT = 6;
            public static int D_TT = 7;
            public static int SL_CD = 8;
            public static int D_CD = 9;
            public static int SL_PV = 10;
            public static int D_PV = 11;
            public static int SL_BS = 12;
            public static int D_BS = 13;
            public static int SL_BT = 14;
            public static int D_BT = 15;
            public static int TRUCHITIEU = 16;
            public static int TONGDIEM = 17;
            public static int TANGGIAM = 18;
            public static int THANHTIEN = 19;

            public static string GetToBaAmHeader(double toBaAmCriteria, double daysOfMonth) 
                => $"Tổ bá âm: Thu tin qua điện thoại + Vận hành máy ({toBaAmCriteria}đ/1CT). Tổng cộng: {daysOfMonth} chương trình";
            public static string GetBBTHeader(double BBTPercent, long CTVCost, long PVCost) 
                => $"Trích Ban Biên tập {BBTPercent}%. ( ({PVCost.ToString("n0")} + {CTVCost.ToString("n0")}) x {BBTPercent}% )";
        }

        public static class TTNM_COL
        {
            public static int STT = 1;
            public static int HO_TEN = 2;
            public static int DON_VI = 3;
            public static int SL_TIN = 4;
            public static int D_TIN = 5;
            public static int SL_PS = 6;
            public static int D_PS = 7;
            public static int SL_QTin = 8;
            public static int D_QTin = 9;
            public static int SL_QPsu = 10;
            public static int D_QPsu = 11;
            public static int SL_Tlt = 12;
            public static int D_Tlt = 13;
            public static int SL_Thop = 14;
            public static int D_Thop = 15;
            public static int TRUCHITIEU = 16;
            public static int TONGDIEM = 17;
            public static int TANGGIAM = 18;
            public static int THANHTIEN = 19;

            public static string GetBBTHeader(double BBTPercent)
                => $"Ban biên tập {BBTPercent}%";
            public static string GetPTVHeader(double PTVPercent)
                => $"Phát thanh viên {PTVPercent}%";
            public static string GetKTDHeader(double KTDPercent)
                => $"Kỹ thuật dựng {KTDPercent}%";
        }

        public static class BSTTNM_COL
        {
            public static int STT = 1;
            public static int HO_TEN = 2;
            public static int DON_VI = 3;
            public static int SL_BS_TTN = 4;
            public static int D_BS_TTN = 5;
            public static int SL_Sapo = 6;
            public static int D_Sapo = 7;
            public static int SL_Kthinh = 8;
            public static int D_Kthinh = 9;
            public static int SL_Tfile = 10;
            public static int D_Tfile = 11;
            public static int SL_BtDuyet = 12;
            public static int D_BtDuyet = 13;
            public static int TRUCHITIEU = 14;
            public static int TONGDIEM = 15;
            public static int TANGGIAM = 16;
            public static int THANHTIEN = 17;
        }

        public static class KHK_COL
        {
            public static int STT = 1;
            public static int HO_TEN = 2;
            public static int DON_VI = 3;
            public static int SL_DCT = 4;
            public static int D_DCT = 5;
            public static int SL_KTD = 6;
            public static int D_KTD = 7;
            public static int SL_TCT = 8;
            public static int D_TCT = 9;
            public static int SL_KTTH = 10;
            public static int D_KTTH = 11;
            public static int TRUCHITIEU = 12;
            public static int TONGDIEM = 13;
            public static int TANGGIAM = 15;
            public static int THANHTIEN = 17;
            public static string GetBBTHeader(double BBTPercent)
                => $"Ban biên tập {BBTPercent}%";
        }

        public static class TS_KHK_COL
        {
            public static int STT = 1;
            public static int BO_PHAN = 2;
            public static int CONG_THUC = 3;
            public static int THANHTIEN = 4;

        }

        public static class Criterias_THOI_SU
        {
            public static int PV_PTV = 1;
            public static int CTV = 2;
            public static int BT_CTTS = 3;
            public static int PTV = 4;
            public static int KTD = 5;
            public static int TP_TRUC_CTTS = 6;
            public static int PV_TD = 7;
            public static int SO_NGAY = 8;
            public static int NGUOI_VI_TINH = 9;
            public static int TIEN_VI_TINH = 10;
            public static int DANH_SACH = 11;
        }

        public static class Criterias_PT
        {
            public static int PV_PTV = 12;
            public static int CTV = 13;
            public static int BBT = 14;
        }

        public static class Criterias_PTTT
        {
            public static int PV_PTV = 15;
            public static int CTV = 16;
            public static int BBT = 18;
            public static int ToBaAm = 17;
        }

        public static class Criterias_TTNM
        {
            public static int PV_PTV = 19;
            public static int CTV = 20;
            public static int KTD = 21;
            public static int BBT = 22;
            public static int PTV = 23;
        }
        public static class Criterias_BSTTNM
        {
            public static int PV_PTV = 24;
            public static int BBT = 25;
        }

        public static class Criterias_Percent
        {
            public static int TANG_GIAM_PV_BTV = 1;
            public static int TANG_GIAM_CTV = 2;
        }

        public static class ImportArticle_Table_Header
        {
            public static List<string> THOI_SU_HANG_NGAY = new List<string> { "Tin", "PS", "QTin", "QPs" };
            public static List<string> THONG_TIN_NGAY_MOI = new List<string> { "Tin", "PS", "QTin", "QPs", "Tl_Tin", "Thop" };
            public static List<string> PHAT_THANH = new List<string> { "Tin", "Pv_Pb", "Tlt", "Sd", "Cd_Cm", "Bai" };
            public static List<string> PHAT_THANH_TT = new List<string> { "Tin", "Pv_Pb", "TTh_Gnh", "CDe", "Bs_DCT", "Bt_Dd" };
            public static List<string> BSTTNM_TIN = new List<string> { "Bs_TTN", "Bs_Sapo/Tỉnh", "KThinh", "TFile", "Bt_Duyet Sa/Tối" };
            public static List<string> BSTTNM_KHOI_HAU_KY = new List<string> { "DCT", "KTD Sa/Tối", "TCT Sa", "KT_TH" };
            public static Dictionary<string, string> BSTTNM_KHK_MAP = new Dictionary<string, string>{
                {"Bs_TTN", "Bs_TTN"},
                {"Bs_Sapo", "Bs_Sapo/Tỉnh"},
                {"KThinh", "KThinh"},
                {"TFile", "TFile"},
                {"Bt_Duyet", "Bt_Duyet Sa/Tối"},

                { "DCT", "DCT"},
                { "KTD", "KTD Sa/Tối"},
                { "TCT", "TCT Sa"},
                { "KT_TH", "KT_TH"},

            };

        }

        public static class ReportName
        {
            public static string TS = "BẢNG THÙ LAO NHUẬN BÚT THỜI SỰ TRUYỀN HÌNH";
            public static string TSKHK = "BẢNG THÙ LAO KHỐI HẬU KỲ THỜI SỰ TRUYỀN HÌNH ";
            public static string PT = "BẢNG TỔNG HỢP NHUẬN BÚT PHÁT THANH";
            public static string PTTT = "BẢNG TỔNG HỢP NHUẬN BÚT PHÁT THANH TRỰC TIẾP";
            public static string TTNM = "BẢNG THÙ LAO TIN, PS TRÊN TỪNG CÂY SỐ";
            public static string BSTTNM = "BẢNG TỔNG HỢP THÙ LAO BIÊN SOẠN TRÊN TỪNG CÂY SỐ";
        }

        public static class BusinessLogStatus {
            public const string SUCCESS = "Success";
            public const string FAIL = "Fail";
        }        
        public static class LoggerType
        {
            public const string BUSINESS = "businessLogger";
            public const string SYSTEM = "systemLogger";
        }

        public static class NLogVariable
        {
            public const string ACTOR_ID = "actorId";
            public const string MESSAGE = "message";
            public const string TYPE = "type";
            public const string STATUS = "status";
            public const string ADDITIONAL_INFO = "additionalInfo";
            public const string CALL_SITE = "callSite";
        }
        
    }
}
