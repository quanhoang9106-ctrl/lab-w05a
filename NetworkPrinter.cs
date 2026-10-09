
/****************/
// Mã sinh viên: 202418971
// Họ tên: Hoàng Văn Quân
/****************/

using System;

public class NetworkPrinter : Printer, INetworkable
{
    // May in nay ho tro ket noi mang
    public override bool SupportsNetwork => true;

    public string IpAddress { get; private set; } = string.Empty;

    public bool IsConnected =>
        !string.IsNullOrEmpty(IpAddress);

    // Constructor
    public NetworkPrinter(
        string id,
        string name,
        int yearInUse,
        decimal purchasePrice,
        DeviceStatus status,
        PrinterType type,
        long printedPages,
        bool isColor)
        : base(
            id,
            name,
            yearInUse,
            purchasePrice,
            status,
            type,
            printedPages,
            isColor)
    {
    }

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
                "May in da ket noi mang.");
        }

        IpAddress = ipAddress.Trim();
    }

    // Ngat ket noi mang
    public void Disconnect()
    {
        IpAddress = string.Empty;
    }
}
