using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using TowerDefense.Entities;

namespace TowerDefense
{
    public partial class Form1 : Form
    {
        private Timer gameTimer;
        private List<Enemy> enemies = new List<Enemy>();
        private List<Tower> towers = new List<Tower>();
        private List<Projectile> projectiles = new List<Projectile>();
        private List<PointF> mapPath = new List<PointF>();

        private int money = 150;
        private int lives = 20;
        private int wave = 1;

        public Form1()
        {
            InitializeComponent();
            SetupTestGame();
            SetupGameLoop();
        }

        private void SetupTestGame()
        {
            // 1. Testovací trasa pro nepřátele (klikatá cesta přes plátno)
            mapPath.Add(new PointF(20, 100));
            mapPath.Add(new PointF(400, 100));
            mapPath.Add(new PointF(400, 350));
            mapPath.Add(new PointF(700, 350));

            // 2. Přidáme testovací věž vedle cesty
            towers.Add(new FastTower(300, 160));

            // 3. Vytvoříme testovacího nepřítele
            enemies.Add(new ScoutEnemy(mapPath));

            // Propojení vykreslování s herním plátnem
            gameCanvas1.Paint += GameCanvas_Paint;
            gameCanvas1.Resize += (s, e) => gameCanvas1.Invalidate();
        }

        private void SetupGameLoop()
        {
            // Herní smyčka běžící cca na 60 FPS (interval ~16 ms)
            gameTimer = new Timer();
            gameTimer.Interval = 16;
            gameTimer.Tick += GameLoop_Tick;
            gameTimer.Start();
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            // A. Aktualizace pohybu nepřátel
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Update();

                // Nepřítel došel na konec trasy -> ztráta života
                if (enemies[i].ReachedBase)
                {
                    lives--;
                    lblLives.Text = $"Životy: {lives}";
                    enemies.RemoveAt(i);
                }
                // Nepřítel byl zničen střelbou -> odměna
                else if (!enemies[i].IsActive)
                {
                    money += enemies[i].Reward;
                    lblMoney.Text = $"Peníze: {money} $";
                    enemies.RemoveAt(i);
                }
            }

            // B. Logika věží a střelba
            foreach (var tower in towers)
            {
                tower.Update();
                Projectile newShot = tower.TryShoot(enemies);
                if (newShot != null)
                {
                    projectiles.Add(newShot);
                }
            }

            // C. Pohyb projektilů
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update();
                if (!projectiles[i].IsActive)
                {
                    projectiles.RemoveAt(i);
                }
            }

            // D. Požadavek na překreslení herního plátna
            gameCanvas1.Invalidate();
        }

        private void GameCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Automatické přizpůsobení (škálování) obsahu plátna při změně velikosti okna
            float scaleX = (float)gameCanvas1.Width / 800f;
            float scaleY = (float)gameCanvas1.Height / 500f;
            g.ScaleTransform(scaleX, scaleY);

            // Vykreslení testovací trasy
            if (mapPath.Count > 1)
            {
                using (Pen pathPen = new Pen(Color.SandyBrown, 36))
                {
                    pathPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    pathPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    g.DrawLines(pathPen, mapPath.ToArray());
                }
            }

            // Vykreslení věží
            foreach (var tower in towers)
            {
                tower.Draw(g);
            }

            // Vykreslení nepřátel
            foreach (var enemy in enemies)
            {
                enemy.Draw(g);
            }

            // Vykreslení projektilů
            foreach (var p in projectiles)
            {
                p.Draw(g);
            }
        }
    }
}