
/****************/
// Mã sinh viên: 202418971
// Họ tên: Hoàng Văn Quân
/****************/

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        int currentYear = DateTime.Now.Year;

        // ===================================
        // PHAN 1: TAO THIET BI
        // ===================================

        Computer computer1 = new Computer(
            "C01", "Dell Precision",
            currentYear - 6, 20000000m,
            DeviceStatus.Active,
            16, "Intel Core i7", true
        );

        Computer computer2 = new Computer(
            "C02", "Dell OptiPlex",
            currentYear - 2, 12000000m,
            DeviceStatus.Active,
            8, "Intel Core i5", false
        );

        Printer printer1 = new Printer(
            "P01", "HP LaserJet",
            currentYear - 2, 8000000m,
            DeviceStatus.Active,
            PrinterType.Laser, 50000, false
        );

        Printer printer2 = new Printer(
            "P02", "Canon Color",
            currentYear - 3, 8000000m,
            DeviceStatus.Active,
            PrinterType.Inkjet, 120000, true
        );

        Projector projector1 = new Projector(
            "PJ01", "Epson EB-X06",
            currentYear - 3, 15000000m,
            DeviceStatus.Active,
            3600, 3500
        );

        NetworkPrinter networkPrinter = new NetworkPrinter(
            "NP01", "Brother WiFi",
            currentYear - 1, 9000000m,
            DeviceStatus.Active,
            PrinterType.Laser, 20000, false
        );

        // ===================================
        // PHAN 2: KIEM THU DA HINH
        // ===================================

        Console.WriteLine("===== KIEM THU DA HINH =====");

        Device[] devices =
        {
            computer1, computer2,
            printer1, printer2, projector1
        };

        decimal totalCost = 0;

        foreach (Device device in devices)
        {
            Console.WriteLine(device);

            decimal cost =
                device.CalculateAnnualMaintenanceCost();

            Console.WriteLine($"Bao tri: {cost:N0} VND");

            totalCost += cost;
        }

        Console.WriteLine(
            $"Tong bao tri 5 thiet bi: {totalCost:N0} VND");

        // ===================================
        // PHAN 3: KIEM THU MAY IN
        // ===================================

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU SO TRANG =====");

        long[] pageCounts = { 99999, 100000, 100001 };

        foreach (long pages in pageCounts)
        {
            Printer p = new Printer(
                "TEST-P-" + pages,
                "May in kiem thu",
                currentYear, 8000000m,
                DeviceStatus.Active,
                PrinterType.Laser, pages, true
            );

            Console.WriteLine(
                $"So trang: {pages:N0}" +
                $" | Bao tri: {p.CalculateAnnualMaintenanceCost():N0} VND");
        }

        // ===================================
        // PHAN 4: KIEM THU MAY CHIEU
        // ===================================

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU GIO BONG DEN =====");

        int[] hourCases = { 2999, 3000, 3001 };

        foreach (int hours in hourCases)
        {
            Projector p = new Projector(
                "TEST-PJ-" + hours,
                "May chieu kiem thu",
                currentYear, 15000000m,
                DeviceStatus.Active,
                3200, hours
            );

            Console.WriteLine(
                $"So gio: {hours:N0}" +
                $" | Bao tri: {p.CalculateAnnualMaintenanceCost():N0} VND");
        }

        // ===================================
        // PHAN 5: KIEM THU INETWORKABLE
        // ===================================

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU KET NOI MANG =====");

        INetworkable[] networkDevices =
        {
            computer1, computer2, networkPrinter
        };

        string[] ips =
        {
            "192.168.1.10",
            "192.168.1.11",
            "192.168.1.20"
        };

        for (int i = 0; i < networkDevices.Length; i++)
        {
            networkDevices[i].Connect(ips[i]);

            Console.WriteLine(
                $"{networkDevices[i].GetType().Name}" +
                $" | Ket noi: {networkDevices[i].IsConnected}" +
                $" | IP: {networkDevices[i].IpAddress}");
        }

        // Kiem thu ket noi trung
        try
        {
            computer1.Connect("192.168.1.99");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(
                $"Da chan ket noi trung: {ex.Message}");
        }

        // Kiem thu ngat ket noi
        networkPrinter.Disconnect();

        Console.WriteLine(
            $"Sau ngat ket noi: {networkPrinter.IsConnected}");

        Console.WriteLine(
            $"IP sau khi ngat: '{networkPrinter.IpAddress}'");

        // Kiem thu IP rong
        try
        {
            networkPrinter.Connect("   ");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(
                $"Da chan IP rong: {ex.Message}");
        }

        // ===================================
        // PHAN 6: TAO HAI PHONG THUC HANH
        // ===================================

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU LABROOM =====");

        LabRoom room1 = new LabRoom(
            "R101", "Phong thuc hanh 101", 40);

        LabRoom room2 = new LabRoom(
            "R102", "Phong thuc hanh 102", 30);

        // Them thiet bi phong 1
        room1.AddDevice(computer1);
        room1.AddDevice(printer1);
        room1.AddDevice(projector1);

        // Them thiet bi phong 2
        room2.AddDevice(computer2);
        room2.AddDevice(printer2);
        room2.AddDevice(networkPrinter);

        // Chuyen P02 sang trang thai dang bao tri
        printer2.Status = DeviceStatus.UnderMaintenance;

        // ===================================
        // PHAN 7: HIEN THI THONG TIN PHONG
        // ===================================

        LabRoom[] rooms = { room1, room2 };

        foreach (LabRoom room in rooms)
        {
            Console.WriteLine();
            Console.WriteLine(room);

            Console.WriteLine("Danh sach thiet bi:");

            foreach (Device device in room.Devices)
            {
                Console.WriteLine(
                    $"- {device.Id}: {device.Name}");
            }

            Console.WriteLine(
                $"Tong bao tri: " +
                $"{room.CalculateAnnualMaintenanceCost():N0} VND");

            Console.WriteLine("Thiet bi can bao tri:");

            List<Device> maintenanceDevices =
                room.GetDevicesRequiringMaintenance();

            if (maintenanceDevices.Count == 0)
            {
                Console.WriteLine("Khong co.");
            }

            foreach (Device device in maintenanceDevices)
            {
                Console.WriteLine(
                    $"- {device.Id}: {device.Name}");
            }
        }

        // ===================================
        // PHAN 8: KIEM THU THEM TRUNG MA
        // ===================================

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU TRUNG MA =====");

        // Tao mot doi tuong moi nhung trung ma C01
        Computer duplicateComputer = new Computer(
            "C01", "May tinh khac",
            currentYear - 1, 10000000m,
            DeviceStatus.Active,
            8, "Intel Core i3", false
        );

        try
        {
            room1.AddDevice(duplicateComputer);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(
                $"Da chan trung ma: {ex.Message}");
        }

        // ===================================
        // PHAN 9: KIEM THU THEM NULL
        // ===================================

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU NULL =====");

        try
        {
            room1.AddDevice(null!);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(
                $"Da chan null: {ex.ParamName}");
        }

        // ===================================
        // PHAN 10: TIM KIEM VA XOA
        // ===================================

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU TIM KIEM =====");

        Device? found = room1.FindDevice("PJ01");

        if (found != null)
        {
            Console.WriteLine(
                $"Tim thay: {found.Id} - {found.Name}");
        }
        else
        {
            Console.WriteLine("Khong tim thay.");
        }

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU XOA =====");

        bool removed = room1.RemoveDevice("PJ01");

        Console.WriteLine(
            $"Xoa PJ01 thanh cong: {removed}");

        bool notFound = room1.FindDevice("PJ01") == null;

        Console.WriteLine(
            $"Khong con PJ01 trong phong: {notFound}");

        // Them lai thiet bi sau khi thu xoa
        room1.AddDevice(projector1);

        Console.WriteLine(
            $"Tong R101 sau khi them lai: " +
            $"{room1.CalculateAnnualMaintenanceCost():N0} VND");

        Console.WriteLine();
        Console.WriteLine("===== KET THUC KIEM THU =====");
    }
}
