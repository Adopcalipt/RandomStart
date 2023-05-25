using GTA;
using GTA.Math;
using GTA.Native;
using RandomStart.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RandomStart
{
    public static class DataStore
    {
        public static int iWait4 { get; set; }
        public static int iUnlock { get; set; }
        public static int iGrouping { get; set; }
        public static int iPostAction { get; set; }
        public static int iActionTime { get; set; }
        public static int iAmModelHash { get; set; }
        public static int iCurrentPed { get; set; }

        public static int GP_Player { get; set; }
        public static int GP_Friend { get; set; }
        public static int GP_Attack { get; set; }

        public static bool bStart { get; set; }

        public static bool UseNSPM { get; set; }
        public static bool OnRestart { get; set; }
        public static bool bDeadorArrest { get; set; }
        public static bool bNagg { get; set; }
        public static bool bFound { get; set; }
        public static bool bLoaded { get; set; }
        public static bool bMenyooZZ { get; set; }
        public static bool bPrisHeli { get; set; }
        public static bool bMethFail { get; set; }
        public static bool bMenuOpen { get; set; }
        public static bool bFallenOff { get; set; }
        public static bool bOpenDoors { get; set; }
        public static bool bInYankton { get; set; }
        public static bool bKeyFinder { get; set; }
        public static bool bMethActor { get; set; }
        public static bool bDontStopMe { get; set; }
        public static bool bAllowControl { get; set; }
        public static bool bLoadUpOnYacht { get; set; }
        public static bool bInCayoPerico { get; set; }
        public static bool bDisableDLCVeh { get; set; }

        public static string sFirstName { get; set; }
        public static string sMainChar { get; set; }
        public static string sFunChar01 { get; set; }
        public static string sFunChar02 { get; set; }

        public static readonly string sVersion = "2.9";
        public static readonly string sHasNSPM = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/";
        public static readonly string sBeeLogs = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RSLog.txt";
        public static readonly string sSaveArts = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Artifacts.txt";
        public static readonly string sCurrentPed = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/CurrentPed.txt";
        public static readonly string sSettings = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RSettings.Xml";
        public static readonly string sWeapsFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/AddonWeaponList.Xml";
        public static readonly string sNamesFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/NamingList.Xml";
        public static readonly string sRandFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RSRNum.Xml";
        public static readonly string sLangedFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/LangOut.Xml";
        public static readonly string sFixSavedFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/SavedPeds.Xml";
        public static readonly string sSavedFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/PedSaver.Xml";
        public static readonly string sOldSavedFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/SavedPedsList.Xml";
        public static readonly string sRandLanguage = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language";

        public static List<string> NSPMAuto = new List<string>
        {
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestMedic.txt",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestFire.txt",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestValey.txt",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestDelivery.txt",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestGroupS.txt",
            "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/RequestSharks.txt"
        };

        public static System.Media.SoundPlayer Ahhhhhh { get; set; }

        public static string sExitAn_01 { get; set; }
        public static string sExitAn_02 { get; set; }

        public static List<string> sWeapList { get; set; }
        public static List<string> sAddsList { get; set; }
        public static List<string> ControlerList { get; set; }
        public static List<string> RsTranslate { get; set; }

        public static List<Vector3> JogON { get; set; }
        public static List<Ped> PeddyList { get; set; }
        public static List<Ped> PedParty { get; set; }
        public static List<Prop> PropList { get; set; }
        public static List<Vector3> PeskyDoors { get; set; }
        public static List<Vehicle> VehList { get; set; }
        public static List<Weather> WetherBe { get; set; }
        public static List<VehicleSeat> Vseats { get; set; }
        public static List<ClothBank> MyPedCollection { get; set; }

        public static Vector3 vPedTarget { get; set; }
        public static Vector3 vPlayerTarget { get; set; }
        public static Vector3 vAreaRest { get; set; }
        public static Vector3 vHell { get; set; }
        public static Vector3 vHeaven { get; set; }

        public static Ped pPilot { get; set; }

        public static Prop TombStone { get; set; }

        public static Vehicle Shoaf { get; set; }
        public static Vehicle RideThis { get; set; }
        public static Vehicle PrisEscape { get; set; }

        public static Weather DeadWeather { get; set; }
        public static double DeadTime { get; set; }

        public static ScriptSettings MenyooTest { get; set; }
        public static NameList MyNames { get; set; } 
        public static SettingsXML MySettingsXML { get; set; }

        public static readonly List<string> LangLocals = new List<string>
            {
                "LangReader",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/English.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Chinese.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/ChineseS.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/French.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/German.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Italian.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Japanese.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Korean.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Mexican.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Polish.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Portuguese.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Russian.Xml",
                "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Spanish.Xml"
            };
        public static readonly List<string> RsEnglish = new List<string>
        {
            "If you didn't download this file from 'gta5-mods.com' then delete it and download the original from 'gta5-mods.com/scripts/random-start-adopcalipt'",     //0
            "Save XML Invalid",      //1
            "We are here today to mourn the loss of ",      //2
            ". He will be missed by his three friends Trevor, Michael and Franklin.",      //3
            ". She will be missed by her three friends Trevor, Michael and Franklin.",      //4
            "You have been sentenced to 150 years hard labor...",      //5
            "Random Start",      //6
            "blank",              //7
            "Set ped options",      //8
            "Hair Colour",      //9
            "Hair Streaks",      //10
            "Eye Colour",      //11
            "Set Face Overlays",      //12
            "Blemishes",      //13
            "Facial Hair",      //14
            "Eyebrows",      //15
            "Ageing",      //16
            "Makeup",      //17
            "Blush",      //18
            "Complexion",      //19
            "Sun Damage",      //20
            "Lipstick",      //21
            "Moles",      //22
            "Chest Hair",      //23
            "Body Blemishes",      //24
            " Opacity",      //25
            " Colour",      //26
            "Set component options",      //27
            "Head",      //28
            "Beard",      //29
            "Hair",      //30
            "Torso",      //31
            "Legs",      //32 
            "Parachute",      //33
            "Shoes",      //34
            "Accessories",      //35
            "Shirts-Tops-Accessories",      //36
            "Armor",      //37
            "Decals",      //38
            "Shirts-Jackets-Tops",      //39
            "Texture",      //40
            "Set prop options",      //41
            "Hats",      //42
            "Glasses",      //43
            "Earrings",      //44
            "Watches",      //45
            "Default Outfit",      //46
            "Reset ped default outfit.",      //47
            "Save Current Ped.",      //48
            "Make a new ped save file.",      //49
            "Saved",      //50
            "Random Location",      //51
            "Set if you would like to load into a random; place, time and weather.",      //52
            "Use Default Ped",      //53
            "Set if you would like to load in as Michael, Franklin or Trevor.",      //54
            "Disable Action Replay",      //55
            "When using a controller action replay can start randomly this disables it.",      //56
            "Use Saved Ped",      //57
            "Set if you would like to load as a saved ped.",      //58
            "Keep Weapons",      //59
            "Use your default weapon loadout.",      //60
            "Change Menu Key",      //61
            "Select menu load key.",      //62
            "Press the key you would like to bind for the menu.",      //63
            "Delete Saved Ped",      //64
            "Deleted",      //65
            "Select a ped type",      //66
            "Beach Ped",      //67
            "Tramps",      //68
            "High class",      //69
            "Mid class",      //70
            "Low class",      //71
            "Business",      //72
            "Body builder",      //73
            "GangStars",      //74
            "Epsilon ",      //75
            "Jogger",      //76
            "Golfer",      //77
            "Hiker",      //78
            "Meth addict",      //79
            "Rural",      //80
            "Cyclist",      //81
            "LGBTWXYZ",      //82
            "Pool Peds",      //83
            "Workers",      //84
            "Jet ski",      //85
            "Bike/ATV",      //86
            "Services",      //87
            "Use 'save ped' option to keep these settings",      //88
            "Can't open while processing action try again in a few seconds.",      //89
            "Key has been selected.",      //90
            "blank",      //91
            "Hold ~INPUT_VEH_EXIT~ to take control",      //92
            "Pilot",      //93
            "Yankton",      //94
            "Cayo Perico",      //95
            "Seatbelt On",      //96
            "Cayo Perico Beach Party",      //97
            "Left/Right choice your save. Select to edit.",      //98
            "Back",      //99
            "Torso",      //100
            "Neck",      //101
            "Right Arm",      //102
            "Left Arm",      //103
            "Right Leg",      //104
            "Left Leg",      //105
            "Head",      //106
            "Hair Style",      //107
            "Remove All Tattoos",      //108
            "Tattoos",      //109
            "Chest",      //110
            "Stomach",      //111
            "New ",      //112
            "blank",      //113
            "Nose Width",      //114
            "Nose Peak Height",      //115
            "Nose Peak Length",      //116
            "Nose Bone High",      //117
            "Nose Peak Lowering",      //118
            "Nose Bone Twist",      //119
            "Eyebrow High",      //120
            "Eyebrow Forward",      //121
            "Cheekbone High",      //122
            "Cheekbone Width",      //123
            "Cheek Width",      //124
            "Eyes Opening",      //125
            "Lips Thickness",      //126
            "Jaw Bone Width",      //127
            "Jaw Bone Back Length",      //128
            "Chimp Bone Lowering",      //129
            "Chimp Bone Length",      //130
            "Chimp Bone Width",      //131
            "Chimp Hole",      //132
            "Neck Thickness",      //133
            "Face Features",      //134
            "Reset Owned Weapon List",      //135
            "Assimilate Ped",      //136
            "Select a nearby ped.",      //137
            "Press ~INPUT_CONTEXT~ to select ped, ~INPUT_SPRINT~ to assimilate, ~INPUT_ENTER~ to exit.",      //138
            "Animals",      //139
            "Reincarnation",      //140
            "An alternative to dying",      //141
            "Include Critters",      //142
            "Return as a saved ped",      //143
            "Return as current ped",      //144
            "TShirt Print",      //145
            "Hair Overlay",      //146
            "Done",      //147
            "Choise a random start type.",      //148
            "Save and edit peds.",      //149
            "Select how you die.",      //150
            "Have beach party peds when on Cayo Perio.",      //151
            "Does Not Actualy Work...Yet.",      //152
            "Capture your current weapon loadout.",      //153
            "Reincarnate as a random animal.",      //154
            "Return as a random saved ped.",      //155
            "Return as you current ped.",      //156
            "Select a saved outfit. Click to add a new outfit.",      //157
            "Change the current outfit.",      //158
            "Change the current hats and glasses.",      //159
            "Change peds hair style.",      //160
            "Change hair colour.",      //161
            "Change hair streaks colour.",      //162
            "Change eye colour and type.",      //163
            "Change ped face overlays.",      //164
            "Add or remove tattoos.",      //165
            "Alter face dimentions",      //166
            "Oufits",      //167
            "Change peds voice",      //168
            "Voice",      //169
            "Save over your currently selected ped",      //170
            "Mini Map",      //171
            "Show/Hide mini map Ui.",      //172
            "blank",      //173
            "blank",      //174
            "blank",      //175
            "blank",      //176
            "blank",      //177
            "blank",      //178
            "blank",      //179
            "blank",      //180
        };
        private static readonly List<string> MultC = new List<string>
        {
            "~r~", // Red
            "~b~", // Blue
            "~g~", // Green
            "~y~", // Yellow
            "~p~", // Purple
            "~o~" // Orange
        };
        public static void LoadUpDataStore()
        {
            bStart = false;

            LoggerLight.LoggersLoad();

            iWait4 = 0;
            iUnlock = 0;
            iGrouping = 0;
            iPostAction = 0;
            iActionTime = 0;
            iAmModelHash = 0;
            iCurrentPed = 0;

            GP_Player = Game.Player.Character.RelationshipGroup;
            GP_Friend = World.AddRelationshipGroup("FriendNPCs");
            GP_Attack = World.AddRelationshipGroup("AttackNPCs");

            sMainChar = "player_zero";
            sFunChar01 = "player_one";
            sFunChar02 = "player_two";

            bDeadorArrest = false;
            bNagg = false;
            bFound = false;
            bLoaded = false;
            bMenyooZZ = false;
            bPrisHeli = false;
            bMethFail = false;
            bMenuOpen = false;
            bFallenOff = false;
            bOpenDoors = false;
            bInYankton = false;
            bKeyFinder = false;
            bMethActor = false;
            bDontStopMe = false;
            bAllowControl = false;
            bInCayoPerico = false;
            bDisableDLCVeh = true;
       
            Ahhhhhh = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/heavenly_choir.wav");
            Ahhhhhh.Load();

            sExitAn_01 = "";
            sExitAn_02 = "";

            bLoadUpOnYacht = false;
            UseNSPM = NSPMComp();

            sWeapList = WeapsList();
            sAddsList = AddonsList();
            ControlerList = ControlList();
            WetherBe = AllWeathers();
            Vseats = SeatList();

            PeddyList = new List<Ped>();
            PedParty = new List<Ped>();
            PropList = new List<Prop>();
            PeskyDoors = new List<Vector3>();
            VehList = new List<Vehicle>();
            MyPedCollection = LoadInBank();
            JogON = new List<Vector3>();
            vPedTarget = Vector3.Zero;
            vPlayerTarget = Vector3.Zero;
            vAreaRest = Vector3.Zero;
            vHell = Vector3.Zero;
            vHeaven = Vector3.Zero;

            pPilot = null;

            Shoaf = null;
            RideThis = null;
            PrisEscape = null;
            DeadWeather = Weather.Clear;
            DeadTime = 0;

            MyNames = GetNames();

            MySettingsXML = LoadSettings(sSettings);

            RsTranslate = FindaLang();
            
            SaveSetMain(MySettingsXML, sSettings);

            LoadUp();

            bStart = true;
            LoggerLight.Loggers("DataStore.bStart == " + bStart);
        }
        public static List<Weather> AllWeathers()
        {
            LoggerLight.Loggers("DataStore.AllWeathers");

            List<Weather> Wetter = new List<Weather> 
            {
                Weather.ExtraSunny,
                Weather.ExtraSunny,
                Weather.ExtraSunny,
                Weather.ExtraSunny,
                Weather.Clear,
                Weather.Clear,
                Weather.Clear,
                Weather.Clouds,
                Weather.Clouds,
                Weather.Smog,
                Weather.Smog,
                Weather.Foggy,
                Weather.Foggy,
                Weather.Overcast,
                Weather.Overcast,
                Weather.Raining,
                Weather.ThunderStorm,
                Weather.Neutral
            };

            return Wetter;
        }
        public static List<VehicleSeat> SeatList()
        {
            LoggerLight.Loggers("DataStore.SeatList");
            List<VehicleSeat> MySeat = new List<VehicleSeat>();

            MySeat.Add(VehicleSeat.LeftFront);
            MySeat.Add(VehicleSeat.RightFront);
            MySeat.Add(VehicleSeat.LeftRear);
            MySeat.Add(VehicleSeat.RightRear);
            MySeat.Add(VehicleSeat.ExtraSeat1);
            MySeat.Add(VehicleSeat.ExtraSeat2);
            MySeat.Add(VehicleSeat.ExtraSeat3);
            MySeat.Add(VehicleSeat.ExtraSeat4);
            MySeat.Add(VehicleSeat.ExtraSeat5);
            MySeat.Add(VehicleSeat.ExtraSeat6);
            MySeat.Add(VehicleSeat.ExtraSeat7);
            MySeat.Add(VehicleSeat.ExtraSeat8);
            MySeat.Add(VehicleSeat.ExtraSeat9);
            MySeat.Add(VehicleSeat.ExtraSeat10);
            MySeat.Add(VehicleSeat.ExtraSeat11);
            MySeat.Add(VehicleSeat.ExtraSeat12);

            return MySeat;
        }
        public static NameList GetNames()
        {
            LoggerLight.Loggers("DataStore.GetNames");

            if (File.Exists(DataStore.sNamesFile))
            {
                return LoadNames(DataStore.sNamesFile);
            }
            else
                return Named();
        }
        public static List<string> AddonsList()
        {
            LoggerLight.Loggers("DataStore.AddonsList");

            List<string> AddAdds = new List<string> 
            {
                "COMPONENT_ADVANCEDRIFLE_CLIP_01",//0xFA8FA10F,
                "COMPONENT_ADVANCEDRIFLE_CLIP_02",//0x8EC1C979,
                "COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE",//0x377CD377,
                "COMPONENT_APPISTOL_CLIP_01",//0x31C4B22A,
                "COMPONENT_APPISTOL_CLIP_02",//0x249A17D5,
                "COMPONENT_APPISTOL_VARMOD_LUXE",//0x9B76C72C,
                "COMPONENT_ASSAULTRIFLE_CLIP_01",//0xBE5EEA16,
                "COMPONENT_ASSAULTRIFLE_CLIP_02",//0xB1214F9B,
                "COMPONENT_ASSAULTRIFLE_CLIP_03",//0xDBF0A53D,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO",//0x911B24AF,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_02",//0x37E5444B,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_03",//0x538B7B97,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_04",//0x25789F72,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_05",//0xC5495F2D,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_06",//0xCF8B73B1,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_07",//0xA9BB2811,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_08",//0xFC674D54,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_09",//0x7C7FCD9B,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_10",//0xA5C38392,
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_IND_01",//0xB9B15DB0,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_01",//0x8610343F,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02",//0xD12ACA6F,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING",//0xA7DD1E58,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ",//0x63E0A098,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY",//0xFB70D853,
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER",//0xEF2C78C1,
                "COMPONENT_ASSAULTRIFLE_VARMOD_LUXE",//0x4EAD7533,
                "COMPONENT_ASSAULTSHOTGUN_CLIP_01",//0x94E81BC7,
                "COMPONENT_ASSAULTSHOTGUN_CLIP_02",//0x86BD7F72,
                "COMPONENT_ASSAULTSMG_CLIP_01",//0x8D1307B0,
                "COMPONENT_ASSAULTSMG_CLIP_02",//0xBB46E417,
                "COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER",//0x278C78AF,
                "COMPONENT_AT_AR_AFGRIP",//0xC164F53,
                "COMPONENT_AT_AR_AFGRIP_02",//0x9D65907A,
                "COMPONENT_AT_AR_BARREL_01",//0x43A49D26,
                "COMPONENT_AT_AR_BARREL_02",//0x5646C26A,
                "COMPONENT_AT_AR_FLSH",//0x7BC4CDDC,
                "COMPONENT_AT_AR_SUPP",//0x837445AA,
                "COMPONENT_AT_AR_SUPP_02",//0xA73D4664,
                "COMPONENT_AT_BP_BARREL_01",//0x659AC11B,
                "COMPONENT_AT_BP_BARREL_02",//0x3BF26DC7,
                "COMPONENT_AT_CR_BARREL_01",//0x833637FF,
                "COMPONENT_AT_CR_BARREL_02",//0x8B3C480B,
                "COMPONENT_AT_MG_BARREL_01",//0xC34EF234,
                "COMPONENT_AT_MG_BARREL_02",//0xB5E2575B,
                "COMPONENT_AT_MRFL_BARREL_01",//0x381B5D89,
                "COMPONENT_AT_MRFL_BARREL_02",//0x68373DDC,
                "COMPONENT_AT_MUZZLE_01",//0xB99402D4,
                "COMPONENT_AT_MUZZLE_02",//0xC867A07B,
                "COMPONENT_AT_MUZZLE_03",//0xDE11CBCF,
                "COMPONENT_AT_MUZZLE_04",//0xEC9068CC,
                "COMPONENT_AT_MUZZLE_05",//0x2E7957A,
                "COMPONENT_AT_MUZZLE_06",//0x347EF8AC,
                "COMPONENT_AT_MUZZLE_07",//0x4DB62ABE,
                "COMPONENT_AT_MUZZLE_08",//0x5F7DCE4D,
                "COMPONENT_AT_MUZZLE_09",//0x6927E1A1,
                "COMPONENT_AT_PI_COMP",//0x21E34793,
                "COMPONENT_AT_PI_COMP_02",//0xAA8283BF,
                "COMPONENT_AT_PI_COMP_03",//0x27077CCB,
                "COMPONENT_AT_PI_FLSH",//0x359B7AAE,
                "COMPONENT_AT_PI_FLSH_02",//0x43FD595B,
                "COMPONENT_AT_PI_FLSH_03",//0x4A4965F3,
                "COMPONENT_AT_PI_RAIL",//0x8ED4BB70,
                "COMPONENT_AT_PI_RAIL_02",//0x47DE9258,
                "COMPONENT_AT_PI_SUPP",//0xC304849A,
                "COMPONENT_AT_PI_SUPP_02",//0x65EA7EBB,
                "COMPONENT_AT_SB_BARREL_01",//0xD9103EE1,
                "COMPONENT_AT_SB_BARREL_02",//0xA564D78B,
                "COMPONENT_AT_SCOPE_LARGE",//0xD2443DDC,
                "COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM",//0x1C221B1A,
                "COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM_MK2",//0x5B1C713C,
                "COMPONENT_AT_SCOPE_LARGE_MK2",//0x82C10383,
                "COMPONENT_AT_SCOPE_MACRO",//0x9D2FBF29,
                "COMPONENT_AT_SCOPE_MACRO_02",//0x3CC6BA57,
                "COMPONENT_AT_SCOPE_MACRO_02_MK2",//0xC7ADD105,
                "COMPONENT_AT_SCOPE_MACRO_02_SMG_MK2",//0xE502AB6B,
                "COMPONENT_AT_SCOPE_MACRO_MK2",//0x49B2945,
                "COMPONENT_AT_SCOPE_MAX",//0xBC54DA77,
                "COMPONENT_AT_SCOPE_MEDIUM",//0xA0D89C42,
                "COMPONENT_AT_SCOPE_MEDIUM_MK2",//0xC66B6542,
                "COMPONENT_AT_SCOPE_NV",//0xB68010B0,
                "COMPONENT_AT_SCOPE_SMALL",//0xAA2C45B4,
                "COMPONENT_AT_SCOPE_SMALL_02",//0x3C00AFED,
                "COMPONENT_AT_SCOPE_SMALL_MK2",//0x3F3C8181,
                "COMPONENT_AT_SCOPE_SMALL_SMG_MK2",//0x3DECC7DA,
                "COMPONENT_AT_SCOPE_THERMAL",//0x2E43DA41,
                "COMPONENT_AT_SC_BARREL_01",//0xE73653A9,
                "COMPONENT_AT_SC_BARREL_02",//0xF97F783B,
                "COMPONENT_AT_SIGHTS",//0x420FD713,
                "COMPONENT_AT_SIGHTS_SMG",//0x9FDB5652,
                "COMPONENT_AT_SR_BARREL_01",//0x909630B7,
                "COMPONENT_AT_SR_BARREL_02",//0x108AB09E,
                "COMPONENT_AT_SR_SUPP",//0xE608B35E,
                "COMPONENT_AT_SR_SUPP_03",//0xAC42DF71,
                "COMPONENT_BULLPUPRIFLE_CLIP_01",//0xC5A12F80,
                "COMPONENT_BULLPUPRIFLE_CLIP_02",//0xB3688B0F,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO",//0xAE4055B7,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_02",//0xB905ED6B,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_03",//0xA6C448E8,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_04",//0x9486246C,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_05",//0x8A390FD2,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_06",//0x2337FC5,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_07",//0xEFFFDB5E,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_08",//0xDDBDB6DA,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_09",//0xCB631225,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_10",//0xA87D541E,
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_IND_01",//0xC5E9AE52,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_01",//0x18929DA,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_02",//0xEFB00628,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_ARMORPIERCING",//0xFAA7F5ED,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_FMJ",//0x43621710,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_INCENDIARY",//0xA99CF95A,
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_TRACER",//0x822060A9,
                "COMPONENT_BULLPUPRIFLE_VARMOD_LOW",//0xA857BC78,
                "COMPONENT_CARBINERIFLE_CLIP_01",//0x9FBE33EC,
                "COMPONENT_CARBINERIFLE_CLIP_02",//0x91109691,
                "COMPONENT_CARBINERIFLE_CLIP_03",//0xBA62E935,
                "COMPONENT_CARBINERIFLE_MK2_CAMO",//0x4BDD6F16,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_02",//0x406A7908,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_03",//0x2F3856A4,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_04",//0xE50C424D,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_05",//0xD37D1F2F,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_06",//0x86268483,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_07",//0xF420E076,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_08",//0xAAE14DF8,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_09",//0x9893A95D,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_10",//0x6B13CD3E,
                "COMPONENT_CARBINERIFLE_MK2_CAMO_IND_01",//0xDA55CD3F,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_01",//0x4C7A391E,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_02",//0x5DD5DBD5,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING",//0x255D5D57,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ",//0x44032F11,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY",//0x3D25C2A7,
                "COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER",//0x1757F566,
                "COMPONENT_CARBINERIFLE_VARMOD_LUXE",//0xD89B9658,
                "COMPONENT_COMBATMG_CLIP_01",//0xE1FFB34A,
                "COMPONENT_COMBATMG_CLIP_02",//0xD6C59CD6,
                "COMPONENT_COMBATMG_MK2_CAMO",//0x4A768CB5,
                "COMPONENT_COMBATMG_MK2_CAMO_02",//0xCCE06BBD,
                "COMPONENT_COMBATMG_MK2_CAMO_03",//0xBE94CF26,
                "COMPONENT_COMBATMG_MK2_CAMO_04",//0x7609BE11,
                "COMPONENT_COMBATMG_MK2_CAMO_05",//0x48AF6351,
                "COMPONENT_COMBATMG_MK2_CAMO_06",//0x9186750A,
                "COMPONENT_COMBATMG_MK2_CAMO_07",//0x84555AA8,
                "COMPONENT_COMBATMG_MK2_CAMO_08",//0x1B4C088B,
                "COMPONENT_COMBATMG_MK2_CAMO_09",//0xE046DFC,
                "COMPONENT_COMBATMG_MK2_CAMO_10",//0x28B536E,
                "COMPONENT_COMBATMG_MK2_CAMO_IND_01",//0xD703C94D,
                "COMPONENT_COMBATMG_MK2_CLIP_01",//0x492B257C,
                "COMPONENT_COMBATMG_MK2_CLIP_02",//0x17DF42E9,
                "COMPONENT_COMBATMG_MK2_CLIP_ARMORPIERCING",//0x29882423,
                "COMPONENT_COMBATMG_MK2_CLIP_FMJ",//0x57EF1CC8,
                "COMPONENT_COMBATMG_MK2_CLIP_INCENDIARY",//0xC326BDBA,
                "COMPONENT_COMBATMG_MK2_CLIP_TRACER",//0xF6649745,
                "COMPONENT_COMBATMG_VARMOD_LOWRIDER",//0x92FECCDD,
                "COMPONENT_COMBATPDW_CLIP_01",//0x4317F19E,
                "COMPONENT_COMBATPDW_CLIP_02",//0x334A5203,
                "COMPONENT_COMBATPDW_CLIP_03",//0x6EB8C8DB,
                "COMPONENT_COMBATPISTOL_CLIP_01",//0x721B079,
                "COMPONENT_COMBATPISTOL_CLIP_02",//0xD67B4F2D,
                "COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER",//0xC6654D72,
                "COMPONENT_COMPACTRIFLE_CLIP_01",//0x513F0A63,
                "COMPONENT_COMPACTRIFLE_CLIP_02",//0x59FF9BF8,
                "COMPONENT_COMPACTRIFLE_CLIP_03",//0xC607740E,
                "COMPONENT_GRENADELAUNCHER_CLIP_01",//0x11AE5C97,
                "COMPONENT_GUSENBERG_CLIP_01",//0x1CE5A6A5,
                "COMPONENT_GUSENBERG_CLIP_02",//0xEAC8C270,
                "COMPONENT_HEAVYPISTOL_CLIP_01",//0xD4A969A,
                "COMPONENT_HEAVYPISTOL_CLIP_02",//0x64F9C62B,
                "COMPONENT_HEAVYPISTOL_VARMOD_LUXE",//0x7A6A7B7B,
                "COMPONENT_HEAVYSHOTGUN_CLIP_01",//0x324F2D5F,
                "COMPONENT_HEAVYSHOTGUN_CLIP_02",//0x971CF6FD,
                "COMPONENT_HEAVYSHOTGUN_CLIP_03",//0x88C7DA53,
                "COMPONENT_HEAVYSNIPER_CLIP_01",//0x476F52F4,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO",//0xF8337D02,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_02",//0xC5BEDD65,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_03",//0xE9712475,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_04",//0x13AA78E7,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_05",//0x26591E50,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_06",//0x302731EC,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_07",//0xAC722A78,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_08",//0xBEA4CEDD,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_09",//0xCD776C82,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_10",//0xABC5ACC7,
                "COMPONENT_HEAVYSNIPER_MK2_CAMO_IND_01",//0x6C32D2EB,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_01",//0xFA1E1A28,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_02",//0x2CD8FF9D,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_ARMORPIERCING",//0xF835D6D4,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_EXPLOSIVE",//0x89EBDAA7,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_FMJ",//0x3BE948F6,
                "COMPONENT_HEAVYSNIPER_MK2_CLIP_INCENDIARY",//0xEC0F617,
                "COMPONENT_KNUCKLE_VARMOD_BALLAS",//0xEED9FD63,
                "COMPONENT_KNUCKLE_VARMOD_BASE",//0xF3462F33,
                "COMPONENT_KNUCKLE_VARMOD_DIAMOND",//0x9761D9DC,
                "COMPONENT_KNUCKLE_VARMOD_DOLLAR",//0x50910C31,
                "COMPONENT_KNUCKLE_VARMOD_HATE",//0x7DECFE30,
                "COMPONENT_KNUCKLE_VARMOD_KING",//0xE28BABEF,
                "COMPONENT_KNUCKLE_VARMOD_LOVE",//0x3F4E8AA6,
                "COMPONENT_KNUCKLE_VARMOD_PIMP",//0xC613F685,
                "COMPONENT_KNUCKLE_VARMOD_PLAYER",//0x8B808BB,
                "COMPONENT_KNUCKLE_VARMOD_VAGOS",//0x7AF3F785,
                "COMPONENT_MACHINEPISTOL_CLIP_01",//0x476E85FF,
                "COMPONENT_MACHINEPISTOL_CLIP_02",//0xB92C6979,
                "COMPONENT_MACHINEPISTOL_CLIP_03",//0xA9E9CAF4,
                "COMPONENT_MARKSMANRIFLE_CLIP_01",//0xD83B4141,
                "COMPONENT_MARKSMANRIFLE_CLIP_02",//0xCCFD2AC5,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO",//0x9094FBA0,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_02",//0x7320F4B2,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_03",//0x60CF500F,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_04",//0xFE668B3F,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_05",//0xF3757559,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_06",//0x193B40E8,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_07",//0x107D2F6C,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_08",//0xC4E91841,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_09",//0x9BB1C5D3,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_10",//0x3B61040B,
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_IND_01",//0xB7A316DA,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_01",//0x94E12DCE,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_02",//0xE6CFD1AA,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_ARMORPIERCING",//0xF46FD079,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_FMJ",//0xE14A9ED3,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_INCENDIARY",//0x6DD7A86E,
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_TRACER",//0xD77A22D2,
                "COMPONENT_MARKSMANRIFLE_VARMOD_LUXE",//0x161E9241,
                "COMPONENT_MG_CLIP_01",//0xF434EF84,
                "COMPONENT_MG_CLIP_02",//0x82158B47,
                "COMPONENT_MG_VARMOD_LOWRIDER",//0xD6DABABE,
                "COMPONENT_MICROSMG_CLIP_01",//0xCB48AEF0,
                "COMPONENT_MICROSMG_CLIP_02",//0x10E6BA2B,
                "COMPONENT_MICROSMG_VARMOD_LUXE",//0x487AAE09,
                "COMPONENT_MINISMG_CLIP_01",//0x84C8B2D3,
                "COMPONENT_MINISMG_CLIP_02",//0x937ED0B7,
                "COMPONENT_PISTOL50_CLIP_01",//0x2297BE19,
                "COMPONENT_PISTOL50_CLIP_02",//0xD9D3AC92,
                "COMPONENT_PISTOL50_VARMOD_LUXE",//0x77B8AB2F,
                "COMPONENT_PISTOL_CLIP_01",//0xFED0FD71,
                "COMPONENT_PISTOL_CLIP_02",//0xED265A1C,
                "COMPONENT_PISTOL_MK2_CAMO",//0x5C6C749C,
                "COMPONENT_PISTOL_MK2_CAMO_02",//0x15F7A390,
                "COMPONENT_PISTOL_MK2_CAMO_02_SLIDE",//0x1A1F1260,
                "COMPONENT_PISTOL_MK2_CAMO_03",//0x968E24DB,
                "COMPONENT_PISTOL_MK2_CAMO_03_SLIDE",//0xE4E00B70,
                "COMPONENT_PISTOL_MK2_CAMO_04",//0x17BFA99,
                "COMPONENT_PISTOL_MK2_CAMO_04_SLIDE",//0x2C298B2B,
                "COMPONENT_PISTOL_MK2_CAMO_05",//0xF2685C72,
                "COMPONENT_PISTOL_MK2_CAMO_05_SLIDE",//0xDFB79725,
                "COMPONENT_PISTOL_MK2_CAMO_06",//0xDD2231E6,
                "COMPONENT_PISTOL_MK2_CAMO_06_SLIDE",//0x6BD7228C,
                "COMPONENT_PISTOL_MK2_CAMO_07",//0xBB43EE76,
                "COMPONENT_PISTOL_MK2_CAMO_07_SLIDE",//0x9DDBCF8C,
                "COMPONENT_PISTOL_MK2_CAMO_08",//0x4D901310,
                "COMPONENT_PISTOL_MK2_CAMO_08_SLIDE",//0xB319A52C,
                "COMPONENT_PISTOL_MK2_CAMO_09",//0x5F31B653,
                "COMPONENT_PISTOL_MK2_CAMO_09_SLIDE",//0xC6836E12,
                "COMPONENT_PISTOL_MK2_CAMO_10",//0x697E19A0,
                "COMPONENT_PISTOL_MK2_CAMO_10_SLIDE",//0x43B1B173,
                "COMPONENT_PISTOL_MK2_CAMO_IND_01",//0x930CB951,
                "COMPONENT_PISTOL_MK2_CAMO_IND_01_SLIDE",//0x4ABDA3FA,
                "COMPONENT_PISTOL_MK2_CAMO_SLIDE",//0xB4FC92B0,
                "COMPONENT_PISTOL_MK2_CLIP_01",//0x94F42D62,
                "COMPONENT_PISTOL_MK2_CLIP_02",//0x5ED6C128,
                "COMPONENT_PISTOL_MK2_CLIP_FMJ",//0x4F37DF2A,
                "COMPONENT_PISTOL_MK2_CLIP_HOLLOWPOINT",//0x85FEA109,
                "COMPONENT_PISTOL_MK2_CLIP_INCENDIARY",//0x2BBD7A3A,
                "COMPONENT_PISTOL_MK2_CLIP_TRACER",//0x25CAAEAF,
                "COMPONENT_PISTOL_VARMOD_LUXE",//0xD7391086,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO",//0xE3BD9E44,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_02",//0x17148F9B,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_03",//0x24D22B16,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_04",//0xF2BEC6F0,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_05",//0x85627D,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_06",//0xDC2919C5,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_07",//0xE184247B,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_08",//0xD8EF9356,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_09",//0xEF29BFCA,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_10",//0x67AEB165,
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_IND_01",//0x46411A1D,
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_01",//0xCD940141,
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_ARMORPIERCING",//0x4E65B425,
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_EXPLOSIVE",//0x3BE4465D,
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_HOLLOWPOINT",//0xE9582927,
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_INCENDIARY",//0x9F8A1BF5,
                "COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER",//0xA2D79DDB,
                "COMPONENT_REVOLVER_CLIP_01",//0xE9867CE3,
                "COMPONENT_REVOLVER_MK2_CAMO",//0xC03FED9F,
                "COMPONENT_REVOLVER_MK2_CAMO_02",//0xB5DE24,
                "COMPONENT_REVOLVER_MK2_CAMO_03",//0xA7FF1B8,
                "COMPONENT_REVOLVER_MK2_CAMO_04",//0xF2E24289,
                "COMPONENT_REVOLVER_MK2_CAMO_05",//0x11317F27,
                "COMPONENT_REVOLVER_MK2_CAMO_06",//0x17C30C42,
                "COMPONENT_REVOLVER_MK2_CAMO_07",//0x257927AE,
                "COMPONENT_REVOLVER_MK2_CAMO_08",//0x37304B1C,
                "COMPONENT_REVOLVER_MK2_CAMO_09",//0x48DAEE71,
                "COMPONENT_REVOLVER_MK2_CAMO_10",//0x20ED9B5B,
                "COMPONENT_REVOLVER_MK2_CAMO_IND_01",//0xD951E867,
                "COMPONENT_REVOLVER_MK2_CLIP_01",//0xBA23D8BE,
                "COMPONENT_REVOLVER_MK2_CLIP_FMJ",//0xDC8BA3F,
                "COMPONENT_REVOLVER_MK2_CLIP_HOLLOWPOINT",//0x10F42E8F,
                "COMPONENT_REVOLVER_MK2_CLIP_INCENDIARY",//0xEFBF25,
                "COMPONENT_REVOLVER_MK2_CLIP_TRACER",//0xC6D8E476,
                "COMPONENT_REVOLVER_VARMOD_BOSS",//0x16EE3040,
                "COMPONENT_REVOLVER_VARMOD_GOON",//0x9493B80D,
                "COMPONENT_SAWNOFFSHOTGUN_VARMOD_LUXE",//0x85A64DF9,
                "COMPONENT_SMG_CLIP_01",//0x26574997,
                "COMPONENT_SMG_CLIP_02",//0x350966FB,
                "COMPONENT_SMG_CLIP_03",//0x79C77076,
                "COMPONENT_SMG_MK2_CAMO",//0xC4979067,
                "COMPONENT_SMG_MK2_CAMO_02",//0x3815A945,
                "COMPONENT_SMG_MK2_CAMO_03",//0x4B4B4FB0,
                "COMPONENT_SMG_MK2_CAMO_04",//0xEC729200,
                "COMPONENT_SMG_MK2_CAMO_05",//0x48F64B22,
                "COMPONENT_SMG_MK2_CAMO_06",//0x35992468,
                "COMPONENT_SMG_MK2_CAMO_07",//0x24B782A5,
                "COMPONENT_SMG_MK2_CAMO_08",//0xA2E67F01,
                "COMPONENT_SMG_MK2_CAMO_09",//0x2218FD68,
                "COMPONENT_SMG_MK2_CAMO_10",//0x45C5C3C5,
                "COMPONENT_SMG_MK2_CAMO_IND_01",//0x399D558F,
                "COMPONENT_SMG_MK2_CLIP_01",//0x4C24806E,
                "COMPONENT_SMG_MK2_CLIP_02",//0xB9835B2E,
                "COMPONENT_SMG_MK2_CLIP_FMJ",//0xB5A715F,
                "COMPONENT_SMG_MK2_CLIP_HOLLOWPOINT",//0x3A1BD6FA,
                "COMPONENT_SMG_MK2_CLIP_INCENDIARY",//0xD99222E5,
                "COMPONENT_SMG_MK2_CLIP_TRACER",//0x7FEA36EC,
                "COMPONENT_SMG_VARMOD_LUXE",//0x27872C90,
                "COMPONENT_SNIPERRIFLE_CLIP_01",//0x9BC64089,
                "COMPONENT_SNIPERRIFLE_VARMOD_LUXE",//0x4032B5E7,
                "COMPONENT_SNSPISTOL_CLIP_01",//0xF8802ED9,
                "COMPONENT_SNSPISTOL_CLIP_02",//0x7B0033B3,
                "COMPONENT_SNSPISTOL_MK2_CAMO",//0xF7BEEDD,
                "COMPONENT_SNSPISTOL_MK2_CAMO_02",//0x8A612EF6,
                "COMPONENT_SNSPISTOL_MK2_CAMO_02_SLIDE",//0x29366D21,
                "COMPONENT_SNSPISTOL_MK2_CAMO_03",//0x76FA8829,
                "COMPONENT_SNSPISTOL_MK2_CAMO_03_SLIDE",//0x3ADE514B,
                "COMPONENT_SNSPISTOL_MK2_CAMO_04",//0xA93C6CAC,
                "COMPONENT_SNSPISTOL_MK2_CAMO_04_SLIDE",//0xE64513E9,
                "COMPONENT_SNSPISTOL_MK2_CAMO_05",//0x9C905354,
                "COMPONENT_SNSPISTOL_MK2_CAMO_05_SLIDE",//0xCD7AEB9A,
                "COMPONENT_SNSPISTOL_MK2_CAMO_06",//0x4DFA3621,
                "COMPONENT_SNSPISTOL_MK2_CAMO_06_SLIDE",//0xFA7B27A6,
                "COMPONENT_SNSPISTOL_MK2_CAMO_07",//0x42E91FFF,
                "COMPONENT_SNSPISTOL_MK2_CAMO_07_SLIDE",//0xE285CA9A,
                "COMPONENT_SNSPISTOL_MK2_CAMO_08",//0x54A8437D,
                "COMPONENT_SNSPISTOL_MK2_CAMO_08_SLIDE",//0x2B904B19,
                "COMPONENT_SNSPISTOL_MK2_CAMO_09",//0x68C2746,
                "COMPONENT_SNSPISTOL_MK2_CAMO_09_SLIDE",//0x22C24F9C,
                "COMPONENT_SNSPISTOL_MK2_CAMO_10",//0x2366E467,
                "COMPONENT_SNSPISTOL_MK2_CAMO_10_SLIDE",//0x8D0D5ECD,
                "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01",//0x441882E6,
                "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01_SLIDE",//0x1F07150A,
                "COMPONENT_SNSPISTOL_MK2_CAMO_SLIDE",//0xE7EE68EA,
                "COMPONENT_SNSPISTOL_MK2_CLIP_01",//0x1466CE6,
                "COMPONENT_SNSPISTOL_MK2_CLIP_02",//0xCE8C0772,
                "COMPONENT_SNSPISTOL_MK2_CLIP_FMJ",//0xC111EB26,
                "COMPONENT_SNSPISTOL_MK2_CLIP_HOLLOWPOINT",//0x8D107402,
                "COMPONENT_SNSPISTOL_MK2_CLIP_INCENDIARY",//0xE6AD5F79,
                "COMPONENT_SNSPISTOL_MK2_CLIP_TRACER",//0x902DA26E,
                "COMPONENT_SNSPISTOL_VARMOD_LOWRIDER",//0x8033ECAF,
                "COMPONENT_SPECIALCARBINE_CLIP_01",//0xC6C7E581,
                "COMPONENT_SPECIALCARBINE_CLIP_02",//0x7C8BD10E,
                "COMPONENT_SPECIALCARBINE_CLIP_03",//0x6B59AEAA,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO",//0xD40BB53B,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_02",//0x431B238B,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_03",//0x34CF86F4,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_04",//0xB4C306DD,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_05",//0xEE677A25,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_06",//0xDF90DC78,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_07",//0xA4C31EE,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_08",//0x89CFB0F7,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_09",//0x7B82145C,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_10",//0x899CAF75,
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_IND_01",//0x5218C819,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_01",//0x16C69281,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_02",//0xDE1FA12C,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_ARMORPIERCING",//0x51351635,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_FMJ",//0x503DEA90,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_INCENDIARY",//0xDE011286,
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_TRACER",//0x8765C68A,
                "COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER",//0x730154F2,
                "COMPONENT_SWITCHBLADE_VARMOD_BASE",//0x9137A500,
                "COMPONENT_SWITCHBLADE_VARMOD_VAR1",//0x5B3E7DB6,
                "COMPONENT_SWITCHBLADE_VARMOD_VAR2",//0xE7939662,
                "COMPONENT_VINTAGEPISTOL_CLIP_01",//0x45A3B6BB,
                "COMPONENT_VINTAGEPISTOL_CLIP_02",//0x33BA12E8

                "COMPONENT_AT_AR_FLSH",//
                "COMPONENT_AT_AR_SUPP",//
                "COMPONENT_MILITARYRIFLE_CLIP_01",//
                "COMPONENT_MILITARYRIFLE_CLIP_02",//
                "COMPONENT_MILITARYRIFLE_SIGHT_01",//
                "COMPONENT_AT_SCOPE_SMALL",//
                "COMPONENT_AT_AR_FLSH",//
                "COMPONENT_AT_AR_SUPP",//

                "COMPONENT_HEAVYRIFLE_CLIP_01",// | 0x5AF49386
                "COMPONENT_HEAVYRIFLE_CLIP_02",//",// | 0x6CBF371B
                "COMPONENT_HEAVYRIFLE_SIGHT_01",// | 0xB3E1C452
                "COMPONENT_AT_SCOPE_MEDIUM",// | 0xA0D89C42
                "COMPONENT_AT_AR_FLSH",// | 0x7BC4CDDC
                "COMPONENT_AT_AR_SUPP",// | 0x837445AA
                "COMPONENT_AT_AR_AFGRIP",// | 0xC164F53
                "COMPONENT_HEAVYRIFLE_CAMO1",// | 0xEC9FECD9
                "COMPONENT_APPISTOL_VARMOD_SECURITY",//
                "COMPONENT_MICROSMG_VARMOD_SECURITY",//
                "COMPONENT_PUMPSHOTGUN_VARMOD_SECURITY",//

			    "COMPONENT_AT_AR_FLSH_REH", //| 0x9DB1E023
			    "COMPONENT_TACTICALRIFLE_CLIP_02", //| 0x8594554F
			    "COMPONENT_AT_AR_SUPP_02", ///| 0xA73D4664
			    "COMPONENT_AT_AR_AFGRIP" //| 0xC164F53
            };
            return AddAdds;
        }
        public static List<string> WeapsList()
        {
            LoggerLight.Loggers("DataStore.WeapsList");
            List<string> AddWeaps = new List<string> 
            {
                "WEAPON_dagger",  //0x92A27487",
                "WEAPON_bat",  //0x958A4A8F",
                "WEAPON_bottle",  //0xF9E6AA4B",
                "WEAPON_crowbar",  //0x84BD7BFD",
                "WEAPON_unarmed",  //0xA2719263",
                "WEAPON_flashlight",  //0x8BB05FD7",
                "WEAPON_golfclub",  //0x440E4788",
                "WEAPON_hammer",  //0x4E875F73",
                "WEAPON_hatchet",  //0xF9DCBF2D",
                "WEAPON_knuckle",  //0xD8DF3C3C",
                "WEAPON_knife",  //0x99B507EA",
                "WEAPON_machete",  //0xDD5DF8D9",
                "WEAPON_switchblade",  //0xDFE37640",
                "WEAPON_nightstick",  //0x678B81B1",
                "WEAPON_wrench",  //0x19044EE0",
                "WEAPON_battleaxe",  //0xCD274149",
                "WEAPON_poolcue",  //0x94117305",
                "WEAPON_stone_hatchet",  //0x3813FC08"--17

                "WEAPON_pistol",  //0x1B06D571",
                "WEAPON_pistol_mk2",  //0xBFE256D4",---------19
                "WEAPON_combatpistol",  //0x5EF9FEC4",
                "WEAPON_appistol",  //0x22D8FE39",
                "WEAPON_pistol50",  //0x99AEEB3B",
                "WEAPON_snspistol",  //0xBFD21232",
                "WEAPON_snspistol_mk2",  //0x88374054",---24
                "WEAPON_heavypistol",  //0xD205520E",
                "WEAPON_vintagepistol",  //0x83839C4",
                "WEAPON_marksmanpistol",  //0xDC4DB296",
                "WEAPON_revolver",  //0xC1B3C3D1",
                "WEAPON_revolver_mk2",  //0xCB96392F",----29
                "WEAPON_doubleaction",  //0x97EA20B8",
                "WEAPON_ceramicpistol",  //0x2B5EF5EC",
                "WEAPON_navyrevolver",  //0x917F6C8C"
                "WEAPON_GADGETPISTOL",  //0xAF3696A1",
                "WEAPON_stungun",  //0x3656C8C1",
                "WEAPON_flaregun",  //0x47757124",
                "WEAPON_raypistol",  //0xAF3696A1",--36

                "WEAPON_microsmg",  //0x13532244",
                "WEAPON_smg",  //0x2BE6766B",
                "WEAPON_smg_mk2",  //0x78A97CD0",-----39
                "WEAPON_assaultsmg",  //0xEFE7E2DF",
                "WEAPON_combatpdw",  //0xA3D4D34",
                "WEAPON_machinepistol",  //0xDB1AA450",
                "WEAPON_minismg",  //0xBD248B55",
                "WEAPON_raycarbine",  //0x476BF155"--44

                "WEAPON_pumpshotgun",  //0x1D073A89",
                "WEAPON_pumpshotgun_mk2",  //0x555AF99A",-----------46
                "WEAPON_sawnoffshotgun",  //0x7846A318",
                "WEAPON_assaultshotgun",  //0xE284C527",
                "WEAPON_bullpupshotgun",  //0x9D61E50F",
                "WEAPON_musket",  //0xA89CB99E",
                "WEAPON_heavyshotgun",  //0x3AABBBAA",
                "WEAPON_dbshotgun",  //0xEF951FBB",
                "WEAPON_autoshotgun",  //0x12E82D3D"--53
                "WEAPON_COMBATSHOTGUN",  //0x5A96BA4--54

                "WEAPON_assaultrifle",  //0xBFEFFF6D",
                "WEAPON_assaultrifle_mk2",  //0x394F415C",-------56
                "WEAPON_carbinerifle",  //0x83BF0278",
                "WEAPON_carbinerifle_mk2",  //0xFAD1F1C9",------58
                "WEAPON_advancedrifle",  //0xAF113F99",
                "WEAPON_specialcarbine",  //0xC0A3098D",
                "WEAPON_specialcarbine_mk2",  //0x969C3D67",------61
                "WEAPON_bullpuprifle",  //0x7F229F94",
                "WEAPON_bullpuprifle_mk2",  //0x84D6FAFD",----63
                "WEAPON_compactrifle",  //0x624FE830"--64
                "WEAPON_MILITARYRIFLE",  //0x624FE830"--65

                "WEAPON_mg",  //0x9D07F764",
                "WEAPON_combatmg",  //0x7FD62962",
                "WEAPON_combatmg_mk2",  //0xDBBD7280",------68
                "WEAPON_gusenberg",  //0x61012683"--69

                "WEAPON_sniperrifle",  //0x5FC3C11",
                "WEAPON_heavysniper",  //0xC472FE2",
                "WEAPON_heavysniper_mk2",  //0xA914799",---72
                "WEAPON_marksmanrifle",  //0xC734385A",
                "WEAPON_marksmanrifle_mk2",  //0x6A6C02E0"--74

                "WEAPON_rpg",  //0xB1CA77B1",
                "WEAPON_grenadelauncher",  //0xA284510B",
                "WEAPON_grenadelauncher_smoke",  //0x4DD2DC56",
                "WEAPON_minigun",  //0x42BF8A85",
                "WEAPON_firework",  //0x7F7497E5",
                "WEAPON_railgun",  //0x6D544C99",
                "WEAPON_hominglauncher",  //0x63AB0442",
                "WEAPON_compactlauncher",  //0x781FE4A",
                "WEAPON_rayminigun",  //0xB62D1F67"--83

                "WEAPON_grenade",  //0x93E220BD",
                "WEAPON_bzgas",  //0xA0973D5E",
                "WEAPON_smokegrenade",  //0xFDBC8A50",
                "WEAPON_flare",  //0x497FACC3",
                "WEAPON_molotov",  //0x24B17070",
                "WEAPON_stickybomb",  //0x2C3731D9",
                "WEAPON_proxmine",  //0xAB564B93",
                "WEAPON_snowball",  //0x787F0BB",
                "WEAPON_pipebomb",  //0xBA45E8B8",
                "WEAPON_ball",  //0x23C9F95C"--93

                "WEAPON_petrolcan",  //0x34A67B97",
                "WEAPON_fireextinguisher",  //0x60EC506",
                "WEAPON_parachute",  //0xFBAB5776",
                "WEAPON_hazardcan",  //0xBA536372"--97

                "WEAPON_EMPLAUNCHER",  // 0xDB26713A--98
                "WEAPON_HEAVYRIFLE",  //0xC78D71B4 --99
                "WEAPON_FERTILIZERCAN",//100
                "WEAPON_STUNGUN_MP",//101

                "WEAPON_METALDETECTOR",
                "WEAPON_PRECISIONRIFLE", //| 0x6E7DDDEC
                "WEAPON_TACTICALRIFLE" //| 0xD1D5F52B
            };
            return AddWeaps;
        }
        public static bool NSPMComp()
        {
            LoggerLight.Loggers("LoadOnYacht");

            string sLocate = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings/Settings.Xml";
            bool LOY = false;

            if (File.Exists(sLocate))
            {
                List<string> MyColect = new List<string>();
                try
                {
                    using (var reader = new StreamReader(sLocate, Encoding.GetEncoding("utf-8")))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            MyColect.Add(line);
                        }
                    }
                }
                catch
                {

                }

                for (int i = 0; i < MyColect.Count(); i++)
                {
                    string line = MyColect[i];
                    if (line.Contains("<StartOnYAcht>"))
                    {
                        int iNum = line.LastIndexOf("<StartOnYAcht>") + 14;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 15);
                        if (line == "true")
                            bLoadUpOnYacht = true;
                    }
                    else if (line.Contains("<ModVersion>"))
                    {
                        int iNum = line.LastIndexOf("<ModVersion>") + 12;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 13);
                        int iSum = (int)Convert.ToInt32(line);
                        if (iSum == 401)
                            LOY = true;
                    }
                }
            }

            return LOY;
        }
        public static List<string> FindaLang()
        {
            LoggerLight.Loggers("DataStore.FindaLang");

            List<string> NewLang = RsEnglish;

            int iLangSupport = MySettingsXML.LangSupport;

            if (iLangSupport == 0)
            {
                if (Game.Language == Language.American)
                    iLangSupport = 1;
                else if (Game.Language == Language.Chinese)
                    iLangSupport = 2;
                else if (Game.Language == Language.ChineseSimplified)
                    iLangSupport = 3;
                else if (Game.Language == Language.French)
                    iLangSupport = 4;
                else if (Game.Language == Language.German)
                    iLangSupport = 5;
                else if (Game.Language == Language.Italian)
                    iLangSupport = 6;
                else if (Game.Language == Language.Japanese)
                    iLangSupport = 7;
                else if (Game.Language == Language.Korean)
                    iLangSupport = 8;
                else if (Game.Language == Language.Mexican)
                    iLangSupport = 9;
                else if (Game.Language == Language.Polish)
                    iLangSupport = 10;
                else if (Game.Language == Language.Portuguese)
                    iLangSupport = 11;
                else if (Game.Language == Language.Russian)
                    iLangSupport = 12;
                else if (Game.Language == Language.Spanish)
                    iLangSupport = 13;
            }
            LoggerLight.Loggers("DataStore.FindaLang iLangSupport == " + iLangSupport);

            if (Directory.Exists(sRandLanguage))
            {
                if (iLangSupport > 0 && iLangSupport < 14)
                {
                    if (File.Exists(LangLocals[iLangSupport]))
                        NewLang = LoadStringList(LangLocals[iLangSupport]);

                }
            }

            if (NewLang.Count < 171)
                NewLang = RsEnglish;

            return NewLang;
        }
        public static List<WeaponSaver> GetWeaps()
        {
            LoggerLight.Loggers("DataStore.GetWeaps");

            List<WeaponSaver> YoWeaps = new List<WeaponSaver>();
            Ped Peddy = Game.Player.Character;

            for (int i = 0; i < DataStore.sWeapList.Count; i++)
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sWeapList[i]), false))
                {
                    WeaponSaver AdThis = new WeaponSaver();
                    AdThis.PlayWeaps = DataStore.sWeapList[i];
                    int iAmmos = 0;
                    iAmmos = Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sWeapList[i]));
                    if (iAmmos < 1)
                        iAmmos = 1;
                    AdThis.Ammos = iAmmos;

                    for (int ii = 0; ii < DataStore.sAddsList.Count; ii++)
                    {
                        if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sWeapList[i]), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sAddsList[ii])))
                            AdThis.PlayCompsList.Add(DataStore.sAddsList[ii]);
                    }
                    YoWeaps.Add(AdThis);
                }
            }
            return YoWeaps;
        }
        public static void LoadUp()
        {
            LoggerLight.Loggers("LoadUp");
            LoadupWeaponXML();

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Friend, DataStore.GP_Player);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, DataStore.GP_Friend);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, DataStore.GP_Attack, DataStore.GP_Player);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, DataStore.GP_Player, DataStore.GP_Attack);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, DataStore.GP_Attack, DataStore.GP_Friend);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, DataStore.GP_Friend, DataStore.GP_Attack);

            UI.Notify("" + MultC[RandomX.RandInt(0, MultC.Count -1)] + "Random Start " + MultC[RandomX.RandInt(0, MultC.Count -1)] + "" + DataStore.sVersion + "" + MultC[RandomX.RandInt(0, MultC.Count -1)] + " by" + MultC[RandomX.RandInt(0, MultC.Count -1)] + " Adopcalipt " + MultC[RandomX.RandInt(0, MultC.Count -1)] + "Loaded" + MultC[RandomX.RandInt(0, MultC.Count -1)] + ".");

            if (File.Exists("" + Directory.GetCurrentDirectory() + "/Menyoo.asi"))
            {
                if (File.Exists("" + Directory.GetCurrentDirectory() + "/menyooStuff/menyooConfig.ini"))
                {
                    MenyooTest = ScriptSettings.Load("" + Directory.GetCurrentDirectory() + "/menyooStuff/menyooConfig.ini");

                    bMenyooZZ = MenyooTest.GetValue<bool>("settings", "DeathModelReset", true);
                }
                else
                    bMenyooZZ = false;

                bDisableDLCVeh = false;
            }

            if (File.Exists("" + Directory.GetCurrentDirectory() + "/EnhancedNativeTrainer.asi"))
            {
                //bEnhanceT = true;
                bDisableDLCVeh = false;
            }

            if (File.Exists("" + Directory.GetCurrentDirectory() + "/TrainerV.asi"))
                bDisableDLCVeh = false;

            if (File.Exists("" + Directory.GetCurrentDirectory() + "/AddonSpawner.asi"))
                bDisableDLCVeh = false;

            PeskyDoors.Add(new Vector3(4977.988f, -5764.742f, 20.93811f));
            PeskyDoors.Add(new Vector3(4989.251f, -5717.235f, 19.87565f));
            PeskyDoors.Add(new Vector3(4983.159f, -5711.408f, 19.40226f));
        }
        public static List<string> ControlList()
        {
            List<string> ControlerSet = new List<string> 
            {
                "INPUT_NEXT_CAMERA 	0 	V",
                "INPUT_LOOK_LR 	1 	Left Mouse Button",
                "INPUT_LOOK_UD 	2 	Right Mouse Button",
                "INPUT_LOOK_UP_ONLY 	3 	Control-Break Processing",
                "INPUT_LOOK_DOWN_ONLY 	4 	Middle Mouse Button",
                "INPUT_LOOK_LEFT_ONLY 	5",
                "INPUT_LOOK_RIGHT_ONLY 	6 	Right Mouse Button",
                "INPUT_CINEMATIC_SLOWMO 	7 	L",
                "INPUT_SCRIPTED_FLY_UD 	8 	S",
                "INPUT_SCRIPTED_FLY_LR 	9 	D",
                "INPUT_SCRIPTED_FLY_ZUP 	10 	PAGE UP",
                "INPUT_SCRIPTED_FLY_ZDOWN 	11 	PAGE DOWN",
                "INPUT_WEAPON_WHEEL_UD 	12 	MOUSE DOWN",
                "INPUT_WEAPON_WHEEL_LR 	13 	MOUSE RIGHT",
                "INPUT_WEAPON_WHEEL_NEXT 	14 	MOUSE SCROLL WHEEL DOWN",
                "INPUT_WEAPON_WHEEL_PREV 	15 	MOUSE SCROLL WHEEL UP",
                "INPUT_SELECT_NEXT_WEAPON 	16 	MOUSE SCROLL WHEEL DOWN",
                "INPUT_SELECT_PREV_WEAPON 	17 	MOUSE SCROLL WHEEL UP",
                "INPUT_SKIP_CUTSCENE 	18 	ENTER / LEFT MOUSE BUTTON / SPACEBAR",
                "INPUT_CHARACTER_WHEEL 	19 	LEFT ALT",
                "INPUT_MULTIPLAYER_INFO 	20 	Z",
                "INPUT_SPRINT 	21 	Shift Key",
                "INPUT_JUMP 	22 	Space Key",
                "INPUT_ENTER 	23 	Enter Key",
                "INPUT_ATTACK 	24 	Left Mouse Button",
                "INPUT_AIM 	25 	Right Mouse Button",
                "INPUT_LOOK_BEHIND 	26 	C",
                "INPUT_PHONE 	27 	ARROW UP/SCROLLWHEEL BUTTON (press)",
                "INPUT_SPECIAL_ABILITY 	28 	",
                "INPUT_SPECIAL_ABILITY_SECONDARY 	29 	B",
                "INPUT_MOVE_LR 	30 	D",
                "INPUT_MOVE_UD 	31 	S",
                "INPUT_MOVE_UP_ONLY 	32 	W",
                "INPUT_MOVE_DOWN_ONLY 	33 	S",
                "INPUT_MOVE_LEFT_ONLY 	34 	A",
                "INPUT_MOVE_RIGHT_ONLY 	35 	D",
                "INPUT_DUCK 	36 	LEFT CONTROL",
                "INPUT_SELECT_WEAPON 	37 	TAB",
                "INPUT_PICKUP 	38 	E",
                "INPUT_SNIPER_ZOOM 	39 	[",
                "INPUT_SNIPER_ZOOM_IN_ONLY 	40 	]",
                "INPUT_SNIPER_ZOOM_OUT_ONLY 	41 	[",
                "INPUT_SNIPER_ZOOM_IN_SECONDARY 	42 	]",
                "INPUT_SNIPER_ZOOM_OUT_SECONDARY 	43 	[",
                "INPUT_COVER 	44 	Q",
                "INPUT_RELOAD 	45 	R",
                "INPUT_TALK 	46 	E",
                "INPUT_DETONATE 	47 	G",
                "INPUT_HUD_SPECIAL 	48 	Z",
                "INPUT_ARREST 	49 	F",
                "INPUT_ACCURATE_AIM 	50 	SCROLLWHEEL DOWN",
                "INPUT_CONTEXT 	51 	E",
                "INPUT_CONTEXT_SECONDARY 	52 	Q",
                "INPUT_WEAPON_SPECIAL 	53 	",
                "INPUT_WEAPON_SPECIAL_TWO 	54 	E",
                "INPUT_DIVE 	55 	SPACEBAR",
                "INPUT_DROP_WEAPON 	56 	F9",
                "INPUT_DROP_AMMO 	57 	F10",
                "INPUT_THROW_GRENADE 	58 	G",
                "INPUT_VEH_MOVE_LR 	59 	D",
                "INPUT_VEH_MOVE_UD 	60 	LEFT CTRL",
                "INPUT_VEH_MOVE_UP_ONLY 	61 	LEFT SHIFT",
                "INPUT_VEH_MOVE_DOWN_ONLY 	62 	LEFT CTRL",
                "INPUT_VEH_MOVE_LEFT_ONLY 	63 	A",
                "INPUT_VEH_MOVE_RIGHT_ONLY 	64 	D",
                "INPUT_VEH_SPECIAL 	65 	",
                "INPUT_VEH_GUN_LR 	66 	MOUSE RIGHT",
                "INPUT_VEH_GUN_UD 	67 	MOUSE DOWN",
                "INPUT_VEH_AIM 	68 	RIGHT MOUSE BUTTON",
                "INPUT_VEH_ATTACK 	69 	LEFT MOUSE BUTTON",
                "INPUT_VEH_ATTACK2 	70 	RIGHT MOUSE BUTTON",
                "INPUT_VEH_ACCELERATE 	71 	W",
                "INPUT_VEH_BRAKE 	72 	S",
                "INPUT_VEH_DUCK 	73 	X",
                "INPUT_VEH_HEADLIGHT 	74 	H",
                "INPUT_VEH_EXIT 	75 	F",
                "INPUT_VEH_HANDBRAKE 	76 	SPACEBAR",
                "INPUT_VEH_HOTWIRE_LEFT 	77 	W",
                "INPUT_VEH_HOTWIRE_RIGHT 	78 	S",
                "INPUT_VEH_LOOK_BEHIND 	79 	C",
                "INPUT_VEH_CIN_CAM 	80 	R",
                "INPUT_VEH_NEXT_RADIO 	81 	.",
                "INPUT_VEH_PREV_RADIO 	82 	,",
                "INPUT_VEH_NEXT_RADIO_TRACK 	83 	=",
                "INPUT_VEH_PREV_RADIO_TRACK 	84 	-",
                "INPUT_VEH_RADIO_WHEEL 	85 	Q",
                "INPUT_VEH_HORN 	86 	E",
                "INPUT_VEH_FLY_THROTTLE_UP 	87 	W",
                "INPUT_VEH_FLY_THROTTLE_DOWN 	88 	S",
                "INPUT_VEH_FLY_YAW_LEFT 	89 	A",
                "INPUT_VEH_FLY_YAW_RIGHT 	90 	D",
                "INPUT_VEH_PASSENGER_AIM 	91 	RIGHT MOUSE BUTTON",
                "INPUT_VEH_PASSENGER_ATTACK 	92 	LEFT MOUSE BUTTON",
                "INPUT_VEH_SPECIAL_ABILITY_FRANKLIN 	93 	",
                "INPUT_VEH_STUNT_UD 	94 	",
                "INPUT_VEH_CINEMATIC_UD 	95 	MOUSE DOWN",
                "INPUT_VEH_CINEMATIC_UP_ONLY 	96 	NUMPAD- / SCROLLWHEEL UP",
                "INPUT_VEH_CINEMATIC_DOWN_ONLY 	97 	NUMPAD+ / SCROLLWHEEL DOWN",
                "INPUT_VEH_CINEMATIC_LR 	98 	MOUSE RIGHT",
                "INPUT_VEH_SELECT_NEXT_WEAPON 	99 	SCROLLWHEEL UP",
                "INPUT_VEH_SELECT_PREV_WEAPON 	100 	[",
                "INPUT_VEH_ROOF 	101 	H",
                "INPUT_VEH_JUMP 	102 	SPACEBAR",
                "INPUT_VEH_GRAPPLING_HOOK 	103 	E",
                "INPUT_VEH_SHUFFLE 	104 	H",
                "INPUT_VEH_DROP_PROJECTILE 	105 	X",
                "INPUT_VEH_MOUSE_CONTROL_OVERRIDE 	106 	LEFT MOUSE BUTTON",
                "INPUT_VEH_FLY_ROLL_LR 	107 	NUMPAD 6",
                "INPUT_VEH_FLY_ROLL_LEFT_ONLY 	108 	NUMPAD 4",
                "INPUT_VEH_FLY_ROLL_RIGHT_ONLY 	109 	NUMPAD 6",
                "INPUT_VEH_FLY_PITCH_UD 	110 	NUMPAD 5",
                "INPUT_VEH_FLY_PITCH_UP_ONLY 	111 	NUMPAD 8",
                "INPUT_VEH_FLY_PITCH_DOWN_ONLY 	112 	NUMPAD 5",
                "INPUT_VEH_FLY_UNDERCARRIAGE 	113 	G",
                "INPUT_VEH_FLY_ATTACK 	114 	RIGHT MOUSE BUTTON",
                "INPUT_VEH_FLY_SELECT_NEXT_WEAPON 	115 	SCROLLWHEEL UP",
                "INPUT_VEH_FLY_SELECT_PREV_WEAPON 	116 	[",
                "INPUT_VEH_FLY_SELECT_TARGET_LEFT 	117 	NUMPAD 7",
                "INPUT_VEH_FLY_SELECT_TARGET_RIGHT 	118 	NUMPAD 9",
                "INPUT_VEH_FLY_VERTICAL_FLIGHT_MODE 	119 	E",
                "INPUT_VEH_FLY_DUCK 	120 	X",
                "INPUT_VEH_FLY_ATTACK_CAMERA 	121 	INSERT",
                "INPUT_VEH_FLY_MOUSE_CONTROL_OVERRIDE 	122 	LEFT MOUSE BUTTON",
                "INPUT_VEH_SUB_TURN_LR 	123 	NUMPAD 6",
                "INPUT_VEH_SUB_TURN_LEFT_ONLY 	124 	NUMPAD 4",
                "INPUT_VEH_SUB_TURN_RIGHT_ONLY 	125 	NUMPAD 6",
                "INPUT_VEH_SUB_PITCH_UD 	126 	NUMPAD 5",
                "INPUT_VEH_SUB_PITCH_UP_ONLY 	127 	NUMPAD 8",
                "INPUT_VEH_SUB_PITCH_DOWN_ONLY 	128 	NUMPAD 5",
                "INPUT_VEH_SUB_THROTTLE_UP 	129 	W",
                "INPUT_VEH_SUB_THROTTLE_DOWN 	130 	S",
                "INPUT_VEH_SUB_ASCEND 	131 	LEFT SHIFT",
                "INPUT_VEH_SUB_DESCEND 	132 	LEFT CTRL",
                "INPUT_VEH_SUB_TURN_HARD_LEFT 	133 	A",
                "INPUT_VEH_SUB_TURN_HARD_RIGHT 	134 	D",
                "INPUT_VEH_SUB_MOUSE_CONTROL_OVERRIDE 	135 	LEFT MOUSE BUTTON",
                "INPUT_VEH_PUSHBIKE_PEDAL 	136 	W",
                "INPUT_VEH_PUSHBIKE_SPRINT 	137 	CAPSLOCK",
                "INPUT_VEH_PUSHBIKE_FRONT_BRAKE 	138 	Q",
                "INPUT_VEH_PUSHBIKE_REAR_BRAKE 	139 	S",
                "INPUT_MELEE_ATTACK_LIGHT 	140 	R",
                "INPUT_MELEE_ATTACK_HEAVY 	141 	Q",
                "INPUT_MELEE_ATTACK_ALTERNATE 	142 	LEFT MOUSE BUTTON",
                "INPUT_MELEE_BLOCK 	143 	SPACEBAR",
                "INPUT_PARACHUTE_DEPLOY 	144 	F / LEFT MOUSE BUTTON",
                "INPUT_PARACHUTE_DETACH 	145 	F",
                "INPUT_PARACHUTE_TURN_LR 	146 	D",
                "INPUT_PARACHUTE_TURN_LEFT_ONLY 	147 	A",
                "INPUT_PARACHUTE_TURN_RIGHT_ONLY 	148 	D",
                "INPUT_PARACHUTE_PITCH_UD 	149 	S",
                "INPUT_PARACHUTE_PITCH_UP_ONLY 	150 	W",
                "INPUT_PARACHUTE_PITCH_DOWN_ONLY 	151 	S",
                "INPUT_PARACHUTE_BRAKE_LEFT 	152 	Q",
                "INPUT_PARACHUTE_BRAKE_RIGHT 	153 	E",
                "INPUT_PARACHUTE_SMOKE 	154 	X",
                "INPUT_PARACHUTE_PRECISION_LANDING 	155 	LEFT SHIFT",
                "INPUT_MAP 	156 	",
                "INPUT_SELECT_WEAPON_UNARMED 	157 	1",
                "INPUT_SELECT_WEAPON_MELEE 	158 	2",
                "INPUT_SELECT_WEAPON_HANDGUN 	159 	6",
                "INPUT_SELECT_WEAPON_SHOTGUN 	160 	3",
                "INPUT_SELECT_WEAPON_SMG 	161 	7",
                "INPUT_SELECT_WEAPON_AUTO_RIFLE 	162 	8",
                "INPUT_SELECT_WEAPON_SNIPER 	163 	9",
                "INPUT_SELECT_WEAPON_HEAVY 	164 	4",
                "INPUT_SELECT_WEAPON_SPECIAL 	165 	5",
                "INPUT_SELECT_CHARACTER_MICHAEL 	166 	F5",
                "INPUT_SELECT_CHARACTER_FRANKLIN 	167 	F6",
                "INPUT_SELECT_CHARACTER_TREVOR 	168 	F7",
                "INPUT_SELECT_CHARACTER_MULTIPLAYER 	169 	F8",
                "INPUT_SAVE_REPLAY_CLIP 	170 	F3",
                "INPUT_SPECIAL_ABILITY_PC 	171 	CAPSLOCK",
                "INPUT_CELLPHONE_UP 	172 	ARROW UP",
                "INPUT_CELLPHONE_DOWN 	173 	ARROW DOWN",
                "INPUT_CELLPHONE_LEFT 	174 	ARROW LEFT",
                "INPUT_CELLPHONE_RIGHT 	175 	ARROW RIGHT",
                "INPUT_CELLPHONE_SELECT 	176 	ENTER/LEFT MOUSE BUTTON",
                "INPUT_CELLPHONE_CANCEL 	177 	BACKSPACE/ESC/RIGHT MOUSE BUTTON",
                "INPUT_CELLPHONE_OPTION 	178 	DELETE",
                "INPUT_CELLPHONE_EXTRA_OPTION 	179 	SPACEBAR",
                "INPUT_CELLPHONE_SCROLL_FORWARD 	180 	SCROLLWHEEL DOWN",
                "INPUT_CELLPHONE_SCROLL_BACKWARD 	181 	SCROLLWHEEL UP",
                "INPUT_CELLPHONE_CAMERA_FOCUS_LOCK 	182 	L",
                "INPUT_CELLPHONE_CAMERA_GRID 	183 	G",
                "INPUT_CELLPHONE_CAMERA_SELFIE 	184 	E",
                "INPUT_CELLPHONE_CAMERA_DOF 	185 	F",
                "INPUT_CELLPHONE_CAMERA_EXPRESSION 	186 	X",
                "INPUT_FRONTEND_DOWN 	187 	ARROW DOWN",
                "INPUT_FRONTEND_UP 	188 	ARROW UP",
                "INPUT_FRONTEND_LEFT 	189 	ARROW LEFT",
                "INPUT_FRONTEND_RIGHT 	190 	ARROW RIGHT",
                "INPUT_FRONTEND_RDOWN 	191 	ENTER",
                "INPUT_FRONTEND_RUP 	192 	TAB",
                "INPUT_FRONTEND_RLEFT 	193 	",
                "INPUT_FRONTEND_RRIGHT 	194 	BACKSPACE",
                "INPUT_FRONTEND_AXIS_X 	195 	D",
                "INPUT_FRONTEND_AXIS_Y 	196 	S",
                "INPUT_FRONTEND_RIGHT_AXIS_X 	197 	]",
                "INPUT_FRONTEND_RIGHT_AXIS_Y 	198 	SCROLLWHEEL DOWN",
                "INPUT_FRONTEND_PAUSE 	199 	P",
                "INPUT_FRONTEND_PAUSE_ALTERNATE 	200 	ESC",
                "INPUT_FRONTEND_ACCEPT 	201 	ENTER/NUMPAD ENTER",
                "INPUT_FRONTEND_CANCEL 	202 	BACKSPACE/ESC",
                "INPUT_FRONTEND_X 	203 	SPACEBAR",
                "INPUT_FRONTEND_Y 	204 	TAB",
                "INPUT_FRONTEND_LB 	205 	Q",
                "INPUT_FRONTEND_RB 	206 	E",
                "INPUT_FRONTEND_LT 	207 	PAGE DOWN",
                "INPUT_FRONTEND_RT 	208 	PAGE UP",
                "INPUT_FRONTEND_LS 	209 	LEFT SHIFT",
                "INPUT_FRONTEND_RS 	210 	LEFT CTRL",
                "INPUT_FRONTEND_LEADERBOARD 	211 	TAB",
                "INPUT_FRONTEND_SOCIAL_CLUB 	212 	HOME",
                "INPUT_FRONTEND_SOCIAL_CLUB_SECONDARY 	213 	HOME",
                "INPUT_FRONTEND_DELETE 	214 	DELETE",
                "INPUT_FRONTEND_ENDSCREEN_ACCEPT 	215 	ENTER",
                "INPUT_FRONTEND_ENDSCREEN_EXPAND 	216 	SPACEBAR",
                "INPUT_FRONTEND_SELECT 	217 	CAPSLOCK",
                "INPUT_SCRIPT_LEFT_AXIS_X 	218 	D",
                "INPUT_SCRIPT_LEFT_AXIS_Y 	219 	S",
                "INPUT_SCRIPT_RIGHT_AXIS_X 	220 	MOUSE RIGHT",
                "INPUT_SCRIPT_RIGHT_AXIS_Y 	221 	MOUSE DOWN",
                "INPUT_SCRIPT_RUP 	222 	RIGHT MOUSE BUTTON",
                "INPUT_SCRIPT_RDOWN 	223 	LEFT MOUSE BUTTON",
                "INPUT_SCRIPT_RLEFT 	224 	LEFT CTRL",
                "INPUT_SCRIPT_RRIGHT 	225 	RIGHT MOUSE BUTTON",
                "INPUT_SCRIPT_LB 	226 	",
                "INPUT_SCRIPT_RB 	227 	",
                "INPUT_SCRIPT_LT 	228 	",
                "INPUT_SCRIPT_RT 	229 	LEFT MOUSE BUTTON",
                "INPUT_SCRIPT_LS 	230 	",
                "INPUT_SCRIPT_RS 	231 	",
                "INPUT_SCRIPT_PAD_UP 	232 	W",
                "INPUT_SCRIPT_PAD_DOWN 	233 	S",
                "INPUT_SCRIPT_PAD_LEFT 	234 	A",
                "INPUT_SCRIPT_PAD_RIGHT 	235 	D",
                "INPUT_SCRIPT_SELECT 	236 	V",
                "INPUT_CURSOR_ACCEPT 	237 	LEFT MOUSE BUTTON",
                "INPUT_CURSOR_CANCEL 	238 	RIGHT MOUSE BUTTON",
                "INPUT_CURSOR_X 	239 	",
                "INPUT_CURSOR_Y 	240 	",
                "INPUT_CURSOR_SCROLL_UP 	241 	SCROLLWHEEL UP",
                "INPUT_CURSOR_SCROLL_DOWN 	242 	SCROLLWHEEL DOWN",
                "INPUT_ENTER_CHEAT_CODE 	243 	~ / `",
                "INPUT_INTERACTION_MENU 	244 	M",
                "INPUT_MP_TEXT_CHAT_ALL 	245 	T",
                "INPUT_MP_TEXT_CHAT_TEAM 	246 	Y",
                "INPUT_MP_TEXT_CHAT_FRIENDS 	247 	",
                "INPUT_MP_TEXT_CHAT_CREW 	248 	",
                "INPUT_PUSH_TO_TALK 	249 	N",
                "INPUT_CREATOR_LS 	250 	R",
                "INPUT_CREATOR_RS 	251 	F",
                "INPUT_CREATOR_LT 	252 	X",
                "INPUT_CREATOR_RT 	253 	C",
                "INPUT_CREATOR_MENU_TOGGLE 	254 	LEFT SHIFT",
                "INPUT_CREATOR_ACCEPT 	255 	SPACEBAR",
                "INPUT_CREATOR_DELETE 	256 	DELETE",
                "INPUT_ATTACK2 	257 	LEFT MOUSE BUTTON",
                "INPUT_RAPPEL_JUMP 	258 	",
                "INPUT_RAPPEL_LONG_JUMP 	259 	",
                "INPUT_RAPPEL_SMASH_WINDOW 	260 	",
                "INPUT_PREV_WEAPON 	261 	SCROLLWHEEL UP",
                "INPUT_NEXT_WEAPON 	262 	SCROLLWHEEL DOWN",
                "INPUT_MELEE_ATTACK1 	263 	R",
                "INPUT_MELEE_ATTACK2 	264 	Q",
                "INPUT_WHISTLE 	265 	",
                "INPUT_MOVE_LEFT 	266 	D",
                "INPUT_MOVE_RIGHT 	267 	D",
                "INPUT_MOVE_UP 	268 	S",
                "INPUT_MOVE_DOWN 	269 	S",
                "INPUT_LOOK_LEFT 	270 	MOUSE RIGHT",
                "INPUT_LOOK_RIGHT 	271 	MOUSE RIGHT",
                "INPUT_LOOK_UP 	272 	MOUSE DOWN",
                "INPUT_LOOK_DOWN 	273 	MOUSE DOWN",
                "INPUT_SNIPER_ZOOM_IN 	274 	[",
                "INPUT_SNIPER_ZOOM_OUT 	275 	[",
                "INPUT_SNIPER_ZOOM_IN_ALTERNATE 	276 	[",
                "INPUT_SNIPER_ZOOM_OUT_ALTERNATE 	277 	[",
                "INPUT_VEH_MOVE_LEFT 	278 	D",
                "INPUT_VEH_MOVE_RIGHT 	279 	D",
                "INPUT_VEH_MOVE_UP 	280 	LEFT CTRL",
                "INPUT_VEH_MOVE_DOWN 	281 	LEFT CTRL",
                "INPUT_VEH_GUN_LEFT 	282 	MOUSE RIGHT",
                "INPUT_VEH_GUN_RIGHT 	283 	MOUSE RIGHT",
                "INPUT_VEH_GUN_UP 	284 	MOUSE RIGHT",
                "INPUT_VEH_GUN_DOWN 	285 	MOUSE RIGHT",
                "INPUT_VEH_LOOK_LEFT 	286 	MOUSE RIGHT",
                "INPUT_VEH_LOOK_RIGHT 	287 	MOUSE RIGHT",
                "INPUT_REPLAY_START_STOP_RECORDING 	288 	F1",
                "INPUT_REPLAY_START_STOP_RECORDING_SECONDARY 	289 	F2",
                "INPUT_SCALED_LOOK_LR 	290 	MOUSE RIGHT",
                "INPUT_SCALED_LOOK_UD 	291 	MOUSE DOWN",
                "INPUT_SCALED_LOOK_UP_ONLY 	292 	",
                "INPUT_SCALED_LOOK_DOWN_ONLY 	293 	",
                "INPUT_SCALED_LOOK_LEFT_ONLY 	294 	",
                "INPUT_SCALED_LOOK_RIGHT_ONLY 	295 	",
                "INPUT_REPLAY_MARKER_DELETE 	296 	DELETE",
                "INPUT_REPLAY_CLIP_DELETE 	297 	DELETE",
                "INPUT_REPLAY_PAUSE 	298 	SPACEBAR",
                "INPUT_REPLAY_REWIND 	299 	ARROW DOWN",
                "INPUT_REPLAY_FFWD 	300 	ARROW UP",
                "INPUT_REPLAY_NEWMARKER 	301 	M",
                "INPUT_REPLAY_RECORD 	302 	S",
                "INPUT_REPLAY_SCREENSHOT 	303 	U",
                "INPUT_REPLAY_HIDEHUD 	304 	H",
                "INPUT_REPLAY_STARTPOINT 	305 	B",
                "INPUT_REPLAY_ENDPOINT 	306 	N",
                "INPUT_REPLAY_ADVANCE 	307 	ARROW RIGHT",
                "INPUT_REPLAY_BACK 	308 	ARROW LEFT",
                "INPUT_REPLAY_TOOLS 	309 	T",
                "INPUT_REPLAY_RESTART 	310 	R",
                "INPUT_REPLAY_SHOWHOTKEY 	311 	K",
                "INPUT_REPLAY_CYCLEMARKERLEFT 	312 	[",
                "INPUT_REPLAY_CYCLEMARKERRIGHT 	313 	]",
                "INPUT_REPLAY_FOVINCREASE 	314 	NUMPAD+",
                "INPUT_REPLAY_FOVDECREASE 	315 	NUMPAD-",
                "INPUT_REPLAY_CAMERAUP 	316 	PAGE UP",
                "INPUT_REPLAY_CAMERADOWN 	317 	PAGE DOWN",
                "INPUT_REPLAY_SAVE 	318 	F5",
                "INPUT_REPLAY_TOGGLETIME 	319 	C",
                "INPUT_REPLAY_TOGGLETIPS 	320 	V",
                "INPUT_REPLAY_PREVIEW 	321 	SPACEBAR",
                "INPUT_REPLAY_TOGGLE_TIMELINE 	322 	ESC",
                "INPUT_REPLAY_TIMELINE_PICKUP_CLIP 	323 	X",
                "INPUT_REPLAY_TIMELINE_DUPLICATE_CLIP 	324 	C",
                "INPUT_REPLAY_TIMELINE_PLACE_CLIP 	325 	V",
                "INPUT_REPLAY_CTRL 	326 	LEFT CTRL",
                "INPUT_REPLAY_TIMELINE_SAVE 	327 	F5",
                "INPUT_REPLAY_PREVIEW_AUDIO 	328 	SPACEBAR",
                "INPUT_VEH_DRIVE_LOOK 	329 	LEFT MOUSE BUTTON",
                "INPUT_VEH_DRIVE_LOOK2 	330 	RIGHT MOUSE BUTTON",
                "INPUT_VEH_FLY_ATTACK2 	331 	RIGHT MOUSE BUTTON",
                "INPUT_RADIO_WHEEL_UD 	332 	MOUSE DOWN",
                "INPUT_RADIO_WHEEL_LR 	333 	MOUSE RIGHT",
                "INPUT_VEH_SLOWMO_UD 	334 	SCROLLWHEEL DOWN",
                "INPUT_VEH_SLOWMO_UP_ONLY 	335 	SCROLLWHEEL UP",
                "INPUT_VEH_SLOWMO_DOWN_ONLY 	336 	SCROLLWHEEL DOWN",
                "INPUT_VEH_HYDRAULICS_CONTROL_TOGGLE 	337 	X",
                "INPUT_VEH_HYDRAULICS_CONTROL_LEFT 	338 	A",
                "INPUT_VEH_HYDRAULICS_CONTROL_RIGHT 	339 	D",
                "INPUT_VEH_HYDRAULICS_CONTROL_UP 	340 	LEFT SHIFT",
                "INPUT_VEH_HYDRAULICS_CONTROL_DOWN 	341 	LEFT CTRL",
                "INPUT_VEH_HYDRAULICS_CONTROL_LR 	342 	D",
                "INPUT_VEH_HYDRAULICS_CONTROL_UD 	343 	LEFT CTRL",
                "INPUT_SWITCH_VISOR 	344 	F11",
                "INPUT_VEH_MELEE_HOLD 	345 	X",
                "INPUT_VEH_MELEE_LEFT 	346 	LEFT MOUSE BUTTON",
                "INPUT_VEH_MELEE_RIGHT 	347 	RIGHT MOUSE BUTTON",
                "INPUT_MAP_POI 	348 	SCROLLWHEEL BUTTON (PRESS)",
                "INPUT_REPLAY_SNAPMATIC_PHOTO 	349 	TAB",
                "INPUT_VEH_CAR_JUMP 	350 	E",
                "INPUT_VEH_ROCKET_BOOST 	351 	E",
                "INPUT_VEH_FLY_BOOST 	352 	LEFT SHIFT",
                "INPUT_VEH_PARACHUTE 	353 	SPACEBAR",
                "INPUT_VEH_BIKE_WINGS 	354 	X",
                "INPUT_VEH_FLY_BOMB_BAY 	355 	E",
                "INPUT_VEH_FLY_COUNTER 	356 	E",
                "INPUT_VEH_TRANSFORM 	357 	X",
                "INPUT_QUAD_LOCO_REVERSE 	358 	",
                "INPUT_RESPAWN_FASTER 	359 	",
                "INPUT_HUDMARKER_SELECT 	360 "
            };
            return ControlerSet;
        }
        private static List<ClothBank> LoadInBank()
        {
            LoggerLight.Loggers("LoadInBank");

            List<ClothBank> MyBank = new List<ClothBank>();

            if (File.Exists(sFixSavedFile))
            {
                MyBank = LoadChars(sFixSavedFile);

                for (int i = 0; i < MyBank.Count; i++)
                {
                    MyBank[i].CothInt = 0;

                    for (int ii = 0; ii < MyBank[i].Cothing.Count(); ii++)
                    {
                        int iFFFSake = -1;
                        for (int iii = 0; iii < MyBank[i].Cothing[ii].ClothA.Count; iii++)
                        {
                            if (MyBank[i].Cothing[ii].ClothA[iii] != 0)
                                iFFFSake = iii;
                        }

                        if (iFFFSake == -1)
                            MyBank[i].Cothing.RemoveAt(ii);
                        else
                        {
                            if (MyBank[i].Cothing[ii].ClothA.Count > 12)
                                MyBank[i].Cothing[ii].ClothA.RemoveRange(0, MyBank[i].Cothing[ii].ClothA.Count - 12);
                            if (MyBank[i].Cothing[ii].ClothB.Count > 12)
                                MyBank[i].Cothing[ii].ClothB.RemoveRange(0, MyBank[i].Cothing[ii].ClothB.Count - 12);
                        }
                    }
                }

                SaveChars(MyBank, sSavedFile);
                File.Delete(sFixSavedFile);
            }
            else if (File.Exists(sSavedFile))
                MyBank = LoadChars(sSavedFile);
            else if (File.Exists(sOldSavedFile))
            {
                MyBank = OldSaveCon(sOldSavedFile);
                SaveChars(MyBank, sSavedFile);
            }
            if (MyBank.Count == 0)
                MyBank.Add(new ClothBank(Game.Player.Character));

            return MyBank;
        }
        private static List<ClothBank> OldSaveCon(string fileName)
        {
            List<ClothBank> MyConverstion = new List<ClothBank>();

            if (File.Exists(fileName))
            {
                List<string> MyColect = new List<string>();
                try
                {
                    using (var reader = new StreamReader(fileName, Encoding.GetEncoding("utf-8")))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            MyColect.Add(line);
                        }
                    }
                }
                catch
                {

                }

                int iMyConvert = -1;
                int iListBuild = 0;
                int iMidPart = -1;


                for (int i = 0; i < MyColect.Count(); i++)
                {
                    string line = MyColect[i];
                    if (line.Contains("<Name>"))
                    {
                        iMyConvert += 1;
                        int iNum = line.LastIndexOf("<Name>") + 6;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 7);
                        MyConverstion.Add(new ClothBank());
                        MyConverstion[iMyConvert].Name = line;
                    }
                    else if (line.Contains("<ModelX>"))
                    {
                        int iNum = line.LastIndexOf("<ModelX>") + 8;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 9);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].ModelX = iSum;
                    }
                    else if (line.Contains("<ClothA>"))
                    {
                        iListBuild = 1;
                        if (MyConverstion[iMyConvert].Cothing.Count == 0)
                            MyConverstion[iMyConvert].Cothing.Add(new ClothX());
                    }
                    else if (iListBuild == 1)
                    {
                        if (line.Contains("</ClothA>"))
                            iListBuild = 0;
                        else
                        {
                            int iNum = line.LastIndexOf("<int>") + 5;
                            line = line.Substring(iNum);
                            line = line.Remove(line.Count() - 6);
                            int iSum = (int)Convert.ToInt32(line);
                            MyConverstion[iMyConvert].Cothing[0].ClothA.Add(iSum);
                        }
                    }
                    else if (line.Contains("<ClothB>"))
                    {
                        iListBuild = 2;
                    }
                    else if (iListBuild == 2)
                    {
                        if (line.Contains("</ClothB>"))
                            iListBuild = 0;
                        else
                        {
                            int iNum = line.LastIndexOf("<int>") + 5;
                            line = line.Substring(iNum);
                            line = line.Remove(line.Count() - 6);
                            int iSum = (int)Convert.ToInt32(line);
                            MyConverstion[iMyConvert].Cothing[0].ClothB.Add(iSum);
                        }
                    }
                    else if (line.Contains("<ExtraA>"))
                    {
                        iListBuild = 3;
                    }
                    else if (iListBuild == 3)
                    {
                        if (line.Contains("</ExtraA>"))
                            iListBuild = 0;
                        else
                        {
                            int iNum = line.LastIndexOf("<int>") + 5;
                            line = line.Substring(iNum);
                            line = line.Remove(line.Count() - 6);
                            int iSum = (int)Convert.ToInt32(line);
                            MyConverstion[iMyConvert].Cothing[0].ExtraA.Add(iSum);
                        }
                    }
                    else if (line.Contains("<ExtraB>"))
                    {
                        iListBuild = 4;
                    }
                    else if (iListBuild == 4)
                    {
                        if (line.Contains("</ExtraB>"))
                            iListBuild = 0;
                        else
                        {
                            int iNum = line.LastIndexOf("<int>") + 5;
                            line = line.Substring(iNum);
                            line = line.Remove(line.Count() - 6);
                            int iSum = (int)Convert.ToInt32(line);
                            MyConverstion[iMyConvert].Cothing[0].ExtraB.Add(iSum);
                        }
                    }
                    else if (line.Contains("<FreeMode>"))
                    {
                        bool bTest = false;
                        if (line.Contains("true"))
                            bTest = true;
                        MyConverstion[iMyConvert].FreeMode = bTest;
                    }
                    else if (line.Contains("<XshapeFirstID>"))
                    {
                        int iNum = line.LastIndexOf("<XshapeFirstID>") + 15;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 16);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].MyFaces.XshapeFirstID = iSum;
                    }
                    else if (line.Contains("<XshapeSecondID>"))
                    {
                        int iNum = line.LastIndexOf("<XshapeSecondID>") + 16;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 17);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].MyFaces.XshapeFirstID = iSum;
                    }
                    else if (line.Contains("<XshapeThirdID>"))
                    {
                        int iNum = line.LastIndexOf("<XshapeThirdID>") + 15;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 16);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].MyFaces.XshapeFirstID = iSum;
                    }
                    else if (line.Contains("<XskinFirstID>"))
                    {
                        int iNum = line.LastIndexOf("<XskinFirstID>") + 14;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 15);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].MyFaces.XshapeFirstID = iSum;
                    }
                    else if (line.Contains("<XskinSecondID>"))
                    {
                        int iNum = line.LastIndexOf("<XskinSecondID>") + 15;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 16);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].MyFaces.XshapeFirstID = iSum;
                    }
                    else if (line.Contains("<XskinThirdID>"))
                    {
                        int iNum = line.LastIndexOf("<XskinThirdID>") + 14;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 15);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].MyFaces.XshapeFirstID = iSum;
                    }
                    else if (line.Contains("<XshapeMix>"))
                    {
                        int iNum = line.LastIndexOf("<XshapeMix>") + 11;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 12);
                        float fSum = (float)Convert.ToDecimal(line);
                        MyConverstion[iMyConvert].MyFaces.XshapeMix = fSum;
                    }
                    else if (line.Contains("<XskinMix>"))
                    {
                        int iNum = line.LastIndexOf("<XskinMix>") + 10;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 11);
                        float fSum = (float)Convert.ToDecimal(line);
                        MyConverstion[iMyConvert].MyFaces.XskinMix = fSum;
                    }
                    else if (line.Contains("<XthirdMix>"))
                    {
                        int iNum = line.LastIndexOf("<XthirdMix>") + 11;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 12);
                        float fSum = (float)Convert.ToDecimal(line);
                        MyConverstion[iMyConvert].MyFaces.XthirdMix = fSum;
                    }
                    else if (line.Contains("<XisParent>"))
                    {
                        int iNum = line.LastIndexOf("<XisParent>") + 11;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 12);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].MyFaces.XisParent = iSum;
                    }
                    else if (line.Contains("<HairColour>"))
                    {
                        int iNum = line.LastIndexOf("<HairColour>") + 12;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 13);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].HairColour = iSum;
                    }
                    else if (line.Contains("<HairStreaks>"))
                    {
                        int iNum = line.LastIndexOf("<HairStreaks>") + 13;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 14);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].HairStreaks = iSum;
                    }
                    else if (line.Contains("<EyeColour>"))
                    {
                        int iNum = line.LastIndexOf("<EyeColour>") + 11;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 12);
                        int iSum = (int)Convert.ToInt32(line);
                        MyConverstion[iMyConvert].EyeColour = iSum;
                    }
                    else if (line.Contains("<Overlay>"))
                    {
                        iListBuild = 5;
                    }
                    else if (iListBuild == 5)
                    {
                        if (line.Contains("</Overlay>"))
                        {
                            iListBuild = 0;
                            iMidPart = -1;
                        }
                        else
                        {
                            int iNum = line.LastIndexOf("<int>") + 5;
                            line = line.Substring(iNum);
                            line = line.Remove(line.Count() - 6);
                            int iSum = (int)Convert.ToInt32(line);
                            MyConverstion[iMyConvert].MyOverlay.Add(new FreeOverLay());
                            MyConverstion[iMyConvert].MyOverlay[MyConverstion[iMyConvert].MyOverlay.Count - 1].Overlay = iSum;
                        }
                    }
                    else if (line.Contains("<OverlayColour>"))
                    {
                        iListBuild = 6;
                    }
                    else if (iListBuild == 6)
                    {
                        if (line.Contains("</OverlayColour>"))
                        {
                            iListBuild = 0;
                            iMidPart = -1;
                        }
                        else
                        {
                            iMidPart++;
                            int iNum = line.LastIndexOf("<int>") + 5;
                            line = line.Substring(iNum);
                            line = line.Remove(line.Count() - 6);
                            int iSum = (int)Convert.ToInt32(line);
                            MyConverstion[iMyConvert].MyOverlay[iMidPart].OverCol = iSum;
                        }
                    }
                    else if (line.Contains("<OverlayOpc>"))
                    {
                        iListBuild = 7;
                    }
                    else if (iListBuild == 7)
                    {
                        if (line.Contains("</OverlayOpc>"))
                            iListBuild = 0;
                        else
                        {
                            iMidPart++;
                            int iNum = line.LastIndexOf("<float>") + 7;
                            line = line.Substring(iNum);
                            line = line.Remove(line.Count() - 8);
                            float fSum = (float)Convert.ToDecimal(line);
                            MyConverstion[iMyConvert].MyOverlay[iMidPart].OverOpc = fSum;
                        }
                    }
                    else if (line.Contains("<Tattoo_COl>"))
                    {
                        iListBuild = 8;
                    }
                    else if (iListBuild == 8)
                    {
                        if (line.Contains("</Tattoo_COl>"))
                        {
                            iListBuild = 0;
                            iMidPart = -1;
                        }
                        else
                        {
                            int iNum = line.LastIndexOf("<string>") + 8;
                            line = line.Substring(iNum);
                            line = line.Remove(line.Count() - 9);
                            MyConverstion[iMyConvert].MyTattoo.Add(new Tattoo());
                            MyConverstion[iMyConvert].MyTattoo[MyConverstion[iMyConvert].MyTattoo.Count - 1].Name = "";
                            MyConverstion[iMyConvert].MyTattoo[MyConverstion[iMyConvert].MyTattoo.Count - 1].BaseName = line;
                        }
                    }
                    else if (line.Contains("<Tattoo_Nam>"))
                    {
                        iListBuild = 9;
                    }
                    else if (iListBuild == 9)
                    {
                        if (line.Contains("</Tattoo_Nam>"))
                            iListBuild = 0;
                        else
                        {
                            iMidPart++;
                            int iNum = line.LastIndexOf("<string>") + 8;
                            line = line.Substring(iNum);
                            line = line.Remove(line.Count() - 9);
                            MyConverstion[iMyConvert].MyTattoo[iMidPart].TatName = line;
                        }
                    }
                    else if (line.Contains("<FaceScale>"))
                    {
                        iListBuild = 10;
                    }
                    else if (iListBuild == 10)
                    {
                        if (line.Contains("</FaceScale>"))
                            iListBuild = 0;
                        else
                        {
                            int iNum = line.LastIndexOf("<float>") + 7;
                            line = line.Substring(iNum);
                            line = line.Remove(line.Count() - 8);
                            float fSum = (float)Convert.ToDecimal(line);
                            MyConverstion[iMyConvert].FaceScale.Add(fSum);
                        }
                    }
                    else if (line.Contains("<PedVoice>"))
                    {
                        int iNum = line.LastIndexOf("<PedVoice>") + 10;
                        line = line.Substring(iNum);
                        line = line.Remove(line.Count() - 11);
                        MyConverstion[iMyConvert].PedVoice = line;
                    }
                }
            }

            return MyConverstion;
        }
        public static List<string> LoadStringList(string fileName)
        {
            LoggerLight.Loggers("LoadLang == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<string>));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (List<string>)xml.Deserialize(sr);
                }
            }
            catch
            {
                return new List<string>();
            }
        }
        public static SettingsXML LoadSettings(string fileName)
        {
            LoggerLight.Loggers("LoadSettings == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(SettingsXML));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (SettingsXML)xml.Deserialize(sr);
                }
            }
            catch
            {
                return WriteSetXML();
            }
        }
        public static WeaponsXML LoadWeaps(string fileName)
        {
            LoggerLight.Loggers("LoadWeaps == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(WeaponsXML));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (WeaponsXML)xml.Deserialize(sr);
                }
            }
            catch
            {
                return new WeaponsXML();
            }
        }
        public static NameList LoadNames(string fileName)
        {
            LoggerLight.Loggers("LoadNames == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(NameList));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (NameList)xml.Deserialize(sr);
                }
            }
            catch
            {
                return Named();
            }
        }
        public static List<ClothBank> LoadChars(string fileName)
        {
            LoggerLight.Loggers("LoadChars == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<ClothBank>));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (List<ClothBank>)xml.Deserialize(sr);
                }
            }
            catch
            {
                return new List<ClothBank>();
            }
        }
        public static void SaveNames(NameList config, string fileName)
        {
            LoggerLight.Loggers("SaveNames == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(NameList));
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    xml.Serialize(sw, config);
                }
            }
            catch
            {
                LoggerLight.Loggers("SaveNames failed");
            }
        }
        public static void SaveWeaps(WeaponsXML config, string fileName)
        {
            LoggerLight.Loggers("SaveWeaps == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(WeaponsXML));
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    xml.Serialize(sw, config);
                }
            }
            catch
            {
                LoggerLight.Loggers("SaveWeaps failed");
            }
        }
        public static void SaveSetMain(SettingsXML config, string fileName)
        {
            LoggerLight.Loggers("SaveSetMain == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(SettingsXML));
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    xml.Serialize(sw, config);
                }
            }
            catch
            {
                LoggerLight.Loggers("SaveSetMain failed");
            }
        }
        public static void SaveChars(List<ClothBank> config, string fileName)
        {
            LoggerLight.Loggers("SaveChars == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<ClothBank>));
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    xml.Serialize(sw, config);
                }
            }
            catch
            {
                LoggerLight.Loggers("SaveChars failed");
            }
        }
        public static void SaveStringList(List<string> config, string fileName)
        {
            LoggerLight.Loggers("SaveStringList == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<string>));
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    xml.Serialize(sw, config);
                }
            }
            catch
            {
                LoggerLight.Loggers("SaveStringList failed");
            }
        }
        public static SettingsXML WriteSetXML()
        {
            LoggerLight.Loggers("XmlReadWrite.WriteSetXML");
            SettingsXML MySet = new SettingsXML
            {
                MenuKey = Keys.L,
                Spawn = false,
                Locate = true,
                Saved = false,
                DisableRecord = false,
                KeepWeapons = false,
                BeltUp = false,
                Version = 0,
                LangSupport = 0,
                Reincarn = false,
                ReCritter = true,
                ReCurr = false,
                ReSave = false,
                YourWeaps = DataStore.GetWeaps(),
                BeachPart = true,
                ControlSupport = false,
                ControlA = 47,
                ControlB = 21,
                BeachPed = true,
                Tramps = true,
                Highclass = true,
                Midclass = true,
                Lowclass = true,
                Business = true,
                Bodybuilder = true,
                GangStars = true,
                Epsilon = true,
                Jogger = true,
                Golfer = true,
                Hiker = true,
                Methaddict = true,
                Rural = true,
                Cyclist = true,
                LGBTWXYZ = true,
                PoolPeds = true,
                Workers = true,
                Jetski = true,
                BikeATV = true,
                Services = true,
                Pilot = true,
                Animals = true,
                Yankton = true,
                Cayo = true,
            };

            return MySet;
        }
        public static NameList Named()
        {
            LoggerLight.Loggers("XmlReadWrite.NamesList");

            NameList XNames = new NameList();

            XNames.FemaleName.Add("Cherry");
            XNames.FemaleName.Add("Delora");
            XNames.FemaleName.Add("Angelic");
            XNames.FemaleName.Add("Jerica");
            XNames.FemaleName.Add("Dianne");
            XNames.FemaleName.Add("Nikia");
            XNames.FemaleName.Add("Fay");
            XNames.FemaleName.Add("Lasonya");
            XNames.FemaleName.Add("Camille");
            XNames.FemaleName.Add("Kiara");
            XNames.FemaleName.Add("Margene");
            XNames.FemaleName.Add("Nery");
            XNames.FemaleName.Add("Robbi");
            XNames.FemaleName.Add("Charla");
            XNames.FemaleName.Add("Rina");
            XNames.FemaleName.Add("Crystle");
            XNames.FemaleName.Add("Kandi");
            XNames.FemaleName.Add("Jonelle");
            XNames.FemaleName.Add("Terese");
            XNames.FemaleName.Add("Obdulia");
            XNames.FemaleName.Add("Maricela");
            XNames.FemaleName.Add("Jacquie");
            XNames.FemaleName.Add("Davine");
            XNames.FemaleName.Add("Minna");
            XNames.FemaleName.Add("Brianne");
            XNames.FemaleName.Add("Pinkie");
            XNames.FemaleName.Add("Rosalina");
            XNames.FemaleName.Add("Nadene");
            XNames.FemaleName.Add("Loida");
            XNames.FemaleName.Add("Kristal");
            XNames.FemaleName.Add("Ramonita");
            XNames.FemaleName.Add("Ula");
            XNames.FemaleName.Add("Windy");
            XNames.FemaleName.Add("Zulema");
            XNames.FemaleName.Add("Marci");
            XNames.FemaleName.Add("Sabra");
            XNames.FemaleName.Add("Kyong");
            XNames.FemaleName.Add("Johnsie");
            XNames.FemaleName.Add("Digna");
            XNames.FemaleName.Add("Hattie");
            XNames.FemaleName.Add("Shirly");
            XNames.FemaleName.Add("Winifred");
            XNames.FemaleName.Add("Magen");
            XNames.FemaleName.Add("Cammy");
            XNames.FemaleName.Add("Sherill");
            XNames.FemaleName.Add("Josephina");
            XNames.FemaleName.Add("Chara");
            XNames.FemaleName.Add("Suzi");
            XNames.FemaleName.Add("Annabelle");
            XNames.FemaleName.Add("Bronwyn");

            XNames.MaleName.Add("Werner");
            XNames.MaleName.Add("Wilbur");
            XNames.MaleName.Add("Blake");
            XNames.MaleName.Add("Grover");
            XNames.MaleName.Add("Jimmy");
            XNames.MaleName.Add("Jamison");
            XNames.MaleName.Add("Josiah");
            XNames.MaleName.Add("Miquel");
            XNames.MaleName.Add("Rupert");
            XNames.MaleName.Add("Christoper");
            XNames.MaleName.Add("Alphonso");
            XNames.MaleName.Add("Malik");
            XNames.MaleName.Add("Korey");
            XNames.MaleName.Add("Jess");
            XNames.MaleName.Add("Dewitt");
            XNames.MaleName.Add("Marquis");
            XNames.MaleName.Add("Mckinley");
            XNames.MaleName.Add("Deshawn");
            XNames.MaleName.Add("Thaddeus");
            XNames.MaleName.Add("Colin");
            XNames.MaleName.Add("Chester");
            XNames.MaleName.Add("Jeremiah");
            XNames.MaleName.Add("Casey");
            XNames.MaleName.Add("Ray");
            XNames.MaleName.Add("Tyron");
            XNames.MaleName.Add("Darron");
            XNames.MaleName.Add("Sylvester");
            XNames.MaleName.Add("Joshua");
            XNames.MaleName.Add("Lenard");
            XNames.MaleName.Add("Leon");
            XNames.MaleName.Add("Son");
            XNames.MaleName.Add("Willis");
            XNames.MaleName.Add("Thurman");
            XNames.MaleName.Add("Noah");
            XNames.MaleName.Add("Josh");
            XNames.MaleName.Add("Sherwood");
            XNames.MaleName.Add("Trey");
            XNames.MaleName.Add("Parker");
            XNames.MaleName.Add("Adalberto");
            XNames.MaleName.Add("Benton");
            XNames.MaleName.Add("Harlan");
            XNames.MaleName.Add("Santos");
            XNames.MaleName.Add("Abraham");
            XNames.MaleName.Add("Moshe");
            XNames.MaleName.Add("Vaughn");
            XNames.MaleName.Add("Quincy");
            XNames.MaleName.Add("Titus");
            XNames.MaleName.Add("Gino");
            XNames.MaleName.Add("Earle");
            XNames.MaleName.Add("Alfonso");

            XNames.SurnName.Add("Agee");
            XNames.SurnName.Add("Hillyer");
            XNames.SurnName.Add("Elie");
            XNames.SurnName.Add("Morrow");
            XNames.SurnName.Add("Wulff");
            XNames.SurnName.Add("Pollan");
            XNames.SurnName.Add("Zieman");
            XNames.SurnName.Add("Welborn");
            XNames.SurnName.Add("Ikeda");
            XNames.SurnName.Add("Mclead");
            XNames.SurnName.Add("Delmonte");
            XNames.SurnName.Add("Eble");
            XNames.SurnName.Add("Beitz");
            XNames.SurnName.Add("Northup");
            XNames.SurnName.Add("Wren");
            XNames.SurnName.Add("Therrien");
            XNames.SurnName.Add("Chitty");
            XNames.SurnName.Add("Bungard");
            XNames.SurnName.Add("Perrella");
            XNames.SurnName.Add("Roselli");
            XNames.SurnName.Add("Million");
            XNames.SurnName.Add("Winder");
            XNames.SurnName.Add("Jaynes");
            XNames.SurnName.Add("Smalling");
            XNames.SurnName.Add("Vito");
            XNames.SurnName.Add("Sabbagh");
            XNames.SurnName.Add("Patenaude");
            XNames.SurnName.Add("Hepburn");
            XNames.SurnName.Add("Lally");
            XNames.SurnName.Add("Fenster");
            XNames.SurnName.Add("Carlen");
            XNames.SurnName.Add("Perri");
            XNames.SurnName.Add("Doepke");
            XNames.SurnName.Add("Livengood");
            XNames.SurnName.Add("Micheal");
            XNames.SurnName.Add("Vanderburg");
            XNames.SurnName.Add("Ringwood");
            XNames.SurnName.Add("Semon");
            XNames.SurnName.Add("Kauffman");
            XNames.SurnName.Add("Frost");
            XNames.SurnName.Add("Simerly");
            XNames.SurnName.Add("Holbrook");
            XNames.SurnName.Add("Waechter");
            XNames.SurnName.Add("Bergstrom");
            XNames.SurnName.Add("Brisker");
            XNames.SurnName.Add("Orwig");
            XNames.SurnName.Add("Gullatt");
            XNames.SurnName.Add("Keifer");
            XNames.SurnName.Add("Rozman");
            XNames.SurnName.Add("Munger");

            SaveNames(XNames, DataStore.sNamesFile);

            return XNames;
        }
        public static void LoadupWeaponXML()
        {
            LoggerLight.Loggers("LoadupWeaponXML");

            if (File.Exists(DataStore.sWeapsFile))
            {
                WeaponsXML WeapsXML = LoadWeaps(DataStore.sWeapsFile);

                for (int i = 0; i < WeapsXML.WeaponsList.Count; i++)
                {
                    if (WeapsXML.WeaponsList[i] != "Add_Your_Custom_Weapons_Here")
                        DataStore.sWeapList.Add(WeapsXML.WeaponsList[i]);
                }

                for (int i = 0; i < WeapsXML.AttachmentsList.Count; i++)
                {
                    if (WeapsXML.AttachmentsList[i] != "Add_Your_Custom_Attachments_Here")
                        DataStore.sAddsList.Add(WeapsXML.AttachmentsList[i]);
                }
            }
            else
                BuildWeapXML();
        }
        public static void BuildWeapXML()
        {
            LoggerLight.Loggers("BuildWeapXML");

            List<string> sWepList = new List<string>();
            sWepList.Add("Add_Your_Custom_Weapons_Here");

            List<string> sAttList = new List<string>();
            sAttList.Add("Add_Your_Custom_Attachments_Here");

            WeaponsXML MyWeapsXML = new WeaponsXML
            {
                WeaponsList = sWepList,
                AttachmentsList = sAttList
            };

            SaveWeaps(MyWeapsXML, DataStore.sWeapsFile);
        }
    }
}
