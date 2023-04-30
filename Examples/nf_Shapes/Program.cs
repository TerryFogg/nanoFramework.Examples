using nanoFramework.UI;


namespace nf_Shapes
{
    public class Program
    {
        public static void Main()
        {
            Font DisplayFont = Resources.GetFont(Resources.FontResources.segoeuiregular12);
            Bitmap fullScreenBitmap = new Bitmap(480, 272);
            //           Bitmap fullScreenBitmap = new Bitmap(240, 135);
            //Bitmap fullScreenBitmap = new Bitmap(240, 240);
            fullScreenBitmap.Clear();

            Shapes bb = new Shapes(fullScreenBitmap, DisplayFont);
        }
    }
}
