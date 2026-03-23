namespace APBD_TASK2.Models
{
    public class Rental
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EquipmentId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal Penalty { get; set; }
        public bool IsReturned { get; set; }

        public Rental(Guid userId, Guid equipmentId, int days)
        {
            Id = Guid.NewGuid();
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