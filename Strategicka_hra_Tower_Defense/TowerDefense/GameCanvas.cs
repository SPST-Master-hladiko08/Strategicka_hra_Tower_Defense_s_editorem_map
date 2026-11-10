using System.Drawing;
using System.Windows.Forms;

namespace TowerDefense
{
    // Vlastní ovládací prvek pro herní plátno s plynulým překreslováním
    public class GameCanvas : Panel
    {
        public GameCanvas()
        {
            // Zapnutí Double Bufferingu a optimalizace pro GDI+ vykreslování
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            this.BackColor = Color.DarkOliveGreen; // Základní barva pozadí mapy
        }
    }
}