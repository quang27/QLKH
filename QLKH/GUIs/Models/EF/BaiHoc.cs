using System;
using System.Collections.Generic;

namespace GUIs.Models.EF;

public partial class BaiHoc
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ChudeId { get; set; }

    public DateTime Ngaytao { get; set; }

    public string? Icon { get; set; }

    public string? Mucdichyeucau { get; set; }

    public string? Mota { get; set; }

    public bool Trangthai { get; set; }

    public bool Vip { get; set; }

    public virtual ChuDe Chude { get; set; } = null!;

    public virtual ICollection<TaiLieu> TaiLieus { get; set; } = new List<TaiLieu>();
}
