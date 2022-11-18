using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public class GameEngine
    {
        private Map gameMap;
        public Map GameMap
        {
            get { return gameMap; }
            set { gameMap = value; }
        }

        private Shop shop;
        public GameEngine()
        {
            GameMap = new Map(10, 15, 5, 10, 4, 3);
        }

        public void MovePlayer(Character.Movement direction)
        {
            GameMap.Hero.Move(GameMap.Hero.ReturnMove(direction), GameMap.Hero);
            if (GameMap.Hero.HeroOnGold)
            {
                GameMap.Hero.PickUp(GameMap.GetItemAtPosition(GameMap.Hero.TileX, GameMap.Hero.TileY));
                gameMap.Hero.HeroOnGold = false;
            }
            GameMap.UpdateVision();
        }

        public void CheckForDead(Enemy enemy)
        {
            if (enemy.IsDead())
            {
                for (int i = enemy.enemyArray; i < GameMap.totalEnemyNum - 1; i++)
                {
                    GameMap.Enemies[i] = GameMap.Enemies[i + 1];
                    GameMap.Enemies[i].enemyArray--;
                }
                GameMap.totalEnemyNum--;

                Map.TileMap[enemy.TileY, enemy.TileX] = new EmptyTile(enemy.TileX, enemy.TileY); // Replace the enemy with an EmptyTile
            }
        }

        public void CheckForDead(Hero hero)
        {
            if (hero.IsDead())
            {
                Map.TileMap[hero.TileY, hero.TileX] = new EmptyTile(hero.TileX, hero.TileY); // Replace the hero with an EmptyTile
            }
        }

        public void MoveEnemies()
        {
            for (int enemyCount = 0; enemyCount < GameMap.totalEnemyNum; enemyCount++)
            {
                GameMap.Enemies[enemyCount].Move(GameMap.Enemies[enemyCount].ReturnMove(), GameMap.Enemies[enemyCount]);
                GameMap.UpdateVision();
            }
        }

        public void EnemiesAttack()
        {
            for (int enemyCount = 0; enemyCount < GameMap.totalEnemyNum; enemyCount++)
            {
                if (GameMap.Enemies[enemyCount].CheckRange(GameMap.Hero))
                {
                    GameMap.Enemies[enemyCount].Attack(GameMap.Hero);
                }
                if (GameMap.Enemies[enemyCount].tileType == Tile.TileType.Mage) // Mage attacks other enemies
                {
                    for (int targetEnemy = 0; targetEnemy < GameMap.totalEnemyNum; targetEnemy++)
                    {
                        if (GameMap.Enemies[enemyCount].CheckRange(GameMap.Enemies[targetEnemy])) // Check if enemies are in range of mage
                        {
                            GameMap.Enemies[enemyCount].Attack(GameMap.Enemies[targetEnemy]);
                            CheckForDead(GameMap.Enemies[targetEnemy]);
                        }
                    }
                }
            }
            CheckForDead(GameMap.Hero);
        }

        public void Save()
        {
            FileStream fs = new FileStream("SaveFile.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            // Write Map
            bw.Write(Map.TileMap.GetLength(1)); // Map width
            bw.Write(Map.TileMap.GetLength(0)); // Map height

            // Write Hero
            bw.Write(GameMap.Hero.TileX);
            bw.Write(GameMap.Hero.TileY);
            bw.Write(GameMap.Hero.CharHP);      
            bw.Write(GameMap.Hero.CharMaxHP);   
            bw.Write(GameMap.Hero.GoldPurse);

            // Write Enemies
            bw.Write(GameMap.totalEnemyNum);
            for (int i = 0; i < GameMap.totalEnemyNum; i++)
            {
                bw.Write(GameMap.Enemies[i].TileX);
                bw.Write(GameMap.Enemies[i].TileY);
                bw.Write((char)GameMap.Enemies[i].tileType); // To determine what type of enemy must spawn
                bw.Write(GameMap.Enemies[i].CharHP);
            }

            // Write Items
            bw.Write(GameMap.Items.Length);
            for (int i = 0; i < GameMap.Items.Length; i++)
            {
                if (GameMap.Items[i] == null)
                {
                    bw.Write(true);
                }
                else
                {
                    bw.Write(false);
                    bw.Write(GameMap.Items[i].TileX);
                    bw.Write(GameMap.Items[i].TileY);
                    bw.Write((GameMap.Items[i] as Gold).GoldAmount);
                }
            }

            bw.Close();
            fs.Close();
        }


        public void Load()
        {
            FileStream fs = new FileStream("SaveFile.bin", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            // Reading must be done in the same order writing was

            // Read Map
            int mapWidth = br.ReadInt32();
            int mapHeight = br.ReadInt32();

            GameMap = new Map(mapWidth, mapHeight); // Create empty map


            // Read Hero
            int heroX = br.ReadInt32();
            int heroY = br.ReadInt32();
            int heroHP = br.ReadInt32();
            int heroMaxHP = br.ReadInt32();
            int goldPurse = br.ReadInt32();
            // Create new hero
            GameMap.Hero = new Hero(heroX, heroY, heroHP, heroMaxHP, goldPurse);
            Map.TileMap[heroY, heroX] = GameMap.Hero; // Place hero on map


            // Read Enemies
            int enemyX, enemyY, enemyHP;
            char enemyIcon;

            GameMap.totalEnemyNum = br.ReadInt32(); // read enemy amount

            GameMap.Enemies = new Enemy[GameMap.totalEnemyNum];

            for (int i = 0; i < GameMap.totalEnemyNum; i++)
            {
                enemyX = br.ReadInt32();
                enemyY = br.ReadInt32();
                enemyIcon = br.ReadChar();
                enemyHP = br.ReadInt32();

                if (enemyIcon == (char)Tile.TileType.SwampCreature) // Create swamp creature
                {
                    GameMap.Enemies[i] = new SwampCreature(enemyX, enemyY, i, enemyHP);
                    Map.TileMap[enemyY, enemyX] = GameMap.Enemies[i];
                }
                else // Create mage enemy
                {
                    GameMap.Enemies[i] = new Mage(enemyX, enemyY, i, enemyHP);
                    Map.TileMap[enemyY, enemyX] = GameMap.Enemies[i];
                }
            }

            // Read Items
            int itemsLength = br.ReadInt32();
            GameMap.Items = new Item[itemsLength];

            bool isNull;
            int itemX;
            int itemY;
            int goldAmount;

            for (int i = 0; i < itemsLength; i++)
            {
                isNull = br.ReadBoolean();  // Check if each item is null or not null
                if (!isNull)
                {                           // Give non-null objects values
                    itemX = br.ReadInt32();
                    itemY = br.ReadInt32();
                    goldAmount = br.ReadInt32();
                    GameMap.Items[i] = new Gold(itemX, itemY, goldAmount);
                    Map.TileMap[itemY, itemX] = GameMap.Items[i];
                }
            }

            br.Close();
            fs.Close();

            GameMap.UpdateVision();
        }

    }
}
