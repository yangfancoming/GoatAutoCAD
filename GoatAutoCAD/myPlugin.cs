

using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;

// This line is not mandatory, but improves loading performances
[assembly: ExtensionApplication(typeof(MyPlugin))]

namespace GoatAutoCAD
{

    public class MyPlugin : IExtensionApplication
    {

        void IExtensionApplication.Initialize()
        {

        }

        void IExtensionApplication.Terminate()
        {
        }

    }

}
