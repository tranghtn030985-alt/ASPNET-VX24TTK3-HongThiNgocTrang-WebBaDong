using System.Web.Mvc;

public class AdminController : Controller
{
    // Trang Dashboard chính hiển thị giao diện Thêm/Xóa/Sửa Tin tức
    public ActionResult NewsManagement()
    {
        if (Session["AdminUser"] == null) return RedirectToAction("Index", "Account");
        return View();
    }

    [HttpPost]
    public ActionResult SaveNews(string Id, string Title, string ImageUrl, string Summary)
    {
        if (Session["AdminUser"] == null) return RedirectToAction("Index", "Account");

        // Logic xử lý nhận dữ liệu gửi lên từ form (Thêm vào Database nếu có ADO/Entity)
        // Sau khi xử lý xong, tải lại trang danh sách bài viết
        return RedirectToAction("NewsManagement");
    }

    public ActionResult DeleteNews(int id)
    {
        if (Session["AdminUser"] == null) return RedirectToAction("Index", "Account");

        // Logic xử lý xóa bài viết dựa trên ID truyền vào từ bảng
        return RedirectToAction("NewsManagement");
    }

    public ActionResult Logout()
    {
        Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}