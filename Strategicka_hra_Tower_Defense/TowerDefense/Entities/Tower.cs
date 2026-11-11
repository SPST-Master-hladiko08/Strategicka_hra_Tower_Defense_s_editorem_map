using System;
using System.Collections.Generic;
using System.Drawing;

namespace TowerDefense.Entities
{
    public abstract class Tower : GameObject
    {
        public float Range { get; protected set; }
        public int Damage { get; protected set; }
        public int Cost { get; protected set; }
        public int FireCooldownMax { get; protected set; }
        protected int currentCooldown = 0;
        public Color TowerColor { get; protected set; }

        protected Tower(float x, float y, float range, int damage, int cost, int cooldown, Color color)
            : base(x, y)
        {
            Range = range;
            Damage = damage;
            Cost = cost;
            FireCooldownMax = cooldown;
            TowerColor = color;
        }

        public override void Update()
        {
            if (currentCooldown > 0)
                currentCooldown--;
        }

        // Vyhledá nepřítele v dosahu a vystřelí projektil
        public Projectile TryShoot(List<Enemy> enemies)
        {
            if (currentCooldown > 0) return null;

            foreach (var enemy in enemies)
            {
                if (!enemy.IsActive) continue;

                float dx = enemy.Position.X - Position.X;
                float dy = enemy.Position.Y - Position.Y;
                float distance = (float)Math.Sqrt(dx * dx + dy * dy);

                if (distance <= Range)
                {
                    currentCooldown = FireCooldownMax;
                    return new Projectile(Position.X, Position.Y, enemy, Damage);
                }
            }
            return null;
        }

        public override void Draw(Graphics g)
        {
            float size = 32f;
            using (Brush b = new SolidBrush(TowerColor))
            {
                g.FillRectangle(b, Position.X - size / 2, Position.Y - size / 2, size, size);
                g.DrawRectangle(Pens.Black, Position.X - size / 2, Position.Y - size / 2, size, size);
            }
            // Vnitřní střed věže (hlaveň/kopule)
            g.FillEllipse(Brushes.DimGray, Position.X - 8, Position.Y - 8, 16, 16);
        }
    }

    // Rychlá věž: nižší poškození, ale vysoká kadence střelby
    public class FastTower : Tower
    {
        public FastTower(float x, float y)
            : base(x, y, range: 130f, damage: 15, cost: 50, cooldown: 18, color: Color.RoyalBlue)
        {
        }
    }

    // Silná věž: velký dostřel a vysoké poškození, ale pomalejší přebíjení
    public class HeavyTower : Tower
    {
        public HeavyTower(float x, float y)
            : base(x, y, range: 180f, damage: 55, cost: 100, cooldown: 50, color: Color.DarkSlateBlue)
        {
        }
    }
}