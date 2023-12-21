using GUIs.Models.DAO;
using GUIs.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace GUIs.Areas.Admin.Controllers
{
    public class hocvienController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            List<Lopchung> pagesize = new List<Lopchung>();
            pagesize.Add(new Lopchung { ID = 10 });
            pagesize.Add(new Lopchung { ID = 20 });
            pagesize.Add(new Lopchung { ID = 30 });
            pagesize.Add(new Lopchung { ID = 40 });
            pagesize.Add(new Lopchung { ID = 50 });
            ViewBag.Pagesize = pagesize;
            return View();
        }
        public JsonResult Create(string name,string username,string password,string email,int cos,bool trangthai,string code)
        {
            hocvienDAO hocvien = new hocvienDAO();
            var item = new HocVien();
            item.Name = name;
            item.Username = username;
            item.Password = password;
            item.Email = email;
            item.Cos = cos;
            item.Trangthai = trangthai;
            item.Code = code;
            hocvien.InsertOrUpdate(item);
            return Json(new { mess = "Thêm học viên thành công" });
        }
        public JsonResult Update(int id,string name, string username, string password, string email, int cos, bool trangthai, string code)
        {
            hocvienDAO hocvien = new hocvienDAO();
            var item = hocvien.getItem(id);
            item.Name = name;
            item.Username = username;
            item.Password = password;
            item.Email = email;
            item.Cos = cos;
            item.Trangthai = trangthai;
            item.Code = code;
            hocvien.InsertOrUpdate(item);
            return Json(new { mess = "Chỉnh sửa học viên thành công" });
        }
        public JsonResult getHocvien(int id)
        {
            hocvienDAO hocvien = new hocvienDAO();

            var query = hocvien.getItemView(id);
            return Json(new { data = query });
        }
        [HttpPost]
        public JsonResult ShowList(string name = "", bool trangthai = true, int index = 1, int size = 10)
        {
            hocvienDAO hocvien = new hocvienDAO();
            int total = 0;
            var query = hocvien.Search(name, trangthai, out total, index, size);
            string text = "";

            foreach (var item in query)
            {
                text += "<tr>";
                text += "<td>" + item.Id + "</td>";
                text += "<td>" + item.Name + "</td>";
                text += "<td>" + item.Username + "</td>";
                text += "<td>" + item.Email + "</td>";
                text += "<td>" + item.Cos + "</td>";
                text += "<td>" +
                    "<a href='javacript:void(0)' data-toggle='modal' data-target='#update' data-whatever='" + item.Id + "'><i class='fa fa-edit'></i></a>" + "</td>";
                text += " <a href='/Admin/hocvien/Delete/" + item.Id + "'><i class='fa fa-trash' aria-hidden='true'></i> </a></td>";
                text += "</tr>";
            }
            string page = Support.Support.InTrang(total, index, size);
            return Json(new { data = text, page = page });
        }
    }
}
