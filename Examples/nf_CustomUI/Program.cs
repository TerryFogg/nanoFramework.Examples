using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using System;
using System.Diagnostics;
using System.Threading;

namespace nf_CustomUI
{
    public class Program : Application
    {
        int ScreenWidth = 480;
        int ScreenHeight = 272;


        public static void Main()
        {
            Program myApplication = new Program();

            // By default, touch notifications are not turned on.  You must
            // explicitly inform the Touch engine that you want touch events to
            // be pumped into the application, and you want the Touch engine to
            // work with the rest of the architecture.
            Touch.Initialize(myApplication);
            Window mainWindow = myApplication.CreateWindow();

            // Start the application
            myApplication.Run(mainWindow);
        }


        private Window mainWindow;

        // Create the list view.
        ListView _listView;

        public Window CreateWindow()
        {
            // Create a window object and set its size to the
            // size of the display.
            mainWindow = new Window();
            mainWindow.Height = ScreenHeight;
            mainWindow.Width = ScreenWidth;

            int buttonWidth = ScreenWidth / 4;
            int buttonHeight = 20;

            // Create a panel to hold the list view and buttons.
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;

            // Create a panel to hold the buttons.
            StackPanel buttonPanel = new StackPanel();
            buttonPanel.Orientation = Orientation.Horizontal;

            ButtonControl newFileButton = new ButtonControl("New File", buttonWidth, buttonHeight);
            newFileButton.TouchDown += new TouchEventHandler(OnNewFile);
            buttonPanel.Children.Add(newFileButton);

            ButtonControl newDirButton = new ButtonControl("New Dir", buttonWidth, buttonHeight);
            newDirButton.TouchDown += new TouchEventHandler(OnNewDirectory);
            buttonPanel.Children.Add(newDirButton);

            ButtonControl deleteButton = new ButtonControl("Delete", buttonWidth, buttonHeight);
            deleteButton.TouchDown += new TouchEventHandler(OnDeleteFile);
            buttonPanel.Children.Add(deleteButton);

            ButtonControl formatButton = new ButtonControl("Format", buttonWidth, buttonHeight);
            formatButton.TouchDown += new TouchEventHandler(OnFormat);
            buttonPanel.Children.Add(formatButton);

            // Create the list view.
            _listView = new ListView(ScreenWidth, ScreenHeight - buttonHeight);
            _listView.AddColumn("Name", 200);
            _listView.AddColumn("Size", 80);
            _listView.AddColumn("Created", 80);
            _listView.SelectionChanged += new SelectionChangedEventHandler(OnItemSelected);

            stackPanel.Children.Add(buttonPanel);
            stackPanel.Children.Add(_listView);
            mainWindow.Child = stackPanel;

            // Refresh the directory and file list
            RefreshList();

            // Set the window visibility to visible.
            mainWindow.Visibility = Visibility.Visible;

            // Attach the button focus to the window.
            Buttons.Focus(mainWindow);

            return mainWindow;
        }

