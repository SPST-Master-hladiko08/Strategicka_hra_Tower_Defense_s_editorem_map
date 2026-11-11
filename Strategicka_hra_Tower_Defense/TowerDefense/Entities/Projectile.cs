using System;
using System.Drawing;

namespace TowerDefense.Entities
{
    public class Projectile : GameObject
    {
        public Enemy Target { get; private set; }
        public int Damage { get; private set; }
        public float Speed { get; private set; } = 8f;

        public Projectile(float x, float y, Enemy target, int damage)
            : base(x, y)
        {
            Target = target;
            Damage = damage;
        }

        public override void Update()
        {
            if (!IsActive) return;

            if (Target == null || !Target.IsActive)
            {
                IsActive = false;
                return;
            }

            float dx = Target.Position.X - Position.X;
            float dy = Target.Position.Y - Position.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance <= Speed)
            {
                Target.TakeDamage(Damage);
                IsActive = false;
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
            g.FillEllipse(Brushes.Yellow, Position.X - 4, Position.Y - 4, 8, 8);
            g.DrawEllipse(Pens.Black, Position.X - 4, Position.Y - 4, 8, 8);
        }
    }
}