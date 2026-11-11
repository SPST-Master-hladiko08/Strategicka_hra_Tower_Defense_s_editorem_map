using System.Drawing;

namespace TowerDefense.Entities
{
    // Abstraktní bázová třída pro všechny herní prvky na plátně
    public abstract class GameObject
    {
        public PointF Position { get; set; }
        public bool IsActive { get; set; } = true;

        protected GameObject(float x, float y)
        {
            Position = new PointF(x, y);
        }

        // Aktualizace logiky prvku v každém kroku herní smyčky
        public abstract void Update();

        // Vykreslení prvku pomocí rozhraní GDI+
        public abstract void Draw(Graphics g);
    }
}