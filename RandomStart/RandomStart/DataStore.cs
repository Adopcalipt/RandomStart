using GTA;
using GTA.Math;
using GTA.Native;
using RandomStart.Classes;
using System.Collections.Generic;
using System.IO;

namespace RandomStart
{
    public class DataStore
    {
        public static int iPath { get; set; }
        public static int iWait4 { get; set; }
        public static int iUnlock { get; set; }
        public static int iGrouping { get; set; }
        public static int iPostAction { get; set; }
        public static int iActionTime { get; set; }
        public static int iCurrentPed { get; set; }
        public static int iAmModelHash { get; set; }

        public static int GP_Player { get; set; }
        public static int GP_Friend { get; set; }
        public static int GP_Attack { get; set; }

        public static bool bStart { get; set; }

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


        public static string sVersion { get; set; }
        public static string sFirstName { get; set; }
        public static string sMainChar { get; set; }
        public static string sFunChar01 { get; set; }
        public static string sFunChar02 { get; set; }

        public static string sBeeLogs { get; set; }
        public static string sSettings { get; set; }
        public static string sWeapsFile { get; set; }
        public static string sNamesFile { get; set; }
        public static string sRandFile { get; set; }
        public static string sSavedFile { get; set; }
        public static string sRandLanguage { get; set; }

        public static System.Media.SoundPlayer Ahhhhhh { get; set; }

        public static string sExitAn_01 { get; set; }
        public static string sExitAn_02 { get; set; }

        public static List<float> fHeads { get; set; }

        public static List<string> sWeapList { get; set; }
        public static List<string> sAddsList { get; set; }
        public static List<string> sLangNames { get; set; }
        public static List<string> sTatBase { get; set; }
        public static List<string> sTatName { get; set; }
        public static List<string> ThemVoices { get; set; }

        public static List<Ped> PeddyList { get; set; }
        public static List<Ped> PedParty { get; set; }
        public static List<Prop> PropList { get; set; }
        public static List<Vector3> RanLoc_01 { get; set; }
        public static List<Vector3> PeskyDoors { get; set; }
        public static List<Vehicle> VehList { get; set; }
        public static List<Weather> WetherBe { get; set; }
        public static List<VehicleSeat> Vseats { get; set; }
        public static List<NewClothBank> MyPedCollection { get; set; }

        public static Vector3 vPedTarget { get; set; }
        public static Vector3 vPlayerTarget { get; set; }
        public static Vector3 vAreaRest { get; set; }
        public static Vector3 vHell { get; set; }
        public static Vector3 vHeaven { get; set; }

        public static Ped pPilot { get; set; }

        public static Vehicle Shoaf { get; set; }
        public static Vehicle RideThis { get; set; }
        public static Vehicle PrisEscape { get; set; }

        public static Weather DeadWeather { get; set; }
        public static double DeadTime { get; set; }

        public static NewClothBank NewBank { get; set; }
        public static ScriptSettings MenyooTest { get; set; }

        public static NameList MyNames { get; set; } 

        public static LangXML MyLang { get; set; }

        public static SettingsXML MySettingsXML { get; set; }

