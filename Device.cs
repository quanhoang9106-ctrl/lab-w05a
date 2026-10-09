
/****************/
// Mã sinh viên: 202418971
// Họ tên: Hoàng Văn Quân
/****************/

using System;

// Lớp trừu tượng biểu diễn thông tin chung của thiết bị.
public abstract class Device
{
    // Các thuộc tính chung.
    public string Id { get; }
    public string Name { get; }
    public int YearInUse { get; }
    public decimal PurchasePrice { get; }
    public DeviceStatus Status { get; set; }

    // Tính số năm sử dụng dựa trên năm hiện tại.
    public int YearsInUse => DateTime.Now.Year - YearInUse;

    // Hàm khởi tạo đối tượng thiết bị.
    protected Device(
        string id,
        string name,
        int yearInUse,
        decimal purchasePrice,
        DeviceStatus status)
    {
        // Kiểm tra mã thiết bị.
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException(
                "Mã thiết bị không được rỗng.");
        }

        // Kiểm tra tên thiết bị.
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Tên thiết bị không được rỗng.");
        }

        // Kiểm tra năm đưa vào sử dụng.
        if (yearInUse < 1 || yearInUse > DateTime.Now.Year)
        {
            throw new ArgumentException(
                "Năm sử dụng không hợp lệ.");
        }

        // Kiểm tra giá mua.
        if (purchasePrice <= 0)
        {
            throw new ArgumentException(
                "Giá mua phải lớn hơn 0.");
        }

        // Gán giá trị cho các thuộc tính.
        Id = id.Trim();
        Name = name.Trim();
        YearInUse = yearInUse;
        PurchasePrice = purchasePrice;
        Status = status;
    }

    // Lớp con phải cài đặt phương thức tính chi phí bảo trì.
    public abstract decimal CalculateAnnualMaintenanceCost();

    // Biểu diễn thông tin thiết bị dưới dạng chuỗi.
    public override string ToString()
    {
        return $"Mã: {Id} | Tên: {Name} | " +
               $"Năm sử dụng: {YearInUse} | " +
               $"Giá mua: {PurchasePrice:N0} VNĐ | " +
               $"Trạng thái: {Status}";
    }
}
