using APBD_TASK2.Models;

namespace APBD_TASK2.Services
{
    public class ReportService
    {
        private readonly RentalService _rentalService;

        public ReportService(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public void GenerateSummaryReport()
        {
            Console.WriteLine("\n========= SUMMARY REPORT =========");
            _rentalService.ListAllEquipment();
            _rentalService.GetOverdueRentals();
            Console.WriteLine("===================================\n");
        }
    }
}