

using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.operate;

// This line is not mandatory, but improves loading performances
[assembly: ExtensionApplication(typeof(MyPlugin))]

/**
 * [assembly: ExtensionApplication(typeof(ManagedApp.Init))]
上面表示ExtensionApplication属性，CAD首先查找它标志的类来初始化，
如果没有找到，就找如上面public class Init : IExtensionApplication 实现了IExtensionApplication的类，
如果还是没有找到，就跳过初始化。所以上面[assembly: ExtensionApplication(typeof(ManagedApp.Init))]
和public class Init : IExtensionApplication后面的IExtensionApplication写上一处就可以了。
*/

namespace GoatAutoCAD
{

    public class MyPlugin : IExtensionApplication
    {

        void IExtensionApplication.Initialize()
        {
            //加载dll的时候执行相关加载操作
            GoatMessageUtil.msg("\n 插件加载 \n");
        }

        void IExtensionApplication.Terminate()
        {
            //这个是退出时执行
            GoatMessageUtil.msg("\n 插件卸载 \n");

        }




    }

}
