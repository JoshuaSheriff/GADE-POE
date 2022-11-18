using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    class MeleeWeapon : Weapon
    {
        public enum Types
        {
            DAGGER,
            LONGSWORD
        }

        public override int WeaponRange { get => base.WeaponRange; set => base.WeaponRange = 1; }

        public MeleeWeapon(string meleeWeaponType, int meleeWeaponX, int meleeWeaponY) : base(meleeWeaponX, meleeWeaponY)
        {
            switch (meleeWeaponType)
            {
                case "DAGGER":
                    WeaponDurability = 10;
                    WeaponDamage = 3;
                    WeaponCost = 3;
                    break;
                case "LONGSWORD":
                    WeaponDurability = 6;
                    WeaponDamage = 4;
                    WeaponCost = 5;
                    break;
            }
        }
    }
}
