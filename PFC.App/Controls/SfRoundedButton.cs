using System;
using System.ComponentModel;
using System.Drawing;              // Added for Rectangle and Region
using System.Drawing.Drawing2D;    // For GraphicsPath and SmoothingMode
using System.Windows.Forms;        // For PaintEventArgs
using Syncfusion.WinForms.Controls;

namespace PFC.App.Controls
{
    /// <summary>
    /// A custom Syncfusion SfButton with adjustable rounded corners.
    /// </summary>
    public class SfRoundedButton : SfButton
    {
        // Private field to store the radius value (the 'backing field')
        private int _cornerRadius = 15;

        public SfRoundedButton()
        {
            // 1. Hide the focus dotted line
            this.FocusRectangleVisible = false;

            // 2. Remove all default borders
            this.Style.Border = null;
            this.Style.HoverBorder = null;
            this.Style.FocusedBorder = null;
            this.Style.PressedBorder = null;
        }

        [Category("Appearance")]
        [DefaultValue(15)]
        [Description("Sets the radius for the rounded corners of the button.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                // Only invalidate if the value actually changes to prevent flickering
                if (_cornerRadius != value)
                {
                    _cornerRadius = value;
                    this.Invalidate(); // Forces the control to redraw in the Designer/Runtime
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 1. Let Syncfusion draw the background, text, and icons first
            base.OnPaint(e);

            // 2. High-quality rendering for the curves
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // 3. Define and apply the new shape to the button's Region
            // Note: We use 'using' to ensure the GraphicsPath is disposed correctly
            using (GraphicsPath path = GetRoundedRectPath(this.ClientRectangle, _cornerRadius))
            {
                // Applying the region clips the square corners off the button
                this.Region = new Region(path);

                // Optional: If you want to draw a border that follows the curve:
                // e.Graphics.DrawPath(SystemPens.ControlDark, path);
            }
        }

        /// <summary>
        /// Generates a geometric path for a rounded rectangle.
        /// </summary>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2f;

            // Ensure the radius doesn't exceed half the height/width to avoid errors
            if (d > rect.Width) d = rect.Width;
            if (d > rect.Height) d = rect.Height;
            if (d <= 0) d = 1; // Prevent 0-size arcs

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);              // Top-Left
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);       // Top-Right
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90); // Bottom-Right
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);       // Bottom-Left

            path.CloseFigure();
            return path;
        }
    }
}
