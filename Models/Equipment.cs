using APBD_TASK2.Enum;

namespace APBD_TASK2.Models
{
    public abstract class Equipment
    {
        private static int _nextId = 1;

        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EquipmentStatus Status { get; set; }
        public DateTime AddedDate { get; set; }

        protected Equipment(string name, string description = "")
        {
            Id = _nextId++;
            Name = name;
            Description = description;
            Status = EquipmentStatus.Available;
            AddedDate = DateTime.Now;
        }

        public virtual string GetDescription()
        {
            return $"[{Id}] {Name} | {Description} | Status: {Status} | Added: {AddedDate:dd/MM/yyyy}";
        }
    }
}