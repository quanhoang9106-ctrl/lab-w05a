
/****************/
// Mã sinh viên: 202418971
// Họ tên: Hoàng Văn Quân
/****************/

using System;

// Lớp Computer kế thừa từ Device.
public class Computer : Device, INetworkable
{
    // Các thuộc tính riêng của máy tính.
    public int RamGB { get; }
    public string Processor { get; }
    public bool HasDedicatedGpu { get; }

    // Hàm khởi tạo máy tính.
    public Computer(
        string id,
        string name,
        int yearInUse,
        decimal purchasePrice,
        DeviceStatus status,
        int ramGB,
        string processor,
        bool hasDedicatedGpu)
        : base(id, name, yearInUse, purchasePrice, status)
    {
        // Kiểm tra dữ liệu.
        if (ramGB <= 0)
        {
            throw new ArgumentException(
                "RAM phải lớn hơn 0.");
        }

        if (string.IsNullOrWhiteSpace(processor))
        {
            throw new ArgumentException(
                "CPU không được rỗng.");
        }

        RamGB = ramGB;
        Processor = processor;
        HasDedicatedGpu = hasDedicatedGpu;
    }

    // Tính chi phí bảo trì hằng năm.
    public override decimal CalculateAnnualMaintenanceCost()
    {
        // Chi phí cơ bản là 5% giá mua.
        decimal cost = PurchasePrice * 0.05m;

        // Có GPU rời thì cộng thêm 2%.
        if (HasDedicatedGpu)
        {
            cost += PurchasePrice * 0.02m;
        }

        // Sử dụng trên 5 năm thì cộng thêm 1%.
        if (YearsInUse > 5)
        {
            cost += PurchasePrice * 0.01m;
        }

        return cost;
    }

    // Hiển thị thông tin máy tính.
    public override string ToString()
    {
        return base.ToString() +
               $" | RAM: {RamGB} GB" +
               $" | CPU: {Processor}" +
               $" | GPU rời: {(HasDedicatedGpu ? "Có" : "Không")}";
    }
    
// Dia chi IP dang su dung
public string IpAddress { get; private set; } = string.Empty;

// Kiem tra trang thai ket noi
public bool IsConnected =>
    !string.IsNullOrEmpty(IpAddress);

// Ket noi mang
public void Connect(string ipAddress)
{
    if (string.IsNullOrWhiteSpace(ipAddress))
    {
        throw new ArgumentException(
            "Dia chi IP khong duoc rong.");
    }

    if (IsConnected)
    {
        throw new InvalidOperationException(
            "Thiet bi da ket noi mang.");
    }

    IpAddress = ipAddress.Trim();
}

// Ngat ket noi mang
public void Disconnect()
{
    IpAddress = string.Empty;
}

}
