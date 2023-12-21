using System;
using System.Collections.Generic;

namespace GUIs.Models.EF;

public partial class TaiLieu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;

    public string? Icon { get; set; }

    public string Loai { get; set; } = null!;

    public int Thutu { get; set; }

    public bool Vip { get; set; }

    public int Luottai { get; set; }

    public bool Trangthai { get; set; }

    public DateTime Ngaytai { get; set; }

    public int BaihocId { get; set; }

    public virtual BaiHoc Baihoc { get; set; } = null!;

    public virtual ICollection<TaiTaiLieu> TaiTaiLieus { get; set; } = new List<TaiTaiLieu>();
}
