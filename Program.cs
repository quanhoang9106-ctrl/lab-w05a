
/****************/
// Mã sinh viên: 202418971
// Họ tên: Hoàng Văn Quân
/****************/

using System;

public class Program
{
    public static void Main()
    {
        int currentYear = DateTime.Now.Year;

        // =====================================
        // PHAN 1: TAO CAC DOI TUONG COMPUTER
        // =====================================

        Computer computer1 = new Computer(
            "C01",
            "Dell Precision",
            currentYear - 6,
            20000000m,
            DeviceStatus.Active,
            16,
            "Intel Core i7",
            true
        );

        Computer computer2 = new Computer(
            "C02",
            "Dell OptiPlex",
            currentYear - 2,
            12000000m,
            DeviceStatus.Active,
            8,
            "Intel Core i5",
            false
        );

        Console.WriteLine("===== COMPUTER =====");

        Console.WriteLine(computer1);
        Console.WriteLine(
            $"Bao tri: {computer1.CalculateAnnualMaintenanceCost():N0} VND");

        Console.WriteLine(computer2);
        Console.WriteLine(
            $"Bao tri: {computer2.CalculateAnnualMaintenanceCost():N0} VND");


        // =====================================
        // PHAN 2: TAO CAC DOI TUONG PRINTER
        // =====================================

        Printer printer1 = new Printer(
            "P01",
            "HP LaserJet",
            currentYear - 2,
            8000000m,
            DeviceStatus.Active,
            PrinterType.Laser,
            50000,
            false
        );

        Printer printer2 = new Printer(
            "P02",
            "Canon Color",
            currentYear - 3,
            8000000m,
            DeviceStatus.Active,
            PrinterType.Inkjet,
            120000,
            true
        );

        Console.WriteLine();
        Console.WriteLine("===== PRINTER =====");

        Console.WriteLine(printer1);
        Console.WriteLine(
            $"Bao tri: {printer1.CalculateAnnualMaintenanceCost():N0} VND");

        Console.WriteLine(printer2);
        Console.WriteLine(
            $"Bao tri: {printer2.CalculateAnnualMaintenanceCost():N0} VND");


        // =====================================
        // PHAN 3: TAO DOI TUONG PROJECTOR
        // =====================================

        Projector projector1 = new Projector(
            "PJ01",
            "Epson EB-X06",
            currentYear - 3,
            15000000m,
            DeviceStatus.Active,
            3600,
            3500
        );

        Console.WriteLine();
        Console.WriteLine("===== PROJECTOR =====");

        Console.WriteLine(projector1);
        Console.WriteLine(
            $"Bao tri: {projector1.CalculateAnnualMaintenanceCost():N0} VND");


        // =====================================
        // PHAN 4: KIEM THU DA HINH
        // =====================================

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU DA HINH =====");

        Device[] devices =
        {
            computer1,
            computer2,
            printer1,
            printer2,
            projector1
        };

        decimal totalCost = 0;

        foreach (Device device in devices)
        {
            decimal cost =
                device.CalculateAnnualMaintenanceCost();

            Console.WriteLine(
                $"Ma: {device.Id} | Bao tri: {cost:N0} VND");

            totalCost += cost;
        }

        Console.WriteLine(
            $"Tong chi phi bao tri: {totalCost:N0} VND");


        // =====================================
        // PHAN 5: KIEM THU SO TRANG MAY IN
        // =====================================

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU SO TRANG =====");

        long[] pageCounts = { 99999, 100000, 100001 };

        foreach (long pages in pageCounts)
        {
            Printer printer = new Printer(
                "TEST-P-" + pages,
                "May in kiem thu",
                currentYear,
                8000000m,
                DeviceStatus.Active,
                PrinterType.Laser,
                pages,
                true
            );

            decimal cost =
                printer.CalculateAnnualMaintenanceCost();

            Console.WriteLine(
                $"So trang: {pages:N0} | Bao tri: {cost:N0} VND");
        }


        // =====================================
        // PHAN 6: KIEM THU GIO BONG DEN
        // =====================================

        Console.WriteLine();
        Console.WriteLine("===== KIEM THU GIO BONG DEN =====");

        int[] bulbHoursCases = { 2999, 3000, 3001 };

        foreach (int hours in bulbHoursCases)
        {
            Projector projector = new Projector(
                "TEST-PJ-" + hours,
                "May chieu kiem thu",
                currentYear,
                15000000m,
                DeviceStatus.Active,
                3200,
                hours
            );

            decimal cost =
                projector.CalculateAnnualMaintenanceCost();

            Console.WriteLine(
                $"So gio: {hours:N0} | Bao tri: {cost:N0} VND");
        }

        Console.WriteLine();
        Console.WriteLine("===== KET THUC KIEM THU =====");
    }
}
