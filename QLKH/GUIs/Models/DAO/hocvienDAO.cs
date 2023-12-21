using GUIs.Models.EF;
using GUIs.Models.VIEW;

namespace GUIs.Models.DAO
{
    public class hocvienDAO
    {
        private KhoahocContext context = new KhoahocContext();
        public void InsertOrUpdate(HocVien item)
        {
            if (item.Id == 0)
            {
                context.HocViens.Add(item);
            }
            context.SaveChanges();
        }
        public HocVien getItem(int id)
        {

            return context.HocViens.Where(x => x.Id == id).FirstOrDefault();
        }
        public hocvienVIEW getItemView(int id)
        {

            var query = (from a in context.HocViens
                         where a.Id == id
                         select new hocvienVIEW
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Username = a.Username,
                             Password = a.Password,
                             Email = a.Email,
                             Cos = a.Cos,
                             Trangthai = a.Trangthai,
                             Code = a.Code
                         }).FirstOrDefault();
            return query;
        }

        public List<hocvienVIEW> getList()
        {
            var query = (from a in context.HocViens
                         select new hocvienVIEW
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Username = a.Username,
                             Password = a.Password,
                             Email = a.Email,
                             Cos = a.Cos,
                             Trangthai = a.Trangthai,
                             Code = a.Code
                         }).ToList();
            return query;
        }
        public List<hocvienVIEW> Search(String name, bool trangthai, out int total, int index = 1, int size = 10)
        {

            var query = (from a in context.HocViens
                         where (a.Trangthai == trangthai)
                         select new hocvienVIEW
                         { 
                             Id = a.Id,
                             Name = a.Name,
                             Username = a.Username,
                             Password = a.Password,
                             Email = a.Email,
                             Cos = a.Cos,
                             Trangthai = a.Trangthai,
                             Code = a.Code
                         }).ToList();
            if (name != null && name != "")
            {
                query = query.Where(x => x.Name.Contains(name)).ToList();
            }
            total = query.Count();
            var result = query.Skip((index - 1) * size).Take(size).ToList();
            return result;
        }
        public void Detele(int id)
        {
            HocVien x = getItem(id);
            context.HocViens.Remove(x);
            context.SaveChanges();
        }
    }
}
