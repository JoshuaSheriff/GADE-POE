using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public class EmptyTile : Tile
    {
        public EmptyTile(int x, int y) : base(x, y)
        {
            tileType = TileType.EmptyTile;
        }
    }
}
