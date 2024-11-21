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
            Console.WriteLine("\n=== QUẢN LÝ CHI TIẾT ĐƠN HÀNG ===");
            Console.WriteLine("1. Thêm mới chi tiết đơn hàng");
            Console.WriteLine("2. Hiển thị tất cả chi tiết đơn hàng");
            Console.WriteLine("3. Cập nhật chi tiết đơn hàng");
            Console.WriteLine("4. Xóa chi tiết đơn hàng");
            Console.WriteLine("5. Thoát");
            Console.Write("Chọn chức năng: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ThemChiTietDonHang(db);
                    break;
                case 2:
                    HienThiChiTietDonHang(db);
                    break;
                case 3:
                    CapNhatChiTietDonHang(db);
                    break;
                case 4:
                    XoaChiTietDonHang(db);
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

    static void ThemChiTietDonHang(AppDbContext db)
    {
        Console.Write("Nhập mã đơn hàng: ");
        int maDonHang = int.Parse(Console.ReadLine());

        Console.Write("Nhập mã cá (NVARCHAR 10): ");
        string maCa = Console.ReadLine();

        Console.Write("Nhập số lượng: ");
        int soLuong = int.Parse(Console.ReadLine());

        Console.Write("Nhập mã giá: ");
        int maGia = int.Parse(Console.ReadLine());

        var chiTietMoi = new ChiTietDonHang
        {
            MaDonHang = maDonHang,
            MaCa = maCa,
            SoLuong = soLuong,
            MaGia = maGia
        };

        db.ChiTietDonHangs.Add(chiTietMoi);
        db.SaveChanges();
        Console.WriteLine("Đã thêm chi tiết đơn hàng mới.");
    }

    static void HienThiChiTietDonHang(AppDbContext db)
    {
        var danhSach = db.ChiTietDonHangs.ToList();

        Console.WriteLine("\nDANH SÁCH CHI TIẾT ĐƠN HÀNG:");
        foreach (var ct in danhSach)
        {
            Console.WriteLine($"Mã CT: {ct.MaCtDonHang}, Mã ĐH: {ct.MaDonHang}, Mã Cá: {ct.MaCa}, Số Lượng: {ct.SoLuong}, Mã Giá: {ct.MaGia}");
        }
    }

    static void CapNhatChiTietDonHang(AppDbContext db)
    {
        Console.Write("Nhập mã chi tiết đơn hàng cần cập nhật: ");
        int maCtDonHang = int.Parse(Console.ReadLine());

        var chiTiet = db.ChiTietDonHangs.FirstOrDefault(ct => ct.MaCtDonHang == maCtDonHang);
        if (chiTiet == null)
        {
            Console.WriteLine("Không tìm thấy chi tiết đơn hàng.");
            return;
        }

        Console.Write("Nhập số lượng mới: ");
        chiTiet.SoLuong = int.Parse(Console.ReadLine());

        db.SaveChanges();
        Console.WriteLine("Đã cập nhật chi tiết đơn hàng.");
    }

    static void XoaChiTietDonHang(AppDbContext db)
    {
        Console.Write("Nhập mã chi tiết đơn hàng cần xóa: ");
        int maCtDonHang = int.Parse(Console.ReadLine());

        var chiTiet = db.ChiTietDonHangs.FirstOrDefault(ct => ct.MaCtDonHang == maCtDonHang);
        if (chiTiet == null)
        {
            Console.WriteLine("Không tìm thấy chi tiết đơn hàng.");
            return;
        }

        db.ChiTietDonHangs.Remove(chiTiet);
        db.SaveChanges();
        Console.WriteLine("Đã xóa chi tiết đơn hàng.");
    }
}
