using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace PFC.App.Controls
{
    public class PfcRoundedGradientPanel : GradientPanel
    {
        private int _cornerRadius = 15;

        [Category("Appearance")]
        [Description("Sets the roundness of the panel corners.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                this.Invalidate(); // Redraw whenever the radius changes
            }
        }

        public PfcRoundedGradientPanel()
        {
            // Set default styling to match your coffee app UI
            this.BorderStyle = BorderStyle.None;
            this.BorderColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 1. High-quality smoothing for the curves
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // 2. Create the rounded path
            using (GraphicsPath path = GetRoundedPath(this.ClientRectangle, _cornerRadius))
            {
                // 3. Set the Region to clip the panel's sharp corners
                this.Region = new Region(path);

                // 4. Let the base GradientPanel draw its background colors
                base.OnPaint(e);

                // 5. Optional: Draw a subtle border to clean up the edges
                if (this.BorderStyle != BorderStyle.None)
                {
                    using (Pen pen = new Pen(this.BorderColor, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2f;

            // Prevent the radius from exceeding panel dimensions
            if (d > rect.Width) d = rect.Width;
            if (d > rect.Height) d = rect.Height;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}