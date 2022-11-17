﻿using System;
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

            try // Check if an enemy is selected
            {
                enemy = gameEngine.GameMap.Enemies[lstEnemies.SelectedIndex];
            }
            catch (IndexOutOfRangeException)
            {
                lblAttackPrompt.Text = "Select an enemy from the list";
                return; // Don't continue if there is no enemy selected
            }

            // Check if enemy is in range
            if (gameEngine.GameMap.Hero.CheckRange(enemy))
            {
                gameEngine.GameMap.Hero.Attack(enemy);
                gameEngine.CheckForDead(enemy);
                lblAttackPrompt.Text = "Hit!";
            }
            else if (!gameEngine.GameMap.Hero.CheckRange(enemy))
            {
                lblAttackPrompt.Text = "Enemy out of range";
            }
            else
            {
                lblAttackPrompt.Text = "Wrong enemy";
            }
            gameEngine.EnemiesAttack(); // Enemies attack Hero after Hero attacks
            GenMap();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gameEngine.Save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
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
      
    }
}
