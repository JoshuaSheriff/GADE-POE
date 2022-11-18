using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    class RangedWeapon : Weapon
    {
        public enum RangedWeapons
        {
            RIFLE,
            LONGBOW
        }

        public override int WeaponRange { get => base.WeaponRange; set => base.WeaponRange = value; }

        public RangedWeapon(string weaponTypeToCreate, int rangedWeaponX, int rangedWeaponY) : base(rangedWeaponX, rangedWeaponY) // Default Constructor
        {
            switch (weaponTypeToCreate)
            {
                case "RIFLE":
                    WeaponDurability = 3;
                    WeaponRange = 3;
                    WeaponDamage = 5;
                    WeaponCost = 7;
                    break;
                case "LONGBOW":
                    WeaponDurability = 4;
                    WeaponRange = 2;
                    WeaponDamage = 4;
                    WeaponCost = 6;
                    break;
            }
        }

        public void RangedWeaponLoad(string weaponTypeToCreateFromSave, int weaponDurability)// 'Constuctor' for when loading the weapon
        {

        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
