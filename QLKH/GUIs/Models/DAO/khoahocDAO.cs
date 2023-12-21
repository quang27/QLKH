using GUIs.Models.EF;
using GUIs.Models.VIEW;

namespace GUIs.Models.DAO
{
    public class khoahocDAO
    {
        private KhoahocContext context = new KhoahocContext();
        public void InsertOrUpdate(KhoaHoc item)
        {
            if (item.Id == 0)
            {
                context.KhoaHocs.Add(item);
            }
            context.SaveChanges();
        }
        public KhoaHoc getItem(int id)
        {

            return context.KhoaHocs.Where(x => x.Id == id).FirstOrDefault();
        }
        public khoahocVIEW getItemView(int id)
        {

            var query = (from a in context.KhoaHocs
                         where a.Id == id
                         select new khoahocVIEW
                         {
                             Id = a.Id,
                             Name = a.Name,
                             GiaovienId = a.GiaovienId,
                             Ngaytao = a.Ngaytao,
                             Ngaybatdau = a.Ngaybatdau,
                             Ngayketthuc = a.Ngayketthuc,
                             Hoctudo = a.Hoctudo,
                             Icon = a.Icon,
                             Mucdichyeucau=a.Mucdichyeucau,
                             Mota=a.Mota,
                             Trangthai=a.Trangthai,
                             Vip=a.Vip
                         }).FirstOrDefault();
       
            return query;
        }

        public List<khoahocVIEW> getList()
        {
            var query = (from a in context.KhoaHocs
                         select new khoahocVIEW
                         {
                             Id = a.Id,
                             Name = a.Name,
                             GiaovienId = a.GiaovienId,
                             Ngaytao = a.Ngaytao,
                             Ngaybatdau = a.Ngaybatdau,
                             Ngayketthuc = a.Ngayketthuc,
                             Hoctudo = a.Hoctudo,
                             Icon = a.Icon,
                             Mucdichyeucau = a.Mucdichyeucau,
                             Mota = a.Mota,
                             Trangthai = a.Trangthai,
                             Vip = a.Vip
                         }).ToList();
            return query;
        }
        public List<khoahocVIEW> Search(String name, bool status, out int total, int index = 1, int size = 10)
        {

            var query = (from a in context.KhoaHocs
                         join b in context.GiaoViens on a.GiaovienId equals b.Id
                         where (a.Trangthai == status)
                         select new khoahocVIEW
                         {
                             Id = a.Id,
                             Name = a.Name,
                             GiaovienId = a.GiaovienId,
                             Ngaytao = a.Ngaytao,
                             Ngaybatdau = a.Ngaybatdau,
                             Ngayketthuc = a.Ngayketthuc,
                             Hoctudo = a.Hoctudo,
                             Icon = a.Icon,
                             Mucdichyeucau = a.Mucdichyeucau,
                             Mota = a.Mota,
                             Trangthai = a.Trangthai,
                             Vip = a.Vip,
                             giaovien=b.Name
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
            KhoaHoc x = getItem(id);
            context.KhoaHocs.Remove(x);
            context.SaveChanges();
        }
    }
}
