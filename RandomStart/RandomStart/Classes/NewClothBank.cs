using System.Collections.Generic;

namespace RandomStart.Classes
{
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
}
