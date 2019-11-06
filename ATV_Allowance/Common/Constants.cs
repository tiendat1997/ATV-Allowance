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
            public static string Diem = "Điểm";
            public static string TotalPoint = "Tổng điểm";
            public static string TotalCost = "Thành tiền";

            //report "thong tin ngay moi"
            public static string SoQTin = "QTin";
            public static string SoQPsu = "QPsu";
            public static string SoTHop = "Thop";

            //report "bien soan thong tin ngay moi"
            public static string SoBs_TTN = "Bs_TTN";
            public static string SoBs_Sapo = "Bs_Sapo";
            public static string SoKThinh = "KThinh";
            public static string SoTFile = "TFile";
            public static string SoBt_Duyet = "Bt_Duyet";

            //report "khoi hau ky thong tin ngay moi"
            public static string SoDCT = "DCT";
            public static string SoKTD = "KTD";
            public static string SoTCT = "TCT";
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
            public static int Login = 1;
            public static int Logout = 2;
            public static int Create = 3;
            public static int Delete = 4;
            public static int Update = 5;
            public static int ExportData = 6;
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
            public static int PHAT_THANH = 1;
            public static int PHAT_THANH_TT = 2;
            public static int THOI_SU = 3;
            public static int PV_TTNM = 4;
            public static int BIENSOAN_TTNM = 5;
            public static int KHOIHK_TTNM = 6;
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
        }

        public static class TS_COL
        {
            public static int STT = 1;
            public static int HO_TEN = 2;
            public static int TIN = 3;
            public static int TIN_DIEM = 4;
            public static int PHSU = 5;
            public static int PHSU_DIEM = 6;
            public static int QTIN_DIEM = 7;
            public static int QPSU_DIEM = 8;
            public static int CONG = 9;
            public static int TRUCHITIEU = 10;
            public static int TANGGIAM = 11;
            public static int TONGCONG = 12;
            public static int THANHTIEN = 13;
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
            public static int TONGDIEM = 16;
            public static int TANGGIAM = 17;
            public static int THANHTIEN = 18;
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
            public static int TONGDIEM = 16;
            public static int TANGGIAM = 17;
            public static int THANHTIEN = 18;
        }

        public static class BSTTNM_COL
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
            public static int TONGDIEM = 16;
            public static int TANGGIAM = 17;
            public static int THANHTIEN = 18;
        }

        public static class TTNM_COL
        {
            public static int STT = 1;
            public static int HO_TEN = 2;
            public static int DON_VI = 3;
            public static int SL_BS_TTN= 4;
            public static int D_BS_TTN = 5;
            public static int SL_Sapo = 6;
            public static int D_Sapo = 7;
            public static int SL_Kthinh = 8;
            public static int D_Kthinh = 9;
            public static int SL_Tfile = 10;
            public static int D_Tfile = 11;
            public static int SL_BtDuyet = 12;
            public static int D_BtDuyet = 13;
            public static int TONGDIEM = 14;
            public static int TANGGIAM = 15;
            public static int THANHTIEN = 16;
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
            public static int TONGDIEM = 12;
            public static int TANGGIAM = 13;
            public static int THANHTIEN = 14;
        }
    }
}
