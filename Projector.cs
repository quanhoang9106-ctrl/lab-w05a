
/****************/
// Mã sinh viên: 202418971
// Họ tên: Hoàng Văn Quân
/****************/

using System;

// Lop may chieu ke thua tu Device
public class Projector : Device
{
    // Do sang cua may chieu (lumen)
    public int Lumens { get; }

    // So gio bong den da su dung
    public int BulbHours { get; }

    // Constructor
    public Projector(
        string id,
        string name,
        int yearInUse,
        decimal purchasePrice,
        DeviceStatus status,
        int lumens,
        int bulbHours)
        : base(id, name, yearInUse, purchasePrice, status)
    {
        if (lumens <= 0)
        {
            throw new ArgumentException(
                "Do sang phai lon hon 0.");
        }

        if (bulbHours < 0)
        {
            throw new ArgumentException(
                "So gio bong den khong duoc am.");
        }

        Lumens = lumens;
        BulbHours = bulbHours;
    }

    // Tinh chi phi bao tri hang nam
    public override decimal CalculateAnnualMaintenanceCost()
    {
        decimal cost = PurchasePrice * 0.03m;

        if (BulbHours > 3000)
        {
            cost += 1500000m;
        }

        return cost;
    }

    // Hien thi thong tin may chieu
    public override string ToString()
    {
        return base.ToString()
            + $" | Do sang: {Lumens:N0} lumen"
            + $" | Gio bong den: {BulbHours:N0}";
    }
}
