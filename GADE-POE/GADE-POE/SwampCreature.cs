using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public class SwampCreature : Enemy
    {
        private MeleeWeapon swampCreatureWeapon = new MeleeWeapon("DAGGER", 0, 0);

        public SwampCreature(int x, int y, int EnemyArray) : base(x, y, EnemyArray) //Default Constructor
        {
            charMaxHP = 10;
            charHP = charMaxHP;
            charDamage = 1;
            enemyType = TileType.SwampCreature;
            tileType = TileType.SwampCreature;
            characterWeapon = swampCreatureWeapon;
        }
        public SwampCreature(int x, int y, int EnemyArray, int hp) : base(x, y, EnemyArray) //Used with loading/saving
        {
            charMaxHP = 10;
            charHP = hp;
            charDamage = 1;
            enemyType = TileType.SwampCreature;
            tileType = TileType.SwampCreature;
        }

        public override Movement ReturnMove(Movement move = 0) //Random Movement
        {
            int direction;
            for (int i = 0; i < 3; i++)
            {
                direction = random.Next(1, 5);
                move = (Movement)direction;
                if (CharacterVision[(int)move].tileType == TileType.EmptyTile) //Validity Check
                {
                    return move;
                }
            }
            return Movement.NoMovement;

        }
    }
}
