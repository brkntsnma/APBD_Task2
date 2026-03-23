namespace APBD_TASK2.Models
{
    public class Camera : Equipment
    {
        public int MegaPixels { get; set; }
        public bool HasVideoMode { get; set; }

        public Camera(string name, int megaPixels, bool hasVideoMode, string description = "") 
            : base(name, description)
        {
            MegaPixels = megaPixels;
            HasVideoMode = hasVideoMode;
        }

        public override string GetDescription()
        {
            return $"[{Id}] Camera: {Name} | MP: {MegaPixels} | Video: {HasVideoMode} | Status: {Status}";
        }
    }
}