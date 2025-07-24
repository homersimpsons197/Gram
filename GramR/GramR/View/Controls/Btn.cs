using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
    public class Btn : Button
    {
        private int borderRadius = 5;
        private Color borderColor = Color.Gray;
        private int borderSize = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        public Btn()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = borderSize > 0 ? borderSize : 1;

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
            using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                this.Region = new Region(pathSurface);
                pevent.Graphics.DrawPath(penSurface, pathSurface);

                if (borderSize >= 1)
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
            }
        }
    }
}
