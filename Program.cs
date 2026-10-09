
/****************/
// Mã sinh viên: 202418971
// Họ tên: Hoàng Văn Quân
/****************/

using System;

public class Program
{
    public static void Main()
    {
        // Tạo một máy tính để kiểm tra.
        Computer computer1 = new Computer(
            "C01",
            "Dell Precision",
            DateTime.Now.Year - 6,
            20000000m,
            DeviceStatus.Active,
            16,
            "Intel Core i7",
            true
        );

        // Hiển thị thông tin máy tính.
        Console.WriteLine("THONG TIN MAY TINH");
        Console.WriteLine(computer1);

        // Tính và hiển thị chi phí bảo trì.
        decimal cost = computer1.CalculateAnnualMaintenanceCost();

        Console.WriteLine($"Chi phi bao tri: {cost:N0} VND");
    }
}
