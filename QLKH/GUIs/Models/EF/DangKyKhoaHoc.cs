using System;
using System.Collections.Generic;

namespace GUIs.Models.EF;

public partial class DangKyKhoaHoc
{
    public int Id { get; set; }

    public int HocvienId { get; set; }

    public int KhoahocId { get; set; }

    public DateTime Ngaydangky { get; set; }

    public bool Xacnhan { get; set; }

    public virtual HocVien Hocvien { get; set; } = null!;

    public virtual KhoaHoc Khoahoc { get; set; } = null!;
}
