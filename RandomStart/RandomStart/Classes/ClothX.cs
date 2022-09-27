using System.Collections.Generic;

namespace RandomStart.Classes
{
    public class ClothX
    {
        public string Title { get; set; }

        public List<int> ClothA { get; set; }
        public List<int> ClothB { get; set; }

        public List<int> ExtraA { get; set; }
        public List<int> ExtraB { get; set; }

        public ClothX()
        {
            ClothA = new List<int>();
            ClothB = new List<int>();
            ExtraA = new List<int>();
            ExtraB = new List<int>();
        }
    }
}
