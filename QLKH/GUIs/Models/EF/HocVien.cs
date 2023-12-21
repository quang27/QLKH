using System;
using System.Collections.Generic;

namespace GUIs.Models.EF;

public partial class HocVien
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public int Cos { get; set; }

    public bool Trangthai { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<DangKyKhoaHoc> DangKyKhoaHocs { get; set; } = new List<DangKyKhoaHoc>();

    public virtual ICollection<TaiTaiLieu> TaiTaiLieus { get; set; } = new List<TaiTaiLieu>();
}
