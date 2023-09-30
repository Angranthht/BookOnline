using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        private dbSachOnlineDataContext data;

        public SachOnlineController()
        {
            string connectionString = @"Data Source=ANGRANT;Initial Catalog=SachOnline;Integrated Security=True";
            data = new dbSachOnlineDataContext(connectionString);
        }
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        // GET: SachOnline
        public ActionResult Index()
        {
            // Lay 6 quyen sach moi
            var listSachMoi = LaySachMoi(6);
            return View(listSachMoi);
        }
        // GET: NavPartial
        public ActionResult NavPartial()
        {
            return PartialView();
        }
        // GET: SliderPartial
        public ActionResult SliderPartial()
        {
            return PartialView();
        }
        // GET: ChuDePartial
        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }
        // GET: NhaXuatBanPartial
        public ActionResult NhaXuatBanPartial()
        {
            var listNhaXuatBan = from cd in data.NHAXUATBANs select cd;
            return PartialView(listNhaXuatBan);
        }
        // GET: SachBanNhieuPartial
        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = from s in data.SACHes orderby s.SoLuongBan descending select s;
            return PartialView(listSachBanNhieu);
        }
        public ActionResult Sachtheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD==id select s;
            return View(sach);
        }
        // GET: FooterPartial
        public ActionResult FooterPartial()
        {
            return PartialView();
        }
    }
}