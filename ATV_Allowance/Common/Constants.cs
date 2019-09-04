using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static class ADGVText
        {
            //Customers, Sessions(Name, Code)
            public static string Name = "Tên";
            public static string Code = "Mã";
            public static string Address = "Địa chỉ";
            public static string TaxCode = "Mã số thuế";
            //CustomerTypes
            public static string Description = "Mô tả";
            public static string CustomerType = "Loại hình";
            //Discounts
            public static string PriceRate = "Mức giá";
            public static string Discount = "Giảm giá (%)";
            //Durations, TimSlots(Duration)
            public static string Duration = "Thời lượng (s)";
            //TimSlots
            public static string Session = "Buổi";
            //Contracts
            public static string CustomerCode = "Mã KH";
            public static string ContractCode = "Mã HĐ";
            public static string StartDate = "Bắt đầu";
            public static string EndDate = "Kết thúc";
            public static string ContractType = "Loại HĐ";
            public static string Cost = "Giá tiền (VNĐ)";
            //ContractDetail
            public static string BelongToContractCode = "Mã hợp đồng";
            public static string ShowDate = "Ngày chiếu";
            public static string TimeSlot = "Khung giờ";
            public static string Quantity = "Số lượng";
            public static string TotalCost = "Thành tiền (VNĐ)";
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
    }
}
