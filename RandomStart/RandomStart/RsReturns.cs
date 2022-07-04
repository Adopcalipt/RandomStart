using GTA;
using GTA.Math;
using GTA.Native;
using RandomStart.Classes;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace RandomStart
{
    public class RsReturns
    {
        public static bool GetMainChar()
        {
            bool bYes = false;
            if (Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Trevor)
                bYes = true;
            return bYes;
        }
        public static int RandomSeletor()
        {
            int iYourSell = -1;

            if (DataStore.MySettingsXML.RandStarts.Count < 1)
                DataStore.MySettingsXML.RandStarts = XmlReadWrite.BuildRandStartsList();

            if (!DataStore.MySettingsXML.BeachPed)
                DataStore.MySettingsXML.RandStarts.Remove(1);
            if (!DataStore.MySettingsXML.Tramps)
                DataStore.MySettingsXML.RandStarts.Remove(2);
            if (!DataStore.MySettingsXML.Highclass)
                DataStore.MySettingsXML.RandStarts.Remove(3);
            if (!DataStore.MySettingsXML.Midclass)
                DataStore.MySettingsXML.RandStarts.Remove(4);
            if (!DataStore.MySettingsXML.Lowclass)
                DataStore.MySettingsXML.RandStarts.Remove(5);
            if (!DataStore.MySettingsXML.Business)
                DataStore.MySettingsXML.RandStarts.Remove(6);
            if (!DataStore.MySettingsXML.Bodybuilder)
                DataStore.MySettingsXML.RandStarts.Remove(7);
            if (!DataStore.MySettingsXML.GangStars)
                DataStore.MySettingsXML.RandStarts.Remove(8);
            if (!DataStore.MySettingsXML.Epsilon)
                DataStore.MySettingsXML.RandStarts.Remove(9);
            if (!DataStore.MySettingsXML.Jogger)
                DataStore.MySettingsXML.RandStarts.Remove(10);
            if (!DataStore.MySettingsXML.Golfer)
                DataStore.MySettingsXML.RandStarts.Remove(11);
            if (!DataStore.MySettingsXML.Hiker)
                DataStore.MySettingsXML.RandStarts.Remove(12);
            if (!DataStore.MySettingsXML.Methaddict)
                DataStore.MySettingsXML.RandStarts.Remove(13);
            if (!DataStore.MySettingsXML.Rural)
                DataStore.MySettingsXML.RandStarts.Remove(14);
            if (!DataStore.MySettingsXML.Cyclist)
                DataStore.MySettingsXML.RandStarts.Remove(15);
            if (!DataStore.MySettingsXML.LGBTWXYZ)
                DataStore.MySettingsXML.RandStarts.Remove(16);
            if (!DataStore.MySettingsXML.PoolPeds)
                DataStore.MySettingsXML.RandStarts.Remove(17);
            if (!DataStore.MySettingsXML.Workers)
                DataStore.MySettingsXML.RandStarts.Remove(18);
            if (!DataStore.MySettingsXML.Jetski)
                DataStore.MySettingsXML.RandStarts.Remove(19);
            if (!DataStore.MySettingsXML.BikeATV)
                DataStore.MySettingsXML.RandStarts.Remove(20);
            if (!DataStore.MySettingsXML.Services)
                DataStore.MySettingsXML.RandStarts.Remove(21);
            if (!DataStore.MySettingsXML.Pilot)
                DataStore.MySettingsXML.RandStarts.Remove(22);
            if (!DataStore.MySettingsXML.Animals)
                DataStore.MySettingsXML.RandStarts.Remove(23);
            if (!DataStore.MySettingsXML.Yankton)
                DataStore.MySettingsXML.RandStarts.Remove(24);
            if (!DataStore.MySettingsXML.Cayo)
                DataStore.MySettingsXML.RandStarts.Remove(25);

            if (DataStore.MySettingsXML.RandStarts.Count < 1)
                DataStore.MySettingsXML.Locate = false;
            else
                iYourSell = DataStore.MySettingsXML.RandStarts[RandInt(0, DataStore.MySettingsXML.RandStarts.Count - 1)];

            return iYourSell;
        }
        public static bool WhileButtonDown(int CButt, bool bDisable)
        {
            if (bDisable)
                RsActions.ButtonDisabler(CButt); ;

            bool bButt = Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);

            if (bButt)
            {
                while (!Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_RELEASED, 0, CButt))
                    Script.Wait(1);
            }

            return bButt;
        }
        public static bool ButtonDown(int CButt, bool bDisable)
        {
            if (bDisable)
                RsActions.ButtonDisabler(CButt);
            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);
        }
        public static int Mk2AmmoFix(string sWeapo)
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
        public static int MaxAmmo(string sWeap, Ped Peddy)
        {
            int iAmmo = 0;
            int iWeap = Function.Call<int>(Hash.GET_HASH_KEY, sWeap);

            unsafe
            {
                Function.Call<bool>(Hash.GET_MAX_AMMO, Peddy.Handle, iWeap, &iAmmo);
            }
            return iAmmo;
        }
        public static string BuildRandVeh(int iList, int iSubSet)
        {

            LoggerLight.Loggers("BuildRandVeh, iList == " + iList + ", iSubSet == " + iSubSet);

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
                if (!DataStore.bDisableDLCVeh)
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
                if (!DataStore.bDisableDLCVeh)
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
                if (!DataStore.bDisableDLCVeh)
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

                if (!DataStore.bDisableDLCVeh)
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
                else
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
                if (!DataStore.bDisableDLCVeh)
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
                    if (!DataStore.bDisableDLCVeh)
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
                else
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
                else
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
            else
            {
                if (iSubSet == 1)
                {

                }       //A_C_Panther
                else if (iSubSet == 2)
                {

                }       //A_F_Y_Beach_02
                else if (iSubSet == 3)
                {
                    if (DataStore.bDisableDLCVeh)
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
        public static string BuildRandomPed(int iPedtype, int iSubType)
        {

            LoggerLight.Loggers("BuildRandomPed, iPedtype == " + iPedtype + ", iSubType == " + iSubType);

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
                else
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
                else
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
                else
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
                else
                    sPeddy.Add("mp_f_helistaff_01");                //"Heli-Staff Female" />
            }       //Pilot
            else if (iPedtype == 23)
            {
                if (iSubType == 1)
                    sPeddy.Add("a_c_boar");                //"a_c_boar");  
                else if (iSubType == 2)
                {
                    sPeddy.Add("a_c_cat_01");
                    sPeddy.Add("a_c_husky");
                    sPeddy.Add("a_c_poodle");
                    sPeddy.Add("a_c_pug");
                    sPeddy.Add("a_c_retriever");
                    sPeddy.Add("a_c_rottweiler");
                    sPeddy.Add("a_c_shepherd");
                    sPeddy.Add("a_c_westy");
                }                //"Cats/dogs"); 
                else if (iSubType == 3)
                    sPeddy.Add("a_c_pigeon");                //"a_c_pigeon" />
                else if (iSubType == 4)
                    sPeddy.Add("a_c_rat");                //"a_c_rat" />
                else if (iSubType == 5)
                    sPeddy.Add("a_c_cow");                //"a_c_cow" />
                else if (iSubType == 6)
                    sPeddy.Add("a_c_coyote");                //"a_c_coyote" />
                else if (iSubType == 7)
                    sPeddy.Add("a_c_crow");                //"a_c_crow" />
                else if (iSubType == 8)
                {
                    sPeddy.Add("a_c_rabbit_01");                //"a_c_rabbit_01" />
                    sPeddy.Add("a_c_deer");                //"a_c_deer" />
                }
                else if (iSubType == 9)
                    sPeddy.Add("a_c_hen");                //"a_c_hen" />
                else if (iSubType == 10)
                    sPeddy.Add("a_c_mtlion");                //"mountain lion" />
                else if (iSubType == 11)
                    sPeddy.Add("a_c_pig");                //"a_c_pig" />
                else if (iSubType == 12)
                {
                    sPeddy.Add("a_c_dolphin");                //"fish/sharks" />
                    sPeddy.Add("a_c_fish");
                    sPeddy.Add("a_c_sharkhammer");
                    sPeddy.Add("a_c_humpback");
                    sPeddy.Add("a_c_killerwhale");
                    sPeddy.Add("a_c_stingray");
                    sPeddy.Add("a_c_sharktiger");
                }
                else if (iSubType == 13)
                    sPeddy.Add("a_c_chickenhawk");                //"a_c_chickenhawk");  
                else
                {
                    sPeddy.Add("a_c_cormorant");                //"a_c_cormorant" />
                    sPeddy.Add("a_c_seagull");
                }
            }       //animals
            else if (iPedtype == 24)
            {
                sPeddy.Add("csb_prologuedriver");
                sPeddy.Add("csb_prolsec");
                sPeddy.Add("cs_prolsec_02");
                sPeddy.Add("ig_prolsec_02");
                sPeddy.Add("u_f_o_prolhost_01");
                sPeddy.Add("u_f_m_promourn_01");
            }       //Yankton
            else
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
        public static Prop MyPropBuild(string sPop, Vector3 Local, Vector3 Rotate, int iPropTask, bool bAddToLiist)
        {

            LoggerLight.Loggers("MyPropBuild, sPop == " + sPop + ", iPropTask == " + iPropTask);

            Prop Propper;

            int iPropHash = Function.Call<int>(Hash.GET_HASH_KEY, sPop);

            if (!Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iPropHash))
            {
                LoggerLight.Loggers("BuildProp, spropMissing...");
                iPropHash = Function.Call<int>(Hash.GET_HASH_KEY, "zprop_bin_01a_old");
            }

            Function.Call(Hash.REQUEST_MODEL, iPropHash);
            while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, iPropHash))
                Script.Wait(1);

            int iProps = Function.Call<int>(Hash.CREATE_OBJECT, iPropHash, Local.X, Local.Y, Local.Z, false, true, false);
            Propper = new Prop(iProps);

            if (Propper.Exists())
            {
                Propper.Rotation = Rotate;
                Propper.IsPersistent = true;

                if (bAddToLiist)
                    DataStore.PropList.Add(new Prop(Propper.Handle));
                if (iPropTask > 0)
                    RsActions.PropTasks(Propper, iPropTask);
            }
            else
                Propper = null;

            Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iPropHash);

            return Propper;
        }
        public static List<string> DanceList(bool bMale, int iSpeed)
        {

            LoggerLight.Loggers("DanceList, bMale == " + bMale + ", iSpeed == " + iSpeed);

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
        public static string AddAnyPed(int iType)
        {
            LoggerLight.Loggers("RsReturns.AddAnyPed");

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
        public static int RandInt(int minNumber, int maxNumber)
        {
            LoggerLight.Loggers("RandInt");

            int iMyRanInt = Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, minNumber, maxNumber);

            return iMyRanInt;
        }
        public static float RandFloat(float fMin, float fMax)
        {
            float iMyRanFlow = Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, fMin, fMax);

            return iMyRanFlow;
        }
        public static List<string> TattoosList(int iPed, int iZone)
        {
            LoggerLight.Loggers("TattoosList, iPed == " + iPed + ", iZone == " + iZone);

            bool bEmpty = false;
            List<string> MyTat = new List<string>();

            DataStore.sTatBase.Clear();
            DataStore.sTatName.Clear();

            if (iPed == 1)
            {
                if (iZone == 1)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_018"); MyTat.Add("Impotent Rage");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_014"); MyTat.Add("Chinese Dragon");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_008"); MyTat.Add("Trinity Knot");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_004"); MyTat.Add("Lucky");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_020"); MyTat.Add("Way of the Gun");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_017"); MyTat.Add("Whiskey Life");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_015"); MyTat.Add("Flaming Shamrock");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_006"); MyTat.Add("Eagle and Serpent");
                }//TORSO
                else if (iZone == 2)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_003"); MyTat.Add("The Rose of My Heart");
                }//HEAD
                else if (iZone == 3)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_019"); MyTat.Add("Dragon");//     
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_012"); MyTat.Add("Faith");//   
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_010"); MyTat.Add("Lady M");//   
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_009"); MyTat.Add("Lucky Celtic Dogs");//  
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_007"); MyTat.Add("Mermaid");//       
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_000"); MyTat.Add("Mandy");//    
                }//LEFT ARM 
                else if (iZone == 4)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_016"); MyTat.Add("Michael and Amanda");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_013"); MyTat.Add("Flower Mural");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_005"); MyTat.Add("Virgin Mary");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_001"); MyTat.Add("Family is Forever");
                }//RIGHT ARM
                else if (iZone == 5)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_002"); MyTat.Add("Smoking Dagger");
                }//LEFT LEG
                else
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("MK_011"); MyTat.Add("Tiki Pinup ");
                }//RIGHT LEG
            }// Michael
            else if (iPed == 2)
            {
                if (iZone == 1)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_038"); MyTat.Add("Angel of Los Santos");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_010"); MyTat.Add("Grace and Power");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_004"); MyTat.Add("Dragon");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_039"); MyTat.Add("Impotent Rage");//   
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_037"); MyTat.Add("Los Santos Bills");// 
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_036"); MyTat.Add("These Streets");//    
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_035"); MyTat.Add("Families");//      
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_032"); MyTat.Add("LS Flames");//  
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_031"); MyTat.Add("Fam 4 Life");//   
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_030"); MyTat.Add("Families Symbol");//      
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_029"); MyTat.Add("FAM Power");//    
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_028"); MyTat.Add("Flaming Cross");//  
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_021"); MyTat.Add("Chamberlain Families LS");//  
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_020"); MyTat.Add("LS Heart ");//   
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_018"); MyTat.Add("Families Kings");//  
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_011"); MyTat.Add("Forum4Life");//      
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_000"); MyTat.Add("Chamberlain");//     
                    //Not in List
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_025"); MyTat.Add("Skull on the Cross");//    
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_024"); MyTat.Add("Skull and Dragon");
                }//TORSO
                else if (iZone == 2)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_022"); MyTat.Add("Chamberlain Families");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_005"); MyTat.Add("Faith");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_034"); MyTat.Add("LS Bold");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_033"); MyTat.Add("LS Script");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_014"); MyTat.Add("F King");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_013"); MyTat.Add("F Crown ");
                }//HEAD
                else if (iZone == 3)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_019"); MyTat.Add("FAMILIES");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_017"); MyTat.Add("Lion");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_016"); MyTat.Add("Dragon Mural");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_007"); MyTat.Add("Serpent Skull");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_001"); MyTat.Add("Brotherhood");
                }//LEFT ARM
                else if (iZone == 4)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_023"); MyTat.Add("Fiery Dragon");//    
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_012"); MyTat.Add("Oriental Mural");//    
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_009"); MyTat.Add("Chop");//    
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_008"); MyTat.Add("Mother");//    
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_006"); MyTat.Add("Serpents");//    
                }//RIGHT ARM
                else if (iZone == 5)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_027"); MyTat.Add("Hottie");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_015"); MyTat.Add("The Warrior");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_002"); MyTat.Add("Dragons");
                }//LEFT LEG
                else
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_026"); MyTat.Add("Trust No One");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("fr_003"); MyTat.Add("Melting Skull");
                }//RIGHT LEG
            }// Franklin
            else if (iPed == 3)
            {
                if (iZone == 1)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_032"); MyTat.Add("Lucky");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_031"); MyTat.Add("Unzipped");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_026"); MyTat.Add("Skulls and Rose");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_022"); MyTat.Add("Chinese Dragon");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_033"); MyTat.Add("Impotent Rage");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_030"); MyTat.Add("Fuck Cops");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_029"); MyTat.Add("Smiley");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_028"); MyTat.Add("Ace");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_027"); MyTat.Add("Piggy");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_023"); MyTat.Add("Monster Pups");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_021"); MyTat.Add("Stone Cross");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_015"); MyTat.Add("Tweaker");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_013"); MyTat.Add("Betraying Scroll");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_012"); MyTat.Add("Eye Catcher");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_006"); MyTat.Add("Blackjack");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_004"); MyTat.Add("Evil Clown");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_000"); MyTat.Add("Imperial Douche");
                }//TORSO
                else if (iZone == 2)
                {
                    bEmpty = true;
                }//HEAD
                else if (iZone == 3)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_024"); MyTat.Add("Grim Reaper Smoking Gun");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_018"); MyTat.Add("Dope Skull");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_017"); MyTat.Add("The Wages of Sin");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_016"); MyTat.Add("Dragon and Dagger");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_003"); MyTat.Add("Zodiac Skull");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_001"); MyTat.Add("R.I.P Michael");
                }//LEFT ARM
                else if (iZone == 4)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_020"); MyTat.Add("Indian Ram");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_014"); MyTat.Add("Muertos");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_010"); MyTat.Add("Flaming Skull");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_009"); MyTat.Add("Broken Skull");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_008"); MyTat.Add("Dagger");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_007"); MyTat.Add("Tribal");
                }//RIGHT ARM
                else if (iZone == 5)
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_011"); MyTat.Add("Serpant Skull");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_002"); MyTat.Add("Grim Reaper");
                }//LEFT LEG
                else
                {
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_025"); MyTat.Add("Freedom");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_019"); MyTat.Add("Flaming Scorpion");
                    DataStore.sTatBase.Add("singleplayer_overlays"); DataStore.sTatName.Add("TP_005"); MyTat.Add("Love to Hate");
                }//RIGHT LEG
            }// Trevor
            else if (iPed == 4)
            {
                if (iZone == 1)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_021_F"); MyTat.Add("Skull Surfer");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_020_F"); MyTat.Add("Speaker Tower");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_019_F"); MyTat.Add("Record Shot");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_018_F"); MyTat.Add("Record Head");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_017_F"); MyTat.Add("Tropical Sorcerer");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_016_F"); MyTat.Add("Rose Panther");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_015_F"); MyTat.Add("Paradise Ukulele");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_014_F"); MyTat.Add("Paradise Nap");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_013_F"); MyTat.Add("Wild Dancers");//

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_039_F"); MyTat.Add("Space Rangers");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_038_F"); MyTat.Add("Robot Bubblegum");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_036_F"); MyTat.Add("LS Shield");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_030_F"); MyTat.Add("Howitzer");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_028_F"); MyTat.Add("Bananas Gone Bad");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_027_F"); MyTat.Add("Epsilon");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_024_F"); MyTat.Add("Mount Chiliad");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_023_F"); MyTat.Add("Bigfoot");//

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_032_F"); MyTat.Add("Play Your Ace");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_029_F"); MyTat.Add("The Table");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_021_F"); MyTat.Add("Show Your Hand");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_017_F"); MyTat.Add("Roll the Dice");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_015_F"); MyTat.Add("The Jolly Joker");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_011_F"); MyTat.Add("Life's a Gamble");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_010_F"); MyTat.Add("Photo Finish");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_009_F"); MyTat.Add("Till Death Do Us Part");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_008_F"); MyTat.Add("Snake Eyes");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_007_F"); MyTat.Add("777");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_006_F"); MyTat.Add("Wheel of Suits");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_001_F"); MyTat.Add("Jackpot");//

                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_027_F"); MyTat.Add("Molon Labe");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_024_F"); MyTat.Add("Dragon Slayer");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_022_F"); MyTat.Add("Spartan and Horse");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_021_F"); MyTat.Add("Spartan and Lion");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_016_F"); MyTat.Add("Odin and Raven");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_015_F"); MyTat.Add("Samurai Combat");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_011_F"); MyTat.Add("Weathered Skull");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_010_F"); MyTat.Add("Spartan Shield");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_009_F"); MyTat.Add("Norse Rune");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_005_F"); MyTat.Add("Ghost Dragon");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_002_F"); MyTat.Add("Kabuto");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_025_F"); MyTat.Add("Claimed By The Beast");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_024_F"); MyTat.Add("Pirate Captain");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_022_F"); MyTat.Add("X Marks The Spot");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_018_F"); MyTat.Add("Finders Keepers");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_017_F"); MyTat.Add("Framed Tall Ship");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_016_F"); MyTat.Add("Skull Compass");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_013_F"); MyTat.Add("Torn Wings");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_009_F"); MyTat.Add("Tall Ship Conflict");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_006_F"); MyTat.Add("Never Surrender");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_003_F"); MyTat.Add("Give Nothing Back");

                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_007_F"); MyTat.Add("Eagle Eyes");
                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_005_F"); MyTat.Add("Parachute Belle");
                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_004_F"); MyTat.Add("Balloon Pioneer");
                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_002_F"); MyTat.Add("Winged Bombshell");
                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_001_F"); MyTat.Add("Pilot Skull");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_022_F"); MyTat.Add("Explosive Heart");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_019_F"); MyTat.Add("Pistol Wings");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_018_F"); MyTat.Add("Dual Wield Skull");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_014_F"); MyTat.Add("Backstabber");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_013_F"); MyTat.Add("Wolf Insignia");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_009_F"); MyTat.Add("Butterfly Knife");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_001_F"); MyTat.Add("Crossed Weapons");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_000_F"); MyTat.Add("Bullet Proof");

                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_011_F"); MyTat.Add("Talk Shit Get Hit");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_010_F"); MyTat.Add("Take the Wheel");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_009_F"); MyTat.Add("Serpents of Destruction");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_002_F"); MyTat.Add("Tuned to Death");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_001_F"); MyTat.Add("Power Plant");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_000_F"); MyTat.Add("Block Back");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_043_F"); MyTat.Add("Ride Forever");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_030_F"); MyTat.Add("Brothers For Life");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_021_F"); MyTat.Add("Flaming Reaper");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_017_F"); MyTat.Add("Clawed Beast");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_011_F"); MyTat.Add("R.I.P. My Brothers");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_008_F"); MyTat.Add("Freedom Wheels");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_006_F"); MyTat.Add("Chopper Freedom");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_048_F"); MyTat.Add("Racing Doll");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_046_F"); MyTat.Add("Full Throttle");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_041_F"); MyTat.Add("Brapp");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_040_F"); MyTat.Add("Monkey Chopper");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_037_F"); MyTat.Add("Big Grills");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_034_F"); MyTat.Add("Feather Road Kill");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_030_F"); MyTat.Add("Man's Ruin");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_029_F"); MyTat.Add("Majestic Finish");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_026_F"); MyTat.Add("Winged Wheel");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_024_F"); MyTat.Add("Road Kill");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_032_F"); MyTat.Add("Reign Over");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_031_F"); MyTat.Add("Dead Pretty");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_008_F"); MyTat.Add("Love the Game");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_000_F"); MyTat.Add("SA Assault");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_021_F"); MyTat.Add("Sad Angel");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_014_F"); MyTat.Add("Love is Blind");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_010_F"); MyTat.Add("Bad Angel");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_009_F"); MyTat.Add("Amazon");//

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_029_F"); MyTat.Add("Geometric Design");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_022_F"); MyTat.Add("Cloaked Angel");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_024_F"); MyTat.Add("Feather Mural");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_006_F"); MyTat.Add("Adorned Wolf");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_015"); MyTat.Add("Japanese Warrior");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_011"); MyTat.Add("Roaring Tiger");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_006"); MyTat.Add("Carp Shaded");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_005"); MyTat.Add("Carp Outline");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_046"); MyTat.Add("Triangles");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_041"); MyTat.Add("Tooth");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_032"); MyTat.Add("Paper Plane");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_031"); MyTat.Add("Skateboard");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_030"); MyTat.Add("Shark Fin");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_025"); MyTat.Add("Watch Your Step");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_024"); MyTat.Add("Pyamid");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_012"); MyTat.Add("Antlers");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_011"); MyTat.Add("Infinity");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_000"); MyTat.Add("Crossed Arrows");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_Back_001"); MyTat.Add("Gold Digger");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_Back_000"); MyTat.Add("Respect");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Should_000"); MyTat.Add("Sea Horses");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Back_002"); MyTat.Add("Shrimp");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Should_001"); MyTat.Add("Catfish");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Back_000"); MyTat.Add("Rock Solid");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Back_001"); MyTat.Add("Hibiscus Flower Duo");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_045"); MyTat.Add("Skulls and Rose");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_030"); MyTat.Add("Lucky Celtic Dogs");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_020"); MyTat.Add("Dragon");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_019"); MyTat.Add("The Wages of Sin");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_016"); MyTat.Add("Evil Clown");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_013"); MyTat.Add("Eagle and Serpent");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_011"); MyTat.Add("LS Script");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_009"); MyTat.Add("Skull on the Cross");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_019"); MyTat.Add("Clown Dual Wield Dollars");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_018"); MyTat.Add("Clown Dual Wield");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_017"); MyTat.Add("Clown and Gun");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_016"); MyTat.Add("Clown");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_014"); MyTat.Add("Trust No One");//Car Bomb Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_008"); MyTat.Add("Los Santos Customs");//Mod a Car Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_005"); MyTat.Add("Angel");//Win Every Game Mode Award
                    //Not In List
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_046"); MyTat.Add("Zip?");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_006"); MyTat.Add("Feather Birds");
                    DataStore.sTatBase.Add("mpchristmas2018_overlays"); DataStore.sTatName.Add("MP_Christmas2018_Tat_000_F"); MyTat.Add("???");
                }//BACK
                else if (iZone == 2)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_023_F"); MyTat.Add("Techno Glitch");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_022_F"); MyTat.Add("Paradise Sirens");//

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_035_F"); MyTat.Add("LS Panic");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_033_F"); MyTat.Add("LS City");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_026_F"); MyTat.Add("Dignity");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_025_F"); MyTat.Add("Davis");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_022_F"); MyTat.Add("Blood Money");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_003_F"); MyTat.Add("Royal Flush");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_000_F"); MyTat.Add("In the Pocket");//

                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_026_F"); MyTat.Add("Spartan Skull");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_020_F"); MyTat.Add("Medusa's Gaze");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_019_F"); MyTat.Add("Strike Force");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_003_F"); MyTat.Add("Native Warrior");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_000_F"); MyTat.Add("Thor - Goblin");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_021_F"); MyTat.Add("Dead Tales");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_019_F"); MyTat.Add("Lost At Sea");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_007_F"); MyTat.Add("No Honor");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_000_F"); MyTat.Add("Bless The Dead");

                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_000_F"); MyTat.Add("Turbulence");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_028_F"); MyTat.Add("Micro SMG Chain");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_020_F"); MyTat.Add("Crowned Weapons");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_017_F"); MyTat.Add("Dog Tags");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_012_F"); MyTat.Add("Dollar Daggers");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_060_F"); MyTat.Add("We Are The Mods!");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_059_F"); MyTat.Add("Faggio");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_058_F"); MyTat.Add("Reaper Vulture");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_050_F"); MyTat.Add("Unforgiven");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_041_F"); MyTat.Add("No Regrets");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_034_F"); MyTat.Add("Brotherhood of Bikes");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_032_F"); MyTat.Add("Western Eagle");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_029_F"); MyTat.Add("Bone Wrench");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_026_F"); MyTat.Add("American Dream");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_023_F"); MyTat.Add("Western MC");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_019_F"); MyTat.Add("Gruesome Talons");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_018_F"); MyTat.Add("Skeletal Chopper");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_013_F"); MyTat.Add("Demon Crossbones");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_005_F"); MyTat.Add("Made In America");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_001_F"); MyTat.Add("Both Barrels");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_000_F"); MyTat.Add("Demon Rider");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_044_F"); MyTat.Add("Ram Skull");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_033_F"); MyTat.Add("Sugar Skull Trucker");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_027_F"); MyTat.Add("Punk Road Hog");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_019_F"); MyTat.Add("Engine Heart");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_018_F"); MyTat.Add("Vintage Bully");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_011_F"); MyTat.Add("Wheels of Death");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_019_F"); MyTat.Add("Death Behind");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_012_F"); MyTat.Add("Royal Kiss");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_026_F"); MyTat.Add("Royal Takeover");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_013_F"); MyTat.Add("Love Gamble");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_002_F"); MyTat.Add("Holy Mary");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_001_F"); MyTat.Add("King Fight");//

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_027_F"); MyTat.Add("Cobra Dawn");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_025_F"); MyTat.Add("Reaper Sway");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_012_F"); MyTat.Add("Geometric Galaxy");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_002_F"); MyTat.Add("The Howler");

                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_015_F"); MyTat.Add("Smoking Sisters");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_014_F"); MyTat.Add("Ancient Queen");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_008_F"); MyTat.Add("Flying Eye");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_007_F"); MyTat.Add("Eye of the Griffin");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_019"); MyTat.Add("Royal Dagger Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_018"); MyTat.Add("Royal Dagger Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_017"); MyTat.Add("Loose Lips Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_016"); MyTat.Add("Loose Lips Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_009"); MyTat.Add("Time To Die");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_047"); MyTat.Add("Cassette");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_033"); MyTat.Add("Stag");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_013"); MyTat.Add("Boombox");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_002"); MyTat.Add("Chemistry");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_Chest_002"); MyTat.Add("Love Money");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_Chest_001"); MyTat.Add("Makin' Money");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_Chest_000"); MyTat.Add("High Roller");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Chest_001"); MyTat.Add("Anchor");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Chest_000"); MyTat.Add("Anchor");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Chest_002"); MyTat.Add("Los Santos Wreath");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_044"); MyTat.Add("Stone Cross");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_034"); MyTat.Add("Flaming Shamrock");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_025"); MyTat.Add("LS Bold");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_024"); MyTat.Add("Flaming Cross");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_010"); MyTat.Add("LS Flames");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_013"); MyTat.Add("Seven Deadly Sins");//Kill 1000 Players Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_012"); MyTat.Add("Embellished Scroll");//Kill 500 Players Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_011"); MyTat.Add("Blank Scroll");////Kill 100 Players Award?
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_003"); MyTat.Add("Blackjack");
                    //
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Female_Crew_Tat_000"); MyTat.Add("Crew Emblem");
                }//CHEST
                else if (iZone == 3)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_030_F"); MyTat.Add("Radio Tape");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_004_F"); MyTat.Add("Skeleton Breeze");//

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_037_F"); MyTat.Add("LadyBug");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_029_F"); MyTat.Add("Fatal Incursion");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_031_F"); MyTat.Add("Gambling Royalty");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_024_F"); MyTat.Add("Cash Mouth");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_016_F"); MyTat.Add("Rose and Aces");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_012_F"); MyTat.Add("Skull of Suits");//

                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_008_F"); MyTat.Add("Spartan Warrior");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_015_F"); MyTat.Add("Jolly Roger");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_010_F"); MyTat.Add("See You In Hell");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_002_F"); MyTat.Add("Dead Lies");

                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_006_F"); MyTat.Add("Bombs Away");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_029_F"); MyTat.Add("Win Some Lose Some");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_010_F"); MyTat.Add("Cash Money");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_052_F"); MyTat.Add("Biker Mount");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_039_F"); MyTat.Add("Gas Guzzler");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_031_F"); MyTat.Add("Gear Head");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_010_F"); MyTat.Add("Skull Of Taurus");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_003_F"); MyTat.Add("Web Rider");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_014_F"); MyTat.Add("Bat Cat of Spades");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_012_F"); MyTat.Add("Punk Biker");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_016_F"); MyTat.Add("Two Face");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_011_F"); MyTat.Add("Lady Liberty");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_004_F"); MyTat.Add("Gun Mic");//

                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_003_F"); MyTat.Add("Abstract Skull");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_028"); MyTat.Add("Executioner");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_013"); MyTat.Add("Lizard");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_035"); MyTat.Add("Sewn Heart");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_029"); MyTat.Add("Sad");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_006"); MyTat.Add("Feather Birds");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_Stom_002"); MyTat.Add("Money Bag");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_Stom_001"); MyTat.Add("Santo Capra Logo");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_Stom_000"); MyTat.Add("Diamond Back");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Stom_000"); MyTat.Add("Swallow");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Stom_002"); MyTat.Add("Dolphin");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Stom_001"); MyTat.Add("Hibiscus Flower");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_RSide_000"); MyTat.Add("Love Dagger");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_036"); MyTat.Add("Way of the Gun");//500 Pistol kills Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_029"); MyTat.Add("Trinity Knot");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_012"); MyTat.Add("Los Santos Bills");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_004"); MyTat.Add("Faith");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_004"); MyTat.Add("Hustler");//Make 50000 from betting Award
                }//STOMACH
                else if (iZone == 4)
                {
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_022_F"); MyTat.Add("Thong's Sword");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_021_F"); MyTat.Add("Wanted");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_020_F"); MyTat.Add("UFO");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_019_F"); MyTat.Add("Teddy Bear");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_018_F"); MyTat.Add("Stitches");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_017_F"); MyTat.Add("Space Monkey");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_016_F"); MyTat.Add("Sleepy");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_015_F"); MyTat.Add("On/Off");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_014_F"); MyTat.Add("LS Wings");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_013_F"); MyTat.Add("LS Star");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_012_F"); MyTat.Add("Razor Pop");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_011_F"); MyTat.Add("Lipstick Kiss");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_010_F"); MyTat.Add("Green Leaf");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_009_F"); MyTat.Add("Knifed");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_008_F"); MyTat.Add("Ice Cream");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_007_F"); MyTat.Add("Two Horns");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_006_F"); MyTat.Add("Crowned");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_005_F"); MyTat.Add("Spades");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_004_F"); MyTat.Add("Bandage");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_003_F"); MyTat.Add("Assault Rifle");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_002_F"); MyTat.Add("Animal");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_001_F"); MyTat.Add("Ace of Spades");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_000_F"); MyTat.Add("Five Stars");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_012_F"); MyTat.Add("Thief");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_011_F"); MyTat.Add("Sinner");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_003_F"); MyTat.Add("Lock and Load");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_051_F"); MyTat.Add("Western Stylized");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_038_F"); MyTat.Add("FTW");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_009_F"); MyTat.Add("Morbid Arachnid");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_042_F"); MyTat.Add("Flaming Quad");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_017_F"); MyTat.Add("Bat Wheel");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_Tat_006_F"); MyTat.Add("Toxic Spider");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_Tat_004_F"); MyTat.Add("Scorpion");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_Tat_000_F"); MyTat.Add("Stunt Skull");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_029"); MyTat.Add("Beautiful Death");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_025"); MyTat.Add("Snake Head Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_024"); MyTat.Add("Snake Head Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_007"); MyTat.Add("Los Muertos");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_021"); MyTat.Add("Geo Fox");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_005"); MyTat.Add("Beautiful Eye");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_Neck_001"); MyTat.Add("Money Rose");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_Neck_000"); MyTat.Add("Val-de-Grace Logo");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Neck_000"); MyTat.Add("Tribal Butterfly");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_Neck_000"); MyTat.Add("Little Fish");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_000"); MyTat.Add("Skull");//500 Headshots Award
                    //Not On the TatlIst     ...                            
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_044_F"); MyTat.Add("Clubs");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_043_F"); MyTat.Add("Diamonds");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_042_F"); MyTat.Add("Hearts");
                }//HEAD
                else if (iZone == 5)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_009_F"); MyTat.Add("Scratch Panther");

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_041_F"); MyTat.Add("Mighty Thog");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_040_F"); MyTat.Add("Tiger Heart");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_026_F"); MyTat.Add("Banknote Rose");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_019_F"); MyTat.Add("Can't Win Them All");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_014_F"); MyTat.Add("Vice");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_005_F"); MyTat.Add("Get Lucky");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_002_F"); MyTat.Add("Suits");//

                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_029_F"); MyTat.Add("Cerberus");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_025_F"); MyTat.Add("Winged Serpent");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_013_F"); MyTat.Add("Katana");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_007_F"); MyTat.Add("Spartan Combat");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_004_F"); MyTat.Add("Tiger and Mask");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_001_F"); MyTat.Add("Viking Warrior");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_014_F"); MyTat.Add("Mermaid's Curse");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_008_F"); MyTat.Add("Horrors Of The Deep");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_004_F"); MyTat.Add("Honor");

                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_003_F"); MyTat.Add("Toxic Trails");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_027_F"); MyTat.Add("Serpent Revolver");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_025_F"); MyTat.Add("Praying Skull");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_016_F"); MyTat.Add("Blood Money");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_015_F"); MyTat.Add("Spiked Skull");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_008_F"); MyTat.Add("Bandolier");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_004_F"); MyTat.Add("Sidearm");

                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_008_F"); MyTat.Add("Scarlett");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_004_F"); MyTat.Add("Piston Sleeve");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_055_F"); MyTat.Add("Poison Scorpion");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_053_F"); MyTat.Add("Muffler Helmet");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_045_F"); MyTat.Add("Ride Hard Die Fast");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_035_F"); MyTat.Add("Chain Fist");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_025_F"); MyTat.Add("Good Luck");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_024_F"); MyTat.Add("Live to Ride");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_020_F"); MyTat.Add("Cranial Rose");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_016_F"); MyTat.Add("Macabre Tree");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_012_F"); MyTat.Add("Urban Stunter");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_043_F"); MyTat.Add("Engine Arm");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_039_F"); MyTat.Add("Kaboom");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_035_F"); MyTat.Add("Stuntman's End");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_023_F"); MyTat.Add("Tanked");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_022_F"); MyTat.Add("Piston Head");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_008_F"); MyTat.Add("Moonlight Ride");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_002_F"); MyTat.Add("Big Cat");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_001_F"); MyTat.Add("8 Eyed Skull");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_022_F"); MyTat.Add("My Crazy Life");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_018_F"); MyTat.Add("Skeleton Party");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_006_F"); MyTat.Add("Love Hustle");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_033_F"); MyTat.Add("City Sorrow");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_027_F"); MyTat.Add("Los Santos Life");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_005_F"); MyTat.Add("No Evil");//

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_028_F"); MyTat.Add("Python Skull");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_018_F"); MyTat.Add("Divine Goddess");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_016_F"); MyTat.Add("Egyptian Mural");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_005_F"); MyTat.Add("Fatal Dagger");

                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_021_F"); MyTat.Add("Gabriel");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_020_F"); MyTat.Add("Archangel and Mary");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_009_F"); MyTat.Add("Floral Symmetry");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_021"); MyTat.Add("Time's Up Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_020"); MyTat.Add("Time's Up Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_012"); MyTat.Add("8 Ball Skull");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_010"); MyTat.Add("Electric Snake");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_000"); MyTat.Add("Skull Rider");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_048"); MyTat.Add("Peace");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_043"); MyTat.Add("Triangle White");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_039"); MyTat.Add("Sleeve");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_037"); MyTat.Add("Sunrise");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_034"); MyTat.Add("Stop");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_028"); MyTat.Add("Thorny Rose");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_027"); MyTat.Add("Padlock");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_026"); MyTat.Add("Pizza");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_016"); MyTat.Add("Lightning Bolt");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_015"); MyTat.Add("Mustache");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_007"); MyTat.Add("Bricks");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_003"); MyTat.Add("Diamond Sparkle");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_LArm_000"); MyTat.Add("Greed is Good");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_LArm_001"); MyTat.Add("Parrot");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_LArm_000"); MyTat.Add("Tribal Flower");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_041"); MyTat.Add("Dope Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_031"); MyTat.Add("Lady M");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_015"); MyTat.Add("Zodiac Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_006"); MyTat.Add("Oriental Mural");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_005"); MyTat.Add("Serpents");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_015"); MyTat.Add("Racing Brunette");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_007"); MyTat.Add("Racing Blonde");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_001"); MyTat.Add("Burning Heart");//50 Death Match Award
                    //not on list
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_031_F"); MyTat.Add("Geometric Design");
                }//LEFT ARM
                else if (iZone == 6)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_032_F"); MyTat.Add("K.U.L.T.99.1 FM");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_031_F"); MyTat.Add("Octopus Shades");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_026_F"); MyTat.Add("Shark Water");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_012_F"); MyTat.Add("Still Slipping");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_011_F"); MyTat.Add("Soulwax");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_008_F"); MyTat.Add("Smiley Glitch");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_007_F"); MyTat.Add("Skeleton DJ");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_006_F"); MyTat.Add("Music Locker");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_005_F"); MyTat.Add("LSUR");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_003_F"); MyTat.Add("Lighthouse");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_002_F"); MyTat.Add("Jellyfish Shades");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_001_F"); MyTat.Add("Tropical Dude");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_000_F"); MyTat.Add("Headphone Splat");

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_034_F"); MyTat.Add("LS Monogram");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_028_F"); MyTat.Add("Skull and Aces");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_025_F"); MyTat.Add("Queen of Roses");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_018_F"); MyTat.Add("The Gambler's Life");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_004_F"); MyTat.Add("Lady Luck");//

                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_028_F"); MyTat.Add("Spartan Mural");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_023_F"); MyTat.Add("Samurai Tallship");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_018_F"); MyTat.Add("Muscle Tear");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_017_F"); MyTat.Add("Feather Sleeve");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_014_F"); MyTat.Add("Celtic Band");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_012_F"); MyTat.Add("Tiger Headdress");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_006_F"); MyTat.Add("Medusa");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_023_F"); MyTat.Add("Stylized Kraken");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_005_F"); MyTat.Add("Mutiny");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_001_F"); MyTat.Add("Crackshot");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_024_F"); MyTat.Add("Combat Reaper");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_021_F"); MyTat.Add("Have a Nice Day");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_002_F"); MyTat.Add("Grenade");

                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_007_F"); MyTat.Add("Drive Forever");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_006_F"); MyTat.Add("Engulfed Block");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_005_F"); MyTat.Add("Dialed In");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_003_F"); MyTat.Add("Mechanical Sleeve");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_054_F"); MyTat.Add("Mum");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_049_F"); MyTat.Add("These Colors Don't Run");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_047_F"); MyTat.Add("Snake Bike");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_046_F"); MyTat.Add("Skull Chain");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_042_F"); MyTat.Add("Grim Rider");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_033_F"); MyTat.Add("Eagle Emblem");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_014_F"); MyTat.Add("Lady Mortality");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_007_F"); MyTat.Add("Swooping Eagle");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_049_F"); MyTat.Add("Seductive Mechanic");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_038_F"); MyTat.Add("One Down Five Up");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_036_F"); MyTat.Add("Biker Stallion");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_016_F"); MyTat.Add("Coffin Racer");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_010_F"); MyTat.Add("Grave Vulture");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_009_F"); MyTat.Add("Arachnid of Death");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_003_F"); MyTat.Add("Poison Wrench");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_035_F"); MyTat.Add("Black Tears");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_028_F"); MyTat.Add("Loving Los Muertos");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_003_F"); MyTat.Add("Lady Vamp");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_015_F"); MyTat.Add("Seductress");//

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_026_F"); MyTat.Add("Floral Print");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_017_F"); MyTat.Add("Heavenly Deity");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_010_F"); MyTat.Add("Intrometric");

                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_019_F"); MyTat.Add("Geisha Bloom");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_013_F"); MyTat.Add("Mermaid Harpist");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_004_F"); MyTat.Add("Floral Raven");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_027"); MyTat.Add("Fuck Luck Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_026"); MyTat.Add("Fuck Luck Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_023"); MyTat.Add("You're Next Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_022"); MyTat.Add("You're Next Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_008"); MyTat.Add("Death Before Dishonor");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_004"); MyTat.Add("Snake Shaded");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_003"); MyTat.Add("Snake Outline");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_045"); MyTat.Add("Mesh Band");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_044"); MyTat.Add("Triangle Black");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_036"); MyTat.Add("Shapes");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_023"); MyTat.Add("Smiley");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_022"); MyTat.Add("Pencil");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_020"); MyTat.Add("Geo Pattern");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_018"); MyTat.Add("Origami");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_017"); MyTat.Add("Eye Triangle");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_014"); MyTat.Add("Spray Can");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_010"); MyTat.Add("Horseshoe");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_008"); MyTat.Add("Cube");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_004"); MyTat.Add("Bone");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_001"); MyTat.Add("Single Arrow");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_RArm_000"); MyTat.Add("Dollar Sign");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_RArm_001"); MyTat.Add("Tribal Fish");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_047"); MyTat.Add("Lion");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_038"); MyTat.Add("Dagger");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_028"); MyTat.Add("Mermaid");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_027"); MyTat.Add("Virgin Mary");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_018"); MyTat.Add("Serpent Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_014"); MyTat.Add("Flower Mural");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_003"); MyTat.Add("Dragons and Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_001"); MyTat.Add("Dragons");
                    //DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_000"); MyTat.Add("Brotherhood");-empty load?

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_010"); MyTat.Add("Ride or Die");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_002"); MyTat.Add("Grim Reaper Smoking Gun");//Clear 5 Gang Atacks in a Day Award
                    //Not In List
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Female_Crew_Tat_001"); MyTat.Add("Crew Tattoo");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_030_F"); MyTat.Add("Geometric Design");
                }//RIGHT ARM
                else if (iZone == 7)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_029_F"); MyTat.Add("Soundwaves");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_028_F"); MyTat.Add("Skull Waters");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_025_F"); MyTat.Add("Glow Princess");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_024_F"); MyTat.Add("Pineapple Skull");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_010_F"); MyTat.Add("Tropical Serpent");

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_032_F"); MyTat.Add("Love Fist");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_027_F"); MyTat.Add("8-Ball Rose");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_013_F"); MyTat.Add("One-armed Bandit");//

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_023_F"); MyTat.Add("Rose Revolver");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_011_F"); MyTat.Add("Death Skull");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_007_F"); MyTat.Add("Stylized Tiger");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_005_F"); MyTat.Add("Patriot Skull");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_057_F"); MyTat.Add("Laughing Skull");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_056_F"); MyTat.Add("Bone Cruiser");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_044_F"); MyTat.Add("Ride Free");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_037_F"); MyTat.Add("Scorched Soul");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_036_F"); MyTat.Add("Engulfed Skull");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_027_F"); MyTat.Add("Bad Luck");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_015_F"); MyTat.Add("Ride or Die");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_002_F"); MyTat.Add("Rose Tribute");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_031_F"); MyTat.Add("Stunt Jesus");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_028_F"); MyTat.Add("Quad Goblin");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_021_F"); MyTat.Add("Golden Cobra");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_013_F"); MyTat.Add("Dirt Track Hero");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_007_F"); MyTat.Add("Dagger Devil");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_029_F"); MyTat.Add("Death Us Do Part");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_020_F"); MyTat.Add("Presidents");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_007_F"); MyTat.Add("LS Serpent");//

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_011_F"); MyTat.Add("Cross of Roses");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_000_F"); MyTat.Add("Serpent of Death");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_002"); MyTat.Add("Spider Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_001"); MyTat.Add("Spider Outline");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_040"); MyTat.Add("Black Anchor");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_019"); MyTat.Add("Charm");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_009"); MyTat.Add("Squares");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_LLeg_000"); MyTat.Add("Single");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_032"); MyTat.Add("Faith");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_037"); MyTat.Add("Grim Reaper");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_035"); MyTat.Add("Dragon");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_033"); MyTat.Add("Chinese Dragon");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_026"); MyTat.Add("Smoking Dagger");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_023"); MyTat.Add("Hottie");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_021"); MyTat.Add("Serpent Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_008"); MyTat.Add("Dragon Mural");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_002"); MyTat.Add("Melting Skull");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_009"); MyTat.Add("Dragon and Dagger");
                }//LEFT LEG
                else
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_027_F"); MyTat.Add("Skullphones");

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_031_F"); MyTat.Add("Kifflom");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_020_F"); MyTat.Add("Cash is King");//

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_020_F"); MyTat.Add("Homeward Bound");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_030_F"); MyTat.Add("Pistol Ace");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_026_F"); MyTat.Add("Restless Skull");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_006_F"); MyTat.Add("Combat Skull");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_048_F"); MyTat.Add("STFU");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_040_F"); MyTat.Add("American Made");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_028_F"); MyTat.Add("Dusk Rider");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_022_F"); MyTat.Add("Western Insignia");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_004_F"); MyTat.Add("Dragon's Fury");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_047_F"); MyTat.Add("Brake Knife");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_045_F"); MyTat.Add("Severed Hand");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_032_F"); MyTat.Add("Wheelie Mouse");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_025_F"); MyTat.Add("Speed Freak");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_020_F"); MyTat.Add("Piston Angel");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_015_F"); MyTat.Add("Praying Gloves");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_005_F"); MyTat.Add("Demon Spark Plug");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_030_F"); MyTat.Add("San Andreas Prayer");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_023_F"); MyTat.Add("Dance of Hearts");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_017_F"); MyTat.Add("Ink Me");//

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_023_F"); MyTat.Add("Starmetric");

                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_001_F"); MyTat.Add("Elaborate Los Muertos");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_F_Tat_014"); MyTat.Add("Floral Dagger");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_042"); MyTat.Add("Sparkplug");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_F_Tat_038"); MyTat.Add("Grub");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_F_RLeg_000"); MyTat.Add("Diamond Crown");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_F_RLeg_000"); MyTat.Add("School of Fish");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_043"); MyTat.Add("Indian Ram");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_042"); MyTat.Add("Flaming Scorpion");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_040"); MyTat.Add("Flaming Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_039"); MyTat.Add("Broken Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_022"); MyTat.Add("Fiery Dragon");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_017"); MyTat.Add("Tribal");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_F_007"); MyTat.Add("The Warrior");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_F_006"); MyTat.Add("Skull and Sword");//Collect 25 Bounties Award
                }//RIGHT LEG
            }// FreeFemale
            else if (iPed == 5)
            {
                if (iZone == 1)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_021_M"); MyTat.Add("Skull Surfer");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_020_M"); MyTat.Add("Speaker Tower");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_019_M"); MyTat.Add("Record Shot");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_018_M"); MyTat.Add("Record Head");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_017_M"); MyTat.Add("Tropical Sorcerer");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_016_M"); MyTat.Add("Rose Panther");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_015_M"); MyTat.Add("Paradise Ukulele");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_014_M"); MyTat.Add("Paradise Nap");//
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_013_M"); MyTat.Add("Wild Dancers");//

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_039_M"); MyTat.Add("Space Rangers");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_038_M"); MyTat.Add("Robot Bubblegum");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_036_M"); MyTat.Add("LS Shield");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_030_M"); MyTat.Add("Howitzer");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_028_M"); MyTat.Add("Bananas Gone Bad");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_027_M"); MyTat.Add("Epsilon");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_024_M"); MyTat.Add("Mount Chiliad");//
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_023_M"); MyTat.Add("Bigfoot");//

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_032_M"); MyTat.Add("Play Your Ace");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_029_M"); MyTat.Add("The Table");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_021_M"); MyTat.Add("Show Your Hand");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_017_M"); MyTat.Add("Roll the Dice");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_015_M"); MyTat.Add("The Jolly Joker");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_011_M"); MyTat.Add("Life's a Gamble");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_010_M"); MyTat.Add("Photo Finish");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_009_M"); MyTat.Add("Till Death Do Us Part");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_008_M"); MyTat.Add("Snake Eyes");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_007_M"); MyTat.Add("777");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_006_M"); MyTat.Add("Wheel of Suits");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_001_M"); MyTat.Add("Jackpot");//

                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_027_M"); MyTat.Add("Molon Labe");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_024_M"); MyTat.Add("Dragon Slayer");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_022_M"); MyTat.Add("Spartan and Horse");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_021_M"); MyTat.Add("Spartan and Lion");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_016_M"); MyTat.Add("Odin and Raven");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_015_M"); MyTat.Add("Samurai Combat");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_011_M"); MyTat.Add("Weathered Skull");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_010_M"); MyTat.Add("Spartan Shield");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_009_M"); MyTat.Add("Norse Rune");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_005_M"); MyTat.Add("Ghost Dragon");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_002_M"); MyTat.Add("Kabuto");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_025_M"); MyTat.Add("Claimed By The Beast");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_024_M"); MyTat.Add("Pirate Captain");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_022_M"); MyTat.Add("X Marks The Spot");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_018_M"); MyTat.Add("Finders Keepers");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_017_M"); MyTat.Add("Framed Tall Ship");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_016_M"); MyTat.Add("Skull Compass");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_013_M"); MyTat.Add("Torn Wings");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_009_M"); MyTat.Add("Tall Ship Conflict");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_006_M"); MyTat.Add("Never Surrender");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_003_M"); MyTat.Add("Give Nothing Back");

                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_007_M"); MyTat.Add("Eagle Eyes");
                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_005_M"); MyTat.Add("Parachute Belle");
                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_004_M"); MyTat.Add("Balloon Pioneer");
                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_002_M"); MyTat.Add("Winged Bombshell");
                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_001_M"); MyTat.Add("Pilot Skull");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_022_M"); MyTat.Add("Explosive Heart");//
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_019_M"); MyTat.Add("Pistol Wings");//
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_018_M"); MyTat.Add("Dual Wield Skull");//
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_014_M"); MyTat.Add("Backstabber");//
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_013_M"); MyTat.Add("Wolf Insignia");//
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_009_M"); MyTat.Add("Butterfly Knife");//
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_001_M"); MyTat.Add("Crossed Weapons");//
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_000_M"); MyTat.Add("Bullet Proof");//

                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_011_M"); MyTat.Add("Talk Shit Get Hit");//
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_010_M"); MyTat.Add("Take the Wheel");//
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_009_M"); MyTat.Add("Serpents of Destruction");//
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_002_M"); MyTat.Add("Tuned to Death");//
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_001_M"); MyTat.Add("Power Plant");//
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_000_M"); MyTat.Add("Block Back");//

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_043_M"); MyTat.Add("Ride Forever");//
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_030_M"); MyTat.Add("Brothers For Life");//
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_021_M"); MyTat.Add("Flaming Reaper");//
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_017_M"); MyTat.Add("Clawed Beast");//
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_011_M"); MyTat.Add("R.I.P. My Brothers");//
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_008_M"); MyTat.Add("Freedom Wheels");//
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_006_M"); MyTat.Add("Chopper Freedom");//

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_048_M"); MyTat.Add("Racing Doll");//
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_046_M"); MyTat.Add("Full Throttle");//
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_041_M"); MyTat.Add("Brapp");//
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_040_M"); MyTat.Add("Monkey Chopper");//
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_037_M"); MyTat.Add("Big Grills");//
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_034_M"); MyTat.Add("Feather Road Kill");//
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_030_M"); MyTat.Add("Man's Ruin");//
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_029_M"); MyTat.Add("Majestic Finish");//
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_026_M"); MyTat.Add("Winged Wheel");//
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_024_M"); MyTat.Add("Road Kill");//

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_032_M"); MyTat.Add("Reign Over");//
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_031_M"); MyTat.Add("Dead Pretty");//
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_008_M"); MyTat.Add("Love the Game");//
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_000_M"); MyTat.Add("SA Assault");//

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_021_M"); MyTat.Add("Sad Angel");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_014_M"); MyTat.Add("Love is Blind");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_010_M"); MyTat.Add("Bad Angel");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_009_M"); MyTat.Add("Amazon");//

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_029_M"); MyTat.Add("Geometric Design");//   
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_022_M"); MyTat.Add("Cloaked Angel");//  
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_024_M"); MyTat.Add("Feather Mural");//    
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_006_M"); MyTat.Add("Adorned Wolf");//   

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_015"); MyTat.Add("Japanese Warrior");//          
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_011"); MyTat.Add("Roaring Tiger");//      
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_006"); MyTat.Add("Carp Shaded");//   
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_005"); MyTat.Add("Carp Outline");//   

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_046"); MyTat.Add("Triangles");//         
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_041"); MyTat.Add("Tooth");//         
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_032"); MyTat.Add("Paper Plane");//         
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_031"); MyTat.Add("Skateboard");//           
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_030"); MyTat.Add("Shark Fin");//        
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_025"); MyTat.Add("Watch Your Step");//          
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_024"); MyTat.Add("Pyamid");//   
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_012"); MyTat.Add("Antlers");//  
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_011"); MyTat.Add("Infinity");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_000"); MyTat.Add("Crossed Arrows");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_Back_000"); MyTat.Add("Makin' Paper");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Back_000"); MyTat.Add("Ship Arms");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_045"); MyTat.Add("Skulls and Rose");//
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_030"); MyTat.Add("Lucky Celtic Dogs");//
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_020"); MyTat.Add("Dragon");//
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_019"); MyTat.Add("The Wages of Sin");//Survival Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_016"); MyTat.Add("Evil Clown");//
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_013"); MyTat.Add("Eagle and Serpent");//
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_011"); MyTat.Add("LS Script");//
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_009"); MyTat.Add("Skull on the Cross");//

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_019"); MyTat.Add("Clown Dual Wield Dollars");//
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_018"); MyTat.Add("Clown Dual Wield");//
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_017"); MyTat.Add("Clown and Gun");//
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_016"); MyTat.Add("Clown");//
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_014"); MyTat.Add("Trust No One");//Car Bomb Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_008"); MyTat.Add("Los Santos Customs");//Mod a Car Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_005"); MyTat.Add("Angel");//Win Every Game Mode Award
                    //Unknowen
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_046"); MyTat.Add("Zip?");//Zip???
                    DataStore.sTatBase.Add("mpchristmas2018_overlays"); DataStore.sTatName.Add("MP_Christmas2018_Tat_000_M"); MyTat.Add("Unknowen");//
                }//BACK
                else if (iZone == 2)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_023_M"); MyTat.Add("Techno Glitch");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_022_M"); MyTat.Add("Paradise Sirens");

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_035_M"); MyTat.Add("LS Panic");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_033_M"); MyTat.Add("LS City");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_026_M"); MyTat.Add("Dignity");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_025_M"); MyTat.Add("Davis");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_022_M"); MyTat.Add("Blood Money");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_003_M"); MyTat.Add("Royal Flush");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_000_M"); MyTat.Add("In the Pocket");

                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_026_M"); MyTat.Add("Spartan Skull");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_020_M"); MyTat.Add("Medusa's Gaze");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_019_M"); MyTat.Add("Strike Force");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_003_M"); MyTat.Add("Native Warrior");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_000_M"); MyTat.Add("Thor - Goblin");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_021_M"); MyTat.Add("Dead Tales");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_019_M"); MyTat.Add("Lost At Sea");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_007_M"); MyTat.Add("No Honor");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_000_M"); MyTat.Add("Bless The Dead");

                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_000_M"); MyTat.Add("Turbulence");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_028_M"); MyTat.Add("Micro SMG Chain");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_020_M"); MyTat.Add("Crowned Weapons");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_017_M"); MyTat.Add("Dog Tags");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_012_M"); MyTat.Add("Dollar Daggers");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_060_M"); MyTat.Add("We Are The Mods!");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_059_M"); MyTat.Add("Faggio");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_058_M"); MyTat.Add("Reaper Vulture");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_050_M"); MyTat.Add("Unforgiven");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_041_M"); MyTat.Add("No Regrets");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_034_M"); MyTat.Add("Brotherhood of Bikes");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_032_M"); MyTat.Add("Western Eagle");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_029_M"); MyTat.Add("Bone Wrench");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_026_M"); MyTat.Add("American Dream");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_023_M"); MyTat.Add("Western MC");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_019_M"); MyTat.Add("Gruesome Talons");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_018_M"); MyTat.Add("Skeletal Chopper");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_013_M"); MyTat.Add("Demon Crossbones");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_005_M"); MyTat.Add("Made In America");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_001_M"); MyTat.Add("Both Barrels");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_000_M"); MyTat.Add("Demon Rider");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_044_M"); MyTat.Add("Ram Skull");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_033_M"); MyTat.Add("Sugar Skull Trucker");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_027_M"); MyTat.Add("Punk Road Hog");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_019_M"); MyTat.Add("Engine Heart");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_018_M"); MyTat.Add("Vintage Bully");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_011_M"); MyTat.Add("Wheels of Death");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_019_M"); MyTat.Add("Death Behind");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_012_M"); MyTat.Add("Royal Kiss");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_026_M"); MyTat.Add("Royal Takeover");
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_013_M"); MyTat.Add("Love Gamble");
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_002_M"); MyTat.Add("Holy Mary");
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_001_M"); MyTat.Add("King Fight");

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_027_M"); MyTat.Add("Cobra Dawn");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_025_M"); MyTat.Add("Reaper Sway");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_012_M"); MyTat.Add("Geometric Galaxy");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_002_M"); MyTat.Add("The Howler");

                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_015_M"); MyTat.Add("Smoking Sisters");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_014_M"); MyTat.Add("Ancient Queen");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_008_M"); MyTat.Add("Flying Eye");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_007_M"); MyTat.Add("Eye of the Griffin");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_019"); MyTat.Add("Royal Dagger Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_018"); MyTat.Add("Royal Dagger Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_017"); MyTat.Add("Loose Lips Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_016"); MyTat.Add("Loose Lips Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_009"); MyTat.Add("Time To Die");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_047"); MyTat.Add("Cassette");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_033"); MyTat.Add("Stag");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_013"); MyTat.Add("Boombox");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_002"); MyTat.Add("Chemistry");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_Chest_001"); MyTat.Add("$$$");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_Chest_000"); MyTat.Add("Rich");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Chest_001"); MyTat.Add("Tribal Shark");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Chest_000"); MyTat.Add("Tribal Hammerhead");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_044"); MyTat.Add("Stone Cross");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_034"); MyTat.Add("Flaming Shamrock");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_025"); MyTat.Add("LS Bold");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_024"); MyTat.Add("Flaming Cross");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_010"); MyTat.Add("LS Flames");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_013"); MyTat.Add("Seven Deadly Sins");//Kill 1000 Players Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_012"); MyTat.Add("Embellished Scroll");//Kill 500 Players Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_011"); MyTat.Add("Blank Scroll");////Kill 100 Players Award?
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_003"); MyTat.Add("Blackjack");

                    //
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Male_Crew_Tat_000"); MyTat.Add("Crew Emblem");
                }//CHEST
                else if (iZone == 3)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_030_M"); MyTat.Add("Radio Tape");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_004_M"); MyTat.Add("Skeleton Breeze");

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_037_M"); MyTat.Add("LadyBug");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_029_M"); MyTat.Add("Fatal Incursion");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_031_M"); MyTat.Add("Gambling Royalty");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_024_M"); MyTat.Add("Cash Mouth");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_016_M"); MyTat.Add("Rose and Aces");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("mp_vinewood_tat_012_M"); MyTat.Add("Skull of Suits");

                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_008_M"); MyTat.Add("Spartan Warrior");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_015_M"); MyTat.Add("Jolly Roger");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_010_M"); MyTat.Add("See You In Hell");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_002_M"); MyTat.Add("Dead Lies");

                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_006_M"); MyTat.Add("Bombs Away");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_029_M"); MyTat.Add("Win Some Lose Some");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_010_M"); MyTat.Add("Cash Money");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_052_M"); MyTat.Add("Biker Mount");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_039_M"); MyTat.Add("Gas Guzzler");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_031_M"); MyTat.Add("Gear Head");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_010_M"); MyTat.Add("Skull Of Taurus");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_003_M"); MyTat.Add("Web Rider");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_014_M"); MyTat.Add("Bat Cat of Spades");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_012_M"); MyTat.Add("Punk Biker");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_016_M"); MyTat.Add("Two Face");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_011_M"); MyTat.Add("Lady Liberty");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_004_M"); MyTat.Add("Gun Mic");

                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_003_M"); MyTat.Add("Abstract Skull");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_028"); MyTat.Add("Executioner");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_013"); MyTat.Add("Lizard");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_035"); MyTat.Add("Sewn Heart");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_029"); MyTat.Add("Sad");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_006"); MyTat.Add("Feather Birds");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_Stomach_000"); MyTat.Add("Refined Hustler");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Stom_001"); MyTat.Add("Wheel");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Stom_000"); MyTat.Add("Swordfish");


                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_036"); MyTat.Add("Way of the Gun");//500 Pistol kills Award
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_029"); MyTat.Add("Trinity Knot");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_012"); MyTat.Add("Los Santos Bills");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_004"); MyTat.Add("Faith");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_004"); MyTat.Add("Hustler");//Make 50000 from betting Award
                }//STOMACH
                else if (iZone == 4)
                {
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_022_M"); MyTat.Add("Thong's Sword");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_021_M"); MyTat.Add("Wanted");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_020_M"); MyTat.Add("UFO");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_019_M"); MyTat.Add("Teddy Bear");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_018_M"); MyTat.Add("Stitches");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_017_M"); MyTat.Add("Space Monkey");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_016_M"); MyTat.Add("Sleepy");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_015_M"); MyTat.Add("On/Off");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_014_M"); MyTat.Add("LS Wings");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_013_M"); MyTat.Add("LS Star");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_012_M"); MyTat.Add("Razor Pop");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_011_M"); MyTat.Add("Lipstick Kiss");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_010_M"); MyTat.Add("Green Leaf");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_009_M"); MyTat.Add("Knifed");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_008_M"); MyTat.Add("Ice Cream");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_007_M"); MyTat.Add("Two Horns");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_006_M"); MyTat.Add("Crowned");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_005_M"); MyTat.Add("Spades");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_004_M"); MyTat.Add("Bandage");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_003_M"); MyTat.Add("Assault Rifle");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_002_M"); MyTat.Add("Animal");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_001_M"); MyTat.Add("Ace of Spades");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_000_M"); MyTat.Add("Five Stars");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_012_M"); MyTat.Add("Thief");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_011_M"); MyTat.Add("Sinner");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_003_M"); MyTat.Add("Lock and Load");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_051_M"); MyTat.Add("Western Stylized");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_038_M"); MyTat.Add("FTW");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_009_M"); MyTat.Add("Morbid Arachnid");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_042_M"); MyTat.Add("Flaming Quad");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_017_M"); MyTat.Add("Bat Wheel");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_Tat_006_M"); MyTat.Add("Toxic Spider");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_Tat_004_M"); MyTat.Add("Scorpion");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_Tat_000_M"); MyTat.Add("Stunt Skull");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_029"); MyTat.Add("Beautiful Death");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_025"); MyTat.Add("Snake Head Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_024"); MyTat.Add("Snake Head Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_007"); MyTat.Add("Los Muertos");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_021"); MyTat.Add("Geo Fox");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_005"); MyTat.Add("Beautiful Eye");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_Neck_003"); MyTat.Add("$100");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_Neck_002"); MyTat.Add("Script Dollar Sign");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_Neck_001"); MyTat.Add("Bold Dollar Sign");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_Neck_000"); MyTat.Add("Cash is King");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Head_002"); MyTat.Add("Shark");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Neck_001"); MyTat.Add("Surfs Up");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Neck_000"); MyTat.Add("Little Fish");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Head_001"); MyTat.Add("Surf LS");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Head_000"); MyTat.Add("Pirate Skull");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_000"); MyTat.Add("Skull");
                    //Not On the TatlIst     ...                            
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_044_M"); MyTat.Add("Clubs");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_043_M"); MyTat.Add("Diamonds");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_042_M"); MyTat.Add("Hearts");
                }//HEAD
                else if (iZone == 5)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_009_M"); MyTat.Add("Scratch Panther");

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_041_M"); MyTat.Add("Mighty Thog");
                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_040_M"); MyTat.Add("Tiger Heart");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_026_M"); MyTat.Add("Banknote Rose");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_019_M"); MyTat.Add("Can't Win Them All");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_014_M"); MyTat.Add("Vice");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_005_M"); MyTat.Add("Get Lucky");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_002_M"); MyTat.Add("Suits");

                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_029_M"); MyTat.Add("Cerberus");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_025_M"); MyTat.Add("Winged Serpent");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_013_M"); MyTat.Add("Katana");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_007_M"); MyTat.Add("Spartan Combat");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_004_M"); MyTat.Add("Tiger and Mask");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_001_M"); MyTat.Add("Viking Warrior");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_014_M"); MyTat.Add("Mermaid's Curse");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_008_M"); MyTat.Add("Horrors Of The Deep");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_004_M"); MyTat.Add("Honor");

                    DataStore.sTatBase.Add("mpairraces_overlays"); DataStore.sTatName.Add("MP_Airraces_Tattoo_003_M"); MyTat.Add("Toxic Trails");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_027_M"); MyTat.Add("Serpent Revolver");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_025_M"); MyTat.Add("Praying Skull");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_016_M"); MyTat.Add("Blood Money");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_015_M"); MyTat.Add("Spiked Skull");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_008_M"); MyTat.Add("Bandolier");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_004_M"); MyTat.Add("Sidearm");

                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_008_M"); MyTat.Add("Scarlett");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_004_M"); MyTat.Add("Piston Sleeve");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_055_M"); MyTat.Add("Poison Scorpion");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_053_M"); MyTat.Add("Muffler Helmet");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_045_M"); MyTat.Add("Ride Hard Die Fast");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_035_M"); MyTat.Add("Chain Fist");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_025_M"); MyTat.Add("Good Luck");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_024_M"); MyTat.Add("Live to Ride");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_020_M"); MyTat.Add("Cranial Rose");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_016_M"); MyTat.Add("Macabre Tree");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_012_M"); MyTat.Add("Urban Stunter");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_043_M"); MyTat.Add("Engine Arm");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_039_M"); MyTat.Add("Kaboom");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_035_M"); MyTat.Add("Stuntman's End");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_023_M"); MyTat.Add("Tanked");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_022_M"); MyTat.Add("Piston Head");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_008_M"); MyTat.Add("Moonlight Ride");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_002_M"); MyTat.Add("Big Cat");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_001_M"); MyTat.Add("8 Eyed Skull");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_022_M"); MyTat.Add("My Crazy Life");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_018_M"); MyTat.Add("Skeleton Party");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_006_M"); MyTat.Add("Love Hustle");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_033_M"); MyTat.Add("City Sorrow");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_027_M"); MyTat.Add("Los Santos Life");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_005_M"); MyTat.Add("No Evil");//

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_028_M"); MyTat.Add("Python Skull");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_018_M"); MyTat.Add("Divine Goddess");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_016_M"); MyTat.Add("Egyptian Mural");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_005_M"); MyTat.Add("Fatal Dagger");


                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_021_M"); MyTat.Add("Gabriel");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_020_M"); MyTat.Add("Archangel and Mary");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_009_M"); MyTat.Add("Floral Symmetry");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_021"); MyTat.Add("Time's Up Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_020"); MyTat.Add("Time's Up Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_012"); MyTat.Add("8 Ball Skull");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_010"); MyTat.Add("Electric Snake");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_000"); MyTat.Add("Skull Rider");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_048"); MyTat.Add("Peace");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_043"); MyTat.Add("Triangle White");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_039"); MyTat.Add("Sleeve");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_037"); MyTat.Add("Sunrise");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_034"); MyTat.Add("Stop");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_028"); MyTat.Add("Thorny Rose");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_027"); MyTat.Add("Padlock");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_026"); MyTat.Add("Pizza");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_016"); MyTat.Add("Lightning Bolt");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_015"); MyTat.Add("Mustache");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_007"); MyTat.Add("Bricks");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_003"); MyTat.Add("Diamond Sparkle");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_LeftArm_001"); MyTat.Add("All-Seeing Eye");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_LeftArm_000"); MyTat.Add("$100 Bill");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_LArm_000"); MyTat.Add("Tiki Tower");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_LArm_001"); MyTat.Add("Mermaid L.S.");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_041"); MyTat.Add("Dope Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_031"); MyTat.Add("Lady M");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_015"); MyTat.Add("Zodiac Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_006"); MyTat.Add("Oriental Mural");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_005"); MyTat.Add("Serpents");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_015"); MyTat.Add("Racing Brunette");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_007"); MyTat.Add("Racing Blonde");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_001"); MyTat.Add("Burning Heart");//50 Death Match Award

                    //not on list
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_031_M"); MyTat.Add("Geometric Design");
                }//LEFT ARM
                else if (iZone == 6)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_032_M"); MyTat.Add("K.U.L.T.99.1 FM");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_031_M"); MyTat.Add("Octopus Shades");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_026_M"); MyTat.Add("Shark Water");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_012_M"); MyTat.Add("Still Slipping");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_011_M"); MyTat.Add("Soulwax");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_008_M"); MyTat.Add("Smiley Glitch");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_007_M"); MyTat.Add("Skeleton DJ");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_006_M"); MyTat.Add("Music Locker");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_005_M"); MyTat.Add("LSUR");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_003_M"); MyTat.Add("Lighthouse");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_002_M"); MyTat.Add("Jellyfish Shades");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_001_M"); MyTat.Add("Tropical Dude");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_000_M"); MyTat.Add("Headphone Splat");

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_034_M"); MyTat.Add("LS Monogram");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_028_M"); MyTat.Add("Skull and Aces");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_025_M"); MyTat.Add("Queen of Roses");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_018_M"); MyTat.Add("The Gambler's Life");
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_004_M"); MyTat.Add("Lady Luck");

                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_028_M"); MyTat.Add("Spartan Mural");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_023_M"); MyTat.Add("Samurai Tallship");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_018_M"); MyTat.Add("Muscle Tear");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_017_M"); MyTat.Add("Feather Sleeve");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_014_M"); MyTat.Add("Celtic Band");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_012_M"); MyTat.Add("Tiger Headdress");
                    DataStore.sTatBase.Add("mpchristmas2017_overlays"); DataStore.sTatName.Add("MP_Christmas2017_Tattoo_006_M"); MyTat.Add("Medusa");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_023_M"); MyTat.Add("Stylized Kraken");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_005_M"); MyTat.Add("Mutiny");
                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_001_M"); MyTat.Add("Crackshot");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_024_M"); MyTat.Add("Combat Reaper");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_021_M"); MyTat.Add("Have a Nice Day");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_002_M"); MyTat.Add("Grenade");

                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_007_M"); MyTat.Add("Drive Forever");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_006_M"); MyTat.Add("Engulfed Block");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_005_M"); MyTat.Add("Dialed In");
                    DataStore.sTatBase.Add("mpimportexport_overlays"); DataStore.sTatName.Add("MP_MP_ImportExport_Tat_003_M"); MyTat.Add("Mechanical Sleeve");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_054_M"); MyTat.Add("Mum");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_049_M"); MyTat.Add("These Colors Don't Run");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_047_M"); MyTat.Add("Snake Bike");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_046_M"); MyTat.Add("Skull Chain");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_042_M"); MyTat.Add("Grim Rider");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_033_M"); MyTat.Add("Eagle Emblem");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_014_M"); MyTat.Add("Lady Mortality");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_007_M"); MyTat.Add("Swooping Eagle");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_049_M"); MyTat.Add("Seductive Mechanic");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_038_M"); MyTat.Add("One Down Five Up");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_036_M"); MyTat.Add("Biker Stallion");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_016_M"); MyTat.Add("Coffin Racer");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_010_M"); MyTat.Add("Grave Vulture");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_009_M"); MyTat.Add("Arachnid of Death");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_003_M"); MyTat.Add("Poison Wrench");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_035_M"); MyTat.Add("Black Tears");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_028_M"); MyTat.Add("Loving Los Muertos");
                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_003_M"); MyTat.Add("Lady Vamp");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_015_M"); MyTat.Add("Seductress");

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_026_M"); MyTat.Add("Floral Print");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_017_M"); MyTat.Add("Heavenly Deity");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_010_M"); MyTat.Add("Intrometric");

                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_019_M"); MyTat.Add("Geisha Bloom");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_013_M"); MyTat.Add("Mermaid Harpist");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_004_M"); MyTat.Add("Floral Raven");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_027"); MyTat.Add("Fuck Luck Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_026"); MyTat.Add("Fuck Luck Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_023"); MyTat.Add("You're Next Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_022"); MyTat.Add("You're Next Outline");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_008"); MyTat.Add("Death Before Dishonor");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_004"); MyTat.Add("Snake Shaded");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_003"); MyTat.Add("Snake Outline");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_045"); MyTat.Add("Mesh Band");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_044"); MyTat.Add("Triangle Black");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_036"); MyTat.Add("Shapes");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_023"); MyTat.Add("Smiley");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_022"); MyTat.Add("Pencil");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_020"); MyTat.Add("Geo Pattern");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_018"); MyTat.Add("Origami");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_017"); MyTat.Add("Eye Triangle");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_014"); MyTat.Add("Spray Can");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_010"); MyTat.Add("Horseshoe");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_008"); MyTat.Add("Cube");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_004"); MyTat.Add("Bone");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_001"); MyTat.Add("Single Arrow");

                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_RightArm_001"); MyTat.Add("Green");
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Buis_M_RightArm_000"); MyTat.Add("Dollar Skull");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_RArm_001"); MyTat.Add("Vespucci Beauty");
                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_RArm_000"); MyTat.Add("Tribal Sun");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_047"); MyTat.Add("Lion");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_038"); MyTat.Add("Dagger");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_028"); MyTat.Add("Mermaid");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_027"); MyTat.Add("Virgin Mary");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_018"); MyTat.Add("Serpent Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_014"); MyTat.Add("Flower Mural");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_003"); MyTat.Add("Dragons and Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_001"); MyTat.Add("Dragons");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_000"); MyTat.Add("Brotherhood");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_010"); MyTat.Add("Ride or Die");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_002"); MyTat.Add("Grim Reaper Smoking Gun");
                    //Not In List
                    DataStore.sTatBase.Add("mpbusiness_overlays"); DataStore.sTatName.Add("MP_Male_Crew_Tat_001"); MyTat.Add("Crew Tattoo");
                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_030_M"); MyTat.Add("Geometric Design");
                }//RIGHT ARM
                else if (iZone == 7)
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_029_M"); MyTat.Add("Soundwaves");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_028_M"); MyTat.Add("Skull Waters");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_025_M"); MyTat.Add("Glow Princess");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_024_M"); MyTat.Add("Pineapple Skull");
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_010_M"); MyTat.Add("Tropical Serpent");

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_032_M"); MyTat.Add("Love Fist");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_027_M"); MyTat.Add("8-Ball Rose");//
                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_013_M"); MyTat.Add("One-armed Bandit");//

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_023_M"); MyTat.Add("Rose Revolver");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_011_M"); MyTat.Add("Death Skull");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_007_M"); MyTat.Add("Stylized Tiger");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_005_M"); MyTat.Add("Patriot Skull");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_057_M"); MyTat.Add("Laughing Skull");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_056_M"); MyTat.Add("Bone Cruiser");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_044_M"); MyTat.Add("Ride Free");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_037_M"); MyTat.Add("Scorched Soul");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_036_M"); MyTat.Add("Engulfed Skull");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_027_M"); MyTat.Add("Bad Luck");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_015_M"); MyTat.Add("Ride or Die");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_002_M"); MyTat.Add("Rose Tribute");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_031_M"); MyTat.Add("Stunt Jesus");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_028_M"); MyTat.Add("Quad Goblin");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_021_M"); MyTat.Add("Golden Cobra");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_013_M"); MyTat.Add("Dirt Track Hero");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_007_M"); MyTat.Add("Dagger Devil");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_029_M"); MyTat.Add("Death Us Do Part");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_020_M"); MyTat.Add("Presidents");//
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_007_M"); MyTat.Add("LS Serpent");//

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_Luxe_Tat_011_M"); MyTat.Add("Cross of Roses");
                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_000_M"); MyTat.Add("Serpent of Death");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_002"); MyTat.Add("Spider Color");
                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_001"); MyTat.Add("Spider Outline");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_040"); MyTat.Add("Black Anchor");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_019"); MyTat.Add("Charm");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_009"); MyTat.Add("Squares");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Lleg_000"); MyTat.Add("Tribal Star");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_032"); MyTat.Add("Faith");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_037"); MyTat.Add("Grim Reaper");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_035"); MyTat.Add("Dragon");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_033"); MyTat.Add("Chinese Dragon");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_026"); MyTat.Add("Smoking Dagger");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_023"); MyTat.Add("Hottie");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_021"); MyTat.Add("Serpent Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_008"); MyTat.Add("Dragon Mural");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_002"); MyTat.Add("Melting Skull");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_009"); MyTat.Add("Dragon and Dagger");
                }//LEFT LEG
                else
                {
                    DataStore.sTatBase.Add("mpheist4_overlays"); DataStore.sTatName.Add("MP_Heist4_Tat_027_M"); MyTat.Add("Skullphones");

                    DataStore.sTatBase.Add("mpheist3_overlays"); DataStore.sTatName.Add("mpHeist3_Tat_031_M"); MyTat.Add("Kifflom");

                    DataStore.sTatBase.Add("mpvinewood_overlays"); DataStore.sTatName.Add("MP_Vinewood_Tat_020_M"); MyTat.Add("Cash is King");

                    DataStore.sTatBase.Add("mpsmuggler_overlays"); DataStore.sTatName.Add("MP_Smuggler_Tattoo_020_M"); MyTat.Add("Homeward Bound");

                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_030_M"); MyTat.Add("Pistol Ace");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_026_M"); MyTat.Add("Restless Skull");
                    DataStore.sTatBase.Add("mpgunrunning_overlays"); DataStore.sTatName.Add("MP_Gunrunning_Tattoo_006_M"); MyTat.Add("Combat Skull");

                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_048_M"); MyTat.Add("STFU");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_040_M"); MyTat.Add("American Made");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_028_M"); MyTat.Add("Dusk Rider");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_022_M"); MyTat.Add("Western Insignia");
                    DataStore.sTatBase.Add("mpbiker_overlays"); DataStore.sTatName.Add("MP_MP_Biker_Tat_004_M"); MyTat.Add("Dragon's Fury");

                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_047_M"); MyTat.Add("Brake Knife");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_045_M"); MyTat.Add("Severed Hand");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_032_M"); MyTat.Add("Wheelie Mouse");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_025_M"); MyTat.Add("Speed Freak");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_020_M"); MyTat.Add("Piston Angel");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_015_M"); MyTat.Add("Praying Gloves");
                    DataStore.sTatBase.Add("mpstunt_overlays"); DataStore.sTatName.Add("MP_MP_Stunt_tat_005_M"); MyTat.Add("Demon Spark Plug");

                    DataStore.sTatBase.Add("mplowrider2_overlays"); DataStore.sTatName.Add("MP_LR_Tat_030_M"); MyTat.Add("San Andreas Prayer");

                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_023_M"); MyTat.Add("Dance of Hearts");
                    DataStore.sTatBase.Add("mplowrider_overlays"); DataStore.sTatName.Add("MP_LR_Tat_017_M"); MyTat.Add("Ink Me");

                    DataStore.sTatBase.Add("mpluxe2_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_023_M"); MyTat.Add("Starmetric");

                    DataStore.sTatBase.Add("mpluxe_overlays"); DataStore.sTatName.Add("MP_LUXE_TAT_001_M"); MyTat.Add("Elaborate Los Muertos");

                    DataStore.sTatBase.Add("mpchristmas2_overlays"); DataStore.sTatName.Add("MP_Xmas2_M_Tat_014"); MyTat.Add("Floral Dagger");

                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_042"); MyTat.Add("Sparkplug");
                    DataStore.sTatBase.Add("mphipster_overlays"); DataStore.sTatName.Add("FM_Hip_M_Tat_038"); MyTat.Add("Grub");

                    DataStore.sTatBase.Add("mpbeach_overlays"); DataStore.sTatName.Add("MP_Bea_M_Rleg_000"); MyTat.Add("Tribal Tiki Tower");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_043"); MyTat.Add("Indian Ram");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_042"); MyTat.Add("Flaming Scorpion");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_040"); MyTat.Add("Flaming Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_039"); MyTat.Add("Broken Skull");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_022"); MyTat.Add("Fiery Dragon");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_017"); MyTat.Add("Tribal");
                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_M_007"); MyTat.Add("The Warrior");

                    DataStore.sTatBase.Add("multiplayer_overlays"); DataStore.sTatName.Add("FM_Tat_Award_M_006"); MyTat.Add("Skull and Sword");
                }//RIGHT LEG
            }// FreeMale

            if (bEmpty)
                MyTat.Add("No Tattoos Available");

            return MyTat;
        }
        public static int FindRandom(int iList, int iMin, int iMax)
        {
            LoggerLight.Loggers("FindRandom, iList == " + iList);

            int iBe = 0;
            RandomPlusList XSets = new RandomPlusList();

            if (File.Exists(DataStore.sRandFile))
            {
                XSets = XmlReadWrite.LoadRando(DataStore.sRandFile);

                if (XSets.BigRanList.Count() < iList + 1)
                {
                    for (int i = XSets.BigRanList.Count() - 1; i < iList + 1; i++)
                    {
                        RandomPlus iBlank = new RandomPlus();
                        XSets.BigRanList.Add(iBlank);
                    }
                }

                for (int i = 0; i < XSets.BigRanList[iList].RandNums.Count; i++)
                {
                    if (XSets.BigRanList[iList].RandNums[i] > iMax || XSets.BigRanList[iList].RandNums[i] < iMin)
                        XSets.BigRanList[iList].RandNums.RemoveAt(i);
                }

                if (XSets.BigRanList[iList].RandNums.Count == 0)
                {
                    for (int i = iMin; i < iMax + 1; i++)
                        XSets.BigRanList[iList].RandNums.Add(i);
                }

                int iRanNum = RandInt(0, XSets.BigRanList[iList].RandNums.Count - 1);
                iBe = XSets.BigRanList[iList].RandNums[iRanNum];
                XSets.BigRanList[iList].RandNums.RemoveAt(iRanNum);
            }
            else
            {
                for (int i = 0; i < iList + 1; i++)
                {
                    RandomPlus iBlank = new RandomPlus();
                    XSets.BigRanList.Add(iBlank);
                }

                for (int i = iMin; i < iMax + 1; i++)
                    XSets.BigRanList[iList].RandNums.Add(i);

                int iRanNum = RandInt(0, XSets.BigRanList[iList].RandNums.Count - 1);
                iBe = XSets.BigRanList[iList].RandNums[iRanNum];
                XSets.BigRanList[iList].RandNums.RemoveAt(iRanNum);
            }
            XmlReadWrite.SaveRando(XSets, DataStore.sRandFile);

            return iBe;
        }
        public static List<string> PedCollect()
        {
            List<string> JustNames = new List<string>();

            for (int i = 0; i < DataStore.MyPedCollection.Count(); i++)
                JustNames.Add(DataStore.MyPedCollection[i].Name);

            return JustNames;
        }
        public static bool SelectingPeds(bool bRando)
        {
            WhileButtonDown(21, true);
            bool bDone = false;
            float fDis = 50.00f;
            if (bRando)
                fDis = 150.00f;
            List<Ped> NearPeds = new List<Ped>();
            Ped[] PedXs = World.GetNearbyPeds(Game.Player.Character.Position, fDis);

            if (bRando)
            {
                for (int i = 0; i < PedXs.Count(); i++)
                {
                    if (PedXs[i] != Game.Player.Character && !PedXs[i].IsPersistent && !PedXs[i].IsDead && PedXs[i].Model.Hash != Function.Call<int>(Hash.GET_HASH_KEY, "a_c_pigeon") && PedXs[i].Model.Hash != Function.Call<int>(Hash.GET_HASH_KEY, "a_c_crow") && PedXs[i].Model.Hash != Function.Call<int>(Hash.GET_HASH_KEY, "a_c_chickenhawk") && PedXs[i].Model.Hash != Function.Call<int>(Hash.GET_HASH_KEY, "a_c_cormorant") && PedXs[i].Model.Hash != Function.Call<int>(Hash.GET_HASH_KEY, "a_c_seagull") && PedXs[i].Model.Hash != DataStore.iAmModelHash)
                    {
                        if (DataStore.MySettingsXML.ReCritter)
                            NearPeds.Add(new Ped(PedXs[i].Handle));
                        else if (Function.Call<int>(Hash.GET_PED_TYPE, PedXs[i].Handle) != 28)
                            NearPeds.Add(new Ped(PedXs[i].Handle));
                    }
                }
            }
            else
            {
                for (int i = 0; i < PedXs.Count(); i++)
                {
                    if (PedXs[i] != Game.Player.Character && !PedXs[i].IsPersistent && !PedXs[i].IsDead)
                        NearPeds.Add(new Ped(PedXs[i].Handle));
                }
            }

            int iPerPickP = NearPeds.Count - 1;
            bool bLooking = true;
            unsafe
            {
                if (iPerPickP > -1)
                {
                    if (bRando)
                    {
                        iPerPickP = RandInt(0, NearPeds.Count - 1);
                        Vector3 Campo = Game.Player.Character.Position;
                        if (DataStore.MySettingsXML.ReCurr)
                        {
                            Vector3 Pedpos = NearPeds[iPerPickP].Position;
                            float PedHed = NearPeds[iPerPickP].Heading;
                            NearPeds[iPerPickP].Delete();
                            Game.Player.Character.Position = Pedpos;
                            Game.Player.Character.Heading = PedHed;
                        }
                        else if (DataStore.MySettingsXML.ReSave)
                        {
                            Vector3 Pedpos = NearPeds[iPerPickP].Position;
                            float PedHed = NearPeds[iPerPickP].Heading;
                            NearPeds[iPerPickP].Delete();
                            RsActions.YourSavedPed();
                            Game.Player.Character.Position = Pedpos;
                            Game.Player.Character.Heading = PedHed;
                        }
                        else
                            RsActions.YourPickedPed(NearPeds[iPerPickP]);
                        bDone = true;
                    }
                    else
                    {
                        while (bLooking && NearPeds[iPerPickP].Exists())
                        {
                            Script.Wait(1);
                            RsActions.TopCornerUI(DataStore.MyLang.Langfile[138]);
                            World.DrawMarker(MarkerType.UpsideDownCone, new Vector3(NearPeds[iPerPickP].Position.X, NearPeds[iPerPickP].Position.Y, NearPeds[iPerPickP].Position.Z + 1.50f), Vector3.Zero, Vector3.Zero, new Vector3(0.75f, 0.75f, 0.75f), Color.Red);
                            if (WhileButtonDown(51, true))
                            {
                                iPerPickP -= 1;
                                if (iPerPickP < 0)
                                    iPerPickP = NearPeds.Count - 1;

                                NearPeds[iPerPickP].Position = (Game.Player.Character.Position) + (Game.Player.Character.ForwardVector * 3);
                            }
                            else if (WhileButtonDown(21, true))
                            {
                                RsActions.YourPickedPed(NearPeds[iPerPickP]);
                                bLooking = false;
                            }
                            else if (WhileButtonDown(23, true))
                                bLooking = false;
                        }
                    }
                }
            }
            return bDone;
        }
        public static bool AreTheyTheSame(int iPreset)
        {
            bool bYes = true;
            Ped Peddy = Game.Player.Character;
            NewClothBank ComBAnk = DataStore.MyPedCollection[iPreset];
            if (ComBAnk.ModelX == Peddy.Model.GetHashCode())
            {
                for (int i = 0; i < DataStore.NewBank.ClothA.Count; i++)
                {
                    if (ComBAnk.ClothA[i] != DataStore.NewBank.ClothA[i])
                        bYes = false;
                    if (ComBAnk.ClothB[i] != DataStore.NewBank.ClothB[i])
                        bYes = false;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (ComBAnk.ExtraA[i] != DataStore.NewBank.ExtraA[i])
                        bYes = false;
                    if (ComBAnk.ExtraB[i] != DataStore.NewBank.ExtraB[i])
                        bYes = false;
                }

                if (ComBAnk.FreeMode)
                {
                    if (ComBAnk.XshapeFirstID != DataStore.NewBank.XshapeFirstID)
                        bYes = false;
                    if (ComBAnk.XshapeSecondID != DataStore.NewBank.XshapeSecondID)
                        bYes = false;
                    if (ComBAnk.XshapeThirdID != DataStore.NewBank.XshapeThirdID)
                        bYes = false;
                    if (ComBAnk.XskinFirstID != DataStore.NewBank.XskinFirstID)
                        bYes = false;
                    if (ComBAnk.XskinSecondID != DataStore.NewBank.XskinSecondID)
                        bYes = false;
                    if (ComBAnk.XskinThirdID != DataStore.NewBank.XskinThirdID)
                        bYes = false;
                    if (ComBAnk.XshapeMix != DataStore.NewBank.XshapeMix)
                        bYes = false;
                    if (ComBAnk.XskinMix != DataStore.NewBank.XskinMix)
                        bYes = false;
                    if (ComBAnk.XthirdMix != DataStore.NewBank.XthirdMix)
                        bYes = false;
                    if (ComBAnk.XisParent != DataStore.NewBank.XisParent)
                        bYes = false;
                }
            }
            else
                bYes = false;

            return bYes;
        }
        public static NewClothBank BuildABank()
        {
            NewClothBank MyBanks = new NewClothBank();
            Ped Peddy = Game.Player.Character;


            MyBanks.Name = "Current";
            MyBanks.ModelX = Peddy.Model.GetHashCode();

            if (Peddy.Model == Function.Call<int>(Hash.GET_HASH_KEY, "mp_f_freemode_01") || Peddy.Model == Function.Call<int>(Hash.GET_HASH_KEY, "mp_m_freemode_01"))
                MyBanks.FreeMode = true;
            else
                MyBanks.FreeMode = false;

            for (int i = 0; i < 12; i++)
            {
                MyBanks.ClothA.Add(Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Peddy.Handle, i));
                MyBanks.ClothB.Add(Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Peddy.Handle, i));
            }
            for (int i = 0; i < 5; i++)
            {
                MyBanks.ExtraA.Add(Function.Call<int>(Hash.GET_PED_PROP_INDEX, Peddy.Handle, i));
                MyBanks.ExtraB.Add(Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Peddy.Handle, i));
            }

            MyBanks.PedVoice = "";

            if (MyBanks.FreeMode)
            {
                MyBanks.XshapeFirstID = SHVFreeFaces.GetHeadBlendData(Peddy).shapeFirstID;
                MyBanks.XshapeSecondID = SHVFreeFaces.GetHeadBlendData(Peddy).shapeSecondID;
                MyBanks.XshapeThirdID = SHVFreeFaces.GetHeadBlendData(Peddy).shapeThirdID;
                MyBanks.XskinFirstID = SHVFreeFaces.GetHeadBlendData(Peddy).skinFirstID;
                MyBanks.XskinSecondID = SHVFreeFaces.GetHeadBlendData(Peddy).skinSecondID;
                MyBanks.XskinThirdID = SHVFreeFaces.GetHeadBlendData(Peddy).skinThirdID;
                MyBanks.XshapeMix = SHVFreeFaces.GetHeadBlendData(Peddy).shapeMix;
                MyBanks.XskinMix = SHVFreeFaces.GetHeadBlendData(Peddy).skinMix;
                MyBanks.XthirdMix = SHVFreeFaces.GetHeadBlendData(Peddy).thirdMix;
                MyBanks.XisParent = SHVFreeFaces.GetHeadBlendData(Peddy).isParent;

                MyBanks = AddMissingOverlays(MyBanks);

                MyBanks = AddMissingFaces(MyBanks);

            }
            return MyBanks;
        }
        public static NewClothBank AddMissingOverlays(NewClothBank ThisBank)
        {
            for (int i = 0; i < 13; i++)
            {
                int iValue = Function.Call<int>(Hash._GET_PED_HEAD_OVERLAY_VALUE, Game.Player.Character.Handle, i);
                ThisBank.Overlay.Add(iValue);
                if (iValue == 255)
                {
                    ThisBank.OverlayColour.Add(0);
                    ThisBank.OverlayOpc.Add(0.00f);
                }
                else
                {
                    ThisBank.OverlayColour.Add(RandInt(0, 61));
                    ThisBank.OverlayOpc.Add(RandFloat(0.65f, 0.99f));
                }
            }
            return ThisBank;
        }
        public static NewClothBank AddMissingFaces(NewClothBank ThisBank)
        {
            for (int i = 0; i < 20; i++)
            {
                ThisBank.FaceScale.Add(0.00f);
            }
            return ThisBank;
        }
    }
}