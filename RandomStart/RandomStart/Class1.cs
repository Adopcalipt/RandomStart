
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Windows.Forms;
using NativeUI;
using GTA;
using GTA.Math;
using GTA.Native;
using System.Runtime.InteropServices;

//The Face blend data This part was from  E66666666/LeeC_HBD.cs, https://gist.github.com/E66666666/466c59df7aff69d2ac788fa38e669300
public static class SHVNative
{
    // These are borrowed from ScriptHookVDotNet's 
    [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?nativeInit@@YAX_K@Z")]
    static extern void NativeInit(ulong hash);

    [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?nativePush64@@YAX_K@Z")]
    static extern void NativePush64(ulong val);

    [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?nativeCall@@YAPEA_KXZ")]
    static extern unsafe ulong* NativeCall();

    // These are from ScriptHookV's nativeCaller.h
    static unsafe void nativePush<T>(T val) where T : unmanaged
    {
        ulong val64 = 0;
        *(T*)(&val64) = val;
        NativePush64(val64);
    }

    public static unsafe R invoke<R>(ulong hash) where R : unmanaged
    {
        NativeInit(hash);
        return *(R*)(NativeCall());
    }

    // Apparently this works, but might be less efficient than C++'s variadic things
    public static unsafe R invoke<R>(ulong hash, params dynamic[] args)
        where R : unmanaged
    {
        NativeInit(hash);

        foreach (var arg in args)
            nativePush(arg);

        return *(R*)(NativeCall());
    }
}
namespace RandomStart
{
    public class Main : Script
    {
        private int iEye = 0;
        private int iPath = 0;
        private int iWait4 = 0;
        private int iHair01 = 0;
        private int iHair02 = 0;
        private int iUnlock = 0;
        private int iPedNum = 0;
        private int iVersion = 0;
        private int iGrouping = 0;
        private int iPostAction = 0;
        private int iActionTime = 0;
        private int iAmModelHash = 0;
        private int iLangSupport = -1;

        private readonly int PlayerGroups = Game.Player.Character.RelationshipGroup;
        private readonly int FriendlyNPCs = World.AddRelationshipGroup("FriendNPCs");
        private readonly int AttackingNPCs = World.AddRelationshipGroup("AttackNPCs");

        private bool bStart = true;
        private bool bRandLocate = true;

        private bool bMale = false;
        private bool bDead = false;
        private bool bFound = false;
        private bool bLoaded = false;
        private bool bBeltUp = false;
        private bool bSavedPed = false;
        private bool bMenyooZZ = false;
        private bool bEnhanceT = false;
        private bool bPrisHeli = false;
        private bool bMethFail = false;
        private bool bMenuOpen = false;
        private bool bFallenOff = false;
        private bool bOpenDoors = false;
        private bool bInYankton = false;
        private bool bKeyFinder = false;
        private bool bMethActor = false;
        private bool bDontStopMe = false;
        private bool bMainProtag = false;
        private bool bWeaponFault = false;
        private bool bKeepWeapons = false;
        private bool bAllowControl = false;
        private bool bInCayoPerico = false;
        private bool bAddBeachParty = true;
        private bool bDisableDLCVeh = true;
        private bool bDisableRecord = false;
        private bool bLoadUpOnYacht = false;
        private bool bPlayingNewMissions = false;


        private readonly string sVersion = "2.3";
        private string sFirstName = "PlayerX";
        private string sMainChar = "player_zero";
        private string sFunChar01 = "player_one";
        private string sFunChar02 = "player_two";
        private readonly string sBeeLogs = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RSLog.txt";
        private readonly string sSettings = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RSettings.Xml";
        private readonly string sLangsFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStartLang.Xml";
        private readonly string sWeapsFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/AddonWeaponList.Xml";
        private readonly string sNamesFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/NamingList.Xml";
        private readonly string sRandFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RSRNum.Xml";
        private readonly string sSavedFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/SavedPedsList.Xml";
        private readonly string sRandLanguage = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language";

        private string sExitAn_01 = "";
        private string sExitAn_02 = "";
        private string sPedVoices = "";

        private List<int> iOverlay = new List<int>();
        private List<int> iOverlayColour = new List<int>();

        private List<bool> bRandList = new List<bool>();

        private List<float> fHeads = new List<float>();
        private List<float> fOverlayOpc = new List<float>();
        private List<float> fAceFeats = new List<float>();

        private List<string> sNameFem = new List<string>();
        private List<string> sNameMal = new List<string>();
        private List<string> sNameSir = new List<string>();
        private List<string> sLangfile = new List<string>();
        private List<string> sWeapList = new List<string>();
        private List<string> sAddsList = new List<string>();
        private List<string> sDebuggler = new List<string>();
        private List<string> sTatBase = new List<string>();
        private List<string> sTatName = new List<string>();
        private List<string> AddTatBase = new List<string>();
        private List<string> AddTatName = new List<string>();
        private List<string> ThemVoices = new List<string>();

        private List<Ped> PeddyList = new List<Ped>();
        private List<Ped> PedParty = new List<Ped>();
        private List<Prop> PropList = new List<Prop>();
        private List<Vector3> RanLoc_01 = new List<Vector3>();
        private List<Vector3> PeskyDoors = new List<Vector3>();
        private List<Vehicle> VehList = new List<Vehicle>();
        private List<Weather> WetherBe = new List<Weather>();
        private List<VehicleSeat> Vseats = new List<VehicleSeat>();
        private List<NewClothBank> MyPedCollection = new List<NewClothBank>();

        private List<int> SABlipsAlfa = new List<int>();
        private List<bool> SABlipsMiniM = new List<bool>();
        private List<Vector3> SABlipsPos = new List<Vector3>();
        private List<BlipColor> SABlipsColor = new List<BlipColor>();
        private List<BlipSprite> SABlipsSCA = new List<BlipSprite>();
        private List<WeaponSaver> wMyWeaps = new List<WeaponSaver>();

        private Vector3 vPedTarget = Vector3.Zero;
        private Vector3 vPlayerTarget = Vector3.Zero;
        private Vector3 vAreaRest = Vector3.Zero;
        private Vector3 vHeaven = Vector3.Zero;

        private Ped pPilot = null;

        private Relationship RelateReset = Relationship.Neutral;

        private Keys KBuild = Keys.L;

        private Vehicle Shoaf = null;
        private Vehicle RideThis = null;
        private Vehicle PrisEscape = null;

        private ScriptSettings MenyooTest;

        private MenuPool MyMenuPool;

        public Main()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            Interval = 1;
        }
        private void LogginSyatem(string sLog)
        {
            using (StreamWriter tEx = File.AppendText(sBeeLogs))
                BeLogs(sLog, tEx);
        }
        private void BeLogs(string sLogs, TextWriter tEx)
        {
            tEx.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} {"--" + sLogs}");
        }
        private void CleanUpMess()
        {
            LogginSyatem("CleanUpMess");

            while (Game.IsControlPressed(2, GTA.Control.VehicleExit))
                Script.Wait(100);

            Game.EnableControlThisFrame(2, GTA.Control.VehicleExit);

            Shoaf = null;
            pPilot = null;
            RideThis = null;
            //Function.Call(Hash.SET_AI_MELEE_WEAPON_DAMAGE_MODIFIER, 1.00f);
            bFallenOff = false;
            bAllowControl = false;
            if (iPostAction > 0)
                PostLaunchAct();

            if (!Game.Player.Character.IsInVehicle())
            {
                Game.Player.Character.HasCollision = true;
                Game.Player.Character.FreezePosition = false;
            }
            if (Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Trevor)
            {
                Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "director_mode");
                Game.Player.Character.Task.ClearAll();
            }
            vPedTarget = new Vector3(0.00f, 0.00f, 0.00f);
            vPlayerTarget = new Vector3(0.00f, 0.00f, 0.00f);
            vAreaRest = new Vector3(0.00f, 0.00f, 0.00f);
            vHeaven = new Vector3(0.00f, 0.00f, 0.00f);
            sExitAn_01 = "";
            sExitAn_02 = "";
            RanLoc_01.Clear();
            CleanPeds();
            CleanProps();
            CleanVeh();
        }
        private void PostLaunchAct()
        {
            LogginSyatem("PostLaunchAct, iPostAction == " + iPostAction);

            if (iPostAction == 1)
            {
                Game.Player.Character.Task.ClearAll();
            }       //Player Driving/Flying
            else if (iPostAction == 2)
            {
                if (sExitAn_01 != "")
                {
                    ForceAnimOnce(Game.Player.Character, sExitAn_01, sExitAn_02, Game.Player.Character.Position, Game.Player.Character.Rotation);
                    Game.Player.Character.Detach();
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Game.Player.Character, 134))
                        Script.Wait(100);
                    Function.Call(Hash.STOP_ANIM_PLAYBACK, Game.Player.Character, 0, 0);
                    //Game.Player.Character.Task.ClearAllImmediately();
                }
                else
                    Game.Player.Character.Task.ClearAll();
            }       //Player Animation
            else if (iPostAction == 3)
            {
                if (iGrouping == 1)
                {
                    World.SetRelationshipBetweenGroups(RelateReset, PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_BALLAS"));
                    World.SetRelationshipBetweenGroups(RelateReset, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_BALLAS"), PlayerGroups);
                }
                else if (iGrouping == 2)
                {
                    World.SetRelationshipBetweenGroups(RelateReset, PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_FAMILY"));
                    World.SetRelationshipBetweenGroups(RelateReset, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_FAMILY"), PlayerGroups);
                }
                else if (iGrouping == 3)
                {
                    World.SetRelationshipBetweenGroups(RelateReset, PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_MEXICAN"));
                    World.SetRelationshipBetweenGroups(RelateReset, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_MEXICAN"), PlayerGroups);
                }
                else if (iGrouping == 4)
                {
                    World.SetRelationshipBetweenGroups(RelateReset, PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_SALVA"));
                    World.SetRelationshipBetweenGroups(RelateReset, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_SALVA"), PlayerGroups);
                }
                else if (iGrouping == 5)
                {
                    World.SetRelationshipBetweenGroups(RelateReset, PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_LOST"));
                    World.SetRelationshipBetweenGroups(RelateReset, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_LOST"), PlayerGroups);
                }
                iGrouping = 0;
            }       //GangStar
            else if (iPostAction == 4)
            {
                PedScenario(Game.Player.Character, "WORLD_HUMAN_JOG_STANDING", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                Script.Wait(4000);
                Game.Player.Character.Task.ClearAll();
            }       //jogger
            else
            {
                Game.Player.Character.Task.ClearAll();
            }       //Atv-Bike
            iPostAction = 0;
        }
        private void CleanPeds()
        {

            LogginSyatem("CleanPeds");

            for (int i = 0; i < PeddyList.Count; i++)
                PeddyList[i].MarkAsNoLongerNeeded();
            PeddyList.Clear();
        }
        private void CleanProps()
        {

            LogginSyatem("CleanProps");

            for (int i = 0; i < PropList.Count; i++)
            {
                PropList[i].Detach();
                PropList[i].MarkAsNoLongerNeeded();
            }
            PropList.Clear();
        }
        private void CleanVeh()
        {

            LogginSyatem("CleanVeh");

            for (int i = 0; i < VehList.Count; i++)
            {
                VehList[i].IsPersistent = false;
                VehList[i].MarkAsNoLongerNeeded();
            }
            VehList.Clear();
        }
        private void LockNLoad(int iAmmo, string sWeap, Ped Peddy)
        {
            Function.Call<bool>(Hash.SET_AMMO_IN_CLIP, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), Function.Call<int>(Hash.GET_MAX_AMMO_IN_CLIP, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), false));
            Function.Call(Hash.SET_PED_AMMO, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), iAmmo);
        }
        public int Mk2AmmoFix(string sWeapo)
        {
            int iAmmo = 0;
            Ped Peddy = Game.Player.Character;
            int iWeap = Function.Call<int>(Hash.GET_HASH_KEY, sWeapo);

            unsafe
            {
                Function.Call<bool>(Hash.GET_MAX_AMMO, Peddy.Handle, iWeap, &iAmmo);
            }

            return iAmmo;
        }
        public class SettingsXML
        {
            public Keys MenuKey { get; set; }
            public bool Locate { get; set; }
            public bool Spawn { get; set; }
            public bool Saved { get; set; }
            public bool DisableRecord { get; set; }
            public bool KeepWeapons { get; set; }
            public bool BeltUp { get; set; }
            public int Version { get; set; }
            public int LangSupport { get; set; }
            public List<WeaponSaver> YourWeaps { get; set;}

            public SettingsXML()
            {
                YourWeaps = new List<WeaponSaver>();
            }
        }
        public SettingsXML LoadSettings(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(SettingsXML));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (SettingsXML)xml.Deserialize(sr);
            }
        }
        public void SaveSetMain(SettingsXML config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(SettingsXML));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        private void LoadSetXML()
        {
            LogginSyatem("LoadSetXML");
            bool bNagg = false;
            if (File.Exists(sSettings))
            {
                SettingsXML SetsXML = LoadSettings(sSettings);
                KBuild = SetsXML.MenuKey;
                bMainProtag = SetsXML.Spawn;
                bRandLocate = SetsXML.Locate;
                bSavedPed = SetsXML.Saved;
                bDisableRecord = SetsXML.DisableRecord;
                bKeepWeapons = SetsXML.KeepWeapons;

                iVersion = SetsXML.Version;

                bBeltUp = SetsXML.BeltUp;
                PlayerBelter();

                if (bMainProtag && bSavedPed)
                {
                    bMainProtag = false;
                    bSavedPed = false;
                }

                if (bRandLocate && bLoadUpOnYacht)
                    bRandLocate = false;

                if (iVersion != 23000)
                    bNagg = true;
                else
                {
                    iLangSupport = SetsXML.LangSupport;
                    wMyWeaps = SetsXML.YourWeaps;
                }
            }
            else
                bNagg = true;

            FindaLang();

            if (bNagg)
                NagScreen();

            if (wMyWeaps.Count < 1)
                GetWeaps();
        }
        private void NagScreen()
        {
            UI.Notify(sLangfile[0]);
            iVersion = 23000;
            WriteSetXML();
        }
        private void WriteSetXML()
        {
            LogginSyatem("WriteSetXML");

            if (KBuild == Keys.None)
                KBuild = Keys.L;

            SettingsXML Set = new SettingsXML();

            Set.MenuKey = KBuild;
            Set.Spawn = bMainProtag;
            Set.Locate = bRandLocate;
            Set.Saved = bSavedPed;
            Set.DisableRecord = bDisableRecord;
            Set.KeepWeapons = bKeepWeapons;
            Set.BeltUp = bBeltUp;
            Set.Version = iVersion;
            Set.LangSupport = iLangSupport;
            Set.YourWeaps = wMyWeaps;
            SaveSetMain(Set, sSettings);
        }
        public class LangXML
        {
            public List<string> Langfile { get; set; }

            public LangXML()
            {
                Langfile = new List<string>();
            }
        }
        public LangXML LoadLang(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(LangXML));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (LangXML)xml.Deserialize(sr);
            }
        }
        public void OutPutLang(LangXML config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(LangXML));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        private void Languages()
        {
            LogginSyatem("Languages");

            sLangfile.Clear();
            sLangfile.Add("If you didn't download this file from 'gta5-mods.com' then delete it and download the original from 'gta5-mods.com/scripts/random-start-adopcalipt'");     //0
            sLangfile.Add("Save XML Invalid");      //1
            sLangfile.Add("We are here today to mourn the loss of ");      //2
            sLangfile.Add(". He will be missed by his three friends Trevor, Michael and Franklin.");      //3
            sLangfile.Add(". She will be missed by her three friends Trevor, Michael and Franklin.");      //4
            sLangfile.Add("You have been sentenced to 150 years hard labor...");      //5
            sLangfile.Add("Random Start");      //6
            sLangfile.Add("blank");              //7
            sLangfile.Add("Set ped options");      //8
            sLangfile.Add("Hair Colour");      //9
            sLangfile.Add("Hair Streaks");      //10
            sLangfile.Add("Eye Colour");      //11
            sLangfile.Add("Set overlay options");      //12
            sLangfile.Add("Blemishes");      //13
            sLangfile.Add("Facial Hair");      //14
            sLangfile.Add("Eyebrows");      //15
            sLangfile.Add("Ageing");      //16
            sLangfile.Add("Makeup");      //17
            sLangfile.Add("Blush");      //18
            sLangfile.Add("Complexion");      //19
            sLangfile.Add("Sun Damage");      //20
            sLangfile.Add("Lipstick");      //21
            sLangfile.Add("Moles");      //22
            sLangfile.Add("Chest Hair");      //23
            sLangfile.Add("Body Blemishes");      //24
            sLangfile.Add(" Opacity");      //25
            sLangfile.Add(" Colour");      //26
            sLangfile.Add("Set component options");      //27
            sLangfile.Add("Head");      //28
            sLangfile.Add("Beard");      //29
            sLangfile.Add("Hair");      //30
            sLangfile.Add("Torso");      //31
            sLangfile.Add("Legs");      //32 
            sLangfile.Add("Parachute");      //33
            sLangfile.Add("Shoes");      //34
            sLangfile.Add("Accessories");      //35
            sLangfile.Add("Shirts-Tops-Accessories");      //36
            sLangfile.Add("Armor");      //37
            sLangfile.Add("Decals");      //38
            sLangfile.Add("Shirts-Jackets-Tops");      //39
            sLangfile.Add(" Texture");      //40
            sLangfile.Add("Set prop options");      //41
            sLangfile.Add("Hats");      //42
            sLangfile.Add("Glasses");      //43
            sLangfile.Add("Earrings");      //44
            sLangfile.Add("Watches");      //45
            sLangfile.Add("Default Ped");      //46
            sLangfile.Add("Reset Ped to Default.");      //47
            sLangfile.Add("Save Current Ped.");      //48
            sLangfile.Add("Make a new ped save file.");      //49
            sLangfile.Add("Saved");      //50
            sLangfile.Add("Random Location");      //51
            sLangfile.Add("Set if you would like to load into a random place time and weather");      //52
            sLangfile.Add("Use Default Ped");      //53
            sLangfile.Add("Set if you would like to load in as Michael,Franklin or Trevor.");      //54
            sLangfile.Add("Disable Action Replay");      //55
            sLangfile.Add("When using a controller action replay can start randomly this disables it.");      //56
            sLangfile.Add("Use Saved Ped");      //57
            sLangfile.Add("Set if you would like to load in as your saved ped.");      //58
            sLangfile.Add("Keep Weapons");      //59
            sLangfile.Add("Use your default weapon loadout.");      //60
            sLangfile.Add("Change Menu Key");      //61
            sLangfile.Add("Select menu load key.");      //62
            sLangfile.Add("Press the key you would like to bind for the menu.");      //63
            sLangfile.Add("Delete Saved Ped");      //64
            sLangfile.Add("Deleted");      //65
            sLangfile.Add("Select a ped type");      //66
            sLangfile.Add("Beach Ped");      //67
            sLangfile.Add("Tramps");      //68
            sLangfile.Add("High class");      //69
            sLangfile.Add("Mid class");      //70
            sLangfile.Add("Low class");      //71
            sLangfile.Add("Business");      //72
            sLangfile.Add("Body builder");      //73
            sLangfile.Add("GangStars");      //74
            sLangfile.Add("Epsilon ");      //75
            sLangfile.Add("Jogger");      //76
            sLangfile.Add("Golfer");      //77
            sLangfile.Add("Hiker");      //78
            sLangfile.Add("Meth addict");      //79
            sLangfile.Add("Rural");      //80
            sLangfile.Add("Cyclist");      //81
            sLangfile.Add("LGBTWXYZ");      //82
            sLangfile.Add("Pool Peds");      //83
            sLangfile.Add("Workers");      //84
            sLangfile.Add("Jet ski");      //85
            sLangfile.Add("Bike/ATV");      //86
            sLangfile.Add("Services");      //87
            sLangfile.Add("Use 'save ped' option to keep these settings");      //88
            sLangfile.Add("Can't open while processing action try again in a few seconds.");      //89
            sLangfile.Add("Key has been selected.");      //90
            sLangfile.Add("blank");      //91
            sLangfile.Add("Hold ~INPUT_VEH_EXIT~ to take control");      //92
            sLangfile.Add("Pilot");      //93
            sLangfile.Add("Yankton");      //94
            sLangfile.Add("Cayo Perico");      //95
            sLangfile.Add("Seatbelt On");      //96
            sLangfile.Add("Cayo Perico Beach Party");      //97
            sLangfile.Add("Left/Right choice your save. Select to edit.");      //98
            sLangfile.Add("Back");      //99
            sLangfile.Add("Torso");      //100
            sLangfile.Add("Neck");      //101
            sLangfile.Add("Right Arm");      //102
            sLangfile.Add("Left Arm");      //103
            sLangfile.Add("Right Leg");      //104
            sLangfile.Add("Left Leg");      //105
            sLangfile.Add("Head");      //106
            sLangfile.Add("Hair");      //107
            sLangfile.Add("Remove All Tattoos");      //108
            sLangfile.Add("Tattoos");      //109
            sLangfile.Add("Chest");      //110
            sLangfile.Add("Stomach");      //111
            sLangfile.Add("New ");      //112
            sLangfile.Add("blank");      //113
            sLangfile.Add("Nose Width");      //114
            sLangfile.Add("Nose Peak Height");      //115
            sLangfile.Add("Nose Peak Length");      //116
            sLangfile.Add("Nose Bone High");      //117
            sLangfile.Add("Nose Peak Lowering");      //118
            sLangfile.Add("Nose Bone Twist");      //119
            sLangfile.Add("Eyebrow High");      //120
            sLangfile.Add("Eyebrow Forward");      //121
            sLangfile.Add("Cheekbone High");      //122
            sLangfile.Add("Cheekbone Width");      //123
            sLangfile.Add("Cheek Width");      //124
            sLangfile.Add("Eyes Opening");      //125
            sLangfile.Add("Lips Thickness");      //126
            sLangfile.Add("Jaw Bone Width");      //127
            sLangfile.Add("Jaw Bone Back Length");      //128
            sLangfile.Add("Chimp Bone Lowering");      //129
            sLangfile.Add("Chimp Bone Length");      //130
            sLangfile.Add("Chimp Bone Width");      //131
            sLangfile.Add("Chimp Hole");      //132
            sLangfile.Add("Neck Thickness");      //133
            sLangfile.Add("Face Features");      //134
            sLangfile.Add("Reset Owned Weapon List");      //135
            sLangfile.Add("blank");      //136
            sLangfile.Add("blank");      //137
            sLangfile.Add("blank");      //138
            sLangfile.Add("blank");      //139
            sLangfile.Add("blank");      //140

            //LangXML Mylang = new LangXML();
            //Mylang.Langfile = sLangfile;
            //OutPutLang(Mylang, "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStartLang.Xml");
        }
        private void FindaLang()
        {
            bool bNoLAng = true;
            LogginSyatem("LangReader");

            if (iLangSupport == -1)
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

            if (Directory.Exists(sRandLanguage))
            {
                if (iLangSupport == 1)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/English.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/English.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 2)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Chinese.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Chinese.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 3)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/ChineseS.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/ChineseS.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 4)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/French.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/French.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 5)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/German.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/German.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 6)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Italian.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Italian.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 7)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Japanese.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Japanese.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 8)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Korean.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Korean.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 9)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Mexican.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Mexican.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 10)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Polish.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Polish.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 11)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Portuguese.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Portuguese.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 12)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Russian.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Russian.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
                else if (iLangSupport == 13)
                {
                    if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Spanish.Xml"))
                    {
                        LangXML LangXML = LoadLang("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Spanish.Xml");
                        sLangfile = LangXML.Langfile;
                        bNoLAng = false;
                    }
                }
            }

            if (bNoLAng)
                Languages();
        }
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
        public WeaponsXML LoadWeaps(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(WeaponsXML));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (WeaponsXML)xml.Deserialize(sr);
            }
        }
        public void SaveWeaps(WeaponsXML config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(WeaponsXML));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        private void LoadupWeaponXML()
        {
            LogginSyatem("LoadupWeaponXML");

            if (File.Exists(sWeapsFile))
            {
                WeaponsXML WeapsXML = LoadWeaps(sWeapsFile);

                for (int i = 0; i < WeapsXML.WeaponsList.Count; i++)
                {
                    if (WeapsXML.WeaponsList[i] != "Add_Your_Custom_Weapons_Here")
                        sWeapList.Add(WeapsXML.WeaponsList[i]);
                }

                for (int i = 0; i < WeapsXML.AttachmentsList.Count; i++)
                {
                    if (WeapsXML.AttachmentsList[i] != "Add_Your_Custom_Attachments_Here")
                        sAddsList.Add(WeapsXML.AttachmentsList[i]);
                }
            }
            else
                BuildWeapXML();
        }
        private void BuildWeapXML()
        {

            LogginSyatem("BuildWeapXML");

            List<string> sWepList = new List<string>();
            sWepList.Add("Add_Your_Custom_Weapons_Here");

            List<string> sAttList = new List<string>();
            sAttList.Add("Add_Your_Custom_Attachments_Here");

            WeaponsXML MyWeapsXML = new WeaponsXML();

            MyWeapsXML.WeaponsList = sWepList;
            MyWeapsXML.AttachmentsList = sAttList;

            SaveWeaps(MyWeapsXML, sWeapsFile);
        }
        private void WeatherList()
        {
            WetherBe.Clear();
            WetherBe.Add(Weather.ExtraSunny);
            WetherBe.Add(Weather.Clear);
            WetherBe.Add(Weather.Clouds);
            WetherBe.Add(Weather.Smog);
            WetherBe.Add(Weather.Foggy);
            WetherBe.Add(Weather.Overcast);
            WetherBe.Add(Weather.Raining);
            WetherBe.Add(Weather.ThunderStorm);
            WetherBe.Add(Weather.Clearing);
            WetherBe.Add(Weather.Neutral);
        }
        private void IHearVoices()
        {
            //Voice list was taken from; https://pastebin.com/vDWd8RYx
            ThemVoices.Clear();

            ThemVoices.Add("ABIGAIL"); //073DD899"); //121493657"); //121493657
            ThemVoices.Add("AFFLUENT_SUBURBAN_FEMALE_01"); //FF4D4698"); //4283254424"); //ThemVoices.Add("11712872
            ThemVoices.Add("AFFLUENT_SUBURBAN_FEMALE_02"); //12836D04"); //310603012"); //310603012
            ThemVoices.Add("AFFLUENT_SUBURBAN_FEMALE_03"); //DC6000BE"); //3697279166"); //ThemVoices.Add("597688130
            ThemVoices.Add("AFFLUENT_SUBURBAN_FEMALE_04"); //EE1AA433"); //3994723379"); //ThemVoices.Add("300243917
            ThemVoices.Add("AFFLUENT_SUBURBAN_FEMALE_05"); //A47190DE"); //2758906078"); //ThemVoices.Add("1536061218
            ThemVoices.Add("AFFLUENT_SUBURBAN_FEMALE_06"); //B62C3453"); //3056350291"); //ThemVoices.Add("1238617005
            ThemVoices.Add("AFFLUENT_SUBURBAN_MALE_01"); //85FA12FF"); //2247758591"); //ThemVoices.Add("2047208705
            ThemVoices.Add("AFFLUENT_SUBURBAN_MALE_02"); //A4394F7D"); //2755219325"); //ThemVoices.Add("1539747971
            ThemVoices.Add("AGENCYJANITOR"); //5288D370"); //1384698736"); //1384698736
            ThemVoices.Add("AIRCRAFT_WARNING_FEMALE_01"); //85A08F9C"); //2241892252"); //ThemVoices.Add("2053075044
            ThemVoices.Add("AIRCRAFT_WARNING_MALE_01"); //A65A6402"); //2790941698"); //ThemVoices.Add("1504025598
            ThemVoices.Add("AIRDUMMER"); //798D01B5"); //2039284149"); //2039284149
            ThemVoices.Add("AIRGUITARIST"); //A1D7351A"); //2715235610"); //ThemVoices.Add("1579731686
            ThemVoices.Add("AIRPIANIST"); //B98B1513"); //3112899859"); //ThemVoices.Add("1182067437
            ThemVoices.Add("AIRPORT_PA_FEMALE"); //80D0944F"); //2161153103"); //ThemVoices.Add("2133814193
            ThemVoices.Add("AIRPORT_PA_MALE"); //4BA3E2F7"); //1269031671"); //1269031671
            ThemVoices.Add("ALIENS"); //EB86F769"); //3951490921"); //ThemVoices.Add("343476375
            ThemVoices.Add("AMANDA_DRUNK"); //5C0B144D"); //1544229965"); //1544229965
            ThemVoices.Add("AMANDA_NORMAL"); //EC6C9072"); //3966537842"); //ThemVoices.Add("328429454
            ThemVoices.Add("AMMUCITY"); //D4503291"); //3562025617"); //ThemVoices.Add("732941679
            ThemVoices.Add("ANDY_MOON"); //B51D1921"); //3038583073"); //ThemVoices.Add("1256384223
            ThemVoices.Add("ANTON"); //ED9B229C"); //3986367132"); //ThemVoices.Add("308600164
            ThemVoices.Add("APT_BEAST"); //14F37BC9"); //351501257"); //351501257
            ThemVoices.Add("AVI"); //EF7A6BDE"); //4017777630"); //ThemVoices.Add("277189666
            ThemVoices.Add("A_F_M_BEACH_01_WHITE_FULL_01"); //6B996380"); //1805214592"); //1805214592
            ThemVoices.Add("A_F_M_BEACH_01_WHITE_MINI_01"); //139EA948"); //329165128"); //329165128
            ThemVoices.Add("A_F_M_BEVHILLS_01_WHITE_FULL_01"); //00A8641D"); //11035677"); //11035677
            ThemVoices.Add("A_F_M_BEVHILLS_01_WHITE_MINI_01"); //3E0995AE"); //1040815534"); //1040815534
            ThemVoices.Add("A_F_M_BEVHILLS_01_WHITE_MINI_02"); //4ABAAF10"); //1253748496"); //1253748496
            ThemVoices.Add("A_F_M_BEVHILLS_02_BLACK_FULL_01"); //8455F5F0"); //2220226032"); //ThemVoices.Add("2074741264
            ThemVoices.Add("A_F_M_BEVHILLS_02_BLACK_MINI_01"); //466B8D2A"); //1181453610"); //1181453610
            ThemVoices.Add("A_F_M_BEVHILLS_02_WHITE_FULL_01"); //B228C501"); //2989016321"); //ThemVoices.Add("1305950975
            ThemVoices.Add("A_F_M_BEVHILLS_02_WHITE_FULL_02"); //CC76F99D"); //3430349213"); //ThemVoices.Add("864618083
            ThemVoices.Add("A_F_M_BEVHILLS_02_WHITE_MINI_01"); //3FD63057"); //1071001687"); //1071001687
            ThemVoices.Add("A_F_M_BODYBUILD_01_BLACK_FULL_01"); //4B0E89BF"); //1259243967"); //1259243967
            ThemVoices.Add("A_F_M_BODYBUILD_01_BLACK_MINI_01"); //23D791B0"); //601330096"); //601330096
            ThemVoices.Add("A_F_M_BODYBUILD_01_WHITE_FULL_01"); //8773ADD6"); //2272505302"); //ThemVoices.Add("2022461994
            ThemVoices.Add("A_F_M_BODYBUILD_01_WHITE_MINI_01"); //B902AA3A"); //3103959610"); //ThemVoices.Add("1191007686
            ThemVoices.Add("A_F_M_BUSINESS_02_WHITE_MINI_01"); //9C4AD53A"); //2622149946"); //ThemVoices.Add("1672817350
            ThemVoices.Add("A_F_M_DOWNTOWN_01_BLACK_FULL_01"); //0AA25C8F"); //178412687"); //178412687
            ThemVoices.Add("A_F_M_EASTSA_01_LATINO_FULL_01"); //0ACC23F9"); //181150713"); //181150713
            ThemVoices.Add("A_F_M_EASTSA_01_LATINO_MINI_01"); //CE348715"); //3459548949"); //ThemVoices.Add("835418347
            ThemVoices.Add("A_F_M_EASTSA_02_LATINO_FULL_01"); //0AA30167"); //178454887"); //178454887
            ThemVoices.Add("A_F_M_EASTSA_02_LATINO_MINI_01"); //721CC9FF"); //1914489343"); //1914489343
            ThemVoices.Add("A_F_M_FATWHITE_01_WHITE_FULL_01"); //D2158D79"); //3524627833"); //ThemVoices.Add("770339463
            ThemVoices.Add("A_F_M_FATWHITE_01_WHITE_MINI_01"); //59E595EB"); //1508218347"); //1508218347
            ThemVoices.Add("A_F_M_KTOWN_01_KOREAN_FULL_01"); //D77777E6"); //3614930918"); //ThemVoices.Add("680036378
            ThemVoices.Add("A_F_M_KTOWN_01_KOREAN_MINI_01"); //AF6FB9B1"); //2943334833"); //ThemVoices.Add("1351632463
            ThemVoices.Add("A_F_M_KTOWN_02_CHINESE_MINI_01"); //C533C983"); //3308505475"); //ThemVoices.Add("986461821
            ThemVoices.Add("A_F_M_KTOWN_02_KOREAN_FULL_01"); //D8CD3773"); //3637327731"); //ThemVoices.Add("657639565
            ThemVoices.Add("A_F_M_SALTON_01_WHITE_FULL_01"); //89DA8A2E"); //2312800814"); //ThemVoices.Add("1982166482
            ThemVoices.Add("A_F_M_SALTON_01_WHITE_FULL_02"); //9C052E83"); //2617585283"); //ThemVoices.Add("1677382013
            ThemVoices.Add("A_F_M_SALTON_01_WHITE_FULL_03"); //A66E4355"); //2792244053"); //ThemVoices.Add("1502723243
            ThemVoices.Add("A_F_M_SALTON_01_WHITE_MINI_01"); //8701705E"); //2265018462"); //ThemVoices.Add("2029948834
            ThemVoices.Add("A_F_M_SALTON_01_WHITE_MINI_02"); //7DC35DE2"); //2109955554"); //2109955554
            ThemVoices.Add("A_F_M_SALTON_01_WHITE_MINI_03"); //6675AF47"); //1718988615"); //1718988615
            ThemVoices.Add("A_F_M_SKIDROW_01_BLACK_FULL_01"); //A7C0DE51"); //2814434897"); //ThemVoices.Add("1480532399
            ThemVoices.Add("A_F_M_SKIDROW_01_BLACK_MINI_01"); //443E6FBE"); //1144942526"); //1144942526
            ThemVoices.Add("A_F_M_SKIDROW_01_WHITE_FULL_01"); //F8F30014"); //4176674836"); //ThemVoices.Add("118292460
            ThemVoices.Add("A_F_M_SKIDROW_01_WHITE_MINI_01"); //705684C4"); //1884718276"); //1884718276
            ThemVoices.Add("A_F_M_SOUCENT_01_BLACK_FULL_01"); //4E0DA806"); //1309517830"); //1309517830
            ThemVoices.Add("A_F_M_SOUCENT_02_BLACK_FULL_01"); //C725E5CC"); //3341149644"); //ThemVoices.Add("953817652
            ThemVoices.Add("A_F_M_TOURIST_01_WHITE_MINI_01"); //25365382"); //624317314"); //624317314
            ThemVoices.Add("A_F_M_TRAMPBEAC_01_BLACK_FULL_01"); //F091AF03"); //4036079363"); //ThemVoices.Add("258887933
            ThemVoices.Add("A_F_M_TRAMPBEAC_01_BLACK_MINI_01"); //DE24211D"); //3726909725"); //ThemVoices.Add("568057571
            ThemVoices.Add("A_F_M_TRAMPBEAC_01_WHITE_FULL_01"); //8D34DFCC"); //2369052620"); //ThemVoices.Add("1925914676
            ThemVoices.Add("A_F_M_TRAMP_01_WHITE_FULL_01"); //D05841FA"); //3495444986"); //ThemVoices.Add("799522310
            ThemVoices.Add("A_F_M_TRAMP_01_WHITE_MINI_01"); //55CE3CCC"); //1439579340"); //1439579340
            ThemVoices.Add("A_F_O_GENSTREET_01_WHITE_MINI_01"); //482D1EC8"); //1210916552"); //1210916552
            ThemVoices.Add("A_F_O_INDIAN_01_INDIAN_MINI_01"); //8755E8CA"); //2270554314"); //ThemVoices.Add("2024412982
            ThemVoices.Add("A_F_O_KTOWN_01_KOREAN_FULL_01"); //DBE7871F"); //3689383711"); //ThemVoices.Add("605583585
            ThemVoices.Add("A_F_O_KTOWN_01_KOREAN_MINI_01"); //F94EAEEB"); //4182683371"); //ThemVoices.Add("112283925
            ThemVoices.Add("A_F_O_SALTON_01_WHITE_FULL_01"); //F79EEC05"); //4154387461"); //ThemVoices.Add("140579835
            ThemVoices.Add("A_F_O_SALTON_01_WHITE_MINI_01"); //FCBC6F1F"); //4240207647"); //ThemVoices.Add("54759649
            ThemVoices.Add("A_F_O_SOUCENT_01_BLACK_FULL_01"); //3439D3C2"); //876204994"); //876204994
            ThemVoices.Add("A_F_O_SOUCENT_02_BLACK_FULL_01"); //F27CEF94"); //4068274068"); //ThemVoices.Add("226693228
            ThemVoices.Add("A_F_Y_BEACH_01_BLACK_MINI_01"); //4B79AF9D"); //1266266013"); //1266266013
            ThemVoices.Add("A_F_Y_BEACH_01_WHITE_FULL_01"); //2BCAB282"); //734704258"); //734704258
            ThemVoices.Add("A_F_Y_BEACH_01_WHITE_MINI_01"); //13609A3C"); //325098044"); //325098044
            ThemVoices.Add("A_F_Y_BEACH_BLACK_FULL_01"); //0422CC2C"); //69389356"); //69389356
            ThemVoices.Add("A_F_Y_BEVHILLS_01_WHITE_FULL_01"); //E7099D21"); //3876166945"); //ThemVoices.Add("418800351
            ThemVoices.Add("A_F_Y_BEVHILLS_01_WHITE_MINI_01"); //D2C133B9"); //3535877049"); //ThemVoices.Add("759090247
            ThemVoices.Add("A_F_Y_BEVHILLS_02_WHITE_FULL_01"); //F700AB54"); //4144016212"); //ThemVoices.Add("150951084
            ThemVoices.Add("A_F_Y_BEVHILLS_02_WHITE_MINI_01"); //AA4B2212"); //2857050642"); //ThemVoices.Add("1437916654
            ThemVoices.Add("A_F_Y_BEVHILLS_02_WHITE_MINI_02"); //7E1BC9B0"); //2115750320"); //2115750320
            ThemVoices.Add("A_F_Y_BEVHILLS_03_WHITE_FULL_01"); //8558FF3F"); //2237202239"); //ThemVoices.Add("2057765057
            ThemVoices.Add("A_F_Y_BEVHILLS_03_WHITE_MINI_01"); //D17E6765"); //3514722149"); //ThemVoices.Add("780245147
            ThemVoices.Add("A_F_Y_BEVHILLS_04_WHITE_FULL_01"); //B91127EB"); //3104909291"); //ThemVoices.Add("1190058005
            ThemVoices.Add("A_F_Y_BEVHILLS_04_WHITE_MINI_01"); //9A251230"); //2586120752"); //ThemVoices.Add("1708846544
            ThemVoices.Add("A_F_Y_BUSINESS_01_WHITE_FULL_01"); //A3D0C7CD"); //2748368845"); //ThemVoices.Add("1546598451
            ThemVoices.Add("A_F_Y_BUSINESS_01_WHITE_MINI_01"); //87816F13"); //2273406739"); //ThemVoices.Add("2021560557
            ThemVoices.Add("A_F_Y_BUSINESS_01_WHITE_MINI_02"); //188B9125"); //411799845"); //411799845
            ThemVoices.Add("A_F_Y_BUSINESS_02_WHITE_FULL_01"); //4CC300E2"); //1287848162"); //1287848162
            ThemVoices.Add("A_F_Y_BUSINESS_02_WHITE_MINI_01"); //94B7537B"); //2495042427"); //ThemVoices.Add("1799924869
            ThemVoices.Add("A_F_Y_BUSINESS_03_CHINESE_FULL_01"); //7D9DD020"); //2107494432"); //2107494432
            ThemVoices.Add("A_F_Y_BUSINESS_03_CHINESE_MINI_01"); //D41AE44A"); //3558532170"); //ThemVoices.Add("736435126
            ThemVoices.Add("A_F_Y_BUSINESS_03_LATINO_FULL_01"); //420377DE"); //1107523550"); //1107523550
            ThemVoices.Add("A_F_Y_BUSINESS_04_BLACK_FULL_01"); //26D1F656"); //651294294"); //651294294
            ThemVoices.Add("A_F_Y_BUSINESS_04_BLACK_MINI_01"); //97D8B312"); //2547561234"); //ThemVoices.Add("1747406062
            ThemVoices.Add("A_F_Y_BUSINESS_04_WHITE_MINI_01"); //BE6FAE2C"); //3194990124"); //ThemVoices.Add("1099977172
            ThemVoices.Add("A_F_Y_EASTSA_01_LATINO_FULL_01"); //3CB71B34"); //1018633012"); //1018633012
            ThemVoices.Add("A_F_Y_EASTSA_01_LATINO_MINI_01"); //D3A7F87F"); //3551000703"); //ThemVoices.Add("743966593
            ThemVoices.Add("A_F_Y_EASTSA_02_WHITE_FULL_01"); //3DDC0236"); //1037828662"); //1037828662
            ThemVoices.Add("A_F_Y_EASTSA_03_LATINO_FULL_01"); //C801D0E0"); //3355562208"); //ThemVoices.Add("939405088
            ThemVoices.Add("A_F_Y_EASTSA_03_LATINO_MINI_01"); //38E9E4FC"); //954852604"); //954852604
            ThemVoices.Add("A_F_Y_EPSILON_01_WHITE_MINI_01"); //1B66BF81"); //459718529"); //459718529
            ThemVoices.Add("A_F_Y_FITNESS_01_WHITE_FULL_01"); //7639B49D"); //1983493277"); //1983493277
            ThemVoices.Add("A_F_Y_FITNESS_01_WHITE_MINI_01"); //E2D732E6"); //3805754086"); //ThemVoices.Add("489213210
            ThemVoices.Add("A_F_Y_FITNESS_02_BLACK_FULL_01"); //851B5376"); //2233160566"); //ThemVoices.Add("2061806730
            ThemVoices.Add("A_F_Y_FITNESS_02_BLACK_MINI_01"); //27C40170"); //667156848"); //667156848
            ThemVoices.Add("A_F_Y_FITNESS_02_WHITE_FULL_01"); //BF9CB8C8"); //3214719176"); //ThemVoices.Add("1080248120
            ThemVoices.Add("A_F_Y_FITNESS_02_WHITE_MINI_01"); //A105E3A0"); //2701517728"); //ThemVoices.Add("1593449568
            ThemVoices.Add("A_F_Y_Golfer_01_WHITE_FULL_01"); //B81316C5"); //3088258757"); //ThemVoices.Add("1206708539
            ThemVoices.Add("A_F_Y_Golfer_01_WHITE_MINI_01"); //5F5BFB44"); //1599863620"); //1599863620
            ThemVoices.Add("A_F_Y_HIKER_01_WHITE_FULL_01"); //BB0A674E"); //3138021198"); //ThemVoices.Add("1156946098
            ThemVoices.Add("A_F_Y_HIKER_01_WHITE_MINI_01"); //C8CAFB5E"); //3368745822"); //ThemVoices.Add("926221474
            ThemVoices.Add("A_F_Y_HIPSTER_01_WHITE_FULL_01"); //A24D58EA"); //2722978026"); //ThemVoices.Add("1571989270
            ThemVoices.Add("A_F_Y_HIPSTER_01_WHITE_MINI_01"); //92D2202A"); //2463244330"); //ThemVoices.Add("1831722966
            ThemVoices.Add("A_F_Y_HIPSTER_02_WHITE_FULL_01"); //83EA9D79"); //2213191033"); //ThemVoices.Add("2081776263
            ThemVoices.Add("A_F_Y_HIPSTER_02_WHITE_MINI_01"); //41543F56"); //1096040278"); //1096040278
            ThemVoices.Add("A_F_Y_HIPSTER_02_WHITE_MINI_02"); //2F6F9B8D"); //795843469"); //795843469
            ThemVoices.Add("A_F_Y_HIPSTER_03_WHITE_FULL_01"); //ADED3C9F"); //2918005919"); //ThemVoices.Add("1376961377
            ThemVoices.Add("A_F_Y_HIPSTER_03_WHITE_MINI_01"); //F824C1C7"); //4163158471"); //ThemVoices.Add("131808825
            ThemVoices.Add("A_F_Y_HIPSTER_03_WHITE_MINI_02"); //E95A2432"); //3914998834"); //ThemVoices.Add("379968462
            ThemVoices.Add("A_F_Y_HIPSTER_04_WHITE_FULL_01"); //3141C876"); //826394742"); //826394742
            ThemVoices.Add("A_F_Y_HIPSTER_04_WHITE_MINI_01"); //6B08FBA6"); //1795750822"); //1795750822
            ThemVoices.Add("A_F_Y_HIPSTER_04_WHITE_MINI_02"); //3BDF1D53"); //1004477779"); //1004477779
            ThemVoices.Add("A_F_Y_INDIAN_01_INDIAN_MINI_01"); //AD0551E1"); //2902807009"); //ThemVoices.Add("1392160287
            ThemVoices.Add("A_F_Y_INDIAN_01_INDIAN_MINI_02"); //BF49F66A"); //3209295466"); //ThemVoices.Add("1085671830
            ThemVoices.Add("A_F_Y_ROLLERCOASTER_01_MINI_01"); //5470D900"); //1416681728"); //1416681728
            ThemVoices.Add("A_F_Y_ROLLERCOASTER_01_MINI_02"); //4295B54A"); //1117107530"); //1117107530
            ThemVoices.Add("A_F_Y_ROLLERCOASTER_01_MINI_03"); //C2393483"); //3258528899"); //ThemVoices.Add("1036438397
            ThemVoices.Add("A_F_Y_ROLLERCOASTER_01_MINI_04"); //B015903C"); //2954203196"); //ThemVoices.Add("1340764100
            ThemVoices.Add("A_F_Y_SKATER_01_WHITE_FULL_01"); //52D929F1"); //1389963761"); //1389963761
            ThemVoices.Add("A_F_Y_SKATER_01_WHITE_MINI_01"); //6E55B81F"); //1851111455"); //1851111455
            ThemVoices.Add("A_F_Y_SOUCENT_01_BLACK_FULL_01"); //A0FDDA5B"); //2700991067"); //ThemVoices.Add("1593976229
            ThemVoices.Add("A_F_Y_SOUCENT_02_BLACK_FULL_01"); //DB96A76C"); //3684083564"); //ThemVoices.Add("610883732
            ThemVoices.Add("A_F_Y_SOUCENT_03_LATINO_FULL_01"); //AA71DF24"); //2859589412"); //ThemVoices.Add("1435377884
            ThemVoices.Add("A_F_Y_SOUCENT_03_LATINO_MINI_01"); //656710BE"); //1701253310"); //1701253310
            ThemVoices.Add("A_F_Y_TENNIS_01_BLACK_MINI_01"); //B602DF7D"); //3053641597"); //ThemVoices.Add("1241325699
            ThemVoices.Add("A_F_Y_TENNIS_01_WHITE_MINI_01"); //434E2C2C"); //1129196588"); //1129196588
            ThemVoices.Add("A_F_Y_TOURIST_01_BLACK_FULL_01"); //ECA3EB4D"); //3970165581"); //ThemVoices.Add("324801715
            ThemVoices.Add("A_F_Y_TOURIST_01_BLACK_MINI_01"); //A3713FCD"); //2742108109"); //ThemVoices.Add("1552859187
            ThemVoices.Add("A_F_Y_TOURIST_01_LATINO_FULL_01"); //D6F2B12F"); //3606229295"); //ThemVoices.Add("688738001
            ThemVoices.Add("A_F_Y_TOURIST_01_LATINO_MINI_01"); //122F5483"); //305091715"); //305091715
            ThemVoices.Add("A_F_Y_TOURIST_01_WHITE_FULL_01"); //DBEFEC5C"); //3689933916"); //ThemVoices.Add("605033380
            ThemVoices.Add("A_F_Y_TOURIST_01_WHITE_MINI_01"); //216BE906"); //560720134"); //560720134
            ThemVoices.Add("A_F_Y_TOURIST_02_WHITE_MINI_01"); //0D6F398A"); //225393034"); //225393034
            ThemVoices.Add("A_F_Y_VINEWOOD_01_WHITE_FULL_01"); //2AF2EF5B"); //720564059"); //720564059
            ThemVoices.Add("A_F_Y_VINEWOOD_01_WHITE_MINI_01"); //23A74DCA"); //598166986"); //598166986
            ThemVoices.Add("A_F_Y_VINEWOOD_02_WHITE_FULL_01"); //3A311C01"); //976296961"); //976296961
            ThemVoices.Add("A_F_Y_VINEWOOD_02_WHITE_MINI_01"); //191A5AF2"); //421157618"); //421157618
            ThemVoices.Add("A_F_Y_Vinewood_03_Chinese_FULL_01"); //E632B0F0"); //3862081776"); //ThemVoices.Add("432885520
            ThemVoices.Add("A_F_Y_VINEWOOD_03_CHINESE_MINI_01"); //3512D951"); //890427729"); //890427729
            ThemVoices.Add("A_F_Y_VINEWOOD_04_WHITE_FULL_01"); //20C68AC8"); //549882568"); //549882568
            ThemVoices.Add("A_F_Y_VINEWOOD_04_WHITE_MINI_01"); //12763C39"); //309738553"); //309738553
            ThemVoices.Add("A_F_Y_VINEWOOD_04_WHITE_MINI_02"); //C8CB28E4"); //3368757476"); //ThemVoices.Add("926209820
            ThemVoices.Add("A_M_M_AFRIAMER_01_BLACK_FULL_01"); //43367BD1"); //1127644113"); //1127644113
            ThemVoices.Add("A_M_M_BEACH_01_BLACK_MINI_01"); //D01013F6"); //3490714614"); //ThemVoices.Add("804252682
            ThemVoices.Add("A_M_M_BEACH_01_LATINO_FULL_01"); //26669A41"); //644258369"); //644258369
            ThemVoices.Add("A_M_M_BEACH_01_LATINO_MINI_01"); //FB444157"); //4215554391"); //ThemVoices.Add("79412905
            ThemVoices.Add("A_M_M_BEACH_01_WHITE_FULL_01"); //30CB4589"); //818627977"); //818627977
            ThemVoices.Add("A_M_M_BEACH_01_WHITE_MINI_02"); //A8E033BD"); //2833265597"); //ThemVoices.Add("1461701699
            ThemVoices.Add("A_M_M_BEACH_02_BLACK_FULL_01"); //BCACE696"); //3165447830"); //ThemVoices.Add("1129519466
            ThemVoices.Add("A_M_M_BEACH_02_WHITE_FULL_01"); //E8314D57"); //3895545175"); //ThemVoices.Add("399422121
            ThemVoices.Add("A_M_M_BEACH_02_WHITE_MINI_01"); //AE3CFC05"); //2923232261"); //ThemVoices.Add("1371735035
            ThemVoices.Add("A_M_M_BEACH_02_WHITE_MINI_02"); //4717ADD8"); //1192734168"); //1192734168
            ThemVoices.Add("A_M_M_BEVHILLS_01_BLACK_FULL_01"); //457F9C3D"); //1165990973"); //1165990973
            ThemVoices.Add("A_M_M_BEVHILLS_01_BLACK_MINI_01"); //29323F4A"); //691158858"); //691158858
            ThemVoices.Add("A_M_M_BevHills_01_WHITE_FULL_01"); //DBCAE12A"); //3687506218"); //ThemVoices.Add("607461078
            ThemVoices.Add("A_M_M_BEVHILLS_01_WHITE_MINI_01"); //D19FFBCA"); //3516922826"); //ThemVoices.Add("778044470
            ThemVoices.Add("A_M_M_BEVHILLS_02_BLACK_FULL_01"); //5370D897"); //1399904407"); //1399904407
            ThemVoices.Add("A_M_M_BEVHILLS_02_BLACK_MINI_01"); //25983C23"); //630733859"); //630733859
            ThemVoices.Add("A_M_M_BEVHILLS_02_WHITE_FULL_01"); //6BB97FD6"); //1807318998"); //1807318998
            ThemVoices.Add("A_M_M_BEVHILLS_02_WHITE_MINI_01"); //B509F09C"); //3037327516"); //ThemVoices.Add("1257639780
            ThemVoices.Add("A_M_M_BUSINESS_01_BLACK_FULL_01"); //4F3C06EB"); //1329333995"); //1329333995
            ThemVoices.Add("A_M_M_BUSINESS_01_BLACK_MINI_01"); //9C4ACF39"); //2622148409"); //ThemVoices.Add("1672818887
            ThemVoices.Add("A_M_M_BUSINESS_01_WHITE_FULL_01"); //CE2B65BC"); //3458950588"); //ThemVoices.Add("836016708
            ThemVoices.Add("A_M_M_BUSINESS_01_WHITE_MINI_01"); //F3AD48DE"); //4088219870"); //ThemVoices.Add("206747426
            ThemVoices.Add("A_M_M_EASTSA_01_LATINO_FULL_01"); //BE01DD94"); //3187793300"); //ThemVoices.Add("1107173996
            ThemVoices.Add("A_M_M_EASTSA_01_LATINO_MINI_01"); //6BF8BF2C"); //1811463980"); //1811463980
            ThemVoices.Add("A_M_M_EASTSA_02_LATINO_FULL_01"); //9CB34BA8"); //2628996008"); //ThemVoices.Add("1665971288
            ThemVoices.Add("A_M_M_EASTSA_02_LATINO_MINI_01"); //CDF2AD27"); //3455233319"); //ThemVoices.Add("839733977
            ThemVoices.Add("A_M_M_FARMER_01_WHITE_MINI_01"); //24689D1A"); //610835738"); //610835738
            ThemVoices.Add("A_M_M_FARMER_01_WHITE_MINI_02"); //4ED1F1EC"); //1322381804"); //1322381804
            ThemVoices.Add("A_M_M_FARMER_01_WHITE_MINI_03"); //F7F4C433"); //4160013363"); //ThemVoices.Add("134953933
            ThemVoices.Add("A_M_M_FATLATIN_01_LATINO_FULL_01"); //2F04A30B"); //788833035"); //788833035
            ThemVoices.Add("A_M_M_FATLATIN_01_LATINO_MINI_01"); //4AED8689"); //1257080457"); //1257080457
            ThemVoices.Add("A_M_M_GENERICMALE_01_WHITE_MINI_01"); //13EFDE7E"); //334487166"); //334487166
            ThemVoices.Add("A_M_M_GENERICMALE_01_WHITE_MINI_02"); //221A7AD3"); //572160723"); //572160723
            ThemVoices.Add("A_M_M_GENERICMALE_01_WHITE_MINI_03"); //5AA26BD6"); //1520593878"); //1520593878
            ThemVoices.Add("A_M_M_GENERICMALE_01_WHITE_MINI_04"); //FD0AB0B4"); //4245336244"); //ThemVoices.Add("49631052
            ThemVoices.Add("A_M_M_GENFAT_01_LATINO_FULL_01"); //E53DAB11"); //3846023953"); //ThemVoices.Add("448943343
            ThemVoices.Add("A_M_M_GENFAT_01_LATINO_MINI_01"); //4C00FC14"); //1275132948"); //1275132948
            ThemVoices.Add("A_M_M_GOLFER_01_BLACK_FULL_01"); //65B984D1"); //1706656977"); //1706656977
            ThemVoices.Add("A_M_M_GOLFER_01_WHITE_FULL_01"); //57DD2744"); //1474111300"); //1474111300
            ThemVoices.Add("A_M_M_GOLFER_01_WHITE_MINI_01"); //CA82D279"); //3397571193"); //ThemVoices.Add("897396103
            ThemVoices.Add("A_M_M_HASJEW_01_WHITE_MINI_01"); //31B413DD"); //833885149"); //833885149
            ThemVoices.Add("A_M_M_HILLBILLY_01_WHITE_MINI_01"); //342FA137"); //875536695"); //875536695
            ThemVoices.Add("A_M_M_HILLBILLY_01_WHITE_MINI_02"); //EEB2964E"); //4004681294"); //ThemVoices.Add("290286002
            ThemVoices.Add("A_M_M_HILLBILLY_01_WHITE_MINI_03"); //62B97E4A"); //1656323658"); //1656323658
            ThemVoices.Add("A_M_M_HILLBILLY_02_WHITE_MINI_01"); //9E428A7D"); //2655160957"); //ThemVoices.Add("1639806339
            ThemVoices.Add("A_M_M_HILLBILLY_02_WHITE_MINI_02"); //ACECA7D1"); //2901190609"); //ThemVoices.Add("1393776687
            ThemVoices.Add("A_M_M_HILLBILLY_02_WHITE_MINI_03"); //7A9EC332"); //2057225010"); //2057225010
            ThemVoices.Add("A_M_M_HILLBILLY_02_WHITE_MINI_04"); //14C3777D"); //348354429"); //348354429
            ThemVoices.Add("A_M_M_INDIAN_01_INDIAN_MINI_01"); //0D92701D"); //227700765"); //227700765
            ThemVoices.Add("A_M_M_KTOWN_01_KOREAN_FULL_01"); //CEB967A9"); //3468257193"); //ThemVoices.Add("826710103
            ThemVoices.Add("A_M_M_KTOWN_01_KOREAN_MINI_01"); //9D5568DD"); //2639620317"); //ThemVoices.Add("1655346979
            ThemVoices.Add("A_M_M_MALIBU_01_BLACK_FULL_01"); //704A0828"); //1883899944"); //1883899944
            ThemVoices.Add("A_M_M_MALIBU_01_LATINO_FULL_01"); //C446CD11"); //3292974353"); //ThemVoices.Add("1001992943
            ThemVoices.Add("A_M_M_MALIBU_01_LATINO_MINI_01"); //23A05D0D"); //597712141"); //597712141
            ThemVoices.Add("A_M_M_MALIBU_01_WHITE_FULL_01"); //ABCCBA7C"); //2882321020"); //ThemVoices.Add("1412646276
            ThemVoices.Add("A_M_M_MALIBU_01_WHITE_MINI_01"); //B71E2A9D"); //3072207517"); //ThemVoices.Add("1222759779
            ThemVoices.Add("A_M_M_POLYNESIAN_01_POLYNESIAN_FULL_01"); //68887F5A"); //1753775962"); //1753775962
            ThemVoices.Add("A_M_M_POLYNESIAN_01_POLYNESIAN_MINI_01"); //CDB20C91"); //3450997905"); //ThemVoices.Add("843969391
            ThemVoices.Add("A_M_M_SALTON_01_WHITE_FULL_01"); //C4B4C301"); //3300180737"); //ThemVoices.Add("994786559
            ThemVoices.Add("A_M_M_SALTON_02_WHITE_FULL_01"); //AAD2C80E"); //2865940494"); //ThemVoices.Add("1429026802
            ThemVoices.Add("A_M_M_SALTON_02_WHITE_MINI_01"); //47C9EC4A"); //1204415562"); //1204415562
            ThemVoices.Add("A_M_M_SALTON_02_WHITE_MINI_02"); //6D9837E6"); //1838692326"); //1838692326
            ThemVoices.Add("A_M_M_SKATER_01_BLACK_FULL_01"); //256B9C01"); //627809281"); //627809281
            ThemVoices.Add("A_M_M_SKATER_01_WHITE_FULL_01"); //011E5DF9"); //18767353"); //18767353
            ThemVoices.Add("A_M_M_SKATER_01_WHITE_MINI_01"); //990DB923"); //2567813411"); //ThemVoices.Add("1727153885
            ThemVoices.Add("A_M_M_SKIDROW_01_BLACK_FULL_01"); //A9B4316E"); //2847158638"); //ThemVoices.Add("1447808658
            ThemVoices.Add("A_M_M_SOCENLAT_01_LATINO_FULL_01"); //06291B43"); //103357251"); //103357251
            ThemVoices.Add("A_M_M_SOCENLAT_01_LATINO_MINI_01"); //E9A5A98F"); //3919948175"); //ThemVoices.Add("375019121
            ThemVoices.Add("A_M_M_SOUCENT_01_BLACK_FULL_01"); //15D5484D"); //366299213"); //366299213
            ThemVoices.Add("A_M_M_SOUCENT_02_BLACK_FULL_01"); //465792F9"); //1180144377"); //1180144377
            ThemVoices.Add("A_M_M_SOUCENT_03_BLACK_FULL_01"); //19DD2A37"); //433924663"); //433924663
            ThemVoices.Add("A_M_M_SOUCENT_04_BLACK_FULL_01"); //3712F629"); //923989545"); //923989545
            ThemVoices.Add("A_M_M_SOUCENT_04_BLACK_MINI_01"); //7BDBD27A"); //2078003834"); //2078003834
            ThemVoices.Add("A_M_M_STLAT_02_LATINO_FULL_01"); //27BC1008"); //666636296"); //666636296
            ThemVoices.Add("A_M_M_TENNIS_01_BLACK_MINI_01"); //74745D9B"); //1953783195"); //1953783195
            ThemVoices.Add("A_M_M_TENNIS_01_WHITE_MINI_01"); //A7AD9A25"); //2813172261"); //ThemVoices.Add("1481795035
            ThemVoices.Add("A_M_M_TOURIST_01_WHITE_MINI_01"); //4B87E962"); //1267198306"); //1267198306
            ThemVoices.Add("A_M_M_TRAMPBEAC_01_BLACK_FULL_01"); //126F2EEF"); //309276399"); //309276399
            ThemVoices.Add("A_M_M_TRAMP_01_BLACK_FULL_01"); //EBC7775E"); //3955717982"); //ThemVoices.Add("339249314
            ThemVoices.Add("A_M_M_TRAMP_01_BLACK_MINI_01"); //7924B380"); //2032448384"); //2032448384
            ThemVoices.Add("A_M_M_TRANVEST_01_WHITE_MINI_01"); //98921800"); //2559711232"); //ThemVoices.Add("1735256064
            ThemVoices.Add("A_M_M_TRANVEST_02_LATINO_FULL_01"); //659F48E4"); //1704937700"); //1704937700
            ThemVoices.Add("A_M_M_TRANVEST_02_LATINO_MINI_01"); //F9BFF521"); //4190106913"); //ThemVoices.Add("104860383
            ThemVoices.Add("A_M_O_BEACH_01_WHITE_FULL_01"); //7FBF0F4A"); //2143227722"); //2143227722
            ThemVoices.Add("A_M_O_BEACH_01_WHITE_MINI_01"); //B21E181B"); //2988316699"); //ThemVoices.Add("1306650597
            ThemVoices.Add("A_M_O_GENSTREET_01_WHITE_FULL_01"); //BB6B9D57"); //3144392023"); //ThemVoices.Add("1150575273
            ThemVoices.Add("A_M_O_GENSTREET_01_WHITE_MINI_01"); //10EE4E6A"); //284053098"); //284053098
            ThemVoices.Add("A_M_O_SALTON_01_WHITE_FULL_01"); //5DBB7560"); //1572566368"); //1572566368
            ThemVoices.Add("A_M_O_SALTON_01_WHITE_MINI_01"); //AEA39902"); //2929957122"); //ThemVoices.Add("1365010174
            ThemVoices.Add("A_M_O_SOUCENT_01_BLACK_FULL_01"); //8F45DF82"); //2403721090"); //ThemVoices.Add("1891246206
            ThemVoices.Add("A_M_O_SOUCENT_02_BLACK_FULL_01"); //C195B582"); //3247814018"); //ThemVoices.Add("1047153278
            ThemVoices.Add("A_M_O_SOUCENT_03_BLACK_FULL_01"); //9CE751AB"); //2632405419"); //ThemVoices.Add("1662561877
            ThemVoices.Add("A_M_O_TRAMP_01_BLACK_FULL_01"); //ABAB17E1"); //2880116705"); //ThemVoices.Add("1414850591
            ThemVoices.Add("A_M_Y_BEACHVESP_01_CHINESE_FULL_01"); //D5130E1F"); //3574795807"); //ThemVoices.Add("720171489
            ThemVoices.Add("A_M_Y_BEACHVESP_01_CHINESE_MINI_01"); //B0C6E699"); //2965825177"); //ThemVoices.Add("1329142119
            ThemVoices.Add("A_M_Y_BEACHVESP_01_LATINO_MINI_01"); //3F13D91C"); //1058265372"); //1058265372
            ThemVoices.Add("A_M_Y_BEACHVESP_01_WHITE_FULL_01"); //3CE0CB56"); //1021365078"); //1021365078
            ThemVoices.Add("A_M_Y_BEACHVESP_01_WHITE_MINI_01"); //AAD5FF3F"); //2866151231"); //ThemVoices.Add("1428816065
            ThemVoices.Add("A_M_Y_BEACHVESP_02_WHITE_FULL_01"); //4C19F4DE"); //1276769502"); //1276769502
            ThemVoices.Add("A_M_Y_BEACHVESP_02_WHITE_MINI_01"); //7F7BB4CC"); //2138813644"); //2138813644
            ThemVoices.Add("A_M_Y_BEACH_01_CHINESE_FULL_01"); //14611348"); //341906248"); //341906248
            ThemVoices.Add("A_M_Y_BEACH_01_CHINESE_MINI_01"); //6A55B403"); //1784001539"); //1784001539
            ThemVoices.Add("A_M_Y_BEACH_01_WHITE_FULL_01"); //1C2149A7"); //471943591"); //471943591
            ThemVoices.Add("A_M_Y_BEACH_01_WHITE_MINI_01"); //912C1ADE"); //2435586782"); //ThemVoices.Add("1859380514
            ThemVoices.Add("A_M_Y_BEACH_02_LATINO_FULL_01"); //DBF1B32E"); //3690050350"); //ThemVoices.Add("604916946
            ThemVoices.Add("A_M_Y_BEACH_02_WHITE_FULL_01"); //0B3E6275"); //188637813"); //188637813
            ThemVoices.Add("A_M_Y_BEACH_03_BLACK_FULL_01"); //18519A78"); //408001144"); //408001144
            ThemVoices.Add("A_M_Y_BEACH_03_BLACK_MINI_01"); //5C219040"); //1545703488"); //1545703488
            ThemVoices.Add("A_M_Y_BEACH_03_WHITE_FULL_01"); //187DBBE4"); //410893284"); //410893284
            ThemVoices.Add("A_M_Y_BEVHILLS_01_BLACK_FULL_01"); //BB7823E2"); //3145212898"); //ThemVoices.Add("1149754398
            ThemVoices.Add("A_M_Y_BevHills_01_WHITE_FULL_01"); //FBF34319"); //4227023641"); //ThemVoices.Add("67943655
            ThemVoices.Add("A_M_Y_BEVHILLS_01_WHITE_MINI_01"); //7C5C68C5"); //2086430917"); //2086430917
            ThemVoices.Add("A_M_Y_BevHills_02_Black_FULL_01"); //7FDB40A6"); //2145075366"); //2145075366
            ThemVoices.Add("A_M_Y_BEVHILLS_02_WHITE_FULL_01"); //D4FC2A78"); //3573295736"); //ThemVoices.Add("721671560
            ThemVoices.Add("A_M_Y_BEVHILLS_02_WHITE_MINI_01"); //E24573FE"); //3796202494"); //ThemVoices.Add("498764802
            ThemVoices.Add("A_M_Y_BUSICAS_01_WHITE_MINI_01"); //AE353C51"); //2922724433"); //ThemVoices.Add("1372242863
            ThemVoices.Add("A_M_Y_BUSINESS_01_BLACK_FULL_01"); //14EA502A"); //350900266"); //350900266
            ThemVoices.Add("A_M_Y_BUSINESS_01_BLACK_MINI_01"); //3EE0C0FD"); //1054916861"); //1054916861
            ThemVoices.Add("A_M_Y_BUSINESS_01_CHINESE_FULL_01"); //2AF37A7A"); //720599674"); //720599674
            ThemVoices.Add("A_M_Y_BUSINESS_01_CHINESE_MINI_01"); //BBE9D5F6"); //3152664054"); //ThemVoices.Add("1142303242
            ThemVoices.Add("A_M_Y_BUSINESS_01_WHITE_FULL_01"); //A3B29220"); //2746389024"); //ThemVoices.Add("1548578272
            ThemVoices.Add("A_M_Y_BUSINESS_01_WHITE_MINI_02"); //D5230A76"); //3575843446"); //ThemVoices.Add("719123850
            ThemVoices.Add("A_M_Y_BUSINESS_02_BLACK_FULL_01"); //455E1156"); //1163792726"); //1163792726
            ThemVoices.Add("A_M_Y_BUSINESS_02_BLACK_MINI_01"); //728E84E0"); //1921942752"); //1921942752
            ThemVoices.Add("A_M_Y_BUSINESS_02_WHITE_FULL_01"); //21BD5DCB"); //566058443"); //566058443
            ThemVoices.Add("A_M_Y_BUSINESS_02_WHITE_MINI_01"); //DF04F10C"); //3741643020"); //ThemVoices.Add("553324276
            ThemVoices.Add("A_M_Y_BUSINESS_02_WHITE_MINI_02"); //D1405583"); //3510654339"); //ThemVoices.Add("784312957
            ThemVoices.Add("A_M_Y_BUSINESS_03_BLACK_FULL_01"); //63CAEDDD"); //1674243549"); //1674243549
            ThemVoices.Add("A_M_Y_BUSINESS_03_WHITE_MINI_01"); //5161018C"); //1365311884"); //1365311884
            ThemVoices.Add("A_M_Y_DOWNTOWN_01_BLACK_FULL_01"); //5C59E524"); //1549395236"); //1549395236
            ThemVoices.Add("A_M_Y_EASTSA_01_LATINO_FULL_01"); //4D091B2B"); //1292442411"); //1292442411
            ThemVoices.Add("A_M_Y_EASTSA_01_LATINO_MINI_01"); //90006FB0"); //2415947696"); //ThemVoices.Add("1879019600
            ThemVoices.Add("A_M_Y_EASTSA_02_LATINO_FULL_01"); //71EFEA69"); //1911548521"); //1911548521
            ThemVoices.Add("A_M_Y_EPSILON_01_BLACK_FULL_01"); //3C737DA3"); //1014201763"); //1014201763
            ThemVoices.Add("A_M_Y_EPSILON_01_KOREAN_FULL_01"); //C5901506"); //3314554118"); //ThemVoices.Add("980413178
            ThemVoices.Add("A_M_Y_EPSILON_01_WHITE_FULL_01"); //8B5E6BA1"); //2338220961"); //ThemVoices.Add("1956746335
            ThemVoices.Add("A_M_Y_EPSILON_02_WHITE_MINI_01"); //5929B31B"); //1495905051"); //1495905051
            ThemVoices.Add("A_M_Y_GAY_01_BLACK_FULL_01"); //D66B6510"); //3597362448"); //ThemVoices.Add("697604848
            ThemVoices.Add("A_M_Y_GAY_01_LATINO_FULL_01"); //56EA4F8A"); //1458196362"); //1458196362
            ThemVoices.Add("A_M_Y_GAY_02_WHITE_MINI_01"); //F31D141C"); //4078769180"); //ThemVoices.Add("216198116
            ThemVoices.Add("A_M_Y_GENSTREET_01_CHINESE_FULL_01"); //FBD60609"); //4225107465"); //ThemVoices.Add("69859831
            ThemVoices.Add("A_M_Y_GENSTREET_01_CHINESE_MINI_01"); //68B1C2E6"); //1756480230"); //1756480230
            ThemVoices.Add("A_M_Y_GenStreet_01_White_FULL_01"); //CCC8E124"); //3435716900"); //ThemVoices.Add("859250396
            ThemVoices.Add("A_M_Y_GENSTREET_01_WHITE_MINI_01"); //0EA63482"); //245773442"); //245773442
            ThemVoices.Add("A_M_Y_GENSTREET_02_BLACK_FULL_01"); //A05521B9"); //2689933753"); //ThemVoices.Add("1605033543
            ThemVoices.Add("A_M_Y_GENSTREET_02_LATINO_FULL_01"); //8A23EC00"); //2317609984"); //ThemVoices.Add("1977357312
            ThemVoices.Add("A_M_Y_GENSTREET_02_LATINO_MINI_01"); //71BDAFD1"); //1908256721"); //1908256721
            ThemVoices.Add("A_M_Y_GOLFER_01_WHITE_FULL_01"); //DB7324F1"); //3681756401"); //ThemVoices.Add("613210895
            ThemVoices.Add("A_M_Y_GOLFER_01_WHITE_MINI_01"); //0F36AC80"); //255241344"); //255241344
            ThemVoices.Add("A_M_Y_HASJEW_01_WHITE_MINI_01"); //C4E78448"); //3303507016"); //ThemVoices.Add("991460280
            ThemVoices.Add("A_M_Y_HIPPY_01_WHITE_FULL_01"); //72E9121E"); //1927877150"); //1927877150
            ThemVoices.Add("A_M_Y_HIPPY_01_WHITE_MINI_01"); //A92E6392"); //2838389650"); //ThemVoices.Add("1456577646
            ThemVoices.Add("A_M_Y_HIPSTER_01_BLACK_FULL_01"); //4D67AAB4"); //1298639540"); //1298639540
            ThemVoices.Add("A_M_Y_HIPSTER_01_WHITE_FULL_01"); //93896827"); //2475255847"); //ThemVoices.Add("1819711449
            ThemVoices.Add("A_M_Y_HIPSTER_01_WHITE_MINI_01"); //B4EB0EBF"); //3035303615"); //ThemVoices.Add("1259663681
            ThemVoices.Add("A_M_Y_HIPSTER_02_WHITE_FULL_01"); //742FB44D"); //1949283405"); //1949283405
            ThemVoices.Add("A_M_Y_HIPSTER_02_WHITE_MINI_01"); //521933C3"); //1377383363"); //1377383363
            ThemVoices.Add("A_M_Y_HIPSTER_03_WHITE_FULL_01"); //E694D959"); //3868514649"); //ThemVoices.Add("426452647
            ThemVoices.Add("A_M_Y_HIPSTER_03_WHITE_MINI_01"); //B22C563F"); //2989250111"); //ThemVoices.Add("1305717185
            ThemVoices.Add("A_M_Y_KTOWN_01_KOREAN_FULL_01"); //285D1B2F"); //677190447"); //677190447
            ThemVoices.Add("A_M_Y_KTOWN_01_KOREAN_MINI_01"); //D97AF207"); //3648713223"); //ThemVoices.Add("646254073
            ThemVoices.Add("A_M_Y_KTOWN_02_KOREAN_FULL_01"); //7B3CEC0F"); //2067590159"); //2067590159
            ThemVoices.Add("A_M_Y_KTOWN_02_KOREAN_MINI_01"); //77B4E675"); //2008344181"); //2008344181
            ThemVoices.Add("A_M_Y_LATINO_01_LATINO_MINI_01"); //26ED66AF"); //653092527"); //653092527
            ThemVoices.Add("A_M_Y_LATINO_01_LATINO_MINI_02"); //C2429D5B"); //3259145563"); //ThemVoices.Add("1035821733
            ThemVoices.Add("A_M_Y_MEXTHUG_01_LATINO_FULL_01"); //5756D257"); //1465307735"); //1465307735
            ThemVoices.Add("A_M_Y_MUSCLBEAC_01_BLACK_FULL_01"); //C1B61E52"); //3249938002"); //ThemVoices.Add("1045029294
            ThemVoices.Add("A_M_Y_MUSCLBEAC_01_WHITE_FULL_01"); //0225E2F9"); //36037369"); //36037369
            ThemVoices.Add("A_M_Y_MUSCLBEAC_01_WHITE_MINI_01"); //977DC3C1"); //2541601729"); //ThemVoices.Add("1753365567
            ThemVoices.Add("A_M_Y_MUSCLBEAC_02_CHINESE_FULL_01"); //A6F52D1E"); //2801085726"); //ThemVoices.Add("1493881570
            ThemVoices.Add("A_M_Y_MUSCLBEAC_02_LATINO_FULL_01"); //67CCA113"); //1741463827"); //1741463827
            ThemVoices.Add("A_M_Y_POLYNESIAN_01_POLYNESIAN_FULL_01"); //121DA55B"); //303932763"); //303932763
            ThemVoices.Add("A_M_Y_RACER_01_WHITE_MINI_01"); //F64541B5"); //4131733941"); //ThemVoices.Add("163233355
            ThemVoices.Add("A_M_Y_ROLLERCOASTER_01_MINI_01"); //7DB0EDFB"); //2108747259"); //2108747259
            ThemVoices.Add("A_M_Y_ROLLERCOASTER_01_MINI_02"); //678FC1B9"); //1737474489"); //1737474489
            ThemVoices.Add("A_M_Y_ROLLERCOASTER_01_MINI_03"); //A3F33A7F"); //2750626431"); //ThemVoices.Add("1544340865
            ThemVoices.Add("A_M_Y_ROLLERCOASTER_01_MINI_04"); //962B9EF0"); //2519441136"); //ThemVoices.Add("1775526160
            ThemVoices.Add("A_M_Y_RUNNER_01_WHITE_FULL_01"); //F85796B7"); //4166489783"); //ThemVoices.Add("128477513
            ThemVoices.Add("A_M_Y_RUNNER_01_WHITE_MINI_01"); //6816D078"); //1746325624"); //1746325624
            ThemVoices.Add("A_M_Y_SALTON_01_WHITE_MINI_01"); //488C6273"); //1217159795"); //1217159795
            ThemVoices.Add("A_M_Y_SALTON_01_WHITE_MINI_02"); //5E6F8E25"); //1584369189"); //1584369189
            ThemVoices.Add("A_M_Y_SKATER_01_WHITE_FULL_01"); //1E6F76CB"); //510621387"); //510621387
            ThemVoices.Add("A_M_Y_SKATER_01_WHITE_MINI_01"); //41386857"); //1094215767"); //1094215767
            ThemVoices.Add("A_M_Y_SKATER_02_BLACK_FULL_01"); //46B9D99F"); //1186584991"); //1186584991
            ThemVoices.Add("A_M_Y_SOUCENT_01_BLACK_FULL_01"); //7ADB7C56"); //2061204566"); //2061204566
            ThemVoices.Add("A_M_Y_SOUCENT_02_BLACK_FULL_01"); //BA7414D7"); //3128169687"); //ThemVoices.Add("1166797609
            ThemVoices.Add("A_M_Y_SOUCENT_03_BLACK_FULL_01"); //997A83C0"); //2574943168"); //ThemVoices.Add("1720024128
            ThemVoices.Add("A_M_Y_SOUCENT_04_BLACK_FULL_01"); //97BA1740"); //2545555264"); //ThemVoices.Add("1749412032
            ThemVoices.Add("A_M_Y_SOUCENT_04_BLACK_MINI_01"); //E3DE23A6"); //3822986150"); //ThemVoices.Add("471981146
            ThemVoices.Add("A_M_Y_STBLA_01_BLACK_FULL_01"); //80372D5A"); //2151099738"); //ThemVoices.Add("2143867558
            ThemVoices.Add("A_M_Y_STBLA_02_BLACK_FULL_01"); //B77F38D5"); //3078568149"); //ThemVoices.Add("1216399147
            ThemVoices.Add("A_M_Y_STLAT_01_LATINO_FULL_01"); //AF739934"); //2943588660"); //ThemVoices.Add("1351378636
            ThemVoices.Add("A_M_Y_STLAT_01_LATINO_MINI_01"); //CDC7408D"); //3452387469"); //ThemVoices.Add("842579827
            ThemVoices.Add("A_M_Y_STWHI_01_WHITE_FULL_01"); //51843C65"); //1367620709"); //1367620709
            ThemVoices.Add("A_M_Y_STWHI_01_WHITE_MINI_01"); //283E7635"); //675182133"); //675182133
            ThemVoices.Add("A_M_Y_STWHI_02_WHITE_FULL_01"); //32F459E7"); //854874599"); //854874599
            ThemVoices.Add("A_M_Y_STWHI_02_WHITE_MINI_01"); //D94A1B14"); //3645512468"); //ThemVoices.Add("649454828
            ThemVoices.Add("A_M_Y_SUNBATHE_01_BLACK_FULL_01"); //523A66C3"); //1379559107"); //1379559107
            ThemVoices.Add("A_M_Y_SUNBATHE_01_WHITE_FULL_01"); //0CEA2526"); //216671526"); //216671526
            ThemVoices.Add("A_M_Y_SUNBATHE_01_WHITE_MINI_01"); //C31ADD04"); //3273317636"); //ThemVoices.Add("1021649660
            ThemVoices.Add("A_M_Y_TRIATHLON_01_MINI_01"); //55B488C4"); //1437894852"); //1437894852
            ThemVoices.Add("A_M_Y_TRIATHLON_01_MINI_02"); //87746C43"); //2272554051"); //ThemVoices.Add("2022413245
            ThemVoices.Add("A_M_Y_TRIATHLON_01_MINI_03"); //BB49D3ED"); //3142177773"); //ThemVoices.Add("1152789523
            ThemVoices.Add("A_M_Y_TRIATHLON_01_MINI_04"); //ED26B7A6"); //3978737574"); //ThemVoices.Add("316229722
            ThemVoices.Add("A_M_Y_VINEWOOD_01_BLACK_FULL_01"); //8567F85C"); //2238183516"); //ThemVoices.Add("2056783780
            ThemVoices.Add("A_M_Y_VINEWOOD_01_BLACK_MINI_01"); //0C746F67"); //208957287"); //208957287
            ThemVoices.Add("A_M_Y_VINEWOOD_02_WHITE_FULL_01"); //0A626D28"); //174222632"); //174222632
            ThemVoices.Add("A_M_Y_VINEWOOD_02_WHITE_MINI_01"); //C370059E"); //3278898590"); //ThemVoices.Add("1016068706
            ThemVoices.Add("A_M_Y_Vinewood_03_Latino_FULL_01"); //F450D2AC"); //4098937516"); //ThemVoices.Add("196029780
            ThemVoices.Add("A_M_Y_VINEWOOD_03_LATINO_MINI_01"); //9FDD31FF"); //2682073599"); //ThemVoices.Add("1612893697
            ThemVoices.Add("A_M_Y_VINEWOOD_03_WHITE_FULL_01"); //852D3A8F"); //2234333839"); //ThemVoices.Add("2060633457
            ThemVoices.Add("A_M_Y_VINEWOOD_03_WHITE_MINI_01"); //3A84F91E"); //981793054"); //981793054
            ThemVoices.Add("A_M_Y_VINEWOOD_04_WHITE_FULL_01"); //77B21017"); //2008158231"); //2008158231
            ThemVoices.Add("A_M_Y_VINEWOOD_04_WHITE_MINI_01"); //99DA0ADA"); //2581203674"); //ThemVoices.Add("1713763622
            ThemVoices.Add("BAILBOND1JUMPER"); //6909D3CC"); //1762251724"); //1762251724
            ThemVoices.Add("BAILBOND2JUMPER"); //8C257BBD"); //2351266749"); //ThemVoices.Add("1943700547
            ThemVoices.Add("BAILBOND3JUMPER"); //2E2EF1F8"); //774828536"); //774828536
            ThemVoices.Add("BAILBOND4JUMPER"); //643A0559"); //1681524057"); //1681524057
            ThemVoices.Add("BALLASOG"); //AAE4ECF8"); //2867129592"); //ThemVoices.Add("1427837704
            ThemVoices.Add("BANK"); //3A15DB98"); //974511000"); //974511000
            ThemVoices.Add("BANKWM1"); //CED9042B"); //3470328875"); //ThemVoices.Add("824638421
            ThemVoices.Add("BANKWM2"); //9C9B9FB1"); //2627444657"); //ThemVoices.Add("1667522639
            ThemVoices.Add("BARRY"); //A9058E54"); //2835713620"); //ThemVoices.Add("1459253676
            ThemVoices.Add("BARRY_01_ALIEN_A"); //82BA2086"); //2193236102"); //ThemVoices.Add("2101731194
            ThemVoices.Add("BARRY_01_ALIEN_B"); //7494843B"); //1955890235"); //1955890235
            ThemVoices.Add("BARRY_01_ALIEN_C"); //F06D7BEB"); //4033706987"); //ThemVoices.Add("261260309
            ThemVoices.Add("BARRY_02_CLOWN_A"); //7929F21D"); //2032792093"); //2032792093
            ThemVoices.Add("BARRY_02_CLOWN_B"); //66F4CDB3"); //1727319475"); //1727319475
            ThemVoices.Add("BARRY_02_CLOWN_C"); //9E16BBF6"); //2652290038"); //ThemVoices.Add("1642677258
            ThemVoices.Add("BAYGOR"); //7BF7A5D6"); //2079827414"); //2079827414
            ThemVoices.Add("BENNY"); //F1EB2693"); //4058719891"); //ThemVoices.Add("236247405
            ThemVoices.Add("BEVERLY"); //79D862EA"); //2044224234"); //2044224234
            ThemVoices.Add("BIKE_MECHANIC"); //573287EB"); //1462929387"); //1462929387
            ThemVoices.Add("BILLBINDER"); //4E43F344"); //1313076036"); //1313076036
            ThemVoices.Add("BJPILOT_CANAL"); //B75951F4"); //3076084212"); //ThemVoices.Add("1218883084
            ThemVoices.Add("BJPILOT_TRAIN"); //0FACABE0"); //262974432"); //262974432
            ThemVoices.Add("BRAD"); //57360243"); //1463157315"); //1463157315
            ThemVoices.Add("BREATHING_FRANKLIN_01"); //777E9106"); //2004783366"); //2004783366
            ThemVoices.Add("BREATHING_MICHAEL_01"); //CAB2CFFB"); //3400716283"); //ThemVoices.Add("894251013
            ThemVoices.Add("BREATHING_TEST_01"); //D75E8754"); //3613296468"); //ThemVoices.Add("681670828
            ThemVoices.Add("BREATHING_TREVOR_01"); //18092047"); //403251271"); //403251271
            ThemVoices.Add("BUSINESSMAN"); //3ECBA7BD"); //1053534141"); //1053534141
            ThemVoices.Add("CASEY"); //908C67DC"); //2425120732"); //ThemVoices.Add("1869846564
            ThemVoices.Add("CHAR_INTRO_FRANKLIN_01"); //420FF5A0"); //1108342176"); //1108342176
            ThemVoices.Add("CHAR_INTRO_MICHAEL_01"); //E4A08B92"); //3835726738"); //ThemVoices.Add("459240558
            ThemVoices.Add("CHAR_INTRO_TREVOR_01"); //8F52758F"); //2404545935"); //ThemVoices.Add("1890421361
            ThemVoices.Add("CHASTITY"); //9B4468A9"); //2604951721"); //ThemVoices.Add("1690015575
            ThemVoices.Add("CHASTITY_MP"); //4E0041AA"); //1308639658"); //1308639658
            ThemVoices.Add("CHEETAH"); //B1D95DA0"); //2983812512"); //ThemVoices.Add("1311154784
            ThemVoices.Add("CHEF"); //BF59CC9A"); //3210333338"); //ThemVoices.Add("1084633958
            ThemVoices.Add("CHENG"); //65BBBE48"); //1706802760"); //1706802760
            ThemVoices.Add("CLETUS"); //9B00816A"); //2600501610"); //ThemVoices.Add("1694465686
            ThemVoices.Add("CLINTON"); //2B502F45"); //726675269"); //726675269
            ThemVoices.Add("CLOWNS"); //D8088180"); //3624436096"); //ThemVoices.Add("670531200
            ThemVoices.Add("CONSTRUCTION_SITE_MALE_01"); //C285BFCA"); //3263545290"); //ThemVoices.Add("1031422006
            ThemVoices.Add("CONSTRUCTION_SITE_MALE_02"); //3572A596"); //896705942"); //896705942
            ThemVoices.Add("CONSTRUCTION_SITE_MALE_03"); //82A1C003"); //2191638531"); //ThemVoices.Add("2103328765
            ThemVoices.Add("CONSTRUCTION_SITE_MALE_04"); //93CE625C"); //2479776348"); //ThemVoices.Add("1815190948
            ThemVoices.Add("COOK"); //5673232D"); //1450386221"); //1450386221
            ThemVoices.Add("CST4ACTRESS"); //6A8C4C84"); //1787579524"); //1787579524
            ThemVoices.Add("DARYL"); //10088962"); //268994914"); //268994914
            ThemVoices.Add("DAVE"); //B1F68A9D"); //2985724573"); //ThemVoices.Add("1309242723
            ThemVoices.Add("DENISE"); //860AA79A"); //2248845210"); //ThemVoices.Add("2046122086
            ThemVoices.Add("DOM"); //BBF2D511"); //3153253649"); //ThemVoices.Add("1141713647
            ThemVoices.Add("EDDIE"); //C5FB1FF5"); //3321569269"); //ThemVoices.Add("973398027
            ThemVoices.Add("EXECPA_FEMALE"); //B6FB2A37"); //3069913655"); //ThemVoices.Add("1225053641
            ThemVoices.Add("EXECPA_MALE"); //0C5C69CC"); //207382988"); //207382988
            ThemVoices.Add("EXT1HELIPILOT"); //EF004581"); //4009772417"); //ThemVoices.Add("285194879
            ThemVoices.Add("FACILITY_ANNOUNCER"); //A9F8234D"); //2851611469"); //ThemVoices.Add("1443355827
            ThemVoices.Add("FLOYD"); //5E69D958"); //1583995224"); //1583995224
            ThemVoices.Add("FM"); //FFE20CE1"); //4293004513"); //ThemVoices.Add("1962783
            ThemVoices.Add("FM_TH"); //2640742C"); //641758252"); //641758252
            ThemVoices.Add("FRANKLIN_1_NORMAL"); //D603B047"); //3590565959"); //ThemVoices.Add("704401337
            ThemVoices.Add("FRANKLIN_2_NORMAL"); //9F8D1B67"); //2676824935"); //ThemVoices.Add("1618142361
            ThemVoices.Add("FRANKLIN_3_NORMAL"); //FA7C388C"); //4202444940"); //ThemVoices.Add("92522356
            ThemVoices.Add("FRANKLIN_ANGRY"); //D227A0A9"); //3525812393"); //ThemVoices.Add("769154903
            ThemVoices.Add("FRANKLIN_DRUNK"); //E6EFD5C5"); //3874477509"); //ThemVoices.Add("420489787
            ThemVoices.Add("FRANKLIN_NORMAL"); //64CCE782"); //1691150210"); //1691150210
            ThemVoices.Add("FUFU"); //ED8EA575"); //3985548661"); //ThemVoices.Add("309418635
            ThemVoices.Add("FUFU_MP"); //4EA343CA"); //1319322570"); //1319322570
            ThemVoices.Add("GARDENER"); //4260B7F4"); //1113634804"); //1113634804
            ThemVoices.Add("GAYMILITARY"); //212EBC3B"); //556710971"); //556710971
            ThemVoices.Add("GERALD"); //07DCC381"); //131908481"); //131908481
            ThemVoices.Add("GIRL1"); //9ABA4CB8"); //2595900600"); //ThemVoices.Add("1699066696
            ThemVoices.Add("GIRL2"); //C38C1E5B"); //3280739931"); //ThemVoices.Add("1014227365
            ThemVoices.Add("GRIFF"); //03DD4948"); //64833864"); //64833864
            ThemVoices.Add("GROOM"); //4A735AF1"); //1249073905"); //1249073905
            ThemVoices.Add("GUSTAVO"); //E5A7195C"); //3852933468"); //ThemVoices.Add("442033828
            ThemVoices.Add("G_F_Y_BALLAS_01_BLACK_MINI_01"); //15BB1C9C"); //364584092"); //364584092
            ThemVoices.Add("G_F_Y_BALLAS_01_BLACK_MINI_02"); //17F72114"); //402071828"); //402071828
            ThemVoices.Add("G_F_Y_BALLAS_01_BLACK_MINI_03"); //1D7F2C2C"); //494873644"); //494873644
            ThemVoices.Add("G_F_Y_BALLAS_01_BLACK_MINI_04"); //403F71AC"); //1077899692"); //1077899692
            ThemVoices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_01"); //4D341506"); //1295258886"); //1295258886
            ThemVoices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_02"); //69F34E84"); //1777553028"); //1777553028
            ThemVoices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_03"); //B0B85C0D"); //2964872205"); //ThemVoices.Add("1330095091
            ThemVoices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_04"); //5B7DB199"); //1534964121"); //1534964121
            ThemVoices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_05"); //85658568"); //2238023016"); //ThemVoices.Add("2056944280
            ThemVoices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_06"); //BFA0F9DE"); //3214997982"); //ThemVoices.Add("1079969314
            ThemVoices.Add("G_F_Y_VAGOS_01_LATINO_MINI_01"); //0320E887"); //52488327"); //52488327
            ThemVoices.Add("G_F_Y_VAGOS_01_LATINO_MINI_02"); //D6930F6C"); //3599961964"); //ThemVoices.Add("695005332
            ThemVoices.Add("G_F_Y_VAGOS_01_LATINO_MINI_03"); //7E0BDE5F"); //2114707039"); //2114707039
            ThemVoices.Add("G_F_Y_VAGOS_01_LATINO_MINI_04"); //8854F2F1"); //2287268593"); //ThemVoices.Add("2007698703
            ThemVoices.Add("G_M_M_ARMBOSS_01_WHITE_ARMENIAN_MINI_01"); //F840ABA3"); //4164987811"); //ThemVoices.Add("129979485
            ThemVoices.Add("G_M_M_ARMBOSS_01_WHITE_ARMENIAN_MINI_02"); //DD7F7641"); //3716118081"); //ThemVoices.Add("578849215
            ThemVoices.Add("G_M_M_ARMLIEUT_01_WHITE_ARMENIAN_MINI_01"); //9B88EB80"); //2609441664"); //ThemVoices.Add("1685525632
            ThemVoices.Add("G_M_M_ARMLIEUT_01_WHITE_ARMENIAN_MINI_02"); //8BCF4C0D"); //2345618445"); //ThemVoices.Add("1949348851
            ThemVoices.Add("G_M_M_CHIBOSS_01_CHINESE_MINI_01"); //FD2B8068"); //4247486568"); //ThemVoices.Add("47480728
            ThemVoices.Add("G_M_M_CHIBOSS_01_CHINESE_MINI_02"); //6EF5E41B"); //1861608475"); //1861608475
            ThemVoices.Add("G_M_M_CHIGOON_01_CHINESE_MINI_01"); //E8CB59DD"); //3905640925"); //ThemVoices.Add("389326371
            ThemVoices.Add("G_M_M_CHIGOON_01_CHINESE_MINI_02"); //F8FCFA40"); //4177328704"); //ThemVoices.Add("117638592
            ThemVoices.Add("G_M_M_CHIGOON_02_CHINESE_MINI_01"); //93D6B240"); //2480321088"); //ThemVoices.Add("1814646208
            ThemVoices.Add("G_M_M_CHIGOON_02_CHINESE_MINI_02"); //2138CD06"); //557370630"); //557370630
            ThemVoices.Add("G_M_M_KORBOSS_01_KOREAN_MINI_01"); //049ADD23"); //77258019"); //77258019
            ThemVoices.Add("G_M_M_KORBOSS_01_KOREAN_MINI_02"); //9DB98F56"); //2646183766"); //ThemVoices.Add("1648783530
            ThemVoices.Add("G_M_M_MEXBOSS_01_LATINO_MINI_01"); //121AC997"); //303745431"); //303745431
            ThemVoices.Add("G_M_M_MEXBOSS_01_LATINO_MINI_02"); //A86BF63B"); //2825647675"); //ThemVoices.Add("1469319621
            ThemVoices.Add("G_M_M_MEXBOSS_02_LATINO_MINI_01"); //FCB3B4DF"); //4239635679"); //ThemVoices.Add("55331617
            ThemVoices.Add("G_M_M_MEXBOSS_02_LATINO_MINI_02"); //59FC6F6F"); //1509715823"); //1509715823
            ThemVoices.Add("G_M_M_X17_RSO_01"); //7B4E71E9"); //2068738537"); //2068738537
            ThemVoices.Add("G_M_M_X17_RSO_02"); //0518057E"); //85460350"); //85460350
            ThemVoices.Add("G_M_M_X17_RSO_03"); //16232794"); //371402644"); //371402644
            ThemVoices.Add("G_M_M_X17_RSO_04"); //09AF0EA8"); //162467496"); //162467496
            ThemVoices.Add("G_M_Y_ARMGOON_02_WHITE_ARMENIAN_MINI_01"); //F98339EA"); //4186126826"); //ThemVoices.Add("108840470
            ThemVoices.Add("G_M_Y_ARMGOON_02_WHITE_ARMENIAN_MINI_02"); //91C4EA6B"); //2445601387"); //ThemVoices.Add("1849365909
            ThemVoices.Add("G_M_Y_BALLAEAST_01_BLACK_FULL_01"); //9CFAAA5C"); //2633673308"); //ThemVoices.Add("1661293988
            ThemVoices.Add("G_M_Y_BALLAEAST_01_BLACK_FULL_02"); //8F2D0EC1"); //2402094785"); //ThemVoices.Add("1892872511
            ThemVoices.Add("G_M_Y_BALLAEAST_01_BLACK_MINI_01"); //2C0FCD9F"); //739233183"); //739233183
            ThemVoices.Add("G_M_Y_BALLAEAST_01_BLACK_MINI_02"); //D5BE20F9"); //3586007289"); //ThemVoices.Add("708960007
            ThemVoices.Add("G_M_Y_BALLAEAST_01_BLACK_MINI_03"); //C77B8474"); //3346760820"); //ThemVoices.Add("948206476
            ThemVoices.Add("G_M_Y_BALLAORIG_01_BLACK_FULL_01"); //F0D6A527"); //4040598823"); //ThemVoices.Add("254368473
            ThemVoices.Add("G_M_Y_BALLAORIG_01_BLACK_FULL_02"); //DF4101FC"); //3745579516"); //ThemVoices.Add("549387780
            ThemVoices.Add("G_M_Y_BALLAORIG_01_BLACK_MINI_01"); //719C62A9"); //1906074281"); //1906074281
            ThemVoices.Add("G_M_Y_BALLAORIG_01_BLACK_MINI_02"); //AD1BD9A7"); //2904283559"); //ThemVoices.Add("1390683737
            ThemVoices.Add("G_M_Y_BALLAORIG_01_BLACK_MINI_03"); //925BA427"); //2455479335"); //ThemVoices.Add("1839487961
            ThemVoices.Add("G_M_Y_BALLASOUT_01_BLACK_FULL_01"); //60B320B0"); //1622352048"); //1622352048
            ThemVoices.Add("G_M_Y_BALLASOUT_01_BLACK_FULL_02"); //2A5033EB"); //709899243"); //709899243
            ThemVoices.Add("G_M_Y_BALLASOUT_01_BLACK_MINI_01"); //6ED150A0"); //1859211424"); //1859211424
            ThemVoices.Add("G_M_Y_BALLASOUT_01_BLACK_MINI_02"); //A00D3317"); //2685219607"); //ThemVoices.Add("1609747689
            ThemVoices.Add("G_M_Y_BALLASOUT_01_BLACK_MINI_03"); //BE746FE5"); //3195301861"); //ThemVoices.Add("1099665435
            ThemVoices.Add("G_M_Y_FAMCA_01_BLACK_FULL_01"); //3F299AE9"); //1059691241"); //1059691241
            ThemVoices.Add("G_M_Y_FAMCA_01_BLACK_FULL_02"); //51573F44"); //1364672324"); //1364672324
            ThemVoices.Add("G_M_Y_FAMCA_01_BLACK_MINI_01"); //D991FA9F"); //3650222751"); //ThemVoices.Add("644744545
            ThemVoices.Add("G_M_Y_FAMCA_01_BLACK_MINI_02"); //6B6D9E58"); //1802346072"); //1802346072
            ThemVoices.Add("G_M_Y_FAMCA_01_BLACK_MINI_03"); //0658D3F8"); //106484728"); //106484728
            ThemVoices.Add("G_M_Y_FAMDNF_01_BLACK_FULL_01"); //5F8F7FB9"); //1603239865"); //1603239865
            ThemVoices.Add("G_M_Y_FAMDNF_01_BLACK_FULL_02"); //B271257B"); //2993759611"); //ThemVoices.Add("1301207685
            ThemVoices.Add("G_M_Y_FAMDNF_01_BLACK_MINI_01"); //BA8A1C11"); //3129613329"); //ThemVoices.Add("1165353967
            ThemVoices.Add("G_M_Y_FAMDNF_01_BLACK_MINI_02"); //28A77842"); //682063938"); //682063938
            ThemVoices.Add("G_M_Y_FAMDNF_01_BLACK_MINI_03"); //D2384B6D"); //3526904685"); //ThemVoices.Add("768062611
            ThemVoices.Add("G_M_Y_FAMFOR_01_BLACK_FULL_01"); //4D505739"); //1297110841"); //1297110841
            ThemVoices.Add("G_M_Y_FAMFOR_01_BLACK_FULL_02"); //7FEB3C3E"); //2146122814"); //2146122814
            ThemVoices.Add("G_M_Y_FAMFOR_01_BLACK_MINI_01"); //FA83BCD1"); //4202937553"); //ThemVoices.Add("92029743
            ThemVoices.Add("G_M_Y_FAMFOR_01_BLACK_MINI_02"); //4721560B"); //1193367051"); //1193367051
            ThemVoices.Add("G_M_Y_FAMFOR_01_BLACK_MINI_03"); //56CEF566"); //1456403814"); //1456403814
            ThemVoices.Add("G_M_Y_KOREAN_01_KOREAN_MINI_01"); //3975B100"); //964014336"); //964014336
            ThemVoices.Add("G_M_Y_KOREAN_01_KOREAN_MINI_02"); //0F585CC6"); //257449158"); //257449158
            ThemVoices.Add("G_M_Y_KOREAN_02_KOREAN_MINI_01"); //E1E0349F"); //3789567135"); //ThemVoices.Add("505400161
            ThemVoices.Add("G_M_Y_KOREAN_02_KOREAN_MINI_02"); //D41A1913"); //3558480147"); //ThemVoices.Add("736487149
            ThemVoices.Add("G_M_Y_KORLIEUT_01_KOREAN_MINI_01"); //6B9A636E"); //1805280110"); //1805280110
            ThemVoices.Add("G_M_Y_KORLIEUT_01_KOREAN_MINI_02"); //2116CE64"); //555142756"); //555142756
            ThemVoices.Add("G_M_Y_LATINO01_LATINO_MINI_02"); //215F60FC"); //559898876"); //559898876
            ThemVoices.Add("G_M_Y_LOST_01_BLACK_FULL_01"); //BD922FD5"); //3180474325"); //ThemVoices.Add("1114492971
            ThemVoices.Add("G_M_Y_LOST_01_BLACK_FULL_02"); //06D7C263"); //114803299"); //114803299
            ThemVoices.Add("G_M_Y_LOST_01_BLACK_MINI_01"); //D03903FA"); //3493397498"); //ThemVoices.Add("801569798
            ThemVoices.Add("G_M_Y_LOST_01_BLACK_MINI_02"); //0154E631"); //22341169"); //22341169
            ThemVoices.Add("G_M_Y_LOST_01_BLACK_MINI_03"); //2ADE3943"); //719206723"); //719206723
            ThemVoices.Add("G_M_Y_LOST_01_WHITE_FULL_01"); //A29BB240"); //2728112704"); //ThemVoices.Add("1566854592
            ThemVoices.Add("G_M_Y_LOST_01_WHITE_MINI_01"); //0477B521"); //74954017"); //74954017
            ThemVoices.Add("G_M_Y_LOST_01_WHITE_MINI_02"); //D6005837"); //3590346807"); //ThemVoices.Add("704620489
            ThemVoices.Add("G_M_Y_LOST_02_LATINO_FULL_01"); //93D0C3D0"); //2479932368"); //ThemVoices.Add("1815034928
            ThemVoices.Add("G_M_Y_LOST_02_LATINO_FULL_02"); //DD9DD769"); //3718109033"); //ThemVoices.Add("576858263
            ThemVoices.Add("G_M_Y_LOST_02_LATINO_MINI_01"); //B4A96868"); //3031001192"); //ThemVoices.Add("1263966104
            ThemVoices.Add("G_M_Y_LOST_02_LATINO_MINI_02"); //C34E85B2"); //3276703154"); //ThemVoices.Add("1018264142
            ThemVoices.Add("G_M_Y_LOST_02_LATINO_MINI_03"); //D1C5229F"); //3519357599"); //ThemVoices.Add("775609697
            ThemVoices.Add("G_M_Y_LOST_02_WHITE_FULL_01"); //552D4F23"); //1429032739"); //1429032739
            ThemVoices.Add("G_M_Y_LOST_02_WHITE_MINI_01"); //AC382220"); //2889359904"); //ThemVoices.Add("1405607392
            ThemVoices.Add("G_M_Y_LOST_02_WHITE_MINI_02"); //302D2A08"); //808266248"); //808266248
            ThemVoices.Add("G_M_Y_LOST_03_WHITE_FULL_01"); //269A2029"); //647634985"); //647634985
            ThemVoices.Add("G_M_Y_LOST_03_WHITE_MINI_02"); //19793B32"); //427375410"); //427375410
            ThemVoices.Add("G_M_Y_LOST_03_WHITE_MINI_03"); //6C55606D"); //1817534573"); //1817534573
            ThemVoices.Add("G_M_Y_MEXGOON_01_LATINO_MINI_01"); //57C1000E"); //1472266254"); //1472266254
            ThemVoices.Add("G_M_Y_MEXGOON_01_LATINO_MINI_02"); //4F90EFAA"); //1334898602"); //1334898602
            ThemVoices.Add("G_M_Y_MEXGOON_02_LATINO_MINI_01"); //B00D3337"); //2953655095"); //ThemVoices.Add("1341312201
            ThemVoices.Add("G_M_Y_MEXGOON_02_LATINO_MINI_02"); //6A4227A2"); //1782720418"); //1782720418
            ThemVoices.Add("G_M_Y_MEXGOON_03_LATINO_MINI_01"); //36640278"); //912523896"); //912523896
            ThemVoices.Add("G_M_Y_MEXGOON_03_LATINO_MINI_02"); //45EBA187"); //1173070215"); //1173070215
            ThemVoices.Add("G_M_Y_POLOGOON_01_LATINO_MINI_01"); //D1389B20"); //3510147872"); //ThemVoices.Add("784819424
            ThemVoices.Add("G_M_Y_POLOGOON_01_LATINO_MINI_02"); //DBFFB0AE"); //3690967214"); //ThemVoices.Add("604000082
            ThemVoices.Add("G_M_Y_SALVABOSS_01_SALVADORIAN_MINI_01"); //083FF1D1"); //138408401"); //138408401
            ThemVoices.Add("G_M_Y_SALVABOSS_01_SALVADORIAN_MINI_02"); //FB1D578C"); //4213004172"); //ThemVoices.Add("81963124
            ThemVoices.Add("G_M_Y_SALVAGOON_01_SALVADORIAN_MINI_01"); //0E2D970B"); //237868811"); //237868811
            ThemVoices.Add("G_M_Y_SALVAGOON_01_SALVADORIAN_MINI_02"); //C9228CF6"); //3374484726"); //ThemVoices.Add("920482570
            ThemVoices.Add("G_M_Y_SALVAGOON_01_SALVADORIAN_MINI_03"); //D6DD286B"); //3604818027"); //ThemVoices.Add("690149269
            ThemVoices.Add("G_M_Y_SALVAGOON_02_SALVADORIAN_MINI_01"); //38FB557B"); //955995515"); //955995515
            ThemVoices.Add("G_M_Y_SalvaGoon_02_SALVADORIAN_MINI_02"); //2B1E39C1"); //723401153"); //723401153
            ThemVoices.Add("G_M_Y_SALVAGOON_02_SALVADORIAN_MINI_03"); //1C639C4C"); //476290124"); //476290124
            ThemVoices.Add("G_M_Y_SALVAGOON_03_SALVADORIAN_MINI_01"); //B2F150B6"); //3002159286"); //ThemVoices.Add("1292808010
            ThemVoices.Add("G_M_Y_SALVAGOON_03_SALVADORIAN_MINI_02"); //50C88C62"); //1355320418"); //1355320418
            ThemVoices.Add("G_M_Y_SalvaGoon_03_SALVADORIAN_MINI_03"); //61092CDF"); //1627991263"); //1627991263
            ThemVoices.Add("G_M_Y_STREETPUNK02_BLACK_MINI_04"); //5E2969AE"); //1579772334"); //1579772334
            ThemVoices.Add("G_M_Y_STREETPUNK_01_BLACK_MINI_01"); //A5364DA4"); //2771799460"); //ThemVoices.Add("1523167836
            ThemVoices.Add("G_M_Y_STREETPUNK_01_BLACK_MINI_02"); //7AD978EB"); //2061072619"); //2061072619
            ThemVoices.Add("G_M_Y_STREETPUNK_01_BLACK_MINI_03"); //4A3417A1"); //1244927905"); //1244927905
            ThemVoices.Add("G_M_Y_STREETPUNK_02_BLACK_MINI_01"); //4C3FB5C7"); //1279243719"); //1279243719
            ThemVoices.Add("G_M_Y_STREETPUNK_02_BLACK_MINI_02"); //658FE867"); //1703929959"); //1703929959
            ThemVoices.Add("G_M_Y_STREETPUNK_02_BLACK_MINI_03"); //58794E3A"); //1484344890"); //1484344890
            ThemVoices.Add("G_M_Y_X17_AGUARD_01"); //0FC95A0C"); //264854028"); //264854028
            ThemVoices.Add("G_M_Y_X17_AGUARD_02"); //1AEC7052"); //451702866"); //451702866
            ThemVoices.Add("G_M_Y_X17_AGUARD_03"); //ED3E94F7"); //3980301559"); //ThemVoices.Add("314665737
            ThemVoices.Add("G_M_Y_X17_AGUARD_04"); //71369CE9"); //1899404521"); //1899404521
            ThemVoices.Add("G_M_Y_X17_AGUARD_05"); //7B64B145"); //2070196549"); //2070196549
            ThemVoices.Add("HAO"); //5F91F8AE"); //1603401902"); //1603401902
            ThemVoices.Add("HEISTMANAGER"); //3F3FAB0F"); //1061137167"); //1061137167
            ThemVoices.Add("HOSTAGEBF1"); //D5D22CA5"); //3587320997"); //ThemVoices.Add("707646299
            ThemVoices.Add("HOSTAGEBM1"); //E8CB2CFF"); //3905629439"); //ThemVoices.Add("389337857
            ThemVoices.Add("HOSTAGEWF1"); //8632FA43"); //2251487811"); //ThemVoices.Add("2043479485
            ThemVoices.Add("HOSTAGEWF2"); //99952107"); //2576687367"); //ThemVoices.Add("1718279929
            ThemVoices.Add("HOSTAGEWM1"); //5779B631"); //1467594289"); //1467594289
            ThemVoices.Add("HOSTAGEWM2"); //9F53C5E4"); //2673067492"); //ThemVoices.Add("1621899804
            ThemVoices.Add("HUGH"); //F4EE78A9"); //4109269161"); //ThemVoices.Add("185698135
            ThemVoices.Add("IMPOTENT_RAGE"); //BE080ED8"); //3188199128"); //ThemVoices.Add("1106768168
            ThemVoices.Add("INFERNUS"); //18F25AC7"); //418536135"); //418536135
            ThemVoices.Add("JANE"); //893E74D0"); //2302571728"); //ThemVoices.Add("1992395568
            ThemVoices.Add("JANET"); //8498F40B"); //2224616459"); //ThemVoices.Add("2070350837
            ThemVoices.Add("JEROME"); //D982DA50"); //3649231440"); //ThemVoices.Add("645735856
            ThemVoices.Add("JESSE"); //916BB095"); //2439753877"); //ThemVoices.Add("1855213419
            ThemVoices.Add("JIMMY_DRUNK"); //43C1EB55"); //1136782165"); //1136782165
            ThemVoices.Add("JIMMY_NORMAL"); //95810242"); //2508259906"); //ThemVoices.Add("1786707390
            ThemVoices.Add("JOE"); //07CC375A"); //130824026"); //130824026
            ThemVoices.Add("JOSEF"); //F63ED80C"); //4131313676"); //ThemVoices.Add("163653620
            ThemVoices.Add("JOSH"); //F4DDE967"); //4108183911"); //ThemVoices.Add("186783385
            ThemVoices.Add("JULIET"); //27AD5D38"); //665673016"); //665673016
            ThemVoices.Add("KAREN"); //FBF9CDB2"); //4227452338"); //ThemVoices.Add("67514958
            ThemVoices.Add("KARIM"); //DB158746"); //3675621190"); //ThemVoices.Add("619346106
            ThemVoices.Add("KARL"); //D29BCDFD"); //3533426173"); //ThemVoices.Add("761541123
            ThemVoices.Add("KIDNAPPEDFEMALE"); //064DC6E9"); //105760489"); //105760489
            ThemVoices.Add("LACEY"); //29CAB776"); //701151094"); //701151094
            ThemVoices.Add("LAMAR"); //EA22BC4D"); //3928144973"); //ThemVoices.Add("366822323
            ThemVoices.Add("LAMAR_1_NORMAL"); //35FE7226"); //905867814"); //905867814
            ThemVoices.Add("LAMAR_2_NORMAL"); //25068D1D"); //621186333"); //621186333
            ThemVoices.Add("LAMAR_DRUNK"); //648A554F"); //1686787407"); //1686787407
            ThemVoices.Add("LAMAR_NORMAL"); //9D861581"); //2642810241"); //ThemVoices.Add("1652157055
            ThemVoices.Add("LESTER"); //8DB38846"); //2377353286"); //ThemVoices.Add("1917614010
            ThemVoices.Add("LIENGINEER"); //BD5D1E88"); //3176996488"); //ThemVoices.Add("1117970808
            ThemVoices.Add("LIENGINEER2"); //3A58B62B"); //978892331"); //978892331
            ThemVoices.Add("LI_FEMALE_01"); //E58E5187"); //3851309447"); //ThemVoices.Add("443657849
            ThemVoices.Add("LI_GEORGE_01"); //F22854E3"); //4062729443"); //ThemVoices.Add("232237853
            ThemVoices.Add("LI_LOBBY_01"); //3DB175B5"); //1035040181"); //1035040181
            ThemVoices.Add("LI_MALE_01"); //9CF88EB5"); //2633535157"); //ThemVoices.Add("1661432139
            ThemVoices.Add("LI_MALE_02"); //AAB22A28"); //2863802920"); //ThemVoices.Add("1431164376
            ThemVoices.Add("LOSTKIDNAPGIRL"); //7D8F4F88"); //2106544008"); //2106544008
            ThemVoices.Add("MAID"); //015EE6C7"); //22996679"); //22996679
            ThemVoices.Add("MALE_STRIP_DJ_WHITE"); //54825131"); //1417826609"); //1417826609
            ThemVoices.Add("MANI"); //9A9B1CC9"); //2593856713"); //ThemVoices.Add("1701110583
            ThemVoices.Add("MARNIE"); //5FA82CAC"); //1604857004"); //1604857004
            ThemVoices.Add("MARYANN"); //9FEEF145"); //2683236677"); //ThemVoices.Add("1611730619
            ThemVoices.Add("MAUDE"); //1AE32960"); //451094880"); //451094880
            ThemVoices.Add("MELVIN"); //558B495C"); //1435191644"); //1435191644
            ThemVoices.Add("MELVINSCIENTIST"); //E90C6953"); //3909904723"); //ThemVoices.Add("385062573
            ThemVoices.Add("MICHAEL_1_NORMAL"); //78BECF39"); //2025770809"); //2025770809
            ThemVoices.Add("MICHAEL_2_NORMAL"); //568D3564"); //1452094820"); //1452094820
            ThemVoices.Add("MICHAEL_3_NORMAL"); //FBC7F7B9"); //4224186297"); //ThemVoices.Add("70780999
            ThemVoices.Add("MICHAEL_ANGRY"); //973C5F18"); //2537316120"); //ThemVoices.Add("1757651176
            ThemVoices.Add("MICHAEL_DRUNK"); //DEBBCFA7"); //3736850343"); //ThemVoices.Add("558116953
            ThemVoices.Add("MICHAEL_NORMAL"); //C46897D1"); //3295188945"); //ThemVoices.Add("999778351
            ThemVoices.Add("MIME"); //5B25DA1F"); //1529207327"); //1529207327
            ThemVoices.Add("MISTERK"); //FF37663A"); //4281820730"); //ThemVoices.Add("13146566
            ThemVoices.Add("MPCT"); //FF02D40E"); //4278375438"); //ThemVoices.Add("16591858
            ThemVoices.Add("MP_M_SHOPKEEP_01_CHINESE_MINI_01"); //D36AF9E4"); //3547003364"); //ThemVoices.Add("747963932
            ThemVoices.Add("MP_M_SHOPKEEP_01_LATINO_MINI_01"); //0592C339"); //93504313"); //93504313
            ThemVoices.Add("MP_M_SHOPKEEP_01_PAKISTANI_MINI_01"); //25364924"); //624314660"); //624314660
            ThemVoices.Add("MP_RESIDENT"); //844127A9"); //2218862505"); //ThemVoices.Add("2076104791
            ThemVoices.Add("MRSTHORNHILL"); //C6DE44C8"); //3336455368"); //ThemVoices.Add("958511928
            ThemVoices.Add("NERVOUSRON"); //20251950"); //539302224"); //539302224
            ThemVoices.Add("NIGEL"); //F95E18F2"); //4183693554"); //ThemVoices.Add("111273742
            ThemVoices.Add("NIGHT_OUT_FEMALE_01"); //33A0908D"); //866160781"); //866160781
            ThemVoices.Add("NIGHT_OUT_FEMALE_02"); //49EBBD23"); //1240186147"); //1240186147
            ThemVoices.Add("NIGHT_OUT_FEMALE_03"); //831EAF88"); //2199826312"); //ThemVoices.Add("2095140984
            ThemVoices.Add("NIGHT_OUT_FEMALE_04"); //A56CF424"); //2775381028"); //ThemVoices.Add("1519586268
            ThemVoices.Add("NIGHT_OUT_MALE_01"); //41EC4175"); //1106002293"); //1106002293
            ThemVoices.Add("NIGHT_OUT_MALE_02"); //C428C5EC"); //3291006444"); //ThemVoices.Add("1003960852
            ThemVoices.Add("NIKKI"); //47F4D564"); //1207227748"); //1207227748
            ThemVoices.Add("NIKKI_MP"); //11515E1F"); //290545183"); //290545183
            ThemVoices.Add("NORM"); //AE21D168"); //2921451880"); //ThemVoices.Add("1373515416
            ThemVoices.Add("NO_VOICE"); //87BFF09A"); //2277503130"); //ThemVoices.Add("2017464166
            ThemVoices.Add("PACKIE"); //B8791A2F"); //3094944303"); //ThemVoices.Add("1200022993
            ThemVoices.Add("PACKIE_AI_NORM_PART1_BOOTH"); //E0D1A809"); //3771836425"); //ThemVoices.Add("523130871
            ThemVoices.Add("PAIGE"); //C2515320"); //3260109600"); //ThemVoices.Add("1034857696
            ThemVoices.Add("PAIN_FEMALE_01"); //40F0B1B8"); //1089515960"); //1089515960
            ThemVoices.Add("PAIN_FEMALE_02"); //D828602D"); //3626524717"); //ThemVoices.Add("668442579
            ThemVoices.Add("PAIN_FEMALE_NORMAL_01"); //6EF36D3C"); //1861446972"); //1861446972
            ThemVoices.Add("PAIN_FEMALE_NORMAL_02"); //5CECC92F"); //1559021871"); //1559021871
            ThemVoices.Add("PAIN_FEMALE_NORMAL_03"); //8AA3249B"); //2325947547"); //ThemVoices.Add("1969019749
            ThemVoices.Add("PAIN_FEMALE_NORMAL_04"); //78878064"); //2022146148"); //2022146148
            ThemVoices.Add("PAIN_FEMALE_NORMAL_05"); //2629DBA6"); //640277414"); //640277414
            ThemVoices.Add("PAIN_FEMALE_NORMAL_06"); //0BF1A736"); //200386358"); //200386358
            ThemVoices.Add("PAIN_FEMALE_NORMAL_07"); //41699229"); //1097437737"); //1097437737
            ThemVoices.Add("PAIN_FEMALE_NORMAL_08"); //374E7DEF"); //927890927"); //927890927
            ThemVoices.Add("PAIN_FEMALE_NORMAL_09"); //DCDE4910"); //3705555216"); //ThemVoices.Add("589412080
            ThemVoices.Add("PAIN_FEMALE_NORMAL_10"); //966B3B23"); //2523609891"); //ThemVoices.Add("1771357405
            ThemVoices.Add("PAIN_FEMALE_NORMAL_11"); //343976BD"); //876181181"); //876181181
            ThemVoices.Add("PAIN_FEMALE_NORMAL_12"); //21EAD220"); //569037344"); //569037344
            ThemVoices.Add("PAIN_FEMALE_TEST_01"); //95928372"); //2509407090"); //ThemVoices.Add("1785560206
            ThemVoices.Add("PAIN_FEMALE_TEST_02"); //AAE0AE0E"); //2866851342"); //ThemVoices.Add("1428115954
            ThemVoices.Add("PAIN_FEMALE_TEST_03"); //B89E4989"); //3097381257"); //ThemVoices.Add("1197586039
            ThemVoices.Add("PAIN_FRANKLIN_01"); //2003420C"); //537084428"); //537084428
            ThemVoices.Add("PAIN_FRANKLIN_02"); //EBF4D9F0"); //3958692336"); //ThemVoices.Add("336274960
            ThemVoices.Add("PAIN_FRANKLIN_03"); //1DA7BD55"); //497532245"); //497532245
            ThemVoices.Add("PAIN_FRANKLIN_04"); //C5B08D68"); //3316682088"); //ThemVoices.Add("978285208
            ThemVoices.Add("PAIN_MALE_MIXED_01"); //0A14C671"); //169133681"); //169133681
            ThemVoices.Add("PAIN_MALE_MIXED_02"); //A251F75D"); //2723280733"); //ThemVoices.Add("1571686563
            ThemVoices.Add("PAIN_MALE_MIXED_03"); //700712C8"); //1879511752"); //1879511752
            ThemVoices.Add("PAIN_MALE_MIXED_04"); //86A03FFA"); //2258649082"); //ThemVoices.Add("2036318214
            ThemVoices.Add("PAIN_MALE_MIXED_05"); //5124548F"); //1361335439"); //1361335439
            ThemVoices.Add("PAIN_MALE_MIXED_06"); //B25B96FC"); //2992346876"); //ThemVoices.Add("1302620420
            ThemVoices.Add("PAIN_MALE_MIXED_07"); //BC96AB72"); //3163990898"); //ThemVoices.Add("1130976398
            ThemVoices.Add("PAIN_MALE_MIXED_08"); //8DA5CD91"); //2376453521"); //ThemVoices.Add("1918513775
            ThemVoices.Add("PAIN_MALE_MIXED_09"); //97EBE21D"); //2548818461"); //ThemVoices.Add("1746148835
            ThemVoices.Add("PAIN_MALE_NORMAL_01"); //E3B792BC"); //3820458684"); //ThemVoices.Add("474508612
            ThemVoices.Add("PAIN_MALE_NORMAL_02"); //145573EB"); //341144555"); //341144555
            ThemVoices.Add("PAIN_MALE_NORMAL_03"); //E296906E"); //3801518190"); //ThemVoices.Add("493449106
            ThemVoices.Add("PAIN_MALE_NORMAL_04"); //B7C53ACC"); //3083156172"); //ThemVoices.Add("1211811124
            ThemVoices.Add("PAIN_MALE_NORMAL_05"); //09F45F29"); //167010089"); //167010089
            ThemVoices.Add("PAIN_MALE_NORMAL_06"); //CB49E1D5"); //3410616789"); //ThemVoices.Add("884350507
            ThemVoices.Add("PAIN_MALE_TOUGH_01"); //ACC806D0"); //2898790096"); //ThemVoices.Add("1396177200
            ThemVoices.Add("PAIN_MALE_TOUGH_02"); //DB33E3A7"); //3677610919"); //ThemVoices.Add("617356377
            ThemVoices.Add("PAIN_MALE_TOUGH_03"); //90FF4F3B"); //2432651067"); //ThemVoices.Add("1862316229
            ThemVoices.Add("PAIN_MALE_TOUGH_04"); //BF202B80"); //3206556544"); //ThemVoices.Add("1088410752
            ThemVoices.Add("PAIN_MALE_TOUGH_05"); //F397946E"); //4086797422"); //ThemVoices.Add("208169874
            ThemVoices.Add("PAIN_MALE_WEAK_01"); //22C36EE8"); //583233256"); //583233256
            ThemVoices.Add("PAIN_MALE_WEAK_02"); //B05B0A1D"); //2958756381"); //ThemVoices.Add("1336210915
            ThemVoices.Add("PAIN_MALE_WEAK_03"); //D62355AD"); //3592639917"); //ThemVoices.Add("702327379
            ThemVoices.Add("PAIN_MALE_WEAK_04"); //E61CF5A0"); //3860657568"); //ThemVoices.Add("434309728
            ThemVoices.Add("PAIN_MICHAEL_01"); //E657BAA9"); //3864509097"); //ThemVoices.Add("430458199
            ThemVoices.Add("PAIN_MICHAEL_02"); //D8151E24"); //3625262628"); //ThemVoices.Add("669704668
            ThemVoices.Add("PAIN_MICHAEL_03"); //3436D666"); //876009062"); //876009062
            ThemVoices.Add("PAIN_MICHAEL_04"); //66EB3BD2"); //1726692306"); //1726692306
            ThemVoices.Add("PAIN_PLAYER_TEST_01"); //F38B2CC2"); //4085984450"); //ThemVoices.Add("208982846
            ThemVoices.Add("PAIN_PLAYER_TEST_02"); //E161886F"); //3781265519"); //ThemVoices.Add("513701777
            ThemVoices.Add("PAIN_PLAYER_TEST_03"); //576C746B"); //1466725483"); //1466725483
            ThemVoices.Add("PAIN_TEST_01"); //F5655828"); //4117059624"); //ThemVoices.Add("177907672
            ThemVoices.Add("PAIN_TEST_02"); //FC1C6596"); //4229719446"); //ThemVoices.Add("65247850
            ThemVoices.Add("PAIN_TEST_03"); //172E9BA2"); //388930466"); //388930466
            ThemVoices.Add("PAIN_TREVOR_01"); //21261ADB"); //556145371"); //556145371
            ThemVoices.Add("PAIN_TREVOR_02"); //32DCBE48"); //853327432"); //853327432
            ThemVoices.Add("PAIN_TREVOR_03"); //3DAED3EC"); //1034867692"); //1034867692
            ThemVoices.Add("PAIN_TREVOR_04"); //4F427713"); //1329755923"); //1329755923
            ThemVoices.Add("PAMELA_DRAKE"); //714E62B7"); //1900962487"); //1900962487
            ThemVoices.Add("PANIC_WALLA"); //14DEB561"); //350139745"); //350139745
            ThemVoices.Add("PATRICIA"); //D22B34C3"); //3526046915"); //ThemVoices.Add("768920381
            ThemVoices.Add("PEACH"); //FE7FCDEA"); //4269788650"); //ThemVoices.Add("25178646
            ThemVoices.Add("PEYOTE_ATTRACT_BOAR"); //44E0B0C1"); //1155576001"); //1155576001
            ThemVoices.Add("PEYOTE_ATTRACT_CAT"); //957D8693"); //2508031635"); //ThemVoices.Add("1786935661
            ThemVoices.Add("PEYOTE_ATTRACT_CHICKENHAWK"); //37642D77"); //929312119"); //929312119
            ThemVoices.Add("PEYOTE_ATTRACT_CORMORANT"); //25B89DC4"); //632856004"); //632856004
            ThemVoices.Add("PEYOTE_ATTRACT_COW"); //D18269E8"); //3514984936"); //ThemVoices.Add("779982360
            ThemVoices.Add("PEYOTE_ATTRACT_COYOTE"); //CACF8A4A"); //3402598986"); //ThemVoices.Add("892368310
            ThemVoices.Add("PEYOTE_ATTRACT_CROW"); //4ECC966B"); //1322030699"); //1322030699
            ThemVoices.Add("PEYOTE_ATTRACT_DEER"); //F0A3CD5D"); //4037266781"); //ThemVoices.Add("257700515
            ThemVoices.Add("PEYOTE_ATTRACT_DOLPHIN"); //59448EA4"); //1497665188"); //1497665188
            ThemVoices.Add("PEYOTE_ATTRACT_HEN"); //E2D7CD2E"); //3805793582"); //ThemVoices.Add("489173714
            ThemVoices.Add("PEYOTE_ATTRACT_HUSKY"); //3E0E6964"); //1041131876"); //1041131876
            ThemVoices.Add("PEYOTE_ATTRACT_MTLION"); //14EF12E9"); //351212265"); //351212265
            ThemVoices.Add("PEYOTE_ATTRACT_PIG"); //49848323"); //1233421091"); //1233421091
            ThemVoices.Add("PEYOTE_ATTRACT_PIGEON"); //8E48AAC7"); //2387126983"); //ThemVoices.Add("1907840313
            ThemVoices.Add("PEYOTE_ATTRACT_RABBIT"); //93CBB169"); //2479599977"); //ThemVoices.Add("1815367319
            ThemVoices.Add("PEYOTE_ATTRACT_RETRIEVER"); //7B353C1A"); //2067086362"); //2067086362
            ThemVoices.Add("PEYOTE_ATTRACT_ROTTWEILER"); //0131CB79"); //20040569"); //20040569
            ThemVoices.Add("PEYOTE_ATTRACT_SASQUATCH"); //068101D6"); //109117910"); //109117910
            ThemVoices.Add("PEYOTE_ATTRACT_SEAGULL"); //427EF9C8"); //1115617736"); //1115617736
            ThemVoices.Add("PEYOTE_ATTRACT_SEA_CREATURE"); //5A3979EC"); //1513716204"); //1513716204
            ThemVoices.Add("PEYOTE_ATTRACT_SHEPHERD"); //5CA8ACB0"); //1554558128"); //1554558128
            ThemVoices.Add("PEYOTE_ATTRACT_SMALL_DOG"); //517711B0"); //1366757808"); //1366757808
            ThemVoices.Add("PIER_ANNOUNCE_FEMALE"); //3AB5E64D"); //984999501"); //984999501
            ThemVoices.Add("PIER_ANNOUNCE_MALE"); //9567A0E1"); //2506596577"); //ThemVoices.Add("1788370719
            ThemVoices.Add("PIER_FOLEY"); //58EA9491"); //1491768465"); //1491768465
            ThemVoices.Add("PLAYER_RINGTONES"); //3A3B02D3"); //976945875"); //976945875
            ThemVoices.Add("PRISONER"); //7EA26372"); //2124571506"); //2124571506
            ThemVoices.Add("PRISON_ANNOUNCER"); //9BEE7F20"); //2616098592"); //ThemVoices.Add("1678868704
            ThemVoices.Add("PRISON_TANNOY"); //E5DCB564"); //3856446820"); //ThemVoices.Add("438520476
            ThemVoices.Add("REDOCASTRO"); //CED55457"); //3470087255"); //ThemVoices.Add("824880041
            ThemVoices.Add("REDR1DRUNK1"); //4184DA81"); //1099225729"); //1099225729
            ThemVoices.Add("REDR1DRUNK1_AI_DRUNK"); //2B10FBD7"); //722533335"); //722533335
            ThemVoices.Add("REDR2DRUNKM"); //51408669"); //1363183209"); //1363183209
            ThemVoices.Add("REHH2HIKER"); //92977683"); //2459399811"); //ThemVoices.Add("1835567485
            ThemVoices.Add("REHH3HIPSTER"); //C0147C2B"); //3222567979"); //ThemVoices.Add("1072399317
            ThemVoices.Add("REHH5BRIDE"); //923B42A5"); //2453357221"); //ThemVoices.Add("1841610075
            ThemVoices.Add("REHOMGIRL"); //745E2A7D"); //1952328317"); //1952328317
            ThemVoices.Add("REPRI1LOST"); //4E9991FE"); //1318687230"); //1318687230
            ThemVoices.Add("SAPPHIRE"); //74F8F352"); //1962472274"); //1962472274
            ThemVoices.Add("SECUROMECH"); //9C7CE8C0"); //2625431744"); //ThemVoices.Add("1669535552
            ThemVoices.Add("SHOPASSISTANT"); //53912D70"); //1402023280"); //1402023280
            ThemVoices.Add("SIMEON"); //82816017"); //2189516823"); //ThemVoices.Add("2105450473
            ThemVoices.Add("SOL1ACTOR"); //4B0CAD83"); //1259122051"); //1259122051
            ThemVoices.Add("SPACE_RANGER"); //21D80107"); //567804167"); //567804167
            ThemVoices.Add("STEVE"); //CE95B9A9"); //3465918889"); //ThemVoices.Add("829048407
            ThemVoices.Add("STRETCH"); //8B13F083"); //2333339779"); //ThemVoices.Add("1961627517
            ThemVoices.Add("SUBWAY_ANNOUNCER"); //1C2F9BF2"); //472882162"); //472882162
            ThemVoices.Add("S_F_M_FEMBARBER_BLACK_MINI_01"); //4B82A928"); //1266854184"); //1266854184
            ThemVoices.Add("S_F_M_GENERICCHEAPWORKER_01_LATINO_MINI_01"); //E085EF87"); //3766873991"); //ThemVoices.Add("528093305
            ThemVoices.Add("S_F_M_GENERICCHEAPWORKER_01_LATINO_MINI_02"); //EA440303"); //3930325763"); //ThemVoices.Add("364641533
            ThemVoices.Add("S_F_M_GENERICCHEAPWORKER_01_LATINO_MINI_03"); //51565112"); //1364611346"); //1364611346
            ThemVoices.Add("S_F_M_PONSEN_01_BLACK_01"); //B60A191B"); //3054115099"); //ThemVoices.Add("1240852197
            ThemVoices.Add("S_F_M_SHOP_HIGH_WHITE_MINI_01"); //AD7E25AA"); //2910725546"); //ThemVoices.Add("1384241750
            ThemVoices.Add("S_F_Y_AIRHOSTESS_01_BLACK_FULL_01"); //50B140C7"); //1353793735"); //1353793735
            ThemVoices.Add("S_F_Y_AIRHOSTESS_01_BLACK_FULL_02"); //D0FFC16E"); //3506422126"); //ThemVoices.Add("788545170
            ThemVoices.Add("S_F_Y_AIRHOSTESS_01_WHITE_FULL_01"); //090B4CD4"); //151735508"); //151735508
            ThemVoices.Add("S_F_Y_AIRHOSTESS_01_WHITE_FULL_02"); //E1B67E2B"); //3786833451"); //ThemVoices.Add("508133845
            ThemVoices.Add("S_F_Y_BAYWATCH_01_BLACK_FULL_01"); //F33860E9"); //4080558313"); //ThemVoices.Add("214408983
            ThemVoices.Add("S_F_Y_BAYWATCH_01_BLACK_FULL_02"); //880F0A98"); //2282687128"); //ThemVoices.Add("2012280168
            ThemVoices.Add("S_F_Y_BAYWATCH_01_WHITE_FULL_01"); //26DECE02"); //652135938"); //652135938
            ThemVoices.Add("S_F_Y_BAYWATCH_01_WHITE_FULL_02"); //35226A89"); //891447945"); //891447945
            ThemVoices.Add("S_F_Y_Cop_01_BLACK_FULL_01"); //EFB0FA91"); //4021353105"); //ThemVoices.Add("273614191
            ThemVoices.Add("S_F_Y_COP_01_BLACK_FULL_02"); //62A6E07B"); //1655103611"); //1655103611
            ThemVoices.Add("S_F_Y_COP_01_WHITE_FULL_01"); //EB73C44F"); //3950232655"); //ThemVoices.Add("344734641
            ThemVoices.Add("S_F_Y_COP_01_WHITE_FULL_02"); //F9C560F2"); //4190462194"); //ThemVoices.Add("104505102
            ThemVoices.Add("S_F_Y_GENERICCHEAPWORKER_01_BLACK_MINI_01"); //44ACE464"); //1152181348"); //1152181348
            ThemVoices.Add("S_F_Y_GENERICCHEAPWORKER_01_BLACK_MINI_02"); //3707C91A"); //923257114"); //923257114
            ThemVoices.Add("S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_01"); //A135DE73"); //2704662131"); //ThemVoices.Add("1590305165
            ThemVoices.Add("S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_02"); //CF08BA18"); //3473455640"); //ThemVoices.Add("821511656
            ThemVoices.Add("S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_03"); //BC269454"); //3156644948"); //ThemVoices.Add("1138322348
            ThemVoices.Add("S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_04"); //EB8E7323"); //3951981347"); //ThemVoices.Add("342985949
            ThemVoices.Add("S_F_Y_GENERICCHEAPWORKER_01_WHITE_MINI_01"); //E5EAA67A"); //3857360506"); //ThemVoices.Add("437606790
            ThemVoices.Add("S_F_Y_GENERICCHEAPWORKER_01_WHITE_MINI_02"); //39B64E08"); //968248840"); //968248840
            ThemVoices.Add("S_F_Y_HOOKER_01_WHITE_FULL_01"); //18B73C7E"); //414661758"); //414661758
            ThemVoices.Add("S_F_Y_HOOKER_01_WHITE_FULL_02"); //66F658FB"); //1727420667"); //1727420667
            ThemVoices.Add("S_F_Y_HOOKER_01_WHITE_FULL_03"); //75E576D9"); //1977972441"); //1977972441
            ThemVoices.Add("S_F_Y_HOOKER_02_WHITE_FULL_01"); //77BE674B"); //2008966987"); //2008966987
            ThemVoices.Add("S_F_Y_HOOKER_02_WHITE_FULL_02"); //09978AFF"); //160926463"); //160926463
            ThemVoices.Add("S_F_Y_HOOKER_02_WHITE_FULL_03"); //1B382E40"); //456666688"); //456666688
            ThemVoices.Add("S_F_Y_HOOKER_03_BLACK_FULL_01"); //875814D6"); //2270696662"); //ThemVoices.Add("2024270634
            ThemVoices.Add("S_F_Y_HOOKER_03_BLACK_FULL_03"); //129DAB5F"); //312322911"); //312322911
            ThemVoices.Add("S_F_Y_PECKER_01_WHITE_01"); //6B019062"); //1795264610"); //1795264610
            ThemVoices.Add("S_F_Y_RANGER_01_WHITE_MINI_01"); //47A85382"); //1202213762"); //1202213762
            ThemVoices.Add("S_F_Y_SHOP_LOW_WHITE_MINI_01"); //ED77E493"); //3984057491"); //ThemVoices.Add("310909805
            ThemVoices.Add("S_F_Y_SHOP_MID_WHITE_MINI_01"); //77B47F14"); //2008317716"); //2008317716
            ThemVoices.Add("S_M_M_AMMUCOUNTRY_01_WHITE_01"); //14AE106F"); //346951791"); //346951791
            ThemVoices.Add("S_M_M_AMMUCOUNTRY_WHITE_MINI_01"); //B6A5CF41"); //3064319809"); //ThemVoices.Add("1230647487
            ThemVoices.Add("S_M_M_AUTOSHOP_01_WHITE_01"); //B97E410A"); //3112059146"); //ThemVoices.Add("1182908150
            ThemVoices.Add("S_M_M_BOUNCER_01_BLACK_FULL_01"); //5CF368B8"); //1559455928"); //1559455928
            ThemVoices.Add("S_M_M_BOUNCER_01_LATINO_FULL_01"); //57B91BD3"); //1471749075"); //1471749075
            ThemVoices.Add("S_M_M_BOUNCER_LATINO_FULL_01"); //66E1CE62"); //1726074466"); //1726074466
            ThemVoices.Add("S_M_M_CIASEC_01_BLACK_MINI_01"); //797CD9E6"); //2038225382"); //2038225382
            ThemVoices.Add("S_M_M_CIASEC_01_BLACK_MINI_02"); //F6AED44C"); //4138652748"); //ThemVoices.Add("156314548
            ThemVoices.Add("S_M_M_CIASEC_01_WHITE_MINI_01"); //7DB88D9D"); //2109246877"); //2109246877
            ThemVoices.Add("S_M_M_CIASEC_01_WHITE_MINI_02"); //AF77F11B"); //2943873307"); //ThemVoices.Add("1351093989
            ThemVoices.Add("S_M_M_FIBOFFICE_01_BLACK_MINI_01"); //DEA5CD64"); //3735407972"); //ThemVoices.Add("559559324
            ThemVoices.Add("S_M_M_FIBOFFICE_01_BLACK_MINI_02"); //F0C0F19A"); //4039176602"); //ThemVoices.Add("255790694
            ThemVoices.Add("S_M_M_FIBOFFICE_01_LATINO_MINI_01"); //655117C7"); //1699813319"); //1699813319
            ThemVoices.Add("S_M_M_FIBOFFICE_01_LATINO_MINI_02"); //938DF440"); //2475553856"); //ThemVoices.Add("1819413440
            ThemVoices.Add("S_M_M_FIBOFFICE_01_WHITE_MINI_01"); //0AC9249C"); //180954268"); //180954268
            ThemVoices.Add("S_M_M_FIBOFFICE_01_WHITE_MINI_02"); //FE040B12"); //4261677842"); //ThemVoices.Add("33289454
            ThemVoices.Add("S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_01"); //90328A79"); //2419231353"); //ThemVoices.Add("1875735943
            ThemVoices.Add("S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_02"); //D9249C5C"); //3643055196"); //ThemVoices.Add("651912100
            ThemVoices.Add("S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_03"); //EBDDC1CE"); //3957178830"); //ThemVoices.Add("337788466
            ThemVoices.Add("S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_04"); //635D30CB"); //1667051723"); //1667051723
            ThemVoices.Add("S_M_M_GENERICMARINE_01_LATINO_MINI_01"); //24A78E34"); //614960692"); //614960692
            ThemVoices.Add("S_M_M_GENERICMARINE_01_LATINO_MINI_02"); //8F6E63C0"); //2406376384"); //ThemVoices.Add("1888590912
            ThemVoices.Add("S_M_M_GENERICMECHANIC_01_BLACK_MINI_01"); //229CDFDF"); //580706271"); //580706271
            ThemVoices.Add("S_M_M_GENERICMECHANIC_01_BLACK_MINI_02"); //09392D18"); //154742040"); //154742040
            ThemVoices.Add("S_M_M_GENERICPOSTWORKER_01_BLACK_MINI_01"); //10C0CBFD"); //281070589"); //281070589
            ThemVoices.Add("S_M_M_GENERICPOSTWORKER_01_BLACK_MINI_02"); //FC16A2A9"); //4229341865"); //ThemVoices.Add("65625431
            ThemVoices.Add("S_M_M_GENERICPOSTWORKER_01_WHITE_MINI_01"); //D2C75726"); //3536279334"); //ThemVoices.Add("758687962
            ThemVoices.Add("S_M_M_GENERICPOSTWORKER_01_WHITE_MINI_02"); //DC906AB8"); //3700452024"); //ThemVoices.Add("594515272
            ThemVoices.Add("S_M_M_GENERICSECURITY_01_BLACK_MINI_01"); //3D1D46D3"); //1025328851"); //1025328851
            ThemVoices.Add("S_M_M_GENERICSECURITY_01_BLACK_MINI_02"); //565A794D"); //1448769869"); //1448769869
            ThemVoices.Add("S_M_M_GENERICSECURITY_01_BLACK_MINI_03"); //9162EF15"); //2439180053"); //ThemVoices.Add("1855787243
            ThemVoices.Add("S_M_M_GENERICSECURITY_01_LATINO_MINI_01"); //B5910C1D"); //3046181917"); //ThemVoices.Add("1248785379
            ThemVoices.Add("S_M_M_GENERICSECURITY_01_LATINO_MINI_02"); //97D1D09F"); //2547110047"); //ThemVoices.Add("1747857249
            ThemVoices.Add("S_M_M_GENERICSECURITY_01_WHITE_MINI_01"); //5D4BE0A9"); //1565253801"); //1565253801
            ThemVoices.Add("S_M_M_GENERICSECURITY_01_WHITE_MINI_02"); //4FE145D4"); //1340163540"); //1340163540
            ThemVoices.Add("S_M_M_GENERICSECURITY_01_WHITE_MINI_03"); //66DDF3D9"); //1725821913"); //1725821913
            ThemVoices.Add("S_M_M_HAIRDRESSER_01_BLACK_MINI_01"); //594BCB86"); //1498139526"); //1498139526
            ThemVoices.Add("S_M_M_HAIRDRESS_01_BLACK_01"); //7E2CBE66"); //2116861542"); //2116861542
            ThemVoices.Add("S_M_M_PARAMEDIC_01_BLACK_MINI_01"); //1DE649B3"); //501631411"); //501631411
            ThemVoices.Add("S_M_M_PARAMEDIC_01_LATINO_MINI_01"); //43261273"); //1126568563"); //1126568563
            ThemVoices.Add("S_M_M_PARAMEDIC_01_WHITE_MINI_01"); //54925FD6"); //1418878934"); //1418878934
            ThemVoices.Add("S_M_M_PILOT_01_BLACK_FULL_01"); //3DAC41B0"); //1034699184"); //1034699184
            ThemVoices.Add("S_M_M_PILOT_01_BLACK_FULL_02"); //4F73E53F"); //1332995391"); //1332995391
            ThemVoices.Add("S_M_M_PILOT_01_WHITE_FULL_01"); //BC0F504A"); //3155120202"); //ThemVoices.Add("1139847094
            ThemVoices.Add("S_M_M_PILOT_01_WHITE_FULL_02"); //A9A32B72"); //2846042994"); //ThemVoices.Add("1448924302
            ThemVoices.Add("S_M_M_TRUCKER_01_BLACK_FULL_01"); //D940A3BC"); //3644892092"); //ThemVoices.Add("650075204
            ThemVoices.Add("S_M_M_TRUCKER_01_WHITE_FULL_01"); //3CA3269A"); //1017325210"); //1017325210
            ThemVoices.Add("S_M_M_TRUCKER_01_WHITE_FULL_02"); //0B4743DF"); //189219807"); //189219807
            ThemVoices.Add("S_M_Y_AIRWORKER_BLACK_FULL_01"); //90ECCFDC"); //2431438812"); //ThemVoices.Add("1863528484
            ThemVoices.Add("S_M_Y_AIRWORKER_BLACK_FULL_02"); //9EAF6B61"); //2662296417"); //ThemVoices.Add("1632670879
            ThemVoices.Add("S_M_Y_AIRWORKER_LATINO_FULL_01"); //0D981AB3"); //228072115"); //228072115
            ThemVoices.Add("S_M_Y_AIRWORKER_LATINO_FULL_02"); //234F4621"); //592397857"); //592397857
            ThemVoices.Add("S_M_Y_AMMUCITY_01_WHITE_01"); //5C7526F0"); //1551181552"); //1551181552
            ThemVoices.Add("S_M_Y_AMMUCITY_01_WHITE_MINI_01"); //20C18390"); //549553040"); //549553040
            ThemVoices.Add("S_M_Y_BAYWATCH_01_BLACK_FULL_01"); //CD79387C"); //3447273596"); //ThemVoices.Add("847693700
            ThemVoices.Add("S_M_Y_BAYWATCH_01_BLACK_FULL_02"); //E32263CE"); //3810681806"); //ThemVoices.Add("484285490
            ThemVoices.Add("S_M_Y_BAYWATCH_01_WHITE_FULL_01"); //BAB6D724"); //3132544804"); //ThemVoices.Add("1162422492
            ThemVoices.Add("S_M_Y_BAYWATCH_01_WHITE_FULL_02"); //1EA89F06"); //514367238"); //514367238
            ThemVoices.Add("S_M_Y_BLACKOPS_01_BLACK_MINI_01"); //BBE7E188"); //3152535944"); //ThemVoices.Add("1142431352
            ThemVoices.Add("S_M_Y_BLACKOPS_01_BLACK_MINI_02"); //DDB7A52B"); //3719800107"); //ThemVoices.Add("575167189
            ThemVoices.Add("S_M_Y_BLACKOPS_01_WHITE_MINI_01"); //65B98207"); //1706656263"); //1706656263
            ThemVoices.Add("S_M_Y_BLACKOPS_01_WHITE_MINI_02"); //D7FFE692"); //3623872146"); //ThemVoices.Add("671095150
            ThemVoices.Add("S_M_Y_BLACKOPS_02_LATINO_MINI_01"); //4214AE9E"); //1108651678"); //1108651678
            ThemVoices.Add("S_M_Y_BLACKOPS_02_LATINO_MINI_02"); //13E2520A"); //333599242"); //333599242
            ThemVoices.Add("S_M_Y_BLACKOPS_02_WHITE_MINI_01"); //C3A6E830"); //3282495536"); //ThemVoices.Add("1012471760
            ThemVoices.Add("S_M_Y_BUSBOY_01_WHITE_MINI_01"); //C847EAA9"); //3360156329"); //ThemVoices.Add("934810967
            ThemVoices.Add("S_M_Y_COP_01_BLACK_FULL_01"); //DD72FE87"); //3715300999"); //ThemVoices.Add("579666297
            ThemVoices.Add("S_M_Y_COP_01_BLACK_FULL_02"); //C7B3D309"); //3350450953"); //ThemVoices.Add("944516343
            ThemVoices.Add("S_M_Y_COP_01_BLACK_MINI_01"); //EF2409AE"); //4012116398"); //ThemVoices.Add("282850898
            ThemVoices.Add("S_M_Y_COP_01_BLACK_MINI_02"); //00CDAD01"); //13479169"); //13479169
            ThemVoices.Add("S_M_Y_COP_01_BLACK_MINI_03"); //4A804065"); //1249919077"); //1249919077
            ThemVoices.Add("S_M_Y_COP_01_BLACK_MINI_04"); //5C34E3CE"); //1546970062"); //1546970062
            ThemVoices.Add("S_M_Y_COP_01_WHITE_FULL_01"); //6F38027D"); //1865941629"); //1865941629
            ThemVoices.Add("S_M_Y_COP_01_WHITE_FULL_02"); //360C1026"); //906760230"); //906760230
            ThemVoices.Add("S_M_Y_COP_01_WHITE_MINI_01"); //BA399207"); //3124335111"); //ThemVoices.Add("1170632185
            ThemVoices.Add("S_M_Y_COP_01_WHITE_MINI_02"); //CBEB356A"); //3421189482"); //ThemVoices.Add("873777814
            ThemVoices.Add("S_M_Y_COP_01_WHITE_MINI_03"); //DDB458FC"); //3719583996"); //ThemVoices.Add("575383300
            ThemVoices.Add("S_M_Y_COP_01_WHITE_MINI_04"); //EF5EFC51"); //4015979601"); //ThemVoices.Add("278987695
            ThemVoices.Add("S_M_Y_FIREMAN_01_LATINO_FULL_01"); //71549C50"); //1901370448"); //1901370448
            ThemVoices.Add("S_M_Y_FIREMAN_01_LATINO_FULL_02"); //7C0BB1BE"); //2081141182"); //2081141182
            ThemVoices.Add("S_M_Y_FIREMAN_01_WHITE_FULL_01"); //0094A96A"); //9742698"); //9742698
            ThemVoices.Add("S_M_Y_FIREMAN_01_WHITE_FULL_02"); //80DB29FD"); //2161846781"); //ThemVoices.Add("2133120515
            ThemVoices.Add("S_M_Y_GENERICCHEAPWORKER_01_BLACK_MINI_01"); //09FD9FD3"); //167616467"); //167616467
            ThemVoices.Add("S_M_Y_GENERICCHEAPWORKER_01_BLACK_MINI_02"); //37D07B78"); //936409976"); //936409976
            ThemVoices.Add("S_M_Y_GENERICCHEAPWORKER_01_WHITE_MINI_01"); //3869CBA7"); //946457511"); //946457511
            ThemVoices.Add("S_M_Y_GENERICMARINE_01_BLACK_MINI_01"); //17F5909B"); //401969307"); //401969307
            ThemVoices.Add("S_M_Y_GENERICMARINE_01_BLACK_MINI_02"); //0E947DD1"); //244612561"); //244612561
            ThemVoices.Add("S_M_Y_GENERICMARINE_01_WHITE_MINI_01"); //55FDC164"); //1442693476"); //1442693476
            ThemVoices.Add("S_M_Y_GENERICMARINE_01_WHITE_MINI_02"); //08BBA6E1"); //146515681"); //146515681
            ThemVoices.Add("S_M_Y_GENERICWORKER_01_BLACK_MINI_01"); //0A3A301F"); //171585567"); //171585567
            ThemVoices.Add("S_M_Y_GENERICWORKER_01_BLACK_MINI_02"); //60D0DD4B"); //1624300875"); //1624300875
            ThemVoices.Add("S_M_Y_GENERICWORKER_01_LATINO_MINI_01"); //86640419"); //2254701593"); //ThemVoices.Add("2040265703
            ThemVoices.Add("S_M_Y_GENERICWORKER_01_LATINO_MINI_02"); //F4AC60AC"); //4104937644"); //ThemVoices.Add("190029652
            ThemVoices.Add("S_M_Y_GENERICWORKER_01_WHITE_01"); //129AD4A3"); //312136867"); //312136867
            ThemVoices.Add("S_M_Y_GENERICWORKER_01_WHITE_MINI_01"); //E8727D7D"); //3899817341"); //ThemVoices.Add("395149955
            ThemVoices.Add("S_M_Y_GENERICWORKER_01_WHITE_MINI_02"); //B23310FF"); //2989691135"); //ThemVoices.Add("1305276161
            ThemVoices.Add("S_M_Y_HWAYCOP_01_BLACK_FULL_01"); //DC403AA7"); //3695196839"); //ThemVoices.Add("599770457
            ThemVoices.Add("S_M_Y_HWAYCOP_01_BLACK_FULL_02"); //11AAA57B"); //296396155"); //296396155
            ThemVoices.Add("S_M_Y_HWAYCOP_01_WHITE_FULL_01"); //F332D786"); //4080195462"); //ThemVoices.Add("214771834
            ThemVoices.Add("S_M_Y_HWAYCOP_01_WHITE_FULL_02"); //0384F82A"); //59045930"); //59045930
            ThemVoices.Add("S_M_Y_MCOP_01_WHITE_MINI_01"); //7A44FB56"); //2051341142"); //2051341142
            ThemVoices.Add("S_M_Y_MCOP_01_WHITE_MINI_02"); //670ED4EA"); //1729025258"); //1729025258
            ThemVoices.Add("S_M_Y_MCOP_01_WHITE_MINI_03"); //54D0306D"); //1422930029"); //1422930029
            ThemVoices.Add("S_M_Y_MCOP_01_WHITE_MINI_04"); //B361ED8F"); //3009539471"); //ThemVoices.Add("1285427825
            ThemVoices.Add("S_M_Y_MCOP_01_WHITE_MINI_05"); //0F8FA5E9"); //261072361"); //261072361
            ThemVoices.Add("S_M_Y_MCOP_01_WHITE_MINI_06"); //FFE50694"); //4293199508"); //ThemVoices.Add("1767788
            ThemVoices.Add("S_M_Y_RANGER_01_LATINO_FULL_01"); //94EBCA6B"); //2498480747"); //ThemVoices.Add("1796486549
            ThemVoices.Add("S_M_Y_RANGER_01_WHITE_FULL_01"); //9723C55B"); //2535703899"); //ThemVoices.Add("1759263397
            ThemVoices.Add("S_M_Y_SHERIFF_01_WHITE_FULL_01"); //A1C8B88A"); //2714286218"); //ThemVoices.Add("1580681078
            ThemVoices.Add("S_M_Y_SHERIFF_01_WHITE_FULL_02"); //939F1C37"); //2476678199"); //ThemVoices.Add("1818289097
            ThemVoices.Add("S_M_Y_SHOP_MASK_WHITE_MINI_01"); //03AAB8B0"); //61520048"); //61520048
            ThemVoices.Add("S_M_Y_SWAT_01_WHITE_FULL_01"); //BA960340"); //3130393408"); //ThemVoices.Add("1164573888
            ThemVoices.Add("S_M_Y_SWAT_01_WHITE_FULL_02"); //E55E58D0"); //3848165584"); //ThemVoices.Add("446801712
            ThemVoices.Add("S_M_Y_SWAT_01_WHITE_FULL_03"); //F324745C"); //4079252572"); //ThemVoices.Add("215714724
            ThemVoices.Add("S_M_Y_SWAT_01_WHITE_FULL_04"); //0236127F"); //37098111"); //37098111
            ThemVoices.Add("TALINA"); //ED031790"); //3976402832"); //ThemVoices.Add("318564464
            ThemVoices.Add("TAXIALONZO"); //A0B07846"); //2695919686"); //ThemVoices.Add("1599047610
            ThemVoices.Add("TAXIBRUCE"); //1E0A9C18"); //504011800"); //504011800
            ThemVoices.Add("TAXICLYDE"); //90992C60"); //2425957472"); //ThemVoices.Add("1869009824
            ThemVoices.Add("TAXIDARREN"); //2C1A5202"); //739922434"); //739922434
            ThemVoices.Add("TAXIDERRICK"); //2D71435C"); //762397532"); //762397532
            ThemVoices.Add("TAXIDOM"); //9DA9FDB5"); //2645163445"); //ThemVoices.Add("1649803851
            ThemVoices.Add("TAXIFELIPE"); //E66D1B66"); //3865910118"); //ThemVoices.Add("429057178
            ThemVoices.Add("TAXIGANGGIRL1"); //E2228087"); //3793911943"); //ThemVoices.Add("501055353
            ThemVoices.Add("TAXIGANGGIRL2"); //F7E3AC09"); //4158893065"); //ThemVoices.Add("136074231
            ThemVoices.Add("TAXIGANGM"); //08AC318A"); //145502602"); //145502602
            ThemVoices.Add("TAXIJAMES"); //A8A8F64E"); //2829645390"); //ThemVoices.Add("1465321906
            ThemVoices.Add("TAXIKEYLA"); //23ACB127"); //598520103"); //598520103
            ThemVoices.Add("TAXIKWAK"); //58B68A9D"); //1488358045"); //1488358045
            ThemVoices.Add("TAXILIZ"); //C8B6AC99"); //3367414937"); //ThemVoices.Add("927552359
            ThemVoices.Add("TAXIMIRANDA"); //97A199A8"); //2543950248"); //ThemVoices.Add("1751017048
            ThemVoices.Add("TAXIOJCOP1"); //5883C603"); //1485030915"); //1485030915
            ThemVoices.Add("TAXIOTIS"); //A0B868F9"); //2696440057"); //ThemVoices.Add("1598527239
            ThemVoices.Add("TAXIPAULIE"); //05437D58"); //88309080"); //88309080
            ThemVoices.Add("TAXIWALTER"); //1A43E0E1"); //440656097"); //440656097
            ThemVoices.Add("TEST_VOICE"); //62883B8C"); //1653095308"); //1653095308
            ThemVoices.Add("TOM"); //97CBE769"); //2546722665"); //ThemVoices.Add("1748244631
            ThemVoices.Add("TONYA"); //FCB43161"); //4239667553"); //ThemVoices.Add("55299743
            ThemVoices.Add("TRACEY"); //5A7D2459"); //1518150745"); //1518150745
            ThemVoices.Add("TRANSLATOR"); //EAC3FECB"); //3938713291"); //ThemVoices.Add("356254005
            ThemVoices.Add("TREVOR_1_NORMAL"); //3AD6D338"); //987157304"); //987157304
            ThemVoices.Add("TREVOR_2_NORMAL"); //CB2DDB29"); //3408780073"); //ThemVoices.Add("886187223
            ThemVoices.Add("TREVOR_3_NORMAL"); //4697A021"); //1184342049"); //1184342049
            ThemVoices.Add("TREVOR_ANGRY"); //0953FCF8"); //156499192"); //156499192
            ThemVoices.Add("TREVOR_DRUNK"); //EA0CA87A"); //3926698106"); //ThemVoices.Add("368269190
            ThemVoices.Add("TREVOR_NORMAL"); //4072CC77"); //1081265271"); //1081265271
            ThemVoices.Add("U_M_Y_TATTOO_01_WHITE_MINI_01"); //956C178D"); //2506889101"); //ThemVoices.Add("1788078195
            ThemVoices.Add("VB_FEMALE_01"); //CB2136C8"); //3407951560"); //ThemVoices.Add("887015736
            ThemVoices.Add("VB_FEMALE_02"); //E4EA6A5A"); //3840567898"); //ThemVoices.Add("454399398
            ThemVoices.Add("VB_FEMALE_03"); //B1510330"); //2974876464"); //ThemVoices.Add("1320090832
            ThemVoices.Add("VB_FEMALE_04"); //C397A7BD"); //3281495997"); //ThemVoices.Add("1013471299
            ThemVoices.Add("VB_LIFEGUARD_01"); //6B6161EE"); //1801544174"); //1801544174
            ThemVoices.Add("VB_MALE_01"); //AC519660"); //2891028064"); //ThemVoices.Add("1403939232
            ThemVoices.Add("VB_MALE_02"); //B5E5A988"); //3051727240"); //ThemVoices.Add("1243240056
            ThemVoices.Add("VB_MALE_03"); //3A03B192"); //973320594"); //973320594
            ThemVoices.Add("VULTURES"); //18219991"); //404855185"); //404855185
            ThemVoices.Add("WADE"); //7DD049A4"); //2110802340"); //2110802340
            ThemVoices.Add("WAVELOAD_PAIN_FEMALE"); //332128AB"); //857811115"); //857811115
            ThemVoices.Add("WAVELOAD_PAIN_FRANKLIN"); //33F65FC3"); //871784387"); //871784387
            ThemVoices.Add("WAVELOAD_PAIN_MALE"); //804C18BB"); //2152470715"); //ThemVoices.Add("2142496581
            ThemVoices.Add("WAVELOAD_PAIN_MICHAEL"); //6531A692"); //1697752722"); //1697752722
            ThemVoices.Add("WAVELOAD_PAIN_TREVOR"); //0CF83E9F"); //217595551"); //217595551
            ThemVoices.Add("WFSTEWARDESS"); //84EDE1BF"); //2230182335"); //ThemVoices.Add("2064784961
            ThemVoices.Add("WHISTLINGJANITOR"); //168D3E8E"); //378355342"); //378355342
            ThemVoices.Add("YACHTCAPTAIN"); //71C9A806"); //1909041158"); //1909041158
            ThemVoices.Add("ZOMBIE"); //22666A99"); //577137305"); //577137305
        }
        private void SeatList()
        {
            Vseats.Clear();
            Vseats.Add(VehicleSeat.LeftFront);
            Vseats.Add(VehicleSeat.RightFront);
            Vseats.Add(VehicleSeat.LeftRear);
            Vseats.Add(VehicleSeat.RightRear);
            Vseats.Add(VehicleSeat.ExtraSeat1);
            Vseats.Add(VehicleSeat.ExtraSeat2);
            Vseats.Add(VehicleSeat.ExtraSeat3);
            Vseats.Add(VehicleSeat.ExtraSeat4);
            Vseats.Add(VehicleSeat.ExtraSeat5);
            Vseats.Add(VehicleSeat.ExtraSeat6);
            Vseats.Add(VehicleSeat.ExtraSeat7);
            Vseats.Add(VehicleSeat.ExtraSeat8);
            Vseats.Add(VehicleSeat.ExtraSeat9);
            Vseats.Add(VehicleSeat.ExtraSeat10);
            Vseats.Add(VehicleSeat.ExtraSeat11);
            Vseats.Add(VehicleSeat.ExtraSeat12);
        }
        private void WeapsList()
        {
            sWeapList.Clear();
            sAddsList.Clear();

            sWeapList.Add("WEAPON_dagger");  //0x92A27487",
            sWeapList.Add("WEAPON_bat");  //0x958A4A8F",
            sWeapList.Add("WEAPON_bottle");  //0xF9E6AA4B",
            sWeapList.Add("WEAPON_crowbar");  //0x84BD7BFD",
            sWeapList.Add("WEAPON_unarmed");  //0xA2719263",
            sWeapList.Add("WEAPON_flashlight");  //0x8BB05FD7",
            sWeapList.Add("WEAPON_golfclub");  //0x440E4788",
            sWeapList.Add("WEAPON_hammer");  //0x4E875F73",
            sWeapList.Add("WEAPON_hatchet");  //0xF9DCBF2D",
            sWeapList.Add("WEAPON_knuckle");  //0xD8DF3C3C",
            sWeapList.Add("WEAPON_knife");  //0x99B507EA",
            sWeapList.Add("WEAPON_machete");  //0xDD5DF8D9",
            sWeapList.Add("WEAPON_switchblade");  //0xDFE37640",
            sWeapList.Add("WEAPON_nightstick");  //0x678B81B1",
            sWeapList.Add("WEAPON_wrench");  //0x19044EE0",
            sWeapList.Add("WEAPON_battleaxe");  //0xCD274149",
            sWeapList.Add("WEAPON_poolcue");  //0x94117305",
            sWeapList.Add("WEAPON_stone_hatchet");  //0x3813FC08"--17

            sWeapList.Add("WEAPON_pistol");  //0x1B06D571",
            sWeapList.Add("WEAPON_pistol_mk2");  //0xBFE256D4",---------19
            sWeapList.Add("WEAPON_combatpistol");  //0x5EF9FEC4",
            sWeapList.Add("WEAPON_appistol");  //0x22D8FE39",
            sWeapList.Add("WEAPON_pistol50");  //0x99AEEB3B",
            sWeapList.Add("WEAPON_snspistol");  //0xBFD21232",
            sWeapList.Add("WEAPON_snspistol_mk2");  //0x88374054",---24
            sWeapList.Add("WEAPON_heavypistol");  //0xD205520E",
            sWeapList.Add("WEAPON_vintagepistol");  //0x83839C4",
            sWeapList.Add("WEAPON_marksmanpistol");  //0xDC4DB296",
            sWeapList.Add("WEAPON_revolver");  //0xC1B3C3D1",
            sWeapList.Add("WEAPON_revolver_mk2");  //0xCB96392F",----29
            sWeapList.Add("WEAPON_doubleaction");  //0x97EA20B8",
            sWeapList.Add("WEAPON_ceramicpistol");  //0x2B5EF5EC",
            sWeapList.Add("WEAPON_navyrevolver");  //0x917F6C8C"
            sWeapList.Add("WEAPON_GADGETPISTOL");  //0xAF3696A1",
            sWeapList.Add("WEAPON_stungun");  //0x3656C8C1",
            sWeapList.Add("WEAPON_flaregun");  //0x47757124",
            sWeapList.Add("WEAPON_raypistol");  //0xAF3696A1",--36

            sWeapList.Add("WEAPON_microsmg");  //0x13532244",
            sWeapList.Add("WEAPON_smg");  //0x2BE6766B",
            sWeapList.Add("WEAPON_smg_mk2");  //0x78A97CD0",-----39
            sWeapList.Add("WEAPON_assaultsmg");  //0xEFE7E2DF",
            sWeapList.Add("WEAPON_combatpdw");  //0xA3D4D34",
            sWeapList.Add("WEAPON_machinepistol");  //0xDB1AA450",
            sWeapList.Add("WEAPON_minismg");  //0xBD248B55",
            sWeapList.Add("WEAPON_raycarbine");  //0x476BF155"--44

            sWeapList.Add("WEAPON_pumpshotgun");  //0x1D073A89",
            sWeapList.Add("WEAPON_pumpshotgun_mk2");  //0x555AF99A",-----------46
            sWeapList.Add("WEAPON_sawnoffshotgun");  //0x7846A318",
            sWeapList.Add("WEAPON_assaultshotgun");  //0xE284C527",
            sWeapList.Add("WEAPON_bullpupshotgun");  //0x9D61E50F",
            sWeapList.Add("WEAPON_musket");  //0xA89CB99E",
            sWeapList.Add("WEAPON_heavyshotgun");  //0x3AABBBAA",
            sWeapList.Add("WEAPON_dbshotgun");  //0xEF951FBB",
            sWeapList.Add("WEAPON_autoshotgun");  //0x12E82D3D"--53
            sWeapList.Add("WEAPON_COMBATSHOTGUN");  //0x5A96BA4--54

            sWeapList.Add("WEAPON_assaultrifle");  //0xBFEFFF6D",
            sWeapList.Add("WEAPON_assaultrifle_mk2");  //0x394F415C",-------56
            sWeapList.Add("WEAPON_carbinerifle");  //0x83BF0278",
            sWeapList.Add("WEAPON_carbinerifle_mk2");  //0xFAD1F1C9",------58
            sWeapList.Add("WEAPON_advancedrifle");  //0xAF113F99",
            sWeapList.Add("WEAPON_specialcarbine");  //0xC0A3098D",
            sWeapList.Add("WEAPON_specialcarbine_mk2");  //0x969C3D67",------61
            sWeapList.Add("WEAPON_bullpuprifle");  //0x7F229F94",
            sWeapList.Add("WEAPON_bullpuprifle_mk2");  //0x84D6FAFD",----63
            sWeapList.Add("WEAPON_compactrifle");  //0x624FE830"--64
            sWeapList.Add("WEAPON_MILITARYRIFLE");  //0x624FE830"--65

            sWeapList.Add("WEAPON_mg");  //0x9D07F764",
            sWeapList.Add("WEAPON_combatmg");  //0x7FD62962",
            sWeapList.Add("WEAPON_combatmg_mk2");  //0xDBBD7280",------68
            sWeapList.Add("WEAPON_gusenberg");  //0x61012683"--69

            sWeapList.Add("WEAPON_sniperrifle");  //0x5FC3C11",
            sWeapList.Add("WEAPON_heavysniper");  //0xC472FE2",
            sWeapList.Add("WEAPON_heavysniper_mk2");  //0xA914799",---72
            sWeapList.Add("WEAPON_marksmanrifle");  //0xC734385A",
            sWeapList.Add("WEAPON_marksmanrifle_mk2");  //0x6A6C02E0"--74

            sWeapList.Add("WEAPON_rpg");  //0xB1CA77B1",
            sWeapList.Add("WEAPON_grenadelauncher");  //0xA284510B",
            sWeapList.Add("WEAPON_grenadelauncher_smoke");  //0x4DD2DC56",
            sWeapList.Add("WEAPON_minigun");  //0x42BF8A85",
            sWeapList.Add("WEAPON_firework");  //0x7F7497E5",
            sWeapList.Add("WEAPON_railgun");  //0x6D544C99",
            sWeapList.Add("WEAPON_hominglauncher");  //0x63AB0442",
            sWeapList.Add("WEAPON_compactlauncher");  //0x781FE4A",
            sWeapList.Add("WEAPON_rayminigun");  //0xB62D1F67"--83

            sWeapList.Add("WEAPON_grenade");  //0x93E220BD",
            sWeapList.Add("WEAPON_bzgas");  //0xA0973D5E",
            sWeapList.Add("WEAPON_smokegrenade");  //0xFDBC8A50",
            sWeapList.Add("WEAPON_flare");  //0x497FACC3",
            sWeapList.Add("WEAPON_molotov");  //0x24B17070",
            sWeapList.Add("WEAPON_stickybomb");  //0x2C3731D9",
            sWeapList.Add("WEAPON_proxmine");  //0xAB564B93",
            sWeapList.Add("WEAPON_snowball");  //0x787F0BB",
            sWeapList.Add("WEAPON_pipebomb");  //0xBA45E8B8",
            sWeapList.Add("WEAPON_ball");  //0x23C9F95C"--93

            sWeapList.Add("WEAPON_petrolcan");  //0x34A67B97",
            sWeapList.Add("WEAPON_fireextinguisher");  //0x60EC506",
            sWeapList.Add("WEAPON_parachute");  //0xFBAB5776",
            sWeapList.Add("WEAPON_hazardcan");  //0xBA536372"--97

            sWeapList.Add("WEAPON_EMPLAUNCHER");  // 0xDB26713A--98

            sWeapList.Add("WEAPON_HEAVYRIFLE");  //0xC78D71B4 --99

            sWeapList.Add("WEAPON_FERTILIZERCAN");//100

            sWeapList.Add("WEAPON_STUNGUN_MP");//101

            sAddsList.Add("COMPONENT_ADVANCEDRIFLE_CLIP_01");//0xFA8FA10F,
            sAddsList.Add("COMPONENT_ADVANCEDRIFLE_CLIP_02");//0x8EC1C979,
            sAddsList.Add("COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE");//0x377CD377,
            sAddsList.Add("COMPONENT_APPISTOL_CLIP_01");//0x31C4B22A,
            sAddsList.Add("COMPONENT_APPISTOL_CLIP_02");//0x249A17D5,
            sAddsList.Add("COMPONENT_APPISTOL_VARMOD_LUXE");//0x9B76C72C,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_CLIP_01");//0xBE5EEA16,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_CLIP_02");//0xB1214F9B,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_CLIP_03");//0xDBF0A53D,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO");//0x911B24AF,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_02");//0x37E5444B,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_03");//0x538B7B97,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_04");//0x25789F72,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_05");//0xC5495F2D,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_06");//0xCF8B73B1,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_07");//0xA9BB2811,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_08");//0xFC674D54,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_09");//0x7C7FCD9B,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_10");//0xA5C38392,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_IND_01");//0xB9B15DB0,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_01");//0x8610343F,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_02");//0xD12ACA6F,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING");//0xA7DD1E58,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ");//0x63E0A098,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY");//0xFB70D853,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER");//0xEF2C78C1,
            sAddsList.Add("COMPONENT_ASSAULTRIFLE_VARMOD_LUXE");//0x4EAD7533,
            sAddsList.Add("COMPONENT_ASSAULTSHOTGUN_CLIP_01");//0x94E81BC7,
            sAddsList.Add("COMPONENT_ASSAULTSHOTGUN_CLIP_02");//0x86BD7F72,
            sAddsList.Add("COMPONENT_ASSAULTSMG_CLIP_01");//0x8D1307B0,
            sAddsList.Add("COMPONENT_ASSAULTSMG_CLIP_02");//0xBB46E417,
            sAddsList.Add("COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER");//0x278C78AF,
            sAddsList.Add("COMPONENT_AT_AR_AFGRIP");//0xC164F53,
            sAddsList.Add("COMPONENT_AT_AR_AFGRIP_02");//0x9D65907A,
            sAddsList.Add("COMPONENT_AT_AR_BARREL_01");//0x43A49D26,
            sAddsList.Add("COMPONENT_AT_AR_BARREL_02");//0x5646C26A,
            sAddsList.Add("COMPONENT_AT_AR_FLSH");//0x7BC4CDDC,
            sAddsList.Add("COMPONENT_AT_AR_SUPP");//0x837445AA,
            sAddsList.Add("COMPONENT_AT_AR_SUPP_02");//0xA73D4664,
            sAddsList.Add("COMPONENT_AT_BP_BARREL_01");//0x659AC11B,
            sAddsList.Add("COMPONENT_AT_BP_BARREL_02");//0x3BF26DC7,
            sAddsList.Add("COMPONENT_AT_CR_BARREL_01");//0x833637FF,
            sAddsList.Add("COMPONENT_AT_CR_BARREL_02");//0x8B3C480B,
            sAddsList.Add("COMPONENT_AT_MG_BARREL_01");//0xC34EF234,
            sAddsList.Add("COMPONENT_AT_MG_BARREL_02");//0xB5E2575B,
            sAddsList.Add("COMPONENT_AT_MRFL_BARREL_01");//0x381B5D89,
            sAddsList.Add("COMPONENT_AT_MRFL_BARREL_02");//0x68373DDC,
            sAddsList.Add("COMPONENT_AT_MUZZLE_01");//0xB99402D4,
            sAddsList.Add("COMPONENT_AT_MUZZLE_02");//0xC867A07B,
            sAddsList.Add("COMPONENT_AT_MUZZLE_03");//0xDE11CBCF,
            sAddsList.Add("COMPONENT_AT_MUZZLE_04");//0xEC9068CC,
            sAddsList.Add("COMPONENT_AT_MUZZLE_05");//0x2E7957A,
            sAddsList.Add("COMPONENT_AT_MUZZLE_06");//0x347EF8AC,
            sAddsList.Add("COMPONENT_AT_MUZZLE_07");//0x4DB62ABE,
            sAddsList.Add("COMPONENT_AT_MUZZLE_08");//0x5F7DCE4D,
            sAddsList.Add("COMPONENT_AT_MUZZLE_09");//0x6927E1A1,
            sAddsList.Add("COMPONENT_AT_PI_COMP");//0x21E34793,
            sAddsList.Add("COMPONENT_AT_PI_COMP_02");//0xAA8283BF,
            sAddsList.Add("COMPONENT_AT_PI_COMP_03");//0x27077CCB,
            sAddsList.Add("COMPONENT_AT_PI_FLSH");//0x359B7AAE,
            sAddsList.Add("COMPONENT_AT_PI_FLSH_02");//0x43FD595B,
            sAddsList.Add("COMPONENT_AT_PI_FLSH_03");//0x4A4965F3,
            sAddsList.Add("COMPONENT_AT_PI_RAIL");//0x8ED4BB70,
            sAddsList.Add("COMPONENT_AT_PI_RAIL_02");//0x47DE9258,
            sAddsList.Add("COMPONENT_AT_PI_SUPP");//0xC304849A,
            sAddsList.Add("COMPONENT_AT_PI_SUPP_02");//0x65EA7EBB,
            sAddsList.Add("COMPONENT_AT_SB_BARREL_01");//0xD9103EE1,
            sAddsList.Add("COMPONENT_AT_SB_BARREL_02");//0xA564D78B,
            sAddsList.Add("COMPONENT_AT_SCOPE_LARGE");//0xD2443DDC,
            sAddsList.Add("COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM");//0x1C221B1A,
            sAddsList.Add("COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM_MK2");//0x5B1C713C,
            sAddsList.Add("COMPONENT_AT_SCOPE_LARGE_MK2");//0x82C10383,
            sAddsList.Add("COMPONENT_AT_SCOPE_MACRO");//0x9D2FBF29,
            sAddsList.Add("COMPONENT_AT_SCOPE_MACRO_02");//0x3CC6BA57,
            sAddsList.Add("COMPONENT_AT_SCOPE_MACRO_02_MK2");//0xC7ADD105,
            sAddsList.Add("COMPONENT_AT_SCOPE_MACRO_02_SMG_MK2");//0xE502AB6B,
            sAddsList.Add("COMPONENT_AT_SCOPE_MACRO_MK2");//0x49B2945,
            sAddsList.Add("COMPONENT_AT_SCOPE_MAX");//0xBC54DA77,
            sAddsList.Add("COMPONENT_AT_SCOPE_MEDIUM");//0xA0D89C42,
            sAddsList.Add("COMPONENT_AT_SCOPE_MEDIUM_MK2");//0xC66B6542,
            sAddsList.Add("COMPONENT_AT_SCOPE_NV");//0xB68010B0,
            sAddsList.Add("COMPONENT_AT_SCOPE_SMALL");//0xAA2C45B4,
            sAddsList.Add("COMPONENT_AT_SCOPE_SMALL_02");//0x3C00AFED,
            sAddsList.Add("COMPONENT_AT_SCOPE_SMALL_MK2");//0x3F3C8181,
            sAddsList.Add("COMPONENT_AT_SCOPE_SMALL_SMG_MK2");//0x3DECC7DA,
            sAddsList.Add("COMPONENT_AT_SCOPE_THERMAL");//0x2E43DA41,
            sAddsList.Add("COMPONENT_AT_SC_BARREL_01");//0xE73653A9,
            sAddsList.Add("COMPONENT_AT_SC_BARREL_02");//0xF97F783B,
            sAddsList.Add("COMPONENT_AT_SIGHTS");//0x420FD713,
            sAddsList.Add("COMPONENT_AT_SIGHTS_SMG");//0x9FDB5652,
            sAddsList.Add("COMPONENT_AT_SR_BARREL_01");//0x909630B7,
            sAddsList.Add("COMPONENT_AT_SR_BARREL_02");//0x108AB09E,
            sAddsList.Add("COMPONENT_AT_SR_SUPP");//0xE608B35E,
            sAddsList.Add("COMPONENT_AT_SR_SUPP_03");//0xAC42DF71,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_CLIP_01");//0xC5A12F80,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_CLIP_02");//0xB3688B0F,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO");//0xAE4055B7,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_02");//0xB905ED6B,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_03");//0xA6C448E8,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_04");//0x9486246C,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_05");//0x8A390FD2,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_06");//0x2337FC5,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_07");//0xEFFFDB5E,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_08");//0xDDBDB6DA,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_09");//0xCB631225,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_10");//0xA87D541E,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_IND_01");//0xC5E9AE52,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_01");//0x18929DA,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_02");//0xEFB00628,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_ARMORPIERCING");//0xFAA7F5ED,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_FMJ");//0x43621710,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_INCENDIARY");//0xA99CF95A,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_TRACER");//0x822060A9,
            sAddsList.Add("COMPONENT_BULLPUPRIFLE_VARMOD_LOW");//0xA857BC78,
            sAddsList.Add("COMPONENT_CARBINERIFLE_CLIP_01");//0x9FBE33EC,
            sAddsList.Add("COMPONENT_CARBINERIFLE_CLIP_02");//0x91109691,
            sAddsList.Add("COMPONENT_CARBINERIFLE_CLIP_03");//0xBA62E935,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO");//0x4BDD6F16,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_02");//0x406A7908,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_03");//0x2F3856A4,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_04");//0xE50C424D,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_05");//0xD37D1F2F,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_06");//0x86268483,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_07");//0xF420E076,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_08");//0xAAE14DF8,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_09");//0x9893A95D,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_10");//0x6B13CD3E,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_IND_01");//0xDA55CD3F,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_01");//0x4C7A391E,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_02");//0x5DD5DBD5,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING");//0x255D5D57,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ");//0x44032F11,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY");//0x3D25C2A7,
            sAddsList.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER");//0x1757F566,
            sAddsList.Add("COMPONENT_CARBINERIFLE_VARMOD_LUXE");//0xD89B9658,
            sAddsList.Add("COMPONENT_COMBATMG_CLIP_01");//0xE1FFB34A,
            sAddsList.Add("COMPONENT_COMBATMG_CLIP_02");//0xD6C59CD6,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO");//0x4A768CB5,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO_02");//0xCCE06BBD,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO_03");//0xBE94CF26,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO_04");//0x7609BE11,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO_05");//0x48AF6351,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO_06");//0x9186750A,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO_07");//0x84555AA8,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO_08");//0x1B4C088B,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO_09");//0xE046DFC,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO_10");//0x28B536E,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CAMO_IND_01");//0xD703C94D,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CLIP_01");//0x492B257C,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CLIP_02");//0x17DF42E9,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CLIP_ARMORPIERCING");//0x29882423,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CLIP_FMJ");//0x57EF1CC8,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CLIP_INCENDIARY");//0xC326BDBA,
            sAddsList.Add("COMPONENT_COMBATMG_MK2_CLIP_TRACER");//0xF6649745,
            sAddsList.Add("COMPONENT_COMBATMG_VARMOD_LOWRIDER");//0x92FECCDD,
            sAddsList.Add("COMPONENT_COMBATPDW_CLIP_01");//0x4317F19E,
            sAddsList.Add("COMPONENT_COMBATPDW_CLIP_02");//0x334A5203,
            sAddsList.Add("COMPONENT_COMBATPDW_CLIP_03");//0x6EB8C8DB,
            sAddsList.Add("COMPONENT_COMBATPISTOL_CLIP_01");//0x721B079,
            sAddsList.Add("COMPONENT_COMBATPISTOL_CLIP_02");//0xD67B4F2D,
            sAddsList.Add("COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER");//0xC6654D72,
            sAddsList.Add("COMPONENT_COMPACTRIFLE_CLIP_01");//0x513F0A63,
            sAddsList.Add("COMPONENT_COMPACTRIFLE_CLIP_02");//0x59FF9BF8,
            sAddsList.Add("COMPONENT_COMPACTRIFLE_CLIP_03");//0xC607740E,
            sAddsList.Add("COMPONENT_GRENADELAUNCHER_CLIP_01");//0x11AE5C97,
            sAddsList.Add("COMPONENT_GUSENBERG_CLIP_01");//0x1CE5A6A5,
            sAddsList.Add("COMPONENT_GUSENBERG_CLIP_02");//0xEAC8C270,
            sAddsList.Add("COMPONENT_HEAVYPISTOL_CLIP_01");//0xD4A969A,
            sAddsList.Add("COMPONENT_HEAVYPISTOL_CLIP_02");//0x64F9C62B,
            sAddsList.Add("COMPONENT_HEAVYPISTOL_VARMOD_LUXE");//0x7A6A7B7B,
            sAddsList.Add("COMPONENT_HEAVYSHOTGUN_CLIP_01");//0x324F2D5F,
            sAddsList.Add("COMPONENT_HEAVYSHOTGUN_CLIP_02");//0x971CF6FD,
            sAddsList.Add("COMPONENT_HEAVYSHOTGUN_CLIP_03");//0x88C7DA53,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_CLIP_01");//0x476F52F4,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO");//0xF8337D02,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_02");//0xC5BEDD65,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_03");//0xE9712475,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_04");//0x13AA78E7,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_05");//0x26591E50,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_06");//0x302731EC,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_07");//0xAC722A78,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_08");//0xBEA4CEDD,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_09");//0xCD776C82,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_10");//0xABC5ACC7,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_IND_01");//0x6C32D2EB,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_01");//0xFA1E1A28,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_02");//0x2CD8FF9D,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_ARMORPIERCING");//0xF835D6D4,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_EXPLOSIVE");//0x89EBDAA7,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_FMJ");//0x3BE948F6,
            sAddsList.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_INCENDIARY");//0xEC0F617,
            sAddsList.Add("COMPONENT_KNUCKLE_VARMOD_BALLAS");//0xEED9FD63,
            sAddsList.Add("COMPONENT_KNUCKLE_VARMOD_BASE");//0xF3462F33,
            sAddsList.Add("COMPONENT_KNUCKLE_VARMOD_DIAMOND");//0x9761D9DC,
            sAddsList.Add("COMPONENT_KNUCKLE_VARMOD_DOLLAR");//0x50910C31,
            sAddsList.Add("COMPONENT_KNUCKLE_VARMOD_HATE");//0x7DECFE30,
            sAddsList.Add("COMPONENT_KNUCKLE_VARMOD_KING");//0xE28BABEF,
            sAddsList.Add("COMPONENT_KNUCKLE_VARMOD_LOVE");//0x3F4E8AA6,
            sAddsList.Add("COMPONENT_KNUCKLE_VARMOD_PIMP");//0xC613F685,
            sAddsList.Add("COMPONENT_KNUCKLE_VARMOD_PLAYER");//0x8B808BB,
            sAddsList.Add("COMPONENT_KNUCKLE_VARMOD_VAGOS");//0x7AF3F785,
            sAddsList.Add("COMPONENT_MACHINEPISTOL_CLIP_01");//0x476E85FF,
            sAddsList.Add("COMPONENT_MACHINEPISTOL_CLIP_02");//0xB92C6979,
            sAddsList.Add("COMPONENT_MACHINEPISTOL_CLIP_03");//0xA9E9CAF4,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_CLIP_01");//0xD83B4141,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_CLIP_02");//0xCCFD2AC5,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO");//0x9094FBA0,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_02");//0x7320F4B2,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_03");//0x60CF500F,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_04");//0xFE668B3F,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_05");//0xF3757559,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_06");//0x193B40E8,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_07");//0x107D2F6C,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_08");//0xC4E91841,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_09");//0x9BB1C5D3,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_10");//0x3B61040B,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_IND_01");//0xB7A316DA,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_01");//0x94E12DCE,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_02");//0xE6CFD1AA,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_ARMORPIERCING");//0xF46FD079,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_FMJ");//0xE14A9ED3,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_INCENDIARY");//0x6DD7A86E,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_TRACER");//0xD77A22D2,
            sAddsList.Add("COMPONENT_MARKSMANRIFLE_VARMOD_LUXE");//0x161E9241,
            sAddsList.Add("COMPONENT_MG_CLIP_01");//0xF434EF84,
            sAddsList.Add("COMPONENT_MG_CLIP_02");//0x82158B47,
            sAddsList.Add("COMPONENT_MG_VARMOD_LOWRIDER");//0xD6DABABE,
            sAddsList.Add("COMPONENT_MICROSMG_CLIP_01");//0xCB48AEF0,
            sAddsList.Add("COMPONENT_MICROSMG_CLIP_02");//0x10E6BA2B,
            sAddsList.Add("COMPONENT_MICROSMG_VARMOD_LUXE");//0x487AAE09,
            sAddsList.Add("COMPONENT_MINISMG_CLIP_01");//0x84C8B2D3,
            sAddsList.Add("COMPONENT_MINISMG_CLIP_02");//0x937ED0B7,
            sAddsList.Add("COMPONENT_PISTOL50_CLIP_01");//0x2297BE19,
            sAddsList.Add("COMPONENT_PISTOL50_CLIP_02");//0xD9D3AC92,
            sAddsList.Add("COMPONENT_PISTOL50_VARMOD_LUXE");//0x77B8AB2F,
            sAddsList.Add("COMPONENT_PISTOL_CLIP_01");//0xFED0FD71,
            sAddsList.Add("COMPONENT_PISTOL_CLIP_02");//0xED265A1C,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO");//0x5C6C749C,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_02");//0x15F7A390,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_02_SLIDE");//0x1A1F1260,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_03");//0x968E24DB,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_03_SLIDE");//0xE4E00B70,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_04");//0x17BFA99,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_04_SLIDE");//0x2C298B2B,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_05");//0xF2685C72,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_05_SLIDE");//0xDFB79725,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_06");//0xDD2231E6,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_06_SLIDE");//0x6BD7228C,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_07");//0xBB43EE76,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_07_SLIDE");//0x9DDBCF8C,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_08");//0x4D901310,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_08_SLIDE");//0xB319A52C,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_09");//0x5F31B653,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_09_SLIDE");//0xC6836E12,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_10");//0x697E19A0,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_10_SLIDE");//0x43B1B173,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_IND_01");//0x930CB951,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_IND_01_SLIDE");//0x4ABDA3FA,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CAMO_SLIDE");//0xB4FC92B0,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CLIP_01");//0x94F42D62,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CLIP_02");//0x5ED6C128,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CLIP_FMJ");//0x4F37DF2A,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CLIP_HOLLOWPOINT");//0x85FEA109,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CLIP_INCENDIARY");//0x2BBD7A3A,
            sAddsList.Add("COMPONENT_PISTOL_MK2_CLIP_TRACER");//0x25CAAEAF,
            sAddsList.Add("COMPONENT_PISTOL_VARMOD_LUXE");//0xD7391086,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO");//0xE3BD9E44,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_02");//0x17148F9B,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_03");//0x24D22B16,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_04");//0xF2BEC6F0,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_05");//0x85627D,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_06");//0xDC2919C5,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_07");//0xE184247B,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_08");//0xD8EF9356,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_09");//0xEF29BFCA,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_10");//0x67AEB165,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_IND_01");//0x46411A1D,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_01");//0xCD940141,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_ARMORPIERCING");//0x4E65B425,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_EXPLOSIVE");//0x3BE4465D,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_HOLLOWPOINT");//0xE9582927,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_INCENDIARY");//0x9F8A1BF5,
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER");//0xA2D79DDB,
            sAddsList.Add("COMPONENT_REVOLVER_CLIP_01");//0xE9867CE3,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO");//0xC03FED9F,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO_02");//0xB5DE24,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO_03");//0xA7FF1B8,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO_04");//0xF2E24289,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO_05");//0x11317F27,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO_06");//0x17C30C42,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO_07");//0x257927AE,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO_08");//0x37304B1C,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO_09");//0x48DAEE71,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO_10");//0x20ED9B5B,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CAMO_IND_01");//0xD951E867,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CLIP_01");//0xBA23D8BE,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CLIP_FMJ");//0xDC8BA3F,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CLIP_HOLLOWPOINT");//0x10F42E8F,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CLIP_INCENDIARY");//0xEFBF25,
            sAddsList.Add("COMPONENT_REVOLVER_MK2_CLIP_TRACER");//0xC6D8E476,
            sAddsList.Add("COMPONENT_REVOLVER_VARMOD_BOSS");//0x16EE3040,
            sAddsList.Add("COMPONENT_REVOLVER_VARMOD_GOON");//0x9493B80D,
            sAddsList.Add("COMPONENT_SAWNOFFSHOTGUN_VARMOD_LUXE");//0x85A64DF9,
            sAddsList.Add("COMPONENT_SMG_CLIP_01");//0x26574997,
            sAddsList.Add("COMPONENT_SMG_CLIP_02");//0x350966FB,
            sAddsList.Add("COMPONENT_SMG_CLIP_03");//0x79C77076,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO");//0xC4979067,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO_02");//0x3815A945,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO_03");//0x4B4B4FB0,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO_04");//0xEC729200,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO_05");//0x48F64B22,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO_06");//0x35992468,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO_07");//0x24B782A5,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO_08");//0xA2E67F01,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO_09");//0x2218FD68,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO_10");//0x45C5C3C5,
            sAddsList.Add("COMPONENT_SMG_MK2_CAMO_IND_01");//0x399D558F,
            sAddsList.Add("COMPONENT_SMG_MK2_CLIP_01");//0x4C24806E,
            sAddsList.Add("COMPONENT_SMG_MK2_CLIP_02");//0xB9835B2E,
            sAddsList.Add("COMPONENT_SMG_MK2_CLIP_FMJ");//0xB5A715F,
            sAddsList.Add("COMPONENT_SMG_MK2_CLIP_HOLLOWPOINT");//0x3A1BD6FA,
            sAddsList.Add("COMPONENT_SMG_MK2_CLIP_INCENDIARY");//0xD99222E5,
            sAddsList.Add("COMPONENT_SMG_MK2_CLIP_TRACER");//0x7FEA36EC,
            sAddsList.Add("COMPONENT_SMG_VARMOD_LUXE");//0x27872C90,
            sAddsList.Add("COMPONENT_SNIPERRIFLE_CLIP_01");//0x9BC64089,
            sAddsList.Add("COMPONENT_SNIPERRIFLE_VARMOD_LUXE");//0x4032B5E7,
            sAddsList.Add("COMPONENT_SNSPISTOL_CLIP_01");//0xF8802ED9,
            sAddsList.Add("COMPONENT_SNSPISTOL_CLIP_02");//0x7B0033B3,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO");//0xF7BEEDD,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_02");//0x8A612EF6,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_02_SLIDE");//0x29366D21,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_03");//0x76FA8829,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_03_SLIDE");//0x3ADE514B,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_04");//0xA93C6CAC,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_04_SLIDE");//0xE64513E9,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_05");//0x9C905354,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_05_SLIDE");//0xCD7AEB9A,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_06");//0x4DFA3621,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_06_SLIDE");//0xFA7B27A6,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_07");//0x42E91FFF,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_07_SLIDE");//0xE285CA9A,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_08");//0x54A8437D,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_08_SLIDE");//0x2B904B19,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_09");//0x68C2746,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_09_SLIDE");//0x22C24F9C,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_10");//0x2366E467,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_10_SLIDE");//0x8D0D5ECD,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_IND_01");//0x441882E6,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_IND_01_SLIDE");//0x1F07150A,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CAMO_SLIDE");//0xE7EE68EA,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CLIP_01");//0x1466CE6,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CLIP_02");//0xCE8C0772,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CLIP_FMJ");//0xC111EB26,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CLIP_HOLLOWPOINT");//0x8D107402,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CLIP_INCENDIARY");//0xE6AD5F79,
            sAddsList.Add("COMPONENT_SNSPISTOL_MK2_CLIP_TRACER");//0x902DA26E,
            sAddsList.Add("COMPONENT_SNSPISTOL_VARMOD_LOWRIDER");//0x8033ECAF,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_CLIP_01");//0xC6C7E581,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_CLIP_02");//0x7C8BD10E,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_CLIP_03");//0x6B59AEAA,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO");//0xD40BB53B,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_02");//0x431B238B,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_03");//0x34CF86F4,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_04");//0xB4C306DD,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_05");//0xEE677A25,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_06");//0xDF90DC78,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_07");//0xA4C31EE,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_08");//0x89CFB0F7,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_09");//0x7B82145C,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_10");//0x899CAF75,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_IND_01");//0x5218C819,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_01");//0x16C69281,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_02");//0xDE1FA12C,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_ARMORPIERCING");//0x51351635,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_FMJ");//0x503DEA90,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_INCENDIARY");//0xDE011286,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_TRACER");//0x8765C68A,
            sAddsList.Add("COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER");//0x730154F2,
            sAddsList.Add("COMPONENT_SWITCHBLADE_VARMOD_BASE");//0x9137A500,
            sAddsList.Add("COMPONENT_SWITCHBLADE_VARMOD_VAR1");//0x5B3E7DB6,
            sAddsList.Add("COMPONENT_SWITCHBLADE_VARMOD_VAR2");//0xE7939662,
            sAddsList.Add("COMPONENT_VINTAGEPISTOL_CLIP_01");//0x45A3B6BB,
            sAddsList.Add("COMPONENT_VINTAGEPISTOL_CLIP_02");//0x33BA12E8

            sAddsList.Add("COMPONENT_AT_AR_FLSH");//
            sAddsList.Add("COMPONENT_AT_AR_SUPP");//
            sAddsList.Add("COMPONENT_MILITARYRIFLE_CLIP_01");//
            sAddsList.Add("COMPONENT_MILITARYRIFLE_CLIP_02");//
            sAddsList.Add("COMPONENT_MILITARYRIFLE_SIGHT_01");//
            sAddsList.Add("COMPONENT_AT_SCOPE_SMALL");//
            sAddsList.Add("COMPONENT_AT_AR_FLSH");//
            sAddsList.Add("COMPONENT_AT_AR_SUPP");//

            sAddsList.Add("COMPONENT_HEAVYRIFLE_CLIP_01");// | 0x5AF49386
            sAddsList.Add("COMPONENT_HEAVYRIFLE_CLIP_02");//");// | 0x6CBF371B
            sAddsList.Add("COMPONENT_HEAVYRIFLE_SIGHT_01");// | 0xB3E1C452
            sAddsList.Add("COMPONENT_AT_SCOPE_MEDIUM");// | 0xA0D89C42
            sAddsList.Add("COMPONENT_AT_AR_FLSH");// | 0x7BC4CDDC
            sAddsList.Add("COMPONENT_AT_AR_SUPP");// | 0x837445AA
            sAddsList.Add("COMPONENT_AT_AR_AFGRIP");// | 0xC164F53
            sAddsList.Add("COMPONENT_HEAVYRIFLE_CAMO1");// | 0xEC9FECD9
            sAddsList.Add("COMPONENT_APPISTOL_VARMOD_SECURITY");//
            sAddsList.Add("COMPONENT_MICROSMG_VARMOD_SECURITY");//
            sAddsList.Add("COMPONENT_PUMPSHOTGUN_VARMOD_SECURITY");//
        }
        private void NSPMComXml()
        {

            LogginSyatem("NSPMComXml");

            if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/NEW_SPM_XML.Xml"))
            {
                XmlTextReader SaveFile = new XmlTextReader("" + Directory.GetCurrentDirectory() + "/Scripts/NEW_SPM_XML.Xml");
                while (SaveFile.Read())
                {
                    string spants = SaveFile.GetAttribute("bLoadUpOnYacht");
                    if (spants == "true")
                        bLoadUpOnYacht = true;
                    else
                        bLoadUpOnYacht = false;

                    spants = SaveFile.GetAttribute("bPlayingNewMissions");
                    if (spants == "true")
                        bPlayingNewMissions = false;
                    else
                        bPlayingNewMissions = true;
                }
                SaveFile.Close();
            }
        }
        private void NSPMSetXml()
        {

            LogginSyatem("NSPMSetXml");

            XmlWriterSettings NSPMsettings = new XmlWriterSettings();
            NSPMsettings.Indent = true;
            NSPMsettings.IndentChars = "\t";
            NSPMsettings.NewLineOnAttributes = true;
            XmlWriter SaveFile = XmlWriter.Create("" + Directory.GetCurrentDirectory() + "/Scripts/NEW_SPM_XML.Xml", NSPMsettings);

            SaveFile.WriteStartElement("Settings");

            SaveFile.WriteStartAttribute("bPlayingNewMissions");
            SaveFile.WriteValue(bPlayingNewMissions);
            SaveFile.WriteEndAttribute();

            SaveFile.WriteStartAttribute("bLoadUpOnYacht");
            SaveFile.WriteValue(bLoadUpOnYacht);
            SaveFile.WriteEndAttribute();

            SaveFile.WriteEndElement();
            SaveFile.Close();
        }
        private void BuildBoolList()
        {

            LogginSyatem("BuildBoolList");

            bool bOnOff = true;
            int iList = 30;
            if (bRandList.Count() != iList - 1)
            {
                for (int i = 0; i < iList; i++)
                {
                    bOnOff = !bOnOff;
                    bRandList.Add(bOnOff);
                }
            }
        }
        public class WeaponSaver
        {
            public string sPlayWeaps { get; set; }
            public List<string> PlayCompsList { get; set; }
            public int iAmmos { get; set; }

            public WeaponSaver()
            {
                PlayCompsList = new List<string>();
            }
        }
        private void ReturnWeaps()
        {
            LogginSyatem("ReturnWeaps");

            Ped Peddy = Game.Player.Character;

            for (int i = 0; i < wMyWeaps.Count; i++)
            {
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, wMyWeaps[i].sPlayWeaps), 0, false, true);

                for (int ii = 0; ii < wMyWeaps[i].PlayCompsList.Count; ii++)
                {
                    if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, Function.Call<int>(Hash.GET_HASH_KEY, wMyWeaps[i].sPlayWeaps), Function.Call<int>(Hash.GET_HASH_KEY, wMyWeaps[i].PlayCompsList[ii])))
                    {
                        Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, wMyWeaps[i].sPlayWeaps), Function.Call<int>(Hash.GET_HASH_KEY, wMyWeaps[i].PlayCompsList[ii]));
                    }
                }
                LockNLoad(wMyWeaps[i].iAmmos, wMyWeaps[i].sPlayWeaps, Peddy);

                if (Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, wMyWeaps[i].sPlayWeaps)) < wMyWeaps[i].iAmmos)
                {
                    if (!bWeaponFault)
                        bWeaponFault = true;
                }
            }
            Function.Call(Hash.SET_PED_CURRENT_WEAPON_VISIBLE, Game.Player.Character, false, true, true, true);
        }
        private void GetWeaps()
        {
            LogginSyatem("GetWeaps");

            wMyWeaps.Clear();
            Ped Peddy = Game.Player.Character;

            for (int i = 0; i < sWeapList.Count; i++)
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeapList[i]), false))
                {
                    WeaponSaver AdThis = new WeaponSaver();
                    AdThis.sPlayWeaps = sWeapList[i];
                    int iAmmos = 0;
                    iAmmos = Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeapList[i]));
                    if (iAmmos < 1)
                        iAmmos = 1;
                    AdThis.iAmmos = iAmmos;

                    for (int ii = 0; ii < sAddsList.Count; ii++)
                    {
                        if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sWeapList[i]), Function.Call<int>(Hash.GET_HASH_KEY, sAddsList[ii])))
                            AdThis.PlayCompsList.Add(sAddsList[ii]);
                    }
                    wMyWeaps.Add(AdThis);
                }
            }
            WriteSetXML();
        }
        public int MaxAmmo(string sWeap, Ped Peddy)
        {
            int iAmmo = 0;
            int iWeap = Function.Call<int>(Hash.GET_HASH_KEY, sWeap);

            unsafe
            {
                Function.Call<bool>(Hash.GET_MAX_AMMO, Peddy.Handle, iWeap, &iAmmo);
            }
            return iAmmo;
        }
        private void SetUpMod()
        {

            LogginSyatem("SetUpMod");

            World.SetRelationshipBetweenGroups(Relationship.Hate, PlayerGroups, AttackingNPCs);
            World.SetRelationshipBetweenGroups(Relationship.Hate, AttackingNPCs, PlayerGroups);

            World.SetRelationshipBetweenGroups(Relationship.Like, PlayerGroups, FriendlyNPCs);
            World.SetRelationshipBetweenGroups(Relationship.Like, FriendlyNPCs, PlayerGroups);

            World.SetRelationshipBetweenGroups(Relationship.Hate, AttackingNPCs, FriendlyNPCs);
            World.SetRelationshipBetweenGroups(Relationship.Hate, FriendlyNPCs, AttackingNPCs);

            UI.Notify("Random Start " + sVersion + " by Adopcalipt Loaded");

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
                bEnhanceT = true;
                bDisableDLCVeh = false;
            }

            if (File.Exists("" + Directory.GetCurrentDirectory() + "/TrainerV.asi"))
                bDisableDLCVeh = false;

            if (File.Exists("" + Directory.GetCurrentDirectory() + "/AddonSpawner.asi"))
                bDisableDLCVeh = false;

            PeskyDoors.Add(new Vector3(4977.988f, -5764.742f, 20.93811f));
            PeskyDoors.Add(new Vector3(4989.251f, -5717.235f, 19.87565f));
            PeskyDoors.Add(new Vector3(4983.159f, -5711.408f, 19.40226f));

            Vector3 Vpos = new Vector3(-282.8405f, 2834.9153f, 53.3622f);
            Vector3 Vrot = new Vector3(0.00f, 0.00f, 151.3774f);
            Prop Props = World.CreateProp(Function.Call<int>(Hash.GET_HASH_KEY, "prop_fib_3b_cover1"), Vpos, Vrot, true, false);
            Props.IsPersistent = true;
        }
        private void LoadUp()
        {
            Game.FadeScreenOut(1);
            Script.Wait(4000);

            if (File.Exists(sBeeLogs))
                File.Delete(sBeeLogs);

            LogginSyatem("LoadUp");

            FaceTheFacts();
            PedPools();
            WeatherList();
            IHearVoices();
            SeatList();
            GetNames();
            WeapsList();
            LoadupWeaponXML();
            NSPMComXml();
            LoadSetXML();

            BuildBoolList();
            SetUpMod();

            StartTheMod(0, true);
        }
        private void StartTheMod(int iSelects, bool bLoading)
        {
            LogginSyatem("StartTheMod, iSelects == " + iSelects + ", bLoading == " + bLoading);

            if (MyPedCollection.Count == 1)
            {
                bSavedPed = false;
                WriteSetXML();
            }

            Game.Player.WantedLevel = 0;
            Game.FadeScreenOut(1);
            Game.Player.Character.IsInvincible = true;

            if (bLoading)
            {
                if (!bLoadUpOnYacht)
                {
                    Game.Player.Character.FreezePosition = false;
                    Game.Player.Character.HasCollision = true;
                }

                if (Game.Player.Character.Model == PedHash.Franklin)
                {
                    sMainChar = "player_one";
                    sFunChar01 = "player_zero";
                    sFunChar02 = "player_two";
                }
                else if (Game.Player.Character.Model == PedHash.Michael)
                {
                    sMainChar = "player_zero";
                    sFunChar01 = "player_one";
                    sFunChar02 = "player_two";
                }
                else if (Game.Player.Character.Model == PedHash.Trevor)
                {
                    sMainChar = "player_two";
                    sFunChar01 = "player_one";
                    sFunChar02 = "player_zero";
                }
                else
                {
                    sMainChar = "player_zero";
                    sFunChar01 = "player_one";
                    sFunChar02 = "player_two"; ;
                }

                if (bRandLocate)
                    RandomLocations(FindRandom(1, 1, 24));
                else
                {
                    if (bMainProtag)
                    {
                        if (Game.Player.Character.Model != PedHash.Franklin || Game.Player.Character.Model != PedHash.Michael || Game.Player.Character.Model != PedHash.Trevor)
                            YourRanPed(sMainChar);
                    }
                    else
                    {
                        if (bSavedPed)
                            YourSavedPed();
                    }
                    Game.Player.Character.IsInvincible = false;
                    Script.Wait(2000);
                    Game.FadeScreenIn(1000);
                    CleanUpMess();
                }
                bLoaded = true;
            }
            else
            {
                bOpenDoors = false;

                if (bInYankton && iSelects != 23)
                    Yankton(false);
                else if (bInCayoPerico && iSelects != 24)
                    CayoPerico(false);

                if (bDontStopMe)
                    BacktoBase(bPrisHeli);

                if (bMethActor)
                    MethEdd(true);

                if (iSelects == 0)
                    RandomLocations(FindRandom(1, 1, 23));
                else
                    RandomLocations(iSelects);
            }
            WriteSetXML();
        }
        private void RandomLocations(int iSelect)
        {

            LogginSyatem("RandomLocations, iSelect == " + iSelect);

            List<float> fHeading = new List<float>();
            List<Vector3> Pos_01 = new List<Vector3>();
            List<Vector3> Pos_02 = new List<Vector3>();

            int iSubSet = 0;
            int iAction = 0;
            int iEnterVeh = 0;
            int iWeapons = 0;
            bool bRequestPB = false;

            if (iSelect == 1)
            {
                World.CurrentDayTime = TimeSpan.FromHours(12);
                World.Weather = Weather.ExtraSunny;

                if (BoolList(1))
                {
                    Pos_01.Add(new Vector3(84.15928f, 870.0395f, 196.9632f)); fHeading.Add(198.6257f);
                    Pos_01.Add(new Vector3(1085.424f, -623.1199f, 55.74931f)); fHeading.Add(231.864f);
                    Pos_01.Add(new Vector3(1935.267f, 138.6639f, 161.0021f)); fHeading.Add(252.3587f);
                    Pos_01.Add(new Vector3(-1545.141f, 5333.643f, 0.374609f)); fHeading.Add(252.4405f);
                    Pos_01.Add(new Vector3(191.4103f, 4008.992f, 30.16784f)); fHeading.Add(247.7711f);
                    Pos_01.Add(new Vector3(735.3177f, 3875.103f, 30.30095f)); fHeading.Add(250.4637f);
                    Pos_01.Add(new Vector3(1301.419f, 4081.359f, 30.85315f)); fHeading.Add(250.8063f);
                    Pos_01.Add(new Vector3(1890.581f, 4207.984f, 29.69297f)); fHeading.Add(254.4965f);
                    Pos_01.Add(new Vector3(3942.418f, 4520.72f, 0.04050386f)); fHeading.Add(254.2912f);
                    Pos_01.Add(new Vector3(1275.859f, 6781.243f, 1.875325f)); fHeading.Add(255.149f);
                    Pos_01.Add(new Vector3(817.8608f, 6868.745f, 0.6500905f)); fHeading.Add(254.5598f);
                    Pos_01.Add(new Vector3(555.2587f, 6948.927f, 2.070866f)); fHeading.Add(235.7191f);
                    Pos_01.Add(new Vector3(380.6453f, 7111.351f, 1.341785f)); fHeading.Add(103.1293f);
                    Pos_01.Add(new Vector3(-75.04967f, 7162.032f, 0.7809207f)); fHeading.Add(106.3162f);
                    Pos_01.Add(new Vector3(-136.6161f, 6985.519f, 2.248812f)); fHeading.Add(109.5711f);
                    Pos_01.Add(new Vector3(-217.6722f, 6772.711f, 0.7187195f)); fHeading.Add(112.3855f);
                    Pos_01.Add(new Vector3(-432.1755f, 6602.485f, -0.9444882f)); fHeading.Add(113.2111f);
                    Pos_01.Add(new Vector3(-711.3498f, 6438.557f, 1.175478f)); fHeading.Add(114.2294f);
                    Pos_01.Add(new Vector3(-783.0923f, 6179.819f, 1.159182f)); fHeading.Add(113.195f);
                    Pos_01.Add(new Vector3(-855.4564f, 6329.2f, 1.649986f)); fHeading.Add(112.0618f);
                    Pos_01.Add(new Vector3(-1105.409f, 6230.149f, 1.402328f)); fHeading.Add(106.5892f);
                    Pos_01.Add(new Vector3(-1041.873f, 5980.121f, 1.402047f)); fHeading.Add(102.712f);
                    Pos_01.Add(new Vector3(-1089.262f, 5718.566f, 2.109917f)); fHeading.Add(99.14839f);
                    Pos_01.Add(new Vector3(-1259.799f, 5542.388f, 1.329061f)); fHeading.Add(101.9638f);
                    Pos_01.Add(new Vector3(-2010.965f, 4706.432f, 0.2131054f)); fHeading.Add(98.64931f);
                    Pos_01.Add(new Vector3(-2289.724f, 4718.518f, 1.205942f)); fHeading.Add(100.3706f);
                    Pos_01.Add(new Vector3(-2620.681f, 4375.571f, 2.598233f)); fHeading.Add(102.3983f);
                    Pos_01.Add(new Vector3(-2752.379f, 3823.479f, 2.192016f)); fHeading.Add(108.3891f);
                    Pos_01.Add(new Vector3(-3094.804f, 3660.478f, 0.3773279f)); fHeading.Add(108.2939f);
                    Pos_01.Add(new Vector3(-3285.914f, 3382.975f, -0.6846119f)); fHeading.Add(111.7754f);
                    Pos_01.Add(new Vector3(-3106.192f, 3070.644f, 0.5554894f)); fHeading.Add(102.6006f);
                    Pos_01.Add(new Vector3(-2875.93f, 2896.969f, 1.137105f)); fHeading.Add(103.0204f);
                    Pos_01.Add(new Vector3(-3370.646f, 1288.255f, 1.050613f)); fHeading.Add(104.7735f);
                    Pos_01.Add(new Vector3(-3457.67f, 1109.7f, -0.8914479f)); fHeading.Add(86.42601f);
                    Pos_01.Add(new Vector3(-3358.214f, 755.0081f, 0.5048277f)); fHeading.Add(89.27978f);
                    Pos_01.Add(new Vector3(-3270.875f, 507.7149f, 1.220188f)); fHeading.Add(97.51931f);
                    Pos_01.Add(new Vector3(-3299.841f, 145.6124f, 1.549924f)); fHeading.Add(98.60503f);
                    Pos_01.Add(new Vector3(-3109.922f, -176.991f, 0.5766438f)); fHeading.Add(98.75866f);
                    Pos_01.Add(new Vector3(-2576.633f, -557.041f, 0.371466f)); fHeading.Add(96.98157f);
                    Pos_01.Add(new Vector3(-2186.475f, -772.5471f, 2.227773f)); fHeading.Add(98.03549f);
                    Pos_01.Add(new Vector3(-1997.154f, -1051.069f, 0.6151424f)); fHeading.Add(99.92389f);
                    Pos_01.Add(new Vector3(-1693.719f, -1348.646f, -0.7338865f)); fHeading.Add(314.2184f);
                    Pos_01.Add(new Vector3(-1604.932f, -1523.64f, -0.2957365f)); fHeading.Add(317.7053f);
                    Pos_01.Add(new Vector3(-1508.621f, -1717.438f, 2.088923f)); fHeading.Add(314.3288f);
                    Pos_01.Add(new Vector3(-1412.39f, -1908.503f, 1.763029f)); fHeading.Add(340.169f);
                    Pos_01.Add(new Vector3(-1564.309f, -2060.263f, 0.694436f)); fHeading.Add(337.7032f);

                    iAction = 1;

                    iEnterVeh = RandInt(1, 3);
                }
                else
                {
                    Pos_01.Add(new Vector3(-1586.421f, -1162.615f, 2.148071f)); fHeading.Add(169.5818f);
                    Pos_01.Add(new Vector3(-1528.565f, -1229.046f, 2.304519f)); fHeading.Add(346.878f);
                    Pos_01.Add(new Vector3(-1516.088f, -1253.902f, 2.428257f)); fHeading.Add(328.3608f);
                    Pos_01.Add(new Vector3(-1521.939f, -1260.365f, 2.188367f)); fHeading.Add(270.5981f);
                    Pos_01.Add(new Vector3(-1497.356f, -1299.038f, 2.420877f)); fHeading.Add(357.6385f);
                    Pos_01.Add(new Vector3(-1493.324f, -1315.754f, 2.520744f)); fHeading.Add(347.6972f);
                    Pos_01.Add(new Vector3(-1484.929f, -1348.339f, 2.574805f)); fHeading.Add(312.4344f);
                    Pos_01.Add(new Vector3(-1479.488f, -1363.246f, 2.578f)); fHeading.Add(246.9683f);
                    Pos_01.Add(new Vector3(-1468.606f, -1384.8f, 2.509771f)); fHeading.Add(310.6684f);
                    Pos_01.Add(new Vector3(-1469.201f, -1408.029f, 2.463026f)); fHeading.Add(347.6103f);
                    Pos_01.Add(new Vector3(-1463.954f, -1428.468f, 2.187906f)); fHeading.Add(290.5826f);
                    Pos_01.Add(new Vector3(-1435.296f, -1441.728f, 2.632148f)); fHeading.Add(359.6833f);
                    Pos_01.Add(new Vector3(-1426.745f, -1460.802f, 2.664341f)); fHeading.Add(325.3264f);
                    Pos_01.Add(new Vector3(-1422.999f, -1475.75f, 2.639942f)); fHeading.Add(325.3264f);
                    Pos_01.Add(new Vector3(-1415.703f, -1489.203f, 2.558141f)); fHeading.Add(353.3201f);
                    Pos_01.Add(new Vector3(-1415.128f, -1498.685f, 2.59455f)); fHeading.Add(345.1029f);
                    Pos_01.Add(new Vector3(-1400.996f, -1517.704f, 2.703964f)); fHeading.Add(351.7414f);
                    Pos_01.Add(new Vector3(-1408.302f, -1525.03f, 2.562711f)); fHeading.Add(341.0873f);
                    Pos_01.Add(new Vector3(-1402.26f, -1536.069f, 2.581975f)); fHeading.Add(306.2956f);
                    Pos_01.Add(new Vector3(-1388.75f, -1542.711f, 2.721804f)); fHeading.Add(331.3119f);
                    Pos_01.Add(new Vector3(-1387.059f, -1556.354f, 2.630548f)); fHeading.Add(28.35612f);
                    Pos_01.Add(new Vector3(-1379.348f, -1565.413f, 2.68825f)); fHeading.Add(323.7297f);
                    Pos_01.Add(new Vector3(-1369.724f, -1578.161f, 2.725863f)); fHeading.Add(331.198f);
                    Pos_01.Add(new Vector3(-1375.492f, -1584.465f, 2.564658f)); fHeading.Add(273.914f);
                    Pos_01.Add(new Vector3(-1371.115f, -1595.559f, 2.581006f)); fHeading.Add(304.458f);
                    Pos_01.Add(new Vector3(-1363.927f, -1608.285f, 2.532254f)); fHeading.Add(299.6023f);
                    Pos_01.Add(new Vector3(-1364.569f, -1601.117f, 2.679783f)); fHeading.Add(294.5104f);
                    Pos_01.Add(new Vector3(-1346.654f, -1630.882f, 2.597588f)); fHeading.Add(354.3592f);
                    Pos_01.Add(new Vector3(-1346.722f, -1639.003f, 2.568485f)); fHeading.Add(324.4639f);
                    Pos_01.Add(new Vector3(-1339.9f, -1652.533f, 2.579392f)); fHeading.Add(303.4597f);
                    Pos_01.Add(new Vector3(-1330.892f, -1664.46f, 2.575971f)); fHeading.Add(283.3677f);
                    Pos_01.Add(new Vector3(-1322.36f, -1663.263f, 2.638669f)); fHeading.Add(322.4428f);
                    Pos_01.Add(new Vector3(-1315.824f, -1679.906f, 2.557489f)); fHeading.Add(305.1698f);
                    Pos_01.Add(new Vector3(-1301.206f, -1686.862f, 2.715342f)); fHeading.Add(313.1601f);
                    Pos_01.Add(new Vector3(-1307.643f, -1692.448f, 2.611342f)); fHeading.Add(334.6165f);
                    Pos_01.Add(new Vector3(-1277.857f, -1739.297f, 2.930711f)); fHeading.Add(308.0513f);
                    Pos_01.Add(new Vector3(-1274.078f, -1764.758f, 2.119832f)); fHeading.Add(331.0865f);
                    Pos_01.Add(new Vector3(-1264.89f, -1759.778f, 2.590501f)); fHeading.Add(314.4068f);
                    Pos_01.Add(new Vector3(-1252.271f, -1761.727f, 2.55158f)); fHeading.Add(253.1007f);
                    Pos_01.Add(new Vector3(-1253.291f, -1774.201f, 2.608327f)); fHeading.Add(289.2869f);
                    Pos_01.Add(new Vector3(-2965.339f, 2.691767f, 6.472663f)); fHeading.Add(41.93862f);
                    Pos_01.Add(new Vector3(-2960.771f, -9.283625f, 5.146744f)); fHeading.Add(238.9136f);
                    Pos_01.Add(new Vector3(-2931.057f, -7.421918f, 6.923255f)); fHeading.Add(52.41067f);

                    iAction = 2;
                }
            }                 //Beach Ped
            else if (iSelect == 2)
            {
                World.Weather = Weather.Raining;

                if (BoolList(2))
                {
                    World.CurrentDayTime = TimeSpan.FromHours(12);

                    Pos_01.Add(new Vector3(203.1747f, -1323.28f, 29.49488f)); fHeading.Add(193.3338f);
                    Pos_01.Add(new Vector3(208.8623f, -1112.774f, 29.48404f)); fHeading.Add(24.76219f);
                    Pos_01.Add(new Vector3(-275.8094f, -1454.74f, 31.61106f)); fHeading.Add(253.4336f);
                    Pos_01.Add(new Vector3(-693.1378f, -1577.24f, 18.84266f)); fHeading.Add(353.1736f);
                    Pos_01.Add(new Vector3(-800.6707f, -2524.994f, 14.12026f)); fHeading.Add(169.2693f);
                    Pos_01.Add(new Vector3(-394.2787f, -1808.287f, 21.73676f)); fHeading.Add(62.14956f);
                    Pos_01.Add(new Vector3(-442.7756f, -1421.596f, 29.47493f)); fHeading.Add(296.8138f);
                    Pos_01.Add(new Vector3(-749.0342f, -1104.87f, 10.93612f)); fHeading.Add(343.8803f);
                    Pos_01.Add(new Vector3(-970.386f, -417.4318f, 38.12127f)); fHeading.Add(58.37359f);
                    Pos_01.Add(new Vector3(-268.4693f, -369.2575f, 30.27961f)); fHeading.Add(35.20417f);
                    Pos_01.Add(new Vector3(-229.4433f, -57.87684f, 49.78816f)); fHeading.Add(327.3621f);
                    Pos_01.Add(new Vector3(-201.4504f, 259.4538f, 92.27294f)); fHeading.Add(317.8449f);

                    iAction = 3;
                }           //HoldSign Tramp
                else
                {
                    World.CurrentDayTime = TimeSpan.FromHours(3);

                    Pos_01.Add(new Vector3(351.7925f, -1188.58f, 29.48054f)); fHeading.Add(1.868855f);
                    Pos_01.Add(new Vector3(138.2023f, -1218.859f, 29.74356f)); fHeading.Add(149.2099f);
                    Pos_01.Add(new Vector3(18.54766f, -1213.865f, 29.78357f)); fHeading.Add(277.7195f);
                    Pos_01.Add(new Vector3(345.3155f, -1093.126f, 29.72063f)); fHeading.Add(329.6081f);
                    Pos_01.Add(new Vector3(466.7483f, -864.7038f, 27.09684f)); fHeading.Add(98.30646f);
                    Pos_01.Add(new Vector3(262.903f, -1114.465f, 29.64995f)); fHeading.Add(29.92652f);
                    Pos_01.Add(new Vector3(843.3406f, -852.6771f, 26.6483f)); fHeading.Add(335.358f);
                    iAction = 4;
                }
                iWeapons = 1;
            }            //Tramps
            else if (iSelect == 3)
            {
                RandomWeatherTime();

                if (BoolList(3))
                {
                    Pos_01.Add(new Vector3(-1354.29f, -140.058f, 49.57456f));
                    Pos_01.Add(new Vector3(-1026.242f, 315.9842f, 66.88311f));
                    Pos_01.Add(new Vector3(-1026.074f, 360.7628f, 71.36153f));
                    Pos_01.Add(new Vector3(-892.2721f, 352.8219f, 85.47115f));
                    Pos_01.Add(new Vector3(-875.8641f, 315.7621f, 84.15994f));
                    Pos_01.Add(new Vector3(-819.4623f, 268.2599f, 86.38909f));
                    Pos_01.Add(new Vector3(-948.934f, 320.3693f, 71.35191f));
                    Pos_01.Add(new Vector3(-1037.066f, 207.9634f, 64.56448f));
                    Pos_01.Add(new Vector3(-949.5158f, 196.6293f, 67.39026f));
                    Pos_01.Add(new Vector3(-916.7498f, 203.2301f, 69.43185f));
                    Pos_01.Add(new Vector3(-993.275f, 162.2733f, 62.14541f));
                    Pos_01.Add(new Vector3(-971.3362f, 122.028f, 57.04857f));
                    Pos_01.Add(new Vector3(-923.2835f, 124.1776f, 55.53205f));
                    Pos_01.Add(new Vector3(-934.5027f, 3.251942f, 47.74643f));
                    Pos_01.Add(new Vector3(-896.5391f, -4.971326f, 43.79887f));
                    Pos_01.Add(new Vector3(-1878.568f, 214.5692f, 84.43929f));
                    Pos_01.Add(new Vector3(-1892.024f, 235.6097f, 86.25183f));
                    Pos_01.Add(new Vector3(-1921.954f, 308.4248f, 89.07661f));
                    Pos_01.Add(new Vector3(-1930.378f, 369.2367f, 93.78211f));
                    Pos_01.Add(new Vector3(-1941.7f, 386.0603f, 96.50709f));
                    Pos_01.Add(new Vector3(-1943.1f, 449.7197f, 102.9281f));
                    Pos_01.Add(new Vector3(-1939.811f, 534.4824f, 114.8257f));
                    Pos_01.Add(new Vector3(-1929.164f, 595.4424f, 122.2849f));
                    Pos_01.Add(new Vector3(-1897.366f, 642.0092f, 130.2086f));
                    Pos_01.Add(new Vector3(-1967.342f, 649.6359f, 122.5363f));
                    Pos_01.Add(new Vector3(-2000.012f, 613.8847f, 117.9034f));
                    Pos_01.Add(new Vector3(-2024.877f, 478.917f, 107.1619f));
                    Pos_01.Add(new Vector3(-2022.839f, 455.3822f, 105.753f));
                    Pos_01.Add(new Vector3(-2011.445f, 350.2057f, 94.4791f));
                    Pos_01.Add(new Vector3(-2009.404f, 289.1414f, 91.97834f));
                    Pos_01.Add(new Vector3(-1970.168f, 246.2813f, 87.81215f));
                    Pos_01.Add(new Vector3(-1960.694f, 212.0906f, 86.81219f));
                    Pos_01.Add(new Vector3(-1931.561f, 162.9542f, 84.65261f));
                    Pos_01.Add(new Vector3(-1906.881f, 141.3684f, 81.64087f));
                    Pos_01.Add(new Vector3(-479.2487f, 218.3924f, 83.69603f));
                    Pos_01.Add(new Vector3(-569.7756f, 169.5958f, 66.56587f));
                    Pos_01.Add(new Vector3(-511.6719f, 108.9022f, 63.79959f));
                    Pos_01.Add(new Vector3(-392.7119f, 151.4118f, 65.52414f));
                    Pos_01.Add(new Vector3(-208.1687f, 159.859f, 74.05302f));
                    Pos_01.Add(new Vector3(-149.0777f, 121.9784f, 70.22536f));
                    Pos_01.Add(new Vector3(-329.4156f, 97.45921f, 67.05153f));
                    Pos_01.Add(new Vector3(-355.3001f, 94.91445f, 70.5202f));
                    Pos_01.Add(new Vector3(-355.2776f, 15.46274f, 47.85473f));
                    Pos_01.Add(new Vector3(-314.8544f, 83.60764f, 71.66293f));
                    Pos_01.Add(new Vector3(-282.1409f, 12.98766f, 54.75249f));
                    Pos_01.Add(new Vector3(-219.1817f, -3.427589f, 52.36488f));
                    Pos_01.Add(new Vector3(-161.3873f, -3.951782f, 62.46285f));
                    Pos_01.Add(new Vector3(-117.107f, -37.25715f, 62.19587f));
                    Pos_01.Add(new Vector3(-77.88377f, 7.237984f, 70.25868f));
                    Pos_01.Add(new Vector3(-0.08573192f, -15.04306f, 71.10311f));
                }
                else
                {
                    Pos_01.Add(new Vector3(-1673.788f, 397.77f, 88.52644f)); fHeading.Add(64.57473f);
                    Pos_01.Add(new Vector3(-1752.39f, 364.5465f, 89.1705f)); fHeading.Add(116.9318f);
                    Pos_01.Add(new Vector3(-1793.994f, 348.2893f, 88.0877f)); fHeading.Add(61.06843f);
                    Pos_01.Add(new Vector3(-1855.511f, 326.3394f, 88.22096f)); fHeading.Add(11.76969f);
                    Pos_01.Add(new Vector3(-1889.329f, 625.9503f, 129.5342f)); fHeading.Add(136.4553f);
                    Pos_01.Add(new Vector3(-1973.023f, 623.2357f, 121.8878f)); fHeading.Add(245.8481f);
                    Pos_01.Add(new Vector3(-1939.265f, 582.2429f, 118.715f)); fHeading.Add(70.56753f);
                    Pos_01.Add(new Vector3(-1988.716f, 606.395f, 117.4611f)); fHeading.Add(258.2865f);
                    Pos_01.Add(new Vector3(-1941.78f, 551.6149f, 114.3409f)); fHeading.Add(337.9585f);
                    Pos_01.Add(new Vector3(-2013.584f, 485.0325f, 106.6326f)); fHeading.Add(259.0422f);
                    Pos_01.Add(new Vector3(-2009.889f, 454.6579f, 102.1945f)); fHeading.Add(284.8948f);
                    Pos_01.Add(new Vector3(-1952.689f, 447.425f, 100.5408f)); fHeading.Add(7.571787f);
                    Pos_01.Add(new Vector3(-1944.265f, 385.2967f, 95.9594f)); fHeading.Add(99.1428f);
                    Pos_01.Add(new Vector3(-2001.322f, 367.8698f, 94.0161f)); fHeading.Add(0.2865385f);
                    Pos_01.Add(new Vector3(-1935.729f, 361.8442f, 93.28986f)); fHeading.Add(176.5911f);
                    Pos_01.Add(new Vector3(-1993.105f, 294.0038f, 91.29748f)); fHeading.Add(197.3417f);
                    Pos_01.Add(new Vector3(-1922.19f, 283.8107f, 88.60562f)); fHeading.Add(100.6357f);
                    Pos_01.Add(new Vector3(-1976.696f, 260.4303f, 86.75058f)); fHeading.Add(288.7364f);
                    Pos_01.Add(new Vector3(-1903.89f, 239.3635f, 85.78407f)); fHeading.Add(26.79044f);
                    Pos_01.Add(new Vector3(-1936.075f, 183.7075f, 84.14386f)); fHeading.Add(308.4178f);
                    Pos_01.Add(new Vector3(-1875.329f, 186.7319f, 83.62743f)); fHeading.Add(127.5535f);
                    Pos_01.Add(new Vector3(-1893.187f, 136.2495f, 80.99354f)); fHeading.Add(37.06417f);
                    Pos_01.Add(new Vector3(-812.4685f, 807.1378f, 201.7596f)); fHeading.Add(17.88073f);
                    Pos_01.Add(new Vector3(-851.6611f, 790.9014f, 191.4005f)); fHeading.Add(6.430694f);
                    Pos_01.Add(new Vector3(-904.0649f, 782.9053f, 185.7406f)); fHeading.Add(6.035343f);
                    Pos_01.Add(new Vector3(-918.5698f, 808.3696f, 183.9496f)); fHeading.Add(182.1112f);
                    Pos_01.Add(new Vector3(-955.7166f, 800.1675f, 177.5815f)); fHeading.Add(183.1433f);
                    Pos_01.Add(new Vector3(-1000.894f, 785.6645f, 171.2225f)); fHeading.Add(293.5203f);
                    Pos_01.Add(new Vector3(-967.0729f, 762.8038f, 175.0238f)); fHeading.Add(46.42586f);
                    Pos_01.Add(new Vector3(-993.1129f, 814.3392f, 172.0806f)); fHeading.Add(148.2752f);
                    Pos_01.Add(new Vector3(-1041.432f, 795.7566f, 166.8573f)); fHeading.Add(201.332f);
                    Pos_01.Add(new Vector3(-1122.904f, 789.71f, 162.8375f)); fHeading.Add(233.6811f);
                    Pos_01.Add(new Vector3(-1244.859f, 667.4886f, 142.3025f)); fHeading.Add(158.0466f);
                    Pos_01.Add(new Vector3(-1286.737f, 649.2265f, 139.3441f)); fHeading.Add(198.2304f);
                    Pos_01.Add(new Vector3(-1289.239f, 624.079f, 138.3185f)); fHeading.Add(44.98028f);
                    Pos_01.Add(new Vector3(-1344.312f, 610.5362f, 133.2736f)); fHeading.Add(99.64004f);
                    Pos_01.Add(new Vector3(-1363.18f, 604.6163f, 133.3924f)); fHeading.Add(276.5648f);
                    Pos_01.Add(new Vector3(-1357.854f, 578.6238f, 130.9159f)); fHeading.Add(251.9284f);
                    Pos_01.Add(new Vector3(-1409.383f, 538.3973f, 122.3506f)); fHeading.Add(97.42818f);
                    Pos_01.Add(new Vector3(-1113.874f, 488.9058f, 81.69276f)); fHeading.Add(165.7216f);
                    Pos_01.Add(new Vector3(-1076.687f, 464.8525f, 77.17262f)); fHeading.Add(143.5085f);
                    Pos_01.Add(new Vector3(-1066.766f, 436.7162f, 73.34963f)); fHeading.Add(99.94284f);
                    Pos_01.Add(new Vector3(-1094.942f, 439.0531f, 74.79195f)); fHeading.Add(263.1792f);
                    Pos_01.Add(new Vector3(-1178.86f, 455.4537f, 86.16233f)); fHeading.Add(83.36571f);
                    Pos_01.Add(new Vector3(-1271.644f, 453.4395f, 94.54791f)); fHeading.Add(35.05694f);
                    Pos_01.Add(new Vector3(-1321.65f, 450.8088f, 99.1374f)); fHeading.Add(3.468128f);
                    Pos_01.Add(new Vector3(-1375.281f, 452.6062f, 104.4827f)); fHeading.Add(81.6608f);
                    Pos_01.Add(new Vector3(-1416.329f, 468.6403f, 108.4619f)); fHeading.Add(337.1019f);
                    Pos_01.Add(new Vector3(-1453.313f, 533.9914f, 118.43f)); fHeading.Add(256.1559f);
                    Pos_01.Add(new Vector3(-1470.98f, 512.717f, 116.9694f)); fHeading.Add(10.18582f);
                    Pos_01.Add(new Vector3(-1488.908f, 526.7175f, 117.4594f)); fHeading.Add(210.5038f);
                    Pos_01.Add(new Vector3(-1495.854f, 417.2953f, 110.295f)); fHeading.Add(45.96989f);
                    Pos_01.Add(new Vector3(-1540.106f, 427.4037f, 108.6132f)); fHeading.Add(272.4252f);
                    Pos_01.Add(new Vector3(-1590.182f, -59.71728f, 55.66955f)); fHeading.Add(269.1685f);
                    Pos_01.Add(new Vector3(-1585.631f, -86.23008f, 53.52139f)); fHeading.Add(267.4581f);
                    Pos_01.Add(new Vector3(-1461.92f, -31.88625f, 53.85183f)); fHeading.Add(40.65616f);
                    Pos_01.Add(new Vector3(-1615.562f, 17.31669f, 61.36497f)); fHeading.Add(331.047f);
                    Pos_01.Add(new Vector3(-1568.184f, 32.2366f, 58.26441f)); fHeading.Add(256.8505f);
                    Pos_01.Add(new Vector3(-1514.182f, 30.78186f, 55.27171f)); fHeading.Add(85.92268f);
                    Pos_01.Add(new Vector3(-1466.721f, 40.39627f, 53.11018f)); fHeading.Add(82.29241f);
                    Pos_01.Add(new Vector3(-1544.478f, 126.1857f, 55.96695f)); fHeading.Add(228.9657f);
                    Pos_01.Add(new Vector3(-907.0533f, 198.3592f, 69.12683f)); fHeading.Add(179.1594f);
                    Pos_01.Add(new Vector3(-936.0016f, 202.6086f, 67.08392f)); fHeading.Add(160.901f);
                    Pos_01.Add(new Vector3(-919.8449f, 108.8946f, 54.94579f)); fHeading.Add(79.66322f);
                    Pos_01.Add(new Vector3(-969.3384f, 103.1074f, 55.28952f)); fHeading.Add(305.5659f);
                    Pos_01.Add(new Vector3(-993.2735f, 144.3372f, 60.29063f)); fHeading.Add(290.562f);
                    Pos_01.Add(new Vector3(-1045.353f, 221.3312f, 63.38915f)); fHeading.Add(180.1422f);
                    Pos_01.Add(new Vector3(-928.8628f, 15.22822f, 47.38865f)); fHeading.Add(303.1562f);
                    Pos_01.Add(new Vector3(-891.0569f, -2.692925f, 43.06151f)); fHeading.Add(22.0157f);
                    Pos_01.Add(new Vector3(-879.8286f, -48.6999f, 37.6939f)); fHeading.Add(296.6208f);
                    Pos_01.Add(new Vector3(-834.5724f, 114.6378f, 54.93201f)); fHeading.Add(179.2774f);
                    Pos_01.Add(new Vector3(-825.395f, 271.9576f, 85.87788f)); fHeading.Add(349.0413f);
                    Pos_01.Add(new Vector3(-869.8893f, 306.2518f, 83.59718f)); fHeading.Add(152.2446f);
                    Pos_01.Add(new Vector3(-886.8126f, 364.8971f, 84.65531f)); fHeading.Add(1.787196f);
                    Pos_01.Add(new Vector3(-988.6418f, 418.2971f, 74.79593f)); fHeading.Add(200.8819f);
                    Pos_01.Add(new Vector3(-1017.659f, 357.3861f, 70.25055f)); fHeading.Add(335.9849f);
                    Pos_01.Add(new Vector3(-1042.106f, 319.8116f, 66.43107f)); fHeading.Add(301.8415f);
                    Pos_01.Add(new Vector3(-1186.364f, 286.2853f, 69.12206f)); fHeading.Add(216.3983f);
                    Pos_01.Add(new Vector3(-1132.066f, 381.8291f, 70.36998f)); fHeading.Add(238.2283f);
                    Pos_01.Add(new Vector3(-613.5519f, 677.818f, 149.0847f)); fHeading.Add(348.3205f);
                    Pos_01.Add(new Vector3(-559.5214f, 686.1437f, 144.7881f)); fHeading.Add(166.524f);
                    Pos_01.Add(new Vector3(-497.7785f, 745.8389f, 162.2046f)); fHeading.Add(242.2073f);
                    Pos_01.Add(new Vector3(-550.3578f, 831.1689f, 197.1528f)); fHeading.Add(339.137f);
                    Pos_01.Add(new Vector3(-608.5907f, 866.8416f, 212.8696f)); fHeading.Add(334.8934f);
                    Pos_01.Add(new Vector3(-661.0247f, 807.5721f, 198.7235f)); fHeading.Add(356.241f);
                    Pos_01.Add(new Vector3(-595.6389f, 806.8098f, 190.2512f)); fHeading.Add(149.1931f);
                    Pos_01.Add(new Vector3(-668.1514f, 752.6746f, 173.6188f)); fHeading.Add(0.7620906f);
                    Pos_01.Add(new Vector3(-668.8094f, 671.1213f, 149.9287f)); fHeading.Add(77.25645f);
                    Pos_01.Add(new Vector3(-710.4108f, 643.9869f, 154.6131f)); fHeading.Add(346.2415f);
                    Pos_01.Add(new Vector3(-808.8945f, 703.7688f, 146.5478f)); fHeading.Add(13.30845f);
                    Pos_01.Add(new Vector3(-862.9958f, 699.7191f, 148.4727f)); fHeading.Add(321.5082f);
                    Pos_01.Add(new Vector3(-951.4864f, 688.2122f, 153.0159f)); fHeading.Add(2.046261f);
                    Pos_01.Add(new Vector3(-1056.415f, 735.5481f, 164.8874f)); fHeading.Add(4.719154f);
                    Pos_01.Add(new Vector3(-1052.971f, 767.2552f, 167.0593f)); fHeading.Add(271.2393f);
                    Pos_01.Add(new Vector3(-1270.056f, 497.2365f, 96.60461f)); fHeading.Add(177.539f);
                    Pos_01.Add(new Vector3(-1237.144f, 487.832f, 92.70634f)); fHeading.Add(132.8591f);
                    Pos_01.Add(new Vector3(-1098.73f, 555.0469f, 102.1592f)); fHeading.Add(92.74675f);
                    Pos_01.Add(new Vector3(-1094.86f, 596.7789f, 102.5024f)); fHeading.Add(214.0652f);
                    Pos_01.Add(new Vector3(-941.9733f, 593.2686f, 100.6847f)); fHeading.Add(158.6948f);
                    Pos_01.Add(new Vector3(-952.6204f, 572.2911f, 101.0466f)); fHeading.Add(338.245f);
                    Pos_01.Add(new Vector3(-911.8775f, 587.877f, 100.6279f)); fHeading.Add(149.6929f);
                    Pos_01.Add(new Vector3(-908.5421f, 553.5905f, 95.87045f)); fHeading.Add(316.3625f);
                    Pos_01.Add(new Vector3(-845.8243f, 520.2244f, 90.02374f)); fHeading.Add(100.3152f);
                    Pos_01.Add(new Vector3(-845.8357f, 461.0065f, 87.09276f)); fHeading.Add(93.49643f);
                    Pos_01.Add(new Vector3(-964.0833f, 435.5407f, 79.3726f)); fHeading.Add(333.6538f);
                    Pos_01.Add(new Vector3(-976.3936f, 523.895f, 80.87231f)); fHeading.Add(146.8071f);
                    Pos_01.Add(new Vector3(-993.5677f, 489.7014f, 81.66727f)); fHeading.Add(11.83891f);
                    Pos_01.Add(new Vector3(-1011.735f, 489.8139f, 78.71857f)); fHeading.Add(2.953075f);
                    Pos_01.Add(new Vector3(-1045.763f, 500.1797f, 83.51974f)); fHeading.Add(215.8596f);
                    Pos_01.Add(new Vector3(-808.8355f, 425.0128f, 90.97233f)); fHeading.Add(349.3546f);
                    Pos_01.Add(new Vector3(-765.5538f, 465.7845f, 99.92818f)); fHeading.Add(213.3331f);
                    Pos_01.Add(new Vector3(-738.7115f, 443.4265f, 106.2674f)); fHeading.Add(26.59777f);
                    Pos_01.Add(new Vector3(-713.8804f, 495.2518f, 108.6712f)); fHeading.Add(206.0219f);
                    Pos_01.Add(new Vector3(-687.8669f, 502.1955f, 109.5336f)); fHeading.Add(198.9874f);
                    Pos_01.Add(new Vector3(-633.8344f, 527.5926f, 109.1043f)); fHeading.Add(190.9024f);
                    Pos_01.Add(new Vector3(-586.6672f, 528.7498f, 107.2383f)); fHeading.Add(218.2536f);
                    Pos_01.Add(new Vector3(-202.556f, 409.7411f, 109.9087f)); fHeading.Add(14.79766f);
                    Pos_01.Add(new Vector3(-304.7013f, 380.7583f, 109.7528f)); fHeading.Add(12.67552f);
                    Pos_01.Add(new Vector3(-381.2098f, 347.0158f, 108.5992f)); fHeading.Add(7.480639f);
                    Pos_01.Add(new Vector3(-404.1221f, 338.9637f, 108.1354f)); fHeading.Add(359.4413f);
                    Pos_01.Add(new Vector3(-473.5081f, 353.0821f, 103.3904f)); fHeading.Add(331.7446f);
                    Pos_01.Add(new Vector3(-449.2093f, 372.955f, 104.1925f)); fHeading.Add(88.32726f);
                    Pos_01.Add(new Vector3(-499.3677f, 428.2659f, 96.70379f)); fHeading.Add(133.329f);
                    Pos_01.Add(new Vector3(-515.5759f, 390.2937f, 93.14224f)); fHeading.Add(58.85709f);
                    Pos_01.Add(new Vector3(-603.5704f, 398.1809f, 101.1029f)); fHeading.Add(6.096045f);
                    Pos_01.Add(new Vector3(-574.8644f, 400.437f, 100.0821f)); fHeading.Add(21.19732f);
                    Pos_01.Add(new Vector3(-540.9546f, 481.944f, 102.4014f)); fHeading.Add(16.34741f);
                    Pos_01.Add(new Vector3(-527.3146f, 527.659f, 111.4062f)); fHeading.Add(44.40198f);
                    Pos_01.Add(new Vector3(-519.2817f, 574.8528f, 120.3787f)); fHeading.Add(280.6111f);
                    Pos_01.Add(new Vector3(-477.9099f, 597.2338f, 127.0411f)); fHeading.Add(91.77653f);
                    Pos_01.Add(new Vector3(-143.1443f, 596.1634f, 203.2704f)); fHeading.Add(3.014483f);
                    Pos_01.Add(new Vector3(-178.2738f, 585.178f, 197.0455f)); fHeading.Add(358.6667f);
                    Pos_01.Add(new Vector3(-226.1506f, 592.6992f, 189.5592f)); fHeading.Add(345.975f);
                    Pos_01.Add(new Vector3(-273.8918f, 600.2565f, 181.155f)); fHeading.Add(353.2928f);
                    Pos_01.Add(new Vector3(-464.1287f, 643.3572f, 143.6065f)); fHeading.Add(47.37784f);
                    Pos_01.Add(new Vector3(-395.2807f, 672.032f, 162.382f)); fHeading.Add(3.729914f);
                    Pos_01.Add(new Vector3(-343.1208f, 634.0641f, 171.7307f)); fHeading.Add(53.57518f);
                    Pos_01.Add(new Vector3(-345.2143f, 663.2159f, 168.9018f)); fHeading.Add(170.6592f);
                    Pos_01.Add(new Vector3(-302.5376f, 632.3251f, 175.0428f)); fHeading.Add(113.3986f);
                    Pos_01.Add(new Vector3(319.1369f, 495.9725f, 152.2041f)); fHeading.Add(284.5606f);
                    Pos_01.Add(new Vector3(229.6781f, 679.8453f, 189.1597f)); fHeading.Add(101.8786f);
                    Pos_01.Add(new Vector3(174.1774f, 471.3581f, 141.4379f)); fHeading.Add(351.6725f);
                    Pos_01.Add(new Vector3(108.1012f, 498.9342f, 146.6786f)); fHeading.Add(195.3518f);
                    Pos_01.Add(new Vector3(89.71058f, 488.3624f, 147.3414f)); fHeading.Add(206.6835f);
                    Pos_01.Add(new Vector3(-78.29935f, 496.4704f, 143.9985f)); fHeading.Add(339.5458f);
                    Pos_01.Add(new Vector3(-353.9483f, 474.0529f, 112.1987f)); fHeading.Add(288.0629f);
                    Pos_01.Add(new Vector3(-360.3586f, 514.3036f, 119.1824f)); fHeading.Add(139.8392f);
                    Pos_01.Add(new Vector3(-401.7088f, 511.3387f, 119.6189f)); fHeading.Add(333.415f);
                    Pos_01.Add(new Vector3(-407.652f, 561.3188f, 123.8938f)); fHeading.Add(153.9519f);
                    Pos_01.Add(new Vector3(1410.476f, 1118.693f, 114.1653f)); fHeading.Add(90.09675f);
                    Pos_01.Add(new Vector3(-1891.32f, 2045.54f, 140.1863f)); fHeading.Add(250.2802f);
                    Pos_01.Add(new Vector3(-2785.476f, 1433.886f, 100.2547f)); fHeading.Add(234.261f);
                    Pos_01.Add(new Vector3(-2995.756f, 721.6164f, 27.824f)); fHeading.Add(112.4172f);
                    Pos_01.Add(new Vector3(-2980.652f, 612.3025f, 19.50303f)); fHeading.Add(104.2501f);

                    iAction = 1;

                    iEnterVeh = RandInt(1, 2);
                }

                iWeapons = 2;
            }            //High class
            else if (iSelect == 4)
            {
                RandomWeatherTime();

                if (BoolList(4))
                {

                    Pos_01.Add(new Vector3(-356.741f, 16.12581f, 47.85474f));
                    Pos_01.Add(new Vector3(-362.0493f, 57.46016f, 54.4298f));
                    Pos_01.Add(new Vector3(-411.5159f, 152.6001f, 81.74309f));
                    Pos_01.Add(new Vector3(-384.4481f, 153.008f, 81.74698f));
                    Pos_01.Add(new Vector3(-303.3091f, 84.56718f, 76.66209f));
                    Pos_01.Add(new Vector3(-313.5391f, 83.60252f, 75.65311f));
                    Pos_01.Add(new Vector3(-332.7193f, 88.68687f, 71.21808f));
                    Pos_01.Add(new Vector3(-263.5449f, 98.93026f, 77.56315f));
                    Pos_01.Add(new Vector3(-188.5497f, 184.8336f, 88.60064f));
                    Pos_01.Add(new Vector3(-154.3215f, 214.6461f, 98.32927f));
                    Pos_01.Add(new Vector3(-143.7316f, 174.7767f, 93.62655f));
                    Pos_01.Add(new Vector3(-161.3621f, 161.0014f, 89.70206f));
                    Pos_01.Add(new Vector3(-206.0126f, -7.720617f, 60.62708f));
                    Pos_01.Add(new Vector3(-161.1083f, -4.599355f, 66.46642f));
                    Pos_01.Add(new Vector3(-102.2039f, -31.8603f, 70.44765f));
                    Pos_01.Add(new Vector3(-18.69028f, -68.38952f, 61.37531f));
                    Pos_01.Add(new Vector3(-27.58074f, -61.06355f, 67.59225f));
                    Pos_01.Add(new Vector3(-21.88984f, -23.86292f, 73.24532f));
                    Pos_01.Add(new Vector3(-14.02445f, -11.82469f, 79.34619f));
                    Pos_01.Add(new Vector3(20.95977f, 114.1915f, 87.27728f));
                    Pos_01.Add(new Vector3(107.7924f, 54.56335f, 81.77329f));
                    Pos_01.Add(new Vector3(189.1337f, 11.49182f, 81.41087f));
                    Pos_01.Add(new Vector3(212.0644f, 1.590603f, 79.19212f));
                    Pos_01.Add(new Vector3(188.576f, 40.0778f, 87.82249f));
                    Pos_01.Add(new Vector3(208.1531f, 73.78002f, 96.09595f));
                    Pos_01.Add(new Vector3(284.9831f, 47.12731f, 96.6929f));
                    Pos_01.Add(new Vector3(254.5233f, 25.36229f, 92.12718f));
                    Pos_01.Add(new Vector3(388.1746f, 2.197361f, 91.41467f));
                    Pos_01.Add(new Vector3(485.1955f, 212.3895f, 108.3095f));
                    Pos_01.Add(new Vector3(-1177.005f, -1073.163f, 5.906403f));
                    Pos_01.Add(new Vector3(-1183.198f, -1064.417f, 2.150418f));
                    Pos_01.Add(new Vector3(-1191.016f, -1054.863f, 2.150433f));
                    Pos_01.Add(new Vector3(-1188.258f, -1041.719f, 2.150275f));
                    Pos_01.Add(new Vector3(-1201.109f, -1031.956f, 2.150406f));
                    Pos_01.Add(new Vector3(-1204.234f, -1021.773f, 5.945113f));
                    Pos_01.Add(new Vector3(-1338.218f, -941.2662f, 15.35802f));
                    Pos_01.Add(new Vector3(-1353.765f, -908.0026f, 12.4705f));
                    Pos_01.Add(new Vector3(-1335.845f, -1146.224f, 6.731401f));
                    Pos_01.Add(new Vector3(-1252.488f, -1143.985f, 8.513974f));
                    Pos_01.Add(new Vector3(-1172.675f, -1260.892f, 14.90674f));
                    Pos_01.Add(new Vector3(-1229.549f, -1235.521f, 11.02771f));
                    Pos_01.Add(new Vector3(-1306.429f, -1229.076f, 8.980485f));
                    Pos_01.Add(new Vector3(-1317.88f, -1238.943f, 7.168704f));
                    Pos_01.Add(new Vector3(-1272.146f, -1295.553f, 8.285895f));
                    Pos_01.Add(new Vector3(-1246.816f, -1358.752f, 7.820462f));
                    Pos_01.Add(new Vector3(-1145.777f, -1466.309f, 7.690706f));
                    Pos_01.Add(new Vector3(-1156.229f, -1574.861f, 8.345174f));
                    Pos_01.Add(new Vector3(-1098.117f, -1673.513f, 8.39401f));
                    Pos_01.Add(new Vector3(-1059.984f, -1657.836f, 4.674311f));
                    Pos_01.Add(new Vector3(-1070.926f, -1636.006f, 8.194701f));
                    Pos_01.Add(new Vector3(-1076.572f, -1620.789f, 4.442664f));
                    Pos_01.Add(new Vector3(-1078.258f, -1616.337f, 4.428094f));
                    Pos_01.Add(new Vector3(-1093.088f, -1607.943f, 8.458809f));
                    Pos_01.Add(new Vector3(-1112.636f, -1577.709f, 8.679523f));
                    Pos_01.Add(new Vector3(-1148.522f, -1523.617f, 10.62805f));
                    Pos_01.Add(new Vector3(-1116.498f, -1506.122f, 4.403326f));
                    Pos_01.Add(new Vector3(-1110.924f, -1498.482f, 4.672343f));
                    Pos_01.Add(new Vector3(-1102.588f, -1492.073f, 4.887649f));
                    Pos_01.Add(new Vector3(-1108.559f, -1527.218f, 6.779534f));
                    Pos_01.Add(new Vector3(-1091.374f, -1517.666f, 4.792679f));
                    Pos_01.Add(new Vector3(-1086.088f, -1503.486f, 5.707945f));
                    Pos_01.Add(new Vector3(-1085.366f, -1558.724f, 4.489116f));
                    Pos_01.Add(new Vector3(-1077.584f, -1553.464f, 4.625066f));
                    Pos_01.Add(new Vector3(-1066.284f, -1545.243f, 4.902433f));
                    Pos_01.Add(new Vector3(-1057.291f, -1551.201f, 4.911008f));
                    Pos_01.Add(new Vector3(-1043.943f, -1579.937f, 5.03639f));
                    Pos_01.Add(new Vector3(-1048.449f, -1579.996f, 4.944197f));
                    Pos_01.Add(new Vector3(-1056.9f, -1587.358f, 4.613483f));
                    Pos_01.Add(new Vector3(-1038.341f, -1609.897f, 5.003761f));
                    Pos_01.Add(new Vector3(-956.5812f, -1432.736f, 7.679167f));
                    Pos_01.Add(new Vector3(-868.7635f, -1286.318f, 13.20004f));
                    Pos_01.Add(new Vector3(-936.1241f, -1310.397f, 9.70009f));
                    Pos_01.Add(new Vector3(-869.3542f, -1103.725f, 6.445571f));
                    Pos_01.Add(new Vector3(-903.3987f, -1005.532f, 2.150328f));
                    Pos_01.Add(new Vector3(-913.8767f, -989.0179f, 2.150327f));
                    Pos_01.Add(new Vector3(-908.3992f, -976.228f, 2.150325f));
                    Pos_01.Add(new Vector3(-942.7357f, -969.0355f, 2.150114f));
                    Pos_01.Add(new Vector3(-934.5264f, -939.1158f, 2.145313f));
                    Pos_01.Add(new Vector3(-947.3409f, -927.6057f, 2.145313f));
                    Pos_01.Add(new Vector3(-975.7267f, -909.0048f, 2.159486f));
                    Pos_01.Add(new Vector3(-1022.753f, -896.6989f, 5.41547f));
                    Pos_01.Add(new Vector3(-1023.957f, -912.3516f, 6.961076f));
                    Pos_01.Add(new Vector3(-1042.891f, -924.6329f, 3.154166f));
                    Pos_01.Add(new Vector3(-1053.634f, -929.9891f, 7.554896f));
                    Pos_01.Add(new Vector3(-1061.149f, -943.5154f, 2.182675f));
                    Pos_01.Add(new Vector3(-1091.015f, -925.9146f, 3.146876f));
                    Pos_01.Add(new Vector3(-1161.481f, -973.403f, 2.150194f));
                    Pos_01.Add(new Vector3(-1181.619f, -988.9208f, 2.150193f));
                    Pos_01.Add(new Vector3(-1204.326f, -943.4292f, 8.114918f));
                    Pos_01.Add(new Vector3(-1151.095f, -913.4648f, 6.628778f));
                    Pos_01.Add(new Vector3(-1042.812f, -1024.366f, 2.150358f));
                    Pos_01.Add(new Vector3(-1008.249f, -1036.944f, 2.150358f));
                    Pos_01.Add(new Vector3(-1000.026f, -1030.441f, 2.150311f));
                    Pos_01.Add(new Vector3(-997.8235f, -1012.419f, 2.150311f));
                    Pos_01.Add(new Vector3(-967.3852f, -1008.264f, 2.15031f));
                    Pos_01.Add(new Vector3(-978.1533f, -990.1673f, 4.545312f));
                    Pos_01.Add(new Vector3(-995.0858f, -966.8881f, 2.54532f));
                    Pos_01.Add(new Vector3(-1018.765f, -963.067f, 2.150194f));
                    Pos_01.Add(new Vector3(-1027.697f, -968.8497f, 2.1502f));
                    Pos_01.Add(new Vector3(-1035.725f, -984.0291f, 2.150194f));
                    Pos_01.Add(new Vector3(-1055.298f, -998.6008f, 6.410484f));
                    Pos_01.Add(new Vector3(-1130.638f, -1031.046f, 2.150357f));
                    Pos_01.Add(new Vector3(-1122.727f, -1027.076f, 2.150356f));
                    Pos_01.Add(new Vector3(-1113.141f, -1018.701f, 2.150358f));
                    Pos_01.Add(new Vector3(-1103.691f, -1013.49f, 2.150357f));
                    Pos_01.Add(new Vector3(-1101.415f, -1082.764f, 2.150356f));
                    Pos_01.Add(new Vector3(-1128.448f, -1080.953f, 4.222689f));
                    Pos_01.Add(new Vector3(-1064.395f, -1057.067f, 6.411655f));
                    Pos_01.Add(new Vector3(-1075.633f, -1026.472f, 4.545251f));
                    Pos_01.Add(new Vector3(-921.0966f, -1095.091f, 2.15031f));
                    Pos_01.Add(new Vector3(-946.3143f, -1050.763f, 2.171845f));
                    Pos_01.Add(new Vector3(-951.3636f, -1079.171f, 2.15031f));
                    Pos_01.Add(new Vector3(-960.2056f, -1109.441f, 2.150381f));
                    Pos_01.Add(new Vector3(-982.7823f, -1066.106f, 2.150313f));
                    Pos_01.Add(new Vector3(-982.4726f, -1083.512f, 2.545213f));
                    Pos_01.Add(new Vector3(-970.9428f, -1120.898f, 2.171845f));
                    Pos_01.Add(new Vector3(-991.4828f, -1103.666f, 2.150312f));
                    Pos_01.Add(new Vector3(-986.8842f, -1122.311f, 4.545273f));
                    Pos_01.Add(new Vector3(-1031.39f, -1109.176f, 2.1586f));
                    Pos_01.Add(new Vector3(-1004.998f, -1154.655f, 2.158741f));
                    Pos_01.Add(new Vector3(-1022.293f, -1160.524f, 2.1586f));
                    Pos_01.Add(new Vector3(-1031.984f, -1173.81f, 2.158597f));
                    Pos_01.Add(new Vector3(-1063.752f, -1132.606f, 2.158602f));
                    Pos_01.Add(new Vector3(-1091.859f, -1145.276f, 2.158598f));
                    Pos_01.Add(new Vector3(-1064.242f, -1159.144f, 2.159603f));
                    Pos_01.Add(new Vector3(-1068.306f, -1163.143f, 2.745344f));
                    Pos_01.Add(new Vector3(-1099.331f, -1210.65f, 2.538017f));
                    Pos_01.Add(new Vector3(-1094.835f, -1218.866f, 2.674695f));
                    Pos_01.Add(new Vector3(-1087.718f, -1230.778f, 2.91478f));
                    Pos_01.Add(new Vector3(-1126.017f, -1172.03f, 2.357591f));
                    Pos_01.Add(new Vector3(-1128.641f, -1162.314f, 6.494957f));
                    Pos_01.Add(new Vector3(-1128.47f, -1143.433f, 2.840051f));
                    Pos_01.Add(new Vector3(-1145.392f, -1127.529f, 6.503163f));
                    Pos_01.Add(new Vector3(-1142.907f, -1122.372f, 2.643049f));
                    Pos_01.Add(new Vector3(-1159.114f, -1100.559f, 6.531281f));
                    Pos_01.Add(new Vector3(-1469.499f, 23.98446f, 53.64318f));
                    Pos_01.Add(new Vector3(-1509.753f, 6.369807f, 56.06623f));
                    Pos_01.Add(new Vector3(-1579.321f, 12.67341f, 61.08215f));
                    Pos_01.Add(new Vector3(-1625.327f, 8.889999f, 62.53669f));
                    Pos_01.Add(new Vector3(-1599.91f, -33.59167f, 58.19274f));
                    Pos_01.Add(new Vector3(-1544.099f, -98.91996f, 54.52899f));
                    Pos_01.Add(new Vector3(-1481.332f, -41.2363f, 56.84435f));

                    Pos_01.Add(new Vector3(-3225.671f, 911.6782f, 13.99328f));
                    Pos_01.Add(new Vector3(-3238.209f, 922.1356f, 13.95989f));
                    Pos_01.Add(new Vector3(-3242.884f, 931.8699f, 17.22135f));
                    Pos_01.Add(new Vector3(-3237.128f, 952.9849f, 13.14549f));
                    Pos_01.Add(new Vector3(-3251.259f, 1027.374f, 11.75769f));
                    Pos_01.Add(new Vector3(-3254.493f, 1063.829f, 11.1462f));
                    Pos_01.Add(new Vector3(-3252.789f, 1077.478f, 11.03329f));
                    Pos_01.Add(new Vector3(-3228.171f, 1092.434f, 10.75639f));
                    Pos_01.Add(new Vector3(-3233.788f, 1110.743f, 10.57354f));
                    Pos_01.Add(new Vector3(-3220.034f, 1137.555f, 9.895407f));
                    Pos_01.Add(new Vector3(-3214.605f, 1149.277f, 9.895408f));
                    Pos_01.Add(new Vector3(-3205.43f, 1151.904f, 9.662267f));
                    Pos_01.Add(new Vector3(-3199.772f, 1165.077f, 9.654344f));
                    Pos_01.Add(new Vector3(-3205.8f, 1186.661f, 9.664678f));
                    Pos_01.Add(new Vector3(-3203.429f, 1206.695f, 12.82314f));
                    Pos_01.Add(new Vector3(-3193.675f, 1230.114f, 10.04832f));
                    Pos_01.Add(new Vector3(-3197.585f, 1274.163f, 12.66765f));
                    Pos_01.Add(new Vector3(-3181.797f, 1310.762f, 14.55494f));
                    Pos_01.Add(new Vector3(-3109.391f, 751.4032f, 24.70188f));
                    Pos_01.Add(new Vector3(-3106.902f, 719.2998f, 20.61939f));
                    Pos_01.Add(new Vector3(-3087.058f, 656.056f, 11.5886f));
                    Pos_01.Add(new Vector3(-3051.573f, 569.4459f, 7.823583f));
                    Pos_01.Add(new Vector3(-3044.509f, 564.0283f, 7.818895f));
                    Pos_01.Add(new Vector3(-3036.565f, 558.9866f, 7.507683f));
                    Pos_01.Add(new Vector3(-3036.482f, 544.608f, 7.507683f));
                    Pos_01.Add(new Vector3(-3041.9f, 523.9325f, 7.426294f));
                    Pos_01.Add(new Vector3(-3038.055f, 492.2998f, 6.767862f));
                    Pos_01.Add(new Vector3(-3053.02f, 487.0674f, 6.779647f));
                    Pos_01.Add(new Vector3(-3049.986f, 474.4078f, 6.779647f));
                    Pos_01.Add(new Vector3(-3069.546f, 454.4254f, 9.643095f));
                    Pos_01.Add(new Vector3(-3073.3f, 452.9189f, 6.357774f));
                    Pos_01.Add(new Vector3(-3080.653f, 406.0587f, 6.968522f));
                    Pos_01.Add(new Vector3(-3090.885f, 379.1903f, 7.112432f));
                    Pos_01.Add(new Vector3(-3102.068f, 367.1784f, 7.119124f));
                    Pos_01.Add(new Vector3(-3100.813f, 361.2336f, 7.59102f));
                    Pos_01.Add(new Vector3(-3110.472f, 335.3844f, 7.493347f));
                    Pos_01.Add(new Vector3(-3111.59f, 315.6106f, 8.38104f));
                    Pos_01.Add(new Vector3(-3115.084f, 303.729f, 8.38104f));
                    Pos_01.Add(new Vector3(-3115.483f, 294.5401f, 8.972106f));
                    Pos_01.Add(new Vector3(-3131.787f, 247.3237f, 12.492f));
                    Pos_01.Add(new Vector3(-3099.842f, 211.6886f, 14.0702f));
                    Pos_01.Add(new Vector3(-2973.217f, 600.1259f, 24.24677f));
                    Pos_01.Add(new Vector3(-2973.584f, 642.0483f, 25.79752f));
                    Pos_01.Add(new Vector3(-2995.112f, 682.2404f, 25.04422f));
                    Pos_01.Add(new Vector3(-2986.079f, 719.8495f, 28.49687f));
                    Pos_01.Add(new Vector3(-3018.052f, 746.3233f, 27.58763f));
                    Pos_01.Add(new Vector3(-1754.303f, -708.6591f, 10.39663f));
                    Pos_01.Add(new Vector3(-1764.108f, -708.2756f, 10.6142f));
                    Pos_01.Add(new Vector3(-1764.566f, -708.1951f, 14.04145f));
                    Pos_01.Add(new Vector3(-1764.033f, -708.2069f, 17.64467f));
                    Pos_01.Add(new Vector3(-1777.351f, -702.067f, 10.4848f));
                    Pos_01.Add(new Vector3(-1776.769f, -691.2233f, 16.97348f));
                    Pos_01.Add(new Vector3(-1780.731f, -680.2358f, 10.44997f));
                    Pos_01.Add(new Vector3(-1793.184f, -673.2136f, 10.57397f));
                    Pos_01.Add(new Vector3(-1803.759f, -662.3365f, 10.7237f));
                    Pos_01.Add(new Vector3(-1817.498f, -657.4927f, 13.81193f));
                    Pos_01.Add(new Vector3(-1827.267f, -652.1654f, 18.04963f));
                    Pos_01.Add(new Vector3(-1834.165f, -641.7821f, 11.47759f));
                    Pos_01.Add(new Vector3(-1836.708f, -631.6794f, 10.74891f));
                    Pos_01.Add(new Vector3(-1838.648f, -629.8493f, 11.0014f));
                    Pos_01.Add(new Vector3(-1879.679f, -606.2506f, 18.92933f));
                    Pos_01.Add(new Vector3(-1885.089f, -600.3168f, 11.89937f));
                    Pos_01.Add(new Vector3(-1885.209f, -600.2053f, 15.5457f));
                    Pos_01.Add(new Vector3(-1884.697f, -600.3395f, 19.14856f));
                    Pos_01.Add(new Vector3(-1890.028f, -592.5482f, 18.331f));
                    Pos_01.Add(new Vector3(-1901.561f, -586.2667f, 11.8717f));
                    Pos_01.Add(new Vector3(-1901.737f, -586.5366f, 15.50729f));
                    Pos_01.Add(new Vector3(-1901.345f, -586.4103f, 18.8586f));
                    Pos_01.Add(new Vector3(-1913.928f, -574.6428f, 11.43515f));
                    Pos_01.Add(new Vector3(-1920.347f, -570.4515f, 11.91194f));
                    Pos_01.Add(new Vector3(-1920.237f, -570.4377f, 14.7448f));
                    Pos_01.Add(new Vector3(-1915.89f, -565.7648f, 17.67347f));
                    Pos_01.Add(new Vector3(-1915.907f, -565.6242f, 20.47274f));
                    Pos_01.Add(new Vector3(-1923.306f, -559.0013f, 12.06105f));
                    Pos_01.Add(new Vector3(-1927.94f, -551.8524f, 11.84189f));
                    Pos_01.Add(new Vector3(-1946.505f, -548.1843f, 14.72549f));
                    Pos_01.Add(new Vector3(-1950.271f, -545.1097f, 14.72549f));
                    Pos_01.Add(new Vector3(-1958.221f, -538.7208f, 11.89937f));
                    Pos_01.Add(new Vector3(-1958.538f, -538.6161f, 15.55085f));
                    Pos_01.Add(new Vector3(-1957.957f, -538.9095f, 19.15357f));
                    Pos_01.Add(new Vector3(-1968.042f, -532.4321f, 12.17067f));
                    Pos_01.Add(new Vector3(-1976.333f, -525.4742f, 18.92434f));
                    Pos_01.Add(new Vector3(-1980.079f, -520.5913f, 11.894f));
                    Pos_01.Add(new Vector3(-1980.366f, -520.8674f, 14.7404f));
                    Pos_01.Add(new Vector3(-1976.356f, -516.4469f, 17.67827f));
                    Pos_01.Add(new Vector3(-1976.218f, -516.0389f, 20.4677f));

                    Pos_01.Add(new Vector3(1303.104f, -528.0761f, 71.46065f));// MyZone == "MIRR" 
                    Pos_01.Add(new Vector3(1328.005f, -536.041f, 72.44083f));
                    Pos_01.Add(new Vector3(1348.163f, -547.7917f, 73.89162f));
                    Pos_01.Add(new Vector3(1372.689f, -555.9731f, 74.68577f));
                    Pos_01.Add(new Vector3(1388.346f, -569.6031f, 74.49653f));
                    Pos_01.Add(new Vector3(1385.853f, -593.0632f, 74.48546f));
                    Pos_01.Add(new Vector3(1367.295f, -606.2516f, 74.71093f));
                    Pos_01.Add(new Vector3(1342f, -597.175f, 74.7008f));
                    Pos_01.Add(new Vector3(1323.486f, -582.6028f, 73.24638f));
                    Pos_01.Add(new Vector3(1301.144f, -573.8477f, 71.73234f));
                    Pos_01.Add(new Vector3(1203.279f, -557.5997f, 69.40067f));
                    Pos_01.Add(new Vector3(1201.368f, -578.7299f, 69.13488f));
                    Pos_01.Add(new Vector3(1203.674f, -599.1799f, 68.06352f));
                    Pos_01.Add(new Vector3(1206.905f, -619.9584f, 66.43616f));
                    Pos_01.Add(new Vector3(1221.432f, -668.447f, 63.50019f));
                    Pos_01.Add(new Vector3(1222.634f, -696.9823f, 60.80664f));
                    Pos_01.Add(new Vector3(1228.98f, -725.4678f, 60.79766f));
                    Pos_01.Add(new Vector3(1265.76f, -703.2062f, 64.56302f));
                    Pos_01.Add(new Vector3(1271.215f, -683.229f, 66.03163f));
                    Pos_01.Add(new Vector3(1265.496f, -648.1833f, 67.92143f));
                    Pos_01.Add(new Vector3(1243.872f, -634.2845f, 69.32861f));
                    Pos_01.Add(new Vector3(1233.232f, -593.3051f, 69.42253f));
                    Pos_01.Add(new Vector3(1242.479f, -565.8297f, 69.65738f));
                    Pos_01.Add(new Vector3(1239.262f, -513.1147f, 69.12914f));
                    Pos_01.Add(new Vector3(1251.532f, -494.2249f, 69.90682f));
                    Pos_01.Add(new Vector3(1260.101f, -479.5116f, 70.18879f));
                    Pos_01.Add(new Vector3(1266.084f, -458.3353f, 70.51691f));
                    Pos_01.Add(new Vector3(1262.461f, -429.394f, 70.01487f));
                    Pos_01.Add(new Vector3(999.6509f, -602.5077f, 59.24988f));
                    Pos_01.Add(new Vector3(1010.405f, -572.106f, 60.59447f));
                    Pos_01.Add(new Vector3(976.5464f, -580.268f, 59.85033f));
                    Pos_01.Add(new Vector3(965.8971f, -609.0874f, 59.49282f));
                    Pos_01.Add(new Vector3(919.8752f, -569.8582f, 58.36637f));
                    Pos_01.Add(new Vector3(965.7161f, -542.8255f, 59.35909f));
                    Pos_01.Add(new Vector3(988.0938f, -525.8449f, 60.69068f));
                    Pos_01.Add(new Vector3(1005.954f, -511.3791f, 60.83396f));
                    Pos_01.Add(new Vector3(1056.8f, -448.1799f, 66.25742f));
                    Pos_01.Add(new Vector3(1051.081f, -470.3268f, 64.29682f));
                    Pos_01.Add(new Vector3(1046.621f, -497.4203f, 64.07932f));
                    Pos_01.Add(new Vector3(1089.776f, -484.1317f, 65.66021f));
                    Pos_01.Add(new Vector3(1097.907f, -464.9969f, 67.3194f));
                    Pos_01.Add(new Vector3(1099.318f, -438.5551f, 67.7905f));
                    Pos_01.Add(new Vector3(1100.173f, -411.3625f, 67.55515f));
                    Pos_01.Add(new Vector3(1121.068f, -396.8421f, 68.32484f));
                    Pos_01.Add(new Vector3(1014.722f, -469.2599f, 64.50301f));
                    Pos_01.Add(new Vector3(970.1812f, -502.0331f, 62.1409f));
                    Pos_01.Add(new Vector3(946.805f, -518.6298f, 60.62551f));
                    Pos_01.Add(new Vector3(924.0212f, -525.62f, 59.78107f));
                    Pos_01.Add(new Vector3(892.7018f, -540.6726f, 58.50655f));
                    Pos_01.Add(new Vector3(979.9705f, -627.5128f, 59.23589f));
                    Pos_01.Add(new Vector3(989.3026f, -738.9448f, 57.46308f));
                    Pos_01.Add(new Vector3(979.4105f, -716.0731f, 58.22066f));
                    Pos_01.Add(new Vector3(970.9582f, -701.2431f, 58.48196f));
                    Pos_01.Add(new Vector3(944.2244f, -678.2466f, 58.44977f));
                    Pos_01.Add(new Vector3(939.8877f, -663.1575f, 58.01383f));
                    Pos_01.Add(new Vector3(929.2795f, -639.2144f, 58.24234f));
                    Pos_01.Add(new Vector3(903.2495f, -615.7738f, 58.45334f));
                    Pos_01.Add(new Vector3(874.7638f, -607.1186f, 58.21776f));
                    Pos_01.Add(new Vector3(862.0755f, -582.3646f, 58.15649f));
                    Pos_01.Add(new Vector3(846.4515f, -551.504f, 57.70799f));
                    Pos_01.Add(new Vector3(850.5616f, -532.464f, 57.92542f));
                    Pos_01.Add(new Vector3(861.998f, -509.8099f, 57.32896f));
                    Pos_01.Add(new Vector3(878.6312f, -498.1406f, 58.09062f));
                    Pos_01.Add(new Vector3(901.3936f, -472.5109f, 59.01522f));
                    Pos_01.Add(new Vector3(922.1134f, -478.2256f, 61.0836f));
                    Pos_01.Add(new Vector3(943.9189f, -463.2539f, 61.39602f));
                    Pos_01.Add(new Vector3(961.065f, -458.4801f, 62.39756f));
                    Pos_01.Add(new Vector3(988.1276f, -433.536f, 63.89075f));
                    Pos_01.Add(new Vector3(1004.812f, -414.8121f, 64.94271f));
                    Pos_01.Add(new Vector3(1029.585f, -409.1599f, 65.94939f));
                    Pos_01.Add(new Vector3(1060.76f, -378.5183f, 68.23116f));

                }
                else
                {
                    Pos_01.Add(new Vector3(980.3473f, -710.9542f, 57.41397f)); fHeading.Add(308.5104f);
                    Pos_01.Add(new Vector3(951.1602f, -653.2234f, 57.62613f)); fHeading.Add(309.0907f);
                    Pos_01.Add(new Vector3(986.1522f, -578.1168f, 58.99873f)); fHeading.Add(34.09512f);
                    Pos_01.Add(new Vector3(957.2338f, -550.9439f, 59.07236f)); fHeading.Add(210.6819f);
                    Pos_01.Add(new Vector3(872.2705f, -599.6787f, 57.93815f)); fHeading.Add(314.4709f);
                    Pos_01.Add(new Vector3(918.4536f, -528.7723f, 58.93024f)); fHeading.Add(24.60192f);
                    Pos_01.Add(new Vector3(946.8775f, -510.3125f, 59.94468f)); fHeading.Add(27.72393f);
                    Pos_01.Add(new Vector3(941.4748f, -467.9566f, 60.98221f)); fHeading.Add(213.9737f);
                    Pos_01.Add(new Vector3(991.3154f, -436.6387f, 63.49977f)); fHeading.Add(292.3408f);
                    Pos_01.Add(new Vector3(1050.35f, -380.3262f, 67.58309f)); fHeading.Add(220.8241f);
                    Pos_01.Add(new Vector3(1102.536f, -418.7316f, 66.88247f)); fHeading.Add(84.60035f);
                    Pos_01.Add(new Vector3(1099.123f, -472.7676f, 66.66756f)); fHeading.Add(76.10673f);
                    Pos_01.Add(new Vector3(1053.464f, -482.5084f, 63.65071f)); fHeading.Add(258.9618f);
                    Pos_01.Add(new Vector3(1275.668f, -672.356f, 65.69302f)); fHeading.Add(273.7066f);
                    Pos_01.Add(new Vector3(1256.901f, -623.048f, 69.11968f)); fHeading.Add(296.0141f);
                    Pos_01.Add(new Vector3(1244.003f, -578.5009f, 69.06626f)); fHeading.Add(269.2307f);
                    Pos_01.Add(new Vector3(1348.324f, -603.4979f, 74.08501f)); fHeading.Add(332.9796f);
                    Pos_01.Add(new Vector3(1365.435f, -548.1692f, 74.06761f)); fHeading.Add(157.7411f);
                    Pos_01.Add(new Vector3(1313.359f, -519.7322f, 71.04205f)); fHeading.Add(161.4133f);
                    Pos_01.Add(new Vector3(1248.07f, -521.2718f, 68.71279f)); fHeading.Add(257.4296f);
                    Pos_01.Add(new Vector3(1271.378f, -451.3935f, 69.2456f)); fHeading.Add(205.39f);
                    Pos_01.Add(new Vector3(134.1088f, -60.30129f, 67.40459f)); fHeading.Add(70.68098f);
                    Pos_01.Add(new Vector3(51.97826f, -44.58509f, 69.12391f)); fHeading.Add(161.6227f);
                    Pos_01.Add(new Vector3(25.30462f, 80.70065f, 74.44212f)); fHeading.Add(272.4667f);
                    Pos_01.Add(new Vector3(-0.9546741f, 1.660976f, 70.78655f)); fHeading.Add(343.9719f);
                    Pos_01.Add(new Vector3(-150.6478f, 155.427f, 77.23077f)); fHeading.Add(160.6391f);
                    Pos_01.Add(new Vector3(-129.3235f, 209.7725f, 92.76147f)); fHeading.Add(177.2645f);
                    Pos_01.Add(new Vector3(-265.9961f, 106.5787f, 68.79312f)); fHeading.Add(359.7277f);
                    Pos_01.Add(new Vector3(-371.1536f, 106.8769f, 65.63227f)); fHeading.Add(358.1223f);
                    Pos_01.Add(new Vector3(-442.6092f, 98.64981f, 62.88636f)); fHeading.Add(356.5314f);
                    Pos_01.Add(new Vector3(-590.1307f, 194.1433f, 71.05424f)); fHeading.Add(91.45513f);
                    Pos_01.Add(new Vector3(-1105.929f, -1048.931f, 1.880021f)); fHeading.Add(209.2422f);
                    Pos_01.Add(new Vector3(-1040.828f, -1005.86f, 1.879707f)); fHeading.Add(206.78f);
                    Pos_01.Add(new Vector3(-996.2587f, -1002.092f, 1.880063f)); fHeading.Add(28.29245f);
                    Pos_01.Add(new Vector3(-955.9408f, -1083.62f, 1.8798f)); fHeading.Add(210.9636f);
                    Pos_01.Add(new Vector3(-1048.461f, -1152.236f, 1.888209f)); fHeading.Add(29.82095f);
                    Pos_01.Add(new Vector3(-1067.682f, -1146.465f, 1.888404f)); fHeading.Add(211.2667f);
                    Pos_01.Add(new Vector3(-1116.791f, -1212.745f, 2.234075f)); fHeading.Add(121.5045f);
                    Pos_01.Add(new Vector3(-1149.541f, -1145.446f, 2.576422f)); fHeading.Add(120.0697f);
                    Pos_01.Add(new Vector3(-1189.255f, -1065.888f, 1.879975f)); fHeading.Add(117.4356f);
                    Pos_01.Add(new Vector3(-1316.356f, -937.4818f, 9.460288f)); fHeading.Add(17.90471f);
                    Pos_01.Add(new Vector3(-1366.617f, -899.1229f, 12.20018f)); fHeading.Add(34.71532f);
                    Pos_01.Add(new Vector3(-1438.836f, -884.637f, 10.52211f)); fHeading.Add(155.3602f);
                    Pos_01.Add(new Vector3(-1146.281f, -910.4403f, 2.425397f)); fHeading.Add(209.4387f);
                    Pos_01.Add(new Vector3(-1081.033f, -921.4058f, 3.200046f)); fHeading.Add(30.9758f);
                    Pos_01.Add(new Vector3(-1054.054f, -906.4894f, 4.082501f)); fHeading.Add(29.95465f);
                    Pos_01.Add(new Vector3(-1038.931f, -902.286f, 3.838736f)); fHeading.Add(299.978f);
                    Pos_01.Add(new Vector3(-1022.476f, -890.4183f, 5.411024f)); fHeading.Add(31.85677f);
                    Pos_01.Add(new Vector3(-1451.42f, -368.5674f, 43.2327f)); fHeading.Add(6.027711f);
                    Pos_01.Add(new Vector3(-1564.278f, -249.5717f, 48.00818f)); fHeading.Add(233.6664f);
                    Pos_01.Add(new Vector3(-1520.583f, -369.7206f, 42.50985f)); fHeading.Add(46.59896f);
                    Pos_01.Add(new Vector3(-1717.838f, -494.1353f, 37.80541f)); fHeading.Add(192.4317f);
                    Pos_01.Add(new Vector3(-1655.704f, -379.0948f, 45.06553f)); fHeading.Add(223.2271f);
                    Pos_01.Add(new Vector3(-1677.955f, -411.3374f, 43.70475f)); fHeading.Add(229.3771f);
                    Pos_01.Add(new Vector3(-1702.202f, -447.6067f, 41.35829f)); fHeading.Add(320.8422f);
                    Pos_01.Add(new Vector3(-1686.702f, -459.3974f, 40.13326f)); fHeading.Add(321.5975f);

                    iAction = 1;

                    iEnterVeh = RandInt(1, 2);
                }

                iWeapons = 3;
            }            //Mid class
            else if (iSelect == 5)
            {
                RandomWeatherTime();

                if (BoolList(5))
                {
                    Pos_01.Add(new Vector3(1258.926f, -1761.398f, 49.67699f));
                    Pos_01.Add(new Vector3(1250.658f, -1734.747f, 52.03196f));
                    Pos_01.Add(new Vector3(1295.26f, -1739.837f, 54.27173f));
                    Pos_01.Add(new Vector3(1289.748f, -1711.345f, 55.27933f));
                    Pos_01.Add(new Vector3(1314.942f, -1732.162f, 54.70008f));
                    Pos_01.Add(new Vector3(1316.928f, -1699.868f, 57.83794f));
                    Pos_01.Add(new Vector3(1365.561f, -1720.873f, 65.63401f));
                    Pos_01.Add(new Vector3(1355.67f, -1690.747f, 60.49119f));
                    Pos_01.Add(new Vector3(1342.94f, -1579.568f, 54.0538f));
                    Pos_01.Add(new Vector3(1411.792f, -1490.745f, 60.65726f));
                    Pos_01.Add(new Vector3(1382.07f, -1544.12f, 57.10718f));
                    Pos_01.Add(new Vector3(1379.234f, -1515.886f, 58.02826f));
                    Pos_01.Add(new Vector3(1360.438f, -1555.744f, 56.34147f));
                    Pos_01.Add(new Vector3(1337.987f, -1525.484f, 54.17774f));
                    Pos_01.Add(new Vector3(1315.645f, -1526.977f, 51.80762f));
                    Pos_01.Add(new Vector3(1326.927f, -1552.963f, 54.05164f));
                    Pos_01.Add(new Vector3(1286.392f, -1603.538f, 54.82489f));
                    Pos_01.Add(new Vector3(1230.891f, -1591.095f, 53.76609f));
                    Pos_01.Add(new Vector3(1244.871f, -1626.249f, 53.28225f));
                    Pos_01.Add(new Vector3(1206.614f, -1608.26f, 50.34828f));
                    Pos_01.Add(new Vector3(1214.302f, -1643.783f, 48.64599f));
                    Pos_01.Add(new Vector3(1193.243f, -1622.892f, 45.22145f));
                    Pos_01.Add(new Vector3(1193.184f, -1656.018f, 43.02645f));  // (MyZone == "EBURO")

                    Pos_01.Add(new Vector3(297.2595f, -2097.519f, 17.66359f));
                    Pos_01.Add(new Vector3(295.5801f, -2093.154f, 17.66357f));
                    Pos_01.Add(new Vector3(293.3682f, -2087.566f, 17.66357f));
                    Pos_01.Add(new Vector3(293.0396f, -2086.144f, 17.66357f));
                    Pos_01.Add(new Vector3(289.6334f, -2077.022f, 17.66078f));
                    Pos_01.Add(new Vector3(287.9153f, -2072.455f, 17.66359f));
                    Pos_01.Add(new Vector3(279.6186f, -2042.905f, 19.76756f));
                    Pos_01.Add(new Vector3(280.6062f, -2041.752f, 19.76755f));
                    Pos_01.Add(new Vector3(287.0049f, -2034.633f, 19.76756f));
                    Pos_01.Add(new Vector3(289.5717f, -2031.132f, 19.76725f));
                    Pos_01.Add(new Vector3(313.9517f, -2040.767f, 20.93602f));
                    Pos_01.Add(new Vector3(317.11f, -2043.383f, 20.93639f));
                    Pos_01.Add(new Vector3(325.714f, -2050.058f, 20.9364f));
                    Pos_01.Add(new Vector3(334.11f, -2057.375f, 20.93613f));
                    Pos_01.Add(new Vector3(342.4112f, -2064.538f, 20.93642f));
                    Pos_01.Add(new Vector3(345.5887f, -2067.228f, 20.93641f));
                    Pos_01.Add(new Vector3(357.6005f, -2073.108f, 21.74449f));
                    Pos_01.Add(new Vector3(364.8902f, -2064.472f, 21.74449f));
                    Pos_01.Add(new Vector3(371.1835f, -2057.155f, 21.7445f));
                    Pos_01.Add(new Vector3(364.3695f, -2045.641f, 22.35371f));
                    Pos_01.Add(new Vector3(360.5106f, -2042.656f, 22.3543f));
                    Pos_01.Add(new Vector3(353.1429f, -2036.6f, 22.35431f));
                    Pos_01.Add(new Vector3(351.7538f, -2035.112f, 22.35429f));
                    Pos_01.Add(new Vector3(344.6013f, -2029.163f, 22.3543f));
                    Pos_01.Add(new Vector3(343.1128f, -2028.159f, 22.35431f));
                    Pos_01.Add(new Vector3(335.6897f, -2021.638f, 22.3543f));
                    Pos_01.Add(new Vector3(332.3005f, -2018.967f, 22.35416f));
                    Pos_01.Add(new Vector3(331.4324f, -1981.701f, 24.16728f));
                    Pos_01.Add(new Vector3(334.114f, -1978.607f, 24.16728f));
                    Pos_01.Add(new Vector3(324.9895f, -1989.26f, 24.16728f));
                    Pos_01.Add(new Vector3(383.8976f, -1994.846f, 24.23498f));
                    Pos_01.Add(new Vector3(374.5296f, -1991.047f, 24.235f));
                    Pos_01.Add(new Vector3(364f, -1987.414f, 24.23451f));
                    Pos_01.Add(new Vector3(405.9168f, -1751.467f, 29.71029f));
                    Pos_01.Add(new Vector3(430.7849f, -1741f, 29.60396f));
                    Pos_01.Add(new Vector3(430.6302f, -1725.376f, 29.60146f));
                    Pos_01.Add(new Vector3(443.4339f, -1707.119f, 29.70905f));
                    Pos_01.Add(new Vector3(490.0269f, -1714.521f, 29.70519f));
                    Pos_01.Add(new Vector3(479.9201f, -1736.504f, 29.15102f));
                    Pos_01.Add(new Vector3(472.2731f, -1774.885f, 29.07085f));
                    Pos_01.Add(new Vector3(513.6623f, -1780.66f, 28.91397f));
                    Pos_01.Add(new Vector3(495.4278f, -1823.095f, 28.86971f));
                    Pos_01.Add(new Vector3(368.6719f, -1896.409f, 25.17853f));
                    Pos_01.Add(new Vector3(385.4476f, -1881.849f, 26.03137f));
                    Pos_01.Add(new Vector3(399.448f, -1864.953f, 26.71635f));
                    Pos_01.Add(new Vector3(427.4836f, -1841.994f, 28.46345f));
                    Pos_01.Add(new Vector3(440.0391f, -1830.395f, 28.36186f));
                    Pos_01.Add(new Vector3(349.0762f, -1820.522f, 28.8941f));
                    Pos_01.Add(new Vector3(328.6295f, -1845.301f, 27.74807f));
                    Pos_01.Add(new Vector3(269.8459f, -1916.823f, 26.18237f));
                    Pos_01.Add(new Vector3(250.4847f, -1935.005f, 24.69927f));
                    Pos_01.Add(new Vector3(324.2186f, -1938.26f, 25.01898f));
                    Pos_01.Add(new Vector3(295.8637f, -1972.111f, 22.90082f));
                    Pos_01.Add(new Vector3(280.3494f, -1993.836f, 20.8038f));
                    Pos_01.Add(new Vector3(256.7441f, -2023.586f, 19.26635f));    // (MyZone == "RANCHO")

                    Pos_01.Add(new Vector3(-50.39761f, -1783.597f, 28.30082f));
                    Pos_01.Add(new Vector3(-20.35306f, -1858.548f, 25.40867f));
                    Pos_01.Add(new Vector3(-10.39145f, -1883.942f, 24.14204f));
                    Pos_01.Add(new Vector3(5.216082f, -1884.246f, 23.69726f));
                    Pos_01.Add(new Vector3(45.92031f, -1864.545f, 23.27833f));
                    Pos_01.Add(new Vector3(23.177f, -1896.414f, 22.96589f));
                    Pos_01.Add(new Vector3(54.39722f, -1873.642f, 22.80583f));
                    Pos_01.Add(new Vector3(39.40047f, -1911.863f, 21.9535f));
                    Pos_01.Add(new Vector3(76.59599f, -1948.475f, 21.17416f));
                    Pos_01.Add(new Vector3(85.55811f, -1958.879f, 21.12167f));
                    Pos_01.Add(new Vector3(114.092f, -1961.006f, 21.33425f));
                    Pos_01.Add(new Vector3(100.4846f, -1912.679f, 21.40742f));
                    Pos_01.Add(new Vector3(104.29f, -1885.105f, 24.31878f));
                    Pos_01.Add(new Vector3(130.2774f, -1853.328f, 25.23479f));
                    Pos_01.Add(new Vector3(128.0303f, -1896.44f, 23.6742f));
                    Pos_01.Add(new Vector3(171.1915f, -1871.533f, 24.40023f));
                    Pos_01.Add(new Vector3(192.1942f, -1883.464f, 25.05676f));
                    Pos_01.Add(new Vector3(179.1025f, -1924.555f, 21.37102f));
                    Pos_01.Add(new Vector3(149.0806f, -1960.494f, 19.45883f));    // (MyZone == "DAVIS")

                    Pos_01.Add(new Vector3(-212.6789f, -1669.577f, 34.4632f));
                    Pos_01.Add(new Vector3(-213.5734f, -1608.434f, 34.86931f));
                    Pos_01.Add(new Vector3(-170.9348f, -1538.064f, 35.1156f));
                    Pos_01.Add(new Vector3(-117.0381f, -1477.216f, 33.8227f));
                    Pos_01.Add(new Vector3(-158.1097f, -1680.082f, 33.83337f));
                    Pos_01.Add(new Vector3(-141.8925f, -1693.16f, 32.87245f));
                    Pos_01.Add(new Vector3(-147.9179f, -1688.423f, 32.87242f));
                    Pos_01.Add(new Vector3(-142.2503f, -1693.109f, 36.1673f));
                    Pos_01.Add(new Vector3(-147.5f, -1688.599f, 36.16715f));
                    Pos_01.Add(new Vector3(-158.2306f, -1679.633f, 36.96638f));
                    Pos_01.Add(new Vector3(-116.7299f, -1660.611f, 32.56437f));
                    Pos_01.Add(new Vector3(-80.86539f, -1612.877f, 31.48242f));
                    Pos_01.Add(new Vector3(-138.0755f, -1590.171f, 34.24369f));   // (MyZone == "CHAMH") 

                    Pos_01.Add(new Vector3(-491.3341f, -705.1888f, 29.66495f));
                    Pos_01.Add(new Vector3(-818.8256f, -575.5591f, 30.27625f));
                    Pos_01.Add(new Vector3(-1006.886f, -729.0814f, 21.52976f));
                    Pos_01.Add(new Vector3(-796.8664f, -684.7003f, 29.54898f));
                    Pos_01.Add(new Vector3(-668.2699f, -971.0567f, 22.34084f));
                    Pos_01.Add(new Vector3(-667.4276f, -1105.683f, 14.68489f));
                    Pos_01.Add(new Vector3(-699.7384f, -1032.83f, 16.10666f));
                    Pos_01.Add(new Vector3(-759.088f, -1047.608f, 13.5029f));
                    Pos_01.Add(new Vector3(-601.835f, -1127.903f, 22.32424f));
                    Pos_01.Add(new Vector3(-729.3005f, -879.8181f, 22.71092f));
                    Pos_01.Add(new Vector3(-693.7856f, -810.1913f, 24.01492f));
                    Pos_01.Add(new Vector3(-471.3071f, -865.2595f, 23.96403f));
                    Pos_01.Add(new Vector3(-598.7448f, -930.2391f, 23.86363f));
                    Pos_01.Add(new Vector3(-546.7633f, -810.2938f, 30.7459f));
                    Pos_01.Add(new Vector3(-580.7145f, -778.4678f, 25.01723f));    // MyZone == "KOREAT" 
                }
                else
                {
                    Pos_01.Add(new Vector3(-38.7114f, -1447.691f, 31.23018f)); fHeading.Add(181.1343f);
                    Pos_01.Add(new Vector3(-57.70175f, -1492.996f, 31.52412f)); fHeading.Add(138.4025f);
                    Pos_01.Add(new Vector3(-219.6123f, -1692.897f, 33.66856f)); fHeading.Add(178.4189f);
                    Pos_01.Add(new Vector3(-28.47212f, -1852.85f, 25.43836f)); fHeading.Add(318.8471f);
                    Pos_01.Add(new Vector3(9.621632f, -1834.356f, 24.49837f)); fHeading.Add(47.81367f);
                    Pos_01.Add(new Vector3(40.60149f, -1854.341f, 22.56051f)); fHeading.Add(132.9123f);
                    Pos_01.Add(new Vector3(53.74987f, -1877.572f, 22.03157f)); fHeading.Add(133.118f);
                    Pos_01.Add(new Vector3(87.4607f, -1968.682f, 20.47694f)); fHeading.Add(322.3264f);
                    Pos_01.Add(new Vector3(167.47f, -1926.777f, 20.74203f)); fHeading.Add(230.3746f);
                    Pos_01.Add(new Vector3(187.1324f, -1877.092f, 24.31138f)); fHeading.Add(156.3198f);
                    Pos_01.Add(new Vector3(163.3907f, -1866.596f, 23.78651f)); fHeading.Add(156.9318f);
                    Pos_01.Add(new Vector3(137.9566f, -1893.429f, 23.1057f)); fHeading.Add(342.2924f);
                    Pos_01.Add(new Vector3(104.8897f, -1880.365f, 23.69134f)); fHeading.Add(317.687f);
                    Pos_01.Add(new Vector3(243.6653f, -1673.326f, 29.05488f)); fHeading.Add(229.2046f);
                    Pos_01.Add(new Vector3(267.9462f, -1722.845f, 29.00331f)); fHeading.Add(48.58075f);
                    Pos_01.Add(new Vector3(224.9899f, -1708.252f, 29.01782f)); fHeading.Add(218.028f);
                    Pos_01.Add(new Vector3(281.1054f, -1980.919f, 20.91549f)); fHeading.Add(230.9107f);
                    Pos_01.Add(new Vector3(241.316f, -2030.528f, 18.03692f)); fHeading.Add(232.2638f);
                    Pos_01.Add(new Vector3(361.9613f, -1901.825f, 24.51496f)); fHeading.Add(229.1611f);
                    Pos_01.Add(new Vector3(401.7927f, -1855.425f, 26.53039f)); fHeading.Add(224.8978f);
                    Pos_01.Add(new Vector3(428.8149f, -1828.597f, 27.70844f)); fHeading.Add(221.0777f);
                    Pos_01.Add(new Vector3(1302.794f, -1707.352f, 54.83981f)); fHeading.Add(201.2906f);
                    Pos_01.Add(new Vector3(1149.551f, -1643.361f, 36.06015f)); fHeading.Add(210.5101f);
                    Pos_01.Add(new Vector3(1228.379f, -1606.012f, 51.44364f)); fHeading.Add(212.9986f);
                    Pos_01.Add(new Vector3(1352.271f, -1575.337f, 53.73643f)); fHeading.Add(215.7542f);
                    Pos_01.Add(new Vector3(1373.983f, -1524.358f, 56.62693f)); fHeading.Add(198.9957f);
                    Pos_01.Add(new Vector3(1346.941f, -1550.501f, 53.38363f)); fHeading.Add(39.08664f);

                    iAction = 1;

                    iEnterVeh = RandInt(1, 3);
                }

                iWeapons = 3;
            }            //Low class
            else if (iSelect == 6)
            {
                RandomWeatherTime();

                if (BoolList(6))
                {
                    Pos_01.Add(new Vector3(-122.6672f, -863.2216f, 33.33057f)); fHeading.Add(104.0432f);
                    Pos_01.Add(new Vector3(-209.1611f, -785.0453f, 30.45403f)); fHeading.Add(250.6104f);
                    Pos_01.Add(new Vector3(-296.5672f, -829.0057f, 32.41154f)); fHeading.Add(214.424f);
                    Pos_01.Add(new Vector3(-262.2707f, -902.109f, 32.30236f)); fHeading.Add(25.94688f);
                    Pos_01.Add(new Vector3(-270.4421f, -706.5453f, 38.26569f)); fHeading.Add(289.103f);
                    Pos_01.Add(new Vector3(-317.5008f, -609.5009f, 33.55332f)); fHeading.Add(247.4754f);
                    Pos_01.Add(new Vector3(-129.8538f, -597.3844f, 48.23175f)); fHeading.Add(222.6407f);
                    Pos_01.Add(new Vector3(-12.27154f, -676.7337f, 49.47276f)); fHeading.Add(30.79782f);
                    Pos_01.Add(new Vector3(205.6318f, -678.3058f, 43.13748f)); fHeading.Add(48.80375f);
                    Pos_01.Add(new Vector3(-175.5412f, -759.5623f, 44.22504f)); fHeading.Add(235.1201f);
                    Pos_01.Add(new Vector3(6.524668f, -933.7928f, 29.90014f)); fHeading.Add(130.7768f);
                }
                else
                {
                    int iRanLand = FindRandom(11, 1, 5);
                    if (iRanLand == 1)
                    {
                        Pos_01.Add(new Vector3(142.9556f, -418.5663f, 357.813f)); fHeading.Add(146.1803f);
                        Pos_01.Add(new Vector3(44.47088f, -588.145f, 394.3559f)); fHeading.Add(144.694f);
                        Pos_01.Add(new Vector3(-25.96486f, -697.7151f, 377.8641f)); fHeading.Add(156.5938f);
                        Pos_01.Add(new Vector3(-75.85501f, -815.7902f, 332.1805f)); fHeading.Add(235.7576f);
                        Pos_01.Add(new Vector3(-75.94235f, -818.4665f, 326.8517f)); fHeading.Add(235.0135f);
                    }
                    else if (iRanLand == 2)
                    {
                        Pos_01.Add(new Vector3(89.14077f, -349.5265f, 220.1292f)); fHeading.Add(95.45492f);
                        Pos_01.Add(new Vector3(-16.09307f, -416.3289f, 237.257f)); fHeading.Add(140.269f);
                        Pos_01.Add(new Vector3(-91.02924f, -495.4232f, 240.5292f)); fHeading.Add(172.6681f);
                        Pos_01.Add(new Vector3(-150.6743f, -586.1757f, 221.0396f)); fHeading.Add(217.9597f);
                        Pos_01.Add(new Vector3(-145.5026f, -593.9283f, 211.6755f)); fHeading.Add(208.2894f);
                    }
                    else if (iRanLand == 3)
                    {
                        Pos_01.Add(new Vector3(-1244.733f, -556.331f, 121.6263f)); fHeading.Add(73.09602f);
                        Pos_01.Add(new Vector3(-1314.872f, -510.2231f, 110.942f)); fHeading.Add(71.39652f);
                        Pos_01.Add(new Vector3(-1376.537f, -482.3608f, 103.3186f)); fHeading.Add(59.46054f);
                        Pos_01.Add(new Vector3(-1391.658f, -478.108f, 91.15266f)); fHeading.Add(92.62007f);
                    }
                    else if (iRanLand == 4)
                    {
                        Pos_01.Add(new Vector3(-1635.331f, -427.2587f, 152.3197f)); fHeading.Add(205.1928f);
                        Pos_01.Add(new Vector3(-1618.455f, -484.9288f, 142.6794f)); fHeading.Add(194.5483f);
                        Pos_01.Add(new Vector3(-1606.263f, -525.6398f, 134.5537f)); fHeading.Add(212.709f);
                        Pos_01.Add(new Vector3(-1593.082f, -555.8522f, 133.8456f)); fHeading.Add(235.4698f);
                        Pos_01.Add(new Vector3(-1581.926f, -568.9014f, 116.2295f)); fHeading.Add(258.0362f);
                    }
                    else if (iRanLand == 5)
                    {
                        Pos_01.Add(new Vector3(-1039.769f, -207.1729f, 178.472f)); fHeading.Add(248.8822f);
                        Pos_01.Add(new Vector3(-1038.105f, -237.4486f, 182.4304f)); fHeading.Add(223.7983f);
                        Pos_01.Add(new Vector3(-948.4437f, -340.3582f, 150.6296f)); fHeading.Add(232.3982f);
                        Pos_01.Add(new Vector3(-924.1201f, -365.4526f, 149.5871f)); fHeading.Add(225.095f);
                        Pos_01.Add(new Vector3(-912.637f, -378.214f, 137.8069f)); fHeading.Add(170.1538f);

                    }

                    iAction = 9;

                    RanLoc_01 = Pos_01;
                    fHeads = fHeading;
                }

                iWeapons = 2;
            }            //Buisness
            else if (iSelect == 7)
            {
                World.CurrentDayTime = TimeSpan.FromHours(12);
                World.Weather = Weather.ExtraSunny;

                Pos_01.Add(new Vector3(-1197.88f, -1568.177f, 4.049531f)); fHeading.Add(305.7955f);//BenchPress
                Pos_01.Add(new Vector3(-1253.458f, -1601.687f, 4.145141f)); fHeading.Add(217.3408f);
                Pos_01.Add(new Vector3(-1464.325f, -1063.733f, 3.817513f)); fHeading.Add(272.4313f);//pull ups
                Pos_01.Add(new Vector3(-1208.286f, -1559.48f, 4.609246f)); fHeading.Add(300.789f);
                Pos_01.Add(new Vector3(-1202.085f, -1572.774f, 4.607903f)); fHeading.Add(353.9804f);
                Pos_01.Add(new Vector3(-1259.167f, -1615.391f, 4.126909f)); fHeading.Add(303.0038f);
                Pos_01.Add(new Vector3(-1236.495f, -1574.453f, 4.145737f)); fHeading.Add(221.2573f);
                Pos_01.Add(new Vector3(-1413.208f, -1067.924f, 3.928926f)); fHeading.Add(18.29077f);
                Pos_01.Add(new Vector3(-1432.567f, -1048.669f, 4.555942f)); fHeading.Add(231.4996f);
                Pos_01.Add(new Vector3(-1208.97f, -1574.327f, 4.607889f)); fHeading.Add(121.9219f);//all else
                iAction = 5;
            }            //Body builder
            else if (iSelect == 8)
            {
                RandomWeatherTime();

                iSubSet = FindRandom(9, 1, 11);
                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(-272.6266f, 325.0637f, 93.25459f)); fHeading.Add(102.7661f);
                    Pos_01.Add(new Vector3(-281.3045f, 324.4917f, 93.26128f)); fHeading.Add(109.3759f);
                    Pos_01.Add(new Vector3(-275.9741f, 324.7222f, 93.27049f)); fHeading.Add(185.5619f);
                    Pos_01.Add(new Vector3(-274.2349f, 312.5389f, 93.25461f)); fHeading.Add(61.95487f);
                    Pos_01.Add(new Vector3(-284.3914f, 311.4577f, 93.25461f)); fHeading.Add(11.21089f);//peds
                }           //Import Ex-- West Vine wood-- Vs. Polynesian.
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(-450.9772f, -1725.333f, 18.68914f)); fHeading.Add(276.2404f);
                    Pos_01.Add(new Vector3(-449.4881f, -1724.789f, 18.68327f)); fHeading.Add(110.7676f);
                    Pos_01.Add(new Vector3(-417.3922f, -1702.755f, 19.50922f)); fHeading.Add(110.1307f);
                    Pos_01.Add(new Vector3(-469.3246f, -1701.666f, 18.65455f)); fHeading.Add(288.1841f);
                    Pos_01.Add(new Vector3(-467.9238f, -1696.069f, 18.82708f)); fHeading.Add(167.8869f); //peds
                }           //Armenian -- Rogers Salvage and Scrap in La Puerta.-- Vs Police 
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(115.3598f, -1947.014f, 20.60158f)); fHeading.Add(217.1962f);
                    Pos_01.Add(new Vector3(115.2621f, -1944.061f, 20.63267f)); fHeading.Add(322.8773f);
                    Pos_01.Add(new Vector3(116.2385f, -1942.619f, 20.60547f)); fHeading.Add(129.2276f);
                    Pos_01.Add(new Vector3(117.9724f, -1940.25f, 20.62111f)); fHeading.Add(106.1278f);
                    Pos_01.Add(new Vector3(118.3578f, -1939.102f, 20.64555f)); fHeading.Add(88.98208f); //peds
                }           //Ballas-- Davis, Vs --Families 
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(458.827f, -737.6528f, 27.35774f)); fHeading.Add(332.2838f);
                    Pos_01.Add(new Vector3(463.1091f, -739.5256f, 27.36115f)); fHeading.Add(167.9439f);
                    Pos_01.Add(new Vector3(462.527f, -742.2394f, 27.3605f)); fHeading.Add(21.53196f);
                    Pos_01.Add(new Vector3(461.8431f, -734.8542f, 27.35998f)); fHeading.Add(132.3374f);
                    Pos_01.Add(new Vector3(466.5947f, -730.8536f, 27.36218f)); fHeading.Add(101.3915f);//peds
                }           //Chinese textile city, Vs-- korean
                else if (iSubSet == 5)
                {
                    Pos_01.Add(new Vector3(-225.4482f, -1490.504f, 31.45079f)); fHeading.Add(310.6292f);
                    Pos_01.Add(new Vector3(-222.5614f, -1488.412f, 31.2943f)); fHeading.Add(228.3047f);
                    Pos_01.Add(new Vector3(-221.2482f, -1488.211f, 31.29151f)); fHeading.Add(102.181f);
                    Pos_01.Add(new Vector3(-221.4105f, -1490.208f, 31.28293f)); fHeading.Add(17.52296f);
                    Pos_01.Add(new Vector3(-223.3837f, -1490.498f, 31.28734f)); fHeading.Add(336.8165f);//peds
                }           //Families --Strawberry--Chamberlain Hills, Vs  Ballas
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(-742.5094f, -1041.155f, 12.51869f)); fHeading.Add(12.97545f);
                    Pos_01.Add(new Vector3(-739.5043f, -1040.927f, 12.5031f)); fHeading.Add(68.58642f);
                    Pos_01.Add(new Vector3(-741.374f, -1040.158f, 12.54656f)); fHeading.Add(143.1764f);
                    Pos_01.Add(new Vector3(-743.769f, -1047.43f, 12.28089f)); fHeading.Add(341.5395f);
                    Pos_01.Add(new Vector3(-744.7137f, -1045.582f, 12.3123f)); fHeading.Add(312.4333f); //peds
                }            //Korean --K-town, Vs Chinesse
                else if (iSubSet == 7)
                {
                    Pos_01.Add(new Vector3(333.0477f, -2041.747f, 20.9505f)); fHeading.Add(78.31051f);
                    Pos_01.Add(new Vector3(335.6685f, -2038.63f, 21.16848f)); fHeading.Add(175.0418f);
                    Pos_01.Add(new Vector3(337.3491f, -2039.961f, 21.20797f)); fHeading.Add(143.0706f);
                    Pos_01.Add(new Vector3(337.0323f, -2041.932f, 21.12964f)); fHeading.Add(29.95985f);
                    Pos_01.Add(new Vector3(334.4699f, -2041.716f, 21.02297f)); fHeading.Add(251.7424f); //peds
                }           //Mexican --Rancho--Central Cypress Flats, Vs Salvadoran
                else if (iSubSet == 8)
                {
                    Pos_01.Add(new Vector3(-750.9026f, 5539.973f, 33.48567f)); fHeading.Add(47.66533f);
                    Pos_01.Add(new Vector3(-753.6173f, 5539.024f, 33.48567f)); fHeading.Add(354.5756f);
                    Pos_01.Add(new Vector3(-755.5646f, 5540.3f, 33.48567f)); fHeading.Add(315.5447f);
                    Pos_01.Add(new Vector3(-753.6513f, 5542.839f, 33.48567f)); fHeading.Add(170.8908f);
                    Pos_01.Add(new Vector3(-750.5474f, 5542.514f, 33.48567f)); fHeading.Add(125.0001f);//peds
                }           //Polynesian -- ? -- Lost
                else if (iSubSet == 9)
                {
                    Pos_01.Add(new Vector3(1161.041f, -1646.738f, 36.91954f)); fHeading.Add(48.9831f);
                    Pos_01.Add(new Vector3(1160.423f, -1644.621f, 36.92954f)); fHeading.Add(161.1805f);
                    Pos_01.Add(new Vector3(1158.195f, -1645.382f, 36.93469f)); fHeading.Add(227.3338f);
                    Pos_01.Add(new Vector3(1158.133f, -1647.429f, 36.91374f)); fHeading.Add(299.3054f);
                    Pos_01.Add(new Vector3(1159.598f, -1648.531f, 36.91959f)); fHeading.Add(17.60314f);//peds
                }           //"Salvadoran --El Burro Heights--Vespucci Beach(night)--East Vinewood Drain Canal, Vs Mexican
                else if (iSubSet == 10)
                {
                    Pos_01.Add(new Vector3(975.9936f, -126.8484f, 74.16551f)); fHeading.Add(348.0559f);
                    Pos_01.Add(new Vector3(977.2745f, -124.7848f, 74.1376f)); fHeading.Add(214.7823f);
                    Pos_01.Add(new Vector3(963.3976f, -123.7268f, 74.35315f)); fHeading.Add(338.3762f);
                    Pos_01.Add(new Vector3(968.5342f, -118.6646f, 74.35315f)); fHeading.Add(121.6418f);
                    Pos_01.Add(new Vector3(974.248f, -113.7502f, 74.35315f)); fHeading.Add(90.07847f); //peds
                }           //Lost ... Vs Impex
                else if (iSubSet == 11)
                {
                    Pos_01.Add(new Vector3(83.97136f, 260.0858f, 108.9136f)); fHeading.Add(154.9512f);
                    Pos_01.Add(new Vector3(1581.418f, 6453.026f, 25.31714f)); fHeading.Add(152.6169f);
                    Pos_01.Add(new Vector3(-1189.455f, -877.1514f, 13.6739f)); fHeading.Add(32.68035f);
                    Pos_01.Add(new Vector3(-1550.502f, -439.1086f, 40.51901f)); fHeading.Add(222.9146f);
                    Pos_01.Add(new Vector3(-593.3647f, -863.3263f, 25.92446f)); fHeading.Add(17.25182f);
                    Pos_01.Add(new Vector3(-1175.367f, -1267.867f, 6.164357f)); fHeading.Add(135.6286f);
                    Pos_01.Add(new Vector3(-856.694f, -1140.941f, 6.942525f)); fHeading.Add(218.6946f);
                    Pos_01.Add(new Vector3(-136.9821f, -260.9609f, 42.97683f)); fHeading.Add(243.6652f);
                    Pos_01.Add(new Vector3(1137.357f, -960.7468f, 47.58101f)); fHeading.Add(329.7662f);
                    Pos_01.Add(new Vector3(104.028f, -1421.119f, 29.30048f)); fHeading.Add(301.8356f);
                    Pos_01.Add(new Vector3(-189.5329f, -1430.544f, 31.51664f)); fHeading.Add(59.90533f);
                    Pos_01.Add(new Vector3(3.255534f, -1605.107f, 29.27947f)); fHeading.Add(64.94491f);
                    Pos_01.Add(new Vector3(281.5654f, -1515.604f, 29.29159f)); fHeading.Add(242.0782f);
                }           //Street Punk-- Vs Old Ladys

                iAction = 6;

                iWeapons = 5;
            }            //GangStars             
            else if (iSelect == 9)
            {
                RandomWeatherTime();

                Pos_01.Add(new Vector3(-673.7844f, 76.16772f, 69.68565f)); fHeading.Add(267.2886f);
                Pos_01.Add(new Vector3(-719.2163f, 43.45778f, 65.19431f)); fHeading.Add(177.8458f);
                Pos_01.Add(new Vector3(-708.9506f, 70.23295f, 69.68565f)); fHeading.Add(154.9646f);
                Pos_01.Add(new Vector3(-698.1004f, 46.26298f, 44.03382f)); fHeading.Add(217.7002f);
                Pos_01.Add(new Vector3(-672.0215f, 88.88709f, 55.85543f)); fHeading.Add(210.2695f);
            }            //Epslon
            else if (iSelect == 10)
            {
                RandomWeatherTime();

                int iPosX = FindRandom(3, 1, 6);
                int iSelectmDrops = FindRandom(4, 1, 5);

                if (iPosX == 1)
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(228.6289f, -1394.52f, 30.494f));
                        Pos_01.Add(new Vector3(252.5324f, -1400.599f, 30.53424f));
                        Pos_01.Add(new Vector3(273.3281f, -1378.727f, 31.95101f));
                        Pos_01.Add(new Vector3(273.2798f, -1359.458f, 31.93511f));
                        Pos_01.Add(new Vector3(250.2143f, -1339.669f, 31.92071f));
                        Pos_01.Add(new Vector3(235.2781f, -1346.481f, 30.5051f));
                        Pos_01.Add(new Vector3(219.2509f, -1365.954f, 30.56017f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(-227.1508f, -2023.395f, 27.75543f));
                        Pos_01.Add(new Vector3(-222.3802f, -2007.24f, 27.75543f));
                        Pos_01.Add(new Vector3(-219.4253f, -1989.297f, 27.75542f));
                        Pos_01.Add(new Vector3(-221.2715f, -1971.702f, 27.75571f));
                        Pos_01.Add(new Vector3(-224.2942f, -1960.297f, 27.75689f));
                        Pos_01.Add(new Vector3(-240.3955f, -1966.939f, 29.94605f));
                        Pos_01.Add(new Vector3(-239.069f, -1973.878f, 29.94605f));
                        Pos_01.Add(new Vector3(-237.4634f, -1992.5f, 29.94605f));
                        Pos_01.Add(new Vector3(-240.9862f, -2009.94f, 29.94605f));
                        Pos_01.Add(new Vector3(-249.9569f, -2026.076f, 29.94605f));
                        Pos_01.Add(new Vector3(-263.3784f, -2040.735f, 29.94605f));
                        Pos_01.Add(new Vector3(-277.9292f, -2048.336f, 29.94605f));
                        Pos_01.Add(new Vector3(-273.3261f, -2064.927f, 27.75543f));
                        Pos_01.Add(new Vector3(-246.0456f, -2048.949f, 27.75543f));
                        Pos_01.Add(new Vector3(-235.4299f, -2037.349f, 27.75543f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(-924.767f, -2571.403f, 13.97616f));
                        Pos_01.Add(new Vector3(-943.3739f, -2565.557f, 13.93645f));
                        Pos_01.Add(new Vector3(-961.3f, -2544.967f, 13.98062f));
                        Pos_01.Add(new Vector3(-967.3834f, -2523.3f, 13.98103f));
                        Pos_01.Add(new Vector3(-965.3172f, -2502.885f, 13.98098f));
                        Pos_01.Add(new Vector3(-960.5615f, -2492.263f, 13.98057f));
                        Pos_01.Add(new Vector3(-947.3313f, -2478.542f, 13.9807f));
                        Pos_01.Add(new Vector3(-932.3168f, -2470.56f, 13.9807f));
                        Pos_01.Add(new Vector3(-913.9728f, -2467.62f, 13.98073f));
                        Pos_01.Add(new Vector3(-889.0792f, -2472.986f, 13.98049f));
                        Pos_01.Add(new Vector3(-872.939f, -2489.196f, 13.98072f));
                        Pos_01.Add(new Vector3(-866.3092f, -2501.952f, 13.98075f));
                        Pos_01.Add(new Vector3(-863.3466f, -2512.478f, 13.98059f));
                        Pos_01.Add(new Vector3(-863.6301f, -2528.947f, 13.98072f));
                        Pos_01.Add(new Vector3(-869.4406f, -2546.69f, 13.97835f));
                        Pos_01.Add(new Vector3(-884.2811f, -2561.323f, 13.98074f));
                        Pos_01.Add(new Vector3(-896.1907f, -2568.416f, 13.98074f));
                        Pos_01.Add(new Vector3(-903.6213f, -2570.235f, 13.98074f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(-287.7649f, -1638.534f, 31.84882f));
                        Pos_01.Add(new Vector3(-298.8279f, -1656.257f, 31.84881f));
                        Pos_01.Add(new Vector3(-317.5655f, -1644.264f, 31.85344f));
                        Pos_01.Add(new Vector3(-303.9065f, -1622.695f, 31.84882f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(1476.682f, -1984.691f, 70.69158f));
                        Pos_01.Add(new Vector3(1453.445f, -1972.131f, 70.44451f));
                        Pos_01.Add(new Vector3(1434.379f, -1986.595f, 65.75795f));
                        Pos_01.Add(new Vector3(1423.388f, -2007.92f, 61.90174f));
                        Pos_01.Add(new Vector3(1433.237f, -2031.683f, 57.47531f));
                        Pos_01.Add(new Vector3(1469.974f, -2042.295f, 57.02632f));
                        Pos_01.Add(new Vector3(1478.932f, -2002.187f, 68.38514f));
                    }
                }
                else if (iPosX == 2)
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(129.9129f, -988.9407f, 29.32248f));
                        Pos_01.Add(new Vector3(169.9703f, -880.6992f, 30.55882f));
                        Pos_01.Add(new Vector3(174.1833f, -881.5703f, 30.89416f));
                        Pos_01.Add(new Vector3(186.1561f, -849.1542f, 31.16665f));
                        Pos_01.Add(new Vector3(193.5296f, -847.7554f, 30.91245f));
                        Pos_01.Add(new Vector3(263.498f, -872.455f, 29.17216f));
                        Pos_01.Add(new Vector3(211.1392f, -1018.212f, 29.30549f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(356.3345f, 160.7301f, 103.0043f));
                        Pos_01.Add(new Vector3(222.6689f, 208.8755f, 105.5123f));
                        Pos_01.Add(new Vector3(266.2624f, 328.2007f, 105.5289f));
                        Pos_01.Add(new Vector3(339.1058f, 311.9287f, 104.5361f));
                        Pos_01.Add(new Vector3(404.6719f, 292.2426f, 102.9655f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(-68.89455f, -402.1517f, 37.29737f));
                        Pos_01.Add(new Vector3(-103.1039f, -389.6021f, 36.63163f));
                        Pos_01.Add(new Vector3(-108.889f, -409.1098f, 35.77497f));
                        Pos_01.Add(new Vector3(-127.2451f, -411.5541f, 34.58294f));
                        Pos_01.Add(new Vector3(-139.3882f, -421.2568f, 33.74562f));
                        Pos_01.Add(new Vector3(-148.7219f, -435.5255f, 33.47985f));
                        Pos_01.Add(new Vector3(-153.0547f, -451.4209f, 33.79173f));
                        Pos_01.Add(new Vector3(-145.8188f, -464.7188f, 33.17519f));
                        Pos_01.Add(new Vector3(-132.132f, -472.3099f, 33.07674f));
                        Pos_01.Add(new Vector3(-121.9619f, -474.8518f, 33.34896f));
                        Pos_01.Add(new Vector3(-89.17182f, -474.3718f, 34.96899f));
                        Pos_01.Add(new Vector3(-77.55576f, -466.7515f, 36.39326f));
                        Pos_01.Add(new Vector3(-67.24388f, -449.3546f, 38.11158f));
                        Pos_01.Add(new Vector3(-64.59761f, -437.8882f, 38.43552f));
                        Pos_01.Add(new Vector3(-64.19228f, -419.8323f, 38.09665f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(-736.3101f, 90.46006f, 55.58132f));
                        Pos_01.Add(new Vector3(-737.0633f, 69.59921f, 54.30896f));
                        Pos_01.Add(new Vector3(-734.0124f, 47.01559f, 47.47584f));
                        Pos_01.Add(new Vector3(-728.4005f, 29.74567f, 42.26787f));
                        Pos_01.Add(new Vector3(-703.6444f, 36.59576f, 43.22058f));
                        Pos_01.Add(new Vector3(-681.6513f, 46.41314f, 43.09964f));
                        Pos_01.Add(new Vector3(-661.1816f, 46.04203f, 41.12265f));
                        Pos_01.Add(new Vector3(-658.776f, 85.53405f, 52.46266f));
                        Pos_01.Add(new Vector3(-662.4477f, 103.3301f, 56.80659f));
                        Pos_01.Add(new Vector3(-662.0488f, 119.3575f, 57.01698f));
                        Pos_01.Add(new Vector3(-675.6852f, 115.9964f, 56.75283f));
                        Pos_01.Add(new Vector3(-709.5087f, 98.95238f, 56.07108f));
                        Pos_01.Add(new Vector3(-718.9947f, 95.15092f, 55.8739f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-1765.645f, -1149.159f, 13.07916f));
                        Pos_01.Add(new Vector3(-1837.407f, -1227.053f, 13.01728f));
                        Pos_01.Add(new Vector3(-1869.622f, -1210.43f, 13.01711f));
                        Pos_01.Add(new Vector3(-1831.916f, -1162.537f, 13.01727f));
                        Pos_01.Add(new Vector3(-1806.807f, -1181.257f, 13.01744f));
                        Pos_01.Add(new Vector3(-1797.633f, -1177.67f, 13.01751f));
                        Pos_01.Add(new Vector3(-1786.751f, -1169.576f, 13.01768f));
                        Pos_01.Add(new Vector3(-1660.035f, -1023.637f, 13.01778f));
                        Pos_01.Add(new Vector3(-1652.489f, -1014.507f, 13.01739f));
                        Pos_01.Add(new Vector3(-1659.945f, -1009.417f, 13.01739f));
                        Pos_01.Add(new Vector3(-1709.898f, -1070.201f, 13.01735f));
                        Pos_01.Add(new Vector3(-1709.359f, -1083.783f, 13.10089f));
                    }
                }
                else if (iPosX == 3)
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(-2891.325f, -8.690169f, 7.963134f));
                        Pos_01.Add(new Vector3(-2910.282f, -37.03131f, 3.024998f));
                        Pos_01.Add(new Vector3(-2999.717f, 0.8205602f, 4.733732f));
                        Pos_01.Add(new Vector3(-2997.566f, 30.52503f, 7.300454f));
                        Pos_01.Add(new Vector3(-2995.444f, 36.81783f, 7.95881f));
                        Pos_01.Add(new Vector3(-2992.152f, 35.16978f, 8.5967f));
                        Pos_01.Add(new Vector3(-2987.468f, 42.83352f, 11.6085f));
                        Pos_01.Add(new Vector3(-2939.735f, 20.68083f, 11.60792f));
                        Pos_01.Add(new Vector3(-2943.227f, 12.65156f, 11.60476f));
                        Pos_01.Add(new Vector3(-2918.954f, 1.69491f, 11.60532f));
                        Pos_01.Add(new Vector3(-2891.381f, -6.391256f, 11.60316f));
                        Pos_01.Add(new Vector3(-2888.387f, 2.114674f, 11.608f));
                        Pos_01.Add(new Vector3(-2886.561f, 0.7008348f, 11.608f));
                        Pos_01.Add(new Vector3(-2888.892f, -7.902122f, 7.959469f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(-1486.228f, 875.5378f, 182.6471f));
                        Pos_01.Add(new Vector3(-1478.33f, 831.1494f, 181.7178f));
                        Pos_01.Add(new Vector3(-1514.694f, 814.3276f, 181.9242f));
                        Pos_01.Add(new Vector3(-1521.786f, 816.0013f, 181.8818f));
                        Pos_01.Add(new Vector3(-1532.458f, 826.3513f, 181.4863f));
                        Pos_01.Add(new Vector3(-1543.011f, 817.2687f, 182.2451f));
                        Pos_01.Add(new Vector3(-1549.201f, 782.2504f, 188.5506f));
                        Pos_01.Add(new Vector3(-1558.725f, 777.4117f, 189.1925f));
                        Pos_01.Add(new Vector3(-1584.688f, 765.293f, 189.1942f));
                        Pos_01.Add(new Vector3(-1592.872f, 784.2383f, 189.194f));
                        Pos_01.Add(new Vector3(-1578.12f, 790.5488f, 189.1929f));
                        Pos_01.Add(new Vector3(-1585.357f, 804.7038f, 185.9943f));
                        Pos_01.Add(new Vector3(-1575.385f, 809.5252f, 185.9944f));
                        Pos_01.Add(new Vector3(-1578.809f, 818.0173f, 185.9939f));
                        Pos_01.Add(new Vector3(-1534.582f, 848.1694f, 181.7705f));
                        Pos_01.Add(new Vector3(-1521.602f, 854.8638f, 181.5947f));
                        Pos_01.Add(new Vector3(-1496.966f, 870.4911f, 181.9422f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(-1893.8f, 1974.631f, 143.1386f));
                        Pos_01.Add(new Vector3(-1929.31f, 1969.096f, 148.8142f));
                        Pos_01.Add(new Vector3(-1966.108f, 1968.237f, 154.9804f));
                        Pos_01.Add(new Vector3(-1982.965f, 1961.467f, 160.8532f));
                        Pos_01.Add(new Vector3(-1987.9f, 1950.067f, 167.1869f));
                        Pos_01.Add(new Vector3(-1982.987f, 1941.103f, 171.1532f));
                        Pos_01.Add(new Vector3(-1945.131f, 1917.294f, 173.789f));
                        Pos_01.Add(new Vector3(-1938.31f, 1890.808f, 179.907f));
                        Pos_01.Add(new Vector3(-1954.827f, 1842.859f, 180.2473f));
                        Pos_01.Add(new Vector3(-1957.488f, 1830.848f, 178.8064f));
                        Pos_01.Add(new Vector3(-1945.764f, 1820.129f, 172.0853f));
                        Pos_01.Add(new Vector3(-1937.965f, 1823.133f, 170.6982f));
                        Pos_01.Add(new Vector3(-1920.848f, 1840.997f, 166.5749f));
                        Pos_01.Add(new Vector3(-1899.503f, 1851.748f, 160.8903f));
                        Pos_01.Add(new Vector3(-1879.112f, 1865.361f, 156.9021f));
                        Pos_01.Add(new Vector3(-1841.115f, 1891.895f, 146.2764f));
                        Pos_01.Add(new Vector3(-1836.474f, 1901.321f, 145.8237f));
                        Pos_01.Add(new Vector3(-1839.368f, 1912.564f, 147.3022f));
                        Pos_01.Add(new Vector3(-1853.069f, 1930.572f, 150.2391f));
                        Pos_01.Add(new Vector3(-1878.708f, 1956.751f, 145.8794f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(-319.6601f, 2786.814f, 59.43f));
                        Pos_01.Add(new Vector3(-337.5543f, 2800.789f, 58.15808f));
                        Pos_01.Add(new Vector3(-338.9051f, 2804.992f, 58.13386f));
                        Pos_01.Add(new Vector3(-327.3314f, 2822.454f, 58.19631f));
                        Pos_01.Add(new Vector3(-317.4219f, 2826.94f, 58.47928f));
                        Pos_01.Add(new Vector3(-312.7925f, 2831.25f, 58.25769f));
                        Pos_01.Add(new Vector3(-310.0566f, 2831.212f, 58.38048f));
                        Pos_01.Add(new Vector3(-297.7459f, 2823.444f, 59.15673f));
                        Pos_01.Add(new Vector3(-299.6138f, 2818.963f, 59.19112f));
                        Pos_01.Add(new Vector3(-295.6808f, 2811.254f, 58.98975f));
                        Pos_01.Add(new Vector3(-308.6064f, 2790.959f, 59.41709f));
                        Pos_01.Add(new Vector3(-316.4038f, 2787.014f, 59.56699f));
                        Pos_01.Add(new Vector3(-323.0881f, 2789.975f, 59.20899f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-2768.271f, 2695.774f, 1.370201f));
                        Pos_01.Add(new Vector3(-2755.266f, 2703.515f, 1.416718f));
                        Pos_01.Add(new Vector3(-2735.553f, 2738.595f, 1.462122f));
                        Pos_01.Add(new Vector3(-2730.177f, 2799.426f, 1.757612f));
                        Pos_01.Add(new Vector3(-2717.147f, 2824.657f, 1.186048f));
                        Pos_01.Add(new Vector3(-2730.011f, 2855.175f, 1.459975f));
                        Pos_01.Add(new Vector3(-2720.936f, 2897.158f, 1.232428f));
                        Pos_01.Add(new Vector3(-2723.055f, 2915.156f, 1.214248f));
                        Pos_01.Add(new Vector3(-2717.156f, 2934.323f, 1.675791f));
                        Pos_01.Add(new Vector3(-2736.917f, 2953.923f, 2.776649f));
                        Pos_01.Add(new Vector3(-2746.004f, 2954.125f, 2.354859f));
                        Pos_01.Add(new Vector3(-2751.835f, 2943.838f, 2.075438f));
                        Pos_01.Add(new Vector3(-2752.229f, 2914.945f, 1.281913f));
                        Pos_01.Add(new Vector3(-2752.62f, 2887.3f, 1.572614f));
                        Pos_01.Add(new Vector3(-2756.117f, 2854.283f, 1.468493f));
                        Pos_01.Add(new Vector3(-2764.645f, 2779.508f, 2.047434f));
                        Pos_01.Add(new Vector3(-2769.536f, 2743.653f, 2.138904f));
                        Pos_01.Add(new Vector3(-2776.014f, 2720.484f, 2.238141f));
                    }
                }
                else if (iPosX == 4)
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(1061.091f, -558.9828f, 59.28479f));
                        Pos_01.Add(new Vector3(1066.203f, -597.2649f, 56.83318f));
                        Pos_01.Add(new Vector3(1062.106f, -610.6114f, 56.76826f));
                        Pos_01.Add(new Vector3(1022.904f, -655.5869f, 58.68858f));
                        Pos_01.Add(new Vector3(1020.39f, -657.876f, 58.61199f));
                        Pos_01.Add(new Vector3(1020.476f, -698.0944f, 56.81086f));
                        Pos_01.Add(new Vector3(1056.699f, -719.1822f, 56.815f));
                        Pos_01.Add(new Vector3(1088.558f, -738.0333f, 56.76314f));
                        Pos_01.Add(new Vector3(1132.372f, -738.0198f, 56.74362f));
                        Pos_01.Add(new Vector3(1143.484f, -710.3257f, 56.80364f));
                        Pos_01.Add(new Vector3(1127.766f, -660.5972f, 56.68017f));
                        Pos_01.Add(new Vector3(1126.506f, -644.8978f, 56.77164f));
                        Pos_01.Add(new Vector3(1119.372f, -633.5688f, 56.78326f));
                        Pos_01.Add(new Vector3(1118.719f, -612.4344f, 56.74827f));
                        Pos_01.Add(new Vector3(1124.979f, -604.9899f, 56.74682f));
                        Pos_01.Add(new Vector3(1139.324f, -591.7932f, 56.75398f));
                        Pos_01.Add(new Vector3(1142.248f, -582.8869f, 56.75351f));
                        Pos_01.Add(new Vector3(1133.203f, -563.3502f, 56.99999f));
                        Pos_01.Add(new Vector3(1125.851f, -551.4424f, 56.93082f));
                        Pos_01.Add(new Vector3(1105.572f, -540.5275f, 57.76503f));
                        Pos_01.Add(new Vector3(1105.599f, -540.5577f, 57.76052f));
                        Pos_01.Add(new Vector3(1100.637f, -540.5255f, 57.95548f));
                        Pos_01.Add(new Vector3(1100.362f, -527.494f, 63.07243f));
                        Pos_01.Add(new Vector3(1073.51f, -530.7902f, 62.03668f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(1163.911f, 280.2455f, 82.19042f));
                        Pos_01.Add(new Vector3(991.5728f, -11.44712f, 81.85177f));
                        Pos_01.Add(new Vector3(993.7879f, -40.10574f, 81.92294f));
                        Pos_01.Add(new Vector3(1011.639f, -65.61469f, 82.19008f));
                        Pos_01.Add(new Vector3(1038.523f, -82.89301f, 82.19008f));
                        Pos_01.Add(new Vector3(1072.831f, -82.7739f, 82.16786f));
                        Pos_01.Add(new Vector3(1095.682f, -69.53146f, 82.08484f));
                        Pos_01.Add(new Vector3(1265.938f, 178.9096f, 81.98807f));
                        Pos_01.Add(new Vector3(1273.632f, 195.978f, 81.91003f));
                        Pos_01.Add(new Vector3(1274.658f, 222.6223f, 81.90385f));
                        Pos_01.Add(new Vector3(1261.318f, 257.1254f, 82.07339f));
                        Pos_01.Add(new Vector3(1235.155f, 278.5591f, 82.08091f));
                        Pos_01.Add(new Vector3(1209.412f, 284.0538f, 82.0095f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(2493.767f, -317.9808f, 92.99265f));
                        Pos_01.Add(new Vector3(2465.75f, -331.269f, 92.99268f));
                        Pos_01.Add(new Vector3(2445.703f, -353.545f, 92.98891f));
                        Pos_01.Add(new Vector3(2446.853f, -417.4889f, 92.99274f));
                        Pos_01.Add(new Vector3(2474.773f, -444.7306f, 92.99303f));
                        Pos_01.Add(new Vector3(2480.923f, -437.5063f, 92.99287f));
                        Pos_01.Add(new Vector3(2479.751f, -420.7701f, 93.73516f));
                        Pos_01.Add(new Vector3(2481.842f, -406.8932f, 93.73528f));
                        Pos_01.Add(new Vector3(2494.202f, -390.2369f, 94.11994f));
                        Pos_01.Add(new Vector3(2493.491f, -374.688f, 94.11996f));
                        Pos_01.Add(new Vector3(2481.127f, -358.7106f, 93.73526f));
                        Pos_01.Add(new Vector3(2481.344f, -341.2011f, 93.00871f));
                        Pos_01.Add(new Vector3(2480.642f, -324.369f, 92.99266f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(1443.998f, 1032.925f, 114.2406f));
                        Pos_01.Add(new Vector3(1507.861f, 1033.247f, 114.2185f));
                        Pos_01.Add(new Vector3(1514.412f, 1043.134f, 114.2258f));
                        Pos_01.Add(new Vector3(1514.912f, 1101.076f, 114.2287f));
                        Pos_01.Add(new Vector3(1502.632f, 1178.213f, 114.2156f));
                        Pos_01.Add(new Vector3(1484.8f, 1185.216f, 114.1505f));
                        Pos_01.Add(new Vector3(1434.625f, 1186.282f, 114.1913f));
                        Pos_01.Add(new Vector3(1433.847f, 1092.753f, 114.2267f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(2692.736f, 1705.75f, 24.68079f));
                        Pos_01.Add(new Vector3(2806.105f, 1705.584f, 24.68113f));
                        Pos_01.Add(new Vector3(2818.727f, 1704.424f, 24.69106f));
                        Pos_01.Add(new Vector3(2823.846f, 1699.423f, 24.71452f));
                        Pos_01.Add(new Vector3(2824.438f, 1696.413f, 24.69556f));
                        Pos_01.Add(new Vector3(2824.696f, 1647.154f, 24.64242f));
                        Pos_01.Add(new Vector3(2782.65f, 1647.183f, 24.60208f));
                        Pos_01.Add(new Vector3(2780.294f, 1653.693f, 24.53028f));
                        Pos_01.Add(new Vector3(2711.461f, 1654.09f, 24.53372f));
                        Pos_01.Add(new Vector3(2711.587f, 1647.229f, 24.60396f));
                        Pos_01.Add(new Vector3(2698.269f, 1646.656f, 24.60472f));
                        Pos_01.Add(new Vector3(2695.426f, 1649.674f, 24.61012f));
                        Pos_01.Add(new Vector3(2694.013f, 1653.814f, 24.62069f));
                        Pos_01.Add(new Vector3(2694.363f, 1691.255f, 24.69635f));
                        Pos_01.Add(new Vector3(2696.989f, 1695.163f, 24.7006f));
                        Pos_01.Add(new Vector3(2702.095f, 1696.548f, 24.66678f));
                    }
                }
                else if (iPosX == 5)
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(1623.121f, 3228.294f, 40.41154f));
                        Pos_01.Add(new Vector3(1548.318f, 3147.528f, 40.53161f));
                        Pos_01.Add(new Vector3(1099.019f, 3015.776f, 40.56151f));
                        Pos_01.Add(new Vector3(1074.616f, 3035.108f, 41.24891f));
                        Pos_01.Add(new Vector3(1085.017f, 3076.249f, 40.42923f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(1090.78f, 3566.191f, 34.09589f));
                        Pos_01.Add(new Vector3(1091.477f, 3610.838f, 33.05823f));
                        Pos_01.Add(new Vector3(1047.076f, 3610.903f, 33.11738f));
                        Pos_01.Add(new Vector3(1012.615f, 3597.394f, 33.21322f));
                        Pos_01.Add(new Vector3(1017.906f, 3568.242f, 33.92956f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(73.27388f, 3633.642f, 39.70792f));
                        Pos_01.Add(new Vector3(27.01976f, 3700.822f, 39.70713f));
                        Pos_01.Add(new Vector3(28.15174f, 3713.856f, 39.71289f));
                        Pos_01.Add(new Vector3(35.53751f, 3726.467f, 39.65743f));
                        Pos_01.Add(new Vector3(73.20634f, 3740.686f, 39.71008f));
                        Pos_01.Add(new Vector3(83.90422f, 3739.935f, 39.69468f));
                        Pos_01.Add(new Vector3(99.68319f, 3726.861f, 39.67576f));
                        Pos_01.Add(new Vector3(102.9181f, 3719.429f, 39.70041f));
                        Pos_01.Add(new Vector3(82.71038f, 3679.274f, 39.71919f));
                        Pos_01.Add(new Vector3(81.40222f, 3636.785f, 39.69534f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(1041.883f, 2191.695f, 44.96709f));
                        Pos_01.Add(new Vector3(1066.888f, 2213.252f, 46.80863f));
                        Pos_01.Add(new Vector3(1031.368f, 2213.759f, 51.05772f));
                        Pos_01.Add(new Vector3(989.4823f, 2218.621f, 47.55013f));
                        Pos_01.Add(new Vector3(997.8649f, 2204.891f, 46.05443f));
                        Pos_01.Add(new Vector3(1021.423f, 2190.472f, 45.28568f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(2440.191f, 4837.629f, 36.53263f));
                        Pos_01.Add(new Vector3(2428.567f, 4921.247f, 43.66103f));
                        Pos_01.Add(new Vector3(2472.179f, 4965.375f, 45.16649f));
                        Pos_01.Add(new Vector3(2480.896f, 4990.179f, 46.22219f));
                        Pos_01.Add(new Vector3(2478.137f, 5002.943f, 45.85592f));
                        Pos_01.Add(new Vector3(2466.199f, 5016.405f, 45.56878f));
                        Pos_01.Add(new Vector3(2416.468f, 4969.382f, 46.13856f));
                        Pos_01.Add(new Vector3(2386.791f, 4938.182f, 42.70732f));
                        Pos_01.Add(new Vector3(2363.594f, 4912.43f, 41.9899f));
                        Pos_01.Add(new Vector3(2373.377f, 4895.569f, 41.92224f));
                        Pos_01.Add(new Vector3(2394.373f, 4874.57f, 40.84945f));
                    }
                }
                else
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(234.6885f, 6418.486f, 30.96218f));
                        Pos_01.Add(new Vector3(248.8196f, 6415.337f, 31.88116f));
                        Pos_01.Add(new Vector3(269.739f, 6414.965f, 32.11745f));
                        Pos_01.Add(new Vector3(288.8002f, 6420.939f, 31.35575f));
                        Pos_01.Add(new Vector3(298.797f, 6432.084f, 31.80929f));
                        Pos_01.Add(new Vector3(301.9339f, 6444.203f, 32.29673f));
                        Pos_01.Add(new Vector3(306.1744f, 6493.814f, 29.37009f));
                        Pos_01.Add(new Vector3(250.2143f, 6489.353f, 30.67807f));
                        Pos_01.Add(new Vector3(171.8803f, 6482.01f, 31.94304f));
                        Pos_01.Add(new Vector3(175.2863f, 6475.943f, 31.89293f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(157.3289f, 7044.97f, 1.865713f));
                        Pos_01.Add(new Vector3(102.7529f, 7073.901f, 1.931986f));
                        Pos_01.Add(new Vector3(52.24357f, 7079.25f, 2.17193f));
                        Pos_01.Add(new Vector3(23.56722f, 7052.823f, 1.409035f));
                        Pos_01.Add(new Vector3(31.16364f, 7023.305f, 7.387625f));
                        Pos_01.Add(new Vector3(41.1493f, 7013.06f, 8.625368f));
                        Pos_01.Add(new Vector3(36.24067f, 6995.254f, 8.021345f));
                        Pos_01.Add(new Vector3(73.45621f, 6951.467f, 11.52127f));
                        Pos_01.Add(new Vector3(76.90339f, 6968.756f, 10.14844f));
                        Pos_01.Add(new Vector3(96.15324f, 6976.542f, 9.490364f));
                        Pos_01.Add(new Vector3(144.0458f, 6980.392f, 8.019959f));
                        Pos_01.Add(new Vector3(157.614f, 6990.637f, 4.969121f));
                        Pos_01.Add(new Vector3(158.9223f, 7011.254f, 3.681879f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(-576.4569f, 5452.922f, 60.71923f));
                        Pos_01.Add(new Vector3(-560.6669f, 5474.996f, 61.77381f));
                        Pos_01.Add(new Vector3(-552.685f, 5494.2f, 59.80086f));
                        Pos_01.Add(new Vector3(-550.2758f, 5515.276f, 59.87648f));
                        Pos_01.Add(new Vector3(-572.0354f, 5544.016f, 52.74706f));
                        Pos_01.Add(new Vector3(-601.4049f, 5515.799f, 49.60851f));
                        Pos_01.Add(new Vector3(-620.7578f, 5506.275f, 51.13645f));
                        Pos_01.Add(new Vector3(-634.4025f, 5477.448f, 53.29848f));
                        Pos_01.Add(new Vector3(-637.6897f, 5453.631f, 52.85682f));
                        Pos_01.Add(new Vector3(-595.5697f, 5458.982f, 59.10485f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(-334.3983f, 6183.464f, 31.42284f));
                        Pos_01.Add(new Vector3(-305.0548f, 6212.236f, 31.45675f));
                        Pos_01.Add(new Vector3(-302.0125f, 6213.075f, 31.39697f));
                        Pos_01.Add(new Vector3(-284.0596f, 6234.494f, 31.49339f));
                        Pos_01.Add(new Vector3(-237.9272f, 6281.979f, 31.45799f));
                        Pos_01.Add(new Vector3(-252.1601f, 6297.677f, 31.45717f));
                        Pos_01.Add(new Vector3(-301.6298f, 6251.044f, 31.51244f));
                        Pos_01.Add(new Vector3(-305.8697f, 6247.805f, 31.43438f));
                        Pos_01.Add(new Vector3(-318.1996f, 6232.045f, 31.48331f));
                        Pos_01.Add(new Vector3(-322.5253f, 6227.77f, 31.46884f));
                        Pos_01.Add(new Vector3(-360.4957f, 6191.922f, 31.48243f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-1445.911f, 4228.153f, 49.88695f));
                        Pos_01.Add(new Vector3(-1437.855f, 4232.769f, 48.72689f));
                        Pos_01.Add(new Vector3(-1414.334f, 4225.317f, 42.9243f));
                        Pos_01.Add(new Vector3(-1406.202f, 4234.257f, 39.57491f));
                        Pos_01.Add(new Vector3(-1398.107f, 4235.384f, 37.1693f));
                        Pos_01.Add(new Vector3(-1381.473f, 4242.933f, 32.96693f));
                        Pos_01.Add(new Vector3(-1379.1f, 4227.457f, 27.85471f));
                        Pos_01.Add(new Vector3(-1375.508f, 4221.704f, 26.20435f));
                        Pos_01.Add(new Vector3(-1371.023f, 4221.62f, 24.55573f));
                        Pos_01.Add(new Vector3(-1369.318f, 4234.283f, 21.74896f));
                        Pos_01.Add(new Vector3(-1365.844f, 4237.374f, 20.58922f));
                        Pos_01.Add(new Vector3(-1362.55f, 4222.789f, 18.0125f));
                        Pos_01.Add(new Vector3(-1357.766f, 4223.158f, 16.33216f));
                        Pos_01.Add(new Vector3(-1355.488f, 4230.613f, 14.08321f));
                        Pos_01.Add(new Vector3(-1349.775f, 4261.309f, 7.204568f));
                        Pos_01.Add(new Vector3(-1350.807f, 4280.167f, 3.489815f));
                        Pos_01.Add(new Vector3(-1366.992f, 4291.422f, 2.879005f));
                        Pos_01.Add(new Vector3(-1375.258f, 4295.798f, 2.808748f));
                        Pos_01.Add(new Vector3(-1409.907f, 4301.811f, 5.031199f));
                        Pos_01.Add(new Vector3(-1511.659f, 4307.015f, 5.628844f));
                        Pos_01.Add(new Vector3(-1585.516f, 4343.747f, 3.159351f));
                        Pos_01.Add(new Vector3(-1610.404f, 4373.366f, 2.441379f));
                        Pos_01.Add(new Vector3(-1644.269f, 4431.979f, 3.232418f));
                        Pos_01.Add(new Vector3(-1677.754f, 4452.332f, 2.484089f));
                        Pos_01.Add(new Vector3(-1734.826f, 4452.425f, 4.763266f));
                        Pos_01.Add(new Vector3(-1783.387f, 4475.105f, 11.17609f));
                        Pos_01.Add(new Vector3(-1815.323f, 4479.708f, 17.87292f));
                        Pos_01.Add(new Vector3(-1842.674f, 4500.0f, 22.1328f));
                        Pos_01.Add(new Vector3(-1855.061f, 4500.765f, 22.36915f));
                        Pos_01.Add(new Vector3(-1878.805f, 4481.325f, 26.10547f));
                        Pos_01.Add(new Vector3(-1912.77f, 4482.177f, 29.16429f));
                        Pos_01.Add(new Vector3(-1927.905f, 4460.231f, 34.65511f));
                        Pos_01.Add(new Vector3(-1905.194f, 4437.292f, 42.7122f));
                        Pos_01.Add(new Vector3(-1870.033f, 4417.005f, 48.25819f));
                        Pos_01.Add(new Vector3(-1739.497f, 4344.018f, 62.30252f));
                        Pos_01.Add(new Vector3(-1701.276f, 4303.689f, 69.18857f));
                        Pos_01.Add(new Vector3(-1659.563f, 4215.886f, 82.93988f));
                        Pos_01.Add(new Vector3(-1637.42f, 4205.126f, 84.06075f));
                        Pos_01.Add(new Vector3(-1587.657f, 4200.398f, 81.1502f));
                        Pos_01.Add(new Vector3(-1567.076f, 4205.095f, 78.5675f));
                        Pos_01.Add(new Vector3(-1566.948f, 4205.121f, 78.53695f));
                        Pos_01.Add(new Vector3(-1489.583f, 4226.147f, 57.02686f));
                        Pos_01.Add(new Vector3(-1461.699f, 4225.801f, 52.18763f));
                    }
                }

                iAction = 7;
            }           //Jogger
            else if (iSelect == 11)
            {
                World.CurrentDayTime = TimeSpan.FromHours(12);
                World.Weather = Weather.ExtraSunny;

                if (BoolList(7))
                {
                    Pos_01.Add(new Vector3(-1364.786f, 88.02513f, 60.62911f)); fHeading.Add(4.459937f);//no cart
                    Pos_01.Add(new Vector3(-1341.147f, 58.34372f, 55.24565f)); fHeading.Add(255.8883f);
                    Pos_01.Add(new Vector3(-1288.279f, 1.371114f, 50.11296f)); fHeading.Add(75.64562f);
                    Pos_01.Add(new Vector3(-1274.725f, 34.73936f, 49.62621f)); fHeading.Add(338.932f);
                    Pos_01.Add(new Vector3(-1175.636f, -65.13375f, 45.69381f)); fHeading.Add(139.9237f);
                    Pos_01.Add(new Vector3(-1114.52f, -104.372f, 41.82968f)); fHeading.Add(90.15023f);
                    Pos_01.Add(new Vector3(-983.2661f, -102.9894f, 40.56398f)); fHeading.Add(126.2475f);
                    Pos_01.Add(new Vector3(-956.8571f, -89.0538f, 40.23488f)); fHeading.Add(152.8323f);
                    Pos_01.Add(new Vector3(-1046.63f, 5.216981f, 50.38495f)); fHeading.Add(192.7493f);
                    Pos_01.Add(new Vector3(-1139.543f, -3.184531f, 48.97698f)); fHeading.Add(259.1323f);
                    Pos_01.Add(new Vector3(-1098.178f, 5.847201f, 50.7424f)); fHeading.Add(301.1844f);
                    Pos_01.Add(new Vector3(-1222.79f, 112.2568f, 58.0234f)); fHeading.Add(202.7297f);
                    Pos_01.Add(new Vector3(-1249.355f, 119.8463f, 56.71364f)); fHeading.Add(267.9071f);
                    Pos_01.Add(new Vector3(-1317.202f, 127.7053f, 57.40704f)); fHeading.Add(246.1611f);
                    Pos_01.Add(new Vector3(-1239.579f, 110.9363f, 56.97162f)); fHeading.Add(331.1595f);
                    iAction = 1;

                    iEnterVeh = 9;
                }
                else
                {
                    Pos_01.Add(new Vector3(-1107.049f, 156.9751f, 63.03234f)); fHeading.Add(122.5306f);
                    Pos_01.Add(new Vector3(-1115.922f, 217.6304f, 64.90271f)); fHeading.Add(353.1153f);
                    Pos_01.Add(new Vector3(-1331.825f, 180.7175f, 58.57675f)); fHeading.Add(279.2617f);
                    Pos_01.Add(new Vector3(-1338.933f, 39.00248f, 60.45947f)); fHeading.Add(269.2881f);
                    Pos_01.Add(new Vector3(-1341.403f, 77.53231f, 60.54446f)); fHeading.Add(272.9171f);
                }

                iWeapons = 6;
            }           //Golf
            else if (iSelect == 12)
            {
                World.CurrentDayTime = TimeSpan.FromHours(12);
                World.Weather = Weather.ExtraSunny;

                Pos_01.Add(new Vector3(2720.672f, 5199.552f, 46.27291f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2963.182f, 5326.022f, 100.778f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2949.531f, 5438.373f, 162.5469f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2992.025f, 5621.749f, 232.6244f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2879.819f, 5899.114f, 365.6005f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2593.217f, 6181.326f, 166.5712f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2878.431f, 6306.65f, 61.58187f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(3088.869f, 5976.871f, 142.4146f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(3343.402f, 5605.421f, 20.52476f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2396.466f, 3537.57f, 73.30798f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2312.362f, 3462.918f, 63.92526f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2283.617f, 3717.97f, 37.76125f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2616.046f, 3664.323f, 102.1026f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(283.5832f, 947.1102f, 210.7036f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(348.7232f, 931.5547f, 203.4314f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(373.0858f, 779.3486f, 185.2447f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(948.7731f, 1037.539f, 261.536f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(700.1483f, 1207.633f, 325.3834f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(387.6657f, 1040.978f, 237.5461f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-14.01058f, 1159.781f, 245.6257f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-20.51055f, 1325.732f, 272.8569f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-185.2845f, 1296.065f, 303.9481f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-288.8628f, 1453.615f, 337.2819f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-378.9312f, 1239.677f, 326.7248f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-252.5762f, 1563.565f, 336.6067f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-426.8705f, 1592.102f, 356.4857f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-2272.792f, -23.2073f, 112.7793f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-2200.135f, 109.4031f, 164.6617f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-840.225f, 4182.86f, 215.2899f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-690.8635f, 4176.191f, 154.5896f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-524.2221f, 4194.03f, 193.7312f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-206.6364f, 4332.957f, 31.91346f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-526.2425f, 4505.556f, 79.13145f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-893.4651f, 4529.192f, 115.0835f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1129.78f, 4593.836f, 141.6974f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1282.924f, 4608.878f, 122.7074f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1640.868f, 4556.064f, 43.19655f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1850.567f, 4794.448f, 4.776535f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1496.777f, 4969.285f, 63.59271f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1640.963f, 4732.36f, 53.54873f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1311.3f, 4852.929f, 143.8367f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-964.3344f, 4723.415f, 270.2252f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-943.7798f, 4610.354f, 238.8457f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-291.9144f, 4670.902f, 243.5815f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-587.2416f, 4754.331f, 212.2155f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-565.4411f, 4879.412f, 168.1732f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(112.5606f, 5108.352f, 511.6148f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(230.4509f, 5247.983f, 601.9519f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(971.1742f, 5642.117f, 634.5059f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(501.2652f, 5605.104f, 797.9101f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2280.013f, 5789.094f, 155.2191f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2326.279f, 5665.603f, 99.50616f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(1793.711f, 5425.402f, 257.2485f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2397.77f, 5316.37f, 96.5042f)); fHeading.Add(122.5306f);
            }           //Hiker
            else if (iSelect == 13)
            {
                RandomWeatherTime();

                Pos_01.Add(new Vector3(1444.053f, 3749.468f, 31.92976f)); fHeading.Add(327.8784f);
                Pos_01.Add(new Vector3(1548.64f, 3513.32f, 35.98967f)); fHeading.Add(272.104f);
                Pos_01.Add(new Vector3(1533.76f, 3587.345f, 38.87133f)); fHeading.Add(114.6104f);
                Pos_01.Add(new Vector3(1628.359f, 3656.295f, 35.1298f)); fHeading.Add(336.5864f);
                Pos_01.Add(new Vector3(1636.128f, 3672.148f, 34.49414f)); fHeading.Add(115.8842f);
                Pos_01.Add(new Vector3(1542.536f, 3801.337f, 38.26442f)); fHeading.Add(174.2905f);
                Pos_01.Add(new Vector3(-177.5078f, 6151.445f, 42.63219f)); fHeading.Add(146.5759f);
                Pos_01.Add(new Vector3(66.09401f, 6663.828f, 31.7822f)); fHeading.Add(106.9903f);
                Pos_01.Add(new Vector3(-1096.575f, 318.6839f, 66.57769f)); fHeading.Add(76.68429f);
                Pos_01.Add(new Vector3(1416.632f, 6359.68f, 23.9975f)); fHeading.Add(211.194f);
                iAction = 11;
                iWeapons = 4;
            }           //Meth
            else if (iSelect == 14)
            {
                RandomWeatherTime();

                if (BoolList(8))
                {
                    Pos_01.Add(new Vector3(606.2311f, 6460.72f, 30.36371f)); fHeading.Add(5.789507f);
                    Pos_01.Add(new Vector3(320.5405f, 6446.443f, 31.04944f)); fHeading.Add(270.2463f);
                    Pos_01.Add(new Vector3(290.7818f, 6630.841f, 29.3664f)); fHeading.Add(90.56525f);
                    Pos_01.Add(new Vector3(2888.594f, 4678.878f, 48.91417f)); fHeading.Add(194.4243f);
                    Pos_01.Add(new Vector3(2570.12f, 4376.354f, 40.19937f)); fHeading.Add(221.7568f);
                    Pos_01.Add(new Vector3(2558.896f, 4476.233f, 38.08518f)); fHeading.Add(315.5452f);
                    Pos_01.Add(new Vector3(2594.646f, 4650.071f, 33.75171f)); fHeading.Add(136.7592f);
                    Pos_01.Add(new Vector3(2494.011f, 4804.704f, 35.34127f)); fHeading.Add(175.9323f);
                    Pos_01.Add(new Vector3(2325.911f, 4943.582f, 41.73738f)); fHeading.Add(222.2322f);
                    Pos_01.Add(new Vector3(2255.547f, 5126.423f, 52.96769f)); fHeading.Add(227.4431f);
                    Pos_01.Add(new Vector3(2162.245f, 5100.812f, 46.41386f)); fHeading.Add(308.368f);
                    Pos_01.Add(new Vector3(2048.374f, 4850.952f, 41.61911f)); fHeading.Add(315.2769f);
                    Pos_01.Add(new Vector3(1862.38f, 4848.723f, 44.41615f)); fHeading.Add(308.6472f);
                    Pos_01.Add(new Vector3(1908.713f, 4948.124f, 50.11693f)); fHeading.Add(246.5423f);
                    Pos_01.Add(new Vector3(2008.261f, 4949.729f, 41.91264f)); fHeading.Add(133.3243f);
                    Pos_01.Add(new Vector3(430.6846f, 6468.167f, 28.74771f)); fHeading.Add(50.51311f);
                    Pos_01.Add(new Vector3(173.5756f, 2281.659f, 92.56126f)); fHeading.Add(263.4358f);
                    Pos_01.Add(new Vector3(-128.4896f, 1935.452f, 195.7328f)); fHeading.Add(0.565784f);
                    Pos_01.Add(new Vector3(851.4491f, 2197.121f, 51.95424f)); fHeading.Add(0.72941f);
                    Pos_01.Add(new Vector3(1510.296f, 2203.938f, 79.86816f)); fHeading.Add(89.00253f);
                    Pos_01.Add(new Vector3(2915.768f, 4706.488f, 49.70249f)); fHeading.Add(289.0847f);
                    Pos_01.Add(new Vector3(2544.22f, 4665.709f, 34.05292f)); fHeading.Add(9.306635f);
                    Pos_01.Add(new Vector3(1959.184f, 4648.749f, 40.72918f)); fHeading.Add(251.9252f);
                    Pos_01.Add(new Vector3(1800.967f, 4583.435f, 36.61988f)); fHeading.Add(3.34992f);
                    Pos_01.Add(new Vector3(1722.527f, 4706.51f, 42.44329f)); fHeading.Add(283.467f);
                    Pos_01.Add(new Vector3(1690.262f, 4787.966f, 41.89737f)); fHeading.Add(88.87373f);
                    Pos_01.Add(new Vector3(1661.02f, 4856.334f, 41.85426f)); fHeading.Add(185.8731f);

                    iEnterVeh = 1;

                    iAction = 1;
                }
                else
                {
                    Pos_01.Add(new Vector3(-106.8555f, 1909.862f, 197.0744f)); fHeading.Add(268.5506f);
                    Pos_01.Add(new Vector3(2222.35f, 5577.166f, 53.84396f)); fHeading.Add(276.1251f);
                    Pos_01.Add(new Vector3(1912.766f, 4822.175f, 45.52872f)); fHeading.Add(228.9311f);
                    Pos_01.Add(new Vector3(2247.639f, 4774.398f, 39.89716f)); fHeading.Add(344.2038f);
                    Pos_01.Add(new Vector3(1872.865f, 5055.132f, 51.92373f)); fHeading.Add(309.9024f);
                    Pos_01.Add(new Vector3(1784.382f, 5000.532f, 52.79548f)); fHeading.Add(128.8428f);
                    Pos_01.Add(new Vector3(340.2533f, 6625.122f, 28.87183f)); fHeading.Add(23.61716f);
                    Pos_01.Add(new Vector3(518.1836f, 6496.691f, 30.03387f)); fHeading.Add(191.6541f);
                }

                iWeapons = 4;
            }           //Rural
            else if (iSelect == 15)
            {
                World.Weather = Weather.ExtraSunny;

                World.CurrentDayTime = TimeSpan.FromHours(12);

                iSubSet = FindRandom(5, 1, 7);

                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(-1831.184f, 812.9753f, 138.7346f)); fHeading.Add(311.9534f);
                    Pos_01.Add(new Vector3(-1764.571f, 820.3898f, 140.6735f)); fHeading.Add(224.452f);
                    Pos_01.Add(new Vector3(-1703.508f, 863.8099f, 146.1381f)); fHeading.Add(329.4052f);
                    Pos_01.Add(new Vector3(-1616.284f, 1302.846f, 135.705f)); fHeading.Add(347.8204f);
                    Pos_01.Add(new Vector3(-1486.132f, 1480.176f, 116.4422f)); fHeading.Add(348.227f);
                    Pos_01.Add(new Vector3(-1441.415f, 1967.07f, 70.34432f)); fHeading.Add(27.66854f);
                    Pos_01.Add(new Vector3(-1533.887f, 2206.239f, 55.41714f)); fHeading.Add(355.8203f);
                    Pos_01.Add(new Vector3(-1660.077f, 2391.279f, 34.17039f)); fHeading.Add(44.57704f);
                    Pos_01.Add(new Vector3(-1751.416f, 2434.735f, 31.05655f)); fHeading.Add(109.2942f);
                    Pos_01.Add(new Vector3(-2023.357f, 2341.409f, 33.70339f)); fHeading.Add(108.7265f);
                    Pos_01.Add(new Vector3(-2061.96f, 2275.943f, 41.02344f)); fHeading.Add(267.6714f);
                    Pos_01.Add(new Vector3(-1675.041f, 2222.344f, 85.92983f)); fHeading.Add(242.9998f);
                    Pos_01.Add(new Vector3(-1866.669f, 2028.195f, 138.2143f)); fHeading.Add(135.3699f);
                    Pos_01.Add(new Vector3(-1920.531f, 1768.664f, 172.25f)); fHeading.Add(107.3471f);
                    Pos_01.Add(new Vector3(-2207.551f, 1929.131f, 187.8876f)); fHeading.Add(114.3961f);
                    Pos_01.Add(new Vector3(-2545.024f, 1883.435f, 166.6029f)); fHeading.Add(204.0507f);
                    Pos_01.Add(new Vector3(-2638.612f, 1611.174f, 126.6342f)); fHeading.Add(155.5314f);
                    Pos_01.Add(new Vector3(-2633.305f, 1457.598f, 127.2729f)); fHeading.Add(184.6736f);
                    Pos_01.Add(new Vector3(-2194.78f, 1038.959f, 192.1174f)); fHeading.Add(220.2004f);
                    Pos_01.Add(new Vector3(-1931.807f, 725.5128f, 140.8996f)); fHeading.Add(309.9311f);
                }       //Racer
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(-1098.633f, -1707.841f, 3.88987f)); fHeading.Add(90.94658f);
                    Pos_01.Add(new Vector3(-1159.836f, -1675.204f, 3.896749f)); fHeading.Add(113.9283f);
                    Pos_01.Add(new Vector3(-1290.18f, -1653.48f, 3.943152f)); fHeading.Add(35.13303f);
                    Pos_01.Add(new Vector3(-1364.189f, -1481.239f, 3.893025f)); fHeading.Add(14.74119f);
                    Pos_01.Add(new Vector3(-1376.141f, -1363.218f, 3.025539f)); fHeading.Add(303.6996f);
                    Pos_01.Add(new Vector3(-1414.212f, -1251.127f, 3.946122f)); fHeading.Add(35.59299f);
                    Pos_01.Add(new Vector3(-1509.133f, -1073.262f, 3.942042f)); fHeading.Add(69.98211f);
                    Pos_01.Add(new Vector3(-1682.818f, -955.2328f, 7.185737f)); fHeading.Add(74.90568f);
                    Pos_01.Add(new Vector3(-1721.408f, -886.7053f, 7.388651f)); fHeading.Add(317.7188f);
                    Pos_01.Add(new Vector3(-1703.534f, -778.4359f, 9.642578f)); fHeading.Add(48.75169f);
                    Pos_01.Add(new Vector3(-1835.261f, -665.6154f, 9.865945f)); fHeading.Add(50.18934f);
                    Pos_01.Add(new Vector3(-2067.342f, -468.4766f, 11.15151f)); fHeading.Add(50.04951f);
                    Pos_01.Add(new Vector3(-2056.839f, -428.9153f, 11.02667f)); fHeading.Add(320.5753f);
                    Pos_01.Add(new Vector3(-2075.677f, -461.2531f, 11.15421f)); fHeading.Add(235.472f);
                    Pos_01.Add(new Vector3(-1886.761f, -619.9555f, 11.02383f)); fHeading.Add(230.0587f);
                    Pos_01.Add(new Vector3(-1672.096f, -805.3911f, 9.649653f)); fHeading.Add(229.8522f);
                    Pos_01.Add(new Vector3(-1718.168f, -922.6528f, 7.201679f)); fHeading.Add(212.6043f);
                    Pos_01.Add(new Vector3(-1594.58f, -1008.036f, 6.960374f)); fHeading.Add(230.1252f);
                    Pos_01.Add(new Vector3(-1421.424f, -1200.432f, 2.879864f)); fHeading.Add(174.2845f);
                    Pos_01.Add(new Vector3(-1363.745f, -1354.689f, 3.734038f)); fHeading.Add(116.6605f);
                    Pos_01.Add(new Vector3(-1373.53f, -1462.265f, 3.899288f)); fHeading.Add(207.7464f);
                    Pos_01.Add(new Vector3(-1188.865f, -1696.42f, 3.944314f)); fHeading.Add(302.5409f);
                    Pos_01.Add(new Vector3(-1119.958f, -1689.427f, 3.891113f)); fHeading.Add(208.4599f);
                }
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(-1017.562f, 5106.583f, 143.565f)); fHeading.Add(143.8827f);
                    Pos_01.Add(new Vector3(-1071.64f, 5061.932f, 166.1416f)); fHeading.Add(174.5619f);
                    Pos_01.Add(new Vector3(-1035.021f, 4968.975f, 200.3412f)); fHeading.Add(211.0696f);
                    Pos_01.Add(new Vector3(-1010.414f, 4957.312f, 195.5821f)); fHeading.Add(313.6152f);
                    Pos_01.Add(new Vector3(-969.2093f, 5008.816f, 180.9947f)); fHeading.Add(31.7368f);
                    Pos_01.Add(new Vector3(-912.714f, 5157.586f, 154.868f)); fHeading.Add(258.4962f);
                    Pos_01.Add(new Vector3(-731.6442f, 5088.924f, 137.6509f)); fHeading.Add(242.9037f);
                    Pos_01.Add(new Vector3(-655.4277f, 5090.802f, 132.4683f)); fHeading.Add(250.5016f);
                    Pos_01.Add(new Vector3(-649.8322f, 5126.122f, 125.6041f)); fHeading.Add(46.66806f);
                    Pos_01.Add(new Vector3(-754.5825f, 5187.835f, 110.7141f)); fHeading.Add(62.56298f);
                    Pos_01.Add(new Vector3(-824.0505f, 5177.887f, 111.9148f)); fHeading.Add(101.8079f);
                    Pos_01.Add(new Vector3(-893.9097f, 5209.729f, 112.5179f)); fHeading.Add(80.07652f);
                    Pos_01.Add(new Vector3(-988.9006f, 5185.046f, 121.5435f)); fHeading.Add(132.7849f);
                }       //Mountain
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(-90.27805f, 1530.019f, 285.9787f)); fHeading.Add(69.38036f);
                    Pos_01.Add(new Vector3(-181.8039f, 1542.743f, 312.8849f)); fHeading.Add(103.2741f);
                    Pos_01.Add(new Vector3(-224.489f, 1560.842f, 325.914f)); fHeading.Add(63.67017f);
                    Pos_01.Add(new Vector3(-267.6929f, 1545.163f, 335.6747f)); fHeading.Add(132.9373f);
                    Pos_01.Add(new Vector3(-289.0792f, 1456.778f, 336.3503f)); fHeading.Add(170.9723f);
                    Pos_01.Add(new Vector3(-327.6443f, 1350.852f, 344.5363f)); fHeading.Add(167.0383f);
                    Pos_01.Add(new Vector3(-375.376f, 1247.601f, 326.4334f)); fHeading.Add(139.2814f);
                    Pos_01.Add(new Vector3(-387.3534f, 1230.396f, 325.1447f)); fHeading.Add(147.9483f);
                    Pos_01.Add(new Vector3(-388.1032f, 1176.121f, 325.1177f)); fHeading.Add(249.1379f);
                    Pos_01.Add(new Vector3(-229.2232f, 1291.04f, 306.4082f)); fHeading.Add(300.9233f);
                    Pos_01.Add(new Vector3(-186.1638f, 1292.394f, 303.1103f)); fHeading.Add(235.3964f);
                    Pos_01.Add(new Vector3(-122.8801f, 1312.186f, 297.1616f)); fHeading.Add(290.4021f);
                    Pos_01.Add(new Vector3(-16.56782f, 1320.053f, 271.3388f)); fHeading.Add(250.8344f);
                    Pos_01.Add(new Vector3(35.19429f, 1292.053f, 262.6383f)); fHeading.Add(250.6078f);
                    Pos_01.Add(new Vector3(111.7312f, 1261.334f, 253.0591f)); fHeading.Add(249.888f);
                    Pos_01.Add(new Vector3(192.726f, 1286.057f, 244.9456f)); fHeading.Add(286.535f);
                    Pos_01.Add(new Vector3(218.4447f, 1324.374f, 239.0383f)); fHeading.Add(349.563f);
                    Pos_01.Add(new Vector3(189.5349f, 1361.092f, 244.0261f)); fHeading.Add(50.20052f);
                    Pos_01.Add(new Vector3(-35.94518f, 1482.559f, 276.2757f)); fHeading.Add(47.98716f);
                }
                else if (iSubSet == 5)
                {
                    Pos_01.Add(new Vector3(1131.343f, 2220.968f, 48.44126f)); fHeading.Add(243.5716f);
                    Pos_01.Add(new Vector3(1159.706f, 2217.349f, 50.82573f)); fHeading.Add(258.8792f);
                    Pos_01.Add(new Vector3(1166.896f, 2162.989f, 53.84629f)); fHeading.Add(169.9953f);
                    Pos_01.Add(new Vector3(1098.576f, 2155.015f, 52.69805f)); fHeading.Add(73.61179f);
                    Pos_01.Add(new Vector3(1090.835f, 2211.467f, 48.93021f)); fHeading.Add(9.747736f);
                    Pos_01.Add(new Vector3(1044.372f, 2192.271f, 44.4439f)); fHeading.Add(118.0097f);
                    Pos_01.Add(new Vector3(993.3459f, 2211.962f, 46.28838f)); fHeading.Add(41.27867f);
                    Pos_01.Add(new Vector3(928.5845f, 2252.565f, 44.727f)); fHeading.Add(65.21915f);
                    Pos_01.Add(new Vector3(898.9063f, 2299.954f, 45.55281f)); fHeading.Add(1.079976f);
                    Pos_01.Add(new Vector3(893.9247f, 2367.798f, 51.03556f)); fHeading.Add(9.637207f);
                    Pos_01.Add(new Vector3(890.4763f, 2458.718f, 50.12368f)); fHeading.Add(344.7286f);
                    Pos_01.Add(new Vector3(946.5344f, 2481.687f, 49.33643f)); fHeading.Add(244.823f);
                    Pos_01.Add(new Vector3(987.7492f, 2452.002f, 48.93232f)); fHeading.Add(244.9161f);
                    Pos_01.Add(new Vector3(1041.457f, 2437.304f, 44.44455f)); fHeading.Add(260.0757f);
                    Pos_01.Add(new Vector3(1079.171f, 2446.667f, 48.99023f)); fHeading.Add(308.1842f);
                    Pos_01.Add(new Vector3(1119.289f, 2479.278f, 50.80782f)); fHeading.Add(276.7901f);
                    Pos_01.Add(new Vector3(1158.328f, 2469.449f, 53.44667f)); fHeading.Add(220.5749f);
                    Pos_01.Add(new Vector3(1165.507f, 2273.166f, 50.33825f)); fHeading.Add(175.9661f);
                    Pos_01.Add(new Vector3(1125.515f, 2274.496f, 48.946f)); fHeading.Add(24.32979f);
                    Pos_01.Add(new Vector3(1114.623f, 2402.528f, 49.40758f)); fHeading.Add(7.477652f);
                    Pos_01.Add(new Vector3(1057.731f, 2410.765f, 49.92449f)); fHeading.Add(93.07478f);
                    Pos_01.Add(new Vector3(1008.178f, 2407.365f, 51.17159f)); fHeading.Add(96.8075f);
                    Pos_01.Add(new Vector3(927.653f, 2374.892f, 46.21589f)); fHeading.Add(143.9296f);
                    Pos_01.Add(new Vector3(974.15f, 2347.133f, 48.14143f)); fHeading.Add(229.5057f);
                    Pos_01.Add(new Vector3(976.75f, 2319.152f, 47.77378f)); fHeading.Add(136.5242f);
                    Pos_01.Add(new Vector3(937.3336f, 2297.426f, 45.63793f)); fHeading.Add(157.523f);
                    Pos_01.Add(new Vector3(966.1271f, 2274.494f, 46.90409f)); fHeading.Add(249.9637f);
                    Pos_01.Add(new Vector3(1012.06f, 2256.639f, 44.98619f)); fHeading.Add(273.5895f);
                    Pos_01.Add(new Vector3(1074.876f, 2257.516f, 43.97958f)); fHeading.Add(269.696f);
                    Pos_01.Add(new Vector3(1119.866f, 2237.699f, 48.11778f)); fHeading.Add(205.3962f);
                }       //BMX
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(709.8904f, -1209.633f, 24.15573f)); fHeading.Add(271.7742f);
                    Pos_01.Add(new Vector3(725.6425f, -1209.393f, 24.15294f)); fHeading.Add(264.8582f);
                    Pos_01.Add(new Vector3(727.7066f, -1226.787f, 24.16752f)); fHeading.Add(176.0324f);
                    Pos_01.Add(new Vector3(711.7754f, -1230.785f, 26.01836f)); fHeading.Add(89.38039f);
                    Pos_01.Add(new Vector3(695.2515f, -1233.058f, 24.22271f)); fHeading.Add(99.51613f);
                    Pos_01.Add(new Vector3(691.3087f, -1221.595f, 24.2079f)); fHeading.Add(1.18434f);
                    Pos_01.Add(new Vector3(710.1845f, -1218.317f, 24.13501f)); fHeading.Add(271.655f);
                }
                else
                {
                    Pos_01.Add(new Vector3(-851.1493f, -856.7646f, 18.77589f)); fHeading.Add(358.0621f);
                    Pos_01.Add(new Vector3(-906.5968f, -968.0899f, 1.743039f)); fHeading.Add(210.8783f);
                    Pos_01.Add(new Vector3(-1348.573f, -1115.726f, 3.962325f)); fHeading.Add(299.9897f);
                    Pos_01.Add(new Vector3(-659.8745f, -959.2974f, 20.91997f)); fHeading.Add(263.4982f);
                    Pos_01.Add(new Vector3(-241.4375f, -1584.557f, 33.22305f)); fHeading.Add(187.4465f);
                    Pos_01.Add(new Vector3(270.0584f, -1683.841f, 28.84942f)); fHeading.Add(297.7897f);
                    Pos_01.Add(new Vector3(473.6976f, -1815.705f, 27.51255f)); fHeading.Add(129.6885f);
                    Pos_01.Add(new Vector3(986.9617f, -676.3321f, 56.99862f)); fHeading.Add(24.37898f);
                    Pos_01.Add(new Vector3(1061.91f, -410.1332f, 66.65007f)); fHeading.Add(306.7592f);
                    Pos_01.Add(new Vector3(-3227.214f, 985.9169f, 12.22838f)); fHeading.Add(3.493601f);
                    Pos_01.Add(new Vector3(-181.3568f, 6463.39f, 30.20193f)); fHeading.Add(323.6627f);
                    Pos_01.Add(new Vector3(1665.24f, 4906.476f, 41.67233f)); fHeading.Add(354.5847f);
                }       //Cruser

                iAction = 8;

                iEnterVeh = 1;
            }           //Cycles
            else if (iSelect == 16)
            {
                World.CurrentDayTime = TimeSpan.FromHours(21);

                Pos_01.Add(new Vector3(-555.8153f, 204.4809f, 82.72643f)); fHeading.Add(252.7766f);
                Pos_01.Add(new Vector3(-237.4932f, 207.43f, 84.30554f)); fHeading.Add(303.6445f);
                Pos_01.Add(new Vector3(224.884f, 302.908f, 105.5358f)); fHeading.Add(247.2323f);
            }           //LGBTWXYZ
            else if (iSelect == 17)
            {
                World.Weather = Weather.ExtraSunny;

                World.CurrentDayTime = TimeSpan.FromHours(12);

                Pos_01.Add(new Vector3(-3045.812f, 55.64172f, 8.627448f)); fHeading.Add(191.5956f);
                Pos_01.Add(new Vector3(-2943.079f, 655.5176f, 22.39165f)); fHeading.Add(32.5262f);
                Pos_01.Add(new Vector3(-2962.768f, 703.4619f, 26.46712f)); fHeading.Add(164.4944f);
                Pos_01.Add(new Vector3(-2964.547f, 731.1447f, 27.88261f)); fHeading.Add(84.45402f);
                Pos_01.Add(new Vector3(-2983.335f, 751.6773f, 25.11157f)); fHeading.Add(111.447f);
                Pos_01.Add(new Vector3(-2795.803f, 1452.367f, 99.25223f)); fHeading.Add(66.35561f);
                Pos_01.Add(new Vector3(-2634.445f, 1880.577f, 158.3878f)); fHeading.Add(153.5368f);
                Pos_01.Add(new Vector3(3096.864f, 6025.98f, 121.8479f)); fHeading.Add(336.2496f);
                Pos_01.Add(new Vector3(2563.98f, 6153.684f, 161.2354f)); fHeading.Add(346.2019f);
                Pos_01.Add(new Vector3(-1859.59f, 228.4411f, 82.96251f)); fHeading.Add(127.7508f);
                Pos_01.Add(new Vector3(-1877.686f, 259.271f, 84.43298f)); fHeading.Add(51.80576f);
                Pos_01.Add(new Vector3(-1881.919f, 295.7777f, 87.72468f)); fHeading.Add(250.4356f);
                Pos_01.Add(new Vector3(-1847.838f, 282.9479f, 87.24543f)); fHeading.Add(240.6522f);
                Pos_01.Add(new Vector3(-1775.012f, 322.7032f, 87.18047f)); fHeading.Add(197.6634f);
                Pos_01.Add(new Vector3(-1710.577f, 367.765f, 88.29889f)); fHeading.Add(106.1305f);
                Pos_01.Add(new Vector3(-1678.33f, 364.0826f, 83.0807f)); fHeading.Add(119.0709f);
                Pos_01.Add(new Vector3(-1893.09f, 357.7369f, 91.81727f)); fHeading.Add(89.98589f);
                Pos_01.Add(new Vector3(-1906.691f, 389.7257f, 95.27182f)); fHeading.Add(70.20741f);
                Pos_01.Add(new Vector3(-1917.88f, 442.0487f, 101.2374f)); fHeading.Add(23.85498f);
                Pos_01.Add(new Vector3(-1775.343f, 437.326f, 125.9239f)); fHeading.Add(279.1228f);
                Pos_01.Add(new Vector3(-1919.291f, 127.1571f, 80.51678f)); fHeading.Add(248.5568f);
                Pos_01.Add(new Vector3(-1955.446f, 141.1171f, 83.02171f)); fHeading.Add(15.4176f);
                Pos_01.Add(new Vector3(-1988.662f, 239.2818f, 85.75612f)); fHeading.Add(317.5026f);
                Pos_01.Add(new Vector3(-1997.83f, 324.9079f, 89.55524f)); fHeading.Add(300.8342f);
                Pos_01.Add(new Vector3(-2033.305f, 356.9896f, 92.78632f)); fHeading.Add(259.0774f);
                Pos_01.Add(new Vector3(-2017.061f, 419.425f, 100.7554f)); fHeading.Add(104.0086f);
                Pos_01.Add(new Vector3(-2042.502f, 510.5439f, 105.0207f)); fHeading.Add(201.5715f);
                Pos_01.Add(new Vector3(-2019.332f, 607.6757f, 116.0399f)); fHeading.Add(176.9692f);
                Pos_01.Add(new Vector3(-1906.127f, 597.2462f, 121.0427f)); fHeading.Add(133.3996f);
                Pos_01.Add(new Vector3(-2004.849f, 647.3167f, 120.8392f)); fHeading.Add(179.2453f);
                Pos_01.Add(new Vector3(-1864.729f, 667.7847f, 128.7296f)); fHeading.Add(120.8827f);
                Pos_01.Add(new Vector3(-994.6255f, -1503.056f, 3.619596f)); fHeading.Add(286.6233f);
                Pos_01.Add(new Vector3(-1303.983f, -1042.059f, 11.07695f)); fHeading.Add(95.69601f);
                Pos_01.Add(new Vector3(-1418.43f, -993.3387f, 18.16207f)); fHeading.Add(113.1817f);
                Pos_01.Add(new Vector3(-1347.12f, -928.1561f, 10.38993f)); fHeading.Add(280.809f);
                Pos_01.Add(new Vector3(-1127.6f, -368.2942f, 47.66271f)); fHeading.Add(2.678566f);
                Pos_01.Add(new Vector3(-1194.313f, -238.2115f, 36.40221f)); fHeading.Add(302.0073f);
                Pos_01.Add(new Vector3(-1655.04f, -423.9619f, 39.99371f)); fHeading.Add(215.616f);
                Pos_01.Add(new Vector3(-1701.476f, -466.6209f, 39.99554f)); fHeading.Add(79.94219f);
                Pos_01.Add(new Vector3(-1996.455f, -271.146f, 30.81234f)); fHeading.Add(161.3845f);
                Pos_01.Add(new Vector3(-1197.041f, 313.4686f, 67.751f)); fHeading.Add(239.0723f);
                Pos_01.Add(new Vector3(-1337.581f, 350.9042f, 62.31931f)); fHeading.Add(289.1602f);
                Pos_01.Add(new Vector3(-1492.492f, -56.38963f, 53.43258f)); fHeading.Add(256.6854f);
                Pos_01.Add(new Vector3(-1540.042f, -109.9774f, 52.42807f)); fHeading.Add(335.4102f);
                Pos_01.Add(new Vector3(-1611.778f, -16.5292f, 56.53456f)); fHeading.Add(226.6901f);
                Pos_01.Add(new Vector3(-1639.233f, -9.076792f, 59.92145f)); fHeading.Add(4.578232f);
                Pos_01.Add(new Vector3(-1586.684f, 4.038853f, 59.26731f)); fHeading.Add(98.43343f);
                Pos_01.Add(new Vector3(-1529.05f, -5.181115f, 54.84669f)); fHeading.Add(332.3435f);
                Pos_01.Add(new Vector3(-1479.162f, 14.24485f, 52.43146f)); fHeading.Add(311.0717f);
                Pos_01.Add(new Vector3(-1461.813f, 179.0799f, 54.75267f)); fHeading.Add(268.7966f);
                Pos_01.Add(new Vector3(-788.2491f, -788.2381f, 26.32391f)); fHeading.Add(347.4677f);
                Pos_01.Add(new Vector3(-552.5022f, -783.8768f, 29.30106f)); fHeading.Add(186.7736f);
                Pos_01.Add(new Vector3(-724.062f, -1001.766f, 16.71691f)); fHeading.Add(75.74413f);
                Pos_01.Add(new Vector3(-1029.607f, 290.339f, 65.11586f)); fHeading.Add(78.66148f);
                Pos_01.Add(new Vector3(-1053.091f, 365.7118f, 68.35947f)); fHeading.Add(165.9629f);
                Pos_01.Add(new Vector3(-878.9501f, 340.3165f, 83.47378f)); fHeading.Add(320.597f);
                Pos_01.Add(new Vector3(-887.8083f, 327.1554f, 82.18018f)); fHeading.Add(180.3041f);
                Pos_01.Add(new Vector3(-831.8134f, 248.9689f, 77.22815f)); fHeading.Add(273.1329f);
                Pos_01.Add(new Vector3(-893.313f, 169.0273f, 67.68666f)); fHeading.Add(93.2482f);
                Pos_01.Add(new Vector3(-954.7523f, 220.4424f, 65.75686f)); fHeading.Add(136.6233f);
                Pos_01.Add(new Vector3(-1010.184f, 226.0269f, 63.68847f)); fHeading.Add(38.22365f);
                Pos_01.Add(new Vector3(-1017.759f, 148.1357f, 56.12671f)); fHeading.Add(293.8944f);
                Pos_01.Add(new Vector3(-1000.254f, 121.9075f, 53.94715f)); fHeading.Add(270.1829f);
                Pos_01.Add(new Vector3(-888.7141f, 101.3723f, 53.14249f)); fHeading.Add(87.43171f);
                Pos_01.Add(new Vector3(-787.3904f, 123.0227f, 54.69615f)); fHeading.Add(80.05839f);
                Pos_01.Add(new Vector3(-952.6634f, 53.73639f, 48.71432f)); fHeading.Add(208.2334f);
                Pos_01.Add(new Vector3(-895.5533f, -37.63317f, 36.60196f)); fHeading.Add(233.8345f);
                Pos_01.Add(new Vector3(-1024.37f, 432.2284f, 71.08146f)); fHeading.Add(154.1581f);
                Pos_01.Add(new Vector3(-995.2686f, 438.8302f, 78.33302f)); fHeading.Add(334.0864f);
                Pos_01.Add(new Vector3(-1000.844f, 463.134f, 77.19495f)); fHeading.Add(104.392f);
                Pos_01.Add(new Vector3(-980.0664f, 463.8022f, 79.73483f)); fHeading.Add(46.73758f);
                Pos_01.Add(new Vector3(-927.5062f, 487.5936f, 82.77666f)); fHeading.Add(170.0165f);
                Pos_01.Add(new Vector3(-936.8797f, 501.3094f, 79.72826f)); fHeading.Add(53.92431f);
                Pos_01.Add(new Vector3(-1013.338f, 539.5078f, 77.79255f)); fHeading.Add(282.0752f);
                Pos_01.Add(new Vector3(-1066.973f, 497.7644f, 83.94453f)); fHeading.Add(220.1158f);
                Pos_01.Add(new Vector3(-1117.826f, 512.5352f, 80.53722f)); fHeading.Add(231.0205f);
                Pos_01.Add(new Vector3(-1160.468f, 509.6538f, 84.52025f)); fHeading.Add(279.801f);
                Pos_01.Add(new Vector3(-1193.058f, 491.3557f, 96.80259f)); fHeading.Add(331.3968f);
                Pos_01.Add(new Vector3(-1303.943f, 492.6552f, 96.08507f)); fHeading.Add(225.8883f);
                Pos_01.Add(new Vector3(-1392.492f, 601.5625f, 129.8707f)); fHeading.Add(353.5048f);
                Pos_01.Add(new Vector3(-1413.317f, 588.257f, 125.1205f)); fHeading.Add(217.9151f);
                Pos_01.Add(new Vector3(-1386.419f, 505.1083f, 119.582f)); fHeading.Add(105.1062f);
                Pos_01.Add(new Vector3(-1326.583f, 540.5914f, 122.6075f)); fHeading.Add(269.3641f);
                Pos_01.Add(new Vector3(-1298.875f, 577.9588f, 128.2203f)); fHeading.Add(178.3084f);
                Pos_01.Add(new Vector3(-1271.058f, 596.7078f, 137.4534f)); fHeading.Add(247.1871f);
                Pos_01.Add(new Vector3(-1233.919f, 615.423f, 137.1098f)); fHeading.Add(289.2881f);
                Pos_01.Add(new Vector3(-1136.452f, 713.3501f, 153.7498f)); fHeading.Add(201.2598f);
                Pos_01.Add(new Vector3(-1107.412f, 732.3629f, 157.4969f)); fHeading.Add(143.5177f);
                Pos_01.Add(new Vector3(-1087.713f, 750.5551f, 167.9281f)); fHeading.Add(164.4328f);
                Pos_01.Add(new Vector3(-1025.926f, 770.5267f, 169.6798f)); fHeading.Add(211.2749f);
                Pos_01.Add(new Vector3(-977.2301f, 735.5602f, 172.0218f)); fHeading.Add(265.5352f);
                Pos_01.Add(new Vector3(-909.6926f, 740.3763f, 180.0956f)); fHeading.Add(81.82249f);
                Pos_01.Add(new Vector3(-868.6624f, 752.2235f, 189.9032f)); fHeading.Add(7.877455f);
                Pos_01.Add(new Vector3(-814.408f, 783.7341f, 200.6464f)); fHeading.Add(29.9381f);
                Pos_01.Add(new Vector3(-752.7916f, 777.5481f, 211.9392f)); fHeading.Add(194.7471f);
                Pos_01.Add(new Vector3(-909.4453f, 843.1014f, 184.2988f)); fHeading.Add(140.1425f);
                Pos_01.Add(new Vector3(-971.9465f, 842.3605f, 175.6778f)); fHeading.Add(54.60799f);
                Pos_01.Add(new Vector3(-1022.66f, 842.3872f, 170.6267f)); fHeading.Add(244.5529f);
                Pos_01.Add(new Vector3(-1066.097f, 839.69f, 164.9688f)); fHeading.Add(217.0195f);
                Pos_01.Add(new Vector3(-1094.515f, 836.8392f, 166.7997f)); fHeading.Add(226.6554f);
                Pos_01.Add(new Vector3(-1159.052f, 807.4681f, 165.6994f)); fHeading.Add(247.5676f);
                Pos_01.Add(new Vector3(-1336.202f, 429.5737f, 98.90172f)); fHeading.Add(10.91781f);
                Pos_01.Add(new Vector3(-1209.78f, 434.0115f, 83.63775f)); fHeading.Add(79.56482f);
                Pos_01.Add(new Vector3(-1146.08f, 437.287f, 84.84669f)); fHeading.Add(213.0582f);
                Pos_01.Add(new Vector3(-1461.746f, 478.9407f, 114.6442f)); fHeading.Add(294.9983f);
                Pos_01.Add(new Vector3(-1474.807f, 432.7327f, 110.9154f)); fHeading.Add(211.9605f);
                Pos_01.Add(new Vector3(-1518.777f, 391.6364f, 106.1265f)); fHeading.Add(187.5404f);
                Pos_01.Add(new Vector3(-1062.276f, 567.8226f, 100.8951f)); fHeading.Add(14.25475f);
                Pos_01.Add(new Vector3(-907.7054f, 504.5181f, 91.1715f)); fHeading.Add(343.916f);
                Pos_01.Add(new Vector3(-900.4271f, 478.245f, 87.10304f)); fHeading.Add(240.5481f);
                Pos_01.Add(new Vector3(-814.1697f, 454.6563f, 88.76468f)); fHeading.Add(97.29221f);
                Pos_01.Add(new Vector3(-834.1874f, 492.4228f, 88.93082f)); fHeading.Add(302.3769f);
                Pos_01.Add(new Vector3(-845.0479f, 545.5221f, 93.45917f)); fHeading.Add(20.59651f);
                Pos_01.Add(new Vector3(-887.1305f, 575.8942f, 99.39474f)); fHeading.Add(305.7055f);
                Pos_01.Add(new Vector3(-937.6163f, 612.3262f, 108.1101f)); fHeading.Add(114.1795f);
                Pos_01.Add(new Vector3(-1125.642f, 604.6667f, 102.6665f)); fHeading.Add(23.63789f);
                Pos_01.Add(new Vector3(-1175.469f, 604.4519f, 101.4761f)); fHeading.Add(220.994f);
                Pos_01.Add(new Vector3(-685.0389f, 794.5554f, 197.2649f)); fHeading.Add(238.0637f);
                Pos_01.Add(new Vector3(-614.069f, 759.4872f, 187.0014f)); fHeading.Add(221.4456f);
                Pos_01.Add(new Vector3(-649.715f, 743.8446f, 172.4775f)); fHeading.Add(87.59254f);
                Pos_01.Add(new Vector3(-613.1782f, 621.3754f, 149.7904f)); fHeading.Add(164.7444f);
                Pos_01.Add(new Vector3(-634.371f, 659.1119f, 148.6696f)); fHeading.Add(22.42731f);
                Pos_01.Add(new Vector3(-661.1744f, 616.6246f, 146.1949f)); fHeading.Add(199.2662f);
                Pos_01.Add(new Vector3(-729.4888f, 685.0509f, 155.9513f)); fHeading.Add(180.7433f);
                Pos_01.Add(new Vector3(-734.0542f, 652.4131f, 154.2377f)); fHeading.Add(167.3811f);
                Pos_01.Add(new Vector3(-839.3329f, 693.5334f, 145.2106f)); fHeading.Add(154.7381f);
                Pos_01.Add(new Vector3(-1064.972f, 701.9827f, 163.6349f)); fHeading.Add(353.3205f);
                Pos_01.Add(new Vector3(-1601.946f, 770.3289f, 187.6154f)); fHeading.Add(101.8007f);
                Pos_01.Add(new Vector3(-674.3577f, 866.253f, 223.6916f)); fHeading.Add(351.8296f);
                Pos_01.Add(new Vector3(-621.1686f, 832.4181f, 204.3554f)); fHeading.Add(326.4169f);
                Pos_01.Add(new Vector3(-544.7578f, 793.3355f, 195.8609f)); fHeading.Add(177.7308f);
                Pos_01.Add(new Vector3(-554.5526f, 612.8793f, 136.0247f)); fHeading.Add(192.0421f);
                Pos_01.Add(new Vector3(-570.2823f, 544.6909f, 108.9361f)); fHeading.Add(196.9023f);
                Pos_01.Add(new Vector3(-571.0569f, 580.2227f, 113.3992f)); fHeading.Add(304.4825f);
                Pos_01.Add(new Vector3(-623.428f, 555.0164f, 110.5005f)); fHeading.Add(256.445f);
                Pos_01.Add(new Vector3(-661.4534f, 551.3612f, 109.9831f)); fHeading.Add(274.937f);
                Pos_01.Add(new Vector3(-662.6475f, 520.2614f, 108.8628f)); fHeading.Add(35.55315f);
                Pos_01.Add(new Vector3(-760.3415f, 495.6663f, 105.6227f)); fHeading.Add(197.768f);
                Pos_01.Add(new Vector3(-792.6409f, 488.0746f, 98.77155f)); fHeading.Add(239.2353f);
                Pos_01.Add(new Vector3(-557.361f, 410.2712f, 98.9854f)); fHeading.Add(103.8872f);
                Pos_01.Add(new Vector3(-622.6409f, 452.2882f, 107.0253f)); fHeading.Add(21.81733f);
                Pos_01.Add(new Vector3(-654.8201f, 443.7271f, 108.8958f)); fHeading.Add(98.25793f);
                Pos_01.Add(new Vector3(-707.8818f, 434.7238f, 105.3034f)); fHeading.Add(206.2419f);
                Pos_01.Add(new Vector3(-793.0532f, 408.5196f, 90.11823f)); fHeading.Add(317.7177f);
                Pos_01.Add(new Vector3(-429.6884f, 433.9929f, 111.3882f)); fHeading.Add(142.4591f);
                Pos_01.Add(new Vector3(-470.8019f, 431.3893f, 101.4715f)); fHeading.Add(65.82205f);
                Pos_01.Add(new Vector3(-485.7001f, 446.8537f, 95.78496f)); fHeading.Add(143.3383f);
                Pos_01.Add(new Vector3(-526.5187f, 455.3444f, 101.9223f)); fHeading.Add(82.61566f);
                Pos_01.Add(new Vector3(-502.1317f, 483.4032f, 105.871f)); fHeading.Add(353.9517f);
                Pos_01.Add(new Vector3(-467.4027f, 505.9088f, 120.1588f)); fHeading.Add(152.0833f);
                Pos_01.Add(new Vector3(-446.5811f, 507.9971f, 118.1903f)); fHeading.Add(237.8992f);
                Pos_01.Add(new Vector3(-400.2415f, 479.6264f, 118.3372f)); fHeading.Add(194.5138f);
                Pos_01.Add(new Vector3(-377.3803f, 442.6701f, 112.4488f)); fHeading.Add(352.5979f);
                Pos_01.Add(new Vector3(-315.0863f, 523.4f, 120.1131f)); fHeading.Add(172.5486f);
                Pos_01.Add(new Vector3(-343.7807f, 556.3951f, 125.0126f)); fHeading.Add(58.56496f);
                Pos_01.Add(new Vector3(-462.3269f, 570.8691f, 125.009f)); fHeading.Add(198.8191f);
                Pos_01.Add(new Vector3(-433.771f, 698.8554f, 151.4797f)); fHeading.Add(104.4336f);
                Pos_01.Add(new Vector3(-246.2313f, 658.5173f, 186.7893f)); fHeading.Add(78.76883f);
                Pos_01.Add(new Vector3(-202.4824f, 662.7463f, 199.0307f)); fHeading.Add(206.3775f);
                Pos_01.Add(new Vector3(-442.3546f, 621.9311f, 141.2312f)); fHeading.Add(94.32441f);
                Pos_01.Add(new Vector3(-409.7963f, 626.1968f, 156.7769f)); fHeading.Add(294.2011f);
                Pos_01.Add(new Vector3(-328.9471f, 602.281f, 170.6802f)); fHeading.Add(186.9233f);
                Pos_01.Add(new Vector3(-280.7156f, 567.8633f, 172.5188f)); fHeading.Add(153.9769f);
                Pos_01.Add(new Vector3(-244.0822f, 565.3209f, 183.8785f)); fHeading.Add(164.9493f);
                Pos_01.Add(new Vector3(-174.8147f, 565.8653f, 188.8128f)); fHeading.Add(166.2484f);
                Pos_01.Add(new Vector3(-122.5135f, 571.5621f, 194.6613f)); fHeading.Add(180.1518f);
                Pos_01.Add(new Vector3(298.9084f, 463.998f, 141.1974f)); fHeading.Add(177.8186f);
                Pos_01.Add(new Vector3(283.5058f, 501.5374f, 146.2818f)); fHeading.Add(272.0558f);
                Pos_01.Add(new Vector3(294.0867f, 530.4378f, 150.9946f)); fHeading.Add(147.5757f);
                Pos_01.Add(new Vector3(242.9051f, 639.3737f, 184.2167f)); fHeading.Add(174.0911f);
                Pos_01.Add(new Vector3(184.7669f, 551.7874f, 178.1748f)); fHeading.Add(161.2797f);
                Pos_01.Add(new Vector3(91.22596f, 535.8976f, 171.8904f)); fHeading.Add(191.2823f);
                Pos_01.Add(new Vector3(52.97155f, 533.974f, 173.7988f)); fHeading.Add(98.56342f);
                Pos_01.Add(new Vector3(223.5663f, 481.628f, 138.9433f)); fHeading.Add(186.0741f);
                Pos_01.Add(new Vector3(154.6444f, 479.0873f, 140.5918f)); fHeading.Add(229.5701f);
                Pos_01.Add(new Vector3(150.1482f, 456.2213f, 139.5088f)); fHeading.Add(192.9131f);
                Pos_01.Add(new Vector3(100.1431f, 439.8868f, 140.4936f)); fHeading.Add(240.5627f);
                Pos_01.Add(new Vector3(24.01077f, 431.562f, 141.2572f)); fHeading.Add(191.9438f);
                Pos_01.Add(new Vector3(-72.6179f, 465.5805f, 135.9239f)); fHeading.Add(76.12296f);
                Pos_01.Add(new Vector3(-123.3051f, 484.7867f, 135.2343f)); fHeading.Add(277.5651f);
                Pos_01.Add(new Vector3(-181.1604f, 481.0771f, 132.1258f)); fHeading.Add(173.1447f);
                Pos_01.Add(new Vector3(-240.873f, 462.7502f, 124.9531f)); fHeading.Add(265.0873f);
                Pos_01.Add(new Vector3(-280.4801f, 455.5736f, 108.9758f)); fHeading.Add(11.24059f);
                Pos_01.Add(new Vector3(-151.0757f, 397.4683f, 109.3303f)); fHeading.Add(102.5608f);
                Pos_01.Add(new Vector3(-195.848f, 375.325f, 107.4195f)); fHeading.Add(118.4353f);
                Pos_01.Add(new Vector3(-250.1479f, 349.482f, 108.4312f)); fHeading.Add(257.0241f);
                Pos_01.Add(new Vector3(-312.6213f, 338.596f, 108.3876f)); fHeading.Add(270.0114f);
                Pos_01.Add(new Vector3(-305.1698f, 404.4672f, 107.9418f)); fHeading.Add(19.61601f);
                Pos_01.Add(new Vector3(-361.4859f, 388.3761f, 110.2353f)); fHeading.Add(296.8794f);
                Pos_01.Add(new Vector3(-427.2299f, 374.5766f, 106.6869f)); fHeading.Add(346.4425f);
                Pos_01.Add(new Vector3(-495.9285f, 379.7473f, 100.1044f)); fHeading.Add(110.8691f);
                Pos_01.Add(new Vector3(259.914f, 768.7663f, 198.1667f)); fHeading.Add(171.6786f);
                Pos_01.Add(new Vector3(-82.69418f, 951.5432f, 231.5304f)); fHeading.Add(4.040697f);
                Pos_01.Add(new Vector3(-53.98798f, 801.733f, 225.2128f)); fHeading.Add(198.7475f);
                Pos_01.Add(new Vector3(-158.4015f, 872.744f, 231.239f)); fHeading.Add(281.8446f);
                Pos_01.Add(new Vector3(-203.0339f, 993.9344f, 229.9067f)); fHeading.Add(170.5246f);
                Pos_01.Add(new Vector3(261.3582f, 53.34766f, 86.86005f)); fHeading.Add(112.5693f);
                Pos_01.Add(new Vector3(-9.255273f, -33.10223f, 67.3112f)); fHeading.Add(170.3541f);
                Pos_01.Add(new Vector3(-118.0738f, 15.28374f, 67.68005f)); fHeading.Add(185.8164f);
                Pos_01.Add(new Vector3(-55.54819f, 112.7238f, 79.84457f)); fHeading.Add(36.34098f);
                Pos_01.Add(new Vector3(-16.14182f, 348.6998f, 111.2587f)); fHeading.Add(185.8422f);
                Pos_01.Add(new Vector3(512.7614f, 214.5401f, 102.8892f)); fHeading.Add(79.30675f);
                Pos_01.Add(new Vector3(-303.4641f, 163.318f, 86.68427f)); fHeading.Add(195.2101f);
                Pos_01.Add(new Vector3(-477.1502f, 182.252f, 82.03768f)); fHeading.Add(79.51382f);
                Pos_01.Add(new Vector3(-96.92668f, -342.335f, 40.3636f)); fHeading.Add(227.6679f);
                Pos_01.Add(new Vector3(96.90714f, -246.5079f, 45.79247f)); fHeading.Add(219.79f);
                Pos_01.Add(new Vector3(78.0203f, -240.652f, 46.40194f)); fHeading.Add(253.2796f);
                Pos_01.Add(new Vector3(333.0154f, -195.3859f, 52.50391f)); fHeading.Add(224.6233f);
                Pos_01.Add(new Vector3(955.6845f, -687.8796f, 55.86848f)); fHeading.Add(146.0258f);
                Pos_01.Add(new Vector3(912.7341f, -654.8762f, 56.21679f)); fHeading.Add(275.1885f);
                Pos_01.Add(new Vector3(903.1922f, -641.8429f, 56.5079f)); fHeading.Add(73.38454f);
                Pos_01.Add(new Vector3(873.175f, -613.0998f, 56.6581f)); fHeading.Add(357.458f);
                Pos_01.Add(new Vector3(839.5805f, -580.3686f, 55.49578f)); fHeading.Add(321.4151f);
                Pos_01.Add(new Vector3(825.0772f, -521.6014f, 54.95789f)); fHeading.Add(119.8508f);
                Pos_01.Add(new Vector3(896.8047f, -466.8496f, 57.32214f)); fHeading.Add(207.8782f);
                Pos_01.Add(new Vector3(917.1431f, -457.6846f, 59.27655f)); fHeading.Add(119.2411f);
                Pos_01.Add(new Vector3(932.3779f, -448.6634f, 59.52022f)); fHeading.Add(296.9828f);
                Pos_01.Add(new Vector3(954.8691f, -441.865f, 61.23558f)); fHeading.Add(47.42667f);
                Pos_01.Add(new Vector3(968.7847f, -432.1448f, 62.18409f)); fHeading.Add(211.815f);
                Pos_01.Add(new Vector3(1425.48f, 1154.443f, 113.2876f)); fHeading.Add(90.80857f);
            }           //Pool Peds   
            else if (iSelect == 18)
            {
                RandomWeatherTime();

                iSubSet = FindRandom(6, 1, 23);
                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(1138.573f, -785.1884f, 57.59872f)); fHeading.Add(167.1082f);
                    Pos_01.Add(new Vector3(544.0156f, -173.4207f, 54.48134f)); fHeading.Add(340.1063f);
                    Pos_01.Add(new Vector3(2515.484f, 4217.121f, 39.929f)); fHeading.Add(144.665f);
                    Pos_01.Add(new Vector3(-67.9494f, 6432.331f, 31.48058f)); fHeading.Add(326.9482f);
                    Pos_01.Add(new Vector3(255.0459f, 2582.047f, 45.13689f)); fHeading.Add(307.621f);
                    Pos_01.Add(new Vector3(1993.807f, 3793.491f, 32.18077f)); fHeading.Add(215.6984f);
                    Pos_01.Add(new Vector3(1688.451f, 3286.147f, 41.14651f)); fHeading.Add(66.41962f);
                    Pos_01.Add(new Vector3(2343.264f, 3114.95f, 48.2087f)); fHeading.Add(152.7309f);
                    Pos_01.Add(new Vector3(-82.67906f, -1325.488f, 29.27505f)); fHeading.Add(339.8256f);
                    Pos_01.Add(new Vector3(-22.95398f, -1674.278f, 29.49172f)); fHeading.Add(324.6906f);
                    Pos_01.Add(new Vector3(1181.487f, 2636.379f, 37.7949f)); fHeading.Add(147.4034f);
                    Pos_01.Add(new Vector3(107.9624f, 6629.401f, 31.78723f)); fHeading.Add(34.92216f);
                }       //"Autoshop Worker 2"); 
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(-3022.146f, 39.75996f, 10.11778f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1982.751f, 3053.365f, 47.21507f)); fHeading.Add(237.2689f);
                }       //"Waiter") ; 
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(1736.674f, -1609.645f, 112.4697f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1561.137f, -2133.279f, 77.4785f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1459.511f, -1935.92f, 71.30696f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1455.132f, -1682.857f, 66.06307f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1193.554f, -1240.154f, 36.32576f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1122.821f, -1303.704f, 34.71646f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(994.2419f, -1555.895f, 30.75485f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(918.1321f, -1516.955f, 30.96606f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(903.4687f, -1590.887f, 30.22392f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(804.6454f, -1666.87f, 30.86449f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(746.9606f, -1862.089f, 29.29224f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1025.895f, -1686.251f, 33.57116f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(928.8152f, -1726.541f, 32.15963f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(897.4868f, -1864.518f, 30.61937f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1087.357f, -1970.058f, 31.01467f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(973.9832f, -1978.706f, 30.63801f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(890.3286f, -2001.457f, 30.61759f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(953.8917f, -2117.238f, 30.55156f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(879.512f, -2166.26f, 32.27139f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(840.3463f, -2292.076f, 30.51253f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(864.4549f, -2361.586f, 31.51551f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(943.5316f, -2169.565f, 30.5664f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1002.891f, -2161.235f, 30.55158f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1041.598f, -2170.343f, 31.50933f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1019.803f, -2381.706f, 30.49956f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1095.563f, -2227.028f, 31.304f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1091.22f, -2279.994f, 30.14508f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1083.314f, -2413.066f, 30.23936f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(923.9042f, -2533.111f, 28.30268f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1211.444f, -3103.413f, 6.027918f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1195.812f, -3254.429f, 7.095187f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(755.6094f, -3181.837f, 7.405778f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(821.003f, -3196.436f, 5.900819f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(814.2813f, -2982.313f, 6.02089f)); fHeading.Add(251.9171f);
                }       //"Sweatshop Worker  
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(1727.791f, 6415.5f, 35.03722f)); fHeading.Add(236.6747f);
                    Pos_01.Add(new Vector3(1697.339f, 4923.185f, 42.06368f)); fHeading.Add(320.4615f);
                    Pos_01.Add(new Vector3(1959.632f, 3740.195f, 32.34374f)); fHeading.Add(296.0751f);
                    Pos_01.Add(new Vector3(2677.702f, 3279.555f, 55.23104f)); fHeading.Add(354.9082f);
                    Pos_01.Add(new Vector3(1392.897f, 3606.55f, 34.98093f)); fHeading.Add(181.8305f);
                    Pos_01.Add(new Vector3(549.17f, 2671.394f, 42.15946f)); fHeading.Add(80.96091f);
                    Pos_01.Add(new Vector3(1165.094f, 2711.289f, 38.15771f)); fHeading.Add(167.705f);
                    Pos_01.Add(new Vector3(2557.217f, 380.7556f, 108.6229f)); fHeading.Add(349.9854f);
                    Pos_01.Add(new Vector3(-3039.342f, 584.2296f, 7.908843f)); fHeading.Add(18.4436f);
                    Pos_01.Add(new Vector3(-2965.881f, 391.8284f, 15.04331f)); fHeading.Add(84.51514f);
                    Pos_01.Add(new Vector3(-1819.316f, 793.3266f, 138.0849f)); fHeading.Add(128.9414f);
                    Pos_01.Add(new Vector3(-1220.953f, -908.2629f, 12.32635f)); fHeading.Add(31.62823f);
                    Pos_01.Add(new Vector3(-706.053f, -914.5494f, 19.21514f)); fHeading.Add(82.03596f);
                    Pos_01.Add(new Vector3(-47.39658f, -1758.836f, 29.42102f)); fHeading.Add(28.16017f);
                    Pos_01.Add(new Vector3(24.2935f, -1347.371f, 29.48629f)); fHeading.Add(278.3273f);
                    Pos_01.Add(new Vector3(372.4779f, 326.4888f, 103.5664f)); fHeading.Add(251.1972f);
                    Pos_01.Add(new Vector3(1165.163f, -323.1492f, 69.20242f)); fHeading.Add(101.1147f);
                    Pos_01.Add(new Vector3(1133.975f, -983.3416f, 46.4158f)); fHeading.Add(285.5776f);
                }       //"Shopkeeper (Male)"); 
                else if (iSubSet == 5)
                {
                    Pos_01.Add(new Vector3(-498.4334f, -336.1266f, 34.50177f)); fHeading.Add(260.0309f);
                    Pos_01.Add(new Vector3(-448.8101f, -340.8905f, 34.50174f)); fHeading.Add(71.48569f);
                    Pos_01.Add(new Vector3(-444.4344f, -360.8369f, 33.49535f)); fHeading.Add(202.3012f);
                    Pos_01.Add(new Vector3(-507.7543f, -350.8057f, 35.20736f)); fHeading.Add(175.4921f);
                    Pos_01.Add(new Vector3(299.0754f, -584.7549f, 43.26083f)); fHeading.Add(31.88034f);
                    Pos_01.Add(new Vector3(355.4822f, -596.1416f, 28.77366f)); fHeading.Add(243.7838f);
                    Pos_01.Add(new Vector3(343.2381f, -1398.023f, 32.50926f)); fHeading.Add(56.42395f);
                    Pos_01.Add(new Vector3(295.1708f, -1449.108f, 29.9666f)); fHeading.Add(342.1343f);
                    Pos_01.Add(new Vector3(391.0455f, -1432.821f, 29.43532f)); fHeading.Add(246.2128f);
                    Pos_01.Add(new Vector3(1102.689f, -1529.41f, 34.89371f)); fHeading.Add(191.0677f);
                    Pos_01.Add(new Vector3(1151.229f, -1529.005f, 35.18423f)); fHeading.Add(319.4206f);
                    Pos_01.Add(new Vector3(1816.119f, 3679.592f, 34.27674f)); fHeading.Add(46.59311f);
                    Pos_01.Add(new Vector3(1827.241f, 3692.945f, 34.22424f)); fHeading.Add(30.81271f);
                    Pos_01.Add(new Vector3(-246.6019f, 6331.854f, 32.42619f)); fHeading.Add(215.443f);
                }       //"Doctor"); 
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(74.20151f, -1028.342f, 29.47368f)); fHeading.Add(213.4145f);
                    Pos_01.Add(new Vector3(-775.8405f, -2235.184f, 5.935775f)); fHeading.Add(59.81636f);
                    Pos_01.Add(new Vector3(-821.5007f, -2103.311f, 8.960504f)); fHeading.Add(353.6512f);
                    Pos_01.Add(new Vector3(-70.87366f, 358.9036f, 112.4451f)); fHeading.Add(227.5854f);
                    Pos_01.Add(new Vector3(-33.33993f, 363.8051f, 113.908f)); fHeading.Add(136.6148f);
                    Pos_01.Add(new Vector3(18.42962f, 341.8936f, 115.3874f)); fHeading.Add(144.6268f);
                    Pos_01.Add(new Vector3(-1275.37f, 374.1922f, 77.58377f)); fHeading.Add(355.0824f);
                }       //"Maid
                else if (iSubSet == 7)
                {
                    Pos_01.Add(new Vector3(-117.671f, 6448.627f, 31.05948f)); fHeading.Add(134.7083f);
                    Pos_01.Add(new Vector3(2550.519f, 342.6139f, 108.0741f)); fHeading.Add(87.43266f);
                    Pos_01.Add(new Vector3(1064.405f, -1728.37f, 35.19252f)); fHeading.Add(200.746f);
                    Pos_01.Add(new Vector3(952.5815f, -2080.921f, 30.33508f)); fHeading.Add(83.92099f);
                    Pos_01.Add(new Vector3(163.1477f, -1608.789f, 28.95174f)); fHeading.Add(301.8476f);
                    Pos_01.Add(new Vector3(-1252.114f, -865.7639f, 11.98873f)); fHeading.Add(217.2558f);
                    Pos_01.Add(new Vector3(-2201.217f, -356.3726f, 12.75363f)); fHeading.Add(266.5727f);
                    Pos_01.Add(new Vector3(-1073.944f, -182.7193f, 37.54315f)); fHeading.Add(242.3141f);
                    Pos_01.Add(new Vector3(-742.4987f, -262.4792f, 36.55564f)); fHeading.Add(21.95997f);
                    Pos_01.Add(new Vector3(-302.9223f, -372.287f, 29.59321f)); fHeading.Add(233.3253f);
                    Pos_01.Add(new Vector3(96.73369f, -167.1032f, 54.54427f)); fHeading.Add(71.51151f);
                    Pos_01.Add(new Vector3(173.5536f, -846.8428f, 30.61277f)); fHeading.Add(339.7813f);
                    iEnterVeh = 9;

                    iAction = 1;
                }       //"Armoured Van Security 2"); 
                else if (iSubSet == 8)
                {
                    Pos_01.Add(new Vector3(2572.041f, 2718.056f, 42.16391f)); fHeading.Add(129.5934f);
                    Pos_01.Add(new Vector3(1219.512f, 2393.812f, 65.47562f)); fHeading.Add(172.7095f);
                    Pos_01.Add(new Vector3(818.2979f, 2367.369f, 51.38051f)); fHeading.Add(166.84f);
                    Pos_01.Add(new Vector3(2676.273f, 1611.337f, 23.99239f)); fHeading.Add(270.9893f);
                    Pos_01.Add(new Vector3(-129.5193f, -2175.594f, 9.808171f)); fHeading.Add(107.5226f);
                    Pos_01.Add(new Vector3(126.0953f, -2537.874f, 5.492153f)); fHeading.Add(90.73464f);
                    Pos_01.Add(new Vector3(641.3249f, -3010.168f, 5.719178f)); fHeading.Add(1.711147f);
                    Pos_01.Add(new Vector3(817.7762f, -3144.448f, 5.393185f)); fHeading.Add(184.152f);
                    Pos_01.Add(new Vector3(1894.648f, -1021.06f, 78.08004f)); fHeading.Add(168.9922f);
                    iEnterVeh = 1;

                    iAction = 1;
                }       //"Security Guard"); 
                else if (iSubSet == 9)
                {
                    Pos_01.Add(new Vector3(2137.336f, 2906.663f, 59.76971f)); fHeading.Add(55.80349f);
                    Pos_01.Add(new Vector3(2122.384f, 2921.195f, 50.91202f)); fHeading.Add(320.7472f);
                    Pos_01.Add(new Vector3(2078.61f, 2945.86f, 56.4167f)); fHeading.Add(181.6763f);
                    Pos_01.Add(new Vector3(2044.698f, 2944.561f, 60.02338f)); fHeading.Add(282.4404f);
                    Pos_01.Add(new Vector3(2008.205f, 2932.849f, 59.47688f)); fHeading.Add(259.2144f);
                    Pos_01.Add(new Vector3(1965.265f, 2918.207f, 56.1685f)); fHeading.Add(159.0523f);
                }        //"Scientist");  
                else if (iSubSet == 10)
                {
                    Pos_01.Add(new Vector3(2751.409f, 1467.832f, 49.05055f)); fHeading.Add(70.61932f);
                    Pos_01.Add(new Vector3(2794.029f, 1673.659f, 20.78217f)); fHeading.Add(172.1612f);
                    Pos_01.Add(new Vector3(2733.363f, 1581.026f, 66.53803f)); fHeading.Add(3.543856f);
                    Pos_01.Add(new Vector3(2739.592f, 1544.221f, 42.89051f)); fHeading.Add(237.7711f);
                    Pos_01.Add(new Vector3(2748.854f, 1505.891f, 38.28401f)); fHeading.Add(152.154f);
                    Pos_01.Add(new Vector3(2664.208f, 1477.163f, 35.2615f)); fHeading.Add(34.45109f);
                    Pos_01.Add(new Vector3(2702.427f, 1483.406f, 44.4654f)); fHeading.Add(81.48576f);
                    Pos_01.Add(new Vector3(2716.197f, 1500.537f, 42.24483f)); fHeading.Add(179.7581f);
                    Pos_01.Add(new Vector3(2772.207f, 1518.493f, 30.77918f)); fHeading.Add(257.5858f);
                    Pos_01.Add(new Vector3(2801.599f, 1454.122f, 34.34266f)); fHeading.Add(111.4636f);
                }       //"Chemical Plant Worker");  
                else if (iSubSet == 11)
                {
                    if (BoolList(9))
                    {
                        Pos_01.Add(new Vector3(2368.954f, 2191.936f, 142.1283f)); fHeading.Add(177.7558f);
                        Pos_01.Add(new Vector3(941.1194f, 2420.352f, 80.66275f)); fHeading.Add(354.4607f);
                        Pos_01.Add(new Vector3(1063.921f, 2295.801f, 79.65724f)); fHeading.Add(54.34263f);
                        Pos_01.Add(new Vector3(1132.265f, 2170.632f, 87.40754f)); fHeading.Add(148.2799f);
                        Pos_01.Add(new Vector3(-119.0797f, -977.1749f, 304.2491f)); fHeading.Add(195.5221f);
                        Pos_01.Add(new Vector3(-130.3379f, -995.1433f, 73.26834f)); fHeading.Add(6.456776f);
                        Pos_01.Add(new Vector3(-207.2522f, -1116.536f, 65.29741f)); fHeading.Add(127.4257f);
                        Pos_01.Add(new Vector3(-471.007f, -1082.965f, 69.37054f)); fHeading.Add(2.687505f);
                        Pos_01.Add(new Vector3(-461.0444f, -975.177f, 77.44084f)); fHeading.Add(24.04421f);
                        Pos_01.Add(new Vector3(-662.969f, 216.808f, 156.3536f)); fHeading.Add(277.3127f);
                        Pos_01.Add(new Vector3(46.32523f, -459.1702f, 107.9676f)); fHeading.Add(47.79955f);
                        Pos_01.Add(new Vector3(140.8991f, -344.787f, 102.6311f)); fHeading.Add(158.7348f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-450.5587f, -1036.252f, 23.09341f)); fHeading.Add(39.48218f);
                        Pos_01.Add(new Vector3(-490.6296f, -942.8484f, 23.51029f)); fHeading.Add(147.3915f);
                        Pos_01.Add(new Vector3(-149.3207f, -959.513f, 20.82236f)); fHeading.Add(160.9155f);
                        Pos_01.Add(new Vector3(-132.5916f, -1098.141f, 21.23154f)); fHeading.Add(132.2186f);
                        Pos_01.Add(new Vector3(98.88792f, -450.8947f, 41.56817f)); fHeading.Add(342.08f);
                        Pos_01.Add(new Vector3(104.5644f, -349.3134f, 41.93143f)); fHeading.Add(94.52675f);
                        iEnterVeh = 9;

                        iAction = 1;
                    }
                }       //"construction Worker 2"); 
                else if (iSubSet == 12)
                {
                    if (BoolList(10))
                    {
                        Pos_01.Add(new Vector3(944.6815f, -2933.804f, 49.12353f)); fHeading.Add(289.2962f);
                        Pos_01.Add(new Vector3(1011.372f, -2896.42f, 39.15219f)); fHeading.Add(172.0232f);
                        Pos_01.Add(new Vector3(970.7809f, -2933.85f, 49.11639f)); fHeading.Add(91.70227f);
                        Pos_01.Add(new Vector3(1157.055f, -2860.837f, 43.28324f)); fHeading.Add(1.263969f);
                        Pos_01.Add(new Vector3(1227.453f, -2903.619f, 13.32729f)); fHeading.Add(58.2732f);
                        Pos_01.Add(new Vector3(1289.939f, -3100.061f, 26.75886f)); fHeading.Add(181.0756f);
                        Pos_01.Add(new Vector3(1296.828f, -3301.1f, 24.38335f)); fHeading.Add(187.5255f);
                        Pos_01.Add(new Vector3(1137.943f, -3191.236f, 24.14786f)); fHeading.Add(185.3562f);
                        Pos_01.Add(new Vector3(905.3866f, -3279.862f, 24.22781f)); fHeading.Add(173.9265f);
                        Pos_01.Add(new Vector3(839.6215f, -3086.641f, 23.10469f)); fHeading.Add(196.4139f);
                        Pos_01.Add(new Vector3(951.5082f, -2964.539f, 23.07471f)); fHeading.Add(54.88553f);
                        Pos_01.Add(new Vector3(1056.643f, -3033.763f, 23.08432f)); fHeading.Add(280.4692f);
                        Pos_01.Add(new Vector3(1170.038f, -2963.04f, 19.98134f)); fHeading.Add(1.24316f);
                        Pos_01.Add(new Vector3(1167.413f, -3020.839f, 24.18315f)); fHeading.Add(348.2981f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-326.8799f, -2617.591f, 5.603117f)); fHeading.Add(135.2283f);
                        Pos_01.Add(new Vector3(-505.1059f, -2765.766f, 5.612922f)); fHeading.Add(314.6254f);
                        Pos_01.Add(new Vector3(-301.3838f, -2419.142f, 5.613175f)); fHeading.Add(146.1276f);
                        Pos_01.Add(new Vector3(-117.8903f, -2660.294f, 5.618917f)); fHeading.Add(358.9177f);
                        Pos_01.Add(new Vector3(266.0363f, -2996.771f, 5.346468f)); fHeading.Add(171.727f);
                        Pos_01.Add(new Vector3(517.1625f, -2951.327f, 5.654205f)); fHeading.Add(268.6839f);
                        Pos_01.Add(new Vector3(924.679f, -3009.876f, 5.503459f)); fHeading.Add(270.0103f);
                        Pos_01.Add(new Vector3(1031.972f, -2914.75f, 5.50889f)); fHeading.Add(79.1702f);
                        Pos_01.Add(new Vector3(1261.785f, -3094.253f, 5.51305f)); fHeading.Add(34.06389f);
                        Pos_01.Add(new Vector3(1044.572f, -3237.142f, 5.503559f)); fHeading.Add(91.10924f);
                        iEnterVeh = 9;

                        iAction = 1;
                    }
                }       //"Dock Worker");  
                else if (iSubSet == 13)
                {
                    Pos_01.Add(new Vector3(-1260.416f, -2465.789f, 13.53846f)); fHeading.Add(150.3708f);
                    Pos_01.Add(new Vector3(-1136.307f, -2565.843f, 13.54877f)); fHeading.Add(239.837f);
                    Pos_01.Add(new Vector3(-1247.719f, -2759.173f, 13.5597f)); fHeading.Add(150.0197f);
                    Pos_01.Add(new Vector3(-1774.23f, -2806.793f, 13.54927f)); fHeading.Add(153.7328f);
                    Pos_01.Add(new Vector3(-1647.934f, -3128.432f, 13.60499f)); fHeading.Add(285.4133f);
                    Pos_01.Add(new Vector3(-1262.489f, -3376.311f, 13.55233f)); fHeading.Add(330.3223f);
                    Pos_01.Add(new Vector3(-965.5756f, -3007.905f, 13.5535f)); fHeading.Add(28.93888f);
                    iEnterVeh = 9;

                    iAction = 1;
                    bRequestPB = true;
                }       //Airport
                else if (iSubSet == 14)
                {
                    Pos_01.Add(new Vector3(-304.5138f, -1544.802f, 25.85103f)); fHeading.Add(154.0407f);
                    iAction = 1;
                    iEnterVeh = 10;
                }       //"Garbage Worker");  
                else if (iSubSet == 15)
                {
                    Pos_01.Add(new Vector3(833.5146f, -280.2225f, 66.37661f)); fHeading.Add(239.6148f);
                    Pos_01.Add(new Vector3(1075.906f, -684.5606f, 57.71888f)); fHeading.Add(30.70767f);
                    Pos_01.Add(new Vector3(-916.4821f, -111.1297f, 37.96105f)); fHeading.Add(295.2327f);
                    Pos_01.Add(new Vector3(-114.3289f, -394.8227f, 35.97801f)); fHeading.Add(252.818f);
                    Pos_01.Add(new Vector3(-1670.235f, -600.6372f, 33.82233f)); fHeading.Add(66.71965f);
                    Pos_01.Add(new Vector3(-809.2332f, -915.7718f, 18.17719f)); fHeading.Add(346.4547f);
                    Pos_01.Add(new Vector3(-900.3068f, -860.772f, 16.3537f)); fHeading.Add(214.3627f);
                    Pos_01.Add(new Vector3(-1714.627f, -258.9235f, 52.60183f)); fHeading.Add(141.2126f);
                    iAction = 5;
                }       //"Latino Handyman Male"); 
                else if (iSubSet == 16)
                {
                    Pos_01.Add(new Vector3(117.6408f, -1729.686f, 30.11062f)); fHeading.Add(145.3675f);
                    Pos_01.Add(new Vector3(-207.5786f, -1017.771f, 30.13827f)); fHeading.Add(137.811f);
                    Pos_01.Add(new Vector3(-500.6882f, -660.5969f, 20.03399f)); fHeading.Add(176.1281f);
                    Pos_01.Add(new Vector3(-1340.413f, -459.3785f, 23.27035f)); fHeading.Add(118.5435f);
                    Pos_01.Add(new Vector3(-810.3533f, -148.9955f, 28.17534f)); fHeading.Add(18.19424f);
                    Pos_01.Add(new Vector3(-306.8699f, -329.439f, 18.28813f)); fHeading.Add(276.2242f);
                    Pos_01.Add(new Vector3(247.4429f, -1204.116f, 38.92488f)); fHeading.Add(293.6903f);
                    Pos_01.Add(new Vector3(-533.9517f, -1267.302f, 26.9016f)); fHeading.Add(140.6523f);
                    Pos_01.Add(new Vector3(-871.7253f, -2321.781f, -3.507766f)); fHeading.Add(55.49453f);
                    Pos_01.Add(new Vector3(-1093.533f, -2709.069f, 0.8148932f)); fHeading.Add(232.3231f);
                }       //"LS Metro Worker Male");  
                else if (iSubSet == 17)
                {
                    Pos_01.Add(new Vector3(772.4866f, -941.0552f, 25.69374f)); fHeading.Add(174.2538f);
                    Pos_01.Add(new Vector3(784.7866f, -778.5135f, 26.37265f)); fHeading.Add(359.7194f);
                    Pos_01.Add(new Vector3(805.5536f, -1353.864f, 26.34939f)); fHeading.Add(1.794775f);
                    Pos_01.Add(new Vector3(438.6497f, -2028.266f, 23.40673f)); fHeading.Add(222.4093f);
                    Pos_01.Add(new Vector3(-252.9165f, -881.4698f, 30.71332f)); fHeading.Add(250.5484f);
                    Pos_01.Add(new Vector3(-562.1918f, -844.0425f, 27.27311f)); fHeading.Add(268.5222f);
                    Pos_01.Add(new Vector3(-1166.271f, -401.646f, 35.44949f)); fHeading.Add(98.17386f);
                    Pos_01.Add(new Vector3(-1483.472f, -634.3616f, 30.36706f)); fHeading.Add(305.0129f);
                    Pos_01.Add(new Vector3(-1407.018f, -570.2193f, 30.32949f)); fHeading.Add(118.4672f);
                    Pos_01.Add(new Vector3(-1523.434f, -465.9171f, 35.33706f)); fHeading.Add(121.1337f);
                    Pos_01.Add(new Vector3(-741.6723f, -753.1192f, 26.65259f)); fHeading.Add(1.035129f);
                    Pos_01.Add(new Vector3(-709.4644f, -828.9621f, 23.4892f)); fHeading.Add(87.2354f);
                    Pos_01.Add(new Vector3(-693.6379f, -667.7115f, 30.77847f)); fHeading.Add(267.3748f);
                    Pos_01.Add(new Vector3(-507.1399f, -667.337f, 33.0463f)); fHeading.Add(269.1283f);
                    Pos_01.Add(new Vector3(118.4946f, -786.554f, 31.31796f)); fHeading.Add(68.02338f);
                    Pos_01.Add(new Vector3(459.9696f, -634.295f, 28.49378f)); fHeading.Add(32.34509f);
                    iEnterVeh = 3;
                    iAction = 1;
                }       //"Transport Worker Male");  
                else if (iSubSet == 18)
                {
                    Pos_01.Add(new Vector3(139.4768f, -3103.723f, 5.89631f)); fHeading.Add(353.8674f);
                }       //"Pest Control");  
                else if (iSubSet == 19)
                {
                    if (BoolList(11))
                    {
                        Pos_01.Add(new Vector3(126.8316f, 217.908f, 107.2581f)); fHeading.Add(250.0984f);
                        Pos_01.Add(new Vector3(-63.64765f, 38.78681f, 72.05331f)); fHeading.Add(246.6971f);
                        Pos_01.Add(new Vector3(-306.1648f, 253.3288f, 87.87576f)); fHeading.Add(286.7962f);
                        Pos_01.Add(new Vector3(-433.5657f, 5.962925f, 46.09057f)); fHeading.Add(86.90429f);
                        Pos_01.Add(new Vector3(-630.7167f, 752.2339f, 178.5925f)); fHeading.Add(66.96705f);
                        Pos_01.Add(new Vector3(-1191.528f, -1263.148f, 6.772604f)); fHeading.Add(19.49872f);
                        Pos_01.Add(new Vector3(-996.5602f, -1131.017f, 2.042427f)); fHeading.Add(31.10395f);
                        iEnterVeh = 1;

                        iAction = 1;
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(85.46738f, 107.2592f, 79.16206f)); fHeading.Add(28.6738f);
                    }
                }       //"Postal Worker Male 2");  
                else if (iSubSet == 20)
                {
                    if (BoolList(12))
                    {
                        Pos_01.Add(new Vector3(775.7664f, -983.2467f, 26.1865f)); fHeading.Add(179.6391f);
                        Pos_01.Add(new Vector3(970.2875f, -1458.307f, 31.24547f)); fHeading.Add(357.9949f);
                        Pos_01.Add(new Vector3(908.9388f, -1758.108f, 30.55537f)); fHeading.Add(82.37654f);
                        Pos_01.Add(new Vector3(708.7218f, -2064.523f, 29.24054f)); fHeading.Add(266.0231f);
                        Pos_01.Add(new Vector3(899.3294f, -2427.047f, 28.41091f)); fHeading.Add(170.9303f);
                        Pos_01.Add(new Vector3(626.4791f, -2650.233f, 6.002013f)); fHeading.Add(25.25125f);
                        Pos_01.Add(new Vector3(171.0083f, -2567.712f, 5.877536f)); fHeading.Add(134.8465f);
                        Pos_01.Add(new Vector3(6.724895f, -2075.361f, 10.17716f)); fHeading.Add(357.7553f);
                        iEnterVeh = 1;

                        iAction = 1;
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-421.5688f, 6136.129f, 31.87731f)); fHeading.Add(151.091f);
                        Pos_01.Add(new Vector3(1194.111f, -3249.756f, 7.095187f)); fHeading.Add(24.04957f);
                        Pos_01.Add(new Vector3(-470.9116f, -2826.893f, 7.295931f)); fHeading.Add(111.9151f);
                    }
                }       //"UPS Driver 2");
                else if (iSubSet == 21)
                {
                    Pos_01.Add(new Vector3(-1692.355f, -1136.184f, 13.1523f)); fHeading.Add(7.620972f);
                    Pos_01.Add(new Vector3(-1682.627f, -1124.328f, 13.15217f)); fHeading.Add(156.3842f);
                    Pos_01.Add(new Vector3(-1638.467f, -1083.328f, 13.07891f)); fHeading.Add(250.2687f);
                    Pos_01.Add(new Vector3(-1630.095f, -1075.994f, 13.06109f)); fHeading.Add(170.5576f);
                    Pos_01.Add(new Vector3(-1693.571f, -1072.634f, 13.01736f)); fHeading.Add(40.26046f);
                    Pos_01.Add(new Vector3(-1720.081f, -1103.823f, 13.01784f)); fHeading.Add(88.03056f);
                    Pos_01.Add(new Vector3(-1772.086f, -1160.577f, 13.01805f)); fHeading.Add(113.3456f);
                    Pos_01.Add(new Vector3(-1784.682f, -1175.788f, 13.01775f)); fHeading.Add(52.88898f);
                    Pos_01.Add(new Vector3(-1835.216f, -1233.972f, 13.01727f)); fHeading.Add(10.32578f);
                    Pos_01.Add(new Vector3(-1856.75f, -1224.386f, 13.01728f)); fHeading.Add(322.1722f);
                }       //"Street Vendor Young");  
                else if (iSubSet == 22)
                {
                    Pos_01.Add(new Vector3(-663.5873f, -183.1233f, 37.67239f)); fHeading.Add(130.6762f);
                }       //"Valet");  
                else if (iSubSet == 23)
                {
                    Pos_01.Add(new Vector3(-74.24763f, -837.0442f, 318.9297f)); fHeading.Add(167.2113f);
                    Pos_01.Add(new Vector3(-148.4851f, -611.0936f, 204.009f)); fHeading.Add(36.52973f);
                    Pos_01.Add(new Vector3(-100.5659f, -548.9984f, 173.528f)); fHeading.Add(326.2725f);
                    Pos_01.Add(new Vector3(162.6209f, -730.3214f, 255.4475f)); fHeading.Add(158.5101f);
                    Pos_01.Add(new Vector3(129.6409f, -720.5817f, 263.644f)); fHeading.Add(353.4834f);
                    Pos_01.Add(new Vector3(102.8595f, -643.2682f, 263.6401f)); fHeading.Add(261.434f);
                }       //"Window Cleaner");  
            }           //Workers  
            else if (iSelect == 19)
            {
                World.Weather = Weather.ExtraSunny;

                World.CurrentDayTime = TimeSpan.FromHours(12);

                Pos_01.Add(new Vector3(212.627f, 3630.045f, 29.9478f)); fHeading.Add(165.2639f);
                Pos_01.Add(new Vector3(3424.472f, 5193.411f, 0.6613104f)); fHeading.Add(275.3657f);
                Pos_01.Add(new Vector3(3067.812f, 638.7896f, 0.3254618f)); fHeading.Add(354.6844f);
                Pos_01.Add(new Vector3(628.3226f, -2122.594f, -0.06220001f)); fHeading.Add(174.2746f);
                iAction = 1;

                iEnterVeh = 9;
            }           //jet ski Male                  
            else if (iSelect == 20)
            {
                World.Weather = Weather.ExtraSunny;

                World.CurrentDayTime = TimeSpan.FromHours(12);

                iSubSet = FindRandom(7, 1, 4);

                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(-1573.766f, 3090.736f, 30.70401f)); fHeading.Add(7.923703f);
                    Pos_01.Add(new Vector3(-1612.333f, 3194.164f, 29.70836f)); fHeading.Add(24.25381f);
                    Pos_01.Add(new Vector3(-1627.943f, 3187.001f, 29.59254f)); fHeading.Add(169.4351f);
                    Pos_01.Add(new Vector3(-1596.471f, 3146.43f, 29.75003f)); fHeading.Add(216.409f);
                    Pos_01.Add(new Vector3(-1578.321f, 2938.288f, 32.46555f)); fHeading.Add(193.4308f);
                    Pos_01.Add(new Vector3(-1447.88f, 2741.831f, 11.2647f)); fHeading.Add(197.5895f);
                    Pos_01.Add(new Vector3(-1501.37f, 2684.001f, 3.191243f)); fHeading.Add(88.94603f);
                    Pos_01.Add(new Vector3(-1627.528f, 2710.553f, 5.176663f)); fHeading.Add(103.4545f);
                    Pos_01.Add(new Vector3(-1725.799f, 2748.991f, 5.00828f)); fHeading.Add(104.025f);
                    Pos_01.Add(new Vector3(-2160.634f, 2730.127f, 3.995766f)); fHeading.Add(50.44249f);
                    Pos_01.Add(new Vector3(-2584.121f, 2877.74f, 3.796169f)); fHeading.Add(68.0451f);
                    Pos_01.Add(new Vector3(-2884.217f, 3187.55f, 10.46736f)); fHeading.Add(41.10115f);
                    Pos_01.Add(new Vector3(-2899.272f, 3182.975f, 10.81549f)); fHeading.Add(226.0815f);
                    Pos_01.Add(new Vector3(-2812.017f, 3118.884f, 8.932123f)); fHeading.Add(233.299f);
                    Pos_01.Add(new Vector3(-2657.327f, 2986.998f, 8.475378f)); fHeading.Add(205.1365f);
                    Pos_01.Add(new Vector3(-2557.48f, 2865.591f, 2.521069f)); fHeading.Add(240.187f);
                    Pos_01.Add(new Vector3(-2356.98f, 2841.752f, 3.348562f)); fHeading.Add(267.1766f);
                    Pos_01.Add(new Vector3(-2166.792f, 2736.821f, 4.362955f)); fHeading.Add(223.5836f);
                    Pos_01.Add(new Vector3(-1844.768f, 2690.219f, 3.537222f)); fHeading.Add(271.2152f);
                    Pos_01.Add(new Vector3(-1555.259f, 2712.102f, 4.116089f)); fHeading.Add(236.3789f);
                    Pos_01.Add(new Vector3(-1459.733f, 2684.367f, 3.303248f)); fHeading.Add(274.8381f);
                    Pos_01.Add(new Vector3(-1438.947f, 2728.815f, 9.611741f)); fHeading.Add(20.52527f);
                    Pos_01.Add(new Vector3(-1482.055f, 2850.693f, 26.6391f)); fHeading.Add(34.27589f);
                    Pos_01.Add(new Vector3(-1581.356f, 3036.075f, 32.53102f)); fHeading.Add(353.6025f);
                }
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(-462.391f, 3022.21f, 28.40036f)); fHeading.Add(313.114f);
                    Pos_01.Add(new Vector3(-272.8297f, 3095.584f, 34.38621f)); fHeading.Add(302.639f);
                    Pos_01.Add(new Vector3(12.49784f, 3269.169f, 40.96146f)); fHeading.Add(335.1027f);
                    Pos_01.Add(new Vector3(107.1125f, 3397.141f, 36.66495f)); fHeading.Add(8.812644f);
                    Pos_01.Add(new Vector3(134.8132f, 3415.844f, 40.02129f)); fHeading.Add(243.3611f);
                    Pos_01.Add(new Vector3(227.9139f, 3344.033f, 39.13525f)); fHeading.Add(194.6835f);
                    Pos_01.Add(new Vector3(221.3962f, 3280.408f, 40.68347f)); fHeading.Add(169.897f);
                    Pos_01.Add(new Vector3(181.2409f, 3240.672f, 41.41757f)); fHeading.Add(141.7103f);
                    Pos_01.Add(new Vector3(26.04806f, 3041.013f, 40.35786f)); fHeading.Add(126.7756f);
                    Pos_01.Add(new Vector3(-172.475f, 2963.227f, 30.90143f)); fHeading.Add(101.0182f);
                    Pos_01.Add(new Vector3(-336.0371f, 2956.438f, 26.28792f)); fHeading.Add(97.28018f);
                    Pos_01.Add(new Vector3(-463.7291f, 2973.831f, 25.10873f)); fHeading.Add(73.1357f);
                }
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(-246.7437f, 4227.788f, 44.22093f)); fHeading.Add(88.70379f);
                    Pos_01.Add(new Vector3(-442.6657f, 4310.995f, 60.11999f)); fHeading.Add(47.96756f);
                    Pos_01.Add(new Vector3(-542.5441f, 4358.369f, 64.7117f)); fHeading.Add(101.0533f);
                    Pos_01.Add(new Vector3(-734.0334f, 4413.731f, 20.70769f)); fHeading.Add(77.96465f);
                    Pos_01.Add(new Vector3(-882.9547f, 4387.652f, 19.15052f)); fHeading.Add(122.8844f);
                    Pos_01.Add(new Vector3(-1094.925f, 4381.365f, 12.11559f)); fHeading.Add(85.9125f);
                    Pos_01.Add(new Vector3(-1274.828f, 4355.382f, 6.493629f)); fHeading.Add(100.2827f);
                    Pos_01.Add(new Vector3(-1362.314f, 4303.132f, 2.091456f)); fHeading.Add(110.5179f);
                    Pos_01.Add(new Vector3(-1624.499f, 4405.334f, 1.869654f)); fHeading.Add(28.06654f);
                    Pos_01.Add(new Vector3(-1853.843f, 4502.354f, 21.63335f)); fHeading.Add(109.9912f);
                    Pos_01.Add(new Vector3(-1912.896f, 4482.269f, 28.62659f)); fHeading.Add(93.04143f);
                    Pos_01.Add(new Vector3(-1893.607f, 4428.335f, 44.1927f)); fHeading.Add(242.4966f);
                    Pos_01.Add(new Vector3(-1614.563f, 4200.422f, 82.80534f)); fHeading.Add(265.1578f);
                    Pos_01.Add(new Vector3(-1420.428f, 4199.886f, 47.63276f)); fHeading.Add(229.7081f);
                    Pos_01.Add(new Vector3(-1352.643f, 4125.354f, 62.40678f)); fHeading.Add(257.9967f);
                    Pos_01.Add(new Vector3(-1108.262f, 4283.507f, 91.09012f)); fHeading.Add(242.1806f);
                    Pos_01.Add(new Vector3(-976.4009f, 4143.866f, 127.7988f)); fHeading.Add(284.5882f);
                    Pos_01.Add(new Vector3(-659.5837f, 4012.206f, 127.7423f)); fHeading.Add(265.3335f);
                    Pos_01.Add(new Vector3(-345.1731f, 4009.185f, 46.76369f)); fHeading.Add(289.7841f);
                    Pos_01.Add(new Vector3(-264.4113f, 3932.506f, 41.40203f)); fHeading.Add(220.5557f);
                    Pos_01.Add(new Vector3(-219.4442f, 3958.519f, 36.85928f)); fHeading.Add(346.6211f);
                    Pos_01.Add(new Vector3(-218.2338f, 4161.347f, 41.95908f)); fHeading.Add(342.4479f);
                }
                else
                {
                    Pos_01.Add(new Vector3(2737.655f, 2743.196f, 41.08186f)); fHeading.Add(300.0414f);
                    Pos_01.Add(new Vector3(2880.482f, 2745.462f, 68.57726f)); fHeading.Add(229.783f);
                    Pos_01.Add(new Vector3(2994.119f, 2681.638f, 74.66668f)); fHeading.Add(313.514f);
                    Pos_01.Add(new Vector3(3068.115f, 2773.374f, 76.51849f)); fHeading.Add(6.837749f);
                    Pos_01.Add(new Vector3(3055.643f, 2876.528f, 85.3677f)); fHeading.Add(304.5084f);
                    Pos_01.Add(new Vector3(3073.354f, 2980.721f, 91.20333f)); fHeading.Add(13.69699f);
                    Pos_01.Add(new Vector3(2987.849f, 2990.086f, 86.409f)); fHeading.Add(158.836f);
                    Pos_01.Add(new Vector3(2872.208f, 2913.032f, 77.55762f)); fHeading.Add(42.19868f);
                    Pos_01.Add(new Vector3(2708.277f, 2962.484f, 36.27277f)); fHeading.Add(98.92899f);
                    Pos_01.Add(new Vector3(2601.988f, 2862.675f, 35.80437f)); fHeading.Add(178.1778f);
                    Pos_01.Add(new Vector3(2697.39f, 2847.054f, 38.85565f)); fHeading.Add(268.2838f);
                    Pos_01.Add(new Vector3(2742.297f, 2911.1f, 35.81622f)); fHeading.Add(57.11665f);
                    Pos_01.Add(new Vector3(2627.528f, 2909.389f, 36.02975f)); fHeading.Add(317.5483f);
                    Pos_01.Add(new Vector3(2718.012f, 2945.823f, 35.64244f)); fHeading.Add(261.9158f);
                    Pos_01.Add(new Vector3(2808.185f, 2827.385f, 41.43419f)); fHeading.Add(160.7458f);
                    Pos_01.Add(new Vector3(2786.199f, 2792.07f, 39.8413f)); fHeading.Add(126.6713f);
                    Pos_01.Add(new Vector3(2744.489f, 2747.907f, 41.75266f)); fHeading.Add(298.9925f);

                }

                iAction = 8;

                iEnterVeh = 1;
            }           //Bike/ATV Male
            else if (iSelect == 21)
            {
                RandomWeatherTime();

                iSubSet = FindRandom(8, 1, 11);

                if (iSubSet == 1)
                {
                    World.Weather = Weather.ExtraSunny;
                    World.CurrentDayTime = TimeSpan.FromHours(12);

                    if (BoolList(13))
                    {
                        Pos_01.Add(new Vector3(-2006.46f, -557.0941f, 12.88623f)); fHeading.Add(131.999f);
                        Pos_01.Add(new Vector3(-1904.047f, -710.8903f, 8.832588f)); fHeading.Add(142.1092f);
                        Pos_01.Add(new Vector3(-1796.982f, -858.4172f, 8.988594f)); fHeading.Add(109.4991f);
                        Pos_01.Add(new Vector3(-1560.853f, -1155.617f, 3.91121f)); fHeading.Add(110.4863f);
                        Pos_01.Add(new Vector3(-1518.387f, -1273.357f, 3.459239f)); fHeading.Add(68.08511f);
                        Pos_01.Add(new Vector3(-1467.155f, -1387.716f, 4.138116f)); fHeading.Add(93.4029f);
                        Pos_01.Add(new Vector3(-1426.954f, -1510.442f, 3.710497f)); fHeading.Add(192.444f);
                        Pos_01.Add(new Vector3(-1373.184f, -1623.852f, 3.725399f)); fHeading.Add(38.85428f);
                        Pos_01.Add(new Vector3(-1290.262f, -1752.792f, 3.713808f)); fHeading.Add(113.0197f);
                        Pos_01.Add(new Vector3(-1203.31f, -1785.278f, 15.62175f)); fHeading.Add(56.26437f);
                        Pos_01.Add(new Vector3(-1496.039f, -1031.543f, 10.52018f)); fHeading.Add(130.5046f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-1175.706f, -1774.746f, 3.363378f)); fHeading.Add(304.6927f);
                        Pos_01.Add(new Vector3(-1287.01f, -1759.955f, 1.672546f)); fHeading.Add(295.8521f);
                        Pos_01.Add(new Vector3(-1367.334f, -1629.258f, 1.649302f)); fHeading.Add(120.9917f);
                        Pos_01.Add(new Vector3(-1428.135f, -1518.865f, 1.663456f)); fHeading.Add(296.1766f);
                        Pos_01.Add(new Vector3(-1457.268f, -1386.405f, 2.275759f)); fHeading.Add(199.2531f);
                        Pos_01.Add(new Vector3(-1524.885f, -1273.191f, 1.530929f)); fHeading.Add(278.7048f);
                        Pos_01.Add(new Vector3(-1553.199f, -1151.16f, 1.866233f)); fHeading.Add(223.5885f);
                        Pos_01.Add(new Vector3(-1805.487f, -861.1481f, 6.189745f)); fHeading.Add(202.9933f);
                        Pos_01.Add(new Vector3(-1893.655f, -714.954f, 6.738693f)); fHeading.Add(140.5407f);
                        Pos_01.Add(new Vector3(-1998.289f, -552.5966f, 11.23209f)); fHeading.Add(234.004f);
                        iEnterVeh = 9;
                        iAction = 1;
                    }
                }            //"Baywatch 
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(1900.911f, 4210.698f, 31.12156f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(456.3666f, 3941.582f, 29.83598f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(-274.0639f, -3168.564f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(1919.113f, -3195.016f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(3095.027f, -2285.647f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(3324.883f, -928.3412f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(3462.442f, 669.5615f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(3461.571f, 1551.177f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(4046.482f, 2779.351f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(4252.938f, 3943.124f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(4028.5f, 5284.229f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(3197.774f, 6780.198f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(2577.655f, 6975.242f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(1584.373f, 7135.975f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(752.0983f, 7195.581f, 1.20f)); fHeading.Add(234.004f);
                    iEnterVeh = 2;
                    iAction = 1;
                }       //"US Coastguard
                else if (iSubSet == 3)
                {
                    if (BoolList(14))
                    {
                        Pos_01.Add(new Vector3(358.6237f, -1583.362f, 29.29193f)); fHeading.Add(327.5265f);
                        Pos_01.Add(new Vector3(824.7567f, -1288.554f, 28.24066f)); fHeading.Add(87.50066f);
                        Pos_01.Add(new Vector3(-1059.216f, -825.3883f, 19.21697f)); fHeading.Add(303.7586f);
                        Pos_01.Add(new Vector3(427.7636f, -978.7175f, 30.71008f)); fHeading.Add(88.30321f);
                        Pos_01.Add(new Vector3(221.1342f, -890.8514f, 30.692f)); fHeading.Add(147.9018f);
                        Pos_01.Add(new Vector3(641.4783f, -4.073126f, 82.7884f)); fHeading.Add(226.4207f);
                        Pos_01.Add(new Vector3(104.8719f, -193.8214f, 54.75231f)); fHeading.Add(247.8596f);
                        Pos_01.Add(new Vector3(-566.6926f, -132.4973f, 37.94614f)); fHeading.Add(199.6771f);
                        Pos_01.Add(new Vector3(-695.9104f, -821.5554f, 23.85311f)); fHeading.Add(269.5868f);
                        Pos_01.Add(new Vector3(-1311.33f, -1521.909f, 4.41676f)); fHeading.Add(157.7447f);
                        Pos_01.Add(new Vector3(-1361.757f, -1126.886f, 4.270231f)); fHeading.Add(184.5965f);
                        Pos_01.Add(new Vector3(-2022.764f, -497.6946f, 11.63673f)); fHeading.Add(229.2497f);
                        Pos_01.Add(new Vector3(1855.582f, 3682.823f, 34.26752f)); fHeading.Add(204.1647f);
                        Pos_01.Add(new Vector3(-256.3628f, 6293.579f, 31.45917f)); fHeading.Add(134.4056f);
                        Pos_01.Add(new Vector3(-442.6062f, 6016.88f, 31.71221f)); fHeading.Add(313.0559f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(885.5582f, -2615.697f, 50.64429f)); fHeading.Add(278.7308f);
                        Pos_01.Add(new Vector3(203.3962f, -2666.317f, 17.77028f)); fHeading.Add(269.1859f);
                        Pos_01.Add(new Vector3(-373.5676f, -2359.221f, 62.95405f)); fHeading.Add(234.2403f);
                        Pos_01.Add(new Vector3(-416.3635f, -1002.121f, 36.88079f)); fHeading.Add(180.3557f);
                        Pos_01.Add(new Vector3(-142.9952f, -489.4464f, 28.90267f)); fHeading.Add(90.18279f);
                        Pos_01.Add(new Vector3(263.6426f, -504.648f, 33.6673f)); fHeading.Add(89.44656f);
                        Pos_01.Add(new Vector3(658.7974f, -572.0912f, 35.72264f)); fHeading.Add(62.07106f);
                        Pos_01.Add(new Vector3(1298.609f, 597.3955f, 79.88807f)); fHeading.Add(136.4441f);
                        Pos_01.Add(new Vector3(1744.206f, 1860.102f, 74.69196f)); fHeading.Add(174.4608f);
                        Pos_01.Add(new Vector3(2644.47f, 3147.029f, 50.34586f)); fHeading.Add(135.5797f);
                        Pos_01.Add(new Vector3(2820.983f, 4262.163f, 49.99089f)); fHeading.Add(201.1554f);
                        Pos_01.Add(new Vector3(2542.731f, 5371.196f, 44.30971f)); fHeading.Add(192.7441f);
                        Pos_01.Add(new Vector3(905.6749f, 6484.458f, 21.066f)); fHeading.Add(266.5843f);
                        Pos_01.Add(new Vector3(-287.8203f, 6080.083f, 30.98392f)); fHeading.Add(315.2855f);
                        Pos_01.Add(new Vector3(-822.1944f, 5455.459f, 33.60496f)); fHeading.Add(302.0413f);
                        Pos_01.Add(new Vector3(-1990.362f, 4519.978f, 56.79668f)); fHeading.Add(313.5679f);
                        Pos_01.Add(new Vector3(-2387.44f, 3921.145f, 24.41055f)); fHeading.Add(340.2222f);
                        Pos_01.Add(new Vector3(-2629.613f, 2777.201f, 16.40953f)); fHeading.Add(352.1142f);
                        Pos_01.Add(new Vector3(-2983.182f, 427.1111f, 14.73897f)); fHeading.Add(356.4609f);
                        Pos_01.Add(new Vector3(-2408.366f, -246.0178f, 15.25864f)); fHeading.Add(61.36377f);
                        Pos_01.Add(new Vector3(-712.5493f, -489.1255f, 24.75532f)); fHeading.Add(88.78899f);
                        Pos_01.Add(new Vector3(-398.3365f, -892.6438f, 36.99687f)); fHeading.Add(2.379511f);
                        Pos_01.Add(new Vector3(349.1497f, -1179.372f, 38.40684f)); fHeading.Add(89.36625f);
                        Pos_01.Add(new Vector3(881.6455f, -1168.795f, 42.78446f)); fHeading.Add(92.00111f);
                        Pos_01.Add(new Vector3(620.7553f, -584.2747f, 35.70321f)); fHeading.Add(241.3658f);
                        Pos_01.Add(new Vector3(35.09534f, -522.4681f, 33.79306f)); fHeading.Add(271.1531f);
                        Pos_01.Add(new Vector3(-580.5308f, -536.8923f, 24.96111f)); fHeading.Add(270.6866f);
                        Pos_01.Add(new Vector3(-1164.99f, -682.7447f, 10.80028f)); fHeading.Add(300.4947f);
                        Pos_01.Add(new Vector3(-1938.348f, -501.9031f, 11.5878f)); fHeading.Add(230.8896f);
                        Pos_01.Add(new Vector3(-2511.576f, -202.5297f, 18.51174f)); fHeading.Add(240.959f);
                        Pos_01.Add(new Vector3(-3107.269f, 1229.96f, 19.99887f)); fHeading.Add(173.2392f);
                        Pos_01.Add(new Vector3(-2246.985f, 4275.212f, 46.0254f)); fHeading.Add(145.9837f);
                        Pos_01.Add(new Vector3(-1787.779f, 4738.555f, 56.77055f)); fHeading.Add(135.9421f);
                        Pos_01.Add(new Vector3(-487.1145f, 5868.34f, 33.32526f)); fHeading.Add(148.7284f);
                        Pos_01.Add(new Vector3(1645.693f, 6401.292f, 29.01801f)); fHeading.Add(70.58336f);
                        Pos_01.Add(new Vector3(2542.887f, 5440.158f, 44.27225f)); fHeading.Add(18.48835f);
                        Pos_01.Add(new Vector3(2720.861f, 4745.983f, 44.15805f)); fHeading.Add(12.34523f);
                        Pos_01.Add(new Vector3(2893.44f, 4158.5f, 49.99942f)); fHeading.Add(18.04636f);
                        Pos_01.Add(new Vector3(2803.914f, 3404.103f, 55.59621f)); fHeading.Add(335.1538f);
                        Pos_01.Add(new Vector3(2159.228f, 2692.351f, 48.39897f)); fHeading.Add(310.3872f);
                        Pos_01.Add(new Vector3(2274.467f, 1177.887f, 77.4653f)); fHeading.Add(41.29153f);
                        Pos_01.Add(new Vector3(2615.018f, 295.7539f, 97.67361f)); fHeading.Add(351.01f);
                        Pos_01.Add(new Vector3(1743.362f, -889.3596f, 69.89281f)); fHeading.Add(302.4699f);
                        Pos_01.Add(new Vector3(1070.263f, -1189.859f, 55.55549f)); fHeading.Add(273.7319f);
                        Pos_01.Add(new Vector3(266.552f, -1222.569f, 38.0509f)); fHeading.Add(269.8226f);
                        iEnterVeh = 12;
                        bFound = false;
                        iAction = 1;
                    }
                }       //><!--Cops
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(2820.983f, 4262.163f, 49.99089f)); fHeading.Add(201.1554f);
                    Pos_01.Add(new Vector3(2542.731f, 5371.196f, 44.30971f)); fHeading.Add(192.7441f);
                    Pos_01.Add(new Vector3(905.6749f, 6484.458f, 21.066f)); fHeading.Add(266.5843f);
                    Pos_01.Add(new Vector3(-287.8203f, 6080.083f, 30.98392f)); fHeading.Add(315.2855f);
                    Pos_01.Add(new Vector3(-822.1944f, 5455.459f, 33.60496f)); fHeading.Add(302.0413f);
                    Pos_01.Add(new Vector3(-1990.362f, 4519.978f, 56.79668f)); fHeading.Add(313.5679f);
                    Pos_01.Add(new Vector3(-2246.985f, 4275.212f, 46.0254f)); fHeading.Add(145.9837f);
                    Pos_01.Add(new Vector3(-1787.779f, 4738.555f, 56.77055f)); fHeading.Add(135.9421f);
                    Pos_01.Add(new Vector3(-487.1145f, 5868.34f, 33.32526f)); fHeading.Add(148.7284f);
                    Pos_01.Add(new Vector3(1645.693f, 6401.292f, 29.01801f)); fHeading.Add(70.58336f);
                    Pos_01.Add(new Vector3(2542.887f, 5440.158f, 44.27225f)); fHeading.Add(18.48835f);
                    Pos_01.Add(new Vector3(2720.861f, 4745.983f, 44.15805f)); fHeading.Add(12.34523f);
                    Pos_01.Add(new Vector3(2893.44f, 4158.5f, 49.99942f)); fHeading.Add(18.04636f);

                    iEnterVeh = 12;
                    bFound = false;
                    iAction = 1;
                }       //><!-- PoliceBike
                else if (iSubSet == 5)
                {
                    Pos_01.Add(new Vector3(-1493.802f, 4979.706f, 62.91706f)); fHeading.Add(351.3716f);
                    Pos_01.Add(new Vector3(-1564.614f, 4385.387f, 4.26155f)); fHeading.Add(26.0204f);
                    Pos_01.Add(new Vector3(-889.2991f, 4427.76f, 20.53571f)); fHeading.Add(69.94745f);
                    Pos_01.Add(new Vector3(-773.6549f, 4520.953f, 93.5034f)); fHeading.Add(267.5718f);
                    Pos_01.Add(new Vector3(-1035.605f, 4576.456f, 122.0881f)); fHeading.Add(207.1876f);
                    Pos_01.Add(new Vector3(-1280.47f, 4608.851f, 122.7791f)); fHeading.Add(261.6023f);
                    Pos_01.Add(new Vector3(-1127.258f, 4682.028f, 240.7662f)); fHeading.Add(169.1925f);
                    Pos_01.Add(new Vector3(-1008.586f, 4706.519f, 246.7317f)); fHeading.Add(65.47046f);
                    Pos_01.Add(new Vector3(-1290.714f, 4936.681f, 152.4774f)); fHeading.Add(174.5883f);
                    Pos_01.Add(new Vector3(-1031.845f, 4916.573f, 205.4106f)); fHeading.Add(133.588f);
                    Pos_01.Add(new Vector3(-596.4041f, 5025.744f, 140.5351f)); fHeading.Add(353.1016f);
                    iEnterVeh = 9;
                    iAction = 1;
                }       //><!-- Ranger
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(885.5582f, -2615.697f, 50.64429f)); fHeading.Add(278.7308f);
                    Pos_01.Add(new Vector3(203.3962f, -2666.317f, 17.77028f)); fHeading.Add(269.1859f);
                    Pos_01.Add(new Vector3(-373.5676f, -2359.221f, 62.95405f)); fHeading.Add(234.2403f);
                    Pos_01.Add(new Vector3(-416.3635f, -1002.121f, 36.88079f)); fHeading.Add(180.3557f);
                    Pos_01.Add(new Vector3(-142.9952f, -489.4464f, 28.90267f)); fHeading.Add(90.18279f);
                    Pos_01.Add(new Vector3(263.6426f, -504.648f, 33.6673f)); fHeading.Add(89.44656f);
                    Pos_01.Add(new Vector3(658.7974f, -572.0912f, 35.72264f)); fHeading.Add(62.07106f);
                    Pos_01.Add(new Vector3(1298.609f, 597.3955f, 79.88807f)); fHeading.Add(136.4441f);
                    Pos_01.Add(new Vector3(1744.206f, 1860.102f, 74.69196f)); fHeading.Add(174.4608f);
                    Pos_01.Add(new Vector3(2644.47f, 3147.029f, 50.34586f)); fHeading.Add(135.5797f);
                    Pos_01.Add(new Vector3(2820.983f, 4262.163f, 49.99089f)); fHeading.Add(201.1554f);
                    Pos_01.Add(new Vector3(2542.731f, 5371.196f, 44.30971f)); fHeading.Add(192.7441f);
                    Pos_01.Add(new Vector3(905.6749f, 6484.458f, 21.066f)); fHeading.Add(266.5843f);
                    Pos_01.Add(new Vector3(-287.8203f, 6080.083f, 30.98392f)); fHeading.Add(315.2855f);
                    Pos_01.Add(new Vector3(-822.1944f, 5455.459f, 33.60496f)); fHeading.Add(302.0413f);
                    Pos_01.Add(new Vector3(-1990.362f, 4519.978f, 56.79668f)); fHeading.Add(313.5679f);
                    Pos_01.Add(new Vector3(-2387.44f, 3921.145f, 24.41055f)); fHeading.Add(340.2222f);
                    Pos_01.Add(new Vector3(-2629.613f, 2777.201f, 16.40953f)); fHeading.Add(352.1142f);
                    Pos_01.Add(new Vector3(-2983.182f, 427.1111f, 14.73897f)); fHeading.Add(356.4609f);
                    Pos_01.Add(new Vector3(-2408.366f, -246.0178f, 15.25864f)); fHeading.Add(61.36377f);
                    Pos_01.Add(new Vector3(-712.5493f, -489.1255f, 24.75532f)); fHeading.Add(88.78899f);
                    Pos_01.Add(new Vector3(-398.3365f, -892.6438f, 36.99687f)); fHeading.Add(2.379511f);
                    Pos_01.Add(new Vector3(349.1497f, -1179.372f, 38.40684f)); fHeading.Add(89.36625f);
                    Pos_01.Add(new Vector3(881.6455f, -1168.795f, 42.78446f)); fHeading.Add(92.00111f);
                    Pos_01.Add(new Vector3(620.7553f, -584.2747f, 35.70321f)); fHeading.Add(241.3658f);
                    Pos_01.Add(new Vector3(35.09534f, -522.4681f, 33.79306f)); fHeading.Add(271.1531f);
                    Pos_01.Add(new Vector3(-580.5308f, -536.8923f, 24.96111f)); fHeading.Add(270.6866f);
                    Pos_01.Add(new Vector3(-1164.99f, -682.7447f, 10.80028f)); fHeading.Add(300.4947f);
                    Pos_01.Add(new Vector3(-1938.348f, -501.9031f, 11.5878f)); fHeading.Add(230.8896f);
                    Pos_01.Add(new Vector3(-2511.576f, -202.5297f, 18.51174f)); fHeading.Add(240.959f);
                    Pos_01.Add(new Vector3(-3107.269f, 1229.96f, 19.99887f)); fHeading.Add(173.2392f);
                    Pos_01.Add(new Vector3(-2246.985f, 4275.212f, 46.0254f)); fHeading.Add(145.9837f);
                    Pos_01.Add(new Vector3(-1787.779f, 4738.555f, 56.77055f)); fHeading.Add(135.9421f);
                    Pos_01.Add(new Vector3(-487.1145f, 5868.34f, 33.32526f)); fHeading.Add(148.7284f);
                    Pos_01.Add(new Vector3(1645.693f, 6401.292f, 29.01801f)); fHeading.Add(70.58336f);
                    Pos_01.Add(new Vector3(2542.887f, 5440.158f, 44.27225f)); fHeading.Add(18.48835f);
                    Pos_01.Add(new Vector3(2720.861f, 4745.983f, 44.15805f)); fHeading.Add(12.34523f);
                    Pos_01.Add(new Vector3(2893.44f, 4158.5f, 49.99942f)); fHeading.Add(18.04636f);
                    Pos_01.Add(new Vector3(2803.914f, 3404.103f, 55.59621f)); fHeading.Add(335.1538f);
                    Pos_01.Add(new Vector3(2159.228f, 2692.351f, 48.39897f)); fHeading.Add(310.3872f);
                    Pos_01.Add(new Vector3(2274.467f, 1177.887f, 77.4653f)); fHeading.Add(41.29153f);
                    Pos_01.Add(new Vector3(2615.018f, 295.7539f, 97.67361f)); fHeading.Add(351.01f);
                    Pos_01.Add(new Vector3(1743.362f, -889.3596f, 69.89281f)); fHeading.Add(302.4699f);
                    Pos_01.Add(new Vector3(1070.263f, -1189.859f, 55.55549f)); fHeading.Add(273.7319f);
                    Pos_01.Add(new Vector3(266.552f, -1222.569f, 38.0509f)); fHeading.Add(269.8226f);
                    iEnterVeh = 12;
                    bFound = false;
                    iAction = 1;
                }       //><!-- Sherif
                else if (iSubSet == 7)
                {
                    if (BoolList(15))
                    {
                        Pos_01.Add(new Vector3(142.8676f, -721.2127f, 42.02895f)); fHeading.Add(38.59577f);
                        Pos_01.Add(new Vector3(180.8606f, -698.6846f, 47.07698f)); fHeading.Add(305.9764f);
                        Pos_01.Add(new Vector3(185.0671f, -782.6472f, 47.07693f)); fHeading.Add(205.7225f);
                        Pos_01.Add(new Vector3(102.9597f, -745.4732f, 45.75473f)); fHeading.Add(73.5444f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(124.8999f, -720.1405f, 32.75769f)); fHeading.Add(340.4963f);
                        Pos_01.Add(new Vector3(132.8888f, -722.7589f, 32.75735f)); fHeading.Add(340.4963f);
                        Pos_01.Add(new Vector3(140.2559f, -725.1739f, 32.75784f)); fHeading.Add(340.4963f);
                        Pos_01.Add(new Vector3(148.2134f, -727.7819f, 32.75822f)); fHeading.Add(340.4963f);
                        Pos_01.Add(new Vector3(151.4105f, -730.2962f, 32.75987f)); fHeading.Add(159.6303f);
                        Pos_01.Add(new Vector3(143.8329f, -727.6848f, 32.7599f)); fHeading.Add(159.6304f);
                        Pos_01.Add(new Vector3(136.2731f, -725.0797f, 32.75871f)); fHeading.Add(159.6304f);
                        Pos_01.Add(new Vector3(128.5793f, -722.4284f, 32.76021f)); fHeading.Add(159.6304f);
                        Pos_01.Add(new Vector3(120.7546f, -719.5478f, 32.75972f)); fHeading.Add(161.0089f);
                        Pos_01.Add(new Vector3(113.7038f, -716.8285f, 32.76033f)); fHeading.Add(161.0155f);
                        Pos_01.Add(new Vector3(110.3745f, -714.157f, 32.75887f)); fHeading.Add(340.0062f);
                        Pos_01.Add(new Vector3(103.6866f, -694.1055f, 32.74104f)); fHeading.Add(160.5572f);
                        Pos_01.Add(new Vector3(107.0196f, -695.1913f, 32.74342f)); fHeading.Add(160.5571f);
                        Pos_01.Add(new Vector3(111.1312f, -696.534f, 32.74039f)); fHeading.Add(160.5572f);
                        Pos_01.Add(new Vector3(114.4097f, -697.6046f, 32.74321f)); fHeading.Add(160.5571f);
                        Pos_01.Add(new Vector3(118.619f, -698.9508f, 32.74128f)); fHeading.Add(160.905f);
                        Pos_01.Add(new Vector3(122.539f, -700.1477f, 32.74237f)); fHeading.Add(161.6465f);
                        Pos_01.Add(new Vector3(125.8455f, -702.1788f, 32.74369f)); fHeading.Add(161.686f);
                        Pos_01.Add(new Vector3(129.9737f, -703.5176f, 32.74564f)); fHeading.Add(160.6104f);
                        Pos_01.Add(new Vector3(133.7075f, -704.7408f, 32.74757f)); fHeading.Add(160.6105f);
                        Pos_01.Add(new Vector3(145.1564f, -699.0904f, 32.75421f)); fHeading.Add(250.3092f);
                        Pos_01.Add(new Vector3(146.2141f, -695.4435f, 32.75328f)); fHeading.Add(252.3628f);
                        Pos_01.Add(new Vector3(148.6901f, -688.0548f, 32.75203f)); fHeading.Add(249.764f);
                        Pos_01.Add(new Vector3(149.8707f, -684.3236f, 32.75465f)); fHeading.Add(251.1089f);
                        Pos_01.Add(new Vector3(155.8789f, -682.1313f, 32.75422f)); fHeading.Add(160.3401f);
                        Pos_01.Add(new Vector3(159.394f, -683.2919f, 32.75308f)); fHeading.Add(160.3402f);
                        Pos_01.Add(new Vector3(163.1044f, -684.5927f, 32.75218f)); fHeading.Add(159.2708f);
                        Pos_01.Add(new Vector3(169.2833f, -686.3806f, 32.75238f)); fHeading.Add(160.0061f);
                        Pos_01.Add(new Vector3(173.0347f, -687.5805f, 32.74957f)); fHeading.Add(160.8067f);
                        Pos_01.Add(new Vector3(179.2498f, -695.2624f, 32.75071f)); fHeading.Add(72.96658f);
                        Pos_01.Add(new Vector3(178.1708f, -698.6674f, 32.75278f)); fHeading.Add(71.0178f);
                        Pos_01.Add(new Vector3(175.3772f, -706.3841f, 32.75247f)); fHeading.Add(71.30013f);
                        Pos_01.Add(new Vector3(174.2273f, -709.7647f, 32.75602f)); fHeading.Add(69.83701f);
                        Pos_01.Add(new Vector3(165.253f, -733.755f, 32.75826f)); fHeading.Add(70.5134f);
                        Pos_01.Add(new Vector3(164.3231f, -737.161f, 32.75834f)); fHeading.Add(70.5134f);
                        Pos_01.Add(new Vector3(162.8038f, -740.7974f, 32.75814f)); fHeading.Add(69.8709f);
                        Pos_01.Add(new Vector3(161.4511f, -744.9138f, 32.75976f)); fHeading.Add(74.06393f);
                        Pos_01.Add(new Vector3(155.2419f, -748.9347f, 32.75949f)); fHeading.Add(339.7729f);
                        Pos_01.Add(new Vector3(151.0513f, -747.5115f, 32.75947f)); fHeading.Add(340.5012f);
                        Pos_01.Add(new Vector3(148.0087f, -746.1507f, 32.75831f)); fHeading.Add(340.5012f);
                        Pos_01.Add(new Vector3(141.0646f, -743.7266f, 32.75826f)); fHeading.Add(338.631f);
                        Pos_01.Add(new Vector3(137.5325f, -742.0901f, 32.75802f)); fHeading.Add(339.5825f);
                        Pos_01.Add(new Vector3(133.8466f, -740.9481f, 32.75931f)); fHeading.Add(338.8475f);
                        Pos_01.Add(new Vector3(119.1344f, -735.6913f, 32.7584f)); fHeading.Add(339.97f);
                        Pos_01.Add(new Vector3(115.5711f, -734.0814f, 32.75903f)); fHeading.Add(340.7244f);
                        Pos_01.Add(new Vector3(108.545f, -731.7458f, 32.75801f)); fHeading.Add(340.7243f);
                        Pos_01.Add(new Vector3(104.27f, -730.391f, 32.75842f)); fHeading.Add(343.5851f);
                        Pos_01.Add(new Vector3(100.4326f, -728.9741f, 32.75946f)); fHeading.Add(340.1993f);
                        Pos_01.Add(new Vector3(96.46036f, -727.2465f, 32.75974f)); fHeading.Add(342.7584f);
                        Pos_01.Add(new Vector3(93.8289f, -720.4455f, 32.75797f)); fHeading.Add(250.9863f);
                        Pos_01.Add(new Vector3(95.17917f, -716.4265f, 32.75877f)); fHeading.Add(250.9863f);
                        Pos_01.Add(new Vector3(96.42334f, -712.7228f, 32.75986f)); fHeading.Add(250.9863f);
                        Pos_01.Add(new Vector3(97.63802f, -708.955f, 32.76009f)); fHeading.Add(249.8051f);

                        iEnterVeh = 3;

                        iAction = 1;
                    }
                }       //><!-- fib
                else if (iSubSet == 8)
                {
                    Pos_01.Add(new Vector3(-119.9115f, 6434.275f, 31.11884f)); fHeading.Add(76.0892f);
                    Pos_01.Add(new Vector3(-2985.351f, 481.0876f, 14.88591f)); fHeading.Add(340.2791f);
                    Pos_01.Add(new Vector3(213.41f, 185.9918f, 105.2675f)); fHeading.Add(42.60518f);
                    iEnterVeh = 3;

                    iAction = 1;
                }       //><!-- swat
                else if (iSubSet == 9)
                {
                    if (BoolList(16))
                    {
                        Pos_01.Add(new Vector3(-2348.52f, 3270.065f, 32.81076f)); fHeading.Add(332.1701f);
                        Pos_01.Add(new Vector3(-2352.183f, 3263.234f, 32.81076f)); fHeading.Add(130.7586f);
                        Pos_01.Add(new Vector3(-2359.573f, 3242.599f, 92.90372f)); fHeading.Add(157.5246f);
                        Pos_01.Add(new Vector3(-2350.698f, 3253.426f, 92.90375f)); fHeading.Add(337.057f);
                        Pos_01.Add(new Vector3(-2358.584f, 3249.421f, 101.4507f)); fHeading.Add(153.4097f);
                        Pos_01.Add(new Vector3(-1741.393f, 3241.755f, 32.79575f)); fHeading.Add(78.55652f);
                        Pos_01.Add(new Vector3(-1804.59f, 3196.451f, 32.82647f)); fHeading.Add(182.0171f);
                        Pos_01.Add(new Vector3(-1805.791f, 3276.147f, 32.8152f)); fHeading.Add(321.533f);
                        Pos_01.Add(new Vector3(-1846.772f, 3299.44f, 32.81537f)); fHeading.Add(237.3338f);
                        Pos_01.Add(new Vector3(-1891.602f, 3248.149f, 36.84936f)); fHeading.Add(60.9971f);
                        Pos_01.Add(new Vector3(-2304.231f, 3388.183f, 31.25652f)); fHeading.Add(69.23507f);
                        Pos_01.Add(new Vector3(-2215.307f, 3335.828f, 49.68368f)); fHeading.Add(213.1394f);
                        Pos_01.Add(new Vector3(-2499.535f, 3299.237f, 91.96436f)); fHeading.Add(250.5922f);
                        Pos_01.Add(new Vector3(-2445.342f, 2922.033f, 32.9602f)); fHeading.Add(251.9464f);
                        Pos_01.Add(new Vector3(-2441.134f, 2951.473f, 34.84854f)); fHeading.Add(334.34f);
                        Pos_01.Add(new Vector3(-2439.48f, 3000.529f, 33.06071f)); fHeading.Add(296.1235f);
                        Pos_01.Add(new Vector3(-1850.713f, 2896.427f, 32.81028f)); fHeading.Add(304.653f);
                        Pos_01.Add(new Vector3(-1838.236f, 3124.419f, 32.81024f)); fHeading.Add(149.3089f);
                        Pos_01.Add(new Vector3(-1774.784f, 3045.097f, 32.81818f)); fHeading.Add(324.3441f);
                        Pos_01.Add(new Vector3(-1785.799f, 3145.48f, 33.06939f)); fHeading.Add(344.5996f);
                        Pos_01.Add(new Vector3(-1709.335f, 3005.007f, 33.19464f)); fHeading.Add(277.5203f);
                        Pos_01.Add(new Vector3(-1591.394f, 2796.617f, 17.07146f)); fHeading.Add(210.1899f);
                        Pos_01.Add(new Vector3(-2148.929f, 3299.234f, 38.73254f)); fHeading.Add(164.7554f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-1899.622f, 3229.268f, 33.47933f)); fHeading.Add(240.4016f);
                        Pos_01.Add(new Vector3(-1803.691f, 3296.952f, 33.47214f)); fHeading.Add(59.49804f);
                        Pos_01.Add(new Vector3(-1987.941f, 3114.901f, 33.3334f)); fHeading.Add(238.1281f);
                        Pos_01.Add(new Vector3(-2298.659f, 3301.444f, 33.35372f)); fHeading.Add(98.11511f);
                        Pos_01.Add(new Vector3(-2175.917f, 3364.38f, 33.65299f)); fHeading.Add(267.6297f);

                        iEnterVeh = 3;

                        iAction = 1;
                    }

                    bRequestPB = true;
                }       //military
                else if (iSubSet == 10)
                {
                    Pos_01.Add(new Vector3(-480.4834f, -350.4613f, 34.13201f)); fHeading.Add(169.3226f);
                    Pos_01.Add(new Vector3(375.7192f, -583.7938f, 28.5012f)); fHeading.Add(268.1963f);
                    Pos_01.Add(new Vector3(314.8461f, -1448.607f, 29.57309f)); fHeading.Add(231.6201f);
                    Pos_01.Add(new Vector3(1128.826f, -1507.548f, 34.46217f)); fHeading.Add(267.5413f);
                    Pos_01.Add(new Vector3(1842.941f, 3706.448f, 33.35268f)); fHeading.Add(348.876f);
                    Pos_01.Add(new Vector3(-239.1304f, 6332.855f, 32.16411f)); fHeading.Add(224.5303f);
                    iEnterVeh = 2;

                    iAction = 1;
                }      //medic
                else if (iSubSet == 11)
                {
                    Pos_01.Add(new Vector3(-370.2138f, 6128.188f, 31.52059f)); fHeading.Add(43.32635f);
                    Pos_01.Add(new Vector3(1696.062f, 3588.495f, 35.69079f)); fHeading.Add(203.5357f);
                    Pos_01.Add(new Vector3(209.5965f, -1646.76f, 29.87245f)); fHeading.Add(318.9238f);
                    Pos_01.Add(new Vector3(1204.332f, -1469.507f, 34.92859f)); fHeading.Add(357.4668f);
                    Pos_01.Add(new Vector3(-640.5964f, -101.5987f, 38.10654f)); fHeading.Add(127.0878f);

                    iEnterVeh = 3;

                    iAction = 1;
                }      //fireman

                iWeapons = 5;
            }           //Services 
            else if (iSelect == 22)
            {
                RandomWeatherTime();

                iSubSet = FindRandom(10, 1, 4);

                if (iSubSet == 1)
                {
                    if (BoolList(17))
                    {
                        Pos_01.Add(new Vector3(-3376.623f, 7834.382f, 1500.00f)); fHeading.Add(217.4295f);
                        Pos_01.Add(new Vector3(4364.612f, -4151.208f, 1500.00f)); fHeading.Add(42.93307f);
                        Pos_01.Add(new Vector3(-3292.792f, -4034.441f, 1500.00f)); fHeading.Add(311.4861f);
                        Pos_01.Add(new Vector3(3585.601f, 7976.706f, 1500.00f)); fHeading.Add(140.3225f);
                        vPlayerTarget = new Vector3(-2352.11f, 2274.94f, 1500.0f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-1669.021f, -2788.412f, 22.72314f)); fHeading.Add(330.7915f);
                        vPlayerTarget = new Vector3(144.6707f, 411.1093f, 562.7795f);
                        bRequestPB = true;
                    }
                    iAction = 1;

                    iEnterVeh = 1;
                }       //civilian
                else if (iSubSet == 2)
                {
                    if (BoolList(18))
                    {
                        Pos_01.Add(new Vector3(-3376.623f, 7834.382f, 700.00f)); fHeading.Add(217.4295f);
                        Pos_01.Add(new Vector3(4364.612f, -4151.208f, 700.00f)); fHeading.Add(42.93307f);
                        Pos_01.Add(new Vector3(-3292.792f, -4034.441f, 700.00f)); fHeading.Add(311.4861f);
                        Pos_01.Add(new Vector3(3585.601f, 7976.706f, 700.00f)); fHeading.Add(140.3225f);
                        vPlayerTarget = new Vector3(-2352.11f, 2274.94f, 1500.0f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-2668.141f, 3239.957f, 33.58316f)); fHeading.Add(240.3811f);
                        vPlayerTarget = new Vector3(-1316.467f, 2441.465f, 418.8308f);
                        bRequestPB = true;
                    }
                    iAction = 1;

                    iEnterVeh = 1;
                }       //milatary
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(-745.0335f, -1434.13f, 5.675035f)); fHeading.Add(49.38052f);
                    Pos_01.Add(new Vector3(-744.5621f, -1434.631f, 45.5694f)); fHeading.Add(43.56923f);
                    Pos_01.Add(new Vector3(-943.0097f, -1372.587f, 88.47835f)); fHeading.Add(76.8955f);
                    Pos_01.Add(new Vector3(-1380.798f, -1231.121f, 120.3375f)); fHeading.Add(64.56821f);
                    Pos_01.Add(new Vector3(-1937.764f, -718.4302f, 124.1025f)); fHeading.Add(41.56572f);
                    Pos_01.Add(new Vector3(-2005.697f, -10.6858f, 183.4718f)); fHeading.Add(350.5649f);
                    Pos_01.Add(new Vector3(-1887.984f, 252.9273f, 219.2129f)); fHeading.Add(332.1073f);
                    Pos_01.Add(new Vector3(-1440.777f, 532.8215f, 241.145f)); fHeading.Add(289.4188f);
                    Pos_01.Add(new Vector3(-824.9135f, 722.5916f, 296.2533f)); fHeading.Add(284.8902f);
                    Pos_01.Add(new Vector3(-489.9325f, 952.3074f, 396.2867f)); fHeading.Add(329.8929f);
                    Pos_01.Add(new Vector3(-140.4692f, 1033.914f, 412.1446f)); fHeading.Add(256.8935f);
                    Pos_01.Add(new Vector3(516.86f, 1063.885f, 403.47f)); fHeading.Add(279.1731f);
                    Pos_01.Add(new Vector3(620.8156f, 13.97498f, 298.2937f)); fHeading.Add(164.5377f);
                    Pos_01.Add(new Vector3(402.175f, -584.6495f, 256.7945f)); fHeading.Add(155.1357f);
                    Pos_01.Add(new Vector3(173.9926f, -954.7323f, 237.2449f)); fHeading.Add(138.4467f);
                    Pos_01.Add(new Vector3(-284.1717f, -1343.872f, 140.4055f)); fHeading.Add(133.4898f);
                    Pos_01.Add(new Vector3(-528.8258f, -1504.724f, 124.409f)); fHeading.Add(89.10454f);
                    Pos_01.Add(new Vector3(-714.8882f, -1458.062f, 42.30001f)); fHeading.Add(58.55215f);
                    iAction = 10;

                    iEnterVeh = 3;
                }       //helitours
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(-286.1589f, 6130.172f, 32.13292f)); fHeading.Add(275.265f);
                    Pos_01.Add(new Vector3(-286.3647f, 6130.907f, 65.98f)); fHeading.Add(281.1871f);
                    Pos_01.Add(new Vector3(-235.833f, 6276.704f, 110.6021f)); fHeading.Add(353.3344f);
                    Pos_01.Add(new Vector3(23.64182f, 6835.598f, 86.64565f)); fHeading.Add(320.9841f);
                    Pos_01.Add(new Vector3(284.416f, 6887.176f, 101.6019f)); fHeading.Add(226.6046f);
                    Pos_01.Add(new Vector3(763.9923f, 6577.445f, 93.83253f)); fHeading.Add(252.6691f);
                    Pos_01.Add(new Vector3(1505.827f, 6548.389f, 108.8764f)); fHeading.Add(272.7405f);
                    Pos_01.Add(new Vector3(1802.909f, 6568.977f, 149.3561f)); fHeading.Add(279.932f);
                    Pos_01.Add(new Vector3(2484.531f, 6498.886f, 200.3775f)); fHeading.Add(250.4998f);
                    Pos_01.Add(new Vector3(3039.205f, 6285.432f, 198.2972f)); fHeading.Add(247.7497f);
                    Pos_01.Add(new Vector3(3278.987f, 5914.606f, 227.383f)); fHeading.Add(185.5986f);
                    Pos_01.Add(new Vector3(3275.25f, 5330.985f, 118.3367f)); fHeading.Add(176.5877f);
                    Pos_01.Add(new Vector3(3189.232f, 5115.614f, 95.28926f)); fHeading.Add(118.7072f);
                    Pos_01.Add(new Vector3(2804.662f, 5091.914f, 127.3515f)); fHeading.Add(83.45394f);
                    Pos_01.Add(new Vector3(2266.839f, 5147.165f, 131.4157f)); fHeading.Add(85.08824f);
                    Pos_01.Add(new Vector3(1800.733f, 5002.501f, 145.9994f)); fHeading.Add(125.2208f);
                    Pos_01.Add(new Vector3(1480.974f, 4630.318f, 183.4221f)); fHeading.Add(143.8588f);
                    Pos_01.Add(new Vector3(901.9067f, 4327.457f, 197.9002f)); fHeading.Add(108.8094f);
                    Pos_01.Add(new Vector3(171.0265f, 4324.955f, 207.0748f)); fHeading.Add(82.35104f);
                    Pos_01.Add(new Vector3(-279.3649f, 4390.429f, 196.3075f)); fHeading.Add(82.40254f);
                    Pos_01.Add(new Vector3(-852.1649f, 4395.291f, 184.6133f)); fHeading.Add(96.01467f);
                    Pos_01.Add(new Vector3(-1271.238f, 4444.289f, 164.0461f)); fHeading.Add(73.29852f);
                    Pos_01.Add(new Vector3(-1553.718f, 4725.6f, 175.09f)); fHeading.Add(21.14607f);
                    Pos_01.Add(new Vector3(-1528.674f, 5186.567f, 162.9194f)); fHeading.Add(313.75f);
                    Pos_01.Add(new Vector3(-1104.559f, 5507.558f, 144.9734f)); fHeading.Add(301.4052f);
                    Pos_01.Add(new Vector3(-600.4811f, 5832.47f, 156.2213f)); fHeading.Add(309.3331f);
                    Pos_01.Add(new Vector3(-360.4607f, 6078.532f, 136.8584f)); fHeading.Add(301.1647f);
                    Pos_01.Add(new Vector3(-316.0546f, 6116.282f, 64.80506f)); fHeading.Add(281.8811f);
                    iAction = 10;

                    iEnterVeh = 3;
                }      //PaletoHeli
            }           //Pilot
            else if (iSelect == 23)
            {
                RandomWeatherTime();

                if (BoolList(20))
                {
                    Pos_01.Add(new Vector3(5308.355f, -5222.566f, 83.51822f)); fHeading.Add(177.7005f);
                    Pos_01.Add(new Vector3(4473.773f, -5041.711f, 112.4676f)); fHeading.Add(3.755754f);
                    Pos_01.Add(new Vector3(3154.248f, -4841.147f, 111.8988f)); fHeading.Add(351.9035f);
                    Pos_01.Add(new Vector3(3271.483f, -4582.126f, 118.072f)); fHeading.Add(183.05f);
                    Pos_01.Add(new Vector3(3558.263f, -4684.025f, 114.5897f)); fHeading.Add(102.3436f);
                }
                else
                {
                    Pos_01.Add(new Vector3(3222.979f, -4692.7f, 112.7545f)); fHeading.Add(174.2392f);
                    Pos_01.Add(new Vector3(3238.098f, -4839.443f, 111.9102f)); fHeading.Add(266.6948f);
                    Pos_01.Add(new Vector3(3341.186f, -4876.17f, 111.7968f)); fHeading.Add(354.3529f);
                    Pos_01.Add(new Vector3(3521.893f, -4851.566f, 111.7791f)); fHeading.Add(164.9078f);
                    Pos_01.Add(new Vector3(3799.094f, -4997.383f, 111.8013f)); fHeading.Add(246.7712f);
                    Pos_01.Add(new Vector3(4389.065f, -5176.559f, 110.9251f)); fHeading.Add(353.9681f);
                    Pos_01.Add(new Vector3(4738.257f, -5103.999f, 106.8863f)); fHeading.Add(357.4206f);
                    iAction = 1;

                    iEnterVeh = RandInt(1, 2);
                }

                iWeapons = 5;

                if (!bInYankton)
                    Yankton(true);
            }           //North Yankton
            else if (iSelect == 24)
            {
                World.CurrentDayTime = TimeSpan.FromHours(12);
                World.Weather = Weather.ExtraSunny;

                iSubSet = FindRandom(12, 1, 6);
                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(4979.349f, -5764.603f, 20.87796f)); fHeading.Add(45.00f);
                    bOpenDoors = true;
                }       //A_C_Panther
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(4893.338f, -4903.796f, 3.486674f)); fHeading.Add(179.7596f);
                    Pos_01.Add(new Vector3(4898.212f, -4913.461f, 3.362877f)); fHeading.Add(62.6438f);
                    Pos_01.Add(new Vector3(4889.125f, -4913.463f, 3.364484f)); fHeading.Add(243.0125f);
                    Pos_01.Add(new Vector3(4886.227f, -4922.317f, 3.370104f)); fHeading.Add(156.813f);
                    Pos_01.Add(new Vector3(4889.59f, -4928.318f, 3.380038f)); fHeading.Add(314.8568f);
                    Pos_01.Add(new Vector3(4898.494f, -4931.63f, 3.367776f)); fHeading.Add(95.74232f);
                    Pos_01.Add(new Vector3(4870.61f, -4930.148f, 2.789379f)); fHeading.Add(333.0222f);
                    Pos_01.Add(new Vector3(4874.745f, -4925.462f, 3.178774f)); fHeading.Add(132.1784f);
                    Pos_01.Add(new Vector3(4869.804f, -4927.207f, 2.743952f)); fHeading.Add(247.7478f);
                    iAction = 12;
                }       //A_F_Y_Beach_02
                else if (iSubSet == 3)
                {
                    if (BoolList(20))
                    {
                        Pos_01.Add(new Vector3(4877.928f, -4488.06f, 26.93383f)); fHeading.Add(7.88381f);
                        Pos_01.Add(new Vector3(5032.213f, -4630.636f, 21.68462f)); fHeading.Add(75.61213f);
                        Pos_01.Add(new Vector3(5153.693f, -4933.251f, 30.87342f)); fHeading.Add(142.8952f);
                        Pos_01.Add(new Vector3(5148.306f, -5053.395f, 20.39156f)); fHeading.Add(85.7536f);
                        Pos_01.Add(new Vector3(5465.802f, -5236.399f, 43.96178f)); fHeading.Add(184.7819f);
                        Pos_01.Add(new Vector3(5360.864f, -5437.077f, 66.17649f)); fHeading.Add(221.3451f);
                        Pos_01.Add(new Vector3(5125.446f, -5526.457f, 70.9704f)); fHeading.Add(199.5584f);
                        Pos_01.Add(new Vector3(4887.5f, -5458.02f, 47.52377f)); fHeading.Add(182.3656f);
                        Pos_01.Add(new Vector3(5042.819f, -5114.771f, 22.94463f)); fHeading.Add(88.81671f);
                        Pos_01.Add(new Vector3(5140.625f, -5243.813f, 26.29192f)); fHeading.Add(253.1926f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(5233.419f, -5043.578f, 14.87521f)); fHeading.Add(43.09966f);
                        Pos_01.Add(new Vector3(5165.328f, -5169.925f, 1.41904f)); fHeading.Add(176.6293f);
                        Pos_01.Add(new Vector3(4941.741f, -5249.38f, 1.856673f)); fHeading.Add(191.2316f);
                        Pos_01.Add(new Vector3(4971.292f, -5701.965f, 19.36028f)); fHeading.Add(38.00845f);
                        Pos_01.Add(new Vector3(5255.248f, -5503.7f, 50.02805f)); fHeading.Add(289.521f);
                        Pos_01.Add(new Vector3(5383.012f, -5666.684f, 49.45168f)); fHeading.Add(348.699f);
                        Pos_01.Add(new Vector3(5250.007f, -5268.963f, 24.84689f)); fHeading.Add(50.79947f);
                        Pos_01.Add(new Vector3(5044.055f, -4904.506f, 14.52278f)); fHeading.Add(277.0196f);
                        Pos_01.Add(new Vector3(4953.167f, -4745.344f, 7.760445f)); fHeading.Add(340.7749f);
                        Pos_01.Add(new Vector3(4928.463f, -4485.532f, 7.438392f)); fHeading.Add(56.79505f);
                        Pos_01.Add(new Vector3(4500.685f, -4494.414f, 3.665595f)); fHeading.Add(287.3625f);
                        iAction = 1;

                        iEnterVeh = RandInt(1, 2);
                    }

                    iWeapons = 5;
                }       //Guard
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(4904.958f, -4941.593f, 3.378354f)); fHeading.Add(37.49379f);
                }       //Bar
                else if (iSubSet == 5)
                {
                    Pos_01.Add(new Vector3(5170.325f, -4675.89f, 2.435122f)); fHeading.Add(66.67837f);
                    Pos_01.Add(new Vector3(5179.303f, -4649.774f, 2.530395f)); fHeading.Add(64.63232f);
                    Pos_01.Add(new Vector3(5127.161f, -4613.125f, 2.567649f)); fHeading.Add(134.3626f);
                    Pos_01.Add(new Vector3(5403.269f, -5174.491f, 31.46002f)); fHeading.Add(30.90309f);
                    Pos_01.Add(new Vector3(5408.926f, -5216.411f, 34.45446f)); fHeading.Add(232.4724f);
                    Pos_01.Add(new Vector3(5382.5f, -5255.195f, 34.15533f)); fHeading.Add(168.2274f);
                    Pos_01.Add(new Vector3(5327.994f, -5265.26f, 33.17245f)); fHeading.Add(216.49f);
                    Pos_01.Add(new Vector3(5312.92f, -5200.948f, 31.73465f)); fHeading.Add(43.35777f);
                    Pos_01.Add(new Vector3(5283.029f, -5239.302f, 30.83397f)); fHeading.Add(226.2264f);
                    Pos_01.Add(new Vector3(5211.092f, -5125.889f, 6.214875f)); fHeading.Add(297.0678f);
                    Pos_01.Add(new Vector3(5182.966f, -5148.639f, 3.549981f)); fHeading.Add(93.57137f);
                    Pos_01.Add(new Vector3(5117.133f, -5172.37f, 2.296359f)); fHeading.Add(90.88295f);
                    Pos_01.Add(new Vector3(5012.493f, -5201.086f, 2.517188f)); fHeading.Add(332.5578f);
                    Pos_01.Add(new Vector3(4957.826f, -5133.129f, 2.44458f)); fHeading.Add(126.1573f);
                    Pos_01.Add(new Vector3(4902.437f, -5180.579f, 2.445158f)); fHeading.Add(256.659f);
                    Pos_01.Add(new Vector3(4949.478f, -5319.582f, 8.065354f)); fHeading.Add(190.8848f);
                    Pos_01.Add(new Vector3(5310.973f, -5600.635f, 64.51008f)); fHeading.Add(298.4847f);
                }       //worker
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(4499.6f, -4523.962f, 4.412367f)); fHeading.Add(276.4212f);
                    iAction = 13;
                }       //pilot
                else
                {
                    Pos_01.Add(new Vector3(4877.928f, -4488.06f, 26.93383f)); fHeading.Add(7.88381f);
                }       //randomOther??

                if (!bInCayoPerico)
                    CayoPerico(true);
            }           //Cayo Perico

            if (bMainProtag)
            {
                if (Game.Player.Character.Model != PedHash.Franklin || Game.Player.Character.Model != PedHash.Michael || Game.Player.Character.Model != PedHash.Trevor)
                    YourRanPed(sMainChar);
            }
            else
            {
                if (bSavedPed)
                    YourSavedPed();
                else
                    YourRanPed(BuildRandomPed(iSelect, iSubSet));
            }

            if (iAction > 0)
            {
                bAllowControl = true;
                Game.DisableControlThisFrame(2, GTA.Control.VehicleExit);

                if (iAction == 1)
                {
                    int iPlace = Pos_01.Count();
                    if (iPlace < 1)
                    {
                        UI.Notify("~r~Debug ~w~No Pos_01's");
                    }
                    else
                    {
                        if (iPlace == 1)
                            iPlace = 0;
                        else
                            iPlace = RandInt(0, iPlace - 1);
                        AddVeh(BuildRandVeh(iSelect, iSubSet), Pos_01[iPlace], fHeading[iPlace], iEnterVeh, iSelect, iSubSet);
                        iPostAction = 1;
                    }
                }            //drive
                else if (iAction == 2)
                {
                    int iPlace = RandInt(0, Pos_01.Count() - 1);

                    Game.Player.Character.Position = Pos_01[iPlace];
                    Game.Player.Character.Heading = fHeading[iPlace];

                    PedScenario(Game.Player.Character, "WORLD_HUMAN_SUNBATHE_BACK", Pos_01[iPlace], fHeading[iPlace], false);

                    iPostAction = 1;
                }       //Sunbath
                else if (iAction == 3)
                {
                    int iPlace = RandInt(0, Pos_01.Count() - 1);
                    Game.Player.Character.Position = Pos_01[iPlace];

                    List<string> sPropers = new List<string>();

                    sPropers.Add("prop_beggers_sign_01");
                    sPropers.Add("prop_beggers_sign_02");
                    sPropers.Add("prop_beggers_sign_03");
                    sPropers.Add("prop_beggers_sign_04");
                    string sProper = sPropers[RandInt(0, 3)];
                    ForceAnim(Game.Player.Character, "amb@lo_res_idles@", "world_human_bum_freeway_lo_res_base", Pos_01[iPlace], new Vector3(0.00f, 0.00f, fHeading[iPlace]));

                    sExitAn_01 = "amb@prop_human_bum_bin@exit";
                    sExitAn_02 = "exit";

                    MyPropBuild(sProper, Pos_01[iPlace], Vector3.Zero, 1);

                    iPostAction = 2;
                }       //TrampSign
                else if (iAction == 4)
                {
                    int iPlace = RandInt(0, Pos_01.Count() - 1);
                    Game.Player.Character.Position = Pos_01[iPlace];

                    ForceAnim(Game.Player.Character, "switch@trevor@scares_tramp", "trev_scares_tramp_idle_tramp", Pos_01[iPlace], new Vector3(0.00f, 0.00f, fHeading[iPlace]));
                    sExitAn_01 = "switch@trevor@scares_tramp";
                    sExitAn_02 = "trev_scares_tramp_exit_tramp";
                    iPostAction = 2;
                }       //TrampSleap
                else if (iAction == 5)
                {
                    int iPlace = RandInt(0, Pos_01.Count() - 1);
                    Game.Player.Character.Position = Pos_01[iPlace];

                    if (iSelect == 7)
                    {
                        if (iPlace == 0)
                            PedScenario(Game.Player.Character, "PROP_HUMAN_SEAT_MUSCLE_BENCH_PRESS", Pos_01[iPlace], fHeading[iPlace], false);
                        else if (iPlace < 3)
                            PedScenario(Game.Player.Character, "PROP_HUMAN_MUSCLE_CHIN_UPS", Pos_01[iPlace], fHeading[iPlace], false);
                        else
                        {
                            int iPose = RandInt(0, 30);
                            if (iPose < 10)
                                PedScenario(Game.Player.Character, "WORLD_HUMAN_SIT_UPS", Pos_01[iPlace], fHeading[iPlace], false);
                            else if (iPose < 20)
                                PedScenario(Game.Player.Character, "WORLD_HUMAN_MUSCLE_FREE_WEIGHTS", Pos_01[iPlace], fHeading[iPlace], false);
                            else
                                PedScenario(Game.Player.Character, "WORLD_HUMAN_PUSH_UPS", Pos_01[iPlace], fHeading[iPlace], false);
                        }
                    }
                    else
                        PedScenario(Game.Player.Character, "WORLD_HUMAN_GARDENER_PLANT", Pos_01[iPlace], fHeading[iPlace], false);
                    iPostAction = 1;
                }       //MuscleBeach
                else if (iAction == 6)
                {
                    iPostAction = 3;

                    if (iSubSet == 1)
                    {
                        vPedTarget = new Vector3(-302.166f, 317.6619f, 92.68359f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(-286.2027f, 311.9702f, 92.69145f);
                        float fRot = 358.9505f;
                        AddVeh("VIRGO2", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-282.5865f, 324.6772f, 92.68803f);
                        fRot = 183.9263f;
                        AddVeh("CHINO2", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-274.7456f, 324.9384f, 92.69529f);
                        fRot = 179.5375f;
                        AddVeh("FACTION3", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-275.7558f, 312.8728f, 92.68794f);
                        fRot = 19.96654f;
                        AddVeh("BUCCANEER2", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(-305.226f, 274.3028f, 87.31434f);
                        fRot = 19.96654f;
                        AddVeh("MINIVAN2", VPos, fRot, 7, iSelect, 8);
                    }           //Import Ex-- West Vine wood-- Vs. Polynesian.
                    else if (iSubSet == 2)
                    {
                        vPedTarget = new Vector3(-450.5249f, -1704.782f, 18.8604f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(-458.0122f, -1719.43f, 18.08753f);
                        float fRot = 336.3535f;
                        AddVeh("SULTAN", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-424.3365f, -1688.027f, 18.49347f);
                        fRot = 162.8363f;
                        AddVeh("FORKLIFT", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(-390.9916f, -1693.444f, 18.16406f);
                        fRot = 151.6561f;
                        AddVeh("FBI2", VPos, fRot, 7, 21, 7);
                    }           //Armenian -- Rogers Salvage and Scrap in La Puerta.-- Vs Police 
                    else if (iSubSet == 3)
                    {
                        vPedTarget = new Vector3(88.2571f, -1926.898f, 19.9731f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(100.9958f, -1929.075f, 19.88203f);
                        float fRot = 160.4151f;
                        AddVeh("EMPEROR", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(113.7581f, -1939.326f, 19.91485f);
                        fRot = 116.716f;
                        AddVeh("PEYOTE", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(106.8031f, -1949.032f, 19.91415f);
                        fRot = 15.96025f;
                        AddVeh("MANANA", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(97.78821f, -1944.386f, 19.94981f);
                        fRot = 312.7894f;
                        AddVeh("VOODOO", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(94.26853f, -1859.033f, 23.66001f);
                        fRot = 141.1448f;
                        AddVeh("BALLER", VPos, fRot, 7, iSelect, 5);

                        RelateReset = World.GetRelationshipBetweenGroups(PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_BALLAS"));
                        World.SetRelationshipBetweenGroups(Relationship.Respect, PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_BALLAS"));
                        World.SetRelationshipBetweenGroups(Relationship.Respect, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_BALLAS"), PlayerGroups);
                        iGrouping = 1;
                    }           //Ballas-- Davis, Vs --Families 
                    else if (iSubSet == 4)
                    {
                        vPedTarget = new Vector3(455.9662f, -728.9713f, 26.54497f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Game.Player.Character.Position = new Vector3(458.5448f, -735.9688f, 27.35763f);
                        Game.Player.Character.Heading = 204.9358f;

                        Vector3 VPos = new Vector3(452.4408f, -682.1255f, 27.24649f);
                        float fRot = 192.9981f;
                        AddVeh("BURRITO", VPos, fRot, 7, iSelect, 6);

                    }           //Chinese textile city, Vs-- korean
                    else if (iSubSet == 5)
                    {
                        vPedTarget = new Vector3(-213.9494f, -1467.139f, 30.95105f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(-224.047f, -1487.307f, 30.99617f);
                        float fRot = 140.3711f;
                        AddVeh("BALLER", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-218.7061f, -1491.246f, 30.95563f);
                        fRot = 139.3282f;
                        AddVeh("TORNADO2", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(-301.5466f, -1441.86f, 30.96148f);
                        fRot = 273.4159f;
                        AddVeh("EMPEROR", VPos, fRot, 7, iSelect, 3);

                        RelateReset = World.GetRelationshipBetweenGroups(PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_FAMILY"));
                        World.SetRelationshipBetweenGroups(Relationship.Respect, PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_FAMILY"));
                        World.SetRelationshipBetweenGroups(Relationship.Respect, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_FAMILY"), PlayerGroups);
                        iGrouping = 2;
                    }           //Families --Strawberry--Chamberlain Hills, Vs  Ballas
                    else if (iSubSet == 6)
                    {
                        vPedTarget = new Vector3(-741.7715f, -1069.828f, 11.82483f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(-755.6411f, -1035.036f, 12.59574f);
                        float fRot = 118.859f;
                        AddVeh("KURUMA", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-737.267f, -1032.804f, 12.42186f);
                        fRot = 299.1285f;
                        AddVeh("ELEGY", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-751.9888f, -1041.709f, 12.31588f);
                        fRot = 116.6273f;
                        AddVeh("FUTO", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-741.7025f, -1045.407f, 12.05153f);
                        fRot = 23.04387f;
                        AddVeh("FUTO", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(-696.5001f, -1061.766f, 14.30107f);
                        fRot = 125.0344f;
                        AddVeh("DUBSTA2", VPos, fRot, 7, iSelect, 4);
                    }            //Korean --K-town, Vs Chinesse
                    else if (iSubSet == 7)
                    {
                        vPedTarget = new Vector3(312.4672f, -2021.409f, 20.13354f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(323.1364f, -2023.899f, 20.57834f);
                        float fRot = 143.4038f;
                        AddVeh("ELEGY", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(320.1991f, -2034.714f, 20.33097f);
                        fRot = 323.2342f;
                        AddVeh("FUTO", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(329.5031f, -2030.321f, 20.78702f);
                        fRot = 141.8689f;
                        AddVeh("KURUMA", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(336.029f, -2037.448f, 20.90948f);
                        fRot = 90.30424f;
                        AddVeh("Z190", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(274.7089f, -2033.892f, 18.23305f);
                        fRot = 316.9213f;
                        AddVeh("RUMPO3", VPos, fRot, 7, iSelect, 9);

                        RelateReset = World.GetRelationshipBetweenGroups(PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_MEXICAN"));
                        World.SetRelationshipBetweenGroups(Relationship.Respect, PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_MEXICAN"));
                        World.SetRelationshipBetweenGroups(Relationship.Respect, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_MEXICAN"), PlayerGroups);
                        iGrouping = 3;
                    }           //Mexican --Rancho--Central Cypress Flats, Vs Salvadoran
                    else if (iSubSet == 8)
                    {
                        vPedTarget = new Vector3(-768.7001f, 5539.55f, 33.00449f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(-753.3419f, 5531.84f, 33.00214f);
                        float fRot = 31.34572f;
                        AddVeh("PANTO", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-747.302f, 5535.622f, 33.00214f);
                        fRot = 28.5319f;
                        AddVeh("RHAPSODY", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-759.3707f, 5547.82f, 33.00235f);
                        fRot = 177.4559f;
                        AddVeh("BRIOSO", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-752.3031f, 5547.335f, 33.00233f);
                        fRot = 177.423f;
                        AddVeh("BLISTA3", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(-773.9064f, 5511.155f, 34.17496f);
                        fRot = 28.73141f;
                        AddVeh("SLAMVAN2", VPos, fRot, 7, iSelect, 10);
                    }           //Polynesian -- ? -- Lost
                    else if (iSubSet == 9)
                    {
                        vPedTarget = new Vector3(1165.813f, -1671.361f, 35.95022f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(1166.919f, -1643.647f, 36.44419f);
                        float fRot = 177.7492f;
                        AddVeh("MANANA", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(1154.781f, -1657.428f, 36.08745f);
                        fRot = 116.5546f;
                        AddVeh("REBEL", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(1157.266f, -1661.953f, 36.12128f);
                        fRot = 117.0901f;
                        AddVeh("PEYOTE", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(1153.491f, -1650.302f, 36.03091f);
                        fRot = 28.40678f;
                        AddVeh("TORNADO2", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(1223.305f, -1684.305f, 39.15781f);
                        fRot = 115.6373f;
                        AddVeh("RUMPO3", VPos, fRot, 7, iSelect, 7);

                        RelateReset = World.GetRelationshipBetweenGroups(PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_SALVA"));
                        World.SetRelationshipBetweenGroups(Relationship.Respect, PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_SALVA"));
                        World.SetRelationshipBetweenGroups(Relationship.Respect, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_SALVA"), PlayerGroups);
                        iGrouping = 4;
                    }           //"Salvadoran --El Burro Heights--Vespucci Beach(night)--East Vinewood Drain Canal, Vs Mexican
                    else if (iSubSet == 10)
                    {
                        vPedTarget = new Vector3(990.1187f, -170.0182f, 71.56162f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(981.2489f, -128.9782f, 73.09866f);
                        float fRot = 63.50796f;
                        AddVeh("DAEMON2", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(965.4485f, -119.1682f, 73.82195f);
                        fRot = 216.7741f;
                        AddVeh("GARGOYLE", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(971.0372f, -115.0153f, 73.82298f);
                        fRot = 218.4778f;
                        AddVeh("CLIFFHANGER", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(979.4431f, -133.8394f, 72.97166f);
                        fRot = 62.28038f;
                        AddVeh("DAEMON", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(961.9417f, -137.4299f, 73.6806f);
                        fRot = 322.8134f;
                        AddVeh("MOONBEAM2", VPos, fRot, 7, iSelect, 1);

                        RelateReset = World.GetRelationshipBetweenGroups(PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_LOST"));
                        World.SetRelationshipBetweenGroups(Relationship.Respect, PlayerGroups, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_LOST"));
                        World.SetRelationshipBetweenGroups(Relationship.Respect, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_LOST"), PlayerGroups);
                        iGrouping = 5;
                    }           //Lost ... Vs Impex
                    else if (iSubSet == 11)
                    {
                        int iLocate = RandInt(0, Pos_01.Count() - 1);

                        Game.Player.Character.Position = Pos_01[iLocate];
                        Game.Player.Character.Heading = fHeading[iLocate];

                        Script.Wait(1000);
                        FindReplacePed(1, Pos_01[iLocate], 55.00f, RandInt(3, 6), 2, 1, false);

                        iWait4 = Game.GameTime + 8000;
                        iPostAction = 8;
                    }           //Street Punk-- Vs Old Ladys
                }       //GangStar--Fixup..
                else if (iAction == 7)
                {
                    RanLoc_01.Clear();
                    RanLoc_01 = Pos_01;

                    iPath = RandInt(1, RanLoc_01.Count() - 1);
                    Game.Player.Character.Position = RanLoc_01[iPath];

                    iPostAction = 4;
                }       //JogOn
                else if (iAction == 8)
                {
                    if (iSubSet == 7)
                    {
                        int iPlace = Pos_01.Count();
                        if (iPlace < 1)
                        {
                            UI.Notify("~r~Debug ~w~No Pos_01's");
                        }
                        else
                        {
                            if (iPlace == 1)
                                iPlace = 0;
                            else
                                iPlace = RandInt(0, iPlace - 1);
                            AddVeh(BuildRandVeh(iSelect, iSubSet), Pos_01[iPlace], fHeading[iPlace], 1, iSelect, iSubSet);
                            iPostAction = 1;
                        }
                    }
                    else
                    {
                        RanLoc_01.Clear();
                        RanLoc_01 = Pos_01;

                        iPath = RandInt(1, RanLoc_01.Count() - 1);
                        vPlayerTarget = RanLoc_01[iPath];
                        AddVeh(BuildRandVeh(iSelect, iSubSet), vPlayerTarget, fHeading[iPath], iEnterVeh, iSelect, iSubSet);

                        iPostAction = 5;
                    }
                }       //Cycles
                else if (iAction == 9)
                {
                    AddVeh(BuildRandVeh(iSelect, iSubSet), Pos_01[Pos_01.Count() - 1], fHeading[Pos_01.Count() - 1], 10, iSelect, iSubSet);
                    iPostAction = 6;
                }       //HelihathNoFury
                else if (iAction == 10)
                {
                    RanLoc_01.Clear();
                    RanLoc_01 = Pos_01;
                    fHeads = fHeading;

                    iPath = RandInt(1, RanLoc_01.Count() - 1);
                    vPlayerTarget = Pos_01[iPath];
                    AddVeh(BuildRandVeh(iSelect, iSubSet), vPlayerTarget, fHeading[iPath], iEnterVeh, 3, 0);
                    iPostAction = 7;
                }      //Helitour
                else if (iAction == 11)
                {
                    int iPlace = RandInt(0, Pos_01.Count() - 1);

                    Game.Player.Character.Position = Pos_01[iPlace];

                    if (fHeading.Count() == Pos_01.Count())
                        Game.Player.Character.Heading = fHeading[iPlace];
                    else
                        Game.Player.Character.Heading = (float)RandInt(0, 360);

                    if (iSelect > 5)
                    {
                        for (int i = 0; i < RandInt(2, 5); i++)
                        {
                            Vector3 vRonud = Pos_01[iPlace].Around(10.00f);
                            vRonud.Z = World.GetGroundHeight(vRonud) + 0.50f;

                            NPCSpawn(BuildRandomPed(iSelect, iSubSet), vRonud, (float)RandInt(0, 360), 1, 0, null, true);
                        }
                    }

                    MethEdd(false);
                    iWait4 = Game.GameTime + 8000;
                    iPostAction = 8;
                }      //MethActing
                else if (iAction == 12)
                {
                    int iPlace = RandInt(0, Pos_01.Count() - 1);
                    Game.Player.Character.Position = Pos_01[iPlace];

                    List<string> DanceSteps = new List<string>();
                    if (Game.Player.Character.Gender == Gender.Male)
                        DanceSteps = DanceList(true, RandInt(1, 3));
                    else
                        DanceSteps = DanceList(false, RandInt(1, 3));

                    if (DanceSteps.Count() > 0)
                        ForceAnim(Game.Player.Character, DanceSteps[0], DanceSteps[1], Game.Player.Character.Position, new Vector3(0.00f, 0.00f, fHeading[iPlace]));

                    sExitAn_01 = "";
                    sExitAn_02 = "";
                    iPostAction = 2;
                }      //Dancing
                else if (iAction == 13)
                {
                    string sChair = "prop_table_03_chr";
                    bool bSeated = false;
                    Game.Player.Character.Position = Pos_01[0];
                    Game.Player.Character.Heading = fHeading[0];
                    Script.Wait(1000);

                    Prop[] PChair = World.GetNearbyProps(Pos_01[0], 2.00f);

                    for (int i = 0; i < PChair.Count(); i++)
                    {
                        if (PChair[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, sChair) && !bSeated)
                        {
                            Vector3 CHpos = new Vector3(PChair[i].Position.X, PChair[i].Position.Y, PChair[i].Position.Z + 0.50f) - (PChair[i].ForwardVector * 0.15f);
                            PedScenario(Game.Player.Character, "PROP_HUMAN_SEAT_CHAIR", CHpos, PChair[i].Heading - 180.00f, true);

                            bSeated = true;
                            break;
                        }
                    }
                    iPostAction = 1;
                }      //Sitting

                Script.Wait(2000);
                Game.FadeScreenIn(1000);
                Script.Wait(1000);
                Game.Player.Character.IsInvincible = false;
            }
            else
            {
                int iPlace = RandInt(0, Pos_01.Count() - 1);

                Game.Player.Character.Position = Pos_01[iPlace];

                if (fHeading.Count() == Pos_01.Count())
                    Game.Player.Character.Heading = fHeading[iPlace];
                else
                    Game.Player.Character.Heading = (float)RandInt(0, 360);

                if (iSelect > 5 && iSelect != 24)
                {
                    for (int i = 0; i < RandInt(2, 5); i++)
                    {
                        Vector3 vRonud = Pos_01[iPlace].Around(10.00f);
                        vRonud.Z = World.GetGroundHeight(vRonud) + 0.50f;

                        NPCSpawn(BuildRandomPed(iSelect, iSubSet), vRonud, (float)RandInt(0, 360), 1, 0, null, true);
                    }
                }

                Script.Wait(2000);
                Game.FadeScreenIn(1000);
                CleanUpMess();
                Script.Wait(1000);
                Game.Player.Character.IsInvincible = false;
            }

            if (bRequestPB)
            {
                vAreaRest = Game.Player.Character.Position;
                AccessAllAreas();
            }

            if (bInCayoPerico)
            {
                Function.Call(Hash.POPULATE_NOW);
                Function.Call(Hash.SET_VEHICLE_POPULATION_BUDGET, 3);
                Function.Call(Hash.SET_PED_POPULATION_BUDGET, 3);
            }

            if (bKeepWeapons)
                ReturnWeaps();
            else
            {
                Game.Player.Character.Weapons.RemoveAll();

                if (iWeapons != 0)
                    PedWeapons(Game.Player.Character, iWeapons);
            }
        }
        public string BuildRandVeh(int iList, int iSubSet)
        {

            LogginSyatem("BuildRandVeh, iList == " + iList + ", iSubSet == " + iSubSet);

            List<string> sVeh = new List<string>();
            string sVehc = "";

            if (iList == 1)
            {
                sVeh.Add("JETMAX"); //>
                sVeh.Add("MARQUIS"); //>
                sVeh.Add("SPEEDER"); //>
                sVeh.Add("SPEEDER2"); //><!-- Speeder yacht variant -->
                sVeh.Add("SQUALO"); //>
                sVeh.Add("SUNTRAP"); //>
                sVeh.Add("TORO"); //>
                sVeh.Add("TORO2"); //><!-- Toro yacht variant -->
                sVeh.Add("TROPIC"); //>
                sVeh.Add("TROPIC2"); //><!-- Tropic yacht variant -->
                if (!bDisableDLCVeh)
                {
                    sVeh.Add("AVISA"); //><!-- Kraken Avisa -->
                    sVeh.Add("LONGFIN"); //><!-- Shitzu Longfin -->
                }
            }
            else if (iList == 3)
            {
                sVeh.Add("PFISTER811"); //><!-- 811 -->
                sVeh.Add("ADDER"); //>
                sVeh.Add("AUTARCH"); //>
                sVeh.Add("BANSHEE2"); //><!-- Banshee 900R -->
                sVeh.Add("BULLET"); //>
                sVeh.Add("CHEETAH"); //>
                sVeh.Add("CYCLONE"); //>
                sVeh.Add("ENTITYXF"); //>
                sVeh.Add("ENTITY2"); //><!-- Entity XXR -->
                sVeh.Add("SHEAVA"); //><!-- ETR1 -->
                sVeh.Add("FMJ"); //>
                sVeh.Add("GP1"); //>
                sVeh.Add("INFERNUS"); //>
                sVeh.Add("ITALIGTB"); //>
                sVeh.Add("ITALIGTB2"); //><!-- Itali GTB Custom -->
                sVeh.Add("OSIRIS"); //>
                sVeh.Add("NERO"); //>
                sVeh.Add("NERO2"); //><!-- Nero Custom -->
                sVeh.Add("PENETRATOR"); //>
                sVeh.Add("REAPER"); //>
                sVeh.Add("SC1"); //>
                sVeh.Add("SULTANRS"); //>
                sVeh.Add("T20"); //>
                sVeh.Add("TAIPAN"); //>
                sVeh.Add("TEMPESTA"); //>
                sVeh.Add("TEZERACT"); //>
                sVeh.Add("TURISMOR"); //>
                sVeh.Add("TYRANT"); //>
                sVeh.Add("TYRUS"); //>
                sVeh.Add("VACCA"); //>
                sVeh.Add("VAGNER"); //>
                sVeh.Add("VIGILANTE"); //>
                sVeh.Add("VISIONE"); //>
                sVeh.Add("PROTOTIPO"); //><!-- X80 Proto -->
                sVeh.Add("XA21"); //>
                sVeh.Add("ZENTORNO"); //>
                sVeh.Add("NINEF"); //>
                sVeh.Add("NINEF2"); //><!-- 9F Cabrio -->
                sVeh.Add("ALPHA"); //>
                sVeh.Add("BANSHEE"); //>
                sVeh.Add("BESTIAGTS"); //>
                sVeh.Add("CARBONIZZARE"); //>
                sVeh.Add("COMET2"); //><!-- Comet -->
                sVeh.Add("COMET3"); //><!-- Comet Retro Custom -->
                sVeh.Add("COMET4"); //><!-- Comet Safari -->
                sVeh.Add("COMET5"); //><!-- Comet SR -->
                sVeh.Add("COQUETTE"); //>
                sVeh.Add("TAMPA2"); //><!-- Drift Tampa -->
                sVeh.Add("ELEGY"); //><!-- Elegy Retro Custom -->
                sVeh.Add("ELEGY2"); //><!-- Elegy RH8 -->
                sVeh.Add("FELTZER2"); //><!-- Feltzer -->
                sVeh.Add("FUROREGT"); //>
                sVeh.Add("GB200"); //>
                sVeh.Add("JESTER"); //>
                sVeh.Add("JESTER2"); //><!-- Jester (Racecar) -->
                sVeh.Add("JESTER3"); //><!-- Jester Classic -->
                sVeh.Add("LYNX"); //>
                sVeh.Add("MASSACRO"); //>
                sVeh.Add("NEON"); //>
                sVeh.Add("OMNIS"); //>
                sVeh.Add("PARIAH"); //>
                sVeh.Add("PENUMBRA"); //>
                sVeh.Add("RAIDEN"); //>
                sVeh.Add("RAPIDGT"); //>
                sVeh.Add("RAPIDGT2"); //><!-- Rapid GT Cabrio -->
                sVeh.Add("REVOLTER"); //>
                sVeh.Add("SEVEN70"); //>
                sVeh.Add("SPECTER"); //>
                sVeh.Add("SPECTER2"); //><!-- Specter Custom -->
                sVeh.Add("BUFFALO3"); //><!-- Sprunk Buffalo -->
                sVeh.Add("STREITER"); //>
                sVeh.Add("SURANO"); //>
                sVeh.Add("TROPOS"); //>
                sVeh.Add("VERLIERER2"); //>
                sVeh.Add("BUCCANEER2"); //><!-- Buccaneer Custom -->
                sVeh.Add("STALION2"); //><!-- Burger Shot Stallion -->
                sVeh.Add("CHINO"); //>
                sVeh.Add("CHINO2"); //><!-- Chino Custom -->
                sVeh.Add("COQUETTE3"); //><!-- Coquette BlackFin -->
                sVeh.Add("DOMINATOR3"); //><!-- Dominator GTX -->
                sVeh.Add("ELLIE"); //>
                sVeh.Add("NIGHTSHADE"); //>
                sVeh.Add("SABREGT2"); //><!-- Sabre Turbo Custom -->
                sVeh.Add("VIRGO2"); //><!-- Virgo Classic Custom -->
                sVeh.Add("Z190"); //><!-- 190z -->
                sVeh.Add("ARDENT"); //>
                sVeh.Add("CASCO"); //>
                sVeh.Add("CHEETAH2"); //><!-- Cheetah Classic -->
                sVeh.Add("COQUETTE2"); //><!-- Coquette Classic -->
                sVeh.Add("INFERNUS2"); //><!-- Infernus Classic -->				
                sVeh.Add("JB700"); //>
                sVeh.Add("MAMBA"); //>				
                sVeh.Add("MICHELLI"); //>	
                sVeh.Add("RAPIDGT3"); //><!-- Rapid GT Classic -->	
                sVeh.Add("BTYPE"); //><!-- Roosevelt -->
                sVeh.Add("BTYPE3"); //><!-- Roosevelt Valor -->	
                sVeh.Add("STINGER"); //>
                sVeh.Add("STINGERGT"); //>		
                sVeh.Add("FELTZER3"); //><!-- Stirling GT -->	
                sVeh.Add("SWINGER"); //>
                sVeh.Add("TORERO"); //>	
                sVeh.Add("VISERIS"); //>
                sVeh.Add("ZTYPE"); //>	
                sVeh.Add("STAFFORD"); //>
                sVeh.Add("SUPERD"); //>
                sVeh.Add("FREECRAWLER"); //>
                sVeh.Add("HELLION");
                sVeh.Add("KALAHARI"); //>
                sVeh.Add("KAMACHO"); //>
                sVeh.Add("MENACER"); //>
                sVeh.Add("CONTENDER"); //>
                sVeh.Add("DUBSTA"); //>
                sVeh.Add("DUBSTA2"); //><!-- Dubsta black variant -->
                sVeh.Add("PATRIOT"); //>
                sVeh.Add("RADI"); //>
                sVeh.Add("ROCOTO"); //>
                sVeh.Add("XLS"); //>
                sVeh.Add("XLS2"); //><!-- XLS (Armored) -->
                if (!bDisableDLCVeh)
                {
                    sVeh.Add("DEVESTE"); //>                ------------DIssapears....
                    sVeh.Add("EMERUS"); //>                ------------DIssapears....
                    sVeh.Add("FURIA"); //>                ------------DIssapears....
                    sVeh.Add("KRIEGER"); //>                ------------DIssapears....
                    sVeh.Add("S80"); //>                ------------DIssapears....
                    sVeh.Add("THRAX"); //>                ------------DIssapears....
                    sVeh.Add("ZORRUSSO"); //>                ------------DIssapears....
                    sVeh.Add("TIGON"); //>                ------------DIssapears....
                    sVeh.Add("DRAFTER"); //><!-- 8F Drafter -->                ------------DIssapears....
                    sVeh.Add("IMORGON"); //>                ------------DIssapears....
                    sVeh.Add("ITALIGTO"); //>                ------------DIssapears....
                    sVeh.Add("JUGULAR"); //>                ------------DIssapears....
                    sVeh.Add("KOMODA"); //>                ------------DIssapears....
                    sVeh.Add("LOCUST"); //>                ------------DIssapears....
                    sVeh.Add("NEO"); //>                ------------DIssapears....
                    sVeh.Add("VSTR"); //><!-- V-STR -->                 ------------DIssapears....
                    sVeh.Add("PENUMBRA2"); //>                ------------DIssapears...
                    sVeh.Add("DEVIANT"); //>                 ------------DIssapears....
                    sVeh.Add("GAUNTLET4"); //><!-- Gauntlet Hellfire -->                 ------------DIssapears....
                    sVeh.Add("TULIP"); //>                 ------------DIssapears....
                    sVeh.Add("JB7002"); //><!-- JB 700W -->                 ------------DIssapears....
                    sVeh.Add("ZION3"); //><!-- Zion Classic -->                 ------------DIssapears....
                    sVeh.Add("COQUETTE4"); //>                 ------------DIssapears....
                    sVeh.Add("DUKES3"); //>                 ------------DIssapears....
                    sVeh.Add("GAUNTLET5"); //>                 ------------DIssapears....
                    sVeh.Add("GLENDALE2"); //>                 ------------DIssapears....
                    sVeh.Add("MANANA2"); //>                 ------------DIssapears....
                    sVeh.Add("PEYOTE3"); //>                 ------------DIssapears....
                    sVeh.Add("YOSEMITE3"); //>                 ------------DIssapears....
                    sVeh.Add("YOUGA3"); //>                 ------------DIssapears....
                    sVeh.Add("TOREADOR"); //><!-- Pegassi Toreador -->
                    sVeh.Add("ITALIRSX"); //><!-- Grotti Itali RSX -->
                    sVeh.Add("champion"); //Dewbauchee Champion
                    sVeh.Add("ignus"); //Pegassi Ignus
                    sVeh.Add("zeno"); //Overflod Zeno
                }
            }
            else if (iList == 4)
            {
                sVeh.Add("BLISTA2"); //><!-- Blista Compact -->
                sVeh.Add("BUFFALO"); //>
                sVeh.Add("BUFFALO2"); //><!-- Buffalo S -->
                sVeh.Add("FLASHGT"); //>
                sVeh.Add("FUTO"); //>
                sVeh.Add("FUSILADE"); //>
                sVeh.Add("KHAMELION"); //>
                sVeh.Add("KURUMA"); //>
                sVeh.Add("RUSTON"); //>
                sVeh.Add("SCHAFTER4"); //><!-- Schafter LWB -->
                sVeh.Add("SCHAFTER3"); //><!-- Schafter V12 -->
                sVeh.Add("SCHWARZER"); //> 
                sVeh.Add("SENTINEL3"); //><!-- Sentinel Classic -->
                sVeh.Add("SULTAN"); //>
                sVeh.Add("COGCABRIO"); //>
                sVeh.Add("EXEMPLAR"); //>
                sVeh.Add("F620"); //>
                sVeh.Add("FELON"); //>
                sVeh.Add("FELON2"); //><!-- Felon GT -->
                sVeh.Add("JACKAL"); //>
                sVeh.Add("ORACLE"); //>
                sVeh.Add("ORACLE2"); //><!-- Oracle XS -->
                sVeh.Add("SENTINEL2"); //><!-- Sentinel -->
                sVeh.Add("SENTINEL"); //><!-- Sentinel XS -->
                sVeh.Add("WINDSOR"); //>
                sVeh.Add("WINDSOR2"); //><!-- Windsor Drop -->
                sVeh.Add("ZION"); //>
                sVeh.Add("ZION2"); //><!-- Zion Cabrio -->
                sVeh.Add("DOMINATOR"); //>
                sVeh.Add("DUKES"); //>
                sVeh.Add("FACTION2"); //><!-- Faction Custom -->
                sVeh.Add("FACTION3"); //><!-- Faction Custom Donk -->
                sVeh.Add("GAUNTLET"); //>
                sVeh.Add("HERMES"); //>
                sVeh.Add("HOTKNIFE"); //>
                sVeh.Add("HUSTLER"); //>
                sVeh.Add("SLAMVAN2"); //><!-- Lost Slamvan -->
                sVeh.Add("LURCHER"); //>
                sVeh.Add("MOONBEAM2"); //><!-- Moonbeam Custom -->
                sVeh.Add("PHOENIX"); //>
                sVeh.Add("DOMINATOR2"); //><!-- Pisswasser Dominator -->
                sVeh.Add("RATLOADER"); //>
                sVeh.Add("RATLOADER2"); //><!-- Rat-Truck -->
                sVeh.Add("GAUNTLET2"); //><!-- Redwood Gauntlet -->
                sVeh.Add("RUINER"); //>
                sVeh.Add("SABREGT"); //>
                sVeh.Add("SLAMVAN3"); //><!-- Slamvan Custom -->
                sVeh.Add("STALION"); //>
                sVeh.Add("TAMPA"); //>
                sVeh.Add("VIGERO"); //>
                sVeh.Add("VIRGO"); //>
                sVeh.Add("VIRGO3"); //><!-- Virgo Classic -->
                sVeh.Add("VOODOO2"); //><!-- Voodoo Custom -->
                sVeh.Add("YOSEMITE"); //>
                sVeh.Add("BTYPE2"); //><!-- FrÃ¤nken Stange -->
                sVeh.Add("GT500"); //>
                sVeh.Add("MONROE"); //>
                sVeh.Add("PEYOTE"); //>
                sVeh.Add("RETINUE"); //>
                sVeh.Add("SAVESTRA"); //>
                sVeh.Add("TORNADO2"); //><!-- Tornado Cabrio -->
                sVeh.Add("TORNADO3"); //><!-- Rusty Tornado -->
                sVeh.Add("TORNADO5"); //><!-- Tornado Custom -->
                sVeh.Add("TORNADO6"); //><!-- Tornado Rat Rod -->
                sVeh.Add("TURISMO2"); //><!-- Turismo Classic -->
                sVeh.Add("FUGITIVE"); //>
                sVeh.Add("PRIMO2"); //><!-- Primo Custom -->
                sVeh.Add("COGNOSCENTI"); //>
                sVeh.Add("COGNOSCENTI2"); //><!-- Cognoscenti (Armored) -->
                sVeh.Add("SCHAFTER2"); //>
                sVeh.Add("SCHAFTER6"); //><!-- Schafter LWB (Armored) -->
                sVeh.Add("SCHAFTER5"); //><!-- Schafter V12 (Armored) -->
                sVeh.Add("SURGE"); //>
                sVeh.Add("TAILGATER"); //>
                sVeh.Add("COG55"); //><!-- Cognoscenti 55 -->
                sVeh.Add("COG552"); //><!-- Cognoscenti 55 (Armored) -->
                sVeh.Add("BIFTA"); //>
                sVeh.Add("BLAZER"); //>
                sVeh.Add("BODHI2"); //>
                sVeh.Add("BRAWLER"); //>
                sVeh.Add("TROPHYTRUCK2"); //><!-- Desert Raid -->
                sVeh.Add("DUNE"); //>
                sVeh.Add("RIATA"); //>
                sVeh.Add("SANDKING2"); //><!-- Sandking SWB -->
                sVeh.Add("SANDKING"); //><!-- Sandking XL -->
                sVeh.Add("TROPHYTRUCK"); //>
                sVeh.Add("BALLER"); //>
                sVeh.Add("BALLER2"); //><!-- Baller 2nd gen variant -->
                sVeh.Add("BALLER3"); //><!-- Baller LE -->
                sVeh.Add("BALLER5"); //><!-- Baller LE (Armored) -->
                sVeh.Add("BALLER4"); //><!-- Baller LE LWB -->
                sVeh.Add("BALLER6"); //><!-- Baller LE LWB (Armored) -->
                sVeh.Add("SEMINOLE"); //>
                sVeh.Add("SERRANO"); //>
                sVeh.Add("HUNTLEY"); //>
                sVeh.Add("LANDSTALKER"); //>
                sVeh.Add("BRIOSO"); //>
                sVeh.Add("ISSI2"); //>
                sVeh.Add("ISSI3"); //><!-- Issi Classic -->
                sVeh.Add("PANTO"); //>
                if (!bDisableDLCVeh)
                {
                    sVeh.Add("ISSI7"); //><!-- Issi Sport -->                ------------DIssapears....
                    sVeh.Add("PARAGON"); //>                ------------DIssapears....
                    sVeh.Add("PARAGON2"); //><!-- Paragon R (Armored) -->                ------------DIssapears....
                    sVeh.Add("SCHLAGEN"); //>                ------------DIssapears....
                    sVeh.Add("SUGOI"); //>                 ------------DIssapears....
                    sVeh.Add("SULTAN2"); //><!-- Sultan Classic -->               ------------DIssapears....
                    sVeh.Add("CLIQUE"); //>                 ------------DIssapears....
                    sVeh.Add("YOSEMITE2"); //><!-- Drift Yosemite -->                 ------------DIssapears....
                    sVeh.Add("GAUNTLET3"); //><!-- Gauntlet Classic -->                 ------------DIssapears....
                    sVeh.Add("PEYOTE2"); //><!-- Peyote Gasser -->                 ------------DIssapears....
                    sVeh.Add("IMPALER"); //>                 ------------DIssapears....
                    sVeh.Add("VAMOS"); //>                 ------------DIssapears....
                    sVeh.Add("DYNASTY"); //>                 ------------DIssapears....
                    sVeh.Add("RETINUE2"); //><!-- Retinue MkII -->                 ------------DIssapears....	
                    sVeh.Add("CARACARA2"); //><!-- Caracara 4x4 -->                 ------------DIssapears....								
                    sVeh.Add("EVERON"); //>                 ------------DIssapears....
                    sVeh.Add("OUTLAW"); //>                 ------------DIssapears....
                    sVeh.Add("VAGRANT"); //>                 ------------DIssapears....
                    sVeh.Add("NOVAK"); //>                 ------------DIssapears....
                    sVeh.Add("REBLA"); //>                 ------------DIssapears....
                    sVeh.Add("TOROS"); //>                 ------------DIssapears....
                    sVeh.Add("LANDSTALKER2"); //>                 ------------DIssapears....
                    sVeh.Add("SEMINOLE2"); //>                 ------------DIssapears....
                    sVeh.Add("ASBO"); //>                 -                        -----------DIssapears....
                    sVeh.Add("KANJO"); //><!-- Blista Kanjo -->                 ------------DIssapears....
                    sVeh.Add("CLUB"); //>                 -                        -----------DIssapears....
                    sVeh.Add("BRIOSO2"); //>Grotti Brioso 300
                    sVeh.Add("WEEVIL"); //><!-- BF Weevil -->
                    sVeh.Add("buffalo4"); //Bravado Buffalo STX
                    sVeh.Add("astron"); //Pfister Astron
                    sVeh.Add("baller7"); //Gallivanter Baller ST
                    sVeh.Add("granger2"); //Declasse Granger 3600LX
                    sVeh.Add("iwagen"); //Obey I-Wagen
                    sVeh.Add("jubilee"); //Enus Jubilee
                    sVeh.Add("patriot3"); //Mammoth Patriot Mil-Spec
                }
            }
            else if (iList == 5)
            {
                sVeh.Add("BLADE"); //>
                sVeh.Add("BUCCANEER"); //>
                sVeh.Add("FACTION"); //>
                sVeh.Add("MOONBEAM"); //>
                sVeh.Add("PICADOR"); //>
                sVeh.Add("SLAMVAN"); //>
                sVeh.Add("VOODOO"); //>
                sVeh.Add("CHEBUREK"); //>
                sVeh.Add("FAGALOA"); //>
                sVeh.Add("MANANA"); //>
                sVeh.Add("PIGALLE"); //>
                sVeh.Add("TORNADO"); //>
                sVeh.Add("TORNADO4"); //><!-- Mariachi Tornado -->
                sVeh.Add("ASEA"); //>
                sVeh.Add("ASTEROPE"); //>
                sVeh.Add("EMPEROR"); //>
                sVeh.Add("EMPEROR2"); //><!-- Emperor beater variant -->
                sVeh.Add("GLENDALE"); //>
                sVeh.Add("INGOT"); //>
                sVeh.Add("INTRUDER"); //>
                sVeh.Add("PREMIER"); //>
                sVeh.Add("PRIMO"); //>
                sVeh.Add("REGINA"); //>
                sVeh.Add("ROMERO"); //>
                sVeh.Add("STANIER"); //>
                sVeh.Add("STRATUM"); //>
                sVeh.Add("WARRENER"); //>
                sVeh.Add("WASHINGTON"); //>
                sVeh.Add("DLOADER"); //>
                sVeh.Add("BFINJECTION"); //>
                sVeh.Add("MESA3"); //><!-- Merryweather Mesa -->
                sVeh.Add("REBEL2"); //>
                sVeh.Add("BJXL"); //>
                sVeh.Add("CAVALCADE"); //>
                sVeh.Add("CAVALCADE2"); //><!-- Cavalcade 2nd gen variant -->
                sVeh.Add("FQ2"); //>
                sVeh.Add("GRANGER"); //>
                sVeh.Add("GRESLEY"); //>
                sVeh.Add("HABANERO"); //>
                sVeh.Add("MESA"); //>
                sVeh.Add("BLISTA"); //>
                sVeh.Add("DILETTANTE"); //>
                sVeh.Add("PRAIRIE"); //>
                sVeh.Add("RHAPSODY"); //>

                if (!bDisableDLCVeh)
                {
                    sVeh.Add("NEBULA"); //>                 ------------DIssapears....
                    sVeh.Add("cinquemila"); //Lampadati Cinquemila
                    sVeh.Add("deity"); //Enus Deity
                }
            }
            else if (iList == 6)
            {
                sVeh.Add("SWIFT2"); //>
            }
            else if (iList == 11)
            {
                sVeh.Add("CADDY"); //>
            }
            else if (iList == 14)
            {
                sVeh.Add("REBEL"); //><!-- Rusty Rebel -->
                sVeh.Add("RANCHERXL"); //>
                sVeh.Add("TRACTOR2"); //>
                sVeh.Add("SCRAP"); //>      
            }
            else if (iList == 15)
            {
                if (iSubSet == 1 || iSubSet == 2)
                {
                    sVeh.Add("TRIBIKE");
                    sVeh.Add("TRIBIKE2");
                    sVeh.Add("TRIBIKE3");
                    sVeh.Add("FIXTER");
                }
                else if (iSubSet == 3 || iSubSet == 4)
                    sVeh.Add("SCORCHER");
                else if (iSubSet == 5 || iSubSet == 6)
                    sVeh.Add("BMX");
                else
                    sVeh.Add("CRUISER");
            }
            else if (iList == 18)
            {
                if (iSubSet == 7)
                {
                    sVeh.Add("STOCKADE");
                }
                else if (iSubSet == 8)
                {
                    sVeh.Add("DILETTANTE2");
                }
                else if (iSubSet == 11)
                {
                    sVeh.Add("BULLDOZER");
                    sVeh.Add("FORKLIFT");
                    sVeh.Add("RIPLEY");
                    sVeh.Add("UTILLITRUCK");
                }
                else if (iSubSet == 12)
                {
                    sVeh.Add("DOCKTUG");
                }
                else if (iSubSet == 13)
                {
                    sVeh.Add("AIRTUG");
                }
                else if (iSubSet == 14)
                {
                    sVeh.Add("TRASH2");
                }
                else if (iSubSet == 17)
                {
                    sVeh.Add("BUS");
                    sVeh.Add("RENTALBUS");
                    sVeh.Add("COACH");
                }
                else if (iSubSet == 19)
                {
                    sVeh.Add("BOXVILLE2");
                }
                else if (iSubSet == 20)
                {
                    sVeh.Add("BOXVILLE2");
                    sVeh.Add("Mule2");
                }
            }
            else if (iList == 19)
            {
                sVeh.Add("SEASHARK");
            }
            else if (iList == 20)
            {
                sVeh.Add("BF400");
                sVeh.Add("MANCHEZ");
                sVeh.Add("SANCHEZ");
                sVeh.Add("BLAZER");
                sVeh.Add("BLAZER5");
                sVeh.Add("BLAZER4");
                if (!bDisableDLCVeh)
                {
                    sVeh.Add("MANCHEZ2"); //><!-- Maibatsu Manchez Scout -->
                    sVeh.Add("VERUS"); //><!-- Dinka Verus -->
                }
            }
            else if (iList == 21)
            {
                if (iSubSet == 1)
                {
                    sVeh.Add("BLAZER2"); //><!-- Blazer Lifeguard -->
                    sVeh.Add("LGUARD"); //>
                }            //"Baywatch 
                else if (iSubSet == 2)
                {
                    sVeh.Add("PREDATOR");
                }       //"US Coastguard
                else if (iSubSet == 3)
                {
                    sVeh.Add("POLICE2"); //><!-- Police Cruiser Buffalo -->
                    sVeh.Add("POLICE"); //><!-- Police Cruiser Stanier -->
                    sVeh.Add("POLICE3"); //><!-- Police Cruiser Interceptor -->
                    sVeh.Add("POLICET"); //><!-- Police Transporter -->
                }       //><!--Cops
                else if (iSubSet == 4)
                {
                    sVeh.Add("POLICEB");
                }       //><!-- PoliceBike
                else if (iSubSet == 5)
                {
                    sVeh.Add("PRANGER"); //><!-- Park Ranger -->
                }       //><!-- Ranger
                else if (iSubSet == 6)
                {
                    sVeh.Add("SHERIFF"); //><!-- Sheriff Cruiser -->
                    sVeh.Add("SHERIFF2"); //><!-- Sheriff SUV -->
                }       //><!-- Sherif
                else if (iSubSet == 7)
                {
                    sVeh.Add("FBI"); //><!-- FIB Buffalo -->
                    sVeh.Add("FBI2"); //><!-- FIB Granger -->
                }       //><!-- fib
                else if (iSubSet == 8)
                {
                    sVeh.Add("RIOT");
                }       //><!-- swat
                else if (iSubSet == 9)
                {
                    sVeh.Add("BARRACKS");
                    sVeh.Add("BARRACKS2");
                    sVeh.Add("BARRAGE");
                    sVeh.Add("CHERNOBOG");
                    sVeh.Add("CRUSADER");
                    sVeh.Add("RHINO");
                    sVeh.Add("KHANJALI");
                    if (!bDisableDLCVeh)
                    {
                        sVeh.Add("SQUADDIE"); //><!-- Mammoth Squaddie -->
                        sVeh.Add("VETIR"); //>Vetir--Patriot truck--
                        sVeh.Add("WINKY"); //><!-- Vapid Winky -->	
                    }
                }       //military
                else if (iSubSet == 10)
                {
                    sVeh.Add("AMBULANCE");
                }       //medic
                else if (iSubSet == 11)
                {
                    sVeh.Add("FIRETRUK");
                }       //fireman
            }       //oddnumbers fixit
            else if (iList == 22)
            {
                if (iSubSet == 1)
                {
                    sVeh.Add("CARGOPLANE"); //>
                    sVeh.Add("CUBAN800"); //>
                    sVeh.Add("JET"); //>
                    sVeh.Add("LUXOR"); //>
                    sVeh.Add("LUXOR2"); //>
                    sVeh.Add("MOGUL"); //>
                    sVeh.Add("SHAMAL"); //>
                    sVeh.Add("VELUM"); //>
                    sVeh.Add("VELUM2"); //>
                }            //civilian
                else if (iSubSet == 2)
                {
                    sVeh.Add("BESRA"); //>
                    sVeh.Add("LAZER"); //>
                    sVeh.Add("NOKOTA"); //>
                    sVeh.Add("PYRO"); //>
                    sVeh.Add("BOMBUSHKA"); //>
                    sVeh.Add("ROGUE"); //>
                    sVeh.Add("TITAN"); //>
                    sVeh.Add("MOLOTOK"); //>
                    sVeh.Add("VOLATOL"); //>
                }       //military
                else if (iSubSet == 3)
                {
                    sVeh.Add("FROGGER"); //>
                }       //Hell tours
                else if (iSubSet == 4)
                {
                    sVeh.Add("SUPERVOLITO2"); //>
                }       //office Hell
            }
            else if (iList == 23)
            {
                sVeh.Add("TRACTOR3"); //>
                sVeh.Add("ASEA2"); //>
                sVeh.Add("EMPEROR3"); //>
                sVeh.Add("RANCHERXL2"); //>
                sVeh.Add("MESA2"); //>
                sVeh.Add("SADLER2"); //>
                sVeh.Add("BURRITO5"); //>
            }
            else if (iList == 24)
            {
                if (iSubSet == 1)
                {

                }       //A_C_Panther
                else if (iSubSet == 2)
                {

                }       //A_F_Y_Beach_02
                else if (iSubSet == 3)
                {
                    if (bDisableDLCVeh)
                    {
                        sVeh.Add("MANCHEZ"); //>
                        sVeh.Add("TECHNICAL"); //>
                        sVeh.Add("MESA3"); //>
                    }
                    else
                    {
                        sVeh.Add("winky"); //Vapid Winky -Road
                        sVeh.Add("vetir"); //Vetir -Military
                        sVeh.Add("slamtruck"); //Vapid Slamtruck -Utility
                        sVeh.Add("VERUS"); //><!-- Dinka Verus -->ATV
                        sVeh.Add("manchez2"); //Maibatsu Manchez Scout -Motorcycles
                    }
                }       //Guard
                else if (iSubSet == 4)
                {

                }       //Bar
                else if (iSubSet == 5)
                {

                }       //worker
                else if (iSubSet == 6)
                {

                }       //pilot
                else
                {
                    sVeh.Add("VETO"); //><!-- Dinka Veto Classic -->GoCart
                    sVeh.Add("VETO2"); //><!-- Dinka Veto Modern -->GoCart
                }       //randomOther??
            }
            if (sVeh.Count() == 1)
                sVehc = sVeh[0];
            else
                sVehc = sVeh[RandInt(0, sVeh.Count() - 1)];

            return sVehc;
        }
        public string BuildRandomPed(int iPedtype, int iSubType)
        {

            LogginSyatem("BuildRandomPed, iPedtype == " + iPedtype + ", iSubType == " + iSubType);

            List<string> sPeddy = new List<string>();

            string sPed = "";

            if (iPedtype == 1)
            {
                sPeddy.Add("a_f_m_beach_01");                //"Beach Female");  
                sPeddy.Add("a_f_m_fatcult_01");                //"Fat Cult Female");  
                sPeddy.Add("a_f_y_hippie_01");                //"Hippie Female"); 
                sPeddy.Add("a_f_y_yoga_01");                //"Yoga Female"); 
                sPeddy.Add("a_m_m_beach_01");                //"Beach Male");  
                sPeddy.Add("a_m_y_beach_01");                //"Beach Young Male");  
                sPeddy.Add("a_m_y_beach_02");                //"Beach Young Male 2");  
                sPeddy.Add("a_m_y_beach_03");                //"Beach Young Male 3"); 
                sPeddy.Add("a_m_y_breakdance_01");                //"Breakdancer Male");
                sPeddy.Add("a_m_y_hippy_01");                //"Hippie Male");  
                sPeddy.Add("a_m_y_sunbathe_01");                //"Sunbather Male");  
                sPeddy.Add("a_m_y_surfer_01");                //"Surfer");
                sPeddy.Add("a_m_y_beachvesp_01");                //"Vespucci Beach Male");  
                sPeddy.Add("a_m_y_beachvesp_02");                //"Vespucci Beach Male 2");  
                sPeddy.Add("a_m_y_stwhi_01");                //"White Street Male");  
                sPeddy.Add("a_m_y_yoga_01");                //"Yoga Male");
            }            //Beach Peds
            else if (iPedtype == 2)
            {
                sPeddy.Add("a_f_m_trampbeac_01");                //"Beach Tramp Female");  
                sPeddy.Add("a_f_m_tramp_01");                //"Tramp Female");  
                sPeddy.Add("a_m_o_beach_01");                //"Beach Old Male");  
                sPeddy.Add("a_m_m_trampbeac_01");                //"Beach Tramp Male");  
                sPeddy.Add("a_m_m_tramp_01");                //"Tramp Male");  
                sPeddy.Add("a_m_o_tramp_01");                //"Tramp Old Male");  
            }       //Tramps
            else if (iPedtype == 3)
            {
                sPeddy.Add("a_f_y_scdressy_01");                //"Dressy Female");  
                sPeddy.Add("a_f_y_bevhills_04");                //"Beverly Hills Young Female 4"); 
                sPeddy.Add("a_f_y_clubcust_01");                //"Club Customer Female 1");  
                sPeddy.Add("a_f_y_clubcust_02");                //"Club Customer Female 2");  
                sPeddy.Add("a_f_y_clubcust_03");                //"Club Customer Female 3"); 
                sPeddy.Add("a_f_y_smartcaspat_01");                //"Formel Casino Guest");  
                sPeddy.Add("s_f_y_movprem_01");                //"Movie Premiere Female");  

                sPeddy.Add("a_m_y_bevhills_02");                //"Beverly Hills Young Male 2"); 
                sPeddy.Add("a_m_y_smartcaspat_01");                //"Formel Casino Guests"); 
                sPeddy.Add("a_m_m_malibu_01");                //"Malibu Male");  
                sPeddy.Add("a_m_y_soucent_04");                //"South Central Young Male 4");  
                sPeddy.Add("s_m_m_movprem_01");                //"Movie Premiere Male");  
            }       //High class
            else if (iPedtype == 4)
            {
                sPeddy.Add("a_f_y_bevhills_01");                //"Beverly Hills Young Female");  
                sPeddy.Add("a_f_y_bevhills_02");                //"Beverly Hills Young Female 2");  
                sPeddy.Add("a_f_y_bevhills_03");                //"Beverly Hills Young Female 3"); 
                sPeddy.Add("a_f_y_eastsa_01");                //"East SA Young Female");  
                sPeddy.Add("a_f_y_eastsa_02");                //"East SA Young Female 2");  
                sPeddy.Add("a_f_y_genhot_01");                //"General Hot Young Female");  
                sPeddy.Add("a_f_y_hipster_01");                //"Hipster Female");  
                sPeddy.Add("a_f_y_hipster_02");                //"Hipster Female 2");  
                sPeddy.Add("a_f_y_hipster_03");                //"Hipster Female 3");  
                sPeddy.Add("a_f_y_hipster_04");                //"Hipster Female 4"); 
                sPeddy.Add("a_f_y_indian_01");                //"Indian Young Female");  
                sPeddy.Add("a_f_y_soucent_03");                //"South Central Young Female 3");  
                sPeddy.Add("a_f_y_tourist_01");                //"Tourist Young Female");  
                sPeddy.Add("a_f_y_vinewood_01");                //"Vinewood Female");  
                sPeddy.Add("a_f_y_vinewood_02");                //"Vinewood Female 2");  
                sPeddy.Add("a_f_y_vinewood_03");                //"Vinewood Female 3");  
                sPeddy.Add("a_f_y_vinewood_04");                //"Vinewood Female 4"); 

                sPeddy.Add("a_m_m_afriamer_01");                //"African American Male");  
                sPeddy.Add("a_m_m_bevhills_01");                //"Beverly Hills Male");  
                sPeddy.Add("a_m_m_bevhills_02");                //"Beverly Hills Male 2");  
                sPeddy.Add("a_m_y_bevhills_01");                //"Beverly Hills Young Male");  
                sPeddy.Add("a_m_y_stbla_02");                //"Black Street Male 2");
                sPeddy.Add("a_m_y_gencaspat_01");                //"Casual Casino Guests");  
                sPeddy.Add("a_m_y_genstreet_01");                //"General Street Young Male");  
                sPeddy.Add("a_m_y_genstreet_02");                //"General Street Young Male 2");  
                sPeddy.Add("a_m_m_hasjew_01");                //"Hasidic Jew Male");  
                sPeddy.Add("a_m_y_hasjew_01");                //"Hasidic Jew Young Male");  
                sPeddy.Add("a_m_y_hipster_01");                //"Hipster Male");  
                sPeddy.Add("a_m_y_hipster_02");                //"Hipster Male 2");  
                sPeddy.Add("a_m_y_hipster_03");                //"Hipster Male 3");  
                sPeddy.Add("a_m_y_indian_01");                //"Indian Young Male");  
                sPeddy.Add("a_m_y_ktown_01");                //"Korean Young Male");  
                sPeddy.Add("a_m_y_ktown_02");                //"Korean Young Male 2");  
                sPeddy.Add("a_m_y_polynesian_01");                //"Polynesian Young"); 
                sPeddy.Add("a_m_y_vindouche_01");                //"Vinewood Douche");  
                sPeddy.Add("a_m_y_vinewood_01");                //"Vinewood Male");  
                sPeddy.Add("a_m_y_vinewood_02");                //"Vinewood Male 2");  
                sPeddy.Add("a_m_y_vinewood_03");                //"Vinewood Male 3");  
                sPeddy.Add("a_m_y_vinewood_04");                //"Vinewood Male 4");  
                sPeddy.Add("a_m_y_stwhi_02");                //"White Street Male 2"); 
                sPeddy.Add("a_m_y_clubcust_01");                //"Club Customer Male 1");  
                sPeddy.Add("a_m_y_clubcust_02");                //"Club Customer Male 2");  
                sPeddy.Add("a_m_y_clubcust_03");                //"Club Customer Male 3"); 
            }       //Mid class
            else if (iPedtype == 5)
            {
                sPeddy.Add("a_f_m_downtown_01");                //"Downtown Female"); 
                sPeddy.Add("a_f_y_gencaspat_01");                //"Casual Casino Guest");  
                sPeddy.Add("a_f_m_eastsa_01");                //"East SA Female");  
                sPeddy.Add("a_f_m_eastsa_02");                //"East SA Female 2");  
                sPeddy.Add("a_f_m_fatbla_01");                //"Fat Black Female");  
                sPeddy.Add("a_f_m_fatwhite_01");                //"Fat White Female");  
                sPeddy.Add("a_f_o_genstreet_01");                //"General Street Old Female");  
                sPeddy.Add("a_f_o_indian_01");                //"Indian Old Female");  
                sPeddy.Add("a_f_m_ktown_01");                //"Korean Female");  
                sPeddy.Add("a_f_m_ktown_02");                //"Korean Female 2");  
                sPeddy.Add("a_f_o_ktown_01");                //"Korean Old Female");  
                sPeddy.Add("a_f_m_skidrow_01");                //"Skid Row Female");  
                sPeddy.Add("a_f_m_soucent_01");                //"South Central Female");  
                sPeddy.Add("a_f_m_soucent_02");                //"South Central Female 2");  
                sPeddy.Add("a_f_m_soucentmc_01");                //"South Central MC Female");  
                sPeddy.Add("a_f_o_soucent_01");                //"South Central Old Female");  
                sPeddy.Add("a_f_o_soucent_02");                //"South Central Old Female 2");  
                sPeddy.Add("a_f_y_soucent_01");                //"South Central Young Female");  
                sPeddy.Add("a_f_y_soucent_02");                //"South Central Young Female 2");  
                sPeddy.Add("a_f_m_tourist_01");                //"Tourist Female");              
                sPeddy.Add("a_f_y_tourist_02");                //"Tourist Young Female 2");  

                sPeddy.Add("a_m_y_stbla_01");                //"Black Street Male");  
                sPeddy.Add("a_m_y_downtown_01");                //"Downtown Male");  
                sPeddy.Add("a_m_m_eastsa_01");                //"East SA Male");  
                sPeddy.Add("a_m_m_eastsa_02");                //"East SA Male 2");  
                sPeddy.Add("a_m_y_eastsa_01");                //"East SA Young Male");  
                sPeddy.Add("a_m_y_eastsa_02");                //"East SA Young Male 2");  
                sPeddy.Add("a_m_m_fatlatin_01");                //"Fat Latino Male");  
                sPeddy.Add("a_m_m_genfat_01");                //"General Fat Male");  
                sPeddy.Add("a_m_m_genfat_02");                //"General Fat Male 2");  
                sPeddy.Add("a_m_o_genstreet_01");                //"General Street Old Male");  
                sPeddy.Add("a_m_m_indian_01");                //"Indian Male"); 
                sPeddy.Add("a_m_m_ktown_01");                //"Korean Male");  
                sPeddy.Add("a_m_o_ktown_01");                //"Korean Old Male"); 
                sPeddy.Add("a_m_m_stlat_02");                //"Latino Street Male 2");  
                sPeddy.Add("a_m_y_stlat_01");                //"Latino Street Young Male");  
                sPeddy.Add("a_m_y_latino_01");                //"Latino Young Male");
                sPeddy.Add("a_m_m_mexlabor_01");                //"Mexican Labourer");  
                sPeddy.Add("a_m_m_mexcntry_01");                //"Mexican Rural"); 
                sPeddy.Add("a_m_m_polynesian_01");                //"Polynesian");   
                sPeddy.Add("a_m_m_skidrow_01");                //"Skid Row Male");  
                sPeddy.Add("a_m_m_socenlat_01");                //"South Central Latino Male");  
                sPeddy.Add("a_m_m_soucent_01");                //"South Central Male");  
                sPeddy.Add("a_m_m_soucent_02");                //"South Central Male 2");  
                sPeddy.Add("a_m_m_soucent_03");                //"South Central Male 3");  
                sPeddy.Add("a_m_m_soucent_04");                //"South Central Male 4");  
                sPeddy.Add("a_m_o_soucent_01");                //"South Central Old Male");  
                sPeddy.Add("a_m_o_soucent_02");                //"South Central Old Male 2");  
                sPeddy.Add("a_m_o_soucent_03");                //"South Central Old Male 3");  
                sPeddy.Add("a_m_y_soucent_01");                //"South Central Young Male");  
                sPeddy.Add("a_m_y_soucent_02");                //"South Central Young Male 2");  
                sPeddy.Add("a_m_y_soucent_03");                //"South Central Young Male 3"); 
                sPeddy.Add("a_m_m_tourist_01");                //"Tourist Male");  
                sPeddy.Add("g_m_m_casrn_01");                //"Casino Guests?");  
            }       //Low class 
            else if (iPedtype == 6)
            {
                sPeddy.Add("a_f_m_bevhills_01");                //"Beverly Hills Female");  
                sPeddy.Add("a_f_m_bevhills_02");                //"Beverly Hills Female 2"); 
                sPeddy.Add("a_f_m_business_02");                //"Business Female 2");  
                sPeddy.Add("a_f_y_business_01");                //"Business Young Female");  
                sPeddy.Add("a_f_y_business_02");                //"Business Young Female 2");  
                sPeddy.Add("a_f_y_business_03");                //"Business Young Female 3");  
                sPeddy.Add("a_f_y_business_04");                //"Business Young Female 4");  
                sPeddy.Add("a_f_y_femaleagent");                //"Female Agent");  

                sPeddy.Add("a_m_y_busicas_01");                //"Business Casual");  
                sPeddy.Add("a_m_m_business_01");                //"Business Male");  
                sPeddy.Add("a_m_y_business_01");                //"Business Young Male");  
                sPeddy.Add("a_m_y_business_02");                //"Business Young Male 2");  
                sPeddy.Add("a_m_y_business_03");                //"Business Young Male 3");  
                sPeddy.Add("a_m_m_prolhost_01");                //"Prologue Host Male");  
            }       //Buisness
            else if (iPedtype == 7)
            {
                sPeddy.Add("a_f_m_bodybuild_01");                //"Bodybuilder Female");  
                sPeddy.Add("a_m_y_musclbeac_01");                //"Beach Muscle Male");  
                sPeddy.Add("a_m_y_musclbeac_02");                //"Beach Muscle Male 2");  
            }       //Body builder
            else if (iPedtype == 8)
            {
                if (iSubType == 1)
                {
                    sPeddy.Add("g_f_importexport_01");                //"Gang Female (Import-Export)"); 
                    sPeddy.Add("a_f_y_eastsa_03");                //"East SA Young Female 3"); 
                    sPeddy.Add("g_f_importexport_01");                //"Import Export Female"); 
                    sPeddy.Add("g_m_importexport_01");                //"Gang Male (Import-Export)");
                }
                else if (iSubType == 2)
                {
                    sPeddy.Add("g_m_m_armboss_01");                //"Armenian Boss");  Rogers Salvage and Scrap in La Puerta.-- NON -- 
                    sPeddy.Add("g_m_m_armgoon_01");                //"Armenian Goon");  
                    sPeddy.Add("g_m_y_armgoon_02");                //"Armenian Goon 2");  
                    sPeddy.Add("g_m_m_armlieut_01");                //"Armenian Lieutenant");  
                }
                else if (iSubType == 3)
                {
                    sPeddy.Add("g_f_y_ballas_01");                //"Ballas Female"); Davis,--Families--Vagos
                    sPeddy.Add("g_m_y_ballaeast_01");                //"Ballas East Male");  
                    sPeddy.Add("g_m_y_ballaorig_01");                //"Ballas Original Male");  
                    sPeddy.Add("g_m_y_ballasout_01");                //"Ballas South Male");  
                }
                else if (iSubType == 4)
                {
                    sPeddy.Add("g_m_m_chiboss_01");                //"Chinese Boss");   textstyle-- korean
                    sPeddy.Add("g_m_m_chigoon_01");                //"Chinese Goon");  
                    sPeddy.Add("g_m_m_chigoon_02");                //"Chinese Goon 2");  
                    sPeddy.Add("g_m_m_chicold_01");                //"Chinese Goon Older");  
                }
                else if (iSubType == 5)
                {
                    sPeddy.Add("g_f_y_families_01");                //"Families Female");Strawberry--Chamberlain Hills-- Ballas-- Vagos-- Mexican Street Gang-- The Lost MC--
                    sPeddy.Add("g_m_y_famca_01");                //"Families CA Male");  
                    sPeddy.Add("g_m_y_famdnf_01");                //"Families DNF Male");  
                    sPeddy.Add("g_m_y_famfor_01");                //"Families FOR Male"); 
                }
                else if (iSubType == 6)
                {
                    sPeddy.Add("g_m_m_korboss_01");                //"Korean Boss");  K-town-- Chinesse
                    sPeddy.Add("g_m_y_korlieut_01");                //"Korean Lieutenant");  
                    sPeddy.Add("g_m_y_korean_01");                //"Korean Young Male");  
                    sPeddy.Add("g_m_y_korean_02");                //"Korean Young Male 2");  
                }
                else if (iSubType == 7)
                {
                    sPeddy.Add("g_m_y_azteca_01");                //"Azteca"); 
                    sPeddy.Add("g_f_y_vagos_01");                //"Vagos Female"); Rancho--Central Cypress Flats,--Families--Ballas
                    sPeddy.Add("a_m_y_mexthug_01");                //"Mexican Thug"); -- Northern Rancho --The Lost MC--Salvadoran Street Gang
                    sPeddy.Add("g_m_m_mexboss_01");                //"Mexican Boss");  
                    sPeddy.Add("g_m_m_mexboss_02");                //"Mexican Boss 2");  
                    sPeddy.Add("g_m_y_mexgang_01");                //"Mexican Gang Member");  
                    sPeddy.Add("g_m_y_mexgoon_01");                //"Mexican Goon");  
                    sPeddy.Add("g_m_y_mexgoon_02");                //"Mexican Goon 2");  
                    sPeddy.Add("g_m_y_mexgoon_03");                //"Mexican Goon 3");  
                }
                else if (iSubType == 8)
                {
                    sPeddy.Add("g_m_y_pologoon_01");                //"Polynesian Goon");  
                    sPeddy.Add("g_m_y_pologoon_02");                //"Polynesian Goon 2");  
                }
                else if (iSubType == 9)
                {
                    sPeddy.Add("g_m_y_salvaboss_01");                //"Salvadoran Boss");  El Burro Heights--Vespucci Beach(night)--East Vinewood Drain Canal,---Mexican Street Gang--Los Santos Vagos--Ballas
                    sPeddy.Add("g_m_y_salvagoon_01");                //"Salvadoran Goon");  
                    sPeddy.Add("g_m_y_salvagoon_02");                //"Salvadoran Goon 2");  
                    sPeddy.Add("g_m_y_salvagoon_03");                //"Salvadoran Goon 3");  
                }
                else if (iSubType == 10)
                {
                    sPeddy.Add("g_f_y_lost_01");                //"The Lost MC Female");  
                    sPeddy.Add("g_m_y_lost_01");                //"The Lost MC Male");  
                    sPeddy.Add("g_m_y_lost_02");                //"The Lost MC Male 2");  
                    sPeddy.Add("g_m_y_lost_03");                //"The Lost MC Male 3");
                }
                else if (iSubType == 11)
                {
                    sPeddy.Add("g_m_y_strpunk_01");                //"Street Punk");  
                    sPeddy.Add("g_m_y_strpunk_02");                //"Street Punk 2");  
                }
            }       //GangStars--Subset
            else if (iPedtype == 9)
            {
                sPeddy.Add("a_f_y_epsilon_01");                //"Epsilon Female");  
                sPeddy.Add("a_m_y_epsilon_01");                //"Epsilon Male");  
                sPeddy.Add("a_m_y_epsilon_02");                //"Epsilon Male 2"); 
            }       //Epslon 
            else if (iPedtype == 10)
            {
                sPeddy.Add("a_f_y_fitness_01");                //"Fitness Female");  
                sPeddy.Add("a_f_y_fitness_02");                //"Fitness Female 2");  
                sPeddy.Add("a_f_y_runner_01");                //"Jogger Female");
                sPeddy.Add("a_f_y_tennis_01");                //"Tennis Player Female");  
                sPeddy.Add("a_m_y_runner_01");                //"Jogger Male");  
                sPeddy.Add("a_m_y_runner_02");                //"Jogger Male 2"); 
            }       //Jogger
            else if (iPedtype == 11)
            {
                sPeddy.Add("a_f_y_golfer_01");                //"Golfer Young Female");  
                sPeddy.Add("a_m_m_golfer_01");                //"Golfer Male");  
                sPeddy.Add("a_m_y_golfer_01");                //"Golfer Young Male");  
            }       //Golfer
            else if (iPedtype == 12)
            {
                sPeddy.Add("a_f_y_hiker_01");                //"Hiker Female");  
                sPeddy.Add("a_m_y_hiker_01");                //"Hiker Male");  
            }       //Hiker
            else if (iPedtype == 13)
            {
                sPeddy.Add("a_f_y_juggalo_01");                //"Juggalo Female");  
                sPeddy.Add("a_m_y_juggalo_01");                //"Juggalo Male"); 
                sPeddy.Add("a_f_y_rurmeth_01");                //"Rural Meth Addict Female");  
                sPeddy.Add("a_m_m_rurmeth_01");                //"Rural Meth Addict Male");  
            }       //Meth
            else if (iPedtype == 14)
            {
                sPeddy.Add("a_f_m_salton_01");                //"Salton Female");  
                sPeddy.Add("a_f_o_salton_01");                //"Salton Old Female");  
                sPeddy.Add("a_m_m_farmer_01");                //"Farmer"); 
                sPeddy.Add("a_m_m_hillbilly_01");                //"Hillbilly Male");  
                sPeddy.Add("a_m_m_hillbilly_02");                //"Hillbilly Male 2");  
                sPeddy.Add("a_m_y_methhead_01");                //"Meth Addict");  

                sPeddy.Add("a_m_m_salton_01");                //"Salton Male");  
                sPeddy.Add("a_m_m_salton_02");                //"Salton Male 2");  
                sPeddy.Add("a_m_m_salton_03");                //"Salton Male 3");  
                sPeddy.Add("a_m_m_salton_04");                //"Salton Male 4");  
                sPeddy.Add("a_m_o_salton_01");                //"Salton Old Male");  
                sPeddy.Add("a_m_y_salton_01");                //"Salton Young Male");  
                sPeddy.Add("s_m_m_cntrybar_01");                //"Bartender (Rural)"); 
            }       //Rural 
            else if (iPedtype == 15)
            {
                sPeddy.Add("a_f_y_skater_01");                //"Skater Female");  
                sPeddy.Add("a_m_y_cyclist_01");                //"Cyclist Male");  
                sPeddy.Add("a_m_y_dhill_01");                //"Downhill Cyclist"); 
                sPeddy.Add("a_m_y_roadcyc_01");                //"Road Cyclist");  
                sPeddy.Add("a_m_y_skater_01");                //"Skater Young Male");  
                sPeddy.Add("a_m_y_skater_02");                //"Skater Young Male 2");  
                sPeddy.Add("a_m_m_tennis_01");                //"Tennis Player Male");  
            }       //Cycles
            else if (iPedtype == 16)
            {
                sPeddy.Add("a_m_y_gay_01");                //"Gay Male");  
                sPeddy.Add("a_m_y_gay_02");                //"Gay Male 2"); 
                sPeddy.Add("a_m_m_tranvest_01");                //"Transvestite Male");  
                sPeddy.Add("a_m_m_tranvest_02");                //"Transvestite Male 2"); 
            }       //LGBTQWSTRVX
            else if (iPedtype == 17)
            {
                sPeddy.Add("a_f_y_beach_01");                //"Beach Young Female"); --Acc set to 1 for swimm 
                sPeddy.Add("a_m_m_beach_02");                //"Beach Male 2");--set torso to 0 for swim
            }       //Pool Peds
            else if (iPedtype == 18)
            {
                if (iSubType == 1)
                {
                    sPeddy.Add("mp_f_bennymech_01");                //"Benny Mechanic (Female)"); 
                    sPeddy.Add("s_m_m_autoshop_01");                //"Autoshop Worker");  
                    sPeddy.Add("s_m_m_autoshop_02");                //"Autoshop Worker 2");  
                }
                else if (iSubType == 2)
                {
                    sPeddy.Add("s_f_y_bartender_01");                //"Bartender");  
                    sPeddy.Add("s_f_y_clubbar_01");                //"Club Bartender Female"); 
                    sPeddy.Add("s_m_y_barman_01");                //"Barman");
                    sPeddy.Add("s_m_y_waiter_01");                //"Waiter"); 
                }
                else if (iSubType == 3)
                {
                    sPeddy.Add("s_f_y_factory_01");                //"Factory Worker Female");  
                    sPeddy.Add("s_f_m_sweatshop_01");                //"Sweatshop Worker");  
                    sPeddy.Add("s_f_y_sweatshop_01");                //"Sweatshop Worker Young");  
                }
                else if (iSubType == 4)
                {
                    sPeddy.Add("mp_m_shopkeep_01");                //"Shopkeeper (Male)"); 
                }
                else if (iSubType == 5)
                {
                    sPeddy.Add("s_f_y_scrubs_01");                //"Hospital Scrubs Female");  
                    sPeddy.Add("s_m_m_doctor_01");                //"Doctor"); 
                }
                else if (iSubType == 6)
                {
                    sPeddy.Add("s_f_m_maid_01");                //"Maid");  
                    sPeddy.Add("s_f_y_migrant_01");                //"Migrant Female--cleaner");  
                    sPeddy.Add("s_m_m_migrant_01");                //"Migrant Male");  
                }
                else if (iSubType == 7)
                {
                    sPeddy.Add("mp_s_m_armoured_01");                //"Armoured Van Security Male"); 
                    sPeddy.Add("s_m_m_armoured_01");                //"Armoured Van Security");  
                    sPeddy.Add("s_m_m_armoured_02");                //"Armoured Van Security 2"); 
                }
                else if (iSubType == 8)
                {
                    sPeddy.Add("s_m_m_chemsec_01");                //"Chemical Plant Security");  
                    sPeddy.Add("mp_m_securoguard_01");                //"Securoserve Guard (Male)"); 
                    sPeddy.Add("s_m_m_security_01");                //"Security Guard");  
                }
                else if (iSubType == 9)
                {
                    sPeddy.Add("s_m_y_autopsy_01");                //"Autopsy Tech");  
                    sPeddy.Add("s_m_m_scientist_01");                //"Scientist");  
                }
                else if (iSubType == 10)
                {
                    sPeddy.Add("g_m_m_chemwork_01");                //"Chemical Plant Worker");  
                }
                else if (iSubType == 11)
                {
                    sPeddy.Add("s_m_y_construct_01");                //"construction Worker");  
                    sPeddy.Add("s_m_y_construct_02");                //"construction Worker 2");  
                }
                else if (iSubType == 12)
                {
                    sPeddy.Add("s_m_m_dockwork_01");                //"Dock Worker");  
                    sPeddy.Add("s_m_y_dockwork_01");                //"Dock Worker");  
                }
                else if (iSubType == 13)
                {
                    sPeddy.Add("s_m_y_airworker");                //"Air Worker Male"); 
                    sPeddy.Add("s_m_y_dwservice_01");                //"DW Airport Worker");  
                    sPeddy.Add("s_m_y_dwservice_02");                //"DW Airport Worker 2");   
                }
                else if (iSubType == 14)
                {
                    sPeddy.Add("s_m_y_garbage");                //"Garbage Worker");  
                }
                else if (iSubType == 15)
                {
                    sPeddy.Add("s_m_m_gardener_01");                //"Gardener");  
                    sPeddy.Add("s_m_m_lathandy_01");                //"Latino Handyman Male");  
                }
                else if (iSubType == 16)
                {
                    sPeddy.Add("s_m_m_lsmetro_01");                //"LS Metro Worker Male");  
                }
                else if (iSubType == 17)
                {
                    sPeddy.Add("s_m_m_gentransport");                //"Transport Worker Male");  
                }
                else if (iSubType == 18)
                {
                    sPeddy.Add("s_m_y_pestcont_01");                //"Pest Control");  
                }
                else if (iSubType == 19)
                {
                    sPeddy.Add("s_m_m_postal_01");                //"Postal Worker Male");  
                    sPeddy.Add("s_m_m_postal_02");                //"Postal Worker Male 2");  
                }
                else if (iSubType == 20)
                {
                    sPeddy.Add("s_m_m_ups_01");                //"UPS Driver");  
                    sPeddy.Add("s_m_m_ups_02");                //"UPS Driver 2");  
                }
                else if (iSubType == 21)
                {
                    sPeddy.Add("s_m_m_strvend_01");                //"Street Vendor");  
                    sPeddy.Add("s_m_y_strvend_01");                //"Street Vendor Young");  
                }
                else if (iSubType == 22)
                {
                    sPeddy.Add("s_m_y_valet_01");                //"Valet");  
                }
                else if (iSubType == 23)
                {
                    sPeddy.Add("s_m_y_winclean_01");                //"Window Cleaner");   
                }
            }       //Workers--Subset
            else if (iPedtype == 19)
            {
                sPeddy.Add("a_m_y_jetski_01");                //"Jetskier");  
            }       //jet ski
            else if (iPedtype == 20)
            {
                sPeddy.Add("a_m_y_motox_01");                //"Motocross Biker");  
                sPeddy.Add("a_m_y_motox_02");                //"Motocross Biker 2"); 
            }       //Bike/ATV Male
            else if (iPedtype == 21)
            {
                if (iSubType == 1)
                {
                    sPeddy.Add("s_f_y_baywatch_01");                //"Baywatch Female"); 
                    sPeddy.Add("s_m_y_baywatch_01");                //"Baywatch Male"); 
                }
                else if (iSubType == 2)
                {
                    sPeddy.Add("s_m_y_uscg_01");                //"US Coastguard"); 
                }
                else if (iSubType == 3)
                {
                    sPeddy.Add("s_m_y_cop_01");                //"Cop Male");  
                    sPeddy.Add("s_f_y_cop_01");                //"Cop Female");
                }
                else if (iSubType == 4)
                {
                    sPeddy.Add("s_m_y_hwaycop_01");                //"Highway Cop");  
                }
                else if (iSubType == 5)
                {
                    sPeddy.Add("s_f_y_ranger_01");                //"Ranger Female"); 
                    sPeddy.Add("s_m_y_ranger_01");                //"Ranger Male");  
                }
                else if (iSubType == 6)
                {
                    sPeddy.Add("s_f_y_sheriff_01");                //"Sheriff Female"); 
                    sPeddy.Add("s_m_y_sheriff_01");                //"Sheriff Male");  
                }
                else if (iSubType == 7)
                {
                    sPeddy.Add("s_m_m_fibsec_01");                //"FIB Security"); 
                }
                else if (iSubType == 8)
                {
                    sPeddy.Add("s_m_y_swat_01");                //"SWAT");  
                }
                else if (iSubType == 9)
                {
                    sPeddy.Add("s_m_y_armymech_01");                //"Army Mechanic");  
                    sPeddy.Add("s_m_m_ccrew_01");                //"Crew Member"); 
                    sPeddy.Add("s_m_y_blackops_01");                //"Black Ops Soldier");  
                    sPeddy.Add("s_m_y_blackops_02");                //"Black Ops Soldier 2");  
                    sPeddy.Add("s_m_y_blackops_03");                //"Black Ops Soldier 3");  
                    sPeddy.Add("s_m_m_marine_01");                //"Marine");  
                    sPeddy.Add("s_m_m_marine_02");                //"Marine 2");  
                    sPeddy.Add("s_m_y_marine_01");                //"Marine Young");  
                    sPeddy.Add("s_m_y_marine_02");                //"Marine Young 2");  
                    sPeddy.Add("s_m_y_marine_03");                //"Marine Young 3"); 
                }
                else if (iSubType == 10)
                {
                    sPeddy.Add("s_m_m_paramedic_01");                //"Paramedic"); 
                }
                else if (iSubType == 11)
                {
                    sPeddy.Add("s_m_y_fireman_01");                //"Fireman Male"); 
                }
            }       //Services
            else if (iPedtype == 22)
            {
                if (iSubType == 1)
                    sPeddy.Add("s_m_y_pilot_01");                //"Pilot");  
                else if (iSubType == 2)
                    sPeddy.Add("s_m_m_pilot_02");                //"Pilot 2"); 
                else if (iSubType == 3)
                    sPeddy.Add("s_m_m_pilot_01");                //"Pilot");  
                else if (iSubType == 4)
                    sPeddy.Add("mp_f_helistaff_01");                //"Heli-Staff Female" />
            }       //Pilot
            else if (iPedtype == 23)
            {
                sPeddy.Add("csb_prologuedriver");
                sPeddy.Add("csb_prolsec");
                sPeddy.Add("cs_prolsec_02");
                sPeddy.Add("ig_prolsec_02");
                sPeddy.Add("u_f_o_prolhost_01");
                sPeddy.Add("u_f_m_promourn_01");
            }       //Yankton
            else if (iPedtype == 24)
            {
                if (iSubType == 1)
                {
                    sPeddy.Add("A_C_Panther");
                }       //A_C_Panther
                else if (iSubType == 2)
                {
                    sPeddy.Add("A_F_Y_Beach_02");
                    sPeddy.Add("A_M_O_Beach_02");
                    sPeddy.Add("A_M_Y_Beach_04");
                    sPeddy.Add("A_F_Y_ClubCust_04");
                    sPeddy.Add("A_M_Y_ClubCust_04");
                }       //A_F_Y_Beach_02
                else if (iSubType == 3)
                {
                    sPeddy.Add("G_M_M_CartelGuards_01");
                    sPeddy.Add("G_M_M_CartelGuards_02");
                    sPeddy.Add("S_M_M_HighSec_04");
                }       //Guard
                else if (iSubType == 4)
                {
                    sPeddy.Add("S_F_Y_BeachBarStaff_01");
                }       //Bar
                else if (iSubType == 5)
                {
                    sPeddy.Add("S_M_M_DrugProcess_01");
                    sPeddy.Add("S_M_M_FieldWorker_01");
                }       //worker
                else if (iSubType == 6)
                {
                    sPeddy.Add("IG_Pilot");
                }       //pilot
                else
                {
                    sPeddy.Add("CSB_JIO");
                    sPeddy.Add("CSB_JuanStrickler");
                    sPeddy.Add("CSB_MJO");
                    sPeddy.Add("CSB_SSS");
                    sPeddy.Add("IG_ARY");
                    sPeddy.Add("IG_JIO");
                    sPeddy.Add("IG_MJO");
                    sPeddy.Add("IG_OldRichGuy");
                    sPeddy.Add("IG_SSS");
                }

                //sPeddy.Add("S_F_Y_ClubBar_02");
                //sPeddy.Add("S_M_M_Bouncer_02");

            }     //Cayo Perico

            if (sPeddy.Count() == 1)
                sPed = sPeddy[0];
            else
                sPed = sPeddy[RandInt(0, sPeddy.Count() - 1)];

            return sPed;
        }
        private void YourRanPed(string PedName)
        {

            LogginSyatem("YourRanPed, PedName == " + PedName);

            var model = new Model(PedName);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                iAmModelHash = model.Hash;
                while (!model.IsLoaded)
                    Wait(1);
                Game.Player.ChangeModel(model);

                if (Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Trevor || Game.Player.Character.Model == PedHash.Franklin)
                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
                else
                    Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Game.Player.Character, false);

                int iHats = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, 0);
                Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, 0, RandInt(-1, iHats), 0, false);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);
            }
        }
        private void YourSavedPed()
        {

            LogginSyatem("YourSavedPed");

            if (MyPedCollection.Count > 1)
                SavePedLoader(MyPedCollection[RandInt(1, MyPedCollection.Count - 1)]);
            else
                bSavedPed = false;
        }
        private void SavePedLoader(NewClothBank MyWoven)
        {

            LogginSyatem("SavePedLoader, ");

            List<int> iWardrobe01 = new List<int>();
            List<int> iWardrobe02 = new List<int>();

            List<int> iWardrobe01Extra = new List<int>();
            List<int> iWardrobe02Extra = new List<int>();

            List<int> FaceInt = new List<int>();
            List<float> FaceFloat = new List<float>();

            AddTatBase.Clear();
            AddTatName.Clear();

            var model = new Model(MyWoven.ModelX);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                iAmModelHash = model.Hash;

                while (!model.IsLoaded)
                    Wait(1);
                Game.Player.ChangeModel(model);

                iWardrobe01 = MyWoven.ClothA;
                iWardrobe02 = MyWoven.ClothB;

                iWardrobe01Extra = MyWoven.ExtraA;
                iWardrobe02Extra = MyWoven.ExtraB;

                AddTatBase = MyWoven.Tattoo_COl;
                AddTatName = MyWoven.Tattoo_Nam;

                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);

                bool bFree = MyWoven.FreeMode;

                if (bFree)
                {
                    FaceInt.Add(MyWoven.XshapeFirstID);
                    FaceInt.Add(MyWoven.XshapeSecondID);
                    FaceInt.Add(MyWoven.XshapeThirdID);
                    FaceInt.Add(MyWoven.XskinFirstID);
                    FaceInt.Add(MyWoven.XskinSecondID);
                    FaceInt.Add(MyWoven.XskinThirdID);
                    FaceFloat.Add(MyWoven.XshapeMix);
                    FaceFloat.Add(MyWoven.XskinMix);
                    FaceFloat.Add(MyWoven.XthirdMix);

                    iHair01 = MyWoven.HairColour;
                    iHair02 = MyWoven.HairStreaks;
                    iEye = MyWoven.EyeColour;

                    iOverlay = MyWoven.Overlay;
                    iOverlayColour = MyWoven.OverlayColour;
                    fOverlayOpc = MyWoven.OverlayOpc;

                    fAceFeats = MyWoven.FaceScale;

                    CustomFree(iWardrobe01, iWardrobe02, iWardrobe01Extra, iWardrobe02Extra, FaceInt, FaceFloat);
                }
                else
                    CustomRand(iWardrobe01, iWardrobe02, iWardrobe01Extra, iWardrobe02Extra);

                sPedVoices = MyWoven.PedVoice;

                if (sPedVoices != "")
                    Function.Call(Hash.SET_AMBIENT_VOICE_NAME, Game.Player.Character, sPedVoices);

                sFirstName = MyWoven.Name;
            }
        }
        private void CustomFree(List<int> iWardrobe01, List<int> iWardrobe02, List<int> iWardrobe01Extra, List<int> iWardrobe02Extra, List<int> FaceInt, List<float> FaceFloat)
        {

            LogginSyatem("CustomFree");

            Ped Peddy = Game.Player.Character;

            for (int i = 0; i < iWardrobe01.Count; i++)
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, i, iWardrobe01[i], iWardrobe02[i], 2);

            Function.Call(Hash.CLEAR_ALL_PED_PROPS, Peddy);

            for (int i = 0; i < iWardrobe01Extra.Count; i++)
                Function.Call(Hash.SET_PED_PROP_INDEX, Peddy, i, iWardrobe01Extra[i], iWardrobe02Extra[i], false);

            for (int i = 0; i < AddTatBase.Count; i++)
                Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, AddTatBase[i]), Function.Call<int>(Hash.GET_HASH_KEY, AddTatName[i]));

            Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Peddy, FaceInt[0], FaceInt[1], FaceInt[2], FaceInt[3], FaceInt[4], FaceInt[5], FaceFloat[0], FaceFloat[1], FaceFloat[2], false);

            Function.Call(Hash._SET_PED_HAIR_COLOR, Peddy, iHair01, iHair02);
            Function.Call(Hash._SET_PED_EYE_COLOR, Peddy, iEye);

            for (int i = 0; i < iOverlay.Count; i++)
            {
                Function.Call(Hash.SET_PED_HEAD_OVERLAY, Peddy, i, iOverlay[i], fOverlayOpc[i]);

                if (i == 1 || i == 2 || i == 10)
                    Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Peddy, i, 1, iOverlayColour[i], 0);
                else if (i == 5 || i == 8)
                    Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Peddy, i, 2, iOverlayColour[i], 0);
            }

            for (int i = 0; i < fAceFeats.Count; i++)
                Function.Call(Hash._SET_PED_FACE_FEATURE, Game.Player.Character, i, fAceFeats[i]);

        }
        private void CustomRand(List<int> iWardrobe01, List<int> iWardrobe02, List<int> iWardrobe01Extra, List<int> iWardrobe02Extra)
        {

            LogginSyatem("CustomRand");

            Ped Peddy = Game.Player.Character;

            for (int i = 0; i < iWardrobe01.Count; i++)
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy, i, iWardrobe01[i], iWardrobe02[i], 2);

            Function.Call(Hash.CLEAR_ALL_PED_PROPS, Peddy);

            for (int i = 0; i < iWardrobe01Extra.Count; i++)
                Function.Call(Hash.SET_PED_PROP_INDEX, Peddy, i, iWardrobe01Extra[i], iWardrobe02Extra[i], false);

            for (int i = 0; i < AddTatBase.Count; i++)
                Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, AddTatBase[i]), Function.Call<int>(Hash.GET_HASH_KEY, AddTatName[i]));
        }
        private void AddVeh(string sVehic, Vector3 Vpos, float fHead, int iEnterV, int iPedtype, int iSubType)
        {

            LogginSyatem("AddVeh, sVehic == " + sVehic + ", iEnterV == " + iEnterV + ", iPedtype == " + iPedtype + ", iSubType == " + iSubType);

            int iVehHash = Function.Call<int>(Hash.GET_HASH_KEY, sVehic);

            if (Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iVehHash) && Function.Call<bool>(Hash.IS_MODEL_A_VEHICLE, iVehHash))
            {
                Function.Call(Hash.REQUEST_MODEL, iVehHash);
                while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, iVehHash))
                    Wait(1);
                Vehicle Vehic = Function.Call<Vehicle>(Hash.CREATE_VEHICLE, iVehHash, Vpos.X, Vpos.Y, Vpos.Z, fHead, true, true);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iVehHash);
                Vehic.IsPersistent = true;
                VehList.Add(new Vehicle(Vehic.Handle));

                MaxMods(Vehic);

                if (iEnterV > 0)
                    EnterVeh(Vehic, iEnterV, iPedtype, iSubType);

            }
            else
            {
                Script.Wait(500);
                AddVeh(BuildRandVeh(iPedtype, iSubType), Vpos, fHead, iEnterV, iPedtype, iSubType);
            }
        }
        private void MaxMods(Vehicle Vehic)
        {

            LogginSyatem("MaxMods");

            Function.Call(Hash.SET_VEHICLE_MOD_KIT, Vehic, 0);
            bool bMotoBike = Vehic.ClassType == VehicleClass.Motorcycles;
            for (int i = 0; i < 50; i++)
            {
                int iSpoilher = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, Vehic.Handle, i);

                if (i == 11 || i == 12 || i == 13 || i == 15 || i == 16)
                    Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, iSpoilher - 1, true);
                else if (i == 18 || i == 22)
                {

                }
                else if (i == 24)
                {
                    if (bMotoBike)
                        Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, Function.Call<int>(Hash.GET_VEHICLE_MOD, Vehic.Handle, 23), true);
                }
                else
                {
                    if (iSpoilher != 0)
                        Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, RandInt(0, iSpoilher - 1), true);
                }
            }
            if (Vehic.ClassType != VehicleClass.Cycles || Vehic.ClassType != VehicleClass.Helicopters || Vehic.ClassType != VehicleClass.Boats || Vehic.ClassType != VehicleClass.Planes)
            {
                Vehic.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
                Vehic.ToggleMod(VehicleToggleMod.Turbo, true);
            }
        }
        private void EnterVeh(Vehicle Vehic, int iEnterV, int iPedtype, int iSubType)
        {

            LogginSyatem("EnterVeh, iEnterV == " + iEnterV + ", iPedtype == " + iPedtype + ", iSubType == " + iSubType);

            Vector3 V3 = Vehic.Position + (Vehic.RightVector * 3.50f);

            if (iEnterV == 1)
            {
                if (Vehic.ClassType == VehicleClass.Planes)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    Function.Call(Hash.TASK_PLANE_MISSION﻿, Game.Player.Character, Vehic, 0, 0, vPlayerTarget.X, vPlayerTarget.Y, vPlayerTarget.Z, 4, 100.0f, 0.0f, 90.0f, 0, 600.0f);
                }
                else if (Vehic.ClassType == VehicleClass.Helicopters)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    float HeliSpeed = 75.00f;

                    float dx = vPlayerTarget.X - Vehic.Position.X;
                    float dy = vPlayerTarget.Y - Vehic.Position.Y;
                    float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;
                    Function.Call(Hash.TASK_HELI_MISSION, Game.Player.Character.Handle, Vehic.Handle, 0, 0, vPlayerTarget.X, vPlayerTarget.Y, vPlayerTarget.Z, 4, HeliSpeed, 0, HeliDirect, -1, -1, -1, 0);
                }
                else
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);

                    if (vPlayerTarget != Vector3.Zero)
                        Game.Player.Character.Task.DriveTo(Vehic, vPlayerTarget, 3.00f, 35.00f);
                    else
                        Game.Player.Character.Task.CruiseWithVehicle(Vehic, 35.00f);
                }
            }       //Player Only
            else if (iEnterV == 2)
            {
                if (Vehic.ClassType == VehicleClass.Planes)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    Function.Call(Hash.TASK_PLANE_MISSION﻿, Game.Player.Character, Vehic, 0, 0, vPlayerTarget.X, vPlayerTarget.Y, vPlayerTarget.Z, 4, 100.0f, 0.0f, 90.0f, 0, 600.0f);
                }
                else if (Vehic.ClassType == VehicleClass.Helicopters)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    float HeliSpeed = 75.00f;

                    float dx = vPlayerTarget.X - Vehic.Position.X;
                    float dy = vPlayerTarget.Y - Vehic.Position.Y;
                    float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;
                    Function.Call(Hash.TASK_HELI_MISSION, Game.Player.Character.Handle, Vehic.Handle, 0, 0, vPlayerTarget.X, vPlayerTarget.Y, vPlayerTarget.Z, 4, HeliSpeed, 0, HeliDirect, -1, -1, -1, 0);
                }
                else
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    if (vPlayerTarget != Vector3.Zero)
                        Game.Player.Character.Task.DriveTo(Vehic, vPlayerTarget, 3.00f, 35.00f);
                    else
                        Game.Player.Character.Task.CruiseWithVehicle(Vehic, 35.00f);
                }

                if (Vehic.PassengerSeats > 0)
                    NPCSpawn(BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 4, 0, Vehic, true);
            }      //Player One Passenger
            else if (iEnterV == 3)
            {
                if (Vehic.ClassType == VehicleClass.Planes)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    Function.Call(Hash.TASK_PLANE_MISSION﻿, Game.Player.Character, Vehic, 0, 0, vPlayerTarget.X, vPlayerTarget.Y, vPlayerTarget.Z, 4, 100.0f, 0.0f, 90.0f, 0, 600.0f);
                }
                else if (Vehic.ClassType == VehicleClass.Helicopters)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    float HeliSpeed = 75.00f;

                    float dx = vPlayerTarget.X - Vehic.Position.X;
                    float dy = vPlayerTarget.Y - Vehic.Position.Y;
                    float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;
                    Function.Call(Hash.TASK_HELI_MISSION, Game.Player.Character.Handle, Vehic.Handle, 0, 0, vPlayerTarget.X, vPlayerTarget.Y, vPlayerTarget.Z, 4, HeliSpeed, 0, HeliDirect, -1, -1, -1, 0);
                }
                else
                {
                    Game.Player.Character.Position = V3;
                    while (!Game.Player.Character.IsInVehicle())
                    {
                        YouTheDriver(Vehic, Game.Player.Character);
                        Script.Wait(10);
                    }
                    if (vPlayerTarget != Vector3.Zero)
                        Game.Player.Character.Task.DriveTo(Vehic, vPlayerTarget, 3.00f, 35.00f);
                    else
                        Game.Player.Character.Task.CruiseWithVehicle(Vehic, 35.00f);
                }
                FillthisVeh(Vehic, iPedtype, iSubType, V3, 4, 0, true);
            }      //Player + full vehicle
            else if (iEnterV == 4)
            {
                NPCSpawn(BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 3, 0, Vehic, true);
            }      //Rand Ped
            else if (iEnterV == 5)
            {
                NPCSpawn(BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 3, 0, Vehic, true);
                FillthisVeh(Vehic, iPedtype, iSubType, V3, 4, 0, true);
            }      //Rand Ped + Fill Veh
            else if (iEnterV == 6)
            {
                NPCSpawn(BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 5, 5, Vehic, false);
            }      //Rand Ped --Attacker
            else if (iEnterV == 7)
            {
                NPCSpawn(BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 5, 0, Vehic, false);
                FillthisVeh(Vehic, iPedtype, iSubType, V3, 6, 5, false);
            }      //Rand Ped --Attacker + Fill Veh
            else if (iEnterV == 8)
            {
                Vehic.AddBlip();
                Vehic.CurrentBlip.Sprite = BlipSprite.HelicopterAnimated;
                PrisEscape = Vehic;
                bPrisHeli = true;
            }      //Prison Heli
            else if (iEnterV == 9)
            {
                Game.Player.Character.Position = V3;
                YouTheDriver(Vehic, Game.Player.Character);
                bAllowControl = false;
                Script.Wait(4000);
                CleanUpMess();
            }      //Golf Cart
            else if (iEnterV == 10)
            {
                Shoaf = Vehic;
                Vehic.EngineRunning = true;
                if (Vehic.ClassType == VehicleClass.Helicopters)
                    NPCSpawn(BuildRandomPed(22, 4), V3, 0.00f, 8, 0, Vehic, true);
                else
                    NPCSpawn(BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 9, 0, Vehic, true);
                while (!Game.Player.Character.IsInVehicle(Vehic))
                {
                    Game.Player.Character.Task.WarpIntoVehicle(Vehic, VehicleSeat.RightRear);
                    Script.Wait(10);
                }
            }      //Player is Passenger
            else if (iEnterV == 11)
            {
                Game.Player.Character.Position = V3;
                YouTheDriver(Vehic, Game.Player.Character);
            }      //Player Driver no driving
            else if (iEnterV == 12)
            {
                Game.Player.Character.Position = V3;
                YouTheDriver(Vehic, Game.Player.Character);

                if (Vehic.PassengerSeats > 0)
                    NPCSpawn(BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 4, 0, Vehic, true);

                FindCrimo(V3, 125.00f, 10.00f);

                Script.Wait(500);
            }      //Cop Chase
            else if (iEnterV == 13)
            {
                NPCSpawn(BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 11, 0, Vehic, true);
            }      //Ped Wait in Vehicle
        }
        private void FillthisVeh(Vehicle Vehic, int iPedtype, int iSubType, Vector3 vPos, int iTask, int iWeapons, bool bFriend)
        {

            LogginSyatem("FillthisVeh, iPedtype == " + iPedtype + ", iSubType == " + iSubType + ", iTask == " + iTask);

            for (int i = 0; i < Vehic.PassengerSeats; i++)
                NPCSpawn(BuildRandomPed(iPedtype, iSubType), vPos, 0.00f, iTask, iWeapons, Vehic, bFriend);
        }
        private void MyPropBuild(string sPop, Vector3 Local, Vector3 Rotate, int iPropTask)
        {

            LogginSyatem("MyPropBuild, sPop == " + sPop + ", iPropTask == " + iPropTask);

            Prop Propper = null;
            Propper = World.CreateProp(Function.Call<int>(Hash.GET_HASH_KEY, sPop), Local, Rotate, true, false);

            if (Propper != null)
            {
                Propper.IsPersistent = true;
                PropList.Add(new Prop(Propper.Handle));
                if (iPropTask > 0)
                    PropTasks(Propper, iPropTask);
            }
            else
            {
                Script.Wait(100);
                MyPropBuild(sPop, Local, Rotate, iPropTask);
            }

        }
        private void PropTasks(Prop Popp, int iPopTask)
        {

            LogginSyatem("PropTasks, iPopTask == " + iPopTask);

            if (iPopTask == 1)
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Popp.Handle, Game.Player.Character.Handle, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, false, false, true, false, 2, true);
            else if (iPopTask == 2)
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Popp.Handle, Game.Player.Character.Handle, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, false, false, true, false, 2, true);
        }
        private void CayoNPCSpawn(string sPed, Prop pMyChair, Vector3 Vpos, float fAce, int iTask)
        {

            LogginSyatem("CayoNPCSpawn, sPed == " + sPed + ", iTask == " + iTask);

            Vector3 vLocal = Vpos;
            float fDir = fAce;
            if (pMyChair != null)
            {
                vLocal = pMyChair.Position;
                fDir = pMyChair.Heading - 180.00f;
            }
            var model = new Model(sPed);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                while (!model.IsLoaded)
                    Wait(1);
                Ped Peddy = Function.Call<Ped>(Hash.CREATE_PED, 4, model, vLocal.X, vLocal.Y, vLocal.Z, fDir, false, false);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);

                if (pMyChair != null)
                {
                    List<string> SitVArs = new List<string>();

                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR");
                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_DRINK");
                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_DRINK_BEER");
                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_FOOD");
                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_UPRIGHT");
                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_MP_PLAYER");

                    PedScenario(Peddy, SitVArs[RandInt(0, SitVArs.Count() - 1)], pMyChair.Position, pMyChair.Heading - 180.00f, true);
                }
                else
                {
                    if (iTask > 0)
                        PedTasks(Peddy, iTask, null);
                }

                PedParty.Add(new Ped(Peddy.Handle));
            }
        }
        private void NPCSpawn(string sPed, Vector3 vLocal, float fAce, int iTask, int iWeapons, Vehicle Vehicary, bool bFriend)
        {

            LogginSyatem("NPCSpawn, sPed == " + sPed + ", iTask == " + iTask);

            var model = new Model(sPed);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                while (!model.IsLoaded)
                    Wait(1);
                Ped Peddy = Function.Call<Ped>(Hash.CREATE_PED, 4, model, vLocal.X, vLocal.Y, vLocal.Z, fAce, false, false);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);

                if (iWeapons > 0)
                    PedWeapons(Peddy, iWeapons);
                if (iTask > 0)
                    PedTasks(Peddy, iTask, Vehicary);

                if (bFriend)
                    Peddy.RelationshipGroup = PlayerGroups;
                else
                    Peddy.RelationshipGroup = AttackingNPCs;
                PeddyList.Add(new Ped(Peddy.Handle));
            }
        }
        private void PedTasks(Ped Peddy, int iTask, Vehicle Vehicary)
        {

            LogginSyatem("NPCSpawn, iTask == " + iTask);

            if (iTask == 1)
            {
                Peddy.Accuracy = 75;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.CanBeTargette﻿d﻿ = false;
                Peddy.RelationshipGroup = FriendlyNPCs;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy, 0, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy, 1);
            }            //FriendPed
            else if (iTask == 2)
            {
                Peddy.Accuracy = 55;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.IsEnemy = true;
                Peddy.CanBeTargette﻿d﻿ = true;
                Peddy.RelationshipGroup = AttackingNPCs;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy, true);
                Peddy.Task.FightAgainst(Game.Player.Character);
                Peddy.AlwaysKeepTask = true;
            }       //EnemyPed
            else if (iTask == 3)
            {
                Peddy.Accuracy = 75;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.CanBeTargette﻿d﻿ = false;
                Peddy.RelationshipGroup = FriendlyNPCs;

                if (Vehicary != null)
                {
                    YouTheDriver(Vehicary, Peddy);
                    Peddy.Task.Wait(-1);
                }
            }       //FriendDriver
            else if (iTask == 4)
            {
                if (Vehicary != null)
                    PedFindMeASeat(Vehicary, Peddy);
            }       //FriendPassenger
            else if (iTask == 5)
            {
                Peddy.Accuracy = 55;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.IsEnemy = true;
                Peddy.CanBeTargette﻿d﻿ = true;
                Peddy.RelationshipGroup = AttackingNPCs;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy, true);
                Peddy.Task.FightAgainst(Game.Player.Character);

                if (Vehicary != null)
                {
                    YouTheDriver(Vehicary, Peddy);

                    if (vPedTarget != Vector3.Zero)
                        Peddy.Task.DriveTo(Vehicary, vPedTarget, 3.00f, 35.00f);
                    else
                        Peddy.Task.CruiseWithVehicle(Vehicary, 35.00f);

                    Peddy.AlwaysKeepTask = true;
                }
            }       //EnemyDriver
            else if (iTask == 6)
            {
                Peddy.Accuracy = 55;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.IsEnemy = true;
                Peddy.CanBeTargette﻿d﻿ = true;
                Peddy.RelationshipGroup = AttackingNPCs;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy, 0, true);
                //Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy, true);
                Peddy.Task.FightAgainst(Game.Player.Character);

                if (Vehicary != null)
                    PedFindMeASeat(Vehicary, Peddy);
            }       //EnemyPassenger
            else if (iTask == 7)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy, true);

                ForceAnim(Peddy, "amb@world_human_bum_standing@depressed@base", "base", Peddy.Position, Peddy.Rotation);
            }       //SolomPriest
            else if (iTask == 8)
            {
                pPilot = Peddy;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy, 0, true);
                if (Vehicary != null)
                {
                    YouTheDriver(Vehicary, Peddy);
                    iPath = 0;
                    iPostAction = 6;
                    Vehicary.Position = RanLoc_01[iPath];
                    iPath += 1;
                    FlyHeliHere(RanLoc_01[iPath], fHeads[iPath], Vehicary, pPilot, false);
                }
            }       //HeliPilot
            else if (iTask == 9)
            {
                Peddy.Accuracy = 75;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.CanBeTargette﻿d﻿ = false;
                Peddy.RelationshipGroup = FriendlyNPCs;

                if (Vehicary != null)
                {
                    YouTheDriver(Vehicary, Peddy);
                    Peddy.Task.CruiseWithVehicle(Vehicary, 12.00f);
                }
            }       //FriendDriver--Driving
            else if (iTask == 10)
            {
                Peddy.Accuracy = 55;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.IsEnemy = true;
                Peddy.CanBeTargette﻿d﻿ = true;
                Peddy.RelationshipGroup = AttackingNPCs;
                if (Vehicary != null)
                {
                    YouTheDriver(Vehicary, Peddy);
                    Peddy.Task.FleeFrom(Game.Player.Character);
                }
            }       //EnemyDriverfleeing
            else if (iTask == 11)
            {
                Peddy.Accuracy = 75;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.CanBeTargette﻿d﻿ = false;
                Peddy.RelationshipGroup = FriendlyNPCs;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy, 0, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy, 1);
                if (Vehicary != null)
                    YouTheDriver(Vehicary, Peddy);
            }       //PedWait
            else if (iTask == 12)
            {
                List<string> DanceSteps = new List<string>();
                if (Peddy.Gender == Gender.Male)
                    DanceSteps = DanceList(true, RandInt(1, 3));
                else
                    DanceSteps = DanceList(false, RandInt(1, 3));

                if (DanceSteps.Count() > 0)
                    ForceAnim(Peddy, DanceSteps[0], DanceSteps[1], Peddy.Position, Peddy.Rotation);
            }       //PedDance-fast?
            else if (iTask == 13)
            {

            }       //Blank
            else if (iTask == 14)
            {
                List<string> DanceSteps = new List<string>();
                if (Peddy.Gender == Gender.Male)
                    DanceSteps = DanceList(true, RandInt(1, 3));
                else
                    DanceSteps = DanceList(false, RandInt(1, 3));

                if (DanceSteps.Count() > 0)
                    ForceAnim(Peddy, DanceSteps[0], DanceSteps[1], Peddy.Position, Peddy.Rotation);
            }       //SLow Dance
            else if (iTask == 15)
            {
                if (Peddy.Gender == Gender.Male)
                    ForceAnim(Peddy, "amb@world_human_sunbathe@male@back@base", "base", Peddy.Position, Peddy.Rotation);
                else
                    ForceAnim(Peddy, "amb@world_human_sunbathe@female@back@base", "base", Peddy.Position, Peddy.Rotation);
            }       //sun back
            else if (iTask == 16)
            {
                if (Peddy.Gender == Gender.Male)
                    ForceAnim(Peddy, "amb@world_human_sunbathe@male@front@base", "base", Peddy.Position, Peddy.Rotation);
                else
                    ForceAnim(Peddy, "amb@world_human_sunbathe@female@front@base", "base", Peddy.Position, Peddy.Rotation);
            }       //sun front
        }
        private void PedWeapons(Ped Peddy, int iWeapons)
        {
            LogginSyatem("PedWeapons, iWeapons == " + iWeapons);

            if (iWeapons == 1)
            {
                string sYourWeap = sWeapList[RandInt(0, 17)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), MaxAmmo(sYourWeap, Peddy), false, true);
            }       //Just Melee
            else if (iWeapons == 2)
            {
                string sYourWeap = sWeapList[RandInt(18, 33)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), MaxAmmo(sYourWeap, Peddy), false, true);
            }       //Just Hand
            else if (iWeapons == 3)
            {
                string sYourWeap = sWeapList[RandInt(55, 64)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), MaxAmmo(sYourWeap, Peddy), false, true);
            }       //Just Assult
            else if (iWeapons == 4)
            {
                string sYourWeap = sWeapList[RandInt(45, 54)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), MaxAmmo(sYourWeap, Peddy), false, true);
            }       //Just ShotGun
            else if (iWeapons == 5)
            {
                string sYourWeap = sWeapList[RandInt(0, 17)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), MaxAmmo(sYourWeap, Peddy), false, true);

                sYourWeap = sWeapList[RandInt(18, 33)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), MaxAmmo(sYourWeap, Peddy), false, true);

                sYourWeap = sWeapList[RandInt(45, 54)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), MaxAmmo(sYourWeap, Peddy), false, true);

                sYourWeap = sWeapList[RandInt(55, 64)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), MaxAmmo(sYourWeap, Peddy), false, true);
            }       //RandomCombos
            else
            {
                string sYourWeap = sWeapList[6];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), MaxAmmo(sYourWeap, Peddy), false, true);
            }       //GolfClub
        }
        private void PedFindMeASeat(Vehicle Vhick, Ped Peddy)
        {

            LogginSyatem("PedFindMeASeat");

            while (!Peddy.IsInVehicle())
            {
                Function.Call(Hash.TASK_WARP_PED_INTO_VEHICLE, Peddy, Vhick, -2);
                Script.Wait(10);
            }
        }
        private void YouTheDriver(Vehicle Vhick, Ped Peddy)
        {

            LogginSyatem("YouTheDriver");

            while (!Peddy.IsInVehicle())
            {
                Function.Call(Hash.TASK_ENTER_VEHICLE, Peddy, Vhick, -1, -1, 2.00f, 16, 0);
                Script.Wait(10);
            }
        }
        private void FindReplacePed(int iAnyPedList, Vector3 vZone, float fRadius, int iCountEm, int iTask, int iWeapons, bool bFriend)
        {

            LogginSyatem("FindReplacePed, iCountEm == " + iCountEm + ", iTask == " + iTask);

            Ped[] MadPeds = World.GetNearbyPeds(vZone, fRadius);
            for (int i = 0; i < MadPeds.Count(); i++)
            {
                if (iCountEm > 0)
                {
                    Ped MadP = MadPeds[i];
                    if (!MadP.IsOnScreen && !MadP.IsInVehicle() && Function.Call<int>(Hash.GET_PED_TYPE, MadP) != 28 && MadP != Game.Player.Character && !MadP.IsPersistent)
                    {
                        iCountEm -= 1;
                        NPCSpawn(AddAnyPed(iAnyPedList), MadP.Position, MadP.Heading, iTask, iWeapons, null, bFriend);
                        MadP.Delete();
                    }
                }
                else
                    break;
            }
            if (iCountEm > 0)
            {
                Script.Wait(500);
                FindReplacePed(iAnyPedList, vZone, 100.00f, iCountEm, iTask, iWeapons, bFriend);
            }
        }
        private void RandomWeatherTime()
        {

            LogginSyatem("RandomWeatherTime");

            int iTimes = RandInt(0, 23);
            double dTime = (int)iTimes;
            int iRain = FindRandom(2, 0, 9);
            World.Weather = WetherBe[iRain];
            World.CurrentDayTime = TimeSpan.FromHours(dTime);
        }
        private void OverLayList()
        {

            LogginSyatem("OverLayList");

            for (int i = 0; i < 13; i++)
            {
                int iValue = Function.Call<int>(Hash._GET_PED_HEAD_OVERLAY_VALUE, Game.Player.Character, i);
                iOverlay.Add(iValue);
                if (iValue == 255)
                {
                    iOverlayColour.Add(0);
                    fOverlayOpc.Add(0.00f);
                }
                else
                {
                    iOverlayColour.Add(RandInt(0, 61));
                    fOverlayOpc.Add(RandFloat(0.65f, 0.99f));
                }
            }
        }
        private void DeathArrestCont(bool bProg)
        {
            LogginSyatem("DeathArrestCont bProg == " + bProg);

            if (Game.Player.Character.Model != PedHash.Michael && Game.Player.Character.Model != PedHash.Trevor && Game.Player.Character.Model != PedHash.Franklin)
            {
                vHeaven = World.GetNextPositionOnSidewalk(Game.Player.Character.Position);

                Game.Player.Character.Position = vHeaven;
                Game.Player.Character.IsVisible = true;
                Game.Player.Character.HasCollision = true;

                if (bDontStopMe)
                {
                    Game.Player.IgnoredByPolice = false;
                    Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, Game.Player.Character, true);
                    Function.Call(Has﻿h.REQUEST_SCRIPT, "restrictedareas");
                    Function.Call(Has﻿h.REQUEST_SCRIPT, "re_armybase");
                    Script.Wait(100);

                    if (bPrisHeli)
                    {
                        bPrisHeli = false;
                        PrisEscape.CurrentBlip.Remove();
                        PrisEscape.MarkAsNoLongerNeeded();
                    }
                    bDontStopMe = false;
                }

                if (bMenyooZZ)
                {
                    if (bProg)
                    {
                        while (!Function.Call<bool>(Hash.IS_PLAYER_PLAYING))
                            Script.Wait(100);

                        Vector3 VMep = Game.Player.Character.Position;
                        while (!Function.Call<bool>(Hash.IS_PED_MODEL, Game.Player.Character, iAmModelHash) && Game.Player.Character.Position.DistanceTo(VMep) < 45.00f)
                            Script.Wait(100);

                        YourRanPed(sMainChar);

                        YouDied();
                    }
                    else
                    {
                        while (!Function.Call<bool>(Hash.IS_PLAYER_PLAYING))
                            Script.Wait(100);

                        Vector3 VMep = Game.Player.Character.Position;
                        while (!Function.Call<bool>(Hash.IS_PED_MODEL, Game.Player.Character, iAmModelHash) && Game.Player.Character.Position.DistanceTo(VMep) < 45.00f)
                            Script.Wait(100);

                        YouArrest();
                    }
                }
                else if (bEnhanceT)
                {
                    if (!bProg)
                        YouArrest();
                }
                else
                {
                    if (bProg)
                    {
                        YourRanPed(sMainChar);
                        YouDied();
                    }
                    else
                        YouArrest();
                }
            }
            else
            {
                if (bInYankton)
                    Yankton(false);
                else if (bInCayoPerico)
                    CayoPerico(false);
            }
        }
        private void ClearDASCript(bool bProg)
        {

            LogginSyatem("ClearDASCript bProg == " + bProg);

            if (bProg)
            {
                Function.Call(Hash.NETWORK_REQUEST_CONTROL_OF_ENTITY, Game.Player.Character);
                Function.Call(Hash.NETWORK_RESURRECT_LOCAL_PLAYER, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z, 0.0, 0.0, 0.0);
                Function.Call(Hash._RESET_LOCALPLAYER_STATE);
                Function.Call(Hash.SET_FADE_OUT_AFTER_DEATH, false);
            }
            else
            {
                while (Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED))
                    Script.Wait(100);
                Function.Call(Hash.NETWORK_REQUEST_CONTROL_OF_ENTITY, Game.Player.Character);
                Function.Call(Hash.RESET_PLAYER_ARREST_STATE, Game.Player.Character);
                Function.Call(Hash._RESET_LOCALPLAYER_STATE);
                Function.Call(Hash.SET_FADE_OUT_AFTER_ARREST, false);
            }

            Function.Call(Hash.DISPLAY_HUD, true);
            Game.Player.Character.FreezePosition = false;

            bDead = true;
            DeathArrestCont(bProg);
        }
        private void PlayerBelter()
        {
            Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character, 32, !bBeltUp);
        }
        private void YouDied()
        {

            LogginSyatem("YouDied");

            if (bMethActor)
                MethEdd(true);

            if (bInYankton)
                Yankton(false);
            else if (bInCayoPerico)
                CayoPerico(false);

            Game.FadeScreenIn(1000);
            MyPropBuild("prop_coffin_01", new Vector3(-278.3422f, 2844.4617f, 52.8818f), new Vector3(-4.20f, 1.015f, -30.6686f), 0);

            Vector3 vPriest = new Vector3(-276.5638f, 2844.45f, 53.75225f);
            float fPriest = 134.9461f;
            NPCSpawn("ig_priest", vPriest, fPriest, 7, 0, null, true);

            Vector3 vMorn02 = new Vector3(-281.5462f, 2844.153f, 54.07914f);
            float fMorn02 = 279.358f;
            NPCSpawn(sFunChar01, vMorn02, fMorn02, 7, 0, null, true);

            Vector3 vMorn01 = new Vector3(-276.7029f, 2841.419f, 53.96595f);
            float fMorn01 = 29.87679f;
            NPCSpawn(sFunChar02, vMorn01, fMorn01, 7, 0, null, true);

            Vector3 vPlayer = new Vector3(-281.0132f, 2840.851f, 54.34494f);
            float fPlayer = 320.0452f;

            Game.Player.Character.Position = vPlayer;
            Game.Player.Character.Heading = fPlayer;

            if (sFirstName == "PlayerX")
            {
                if (Game.Player.Character.Gender == Gender.Male)
                    sFirstName = sNameMal[RandInt(0, sNameMal.Count() - 1)];
                else
                    sFirstName = sNameFem[RandInt(0, sNameFem.Count() - 1)];
            }

            int iNameSir = sNameSir.Count();
            if (iNameSir > 0)
            {
                if (iNameSir == 1)
                {
                    if (bMale)
                        UI.Notify(sLangfile[2] + sFirstName + " " + sNameSir[0] + sLangfile[3]);
                    else
                        UI.Notify(sLangfile[2] + sFirstName + " " + sNameSir[0] + sLangfile[4]);
                }
                else
                {
                    iNameSir = RandInt(0, iNameSir - 1);
                    if (bMale)
                        UI.Notify(sLangfile[2] + sFirstName + " " + sNameSir[iNameSir] + sLangfile[3]);
                    else
                        UI.Notify(sLangfile[2] + sFirstName + " " + sNameSir[iNameSir] + sLangfile[4]);
                }
            }
            else
            {
                if (bMale)
                    UI.Notify(sLangfile[2] + sFirstName + " Davis. " + sLangfile[3]);
                else
                    UI.Notify(sLangfile[2] + sFirstName + " Davis. " + sLangfile[4]);
            }

            ReturnWeaps();

            Script.Wait(7000);
            CleanUpMess();
            bDead = false;
        }
        private void YouArrest()
        {

            LogginSyatem("YouArrest");

            Game.FadeScreenIn(2000);

            if (bInYankton)
                Yankton(false);
            else if (bInCayoPerico)
                CayoPerico(false);

            Vector3 HeliPos = new Vector3(1635.97f, 2628.04f, 44.55f);
            vAreaRest = HeliPos;
            float HeliRot = -150.75f;
            AddVeh("POLMAV", HeliPos, HeliRot, 8, 0, 0);

            UI.Notify(sLangfile[5]);
            Vector3 vPlayer = new Vector3(1658.052f, 2543.221f, 45.56487f);
            Game.Player.Character.Position = vPlayer;
            AccessAllAreas();
            Script.Wait(500);
            Vector3 Pris_01 = new Vector3(1656.865f, 2545.687f, 45.56487f);
            NPCSpawn("s_m_y_prisoner_01", Pris_01, 0.00f, 2, 1, null, false);
            Vector3 Pris_02 = new Vector3(1655.01f, 2543.518f, 45.56487f);
            NPCSpawn("s_m_y_prismuscl_01", Pris_02, 0.00f, 2, 1, null, false);
            Vector3 Pris_03 = new Vector3(1655.93f, 2544.805f, 45.56487f);
            NPCSpawn("s_m_m_prisguard_01", Pris_03, 0.00f, 2, 1, null, false);

            bDead = false;
        }
        private void YouJog()
        {

            LogginSyatem("YouJog");

            iActionTime = Game.GameTime + 100;

            if (Game.Player.Character.Position.DistanceTo(RanLoc_01[iPath]) < 3.75f)
            {
                iPath += 1;
                if (iPath == RanLoc_01.Count())
                    iPath = 0;
                Game.Player.Character.Task.RunTo(RanLoc_01[iPath]);
            }
        }
        private void YouDrive()
        {

            LogginSyatem("YouDrive");

            iActionTime = Game.GameTime + 100;

            if (bFallenOff)
            {
                if (!Game.Player.Character.IsInVehicle(RideThis))
                {
                    Game.Player.Character.Task.EnterVehicle(RideThis, VehicleSeat.Driver, -1, 2.00f);
                    iActionTime = Game.GameTime + 3000;
                }
                else
                {
                    Game.Player.Character.Task.DriveTo(RideThis, RanLoc_01[iPath], 5.00f, 35.00f);
                    bFallenOff = false;
                }
            }
            else if (Game.Player.Character.IsInVehicle())
            {
                if (Game.Player.Character.Position.DistanceTo(RanLoc_01[iPath]) < 2.50f)
                {
                    if (RideThis == null)
                        RideThis = Game.Player.Character.CurrentVehicle;

                    iPath += 1;
                    if (iPath == RanLoc_01.Count())
                        iPath = 0;
                    Game.Player.Character.Task.DriveTo(RideThis, RanLoc_01[iPath], 5.00f, 35.00f);
                }
            }
            else if (RideThis != null)
            {
                Game.Player.Character.Task.EnterVehicle(RideThis, VehicleSeat.Driver, -1, 2.00f);
                bFallenOff = true;
            }
        }
        private void YouHeliTo()
        {
            iActionTime = Game.GameTime + 100;

            if (Game.Player.Character.IsInVehicle())
            {
                if (iPath == 0)
                {
                    if (!Game.Player.Character.CurrentVehicle.IsInAir)
                    {
                        iActionTime = Game.GameTime + 6000;
                        iPath += 1;
                    }
                }
                else if (Game.Player.Character.Position.DistanceTo(RanLoc_01[iPath]) < 5.00f)
                {
                    iPath += 1;
                    if (iPath == RanLoc_01.Count())
                    {
                        FlyHeliHere(RanLoc_01[0], fHeads[0], Game.Player.Character.CurrentVehicle, Game.Player.Character, true);
                        iPath = 0;
                    }
                    else
                        FlyHeliHere(RanLoc_01[iPath], fHeads[iPath], Game.Player.Character.CurrentVehicle, Game.Player.Character, false);
                }
                else if (iPath == 1)
                {
                    iActionTime = Game.GameTime + 1000;
                    FlyHeliHere(RanLoc_01[iPath], fHeads[iPath], Game.Player.Character.CurrentVehicle, Game.Player.Character, false);
                }
            }
        }
        private void HeliFlyYou()
        {
            iActionTime = Game.GameTime + 100;

            if (iPath < RanLoc_01.Count() - 1)
            {
                if (Shoaf.Position.DistanceTo(RanLoc_01[iPath]) < 10.00f)
                {
                    iPath += 1;
                    FlyHeliHere(RanLoc_01[iPath], fHeads[iPath], Shoaf, pPilot, false);
                }
            }
            else
            {
                FlyHeliHere(RanLoc_01[RanLoc_01.Count() - 1], fHeads[fHeads.Count() - 1], Shoaf, pPilot, true);
                bAllowControl = false;
                while (Game.Player.Character.IsInVehicle())
                    Script.Wait(100);
                Shoaf.EngineRunning = false;
                CleanUpMess();
            }
        }
        private void PedScenario(Ped Peddy, string sCenario, Vector3 Vpos, float fHeadings, bool bSeated)
        {

            LogginSyatem("PedScenario sCenario == " + sCenario);

            Function.Call(Hash.TASK_START_SCENARIO_AT_POSITION, Peddy.Handle, sCenario, Vpos.X, Vpos.Y, Vpos.Z, fHeadings, 0, 0, 1);
        }
        private void Yankton(bool bLoadIn)
        {

            LogginSyatem("Yankton");

            List<string> YanktonIPLs = new List<string>();

            YanktonIPLs.Add("plg_01");
            YanktonIPLs.Add("prologue01");
            YanktonIPLs.Add("prologue01_lod");
            YanktonIPLs.Add("prologue01c");
            YanktonIPLs.Add("prologue01c_lod");
            YanktonIPLs.Add("prologue01d");
            YanktonIPLs.Add("prologue01d_lod");
            YanktonIPLs.Add("prologue01e");
            YanktonIPLs.Add("prologue01e_lod");
            YanktonIPLs.Add("prologue01f");
            YanktonIPLs.Add("prologue01f_lod");
            YanktonIPLs.Add("prologue01g");
            YanktonIPLs.Add("prologue01h");
            YanktonIPLs.Add("prologue01h_lod");
            YanktonIPLs.Add("prologue01i");
            YanktonIPLs.Add("prologue01i_lod");
            YanktonIPLs.Add("prologue01j");
            YanktonIPLs.Add("prologue01j_lod");
            YanktonIPLs.Add("prologue01k");
            YanktonIPLs.Add("prologue01k_lod");
            YanktonIPLs.Add("prologue01z");
            YanktonIPLs.Add("prologue01z_lod");
            YanktonIPLs.Add("plg_02");
            YanktonIPLs.Add("prologue02");
            YanktonIPLs.Add("prologue02_lod");
            YanktonIPLs.Add("plg_03");
            YanktonIPLs.Add("prologue03");
            YanktonIPLs.Add("prologue03_lod");
            YanktonIPLs.Add("prologue03b");
            YanktonIPLs.Add("prologue03b_lod");
            YanktonIPLs.Add("prologue03_grv_dug");
            YanktonIPLs.Add("prologue03_grv_dug_lod");
            YanktonIPLs.Add("prologue_grv_torch");
            YanktonIPLs.Add("plg_04");
            YanktonIPLs.Add("prologue04");
            YanktonIPLs.Add("prologue04_lod");
            YanktonIPLs.Add("prologue04b");
            YanktonIPLs.Add("prologue04b_lod");
            YanktonIPLs.Add("prologue04_cover");
            YanktonIPLs.Add("des_protree_end");
            YanktonIPLs.Add("des_protree_start");
            YanktonIPLs.Add("des_protree_start_lod");
            YanktonIPLs.Add("plg_05");
            YanktonIPLs.Add("prologue05");
            YanktonIPLs.Add("prologue05_lod");
            YanktonIPLs.Add("prologue05b");
            YanktonIPLs.Add("prologue05b_lod");
            YanktonIPLs.Add("plg_06");
            YanktonIPLs.Add("prologue06");
            YanktonIPLs.Add("prologue06_lod");
            YanktonIPLs.Add("prologue06b");
            YanktonIPLs.Add("prologue06b_lod");
            YanktonIPLs.Add("prologue06_int");
            YanktonIPLs.Add("prologue06_int_lod");
            YanktonIPLs.Add("prologue06_pannel");
            YanktonIPLs.Add("prologue06_pannel_lod");
            YanktonIPLs.Add("prologue_m2_door");
            YanktonIPLs.Add("prologue_m2_door_lod");
            YanktonIPLs.Add("plg_occl_00");
            YanktonIPLs.Add("prologue_occl");
            YanktonIPLs.Add("plg_rd");
            YanktonIPLs.Add("prologuerd");
            YanktonIPLs.Add("prologuerdb");
            YanktonIPLs.Add("prologuerd_lod");

            if (bLoadIn)
            {
                Function.Call(Hash._ENABLE_MP_DLC_MAPS, false);
                Function.Call((Hash)0x9133955F1A2DA957, true);

                for (int i = 0; i < YanktonIPLs.Count; i++)
                    Function.Call(Hash.REQUEST_IPL, YanktonIPLs[i]);

                bInYankton = true;
            }
            else
            {
                Function.Call(Hash._ENABLE_MP_DLC_MAPS, true);
                Function.Call((Hash)0x9133955F1A2DA957, false);

                Function.Call(Hash._LOAD_MP_DLC_MAPS);

                Function.Call((Hash)0x9BAE5AD2508DF078, false);

                for (int i = 0; i < YanktonIPLs.Count; i++)
                    Function.Call(Hash.REMOVE_IPL, YanktonIPLs[i]);

                bInYankton = false;
            }
        }
        private void CayoPerico(bool bLoadIn)
        {

            LogginSyatem("CayoPerico");

            List<string> CayoPericoIPLs = new List<string>();

            CayoPericoIPLs.Add("h4_islandairstrip");
            CayoPericoIPLs.Add("h4_islandairstrip_props");
            CayoPericoIPLs.Add("h4_islandx_mansion");
            CayoPericoIPLs.Add("h4_islandx_mansion_props");
            CayoPericoIPLs.Add("h4_islandx_props");
            CayoPericoIPLs.Add("h4_islandxdock");
            CayoPericoIPLs.Add("h4_islandxdock_props");
            CayoPericoIPLs.Add("h4_islandxdock_props_2");
            CayoPericoIPLs.Add("h4_islandxtower");
            CayoPericoIPLs.Add("h4_islandx_maindock");
            CayoPericoIPLs.Add("h4_islandx_maindock_props");
            CayoPericoIPLs.Add("h4_islandx_maindock_props_2");
            CayoPericoIPLs.Add("h4_IslandX_Mansion_Vault");
            CayoPericoIPLs.Add("h4_islandairstrip_propsb");
            CayoPericoIPLs.Add("h4_islandx_barrack_props");
            CayoPericoIPLs.Add("h4_islandx_checkpoint");
            CayoPericoIPLs.Add("h4_islandx_checkpoint_props");
            CayoPericoIPLs.Add("h4_islandx_Mansion_Office");
            CayoPericoIPLs.Add("h4_islandx_Mansion_LockUp_01");
            CayoPericoIPLs.Add("h4_islandx_Mansion_LockUp_02");
            CayoPericoIPLs.Add("h4_islandx_Mansion_LockUp_03");
            CayoPericoIPLs.Add("h4_islandairstrip_hangar_props");
            CayoPericoIPLs.Add("h4_IslandX_Mansion_B");
            CayoPericoIPLs.Add("h4_islandairstrip_doorsclosed");
            CayoPericoIPLs.Add("h4_Underwater_Gate_Closed");
            CayoPericoIPLs.Add("h4_mansion_gate_closed");
            CayoPericoIPLs.Add("h4_aa_guns");
            CayoPericoIPLs.Add("h4_IslandX_Mansion_GuardFence");
            CayoPericoIPLs.Add("h4_IslandX_Mansion_Entrance_Fence");
            CayoPericoIPLs.Add("h4_IslandX_Mansion_B_Side_Fence");
            CayoPericoIPLs.Add("h4_IslandX_Mansion_Lights");
            CayoPericoIPLs.Add("h4_islandxcanal_props");
            CayoPericoIPLs.Add("h4_islandX_Terrain_props_06_a");
            CayoPericoIPLs.Add("h4_islandX_Terrain_props_06_b");
            CayoPericoIPLs.Add("h4_islandX_Terrain_props_06_c");
            CayoPericoIPLs.Add("h4_islandX_Terrain_props_05_a");
            CayoPericoIPLs.Add("h4_islandX_Terrain_props_05_b");
            CayoPericoIPLs.Add("h4_islandX_Terrain_props_05_c");
            CayoPericoIPLs.Add("h4_islandX_Terrain_props_05_d");
            CayoPericoIPLs.Add("h4_islandX_Terrain_props_05_e");
            CayoPericoIPLs.Add("h4_islandX_Terrain_props_05_f");
            CayoPericoIPLs.Add("H4_islandx_terrain_01");
            CayoPericoIPLs.Add("H4_islandx_terrain_02");
            CayoPericoIPLs.Add("H4_islandx_terrain_03");
            CayoPericoIPLs.Add("H4_islandx_terrain_04");
            CayoPericoIPLs.Add("H4_islandx_terrain_05");
            CayoPericoIPLs.Add("H4_islandx_terrain_06");
            CayoPericoIPLs.Add("h4_ne_ipl_00");
            CayoPericoIPLs.Add("h4_ne_ipl_01");
            CayoPericoIPLs.Add("h4_ne_ipl_02");
            CayoPericoIPLs.Add("h4_ne_ipl_03");
            CayoPericoIPLs.Add("h4_ne_ipl_04");
            CayoPericoIPLs.Add("h4_ne_ipl_05");
            CayoPericoIPLs.Add("h4_ne_ipl_06");
            CayoPericoIPLs.Add("h4_ne_ipl_07");
            CayoPericoIPLs.Add("h4_ne_ipl_08");
            CayoPericoIPLs.Add("h4_ne_ipl_09");
            CayoPericoIPLs.Add("h4_nw_ipl_00");
            CayoPericoIPLs.Add("h4_nw_ipl_01");
            CayoPericoIPLs.Add("h4_nw_ipl_02");
            CayoPericoIPLs.Add("h4_nw_ipl_03");
            CayoPericoIPLs.Add("h4_nw_ipl_04");
            CayoPericoIPLs.Add("h4_nw_ipl_05");
            CayoPericoIPLs.Add("h4_nw_ipl_06");
            CayoPericoIPLs.Add("h4_nw_ipl_07");
            CayoPericoIPLs.Add("h4_nw_ipl_08");
            CayoPericoIPLs.Add("h4_nw_ipl_09");
            CayoPericoIPLs.Add("h4_se_ipl_00");
            CayoPericoIPLs.Add("h4_se_ipl_01");
            CayoPericoIPLs.Add("h4_se_ipl_02");
            CayoPericoIPLs.Add("h4_se_ipl_03");
            CayoPericoIPLs.Add("h4_se_ipl_04");
            CayoPericoIPLs.Add("h4_se_ipl_05");
            CayoPericoIPLs.Add("h4_se_ipl_06");
            CayoPericoIPLs.Add("h4_se_ipl_07");
            CayoPericoIPLs.Add("h4_se_ipl_08");
            CayoPericoIPLs.Add("h4_se_ipl_09");
            CayoPericoIPLs.Add("h4_sw_ipl_00");
            CayoPericoIPLs.Add("h4_sw_ipl_01");
            CayoPericoIPLs.Add("h4_sw_ipl_02");
            CayoPericoIPLs.Add("h4_sw_ipl_03");
            CayoPericoIPLs.Add("h4_sw_ipl_04");
            CayoPericoIPLs.Add("h4_sw_ipl_05");
            CayoPericoIPLs.Add("h4_sw_ipl_06");
            CayoPericoIPLs.Add("h4_sw_ipl_07");
            CayoPericoIPLs.Add("h4_sw_ipl_08");
            CayoPericoIPLs.Add("h4_sw_ipl_09");
            CayoPericoIPLs.Add("h4_islandx_mansion");
            CayoPericoIPLs.Add("h4_islandxtower_veg");
            CayoPericoIPLs.Add("h4_islandx_sea_mines");
            CayoPericoIPLs.Add("h4_islandx");
            CayoPericoIPLs.Add("h4_islandx_barrack_hatch");
            CayoPericoIPLs.Add("h4_islandxdock_water_hatch");

            CayoPericoIPLs.Add("h4_beach");
            CayoPericoIPLs.Add("h4_beach_props");
            CayoPericoIPLs.Add("h4_beach_bar_props");
            CayoPericoIPLs.Add("h4_beach_props_party");
            CayoPericoIPLs.Add("h4_beach_party");
            //sPropAttach.Add("h4_prop_battle_analoguemixer_01a");//Dj Deck-  02

            if (bLoadIn)
            {
                Function.Call(Hash._ENABLE_MP_DLC_MAPS, true);
                Function.Call((Hash)0x9A9D1BA639675CF1, "HeistIsland", 1);
                Function.Call((Hash)0x5E1460624D194A38, 1);

                Function.Call((Hash)0xF74B1FFA4A15FBEA, true);
                Function.Call((Hash)0x53797676AD34A9AA, false);

                Function.Call((Hash)0xF8DEE0A5600CBB93, true);

                for (int i = 0; i < CayoPericoIPLs.Count; i++)
                    Function.Call(Hash.REQUEST_IPL, CayoPericoIPLs[i]);

                if (bAddBeachParty)
                {
                    List<Vector3> vPartays = new List<Vector3>();
                    List<Vector3> vPartB = new List<Vector3>();
                    List<float> vPartBHead = new List<float>();

                    vPartays.Add(new Vector3(4894.263f, -4913.141f, 3.36446f));     //Dance Rad == 5    00
                    vPartays.Add(new Vector3(4890.318f, -4923.923f, 3.368097f));    //Dance Rad == 8    01
                    vPartays.Add(new Vector3(4900.574f, -4923.098f, 3.36113f));     //Sit  Rad == 3     02
                    vPartays.Add(new Vector3(4883.7f, -4916.323f, 3.368711f));      //Sit  Rad == 3     03
                    vPartays.Add(new Vector3(4888.34f, -4933.511f, 3.367885f));     //Sit  Rad == 3     04
                    vPartays.Add(new Vector3(4882.221f, -4933.872f, 3.37767f));     //Sit  Rad == 3     05
                    vPartays.Add(new Vector3(4897.382f, -4938.688f, 3.362702f));    //Sit  Rad == 3     06
                    vPartays.Add(new Vector3(4901.941f, -4935.71f, 3.363577f));     //Sit  Rad == 3     07
                    vPartays.Add(new Vector3(4908.562f, -4934.384f, 3.367695f));    //Sit  Rad == 3     08

                    vPartB.Add(new Vector3(4878.054f, -4948.04f, 3.556281f)); vPartBHead.Add(91.67182f);
                    vPartB.Add(new Vector3(4875.837f, -4950.161f, 3.629188f)); vPartBHead.Add(351.4073f);
                    vPartB.Add(new Vector3(4874.032f, -4947.307f, 3.575044f)); vPartBHead.Add(242.7412f);
                    vPartB.Add(new Vector3(4876.772f, -4946.251f, 3.520398f)); vPartBHead.Add(146.6341f);//Fire Pit

                    vPartB.Add(new Vector3(4872.481f, -4911.394f, 3.003824f)); vPartBHead.Add(294.576f);
                    vPartB.Add(new Vector3(4872.82f, -4917.226f, 2.915241f)); vPartBHead.Add(271.9123f);
                    vPartB.Add(new Vector3(4871.187f, -4917.283f, 2.847157f)); vPartBHead.Add(341.5042f);//sun back

                    vPartB.Add(new Vector3(4871.44f, -4910.393f, 2.946956f)); vPartBHead.Add(288.3906f);
                    vPartB.Add(new Vector3(4872.479f, -4911.321f, 3.003426f)); vPartBHead.Add(119.555f);
                    vPartB.Add(new Vector3(4866.439f, -4906.744f, 2.577915f)); vPartBHead.Add(106.9248f);
                    vPartB.Add(new Vector3(4867.695f, -4910.954f, 2.650635f)); vPartBHead.Add(110.5905f);
                    vPartB.Add(new Vector3(4867.171f, -4909.43f, 2.605493f)); vPartBHead.Add(101.497f);
                    vPartB.Add(new Vector3(4868.493f, -4913.752f, 2.716372f)); vPartBHead.Add(283.9765f);
                    vPartB.Add(new Vector3(4869.915f, -4921.263f, 2.879118f)); vPartBHead.Add(278.9364f);
                    vPartB.Add(new Vector3(4868.144f, -4943.559f, 2.709443f)); vPartBHead.Add(246.9356f);
                    vPartB.Add(new Vector3(4862.854f, -4956.314f, 2.491656f)); vPartBHead.Add(64.97399f);
                    vPartB.Add(new Vector3(4863.502f, -4955.183f, 2.544171f)); vPartBHead.Add(78.42456f);//sun front

                    Game.Player.Character.Position = vPartays[1];
                    Script.Wait(1000);
                    int iRan = RandInt(4, 7);

                    for (int i = 0; i < iRan; i++)
                    {
                        Vector3 vDance = vPartays[0].Around(5.00f);
                        vDance.Z = vPartays[0].Z;
                        CayoNPCSpawn(AddAnyPed(2), null, vDance, RandInt(0, 360), 12);
                    }

                    iRan = RandInt(7, 13);

                    for (int i = 0; i < iRan; i++)
                    {
                        Vector3 vDance = vPartays[1].Around(8.00f);
                        vDance.Z = vPartays[1].Z;
                        CayoNPCSpawn(AddAnyPed(2), null, vDance, RandInt(0, 360), 12);
                    }

                    for (int i = 2; i < vPartays.Count; i++)
                    {
                        Prop[] PSit = World.GetNearbyProps(vPartays[i], 3.00f);
                        for (int ii = 0; ii < PSit.Count(); ii++)
                        {
                            if (PSit[ii].Model == Function.Call<int>(Hash.GET_HASH_KEY, "h4_prop_h4_couch_01a") || PSit[ii].Model == Function.Call<int>(Hash.GET_HASH_KEY, "h4_prop_h4_chair_01a"))
                            {
                                if (RandInt(0, 20) < 10)
                                    CayoNPCSpawn(AddAnyPed(2), PSit[ii], Vector3.Zero, RandInt(0, 360), 12);
                            }
                        }
                    }

                    for (int i = 0; i < 4; i++)
                        CayoNPCSpawn(AddAnyPed(2), null, vPartB[i], vPartBHead[i], 12);


                    for (int i = 4; i < 6; i++)
                    {
                        if (RandInt(0, 20) < 10)
                            CayoNPCSpawn(AddAnyPed(2), null, vPartB[i], vPartBHead[i], 15);
                    }

                    for (int i = 6; i < vPartB.Count; i++)
                    {
                        if (RandInt(0, 20) < 10)
                            CayoNPCSpawn(AddAnyPed(2), null, vPartB[i], vPartBHead[i], 16);
                    }

                    Vector3 vDj = new Vector3(4893.571f, -4905.296f, 3.481121f);
                    Vector3 vBar = new Vector3(4902.647f, -4943.707f, 3.392626f);

                    CayoNPCSpawn("IG_SSS", null, vDj, 192.4766f, 12);
                    CayoNPCSpawn("S_F_Y_BeachBarStaff_01", null, vBar, 46.24336f, 12);

                    DanceFloor(true);
                }

                bInCayoPerico = true;
            }
            else
            {
                Function.Call((Hash)0x9A9D1BA639675CF1, "HeistIsland", 0);
                Function.Call((Hash)0x5E1460624D194A38, 0);

                Function.Call((Hash)0xF74B1FFA4A15FBEA, false);
                Function.Call((Hash)0x53797676AD34A9AA, true);

                LoadOnlineIps();

                for (int i = 0; i < CayoPericoIPLs.Count; i++)
                    Function.Call(Hash.REMOVE_IPL, CayoPericoIPLs[i]);

                for (int i = 0; i < PedParty.Count; i++)
                    PedParty[i].Delete();

                PedParty.Clear();
                DanceFloor(false);
                bInCayoPerico = false;
                bOpenDoors = false;
            }
        }
        private void DanceFloor(bool bOn)
        {

            LogginSyatem("DanceFloor, bOn == " + bOn);

            if (bOn)
            {
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_01_left", true);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_02_right", true);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_04_reverb", true);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_03_reverb", true);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_02_right", true);

            }
            else
            {
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_01_left", false);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_02_right", false);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_04_reverb", false);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_03_reverb", false);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_02_right", false);
            }
        }
        public List<string> DanceList(bool bMale, int iSpeed)
        {

            LogginSyatem("DanceList, bMale == " + bMale + ", iSpeed == " + iSpeed);

            List<string> sDancing = new List<string>();
            List<string> Dance = new List<string>(); List<string> DanceVar = new List<string>();

            if (bMale)
            {
                if (iSpeed == 1)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_male^5");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_male^6");
                }
                else if (iSpeed == 2)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_male^6");
                }
                else
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_male^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_male^6");
                }
            }
            else
            {
                if (iSpeed == 1)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_09_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_11_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_13_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_15_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity"); DanceVar.Add("li_dance_facedj_17_v2_female^6");
                }
                else if (iSpeed == 2)
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_09_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_11_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_13_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_15_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity"); DanceVar.Add("mi_dance_facedj_17_v1_female^6");
                }
                else
                {
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_09_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_11_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_13_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_15_v2_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v1_female^6");

                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^1");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^2");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^3");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^4");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^5");
                    Dance.Add("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity"); DanceVar.Add("hi_dance_facedj_17_v2_female^6");
                }
            }
            if (Dance.Count() > 0)
            {
                int iRand = RandInt(0, Dance.Count() - 1);
                sDancing.Add(Dance[iRand]);
                sDancing.Add(DanceVar[iRand]);
            }
            else
            {
                sDancing.Add("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity");
                sDancing.Add("li_dance_facedj_17_v2_female^6");
            }

            return sDancing;
        }
        private void LoadOnlineIps()
        {

            LogginSyatem("LoadOnlineIps");

            List<string> sAddIpl = new List<string>();

            Function.Call(Hash._ENABLE_MP_DLC_MAPS, true);
            Function.Call(Hash._LOAD_MP_DLC_MAPS);

            Function.Call((Hash)0x9BAE5AD2508DF078, false);

            sAddIpl.Add("vw_casino_billboard_lod");
            sAddIpl.Add("vw_casino_billboard_lod(1)");
            sAddIpl.Add("vw_casino_billboard");
            sAddIpl.Add("hei_dlc_windows_casino_lod");
            sAddIpl.Add("hei_dlc_windows_casino");
            sAddIpl.Add("hei_dlc_casino_door_lod");
            sAddIpl.Add("hei_dlc_casino_door");
            sAddIpl.Add("hei_dlc_casino_aircon_lod");
            sAddIpl.Add("hei_dlc_casino_aircon");

            for (int i = 0; i < sAddIpl.Count; i++)
            {
                if (!Function.Call<bool>(Hash.IS_IPL_ACTIVE, sAddIpl[i]))
                    Function.Call(Hash.REQUEST_IPL, sAddIpl[i]);
            }
        }
        private void FlyHeliHere(Vector3 Vloc, float fHeadin, Vehicle Heli, Ped Plot, bool bLand)
        {

            LogginSyatem("FlyHeliHere, bLand == " + bLand);

            float HeliDesX = Vloc.X;
            float HeliDesY = Vloc.Y;
            float HeliDesZ = Vloc.Z;
            float HeliSpeed = 50.00f;
            float HeliLandArea = 0.00f;
            float HeliDirect = fHeadin;

            if (bLand)
                Function.Call(Hash.TASK_HELI_MISSION, Plot.Handle, Heli.Handle, 0, 0, HeliDesX, HeliDesY, HeliDesZ, 4, 15.00f, 4.50f, HeliDirect, -1, -1, -1, 32);
            else
                Function.Call(Hash.TASK_HELI_MISSION, Plot.Handle, Heli.Handle, 0, 0, HeliDesX, HeliDesY, HeliDesZ, 4, HeliSpeed, HeliLandArea, HeliDirect, -1, -1, -1, 0);
        }
        private void MethEdd(bool bOver)
        {

            LogginSyatem("MethEdd, bOver == " + bOver);

            if (bOver)
            {
                bMethActor = false;
                Function.Call(Hash.CLEAR_TIMECYCLE_MODIFIER);
                if (bMethFail)
                    Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, Game.Player.Character, 0.00f);
                bMethFail = false;
            }
            else
            {
                bMethFail = false;
                int iTenPass = 10;
                bMethActor = true;
                Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "DRUG_gas_huffin");
                while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "move_m@drunk@moderatedrunk") || iTenPass < 0)
                {
                    iTenPass -= 1;
                    Function.Call(Hash.REQUEST_ANIM_SET, "move_m@drunk@moderatedrunk");
                    Script.Wait(100);
                }
                if (Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "move_m@drunk@moderatedrunk"))
                {
                    bMethFail = true;
                    Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character.Handle, "move_m@drunk@moderatedrunk", 1.00f);
                }

            }
        }
        private void YouDrive(Vehicle Vhick)
        {

            LogginSyatem("YouDrive");

            Vector3 V3ME = Vhick.Position + (Vhick.ForwardVector * 45.00f);
            Game.Player.Character.Task.DriveTo(Vhick, V3ME, 2.00f, 45.00f);
        }
        private void AccessAllAreas()
        {

            LogginSyatem("AccessAllAreas");

            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "restrictedareas");
            bDontStopMe = true;
            bDead = false;
        }
        private void InRestrictedArea()
        {
            Game.Player.WantedLevel = 0;
            Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, Game.Player.Character, false);
            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_prison");
            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_armybase");
            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_lossantosintl");
            Function.Call(Hash.STOP_ALARM, "PRISON_ALARMS", 0);
            Function.Call(Hash.CLEAR_AMBIENT_ZONE_STATE, "AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_GENERAL", 0);
            Function.Call(Hash.CLEAR_AMBIENT_ZONE_STATE, "AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_WARNING", 0);

            if (bPrisHeli)
            {
                if (Game.Player.Character.IsInVehicle(PrisEscape) || Game.Player.Character.Position.DistanceTo(vAreaRest) > 1500.00f)
                {
                    bPrisHeli = false;
                    bDontStopMe = false;
                    BacktoBase(true);
                }
            }
            else if (Game.Player.Character.Position.DistanceTo(vAreaRest) > 1500.00f)
            {
                bDontStopMe = false;
                BacktoBase(false);
            }

        }
        private void OpeningDoors(Vector3 Vtarg01, Vector3 Vtarg02, Vector3 Vtarg03)
        {
            int iLockBreak = 0;
            if (iUnlock < Game.GameTime)
            {
                iUnlock = Game.GameTime + 1000;
                if (Game.Player.Character.Position.DistanceTo(Vtarg01) < 3.00f)
                    iLockBreak = 1;
                else if (Game.Player.Character.Position.DistanceTo(Vtarg02) < 3.00f)
                    iLockBreak = 2;
                else if (Game.Player.Character.Position.DistanceTo(Vtarg03) < 3.00f)
                    iLockBreak = 3;
            }
            if (iLockBreak > 0)
            {
                string sGate = "";
                Vector3 vMyGate = Vector3.Zero;
                if (iLockBreak == 1)
                {
                    sGate = "h4_prop_h4_gate_04a";
                    vMyGate = Vtarg01;
                }
                else if (iLockBreak == 2)
                {
                    sGate = "h4_prop_h4_gate_r_03a";
                    vMyGate = Vtarg02;
                }
                else if (iLockBreak == 3)
                {
                    sGate = "h4_prop_h4_gate_l_03a ";
                    vMyGate = Vtarg03;
                    bOpenDoors = false;
                }
                Prop[] PList = World.GetNearbyProps(vMyGate, 12.00f);

                for (int i = 0; i < PList.Count(); i++)
                {
                    if (PList[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, sGate))
                    {
                        Function.Call(Hash._DOOR_CONTROL, Function.Call<int>(Hash.GET_HASH_KEY, sGate), PList[i].Position.X, PList[i].Position.Y, PList[i].Position.Z, 0, 0.0f, 50.0f, 0.0f);
                        PList[i].FreezePosition = false;
                    }
                }
            }
        }
        private void BacktoBase(bool bPrisHel)
        {

            LogginSyatem("BacktoBase, bPrisHel == " + bPrisHel);

            if (bPrisHel)
            {
                Game.Player.WantedLevel = 3;
                PrisEscape.FreezePosition = false;
                PrisEscape.CurrentBlip.Remove();
                PrisEscape.MarkAsNoLongerNeeded();
                PrisEscape = null;
                bPrisHeli = false;
            }
            Game.Player.IgnoredByPolice = false;
            Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, Game.Player.Character, true);
            Function.Call(Has﻿h.REQUEST_SCRIPT, "restrictedareas");
            Function.Call(Has﻿h.REQUEST_SCRIPT, "re_armybase");
            Function.Call(Has﻿h.REQUEST_SCRIPT, "re_lossantosintl");
            bDontStopMe = false;
        }
        private void FindCrimo(Vector3 Vec3, float fRadi, float fMinRadi)
        {

            LogginSyatem("FindCrimo");

            Vehicle[] CarSpot = World.GetNearbyVehicles(Vec3, fRadi);
            int iFind = CarSpot.Count();

            for (int i = 0; i < iFind; i++)
            {
                if (!bFound)
                {
                    if (CarSpot[i].IsPersistent == false && CarSpot[i].Position.DistanceTo(Game.Player.Character.Position) > fMinRadi && CarSpot[i] != Game.Player.Character.CurrentVehicle)
                    {
                        if (CarSpot[i].ClassType != VehicleClass.Boats && CarSpot[i].ClassType != VehicleClass.Cycles && CarSpot[i].ClassType != VehicleClass.Helicopters && CarSpot[i].ClassType != VehicleClass.Planes && CarSpot[i].ClassType != VehicleClass.Trains)
                        {
                            if (!CarSpot[i].IsSeatFree(VehicleSeat.Driver) && CarSpot[i].EngineRunning)
                            {
                                if (CarSpot[i].Exists())
                                {
                                    bFound = true;
                                    CarSpot[i].IsPersistent = true;
                                    CarSpot[i].Driver.IsPersistent = true;
                                    CopsNRobbers(CarSpot[i], CarSpot[i].Driver);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (!bFound)
            {
                Game.FadeScreenIn(1000);
                Game.Player.Character.Task.CruiseWithVehicle(Game.Player.Character.CurrentVehicle, 35.00f);
                Script.Wait(1000);
                FindCrimo(Vec3, fRadi, fMinRadi);
            }
        }
        private void CopsNRobbers(Vehicle vGetAway, Ped pDriver)
        {

            LogginSyatem("CopsNRobbers");

            Game.Player.Character.CurrentVehicle.SirenActive = true;
            pDriver.Task.FleeFrom(Game.Player.Character);
            Game.Player.Character.Task.VehicleChase(pDriver);
            for (int i = 0; i < vGetAway.PassengerSeats; i++)
            {
                if (!vGetAway.IsSeatFree(Vseats[i]))
                {
                    if (vGetAway.GetPedOnSeat(Vseats[i]) != pDriver)
                        vGetAway.GetPedOnSeat(Vseats[i]).Delete();
                }
            }
            VehList.Add(new Vehicle(vGetAway.Handle));
            PeddyList.Add(new Ped(pDriver.Handle));
            Vector3 V3 = vGetAway.Position + (vGetAway.RightVector * 4);
            FillthisVeh(vGetAway, 2, 0, V3, 6, 2, false);
        }
        public string AddAnyPed(int iType)
        {

            LogginSyatem("AddAnyPed");

            List<string> sPeds = new List<string>();

            if (iType == 1)
            {
                sPeds.Add("a_f_o_soucent_01");                //"South Central Old Female");  
                sPeds.Add("a_f_o_soucent_02");                //"South Central Old Female 2"); 
                sPeds.Add("a_f_o_indian_01");                //"Indian Old Female");  
                sPeds.Add("a_f_o_genstreet_01");                //"General Street Old Female");  
                sPeds.Add("a_f_o_ktown_01");                //"Korean Old Female");  
            }           //Old dear 
            else if (iType == 2)
            {
                sPeds.Add("a_f_m_beach_01");                //"Beach Female");   
                sPeds.Add("a_f_y_hippie_01");                //"Hippie Female"); 
                sPeds.Add("a_m_m_beach_01");                //"Beach Male");  
                sPeds.Add("a_m_y_beach_01");                //"Beach Young Male");  
                sPeds.Add("a_m_y_beach_03");                //"Beach Young Male 3"); 
                sPeds.Add("a_m_y_sunbathe_01");                //"Sunbather Male");  
                sPeds.Add("a_m_y_beachvesp_01");                //"Vespucci Beach Male");  
                sPeds.Add("a_m_y_beachvesp_02");                //"Vespucci Beach Male 2"); 
                sPeds.Add("A_F_Y_Beach_02");
                sPeds.Add("A_M_O_Beach_02");
                sPeds.Add("A_M_Y_Beach_04");
            }           //DancingBeach

            return sPeds[RandInt(0, sPeds.Count() - 1)];
        }
        public int RandInt(int minNumber, int maxNumber)
        {

            LogginSyatem("RandInt");

            int iMyRanInt = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, minNumber, maxNumber);
            if (minNumber + 1 == maxNumber)
            {
                if (BoolList(19))
                    iMyRanInt = maxNumber;
                else
                    iMyRanInt = minNumber;
            }
            return iMyRanInt;
        }
        public float RandFloat(float fMin, float fMax)
        {
            float iMyRanFlow = Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, fMin, fMax);

            return iMyRanFlow;
        }
        public List<string> TattoosList(int iPed, int iZone)
        {

            LogginSyatem("TattoosList, iPed == " + iPed + ", iZone == " + iZone);

            bool bEmpty = false;
            List<string> MyTat = new List<string>();

            sTatBase.Clear();
            sTatName.Clear();

            if (iPed == 1)
            {
                if (iZone == 1)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_018"); MyTat.Add("Impotent Rage");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_014"); MyTat.Add("Chinese Dragon");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_008"); MyTat.Add("Trinity Knot");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_004"); MyTat.Add("Lucky");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_020"); MyTat.Add("Way of the Gun");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_017"); MyTat.Add("Whiskey Life");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_015"); MyTat.Add("Flaming Shamrock");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_006"); MyTat.Add("Eagle and Serpent");
                }//TORSO
                else if (iZone == 2)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_003"); MyTat.Add("The Rose of My Heart");
                }//HEAD
                else if (iZone == 3)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_019"); MyTat.Add("Dragon");//     
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_012"); MyTat.Add("Faith");//   
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_010"); MyTat.Add("Lady M");//   
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_009"); MyTat.Add("Lucky Celtic Dogs");//  
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_007"); MyTat.Add("Mermaid");//       
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_000"); MyTat.Add("Mandy");//    
                }//LEFT ARM 
                else if (iZone == 4)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_016"); MyTat.Add("Michael and Amanda");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_013"); MyTat.Add("Flower Mural");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_005"); MyTat.Add("Virgin Mary");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_001"); MyTat.Add("Family is Forever");
                }//RIGHT ARM
                else if (iZone == 5)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_002"); MyTat.Add("Smoking Dagger");
                }//LEFT LEG
                else
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("MK_011"); MyTat.Add("Tiki Pinup ");
                }//RIGHT LEG
            }// Michael
            else if (iPed == 2)
            {
                if (iZone == 1)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_038"); MyTat.Add("Angel of Los Santos");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_010"); MyTat.Add("Grace and Power");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_004"); MyTat.Add("Dragon");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_039"); MyTat.Add("Impotent Rage");//   
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_037"); MyTat.Add("Los Santos Bills");// 
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_036"); MyTat.Add("These Streets");//    
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_035"); MyTat.Add("Families");//      
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_032"); MyTat.Add("LS Flames");//  
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_031"); MyTat.Add("Fam 4 Life");//   
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_030"); MyTat.Add("Families Symbol");//      
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_029"); MyTat.Add("FAM Power");//    
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_028"); MyTat.Add("Flaming Cross");//  
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_021"); MyTat.Add("Chamberlain Families LS");//  
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_020"); MyTat.Add("LS Heart ");//   
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_018"); MyTat.Add("Families Kings");//  
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_011"); MyTat.Add("Forum4Life");//      
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_000"); MyTat.Add("Chamberlain");//     
                    //Not in List
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_025"); MyTat.Add("Skull on the Cross");//    
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_024"); MyTat.Add("Skull and Dragon");
                }//TORSO
                else if (iZone == 2)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_022"); MyTat.Add("Chamberlain Families");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_005"); MyTat.Add("Faith");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_034"); MyTat.Add("LS Bold");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_033"); MyTat.Add("LS Script");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_014"); MyTat.Add("F King");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_013"); MyTat.Add("F Crown ");
                }//HEAD
                else if (iZone == 3)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_019"); MyTat.Add("FAMILIES");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_017"); MyTat.Add("Lion");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_016"); MyTat.Add("Dragon Mural");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_007"); MyTat.Add("Serpent Skull");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_001"); MyTat.Add("Brotherhood");
                }//LEFT ARM
                else if (iZone == 4)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_023"); MyTat.Add("Fiery Dragon");//    
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_012"); MyTat.Add("Oriental Mural");//    
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_009"); MyTat.Add("Chop");//    
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_008"); MyTat.Add("Mother");//    
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_006"); MyTat.Add("Serpents");//    
                }//RIGHT ARM
                else if (iZone == 5)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_027"); MyTat.Add("Hottie");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_015"); MyTat.Add("The Warrior");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_002"); MyTat.Add("Dragons");
                }//LEFT LEG
                else
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_026"); MyTat.Add("Trust No One");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("fr_003"); MyTat.Add("Melting Skull");
                }//RIGHT LEG
            }// Franklin
            else if (iPed == 3)
            {
                if (iZone == 1)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_032"); MyTat.Add("Lucky");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_031"); MyTat.Add("Unzipped");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_026"); MyTat.Add("Skulls and Rose");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_022"); MyTat.Add("Chinese Dragon");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_033"); MyTat.Add("Impotent Rage");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_030"); MyTat.Add("Fuck Cops");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_029"); MyTat.Add("Smiley");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_028"); MyTat.Add("Ace");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_027"); MyTat.Add("Piggy");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_023"); MyTat.Add("Monster Pups");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_021"); MyTat.Add("Stone Cross");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_015"); MyTat.Add("Tweaker");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_013"); MyTat.Add("Betraying Scroll");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_012"); MyTat.Add("Eye Catcher");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_006"); MyTat.Add("Blackjack");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_004"); MyTat.Add("Evil Clown");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_000"); MyTat.Add("Imperial Douche");
                }//TORSO
                else if (iZone == 2)
                {
                    bEmpty = true;
                }//HEAD
                else if (iZone == 3)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_024"); MyTat.Add("Grim Reaper Smoking Gun");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_018"); MyTat.Add("Dope Skull");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_017"); MyTat.Add("The Wages of Sin");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_016"); MyTat.Add("Dragon and Dagger");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_003"); MyTat.Add("Zodiac Skull");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_001"); MyTat.Add("R.I.P Michael");
                }//LEFT ARM
                else if (iZone == 4)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_020"); MyTat.Add("Indian Ram");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_014"); MyTat.Add("Muertos");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_010"); MyTat.Add("Flaming Skull");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_009"); MyTat.Add("Broken Skull");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_008"); MyTat.Add("Dagger");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_007"); MyTat.Add("Tribal");
                }//RIGHT ARM
                else if (iZone == 5)
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_011"); MyTat.Add("Serpant Skull");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_002"); MyTat.Add("Grim Reaper");
                }//LEFT LEG
                else
                {
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_025"); MyTat.Add("Freedom");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_019"); MyTat.Add("Flaming Scorpion");
                    sTatBase.Add("singleplayer_overlays"); sTatName.Add("TP_005"); MyTat.Add("Love to Hate");
                }//RIGHT LEG
            }// Trevor
            else if (iPed == 4)
            {
                if (iZone == 1)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_021_F"); MyTat.Add("Skull Surfer");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_020_F"); MyTat.Add("Speaker Tower");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_019_F"); MyTat.Add("Record Shot");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_018_F"); MyTat.Add("Record Head");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_017_F"); MyTat.Add("Tropical Sorcerer");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_016_F"); MyTat.Add("Rose Panther");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_015_F"); MyTat.Add("Paradise Ukulele");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_014_F"); MyTat.Add("Paradise Nap");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_013_F"); MyTat.Add("Wild Dancers");//

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_039_F"); MyTat.Add("Space Rangers");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_038_F"); MyTat.Add("Robot Bubblegum");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_036_F"); MyTat.Add("LS Shield");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_030_F"); MyTat.Add("Howitzer");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_028_F"); MyTat.Add("Bananas Gone Bad");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_027_F"); MyTat.Add("Epsilon");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_024_F"); MyTat.Add("Mount Chiliad");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_023_F"); MyTat.Add("Bigfoot");//

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_032_F"); MyTat.Add("Play Your Ace");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_029_F"); MyTat.Add("The Table");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_021_F"); MyTat.Add("Show Your Hand");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_017_F"); MyTat.Add("Roll the Dice");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_015_F"); MyTat.Add("The Jolly Joker");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_011_F"); MyTat.Add("Life's a Gamble");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_010_F"); MyTat.Add("Photo Finish");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_009_F"); MyTat.Add("Till Death Do Us Part");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_008_F"); MyTat.Add("Snake Eyes");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_007_F"); MyTat.Add("777");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_006_F"); MyTat.Add("Wheel of Suits");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_001_F"); MyTat.Add("Jackpot");//

                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_027_F"); MyTat.Add("Molon Labe");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_024_F"); MyTat.Add("Dragon Slayer");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_022_F"); MyTat.Add("Spartan and Horse");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_021_F"); MyTat.Add("Spartan and Lion");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_016_F"); MyTat.Add("Odin and Raven");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_015_F"); MyTat.Add("Samurai Combat");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_011_F"); MyTat.Add("Weathered Skull");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_010_F"); MyTat.Add("Spartan Shield");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_009_F"); MyTat.Add("Norse Rune");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_005_F"); MyTat.Add("Ghost Dragon");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_002_F"); MyTat.Add("Kabuto");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_025_F"); MyTat.Add("Claimed By The Beast");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_024_F"); MyTat.Add("Pirate Captain");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_022_F"); MyTat.Add("X Marks The Spot");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_018_F"); MyTat.Add("Finders Keepers");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_017_F"); MyTat.Add("Framed Tall Ship");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_016_F"); MyTat.Add("Skull Compass");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_013_F"); MyTat.Add("Torn Wings");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_009_F"); MyTat.Add("Tall Ship Conflict");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_006_F"); MyTat.Add("Never Surrender");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_003_F"); MyTat.Add("Give Nothing Back");

                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_007_F"); MyTat.Add("Eagle Eyes");
                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_005_F"); MyTat.Add("Parachute Belle");
                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_004_F"); MyTat.Add("Balloon Pioneer");
                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_002_F"); MyTat.Add("Winged Bombshell");
                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_001_F"); MyTat.Add("Pilot Skull");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_022_F"); MyTat.Add("Explosive Heart");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_019_F"); MyTat.Add("Pistol Wings");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_018_F"); MyTat.Add("Dual Wield Skull");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_014_F"); MyTat.Add("Backstabber");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_013_F"); MyTat.Add("Wolf Insignia");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_009_F"); MyTat.Add("Butterfly Knife");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_001_F"); MyTat.Add("Crossed Weapons");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_000_F"); MyTat.Add("Bullet Proof");

                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_011_F"); MyTat.Add("Talk Shit Get Hit");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_010_F"); MyTat.Add("Take the Wheel");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_009_F"); MyTat.Add("Serpents of Destruction");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_002_F"); MyTat.Add("Tuned to Death");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_001_F"); MyTat.Add("Power Plant");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_000_F"); MyTat.Add("Block Back");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_043_F"); MyTat.Add("Ride Forever");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_030_F"); MyTat.Add("Brothers For Life");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_021_F"); MyTat.Add("Flaming Reaper");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_017_F"); MyTat.Add("Clawed Beast");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_011_F"); MyTat.Add("R.I.P. My Brothers");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_008_F"); MyTat.Add("Freedom Wheels");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_006_F"); MyTat.Add("Chopper Freedom");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_048_F"); MyTat.Add("Racing Doll");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_046_F"); MyTat.Add("Full Throttle");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_041_F"); MyTat.Add("Brapp");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_040_F"); MyTat.Add("Monkey Chopper");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_037_F"); MyTat.Add("Big Grills");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_034_F"); MyTat.Add("Feather Road Kill");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_030_F"); MyTat.Add("Man's Ruin");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_029_F"); MyTat.Add("Majestic Finish");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_026_F"); MyTat.Add("Winged Wheel");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_024_F"); MyTat.Add("Road Kill");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_032_F"); MyTat.Add("Reign Over");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_031_F"); MyTat.Add("Dead Pretty");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_008_F"); MyTat.Add("Love the Game");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_000_F"); MyTat.Add("SA Assault");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_021_F"); MyTat.Add("Sad Angel");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_014_F"); MyTat.Add("Love is Blind");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_010_F"); MyTat.Add("Bad Angel");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_009_F"); MyTat.Add("Amazon");//

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_029_F"); MyTat.Add("Geometric Design");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_022_F"); MyTat.Add("Cloaked Angel");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_024_F"); MyTat.Add("Feather Mural");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_006_F"); MyTat.Add("Adorned Wolf");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_015"); MyTat.Add("Japanese Warrior");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_011"); MyTat.Add("Roaring Tiger");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_006"); MyTat.Add("Carp Shaded");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_005"); MyTat.Add("Carp Outline");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_046"); MyTat.Add("Triangles");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_041"); MyTat.Add("Tooth");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_032"); MyTat.Add("Paper Plane");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_031"); MyTat.Add("Skateboard");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_030"); MyTat.Add("Shark Fin");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_025"); MyTat.Add("Watch Your Step");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_024"); MyTat.Add("Pyamid");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_012"); MyTat.Add("Antlers");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_011"); MyTat.Add("Infinity");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_000"); MyTat.Add("Crossed Arrows");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_Back_001"); MyTat.Add("Gold Digger");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_Back_000"); MyTat.Add("Respect");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Should_000"); MyTat.Add("Sea Horses");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Back_002"); MyTat.Add("Shrimp");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Should_001"); MyTat.Add("Catfish");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Back_000"); MyTat.Add("Rock Solid");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Back_001"); MyTat.Add("Hibiscus Flower Duo");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_045"); MyTat.Add("Skulls and Rose");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_030"); MyTat.Add("Lucky Celtic Dogs");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_020"); MyTat.Add("Dragon");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_019"); MyTat.Add("The Wages of Sin");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_016"); MyTat.Add("Evil Clown");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_013"); MyTat.Add("Eagle and Serpent");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_011"); MyTat.Add("LS Script");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_009"); MyTat.Add("Skull on the Cross");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_019"); MyTat.Add("Clown Dual Wield Dollars");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_018"); MyTat.Add("Clown Dual Wield");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_017"); MyTat.Add("Clown and Gun");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_016"); MyTat.Add("Clown");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_014"); MyTat.Add("Trust No One");//Car Bomb Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_008"); MyTat.Add("Los Santos Customs");//Mod a Car Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_005"); MyTat.Add("Angel");//Win Every Game Mode Award
                    //Not In List
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_046"); MyTat.Add("Zip?");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_006"); MyTat.Add("Feather Birds");
                    sTatBase.Add("mpchristmas2018_overlays"); sTatName.Add("MP_Christmas2018_Tat_000_F"); MyTat.Add("???");
                }//BACK
                else if (iZone == 2)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_023_F"); MyTat.Add("Techno Glitch");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_022_F"); MyTat.Add("Paradise Sirens");//

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_035_F"); MyTat.Add("LS Panic");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_033_F"); MyTat.Add("LS City");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_026_F"); MyTat.Add("Dignity");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_025_F"); MyTat.Add("Davis");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_022_F"); MyTat.Add("Blood Money");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_003_F"); MyTat.Add("Royal Flush");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_000_F"); MyTat.Add("In the Pocket");//

                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_026_F"); MyTat.Add("Spartan Skull");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_020_F"); MyTat.Add("Medusa's Gaze");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_019_F"); MyTat.Add("Strike Force");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_003_F"); MyTat.Add("Native Warrior");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_000_F"); MyTat.Add("Thor - Goblin");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_021_F"); MyTat.Add("Dead Tales");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_019_F"); MyTat.Add("Lost At Sea");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_007_F"); MyTat.Add("No Honor");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_000_F"); MyTat.Add("Bless The Dead");

                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_000_F"); MyTat.Add("Turbulence");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_028_F"); MyTat.Add("Micro SMG Chain");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_020_F"); MyTat.Add("Crowned Weapons");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_017_F"); MyTat.Add("Dog Tags");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_012_F"); MyTat.Add("Dollar Daggers");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_060_F"); MyTat.Add("We Are The Mods!");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_059_F"); MyTat.Add("Faggio");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_058_F"); MyTat.Add("Reaper Vulture");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_050_F"); MyTat.Add("Unforgiven");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_041_F"); MyTat.Add("No Regrets");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_034_F"); MyTat.Add("Brotherhood of Bikes");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_032_F"); MyTat.Add("Western Eagle");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_029_F"); MyTat.Add("Bone Wrench");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_026_F"); MyTat.Add("American Dream");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_023_F"); MyTat.Add("Western MC");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_019_F"); MyTat.Add("Gruesome Talons");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_018_F"); MyTat.Add("Skeletal Chopper");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_013_F"); MyTat.Add("Demon Crossbones");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_005_F"); MyTat.Add("Made In America");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_001_F"); MyTat.Add("Both Barrels");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_000_F"); MyTat.Add("Demon Rider");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_044_F"); MyTat.Add("Ram Skull");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_033_F"); MyTat.Add("Sugar Skull Trucker");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_027_F"); MyTat.Add("Punk Road Hog");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_019_F"); MyTat.Add("Engine Heart");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_018_F"); MyTat.Add("Vintage Bully");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_011_F"); MyTat.Add("Wheels of Death");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_019_F"); MyTat.Add("Death Behind");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_012_F"); MyTat.Add("Royal Kiss");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_026_F"); MyTat.Add("Royal Takeover");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_013_F"); MyTat.Add("Love Gamble");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_002_F"); MyTat.Add("Holy Mary");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_001_F"); MyTat.Add("King Fight");//

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_027_F"); MyTat.Add("Cobra Dawn");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_025_F"); MyTat.Add("Reaper Sway");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_012_F"); MyTat.Add("Geometric Galaxy");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_002_F"); MyTat.Add("The Howler");

                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_015_F"); MyTat.Add("Smoking Sisters");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_014_F"); MyTat.Add("Ancient Queen");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_008_F"); MyTat.Add("Flying Eye");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_007_F"); MyTat.Add("Eye of the Griffin");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_019"); MyTat.Add("Royal Dagger Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_018"); MyTat.Add("Royal Dagger Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_017"); MyTat.Add("Loose Lips Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_016"); MyTat.Add("Loose Lips Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_009"); MyTat.Add("Time To Die");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_047"); MyTat.Add("Cassette");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_033"); MyTat.Add("Stag");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_013"); MyTat.Add("Boombox");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_002"); MyTat.Add("Chemistry");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_Chest_002"); MyTat.Add("Love Money");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_Chest_001"); MyTat.Add("Makin' Money");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_Chest_000"); MyTat.Add("High Roller");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Chest_001"); MyTat.Add("Anchor");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Chest_000"); MyTat.Add("Anchor");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Chest_002"); MyTat.Add("Los Santos Wreath");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_044"); MyTat.Add("Stone Cross");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_034"); MyTat.Add("Flaming Shamrock");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_025"); MyTat.Add("LS Bold");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_024"); MyTat.Add("Flaming Cross");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_010"); MyTat.Add("LS Flames");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_013"); MyTat.Add("Seven Deadly Sins");//Kill 1000 Players Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_012"); MyTat.Add("Embellished Scroll");//Kill 500 Players Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_011"); MyTat.Add("Blank Scroll");////Kill 100 Players Award?
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_003"); MyTat.Add("Blackjack");
                    //
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Female_Crew_Tat_000"); MyTat.Add("Crew Emblem");
                }//CHEST
                else if (iZone == 3)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_030_F"); MyTat.Add("Radio Tape");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_004_F"); MyTat.Add("Skeleton Breeze");//

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_037_F"); MyTat.Add("LadyBug");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_029_F"); MyTat.Add("Fatal Incursion");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_031_F"); MyTat.Add("Gambling Royalty");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_024_F"); MyTat.Add("Cash Mouth");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_016_F"); MyTat.Add("Rose and Aces");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_012_F"); MyTat.Add("Skull of Suits");//

                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_008_F"); MyTat.Add("Spartan Warrior");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_015_F"); MyTat.Add("Jolly Roger");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_010_F"); MyTat.Add("See You In Hell");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_002_F"); MyTat.Add("Dead Lies");

                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_006_F"); MyTat.Add("Bombs Away");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_029_F"); MyTat.Add("Win Some Lose Some");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_010_F"); MyTat.Add("Cash Money");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_052_F"); MyTat.Add("Biker Mount");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_039_F"); MyTat.Add("Gas Guzzler");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_031_F"); MyTat.Add("Gear Head");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_010_F"); MyTat.Add("Skull Of Taurus");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_003_F"); MyTat.Add("Web Rider");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_014_F"); MyTat.Add("Bat Cat of Spades");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_012_F"); MyTat.Add("Punk Biker");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_016_F"); MyTat.Add("Two Face");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_011_F"); MyTat.Add("Lady Liberty");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_004_F"); MyTat.Add("Gun Mic");//

                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_003_F"); MyTat.Add("Abstract Skull");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_028"); MyTat.Add("Executioner");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_013"); MyTat.Add("Lizard");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_035"); MyTat.Add("Sewn Heart");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_029"); MyTat.Add("Sad");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_006"); MyTat.Add("Feather Birds");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_Stom_002"); MyTat.Add("Money Bag");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_Stom_001"); MyTat.Add("Santo Capra Logo");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_Stom_000"); MyTat.Add("Diamond Back");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Stom_000"); MyTat.Add("Swallow");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Stom_002"); MyTat.Add("Dolphin");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Stom_001"); MyTat.Add("Hibiscus Flower");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_RSide_000"); MyTat.Add("Love Dagger");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_036"); MyTat.Add("Way of the Gun");//500 Pistol kills Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_029"); MyTat.Add("Trinity Knot");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_012"); MyTat.Add("Los Santos Bills");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_004"); MyTat.Add("Faith");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_004"); MyTat.Add("Hustler");//Make 50000 from betting Award
                }//STOMACH
                else if (iZone == 4)
                {
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_022_F"); MyTat.Add("Thong's Sword");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_021_F"); MyTat.Add("Wanted");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_020_F"); MyTat.Add("UFO");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_019_F"); MyTat.Add("Teddy Bear");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_018_F"); MyTat.Add("Stitches");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_017_F"); MyTat.Add("Space Monkey");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_016_F"); MyTat.Add("Sleepy");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_015_F"); MyTat.Add("On/Off");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_014_F"); MyTat.Add("LS Wings");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_013_F"); MyTat.Add("LS Star");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_012_F"); MyTat.Add("Razor Pop");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_011_F"); MyTat.Add("Lipstick Kiss");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_010_F"); MyTat.Add("Green Leaf");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_009_F"); MyTat.Add("Knifed");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_008_F"); MyTat.Add("Ice Cream");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_007_F"); MyTat.Add("Two Horns");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_006_F"); MyTat.Add("Crowned");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_005_F"); MyTat.Add("Spades");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_004_F"); MyTat.Add("Bandage");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_003_F"); MyTat.Add("Assault Rifle");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_002_F"); MyTat.Add("Animal");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_001_F"); MyTat.Add("Ace of Spades");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_000_F"); MyTat.Add("Five Stars");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_012_F"); MyTat.Add("Thief");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_011_F"); MyTat.Add("Sinner");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_003_F"); MyTat.Add("Lock and Load");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_051_F"); MyTat.Add("Western Stylized");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_038_F"); MyTat.Add("FTW");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_009_F"); MyTat.Add("Morbid Arachnid");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_042_F"); MyTat.Add("Flaming Quad");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_017_F"); MyTat.Add("Bat Wheel");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_Tat_006_F"); MyTat.Add("Toxic Spider");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_Tat_004_F"); MyTat.Add("Scorpion");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_Tat_000_F"); MyTat.Add("Stunt Skull");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_029"); MyTat.Add("Beautiful Death");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_025"); MyTat.Add("Snake Head Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_024"); MyTat.Add("Snake Head Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_007"); MyTat.Add("Los Muertos");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_021"); MyTat.Add("Geo Fox");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_005"); MyTat.Add("Beautiful Eye");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_Neck_001"); MyTat.Add("Money Rose");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_Neck_000"); MyTat.Add("Val-de-Grace Logo");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Neck_000"); MyTat.Add("Tribal Butterfly");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_Neck_000"); MyTat.Add("Little Fish");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_000"); MyTat.Add("Skull");//500 Headshots Award
                    //Not On the TatlIst     ...                            
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_044_F"); MyTat.Add("Clubs");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_043_F"); MyTat.Add("Diamonds");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_042_F"); MyTat.Add("Hearts");
                }//HEAD
                else if (iZone == 5)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_009_F"); MyTat.Add("Scratch Panther");

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_041_F"); MyTat.Add("Mighty Thog");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_040_F"); MyTat.Add("Tiger Heart");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_026_F"); MyTat.Add("Banknote Rose");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_019_F"); MyTat.Add("Can't Win Them All");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_014_F"); MyTat.Add("Vice");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_005_F"); MyTat.Add("Get Lucky");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_002_F"); MyTat.Add("Suits");//

                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_029_F"); MyTat.Add("Cerberus");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_025_F"); MyTat.Add("Winged Serpent");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_013_F"); MyTat.Add("Katana");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_007_F"); MyTat.Add("Spartan Combat");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_004_F"); MyTat.Add("Tiger and Mask");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_001_F"); MyTat.Add("Viking Warrior");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_014_F"); MyTat.Add("Mermaid's Curse");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_008_F"); MyTat.Add("Horrors Of The Deep");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_004_F"); MyTat.Add("Honor");

                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_003_F"); MyTat.Add("Toxic Trails");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_027_F"); MyTat.Add("Serpent Revolver");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_025_F"); MyTat.Add("Praying Skull");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_016_F"); MyTat.Add("Blood Money");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_015_F"); MyTat.Add("Spiked Skull");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_008_F"); MyTat.Add("Bandolier");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_004_F"); MyTat.Add("Sidearm");

                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_008_F"); MyTat.Add("Scarlett");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_004_F"); MyTat.Add("Piston Sleeve");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_055_F"); MyTat.Add("Poison Scorpion");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_053_F"); MyTat.Add("Muffler Helmet");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_045_F"); MyTat.Add("Ride Hard Die Fast");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_035_F"); MyTat.Add("Chain Fist");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_025_F"); MyTat.Add("Good Luck");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_024_F"); MyTat.Add("Live to Ride");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_020_F"); MyTat.Add("Cranial Rose");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_016_F"); MyTat.Add("Macabre Tree");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_012_F"); MyTat.Add("Urban Stunter");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_043_F"); MyTat.Add("Engine Arm");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_039_F"); MyTat.Add("Kaboom");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_035_F"); MyTat.Add("Stuntman's End");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_023_F"); MyTat.Add("Tanked");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_022_F"); MyTat.Add("Piston Head");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_008_F"); MyTat.Add("Moonlight Ride");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_002_F"); MyTat.Add("Big Cat");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_001_F"); MyTat.Add("8 Eyed Skull");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_022_F"); MyTat.Add("My Crazy Life");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_018_F"); MyTat.Add("Skeleton Party");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_006_F"); MyTat.Add("Love Hustle");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_033_F"); MyTat.Add("City Sorrow");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_027_F"); MyTat.Add("Los Santos Life");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_005_F"); MyTat.Add("No Evil");//

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_028_F"); MyTat.Add("Python Skull");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_018_F"); MyTat.Add("Divine Goddess");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_016_F"); MyTat.Add("Egyptian Mural");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_005_F"); MyTat.Add("Fatal Dagger");

                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_021_F"); MyTat.Add("Gabriel");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_020_F"); MyTat.Add("Archangel and Mary");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_009_F"); MyTat.Add("Floral Symmetry");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_021"); MyTat.Add("Time's Up Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_020"); MyTat.Add("Time's Up Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_012"); MyTat.Add("8 Ball Skull");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_010"); MyTat.Add("Electric Snake");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_000"); MyTat.Add("Skull Rider");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_048"); MyTat.Add("Peace");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_043"); MyTat.Add("Triangle White");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_039"); MyTat.Add("Sleeve");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_037"); MyTat.Add("Sunrise");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_034"); MyTat.Add("Stop");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_028"); MyTat.Add("Thorny Rose");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_027"); MyTat.Add("Padlock");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_026"); MyTat.Add("Pizza");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_016"); MyTat.Add("Lightning Bolt");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_015"); MyTat.Add("Mustache");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_007"); MyTat.Add("Bricks");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_003"); MyTat.Add("Diamond Sparkle");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_LArm_000"); MyTat.Add("Greed is Good");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_LArm_001"); MyTat.Add("Parrot");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_LArm_000"); MyTat.Add("Tribal Flower");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_041"); MyTat.Add("Dope Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_031"); MyTat.Add("Lady M");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_015"); MyTat.Add("Zodiac Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_006"); MyTat.Add("Oriental Mural");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_005"); MyTat.Add("Serpents");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_015"); MyTat.Add("Racing Brunette");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_007"); MyTat.Add("Racing Blonde");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_001"); MyTat.Add("Burning Heart");//50 Death Match Award
                    //not on list
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_031_F"); MyTat.Add("Geometric Design");
                }//LEFT ARM
                else if (iZone == 6)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_032_F"); MyTat.Add("K.U.L.T.99.1 FM");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_031_F"); MyTat.Add("Octopus Shades");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_026_F"); MyTat.Add("Shark Water");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_012_F"); MyTat.Add("Still Slipping");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_011_F"); MyTat.Add("Soulwax");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_008_F"); MyTat.Add("Smiley Glitch");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_007_F"); MyTat.Add("Skeleton DJ");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_006_F"); MyTat.Add("Music Locker");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_005_F"); MyTat.Add("LSUR");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_003_F"); MyTat.Add("Lighthouse");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_002_F"); MyTat.Add("Jellyfish Shades");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_001_F"); MyTat.Add("Tropical Dude");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_000_F"); MyTat.Add("Headphone Splat");

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_034_F"); MyTat.Add("LS Monogram");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_028_F"); MyTat.Add("Skull and Aces");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_025_F"); MyTat.Add("Queen of Roses");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_018_F"); MyTat.Add("The Gambler's Life");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_004_F"); MyTat.Add("Lady Luck");//

                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_028_F"); MyTat.Add("Spartan Mural");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_023_F"); MyTat.Add("Samurai Tallship");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_018_F"); MyTat.Add("Muscle Tear");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_017_F"); MyTat.Add("Feather Sleeve");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_014_F"); MyTat.Add("Celtic Band");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_012_F"); MyTat.Add("Tiger Headdress");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_006_F"); MyTat.Add("Medusa");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_023_F"); MyTat.Add("Stylized Kraken");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_005_F"); MyTat.Add("Mutiny");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_001_F"); MyTat.Add("Crackshot");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_024_F"); MyTat.Add("Combat Reaper");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_021_F"); MyTat.Add("Have a Nice Day");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_002_F"); MyTat.Add("Grenade");

                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_007_F"); MyTat.Add("Drive Forever");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_006_F"); MyTat.Add("Engulfed Block");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_005_F"); MyTat.Add("Dialed In");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_003_F"); MyTat.Add("Mechanical Sleeve");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_054_F"); MyTat.Add("Mum");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_049_F"); MyTat.Add("These Colors Don't Run");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_047_F"); MyTat.Add("Snake Bike");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_046_F"); MyTat.Add("Skull Chain");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_042_F"); MyTat.Add("Grim Rider");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_033_F"); MyTat.Add("Eagle Emblem");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_014_F"); MyTat.Add("Lady Mortality");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_007_F"); MyTat.Add("Swooping Eagle");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_049_F"); MyTat.Add("Seductive Mechanic");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_038_F"); MyTat.Add("One Down Five Up");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_036_F"); MyTat.Add("Biker Stallion");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_016_F"); MyTat.Add("Coffin Racer");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_010_F"); MyTat.Add("Grave Vulture");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_009_F"); MyTat.Add("Arachnid of Death");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_003_F"); MyTat.Add("Poison Wrench");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_035_F"); MyTat.Add("Black Tears");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_028_F"); MyTat.Add("Loving Los Muertos");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_003_F"); MyTat.Add("Lady Vamp");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_015_F"); MyTat.Add("Seductress");//

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_LUXE_TAT_026_F"); MyTat.Add("Floral Print");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_LUXE_TAT_017_F"); MyTat.Add("Heavenly Deity");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_LUXE_TAT_010_F"); MyTat.Add("Intrometric");

                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_019_F"); MyTat.Add("Geisha Bloom");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_013_F"); MyTat.Add("Mermaid Harpist");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_004_F"); MyTat.Add("Floral Raven");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_027"); MyTat.Add("Fuck Luck Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_026"); MyTat.Add("Fuck Luck Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_023"); MyTat.Add("You're Next Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_022"); MyTat.Add("You're Next Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_008"); MyTat.Add("Death Before Dishonor");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_004"); MyTat.Add("Snake Shaded");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_003"); MyTat.Add("Snake Outline");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_045"); MyTat.Add("Mesh Band");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_044"); MyTat.Add("Triangle Black");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_036"); MyTat.Add("Shapes");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_023"); MyTat.Add("Smiley");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_022"); MyTat.Add("Pencil");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_020"); MyTat.Add("Geo Pattern");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_018"); MyTat.Add("Origami");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_017"); MyTat.Add("Eye Triangle");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_014"); MyTat.Add("Spray Can");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_010"); MyTat.Add("Horseshoe");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_008"); MyTat.Add("Cube");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_004"); MyTat.Add("Bone");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_001"); MyTat.Add("Single Arrow");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_RArm_000"); MyTat.Add("Dollar Sign");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_RArm_001"); MyTat.Add("Tribal Fish");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_047"); MyTat.Add("Lion");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_038"); MyTat.Add("Dagger");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_028"); MyTat.Add("Mermaid");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_027"); MyTat.Add("Virgin Mary");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_018"); MyTat.Add("Serpent Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_014"); MyTat.Add("Flower Mural");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_003"); MyTat.Add("Dragons and Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_001"); MyTat.Add("Dragons");
                    //sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_000"); MyTat.Add("Brotherhood");-empty load?

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_010"); MyTat.Add("Ride or Die");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_002"); MyTat.Add("Grim Reaper Smoking Gun");//Clear 5 Gang Atacks in a Day Award
                    //Not In List
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Female_Crew_Tat_001"); MyTat.Add("Crew Tattoo");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_LUXE_TAT_030_F"); MyTat.Add("Geometric Design");
                }//RIGHT ARM
                else if (iZone == 7)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_029_F"); MyTat.Add("Soundwaves");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_028_F"); MyTat.Add("Skull Waters");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_025_F"); MyTat.Add("Glow Princess");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_024_F"); MyTat.Add("Pineapple Skull");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_010_F"); MyTat.Add("Tropical Serpent");

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_032_F"); MyTat.Add("Love Fist");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_027_F"); MyTat.Add("8-Ball Rose");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_013_F"); MyTat.Add("One-armed Bandit");//

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_023_F"); MyTat.Add("Rose Revolver");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_011_F"); MyTat.Add("Death Skull");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_007_F"); MyTat.Add("Stylized Tiger");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_005_F"); MyTat.Add("Patriot Skull");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_057_F"); MyTat.Add("Laughing Skull");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_056_F"); MyTat.Add("Bone Cruiser");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_044_F"); MyTat.Add("Ride Free");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_037_F"); MyTat.Add("Scorched Soul");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_036_F"); MyTat.Add("Engulfed Skull");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_027_F"); MyTat.Add("Bad Luck");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_015_F"); MyTat.Add("Ride or Die");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_002_F"); MyTat.Add("Rose Tribute");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_031_F"); MyTat.Add("Stunt Jesus");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_028_F"); MyTat.Add("Quad Goblin");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_021_F"); MyTat.Add("Golden Cobra");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_013_F"); MyTat.Add("Dirt Track Hero");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_007_F"); MyTat.Add("Dagger Devil");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_029_F"); MyTat.Add("Death Us Do Part");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_020_F"); MyTat.Add("Presidents");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_007_F"); MyTat.Add("LS Serpent");//

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_011_F"); MyTat.Add("Cross of Roses");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_000_F"); MyTat.Add("Serpent of Death");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_002"); MyTat.Add("Spider Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_001"); MyTat.Add("Spider Outline");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_040"); MyTat.Add("Black Anchor");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_019"); MyTat.Add("Charm");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_009"); MyTat.Add("Squares");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_LLeg_000"); MyTat.Add("Single");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_032"); MyTat.Add("Faith");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_037"); MyTat.Add("Grim Reaper");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_035"); MyTat.Add("Dragon");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_033"); MyTat.Add("Chinese Dragon");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_026"); MyTat.Add("Smoking Dagger");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_023"); MyTat.Add("Hottie");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_021"); MyTat.Add("Serpent Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_008"); MyTat.Add("Dragon Mural");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_002"); MyTat.Add("Melting Skull");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_009"); MyTat.Add("Dragon and Dagger");
                }//LEFT LEG
                else
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_027_F"); MyTat.Add("Skullphones");

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_031_F"); MyTat.Add("Kifflom");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_020_F"); MyTat.Add("Cash is King");//

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_020_F"); MyTat.Add("Homeward Bound");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_030_F"); MyTat.Add("Pistol Ace");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_026_F"); MyTat.Add("Restless Skull");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_006_F"); MyTat.Add("Combat Skull");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_048_F"); MyTat.Add("STFU");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_040_F"); MyTat.Add("American Made");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_028_F"); MyTat.Add("Dusk Rider");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_022_F"); MyTat.Add("Western Insignia");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_004_F"); MyTat.Add("Dragon's Fury");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_047_F"); MyTat.Add("Brake Knife");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_045_F"); MyTat.Add("Severed Hand");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_032_F"); MyTat.Add("Wheelie Mouse");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_025_F"); MyTat.Add("Speed Freak");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_020_F"); MyTat.Add("Piston Angel");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_015_F"); MyTat.Add("Praying Gloves");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_005_F"); MyTat.Add("Demon Spark Plug");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_030_F"); MyTat.Add("San Andreas Prayer");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_023_F"); MyTat.Add("Dance of Hearts");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_017_F"); MyTat.Add("Ink Me");//

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_LUXE_TAT_023_F"); MyTat.Add("Starmetric");

                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_001_F"); MyTat.Add("Elaborate Los Muertos");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_F_Tat_014"); MyTat.Add("Floral Dagger");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_042"); MyTat.Add("Sparkplug");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_F_Tat_038"); MyTat.Add("Grub");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_F_RLeg_000"); MyTat.Add("Diamond Crown");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_F_RLeg_000"); MyTat.Add("School of Fish");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_043"); MyTat.Add("Indian Ram");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_042"); MyTat.Add("Flaming Scorpion");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_040"); MyTat.Add("Flaming Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_039"); MyTat.Add("Broken Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_022"); MyTat.Add("Fiery Dragon");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_017"); MyTat.Add("Tribal");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_F_007"); MyTat.Add("The Warrior");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_F_006"); MyTat.Add("Skull and Sword");//Collect 25 Bounties Award
                }//RIGHT LEG
            }// FreeFemale
            else if (iPed == 5)
            {
                if (iZone == 1)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_021_M"); MyTat.Add("Skull Surfer");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_020_M"); MyTat.Add("Speaker Tower");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_019_M"); MyTat.Add("Record Shot");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_018_M"); MyTat.Add("Record Head");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_017_M"); MyTat.Add("Tropical Sorcerer");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_016_M"); MyTat.Add("Rose Panther");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_015_M"); MyTat.Add("Paradise Ukulele");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_014_M"); MyTat.Add("Paradise Nap");//
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_013_M"); MyTat.Add("Wild Dancers");//

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_039_M"); MyTat.Add("Space Rangers");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_038_M"); MyTat.Add("Robot Bubblegum");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_036_M"); MyTat.Add("LS Shield");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_030_M"); MyTat.Add("Howitzer");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_028_M"); MyTat.Add("Bananas Gone Bad");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_027_M"); MyTat.Add("Epsilon");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_024_M"); MyTat.Add("Mount Chiliad");//
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_023_M"); MyTat.Add("Bigfoot");//

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_032_M"); MyTat.Add("Play Your Ace");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_029_M"); MyTat.Add("The Table");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_021_M"); MyTat.Add("Show Your Hand");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_017_M"); MyTat.Add("Roll the Dice");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_015_M"); MyTat.Add("The Jolly Joker");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_011_M"); MyTat.Add("Life's a Gamble");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_010_M"); MyTat.Add("Photo Finish");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_009_M"); MyTat.Add("Till Death Do Us Part");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_008_M"); MyTat.Add("Snake Eyes");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_007_M"); MyTat.Add("777");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_006_M"); MyTat.Add("Wheel of Suits");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_001_M"); MyTat.Add("Jackpot");//

                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_027_M"); MyTat.Add("Molon Labe");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_024_M"); MyTat.Add("Dragon Slayer");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_022_M"); MyTat.Add("Spartan and Horse");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_021_M"); MyTat.Add("Spartan and Lion");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_016_M"); MyTat.Add("Odin and Raven");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_015_M"); MyTat.Add("Samurai Combat");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_011_M"); MyTat.Add("Weathered Skull");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_010_M"); MyTat.Add("Spartan Shield");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_009_M"); MyTat.Add("Norse Rune");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_005_M"); MyTat.Add("Ghost Dragon");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_002_M"); MyTat.Add("Kabuto");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_025_M"); MyTat.Add("Claimed By The Beast");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_024_M"); MyTat.Add("Pirate Captain");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_022_M"); MyTat.Add("X Marks The Spot");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_018_M"); MyTat.Add("Finders Keepers");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_017_M"); MyTat.Add("Framed Tall Ship");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_016_M"); MyTat.Add("Skull Compass");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_013_M"); MyTat.Add("Torn Wings");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_009_M"); MyTat.Add("Tall Ship Conflict");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_006_M"); MyTat.Add("Never Surrender");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_003_M"); MyTat.Add("Give Nothing Back");

                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_007_M"); MyTat.Add("Eagle Eyes");
                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_005_M"); MyTat.Add("Parachute Belle");
                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_004_M"); MyTat.Add("Balloon Pioneer");
                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_002_M"); MyTat.Add("Winged Bombshell");
                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_001_M"); MyTat.Add("Pilot Skull");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_022_M"); MyTat.Add("Explosive Heart");//
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_019_M"); MyTat.Add("Pistol Wings");//
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_018_M"); MyTat.Add("Dual Wield Skull");//
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_014_M"); MyTat.Add("Backstabber");//
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_013_M"); MyTat.Add("Wolf Insignia");//
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_009_M"); MyTat.Add("Butterfly Knife");//
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_001_M"); MyTat.Add("Crossed Weapons");//
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_000_M"); MyTat.Add("Bullet Proof");//

                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_011_M"); MyTat.Add("Talk Shit Get Hit");//
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_010_M"); MyTat.Add("Take the Wheel");//
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_009_M"); MyTat.Add("Serpents of Destruction");//
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_002_M"); MyTat.Add("Tuned to Death");//
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_001_M"); MyTat.Add("Power Plant");//
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_000_M"); MyTat.Add("Block Back");//

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_043_M"); MyTat.Add("Ride Forever");//
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_030_M"); MyTat.Add("Brothers For Life");//
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_021_M"); MyTat.Add("Flaming Reaper");//
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_017_M"); MyTat.Add("Clawed Beast");//
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_011_M"); MyTat.Add("R.I.P. My Brothers");//
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_008_M"); MyTat.Add("Freedom Wheels");//
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_006_M"); MyTat.Add("Chopper Freedom");//

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_048_M"); MyTat.Add("Racing Doll");//
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_046_M"); MyTat.Add("Full Throttle");//
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_041_M"); MyTat.Add("Brapp");//
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_040_M"); MyTat.Add("Monkey Chopper");//
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_037_M"); MyTat.Add("Big Grills");//
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_034_M"); MyTat.Add("Feather Road Kill");//
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_030_M"); MyTat.Add("Man's Ruin");//
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_029_M"); MyTat.Add("Majestic Finish");//
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_026_M"); MyTat.Add("Winged Wheel");//
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_024_M"); MyTat.Add("Road Kill");//

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_032_M"); MyTat.Add("Reign Over");//
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_031_M"); MyTat.Add("Dead Pretty");//
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_008_M"); MyTat.Add("Love the Game");//
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_000_M"); MyTat.Add("SA Assault");//

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_021_M"); MyTat.Add("Sad Angel");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_014_M"); MyTat.Add("Love is Blind");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_010_M"); MyTat.Add("Bad Angel");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_009_M"); MyTat.Add("Amazon");//

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_029_M"); MyTat.Add("Geometric Design");//   
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_022_M"); MyTat.Add("Cloaked Angel");//  
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_024_M"); MyTat.Add("Feather Mural");//    
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_006_M"); MyTat.Add("Adorned Wolf");//   

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_015"); MyTat.Add("Japanese Warrior");//          
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_011"); MyTat.Add("Roaring Tiger");//      
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_006"); MyTat.Add("Carp Shaded");//   
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_005"); MyTat.Add("Carp Outline");//   

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_046"); MyTat.Add("Triangles");//         
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_041"); MyTat.Add("Tooth");//         
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_032"); MyTat.Add("Paper Plane");//         
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_031"); MyTat.Add("Skateboard");//           
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_030"); MyTat.Add("Shark Fin");//        
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_025"); MyTat.Add("Watch Your Step");//          
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_024"); MyTat.Add("Pyamid");//   
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_012"); MyTat.Add("Antlers");//  
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_011"); MyTat.Add("Infinity");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_000"); MyTat.Add("Crossed Arrows");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_Back_000"); MyTat.Add("Makin' Paper");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Back_000"); MyTat.Add("Ship Arms");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_045"); MyTat.Add("Skulls and Rose");//
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_030"); MyTat.Add("Lucky Celtic Dogs");//
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_020"); MyTat.Add("Dragon");//
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_019"); MyTat.Add("The Wages of Sin");//Survival Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_016"); MyTat.Add("Evil Clown");//
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_013"); MyTat.Add("Eagle and Serpent");//
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_011"); MyTat.Add("LS Script");//
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_009"); MyTat.Add("Skull on the Cross");//

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_019"); MyTat.Add("Clown Dual Wield Dollars");//
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_018"); MyTat.Add("Clown Dual Wield");//
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_017"); MyTat.Add("Clown and Gun");//
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_016"); MyTat.Add("Clown");//
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_014"); MyTat.Add("Trust No One");//Car Bomb Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_008"); MyTat.Add("Los Santos Customs");//Mod a Car Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_005"); MyTat.Add("Angel");//Win Every Game Mode Award
                    //Unknowen
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_046"); MyTat.Add("Zip?");//Zip???
                    sTatBase.Add("mpchristmas2018_overlays"); sTatName.Add("MP_Christmas2018_Tat_000_M"); MyTat.Add("Unknowen");//
                }//BACK
                else if (iZone == 2)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_023_M"); MyTat.Add("Techno Glitch");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_022_M"); MyTat.Add("Paradise Sirens");

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_035_M"); MyTat.Add("LS Panic");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_033_M"); MyTat.Add("LS City");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_026_M"); MyTat.Add("Dignity");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_025_M"); MyTat.Add("Davis");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_022_M"); MyTat.Add("Blood Money");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_003_M"); MyTat.Add("Royal Flush");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_000_M"); MyTat.Add("In the Pocket");

                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_026_M"); MyTat.Add("Spartan Skull");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_020_M"); MyTat.Add("Medusa's Gaze");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_019_M"); MyTat.Add("Strike Force");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_003_M"); MyTat.Add("Native Warrior");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_000_M"); MyTat.Add("Thor - Goblin");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_021_M"); MyTat.Add("Dead Tales");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_019_M"); MyTat.Add("Lost At Sea");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_007_M"); MyTat.Add("No Honor");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_000_M"); MyTat.Add("Bless The Dead");

                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_000_M"); MyTat.Add("Turbulence");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_028_M"); MyTat.Add("Micro SMG Chain");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_020_M"); MyTat.Add("Crowned Weapons");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_017_M"); MyTat.Add("Dog Tags");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_012_M"); MyTat.Add("Dollar Daggers");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_060_M"); MyTat.Add("We Are The Mods!");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_059_M"); MyTat.Add("Faggio");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_058_M"); MyTat.Add("Reaper Vulture");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_050_M"); MyTat.Add("Unforgiven");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_041_M"); MyTat.Add("No Regrets");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_034_M"); MyTat.Add("Brotherhood of Bikes");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_032_M"); MyTat.Add("Western Eagle");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_029_M"); MyTat.Add("Bone Wrench");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_026_M"); MyTat.Add("American Dream");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_023_M"); MyTat.Add("Western MC");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_019_M"); MyTat.Add("Gruesome Talons");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_018_M"); MyTat.Add("Skeletal Chopper");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_013_M"); MyTat.Add("Demon Crossbones");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_005_M"); MyTat.Add("Made In America");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_001_M"); MyTat.Add("Both Barrels");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_000_M"); MyTat.Add("Demon Rider");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_044_M"); MyTat.Add("Ram Skull");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_033_M"); MyTat.Add("Sugar Skull Trucker");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_027_M"); MyTat.Add("Punk Road Hog");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_019_M"); MyTat.Add("Engine Heart");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_018_M"); MyTat.Add("Vintage Bully");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_011_M"); MyTat.Add("Wheels of Death");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_019_M"); MyTat.Add("Death Behind");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_012_M"); MyTat.Add("Royal Kiss");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_026_M"); MyTat.Add("Royal Takeover");
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_013_M"); MyTat.Add("Love Gamble");
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_002_M"); MyTat.Add("Holy Mary");
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_001_M"); MyTat.Add("King Fight");

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_027_M"); MyTat.Add("Cobra Dawn");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_025_M"); MyTat.Add("Reaper Sway");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_012_M"); MyTat.Add("Geometric Galaxy");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_002_M"); MyTat.Add("The Howler");

                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_015_M"); MyTat.Add("Smoking Sisters");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_014_M"); MyTat.Add("Ancient Queen");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_008_M"); MyTat.Add("Flying Eye");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_007_M"); MyTat.Add("Eye of the Griffin");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_019"); MyTat.Add("Royal Dagger Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_018"); MyTat.Add("Royal Dagger Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_017"); MyTat.Add("Loose Lips Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_016"); MyTat.Add("Loose Lips Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_009"); MyTat.Add("Time To Die");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_047"); MyTat.Add("Cassette");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_033"); MyTat.Add("Stag");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_013"); MyTat.Add("Boombox");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_002"); MyTat.Add("Chemistry");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_Chest_001"); MyTat.Add("$$$");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_Chest_000"); MyTat.Add("Rich");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Chest_001"); MyTat.Add("Tribal Shark");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Chest_000"); MyTat.Add("Tribal Hammerhead");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_044"); MyTat.Add("Stone Cross");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_034"); MyTat.Add("Flaming Shamrock");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_025"); MyTat.Add("LS Bold");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_024"); MyTat.Add("Flaming Cross");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_010"); MyTat.Add("LS Flames");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_013"); MyTat.Add("Seven Deadly Sins");//Kill 1000 Players Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_012"); MyTat.Add("Embellished Scroll");//Kill 500 Players Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_011"); MyTat.Add("Blank Scroll");////Kill 100 Players Award?
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_003"); MyTat.Add("Blackjack");

                    //
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Male_Crew_Tat_000"); MyTat.Add("Crew Emblem");
                }//CHEST
                else if (iZone == 3)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_030_M"); MyTat.Add("Radio Tape");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_004_M"); MyTat.Add("Skeleton Breeze");

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_037_M"); MyTat.Add("LadyBug");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_029_M"); MyTat.Add("Fatal Incursion");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_031_M"); MyTat.Add("Gambling Royalty");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_024_M"); MyTat.Add("Cash Mouth");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_016_M"); MyTat.Add("Rose and Aces");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("mp_vinewood_tat_012_M"); MyTat.Add("Skull of Suits");

                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_008_M"); MyTat.Add("Spartan Warrior");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_015_M"); MyTat.Add("Jolly Roger");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_010_M"); MyTat.Add("See You In Hell");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_002_M"); MyTat.Add("Dead Lies");

                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_006_M"); MyTat.Add("Bombs Away");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_029_M"); MyTat.Add("Win Some Lose Some");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_010_M"); MyTat.Add("Cash Money");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_052_M"); MyTat.Add("Biker Mount");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_039_M"); MyTat.Add("Gas Guzzler");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_031_M"); MyTat.Add("Gear Head");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_010_M"); MyTat.Add("Skull Of Taurus");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_003_M"); MyTat.Add("Web Rider");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_014_M"); MyTat.Add("Bat Cat of Spades");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_012_M"); MyTat.Add("Punk Biker");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_016_M"); MyTat.Add("Two Face");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_011_M"); MyTat.Add("Lady Liberty");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_004_M"); MyTat.Add("Gun Mic");

                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_003_M"); MyTat.Add("Abstract Skull");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_028"); MyTat.Add("Executioner");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_013"); MyTat.Add("Lizard");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_035"); MyTat.Add("Sewn Heart");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_029"); MyTat.Add("Sad");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_006"); MyTat.Add("Feather Birds");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_Stomach_000"); MyTat.Add("Refined Hustler");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Stom_001"); MyTat.Add("Wheel");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Stom_000"); MyTat.Add("Swordfish");


                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_036"); MyTat.Add("Way of the Gun");//500 Pistol kills Award
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_029"); MyTat.Add("Trinity Knot");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_012"); MyTat.Add("Los Santos Bills");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_004"); MyTat.Add("Faith");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_004"); MyTat.Add("Hustler");//Make 50000 from betting Award
                }//STOMACH
                else if (iZone == 4)
                {
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_022_M"); MyTat.Add("Thong's Sword");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_021_M"); MyTat.Add("Wanted");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_020_M"); MyTat.Add("UFO");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_019_M"); MyTat.Add("Teddy Bear");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_018_M"); MyTat.Add("Stitches");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_017_M"); MyTat.Add("Space Monkey");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_016_M"); MyTat.Add("Sleepy");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_015_M"); MyTat.Add("On/Off");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_014_M"); MyTat.Add("LS Wings");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_013_M"); MyTat.Add("LS Star");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_012_M"); MyTat.Add("Razor Pop");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_011_M"); MyTat.Add("Lipstick Kiss");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_010_M"); MyTat.Add("Green Leaf");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_009_M"); MyTat.Add("Knifed");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_008_M"); MyTat.Add("Ice Cream");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_007_M"); MyTat.Add("Two Horns");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_006_M"); MyTat.Add("Crowned");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_005_M"); MyTat.Add("Spades");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_004_M"); MyTat.Add("Bandage");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_003_M"); MyTat.Add("Assault Rifle");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_002_M"); MyTat.Add("Animal");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_001_M"); MyTat.Add("Ace of Spades");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_000_M"); MyTat.Add("Five Stars");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_012_M"); MyTat.Add("Thief");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_011_M"); MyTat.Add("Sinner");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_003_M"); MyTat.Add("Lock and Load");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_051_M"); MyTat.Add("Western Stylized");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_038_M"); MyTat.Add("FTW");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_009_M"); MyTat.Add("Morbid Arachnid");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_042_M"); MyTat.Add("Flaming Quad");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_017_M"); MyTat.Add("Bat Wheel");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_Tat_006_M"); MyTat.Add("Toxic Spider");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_Tat_004_M"); MyTat.Add("Scorpion");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_Tat_000_M"); MyTat.Add("Stunt Skull");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_029"); MyTat.Add("Beautiful Death");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_025"); MyTat.Add("Snake Head Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_024"); MyTat.Add("Snake Head Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_007"); MyTat.Add("Los Muertos");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_021"); MyTat.Add("Geo Fox");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_005"); MyTat.Add("Beautiful Eye");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_Neck_003"); MyTat.Add("$100");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_Neck_002"); MyTat.Add("Script Dollar Sign");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_Neck_001"); MyTat.Add("Bold Dollar Sign");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_Neck_000"); MyTat.Add("Cash is King");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Head_002"); MyTat.Add("Shark");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Neck_001"); MyTat.Add("Surfs Up");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Neck_000"); MyTat.Add("Little Fish");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Head_001"); MyTat.Add("Surf LS");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Head_000"); MyTat.Add("Pirate Skull");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_000"); MyTat.Add("Skull");
                    //Not On the TatlIst     ...                            
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_044_M"); MyTat.Add("Clubs");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_043_M"); MyTat.Add("Diamonds");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_042_M"); MyTat.Add("Hearts");
                }//HEAD
                else if (iZone == 5)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_009_M"); MyTat.Add("Scratch Panther");

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_041_M"); MyTat.Add("Mighty Thog");
                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_040_M"); MyTat.Add("Tiger Heart");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_026_M"); MyTat.Add("Banknote Rose");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_019_M"); MyTat.Add("Can't Win Them All");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_014_M"); MyTat.Add("Vice");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_005_M"); MyTat.Add("Get Lucky");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_002_M"); MyTat.Add("Suits");

                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_029_M"); MyTat.Add("Cerberus");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_025_M"); MyTat.Add("Winged Serpent");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_013_M"); MyTat.Add("Katana");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_007_M"); MyTat.Add("Spartan Combat");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_004_M"); MyTat.Add("Tiger and Mask");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_001_M"); MyTat.Add("Viking Warrior");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_014_M"); MyTat.Add("Mermaid's Curse");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_008_M"); MyTat.Add("Horrors Of The Deep");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_004_M"); MyTat.Add("Honor");

                    sTatBase.Add("mpairraces_overlays"); sTatName.Add("MP_Airraces_Tattoo_003_M"); MyTat.Add("Toxic Trails");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_027_M"); MyTat.Add("Serpent Revolver");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_025_M"); MyTat.Add("Praying Skull");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_016_M"); MyTat.Add("Blood Money");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_015_M"); MyTat.Add("Spiked Skull");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_008_M"); MyTat.Add("Bandolier");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_004_M"); MyTat.Add("Sidearm");

                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_008_M"); MyTat.Add("Scarlett");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_004_M"); MyTat.Add("Piston Sleeve");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_055_M"); MyTat.Add("Poison Scorpion");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_053_M"); MyTat.Add("Muffler Helmet");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_045_M"); MyTat.Add("Ride Hard Die Fast");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_035_M"); MyTat.Add("Chain Fist");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_025_M"); MyTat.Add("Good Luck");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_024_M"); MyTat.Add("Live to Ride");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_020_M"); MyTat.Add("Cranial Rose");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_016_M"); MyTat.Add("Macabre Tree");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_012_M"); MyTat.Add("Urban Stunter");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_043_M"); MyTat.Add("Engine Arm");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_039_M"); MyTat.Add("Kaboom");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_035_M"); MyTat.Add("Stuntman's End");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_023_M"); MyTat.Add("Tanked");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_022_M"); MyTat.Add("Piston Head");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_008_M"); MyTat.Add("Moonlight Ride");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_002_M"); MyTat.Add("Big Cat");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_001_M"); MyTat.Add("8 Eyed Skull");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_022_M"); MyTat.Add("My Crazy Life");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_018_M"); MyTat.Add("Skeleton Party");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_006_M"); MyTat.Add("Love Hustle");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_033_M"); MyTat.Add("City Sorrow");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_027_M"); MyTat.Add("Los Santos Life");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_005_M"); MyTat.Add("No Evil");//

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_028_M"); MyTat.Add("Python Skull");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_018_M"); MyTat.Add("Divine Goddess");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_016_M"); MyTat.Add("Egyptian Mural");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_005_M"); MyTat.Add("Fatal Dagger");


                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_021_M"); MyTat.Add("Gabriel");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_020_M"); MyTat.Add("Archangel and Mary");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_Luxe_Tat_009_M"); MyTat.Add("Floral Symmetry");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_021"); MyTat.Add("Time's Up Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_020"); MyTat.Add("Time's Up Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_012"); MyTat.Add("8 Ball Skull");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_010"); MyTat.Add("Electric Snake");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_000"); MyTat.Add("Skull Rider");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_048"); MyTat.Add("Peace");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_043"); MyTat.Add("Triangle White");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_039"); MyTat.Add("Sleeve");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_037"); MyTat.Add("Sunrise");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_034"); MyTat.Add("Stop");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_028"); MyTat.Add("Thorny Rose");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_027"); MyTat.Add("Padlock");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_026"); MyTat.Add("Pizza");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_016"); MyTat.Add("Lightning Bolt");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_015"); MyTat.Add("Mustache");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_007"); MyTat.Add("Bricks");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_003"); MyTat.Add("Diamond Sparkle");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_LeftArm_001"); MyTat.Add("All-Seeing Eye");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_LeftArm_000"); MyTat.Add("$100 Bill");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_LArm_000"); MyTat.Add("Tiki Tower");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_LArm_001"); MyTat.Add("Mermaid L.S.");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_041"); MyTat.Add("Dope Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_031"); MyTat.Add("Lady M");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_015"); MyTat.Add("Zodiac Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_006"); MyTat.Add("Oriental Mural");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_005"); MyTat.Add("Serpents");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_015"); MyTat.Add("Racing Brunette");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_007"); MyTat.Add("Racing Blonde");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_001"); MyTat.Add("Burning Heart");//50 Death Match Award

                    //not on list
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_031_M"); MyTat.Add("Geometric Design");
                }//LEFT ARM
                else if (iZone == 6)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_032_M"); MyTat.Add("K.U.L.T.99.1 FM");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_031_M"); MyTat.Add("Octopus Shades");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_026_M"); MyTat.Add("Shark Water");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_012_M"); MyTat.Add("Still Slipping");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_011_M"); MyTat.Add("Soulwax");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_008_M"); MyTat.Add("Smiley Glitch");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_007_M"); MyTat.Add("Skeleton DJ");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_006_M"); MyTat.Add("Music Locker");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_005_M"); MyTat.Add("LSUR");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_003_M"); MyTat.Add("Lighthouse");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_002_M"); MyTat.Add("Jellyfish Shades");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_001_M"); MyTat.Add("Tropical Dude");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_000_M"); MyTat.Add("Headphone Splat");

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_034_M"); MyTat.Add("LS Monogram");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_028_M"); MyTat.Add("Skull and Aces");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_025_M"); MyTat.Add("Queen of Roses");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_018_M"); MyTat.Add("The Gambler's Life");
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_004_M"); MyTat.Add("Lady Luck");

                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_028_M"); MyTat.Add("Spartan Mural");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_023_M"); MyTat.Add("Samurai Tallship");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_018_M"); MyTat.Add("Muscle Tear");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_017_M"); MyTat.Add("Feather Sleeve");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_014_M"); MyTat.Add("Celtic Band");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_012_M"); MyTat.Add("Tiger Headdress");
                    sTatBase.Add("mpchristmas2017_overlays"); sTatName.Add("MP_Christmas2017_Tattoo_006_M"); MyTat.Add("Medusa");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_023_M"); MyTat.Add("Stylized Kraken");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_005_M"); MyTat.Add("Mutiny");
                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_001_M"); MyTat.Add("Crackshot");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_024_M"); MyTat.Add("Combat Reaper");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_021_M"); MyTat.Add("Have a Nice Day");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_002_M"); MyTat.Add("Grenade");

                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_007_M"); MyTat.Add("Drive Forever");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_006_M"); MyTat.Add("Engulfed Block");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_005_M"); MyTat.Add("Dialed In");
                    sTatBase.Add("mpimportexport_overlays"); sTatName.Add("MP_MP_ImportExport_Tat_003_M"); MyTat.Add("Mechanical Sleeve");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_054_M"); MyTat.Add("Mum");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_049_M"); MyTat.Add("These Colors Don't Run");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_047_M"); MyTat.Add("Snake Bike");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_046_M"); MyTat.Add("Skull Chain");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_042_M"); MyTat.Add("Grim Rider");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_033_M"); MyTat.Add("Eagle Emblem");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_014_M"); MyTat.Add("Lady Mortality");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_007_M"); MyTat.Add("Swooping Eagle");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_049_M"); MyTat.Add("Seductive Mechanic");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_038_M"); MyTat.Add("One Down Five Up");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_036_M"); MyTat.Add("Biker Stallion");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_016_M"); MyTat.Add("Coffin Racer");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_010_M"); MyTat.Add("Grave Vulture");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_009_M"); MyTat.Add("Arachnid of Death");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_003_M"); MyTat.Add("Poison Wrench");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_035_M"); MyTat.Add("Black Tears");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_028_M"); MyTat.Add("Loving Los Muertos");
                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_003_M"); MyTat.Add("Lady Vamp");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_015_M"); MyTat.Add("Seductress");

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_LUXE_TAT_026_M"); MyTat.Add("Floral Print");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_LUXE_TAT_017_M"); MyTat.Add("Heavenly Deity");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_LUXE_TAT_010_M"); MyTat.Add("Intrometric");

                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_019_M"); MyTat.Add("Geisha Bloom");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_013_M"); MyTat.Add("Mermaid Harpist");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_004_M"); MyTat.Add("Floral Raven");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_027"); MyTat.Add("Fuck Luck Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_026"); MyTat.Add("Fuck Luck Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_023"); MyTat.Add("You're Next Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_022"); MyTat.Add("You're Next Outline");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_008"); MyTat.Add("Death Before Dishonor");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_004"); MyTat.Add("Snake Shaded");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_003"); MyTat.Add("Snake Outline");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_045"); MyTat.Add("Mesh Band");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_044"); MyTat.Add("Triangle Black");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_036"); MyTat.Add("Shapes");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_023"); MyTat.Add("Smiley");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_022"); MyTat.Add("Pencil");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_020"); MyTat.Add("Geo Pattern");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_018"); MyTat.Add("Origami");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_017"); MyTat.Add("Eye Triangle");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_014"); MyTat.Add("Spray Can");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_010"); MyTat.Add("Horseshoe");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_008"); MyTat.Add("Cube");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_004"); MyTat.Add("Bone");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_001"); MyTat.Add("Single Arrow");

                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_RightArm_001"); MyTat.Add("Green");
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Buis_M_RightArm_000"); MyTat.Add("Dollar Skull");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_RArm_001"); MyTat.Add("Vespucci Beauty");
                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_RArm_000"); MyTat.Add("Tribal Sun");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_047"); MyTat.Add("Lion");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_038"); MyTat.Add("Dagger");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_028"); MyTat.Add("Mermaid");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_027"); MyTat.Add("Virgin Mary");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_018"); MyTat.Add("Serpent Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_014"); MyTat.Add("Flower Mural");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_003"); MyTat.Add("Dragons and Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_001"); MyTat.Add("Dragons");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_000"); MyTat.Add("Brotherhood");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_010"); MyTat.Add("Ride or Die");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_002"); MyTat.Add("Grim Reaper Smoking Gun");
                    //Not In List
                    sTatBase.Add("mpbusiness_overlays"); sTatName.Add("MP_Male_Crew_Tat_001"); MyTat.Add("Crew Tattoo");
                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_LUXE_TAT_030_M"); MyTat.Add("Geometric Design");
                }//RIGHT ARM
                else if (iZone == 7)
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_029_M"); MyTat.Add("Soundwaves");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_028_M"); MyTat.Add("Skull Waters");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_025_M"); MyTat.Add("Glow Princess");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_024_M"); MyTat.Add("Pineapple Skull");
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_010_M"); MyTat.Add("Tropical Serpent");

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_032_M"); MyTat.Add("Love Fist");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_027_M"); MyTat.Add("8-Ball Rose");//
                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_013_M"); MyTat.Add("One-armed Bandit");//

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_023_M"); MyTat.Add("Rose Revolver");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_011_M"); MyTat.Add("Death Skull");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_007_M"); MyTat.Add("Stylized Tiger");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_005_M"); MyTat.Add("Patriot Skull");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_057_M"); MyTat.Add("Laughing Skull");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_056_M"); MyTat.Add("Bone Cruiser");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_044_M"); MyTat.Add("Ride Free");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_037_M"); MyTat.Add("Scorched Soul");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_036_M"); MyTat.Add("Engulfed Skull");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_027_M"); MyTat.Add("Bad Luck");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_015_M"); MyTat.Add("Ride or Die");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_002_M"); MyTat.Add("Rose Tribute");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_031_M"); MyTat.Add("Stunt Jesus");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_028_M"); MyTat.Add("Quad Goblin");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_021_M"); MyTat.Add("Golden Cobra");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_013_M"); MyTat.Add("Dirt Track Hero");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_007_M"); MyTat.Add("Dagger Devil");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_029_M"); MyTat.Add("Death Us Do Part");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_020_M"); MyTat.Add("Presidents");//
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_007_M"); MyTat.Add("LS Serpent");//

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_Luxe_Tat_011_M"); MyTat.Add("Cross of Roses");
                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_000_M"); MyTat.Add("Serpent of Death");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_002"); MyTat.Add("Spider Color");
                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_001"); MyTat.Add("Spider Outline");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_040"); MyTat.Add("Black Anchor");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_019"); MyTat.Add("Charm");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_009"); MyTat.Add("Squares");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Lleg_000"); MyTat.Add("Tribal Star");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_032"); MyTat.Add("Faith");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_037"); MyTat.Add("Grim Reaper");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_035"); MyTat.Add("Dragon");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_033"); MyTat.Add("Chinese Dragon");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_026"); MyTat.Add("Smoking Dagger");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_023"); MyTat.Add("Hottie");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_021"); MyTat.Add("Serpent Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_008"); MyTat.Add("Dragon Mural");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_002"); MyTat.Add("Melting Skull");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_009"); MyTat.Add("Dragon and Dagger");
                }//LEFT LEG
                else
                {
                    sTatBase.Add("mpheist4_overlays"); sTatName.Add("MP_Heist4_Tat_027_M"); MyTat.Add("Skullphones");

                    sTatBase.Add("mpheist3_overlays"); sTatName.Add("mpHeist3_Tat_031_M"); MyTat.Add("Kifflom");

                    sTatBase.Add("mpvinewood_overlays"); sTatName.Add("MP_Vinewood_Tat_020_M"); MyTat.Add("Cash is King");

                    sTatBase.Add("mpsmuggler_overlays"); sTatName.Add("MP_Smuggler_Tattoo_020_M"); MyTat.Add("Homeward Bound");

                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_030_M"); MyTat.Add("Pistol Ace");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_026_M"); MyTat.Add("Restless Skull");
                    sTatBase.Add("mpgunrunning_overlays"); sTatName.Add("MP_Gunrunning_Tattoo_006_M"); MyTat.Add("Combat Skull");

                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_048_M"); MyTat.Add("STFU");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_040_M"); MyTat.Add("American Made");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_028_M"); MyTat.Add("Dusk Rider");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_022_M"); MyTat.Add("Western Insignia");
                    sTatBase.Add("mpbiker_overlays"); sTatName.Add("MP_MP_Biker_Tat_004_M"); MyTat.Add("Dragon's Fury");

                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_047_M"); MyTat.Add("Brake Knife");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_045_M"); MyTat.Add("Severed Hand");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_032_M"); MyTat.Add("Wheelie Mouse");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_025_M"); MyTat.Add("Speed Freak");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_020_M"); MyTat.Add("Piston Angel");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_015_M"); MyTat.Add("Praying Gloves");
                    sTatBase.Add("mpstunt_overlays"); sTatName.Add("MP_MP_Stunt_tat_005_M"); MyTat.Add("Demon Spark Plug");

                    sTatBase.Add("mplowrider2_overlays"); sTatName.Add("MP_LR_Tat_030_M"); MyTat.Add("San Andreas Prayer");

                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_023_M"); MyTat.Add("Dance of Hearts");
                    sTatBase.Add("mplowrider_overlays"); sTatName.Add("MP_LR_Tat_017_M"); MyTat.Add("Ink Me");

                    sTatBase.Add("mpluxe2_overlays"); sTatName.Add("MP_LUXE_TAT_023_M"); MyTat.Add("Starmetric");

                    sTatBase.Add("mpluxe_overlays"); sTatName.Add("MP_LUXE_TAT_001_M"); MyTat.Add("Elaborate Los Muertos");

                    sTatBase.Add("mpchristmas2_overlays"); sTatName.Add("MP_Xmas2_M_Tat_014"); MyTat.Add("Floral Dagger");

                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_042"); MyTat.Add("Sparkplug");
                    sTatBase.Add("mphipster_overlays"); sTatName.Add("FM_Hip_M_Tat_038"); MyTat.Add("Grub");

                    sTatBase.Add("mpbeach_overlays"); sTatName.Add("MP_Bea_M_Rleg_000"); MyTat.Add("Tribal Tiki Tower");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_043"); MyTat.Add("Indian Ram");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_042"); MyTat.Add("Flaming Scorpion");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_040"); MyTat.Add("Flaming Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_039"); MyTat.Add("Broken Skull");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_022"); MyTat.Add("Fiery Dragon");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_017"); MyTat.Add("Tribal");
                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_M_007"); MyTat.Add("The Warrior");

                    sTatBase.Add("multiplayer_overlays"); sTatName.Add("FM_Tat_Award_M_006"); MyTat.Add("Skull and Sword");
                }//RIGHT LEG
            }// FreeMale

            if (bEmpty)
                MyTat.Add("No Tattoos Available");

            return MyTat;
        }
        public class NameList
        {
            public List<string> MaleName { get; set; }
            public List<string> FemaleName { get; set; }
            public List<string> SurnName { get; set; }

            public NameList()
            {
                MaleName = new List<string>();
                FemaleName = new List<string>();
                SurnName = new List<string>();
            }
        }
        public NameList LoadNames(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(NameList));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (NameList)xml.Deserialize(sr);
            }
        }
        public void SaveNames(NameList config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(NameList));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        private void GetNames()
        {

            LogginSyatem("GetNames");

            if (File.Exists(sNamesFile))
            {
                NameList XSets = LoadNames(sNamesFile);

                sNameFem = XSets.FemaleName;
                sNameMal = XSets.MaleName;
                sNameSir = XSets.SurnName;

                if (sNameFem.Count == 0 || sNameMal.Count == 0 || sNameSir.Count == 0)
                    NamesList();
            }
            else
                NamesList();
        }
        private void NamesList()
        {

            LogginSyatem("NamesList");

            sNameFem.Clear();
            sNameMal.Clear();
            sNameSir.Clear();
            sNameFem.Add("Cherry");
            sNameFem.Add("Delora");
            sNameFem.Add("Angelic");
            sNameFem.Add("Jerica");
            sNameFem.Add("Dianne");
            sNameFem.Add("Nikia");
            sNameFem.Add("Fay");
            sNameFem.Add("Lasonya");
            sNameFem.Add("Camille");
            sNameFem.Add("Kiara");
            sNameFem.Add("Margene");
            sNameFem.Add("Nery");
            sNameFem.Add("Robbi");
            sNameFem.Add("Charla");
            sNameFem.Add("Rina");
            sNameFem.Add("Crystle");
            sNameFem.Add("Kandi");
            sNameFem.Add("Jonelle");
            sNameFem.Add("Terese");
            sNameFem.Add("Obdulia");
            sNameFem.Add("Maricela");
            sNameFem.Add("Jacquie");
            sNameFem.Add("Davine");
            sNameFem.Add("Minna");
            sNameFem.Add("Brianne");
            sNameFem.Add("Pinkie");
            sNameFem.Add("Rosalina");
            sNameFem.Add("Nadene");
            sNameFem.Add("Loida");
            sNameFem.Add("Kristal");
            sNameFem.Add("Ramonita");
            sNameFem.Add("Ula");
            sNameFem.Add("Windy");
            sNameFem.Add("Zulema");
            sNameFem.Add("Marci");
            sNameFem.Add("Sabra");
            sNameFem.Add("Kyong");
            sNameFem.Add("Johnsie");
            sNameFem.Add("Digna");
            sNameFem.Add("Hattie");
            sNameFem.Add("Shirly");
            sNameFem.Add("Winifred");
            sNameFem.Add("Magen");
            sNameFem.Add("Cammy");
            sNameFem.Add("Sherill");
            sNameFem.Add("Josephina");
            sNameFem.Add("Chara");
            sNameFem.Add("Suzi");
            sNameFem.Add("Annabelle");
            sNameFem.Add("Bronwyn");

            sNameMal.Add("Werner");
            sNameMal.Add("Wilbur");
            sNameMal.Add("Blake");
            sNameMal.Add("Grover");
            sNameMal.Add("Jimmy");
            sNameMal.Add("Jamison");
            sNameMal.Add("Josiah");
            sNameMal.Add("Miquel");
            sNameMal.Add("Rupert");
            sNameMal.Add("Christoper");
            sNameMal.Add("Alphonso");
            sNameMal.Add("Malik");
            sNameMal.Add("Korey");
            sNameMal.Add("Jess");
            sNameMal.Add("Dewitt");
            sNameMal.Add("Marquis");
            sNameMal.Add("Mckinley");
            sNameMal.Add("Deshawn");
            sNameMal.Add("Thaddeus");
            sNameMal.Add("Colin");
            sNameMal.Add("Chester");
            sNameMal.Add("Jeremiah");
            sNameMal.Add("Casey");
            sNameMal.Add("Ray");
            sNameMal.Add("Tyron");
            sNameMal.Add("Darron");
            sNameMal.Add("Sylvester");
            sNameMal.Add("Joshua");
            sNameMal.Add("Lenard");
            sNameMal.Add("Leon");
            sNameMal.Add("Son");
            sNameMal.Add("Willis");
            sNameMal.Add("Thurman");
            sNameMal.Add("Noah");
            sNameMal.Add("Josh");
            sNameMal.Add("Sherwood");
            sNameMal.Add("Trey");
            sNameMal.Add("Parker");
            sNameMal.Add("Adalberto");
            sNameMal.Add("Benton");
            sNameMal.Add("Harlan");
            sNameMal.Add("Santos");
            sNameMal.Add("Abraham");
            sNameMal.Add("Moshe");
            sNameMal.Add("Vaughn");
            sNameMal.Add("Quincy");
            sNameMal.Add("Titus");
            sNameMal.Add("Gino");
            sNameMal.Add("Earle");
            sNameMal.Add("Alfonso");

            sNameSir.Add("Agee");
            sNameSir.Add("Hillyer");
            sNameSir.Add("Elie");
            sNameSir.Add("Morrow");
            sNameSir.Add("Wulff");
            sNameSir.Add("Pollan");
            sNameSir.Add("Zieman");
            sNameSir.Add("Welborn");
            sNameSir.Add("Ikeda");
            sNameSir.Add("Mclead");
            sNameSir.Add("Delmonte");
            sNameSir.Add("Eble");
            sNameSir.Add("Beitz");
            sNameSir.Add("Northup");
            sNameSir.Add("Wren");
            sNameSir.Add("Therrien");
            sNameSir.Add("Chitty");
            sNameSir.Add("Bungard");
            sNameSir.Add("Perrella");
            sNameSir.Add("Roselli");
            sNameSir.Add("Million");
            sNameSir.Add("Winder");
            sNameSir.Add("Jaynes");
            sNameSir.Add("Smalling");
            sNameSir.Add("Vito");
            sNameSir.Add("Sabbagh");
            sNameSir.Add("Patenaude");
            sNameSir.Add("Hepburn");
            sNameSir.Add("Lally");
            sNameSir.Add("Fenster");
            sNameSir.Add("Carlen");
            sNameSir.Add("Perri");
            sNameSir.Add("Doepke");
            sNameSir.Add("Livengood");
            sNameSir.Add("Micheal");
            sNameSir.Add("Vanderburg");
            sNameSir.Add("Ringwood");
            sNameSir.Add("Semon");
            sNameSir.Add("Kauffman");
            sNameSir.Add("Frost");
            sNameSir.Add("Simerly");
            sNameSir.Add("Holbrook");
            sNameSir.Add("Waechter");
            sNameSir.Add("Bergstrom");
            sNameSir.Add("Brisker");
            sNameSir.Add("Orwig");
            sNameSir.Add("Gullatt");
            sNameSir.Add("Keifer");
            sNameSir.Add("Rozman");
            sNameSir.Add("Munger");

            NameList XSets = new NameList();

            XSets.FemaleName = sNameFem;
            XSets.MaleName = sNameMal;
            XSets.SurnName = sNameSir;

            SaveNames(XSets, sNamesFile);
        }
        public class RandomPlus
        {
            public List<int> RandNum_01 { get; set; }
            public List<int> RandNum_02 { get; set; }
            public List<int> RandNum_03 { get; set; }
            public List<int> RandNum_04 { get; set; }
            public List<int> RandNum_05 { get; set; }
            public List<int> RandNum_06 { get; set; }
            public List<int> RandNum_07 { get; set; }
            public List<int> RandNum_08 { get; set; }
            public List<int> RandNum_09 { get; set; }
            public List<int> RandNum_10 { get; set; }
            public List<int> RandNum_11 { get; set; }
            public List<int> RandNum_12 { get; set; }

            public List<bool> RanBool { get; set; }

            public RandomPlus()
            {
                RandNum_01 = new List<int>();
                RandNum_02 = new List<int>();
                RandNum_03 = new List<int>();
                RandNum_04 = new List<int>();
                RandNum_05 = new List<int>();
                RandNum_06 = new List<int>();
                RandNum_07 = new List<int>();
                RandNum_08 = new List<int>();
                RandNum_09 = new List<int>();
                RandNum_10 = new List<int>();
                RandNum_11 = new List<int>();
                RandNum_12 = new List<int>();

                RanBool = new List<bool>();
            }
        }
        public RandomPlus LoadRando(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(RandomPlus));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (RandomPlus)xml.Deserialize(sr);
            }
        }
        public void SaveRando(RandomPlus config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(RandomPlus));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public bool BoolList(int iList)
        {

            LogginSyatem("BoolList, iList == " + iList);

            List<int> IntList = new List<int>();

            if (!File.Exists(sRandFile))
                BuildRanXml(true, 0, IntList);

            RandomPlus XSets = LoadRando(sRandFile);
            XSets.RanBool = bRandList;
            bRandList[iList] = !bRandList[iList];
            BuildRanXml(false, 0, IntList);

            return bRandList[iList];
        }
        private void BuildRanXml(bool bBulid, int iList, List<int> list)
        {

            LogginSyatem("BuildRanXml, bBulid == " + bBulid + ", iList == " + iList);

            RandomPlus XSets = new RandomPlus();

            if (bBulid)
            {
                XSets.RandNum_01 = list;
                XSets.RandNum_02 = list;
                XSets.RandNum_03 = list;
                XSets.RandNum_04 = list;
                XSets.RandNum_05 = list;
                XSets.RandNum_06 = list;
                XSets.RandNum_07 = list;
                XSets.RandNum_08 = list;
                XSets.RandNum_09 = list;
                XSets.RandNum_10 = list;
                XSets.RandNum_11 = list;
                XSets.RandNum_12 = list;

                XSets.RanBool = bRandList;
            }
            else
            {
                RandomPlus XySets = LoadRando("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RSRNum.Xml");

                XSets.RandNum_01 = XySets.RandNum_01;
                XSets.RandNum_02 = XySets.RandNum_02;
                XSets.RandNum_03 = XySets.RandNum_03;
                XSets.RandNum_04 = XySets.RandNum_04;
                XSets.RandNum_05 = XySets.RandNum_05;
                XSets.RandNum_06 = XySets.RandNum_06;
                XSets.RandNum_07 = XySets.RandNum_07;
                XSets.RandNum_08 = XySets.RandNum_08;
                XSets.RandNum_09 = XySets.RandNum_09;
                XSets.RandNum_10 = XySets.RandNum_10;
                XSets.RandNum_11 = XySets.RandNum_11;
                XSets.RandNum_12 = XySets.RandNum_12;

                if (iList == 1)
                    XSets.RandNum_01 = list;
                else if (iList == 2)
                    XSets.RandNum_02 = list;
                else if (iList == 3)
                    XSets.RandNum_03 = list;
                else if (iList == 4)
                    XSets.RandNum_04 = list;
                else if (iList == 5)
                    XSets.RandNum_05 = list;
                else if (iList == 6)
                    XSets.RandNum_06 = list;
                else if (iList == 7)
                    XSets.RandNum_07 = list;
                else if (iList == 8)
                    XSets.RandNum_08 = list;
                else if (iList == 9)
                    XSets.RandNum_09 = list;
                else if (iList == 10)
                    XSets.RandNum_10 = list;
                else if (iList == 11)
                    XSets.RandNum_11 = list;
                else if (iList == 12)
                    XSets.RandNum_12 = list;

                XSets.RanBool = bRandList;
            }
            SaveRando(XSets, sRandFile);
        }
        public int FindRandom(int iList, int iMin, int iMax)
        {

            LogginSyatem("FindRandom, iList == " + iList);

            List<int> IntList = new List<int>();
            int iBe = 0;

            if (!File.Exists(sRandFile))
                BuildRanXml(true, 0, IntList);

            RandomPlus XSets = LoadRando(sRandFile);

            if (iList == 1)
                IntList = XSets.RandNum_01;
            else if (iList == 2)
                IntList = XSets.RandNum_02;
            else if (iList == 3)
                IntList = XSets.RandNum_03;
            else if (iList == 4)
                IntList = XSets.RandNum_04;
            else if (iList == 5)
                IntList = XSets.RandNum_05;
            else if (iList == 6)
                IntList = XSets.RandNum_06;
            else if (iList == 7)
                IntList = XSets.RandNum_07;
            else if (iList == 8)
                IntList = XSets.RandNum_08;
            else if (iList == 9)
                IntList = XSets.RandNum_09;
            else if (iList == 10)
                IntList = XSets.RandNum_10;
            else if (iList == 11)
                IntList = XSets.RandNum_11;
            else if (iList == 12)
                IntList = XSets.RandNum_12;

            if (IntList.Count() < 1)
            {
                IntList.Clear();
                for (int i = iMin; i < iMax + 1; i++)
                    IntList.Add(i);
            }
            int iRanNum = RandInt(0, IntList.Count - 1);
            iBe = IntList[iRanNum];
            IntList.RemoveAt(iRanNum);

            BuildRanXml(false, iList, IntList);

            return iBe;
        }
        public List<string> PedCollect()
        {
            List<string> JustNames = new List<string>();

            for (int i = 0; i < MyPedCollection.Count(); i++)
                JustNames.Add(MyPedCollection[i].Name);

            return JustNames;
        }
        public class ClothBankist
        {
            public List<NewClothBank> FreeChars { get; set; }

            public ClothBankist()
            {
                FreeChars = new List<NewClothBank>();
            }
        }
        public ClothBankist LoadChars(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ClothBankist));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (ClothBankist)xml.Deserialize(sr);
            }
        }
        public void SaveChars(ClothBankist config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ClothBankist));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public void AddChars(NewClothBank MyNewChar)
        {
            bool bOverWrite = true;
            for (int i = 0; i < MyPedCollection.Count; i++)
            {
                if (bOverWrite)
                {
                    if (MyPedCollection[i].Name == MyNewChar.Name)
                    {
                        bOverWrite = false;
                        MyPedCollection[i].ModelX = MyNewChar.ModelX;

                        MyPedCollection[i].ClothA = new List<int>(MyNewChar.ClothA);
                        MyPedCollection[i].ClothB = new List<int>(MyNewChar.ClothB);

                        MyPedCollection[i].ExtraA = new List<int>(MyNewChar.ExtraA);
                        MyPedCollection[i].ExtraB = new List<int>(MyNewChar.ExtraB);

                        MyPedCollection[i].FreeMode = MyNewChar.FreeMode;

                        MyPedCollection[i].XshapeFirstID = MyNewChar.XshapeFirstID;
                        MyPedCollection[i].XshapeSecondID = MyNewChar.XshapeSecondID;
                        MyPedCollection[i].XshapeThirdID = MyNewChar.XshapeThirdID;
                        MyPedCollection[i].XskinFirstID = MyNewChar.XskinFirstID;
                        MyPedCollection[i].XskinSecondID = MyNewChar.XskinSecondID;
                        MyPedCollection[i].XskinThirdID = MyNewChar.XskinThirdID;
                        MyPedCollection[i].XshapeMix = MyNewChar.XshapeMix;
                        MyPedCollection[i].XskinMix = MyNewChar.XskinMix;
                        MyPedCollection[i].XthirdMix = MyNewChar.XthirdMix;
                        MyPedCollection[i].XisParent = MyNewChar.XisParent;

                        MyPedCollection[i].HairColour = MyNewChar.HairColour;
                        MyPedCollection[i].HairStreaks = MyNewChar.HairStreaks;
                        MyPedCollection[i].EyeColour = MyNewChar.EyeColour;

                        MyPedCollection[i].Overlay = new List<int>(MyNewChar.Overlay);
                        MyPedCollection[i].OverlayColour = new List<int>(MyNewChar.OverlayColour);
                        MyPedCollection[i].OverlayOpc = new List<float>(MyNewChar.OverlayOpc);

                        MyPedCollection[i].Tattoo_COl = new List<string>(MyNewChar.Tattoo_COl);
                        MyPedCollection[i].Tattoo_Nam = new List<string>(MyNewChar.Tattoo_Nam);

                        MyPedCollection[i].FaceScale = new List<float>(MyNewChar.FaceScale);

                        MyPedCollection[i].PedVoice = MyNewChar.PedVoice;
                        break;
                    }
                }
            }

            if (bOverWrite)
                MyPedCollection.Add(MyNewChar);

            SetPedSaveXML();
        }
        public class NewClothBank
        {
            public string Name { get; set; }

            public int ModelX { get; set; }

            public List<int> ClothA { get; set; }
            public List<int> ClothB { get; set; }

            public List<int> ExtraA { get; set; }
            public List<int> ExtraB { get; set; }

            public bool FreeMode { get; set; }

            public int XshapeFirstID { get; set; }
            public int XshapeSecondID { get; set; }
            public int XshapeThirdID { get; set; }
            public int XskinFirstID { get; set; }
            public int XskinSecondID { get; set; }
            public int XskinThirdID { get; set; }
            public float XshapeMix { get; set; }
            public float XskinMix { get; set; }
            public float XthirdMix { get; set; }
            public int XisParent { get; set; }

            public int HairColour { get; set; }
            public int HairStreaks { get; set; }
            public int EyeColour { get; set; }

            public List<int> Overlay { get; set; }
            public List<int> OverlayColour { get; set; }
            public List<float> OverlayOpc { get; set; }

            public List<string> Tattoo_COl { get; set; }
            public List<string> Tattoo_Nam { get; set; }

            public List<float> FaceScale { get; set; }

            public string PedVoice { get; set; }

            public NewClothBank()
            {
                ClothA = new List<int>();
                ClothB = new List<int>();

                ExtraA = new List<int>();
                ExtraB = new List<int>();

                Overlay = new List<int>();
                OverlayColour = new List<int>();
                OverlayOpc = new List<float>();

                Tattoo_COl = new List<string>();
                Tattoo_Nam = new List<string>();

                FaceScale = new List<float>();
            }
        }
        public NewClothBank LoadNewOutfit(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(NewClothBank));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (NewClothBank)xml.Deserialize(sr);
            }
        }
        public void SaveNewOutfitMain(NewClothBank config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(NewClothBank));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public class ClothBank
        {
            public int ModelX { get; set; }

            public List<int> ClothA { get; set; }
            public List<int> ClothB { get; set; }

            public List<int> ExtraA { get; set; }
            public List<int> ExtraB { get; set; }

            public bool FreeMode { get; set; }

            public int XshapeFirstID { get; set; }
            public int XshapeSecondID { get; set; }
            public int XshapeThirdID { get; set; }
            public int XskinFirstID { get; set; }
            public int XskinSecondID { get; set; }
            public int XskinThirdID { get; set; }
            public float XshapeMix { get; set; }
            public float XskinMix { get; set; }
            public float XthirdMix { get; set; }
            public int XisParent { get; set; }

            public int HairColour { get; set; }
            public int HairStreaks { get; set; }
            public int EyeColour { get; set; }

            public List<int> Overlay { get; set; }
            public List<int> OverlayColour { get; set; }
            public List<float> OverlayOpc { get; set; }

            public List<string> Tattoo_COl { get; set; }
            public List<string> Tattoo_Nam { get; set; }

            public ClothBank()
            {
                ClothA = new List<int>();
                ClothB = new List<int>();
                ExtraA = new List<int>();
                ExtraB = new List<int>();

                Overlay = new List<int>();
                OverlayColour = new List<int>();
                OverlayOpc = new List<float>();

                Tattoo_COl = new List<string>();
                Tattoo_Nam = new List<string>();
            }
        }
        public ClothBank LoadOutfit(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ClothBank));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (ClothBank)xml.Deserialize(sr);
            }
        }
        private void PedPools()
        {

            LogginSyatem("PedPool");

            if (File.Exists(sSavedFile))
            {
                ClothBankist ClothXML = new ClothBankist();
                ClothXML = LoadChars(sSavedFile);
                MyPedCollection = new List<NewClothBank>(ClothXML.FreeChars);
            }
            else
            {
                WritePedSave("Current");

                string sNamez = "SP";
                List<string> sWardrobe = new List<string>();

                string[] sWrite = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/");
                for (int i = 0; i < sWrite.Count(); i++)
                {
                    string sting = sWrite[i];
                    if (sting.Contains(sNamez))
                    {
                        int iNum = sting.LastIndexOf("/") + 1;
                        sWardrobe.Add(sting.Substring(iNum));
                    }
                }
                if (File.Exists("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/SavePed.Xml"))
                    sWardrobe.Add("SavePed.Xml");

                for (int i = 0; i < sWardrobe.Count(); i++)
                {
                    NewClothBank NewCloth = new NewClothBank();
                    ClothBank OldCloths = LoadOutfit("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/" + sWardrobe[i]);

                    string sNameFix = sWardrobe[i];
                    string sNAme = sNameFix.Remove(0, 3);
                    int iNum = sNAme.Length;

                    NewCloth.Name = sNAme.Remove(iNum - 4, 4);
                    NewCloth.ModelX = OldCloths.ModelX;

                    NewCloth.ClothA = new List<int>(OldCloths.ClothA);
                    NewCloth.ClothB = new List<int>(OldCloths.ClothB);

                    NewCloth.ExtraA = new List<int>(OldCloths.ExtraA);
                    NewCloth.ExtraB = new List<int>(OldCloths.ExtraB);

                    NewCloth.FreeMode = OldCloths.FreeMode;

                    NewCloth.XshapeFirstID = OldCloths.XshapeFirstID;
                    NewCloth.XshapeSecondID = OldCloths.XshapeSecondID;
                    NewCloth.XshapeThirdID = OldCloths.XshapeThirdID;
                    NewCloth.XskinFirstID = OldCloths.XskinFirstID;
                    NewCloth.XskinSecondID = OldCloths.XskinSecondID;
                    NewCloth.XskinThirdID = OldCloths.XskinThirdID;
                    NewCloth.XshapeMix = OldCloths.XshapeMix;
                    NewCloth.XskinMix = OldCloths.XskinMix;
                    NewCloth.XthirdMix = OldCloths.XthirdMix;
                    NewCloth.XisParent = OldCloths.XisParent;

                    NewCloth.HairColour = OldCloths.HairColour;
                    NewCloth.HairStreaks = OldCloths.HairStreaks;
                    NewCloth.EyeColour = OldCloths.EyeColour;

                    NewCloth.Overlay = new List<int>(OldCloths.Overlay);
                    NewCloth.OverlayColour = new List<int>(OldCloths.OverlayColour);
                    NewCloth.OverlayOpc = new List<float>(OldCloths.OverlayOpc);

                    NewCloth.Tattoo_COl = new List<string>(OldCloths.Tattoo_COl);
                    NewCloth.Tattoo_Nam = new List<string>(OldCloths.Tattoo_Nam);

                    NewCloth.FaceScale = new List<float>();

                    NewCloth.PedVoice = "";

                    MyPedCollection.Add(NewCloth);

                    File.Delete("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/" + sWardrobe[i]);
                }
                SetPedSaveXML();
            }
        }
        public void SetPedSaveXML()
        {
            ClothBankist ClothXML = new ClothBankist();

            ClothXML.FreeChars = new List<NewClothBank>(MyPedCollection);

            SaveChars(ClothXML, sSavedFile);
        }
        public void WritePedSave(string sPed)
        {

            LogginSyatem("WritePedSave, sPed == " + sPed);

            List<int> ClothsA = new List<int>();
            List<int> ClothsB = new List<int>();
            List<int> ExtrasA = new List<int>();
            List<int> ExtrasB = new List<int>();

            Ped Peddy = Game.Player.Character;
            NewClothBank Cbank = new NewClothBank();

            Cbank.Name = sPed;

            Cbank.ModelX = Peddy.Model.GetHashCode();

            if (Peddy.Model == Function.Call<int>(Hash.GET_HASH_KEY, "mp_f_freemode_01") || Peddy.Model == Function.Call<int>(Hash.GET_HASH_KEY, "mp_m_freemode_01"))
                Cbank.FreeMode = true;
            else
                Cbank.FreeMode = false;

            for (int i = 0; i < 12; i++)
            {
                ClothsA.Add(Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Peddy, i));
                ClothsB.Add(Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Peddy, i));
            }
            for (int i = 0; i < 5; i++)
            {
                ExtrasA.Add(Function.Call<int>(Hash.GET_PED_PROP_INDEX, Peddy, i));
                ExtrasB.Add(Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Peddy, i));
            }

            Cbank.ClothA = ClothsA;
            Cbank.ClothB = ClothsB;

            Cbank.ExtraA = ExtrasA;
            Cbank.ExtraB = ExtrasB;

            Cbank.Overlay = iOverlay;
            Cbank.OverlayColour = iOverlayColour;
            Cbank.OverlayOpc = fOverlayOpc;

            if (Cbank.FreeMode)
            {
                Cbank.XshapeFirstID = GetHeadBlendData(Peddy).shapeFirstID;
                Cbank.XshapeSecondID = GetHeadBlendData(Peddy).shapeSecondID;
                Cbank.XshapeThirdID = GetHeadBlendData(Peddy).shapeThirdID;
                Cbank.XskinFirstID = GetHeadBlendData(Peddy).skinFirstID;
                Cbank.XskinSecondID = GetHeadBlendData(Peddy).skinSecondID;
                Cbank.XskinThirdID = GetHeadBlendData(Peddy).skinThirdID;
                Cbank.XshapeMix = GetHeadBlendData(Peddy).shapeMix;
                Cbank.XskinMix = GetHeadBlendData(Peddy).skinMix;
                Cbank.XthirdMix = GetHeadBlendData(Peddy).thirdMix;
                Cbank.XisParent = GetHeadBlendData(Peddy).isParent;

                Cbank.Overlay = iOverlay;
                Cbank.OverlayColour = iOverlayColour;
                Cbank.OverlayOpc = fOverlayOpc;

                Cbank.HairColour = iHair01;
                Cbank.HairStreaks = iHair02;
                Cbank.EyeColour = iEye;

                Cbank.FaceScale = fAceFeats;
            }
            Cbank.Tattoo_COl = AddTatBase;
            Cbank.Tattoo_Nam = AddTatName;

            Cbank.PedVoice = sPedVoices;

            AddChars(Cbank);
        }
        [StructLayout(LayoutKind.Explicit, Size = 80)]
        public struct HeadBlendData
        {
            [FieldOffset(0)] public int shapeFirstID;
            [FieldOffset(8)] public int shapeSecondID;
            [FieldOffset(16)] public int shapeThirdID;
            [FieldOffset(24)] public int skinFirstID;
            [FieldOffset(32)] public int skinSecondID;
            [FieldOffset(40)] public int skinThirdID;
            [FieldOffset(48)] public float shapeMix;
            [FieldOffset(56)] public float skinMix;
            [FieldOffset(64)] public float thirdMix;
            [FieldOffset(72)] public int isParent;
        }
        public unsafe HeadBlendData GetHeadBlendData(Ped Peddy)
        {
            HeadBlendData hbd = new HeadBlendData() { shapeFirstID = -1 };
            HeadBlendData* pHbd = &hbd;

            bool result = SHVNative.invoke<bool>((ulong)Hash._GET_PED_HEAD_BLEND_DATA, Peddy.Handle, (IntPtr)pHbd);

            // result handling might be useful

            return *pHbd;
        }
        private void ForceAnim(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {

            LogginSyatem("ForceAnim, sAnimName == " + sAnimName);

            peddy.Task.ClearAll();
            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(1);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 1, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        private void ForceAnimOnce(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {

            LogginSyatem("ForceAnimOnce, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 0, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        private void PedMenuMain()
        {
            LogginSyatem("PedMenuMain");

            iPedNum = 0;
            MyMenuPool = new MenuPool();
            var mainMenu = new UIMenu(sLangfile[6], "");
            MyMenuPool.Add(mainMenu);
            RanPedMenu(mainMenu); //Here we add the  Sub Menus
            SetLocate(mainMenu);
            SetChar(mainMenu);
            SetLoadWeps(mainMenu);
            SetMenuKey(mainMenu);
            SelectSaved(mainMenu);
            DisRecord(mainMenu);
            AddBeachParty(mainMenu);
            SeatBeltON(mainMenu);
            Re_WriteLoadout(mainMenu);
            MyMenuPool.RefreshIndex();
            bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private void SavePedMenu(UIMenu XMen)
        {

            LogginSyatem("SavePedMenu");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, sLangfile[8]);

            SetComponents(playermodelmenu);
            SetPedProps(playermodelmenu);
            ResetPedProps(playermodelmenu);
            SetHVoice(playermodelmenu);

            if (Game.Player.Character.Model == PedHash.Michael)
            {
                AddTatts(playermodelmenu, 1);
            }
            else if (Game.Player.Character.Model == PedHash.Franklin)
            {
                AddTatts(playermodelmenu, 2);
            }
            else if (Game.Player.Character.Model == PedHash.Trevor)
            {
                AddTatts(playermodelmenu, 3);
            }
            else if (Game.Player.Character.Model == PedHash.FreemodeFemale01)
            {
                if (iOverlay.Count() == 0)
                    OverLayList();

                SetHair01(playermodelmenu);
                SetHair02(playermodelmenu);
                SetHEyes(playermodelmenu);
                SetOverLays(playermodelmenu);
                AddTatts(playermodelmenu, 4);
                SetFaceFeatures(playermodelmenu);
            }
            else if (Game.Player.Character.Model == PedHash.FreemodeMale01)
            {
                if (iOverlay.Count() == 0)
                    OverLayList();

                SetHair01(playermodelmenu);
                SetHair02(playermodelmenu);
                SetHEyes(playermodelmenu);
                SetOverLays(playermodelmenu);
                AddTatts(playermodelmenu, 5);
                SetFaceFeatures(playermodelmenu);
            }

            if (iPedNum > 0)
                SaveMyPed(playermodelmenu);
            CreateNewPed(playermodelmenu);
            DeleteCurrentPed(playermodelmenu);
        }
        private void SelectSaved(UIMenu XMen)
        {

            LogginSyatem("SelectSaved");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, sLangfile[8]);

            AddTatBase.Clear();
            AddTatName.Clear();
            sPedVoices = "";
            WritePedSave("Current");

            List<dynamic> SavedPeds = new List<dynamic>();

            for (int i = 0; i < MyPedCollection.Count; i++)
                SavedPeds.Add(MyPedCollection[i].Name);

            var ThisShizle = new UIMenuListItem("", SavedPeds, 0);
            ThisShizle.Description = sLangfile[98];
            playermodelmenu.AddItem(ThisShizle);
            playermodelmenu.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    iPedNum = index;
                    SavePedLoader(MyPedCollection[iPedNum]);
                }
            };
            playermodelmenu.OnItemSelect += (sender, item, index) =>
            {

                if (item == ThisShizle)
                {
                    playermodelmenu.Clear();
                    SavePedMenu(playermodelmenu);
                }
            };
        }
        private void CompileMenuTotals(List<dynamic> dList, int iTotal, int iBZero)
        {

            LogginSyatem("CompileMenuTotals");

            while (iBZero < iTotal)
            {
                dList.Add("- " + iBZero + " -");
                iBZero = iBZero + 1;
            }
        }
        private void CompileMenuTotalsFloats(List<dynamic> dList, int iLow, int iTotal)
        {

            LogginSyatem("CompileMenuTotalsFloats");

            int iUpC = iLow;
            while (iUpC < iTotal)
            {
                if (iUpC < -9)
                {
                    dList.Add("[ -0." + iUpC * -1 + " ]");
                }
                else if (iUpC < 0)
                {
                    dList.Add("[ -0.0" + iUpC * -1 + " ]");
                }
                else if (iUpC < 10)
                    dList.Add("[ 0.0" + iUpC + " ]");
                else
                    dList.Add("[ 0." + iUpC + " ]");
                iUpC = iUpC + 1;
            }
        }
        private void SetHair01(UIMenu XMen)
        {

            LogginSyatem("SetHair01");

            List<dynamic> Hair01 = new List<dynamic>();

            int iCount = Function.Call<int>(Hash._GET_NUM_HAIR_COLORS);
            CompileMenuTotals(Hair01, iCount, 0);
            var newitem = new UIMenuListItem(sLangfile[9], Hair01, 0);
            newitem.Index = iHair01;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    Function.Call(Hash._SET_PED_HAIR_COLOR, Game.Player.Character, index, iHair02);
                    iHair01 = index;
                }

            };
        }
        private void SetHair02(UIMenu XMen)
        {

            LogginSyatem("SetHair02");

            List<dynamic> Hair02 = new List<dynamic>();

            int iCount = Function.Call<int>(Hash._GET_NUM_HAIR_COLORS);
            CompileMenuTotals(Hair02, iCount, 0);
            var newitem = new UIMenuListItem(sLangfile[10], Hair02, 0);
            newitem.Index = iHair02;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    Function.Call(Hash._SET_PED_HAIR_COLOR, Game.Player.Character, iHair01, index);
                    iHair02 = index;
                }
            };
        }
        private void SetHEyes(UIMenu XMen)
        {

            LogginSyatem("SetHEyes");

            List<dynamic> Eyes = new List<dynamic>();

            int iCount = 32;
            CompileMenuTotals(Eyes, iCount, 0);

            var newitem = new UIMenuListItem(sLangfile[11], Eyes, 0);
            newitem.Index = iEye;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    Function.Call(Hash._SET_PED_EYE_COLOR, Game.Player.Character, index);
                    iEye = index;
                }
            };
        }
        private void SetHVoice(UIMenu XMen)
        {

            LogginSyatem("SetHVoice");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, "Voices");

            List<dynamic> Voices = new List<dynamic>();

            for (int i = 0; i < ThemVoices.Count; i++)
            {
                Voices.Add(ThemVoices[i]);
                var newitem = new UIMenuItem(ThemVoices[i]);
                playermodelmenu.AddItem(newitem);
            }

            playermodelmenu.OnItemSelect += (sender, item, index) =>
            {
                sPedVoices = ThemVoices[index];
                Function.Call(Hash.SET_AMBIENT_VOICE_NAME, Game.Player.Character, sPedVoices);
                Function.Call((Hash)0x4ADA3F19BE4A6047, Game.Player.Character);
                UI.Notify("Voice set to " + sPedVoices);
            };
        }
        private void SetOverLays(UIMenu XMen)
        {

            LogginSyatem("SetOverLays");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, sLangfile[12]);

            SetOvers(playermodelmenu, 0, sLangfile[13], 23);
            SetOversColour(playermodelmenu, 1, sLangfile[14], 28);
            SetOversColour(playermodelmenu, 2, sLangfile[15], 33);
            SetOvers(playermodelmenu, 3, sLangfile[16], 14);
            SetOvers(playermodelmenu, 4, sLangfile[17], 74);
            SetOversColour(playermodelmenu, 5, sLangfile[18], 6);
            SetOvers(playermodelmenu, 6, sLangfile[19], 11);
            SetOvers(playermodelmenu, 7, sLangfile[20], 10);
            SetOversColour(playermodelmenu, 8, sLangfile[21], 9);
            SetOvers(playermodelmenu, 9, sLangfile[22], 17);
            SetOversColour(playermodelmenu, 10, sLangfile[23], 16);
            SetOvers(playermodelmenu, 11, sLangfile[24], 11);
        }
        private void SetOvers(UIMenu XMen, int OverLayId, string sName, int iCount)
        {

            LogginSyatem("SetOvers");

            string sOpacity = "" + sName + sLangfile[25];

            List<dynamic> Main = new List<dynamic>();
            int iZero = iOverlay[OverLayId];
            if (iZero == 255)
                iZero = -1;
            CompileMenuTotals(Main, iCount, -1);
            var newitem = new UIMenuListItem(sName, Main, 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            List<dynamic> Opacity = new List<dynamic>();
            iCount = 99;
            float fOvers = fOverlayOpc[OverLayId];
            fOvers = fOvers * 100;
            int iAM = (int)Math.Ceiling(fOvers);
            CompileMenuTotalsFloats(Opacity, 0, iCount);
            var newitemOpac = new UIMenuListItem(sOpacity, Opacity, 0);
            newitemOpac.Index = iAM;
            XMen.AddItem(newitemOpac);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iOver = index - 1;
                    if (iOver == -1)
                        iOver = 255;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, OverLayId, iOver, fOverlayOpc[OverLayId]);
                    iOverlay[OverLayId] = iOver;
                }
                else if (item == newitemOpac)
                {
                    float fOpal = (int)index;
                    fOpal = fOpal / 100;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, OverLayId, Function.Call<int>(Hash._GET_PED_HEAD_OVERLAY_VALUE, Game.Player.Character, OverLayId), fOpal);
                    fOverlayOpc[OverLayId] = fOpal;
                }
            };
        }
        private void SetOversColour(UIMenu XMen, int OverLayId, string sName, int iCount)
        {

            LogginSyatem("SetOversColour");

            string sOpacity = "" + sName + sLangfile[25];
            string sColour = "" + sName + sLangfile[26];

            List<dynamic> Main = new List<dynamic>();
            int iZero = iOverlay[OverLayId];
            if (iZero == 255)
                iZero = -1;
            CompileMenuTotals(Main, iCount, -1);
            var newitem = new UIMenuListItem(sName, Main, 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            List<dynamic> Colour = new List<dynamic>();

            iCount = 64;
            CompileMenuTotals(Colour, iCount, 0);
            var newitem2 = new UIMenuListItem(sColour, Colour, 0);
            newitem2.Index = iOverlayColour[OverLayId];
            XMen.AddItem(newitem2);

            List<dynamic> Opacity = new List<dynamic>();
            iCount = 99;
            float fOvers = fOverlayOpc[OverLayId];
            fOvers = fOvers * 100;
            int iAM = (int)Math.Ceiling(fOvers);
            CompileMenuTotalsFloats(Opacity, 0, iCount);
            var newitemOpac = new UIMenuListItem(sOpacity, Opacity, 0);
            newitemOpac.Index = iAM;
            XMen.AddItem(newitemOpac);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iOver = index - 1;
                    if (iOver == -1)
                        iOver = 255;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, OverLayId, iOver, fOverlayOpc[OverLayId]);
                    iOverlay[OverLayId] = iOver;
                }
                else if (item == newitem2)
                {
                    Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Game.Player.Character, OverLayId, 1, index, 0);
                    iOverlayColour[OverLayId] = index;
                }
                else if (item == newitemOpac)
                {
                    float fOpal = (int)index;
                    fOpal = fOpal / 100;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character, OverLayId, Function.Call<int>(Hash._GET_PED_HEAD_OVERLAY_VALUE, Game.Player.Character, OverLayId), fOpal);
                    fOverlayOpc[OverLayId] = fOpal;
                }
            };
        }
        private void SetComponents(UIMenu XMen)
        {

            LogginSyatem("SetComponents");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, sLangfile[27]);

            if (Game.Player.Character.Model != PedHash.Michael && Game.Player.Character.Model != PedHash.Trevor && Game.Player.Character.Model != PedHash.Franklin)
                Componets(playermodelmenu, 0, sLangfile[28]);
            Componets(playermodelmenu, 1, sLangfile[29]);
            Componets(playermodelmenu, 2, sLangfile[30]);
            Componets(playermodelmenu, 3, sLangfile[31]);
            Componets(playermodelmenu, 4, sLangfile[32]);
            Componets(playermodelmenu, 5, sLangfile[33]);
            Componets(playermodelmenu, 6, sLangfile[34]);
            Componets(playermodelmenu, 7, sLangfile[35]);
            Componets(playermodelmenu, 8, sLangfile[36]);
            Componets(playermodelmenu, 9, sLangfile[37]);
            Componets(playermodelmenu, 10, sLangfile[38]);
            Componets(playermodelmenu, 11, sLangfile[39]);
        }
        private void Componets(UIMenu XMen, int CompId, string sName)
        {

            LogginSyatem("Componets");

            string sText = "" + sName + sLangfile[40];

            List<dynamic> Comp = new List<dynamic>();

            int iCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, CompId) + 1;
            int iZero = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, CompId);
            CompileMenuTotals(Comp, iCount, -1);
            var newitem = new UIMenuListItem(sName, Comp, 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            List<dynamic> Txture = new List<dynamic>();

            int iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, CompId, iZero) + 1;
            CompileMenuTotals(Txture, iTexTotal, 0);
            var newitem2 = new UIMenuListItem(sText, Txture, 0);
            newitem2.Index = 0;
            XMen.AddItem(newitem2);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iDex = index - 1;
                    iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character, CompId, iDex) + 1;
                    newitem2.Items.Clear();
                    CompileMenuTotals(newitem2.Items, iTexTotal, 0);
                    newitem2.Index = 0;
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, CompId, iDex, 0, 2);
                }
                else if (item == newitem2)
                {
                    int iAmComp = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, CompId);
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, CompId, iAmComp, index, 2);
                }
            };
        }
        private void SetPedProps(UIMenu XMen)
        {

            LogginSyatem("SetPedProps");

            var playermodelmenu2 = MyMenuPool.AddSubMenu(XMen, sLangfile[41]);

            PedProps(playermodelmenu2, 0, sLangfile[42]);
            PedProps(playermodelmenu2, 1, sLangfile[43]);
            PedProps(playermodelmenu2, 2, sLangfile[44]);
            PedProps(playermodelmenu2, 3, sLangfile[45]);
        }
        private void PedProps(UIMenu XMen, int CompId, string sName)
        {

            LogginSyatem("PedProps");

            string sText = "" + sName + sLangfile[40];

            List<dynamic> Comp = new List<dynamic>();

            int iCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character, CompId) + 1;
            int iZero = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, CompId);
            CompileMenuTotals(Comp, iCount, -1);
            var newitem = new UIMenuListItem(sName, Comp, 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            List<dynamic> Txture = new List<dynamic>();

            int iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, CompId, iZero) + 1;
            CompileMenuTotals(Txture, iTexTotal, 0);
            var newitem2 = new UIMenuListItem(sText, Txture, 0);
            newitem2.Index = 0;
            XMen.AddItem(newitem2);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iDex = index - 1;
                    iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character, CompId, iDex) + 1;
                    newitem2.Items.Clear();
                    CompileMenuTotals(newitem2.Items, iTexTotal, 0);
                    newitem2.Index = 0;
                    if (iDex == -1)
                        Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, CompId);
                    else
                        Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, CompId, iDex, 0, false);
                }
                else if (item == newitem2)
                {
                    int iAmComp = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, CompId);
                    Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character, CompId, iAmComp, index, false);
                }
            };
        }
        private void ResetPedProps(UIMenu XMen)
        {

            LogginSyatem("ResetPedProps");

            var playermodelmenu = new UIMenuItem(sLangfile[46], sLangfile[47]);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
                    Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 0);
                    Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 1);
                    Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 2);
                    Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character, 3);
                }
            };
        }
        private void AddTatts(UIMenu XMen, int iChar)
        {
            LogginSyatem("AddTatts");

            if (iChar == 1 || iChar == 2 || iChar == 3)
            {
                var playermodelmenu = MyMenuPool.AddSubMenu(XMen, sLangfile[109]);

                Tatty(playermodelmenu, iChar, 1, sLangfile[100]);    //TORSO
                Tatty(playermodelmenu, iChar, 2, sLangfile[106]);   //HEAD
                Tatty(playermodelmenu, iChar, 3, sLangfile[103]);   //LEFT ARM
                Tatty(playermodelmenu, iChar, 4, sLangfile[102]);   //RIGHT ARM
                Tatty(playermodelmenu, iChar, 5, sLangfile[105]);   //LEFT LEG
                Tatty(playermodelmenu, iChar, 6, sLangfile[104]);   //RIGHT LEG

                ClearTats(playermodelmenu);
            }
            else
            {
                var playermodelmenu = MyMenuPool.AddSubMenu(XMen, sLangfile[109]);

                Tatty(playermodelmenu, iChar, 1, sLangfile[99]);    //BACK
                Tatty(playermodelmenu, iChar, 2, sLangfile[110]);   //CHEST
                Tatty(playermodelmenu, iChar, 3, sLangfile[111]);   //STOMACH
                Tatty(playermodelmenu, iChar, 4, sLangfile[106]);   //HEAD
                Tatty(playermodelmenu, iChar, 5, sLangfile[103]);   //LEFT ARM
                Tatty(playermodelmenu, iChar, 6, sLangfile[102]);   //RIGHT ARM
                Tatty(playermodelmenu, iChar, 7, sLangfile[105]);   //LEFT LEG
                Tatty(playermodelmenu, iChar, 8, sLangfile[104]);   //RIGHT LEG

                ClearTats(playermodelmenu);
            }
        }
        private void Tatty(UIMenu XMen, int iChar, int iSkin, string sName)
        {
            LogginSyatem("Tatty");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, sName);

            List<string> sub_01 = TattoosList(iChar, iSkin);

            if (sub_01[0] != "No Tattoos Available")
            {
                for (int i = 0; i < sub_01.Count; i++)
                {
                    var item_ = new UIMenuItem(sub_01[i], "");
                    playermodelmenu.AddItem(item_);
                    if (AddTatName.Contains(sTatName[i]))
                        item_.SetRightBadge(UIMenuItem.BadgeStyle.Tatoo);

                }

                playermodelmenu.OnItemSelect += (sender, item, index) =>
                {
                    TattoosList(iChar, iSkin);
                    if (sub_01[index] != "No Tattoos Available")
                    {
                        Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character);

                        if (!AddTatName.Contains(sTatName[index]))
                        {
                            item.SetRightBadge(UIMenuItem.BadgeStyle.Tatoo);
                            AddTatBase.Add(sTatBase[index]);
                            AddTatName.Add(sTatName[index]);
                            Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, sTatBase[index]), Function.Call<int>(Hash.GET_HASH_KEY, sTatName[index]));
                        }
                        else
                        {
                            item.SetRightBadge(UIMenuItem.BadgeStyle.None);
                            int iAm = AddTatName.IndexOf(sTatName[index]);
                            AddTatBase.RemoveAt(iAm);
                            AddTatName.RemoveAt(iAm);
                        }

                    }

                };
                playermodelmenu.OnMenuClose += (sender) =>
                {
                    Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character);
                    for (int i = 0; i < AddTatBase.Count; i++)
                        Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character, Function.Call<int>(Hash.GET_HASH_KEY, AddTatBase[i]), Function.Call<int>(Hash.GET_HASH_KEY, AddTatName[i]));
                };
            }



        }
        private void ClearTats(UIMenu XMen)
        {

            LogginSyatem("ClearTats");

            var playermodelmenu = new UIMenuItem(sLangfile[108], "");
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character);
                    AddTatBase.Clear();
                    AddTatName.Clear();
                }
            };
        }
        private void FaceTheFacts()
        {
            for (int i = 0; i < 20; i++)
            {
                fAceFeats.Add(0.00f);
            }
        }
        private void SetFaceFeatures(UIMenu XMen)
        {
            LogginSyatem("SetFaceFeatures");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, sLangfile[134]);

            FaceFeatures(playermodelmenu, 0, sLangfile[114]);
            FaceFeatures(playermodelmenu, 1, sLangfile[115]);
            FaceFeatures(playermodelmenu, 2, sLangfile[116]);
            FaceFeatures(playermodelmenu, 3, sLangfile[117]);
            FaceFeatures(playermodelmenu, 4, sLangfile[118]);
            FaceFeatures(playermodelmenu, 5, sLangfile[119]);
            FaceFeatures(playermodelmenu, 6, sLangfile[120]);
            FaceFeatures(playermodelmenu, 7, sLangfile[121]);
            FaceFeatures(playermodelmenu, 8, sLangfile[122]);
            FaceFeatures(playermodelmenu, 9, sLangfile[123]);
            FaceFeatures(playermodelmenu, 10, sLangfile[124]);
            FaceFeatures(playermodelmenu, 11, sLangfile[125]);
            FaceFeatures(playermodelmenu, 12, sLangfile[126]);
            FaceFeatures(playermodelmenu, 13, sLangfile[127]);
            FaceFeatures(playermodelmenu, 14, sLangfile[128]);
            FaceFeatures(playermodelmenu, 15, sLangfile[129]);
            FaceFeatures(playermodelmenu, 16, sLangfile[130]);
            FaceFeatures(playermodelmenu, 17, sLangfile[131]);
            FaceFeatures(playermodelmenu, 18, sLangfile[132]);
            FaceFeatures(playermodelmenu, 19, sLangfile[133]);
        }
        private void FaceFeatures(UIMenu XMen, int CompId, string sName)
        {
            LogginSyatem("FaceFeatures");

            List<dynamic> FeatVar = new List<dynamic>();

            float fOvers = fAceFeats[CompId];
            fOvers = fOvers * 100;
            int iAM = (int)Math.Ceiling(fOvers) + 99;
            CompileMenuTotalsFloats(FeatVar, -99, 99);
            var newitem = new UIMenuListItem(sName, FeatVar, 99);
            XMen.AddItem(newitem);
            newitem.Index = iAM;

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    float fOpal = (int)index -99 ;
                    fOpal = (fOpal / 100);
                    Function.Call(Hash._SET_PED_FACE_FEATURE, Game.Player.Character, CompId, fOpal);
                    fAceFeats[CompId] = fOpal;
                }
            };

            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
            //  void _SET_PED_FACE_FEATURE(Ped ped, int index, float scale) // 71A5C1DBA060049E
            //  Sets the various freemode face features, e.g.nose length, chin shape.Scale ranges from - 1.0 to 1.0.

            //Nose_Width                                0
            //Nose_Peak_Hight                           1
            //Nose_Peak_Lenght                          2
            //Nose_Bone_High                            3
            //Nose_Peak_Lowering                        4
            //Nose_Bone_Twist                           5
            //EyeBrown_High                             6
            //EyeBrown_Forward                          7
            //Cheeks_Bone_High                          8
            //Cheeks_Bone_Width                         9
            //Cheeks_Width                              10
            //Eyes_Openning                             11
            //Lips_Thickness                            12
            //Jaw_Bone_Width 'Bone size to sides        13
            //Jaw_Bone_Back_Lenght 'Bone size to back   14
            //Chimp_Bone_Lowering 'Go Down              15
            //Chimp_Bone_Lenght 'Go forward             16
            //Chimp_Bone_Width                          17
            //Chimp_Hole                                18
            //Neck_Thikness                             19
        }
        private void SaveMyPed(UIMenu XMen)
        {
            
                LogginSyatem("SaveMyPed");

            var playermodelmenu = new UIMenuItem(sLangfile[48], MyPedCollection[iPedNum].Name);
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    WriteSetXML();
                    WritePedSave(MyPedCollection[iPedNum].Name);
                    MyMenuPool.CloseAllMenus();
                    UI.ShowSubtitle("~g~" + sLangfile[50] + MyPedCollection[iPedNum].Name);
                }
            };
        }
        private void CreateNewPed(UIMenu XMen)
        {
            
                LogginSyatem("CreateNewPed");

            var playermodelmenu = new UIMenuItem(sLangfile[112] + sLangfile[48], sLangfile[49]);
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    string sPed = Game.GetUserInput(255);
                    if (sPed != "")
                    {
                        WriteSetXML();
                        WritePedSave(sPed);
                        UI.ShowSubtitle("~g~" + sLangfile[50] + sPed);
                        MyMenuPool.CloseAllMenus();
                    }
                }
            };
        }
        private void SetLocate(UIMenu XMen)
        {
            
                LogginSyatem("SetLocate");

            var playermodelmenu = new UIMenuItem(sLangfile[51], sLangfile[52]);
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (bRandLocate)
                playermodelmenu.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    bRandLocate = !bRandLocate;
                    if (bRandLocate)
                        playermodelmenu.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        playermodelmenu.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (bRandLocate && bLoadUpOnYacht)
                    {
                        bLoadUpOnYacht = false;
                        NSPMSetXml();
                    }
                    WriteSetXML();
                }
            };
        }
        private void SetChar(UIMenu XMen)
        {
            
                LogginSyatem("SetChar");

            var SetCharOpt = new UIMenuItem(sLangfile[53], sLangfile[54]);
            SetCharOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (bMainProtag)
                SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);          
            XMen.AddItem(SetCharOpt);

            var SetSVSaveOpt = new UIMenuItem(sLangfile[57], sLangfile[58]);
            SetSVSaveOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (bSavedPed)
                SetSVSaveOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetSVSaveOpt);


            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    bMainProtag = !bMainProtag;
                    if (bSavedPed && bMainProtag)
                    {
                        bSavedPed = false;
                        SetSVSaveOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    }
                    if (bMainProtag)
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == SetSVSaveOpt)
                {
                    if (MyPedCollection.Count > 0)
                    {
                        bSavedPed = !bSavedPed;
                        if (bSavedPed && bMainProtag)
                        {
                            bMainProtag = false;
                            SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        }
                        if (bSavedPed)
                            SetSVSaveOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                        else
                            SetSVSaveOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    }
                }
                WriteSetXML();
            };
        }
        private void DisRecord(UIMenu XMen)
        {
            
                LogginSyatem("DisRecord");

            var SetCharOpt = new UIMenuItem(sLangfile[55], sLangfile[56]);
            SetCharOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (bDisableRecord)
                SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetCharOpt);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    bDisableRecord = !bDisableRecord;
                    if (bDisableRecord)
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    WriteSetXML();
                }
            };
        }
        private void SeatBeltON(UIMenu XMen)
        {
            
                LogginSyatem("SeatBeltON");

            var SetCharOpt = new UIMenuItem(sLangfile[96], "");
            SetCharOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (Function.Call<bool>(Hash.GET_PED_CONFIG_FLAG, Game.Player.Character, 32, true))
            {
                SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                bBeltUp = true;
            }
            else
                bBeltUp = false;

            XMen.AddItem(SetCharOpt);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    bBeltUp = !bBeltUp;
                    PlayerBelter();
                    if (bBeltUp)
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    WriteSetXML();
                }
            };
        }
        private void AddBeachParty(UIMenu XMen)
        {
            
                LogginSyatem("AddBeachParty");

            var SetCharOpt = new UIMenuItem(sLangfile[97], "");
            SetCharOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (bAddBeachParty)
                SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetCharOpt);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    bAddBeachParty = !bAddBeachParty;
                    if (bAddBeachParty)
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    WriteSetXML();
                }
            };
        }
        private void SetLoadWeps(UIMenu XMen)
        {
            LogginSyatem("SetLoadWeps");

            var SetSVCharOpt = new UIMenuItem(sLangfile[59], sLangfile[60]);
            SetSVCharOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (bKeepWeapons)
                SetSVCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetSVCharOpt);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetSVCharOpt)
                {
                    bKeepWeapons = !bKeepWeapons;
                    if (bKeepWeapons)
                        SetSVCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetSVCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    WriteSetXML();
                }
            };
        }
        private void Re_WriteLoadout(UIMenu XMen)
        {
            LogginSyatem("Re_WriteLoadout");

            var SetCharOpt = new UIMenuItem(sLangfile[135], "");
            XMen.AddItem(SetCharOpt);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    MyMenuPool.CloseAllMenus();
                    GetWeaps();
                }
            };
        }
        private void SetMenuKey(UIMenu XMen)
        {
            LogginSyatem("SetMenuKey");

            var playermodelmenu = new UIMenuItem(sLangfile[61], sLangfile[62]);
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    MyMenuPool.CloseAllMenus();
                    UI.ShowSubtitle(sLangfile[63]);
                    bKeyFinder = true;
                }
            };
        }
        private void DeleteCurrentPed(UIMenu XMen)
        {
            
                LogginSyatem("DeleteCurrentPed");

            var playermodelmenu = new UIMenuItem(sLangfile[64], MyPedCollection[iPedNum].Name);
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu && iPedNum > 0)
                {
                    UI.ShowSubtitle("~g~" + sLangfile[65] + " " + MyPedCollection[iPedNum].Name);
                    MyPedCollection.RemoveAt(iPedNum);
                    SetPedSaveXML();
                    MyMenuPool.CloseAllMenus();
                }
            };
        }
        private void RanPedMenu(UIMenu XMen)
        {
            LogginSyatem("RanPedMenu");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, sLangfile[66]);
            //for (int i = 0; i < 1; i++) ;
            var Rand_01 = new UIMenuItem(sLangfile[67], "");
            var Rand_02 = new UIMenuItem(sLangfile[68], "");
            var Rand_03 = new UIMenuItem(sLangfile[69], "");
            var Rand_04 = new UIMenuItem(sLangfile[70], "");
            var Rand_05 = new UIMenuItem(sLangfile[71], "");
            var Rand_06 = new UIMenuItem(sLangfile[72], "");
            var Rand_07 = new UIMenuItem(sLangfile[73], "");
            var Rand_08 = new UIMenuItem(sLangfile[74], "");
            var Rand_09 = new UIMenuItem(sLangfile[75], "");
            var Rand_10 = new UIMenuItem(sLangfile[76], "");
            var Rand_11 = new UIMenuItem(sLangfile[77], "");
            var Rand_12 = new UIMenuItem(sLangfile[78], "");
            var Rand_13 = new UIMenuItem(sLangfile[79], "");
            var Rand_14 = new UIMenuItem(sLangfile[80], "");
            var Rand_15 = new UIMenuItem(sLangfile[81], "");
            var Rand_16 = new UIMenuItem(sLangfile[82], "");
            var Rand_17 = new UIMenuItem(sLangfile[83], "");
            var Rand_18 = new UIMenuItem(sLangfile[84], "");
            var Rand_19 = new UIMenuItem(sLangfile[85], "");
            var Rand_20 = new UIMenuItem(sLangfile[86], "");
            var Rand_21 = new UIMenuItem(sLangfile[87], "");
            var Rand_22 = new UIMenuItem(sLangfile[93], "");
            var Rand_23 = new UIMenuItem(sLangfile[94], "");
            var Rand_24 = new UIMenuItem(sLangfile[95], "");

            playermodelmenu.AddItem(Rand_01);
            playermodelmenu.AddItem(Rand_02);
            playermodelmenu.AddItem(Rand_03);
            playermodelmenu.AddItem(Rand_04);
            playermodelmenu.AddItem(Rand_05);
            playermodelmenu.AddItem(Rand_06);
            playermodelmenu.AddItem(Rand_07);
            playermodelmenu.AddItem(Rand_08);
            playermodelmenu.AddItem(Rand_09);
            playermodelmenu.AddItem(Rand_10);
            playermodelmenu.AddItem(Rand_11);
            playermodelmenu.AddItem(Rand_12);
            playermodelmenu.AddItem(Rand_13);
            playermodelmenu.AddItem(Rand_14);
            playermodelmenu.AddItem(Rand_15);
            playermodelmenu.AddItem(Rand_16);
            playermodelmenu.AddItem(Rand_17);
            playermodelmenu.AddItem(Rand_18);
            playermodelmenu.AddItem(Rand_19);
            playermodelmenu.AddItem(Rand_20);
            playermodelmenu.AddItem(Rand_21);
            playermodelmenu.AddItem(Rand_22);
            playermodelmenu.AddItem(Rand_23);
            playermodelmenu.AddItem(Rand_24);

            playermodelmenu.OnItemSelect += (sender, item, index) =>
            {
                MyMenuPool.CloseAllMenus();
                AddTatBase.Clear();
                AddTatName.Clear();
                bMenuOpen = false;
                if (item == Rand_01)
                    StartTheMod(1, false);
                else if (item == Rand_02)
                    StartTheMod(2, false);
                else if (item == Rand_03)
                    StartTheMod(3, false);
                else if (item == Rand_04)
                    StartTheMod(4, false);
                else if (item == Rand_05)
                    StartTheMod(5, false);
                else if (item == Rand_06)
                    StartTheMod(6, false);
                else if (item == Rand_07)
                    StartTheMod(7, false);
                else if (item == Rand_08)
                    StartTheMod(8, false);
                else if (item == Rand_09)
                    StartTheMod(9, false);
                else if (item == Rand_10)
                    StartTheMod(10, false);
                else if (item == Rand_11)
                    StartTheMod(11, false);
                else if (item == Rand_12)
                    StartTheMod(12, false);
                else if (item == Rand_13)
                    StartTheMod(13, false);
                else if (item == Rand_14)
                    StartTheMod(14, false);
                else if (item == Rand_15)
                    StartTheMod(15, false);
                else if (item == Rand_16)
                    StartTheMod(16, false);
                else if (item == Rand_17)
                    StartTheMod(17, false);
                else if (item == Rand_18)
                    StartTheMod(18, false);
                else if (item == Rand_19)
                    StartTheMod(19, false);
                else if (item == Rand_20)
                    StartTheMod(20, false);
                else if (item == Rand_21)
                    StartTheMod(21, false);
                else if (item == Rand_22)
                    StartTheMod(22, false);
                else if (item == Rand_23)
                    StartTheMod(23, false);
                else if (item == Rand_24)
                    StartTheMod(24, false);
            };
        }
        private void TopCornerUI(string sText)
        {
            Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, sText);
            Function.Call(Hash._0x238FFE5C7B0498A6, 0, 0, 1, -1);
        }
        private void OnTick(object sender, EventArgs e)
        {
            if (bStart)
            {
                if (!Game.IsLoading)
                {
                    LoadUp();
                    bStart = false;
                }
            }
            else if (bMenuOpen)
            {
                if (MyMenuPool.IsAnyMenuOpen())
                    MyMenuPool.ProcessMenus();
                else
                {
                    iOverlay.Clear();
                    iOverlayColour.Clear();
                    fOverlayOpc.Clear();
                    AddTatBase.Clear();
                    AddTatName.Clear();
                    bMenuOpen = false;
                }
            }
            else if (bWeaponFault)
            {
                if (!Game.IsLoading)
                {
                    ReturnWeaps();
                    bWeaponFault = false;
                }
            }
            else
            {
                if (!bDead)
                {
                    if (bMenyooZZ)
                    {
                        if (Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED))
                        {
                            if (bAllowControl)
                                CleanUpMess();
                            bDead = true;
                            DeathArrestCont(false);
                        }
                        else if (Function.Call<bool>(Hash.IS_PLAYER_DEAD))
                        {
                            if (bAllowControl)
                                CleanUpMess();
                            bDead = true;
                            DeathArrestCont(true);
                        }
                    }
                    else
                    {
                        if (Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Trevor)
                        {
                            if (Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED) || Function.Call<bool>(Hash.IS_PLAYER_DEAD))
                            {
                                if (bInYankton)
                                    Yankton(false);
                                else if (bInCayoPerico)
                                    CayoPerico(false);
                            }
                            else if (Function.Call<bool>(Hash.HAS_SCRIPT_LOADED, "director_mode"))
                            {
                                Script.Wait(500);
                                Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "director_mode");
                            }
                        }
                        else
                        {
                            if (Function.Call<bool>(Hash.HAS_SCRIPT_LOADED, "director_mode"))
                            {
                                if (Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED))
                                {
                                    if (bAllowControl)
                                        CleanUpMess();

                                    Game.FadeScreenOut(1);
                                    ClearDASCript(false);
                                }
                                else if (Function.Call<bool>(Hash.IS_PLAYER_DEAD))
                                {
                                    if (bAllowControl)
                                        CleanUpMess();

                                    Game.FadeScreenOut(1);
                                    ClearDASCript(true);
                                }
                            }
                            else
                            {
                                Script.Wait(500);
                                Function.Call(Hash.REQUEST_SCRIPT, "director_mode");
                            }
                        }
                    }
                }

                if (bAllowControl)
                {
                    if (iPostAction == 3)
                    {
                        if (VehList[VehList.Count() - 1].IsSeatFree(VehicleSeat.Driver))
                        {
                            if (Game.Player.Character.Position.DistanceTo(VehList[VehList.Count() - 1].Position) > 300.00f)
                            {
                                CleanUpMess();
                                bAllowControl = false;
                            }
                            else
                            {
                                Script.Wait(5000);
                                CleanUpMess();
                                bAllowControl = false;
                            }
                        }
                        else
                        {
                            if (Game.Player.Character.Position.DistanceTo(VehList[VehList.Count() - 1].Position) > 300.00f)
                            {
                                CleanUpMess();
                                bAllowControl = false;
                            }
                            else if (VehList[VehList.Count() - 1].GetPedOnSeat(VehicleSeat.Driver).IsDead)
                            {
                                Script.Wait(5000);
                                CleanUpMess();
                                bAllowControl = false;
                            }
                        }
                    }
                    else if (iPostAction == 6)
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            if (iActionTime < Game.GameTime)
                                HeliFlyYou();
                        }
                        else
                        {
                            CleanUpMess();
                            bAllowControl = false;
                        }
                    }
                    else if (iPostAction == 8)
                    {
                        if (iWait4 < Game.GameTime)
                        {
                            iPostAction = 0;
                            bAllowControl = false;
                            CleanUpMess();
                        }
                    }
                    else
                    {
                        TopCornerUI(sLangfile[92]);
                        if (Game.IsControlPressed(2, GTA.Control.VehicleExit))
                        {
                            if (iWait4 < Game.GameTime)
                            {
                                CleanUpMess();
                                bAllowControl = false;
                            }
                        }
                        else
                            iWait4 = Game.GameTime + 1000;


                        if (iPostAction == 4)
                        {
                            if (iActionTime < Game.GameTime)
                                YouJog();
                        }
                        else if (iPostAction == 5)
                        {
                            if (iActionTime < Game.GameTime)
                                YouDrive();
                        }
                        else if (iPostAction == 7)
                        {
                            if (iActionTime < Game.GameTime)
                                YouHeliTo();
                        }
                        else if (Game.Player.Character.IsInVehicle())
                        {
                            if (Game.Player.Character.CurrentVehicle.ClassType == VehicleClass.Planes)
                            {
                                if (Game.Player.Character.CurrentVehicle.LandingGear == VehicleLandingGear.Deployed)
                                {
                                    if (Game.Player.Character.CurrentVehicle.IsInAir)
                                        Game.Player.Character.CurrentVehicle.LandingGear = VehicleLandingGear.Closing;

                                }
                            }
                        }
                    }
                }

                if (bDisableRecord)
                {
                    if (Function.Call<bool>(Hash._IS_RECORDING))
                        Function.Call(Hash._STOP_RECORDING_AND_DISCARD_CLIP);
                }

                if (bDontStopMe)
                    InRestrictedArea();
                else if (bOpenDoors)
                    OpeningDoors(PeskyDoors[0], PeskyDoors[1], PeskyDoors[2]);
            }
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (bLoaded)
            {
                if (bKeyFinder)
                {
                    KBuild = e.KeyCode;
                    UI.ShowSubtitle("~r~" + KBuild + "' ~w~" + sLangfile[90]);
                    WriteSetXML();
                    bKeyFinder = false;
                }
                else if (e.KeyCode == KBuild)
                {
                    Game.FadeScreenIn(1);
                    if (bAllowControl)
                        UI.Notify(sLangfile[89]);
                    else
                    {
                        bMenuOpen = true;
                        PedMenuMain();
                    }
                }
            }
        }
    }
}
