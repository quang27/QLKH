using GUIs.Models.EF;
using GUIs.Models.VIEW;
using Microsoft.EntityFrameworkCore;

namespace GUIs.Models.DAO
{
    public class giaovienDAO
    {
        private KhoahocContext context = new KhoahocContext();
        public void InsertOrUpdate(GiaoVien item)
        {
            if (item.Id == 0)
            {
                context.GiaoViens.Add(item);
            }
            context.SaveChanges();
        }
        public GiaoVien getItem(int id)
        {

            return context.GiaoViens.Where(x => x.Id == id).FirstOrDefault();
        }
        public giaovienVIEW getItemView(int id)
        {

            var query = (from a in context.GiaoViens
                         where a.Id == id
                         select new giaovienVIEW
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Username = a.Username,
                             Password = a.Password,
                             Email = a.Email,
                             Cot = a.Cot,
                             Code = a.Code,
                             Trangthai = a.Trangthai
                         }).FirstOrDefault();
            return query;
        }

        public List<giaovienVIEW> getList()
        {
            var query = (from a in context.GiaoViens
                         select new giaovienVIEW
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Username = a.Username,
                             Password = a.Password,
                             Email = a.Email,
                             Cot = a.Cot,
                             Code = a.Code,
                             Trangthai = a.Trangthai
                         }).ToList();
            return query;
        }
        public List<giaovienVIEW> Search(String name,bool status, out int total, int index = 1, int size = 10)
        {
            
            var query = (from a in context.GiaoViens
                         where (a.Trangthai == status)
                         select new giaovienVIEW
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Username = a.Username,
                             Password = a.Password,
                             Email = a.Email,
                             Cot = a.Cot,
                             Code = a.Code,
                             Trangthai = a.Trangthai
                         }).ToList();
            if (name != null && name != ""){
                query = query.Where(x=>x.Name.Contains(name)).ToList();
            }
            total = query.Count();
            var result = query.Skip((index - 1) * size).Take(size).ToList();
            return result;
        }
        public void Detele(int id)
        {
            GiaoVien x = getItem(id);
            context.GiaoViens.Remove(x);
            context.SaveChanges();
        }
    }
}

