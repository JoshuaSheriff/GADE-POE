using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public class Gold : Item
    {
        private Random random = new Random();
        private int goldAmount;
        public int GoldAmount
        {
            get { return goldAmount; }
            set { goldAmount = value; }
        }
        public Gold(int x, int y) : base(x, y)
        {
            GoldAmount = random.Next(1, 6);
            tileType = TileType.Gold;
        }
        public Gold(int x, int y, int goldAmount) : base(x, y) //Used in loading/saving
        {
            GoldAmount = goldAmount;
            tileType = TileType.Gold;
        }

        public override string ToString()
        {
            return "Gold";
        }
    }
}
