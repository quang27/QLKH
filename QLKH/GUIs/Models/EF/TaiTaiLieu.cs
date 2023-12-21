using System;
using System.Collections.Generic;

namespace GUIs.Models.EF;

public partial class TaiTaiLieu
{
    public int Id { get; set; }

    public int? GiaovienId { get; set; }

    public int? HocvienId { get; set; }

    public DateTime Ngaytai { get; set; }

    public int TailieuId { get; set; }

    public virtual GiaoVien? Giaovien { get; set; }

    public virtual HocVien? Hocvien { get; set; }

    public virtual TaiLieu Tailieu { get; set; } = null!;
}
