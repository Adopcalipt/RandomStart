using System.Collections.Generic;

namespace RandomStart.Classes
{
    public class WeaponsXML
    {
        public List<string> WeaponsList { get; set; }
        public List<string> AttachmentsList { get; set; }

        public WeaponsXML()
        {
            WeaponsList = new List<string>();
            AttachmentsList = new List<string>();
        }
    }
}
