using System;
using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI.Input;
using nanoFramework.UI;
using System.Drawing;
using nanoFramework.UI.Threading;

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
