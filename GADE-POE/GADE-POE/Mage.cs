using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public class Mage : Enemy
    {

        public Mage(int x, int y, int enemyArrayNum) : base(x, y, enemyArrayNum)
        {
            charMaxHP = 5;
            charHP = charMaxHP;
            charDamage = 5;
            enemyType = TileType.Mage;
            tileType = TileType.Mage;
        }
        public Mage(int x, int y, int enemyArrayNum, int hp) : base(x, y, enemyArrayNum) // For loading from save file
        {
            charMaxHP = 5;
            charHP = hp;      
            charDamage = 5;
            enemyType = TileType.Mage;
            tileType = TileType.Mage;
        }


        public override Movement ReturnMove(Movement move = 0)
        {
            return Movement.NoMovement;
        }
        public override bool CheckRange(Character target)
        {           
            double distance = Math.Pow(target.TileX - TileX, 2) + Math.Pow(target.TileY - TileY, 2);

            distance = Math.Abs(distance); 

            return distance <= 2 && distance > 0;
        }
    }
}
