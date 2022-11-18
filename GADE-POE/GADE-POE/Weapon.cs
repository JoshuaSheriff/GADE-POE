using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public abstract class Weapon : Item
    {
        protected int weaponDamage;
        public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }

        protected int weaponRange;
        public virtual int WeaponRange { get { return weaponRange; } set { weaponRange = value; } }

        protected int weaponDurability;
        public int WeaponDurability { get { return weaponDurability; } set { weaponDurability = value; } }

        protected int weaponCost;
        public virtual int WeaponCost { get { return weaponCost; } set { weaponCost = value; } }

        public TileType weaponTileType { get; set; } //Only used in ToString


        protected enum weaponType
        {
            MELEE,
            RANGED
        }

        public Weapon(int weaponX, int weaponY) : base( weaponX, weaponY)
        {

        }
    }
}
