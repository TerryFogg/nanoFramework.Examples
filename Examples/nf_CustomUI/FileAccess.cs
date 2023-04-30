using System;

namespace nf_CustomUI
{

    enum FileMode
    {
        Create
    }
    internal static class FileAccess
    {
        // Always start in the root directory.
        //Directory.SetCurrentDirectory("\\");
        //RemovableMedia.Eject += new EjectEventHandler(Eject);
        //RemovableMedia.Insert += new InsertEventHandler(Insert);

        //static void Insert(object sender, MediaEventArgs args)
        //{
        //    Debug.WriteLine("Media Inserted: " + args.Volume.Name);
        //}

        //static void Eject(object sender, MediaEventArgs args)
        //{
        //    Debug.WriteLine("Media Ejected: " + args.Volume.Name);
        //}
        public class Directory
        {
            internal static void CreateDirectory(string name)
            {
                throw new NotImplementedException();
            }
            internal static void Delete(string name)
            {
                throw new NotImplementedException();
            }
            internal static bool Exists(string directoryName)
            {
                throw new NotImplementedException();
            }
            internal static string GetCurrentDirectory()
            {
                return "\\";
            }
            internal static string GetDirectoryName(string directoryName)
            {
                return "Directory 1";
            }
            internal static string[] GetFiles(object value)
            {
                string[] files = null;
                switch (value)
                {
                    case "dir1":
                        files = new string[] { "dir1_a.csv", "dir1_b.dat", "dir1_c.jpg" };
                        break;
                    case "dir2":
                        files = new string[] { "dir2_a.csv", "dir2_b.dat", "dir2_c.jpg" };
                        break;
                    case "dir3":
                        files = new string[] { "dir3_a.csv", "dir3_b.dat", "dir3_c.jpg" };
                        break;
                    case "dir4":
                        files = new string[] { "dir4_a.csv", "dir4_b.dat", "dir4_c.jpg" };
                        break;
                }
                return files;
            }

            internal static string[] GetListOfDirectories()
            {
                return new string[] { "dir1", "dir2", "dir3", "dir4" };
            }

            internal static void SetCurrentDirectory(string directoryName)
            {
                return;
            }
        }
        public class File
        {
            internal static void Delete(string text)
            {
                throw new NotImplementedException();
            }

            internal static bool Exists(string text)
            {
                throw new NotImplementedException();
            }
        }
        public class IO
        {
            public class VolumeInfo
            {
                private string volume;
                public VolumeInfo(string volume)
                {
                    this.volume = volume;
                }
                public string FileInfo { get; set; }
                public object FileSystem { get; internal set; }
                internal void Format(string v1, int v2, string v3, bool v4)
                {
                    throw new NotImplementedException();
                }
                internal void Format(int v)
                {
                    throw new NotImplementedException();
                }
            }
        }
        public class FileInfo
        {
            private string v;
            public FileInfo(string v)
            {
                this.v = v;
            }
            public int Length { get; set; }
            public DateTime CreationTime { get; set; }
        }
        public class FileStream
        {
            private string name;
            private object create;
            public FileStream(string name, object create)
            {
                this.name = name;
                this.create = create;
            }
            public void WriteByte(byte b)
            {
                return;
            }
            public void Close()
            {

            }
        }
    }
}
