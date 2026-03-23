using APBD_TASK2.Enum;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services
{
    public class RentalService
    {
        private readonly List<Equipment> _equipments = new List<Equipment>();
        private readonly List<User> _users = new List<User>();
        private readonly List<Rental> _rentals = new List<Rental>();

        private const int StudentRentalLimit = 2;
        private const int EmployeeRentalLimit = 5;
        private const decimal PenaltyPerDay = 5m;

        // Add user
        public void AddUser(User user)
        {
            _users.Add(user);
            Console.WriteLine($"User added: {user.GetFullName()}");
        }

        // Add equipment
        public void AddEquipment(Equipment equipment)
        {
            _equipments.Add(equipment);
            Console.WriteLine($"Equipment added: {equipment.GetDescription()}");
        }

        // List all equipment
        public void ListAllEquipment()
        {
            Console.WriteLine("\n--- All Equipment ---");
            foreach (var e in _equipments)
                Console.WriteLine(e.GetDescription());
        }

        // List available equipment
        public void ListAvailableEquipment()
        {
            Console.WriteLine("\n--- Available Equipment ---");
            foreach (var e in _equipments.Where(e => e.Status == EquipmentStatus.Available))
                Console.WriteLine(e.GetDescription());
        }

        // Rent equipment
        public void RentEquipment(int userId, int equipmentId, int days)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            var equipment = _equipments.FirstOrDefault(e => e.Id == equipmentId);

            if (user == null) { Console.WriteLine("User not found."); return; }
            if (equipment == null) { Console.WriteLine("Equipment not found."); return; }
            if (equipment.Status != EquipmentStatus.Available) 
            { Console.WriteLine($"Equipment '{equipment.Name}' is not available."); return; }

            int activeRentals = _rentals.Count(r => r.UserId == user.Id && !r.IsReturned);
            int limit = user.UserType == UserType.Student ? StudentRentalLimit : EmployeeRentalLimit;

            if (activeRentals >= limit)
            { Console.WriteLine($"Rental denied. {user.GetFullName()} has reached the limit of {limit} active rentals."); return; }

            var rental = new Rental(user.Id, equipment.Id, days);
            _rentals.Add(rental);
            equipment.Status = EquipmentStatus.Rented;
            Console.WriteLine($"Rented: {equipment.Name} to {user.GetFullName()} for {days} days. Due: {rental.DueDate:dd/MM/yyyy}");
        }

        // Return equipment
        public void ReturnEquipment(int rentalId, DateTime returnDate)
        {
            var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);
            var equipment = _equipments.FirstOrDefault(e => e.Id == rental?.EquipmentId);

            if (rental == null) { Console.WriteLine("Rental not found."); return; }
            if (rental.IsReturned) { Console.WriteLine("Already returned."); return; }

            rental.ReturnDate = returnDate;
            rental.IsReturned = true;
            equipment!.Status = EquipmentStatus.Available;

            if (returnDate > rental.DueDate)
            {
                int lateDays = (returnDate - rental.DueDate).Days;
                rental.Penalty = lateDays * PenaltyPerDay;
                Console.WriteLine($"Returned late by {lateDays} days. Penalty: {rental.Penalty} PLN");
            }
            else
            {
                Console.WriteLine($"Returned on time. No penalty.");
            }
        }

        // Mark equipment unavailable
        public void MarkUnavailable(int equipmentId)
        {
            var equipment = _equipments.FirstOrDefault(e => e.Id == equipmentId);
            if (equipment == null) { Console.WriteLine("Equipment not found."); return; }
            equipment.Status = EquipmentStatus.Unavailable;
            Console.WriteLine($"{equipment.Name} marked as unavailable.");
        }

        // Active rentals for user
        public void GetActiveRentalsForUser(int userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null) { Console.WriteLine("User not found."); return; }

            Console.WriteLine($"\n--- Active Rentals for {user.GetFullName()} ---");
            var rentals = _rentals.Where(r => r.UserId == userId && !r.IsReturned);
            foreach (var r in rentals)
            {
                var eq = _equipments.First(e => e.Id == r.EquipmentId);
                Console.WriteLine($"Rental [{r.Id}] {eq.Name} | Due: {r.DueDate:dd/MM/yyyy}");
            }
        }

        // Overdue rentals
        public void GetOverdueRentals()
        {
            Console.WriteLine("\n--- Overdue Rentals ---");
            var overdue = _rentals.Where(r => r.IsOverdue());
            foreach (var r in overdue)
            {
                var eq = _equipments.First(e => e.Id == r.EquipmentId);
                var user = _users.First(u => u.Id == r.UserId);
                Console.WriteLine($"{eq.Name} rented by {user.GetFullName()} | Due: {r.DueDate:dd/MM/yyyy}");
            }
        }
    }
}