﻿using System;
using System.Collections.Generic;

namespace GUIs.Models.EF;

public partial class KhoaHoc
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

    public virtual ICollection<ChuDe> ChuDes { get; set; } = new List<ChuDe>();

    public virtual ICollection<DangKyKhoaHoc> DangKyKhoaHocs { get; set; } = new List<DangKyKhoaHoc>();

    public virtual GiaoVien Giaovien { get; set; } = null!;
}
