
/****************/
// Mã sinh viên: 202418971
// Họ tên: Hoàng Văn Quân
/****************/

using System;

// Lớp Printer kế thừa từ Device.
public class Printer : Device
{
    // Các thuộc tính riêng của máy in.
    public PrinterType Type { get; }

    public long PrintedPages { get; }

    public bool IsColor { get; }

    // Máy in thông thường không hỗ trợ mạng.
    // Lớp NetworkPrinter sẽ ghi đè thuộc tính này.
    public virtual bool SupportsNetwork => false;

    // Constructor khởi tạo máy in.
    public Printer(
        string id,
        string name,
        int yearInUse,
        decimal purchasePrice,
        DeviceStatus status,
        PrinterType type,
        long printedPages,
        bool isColor)
        : base(id, name, yearInUse, purchasePrice, status)
    {
        // Kiểm tra loại máy in.
        if (!Enum.IsDefined(typeof(PrinterType), type))
        {
            throw new ArgumentException(
                "Loại máy in không hợp lệ.");
        }

        // Kiểm tra số trang đã in.
        if (printedPages < 0)
        {
            throw new ArgumentException(
                "Số trang đã in không được âm.");
        }

        // Gán giá trị cho các thuộc tính riêng.
        Type = type;
        PrintedPages = printedPages;
        IsColor = isColor;
    }

    // Ghi đè phương thức tính chi phí bảo trì.
    public override decimal CalculateAnnualMaintenanceCost()
    {
        // Chi phí cơ bản bằng 4% giá mua.
        decimal cost = PurchasePrice * 0.04m;

        // Đã in trên 100000 trang.
        if (PrintedPages > 100000)
        {
            cost += 500000m;
        }

        // Máy in màu.
        if (IsColor)
        {
            cost += 300000m;
        }

        return cost;
    }

    // Hiển thị thông tin máy in.
    public override string ToString()
    {
        return base.ToString() +
               $" | Loại: {Type}" +
               $" | Số trang: {PrintedPages:N0}" +
               $" | In màu: {(IsColor ? "Có" : "Không")}" +
               $" | Hỗ trợ mạng: {(SupportsNetwork ? "Có" : "Không")}";
    }
}
