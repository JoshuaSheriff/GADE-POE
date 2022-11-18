﻿using System;
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

        public Leader(int leaderX, int leaderY, int leaderEnemyArray, Tile target) : base(leaderX, leaderY, leaderEnemyArray)
        {
            CharMaxHP = 20;
            CharHP = CharMaxHP;
            charDamage = 2;
            LeaderTarget = target;
            enemyType = TileType.Leader;
            tileType = TileType.Leader;
        }

        public override Movement ReturnMove(Movement move = 0)
        {
            int direction;
            int directionBefore;
            Tile charVision;
            int directionAfter;
            
            for (int i = 0; i < 3; i++)
            {   
                directionBefore = Math.Abs(LeaderTarget.TileX - TileX) + Math.Abs(LeaderTarget.TileY - TileY);
                
                direction = random.Next(1, 5);

                move = (Movement)direction;

                charVision = CharacterVision[(int)move];

                directionAfter = Math.Abs(LeaderTarget.TileX - charVision.TileX) + Math.Abs(LeaderTarget.TileY - charVision.TileY);

                if (directionBefore > directionAfter)
                {
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
