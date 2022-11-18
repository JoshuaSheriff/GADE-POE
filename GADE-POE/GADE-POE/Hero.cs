using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public class Hero : Character
    {

        public Hero(int heroX, int heroY, int maxHP) : base(heroX, heroY)
        {
            charMaxHP = maxHP;
            charHP = charMaxHP;
            charDamage = 2;
            tileType = TileType.Hero;
        }
        public Hero(int heroX, int heroY, int hp, int maxHP, int gold) : base(heroX, heroY) // For loading from save file
        {
            charHP = hp;
            charMaxHP = maxHP;
            charDamage = 2;
            tileType = TileType.Hero;
            GoldPurse = gold;
        }
        public bool HeroOnGold { get; set; } = false; // to indicate to the MovePlayer method that the Hero is standing on gold
        public bool HeroOnDagger { get; set; } = false; // to indicate to the MovePlayer method that the Hero is standing on a dagger
        public bool HeroOnLongsword{ get; set; } = false; // to indicate to the MovePlayer method that the Hero is standing on a longsword
        public bool HeroOnRifle{ get; set; } = false; // to indicate to the MovePlayer method that the Hero is standing on a rifle
        public bool HeroOnLongbow{ get; set; } = false; // to indicate to the MovePlayer method that the Hero is standing on a longbow

        public override Movement ReturnMove(Movement move) // Checks if the space to move to is valid
        {
            if (CharacterVision[(int)move].tileType == TileType.EmptyTile)
            {
                return move;
            }
            else if (CharacterVision[(int)move].tileType == TileType.Gold) // this is needed to be able to move onto a gold Tile
            {
                HeroOnGold = true;
                return move;
            }
            else if (CharacterVision[(int)move].tileType == TileType.Dagger)// this is needed to be able to move onto a dagger Tile
            {
                HeroOnDagger = true;
                return move;
            }
            else if (CharacterVision[(int)move].tileType == TileType.Longsword)// this is needed to be able to move onto a longsword Tile
            {
                HeroOnLongsword= true;
                return move;
            }
            else if (CharacterVision[(int)move].tileType == TileType.Rifle)// this is needed to be able to move onto a rifle Tile
            {
                HeroOnRifle= true;
                return move;
            }
            else if (CharacterVision[(int)move].tileType == TileType.Longbow)// this is needed to be able to move onto a longbow Tile
            {
                HeroOnLongbow= true;
                return move;
            }
            else return Movement.NoMovement; // returned if the movement is not valid
        }

        public override string ToString()
        {
            if (characterWeapon != null)
            {
                //If character wields a weapon
                return $"Player Stats:\n" +
    $"HP: {charHP}/{charMaxHP}\n" +
    $"Current Weapon:  {CharacterWeapon.tileType}\n" +
    $"Weapon Range: {CharacterWeapon.WeaponRange}\n" +
    $"Weapon Damage: {characterWeapon.WeaponDamage}\n" +
    $"Gold: {GoldPurse}\n" +
    $"[{TileX},{TileY}]";
            }
            else
            {
                //If they don't wield a weapon
                return $"Player Stats:\n" +
    $"HP: {charHP}/{charMaxHP}\n" +
    $"Current Weapon: Bare Hands\n" +
    $"Weapon Range: 1\n" +
    $"Weapon Damage: {charDamage}\n" +
    $"Gold: {GoldPurse}\n" +
    $"[{TileX},{TileY}]";
            }
        }
    }
}
