namespace APBD_TASK2.Models
{
    public class Projector : Equipment
    {
        public int Lumens { get; set; }
        public bool IsPortable { get; set; }

        public Projector(string name, int lumens, bool isPortable, string description = "") 
            : base(name, description)
        {
            Lumens = lumens;
            IsPortable = isPortable;
        }

        public override string GetDescription()
        {
            return $"[{Id}] Projector: {Name} | Lumens: {Lumens} | Portable: {IsPortable} | Status: {Status}";
        }
    }
}