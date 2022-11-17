using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public class Hero : Character
    {

        public Hero(int heroX, int heroY, int maxHP) : base(heroX, heroY)
        {
            charMaxHP = maxHP;
            charHP = charMaxHP;
            charDamage = 2;
            tileType = TileType.Hero;
        }
        public Hero(int heroX, int heroY, int hp, int maxHP, int gold) : base(heroX, heroY) // For loading from save file
        {
            charHP = hp;
            charMaxHP = maxHP;
            charDamage = 2;
            tileType = TileType.Hero;
            GoldPurse = gold;
        }
        public bool HeroOnGold { get; set; } = false; // to indicate to the MovePlayer method that the Hero is standing on gold

        public override Movement ReturnMove(Movement move) // Checks if the space to move to is valid
        {
            if (CharacterVision[(int)move].tileType == TileType.EmptyTile)
            {
                return move;
            }
            else if (CharacterVision[(int)move].tileType == TileType.Gold) // this is needed to be able to move onto a gold Tile
            {
                HeroOnGold = true;
                return move;
            }
            else return Movement.NoMovement; // returned if the movement is not valid
        }

        public override string ToString()
        {
            return $"Player Stats:\nHP: {charHP}/{charMaxHP}\nDamage: {charDamage}\nGold: {GoldPurse}\n[{TileX},{TileY}]";
        }
    }
}
