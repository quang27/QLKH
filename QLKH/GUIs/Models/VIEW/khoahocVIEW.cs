namespace GUIs.Models.VIEW
{
    public class khoahocVIEW
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int GiaovienId { get; set; }

        public DateTime Ngaytao { get; set; }

        public DateTime? Ngaybatdau { get; set; }

        public DateTime? Ngayketthuc { get; set; }

        public bool Hoctudo { get; set; }

        public string Icon { get; set; } = null!;

        public string? Mucdichyeucau { get; set; }

        public string? Mota { get; set; }

        public bool Trangthai { get; set; }

        public bool Vip { get; set; }
        public string giaovien {  get; set; }=null!;

    }
}
