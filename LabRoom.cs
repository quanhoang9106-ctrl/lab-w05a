
/****************/
// Mã sinh viên: 202418971
// Họ tên: Hoàng Văn Quân
/****************/

using System;
using System.Collections.Generic;

public class LabRoom
{
    // 1. Thong tin phong
    public string Id { get; }
    public string Name { get; }
    public int Capacity { get; }

    // 2. Danh sach thiet bi
    private readonly List<Device> _devices = new List<Device>();

    public IReadOnlyList<Device> Devices => _devices.AsReadOnly();

    // 3. Constructor
    public LabRoom(string id, string name, int capacity)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException(
                "Ma phong khong duoc rong.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Ten phong khong duoc rong.");
        }

        if (capacity <= 0)
        {
            throw new ArgumentException(
                "Suc chua phai lon hon 0.");
        }

        Id = id.Trim();
        Name = name.Trim();
        Capacity = capacity;
    }

    // 4. Them thiet bi vao phong
    public void AddDevice(Device device)
    {
        if (device == null)
        {
            throw new ArgumentNullException(nameof(device));
        }

        if (FindDevice(device.Id) != null)
        {
            throw new InvalidOperationException(
                "Ma thiet bi da ton tai trong phong.");
        }

        _devices.Add(device);
    }

    // 5. Tim thiet bi theo ma
    public Device? FindDevice(string deviceId)
    {
        if (string.IsNullOrWhiteSpace(deviceId))
        {
            return null;
        }

        foreach (Device device in _devices)
        {
            if (string.Equals(
                device.Id,
                deviceId.Trim(),
                StringComparison.OrdinalIgnoreCase))
            {
                return device;
            }
        }

        return null;
    }

    // 6. Xoa thiet bi theo ma
    public bool RemoveDevice(string deviceId)
    {
        Device? device = FindDevice(deviceId);

        if (device == null)
        {
            return false;
        }

        return _devices.Remove(device);
    }

    // 7. Tinh tong chi phi bao tri
    public decimal CalculateAnnualMaintenanceCost()
    {
        decimal total = 0;

        foreach (Device device in _devices)
        {
            total += device.CalculateAnnualMaintenanceCost();
        }

        return total;
    }

    // 8. Tim cac thiet bi can bao tri
    public List<Device> GetDevicesRequiringMaintenance()
    {
        List<Device> result = new List<Device>();

        foreach (Device device in _devices)
        {
            if (device.Status == DeviceStatus.UnderMaintenance
                || device.YearsInUse > 5)
            {
                result.Add(device);
            }
        }

        return result;
    }

    // 9. Hien thi thong tin phong
    public override string ToString()
    {
        return $"Phong: {Id} | Ten: {Name}"
            + $" | Suc chua: {Capacity}"
            + $" | So thiet bi: {_devices.Count}";
    }
}
