using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public abstract class Tile
    {
        protected int tileX;
        protected int tileY;

        public int TileX
        {
            get { return tileX; }
            set { tileX = value; }
        }
        public int TileY
        {
            get { return tileY; }
            set { tileY = value; }
        }

        public enum TileType
        {
            Hero = 'H',
            SwampCreature = 'C',
            Mage = 'M',
            Gold = 'G',
            Weapon = '|',
            Obstacle = 'X',
            EmptyTile = '.',
        }

        public Tile(int x, int y)
        {
            TileX = x;
            TileY = y;
        }

        public TileType tileType { get; set; }
    }

}
