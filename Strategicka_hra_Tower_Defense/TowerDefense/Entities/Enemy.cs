using System;
using System.Collections.Generic;
using System.Drawing;

namespace TowerDefense.Entities
{
    public class Enemy : GameObject
    {
        public float Speed { get; protected set; }
        public int MaxHealth { get; protected set; }
        public int CurrentHealth { get; set; }
        public int Reward { get; protected set; }
        public Color EnemyColor { get; protected set; }
        public float Radius { get; protected set; } = 14f;

        private readonly List<PointF> path;
        private int targetWaypointIndex = 0;
        public bool ReachedBase { get; private set; } = false;

        public Enemy(List<PointF> waypoints, float speed, int maxHealth, int reward, Color color)
            : base(waypoints[0].X, waypoints[0].Y)
        {
            path = waypoints;
            Speed = speed;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            Reward = reward;
            EnemyColor = color;
            targetWaypointIndex = 1;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                IsActive = false;
            }
        }

        public override void Update()
        {
            if (!IsActive || path == null || targetWaypointIndex >= path.Count)
                return;

            PointF target = path[targetWaypointIndex];
            float dx = target.X - Position.X;
            float dy = target.Y - Position.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance <= Speed)
            {
                Position = target;
                targetWaypointIndex++;
                if (targetWaypointIndex >= path.Count)
                {
                    ReachedBase = true;
                    IsActive = false;
                }
            }
            else
            {
                Position = new PointF(
                    Position.X + (dx / distance) * Speed,
                    Position.Y + (dy / distance) * Speed);
            }
        }

        public override void Draw(Graphics g)
        {
            if (!IsActive) return;

            // Tělo nepřítele
            using (Brush bodyBrush = new SolidBrush(EnemyColor))
            {
                g.FillEllipse(bodyBrush, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
                g.DrawEllipse(Pens.Black, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
            }

            // Ukazatel životů (Health bar) nad nepřítelem
            float barWidth = 30f;
            float barHeight = 5f;
            float healthRatio = (float)CurrentHealth / MaxHealth;

            g.FillRectangle(Brushes.Red, Position.X - barWidth / 2, Position.Y - Radius - 10, barWidth, barHeight);
            g.FillRectangle(Brushes.LimeGreen, Position.X - barWidth / 2, Position.Y - Radius - 10, barWidth * healthRatio, barHeight);
            g.DrawRectangle(Pens.Black, Position.X - barWidth / 2, Position.Y - Radius - 10, barWidth, barHeight);
        }
    }

    // Rychlý nepřítel s méně životy
    public class ScoutEnemy : Enemy
    {
        public ScoutEnemy(List<PointF> waypoints)
            : base(waypoints, speed: 3.2f, maxHealth: 60, reward: 15, color: Color.OrangeRed)
        {
            Radius = 11f;
        }
    }

    // Pomalý odolný nepřítel s vysokým počtem životů
    public class TankEnemy : Enemy
    {
        public TankEnemy(List<PointF> waypoints)
            : base(waypoints, speed: 1.4f, maxHealth: 200, reward: 35, color: Color.DarkRed)
        {
            Radius = 16f;
        }
    }
}