        public static void LoadUpDataStore()
        {
            bStart = false;
            sBeeLogs = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RSLog.txt";

            if (File.Exists(DataStore.sBeeLogs))
                File.Delete(DataStore.sBeeLogs);

            iPath = 0;
            iWait4 = 0;
            iUnlock = 0;
            iGrouping = 0;
            iPostAction = 0;
            iActionTime = 0;
            iCurrentPed = 0;
            iAmModelHash = 0;

            GP_Player = Game.Player.Character.RelationshipGroup;
            GP_Friend = World.AddRelationshipGroup("FriendNPCs");
            GP_Attack = World.AddRelationshipGroup("AttackNPCs");

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


            sVersion = "2.7";
            sFirstName = "PlayerX";
            sMainChar = "player_zero";
            sFunChar01 = "player_one";
            sFunChar02 = "player_two";
       
            sSettings = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RSettings.Xml";
            sWeapsFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/AddonWeaponList.Xml";
            sNamesFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/NamingList.Xml";
            sRandFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RSRNum.Xml";
            sSavedFile = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/SavedPedsList.Xml";
            sRandLanguage = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language";

            Ahhhhhh = new System.Media.SoundPlayer("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/heavenly_choir.wav");
            Ahhhhhh.Load();

            sExitAn_01 = "";
            sExitAn_02 = "";

            bLoadUpOnYacht = NSPMYachtTest();

            fHeads = new List<float>();

            sWeapList = WeapsList();
            sAddsList = AddonsList();
            sLangNames = LangText();
            sTatBase = new List<string>();
            sTatName = new List<string>();
            ThemVoices = IHearVoices();

            PeddyList = new List<Ped>();
            PedParty = new List<Ped>();
            PropList = new List<Prop>();
            RanLoc_01 = new List<Vector3>();
            PeskyDoors = new List<Vector3>();
            VehList = new List<Vehicle>();
            WetherBe = AllWeathers();
            Vseats = SeatList();
            MyPedCollection = new List<NewClothBank>();

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

            NewBank = null;

            MySettingsXML = LoadSetXML();

            MyLang = FindaLang();

            if (bNagg)
            {
                UI.Notify(MyLang.Langfile[0]);
                bNagg = false;
            }

            XmlReadWrite.SaveSetMain(MySettingsXML, sSettings);

            LoadUp();

            bStart = true;
            LoggerLight.Loggers("DataStore.bStart == " + bStart);
        }
        public static bool NSPMYachtTest()
        {
            LoggerLight.Loggers("DataStore.NSPMYachtTest");

            string sMe = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Settings.Xml";
            string sLocate = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM";

            if (Directory.Exists(sLocate))
            {
                if (File.Exists(sMe))
                {
                    XmlSetings MyNSPM = XmlReadWrite.LoadNSPM(sMe);
                    if (MyNSPM.ModVersion > 34900)
                    {
                        if (MyNSPM.StartOnYAcht)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static List<Weather> AllWeathers()
        {
            LoggerLight.Loggers("DataStore.AllWeathers");

            List<Weather> Wetter = new List<Weather>();

            Wetter.Add(Weather.ExtraSunny);
            Wetter.Add(Weather.Clear);
            Wetter.Add(Weather.Clouds);
            Wetter.Add(Weather.Smog);
            Wetter.Add(Weather.Foggy);
            Wetter.Add(Weather.Overcast);
            Wetter.Add(Weather.Raining);
            Wetter.Add(Weather.ThunderStorm);
            Wetter.Add(Weather.Clearing);
            Wetter.Add(Weather.Neutral);

            return Wetter;
        }
        public static List<string> IHearVoices()
        {
            LoggerLight.Loggers("DataStore.IHearVoices");//Voice list was taken from; https://pastebin.com/vDWd8RYx
           
            List<string> Voices = new List<string>();

            Voices.Add("ABIGAIL"); //073DD899"); //121493657"); //121493657
            Voices.Add("AFFLUENT_SUBURBAN_FEMALE_01"); //FF4D4698"); //4283254424"); //Voices.Add("11712872
            Voices.Add("AFFLUENT_SUBURBAN_FEMALE_02"); //12836D04"); //310603012"); //310603012
            Voices.Add("AFFLUENT_SUBURBAN_FEMALE_03"); //DC6000BE"); //3697279166"); //Voices.Add("597688130
            Voices.Add("AFFLUENT_SUBURBAN_FEMALE_04"); //EE1AA433"); //3994723379"); //Voices.Add("300243917
            Voices.Add("AFFLUENT_SUBURBAN_FEMALE_05"); //A47190DE"); //2758906078"); //Voices.Add("1536061218
            Voices.Add("AFFLUENT_SUBURBAN_FEMALE_06"); //B62C3453"); //3056350291"); //Voices.Add("1238617005
            Voices.Add("AFFLUENT_SUBURBAN_MALE_01"); //85FA12FF"); //2247758591"); //Voices.Add("2047208705
            Voices.Add("AFFLUENT_SUBURBAN_MALE_02"); //A4394F7D"); //2755219325"); //Voices.Add("1539747971
            Voices.Add("AGENCYJANITOR"); //5288D370"); //1384698736"); //1384698736
            Voices.Add("AIRCRAFT_WARNING_FEMALE_01"); //85A08F9C"); //2241892252"); //Voices.Add("2053075044
            Voices.Add("AIRCRAFT_WARNING_MALE_01"); //A65A6402"); //2790941698"); //Voices.Add("1504025598
            Voices.Add("AIRDUMMER"); //798D01B5"); //2039284149"); //2039284149
            Voices.Add("AIRGUITARIST"); //A1D7351A"); //2715235610"); //Voices.Add("1579731686
            Voices.Add("AIRPIANIST"); //B98B1513"); //3112899859"); //Voices.Add("1182067437
            Voices.Add("AIRPORT_PA_FEMALE"); //80D0944F"); //2161153103"); //Voices.Add("2133814193
            Voices.Add("AIRPORT_PA_MALE"); //4BA3E2F7"); //1269031671"); //1269031671
            Voices.Add("ALIENS"); //EB86F769"); //3951490921"); //Voices.Add("343476375
            Voices.Add("AMANDA_DRUNK"); //5C0B144D"); //1544229965"); //1544229965
            Voices.Add("AMANDA_NORMAL"); //EC6C9072"); //3966537842"); //Voices.Add("328429454
            Voices.Add("AMMUCITY"); //D4503291"); //3562025617"); //Voices.Add("732941679
            Voices.Add("ANDY_MOON"); //B51D1921"); //3038583073"); //Voices.Add("1256384223
            Voices.Add("ANTON"); //ED9B229C"); //3986367132"); //Voices.Add("308600164
            Voices.Add("APT_BEAST"); //14F37BC9"); //351501257"); //351501257
            Voices.Add("AVI"); //EF7A6BDE"); //4017777630"); //Voices.Add("277189666
            Voices.Add("A_F_M_BEACH_01_WHITE_FULL_01"); //6B996380"); //1805214592"); //1805214592
            Voices.Add("A_F_M_BEACH_01_WHITE_MINI_01"); //139EA948"); //329165128"); //329165128
            Voices.Add("A_F_M_BEVHILLS_01_WHITE_FULL_01"); //00A8641D"); //11035677"); //11035677
            Voices.Add("A_F_M_BEVHILLS_01_WHITE_MINI_01"); //3E0995AE"); //1040815534"); //1040815534
            Voices.Add("A_F_M_BEVHILLS_01_WHITE_MINI_02"); //4ABAAF10"); //1253748496"); //1253748496
            Voices.Add("A_F_M_BEVHILLS_02_BLACK_FULL_01"); //8455F5F0"); //2220226032"); //Voices.Add("2074741264
            Voices.Add("A_F_M_BEVHILLS_02_BLACK_MINI_01"); //466B8D2A"); //1181453610"); //1181453610
            Voices.Add("A_F_M_BEVHILLS_02_WHITE_FULL_01"); //B228C501"); //2989016321"); //Voices.Add("1305950975
            Voices.Add("A_F_M_BEVHILLS_02_WHITE_FULL_02"); //CC76F99D"); //3430349213"); //Voices.Add("864618083
            Voices.Add("A_F_M_BEVHILLS_02_WHITE_MINI_01"); //3FD63057"); //1071001687"); //1071001687
            Voices.Add("A_F_M_BODYBUILD_01_BLACK_FULL_01"); //4B0E89BF"); //1259243967"); //1259243967
            Voices.Add("A_F_M_BODYBUILD_01_BLACK_MINI_01"); //23D791B0"); //601330096"); //601330096
            Voices.Add("A_F_M_BODYBUILD_01_WHITE_FULL_01"); //8773ADD6"); //2272505302"); //Voices.Add("2022461994
            Voices.Add("A_F_M_BODYBUILD_01_WHITE_MINI_01"); //B902AA3A"); //3103959610"); //Voices.Add("1191007686
            Voices.Add("A_F_M_BUSINESS_02_WHITE_MINI_01"); //9C4AD53A"); //2622149946"); //Voices.Add("1672817350
            Voices.Add("A_F_M_DOWNTOWN_01_BLACK_FULL_01"); //0AA25C8F"); //178412687"); //178412687
            Voices.Add("A_F_M_EASTSA_01_LATINO_FULL_01"); //0ACC23F9"); //181150713"); //181150713
            Voices.Add("A_F_M_EASTSA_01_LATINO_MINI_01"); //CE348715"); //3459548949"); //Voices.Add("835418347
            Voices.Add("A_F_M_EASTSA_02_LATINO_FULL_01"); //0AA30167"); //178454887"); //178454887
            Voices.Add("A_F_M_EASTSA_02_LATINO_MINI_01"); //721CC9FF"); //1914489343"); //1914489343
            Voices.Add("A_F_M_FATWHITE_01_WHITE_FULL_01"); //D2158D79"); //3524627833"); //Voices.Add("770339463
            Voices.Add("A_F_M_FATWHITE_01_WHITE_MINI_01"); //59E595EB"); //1508218347"); //1508218347
            Voices.Add("A_F_M_KTOWN_01_KOREAN_FULL_01"); //D77777E6"); //3614930918"); //Voices.Add("680036378
            Voices.Add("A_F_M_KTOWN_01_KOREAN_MINI_01"); //AF6FB9B1"); //2943334833"); //Voices.Add("1351632463
            Voices.Add("A_F_M_KTOWN_02_CHINESE_MINI_01"); //C533C983"); //3308505475"); //Voices.Add("986461821
            Voices.Add("A_F_M_KTOWN_02_KOREAN_FULL_01"); //D8CD3773"); //3637327731"); //Voices.Add("657639565
            Voices.Add("A_F_M_SALTON_01_WHITE_FULL_01"); //89DA8A2E"); //2312800814"); //Voices.Add("1982166482
            Voices.Add("A_F_M_SALTON_01_WHITE_FULL_02"); //9C052E83"); //2617585283"); //Voices.Add("1677382013
            Voices.Add("A_F_M_SALTON_01_WHITE_FULL_03"); //A66E4355"); //2792244053"); //Voices.Add("1502723243
            Voices.Add("A_F_M_SALTON_01_WHITE_MINI_01"); //8701705E"); //2265018462"); //Voices.Add("2029948834
            Voices.Add("A_F_M_SALTON_01_WHITE_MINI_02"); //7DC35DE2"); //2109955554"); //2109955554
            Voices.Add("A_F_M_SALTON_01_WHITE_MINI_03"); //6675AF47"); //1718988615"); //1718988615
            Voices.Add("A_F_M_SKIDROW_01_BLACK_FULL_01"); //A7C0DE51"); //2814434897"); //Voices.Add("1480532399
            Voices.Add("A_F_M_SKIDROW_01_BLACK_MINI_01"); //443E6FBE"); //1144942526"); //1144942526
            Voices.Add("A_F_M_SKIDROW_01_WHITE_FULL_01"); //F8F30014"); //4176674836"); //Voices.Add("118292460
            Voices.Add("A_F_M_SKIDROW_01_WHITE_MINI_01"); //705684C4"); //1884718276"); //1884718276
            Voices.Add("A_F_M_SOUCENT_01_BLACK_FULL_01"); //4E0DA806"); //1309517830"); //1309517830
            Voices.Add("A_F_M_SOUCENT_02_BLACK_FULL_01"); //C725E5CC"); //3341149644"); //Voices.Add("953817652
            Voices.Add("A_F_M_TOURIST_01_WHITE_MINI_01"); //25365382"); //624317314"); //624317314
            Voices.Add("A_F_M_TRAMPBEAC_01_BLACK_FULL_01"); //F091AF03"); //4036079363"); //Voices.Add("258887933
            Voices.Add("A_F_M_TRAMPBEAC_01_BLACK_MINI_01"); //DE24211D"); //3726909725"); //Voices.Add("568057571
            Voices.Add("A_F_M_TRAMPBEAC_01_WHITE_FULL_01"); //8D34DFCC"); //2369052620"); //Voices.Add("1925914676
            Voices.Add("A_F_M_TRAMP_01_WHITE_FULL_01"); //D05841FA"); //3495444986"); //Voices.Add("799522310
            Voices.Add("A_F_M_TRAMP_01_WHITE_MINI_01"); //55CE3CCC"); //1439579340"); //1439579340
            Voices.Add("A_F_O_GENSTREET_01_WHITE_MINI_01"); //482D1EC8"); //1210916552"); //1210916552
            Voices.Add("A_F_O_INDIAN_01_INDIAN_MINI_01"); //8755E8CA"); //2270554314"); //Voices.Add("2024412982
            Voices.Add("A_F_O_KTOWN_01_KOREAN_FULL_01"); //DBE7871F"); //3689383711"); //Voices.Add("605583585
            Voices.Add("A_F_O_KTOWN_01_KOREAN_MINI_01"); //F94EAEEB"); //4182683371"); //Voices.Add("112283925
            Voices.Add("A_F_O_SALTON_01_WHITE_FULL_01"); //F79EEC05"); //4154387461"); //Voices.Add("140579835
            Voices.Add("A_F_O_SALTON_01_WHITE_MINI_01"); //FCBC6F1F"); //4240207647"); //Voices.Add("54759649
            Voices.Add("A_F_O_SOUCENT_01_BLACK_FULL_01"); //3439D3C2"); //876204994"); //876204994
            Voices.Add("A_F_O_SOUCENT_02_BLACK_FULL_01"); //F27CEF94"); //4068274068"); //Voices.Add("226693228
            Voices.Add("A_F_Y_BEACH_01_BLACK_MINI_01"); //4B79AF9D"); //1266266013"); //1266266013
            Voices.Add("A_F_Y_BEACH_01_WHITE_FULL_01"); //2BCAB282"); //734704258"); //734704258
            Voices.Add("A_F_Y_BEACH_01_WHITE_MINI_01"); //13609A3C"); //325098044"); //325098044
            Voices.Add("A_F_Y_BEACH_BLACK_FULL_01"); //0422CC2C"); //69389356"); //69389356
            Voices.Add("A_F_Y_BEVHILLS_01_WHITE_FULL_01"); //E7099D21"); //3876166945"); //Voices.Add("418800351
            Voices.Add("A_F_Y_BEVHILLS_01_WHITE_MINI_01"); //D2C133B9"); //3535877049"); //Voices.Add("759090247
            Voices.Add("A_F_Y_BEVHILLS_02_WHITE_FULL_01"); //F700AB54"); //4144016212"); //Voices.Add("150951084
            Voices.Add("A_F_Y_BEVHILLS_02_WHITE_MINI_01"); //AA4B2212"); //2857050642"); //Voices.Add("1437916654
            Voices.Add("A_F_Y_BEVHILLS_02_WHITE_MINI_02"); //7E1BC9B0"); //2115750320"); //2115750320
            Voices.Add("A_F_Y_BEVHILLS_03_WHITE_FULL_01"); //8558FF3F"); //2237202239"); //Voices.Add("2057765057
            Voices.Add("A_F_Y_BEVHILLS_03_WHITE_MINI_01"); //D17E6765"); //3514722149"); //Voices.Add("780245147
            Voices.Add("A_F_Y_BEVHILLS_04_WHITE_FULL_01"); //B91127EB"); //3104909291"); //Voices.Add("1190058005
            Voices.Add("A_F_Y_BEVHILLS_04_WHITE_MINI_01"); //9A251230"); //2586120752"); //Voices.Add("1708846544
            Voices.Add("A_F_Y_BUSINESS_01_WHITE_FULL_01"); //A3D0C7CD"); //2748368845"); //Voices.Add("1546598451
            Voices.Add("A_F_Y_BUSINESS_01_WHITE_MINI_01"); //87816F13"); //2273406739"); //Voices.Add("2021560557
            Voices.Add("A_F_Y_BUSINESS_01_WHITE_MINI_02"); //188B9125"); //411799845"); //411799845
            Voices.Add("A_F_Y_BUSINESS_02_WHITE_FULL_01"); //4CC300E2"); //1287848162"); //1287848162
            Voices.Add("A_F_Y_BUSINESS_02_WHITE_MINI_01"); //94B7537B"); //2495042427"); //Voices.Add("1799924869
            Voices.Add("A_F_Y_BUSINESS_03_CHINESE_FULL_01"); //7D9DD020"); //2107494432"); //2107494432
            Voices.Add("A_F_Y_BUSINESS_03_CHINESE_MINI_01"); //D41AE44A"); //3558532170"); //Voices.Add("736435126
            Voices.Add("A_F_Y_BUSINESS_03_LATINO_FULL_01"); //420377DE"); //1107523550"); //1107523550
            Voices.Add("A_F_Y_BUSINESS_04_BLACK_FULL_01"); //26D1F656"); //651294294"); //651294294
            Voices.Add("A_F_Y_BUSINESS_04_BLACK_MINI_01"); //97D8B312"); //2547561234"); //Voices.Add("1747406062
            Voices.Add("A_F_Y_BUSINESS_04_WHITE_MINI_01"); //BE6FAE2C"); //3194990124"); //Voices.Add("1099977172
            Voices.Add("A_F_Y_EASTSA_01_LATINO_FULL_01"); //3CB71B34"); //1018633012"); //1018633012
            Voices.Add("A_F_Y_EASTSA_01_LATINO_MINI_01"); //D3A7F87F"); //3551000703"); //Voices.Add("743966593
            Voices.Add("A_F_Y_EASTSA_02_WHITE_FULL_01"); //3DDC0236"); //1037828662"); //1037828662
            Voices.Add("A_F_Y_EASTSA_03_LATINO_FULL_01"); //C801D0E0"); //3355562208"); //Voices.Add("939405088
            Voices.Add("A_F_Y_EASTSA_03_LATINO_MINI_01"); //38E9E4FC"); //954852604"); //954852604
            Voices.Add("A_F_Y_EPSILON_01_WHITE_MINI_01"); //1B66BF81"); //459718529"); //459718529
            Voices.Add("A_F_Y_FITNESS_01_WHITE_FULL_01"); //7639B49D"); //1983493277"); //1983493277
            Voices.Add("A_F_Y_FITNESS_01_WHITE_MINI_01"); //E2D732E6"); //3805754086"); //Voices.Add("489213210
            Voices.Add("A_F_Y_FITNESS_02_BLACK_FULL_01"); //851B5376"); //2233160566"); //Voices.Add("2061806730
            Voices.Add("A_F_Y_FITNESS_02_BLACK_MINI_01"); //27C40170"); //667156848"); //667156848
            Voices.Add("A_F_Y_FITNESS_02_WHITE_FULL_01"); //BF9CB8C8"); //3214719176"); //Voices.Add("1080248120
            Voices.Add("A_F_Y_FITNESS_02_WHITE_MINI_01"); //A105E3A0"); //2701517728"); //Voices.Add("1593449568
            Voices.Add("A_F_Y_Golfer_01_WHITE_FULL_01"); //B81316C5"); //3088258757"); //Voices.Add("1206708539
            Voices.Add("A_F_Y_Golfer_01_WHITE_MINI_01"); //5F5BFB44"); //1599863620"); //1599863620
            Voices.Add("A_F_Y_HIKER_01_WHITE_FULL_01"); //BB0A674E"); //3138021198"); //Voices.Add("1156946098
            Voices.Add("A_F_Y_HIKER_01_WHITE_MINI_01"); //C8CAFB5E"); //3368745822"); //Voices.Add("926221474
            Voices.Add("A_F_Y_HIPSTER_01_WHITE_FULL_01"); //A24D58EA"); //2722978026"); //Voices.Add("1571989270
            Voices.Add("A_F_Y_HIPSTER_01_WHITE_MINI_01"); //92D2202A"); //2463244330"); //Voices.Add("1831722966
            Voices.Add("A_F_Y_HIPSTER_02_WHITE_FULL_01"); //83EA9D79"); //2213191033"); //Voices.Add("2081776263
            Voices.Add("A_F_Y_HIPSTER_02_WHITE_MINI_01"); //41543F56"); //1096040278"); //1096040278
            Voices.Add("A_F_Y_HIPSTER_02_WHITE_MINI_02"); //2F6F9B8D"); //795843469"); //795843469
            Voices.Add("A_F_Y_HIPSTER_03_WHITE_FULL_01"); //ADED3C9F"); //2918005919"); //Voices.Add("1376961377
            Voices.Add("A_F_Y_HIPSTER_03_WHITE_MINI_01"); //F824C1C7"); //4163158471"); //Voices.Add("131808825
            Voices.Add("A_F_Y_HIPSTER_03_WHITE_MINI_02"); //E95A2432"); //3914998834"); //Voices.Add("379968462
            Voices.Add("A_F_Y_HIPSTER_04_WHITE_FULL_01"); //3141C876"); //826394742"); //826394742
            Voices.Add("A_F_Y_HIPSTER_04_WHITE_MINI_01"); //6B08FBA6"); //1795750822"); //1795750822
            Voices.Add("A_F_Y_HIPSTER_04_WHITE_MINI_02"); //3BDF1D53"); //1004477779"); //1004477779
            Voices.Add("A_F_Y_INDIAN_01_INDIAN_MINI_01"); //AD0551E1"); //2902807009"); //Voices.Add("1392160287
            Voices.Add("A_F_Y_INDIAN_01_INDIAN_MINI_02"); //BF49F66A"); //3209295466"); //Voices.Add("1085671830
            Voices.Add("A_F_Y_ROLLERCOASTER_01_MINI_01"); //5470D900"); //1416681728"); //1416681728
            Voices.Add("A_F_Y_ROLLERCOASTER_01_MINI_02"); //4295B54A"); //1117107530"); //1117107530
            Voices.Add("A_F_Y_ROLLERCOASTER_01_MINI_03"); //C2393483"); //3258528899"); //Voices.Add("1036438397
            Voices.Add("A_F_Y_ROLLERCOASTER_01_MINI_04"); //B015903C"); //2954203196"); //Voices.Add("1340764100
            Voices.Add("A_F_Y_SKATER_01_WHITE_FULL_01"); //52D929F1"); //1389963761"); //1389963761
            Voices.Add("A_F_Y_SKATER_01_WHITE_MINI_01"); //6E55B81F"); //1851111455"); //1851111455
            Voices.Add("A_F_Y_SOUCENT_01_BLACK_FULL_01"); //A0FDDA5B"); //2700991067"); //Voices.Add("1593976229
            Voices.Add("A_F_Y_SOUCENT_02_BLACK_FULL_01"); //DB96A76C"); //3684083564"); //Voices.Add("610883732
            Voices.Add("A_F_Y_SOUCENT_03_LATINO_FULL_01"); //AA71DF24"); //2859589412"); //Voices.Add("1435377884
            Voices.Add("A_F_Y_SOUCENT_03_LATINO_MINI_01"); //656710BE"); //1701253310"); //1701253310
            Voices.Add("A_F_Y_TENNIS_01_BLACK_MINI_01"); //B602DF7D"); //3053641597"); //Voices.Add("1241325699
            Voices.Add("A_F_Y_TENNIS_01_WHITE_MINI_01"); //434E2C2C"); //1129196588"); //1129196588
            Voices.Add("A_F_Y_TOURIST_01_BLACK_FULL_01"); //ECA3EB4D"); //3970165581"); //Voices.Add("324801715
            Voices.Add("A_F_Y_TOURIST_01_BLACK_MINI_01"); //A3713FCD"); //2742108109"); //Voices.Add("1552859187
            Voices.Add("A_F_Y_TOURIST_01_LATINO_FULL_01"); //D6F2B12F"); //3606229295"); //Voices.Add("688738001
            Voices.Add("A_F_Y_TOURIST_01_LATINO_MINI_01"); //122F5483"); //305091715"); //305091715
            Voices.Add("A_F_Y_TOURIST_01_WHITE_FULL_01"); //DBEFEC5C"); //3689933916"); //Voices.Add("605033380
            Voices.Add("A_F_Y_TOURIST_01_WHITE_MINI_01"); //216BE906"); //560720134"); //560720134
            Voices.Add("A_F_Y_TOURIST_02_WHITE_MINI_01"); //0D6F398A"); //225393034"); //225393034
            Voices.Add("A_F_Y_VINEWOOD_01_WHITE_FULL_01"); //2AF2EF5B"); //720564059"); //720564059
            Voices.Add("A_F_Y_VINEWOOD_01_WHITE_MINI_01"); //23A74DCA"); //598166986"); //598166986
            Voices.Add("A_F_Y_VINEWOOD_02_WHITE_FULL_01"); //3A311C01"); //976296961"); //976296961
            Voices.Add("A_F_Y_VINEWOOD_02_WHITE_MINI_01"); //191A5AF2"); //421157618"); //421157618
            Voices.Add("A_F_Y_Vinewood_03_Chinese_FULL_01"); //E632B0F0"); //3862081776"); //Voices.Add("432885520
            Voices.Add("A_F_Y_VINEWOOD_03_CHINESE_MINI_01"); //3512D951"); //890427729"); //890427729
            Voices.Add("A_F_Y_VINEWOOD_04_WHITE_FULL_01"); //20C68AC8"); //549882568"); //549882568
            Voices.Add("A_F_Y_VINEWOOD_04_WHITE_MINI_01"); //12763C39"); //309738553"); //309738553
            Voices.Add("A_F_Y_VINEWOOD_04_WHITE_MINI_02"); //C8CB28E4"); //3368757476"); //Voices.Add("926209820
            Voices.Add("A_M_M_AFRIAMER_01_BLACK_FULL_01"); //43367BD1"); //1127644113"); //1127644113
            Voices.Add("A_M_M_BEACH_01_BLACK_MINI_01"); //D01013F6"); //3490714614"); //Voices.Add("804252682
            Voices.Add("A_M_M_BEACH_01_LATINO_FULL_01"); //26669A41"); //644258369"); //644258369
            Voices.Add("A_M_M_BEACH_01_LATINO_MINI_01"); //FB444157"); //4215554391"); //Voices.Add("79412905
            Voices.Add("A_M_M_BEACH_01_WHITE_FULL_01"); //30CB4589"); //818627977"); //818627977
            Voices.Add("A_M_M_BEACH_01_WHITE_MINI_02"); //A8E033BD"); //2833265597"); //Voices.Add("1461701699
            Voices.Add("A_M_M_BEACH_02_BLACK_FULL_01"); //BCACE696"); //3165447830"); //Voices.Add("1129519466
            Voices.Add("A_M_M_BEACH_02_WHITE_FULL_01"); //E8314D57"); //3895545175"); //Voices.Add("399422121
            Voices.Add("A_M_M_BEACH_02_WHITE_MINI_01"); //AE3CFC05"); //2923232261"); //Voices.Add("1371735035
            Voices.Add("A_M_M_BEACH_02_WHITE_MINI_02"); //4717ADD8"); //1192734168"); //1192734168
            Voices.Add("A_M_M_BEVHILLS_01_BLACK_FULL_01"); //457F9C3D"); //1165990973"); //1165990973
            Voices.Add("A_M_M_BEVHILLS_01_BLACK_MINI_01"); //29323F4A"); //691158858"); //691158858
            Voices.Add("A_M_M_BevHills_01_WHITE_FULL_01"); //DBCAE12A"); //3687506218"); //Voices.Add("607461078
            Voices.Add("A_M_M_BEVHILLS_01_WHITE_MINI_01"); //D19FFBCA"); //3516922826"); //Voices.Add("778044470
            Voices.Add("A_M_M_BEVHILLS_02_BLACK_FULL_01"); //5370D897"); //1399904407"); //1399904407
            Voices.Add("A_M_M_BEVHILLS_02_BLACK_MINI_01"); //25983C23"); //630733859"); //630733859
            Voices.Add("A_M_M_BEVHILLS_02_WHITE_FULL_01"); //6BB97FD6"); //1807318998"); //1807318998
            Voices.Add("A_M_M_BEVHILLS_02_WHITE_MINI_01"); //B509F09C"); //3037327516"); //Voices.Add("1257639780
            Voices.Add("A_M_M_BUSINESS_01_BLACK_FULL_01"); //4F3C06EB"); //1329333995"); //1329333995
            Voices.Add("A_M_M_BUSINESS_01_BLACK_MINI_01"); //9C4ACF39"); //2622148409"); //Voices.Add("1672818887
            Voices.Add("A_M_M_BUSINESS_01_WHITE_FULL_01"); //CE2B65BC"); //3458950588"); //Voices.Add("836016708
            Voices.Add("A_M_M_BUSINESS_01_WHITE_MINI_01"); //F3AD48DE"); //4088219870"); //Voices.Add("206747426
            Voices.Add("A_M_M_EASTSA_01_LATINO_FULL_01"); //BE01DD94"); //3187793300"); //Voices.Add("1107173996
            Voices.Add("A_M_M_EASTSA_01_LATINO_MINI_01"); //6BF8BF2C"); //1811463980"); //1811463980
            Voices.Add("A_M_M_EASTSA_02_LATINO_FULL_01"); //9CB34BA8"); //2628996008"); //Voices.Add("1665971288
            Voices.Add("A_M_M_EASTSA_02_LATINO_MINI_01"); //CDF2AD27"); //3455233319"); //Voices.Add("839733977
            Voices.Add("A_M_M_FARMER_01_WHITE_MINI_01"); //24689D1A"); //610835738"); //610835738
            Voices.Add("A_M_M_FARMER_01_WHITE_MINI_02"); //4ED1F1EC"); //1322381804"); //1322381804
            Voices.Add("A_M_M_FARMER_01_WHITE_MINI_03"); //F7F4C433"); //4160013363"); //Voices.Add("134953933
            Voices.Add("A_M_M_FATLATIN_01_LATINO_FULL_01"); //2F04A30B"); //788833035"); //788833035
            Voices.Add("A_M_M_FATLATIN_01_LATINO_MINI_01"); //4AED8689"); //1257080457"); //1257080457
            Voices.Add("A_M_M_GENERICMALE_01_WHITE_MINI_01"); //13EFDE7E"); //334487166"); //334487166
            Voices.Add("A_M_M_GENERICMALE_01_WHITE_MINI_02"); //221A7AD3"); //572160723"); //572160723
            Voices.Add("A_M_M_GENERICMALE_01_WHITE_MINI_03"); //5AA26BD6"); //1520593878"); //1520593878
            Voices.Add("A_M_M_GENERICMALE_01_WHITE_MINI_04"); //FD0AB0B4"); //4245336244"); //Voices.Add("49631052
            Voices.Add("A_M_M_GENFAT_01_LATINO_FULL_01"); //E53DAB11"); //3846023953"); //Voices.Add("448943343
            Voices.Add("A_M_M_GENFAT_01_LATINO_MINI_01"); //4C00FC14"); //1275132948"); //1275132948
            Voices.Add("A_M_M_GOLFER_01_BLACK_FULL_01"); //65B984D1"); //1706656977"); //1706656977
            Voices.Add("A_M_M_GOLFER_01_WHITE_FULL_01"); //57DD2744"); //1474111300"); //1474111300
            Voices.Add("A_M_M_GOLFER_01_WHITE_MINI_01"); //CA82D279"); //3397571193"); //Voices.Add("897396103
            Voices.Add("A_M_M_HASJEW_01_WHITE_MINI_01"); //31B413DD"); //833885149"); //833885149
            Voices.Add("A_M_M_HILLBILLY_01_WHITE_MINI_01"); //342FA137"); //875536695"); //875536695
            Voices.Add("A_M_M_HILLBILLY_01_WHITE_MINI_02"); //EEB2964E"); //4004681294"); //Voices.Add("290286002
            Voices.Add("A_M_M_HILLBILLY_01_WHITE_MINI_03"); //62B97E4A"); //1656323658"); //1656323658
            Voices.Add("A_M_M_HILLBILLY_02_WHITE_MINI_01"); //9E428A7D"); //2655160957"); //Voices.Add("1639806339
            Voices.Add("A_M_M_HILLBILLY_02_WHITE_MINI_02"); //ACECA7D1"); //2901190609"); //Voices.Add("1393776687
            Voices.Add("A_M_M_HILLBILLY_02_WHITE_MINI_03"); //7A9EC332"); //2057225010"); //2057225010
            Voices.Add("A_M_M_HILLBILLY_02_WHITE_MINI_04"); //14C3777D"); //348354429"); //348354429
            Voices.Add("A_M_M_INDIAN_01_INDIAN_MINI_01"); //0D92701D"); //227700765"); //227700765
            Voices.Add("A_M_M_KTOWN_01_KOREAN_FULL_01"); //CEB967A9"); //3468257193"); //Voices.Add("826710103
            Voices.Add("A_M_M_KTOWN_01_KOREAN_MINI_01"); //9D5568DD"); //2639620317"); //Voices.Add("1655346979
            Voices.Add("A_M_M_MALIBU_01_BLACK_FULL_01"); //704A0828"); //1883899944"); //1883899944
            Voices.Add("A_M_M_MALIBU_01_LATINO_FULL_01"); //C446CD11"); //3292974353"); //Voices.Add("1001992943
            Voices.Add("A_M_M_MALIBU_01_LATINO_MINI_01"); //23A05D0D"); //597712141"); //597712141
            Voices.Add("A_M_M_MALIBU_01_WHITE_FULL_01"); //ABCCBA7C"); //2882321020"); //Voices.Add("1412646276
            Voices.Add("A_M_M_MALIBU_01_WHITE_MINI_01"); //B71E2A9D"); //3072207517"); //Voices.Add("1222759779
            Voices.Add("A_M_M_POLYNESIAN_01_POLYNESIAN_FULL_01"); //68887F5A"); //1753775962"); //1753775962
            Voices.Add("A_M_M_POLYNESIAN_01_POLYNESIAN_MINI_01"); //CDB20C91"); //3450997905"); //Voices.Add("843969391
            Voices.Add("A_M_M_SALTON_01_WHITE_FULL_01"); //C4B4C301"); //3300180737"); //Voices.Add("994786559
            Voices.Add("A_M_M_SALTON_02_WHITE_FULL_01"); //AAD2C80E"); //2865940494"); //Voices.Add("1429026802
            Voices.Add("A_M_M_SALTON_02_WHITE_MINI_01"); //47C9EC4A"); //1204415562"); //1204415562
            Voices.Add("A_M_M_SALTON_02_WHITE_MINI_02"); //6D9837E6"); //1838692326"); //1838692326
            Voices.Add("A_M_M_SKATER_01_BLACK_FULL_01"); //256B9C01"); //627809281"); //627809281
            Voices.Add("A_M_M_SKATER_01_WHITE_FULL_01"); //011E5DF9"); //18767353"); //18767353
            Voices.Add("A_M_M_SKATER_01_WHITE_MINI_01"); //990DB923"); //2567813411"); //Voices.Add("1727153885
            Voices.Add("A_M_M_SKIDROW_01_BLACK_FULL_01"); //A9B4316E"); //2847158638"); //Voices.Add("1447808658
            Voices.Add("A_M_M_SOCENLAT_01_LATINO_FULL_01"); //06291B43"); //103357251"); //103357251
            Voices.Add("A_M_M_SOCENLAT_01_LATINO_MINI_01"); //E9A5A98F"); //3919948175"); //Voices.Add("375019121
            Voices.Add("A_M_M_SOUCENT_01_BLACK_FULL_01"); //15D5484D"); //366299213"); //366299213
            Voices.Add("A_M_M_SOUCENT_02_BLACK_FULL_01"); //465792F9"); //1180144377"); //1180144377
            Voices.Add("A_M_M_SOUCENT_03_BLACK_FULL_01"); //19DD2A37"); //433924663"); //433924663
            Voices.Add("A_M_M_SOUCENT_04_BLACK_FULL_01"); //3712F629"); //923989545"); //923989545
            Voices.Add("A_M_M_SOUCENT_04_BLACK_MINI_01"); //7BDBD27A"); //2078003834"); //2078003834
            Voices.Add("A_M_M_STLAT_02_LATINO_FULL_01"); //27BC1008"); //666636296"); //666636296
            Voices.Add("A_M_M_TENNIS_01_BLACK_MINI_01"); //74745D9B"); //1953783195"); //1953783195
            Voices.Add("A_M_M_TENNIS_01_WHITE_MINI_01"); //A7AD9A25"); //2813172261"); //Voices.Add("1481795035
            Voices.Add("A_M_M_TOURIST_01_WHITE_MINI_01"); //4B87E962"); //1267198306"); //1267198306
            Voices.Add("A_M_M_TRAMPBEAC_01_BLACK_FULL_01"); //126F2EEF"); //309276399"); //309276399
            Voices.Add("A_M_M_TRAMP_01_BLACK_FULL_01"); //EBC7775E"); //3955717982"); //Voices.Add("339249314
            Voices.Add("A_M_M_TRAMP_01_BLACK_MINI_01"); //7924B380"); //2032448384"); //2032448384
            Voices.Add("A_M_M_TRANVEST_01_WHITE_MINI_01"); //98921800"); //2559711232"); //Voices.Add("1735256064
            Voices.Add("A_M_M_TRANVEST_02_LATINO_FULL_01"); //659F48E4"); //1704937700"); //1704937700
            Voices.Add("A_M_M_TRANVEST_02_LATINO_MINI_01"); //F9BFF521"); //4190106913"); //Voices.Add("104860383
            Voices.Add("A_M_O_BEACH_01_WHITE_FULL_01"); //7FBF0F4A"); //2143227722"); //2143227722
            Voices.Add("A_M_O_BEACH_01_WHITE_MINI_01"); //B21E181B"); //2988316699"); //Voices.Add("1306650597
            Voices.Add("A_M_O_GENSTREET_01_WHITE_FULL_01"); //BB6B9D57"); //3144392023"); //Voices.Add("1150575273
            Voices.Add("A_M_O_GENSTREET_01_WHITE_MINI_01"); //10EE4E6A"); //284053098"); //284053098
            Voices.Add("A_M_O_SALTON_01_WHITE_FULL_01"); //5DBB7560"); //1572566368"); //1572566368
            Voices.Add("A_M_O_SALTON_01_WHITE_MINI_01"); //AEA39902"); //2929957122"); //Voices.Add("1365010174
            Voices.Add("A_M_O_SOUCENT_01_BLACK_FULL_01"); //8F45DF82"); //2403721090"); //Voices.Add("1891246206
            Voices.Add("A_M_O_SOUCENT_02_BLACK_FULL_01"); //C195B582"); //3247814018"); //Voices.Add("1047153278
            Voices.Add("A_M_O_SOUCENT_03_BLACK_FULL_01"); //9CE751AB"); //2632405419"); //Voices.Add("1662561877
            Voices.Add("A_M_O_TRAMP_01_BLACK_FULL_01"); //ABAB17E1"); //2880116705"); //Voices.Add("1414850591
            Voices.Add("A_M_Y_BEACHVESP_01_CHINESE_FULL_01"); //D5130E1F"); //3574795807"); //Voices.Add("720171489
            Voices.Add("A_M_Y_BEACHVESP_01_CHINESE_MINI_01"); //B0C6E699"); //2965825177"); //Voices.Add("1329142119
            Voices.Add("A_M_Y_BEACHVESP_01_LATINO_MINI_01"); //3F13D91C"); //1058265372"); //1058265372
            Voices.Add("A_M_Y_BEACHVESP_01_WHITE_FULL_01"); //3CE0CB56"); //1021365078"); //1021365078
            Voices.Add("A_M_Y_BEACHVESP_01_WHITE_MINI_01"); //AAD5FF3F"); //2866151231"); //Voices.Add("1428816065
            Voices.Add("A_M_Y_BEACHVESP_02_WHITE_FULL_01"); //4C19F4DE"); //1276769502"); //1276769502
            Voices.Add("A_M_Y_BEACHVESP_02_WHITE_MINI_01"); //7F7BB4CC"); //2138813644"); //2138813644
            Voices.Add("A_M_Y_BEACH_01_CHINESE_FULL_01"); //14611348"); //341906248"); //341906248
            Voices.Add("A_M_Y_BEACH_01_CHINESE_MINI_01"); //6A55B403"); //1784001539"); //1784001539
            Voices.Add("A_M_Y_BEACH_01_WHITE_FULL_01"); //1C2149A7"); //471943591"); //471943591
            Voices.Add("A_M_Y_BEACH_01_WHITE_MINI_01"); //912C1ADE"); //2435586782"); //Voices.Add("1859380514
            Voices.Add("A_M_Y_BEACH_02_LATINO_FULL_01"); //DBF1B32E"); //3690050350"); //Voices.Add("604916946
            Voices.Add("A_M_Y_BEACH_02_WHITE_FULL_01"); //0B3E6275"); //188637813"); //188637813
            Voices.Add("A_M_Y_BEACH_03_BLACK_FULL_01"); //18519A78"); //408001144"); //408001144
            Voices.Add("A_M_Y_BEACH_03_BLACK_MINI_01"); //5C219040"); //1545703488"); //1545703488
            Voices.Add("A_M_Y_BEACH_03_WHITE_FULL_01"); //187DBBE4"); //410893284"); //410893284
            Voices.Add("A_M_Y_BEVHILLS_01_BLACK_FULL_01"); //BB7823E2"); //3145212898"); //Voices.Add("1149754398
            Voices.Add("A_M_Y_BevHills_01_WHITE_FULL_01"); //FBF34319"); //4227023641"); //Voices.Add("67943655
            Voices.Add("A_M_Y_BEVHILLS_01_WHITE_MINI_01"); //7C5C68C5"); //2086430917"); //2086430917
            Voices.Add("A_M_Y_BevHills_02_Black_FULL_01"); //7FDB40A6"); //2145075366"); //2145075366
            Voices.Add("A_M_Y_BEVHILLS_02_WHITE_FULL_01"); //D4FC2A78"); //3573295736"); //Voices.Add("721671560
            Voices.Add("A_M_Y_BEVHILLS_02_WHITE_MINI_01"); //E24573FE"); //3796202494"); //Voices.Add("498764802
            Voices.Add("A_M_Y_BUSICAS_01_WHITE_MINI_01"); //AE353C51"); //2922724433"); //Voices.Add("1372242863
            Voices.Add("A_M_Y_BUSINESS_01_BLACK_FULL_01"); //14EA502A"); //350900266"); //350900266
            Voices.Add("A_M_Y_BUSINESS_01_BLACK_MINI_01"); //3EE0C0FD"); //1054916861"); //1054916861
            Voices.Add("A_M_Y_BUSINESS_01_CHINESE_FULL_01"); //2AF37A7A"); //720599674"); //720599674
            Voices.Add("A_M_Y_BUSINESS_01_CHINESE_MINI_01"); //BBE9D5F6"); //3152664054"); //Voices.Add("1142303242
            Voices.Add("A_M_Y_BUSINESS_01_WHITE_FULL_01"); //A3B29220"); //2746389024"); //Voices.Add("1548578272
            Voices.Add("A_M_Y_BUSINESS_01_WHITE_MINI_02"); //D5230A76"); //3575843446"); //Voices.Add("719123850
            Voices.Add("A_M_Y_BUSINESS_02_BLACK_FULL_01"); //455E1156"); //1163792726"); //1163792726
            Voices.Add("A_M_Y_BUSINESS_02_BLACK_MINI_01"); //728E84E0"); //1921942752"); //1921942752
            Voices.Add("A_M_Y_BUSINESS_02_WHITE_FULL_01"); //21BD5DCB"); //566058443"); //566058443
            Voices.Add("A_M_Y_BUSINESS_02_WHITE_MINI_01"); //DF04F10C"); //3741643020"); //Voices.Add("553324276
            Voices.Add("A_M_Y_BUSINESS_02_WHITE_MINI_02"); //D1405583"); //3510654339"); //Voices.Add("784312957
            Voices.Add("A_M_Y_BUSINESS_03_BLACK_FULL_01"); //63CAEDDD"); //1674243549"); //1674243549
            Voices.Add("A_M_Y_BUSINESS_03_WHITE_MINI_01"); //5161018C"); //1365311884"); //1365311884
            Voices.Add("A_M_Y_DOWNTOWN_01_BLACK_FULL_01"); //5C59E524"); //1549395236"); //1549395236
            Voices.Add("A_M_Y_EASTSA_01_LATINO_FULL_01"); //4D091B2B"); //1292442411"); //1292442411
            Voices.Add("A_M_Y_EASTSA_01_LATINO_MINI_01"); //90006FB0"); //2415947696"); //Voices.Add("1879019600
            Voices.Add("A_M_Y_EASTSA_02_LATINO_FULL_01"); //71EFEA69"); //1911548521"); //1911548521
            Voices.Add("A_M_Y_EPSILON_01_BLACK_FULL_01"); //3C737DA3"); //1014201763"); //1014201763
            Voices.Add("A_M_Y_EPSILON_01_KOREAN_FULL_01"); //C5901506"); //3314554118"); //Voices.Add("980413178
            Voices.Add("A_M_Y_EPSILON_01_WHITE_FULL_01"); //8B5E6BA1"); //2338220961"); //Voices.Add("1956746335
            Voices.Add("A_M_Y_EPSILON_02_WHITE_MINI_01"); //5929B31B"); //1495905051"); //1495905051
            Voices.Add("A_M_Y_GAY_01_BLACK_FULL_01"); //D66B6510"); //3597362448"); //Voices.Add("697604848
            Voices.Add("A_M_Y_GAY_01_LATINO_FULL_01"); //56EA4F8A"); //1458196362"); //1458196362
            Voices.Add("A_M_Y_GAY_02_WHITE_MINI_01"); //F31D141C"); //4078769180"); //Voices.Add("216198116
            Voices.Add("A_M_Y_GENSTREET_01_CHINESE_FULL_01"); //FBD60609"); //4225107465"); //Voices.Add("69859831
            Voices.Add("A_M_Y_GENSTREET_01_CHINESE_MINI_01"); //68B1C2E6"); //1756480230"); //1756480230
            Voices.Add("A_M_Y_GenStreet_01_White_FULL_01"); //CCC8E124"); //3435716900"); //Voices.Add("859250396
            Voices.Add("A_M_Y_GENSTREET_01_WHITE_MINI_01"); //0EA63482"); //245773442"); //245773442
            Voices.Add("A_M_Y_GENSTREET_02_BLACK_FULL_01"); //A05521B9"); //2689933753"); //Voices.Add("1605033543
            Voices.Add("A_M_Y_GENSTREET_02_LATINO_FULL_01"); //8A23EC00"); //2317609984"); //Voices.Add("1977357312
            Voices.Add("A_M_Y_GENSTREET_02_LATINO_MINI_01"); //71BDAFD1"); //1908256721"); //1908256721
            Voices.Add("A_M_Y_GOLFER_01_WHITE_FULL_01"); //DB7324F1"); //3681756401"); //Voices.Add("613210895
            Voices.Add("A_M_Y_GOLFER_01_WHITE_MINI_01"); //0F36AC80"); //255241344"); //255241344
            Voices.Add("A_M_Y_HASJEW_01_WHITE_MINI_01"); //C4E78448"); //3303507016"); //Voices.Add("991460280
            Voices.Add("A_M_Y_HIPPY_01_WHITE_FULL_01"); //72E9121E"); //1927877150"); //1927877150
            Voices.Add("A_M_Y_HIPPY_01_WHITE_MINI_01"); //A92E6392"); //2838389650"); //Voices.Add("1456577646
            Voices.Add("A_M_Y_HIPSTER_01_BLACK_FULL_01"); //4D67AAB4"); //1298639540"); //1298639540
            Voices.Add("A_M_Y_HIPSTER_01_WHITE_FULL_01"); //93896827"); //2475255847"); //Voices.Add("1819711449
            Voices.Add("A_M_Y_HIPSTER_01_WHITE_MINI_01"); //B4EB0EBF"); //3035303615"); //Voices.Add("1259663681
            Voices.Add("A_M_Y_HIPSTER_02_WHITE_FULL_01"); //742FB44D"); //1949283405"); //1949283405
            Voices.Add("A_M_Y_HIPSTER_02_WHITE_MINI_01"); //521933C3"); //1377383363"); //1377383363
            Voices.Add("A_M_Y_HIPSTER_03_WHITE_FULL_01"); //E694D959"); //3868514649"); //Voices.Add("426452647
            Voices.Add("A_M_Y_HIPSTER_03_WHITE_MINI_01"); //B22C563F"); //2989250111"); //Voices.Add("1305717185
            Voices.Add("A_M_Y_KTOWN_01_KOREAN_FULL_01"); //285D1B2F"); //677190447"); //677190447
            Voices.Add("A_M_Y_KTOWN_01_KOREAN_MINI_01"); //D97AF207"); //3648713223"); //Voices.Add("646254073
            Voices.Add("A_M_Y_KTOWN_02_KOREAN_FULL_01"); //7B3CEC0F"); //2067590159"); //2067590159
            Voices.Add("A_M_Y_KTOWN_02_KOREAN_MINI_01"); //77B4E675"); //2008344181"); //2008344181
            Voices.Add("A_M_Y_LATINO_01_LATINO_MINI_01"); //26ED66AF"); //653092527"); //653092527
            Voices.Add("A_M_Y_LATINO_01_LATINO_MINI_02"); //C2429D5B"); //3259145563"); //Voices.Add("1035821733
            Voices.Add("A_M_Y_MEXTHUG_01_LATINO_FULL_01"); //5756D257"); //1465307735"); //1465307735
            Voices.Add("A_M_Y_MUSCLBEAC_01_BLACK_FULL_01"); //C1B61E52"); //3249938002"); //Voices.Add("1045029294
            Voices.Add("A_M_Y_MUSCLBEAC_01_WHITE_FULL_01"); //0225E2F9"); //36037369"); //36037369
            Voices.Add("A_M_Y_MUSCLBEAC_01_WHITE_MINI_01"); //977DC3C1"); //2541601729"); //Voices.Add("1753365567
            Voices.Add("A_M_Y_MUSCLBEAC_02_CHINESE_FULL_01"); //A6F52D1E"); //2801085726"); //Voices.Add("1493881570
            Voices.Add("A_M_Y_MUSCLBEAC_02_LATINO_FULL_01"); //67CCA113"); //1741463827"); //1741463827
            Voices.Add("A_M_Y_POLYNESIAN_01_POLYNESIAN_FULL_01"); //121DA55B"); //303932763"); //303932763
            Voices.Add("A_M_Y_RACER_01_WHITE_MINI_01"); //F64541B5"); //4131733941"); //Voices.Add("163233355
            Voices.Add("A_M_Y_ROLLERCOASTER_01_MINI_01"); //7DB0EDFB"); //2108747259"); //2108747259
            Voices.Add("A_M_Y_ROLLERCOASTER_01_MINI_02"); //678FC1B9"); //1737474489"); //1737474489
            Voices.Add("A_M_Y_ROLLERCOASTER_01_MINI_03"); //A3F33A7F"); //2750626431"); //Voices.Add("1544340865
            Voices.Add("A_M_Y_ROLLERCOASTER_01_MINI_04"); //962B9EF0"); //2519441136"); //Voices.Add("1775526160
            Voices.Add("A_M_Y_RUNNER_01_WHITE_FULL_01"); //F85796B7"); //4166489783"); //Voices.Add("128477513
            Voices.Add("A_M_Y_RUNNER_01_WHITE_MINI_01"); //6816D078"); //1746325624"); //1746325624
            Voices.Add("A_M_Y_SALTON_01_WHITE_MINI_01"); //488C6273"); //1217159795"); //1217159795
            Voices.Add("A_M_Y_SALTON_01_WHITE_MINI_02"); //5E6F8E25"); //1584369189"); //1584369189
            Voices.Add("A_M_Y_SKATER_01_WHITE_FULL_01"); //1E6F76CB"); //510621387"); //510621387
            Voices.Add("A_M_Y_SKATER_01_WHITE_MINI_01"); //41386857"); //1094215767"); //1094215767
            Voices.Add("A_M_Y_SKATER_02_BLACK_FULL_01"); //46B9D99F"); //1186584991"); //1186584991
            Voices.Add("A_M_Y_SOUCENT_01_BLACK_FULL_01"); //7ADB7C56"); //2061204566"); //2061204566
            Voices.Add("A_M_Y_SOUCENT_02_BLACK_FULL_01"); //BA7414D7"); //3128169687"); //Voices.Add("1166797609
            Voices.Add("A_M_Y_SOUCENT_03_BLACK_FULL_01"); //997A83C0"); //2574943168"); //Voices.Add("1720024128
            Voices.Add("A_M_Y_SOUCENT_04_BLACK_FULL_01"); //97BA1740"); //2545555264"); //Voices.Add("1749412032
            Voices.Add("A_M_Y_SOUCENT_04_BLACK_MINI_01"); //E3DE23A6"); //3822986150"); //Voices.Add("471981146
            Voices.Add("A_M_Y_STBLA_01_BLACK_FULL_01"); //80372D5A"); //2151099738"); //Voices.Add("2143867558
            Voices.Add("A_M_Y_STBLA_02_BLACK_FULL_01"); //B77F38D5"); //3078568149"); //Voices.Add("1216399147
            Voices.Add("A_M_Y_STLAT_01_LATINO_FULL_01"); //AF739934"); //2943588660"); //Voices.Add("1351378636
            Voices.Add("A_M_Y_STLAT_01_LATINO_MINI_01"); //CDC7408D"); //3452387469"); //Voices.Add("842579827
            Voices.Add("A_M_Y_STWHI_01_WHITE_FULL_01"); //51843C65"); //1367620709"); //1367620709
            Voices.Add("A_M_Y_STWHI_01_WHITE_MINI_01"); //283E7635"); //675182133"); //675182133
            Voices.Add("A_M_Y_STWHI_02_WHITE_FULL_01"); //32F459E7"); //854874599"); //854874599
            Voices.Add("A_M_Y_STWHI_02_WHITE_MINI_01"); //D94A1B14"); //3645512468"); //Voices.Add("649454828
            Voices.Add("A_M_Y_SUNBATHE_01_BLACK_FULL_01"); //523A66C3"); //1379559107"); //1379559107
            Voices.Add("A_M_Y_SUNBATHE_01_WHITE_FULL_01"); //0CEA2526"); //216671526"); //216671526
            Voices.Add("A_M_Y_SUNBATHE_01_WHITE_MINI_01"); //C31ADD04"); //3273317636"); //Voices.Add("1021649660
            Voices.Add("A_M_Y_TRIATHLON_01_MINI_01"); //55B488C4"); //1437894852"); //1437894852
            Voices.Add("A_M_Y_TRIATHLON_01_MINI_02"); //87746C43"); //2272554051"); //Voices.Add("2022413245
            Voices.Add("A_M_Y_TRIATHLON_01_MINI_03"); //BB49D3ED"); //3142177773"); //Voices.Add("1152789523
            Voices.Add("A_M_Y_TRIATHLON_01_MINI_04"); //ED26B7A6"); //3978737574"); //Voices.Add("316229722
            Voices.Add("A_M_Y_VINEWOOD_01_BLACK_FULL_01"); //8567F85C"); //2238183516"); //Voices.Add("2056783780
            Voices.Add("A_M_Y_VINEWOOD_01_BLACK_MINI_01"); //0C746F67"); //208957287"); //208957287
            Voices.Add("A_M_Y_VINEWOOD_02_WHITE_FULL_01"); //0A626D28"); //174222632"); //174222632
            Voices.Add("A_M_Y_VINEWOOD_02_WHITE_MINI_01"); //C370059E"); //3278898590"); //Voices.Add("1016068706
            Voices.Add("A_M_Y_Vinewood_03_Latino_FULL_01"); //F450D2AC"); //4098937516"); //Voices.Add("196029780
            Voices.Add("A_M_Y_VINEWOOD_03_LATINO_MINI_01"); //9FDD31FF"); //2682073599"); //Voices.Add("1612893697
            Voices.Add("A_M_Y_VINEWOOD_03_WHITE_FULL_01"); //852D3A8F"); //2234333839"); //Voices.Add("2060633457
            Voices.Add("A_M_Y_VINEWOOD_03_WHITE_MINI_01"); //3A84F91E"); //981793054"); //981793054
            Voices.Add("A_M_Y_VINEWOOD_04_WHITE_FULL_01"); //77B21017"); //2008158231"); //2008158231
            Voices.Add("A_M_Y_VINEWOOD_04_WHITE_MINI_01"); //99DA0ADA"); //2581203674"); //Voices.Add("1713763622
            Voices.Add("BAILBOND1JUMPER"); //6909D3CC"); //1762251724"); //1762251724
            Voices.Add("BAILBOND2JUMPER"); //8C257BBD"); //2351266749"); //Voices.Add("1943700547
            Voices.Add("BAILBOND3JUMPER"); //2E2EF1F8"); //774828536"); //774828536
            Voices.Add("BAILBOND4JUMPER"); //643A0559"); //1681524057"); //1681524057
            Voices.Add("BALLASOG"); //AAE4ECF8"); //2867129592"); //Voices.Add("1427837704
            Voices.Add("BANK"); //3A15DB98"); //974511000"); //974511000
            Voices.Add("BANKWM1"); //CED9042B"); //3470328875"); //Voices.Add("824638421
            Voices.Add("BANKWM2"); //9C9B9FB1"); //2627444657"); //Voices.Add("1667522639
            Voices.Add("BARRY"); //A9058E54"); //2835713620"); //Voices.Add("1459253676
            Voices.Add("BARRY_01_ALIEN_A"); //82BA2086"); //2193236102"); //Voices.Add("2101731194
            Voices.Add("BARRY_01_ALIEN_B"); //7494843B"); //1955890235"); //1955890235
            Voices.Add("BARRY_01_ALIEN_C"); //F06D7BEB"); //4033706987"); //Voices.Add("261260309
            Voices.Add("BARRY_02_CLOWN_A"); //7929F21D"); //2032792093"); //2032792093
            Voices.Add("BARRY_02_CLOWN_B"); //66F4CDB3"); //1727319475"); //1727319475
            Voices.Add("BARRY_02_CLOWN_C"); //9E16BBF6"); //2652290038"); //Voices.Add("1642677258
            Voices.Add("BAYGOR"); //7BF7A5D6"); //2079827414"); //2079827414
            Voices.Add("BENNY"); //F1EB2693"); //4058719891"); //Voices.Add("236247405
            Voices.Add("BEVERLY"); //79D862EA"); //2044224234"); //2044224234
            Voices.Add("BIKE_MECHANIC"); //573287EB"); //1462929387"); //1462929387
            Voices.Add("BILLBINDER"); //4E43F344"); //1313076036"); //1313076036
            Voices.Add("BJPILOT_CANAL"); //B75951F4"); //3076084212"); //Voices.Add("1218883084
            Voices.Add("BJPILOT_TRAIN"); //0FACABE0"); //262974432"); //262974432
            Voices.Add("BRAD"); //57360243"); //1463157315"); //1463157315
            Voices.Add("BREATHING_FRANKLIN_01"); //777E9106"); //2004783366"); //2004783366
            Voices.Add("BREATHING_MICHAEL_01"); //CAB2CFFB"); //3400716283"); //Voices.Add("894251013
            Voices.Add("BREATHING_TEST_01"); //D75E8754"); //3613296468"); //Voices.Add("681670828
            Voices.Add("BREATHING_TREVOR_01"); //18092047"); //403251271"); //403251271
            Voices.Add("BUSINESSMAN"); //3ECBA7BD"); //1053534141"); //1053534141
            Voices.Add("CASEY"); //908C67DC"); //2425120732"); //Voices.Add("1869846564
            Voices.Add("CHAR_INTRO_FRANKLIN_01"); //420FF5A0"); //1108342176"); //1108342176
            Voices.Add("CHAR_INTRO_MICHAEL_01"); //E4A08B92"); //3835726738"); //Voices.Add("459240558
            Voices.Add("CHAR_INTRO_TREVOR_01"); //8F52758F"); //2404545935"); //Voices.Add("1890421361
            Voices.Add("CHASTITY"); //9B4468A9"); //2604951721"); //Voices.Add("1690015575
            Voices.Add("CHASTITY_MP"); //4E0041AA"); //1308639658"); //1308639658
            Voices.Add("CHEETAH"); //B1D95DA0"); //2983812512"); //Voices.Add("1311154784
            Voices.Add("CHEF"); //BF59CC9A"); //3210333338"); //Voices.Add("1084633958
            Voices.Add("CHENG"); //65BBBE48"); //1706802760"); //1706802760
            Voices.Add("CLETUS"); //9B00816A"); //2600501610"); //Voices.Add("1694465686
            Voices.Add("CLINTON"); //2B502F45"); //726675269"); //726675269
            Voices.Add("CLOWNS"); //D8088180"); //3624436096"); //Voices.Add("670531200
            Voices.Add("CONSTRUCTION_SITE_MALE_01"); //C285BFCA"); //3263545290"); //Voices.Add("1031422006
            Voices.Add("CONSTRUCTION_SITE_MALE_02"); //3572A596"); //896705942"); //896705942
            Voices.Add("CONSTRUCTION_SITE_MALE_03"); //82A1C003"); //2191638531"); //Voices.Add("2103328765
            Voices.Add("CONSTRUCTION_SITE_MALE_04"); //93CE625C"); //2479776348"); //Voices.Add("1815190948
            Voices.Add("COOK"); //5673232D"); //1450386221"); //1450386221
            Voices.Add("CST4ACTRESS"); //6A8C4C84"); //1787579524"); //1787579524
            Voices.Add("DARYL"); //10088962"); //268994914"); //268994914
            Voices.Add("DAVE"); //B1F68A9D"); //2985724573"); //Voices.Add("1309242723
            Voices.Add("DENISE"); //860AA79A"); //2248845210"); //Voices.Add("2046122086
            Voices.Add("DOM"); //BBF2D511"); //3153253649"); //Voices.Add("1141713647
            Voices.Add("EDDIE"); //C5FB1FF5"); //3321569269"); //Voices.Add("973398027
            Voices.Add("EXECPA_FEMALE"); //B6FB2A37"); //3069913655"); //Voices.Add("1225053641
            Voices.Add("EXECPA_MALE"); //0C5C69CC"); //207382988"); //207382988
            Voices.Add("EXT1HELIPILOT"); //EF004581"); //4009772417"); //Voices.Add("285194879
            Voices.Add("FACILITY_ANNOUNCER"); //A9F8234D"); //2851611469"); //Voices.Add("1443355827
            Voices.Add("FLOYD"); //5E69D958"); //1583995224"); //1583995224
            Voices.Add("FM"); //FFE20CE1"); //4293004513"); //Voices.Add("1962783
            Voices.Add("FM_TH"); //2640742C"); //641758252"); //641758252
            Voices.Add("FRANKLIN_1_NORMAL"); //D603B047"); //3590565959"); //Voices.Add("704401337
            Voices.Add("FRANKLIN_2_NORMAL"); //9F8D1B67"); //2676824935"); //Voices.Add("1618142361
            Voices.Add("FRANKLIN_3_NORMAL"); //FA7C388C"); //4202444940"); //Voices.Add("92522356
            Voices.Add("FRANKLIN_ANGRY"); //D227A0A9"); //3525812393"); //Voices.Add("769154903
            Voices.Add("FRANKLIN_DRUNK"); //E6EFD5C5"); //3874477509"); //Voices.Add("420489787
            Voices.Add("FRANKLIN_NORMAL"); //64CCE782"); //1691150210"); //1691150210
            Voices.Add("FUFU"); //ED8EA575"); //3985548661"); //Voices.Add("309418635
            Voices.Add("FUFU_MP"); //4EA343CA"); //1319322570"); //1319322570
            Voices.Add("GARDENER"); //4260B7F4"); //1113634804"); //1113634804
            Voices.Add("GAYMILITARY"); //212EBC3B"); //556710971"); //556710971
            Voices.Add("GERALD"); //07DCC381"); //131908481"); //131908481
            Voices.Add("GIRL1"); //9ABA4CB8"); //2595900600"); //Voices.Add("1699066696
            Voices.Add("GIRL2"); //C38C1E5B"); //3280739931"); //Voices.Add("1014227365
            Voices.Add("GRIFF"); //03DD4948"); //64833864"); //64833864
            Voices.Add("GROOM"); //4A735AF1"); //1249073905"); //1249073905
            Voices.Add("GUSTAVO"); //E5A7195C"); //3852933468"); //Voices.Add("442033828
            Voices.Add("G_F_Y_BALLAS_01_BLACK_MINI_01"); //15BB1C9C"); //364584092"); //364584092
            Voices.Add("G_F_Y_BALLAS_01_BLACK_MINI_02"); //17F72114"); //402071828"); //402071828
            Voices.Add("G_F_Y_BALLAS_01_BLACK_MINI_03"); //1D7F2C2C"); //494873644"); //494873644
            Voices.Add("G_F_Y_BALLAS_01_BLACK_MINI_04"); //403F71AC"); //1077899692"); //1077899692
            Voices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_01"); //4D341506"); //1295258886"); //1295258886
            Voices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_02"); //69F34E84"); //1777553028"); //1777553028
            Voices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_03"); //B0B85C0D"); //2964872205"); //Voices.Add("1330095091
            Voices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_04"); //5B7DB199"); //1534964121"); //1534964121
            Voices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_05"); //85658568"); //2238023016"); //Voices.Add("2056944280
            Voices.Add("G_F_Y_FAMILIES_01_BLACK_MINI_06"); //BFA0F9DE"); //3214997982"); //Voices.Add("1079969314
            Voices.Add("G_F_Y_VAGOS_01_LATINO_MINI_01"); //0320E887"); //52488327"); //52488327
            Voices.Add("G_F_Y_VAGOS_01_LATINO_MINI_02"); //D6930F6C"); //3599961964"); //Voices.Add("695005332
            Voices.Add("G_F_Y_VAGOS_01_LATINO_MINI_03"); //7E0BDE5F"); //2114707039"); //2114707039
            Voices.Add("G_F_Y_VAGOS_01_LATINO_MINI_04"); //8854F2F1"); //2287268593"); //Voices.Add("2007698703
            Voices.Add("G_M_M_ARMBOSS_01_WHITE_ARMENIAN_MINI_01"); //F840ABA3"); //4164987811"); //Voices.Add("129979485
            Voices.Add("G_M_M_ARMBOSS_01_WHITE_ARMENIAN_MINI_02"); //DD7F7641"); //3716118081"); //Voices.Add("578849215
            Voices.Add("G_M_M_ARMLIEUT_01_WHITE_ARMENIAN_MINI_01"); //9B88EB80"); //2609441664"); //Voices.Add("1685525632
            Voices.Add("G_M_M_ARMLIEUT_01_WHITE_ARMENIAN_MINI_02"); //8BCF4C0D"); //2345618445"); //Voices.Add("1949348851
            Voices.Add("G_M_M_CHIBOSS_01_CHINESE_MINI_01"); //FD2B8068"); //4247486568"); //Voices.Add("47480728
            Voices.Add("G_M_M_CHIBOSS_01_CHINESE_MINI_02"); //6EF5E41B"); //1861608475"); //1861608475
            Voices.Add("G_M_M_CHIGOON_01_CHINESE_MINI_01"); //E8CB59DD"); //3905640925"); //Voices.Add("389326371
            Voices.Add("G_M_M_CHIGOON_01_CHINESE_MINI_02"); //F8FCFA40"); //4177328704"); //Voices.Add("117638592
            Voices.Add("G_M_M_CHIGOON_02_CHINESE_MINI_01"); //93D6B240"); //2480321088"); //Voices.Add("1814646208
            Voices.Add("G_M_M_CHIGOON_02_CHINESE_MINI_02"); //2138CD06"); //557370630"); //557370630
            Voices.Add("G_M_M_KORBOSS_01_KOREAN_MINI_01"); //049ADD23"); //77258019"); //77258019
            Voices.Add("G_M_M_KORBOSS_01_KOREAN_MINI_02"); //9DB98F56"); //2646183766"); //Voices.Add("1648783530
            Voices.Add("G_M_M_MEXBOSS_01_LATINO_MINI_01"); //121AC997"); //303745431"); //303745431
            Voices.Add("G_M_M_MEXBOSS_01_LATINO_MINI_02"); //A86BF63B"); //2825647675"); //Voices.Add("1469319621
            Voices.Add("G_M_M_MEXBOSS_02_LATINO_MINI_01"); //FCB3B4DF"); //4239635679"); //Voices.Add("55331617
            Voices.Add("G_M_M_MEXBOSS_02_LATINO_MINI_02"); //59FC6F6F"); //1509715823"); //1509715823
            Voices.Add("G_M_M_X17_RSO_01"); //7B4E71E9"); //2068738537"); //2068738537
            Voices.Add("G_M_M_X17_RSO_02"); //0518057E"); //85460350"); //85460350
            Voices.Add("G_M_M_X17_RSO_03"); //16232794"); //371402644"); //371402644
            Voices.Add("G_M_M_X17_RSO_04"); //09AF0EA8"); //162467496"); //162467496
            Voices.Add("G_M_Y_ARMGOON_02_WHITE_ARMENIAN_MINI_01"); //F98339EA"); //4186126826"); //Voices.Add("108840470
            Voices.Add("G_M_Y_ARMGOON_02_WHITE_ARMENIAN_MINI_02"); //91C4EA6B"); //2445601387"); //Voices.Add("1849365909
            Voices.Add("G_M_Y_BALLAEAST_01_BLACK_FULL_01"); //9CFAAA5C"); //2633673308"); //Voices.Add("1661293988
            Voices.Add("G_M_Y_BALLAEAST_01_BLACK_FULL_02"); //8F2D0EC1"); //2402094785"); //Voices.Add("1892872511
            Voices.Add("G_M_Y_BALLAEAST_01_BLACK_MINI_01"); //2C0FCD9F"); //739233183"); //739233183
            Voices.Add("G_M_Y_BALLAEAST_01_BLACK_MINI_02"); //D5BE20F9"); //3586007289"); //Voices.Add("708960007
            Voices.Add("G_M_Y_BALLAEAST_01_BLACK_MINI_03"); //C77B8474"); //3346760820"); //Voices.Add("948206476
            Voices.Add("G_M_Y_BALLAORIG_01_BLACK_FULL_01"); //F0D6A527"); //4040598823"); //Voices.Add("254368473
            Voices.Add("G_M_Y_BALLAORIG_01_BLACK_FULL_02"); //DF4101FC"); //3745579516"); //Voices.Add("549387780
            Voices.Add("G_M_Y_BALLAORIG_01_BLACK_MINI_01"); //719C62A9"); //1906074281"); //1906074281
            Voices.Add("G_M_Y_BALLAORIG_01_BLACK_MINI_02"); //AD1BD9A7"); //2904283559"); //Voices.Add("1390683737
            Voices.Add("G_M_Y_BALLAORIG_01_BLACK_MINI_03"); //925BA427"); //2455479335"); //Voices.Add("1839487961
            Voices.Add("G_M_Y_BALLASOUT_01_BLACK_FULL_01"); //60B320B0"); //1622352048"); //1622352048
            Voices.Add("G_M_Y_BALLASOUT_01_BLACK_FULL_02"); //2A5033EB"); //709899243"); //709899243
            Voices.Add("G_M_Y_BALLASOUT_01_BLACK_MINI_01"); //6ED150A0"); //1859211424"); //1859211424
            Voices.Add("G_M_Y_BALLASOUT_01_BLACK_MINI_02"); //A00D3317"); //2685219607"); //Voices.Add("1609747689
            Voices.Add("G_M_Y_BALLASOUT_01_BLACK_MINI_03"); //BE746FE5"); //3195301861"); //Voices.Add("1099665435
            Voices.Add("G_M_Y_FAMCA_01_BLACK_FULL_01"); //3F299AE9"); //1059691241"); //1059691241
            Voices.Add("G_M_Y_FAMCA_01_BLACK_FULL_02"); //51573F44"); //1364672324"); //1364672324
            Voices.Add("G_M_Y_FAMCA_01_BLACK_MINI_01"); //D991FA9F"); //3650222751"); //Voices.Add("644744545
            Voices.Add("G_M_Y_FAMCA_01_BLACK_MINI_02"); //6B6D9E58"); //1802346072"); //1802346072
            Voices.Add("G_M_Y_FAMCA_01_BLACK_MINI_03"); //0658D3F8"); //106484728"); //106484728
            Voices.Add("G_M_Y_FAMDNF_01_BLACK_FULL_01"); //5F8F7FB9"); //1603239865"); //1603239865
            Voices.Add("G_M_Y_FAMDNF_01_BLACK_FULL_02"); //B271257B"); //2993759611"); //Voices.Add("1301207685
            Voices.Add("G_M_Y_FAMDNF_01_BLACK_MINI_01"); //BA8A1C11"); //3129613329"); //Voices.Add("1165353967
            Voices.Add("G_M_Y_FAMDNF_01_BLACK_MINI_02"); //28A77842"); //682063938"); //682063938
            Voices.Add("G_M_Y_FAMDNF_01_BLACK_MINI_03"); //D2384B6D"); //3526904685"); //Voices.Add("768062611
            Voices.Add("G_M_Y_FAMFOR_01_BLACK_FULL_01"); //4D505739"); //1297110841"); //1297110841
            Voices.Add("G_M_Y_FAMFOR_01_BLACK_FULL_02"); //7FEB3C3E"); //2146122814"); //2146122814
            Voices.Add("G_M_Y_FAMFOR_01_BLACK_MINI_01"); //FA83BCD1"); //4202937553"); //Voices.Add("92029743
            Voices.Add("G_M_Y_FAMFOR_01_BLACK_MINI_02"); //4721560B"); //1193367051"); //1193367051
            Voices.Add("G_M_Y_FAMFOR_01_BLACK_MINI_03"); //56CEF566"); //1456403814"); //1456403814
            Voices.Add("G_M_Y_KOREAN_01_KOREAN_MINI_01"); //3975B100"); //964014336"); //964014336
            Voices.Add("G_M_Y_KOREAN_01_KOREAN_MINI_02"); //0F585CC6"); //257449158"); //257449158
            Voices.Add("G_M_Y_KOREAN_02_KOREAN_MINI_01"); //E1E0349F"); //3789567135"); //Voices.Add("505400161
            Voices.Add("G_M_Y_KOREAN_02_KOREAN_MINI_02"); //D41A1913"); //3558480147"); //Voices.Add("736487149
            Voices.Add("G_M_Y_KORLIEUT_01_KOREAN_MINI_01"); //6B9A636E"); //1805280110"); //1805280110
            Voices.Add("G_M_Y_KORLIEUT_01_KOREAN_MINI_02"); //2116CE64"); //555142756"); //555142756
            Voices.Add("G_M_Y_LATINO01_LATINO_MINI_02"); //215F60FC"); //559898876"); //559898876
            Voices.Add("G_M_Y_LOST_01_BLACK_FULL_01"); //BD922FD5"); //3180474325"); //Voices.Add("1114492971
            Voices.Add("G_M_Y_LOST_01_BLACK_FULL_02"); //06D7C263"); //114803299"); //114803299
            Voices.Add("G_M_Y_LOST_01_BLACK_MINI_01"); //D03903FA"); //3493397498"); //Voices.Add("801569798
            Voices.Add("G_M_Y_LOST_01_BLACK_MINI_02"); //0154E631"); //22341169"); //22341169
            Voices.Add("G_M_Y_LOST_01_BLACK_MINI_03"); //2ADE3943"); //719206723"); //719206723
            Voices.Add("G_M_Y_LOST_01_WHITE_FULL_01"); //A29BB240"); //2728112704"); //Voices.Add("1566854592
            Voices.Add("G_M_Y_LOST_01_WHITE_MINI_01"); //0477B521"); //74954017"); //74954017
            Voices.Add("G_M_Y_LOST_01_WHITE_MINI_02"); //D6005837"); //3590346807"); //Voices.Add("704620489
            Voices.Add("G_M_Y_LOST_02_LATINO_FULL_01"); //93D0C3D0"); //2479932368"); //Voices.Add("1815034928
            Voices.Add("G_M_Y_LOST_02_LATINO_FULL_02"); //DD9DD769"); //3718109033"); //Voices.Add("576858263
            Voices.Add("G_M_Y_LOST_02_LATINO_MINI_01"); //B4A96868"); //3031001192"); //Voices.Add("1263966104
            Voices.Add("G_M_Y_LOST_02_LATINO_MINI_02"); //C34E85B2"); //3276703154"); //Voices.Add("1018264142
            Voices.Add("G_M_Y_LOST_02_LATINO_MINI_03"); //D1C5229F"); //3519357599"); //Voices.Add("775609697
            Voices.Add("G_M_Y_LOST_02_WHITE_FULL_01"); //552D4F23"); //1429032739"); //1429032739
            Voices.Add("G_M_Y_LOST_02_WHITE_MINI_01"); //AC382220"); //2889359904"); //Voices.Add("1405607392
            Voices.Add("G_M_Y_LOST_02_WHITE_MINI_02"); //302D2A08"); //808266248"); //808266248
            Voices.Add("G_M_Y_LOST_03_WHITE_FULL_01"); //269A2029"); //647634985"); //647634985
            Voices.Add("G_M_Y_LOST_03_WHITE_MINI_02"); //19793B32"); //427375410"); //427375410
            Voices.Add("G_M_Y_LOST_03_WHITE_MINI_03"); //6C55606D"); //1817534573"); //1817534573
            Voices.Add("G_M_Y_MEXGOON_01_LATINO_MINI_01"); //57C1000E"); //1472266254"); //1472266254
            Voices.Add("G_M_Y_MEXGOON_01_LATINO_MINI_02"); //4F90EFAA"); //1334898602"); //1334898602
            Voices.Add("G_M_Y_MEXGOON_02_LATINO_MINI_01"); //B00D3337"); //2953655095"); //Voices.Add("1341312201
            Voices.Add("G_M_Y_MEXGOON_02_LATINO_MINI_02"); //6A4227A2"); //1782720418"); //1782720418
            Voices.Add("G_M_Y_MEXGOON_03_LATINO_MINI_01"); //36640278"); //912523896"); //912523896
            Voices.Add("G_M_Y_MEXGOON_03_LATINO_MINI_02"); //45EBA187"); //1173070215"); //1173070215
            Voices.Add("G_M_Y_POLOGOON_01_LATINO_MINI_01"); //D1389B20"); //3510147872"); //Voices.Add("784819424
            Voices.Add("G_M_Y_POLOGOON_01_LATINO_MINI_02"); //DBFFB0AE"); //3690967214"); //Voices.Add("604000082
            Voices.Add("G_M_Y_SALVABOSS_01_SALVADORIAN_MINI_01"); //083FF1D1"); //138408401"); //138408401
            Voices.Add("G_M_Y_SALVABOSS_01_SALVADORIAN_MINI_02"); //FB1D578C"); //4213004172"); //Voices.Add("81963124
            Voices.Add("G_M_Y_SALVAGOON_01_SALVADORIAN_MINI_01"); //0E2D970B"); //237868811"); //237868811
            Voices.Add("G_M_Y_SALVAGOON_01_SALVADORIAN_MINI_02"); //C9228CF6"); //3374484726"); //Voices.Add("920482570
            Voices.Add("G_M_Y_SALVAGOON_01_SALVADORIAN_MINI_03"); //D6DD286B"); //3604818027"); //Voices.Add("690149269
            Voices.Add("G_M_Y_SALVAGOON_02_SALVADORIAN_MINI_01"); //38FB557B"); //955995515"); //955995515
            Voices.Add("G_M_Y_SalvaGoon_02_SALVADORIAN_MINI_02"); //2B1E39C1"); //723401153"); //723401153
            Voices.Add("G_M_Y_SALVAGOON_02_SALVADORIAN_MINI_03"); //1C639C4C"); //476290124"); //476290124
            Voices.Add("G_M_Y_SALVAGOON_03_SALVADORIAN_MINI_01"); //B2F150B6"); //3002159286"); //Voices.Add("1292808010
            Voices.Add("G_M_Y_SALVAGOON_03_SALVADORIAN_MINI_02"); //50C88C62"); //1355320418"); //1355320418
            Voices.Add("G_M_Y_SalvaGoon_03_SALVADORIAN_MINI_03"); //61092CDF"); //1627991263"); //1627991263
            Voices.Add("G_M_Y_STREETPUNK02_BLACK_MINI_04"); //5E2969AE"); //1579772334"); //1579772334
            Voices.Add("G_M_Y_STREETPUNK_01_BLACK_MINI_01"); //A5364DA4"); //2771799460"); //Voices.Add("1523167836
            Voices.Add("G_M_Y_STREETPUNK_01_BLACK_MINI_02"); //7AD978EB"); //2061072619"); //2061072619
            Voices.Add("G_M_Y_STREETPUNK_01_BLACK_MINI_03"); //4A3417A1"); //1244927905"); //1244927905
            Voices.Add("G_M_Y_STREETPUNK_02_BLACK_MINI_01"); //4C3FB5C7"); //1279243719"); //1279243719
            Voices.Add("G_M_Y_STREETPUNK_02_BLACK_MINI_02"); //658FE867"); //1703929959"); //1703929959
            Voices.Add("G_M_Y_STREETPUNK_02_BLACK_MINI_03"); //58794E3A"); //1484344890"); //1484344890
            Voices.Add("G_M_Y_X17_AGUARD_01"); //0FC95A0C"); //264854028"); //264854028
            Voices.Add("G_M_Y_X17_AGUARD_02"); //1AEC7052"); //451702866"); //451702866
            Voices.Add("G_M_Y_X17_AGUARD_03"); //ED3E94F7"); //3980301559"); //Voices.Add("314665737
            Voices.Add("G_M_Y_X17_AGUARD_04"); //71369CE9"); //1899404521"); //1899404521
            Voices.Add("G_M_Y_X17_AGUARD_05"); //7B64B145"); //2070196549"); //2070196549
            Voices.Add("HAO"); //5F91F8AE"); //1603401902"); //1603401902
            Voices.Add("HEISTMANAGER"); //3F3FAB0F"); //1061137167"); //1061137167
            Voices.Add("HOSTAGEBF1"); //D5D22CA5"); //3587320997"); //Voices.Add("707646299
            Voices.Add("HOSTAGEBM1"); //E8CB2CFF"); //3905629439"); //Voices.Add("389337857
            Voices.Add("HOSTAGEWF1"); //8632FA43"); //2251487811"); //Voices.Add("2043479485
            Voices.Add("HOSTAGEWF2"); //99952107"); //2576687367"); //Voices.Add("1718279929
            Voices.Add("HOSTAGEWM1"); //5779B631"); //1467594289"); //1467594289
            Voices.Add("HOSTAGEWM2"); //9F53C5E4"); //2673067492"); //Voices.Add("1621899804
            Voices.Add("HUGH"); //F4EE78A9"); //4109269161"); //Voices.Add("185698135
            Voices.Add("IMPOTENT_RAGE"); //BE080ED8"); //3188199128"); //Voices.Add("1106768168
            Voices.Add("INFERNUS"); //18F25AC7"); //418536135"); //418536135
            Voices.Add("JANE"); //893E74D0"); //2302571728"); //Voices.Add("1992395568
            Voices.Add("JANET"); //8498F40B"); //2224616459"); //Voices.Add("2070350837
            Voices.Add("JEROME"); //D982DA50"); //3649231440"); //Voices.Add("645735856
            Voices.Add("JESSE"); //916BB095"); //2439753877"); //Voices.Add("1855213419
            Voices.Add("JIMMY_DRUNK"); //43C1EB55"); //1136782165"); //1136782165
            Voices.Add("JIMMY_NORMAL"); //95810242"); //2508259906"); //Voices.Add("1786707390
            Voices.Add("JOE"); //07CC375A"); //130824026"); //130824026
            Voices.Add("JOSEF"); //F63ED80C"); //4131313676"); //Voices.Add("163653620
            Voices.Add("JOSH"); //F4DDE967"); //4108183911"); //Voices.Add("186783385
            Voices.Add("JULIET"); //27AD5D38"); //665673016"); //665673016
            Voices.Add("KAREN"); //FBF9CDB2"); //4227452338"); //Voices.Add("67514958
            Voices.Add("KARIM"); //DB158746"); //3675621190"); //Voices.Add("619346106
            Voices.Add("KARL"); //D29BCDFD"); //3533426173"); //Voices.Add("761541123
            Voices.Add("KIDNAPPEDFEMALE"); //064DC6E9"); //105760489"); //105760489
            Voices.Add("LACEY"); //29CAB776"); //701151094"); //701151094
            Voices.Add("LAMAR"); //EA22BC4D"); //3928144973"); //Voices.Add("366822323
            Voices.Add("LAMAR_1_NORMAL"); //35FE7226"); //905867814"); //905867814
            Voices.Add("LAMAR_2_NORMAL"); //25068D1D"); //621186333"); //621186333
            Voices.Add("LAMAR_DRUNK"); //648A554F"); //1686787407"); //1686787407
            Voices.Add("LAMAR_NORMAL"); //9D861581"); //2642810241"); //Voices.Add("1652157055
            Voices.Add("LESTER"); //8DB38846"); //2377353286"); //Voices.Add("1917614010
            Voices.Add("LIENGINEER"); //BD5D1E88"); //3176996488"); //Voices.Add("1117970808
            Voices.Add("LIENGINEER2"); //3A58B62B"); //978892331"); //978892331
            Voices.Add("LI_FEMALE_01"); //E58E5187"); //3851309447"); //Voices.Add("443657849
            Voices.Add("LI_GEORGE_01"); //F22854E3"); //4062729443"); //Voices.Add("232237853
            Voices.Add("LI_LOBBY_01"); //3DB175B5"); //1035040181"); //1035040181
            Voices.Add("LI_MALE_01"); //9CF88EB5"); //2633535157"); //Voices.Add("1661432139
            Voices.Add("LI_MALE_02"); //AAB22A28"); //2863802920"); //Voices.Add("1431164376
            Voices.Add("LOSTKIDNAPGIRL"); //7D8F4F88"); //2106544008"); //2106544008
            Voices.Add("MAID"); //015EE6C7"); //22996679"); //22996679
            Voices.Add("MALE_STRIP_DJ_WHITE"); //54825131"); //1417826609"); //1417826609
            Voices.Add("MANI"); //9A9B1CC9"); //2593856713"); //Voices.Add("1701110583
            Voices.Add("MARNIE"); //5FA82CAC"); //1604857004"); //1604857004
            Voices.Add("MARYANN"); //9FEEF145"); //2683236677"); //Voices.Add("1611730619
            Voices.Add("MAUDE"); //1AE32960"); //451094880"); //451094880
            Voices.Add("MELVIN"); //558B495C"); //1435191644"); //1435191644
            Voices.Add("MELVINSCIENTIST"); //E90C6953"); //3909904723"); //Voices.Add("385062573
            Voices.Add("MICHAEL_1_NORMAL"); //78BECF39"); //2025770809"); //2025770809
            Voices.Add("MICHAEL_2_NORMAL"); //568D3564"); //1452094820"); //1452094820
            Voices.Add("MICHAEL_3_NORMAL"); //FBC7F7B9"); //4224186297"); //Voices.Add("70780999
            Voices.Add("MICHAEL_ANGRY"); //973C5F18"); //2537316120"); //Voices.Add("1757651176
            Voices.Add("MICHAEL_DRUNK"); //DEBBCFA7"); //3736850343"); //Voices.Add("558116953
            Voices.Add("MICHAEL_NORMAL"); //C46897D1"); //3295188945"); //Voices.Add("999778351
            Voices.Add("MIME"); //5B25DA1F"); //1529207327"); //1529207327
            Voices.Add("MISTERK"); //FF37663A"); //4281820730"); //Voices.Add("13146566
            Voices.Add("MPCT"); //FF02D40E"); //4278375438"); //Voices.Add("16591858
            Voices.Add("MP_M_SHOPKEEP_01_CHINESE_MINI_01"); //D36AF9E4"); //3547003364"); //Voices.Add("747963932
            Voices.Add("MP_M_SHOPKEEP_01_LATINO_MINI_01"); //0592C339"); //93504313"); //93504313
            Voices.Add("MP_M_SHOPKEEP_01_PAKISTANI_MINI_01"); //25364924"); //624314660"); //624314660
            Voices.Add("MP_RESIDENT"); //844127A9"); //2218862505"); //Voices.Add("2076104791
            Voices.Add("MRSTHORNHILL"); //C6DE44C8"); //3336455368"); //Voices.Add("958511928
            Voices.Add("NERVOUSRON"); //20251950"); //539302224"); //539302224
            Voices.Add("NIGEL"); //F95E18F2"); //4183693554"); //Voices.Add("111273742
            Voices.Add("NIGHT_OUT_FEMALE_01"); //33A0908D"); //866160781"); //866160781
            Voices.Add("NIGHT_OUT_FEMALE_02"); //49EBBD23"); //1240186147"); //1240186147
            Voices.Add("NIGHT_OUT_FEMALE_03"); //831EAF88"); //2199826312"); //Voices.Add("2095140984
            Voices.Add("NIGHT_OUT_FEMALE_04"); //A56CF424"); //2775381028"); //Voices.Add("1519586268
            Voices.Add("NIGHT_OUT_MALE_01"); //41EC4175"); //1106002293"); //1106002293
            Voices.Add("NIGHT_OUT_MALE_02"); //C428C5EC"); //3291006444"); //Voices.Add("1003960852
            Voices.Add("NIKKI"); //47F4D564"); //1207227748"); //1207227748
            Voices.Add("NIKKI_MP"); //11515E1F"); //290545183"); //290545183
            Voices.Add("NORM"); //AE21D168"); //2921451880"); //Voices.Add("1373515416
            Voices.Add("NO_VOICE"); //87BFF09A"); //2277503130"); //Voices.Add("2017464166
            Voices.Add("PACKIE"); //B8791A2F"); //3094944303"); //Voices.Add("1200022993
            Voices.Add("PACKIE_AI_NORM_PART1_BOOTH"); //E0D1A809"); //3771836425"); //Voices.Add("523130871
            Voices.Add("PAIGE"); //C2515320"); //3260109600"); //Voices.Add("1034857696
            Voices.Add("PAIN_FEMALE_01"); //40F0B1B8"); //1089515960"); //1089515960
            Voices.Add("PAIN_FEMALE_02"); //D828602D"); //3626524717"); //Voices.Add("668442579
            Voices.Add("PAIN_FEMALE_NORMAL_01"); //6EF36D3C"); //1861446972"); //1861446972
            Voices.Add("PAIN_FEMALE_NORMAL_02"); //5CECC92F"); //1559021871"); //1559021871
            Voices.Add("PAIN_FEMALE_NORMAL_03"); //8AA3249B"); //2325947547"); //Voices.Add("1969019749
            Voices.Add("PAIN_FEMALE_NORMAL_04"); //78878064"); //2022146148"); //2022146148
            Voices.Add("PAIN_FEMALE_NORMAL_05"); //2629DBA6"); //640277414"); //640277414
            Voices.Add("PAIN_FEMALE_NORMAL_06"); //0BF1A736"); //200386358"); //200386358
            Voices.Add("PAIN_FEMALE_NORMAL_07"); //41699229"); //1097437737"); //1097437737
            Voices.Add("PAIN_FEMALE_NORMAL_08"); //374E7DEF"); //927890927"); //927890927
            Voices.Add("PAIN_FEMALE_NORMAL_09"); //DCDE4910"); //3705555216"); //Voices.Add("589412080
            Voices.Add("PAIN_FEMALE_NORMAL_10"); //966B3B23"); //2523609891"); //Voices.Add("1771357405
            Voices.Add("PAIN_FEMALE_NORMAL_11"); //343976BD"); //876181181"); //876181181
            Voices.Add("PAIN_FEMALE_NORMAL_12"); //21EAD220"); //569037344"); //569037344
            Voices.Add("PAIN_FEMALE_TEST_01"); //95928372"); //2509407090"); //Voices.Add("1785560206
            Voices.Add("PAIN_FEMALE_TEST_02"); //AAE0AE0E"); //2866851342"); //Voices.Add("1428115954
            Voices.Add("PAIN_FEMALE_TEST_03"); //B89E4989"); //3097381257"); //Voices.Add("1197586039
            Voices.Add("PAIN_FRANKLIN_01"); //2003420C"); //537084428"); //537084428
            Voices.Add("PAIN_FRANKLIN_02"); //EBF4D9F0"); //3958692336"); //Voices.Add("336274960
            Voices.Add("PAIN_FRANKLIN_03"); //1DA7BD55"); //497532245"); //497532245
            Voices.Add("PAIN_FRANKLIN_04"); //C5B08D68"); //3316682088"); //Voices.Add("978285208
            Voices.Add("PAIN_MALE_MIXED_01"); //0A14C671"); //169133681"); //169133681
            Voices.Add("PAIN_MALE_MIXED_02"); //A251F75D"); //2723280733"); //Voices.Add("1571686563
            Voices.Add("PAIN_MALE_MIXED_03"); //700712C8"); //1879511752"); //1879511752
            Voices.Add("PAIN_MALE_MIXED_04"); //86A03FFA"); //2258649082"); //Voices.Add("2036318214
            Voices.Add("PAIN_MALE_MIXED_05"); //5124548F"); //1361335439"); //1361335439
            Voices.Add("PAIN_MALE_MIXED_06"); //B25B96FC"); //2992346876"); //Voices.Add("1302620420
            Voices.Add("PAIN_MALE_MIXED_07"); //BC96AB72"); //3163990898"); //Voices.Add("1130976398
            Voices.Add("PAIN_MALE_MIXED_08"); //8DA5CD91"); //2376453521"); //Voices.Add("1918513775
            Voices.Add("PAIN_MALE_MIXED_09"); //97EBE21D"); //2548818461"); //Voices.Add("1746148835
            Voices.Add("PAIN_MALE_NORMAL_01"); //E3B792BC"); //3820458684"); //Voices.Add("474508612
            Voices.Add("PAIN_MALE_NORMAL_02"); //145573EB"); //341144555"); //341144555
            Voices.Add("PAIN_MALE_NORMAL_03"); //E296906E"); //3801518190"); //Voices.Add("493449106
            Voices.Add("PAIN_MALE_NORMAL_04"); //B7C53ACC"); //3083156172"); //Voices.Add("1211811124
            Voices.Add("PAIN_MALE_NORMAL_05"); //09F45F29"); //167010089"); //167010089
            Voices.Add("PAIN_MALE_NORMAL_06"); //CB49E1D5"); //3410616789"); //Voices.Add("884350507
            Voices.Add("PAIN_MALE_TOUGH_01"); //ACC806D0"); //2898790096"); //Voices.Add("1396177200
            Voices.Add("PAIN_MALE_TOUGH_02"); //DB33E3A7"); //3677610919"); //Voices.Add("617356377
            Voices.Add("PAIN_MALE_TOUGH_03"); //90FF4F3B"); //2432651067"); //Voices.Add("1862316229
            Voices.Add("PAIN_MALE_TOUGH_04"); //BF202B80"); //3206556544"); //Voices.Add("1088410752
            Voices.Add("PAIN_MALE_TOUGH_05"); //F397946E"); //4086797422"); //Voices.Add("208169874
            Voices.Add("PAIN_MALE_WEAK_01"); //22C36EE8"); //583233256"); //583233256
            Voices.Add("PAIN_MALE_WEAK_02"); //B05B0A1D"); //2958756381"); //Voices.Add("1336210915
            Voices.Add("PAIN_MALE_WEAK_03"); //D62355AD"); //3592639917"); //Voices.Add("702327379
            Voices.Add("PAIN_MALE_WEAK_04"); //E61CF5A0"); //3860657568"); //Voices.Add("434309728
            Voices.Add("PAIN_MICHAEL_01"); //E657BAA9"); //3864509097"); //Voices.Add("430458199
            Voices.Add("PAIN_MICHAEL_02"); //D8151E24"); //3625262628"); //Voices.Add("669704668
            Voices.Add("PAIN_MICHAEL_03"); //3436D666"); //876009062"); //876009062
            Voices.Add("PAIN_MICHAEL_04"); //66EB3BD2"); //1726692306"); //1726692306
            Voices.Add("PAIN_PLAYER_TEST_01"); //F38B2CC2"); //4085984450"); //Voices.Add("208982846
            Voices.Add("PAIN_PLAYER_TEST_02"); //E161886F"); //3781265519"); //Voices.Add("513701777
            Voices.Add("PAIN_PLAYER_TEST_03"); //576C746B"); //1466725483"); //1466725483
            Voices.Add("PAIN_TEST_01"); //F5655828"); //4117059624"); //Voices.Add("177907672
            Voices.Add("PAIN_TEST_02"); //FC1C6596"); //4229719446"); //Voices.Add("65247850
            Voices.Add("PAIN_TEST_03"); //172E9BA2"); //388930466"); //388930466
            Voices.Add("PAIN_TREVOR_01"); //21261ADB"); //556145371"); //556145371
            Voices.Add("PAIN_TREVOR_02"); //32DCBE48"); //853327432"); //853327432
            Voices.Add("PAIN_TREVOR_03"); //3DAED3EC"); //1034867692"); //1034867692
            Voices.Add("PAIN_TREVOR_04"); //4F427713"); //1329755923"); //1329755923
            Voices.Add("PAMELA_DRAKE"); //714E62B7"); //1900962487"); //1900962487
            Voices.Add("PANIC_WALLA"); //14DEB561"); //350139745"); //350139745
            Voices.Add("PATRICIA"); //D22B34C3"); //3526046915"); //Voices.Add("768920381
            Voices.Add("PEACH"); //FE7FCDEA"); //4269788650"); //Voices.Add("25178646
            Voices.Add("PEYOTE_ATTRACT_BOAR"); //44E0B0C1"); //1155576001"); //1155576001
            Voices.Add("PEYOTE_ATTRACT_CAT"); //957D8693"); //2508031635"); //Voices.Add("1786935661
            Voices.Add("PEYOTE_ATTRACT_CHICKENHAWK"); //37642D77"); //929312119"); //929312119
            Voices.Add("PEYOTE_ATTRACT_CORMORANT"); //25B89DC4"); //632856004"); //632856004
            Voices.Add("PEYOTE_ATTRACT_COW"); //D18269E8"); //3514984936"); //Voices.Add("779982360
            Voices.Add("PEYOTE_ATTRACT_COYOTE"); //CACF8A4A"); //3402598986"); //Voices.Add("892368310
            Voices.Add("PEYOTE_ATTRACT_CROW"); //4ECC966B"); //1322030699"); //1322030699
            Voices.Add("PEYOTE_ATTRACT_DEER"); //F0A3CD5D"); //4037266781"); //Voices.Add("257700515
            Voices.Add("PEYOTE_ATTRACT_DOLPHIN"); //59448EA4"); //1497665188"); //1497665188
            Voices.Add("PEYOTE_ATTRACT_HEN"); //E2D7CD2E"); //3805793582"); //Voices.Add("489173714
            Voices.Add("PEYOTE_ATTRACT_HUSKY"); //3E0E6964"); //1041131876"); //1041131876
            Voices.Add("PEYOTE_ATTRACT_MTLION"); //14EF12E9"); //351212265"); //351212265
            Voices.Add("PEYOTE_ATTRACT_PIG"); //49848323"); //1233421091"); //1233421091
            Voices.Add("PEYOTE_ATTRACT_PIGEON"); //8E48AAC7"); //2387126983"); //Voices.Add("1907840313
            Voices.Add("PEYOTE_ATTRACT_RABBIT"); //93CBB169"); //2479599977"); //Voices.Add("1815367319
            Voices.Add("PEYOTE_ATTRACT_RETRIEVER"); //7B353C1A"); //2067086362"); //2067086362
            Voices.Add("PEYOTE_ATTRACT_ROTTWEILER"); //0131CB79"); //20040569"); //20040569
            Voices.Add("PEYOTE_ATTRACT_SASQUATCH"); //068101D6"); //109117910"); //109117910
            Voices.Add("PEYOTE_ATTRACT_SEAGULL"); //427EF9C8"); //1115617736"); //1115617736
            Voices.Add("PEYOTE_ATTRACT_SEA_CREATURE"); //5A3979EC"); //1513716204"); //1513716204
            Voices.Add("PEYOTE_ATTRACT_SHEPHERD"); //5CA8ACB0"); //1554558128"); //1554558128
            Voices.Add("PEYOTE_ATTRACT_SMALL_DOG"); //517711B0"); //1366757808"); //1366757808
            Voices.Add("PIER_ANNOUNCE_FEMALE"); //3AB5E64D"); //984999501"); //984999501
            Voices.Add("PIER_ANNOUNCE_MALE"); //9567A0E1"); //2506596577"); //Voices.Add("1788370719
            Voices.Add("PIER_FOLEY"); //58EA9491"); //1491768465"); //1491768465
            Voices.Add("PLAYER_RINGTONES"); //3A3B02D3"); //976945875"); //976945875
            Voices.Add("PRISONER"); //7EA26372"); //2124571506"); //2124571506
            Voices.Add("PRISON_ANNOUNCER"); //9BEE7F20"); //2616098592"); //Voices.Add("1678868704
            Voices.Add("PRISON_TANNOY"); //E5DCB564"); //3856446820"); //Voices.Add("438520476
            Voices.Add("REDOCASTRO"); //CED55457"); //3470087255"); //Voices.Add("824880041
            Voices.Add("REDR1DRUNK1"); //4184DA81"); //1099225729"); //1099225729
            Voices.Add("REDR1DRUNK1_AI_DRUNK"); //2B10FBD7"); //722533335"); //722533335
            Voices.Add("REDR2DRUNKM"); //51408669"); //1363183209"); //1363183209
            Voices.Add("REHH2HIKER"); //92977683"); //2459399811"); //Voices.Add("1835567485
            Voices.Add("REHH3HIPSTER"); //C0147C2B"); //3222567979"); //Voices.Add("1072399317
            Voices.Add("REHH5BRIDE"); //923B42A5"); //2453357221"); //Voices.Add("1841610075
            Voices.Add("REHOMGIRL"); //745E2A7D"); //1952328317"); //1952328317
            Voices.Add("REPRI1LOST"); //4E9991FE"); //1318687230"); //1318687230
            Voices.Add("SAPPHIRE"); //74F8F352"); //1962472274"); //1962472274
            Voices.Add("SECUROMECH"); //9C7CE8C0"); //2625431744"); //Voices.Add("1669535552
            Voices.Add("SHOPASSISTANT"); //53912D70"); //1402023280"); //1402023280
            Voices.Add("SIMEON"); //82816017"); //2189516823"); //Voices.Add("2105450473
            Voices.Add("SOL1ACTOR"); //4B0CAD83"); //1259122051"); //1259122051
            Voices.Add("SPACE_RANGER"); //21D80107"); //567804167"); //567804167
            Voices.Add("STEVE"); //CE95B9A9"); //3465918889"); //Voices.Add("829048407
            Voices.Add("STRETCH"); //8B13F083"); //2333339779"); //Voices.Add("1961627517
            Voices.Add("SUBWAY_ANNOUNCER"); //1C2F9BF2"); //472882162"); //472882162
            Voices.Add("S_F_M_FEMBARBER_BLACK_MINI_01"); //4B82A928"); //1266854184"); //1266854184
            Voices.Add("S_F_M_GENERICCHEAPWORKER_01_LATINO_MINI_01"); //E085EF87"); //3766873991"); //Voices.Add("528093305
            Voices.Add("S_F_M_GENERICCHEAPWORKER_01_LATINO_MINI_02"); //EA440303"); //3930325763"); //Voices.Add("364641533
            Voices.Add("S_F_M_GENERICCHEAPWORKER_01_LATINO_MINI_03"); //51565112"); //1364611346"); //1364611346
            Voices.Add("S_F_M_PONSEN_01_BLACK_01"); //B60A191B"); //3054115099"); //Voices.Add("1240852197
            Voices.Add("S_F_M_SHOP_HIGH_WHITE_MINI_01"); //AD7E25AA"); //2910725546"); //Voices.Add("1384241750
            Voices.Add("S_F_Y_AIRHOSTESS_01_BLACK_FULL_01"); //50B140C7"); //1353793735"); //1353793735
            Voices.Add("S_F_Y_AIRHOSTESS_01_BLACK_FULL_02"); //D0FFC16E"); //3506422126"); //Voices.Add("788545170
            Voices.Add("S_F_Y_AIRHOSTESS_01_WHITE_FULL_01"); //090B4CD4"); //151735508"); //151735508
            Voices.Add("S_F_Y_AIRHOSTESS_01_WHITE_FULL_02"); //E1B67E2B"); //3786833451"); //Voices.Add("508133845
            Voices.Add("S_F_Y_BAYWATCH_01_BLACK_FULL_01"); //F33860E9"); //4080558313"); //Voices.Add("214408983
            Voices.Add("S_F_Y_BAYWATCH_01_BLACK_FULL_02"); //880F0A98"); //2282687128"); //Voices.Add("2012280168
            Voices.Add("S_F_Y_BAYWATCH_01_WHITE_FULL_01"); //26DECE02"); //652135938"); //652135938
            Voices.Add("S_F_Y_BAYWATCH_01_WHITE_FULL_02"); //35226A89"); //891447945"); //891447945
            Voices.Add("S_F_Y_Cop_01_BLACK_FULL_01"); //EFB0FA91"); //4021353105"); //Voices.Add("273614191
            Voices.Add("S_F_Y_COP_01_BLACK_FULL_02"); //62A6E07B"); //1655103611"); //1655103611
            Voices.Add("S_F_Y_COP_01_WHITE_FULL_01"); //EB73C44F"); //3950232655"); //Voices.Add("344734641
            Voices.Add("S_F_Y_COP_01_WHITE_FULL_02"); //F9C560F2"); //4190462194"); //Voices.Add("104505102
            Voices.Add("S_F_Y_GENERICCHEAPWORKER_01_BLACK_MINI_01"); //44ACE464"); //1152181348"); //1152181348
            Voices.Add("S_F_Y_GENERICCHEAPWORKER_01_BLACK_MINI_02"); //3707C91A"); //923257114"); //923257114
            Voices.Add("S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_01"); //A135DE73"); //2704662131"); //Voices.Add("1590305165
            Voices.Add("S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_02"); //CF08BA18"); //3473455640"); //Voices.Add("821511656
            Voices.Add("S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_03"); //BC269454"); //3156644948"); //Voices.Add("1138322348
            Voices.Add("S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_04"); //EB8E7323"); //3951981347"); //Voices.Add("342985949
            Voices.Add("S_F_Y_GENERICCHEAPWORKER_01_WHITE_MINI_01"); //E5EAA67A"); //3857360506"); //Voices.Add("437606790
            Voices.Add("S_F_Y_GENERICCHEAPWORKER_01_WHITE_MINI_02"); //39B64E08"); //968248840"); //968248840
            Voices.Add("S_F_Y_HOOKER_01_WHITE_FULL_01"); //18B73C7E"); //414661758"); //414661758
            Voices.Add("S_F_Y_HOOKER_01_WHITE_FULL_02"); //66F658FB"); //1727420667"); //1727420667
            Voices.Add("S_F_Y_HOOKER_01_WHITE_FULL_03"); //75E576D9"); //1977972441"); //1977972441
            Voices.Add("S_F_Y_HOOKER_02_WHITE_FULL_01"); //77BE674B"); //2008966987"); //2008966987
            Voices.Add("S_F_Y_HOOKER_02_WHITE_FULL_02"); //09978AFF"); //160926463"); //160926463
            Voices.Add("S_F_Y_HOOKER_02_WHITE_FULL_03"); //1B382E40"); //456666688"); //456666688
            Voices.Add("S_F_Y_HOOKER_03_BLACK_FULL_01"); //875814D6"); //2270696662"); //Voices.Add("2024270634
            Voices.Add("S_F_Y_HOOKER_03_BLACK_FULL_03"); //129DAB5F"); //312322911"); //312322911
            Voices.Add("S_F_Y_PECKER_01_WHITE_01"); //6B019062"); //1795264610"); //1795264610
            Voices.Add("S_F_Y_RANGER_01_WHITE_MINI_01"); //47A85382"); //1202213762"); //1202213762
            Voices.Add("S_F_Y_SHOP_LOW_WHITE_MINI_01"); //ED77E493"); //3984057491"); //Voices.Add("310909805
            Voices.Add("S_F_Y_SHOP_MID_WHITE_MINI_01"); //77B47F14"); //2008317716"); //2008317716
            Voices.Add("S_M_M_AMMUCOUNTRY_01_WHITE_01"); //14AE106F"); //346951791"); //346951791
            Voices.Add("S_M_M_AMMUCOUNTRY_WHITE_MINI_01"); //B6A5CF41"); //3064319809"); //Voices.Add("1230647487
            Voices.Add("S_M_M_AUTOSHOP_01_WHITE_01"); //B97E410A"); //3112059146"); //Voices.Add("1182908150
            Voices.Add("S_M_M_BOUNCER_01_BLACK_FULL_01"); //5CF368B8"); //1559455928"); //1559455928
            Voices.Add("S_M_M_BOUNCER_01_LATINO_FULL_01"); //57B91BD3"); //1471749075"); //1471749075
            Voices.Add("S_M_M_BOUNCER_LATINO_FULL_01"); //66E1CE62"); //1726074466"); //1726074466
            Voices.Add("S_M_M_CIASEC_01_BLACK_MINI_01"); //797CD9E6"); //2038225382"); //2038225382
            Voices.Add("S_M_M_CIASEC_01_BLACK_MINI_02"); //F6AED44C"); //4138652748"); //Voices.Add("156314548
            Voices.Add("S_M_M_CIASEC_01_WHITE_MINI_01"); //7DB88D9D"); //2109246877"); //2109246877
            Voices.Add("S_M_M_CIASEC_01_WHITE_MINI_02"); //AF77F11B"); //2943873307"); //Voices.Add("1351093989
            Voices.Add("S_M_M_FIBOFFICE_01_BLACK_MINI_01"); //DEA5CD64"); //3735407972"); //Voices.Add("559559324
            Voices.Add("S_M_M_FIBOFFICE_01_BLACK_MINI_02"); //F0C0F19A"); //4039176602"); //Voices.Add("255790694
            Voices.Add("S_M_M_FIBOFFICE_01_LATINO_MINI_01"); //655117C7"); //1699813319"); //1699813319
            Voices.Add("S_M_M_FIBOFFICE_01_LATINO_MINI_02"); //938DF440"); //2475553856"); //Voices.Add("1819413440
            Voices.Add("S_M_M_FIBOFFICE_01_WHITE_MINI_01"); //0AC9249C"); //180954268"); //180954268
            Voices.Add("S_M_M_FIBOFFICE_01_WHITE_MINI_02"); //FE040B12"); //4261677842"); //Voices.Add("33289454
            Voices.Add("S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_01"); //90328A79"); //2419231353"); //Voices.Add("1875735943
            Voices.Add("S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_02"); //D9249C5C"); //3643055196"); //Voices.Add("651912100
            Voices.Add("S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_03"); //EBDDC1CE"); //3957178830"); //Voices.Add("337788466
            Voices.Add("S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_04"); //635D30CB"); //1667051723"); //1667051723
            Voices.Add("S_M_M_GENERICMARINE_01_LATINO_MINI_01"); //24A78E34"); //614960692"); //614960692
            Voices.Add("S_M_M_GENERICMARINE_01_LATINO_MINI_02"); //8F6E63C0"); //2406376384"); //Voices.Add("1888590912
            Voices.Add("S_M_M_GENERICMECHANIC_01_BLACK_MINI_01"); //229CDFDF"); //580706271"); //580706271
            Voices.Add("S_M_M_GENERICMECHANIC_01_BLACK_MINI_02"); //09392D18"); //154742040"); //154742040
            Voices.Add("S_M_M_GENERICPOSTWORKER_01_BLACK_MINI_01"); //10C0CBFD"); //281070589"); //281070589
            Voices.Add("S_M_M_GENERICPOSTWORKER_01_BLACK_MINI_02"); //FC16A2A9"); //4229341865"); //Voices.Add("65625431
            Voices.Add("S_M_M_GENERICPOSTWORKER_01_WHITE_MINI_01"); //D2C75726"); //3536279334"); //Voices.Add("758687962
            Voices.Add("S_M_M_GENERICPOSTWORKER_01_WHITE_MINI_02"); //DC906AB8"); //3700452024"); //Voices.Add("594515272
            Voices.Add("S_M_M_GENERICSECURITY_01_BLACK_MINI_01"); //3D1D46D3"); //1025328851"); //1025328851
            Voices.Add("S_M_M_GENERICSECURITY_01_BLACK_MINI_02"); //565A794D"); //1448769869"); //1448769869
            Voices.Add("S_M_M_GENERICSECURITY_01_BLACK_MINI_03"); //9162EF15"); //2439180053"); //Voices.Add("1855787243
            Voices.Add("S_M_M_GENERICSECURITY_01_LATINO_MINI_01"); //B5910C1D"); //3046181917"); //Voices.Add("1248785379
            Voices.Add("S_M_M_GENERICSECURITY_01_LATINO_MINI_02"); //97D1D09F"); //2547110047"); //Voices.Add("1747857249
            Voices.Add("S_M_M_GENERICSECURITY_01_WHITE_MINI_01"); //5D4BE0A9"); //1565253801"); //1565253801
            Voices.Add("S_M_M_GENERICSECURITY_01_WHITE_MINI_02"); //4FE145D4"); //1340163540"); //1340163540
            Voices.Add("S_M_M_GENERICSECURITY_01_WHITE_MINI_03"); //66DDF3D9"); //1725821913"); //1725821913
            Voices.Add("S_M_M_HAIRDRESSER_01_BLACK_MINI_01"); //594BCB86"); //1498139526"); //1498139526
            Voices.Add("S_M_M_HAIRDRESS_01_BLACK_01"); //7E2CBE66"); //2116861542"); //2116861542
            Voices.Add("S_M_M_PARAMEDIC_01_BLACK_MINI_01"); //1DE649B3"); //501631411"); //501631411
            Voices.Add("S_M_M_PARAMEDIC_01_LATINO_MINI_01"); //43261273"); //1126568563"); //1126568563
            Voices.Add("S_M_M_PARAMEDIC_01_WHITE_MINI_01"); //54925FD6"); //1418878934"); //1418878934
            Voices.Add("S_M_M_PILOT_01_BLACK_FULL_01"); //3DAC41B0"); //1034699184"); //1034699184
            Voices.Add("S_M_M_PILOT_01_BLACK_FULL_02"); //4F73E53F"); //1332995391"); //1332995391
            Voices.Add("S_M_M_PILOT_01_WHITE_FULL_01"); //BC0F504A"); //3155120202"); //Voices.Add("1139847094
            Voices.Add("S_M_M_PILOT_01_WHITE_FULL_02"); //A9A32B72"); //2846042994"); //Voices.Add("1448924302
            Voices.Add("S_M_M_TRUCKER_01_BLACK_FULL_01"); //D940A3BC"); //3644892092"); //Voices.Add("650075204
            Voices.Add("S_M_M_TRUCKER_01_WHITE_FULL_01"); //3CA3269A"); //1017325210"); //1017325210
            Voices.Add("S_M_M_TRUCKER_01_WHITE_FULL_02"); //0B4743DF"); //189219807"); //189219807
            Voices.Add("S_M_Y_AIRWORKER_BLACK_FULL_01"); //90ECCFDC"); //2431438812"); //Voices.Add("1863528484
            Voices.Add("S_M_Y_AIRWORKER_BLACK_FULL_02"); //9EAF6B61"); //2662296417"); //Voices.Add("1632670879
            Voices.Add("S_M_Y_AIRWORKER_LATINO_FULL_01"); //0D981AB3"); //228072115"); //228072115
            Voices.Add("S_M_Y_AIRWORKER_LATINO_FULL_02"); //234F4621"); //592397857"); //592397857
            Voices.Add("S_M_Y_AMMUCITY_01_WHITE_01"); //5C7526F0"); //1551181552"); //1551181552
            Voices.Add("S_M_Y_AMMUCITY_01_WHITE_MINI_01"); //20C18390"); //549553040"); //549553040
            Voices.Add("S_M_Y_BAYWATCH_01_BLACK_FULL_01"); //CD79387C"); //3447273596"); //Voices.Add("847693700
            Voices.Add("S_M_Y_BAYWATCH_01_BLACK_FULL_02"); //E32263CE"); //3810681806"); //Voices.Add("484285490
            Voices.Add("S_M_Y_BAYWATCH_01_WHITE_FULL_01"); //BAB6D724"); //3132544804"); //Voices.Add("1162422492
            Voices.Add("S_M_Y_BAYWATCH_01_WHITE_FULL_02"); //1EA89F06"); //514367238"); //514367238
            Voices.Add("S_M_Y_BLACKOPS_01_BLACK_MINI_01"); //BBE7E188"); //3152535944"); //Voices.Add("1142431352
            Voices.Add("S_M_Y_BLACKOPS_01_BLACK_MINI_02"); //DDB7A52B"); //3719800107"); //Voices.Add("575167189
            Voices.Add("S_M_Y_BLACKOPS_01_WHITE_MINI_01"); //65B98207"); //1706656263"); //1706656263
            Voices.Add("S_M_Y_BLACKOPS_01_WHITE_MINI_02"); //D7FFE692"); //3623872146"); //Voices.Add("671095150
            Voices.Add("S_M_Y_BLACKOPS_02_LATINO_MINI_01"); //4214AE9E"); //1108651678"); //1108651678
            Voices.Add("S_M_Y_BLACKOPS_02_LATINO_MINI_02"); //13E2520A"); //333599242"); //333599242
            Voices.Add("S_M_Y_BLACKOPS_02_WHITE_MINI_01"); //C3A6E830"); //3282495536"); //Voices.Add("1012471760
            Voices.Add("S_M_Y_BUSBOY_01_WHITE_MINI_01"); //C847EAA9"); //3360156329"); //Voices.Add("934810967
            Voices.Add("S_M_Y_COP_01_BLACK_FULL_01"); //DD72FE87"); //3715300999"); //Voices.Add("579666297
            Voices.Add("S_M_Y_COP_01_BLACK_FULL_02"); //C7B3D309"); //3350450953"); //Voices.Add("944516343
            Voices.Add("S_M_Y_COP_01_BLACK_MINI_01"); //EF2409AE"); //4012116398"); //Voices.Add("282850898
            Voices.Add("S_M_Y_COP_01_BLACK_MINI_02"); //00CDAD01"); //13479169"); //13479169
            Voices.Add("S_M_Y_COP_01_BLACK_MINI_03"); //4A804065"); //1249919077"); //1249919077
            Voices.Add("S_M_Y_COP_01_BLACK_MINI_04"); //5C34E3CE"); //1546970062"); //1546970062
            Voices.Add("S_M_Y_COP_01_WHITE_FULL_01"); //6F38027D"); //1865941629"); //1865941629
            Voices.Add("S_M_Y_COP_01_WHITE_FULL_02"); //360C1026"); //906760230"); //906760230
            Voices.Add("S_M_Y_COP_01_WHITE_MINI_01"); //BA399207"); //3124335111"); //Voices.Add("1170632185
            Voices.Add("S_M_Y_COP_01_WHITE_MINI_02"); //CBEB356A"); //3421189482"); //Voices.Add("873777814
            Voices.Add("S_M_Y_COP_01_WHITE_MINI_03"); //DDB458FC"); //3719583996"); //Voices.Add("575383300
            Voices.Add("S_M_Y_COP_01_WHITE_MINI_04"); //EF5EFC51"); //4015979601"); //Voices.Add("278987695
            Voices.Add("S_M_Y_FIREMAN_01_LATINO_FULL_01"); //71549C50"); //1901370448"); //1901370448
            Voices.Add("S_M_Y_FIREMAN_01_LATINO_FULL_02"); //7C0BB1BE"); //2081141182"); //2081141182
            Voices.Add("S_M_Y_FIREMAN_01_WHITE_FULL_01"); //0094A96A"); //9742698"); //9742698
            Voices.Add("S_M_Y_FIREMAN_01_WHITE_FULL_02"); //80DB29FD"); //2161846781"); //Voices.Add("2133120515
            Voices.Add("S_M_Y_GENERICCHEAPWORKER_01_BLACK_MINI_01"); //09FD9FD3"); //167616467"); //167616467
            Voices.Add("S_M_Y_GENERICCHEAPWORKER_01_BLACK_MINI_02"); //37D07B78"); //936409976"); //936409976
            Voices.Add("S_M_Y_GENERICCHEAPWORKER_01_WHITE_MINI_01"); //3869CBA7"); //946457511"); //946457511
            Voices.Add("S_M_Y_GENERICMARINE_01_BLACK_MINI_01"); //17F5909B"); //401969307"); //401969307
            Voices.Add("S_M_Y_GENERICMARINE_01_BLACK_MINI_02"); //0E947DD1"); //244612561"); //244612561
            Voices.Add("S_M_Y_GENERICMARINE_01_WHITE_MINI_01"); //55FDC164"); //1442693476"); //1442693476
            Voices.Add("S_M_Y_GENERICMARINE_01_WHITE_MINI_02"); //08BBA6E1"); //146515681"); //146515681
            Voices.Add("S_M_Y_GENERICWORKER_01_BLACK_MINI_01"); //0A3A301F"); //171585567"); //171585567
            Voices.Add("S_M_Y_GENERICWORKER_01_BLACK_MINI_02"); //60D0DD4B"); //1624300875"); //1624300875
            Voices.Add("S_M_Y_GENERICWORKER_01_LATINO_MINI_01"); //86640419"); //2254701593"); //Voices.Add("2040265703
            Voices.Add("S_M_Y_GENERICWORKER_01_LATINO_MINI_02"); //F4AC60AC"); //4104937644"); //Voices.Add("190029652
            Voices.Add("S_M_Y_GENERICWORKER_01_WHITE_01"); //129AD4A3"); //312136867"); //312136867
            Voices.Add("S_M_Y_GENERICWORKER_01_WHITE_MINI_01"); //E8727D7D"); //3899817341"); //Voices.Add("395149955
            Voices.Add("S_M_Y_GENERICWORKER_01_WHITE_MINI_02"); //B23310FF"); //2989691135"); //Voices.Add("1305276161
            Voices.Add("S_M_Y_HWAYCOP_01_BLACK_FULL_01"); //DC403AA7"); //3695196839"); //Voices.Add("599770457
            Voices.Add("S_M_Y_HWAYCOP_01_BLACK_FULL_02"); //11AAA57B"); //296396155"); //296396155
            Voices.Add("S_M_Y_HWAYCOP_01_WHITE_FULL_01"); //F332D786"); //4080195462"); //Voices.Add("214771834
            Voices.Add("S_M_Y_HWAYCOP_01_WHITE_FULL_02"); //0384F82A"); //59045930"); //59045930
            Voices.Add("S_M_Y_MCOP_01_WHITE_MINI_01"); //7A44FB56"); //2051341142"); //2051341142
            Voices.Add("S_M_Y_MCOP_01_WHITE_MINI_02"); //670ED4EA"); //1729025258"); //1729025258
            Voices.Add("S_M_Y_MCOP_01_WHITE_MINI_03"); //54D0306D"); //1422930029"); //1422930029
            Voices.Add("S_M_Y_MCOP_01_WHITE_MINI_04"); //B361ED8F"); //3009539471"); //Voices.Add("1285427825
            Voices.Add("S_M_Y_MCOP_01_WHITE_MINI_05"); //0F8FA5E9"); //261072361"); //261072361
            Voices.Add("S_M_Y_MCOP_01_WHITE_MINI_06"); //FFE50694"); //4293199508"); //Voices.Add("1767788
            Voices.Add("S_M_Y_RANGER_01_LATINO_FULL_01"); //94EBCA6B"); //2498480747"); //Voices.Add("1796486549
            Voices.Add("S_M_Y_RANGER_01_WHITE_FULL_01"); //9723C55B"); //2535703899"); //Voices.Add("1759263397
            Voices.Add("S_M_Y_SHERIFF_01_WHITE_FULL_01"); //A1C8B88A"); //2714286218"); //Voices.Add("1580681078
            Voices.Add("S_M_Y_SHERIFF_01_WHITE_FULL_02"); //939F1C37"); //2476678199"); //Voices.Add("1818289097
            Voices.Add("S_M_Y_SHOP_MASK_WHITE_MINI_01"); //03AAB8B0"); //61520048"); //61520048
            Voices.Add("S_M_Y_SWAT_01_WHITE_FULL_01"); //BA960340"); //3130393408"); //Voices.Add("1164573888
            Voices.Add("S_M_Y_SWAT_01_WHITE_FULL_02"); //E55E58D0"); //3848165584"); //Voices.Add("446801712
            Voices.Add("S_M_Y_SWAT_01_WHITE_FULL_03"); //F324745C"); //4079252572"); //Voices.Add("215714724
            Voices.Add("S_M_Y_SWAT_01_WHITE_FULL_04"); //0236127F"); //37098111"); //37098111
            Voices.Add("TALINA"); //ED031790"); //3976402832"); //Voices.Add("318564464
            Voices.Add("TAXIALONZO"); //A0B07846"); //2695919686"); //Voices.Add("1599047610
            Voices.Add("TAXIBRUCE"); //1E0A9C18"); //504011800"); //504011800
            Voices.Add("TAXICLYDE"); //90992C60"); //2425957472"); //Voices.Add("1869009824
            Voices.Add("TAXIDARREN"); //2C1A5202"); //739922434"); //739922434
            Voices.Add("TAXIDERRICK"); //2D71435C"); //762397532"); //762397532
            Voices.Add("TAXIDOM"); //9DA9FDB5"); //2645163445"); //Voices.Add("1649803851
            Voices.Add("TAXIFELIPE"); //E66D1B66"); //3865910118"); //Voices.Add("429057178
            Voices.Add("TAXIGANGGIRL1"); //E2228087"); //3793911943"); //Voices.Add("501055353
            Voices.Add("TAXIGANGGIRL2"); //F7E3AC09"); //4158893065"); //Voices.Add("136074231
            Voices.Add("TAXIGANGM"); //08AC318A"); //145502602"); //145502602
            Voices.Add("TAXIJAMES"); //A8A8F64E"); //2829645390"); //Voices.Add("1465321906
            Voices.Add("TAXIKEYLA"); //23ACB127"); //598520103"); //598520103
            Voices.Add("TAXIKWAK"); //58B68A9D"); //1488358045"); //1488358045
            Voices.Add("TAXILIZ"); //C8B6AC99"); //3367414937"); //Voices.Add("927552359
            Voices.Add("TAXIMIRANDA"); //97A199A8"); //2543950248"); //Voices.Add("1751017048
            Voices.Add("TAXIOJCOP1"); //5883C603"); //1485030915"); //1485030915
            Voices.Add("TAXIOTIS"); //A0B868F9"); //2696440057"); //Voices.Add("1598527239
            Voices.Add("TAXIPAULIE"); //05437D58"); //88309080"); //88309080
            Voices.Add("TAXIWALTER"); //1A43E0E1"); //440656097"); //440656097
            Voices.Add("TEST_VOICE"); //62883B8C"); //1653095308"); //1653095308
            Voices.Add("TOM"); //97CBE769"); //2546722665"); //Voices.Add("1748244631
            Voices.Add("TONYA"); //FCB43161"); //4239667553"); //Voices.Add("55299743
            Voices.Add("TRACEY"); //5A7D2459"); //1518150745"); //1518150745
            Voices.Add("TRANSLATOR"); //EAC3FECB"); //3938713291"); //Voices.Add("356254005
            Voices.Add("TREVOR_1_NORMAL"); //3AD6D338"); //987157304"); //987157304
            Voices.Add("TREVOR_2_NORMAL"); //CB2DDB29"); //3408780073"); //Voices.Add("886187223
            Voices.Add("TREVOR_3_NORMAL"); //4697A021"); //1184342049"); //1184342049
            Voices.Add("TREVOR_ANGRY"); //0953FCF8"); //156499192"); //156499192
            Voices.Add("TREVOR_DRUNK"); //EA0CA87A"); //3926698106"); //Voices.Add("368269190
            Voices.Add("TREVOR_NORMAL"); //4072CC77"); //1081265271"); //1081265271
            Voices.Add("U_M_Y_TATTOO_01_WHITE_MINI_01"); //956C178D"); //2506889101"); //Voices.Add("1788078195
            Voices.Add("VB_FEMALE_01"); //CB2136C8"); //3407951560"); //Voices.Add("887015736
            Voices.Add("VB_FEMALE_02"); //E4EA6A5A"); //3840567898"); //Voices.Add("454399398
            Voices.Add("VB_FEMALE_03"); //B1510330"); //2974876464"); //Voices.Add("1320090832
            Voices.Add("VB_FEMALE_04"); //C397A7BD"); //3281495997"); //Voices.Add("1013471299
            Voices.Add("VB_LIFEGUARD_01"); //6B6161EE"); //1801544174"); //1801544174
            Voices.Add("VB_MALE_01"); //AC519660"); //2891028064"); //Voices.Add("1403939232
            Voices.Add("VB_MALE_02"); //B5E5A988"); //3051727240"); //Voices.Add("1243240056
            Voices.Add("VB_MALE_03"); //3A03B192"); //973320594"); //973320594
            Voices.Add("VULTURES"); //18219991"); //404855185"); //404855185
            Voices.Add("WADE"); //7DD049A4"); //2110802340"); //2110802340
            Voices.Add("WAVELOAD_PAIN_FEMALE"); //332128AB"); //857811115"); //857811115
            Voices.Add("WAVELOAD_PAIN_FRANKLIN"); //33F65FC3"); //871784387"); //871784387
            Voices.Add("WAVELOAD_PAIN_MALE"); //804C18BB"); //2152470715"); //Voices.Add("2142496581
            Voices.Add("WAVELOAD_PAIN_MICHAEL"); //6531A692"); //1697752722"); //1697752722
            Voices.Add("WAVELOAD_PAIN_TREVOR"); //0CF83E9F"); //217595551"); //217595551
            Voices.Add("WFSTEWARDESS"); //84EDE1BF"); //2230182335"); //Voices.Add("2064784961
            Voices.Add("WHISTLINGJANITOR"); //168D3E8E"); //378355342"); //378355342
            Voices.Add("YACHTCAPTAIN"); //71C9A806"); //1909041158"); //1909041158
            Voices.Add("ZOMBIE"); //22666A99"); //577137305"); //577137305

