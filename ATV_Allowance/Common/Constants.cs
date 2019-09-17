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
            public static string Organization = "Đơn vị";
        }

        public static class ADGVReportHeader
        {
            public static string Name = "Họ và tên";
            public static string Organization = "Đơn vị";
            public static string ArticleAmount = "SL Tin";
            public static string ArticlePoint = "Đ Tin";
            public static string SpeechAmount = "SL T/thuật G/nhanh";
            public static string SpeechPoint = "Đ T/thuật G/nhanh";
            public static string MajorAmount = "SL Chuyên đề";
            public static string MajorPoint = "Đ Chuyên đề";
            public static string PVAmount = "SL Pv/Pb";
            public static string PVPoint = "Đ Pv/Pb";
            public static string BSAmount = "SL B/soạn Dẫn CT";
            public static string BSPoint = "Đ B/soạn Dẫn CT";
            public static string BTAmount = "SL B/tập Đ/diễn";
            public static string BTPoint = "Đ B/tập Đ/diễn";
            public static string TotalPoint = "Tổng điểm";
            public static string IncreasePercent = "Tăng 30%";
            public static string TotalCost = "Thành tiền";


        }
        public static class ADGVArticleText
        {
            public static string Title = "Tin";
            public static string Date = "Ngày";
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

        public static class ReportType
        {
            public static int PT = 1;
            public static int PTTT = 2;
            public static int TS = 3;
        }

        public static class Unit
        {
            public static int Percent = 1;
            public static int Point = 2;
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
            public static int THOI_SU = 1;
            public static int PHAT_THANH = 2;
            public static int PHAT_THANH_TT = 3;
        }
    }
}
