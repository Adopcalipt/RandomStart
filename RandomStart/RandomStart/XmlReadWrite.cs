using RandomStart.Classes;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RandomStart
{
    public class XmlReadWrite : DataStore
    {
        public static LangXML LoadLang(string fileName)
        {
            LoggerLight.Loggers("LoadLang == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(LangXML));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (LangXML)xml.Deserialize(sr);
                }
            }
            catch
            {
                return Languages();
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
        public static XmlSetings LoadNSPM(string fileName)
        {
            LoggerLight.Loggers("LoadNSPM == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(XmlSetings));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (XmlSetings)xml.Deserialize(sr);
                }
            }
            catch
            {
                return new XmlSetings();
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
        public static RandomPlusList LoadRando(string fileName)
        {
            LoggerLight.Loggers("LoadRando == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(RandomPlusList));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (RandomPlusList)xml.Deserialize(sr);
                }
            }
            catch
            {
                return new RandomPlusList();
            }
        }
        public static ClothBankist LoadChars(string fileName)
        {
            LoggerLight.Loggers("LoadChars == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(ClothBankist));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (ClothBankist)xml.Deserialize(sr);
                }
            }
            catch
            {
                return new ClothBankist();
            }
        }
        public static NewClothBank LoadNewOutfit(string fileName)
        {
            LoggerLight.Loggers("LoadNewOutfit == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(NewClothBank));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (NewClothBank)xml.Deserialize(sr);
                }
            }
            catch
            {
                return new NewClothBank();
            }
        }
        public static ClothBank LoadOutfit(string fileName)
        {
            LoggerLight.Loggers("LoadOutfit == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(ClothBank));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (ClothBank)xml.Deserialize(sr);
                }
            }
            catch
            {
                return new ClothBank();
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
        public static void SaveRando(RandomPlusList config, string fileName)
        {
            LoggerLight.Loggers("SaveRando == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(RandomPlusList));
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    xml.Serialize(sw, config);
                }
            }
            catch
            {
                LoggerLight.Loggers("SaveRando failed");
            }
        }
        public static void SaveChars(ClothBankist config, string fileName)
        {
            LoggerLight.Loggers("SaveChars == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(ClothBankist));
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
        public static void SaveNewOutfitMain(NewClothBank config, string fileName)
        {
            LoggerLight.Loggers("SaveNewOutfitMain == " + fileName);
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(NewClothBank));
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    xml.Serialize(sw, config);
                }
            }
            catch
            {
                LoggerLight.Loggers("SaveNewOutfitMain failed");
            }

        }
        public static LangXML Languages()
        {
            LoggerLight.Loggers("XmlReadWrite.Languages");

            LangXML Lingoo = new LangXML();

            Lingoo.Langfile.Add("If you didn't download this file from 'gta5-mods.com' then delete it and download the original from 'gta5-mods.com/scripts/random-start-adopcalipt'");     //0
            Lingoo.Langfile.Add("Save XML Invalid");      //1
            Lingoo.Langfile.Add("We are here today to mourn the loss of ");      //2
            Lingoo.Langfile.Add(". He will be missed by his three friends Trevor, Michael and Franklin.");      //3
            Lingoo.Langfile.Add(". She will be missed by her three friends Trevor, Michael and Franklin.");      //4
            Lingoo.Langfile.Add("You have been sentenced to 150 years hard labor...");      //5
            Lingoo.Langfile.Add("Random Start");      //6
            Lingoo.Langfile.Add("blank");              //7
            Lingoo.Langfile.Add("Set ped options");      //8
            Lingoo.Langfile.Add("Hair Colour");      //9
            Lingoo.Langfile.Add("Hair Streaks");      //10
            Lingoo.Langfile.Add("Eye Colour");      //11
            Lingoo.Langfile.Add("Set overlay options");      //12
            Lingoo.Langfile.Add("Blemishes");      //13
            Lingoo.Langfile.Add("Facial Hair");      //14
            Lingoo.Langfile.Add("Eyebrows");      //15
            Lingoo.Langfile.Add("Ageing");      //16
            Lingoo.Langfile.Add("Makeup");      //17
            Lingoo.Langfile.Add("Blush");      //18
            Lingoo.Langfile.Add("Complexion");      //19
            Lingoo.Langfile.Add("Sun Damage");      //20
            Lingoo.Langfile.Add("Lipstick");      //21
            Lingoo.Langfile.Add("Moles");      //22
            Lingoo.Langfile.Add("Chest Hair");      //23
            Lingoo.Langfile.Add("Body Blemishes");      //24
            Lingoo.Langfile.Add(" Opacity");      //25
            Lingoo.Langfile.Add(" Colour");      //26
            Lingoo.Langfile.Add("Set component options");      //27
            Lingoo.Langfile.Add("Head");      //28
            Lingoo.Langfile.Add("Beard");      //29
            Lingoo.Langfile.Add("Hair");      //30
            Lingoo.Langfile.Add("Torso");      //31
            Lingoo.Langfile.Add("Legs");      //32 
            Lingoo.Langfile.Add("Parachute");      //33
            Lingoo.Langfile.Add("Shoes");      //34
            Lingoo.Langfile.Add("Accessories");      //35
            Lingoo.Langfile.Add("Shirts-Tops-Accessories");      //36
            Lingoo.Langfile.Add("Armor");      //37
            Lingoo.Langfile.Add("Decals");      //38
            Lingoo.Langfile.Add("Shirts-Jackets-Tops");      //39
            Lingoo.Langfile.Add("Texture");      //40
            Lingoo.Langfile.Add("Set prop options");      //41
            Lingoo.Langfile.Add("Hats");      //42
            Lingoo.Langfile.Add("Glasses");      //43
            Lingoo.Langfile.Add("Earrings");      //44
            Lingoo.Langfile.Add("Watches");      //45
            Lingoo.Langfile.Add("Default Ped");      //46
            Lingoo.Langfile.Add("Reset Ped to Default.");      //47
            Lingoo.Langfile.Add("Save Current Ped.");      //48
            Lingoo.Langfile.Add("Make a new ped save file.");      //49
            Lingoo.Langfile.Add("Saved");      //50
            Lingoo.Langfile.Add("Random Location");      //51
            Lingoo.Langfile.Add("Set if you would like to load into a random place time and weather");      //52
            Lingoo.Langfile.Add("Use Default Ped");      //53
            Lingoo.Langfile.Add("Set if you would like to load in as Michael,Franklin or Trevor.");      //54
            Lingoo.Langfile.Add("Disable Action Replay");      //55
            Lingoo.Langfile.Add("When using a controller action replay can start randomly this disables it.");      //56
            Lingoo.Langfile.Add("Use Saved Ped");      //57
            Lingoo.Langfile.Add("Set if you would like to load in as your saved ped.");      //58
            Lingoo.Langfile.Add("Keep Weapons");      //59
            Lingoo.Langfile.Add("Use your default weapon loadout.");      //60
            Lingoo.Langfile.Add("Change Menu Key");      //61
            Lingoo.Langfile.Add("Select menu load key.");      //62
            Lingoo.Langfile.Add("Press the key you would like to bind for the menu.");      //63
            Lingoo.Langfile.Add("Delete Saved Ped");      //64
            Lingoo.Langfile.Add("Deleted");      //65
            Lingoo.Langfile.Add("Select a ped type");      //66
            Lingoo.Langfile.Add("Beach Ped");      //67
            Lingoo.Langfile.Add("Tramps");      //68
            Lingoo.Langfile.Add("High class");      //69
            Lingoo.Langfile.Add("Mid class");      //70
            Lingoo.Langfile.Add("Low class");      //71
            Lingoo.Langfile.Add("Business");      //72
            Lingoo.Langfile.Add("Body builder");      //73
            Lingoo.Langfile.Add("GangStars");      //74
            Lingoo.Langfile.Add("Epsilon ");      //75
            Lingoo.Langfile.Add("Jogger");      //76
            Lingoo.Langfile.Add("Golfer");      //77
            Lingoo.Langfile.Add("Hiker");      //78
            Lingoo.Langfile.Add("Meth addict");      //79
            Lingoo.Langfile.Add("Rural");      //80
            Lingoo.Langfile.Add("Cyclist");      //81
            Lingoo.Langfile.Add("LGBTWXYZ");      //82
            Lingoo.Langfile.Add("Pool Peds");      //83
            Lingoo.Langfile.Add("Workers");      //84
            Lingoo.Langfile.Add("Jet ski");      //85
            Lingoo.Langfile.Add("Bike/ATV");      //86
            Lingoo.Langfile.Add("Services");      //87
            Lingoo.Langfile.Add("Use 'save ped' option to keep these settings");      //88
            Lingoo.Langfile.Add("Can't open while processing action try again in a few seconds.");      //89
            Lingoo.Langfile.Add("Key has been selected.");      //90
            Lingoo.Langfile.Add("blank");      //91
            Lingoo.Langfile.Add("Hold ~INPUT_VEH_EXIT~ to take control");      //92
            Lingoo.Langfile.Add("Pilot");      //93
            Lingoo.Langfile.Add("Yankton");      //94
            Lingoo.Langfile.Add("Cayo Perico");      //95
            Lingoo.Langfile.Add("Seatbelt On");      //96
            Lingoo.Langfile.Add("Cayo Perico Beach Party");      //97
            Lingoo.Langfile.Add("Left/Right choice your save. Select to edit.");      //98
            Lingoo.Langfile.Add("Back");      //99
            Lingoo.Langfile.Add("Torso");      //100
            Lingoo.Langfile.Add("Neck");      //101
            Lingoo.Langfile.Add("Right Arm");      //102
            Lingoo.Langfile.Add("Left Arm");      //103
            Lingoo.Langfile.Add("Right Leg");      //104
            Lingoo.Langfile.Add("Left Leg");      //105
            Lingoo.Langfile.Add("Head");      //106
            Lingoo.Langfile.Add("Hair");      //107
            Lingoo.Langfile.Add("Remove All Tattoos");      //108
            Lingoo.Langfile.Add("Tattoos");      //109
            Lingoo.Langfile.Add("Chest");      //110
            Lingoo.Langfile.Add("Stomach");      //111
            Lingoo.Langfile.Add("New ");      //112
            Lingoo.Langfile.Add("blank");      //113
            Lingoo.Langfile.Add("Nose Width");      //114
            Lingoo.Langfile.Add("Nose Peak Height");      //115
            Lingoo.Langfile.Add("Nose Peak Length");      //116
            Lingoo.Langfile.Add("Nose Bone High");      //117
            Lingoo.Langfile.Add("Nose Peak Lowering");      //118
            Lingoo.Langfile.Add("Nose Bone Twist");      //119
            Lingoo.Langfile.Add("Eyebrow High");      //120
            Lingoo.Langfile.Add("Eyebrow Forward");      //121
            Lingoo.Langfile.Add("Cheekbone High");      //122
            Lingoo.Langfile.Add("Cheekbone Width");      //123
            Lingoo.Langfile.Add("Cheek Width");      //124
            Lingoo.Langfile.Add("Eyes Opening");      //125
            Lingoo.Langfile.Add("Lips Thickness");      //126
            Lingoo.Langfile.Add("Jaw Bone Width");      //127
            Lingoo.Langfile.Add("Jaw Bone Back Length");      //128
            Lingoo.Langfile.Add("Chimp Bone Lowering");      //129
            Lingoo.Langfile.Add("Chimp Bone Length");      //130
            Lingoo.Langfile.Add("Chimp Bone Width");      //131
            Lingoo.Langfile.Add("Chimp Hole");      //132
            Lingoo.Langfile.Add("Neck Thickness");      //133
            Lingoo.Langfile.Add("Face Features");      //134
            Lingoo.Langfile.Add("Reset Owned Weapon List");      //135
            Lingoo.Langfile.Add("Assimilate Ped");      //136
            Lingoo.Langfile.Add("Select a nearby ped");      //137
            Lingoo.Langfile.Add("Press ~INPUT_CONTEXT~ to select ped, ~INPUT_SPRINT~ to assimilate, ~INPUT_ENTER~ to exit.");      //138
            Lingoo.Langfile.Add("Animals");      //139
            Lingoo.Langfile.Add("Reincarnation");      //140
            Lingoo.Langfile.Add("An alternative to dying");      //141
            Lingoo.Langfile.Add("Include Critters");      //142
            Lingoo.Langfile.Add("Return as a saved ped");      //143
            Lingoo.Langfile.Add("Return as current ped");      //144
            Lingoo.Langfile.Add("blank");      //145
            Lingoo.Langfile.Add("blank");      //146
            Lingoo.Langfile.Add("blank");      //147
            Lingoo.Langfile.Add("blank");      //148
            Lingoo.Langfile.Add("blank");      //149
            Lingoo.Langfile.Add("blank");      //150

            return Lingoo;
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
                RandStarts = BuildRandStartsList()
            };

            return MySet;
        }
        public static List<int> BuildRandStartsList()
        {
            LoggerLight.Loggers("XmlReadWrite.BuildRandStartsList");

            List<int> iSel = new List<int>();

            for (int i = 1; i < 26; i++)
                iSel.Add(i);

            return iSel;
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
                WeaponsXML WeapsXML = XmlReadWrite.LoadWeaps(DataStore.sWeapsFile);

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
