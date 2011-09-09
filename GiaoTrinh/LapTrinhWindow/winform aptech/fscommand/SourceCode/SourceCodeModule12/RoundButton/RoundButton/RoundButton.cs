/*
 * RoundButton.cs
 * 
 * Copyright © 2007 Aptech Software Limited. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RoundButton
{
    /// <summary>
    /// Class RoundButton is used to create a simple custom control.
    /// </summary>
    public partial class RoundButton : Control
    {
        private Color backgroundColor = Color.LightBlue;
        private Color borderColor = Color.Blue;
        private string text = "roundButton1";

        /// <value>Property <c>BorderColor</c> represents the border color.</value>
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <value>Property <c>Text</c> represents the text.</value>
        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Draws a custom control.
        /// </summary>
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            int penWidth = 4;
            Pen pen = new Pen(borderColor, penWidth);
            int fontHeight = 10;
            Font font = new Font("Arial", fontHeight);
            SolidBrush brush = new SolidBrush(backgroundColor);
            graphics.FillEllipse(brush, 0, 0, Width, Height);
            SolidBrush textBrush = new SolidBrush(Color.Black);
            graphics.DrawEllipse(pen, (int)penWidth / 2,
                (int)penWidth / 2, Width - penWidth, Height - penWidth);
            SizeF textSize = graphics.MeasureString(text, font);
            graphics.DrawString(text, font, textBrush, (Width - textSize.Width) / 2,
                (Height - textSize.Height) / 2);
        }
    }
}
