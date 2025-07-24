using System.ComponentModel;

namespace System.Windows.Forms
{
    [ToolboxItem(true)]
    public class Pnl : ScrollableControl
    {
        private bool customSized;
        private Color borderColor;
        private int borderSize;
        private int borderSizeLeft;
        private int borderSizeRight;
        private int borderSizeTop;
        private int borderSizeBottom;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(0)]
        [property: RefreshProperties(RefreshProperties.All)]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value != 0)
                {
                    borderSize = value;
                    ResetValue(0);
                }
                else
                {
                    borderSize = 0;
                    Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(0)]
        [property: RefreshProperties(RefreshProperties.All)]
        public int BorderSizeLeft
        {
            get { return borderSizeLeft; }
            set
            {
                if (value != 0)
                {
                    borderSizeLeft = value;
                    ResetValue(1);
                }
                else
                {
                    borderSizeLeft = 0;
                    Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(0)]
        [property: RefreshProperties(RefreshProperties.All)]
        public int BorderSizeRight
        {
            get { return borderSizeRight; }
            set
            {
                if (value != 0)
                {
                    borderSizeRight = value;
                    ResetValue(1);
                }
                else
                {
                    borderSizeRight = 0;
                    Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(0)]
        [property: RefreshProperties(RefreshProperties.All)]
        public int BorderSizeTop
        {
            get { return borderSizeTop; }
            set
            {
                if (value != 0)
                {
                    borderSizeTop = value;
                    ResetValue(1);
                }
                else
                {
                    borderSizeTop = 0;
                    Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(0)]
        [property: RefreshProperties(RefreshProperties.All)]
        public int BorderSizeBottom
        {
            get { return borderSizeBottom; }
            set
            {
                if (value != 0)
                {
                    borderSizeBottom = value;
                    ResetValue(1);
                }
                else
                {
                    borderSizeBottom = 0;
                    Invalidate();
                }
            }
        }

        public void ResetValue(int code)
        {
            switch (code)
            {
                case 0:
                    borderSizeLeft = 0;
                    borderSizeTop = 0;
                    borderSizeRight = 0;
                    borderSizeBottom = 0;
                    customSized = false;
                    Invalidate();
                    break;
                case 1:
                    borderSize = 0;
                    customSized = true;
                    Invalidate();
                    break;
            }
        }

        public Pnl()
        {
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (customSized)
            {
                base.OnPaint(e);
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, BorderColor, BorderSizeLeft, ButtonBorderStyle.Solid,
                                                                     BorderColor, BorderSizeTop, ButtonBorderStyle.Solid,
                                                                     BorderColor, BorderSizeRight, ButtonBorderStyle.Solid,
                                                                     BorderColor, BorderSizeBottom, ButtonBorderStyle.Solid);
            }
            else if (!customSized)
            {
                base.OnPaint(e);
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, BorderColor, BorderSize, ButtonBorderStyle.Solid,
                                                                     BorderColor, BorderSize, ButtonBorderStyle.Solid,
                                                                     BorderColor, BorderSize, ButtonBorderStyle.Solid,
                                                                     BorderColor, BorderSize, ButtonBorderStyle.Solid);
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                rect.Inflate(-1, -1);
                return rect;
            }
        }
    }
}

