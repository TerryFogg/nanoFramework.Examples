using nanoFramework.Presentation.Media;
using nanoFramework.Presentation;
using nanoFramework.UI.Input;
using nanoFramework.UI;
using System;
using System.Drawing;

namespace Puzzle
{
    /// <summary>
    /// Defines a Button.
    /// </summary>
    /// 
    class Button : UIElement
    {
        int _width;
        int _height;
        string _caption = "";
        Font _font = null;
        Color _foreColor = Color.FromArgb(0, 0, 0);
        Color _pressedForeColor = Color.FromArgb(255, 255, 255);
        private TextTrimming _trimming = TextTrimming.WordEllipsis;
        private TextAlignment _alignment = TextAlignment.Center;
        protected int _textMarginX = 16;
        protected int _textMarginY = 8;
        protected bool _pressed = false;
        private SolidColorBrush _normalBackgroundBrush = new SolidColorBrush(Color.FromArgb(192, 192, 192));
        private SolidColorBrush _pressedBackgroundBrush = new SolidColorBrush(Color.FromArgb(128, 128, 128));
        private Pen _borderPen = new Pen(Color.FromArgb(128, 128, 128));
        private Pen _pressedBorderPen = new Pen(Color.FromArgb(128, 128, 128));
        private Pen _lightShade = new Pen(Color.FromArgb(216, 216, 216));
        private Pen _darkShade = new Pen(Color.FromArgb(64, 64, 64));

        /// <summary>
        /// Constructs a Button with the specified caption and font, and  default size.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="font"></param>
        public Button(string caption, Font font)
        {
            _caption = caption;
            _font = font;
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Bottom;

            int textWidth;
            int textHeight;
            _font.ComputeExtent(_caption, out textWidth, out textHeight);

            _width = textWidth + _textMarginX * 2;
            _height = textHeight + _textMarginY * 2 + 10;
        }

        /// <summary>
        /// Constructs a Button with the specified caption, font, and size.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="font"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Button(string caption, Font font, int width, int height)
        {
            _width = width;
            _height = height;
            _caption = caption;
            _font = font;
        }

        /// <summary>
        /// Overrides OnRender to do our own drawing.
        /// </summary>
        /// <param name="dc"></param>
        public override void OnRender(DrawingContext dc)
        {
            int x;
            int y;

            SolidColorBrush brush;
            Pen pen;
            Color color;
            Pen shade1;
            Pen shade2;

            // Check the pressed state and draw accordingly.
            if (_pressed)
            {
                brush = _pressedBackgroundBrush;
                pen = _pressedBorderPen;
                color = _pressedForeColor;
                shade1 = _darkShade;
                shade2 = _lightShade;
            }
            else
            {
                brush = _normalBackgroundBrush;
                pen = _borderPen;
                color = _foreColor;
                shade1 = _lightShade;
                shade2 = _darkShade;
            }

            GetLayoutOffset(out x, out y);

            // Draw the base rectangle of the button.
            dc.DrawRectangle(brush, pen, 1, 1, _width - 1, _height - 1);

            // Draw the caption.
            string caption = _caption;
            dc.DrawText(ref caption, _font, color, 0, _textMarginY, _width, _height, _alignment, _trimming);

            // Shade the outline of the rectangle for classic button look.
            dc.DrawLine(shade1, 1, 1, _width - 1, 1);
            dc.DrawLine(shade1, 1, 1, 1, _height - 1);
            dc.DrawLine(shade2, _width - 1, 1, _width - 1, _height - 1);
            dc.DrawLine(shade2, 1, _height - 1, _width - 1, _height - 1);
        }


        /// <summary>
        /// Handles the touch down event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTouchDown(TouchEventArgs e)
        {
            _pressed = true;
            TouchCapture.Capture(this);
            Invalidate();
        }

        /// <summary>
        /// Handles the touch up event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTouchUp(TouchEventArgs e)
        {
            _pressed = false;
            TouchCapture.Capture(this, TouchCaptureMode.None);
            Invalidate();
            EventArgs args = new EventArgs();
            OnClick(args);
        }

        /// <summary>
        /// Handles the touch move.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTouchMove(TouchEventArgs e)
        {
        }

        /// <summary>
        /// Handles a click.
        /// </summary>
        /// <param name="e"></param>
        public event EventHandler Click;
        protected virtual void OnClick(EventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrangeWidth"></param>
        /// <param name="arrangeHeight"></param>
        protected override void ArrangeOverride(int arrangeWidth,int arrangeHeight)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="availableWidth"></param>
        /// <param name="availableHeight"></param>
        /// <param name="desiredWidth"></param>
        /// <param name="desiredHeight"></param>
        protected override void MeasureOverride(int availableWidth, int availableHeight, out int desiredWidth, out int desiredHeight)
        {
            desiredWidth = (availableWidth > _width) ? _width : availableWidth;
            desiredHeight = (availableHeight > _height) ? _height : availableHeight;
        }
    }
}