            return Voices;
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
                return XmlReadWrite.LoadNames(DataStore.sNamesFile);
            }
            else
                return XmlReadWrite.Named();
        }
        public static List<string> AddonsList()
        {
            LoggerLight.Loggers("DataStore.AddonsList");

            List<string> AddAdds = new List<string>();

            AddAdds.Add("COMPONENT_ADVANCEDRIFLE_CLIP_01");//0xFA8FA10F,
            AddAdds.Add("COMPONENT_ADVANCEDRIFLE_CLIP_02");//0x8EC1C979,
            AddAdds.Add("COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE");//0x377CD377,
            AddAdds.Add("COMPONENT_APPISTOL_CLIP_01");//0x31C4B22A,
            AddAdds.Add("COMPONENT_APPISTOL_CLIP_02");//0x249A17D5,
            AddAdds.Add("COMPONENT_APPISTOL_VARMOD_LUXE");//0x9B76C72C,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_CLIP_01");//0xBE5EEA16,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_CLIP_02");//0xB1214F9B,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_CLIP_03");//0xDBF0A53D,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO");//0x911B24AF,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_02");//0x37E5444B,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_03");//0x538B7B97,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_04");//0x25789F72,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_05");//0xC5495F2D,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_06");//0xCF8B73B1,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_07");//0xA9BB2811,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_08");//0xFC674D54,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_09");//0x7C7FCD9B,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_10");//0xA5C38392,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CAMO_IND_01");//0xB9B15DB0,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_01");//0x8610343F,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_02");//0xD12ACA6F,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING");//0xA7DD1E58,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ");//0x63E0A098,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY");//0xFB70D853,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER");//0xEF2C78C1,
            AddAdds.Add("COMPONENT_ASSAULTRIFLE_VARMOD_LUXE");//0x4EAD7533,
            AddAdds.Add("COMPONENT_ASSAULTSHOTGUN_CLIP_01");//0x94E81BC7,
            AddAdds.Add("COMPONENT_ASSAULTSHOTGUN_CLIP_02");//0x86BD7F72,
            AddAdds.Add("COMPONENT_ASSAULTSMG_CLIP_01");//0x8D1307B0,
            AddAdds.Add("COMPONENT_ASSAULTSMG_CLIP_02");//0xBB46E417,
            AddAdds.Add("COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER");//0x278C78AF,
            AddAdds.Add("COMPONENT_AT_AR_AFGRIP");//0xC164F53,
            AddAdds.Add("COMPONENT_AT_AR_AFGRIP_02");//0x9D65907A,
            AddAdds.Add("COMPONENT_AT_AR_BARREL_01");//0x43A49D26,
            AddAdds.Add("COMPONENT_AT_AR_BARREL_02");//0x5646C26A,
            AddAdds.Add("COMPONENT_AT_AR_FLSH");//0x7BC4CDDC,
            AddAdds.Add("COMPONENT_AT_AR_SUPP");//0x837445AA,
            AddAdds.Add("COMPONENT_AT_AR_SUPP_02");//0xA73D4664,
            AddAdds.Add("COMPONENT_AT_BP_BARREL_01");//0x659AC11B,
            AddAdds.Add("COMPONENT_AT_BP_BARREL_02");//0x3BF26DC7,
            AddAdds.Add("COMPONENT_AT_CR_BARREL_01");//0x833637FF,
            AddAdds.Add("COMPONENT_AT_CR_BARREL_02");//0x8B3C480B,
            AddAdds.Add("COMPONENT_AT_MG_BARREL_01");//0xC34EF234,
            AddAdds.Add("COMPONENT_AT_MG_BARREL_02");//0xB5E2575B,
            AddAdds.Add("COMPONENT_AT_MRFL_BARREL_01");//0x381B5D89,
            AddAdds.Add("COMPONENT_AT_MRFL_BARREL_02");//0x68373DDC,
            AddAdds.Add("COMPONENT_AT_MUZZLE_01");//0xB99402D4,
            AddAdds.Add("COMPONENT_AT_MUZZLE_02");//0xC867A07B,
            AddAdds.Add("COMPONENT_AT_MUZZLE_03");//0xDE11CBCF,
            AddAdds.Add("COMPONENT_AT_MUZZLE_04");//0xEC9068CC,
            AddAdds.Add("COMPONENT_AT_MUZZLE_05");//0x2E7957A,
            AddAdds.Add("COMPONENT_AT_MUZZLE_06");//0x347EF8AC,
            AddAdds.Add("COMPONENT_AT_MUZZLE_07");//0x4DB62ABE,
            AddAdds.Add("COMPONENT_AT_MUZZLE_08");//0x5F7DCE4D,
            AddAdds.Add("COMPONENT_AT_MUZZLE_09");//0x6927E1A1,
            AddAdds.Add("COMPONENT_AT_PI_COMP");//0x21E34793,
            AddAdds.Add("COMPONENT_AT_PI_COMP_02");//0xAA8283BF,
            AddAdds.Add("COMPONENT_AT_PI_COMP_03");//0x27077CCB,
            AddAdds.Add("COMPONENT_AT_PI_FLSH");//0x359B7AAE,
            AddAdds.Add("COMPONENT_AT_PI_FLSH_02");//0x43FD595B,
            AddAdds.Add("COMPONENT_AT_PI_FLSH_03");//0x4A4965F3,
            AddAdds.Add("COMPONENT_AT_PI_RAIL");//0x8ED4BB70,
            AddAdds.Add("COMPONENT_AT_PI_RAIL_02");//0x47DE9258,
            AddAdds.Add("COMPONENT_AT_PI_SUPP");//0xC304849A,
            AddAdds.Add("COMPONENT_AT_PI_SUPP_02");//0x65EA7EBB,
            AddAdds.Add("COMPONENT_AT_SB_BARREL_01");//0xD9103EE1,
            AddAdds.Add("COMPONENT_AT_SB_BARREL_02");//0xA564D78B,
            AddAdds.Add("COMPONENT_AT_SCOPE_LARGE");//0xD2443DDC,
            AddAdds.Add("COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM");//0x1C221B1A,
            AddAdds.Add("COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM_MK2");//0x5B1C713C,
            AddAdds.Add("COMPONENT_AT_SCOPE_LARGE_MK2");//0x82C10383,
            AddAdds.Add("COMPONENT_AT_SCOPE_MACRO");//0x9D2FBF29,
            AddAdds.Add("COMPONENT_AT_SCOPE_MACRO_02");//0x3CC6BA57,
            AddAdds.Add("COMPONENT_AT_SCOPE_MACRO_02_MK2");//0xC7ADD105,
            AddAdds.Add("COMPONENT_AT_SCOPE_MACRO_02_SMG_MK2");//0xE502AB6B,
            AddAdds.Add("COMPONENT_AT_SCOPE_MACRO_MK2");//0x49B2945,
            AddAdds.Add("COMPONENT_AT_SCOPE_MAX");//0xBC54DA77,
            AddAdds.Add("COMPONENT_AT_SCOPE_MEDIUM");//0xA0D89C42,
            AddAdds.Add("COMPONENT_AT_SCOPE_MEDIUM_MK2");//0xC66B6542,
            AddAdds.Add("COMPONENT_AT_SCOPE_NV");//0xB68010B0,
            AddAdds.Add("COMPONENT_AT_SCOPE_SMALL");//0xAA2C45B4,
            AddAdds.Add("COMPONENT_AT_SCOPE_SMALL_02");//0x3C00AFED,
            AddAdds.Add("COMPONENT_AT_SCOPE_SMALL_MK2");//0x3F3C8181,
            AddAdds.Add("COMPONENT_AT_SCOPE_SMALL_SMG_MK2");//0x3DECC7DA,
            AddAdds.Add("COMPONENT_AT_SCOPE_THERMAL");//0x2E43DA41,
            AddAdds.Add("COMPONENT_AT_SC_BARREL_01");//0xE73653A9,
            AddAdds.Add("COMPONENT_AT_SC_BARREL_02");//0xF97F783B,
            AddAdds.Add("COMPONENT_AT_SIGHTS");//0x420FD713,
            AddAdds.Add("COMPONENT_AT_SIGHTS_SMG");//0x9FDB5652,
            AddAdds.Add("COMPONENT_AT_SR_BARREL_01");//0x909630B7,
            AddAdds.Add("COMPONENT_AT_SR_BARREL_02");//0x108AB09E,
            AddAdds.Add("COMPONENT_AT_SR_SUPP");//0xE608B35E,
            AddAdds.Add("COMPONENT_AT_SR_SUPP_03");//0xAC42DF71,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_CLIP_01");//0xC5A12F80,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_CLIP_02");//0xB3688B0F,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO");//0xAE4055B7,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_02");//0xB905ED6B,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_03");//0xA6C448E8,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_04");//0x9486246C,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_05");//0x8A390FD2,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_06");//0x2337FC5,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_07");//0xEFFFDB5E,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_08");//0xDDBDB6DA,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_09");//0xCB631225,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_10");//0xA87D541E,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CAMO_IND_01");//0xC5E9AE52,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_01");//0x18929DA,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_02");//0xEFB00628,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_ARMORPIERCING");//0xFAA7F5ED,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_FMJ");//0x43621710,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_INCENDIARY");//0xA99CF95A,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_MK2_CLIP_TRACER");//0x822060A9,
            AddAdds.Add("COMPONENT_BULLPUPRIFLE_VARMOD_LOW");//0xA857BC78,
            AddAdds.Add("COMPONENT_CARBINERIFLE_CLIP_01");//0x9FBE33EC,
            AddAdds.Add("COMPONENT_CARBINERIFLE_CLIP_02");//0x91109691,
            AddAdds.Add("COMPONENT_CARBINERIFLE_CLIP_03");//0xBA62E935,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO");//0x4BDD6F16,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_02");//0x406A7908,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_03");//0x2F3856A4,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_04");//0xE50C424D,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_05");//0xD37D1F2F,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_06");//0x86268483,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_07");//0xF420E076,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_08");//0xAAE14DF8,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_09");//0x9893A95D,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_10");//0x6B13CD3E,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CAMO_IND_01");//0xDA55CD3F,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_01");//0x4C7A391E,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_02");//0x5DD5DBD5,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING");//0x255D5D57,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ");//0x44032F11,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY");//0x3D25C2A7,
            AddAdds.Add("COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER");//0x1757F566,
            AddAdds.Add("COMPONENT_CARBINERIFLE_VARMOD_LUXE");//0xD89B9658,
            AddAdds.Add("COMPONENT_COMBATMG_CLIP_01");//0xE1FFB34A,
            AddAdds.Add("COMPONENT_COMBATMG_CLIP_02");//0xD6C59CD6,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO");//0x4A768CB5,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO_02");//0xCCE06BBD,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO_03");//0xBE94CF26,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO_04");//0x7609BE11,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO_05");//0x48AF6351,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO_06");//0x9186750A,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO_07");//0x84555AA8,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO_08");//0x1B4C088B,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO_09");//0xE046DFC,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO_10");//0x28B536E,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CAMO_IND_01");//0xD703C94D,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CLIP_01");//0x492B257C,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CLIP_02");//0x17DF42E9,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CLIP_ARMORPIERCING");//0x29882423,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CLIP_FMJ");//0x57EF1CC8,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CLIP_INCENDIARY");//0xC326BDBA,
            AddAdds.Add("COMPONENT_COMBATMG_MK2_CLIP_TRACER");//0xF6649745,
            AddAdds.Add("COMPONENT_COMBATMG_VARMOD_LOWRIDER");//0x92FECCDD,
            AddAdds.Add("COMPONENT_COMBATPDW_CLIP_01");//0x4317F19E,
            AddAdds.Add("COMPONENT_COMBATPDW_CLIP_02");//0x334A5203,
            AddAdds.Add("COMPONENT_COMBATPDW_CLIP_03");//0x6EB8C8DB,
            AddAdds.Add("COMPONENT_COMBATPISTOL_CLIP_01");//0x721B079,
            AddAdds.Add("COMPONENT_COMBATPISTOL_CLIP_02");//0xD67B4F2D,
            AddAdds.Add("COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER");//0xC6654D72,
            AddAdds.Add("COMPONENT_COMPACTRIFLE_CLIP_01");//0x513F0A63,
            AddAdds.Add("COMPONENT_COMPACTRIFLE_CLIP_02");//0x59FF9BF8,
            AddAdds.Add("COMPONENT_COMPACTRIFLE_CLIP_03");//0xC607740E,
            AddAdds.Add("COMPONENT_GRENADELAUNCHER_CLIP_01");//0x11AE5C97,
            AddAdds.Add("COMPONENT_GUSENBERG_CLIP_01");//0x1CE5A6A5,
            AddAdds.Add("COMPONENT_GUSENBERG_CLIP_02");//0xEAC8C270,
            AddAdds.Add("COMPONENT_HEAVYPISTOL_CLIP_01");//0xD4A969A,
            AddAdds.Add("COMPONENT_HEAVYPISTOL_CLIP_02");//0x64F9C62B,
            AddAdds.Add("COMPONENT_HEAVYPISTOL_VARMOD_LUXE");//0x7A6A7B7B,
            AddAdds.Add("COMPONENT_HEAVYSHOTGUN_CLIP_01");//0x324F2D5F,
            AddAdds.Add("COMPONENT_HEAVYSHOTGUN_CLIP_02");//0x971CF6FD,
            AddAdds.Add("COMPONENT_HEAVYSHOTGUN_CLIP_03");//0x88C7DA53,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_CLIP_01");//0x476F52F4,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO");//0xF8337D02,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_02");//0xC5BEDD65,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_03");//0xE9712475,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_04");//0x13AA78E7,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_05");//0x26591E50,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_06");//0x302731EC,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_07");//0xAC722A78,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_08");//0xBEA4CEDD,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_09");//0xCD776C82,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_10");//0xABC5ACC7,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CAMO_IND_01");//0x6C32D2EB,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_01");//0xFA1E1A28,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_02");//0x2CD8FF9D,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_ARMORPIERCING");//0xF835D6D4,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_EXPLOSIVE");//0x89EBDAA7,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_FMJ");//0x3BE948F6,
            AddAdds.Add("COMPONENT_HEAVYSNIPER_MK2_CLIP_INCENDIARY");//0xEC0F617,
            AddAdds.Add("COMPONENT_KNUCKLE_VARMOD_BALLAS");//0xEED9FD63,
            AddAdds.Add("COMPONENT_KNUCKLE_VARMOD_BASE");//0xF3462F33,
            AddAdds.Add("COMPONENT_KNUCKLE_VARMOD_DIAMOND");//0x9761D9DC,
            AddAdds.Add("COMPONENT_KNUCKLE_VARMOD_DOLLAR");//0x50910C31,
            AddAdds.Add("COMPONENT_KNUCKLE_VARMOD_HATE");//0x7DECFE30,
            AddAdds.Add("COMPONENT_KNUCKLE_VARMOD_KING");//0xE28BABEF,
            AddAdds.Add("COMPONENT_KNUCKLE_VARMOD_LOVE");//0x3F4E8AA6,
            AddAdds.Add("COMPONENT_KNUCKLE_VARMOD_PIMP");//0xC613F685,
            AddAdds.Add("COMPONENT_KNUCKLE_VARMOD_PLAYER");//0x8B808BB,
            AddAdds.Add("COMPONENT_KNUCKLE_VARMOD_VAGOS");//0x7AF3F785,
            AddAdds.Add("COMPONENT_MACHINEPISTOL_CLIP_01");//0x476E85FF,
            AddAdds.Add("COMPONENT_MACHINEPISTOL_CLIP_02");//0xB92C6979,
            AddAdds.Add("COMPONENT_MACHINEPISTOL_CLIP_03");//0xA9E9CAF4,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_CLIP_01");//0xD83B4141,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_CLIP_02");//0xCCFD2AC5,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO");//0x9094FBA0,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_02");//0x7320F4B2,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_03");//0x60CF500F,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_04");//0xFE668B3F,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_05");//0xF3757559,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_06");//0x193B40E8,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_07");//0x107D2F6C,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_08");//0xC4E91841,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_09");//0x9BB1C5D3,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_10");//0x3B61040B,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CAMO_IND_01");//0xB7A316DA,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_01");//0x94E12DCE,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_02");//0xE6CFD1AA,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_ARMORPIERCING");//0xF46FD079,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_FMJ");//0xE14A9ED3,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_INCENDIARY");//0x6DD7A86E,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_MK2_CLIP_TRACER");//0xD77A22D2,
            AddAdds.Add("COMPONENT_MARKSMANRIFLE_VARMOD_LUXE");//0x161E9241,
            AddAdds.Add("COMPONENT_MG_CLIP_01");//0xF434EF84,
            AddAdds.Add("COMPONENT_MG_CLIP_02");//0x82158B47,
            AddAdds.Add("COMPONENT_MG_VARMOD_LOWRIDER");//0xD6DABABE,
            AddAdds.Add("COMPONENT_MICROSMG_CLIP_01");//0xCB48AEF0,
            AddAdds.Add("COMPONENT_MICROSMG_CLIP_02");//0x10E6BA2B,
            AddAdds.Add("COMPONENT_MICROSMG_VARMOD_LUXE");//0x487AAE09,
            AddAdds.Add("COMPONENT_MINISMG_CLIP_01");//0x84C8B2D3,
            AddAdds.Add("COMPONENT_MINISMG_CLIP_02");//0x937ED0B7,
            AddAdds.Add("COMPONENT_PISTOL50_CLIP_01");//0x2297BE19,
            AddAdds.Add("COMPONENT_PISTOL50_CLIP_02");//0xD9D3AC92,
            AddAdds.Add("COMPONENT_PISTOL50_VARMOD_LUXE");//0x77B8AB2F,
            AddAdds.Add("COMPONENT_PISTOL_CLIP_01");//0xFED0FD71,
            AddAdds.Add("COMPONENT_PISTOL_CLIP_02");//0xED265A1C,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO");//0x5C6C749C,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_02");//0x15F7A390,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_02_SLIDE");//0x1A1F1260,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_03");//0x968E24DB,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_03_SLIDE");//0xE4E00B70,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_04");//0x17BFA99,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_04_SLIDE");//0x2C298B2B,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_05");//0xF2685C72,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_05_SLIDE");//0xDFB79725,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_06");//0xDD2231E6,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_06_SLIDE");//0x6BD7228C,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_07");//0xBB43EE76,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_07_SLIDE");//0x9DDBCF8C,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_08");//0x4D901310,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_08_SLIDE");//0xB319A52C,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_09");//0x5F31B653,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_09_SLIDE");//0xC6836E12,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_10");//0x697E19A0,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_10_SLIDE");//0x43B1B173,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_IND_01");//0x930CB951,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_IND_01_SLIDE");//0x4ABDA3FA,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CAMO_SLIDE");//0xB4FC92B0,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CLIP_01");//0x94F42D62,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CLIP_02");//0x5ED6C128,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CLIP_FMJ");//0x4F37DF2A,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CLIP_HOLLOWPOINT");//0x85FEA109,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CLIP_INCENDIARY");//0x2BBD7A3A,
            AddAdds.Add("COMPONENT_PISTOL_MK2_CLIP_TRACER");//0x25CAAEAF,
            AddAdds.Add("COMPONENT_PISTOL_VARMOD_LUXE");//0xD7391086,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO");//0xE3BD9E44,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_02");//0x17148F9B,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_03");//0x24D22B16,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_04");//0xF2BEC6F0,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_05");//0x85627D,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_06");//0xDC2919C5,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_07");//0xE184247B,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_08");//0xD8EF9356,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_09");//0xEF29BFCA,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_10");//0x67AEB165,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CAMO_IND_01");//0x46411A1D,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_01");//0xCD940141,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_ARMORPIERCING");//0x4E65B425,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_EXPLOSIVE");//0x3BE4465D,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_HOLLOWPOINT");//0xE9582927,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_MK2_CLIP_INCENDIARY");//0x9F8A1BF5,
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER");//0xA2D79DDB,
            AddAdds.Add("COMPONENT_REVOLVER_CLIP_01");//0xE9867CE3,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO");//0xC03FED9F,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO_02");//0xB5DE24,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO_03");//0xA7FF1B8,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO_04");//0xF2E24289,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO_05");//0x11317F27,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO_06");//0x17C30C42,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO_07");//0x257927AE,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO_08");//0x37304B1C,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO_09");//0x48DAEE71,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO_10");//0x20ED9B5B,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CAMO_IND_01");//0xD951E867,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CLIP_01");//0xBA23D8BE,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CLIP_FMJ");//0xDC8BA3F,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CLIP_HOLLOWPOINT");//0x10F42E8F,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CLIP_INCENDIARY");//0xEFBF25,
            AddAdds.Add("COMPONENT_REVOLVER_MK2_CLIP_TRACER");//0xC6D8E476,
            AddAdds.Add("COMPONENT_REVOLVER_VARMOD_BOSS");//0x16EE3040,
            AddAdds.Add("COMPONENT_REVOLVER_VARMOD_GOON");//0x9493B80D,
            AddAdds.Add("COMPONENT_SAWNOFFSHOTGUN_VARMOD_LUXE");//0x85A64DF9,
            AddAdds.Add("COMPONENT_SMG_CLIP_01");//0x26574997,
            AddAdds.Add("COMPONENT_SMG_CLIP_02");//0x350966FB,
            AddAdds.Add("COMPONENT_SMG_CLIP_03");//0x79C77076,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO");//0xC4979067,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO_02");//0x3815A945,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO_03");//0x4B4B4FB0,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO_04");//0xEC729200,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO_05");//0x48F64B22,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO_06");//0x35992468,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO_07");//0x24B782A5,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO_08");//0xA2E67F01,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO_09");//0x2218FD68,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO_10");//0x45C5C3C5,
            AddAdds.Add("COMPONENT_SMG_MK2_CAMO_IND_01");//0x399D558F,
            AddAdds.Add("COMPONENT_SMG_MK2_CLIP_01");//0x4C24806E,
            AddAdds.Add("COMPONENT_SMG_MK2_CLIP_02");//0xB9835B2E,
            AddAdds.Add("COMPONENT_SMG_MK2_CLIP_FMJ");//0xB5A715F,
            AddAdds.Add("COMPONENT_SMG_MK2_CLIP_HOLLOWPOINT");//0x3A1BD6FA,
            AddAdds.Add("COMPONENT_SMG_MK2_CLIP_INCENDIARY");//0xD99222E5,
            AddAdds.Add("COMPONENT_SMG_MK2_CLIP_TRACER");//0x7FEA36EC,
            AddAdds.Add("COMPONENT_SMG_VARMOD_LUXE");//0x27872C90,
            AddAdds.Add("COMPONENT_SNIPERRIFLE_CLIP_01");//0x9BC64089,
            AddAdds.Add("COMPONENT_SNIPERRIFLE_VARMOD_LUXE");//0x4032B5E7,
            AddAdds.Add("COMPONENT_SNSPISTOL_CLIP_01");//0xF8802ED9,
            AddAdds.Add("COMPONENT_SNSPISTOL_CLIP_02");//0x7B0033B3,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO");//0xF7BEEDD,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_02");//0x8A612EF6,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_02_SLIDE");//0x29366D21,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_03");//0x76FA8829,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_03_SLIDE");//0x3ADE514B,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_04");//0xA93C6CAC,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_04_SLIDE");//0xE64513E9,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_05");//0x9C905354,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_05_SLIDE");//0xCD7AEB9A,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_06");//0x4DFA3621,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_06_SLIDE");//0xFA7B27A6,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_07");//0x42E91FFF,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_07_SLIDE");//0xE285CA9A,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_08");//0x54A8437D,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_08_SLIDE");//0x2B904B19,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_09");//0x68C2746,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_09_SLIDE");//0x22C24F9C,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_10");//0x2366E467,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_10_SLIDE");//0x8D0D5ECD,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_IND_01");//0x441882E6,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_IND_01_SLIDE");//0x1F07150A,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CAMO_SLIDE");//0xE7EE68EA,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CLIP_01");//0x1466CE6,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CLIP_02");//0xCE8C0772,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CLIP_FMJ");//0xC111EB26,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CLIP_HOLLOWPOINT");//0x8D107402,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CLIP_INCENDIARY");//0xE6AD5F79,
            AddAdds.Add("COMPONENT_SNSPISTOL_MK2_CLIP_TRACER");//0x902DA26E,
            AddAdds.Add("COMPONENT_SNSPISTOL_VARMOD_LOWRIDER");//0x8033ECAF,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_CLIP_01");//0xC6C7E581,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_CLIP_02");//0x7C8BD10E,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_CLIP_03");//0x6B59AEAA,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO");//0xD40BB53B,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_02");//0x431B238B,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_03");//0x34CF86F4,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_04");//0xB4C306DD,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_05");//0xEE677A25,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_06");//0xDF90DC78,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_07");//0xA4C31EE,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_08");//0x89CFB0F7,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_09");//0x7B82145C,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_10");//0x899CAF75,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CAMO_IND_01");//0x5218C819,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_01");//0x16C69281,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_02");//0xDE1FA12C,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_ARMORPIERCING");//0x51351635,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_FMJ");//0x503DEA90,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_INCENDIARY");//0xDE011286,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_MK2_CLIP_TRACER");//0x8765C68A,
            AddAdds.Add("COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER");//0x730154F2,
            AddAdds.Add("COMPONENT_SWITCHBLADE_VARMOD_BASE");//0x9137A500,
            AddAdds.Add("COMPONENT_SWITCHBLADE_VARMOD_VAR1");//0x5B3E7DB6,
            AddAdds.Add("COMPONENT_SWITCHBLADE_VARMOD_VAR2");//0xE7939662,
            AddAdds.Add("COMPONENT_VINTAGEPISTOL_CLIP_01");//0x45A3B6BB,
            AddAdds.Add("COMPONENT_VINTAGEPISTOL_CLIP_02");//0x33BA12E8

            AddAdds.Add("COMPONENT_AT_AR_FLSH");//
            AddAdds.Add("COMPONENT_AT_AR_SUPP");//
            AddAdds.Add("COMPONENT_MILITARYRIFLE_CLIP_01");//
            AddAdds.Add("COMPONENT_MILITARYRIFLE_CLIP_02");//
            AddAdds.Add("COMPONENT_MILITARYRIFLE_SIGHT_01");//
            AddAdds.Add("COMPONENT_AT_SCOPE_SMALL");//
            AddAdds.Add("COMPONENT_AT_AR_FLSH");//
            AddAdds.Add("COMPONENT_AT_AR_SUPP");//

            AddAdds.Add("COMPONENT_HEAVYRIFLE_CLIP_01");// | 0x5AF49386
            AddAdds.Add("COMPONENT_HEAVYRIFLE_CLIP_02");//");// | 0x6CBF371B
            AddAdds.Add("COMPONENT_HEAVYRIFLE_SIGHT_01");// | 0xB3E1C452
            AddAdds.Add("COMPONENT_AT_SCOPE_MEDIUM");// | 0xA0D89C42
            AddAdds.Add("COMPONENT_AT_AR_FLSH");// | 0x7BC4CDDC
            AddAdds.Add("COMPONENT_AT_AR_SUPP");// | 0x837445AA
            AddAdds.Add("COMPONENT_AT_AR_AFGRIP");// | 0xC164F53
            AddAdds.Add("COMPONENT_HEAVYRIFLE_CAMO1");// | 0xEC9FECD9
            AddAdds.Add("COMPONENT_APPISTOL_VARMOD_SECURITY");//
            AddAdds.Add("COMPONENT_MICROSMG_VARMOD_SECURITY");//
            AddAdds.Add("COMPONENT_PUMPSHOTGUN_VARMOD_SECURITY");//

            return AddAdds;
        }
        public static List<string> WeapsList()
        {
            LoggerLight.Loggers("DataStore.WeapsList");
            List<string> AddWeaps = new List<string>();

            AddWeaps.Add("WEAPON_dagger");  //0x92A27487",
            AddWeaps.Add("WEAPON_bat");  //0x958A4A8F",
            AddWeaps.Add("WEAPON_bottle");  //0xF9E6AA4B",
            AddWeaps.Add("WEAPON_crowbar");  //0x84BD7BFD",
            AddWeaps.Add("WEAPON_unarmed");  //0xA2719263",
            AddWeaps.Add("WEAPON_flashlight");  //0x8BB05FD7",
            AddWeaps.Add("WEAPON_golfclub");  //0x440E4788",
            AddWeaps.Add("WEAPON_hammer");  //0x4E875F73",
            AddWeaps.Add("WEAPON_hatchet");  //0xF9DCBF2D",
            AddWeaps.Add("WEAPON_knuckle");  //0xD8DF3C3C",
            AddWeaps.Add("WEAPON_knife");  //0x99B507EA",
            AddWeaps.Add("WEAPON_machete");  //0xDD5DF8D9",
            AddWeaps.Add("WEAPON_switchblade");  //0xDFE37640",
            AddWeaps.Add("WEAPON_nightstick");  //0x678B81B1",
            AddWeaps.Add("WEAPON_wrench");  //0x19044EE0",
            AddWeaps.Add("WEAPON_battleaxe");  //0xCD274149",
            AddWeaps.Add("WEAPON_poolcue");  //0x94117305",
            AddWeaps.Add("WEAPON_stone_hatchet");  //0x3813FC08"--17

            AddWeaps.Add("WEAPON_pistol");  //0x1B06D571",
            AddWeaps.Add("WEAPON_pistol_mk2");  //0xBFE256D4",---------19
            AddWeaps.Add("WEAPON_combatpistol");  //0x5EF9FEC4",
            AddWeaps.Add("WEAPON_appistol");  //0x22D8FE39",
            AddWeaps.Add("WEAPON_pistol50");  //0x99AEEB3B",
            AddWeaps.Add("WEAPON_snspistol");  //0xBFD21232",
            AddWeaps.Add("WEAPON_snspistol_mk2");  //0x88374054",---24
            AddWeaps.Add("WEAPON_heavypistol");  //0xD205520E",
            AddWeaps.Add("WEAPON_vintagepistol");  //0x83839C4",
            AddWeaps.Add("WEAPON_marksmanpistol");  //0xDC4DB296",
            AddWeaps.Add("WEAPON_revolver");  //0xC1B3C3D1",
            AddWeaps.Add("WEAPON_revolver_mk2");  //0xCB96392F",----29
            AddWeaps.Add("WEAPON_doubleaction");  //0x97EA20B8",
            AddWeaps.Add("WEAPON_ceramicpistol");  //0x2B5EF5EC",
            AddWeaps.Add("WEAPON_navyrevolver");  //0x917F6C8C"
            AddWeaps.Add("WEAPON_GADGETPISTOL");  //0xAF3696A1",
            AddWeaps.Add("WEAPON_stungun");  //0x3656C8C1",
            AddWeaps.Add("WEAPON_flaregun");  //0x47757124",
            AddWeaps.Add("WEAPON_raypistol");  //0xAF3696A1",--36

            AddWeaps.Add("WEAPON_microsmg");  //0x13532244",
            AddWeaps.Add("WEAPON_smg");  //0x2BE6766B",
            AddWeaps.Add("WEAPON_smg_mk2");  //0x78A97CD0",-----39
            AddWeaps.Add("WEAPON_assaultsmg");  //0xEFE7E2DF",
            AddWeaps.Add("WEAPON_combatpdw");  //0xA3D4D34",
            AddWeaps.Add("WEAPON_machinepistol");  //0xDB1AA450",
            AddWeaps.Add("WEAPON_minismg");  //0xBD248B55",
            AddWeaps.Add("WEAPON_raycarbine");  //0x476BF155"--44

            AddWeaps.Add("WEAPON_pumpshotgun");  //0x1D073A89",
            AddWeaps.Add("WEAPON_pumpshotgun_mk2");  //0x555AF99A",-----------46
            AddWeaps.Add("WEAPON_sawnoffshotgun");  //0x7846A318",
            AddWeaps.Add("WEAPON_assaultshotgun");  //0xE284C527",
            AddWeaps.Add("WEAPON_bullpupshotgun");  //0x9D61E50F",
            AddWeaps.Add("WEAPON_musket");  //0xA89CB99E",
            AddWeaps.Add("WEAPON_heavyshotgun");  //0x3AABBBAA",
            AddWeaps.Add("WEAPON_dbshotgun");  //0xEF951FBB",
            AddWeaps.Add("WEAPON_autoshotgun");  //0x12E82D3D"--53
            AddWeaps.Add("WEAPON_COMBATSHOTGUN");  //0x5A96BA4--54

            AddWeaps.Add("WEAPON_assaultrifle");  //0xBFEFFF6D",
            AddWeaps.Add("WEAPON_assaultrifle_mk2");  //0x394F415C",-------56
            AddWeaps.Add("WEAPON_carbinerifle");  //0x83BF0278",
            AddWeaps.Add("WEAPON_carbinerifle_mk2");  //0xFAD1F1C9",------58
            AddWeaps.Add("WEAPON_advancedrifle");  //0xAF113F99",
            AddWeaps.Add("WEAPON_specialcarbine");  //0xC0A3098D",
            AddWeaps.Add("WEAPON_specialcarbine_mk2");  //0x969C3D67",------61
            AddWeaps.Add("WEAPON_bullpuprifle");  //0x7F229F94",
            AddWeaps.Add("WEAPON_bullpuprifle_mk2");  //0x84D6FAFD",----63
            AddWeaps.Add("WEAPON_compactrifle");  //0x624FE830"--64
            AddWeaps.Add("WEAPON_MILITARYRIFLE");  //0x624FE830"--65

            AddWeaps.Add("WEAPON_mg");  //0x9D07F764",
            AddWeaps.Add("WEAPON_combatmg");  //0x7FD62962",
            AddWeaps.Add("WEAPON_combatmg_mk2");  //0xDBBD7280",------68
            AddWeaps.Add("WEAPON_gusenberg");  //0x61012683"--69

            AddWeaps.Add("WEAPON_sniperrifle");  //0x5FC3C11",
            AddWeaps.Add("WEAPON_heavysniper");  //0xC472FE2",
            AddWeaps.Add("WEAPON_heavysniper_mk2");  //0xA914799",---72
            AddWeaps.Add("WEAPON_marksmanrifle");  //0xC734385A",
            AddWeaps.Add("WEAPON_marksmanrifle_mk2");  //0x6A6C02E0"--74

            AddWeaps.Add("WEAPON_rpg");  //0xB1CA77B1",
            AddWeaps.Add("WEAPON_grenadelauncher");  //0xA284510B",
            AddWeaps.Add("WEAPON_grenadelauncher_smoke");  //0x4DD2DC56",
            AddWeaps.Add("WEAPON_minigun");  //0x42BF8A85",
            AddWeaps.Add("WEAPON_firework");  //0x7F7497E5",
            AddWeaps.Add("WEAPON_railgun");  //0x6D544C99",
            AddWeaps.Add("WEAPON_hominglauncher");  //0x63AB0442",
            AddWeaps.Add("WEAPON_compactlauncher");  //0x781FE4A",
            AddWeaps.Add("WEAPON_rayminigun");  //0xB62D1F67"--83

            AddWeaps.Add("WEAPON_grenade");  //0x93E220BD",
            AddWeaps.Add("WEAPON_bzgas");  //0xA0973D5E",
            AddWeaps.Add("WEAPON_smokegrenade");  //0xFDBC8A50",
            AddWeaps.Add("WEAPON_flare");  //0x497FACC3",
            AddWeaps.Add("WEAPON_molotov");  //0x24B17070",
            AddWeaps.Add("WEAPON_stickybomb");  //0x2C3731D9",
            AddWeaps.Add("WEAPON_proxmine");  //0xAB564B93",
            AddWeaps.Add("WEAPON_snowball");  //0x787F0BB",
            AddWeaps.Add("WEAPON_pipebomb");  //0xBA45E8B8",
            AddWeaps.Add("WEAPON_ball");  //0x23C9F95C"--93

            AddWeaps.Add("WEAPON_petrolcan");  //0x34A67B97",
            AddWeaps.Add("WEAPON_fireextinguisher");  //0x60EC506",
            AddWeaps.Add("WEAPON_parachute");  //0xFBAB5776",
            AddWeaps.Add("WEAPON_hazardcan");  //0xBA536372"--97

            AddWeaps.Add("WEAPON_EMPLAUNCHER");  // 0xDB26713A--98

            AddWeaps.Add("WEAPON_HEAVYRIFLE");  //0xC78D71B4 --99

            AddWeaps.Add("WEAPON_FERTILIZERCAN");//100

            AddWeaps.Add("WEAPON_STUNGUN_MP");//101

            return AddWeaps;
        }
        public static SettingsXML LoadSetXML()
        {
            LoggerLight.Loggers("DataStore.LoadSetXML");

            SettingsXML GetMySets = new SettingsXML();

            if (File.Exists(sSettings))
            {
                GetMySets = XmlReadWrite.LoadSettings(sSettings);

                if (GetMySets.Spawn && GetMySets.Saved)
                {
                    GetMySets.Spawn = false;
                    GetMySets.Saved = false;
                }

                if (GetMySets.Locate && bLoadUpOnYacht)
                    GetMySets.Locate = false;

                if (GetMySets.Version != 27000)
                {
                    GetMySets.Version = 27000;
                    bNagg = true;
                }

                if (GetMySets.YourWeaps.Count == 0)
                    GetMySets.YourWeaps = GetWeaps();
            }
            else
            {
                GetMySets = XmlReadWrite.WriteSetXML();
                bNagg = true;
            }

            return GetMySets;
        }
        public static List<string> LangText()
        {
            LoggerLight.Loggers("DataStore.LangText");

            List<string> Locals = new List<string>();

            Locals.Add("LangReader");
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/English.Xml"); //1
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Chinese.Xml"); //2
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/ChineseS.Xml");//3
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/French.Xml");//4
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/German.Xml");//5
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Italian.Xml");//6
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Japanese.Xml");//7
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Korean.Xml");//8
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Mexican.Xml");//9
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Polish.Xml");//10
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Portuguese.Xml");//11
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Russian.Xml");//12
            Locals.Add("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/Language/Spanish.Xml");//13

            return Locals;
        }
        public static LangXML FindaLang()
        {
            LoggerLight.Loggers("DataStore.FindaLang");
            bool bNoLAng = true;

            LangXML NewLang = new LangXML();

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
                    if (File.Exists(sLangNames[iLangSupport]))
                    {
                        NewLang = XmlReadWrite.LoadLang(sLangNames[iLangSupport]);
                        bNoLAng = false;
                    }
                }
            }

            if (bNoLAng)
                NewLang = XmlReadWrite.Languages();

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

            RsActions.PedPools();
            XmlReadWrite.LoadupWeaponXML();
            SetUpMod();

        }
        public static void SetUpMod()
        {
            LoggerLight.Loggers("SetUpMod");
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Friend, DataStore.GP_Player);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, DataStore.GP_Friend);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, DataStore.GP_Attack, DataStore.GP_Player);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, DataStore.GP_Player, DataStore.GP_Attack);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, DataStore.GP_Attack, DataStore.GP_Friend);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, DataStore.GP_Friend, DataStore.GP_Attack);


            UI.Notify("Random Start " + DataStore.sVersion + " by Adopcalipt Loaded");

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
    }
}
