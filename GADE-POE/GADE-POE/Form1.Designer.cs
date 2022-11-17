namespace GADE_POE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblMap = new System.Windows.Forms.Label();
            this.lblPlayerStats = new System.Windows.Forms.Label();
            this.lstEnemies = new System.Windows.Forms.ListBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.lblAttackPrompt = new System.Windows.Forms.Label();
            this.btnStill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.btnLeft.Location = new System.Drawing.Point(16, 578);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(100, 85);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.btnUp.Location = new System.Drawing.Point(155, 578);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(100, 85);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "/\\";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.btnDown.Location = new System.Drawing.Point(295, 578);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(100, 85);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "\\/";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.btnRight.Location = new System.Drawing.Point(432, 578);
            this.btnRight.Margin = new System.Windows.Forms.Padding(4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(100, 85);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnSave.Location = new System.Drawing.Point(16, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(516, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnLoad.Location = new System.Drawing.Point(540, 15);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(511, 36);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Font = new System.Drawing.Font("Consolas", 25F);
            this.lblMap.Location = new System.Drawing.Point(16, 59);
            this.lblMap.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(150, 40);
            this.lblMap.TabIndex = 6;
            this.lblMap.Text = "GameMap";
            // 
            // lblPlayerStats
            // 
            this.lblPlayerStats.AutoSize = true;
            this.lblPlayerStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblPlayerStats.Location = new System.Drawing.Point(540, 59);
            this.lblPlayerStats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerStats.Name = "lblPlayerStats";
            this.lblPlayerStats.Size = new System.Drawing.Size(154, 31);
            this.lblPlayerStats.TabIndex = 7;
            this.lblPlayerStats.Text = "PlayerStats";
            // 
            // lstEnemies
            // 
            this.lstEnemies.FormattingEnabled = true;
            this.lstEnemies.ItemHeight = 16;
            this.lstEnemies.Location = new System.Drawing.Point(540, 492);
            this.lstEnemies.Margin = new System.Windows.Forms.Padding(4);
            this.lstEnemies.Name = "lstEnemies";
            this.lstEnemies.Size = new System.Drawing.Size(509, 116);
            this.lstEnemies.TabIndex = 8;
            // 
            // btnAttack
            // 
            this.btnAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnAttack.Location = new System.Drawing.Point(540, 617);
            this.btnAttack.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(511, 47);
            this.btnAttack.TabIndex = 9;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // lblAttackPrompt
            // 
            this.lblAttackPrompt.AutoSize = true;
            this.lblAttackPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblAttackPrompt.Location = new System.Drawing.Point(541, 672);
            this.lblAttackPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttackPrompt.Name = "lblAttackPrompt";
            this.lblAttackPrompt.Size = new System.Drawing.Size(117, 22);
            this.lblAttackPrompt.TabIndex = 10;
            this.lblAttackPrompt.Text = "AttackPrompt";
            // 
            // btnStill
            // 
            this.btnStill.Location = new System.Drawing.Point(16, 673);
            this.btnStill.Margin = new System.Windows.Forms.Padding(4);
            this.btnStill.Name = "btnStill";
            this.btnStill.Size = new System.Drawing.Size(516, 28);
            this.btnStill.TabIndex = 11;
            this.btnStill.Text = "No Movement";
            this.btnStill.UseVisualStyleBackColor = true;
            this.btnStill.Click += new System.EventHandler(this.btnStill_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 716);
            this.Controls.Add(this.btnStill);
            this.Controls.Add(this.lblAttackPrompt);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.lstEnemies);
            this.Controls.Add(this.lblPlayerStats);
            this.Controls.Add(this.lblMap);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnLeft);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "GAMEBOY Adv";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblPlayerStats;
        private System.Windows.Forms.ListBox lstEnemies;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Label lblAttackPrompt;
        private System.Windows.Forms.Button btnStill;
    }
}

