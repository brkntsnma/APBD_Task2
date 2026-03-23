namespace APBD_TASK2.Models
{
    public class Rental
    {
        private static int _nextId = 1;

        public int Id { get; set; }
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal Penalty { get; set; }
        public bool IsReturned { get; set; }

        public Rental(int userId, int equipmentId, int days)
        {
            Id = _nextId++;
            UserId = userId;
            EquipmentId = equipmentId;
            RentalDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(days);
            Penalty = 0;
            IsReturned = false;
        }

        public bool IsOverdue()
        {
            return !IsReturned && DateTime.Now > DueDate;
        }
    }
}