using nanoFramework.Presentation;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;

namespace nf_CustomUI
{
    class ButtonControl : UIElement
    {
        protected string _name;
        protected Font _font;

        protected Brush _cyanBrush = new SolidColorBrush(ColorUtility.ColorFromRGB(192, 192, 255));
        protected Pen _darkCyanPen = new Pen(ColorUtility.ColorFromRGB(128, 128, 192), 1);

        public ButtonControl(string name, int width, int height)
        {
            Width = width;
            Height = height;
            _name = name;
            _font = Resources.GetFont(Resources.FontResources.small);
        }

        public override void OnRender(DrawingContext dc)
        {
            dc.DrawRectangle(_cyanBrush, _darkCyanPen, 0, 0, Width, Height);
            dc.DrawText(ref _name,
                        _font,
                        Color.Black,
                        0,
                        2,
                        Width,
                        Height - 2,
                        TextAlignment.Center,
                        TextTrimming.None);
        }
    }
}
