using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PuzzleDevCom
{
    class CircularButton : Button
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath g = new GraphicsPath();
            g.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(g);
            base.OnPaint(pe);
        }

    }
}
