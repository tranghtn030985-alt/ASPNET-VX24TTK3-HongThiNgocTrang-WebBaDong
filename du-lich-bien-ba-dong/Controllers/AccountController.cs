using System.Web.Mvc;

namespace YourProjectName.Controllers // Thay YourProjectName bằng tên dự án của bạn
{
    public class AccountController : Controller
    {
        // GET: Hiển thị trang đăng nhập
        public ActionResult Index()
        {
            // Nếu đã đăng nhập trước đó thì vào thẳng Admin
            if (Session["AdminUser"] != null)
            {
                return RedirectToAction("NewsManagement", "Admin");
            }
            return View();
        }

        // POST: Xử lý thông tin đăng nhập gửi lên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            // Tài khoản kiểm thử (Bạn có thể đổi tùy ý)
            if (username == "admin" && password == "123456")
            {
                // Lưu trạng thái đăng nhập vào Session
                Session["AdminUser"] = username;

                // Đăng nhập thành công -> Vào trang quản trị tin tức
                return RedirectToAction("NewsManagement", "Admin");
            }

            // Đăng nhập thất bại -> Trả lại thông báo lỗi ra giao diện kính mờ
            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu Admin không chính xác!";
            return View("Index");
        }
    }
}