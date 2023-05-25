using GTA;
using GTA.Native;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RandomStart.Classes
{
    public class HairSets
    {
        public int Comp { get; set; }
        public int Text { get; set; }
        public string HandName { get; set; }
        public string Name { get; set; }
        public int OverLib { get; set; }
        public int Over { get; set; }

        public HairSets()
        {
            Comp = 0;
            Text = 0;
            HandName = "";
            Name = "";
            OverLib = 0;
            Over = 0;
        }
        public HairSets(int comp, int text, string handName, string name, int overLib, int over)
        {
            Comp = comp;
            Text = text;
            HandName = handName;
            Name = name;
            OverLib = overLib;
            Over = over;
        }
    }
    public class Oufiter
    {
        public int Component { get; set; }
        public int Cloth { get; set; }
        public List<int> Textures { get; set; }

        public Oufiter()
        {
            Component = -1;
            Cloth = -1;
            Textures = new List<int> { -1 };
        }
        public Oufiter(int component, int cloth, List<int> textures)
        {
            Component = component;
            Cloth = cloth;
            Textures = textures;
        }
    }
    public class OufiterTop
    {
        public int Component { get; set; }
        public int Torso { get; set; }
        public int Cloth { get; set; }
        public List<int> Textures { get; set; }

        public OufiterTop()
        {
            Component = 0;
            Torso = 15;
            Cloth = -1;
            Textures = new List<int> { -1 };
        }
        public OufiterTop(int component, int torso, int cloth, List<int> textures)
        {
            Component = component;
            Torso = torso;
            Cloth = cloth;
            Textures = textures;
        }
    }
    public class ClothBank
    {
        public string Name { get; set; }

        public int ModelX { get; set; }

        public int CothInt { get; set; }

        public List<ClothX> Cothing { get; set; }

        public bool Male { get; set; }

        public bool FreeMode { get; set; }

        public bool BodySuit { get; set; }

        public FaceBank MyFaces { get; set; }

        public HairSets MyHair { get; set; }

        public int HairColour { get; set; }
        public int HairStreaks { get; set; }
        public int EyeColour { get; set; }

        public TShirt MyTag { get; set; }

        public List<FreeOverLay> MyOverlay { get; set; }

        public List<Tattoo> MyTattoo { get; set; }

        public List<float> FaceScale { get; set; }

        public string PedVoice { get; set; }

        private FaceBank NewFaces(bool male)
        {
            FaceBank thisFace = new FaceBank();

            int shapeFirstID;
            int shapeSecondID;
            int shapeThirdID;
            int skinFirstID;
            int skinSecondID;
            int skinThirdID;
            float shapeMix;
            float skinMix;
            float thirdMix;

            if (male)
            {
                shapeFirstID = RandomX.RandInt(0, 20);
                shapeSecondID = RandomX.RandInt(0, 20);
                shapeThirdID = shapeFirstID;
                skinFirstID = shapeFirstID;
                skinSecondID = shapeSecondID;
                skinThirdID = shapeThirdID;
            }
            else
            {
                shapeFirstID = RandomX.RandInt(21, 41);
                shapeSecondID = RandomX.RandInt(21, 41);
                shapeThirdID = shapeFirstID;
                skinFirstID = shapeFirstID;
                skinSecondID = shapeSecondID;
                skinThirdID = shapeThirdID;
            }

            shapeMix = RandomX.RandFlow(-0.9f, 0.9f);
            skinMix = RandomX.RandFlow(0.9f, 0.99f);
            thirdMix = RandomX.RandFlow(-0.9f, 0.9f);

            thisFace.XshapeFirstID = shapeFirstID;
            thisFace.XshapeSecondID = shapeSecondID;
            thisFace.XshapeThirdID = shapeThirdID;
            thisFace.XskinFirstID = skinFirstID;
            thisFace.XskinSecondID = skinSecondID;
            thisFace.XskinThirdID = skinThirdID;
            thisFace.XshapeMix = shapeMix;
            thisFace.XskinMix = skinMix;
            thisFace.XthirdMix = thirdMix;

            return thisFace;
        }
        private List<FreeOverLay> BuildNewOverlay(bool male)
        {
            List<FreeOverLay> MyOvers = new List<FreeOverLay>();

            for (int i = 0; i < 12; i++)
            {
                int iColour = 0;
                int iChange = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HEAD_OVERLAY_VALUES, i));
                float fVar = RandomX.RandFlow(0.45f, 0.99f);

                if (i == 0)
                {
                    iChange = RandomX.RandInt(0, iChange);
                }//Blemishes
                else if (i == 1)
                {
                    if (male)
                        iChange = RandomX.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 1;
                }//Facial Hair
                else if (i == 2)
                {
                    iChange = RandomX.RandInt(0, iChange);
                    iColour = 1;
                }//Eyebrows
                else if (i == 3)
                {
                    iChange = 255;
                }//Ageing
                else if (i == 4)
                {
                    int iFace = RandomX.RandInt(0, 50);
                    if (iFace < 30)
                    {
                        iChange = RandomX.RandInt(0, 15);
                    }
                    else if (iFace < 45)
                    {
                        iChange = RandomX.RandInt(0, iChange);
                        fVar = RandomX.RandFlow(0.85f, 0.99f);
                    }
                    else
                        iChange = 255;
                }//Makeup
                else if (i == 5)
                {
                    if (!male)
                    {
                        iChange = RandomX.RandInt(0, iChange);
                        fVar = RandomX.RandFlow(0.15f, 0.39f);
                    }
                    else
                        iChange = 255;
                    iColour = 2;
                }//Blush
                else if (i == 6)
                {
                    iChange = RandomX.RandInt(0, iChange);
                }//Complexion
                else if (i == 7)
                {
                    iChange = 255;
                }//Sun Damage
                else if (i == 8)
                {
                    if (!male)
                        iChange = RandomX.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 2;
                }//Lipstick
                else if (i == 9)
                {
                    iChange = RandomX.RandInt(0, iChange);
                }//Moles/Freckles
                else if (i == 10)
                {
                    if (male)
                        iChange = RandomX.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 1;
                }//Chest Hair
                else if (i == 11)
                {
                    iChange = RandomX.RandInt(0, iChange);
                }//Body Blemishes

                int AddColour = 0;

                if (iColour > 0)
                    AddColour = RandomX.RandInt(0, 64);

                MyOvers.Add(new FreeOverLay(iChange, AddColour, fVar));
            }

            return MyOvers;
        }

        public ClothBank()
        {
            Name = "";
            ModelX = 0;
            CothInt = 0;
            Cothing = new List<ClothX>();
            Male = false;
            FreeMode = false;
            BodySuit = false;
            MyFaces = new FaceBank();
            MyHair = new HairSets();
            HairColour = 0;
            HairStreaks = 0;
            EyeColour = 0;
            MyTag = new TShirt();
            MyOverlay = null;
            MyTattoo = new List<Tattoo>();
            FaceScale = new List<float>();
            PedVoice = "";
        }
        public ClothBank(Ped ThisPed)
        {
            ModelX = ThisPed.Model.Hash;
            FreeMode = false;
            CothInt = 0;
            if (ThisPed.Model == PedHash.Franklin)
                Name = "Franklin";
            else if (ThisPed.Model == PedHash.Michael)
                Name = "Michael";
            else if (ThisPed.Model == PedHash.Trevor)
                Name = "Trevor";
            else if (ThisPed.Model == PedHash.FreemodeFemale01)
            {
                FreeMode = true;
                Name = "FreeFemale";
            }
            else if (ThisPed.Model == PedHash.FreemodeMale01)
            {
                FreeMode = true;
                Name = "FreeMale";
            }
            else
                Name = "" + ModelX;

            Cothing = new List<ClothX> { new ClothX(ThisPed) };
            Male = ThisPed.Gender == Gender.Male;
            BodySuit = false;
            if (FreeMode)
            {
                MyFaces = new FaceBank(ThisPed);
                HairColour = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
                HairStreaks = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
                EyeColour = 0;
                MyTag = new TShirt();
                MyHair = new HairSets();
                MyOverlay = RsReturns.BuildOverlay(ThisPed);
                MyTattoo = new List<Tattoo>();
            }
            else
            {
                MyFaces = null;
                HairColour = 0;
                HairStreaks = 0;
                EyeColour = 0;
                MyTag = null;
                MyHair = null;
                MyOverlay = null;
                MyTattoo = new List<Tattoo>();
            }

            FaceScale = new List<float>();
            PedVoice = "";
        }
        public ClothBank(string name, bool Freemode, int iSelect, int iSubset)
        {
            Name = name;
            ModelX = 0;
            CothInt = 0;
            FreeMode = Freemode;

            Male = false;
            BodySuit = false;
            if (FreeMode)
            {
                if (name == "mp_m_freemode_01")
                    Male = true;

                MyFaces = NewFaces(Male);
                Cothing = new List<ClothX> { RsReturns.PickOutfit(Male, iSelect, iSubset) };

                if (Male)
                    Cothing[0].ClothA[2] = RandomX.RandInt(37, 76);
                else
                    Cothing[0].ClothA[2] = RandomX.RandInt(37, 80);

                MyOverlay = BuildNewOverlay(Male);
                MyTattoo = new List<Tattoo>();
                HairColour = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
                HairStreaks = RandomX.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
                EyeColour = 0;
            }
            else
            {
                HairColour = 0;
                HairStreaks = 0;
                EyeColour = 0;
                MyFaces = new FaceBank();
                Cothing = new List<ClothX> { new ClothX() };
                MyOverlay = new List<FreeOverLay>();
                MyTattoo = new List<Tattoo>();
            }
            MyHair = new HairSets();
            MyTag = new TShirt();
            FaceScale = new List<float>();
            PedVoice = "";
        }
    }
    public class ClothX
    {
        public string Title { get; set; }

        public List<int> ClothA { get; set; }
        public List<int> ClothB { get; set; }

        public List<int> ExtraA { get; set; }
        public List<int> ExtraB { get; set; }

        public ClothX()
        {
            Title = "";
            ClothA = new List<int>();
            ClothB = new List<int>();
            ExtraA = new List<int>();
            ExtraB = new List<int>();
        }
        public ClothX(bool bLAnk)
        {
            Title = "";
            ClothA = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            ExtraA = new List<int>();
            ExtraB = new List<int>();
        }
        public ClothX(Ped ThisPed)
        {
            Title = "Current";
            ClothA = new List<int>();
            ClothB = new List<int>();
            ExtraA = new List<int>();
            ExtraB = new List<int>();

            for (int i = 0; i < 12; i++)
            {
                int iDrawId = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, ThisPed.Handle, i);
                ClothA.Add(iDrawId);
                int iTextId = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, ThisPed.Handle, i);
                ClothB.Add(iTextId);
            }

            for (int i = 0; i < 8; i++)
            {
                int iDrawId = Function.Call<int>(Hash.GET_PED_PROP_INDEX, ThisPed.Handle, i);
                ExtraA.Add(iDrawId);
                int iTextId = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, ThisPed.Handle, i);
                ExtraB.Add(iTextId);
            }
        }
        public ClothX(string title, List<int> clothA, List<int> clothB, List<int> extraA, List<int> extraB)
        {
            Title = title;
            ClothA = clothA;
            ClothB = clothB;
            ExtraA = extraA;
            ExtraB = extraB;
        }
    }
    public class FaceBank
    {
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

        public FaceBank()
        {
            XshapeFirstID = 0;
            XshapeSecondID = 0;
            XshapeThirdID = 0;
            XskinFirstID = 0;
            XskinSecondID = 0;
            XskinThirdID = 0;
            XshapeMix = 0f;
            XskinMix = 0f;
            XthirdMix = 0f;
            XisParent = 0;
        }
        public FaceBank(Ped Peddy)
        {
            XshapeFirstID = SHVFreeFaces.GetHeadBlendData(Peddy).shapeFirstID;
            XshapeSecondID = SHVFreeFaces.GetHeadBlendData(Peddy).shapeSecondID;
            XshapeThirdID = SHVFreeFaces.GetHeadBlendData(Peddy).shapeThirdID;
            XskinFirstID = SHVFreeFaces.GetHeadBlendData(Peddy).skinFirstID;
            XskinSecondID = SHVFreeFaces.GetHeadBlendData(Peddy).skinSecondID;
            XskinThirdID = SHVFreeFaces.GetHeadBlendData(Peddy).skinThirdID;
            XshapeMix = SHVFreeFaces.GetHeadBlendData(Peddy).shapeMix;
            XskinMix = SHVFreeFaces.GetHeadBlendData(Peddy).skinMix;
            XthirdMix = SHVFreeFaces.GetHeadBlendData(Peddy).thirdMix;
            XisParent = SHVFreeFaces.GetHeadBlendData(Peddy).isParent;
        }
    }
    public class Tattoo
    {
        public string BaseName { get; set; }
        public string TatName { get; set; }
        public string Name { get; set; }

        public Tattoo()
        {
            BaseName = "";
            TatName = "";
            Name = "";
        }

        public Tattoo(string baseName, string tatName, string name)
        {
            BaseName = baseName;
            TatName = tatName;
            Name = name;
        }
    }
    public class TShirt
    {
        public string BaseName { get; set; }
        public string ShirtName { get; set; }
        public string Name { get; set; }

        public TShirt()
        {
            BaseName = "";
            ShirtName = "";
            Name = "";
        }

        public TShirt(string baseName, string shirtName, string name)
        {
            BaseName = baseName;
            ShirtName = shirtName;
            Name = name;
        }
    }
    public class FreeOverLay
    {
        public int Overlay { get; set; }
        public int OverCol { get; set; }
        public float OverOpc { get; set; }

        public FreeOverLay()
        {
            Overlay = 0;
            OverCol = 0;
            OverOpc = 0f;
        }
        public FreeOverLay(int overlay, int overCol, float overOpc)
        {
            Overlay = overlay;
            OverCol = overCol;
            OverOpc = overOpc;
        }
    }
    public class AnimatedActions
    {
        public string Libary { get; set; }
        public string Action { get; set; }

        public AnimatedActions()
        {
            Libary = "";
            Action = "";
        }
        public AnimatedActions(string libary, string action)
        {
            Libary = libary;
            Action = action;
        }
    }
    public class AnimList
    {
        public AnimatedActions Start { get; set; }
        public List<AnimatedActions> Middle { get; set; }
        public AnimatedActions End { get; set; }

        public AnimList()
        {
            Start = new AnimatedActions();
            Middle = new List<AnimatedActions>();
            End = new AnimatedActions();
        }
        public AnimList(AnimatedActions start, AnimatedActions end, List<AnimatedActions> middle)
        {
            Start = start;
            Middle = middle;
            End = end;
        }
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
    public class RandX
    {
        public List<int> RandNumbers { get; set; }

        public RandX()
        {
            RandNumbers = new List<int>();
        }
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
        public bool Reincarn { get; set; }
        public bool ReCritter { get; set; }
        public bool ReSave { get; set; }
        public bool ReCurr { get; set; }
        public bool BeachPart { get; set; }
        public int Version { get; set; }
        public int LangSupport { get; set; }
        public bool ControlSupport { get; set; }
        public int ControlA { get; set; }
        public int ControlB { get; set; }

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

        public List<WeaponSaver> YourWeaps { get; set; }

        public bool MinMap { get; set; }

        public SettingsXML()
        {
            MenuKey = Keys.L;
            Locate = true;
            Spawn = false;
            Saved = false;
            DisableRecord = false;
            KeepWeapons = true;
            BeltUp = true;
            Reincarn = true;
            ReCritter = true;
            ReSave = false;
            ReCurr = false;
            BeachPart = true;
            Version = 29;
            LangSupport = 0;
            ControlSupport = false;
            ControlA = 0;
            ControlB = 0;

            MinMap = true;

            BeachPed = true;
            Tramps = true;
            Highclass = true;
            Midclass = true;
            Lowclass = true;
            Business = true;
            Bodybuilder = true;
            GangStars = true;
            Epsilon = true;
            Jogger = true;
            Golfer = true;
            Hiker = true;
            Methaddict = true;
            Rural = true;
            Cyclist = true;
            LGBTWXYZ = true;
            PoolPeds = true;
            Workers = true;
            Jetski = true;
            BikeATV = true;
            Services = true;
            Pilot = true;
            Animals = true;
            Yankton = true;
            Cayo = true;
            YourWeaps = new List<WeaponSaver>();
        }
    }
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float R;

        public Vector4(float x, float y, float z, float r)
        {
            X = x; Y = y; Z = z; R = r;
        }
    }
    public class WeaponSaver
    {
        public string PlayWeaps { get; set; }
        public List<string> PlayCompsList { get; set; }
        public int Ammos { get; set; }

        public WeaponSaver()
        {
            PlayWeaps = "";
            PlayCompsList = new List<string>();
            Ammos = 0;
        }
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
}
