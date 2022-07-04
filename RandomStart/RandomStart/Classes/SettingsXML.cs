using System.Collections.Generic;
using System.Windows.Forms;

namespace RandomStart.Classes
{
    public class SettingsXML
    {
        public Keys MenuKey { get; set; }
        public bool Locate { get; set; }
        public bool Spawn { get; set; }
        public bool Saved { get; set; }
        public bool DisableRecord { get; set; }
        public bool KeepWeapons { get; set; }
        public bool BeltUp { get; set; }
        public bool Reincarn { get; set; }
        public bool ReCritter { get; set; }
        public bool ReSave { get; set; }
        public bool ReCurr { get; set; }
        public bool BeachPart { get; set; }
        public int Version { get; set; }
        public int LangSupport { get; set; }

        public bool BeachPed { get; set; }
        public bool Tramps { get; set; }
        public bool Highclass { get; set; }
        public bool Midclass { get; set; }
        public bool Lowclass { get; set; }
        public bool Business { get; set; }
        public bool Bodybuilder { get; set; }
        public bool GangStars { get; set; }
        public bool Epsilon { get; set; }
        public bool Jogger { get; set; }
        public bool Golfer { get; set; }
        public bool Hiker { get; set; }
        public bool Methaddict { get; set; }
        public bool Rural { get; set; }
        public bool Cyclist { get; set; }
        public bool LGBTWXYZ { get; set; }
        public bool PoolPeds { get; set; }
        public bool Workers { get; set; }
        public bool Jetski { get; set; }
        public bool BikeATV { get; set; }
        public bool Services { get; set; }
        public bool Pilot { get; set; }
        public bool Animals { get; set; }
        public bool Yankton { get; set; }
        public bool Cayo { get; set; }

        public List<int> RandStarts { get; set; }

        public List<WeaponSaver> YourWeaps { get; set; }


        public SettingsXML()
        {
            YourWeaps = new List<WeaponSaver>();
            RandStarts = new List<int>();
        }
    }
}
