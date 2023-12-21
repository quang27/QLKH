using System;
using System.Collections.Generic;

namespace GUIs.Models.EF;

public partial class GiaoVien
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public int Cot { get; set; }

    public string Code { get; set; } = null!;

    public bool Trangthai { get; set; }

    public virtual ICollection<KhoaHoc> KhoaHocs { get; set; } = new List<KhoaHoc>();

    public virtual ICollection<TaiTaiLieu> TaiTaiLieus { get; set; } = new List<TaiTaiLieu>();
}
