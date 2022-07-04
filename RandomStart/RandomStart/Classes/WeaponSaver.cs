using System.Collections.Generic;

namespace RandomStart.Classes
{
    public class WeaponSaver
    {
        public string PlayWeaps { get; set; }
        public List<string> PlayCompsList { get; set; }
        public int Ammos { get; set; }

        public WeaponSaver()
        {
            PlayCompsList = new List<string>();
        }
    }
}
