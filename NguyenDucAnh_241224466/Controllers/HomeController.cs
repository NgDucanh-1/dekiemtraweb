using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenDucAnh_241224466.Models;

namespace NguyenDucAnh_241224466.Controllers;

public class HomeController : Controller
{
    private readonly QLNhaSachContext _db;

    public HomeController(QLNhaSachContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.TieuDe = "Nguyễn Đức Anh";
        var ds = await _db.Saches
            .Where(s => s.Gia != null && s.Gia >= 100)
            .OrderBy(s => s.MaSach)
            .ToListAsync();
        return View(ds);
    }

    public async Task<IActionResult> SachTheoTheLoai(int maTL)
    {
        var tl = await _db.TheLoais.FindAsync(maTL);
        ViewBag.TieuDe = tl?.TenTl;
        var ds = await _db.Saches
            .Where(s => s.MaTl == maTL)
            .OrderBy(s => s.MaSach)
            .ToListAsync();
        return PartialView("NguyenDucAnh_MainContent", ds);
    }
}
