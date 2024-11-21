using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using var db = new AppDbContext();
        int choice;

        do
        {
            Console.WriteLine("\n=== QUẢN LÝ KHÁCH HÀNG ===");
            Console.WriteLine("1. Thêm mới khách hàng");
            Console.WriteLine("2. Hiển thị tất cả khách hàng");
            Console.WriteLine("3. Cập nhật khách hàng");
            Console.WriteLine("4. Xóa khách hàng");
            Console.WriteLine("5. Thoát");
            Console.Write("Chọn chức năng: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ThemKhachHang(db);
                    break;
                case 2:
                    HienThiKhachHang(db);
                    break;
                case 3:
                    CapNhatKhachHang(db);
                    break;
                case 4:
                    XoaKhachHang(db);
                    break;
                case 5:
                    Console.WriteLine("Thoát chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        } while (choice != 5);
    }

    static void ThemKhachHang(AppDbContext db)
    {
        Console.Write("Nhập mã khách hàng (NVARCHAR 10): ");
        string maKhach = Console.ReadLine();

        Console.Write("Nhập tên khách hàng: ");
        string tenKhach = Console.ReadLine();

        Console.Write("Nhập giới tính (1: Nam, 0: Nữ): ");
        bool gioiTinhKhach = Console.ReadLine() == "1";

        Console.Write("Nhập địa chỉ khách hàng: ");
        string diaChiKhach = Console.ReadLine();

        Console.Write("Nhập số điện thoại: ");
        string soDienThoai = Console.ReadLine();

        Console.Write("Nhập email: ");
        string email = Console.ReadLine();

        var khachHangMoi = new KhachHang
        {
            MaKhach = maKhach,
            TenKhach = tenKhach,
            GioiTinhKhach = gioiTinhKhach,
            DiaChiKhach = diaChiKhach,
            SoDienThoai = soDienThoai,
            Email = email,
            NgayTao = DateTime.Now,
            NgayChinhSua = DateTime.Now
        };

        db.KhachHangs.Add(khachHangMoi);
        db.SaveChanges();
        Console.WriteLine("Đã thêm khách hàng mới.");
    }

    static void HienThiKhachHang(AppDbContext db)
    {
        var danhSach = db.KhachHangs.ToList();

        Console.WriteLine("\nDANH SÁCH KHÁCH HÀNG:");
        foreach (var kh in danhSach)
        {
            Console.WriteLine($"Mã KH: {kh.MaKhach}, Tên KH: {kh.TenKhach}, GT: {(kh.GioiTinhKhach ? "Nam" : "Nữ")}, Địa chỉ: {kh.DiaChiKhach}, SĐT: {kh.SoDienThoai}, Email: {kh.Email}");
        }
    }

    static void CapNhatKhachHang(AppDbContext db)
    {
        Console.Write("Nhập mã khách hàng cần cập nhật: ");
        string maKhach = Console.ReadLine();

        var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKhach == maKhach);
        if (khachHang == null)
        {
            Console.WriteLine("Không tìm thấy khách hàng.");
            return;
        }

        Console.Write("Nhập tên khách hàng mới: ");
        khachHang.TenKhach = Console.ReadLine();

        Console.Write("Nhập địa chỉ khách hàng mới: ");
        khachHang.DiaChiKhach = Console.ReadLine();

        Console.Write("Nhập số điện thoại mới: ");
        khachHang.SoDienThoai = Console.ReadLine();

        Console.Write("Nhập email mới: ");
        khachHang.Email = Console.ReadLine();

        khachHang.NgayChinhSua = DateTime.Now;

        db.SaveChanges();
        Console.WriteLine("Đã cập nhật thông tin khách hàng.");
    }

    static void XoaKhachHang(AppDbContext db)
    {
        Console.Write("Nhập mã khách hàng cần xóa: ");
        string maKhach = Console.ReadLine();

        var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKhach == maKhach);
        if (khachHang == null)
        {
            Console.WriteLine("Không tìm thấy khách hàng.");
            return;
        }

        db.KhachHangs.Remove(khachHang);
        db.SaveChanges();
        Console.WriteLine("Đã xóa khách hàng.");
    }
}
