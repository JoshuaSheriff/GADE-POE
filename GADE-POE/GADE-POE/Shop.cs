using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public class Shop
    {
        private Weapon[] weaponArr;

        private Random rng;

        private Character buyer;



        public Shop(Character characterBuyer)
        {
            this.buyer = characterBuyer;
            weaponArr = new Weapon[3];
            rng = new Random();

            for (int i = 0; i < weaponArr.Length; i++)
            {
                weaponArr[i] = RandomWeapon();
            }
        }

        private Weapon RandomWeapon()
        {
            int randomWeapon = rng.Next(4);

            MeleeWeapon mWeapon = new MeleeWeapon("DAGGER", 0, 0);
            RangedWeapon rWeapon = new RangedWeapon("RIFLE", 0, 0);
            switch (randomWeapon)
            {
                case 0:
                    mWeapon = new MeleeWeapon("DAGGER", 0, 0);
                    return mWeapon;
                    break;
                case 1:
                    mWeapon = new MeleeWeapon("LONGSWORD", 0, 0);
                    return mWeapon;
                    break;
                case 2:
                    rWeapon = new RangedWeapon("RIFLE", 0, 0);
                    return rWeapon; 
                    break;
                case 3:
                    rWeapon = new RangedWeapon("LONGBOW", 0, 0);
                    return rWeapon;
                    break;
            }

            return mWeapon = new MeleeWeapon("DAGGER", 0, 0);

        }

        public bool CanBuy(int num)
        {
            if (weaponArr[num].WeaponCost < buyer.GoldPurse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Buy(int num)
        {
            buyer.GoldPurse -= weaponArr[num].WeaponCost;
            //PickUp()?? What Pickup() method?
            weaponArr[num] = RandomWeapon();
        }

        public string DisplayWeapon(int num) //Must be assigned to the form button
        {
            return $"Buy {weaponArr[num]} ({weaponArr[num].WeaponCost}"; 
        }
    }
}
