using GTA.Math;
using System.Collections.Generic;

namespace RandomStart.Classes
{
    public class XmlSetings
    {
        public bool Truckin { get; set; }
        public bool Getaway { get; set; }
        public bool Packages { get; set; }
        public bool Convicts { get; set; }
        public bool FUber { get; set; }
        public bool Pilot { get; set; }
        public bool Amulance { get; set; }
        public bool Follow { get; set; }
        public bool LSFD { get; set; }
        public bool Johnny { get; set; }
        public bool Raceist { get; set; }
        public bool BBBomb { get; set; }
        public bool Assassination { get; set; }
        public bool Gruppe6 { get; set; }
        public bool Sailor { get; set; }
        public bool ImportantEx { get; set; }
        public bool DebtCollect { get; set; }
        public bool MCBusiness { get; set; }
        public bool BayLift { get; set; }
        public bool Sharks { get; set; }
        public bool HappyShopper { get; set; }
        public bool MoresMute { get; set; }
        public bool TempJob { get; set; }
        public bool ParaDisplay { get; set; }
        public bool Deliverwho { get; set; }

        public bool ShowRoute { get; set; }
        public bool EnemyStrength { get; set; }
        public bool FastTraveltoStart { get; set; }
        public bool Subtitles { get; set; }
        public bool PhoneCone { get; set; }
        public bool PhoneAudio { get; set; }
        public bool BulderOnly { get; set; }
        public int YachtPrice { get; set; }
        public bool PhoneAnim { set; get; }
        public bool PreLoadOnline { set; get; }
        public bool MenyooAppFixer { set; get; }
        public bool StartOnYAcht { set; get; }
        public int LangSupport { set; get; }

        public int LowerAim { get; set; }
        public int UpperAim { get; set; }

        public int AssZone01 { get; set; }
        public int AssZone02 { get; set; }
        public int AssZone03 { get; set; }
        public int AssZone04 { get; set; }
        public int AssZone05 { get; set; }
        public int AssZone06 { get; set; }
        public int AssZone07 { get; set; }

        public int ModVersion { get; set; }
        public int SPDelayTime { get; set; }
        public int WhyNotSubscribe { get; set; }

        public List<Vector3> PhoneBlock { get; set; }

        public XmlSetings()
        {
            PhoneBlock = new List<Vector3>();
        }
    }
}