        /// <summary>
        /// Refreshes the list of directories and files.
        /// </summary>
        public void RefreshList()
        {
            _listView.Clear();

            try
            {
                // Get the string list of directories for the current
                // directory.
                string[] dirs = FileAccess.Directory.GetListOfDirectories();

                // If this is not the root directory of the volume, add a
                // ".." entry.  In this demo, the root volume is named
                // "\\ROOT".
                if (FileAccess.Directory.GetCurrentDirectory() != "\\")
                {
                    ListViewItem item = new ListViewItem();
                    item.AddSubItem("[..]");
                    _listView.AddItem(item);
                }

                // Add each directory name to the list view.
                for (int i = 0; i < dirs.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.AddSubItem("[" + dirs[i] + "]");
                    _listView.AddItem(item);
                }

                // Get the string list of files for the current directory.
                string[] files = FileAccess.Directory.GetFiles(FileAccess.Directory.GetCurrentDirectory());

                // Add each file name and its information to the list view.
                for (int i = 0; i < files.Length; i++)
                {
                    // Get information about the file.
                    FileAccess.FileInfo info = new FileAccess.FileInfo(files[i]);

                    // Add the name, length, and creation date.
                    ListViewItem item = new ListViewItem();
                    item.AddSubItem(files[i]);
                    item.AddSubItem(info.Length.ToString());
                    item.AddSubItem(info.CreationTime.ToString("d"));
                    _listView.AddItem(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private object GetListOfDirectories()
        {
            throw new NotImplementedException();
        }

        private void OnNewFile(object sender, TouchEventArgs e)
        {
            if (FileAccess.Directory.GetCurrentDirectory() == "\\")
            {
                Debug.WriteLine("Cannot create a file at \\");
                return;
            }

            // Get the next file name, by looping until the file
            // doesn't exist.
            int index = 0;
            string name = "File_0.txt";
            while (FileAccess.File.Exists(name))
            {
                name = "File_" + (++index).ToString() + ".txt";
            }

            // Create the file using the standard .NET FileStream.
            FileAccess.FileStream file = new FileAccess.FileStream(name, FileMode.Create);

            // Write some dummy data to the file.
            for (int i = 0; i < (index + 5) * 2; i++)
            {
                file.WriteByte((byte)i);
            }

            // Close the file.
            file.Close();

            // Refresh the list and invalidate.
            RefreshList();
            _listView.Invalidate();
        }

        private void OnNewDirectory(object sender, TouchEventArgs e)
        {
            if (FileAccess.Directory.GetCurrentDirectory() == "\\")
            {
                Debug.WriteLine("Cannot create a directory at \\");
                return;
            }

            // Get the next directory name, by looping until the
            // directory doesn't exist.
            int index = 0;
            string name = "Directory_0";
            while (FileAccess.Directory.Exists(name))
                name = "Directory_" + (++index).ToString();

            // Create the directory.
            FileAccess.Directory.CreateDirectory(name);

            // Refresh the list, then re-draw the list.
            RefreshList();
            _listView.Invalidate();
        }

        private void OnDeleteFile(object sender, TouchEventArgs e)
        {
            if (FileAccess.Directory.GetCurrentDirectory() == "\\")
            {
                Debug.WriteLine("Cannot delete from \\");
                return;
            }

            // If an item is selected, delete the item.
            if (_listView.SelectedItem != null)
            {
                // Get the sub-item that has the name.
                ListViewSubItem subItem = (ListViewSubItem)_listView.SelectedItem.SubItems[0];
                if (subItem != null)
                {
                    // If the name starts with [ and ends with ],
                    // then it is a directory.  This is only because
                    // we put the [ and ] on our directory names.
                    // There is nothing in the file system that
                    // requires the [ and ].
                    if ((subItem.Text[0] == '[') &&
                        (subItem.Text[subItem.Text.Length - 1] == ']'))
                    {
                        // Remove the [ and ].
                        string name = subItem.Text.Substring(1, subItem.Text.Length - 2);

                        // Make sure the directory exists.
                        if (FileAccess.Directory.Exists(name))
                        {
                            // Delete the directory.
                            FileAccess.Directory.Delete(name);

                            // Remove it from the list view.
                            _listView.RemoveItem(_listView.SelectedItem);
                        }
                    }
                    else if (FileAccess.File.Exists(subItem.Text))
                    {
                        // Without the [ and ], it is a file.

                        // Delete the file.
                        FileAccess.File.Delete(subItem.Text);

                        // Remove it from the list view.
                        _listView.RemoveItem(_listView.SelectedItem);
                    }

                    // Re-draw the list view.
                    _listView.Invalidate();
                }
            }
        }

        private void OnFormat(object sender, TouchEventArgs e)
        {
            if (FileAccess.Directory.GetCurrentDirectory() == "\\")
            {
                // Always go back to the root directory before formatting.
                if (_listView.SelectedItem != null)
                {
                    FileAccess.Directory.SetCurrentDirectory("\\");

                    // Get the name of the selected volume.
                    string volume = ((ListViewSubItem)_listView.SelectedItem.SubItems[0]).Text;
                    volume = volume.Trim('[', ']', '\\');

                    // Format the selected volume.
                    FileAccess.IO.VolumeInfo volInfo = new FileAccess.IO.VolumeInfo(volume);
                    if (volInfo.FileSystem == null)
                    {
                        volInfo.Format("FAT", 0, volume + "FS", true);
                    }
                    else
                    {
                        volInfo.Format(0);
                    }

                    // Refresh the list, then re-draw the list.
                    RefreshList();
                    _listView.Invalidate();
                }
            }
            else
            {
                Debug.WriteLine("Format can only be performed on a root directory.");
            }
        }

        private void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem selectedItem = ((ListView)sender).SelectedItem;

            // If this is a double-tap on a directory, change the current directory to the selection.
            if ((selectedItem != null) &&
                (selectedItem.SubItems.Count > 0) &&
                (e.SelectedIndex == e.PreviousSelectedIndex))
            {
                string directoryName = ((ListViewSubItem)selectedItem.SubItems[0]).Text;
                directoryName = directoryName.Substring(1, directoryName.Length - 2);

                // Check for special ".." name.
                if (directoryName == "..")
                {
                    directoryName = FileAccess.Directory.GetCurrentDirectory();
                    directoryName = FileAccess.Directory.GetDirectoryName(directoryName);
                }

                // If the directory exists...
                if (FileAccess.Directory.Exists(directoryName))
                {
                    // Set the current directory.
                    FileAccess.Directory.SetCurrentDirectory(directoryName);

                    // Refresh the list.
                    RefreshList();
                }
            }
        }

        private object GetCurrentDirectory()
        {
            throw new NotImplementedException();
        }
    }
}