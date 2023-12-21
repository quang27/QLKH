using GUIs.Models.DAO;
using GUIs.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace GUIs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class khoahocController : Controller
    {
        public IActionResult Index()
        {
            giaovienDAO giaovien = new giaovienDAO();
            List<Lopchung> pagesize = new List<Lopchung>();
            pagesize.Add(new Lopchung { ID = 10 });
            pagesize.Add(new Lopchung { ID = 20 });
            pagesize.Add(new Lopchung { ID = 30 });
            pagesize.Add(new Lopchung { ID = 40 });
            pagesize.Add(new Lopchung { ID = 50 });
            ViewBag.Pagesize = pagesize;
            ViewBag.listGiaovien = giaovien.getList();
            return View();
        }
        public JsonResult Create(string name, int giaovienid,DateTime ngaybatdau,DateTime ngayketthuc,bool hoctudo,string icon,string mucdichyeucau,string mota,bool trangthai,bool vip)
        {

            khoahocDAO khoahoc = new khoahocDAO();
            KhoaHoc item = new KhoaHoc();
            item.Name = name;
            item.GiaovienId = giaovienid;
            item.Ngaytao = DateTime.Now;
            item.Ngaybatdau = ngaybatdau;
            item.Ngayketthuc=ngayketthuc;
            item.Hoctudo=hoctudo;
            item.Icon=icon;
            item.Mucdichyeucau=mucdichyeucau;
            item.Mota=mota;
            item.Trangthai=trangthai;
            item.Vip=vip;
            khoahoc.InsertOrUpdate(item);
            return Json(new { mess = "Thêm khóa học thành công" });
        }
        public JsonResult Update(int id,string name,int giaovienid,DateTime ngaybatdau,DateTime ngayketthuc,bool hoctudo,string icon,string mucdichyeucau,string mota,bool trangthai,bool vip) 
        {
            khoahocDAO khoahoc = new khoahocDAO();
            var item = khoahoc.getItem(id);
            item.Name = name;
            item.GiaovienId = giaovienid;
            item.Ngaybatdau = ngaybatdau;
            item.Ngayketthuc = ngayketthuc;
            item.Hoctudo = hoctudo;
            item.Icon = icon;
            item.Mucdichyeucau = mucdichyeucau;
            item.Mota = mota;
            item.Trangthai=trangthai; 
            item.Vip=vip;
            khoahoc.InsertOrUpdate(item);
            return Json(new { mess = "Chỉnh sửa khóa học thành công" });
        }
        public JsonResult getKhoahoc(int id)
        {
            khoahocDAO khoahoc = new khoahocDAO();

            var query = khoahoc.getItemView(id);
            return Json(new { data = query });
        }
        [HttpPost]
        public JsonResult ShowList(string name = "", bool trangthai = true, int index = 1, int size = 10)
        {
            khoahocDAO khoahoc = new khoahocDAO();
            int total = 0;
            var query = khoahoc.Search(name, trangthai, out total, index, size);
            string text = "";

            foreach (var item in query)
            {
                text += "<tr>";
                text += "<td>" + item.Id + "</td>";
                text += "<td>" + item.Name + "</td>";
                text += "<td>" + item.giaovien + "</td>";
                text += "<td>" + item.Ngaytao + "</td>";
                text += "<td>" + item.Ngaybatdau + "</td>";
                text += "<td>" + item.Ngayketthuc + "</td>";
                text += "<td>" + item.Hoctudo + "</td>";
                text += "<td>" + item.Icon + "</td>";
                text += "<td>" + item.Hoctudo + "</td>";
                text += "<td>" + item.Vip + "</td>";
                text += "<td>" +
                    "<a href='javacript:void(0)' data-toggle='modal' data-target='#update' data-whatever='" + item.Id + "'><i class='fa fa-edit'></i></a>" + "</td>";
                text += " <a href='/Admin/khoahoc/Delete/" + item.Id + "'><i class='fa fa-trash' aria-hidden='true'></i> </a></td>";
                text += "</tr>";
            }
            string page = Support.Support.InTrang(total, index, size);
            return Json(new { data = text, page = page });
        }
    }
}
