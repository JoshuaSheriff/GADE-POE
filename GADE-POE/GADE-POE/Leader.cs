using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    class Leader : Enemy
    {
        private Tile leaderTarget;
        public Tile LeaderTarget { get { return leaderTarget; } set { leaderTarget = value; } }

        public Leader(int leaderX, int leaderY, int leaderEnemyArray) : base(leaderX, leaderY, leaderEnemyArray)
        {
            CharMaxHP = 20;
            CharHP = CharMaxHP;
            charDamage = 2;
        }

        public override Movement ReturnMove(Movement move = Movement.NoMovement) // Haven't done movement yet
        {
            throw new NotImplementedException();
        }
    }
}
