using du_lich_bien_ba_dong.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class AdminController : Controller
{
    BienBaDongDbContext _db;
    public AdminController()
    {
        _db= new BienBaDongDbContext();
    }
    // Trang Dashboard chính hiển thị giao diện Thêm/Xóa/Sửa Tin tức
    public ActionResult NewsManagement()
    {
        if (Session["AdminUser"] == null) return RedirectToAction("Index", "Account");
        List<TinTuc> t = _db.TinTucs.ToList();
        return View(t);
    }

    [HttpPost]
    public ActionResult SaveNews(TinTuc t,HttpPostedFileBase image)
    {
        if (Session["AdminUser"] == null) return RedirectToAction("Index", "Account");

        // Logic xử lý nhận dữ liệu gửi lên từ form (Thêm vào Database nếu có ADO/Entity)
        // Sau khi xử lý xong, tải lại trang danh sách bài viết
        try
        {
            if (t.TinTucId == 0)
            {
                if (image != null && image.ContentLength > 0)
                {
                    //1. Lấy tên file
                    string fileName = Path.GetFileName(image.FileName);
                    //2. Định nghĩa đường dẫn lưu trữ
                    string path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    image.SaveAs(path);

                    //3 gán tên fileName vào property Product;
                    t.HinhAnhUrl = "/Uploads/" + fileName;
                }
                //4.lưu xuống cơ sở dữ liệu
                _db.TinTucs.Add(t);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Đã thêm thành công tin tức: " + t.TieuDe;
            }
            else
            {
                //Lay Thong tin tin tuc de cap nhat
                TinTuc editTinTuc = _db.TinTucs.FirstOrDefault(x => x.TinTucId == t.TinTucId);

                if (image != null && image.ContentLength > 0)
                {
                    //1. Lấy tên file
                    string fileName = Path.GetFileName(image.FileName);
                    //2. Định nghĩa đường dẫn lưu trữ
                    string path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    image.SaveAs(path);

                    //3 gán tên fileName vào property Product;
                    editTinTuc.HinhAnhUrl = "/Uploads/" + fileName;
                }
                //4 gan du lieu 
                editTinTuc.TinTucId = t.TinTucId;
                editTinTuc.TomTat = t.TomTat;
                editTinTuc.BanTin = t.BanTin;
                editTinTuc.NgayBatDau = t.NgayBatDau;
                editTinTuc.NgayKetThuc = t.NgayKetThuc;
                editTinTuc.TieuDe = t.TieuDe;
                //5.lưu xuống cơ sở dữ liệu
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Đã cập nhật thành công tin tức: " + t.TieuDe;
            }

        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Lỗi định dạng dữ liệu: " + ex.Message;
        }

        return RedirectToAction("NewsManagement");
    }

    public ActionResult DeleteNews(int id)
    {
        if (Session["AdminUser"] == null) return RedirectToAction("Index", "Account");

        // Logic xử lý xóa bài viết dựa trên ID truyền vào từ bảng
        //1 Lấy thông tin tin tức
        TinTuc t = _db.TinTucs.FirstOrDefault(x => x.TinTucId == id);

        if (t == null)
            TempData["ErrorMessage"] = "Không tìm thấy tin tức";
        else
        {
            //2 Xóa tin tức
            _db.TinTucs.Remove(t);
            _db.SaveChanges();
            TempData["SuccessMessage"] = "Xóa tin tức thành công ";
        }

        return RedirectToAction("NewsManagement");
    }

    public ActionResult Logout()
    {
        Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}