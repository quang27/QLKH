using GUIs.Models.DAO;
using GUIs.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace GUIs.Areas.Admin.Controllers
{
    
    public class Lopchung
    {
        public int ID { set; get; }
    }
    [Area("Admin")]
    public class giaovienController : Controller
    {
         
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
        public JsonResult Create(string name, string username, string password, string email, int cot,string code,int status)
        {

            giaovienDAO giaovien = new giaovienDAO();
            GiaoVien item = new GiaoVien();
            item.Name = name;
            item.Username = username;
            item.Password = Support.Support.HashSHA256(password);
            item.Email = email;
            item.Cot =cot;
            item.Code = code;
            bool trangthai = Convert.ToBoolean(status);
            item.Trangthai = trangthai;
            giaovien.InsertOrUpdate(item);
            return Json(new { mess = "Thêm giảng viên thành công" });
        }

        public JsonResult Update(int id, string name, string username, string password, string email, int cot, string code, int status)
        {

            giaovienDAO giaovien = new giaovienDAO();
            var item = giaovien.getItem(id);
            item.Name = name;
            item.Username = username;
            item.Password = Support.Support.HashSHA256(password);
            item.Email = email;
            item.Cot = cot;
            item.Code = code;
            bool trangthai = Convert.ToBoolean(status);
            item.Trangthai = trangthai;
            giaovien.InsertOrUpdate(item);
            return Json(new { mess = "Chỉnh sửa giảng viên thành công" });
        }
        [HttpGet]
        public JsonResult getGiaovien(int id)
        {
            giaovienDAO giaovien = new giaovienDAO();

            var query = giaovien.getItemView(id);
            return Json(new { data = query });
        }
        [HttpPost]
        public JsonResult ShowList(string name ="", int status=1,int index = 1,int size = 10)
        {
            giaovienDAO giaovien = new giaovienDAO();
            int total = 0;

            bool statusBool = Convert.ToBoolean(status);
            var query = giaovien.Search(name, statusBool, out total, index, size);
            string text = "";

            foreach (var item in query)
            {
                text += "<tr>";
                text += "<td>" + item.Id + "</td>";
                text += "<td>" + item.Name + "</td>";
                text += "<td>" + item.Username + "</td>";
                text += "<td>" + item.Email + "</td>";
                text += "<td>" + item.Cot + "</td>";
                text += "<td>" + item.Code + "</td>";
                text += "<td>" + item.Cot + "</td>";
                text += "<td>" +
                    "<a href='javacript:void(0)' data-toggle='modal' data-target='#update' data-whatever='" + item.Id + "'><i class='fa fa-edit'></i></a>" + "</td>";
                text += " <a href='/Admin/giaovien/Delete/" + item.Id + "'><i class='fa fa-trash' aria-hidden='true'></i> </a></td>";
                text += "</tr>";
            }
            string page = Support.Support.InTrang(total, index, size);
            return Json(new { data = text, page = page });
        }

    }
}
