using System.Collections.Generic;

namespace RandomStart.Classes
{
    public class ClothBankist
    {
        public List<NewClothBank> FreeChars { get; set; }

        public ClothBankist()
        {
            FreeChars = new List<NewClothBank>();
        }
    }
}
