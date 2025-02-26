using nanoFramework.Presentation;
using nanoFramework.UI;

namespace Puzzle
{
    public class PROGRAM
    {
        static MyPuzzle myApplication;
        public static void Main()
        {
            myApplication = new MyPuzzle();
            Touch.Initialize(myApplication);
            Window mainWindow = myApplication.CreateWindow();
            myApplication.Run(mainWindow);
        }
    }
}
