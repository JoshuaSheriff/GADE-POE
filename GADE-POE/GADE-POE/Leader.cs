using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public class Leader : Enemy
    {
        private Tile leaderTarget;
        public Tile LeaderTarget { get { return leaderTarget; } set { leaderTarget = value; } }

        private MeleeWeapon leaderWeapon = new MeleeWeapon("LONGSWORD", 0,0);

        public Leader(int leaderX, int leaderY, int leaderEnemyArray, Tile target) : base(leaderX, leaderY, leaderEnemyArray)
        {
            CharMaxHP = 20;
            CharHP = CharMaxHP;
            charDamage = 2;
            LeaderTarget = target;
            enemyType = TileType.Leader;
            tileType = TileType.Leader;
            characterWeapon = leaderWeapon;
        }

        public override Movement ReturnMove(Movement move = 0)
        {
            int direction;
            int distanceBefore;
            Tile charVision;
            int distanceAfter;
            bool canMoveCloser = false;
            
            for (int i = 0; i < 4; i++)
            {   
                distanceBefore = Math.Abs(LeaderTarget.TileX - TileX) + Math.Abs(LeaderTarget.TileY - TileY);

                //direction = random.Next(1, 5);
                direction = i;

                move = (Movement)direction;

                charVision = CharacterVision[(int)move];

                distanceAfter = Math.Abs(LeaderTarget.TileX - charVision.TileX) + Math.Abs(LeaderTarget.TileY - charVision.TileY);

                if (distanceBefore >= distanceAfter)
                {
                    if (CharacterVision[(int)move].tileType == TileType.EmptyTile) //Validity Check
                    {
                        return move;
                        canMoveCloser = true;
                    }
                    
                }
            }
            if (canMoveCloser == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    direction = random.Next(1, 5);
                    move = (Movement)direction;
                    if (CharacterVision[(int)move].tileType == TileType.EmptyTile) //Validity Check
                    {
                        return move;
                    }
                }
            }
            return Movement.NoMovement;
        }

    }
}
