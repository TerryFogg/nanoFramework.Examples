//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nf_nPF_example1
{
    
    internal partial class Resources
    {
        private static System.Resources.ResourceManager manager;
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if ((Resources.manager == null))
                {
                    Resources.manager = new System.Resources.ResourceManager("nf_nPF_example1.Resources", typeof(Resources).Assembly);
                }
                return Resources.manager;
            }
        }
        internal static nanoFramework.UI.Bitmap GetBitmap(Resources.BitmapResources id)
        {
            return ((nanoFramework.UI.Bitmap)(nanoFramework.Runtime.Native.ResourceUtility.GetObject(ResourceManager, id)));
        }
        [System.SerializableAttribute()]
        internal enum BitmapResources : short
        {
            Canvas_Panel_Icon_Small = 20403,
        }
    }
}
