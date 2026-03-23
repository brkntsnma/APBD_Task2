namespace APBD_TASK2.Models
{
    public class Laptop : Equipment
    {
        public string OperatingSystem { get; set; }
        public int RamGb { get; set; }

        public Laptop(string name, string operatingSystem, int ramGb, string description = "") 
            : base(name, description)
        {
            OperatingSystem = operatingSystem;
            RamGb = ramGb;
        }

        public override string GetDescription()
        {
            return $"[{Id}] Laptop: {Name} | OS: {OperatingSystem} | RAM: {RamGb}GB | Status: {Status}";
        }
    }
}