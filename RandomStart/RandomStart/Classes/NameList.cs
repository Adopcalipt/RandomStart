using System.Collections.Generic;

namespace RandomStart.Classes
{
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
}
