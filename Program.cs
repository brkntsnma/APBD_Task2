using APBD_TASK2.Enum;
using APBD_TASK2.Models;
using APBD_TASK2.Services;

var rentalService = new RentalService();
var reportService = new ReportService(rentalService);

Console.WriteLine("=== University Equipment Rental System ===\n");

rentalService.AddEquipment(new Laptop("Dell XPS 15", "Windows 11", 16));
rentalService.AddEquipment(new Laptop("MacBook Pro", "macOS", 32));
rentalService.AddEquipment(new Projector("Epson EB-X51", 3600, true));
rentalService.AddEquipment(new Camera("Canon EOS R50", 24, true));

rentalService.AddUser(new User("Yusuf", "Taşkın", UserType.Student));
rentalService.AddUser(new User("Mehmet", "Demir", UserType.Employee));
rentalService.AddUser(new User("Ayşe", "Kaya", UserType.Student));

rentalService.ListAllEquipment();
rentalService.ListAvailableEquipment();

rentalService.RentEquipment(1, 1, 7);
rentalService.RentEquipment(2, 3, 14);

rentalService.RentEquipment(3, 1, 5);

rentalService.MarkUnavailable(4);
rentalService.RentEquipment(1, 4, 3);

rentalService.ReturnEquipment(1, DateTime.Now);
rentalService.ReturnEquipment(2, DateTime.Now.AddDays(20));

rentalService.GetActiveRentalsForUser(1);
rentalService.GetOverdueRentals();

reportService.GenerateSummaryReport();

Console.WriteLine("\nDemo completed.");