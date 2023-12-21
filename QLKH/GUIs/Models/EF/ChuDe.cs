using System;
using System.Collections.Generic;

namespace GUIs.Models.EF;

public partial class ChuDe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int KhoahocId { get; set; }

    public DateTime Ngaytao { get; set; }

    public string? Icon { get; set; }

    public string? Mucdichyeucau { get; set; }

    public string? Mota { get; set; }

    public bool Trangthai { get; set; }

    public bool Vip { get; set; }

    public virtual ICollection<BaiHoc> BaiHocs { get; set; } = new List<BaiHoc>();

    public virtual KhoaHoc Khoahoc { get; set; } = null!;
}
