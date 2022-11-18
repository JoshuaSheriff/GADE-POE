using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public abstract class Enemy : Character
    {
        protected Random random = new Random();
        public TileType enemyType { get; set; } //Only used in ToString

        public int enemyArray { get; set; }
        public Enemy(int x, int y, int EnemyArray) : base(x, y)
        {
            enemyArray = EnemyArray;
        }

        public override string ToString()
        {
            if (characterWeapon == null) //They don't wield a weapon
            {
                return $"Barehanded: {enemyType} ({charHP}/{charMaxHP}HP) at [{TileX},{TileY}] ({charDamage}DMG)";
            }
            else //If they have a weapon equipped
            {
                return $"Equipped: {enemyType} ({charHP}/{charMaxHP}HP) at [{TileX},{TileY}] with {CharacterWeapon.tileType} ({characterWeapon.WeaponDurability}x{characterWeapon.WeaponDamage} DMG)";
            }
        }




    }
}
