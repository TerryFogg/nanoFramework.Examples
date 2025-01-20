using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using System;
using System.Drawing;

namespace nf_simpleTouchDisplay
{
    public class TouchButton : Border
    {
        private Text buttonText;

        public Color BorderColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color PressedBorderColor { get; set; }
        public Color PressedBackgroundColor { get; set; }

        public event EventHandler Click;

        private Canvas container;
        private int top;
        private int left;

        public TouchButton(Font font, string content)
            : this(font, content, null, 0, 0)
        { }

        public TouchButton(Font font, string content, Canvas canvas, int top, int left)
        {
            BackgroundColor = Color.LightGray;
            BorderColor = Color.DarkGray;
            PressedBorderColor = Color.DarkGray;
            PressedBackgroundColor = Color.LightGray;

            HorizontalAlignment = HorizontalAlignment.Center;
            Background = new SolidColorBrush(BackgroundColor);
            BorderBrush = new SolidColorBrush(BorderColor);
            SetBorderThickness(2, 2, 2, 2);
            buttonText = new Text(font, content);
            buttonText.SetMargin(25);
            buttonText.HorizontalAlignment = HorizontalAlignment.Center;
            Child = buttonText;

            if (canvas != null)
                AddToCanvas(canvas, top, left);
        }

        protected override void OnTouchDown(TouchEventArgs e)
        {
            if (container != null)
                Canvas.SetTop(this, top + 1);

            Background = new SolidColorBrush(PressedBackgroundColor);
            BorderBrush = new SolidColorBrush(PressedBorderColor);
            base.OnTouchDown(e);
        }

        protected override void OnTouchUp(TouchEventArgs e)
        {
            if (container != null)
                Canvas.SetTop(this, top - 1);

            Background = new SolidColorBrush(BackgroundColor);
            BorderBrush = new SolidColorBrush(BorderColor);
            base.OnTouchUp(e);
            OnClick();
        }

        public void AddToCanvas(Canvas canvas, int top, int left)
        {
            container = canvas;
            this.top = top;
            this.left = left;

            canvas.Children.Add(this);
            Canvas.SetTop(this, top);
            Canvas.SetLeft(this, left);
        }

        public string Text
        {
            get { return buttonText.TextContent; }
            set { buttonText.TextContent = value; }
        }

        protected virtual void OnClick()
        {
            if (Click != null)
                Click(this, EventArgs.Empty);
        }
    }

}

