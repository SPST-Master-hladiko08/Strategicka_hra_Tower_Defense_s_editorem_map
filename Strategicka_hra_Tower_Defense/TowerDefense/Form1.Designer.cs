namespace TowerDefense
{
    partial class gameCanvas
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblLives = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblWave = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFastTower = new System.Windows.Forms.Button();
            this.btnHeavyTower = new System.Windows.Forms.Button();
            this.gameCanvas1 = new TowerDefense.GameCanvas();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSidebar.Controls.Add(this.btnHeavyTower);
            this.panelSidebar.Controls.Add(this.btnFastTower);
            this.panelSidebar.Controls.Add(this.label4);
            this.panelSidebar.Controls.Add(this.lblWave);
            this.panelSidebar.Controls.Add(this.lblMoney);
            this.panelSidebar.Controls.Add(this.lblLives);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSidebar.Location = new System.Drawing.Point(788, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 561);
            this.panelSidebar.TabIndex = 0;
            // 
            // lblLives
            // 
            this.lblLives.AutoSize = true;
            this.lblLives.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLives.Location = new System.Drawing.Point(3, 29);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(86, 20);
            this.lblLives.TabIndex = 0;
            this.lblLives.Text = "Životy: 20";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMoney.Location = new System.Drawing.Point(3, 9);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(118, 20);
            this.lblMoney.TabIndex = 1;
            this.lblMoney.Text = "Peníze: 150 $";
            // 
            // lblWave
            // 
            this.lblWave.AutoSize = true;
            this.lblWave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWave.Location = new System.Drawing.Point(3, 49);
            this.lblWave.Name = "lblWave";
            this.lblWave.Size = new System.Drawing.Size(65, 20);
            this.lblWave.TabIndex = 2;
            this.lblWave.Text = "Vlna: 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stavba věží:";
            // 
            // btnFastTower
            // 
            this.btnFastTower.Location = new System.Drawing.Point(7, 85);
            this.btnFastTower.Name = "btnFastTower";
            this.btnFastTower.Size = new System.Drawing.Size(114, 23);
            this.btnFastTower.TabIndex = 4;
            this.btnFastTower.Text = "Rychlá věž (50 $)";
            this.btnFastTower.UseVisualStyleBackColor = true;
            // 
            // btnHeavyTower
            // 
            this.btnHeavyTower.Location = new System.Drawing.Point(7, 114);
            this.btnHeavyTower.Name = "btnHeavyTower";
            this.btnHeavyTower.Size = new System.Drawing.Size(114, 23);
            this.btnHeavyTower.TabIndex = 5;
            this.btnHeavyTower.Text = "Silná věž (100 $)";
            this.btnHeavyTower.UseVisualStyleBackColor = true;
            // 
            // gameCanvas1
            // 
            this.gameCanvas1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.gameCanvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameCanvas1.Location = new System.Drawing.Point(0, 0);
            this.gameCanvas1.Name = "gameCanvas1";
            this.gameCanvas1.Size = new System.Drawing.Size(1008, 561);
            this.gameCanvas1.TabIndex = 1;
            // 
            // gameCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.gameCanvas1);
            this.Name = "gameCanvas";
            this.Text = "Strategická hra Tower Defense";
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblWave;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblLives;
        private System.Windows.Forms.Button btnHeavyTower;
        private System.Windows.Forms.Button btnFastTower;
        private System.Windows.Forms.Label label4;
        private GameCanvas gameCanvas1;
    }
}

