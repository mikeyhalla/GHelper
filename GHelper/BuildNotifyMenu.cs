using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GHelper
{
    public class BuildNotifyMenu
    {
        public class MyColorTable : ProfessionalColorTable
        {
            public override Color MenuItemBorder
            {
                get { return Color.FromArgb(0); }
            }
            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(0, 82, 164); }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return Color.FromArgb(22, 22, 22); }
            }
            public override Color ImageMarginGradientBegin
            {
                get { return Color.FromArgb(22, 22, 22); }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return Color.FromArgb(22, 22, 22); }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return Color.FromArgb(22, 22, 22); }
            }
        }

        public class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer()
                : base(new MyColorTable())
            {
            }
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var r = new Rectangle(e.ArrowRectangle.Location, e.ArrowRectangle.Size);
                r.Inflate(-2, -6);

                Pen pen = new Pen(Color.FromArgb(255, 230, 230, 230));
                e.Graphics.DrawLines(pen, new Point[]{
        new Point(r.Left, r.Top),
        new Point(r.Right, r.Top + r.Height /2),
        new Point(r.Left, r.Top+ r.Height)});
            }

            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var r = new Rectangle(e.ImageRectangle.Location, e.ImageRectangle.Size);
                r.Inflate(-4, -6);
                Pen pen = new Pen(Color.FromArgb(255, 230, 230, 230));
                e.Graphics.DrawLines(pen, new Point[]{
        new Point(r.Left, r.Bottom - r.Height /2),
        new Point(r.Left + r.Width /3,  r.Bottom),
        new Point(r.Right, r.Top)});
            }
        }
    }
}
