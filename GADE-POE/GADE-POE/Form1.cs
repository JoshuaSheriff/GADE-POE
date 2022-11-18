using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_POE
{
    public partial class Form1 : Form
    {
        private GameEngine gameEngine;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameEngine = new GameEngine();
            lblAttackPrompt.Text = "";
            GenMap();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Up);
            EnemiesTurn();
            GenMap();
            lblAttackPrompt.Text = "";
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Down);
            EnemiesTurn();
            GenMap();
            lblAttackPrompt.Text = "";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Left);
            EnemiesTurn();
            GenMap();
            lblAttackPrompt.Text = "";
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Right);
            EnemiesTurn();
            GenMap();
            lblAttackPrompt.Text = "";
        }

        private void btnStill_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.NoMovement);
            EnemiesTurn();
            GenMap();
            lblAttackPrompt.Text = "";
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            Enemy enemy;

            try // Check if player selected an enemy
            {
                enemy = gameEngine.GameMap.Enemies[lstEnemies.SelectedIndex];
            }
            catch (IndexOutOfRangeException)
            {
                lblAttackPrompt.Text = "Select an enemy from the list";
                return;
            }

            
            if (gameEngine.GameMap.Hero.CheckRange(enemy)) // Check if enemy is in range
            {
                gameEngine.GameMap.Hero.Attack(enemy);
                gameEngine.CheckForDead(enemy);
                lblAttackPrompt.Text = $"{enemy.enemyType} was hit Hit!";
            }
            else if (!gameEngine.GameMap.Hero.CheckRange(enemy))
            {
                lblAttackPrompt.Text = $"{enemy.enemyType} is out of range";
            }
            else
            {
                lblAttackPrompt.Text = "Wrong enemy";
            }
            gameEngine.EnemiesAttack();
            GenMap();
        }

        //private void btnSave_Click(object sender, EventArgs e) 
        //{                                                         DO NOT CHANGE EITHER OF THESE
            
        //}

        //private void btnLoad_Click(object sender, EventArgs e)
        //{
            
        //}

        private void GenMap()
        {
            lblMap.Text = gameEngine.GameMap.ToString();
            lblPlayerStats.Text = gameEngine.GameMap.Hero.ToString();

            lstEnemies.Items.Clear();
            for (int enemy = 0; enemy < gameEngine.GameMap.totalEnemyNum; enemy++)
            {
                lstEnemies.Items.Add(gameEngine.GameMap.Enemies[enemy].ToString());
            }
        }
        private void EnemiesTurn()
        {
            gameEngine.MoveEnemies();
            gameEngine.EnemiesAttack();
        }

        private void btnSave_Click_1(object sender, EventArgs e) //DO NOT CHANGE
        {
            gameEngine.Save();
        }

        private void btnLoad_Click_1(object sender, EventArgs e) //DO NOT CHANGE
        {
            try
            {
                gameEngine.Load();
                GenMap();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Save file does not exist");
            }
        }
    }
}
