using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public abstract class Character : Tile
    {
        public Character(int charX, int charY) : base(charX, charY)
        {
        }
        protected int charHP { get; set; }
        protected int charMaxHP { get; set; }
        public int CharHP
        {
            get { return charHP; }
            set { charHP = value; }
        }
        public int CharMaxHP
        {
            get { return charMaxHP; }
            set { charMaxHP = value; }
        }

        public int GoldPurse { get; set; }

        protected int charDamage { get; set; }

        public enum Movement
        {
            NoMovement,
            Up,
            Down,
            Left,
            Right,
        }
        public Tile[] CharacterVision { get; set; } = new Tile[5];

        public virtual void Attack(Character target)
        {
            target.charHP -= charDamage;
        }
        public bool IsDead()
        {
            return charHP <= 0;
        }

        public virtual bool CheckRange(Character target)
        {
            return DistanceTo(target) == 1;
        }
        private int DistanceTo(Character target)
        {
            return Math.Abs(target.TileX - TileX) + Math.Abs(target.TileY - TileY);
        }

        public void Move(Movement move, Tile charTile)
        {
            Map.TileMap[TileY, TileX] = new EmptyTile(TileX, TileY);
            switch (move)
            {
                case Movement.NoMovement:
                    break;
                case Movement.Up:
                    TileY -= 1;
                    break;
                case Movement.Down:
                    TileY += 1;
                    break;
                case Movement.Left:
                    TileX -= 1;
                    break;
                case Movement.Right:
                    TileX += 1;
                    break;
            }
            Map.TileMap[TileY, TileX] = charTile;
        }

        public void PickUp(Item item)
        {
            if (item.tileType == TileType.Gold)
            {
                Gold gold = item as Gold;
                GoldPurse += gold.GoldAmount;
            }
        }


        public abstract Movement ReturnMove(Movement move = 0); // Returns a direction of movement

        public abstract override string ToString();

    }
}
