using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    public class Map
    {
        private Enemy[] enemies;
        public Enemy[] Enemies { get { return enemies; } set { enemies = value; } }

        private Hero hero;
        public Hero Hero
        {
            get { return hero; }
            set { hero = value; }
        }
        public Item[] Items { get; set; }

        private int totalGoldSpawns;
        private int goldCounter;

        private int totalWeaponDrops;
        private int weaponCounter;

        private int itemCounter;

        private Random random = new Random();
        private int mapHeight; // Y
        private int mapWidth; // X
        public int totalEnemyNum { get; set; }
        private int enemyCounter;

        public static Tile[,] TileMap { get; set; }
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int totalEnemies, int goldDropsAmount, int weaponDropsAmount)
        {
            mapWidth = random.Next(minWidth, maxWidth + 1);
            mapHeight = random.Next(minHeight, maxHeight + 1);
            TileMap = new Tile[mapHeight, mapWidth];

            totalEnemyNum = totalEnemies;
            Enemies = new Enemy[totalEnemyNum];

            totalGoldSpawns = goldDropsAmount;
            totalWeaponDrops = weaponDropsAmount;

            itemCounter = totalGoldSpawns + totalWeaponDrops;
            Items = new Item[itemCounter];
            itemCounter = 0;

            
            for (int row = 0; row < TileMap.GetLength(0); row++) //Empty Map creation
            {
                for (int column = 0; column < TileMap.GetLength(1); column++)
                {
                    if (row == 0 || row == mapHeight - 1)
                    {
                        TileMap[row, column] = new Obstacle(column, row); //top and bottom border creation
                    }
                    else if (column == 0 || column == mapWidth - 1)
                    {
                        TileMap[row, column] = new Obstacle(column, row); //left and right border creation
                    }
                    else
                    {
                        TileMap[row, column] = new EmptyTile(column, row); //fill map with empty
                    }
                }
            }
            Create(Tile.TileType.Hero); //hero spawner

            int enemyRandomiser;
            for (enemyCounter = 0; enemyCounter < totalEnemyNum; enemyCounter++) //enemy spawner
            {
                enemyRandomiser = random.Next(3);

                if (enemyRandomiser == 1)
                    Create(Tile.TileType.Leader);
                else if (enemyRandomiser == 2)
                    Create(Tile.TileType.SwampCreature);
                else
                    Create(Tile.TileType.Mage);
            }
            

            for (goldCounter = 0; goldCounter < totalGoldSpawns; goldCounter++) //gold spawner
            {
                Create(Tile.TileType.Gold);
                itemCounter++;
            }

            for (weaponCounter = 0; weaponCounter < totalWeaponDrops; weaponCounter++) //weapon spawner
            {
                int randomWeapon = random.Next(4);
                switch (randomWeapon)
                {
                    case 0:
                        Create(Tile.TileType.Dagger);
                        break;
                    case 1:
                        Create(Tile.TileType.Longsword);
                        break;
                    case 2:
                        Create(Tile.TileType.Rifle);
                        break;
                    case 3:
                        Create(Tile.TileType.Longbow);
                        break;
                }
                itemCounter++;
            }

            UpdateVision();
        }

        public Map(int MapWidth, int MapHeight) //used for loading
        {
            mapWidth = MapWidth;
            mapHeight = MapHeight;
            TileMap = new Tile[mapHeight, mapWidth];

            //same purpose as above
            for (int row = 0; row < TileMap.GetLength(0); row++)
            {
                for (int column = 0; column < TileMap.GetLength(1); column++)
                {
                    if (row == 0 || row == mapHeight - 1)
                    {
                        TileMap[row, column] = new Obstacle(column, row);
                    }
                    else if (column == 0 || column == mapWidth - 1)
                    {
                        TileMap[row, column] = new Obstacle(column, row);
                    }
                    else
                    {
                        TileMap[row, column] = new EmptyTile(column, row);
                    }
                }
            }
        }

        public Tile Create(Tile.TileType type)
        {
            int xPos;
            int yPos;

            do
            {
                xPos = random.Next(1, mapWidth - 1);
                yPos = random.Next(1, mapHeight - 1);
            }
            while (TileMap[yPos, xPos].tileType != Tile.TileType.EmptyTile); //prevents spawning on already existing tiles

            if (type == Tile.TileType.SwampCreature) // enemy spawner
            {
                Enemies[enemyCounter] = new SwampCreature(xPos, yPos, enemyCounter);
                TileMap[yPos, xPos] = Enemies[enemyCounter];                       
            }
            else if (type == Tile.TileType.Mage)
            {
                Enemies[enemyCounter] = new Mage(xPos, yPos, enemyCounter);
                TileMap[yPos, xPos] = Enemies[enemyCounter];
            }
            else if (type == Tile.TileType.Leader)
            {
                Enemies[enemyCounter] = new Leader(xPos, yPos, enemyCounter, Hero);
                TileMap[yPos, xPos] = Enemies[enemyCounter];
            }
            else if (type == Tile.TileType.Hero)// hero spawner
            {
                Hero = new Hero(xPos, yPos, 30);
                TileMap[yPos, xPos] = Hero;
            }
            else if (type == Tile.TileType.Gold)// gold spawner
            {
                Items[itemCounter] = new Gold(xPos, yPos);
                TileMap[yPos, xPos] = Items[itemCounter];
            }
            else if(type == Tile.TileType.Dagger)
            {
                Items[itemCounter] = new MeleeWeapon("DAGGER",xPos, yPos);
                TileMap[yPos, xPos] = Items[itemCounter];
            }
            else if (type == Tile.TileType.Longsword)
            {
                Items[itemCounter] = new MeleeWeapon("LONGSWORD", xPos, yPos);
                TileMap[yPos, xPos] = Items[itemCounter];
            }
            else if (type == Tile.TileType.Rifle)
            {
                Items[itemCounter] = new RangedWeapon("RIFLE", xPos, yPos);
                TileMap[yPos, xPos] = Items[itemCounter];
            }
            else if (type == Tile.TileType.Longbow)
            {
                Items[itemCounter] = new RangedWeapon("LONGBOW", xPos, yPos);
                TileMap[yPos, xPos] = Items[itemCounter];
            }
            return TileMap[yPos, xPos];
        }

        public void UpdateVision()
        {
            Hero.CharacterVision[0] = TileMap[Hero.TileY, Hero.TileX    ]; // None
            Hero.CharacterVision[1] = TileMap[Hero.TileY - 1, Hero.TileX]; // Up
            Hero.CharacterVision[2] = TileMap[Hero.TileY + 1, Hero.TileX]; // Down
            Hero.CharacterVision[3] = TileMap[Hero.TileY, Hero.TileX - 1]; // Left
            Hero.CharacterVision[4] = TileMap[Hero.TileY, Hero.TileX + 1]; // Right

            for (int i = 0; i < totalEnemyNum; i++)
            {
                Enemies[i].CharacterVision[0] = TileMap[Enemies[i].TileY, Enemies[i].TileX];
                Enemies[i].CharacterVision[1] = TileMap[Enemies[i].TileY - 1, Enemies[i].TileX];
                Enemies[i].CharacterVision[2] = TileMap[Enemies[i].TileY + 1, Enemies[i].TileX];
                Enemies[i].CharacterVision[3] = TileMap[Enemies[i].TileY, Enemies[i].TileX - 1];
                Enemies[i].CharacterVision[4] = TileMap[Enemies[i].TileY, Enemies[i].TileX + 1];
            }
        }

        public Item GetItemAtPosition(int itemX, int itemY)
        {
            Item returnItem;
            for (int searchIndex = 0; searchIndex < Items.Length; searchIndex++)
            {
                if (Items[searchIndex] != null) // prevents crashing
                {                              

                    if (Items[searchIndex].TileX == itemX && Items[searchIndex].TileY == itemY) // find item co-ordinates
                    {
                        returnItem = Items[searchIndex];
                        Items[searchIndex] = null;
                        return returnItem;
                    }
                }
            }
            return null;
        }

        public override string ToString() // map creation loop
        {
            string mapString = "";
            for (int row = 0; row < TileMap.GetLength(0); row++)
            {
                for (int column = 0; column < TileMap.GetLength(1); column++)
                {
                    mapString += (char)TileMap[row, column].tileType;
                }
                mapString += "\n";
            }
            return mapString;
        }

    }
}
