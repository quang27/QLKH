namespace GUIs.Models.VIEW
{
    public class hocvienVIEW
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Email { get; set; }

        public int Cos { get; set; }

        public bool Trangthai { get; set; }

        public string Code { get; set; } = null!;
    }
}
