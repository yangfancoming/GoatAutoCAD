

using System.IO;
using System.Reflection;
using Autodesk.AutoCAD.Runtime;
using Microsoft.Win32;
using GoatAutoCAD;

[assembly: CommandClass(typeof(GoatNetload))]
namespace GoatAutoCAD{

    /// <summary>
    /// 扩展Cad的NETLOAD命令
    /// 防止修改其他命令代码的时候，编译时提示dll被占用的问题
    /// </summary>
    public class GoatNetload{

        [CommandMethod("NetLoadEx")]
        public void NetLoad() {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Dll文件（*.dll）|*.dll";
            openFileDialog.Title = "选择DLL文件";
            openFileDialog.InitialDirectory = Assembly.GetExecutingAssembly().Location;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true) {
                if (File.Exists(openFileDialog.FileName)) {
                    byte[] fileBuffer = File.ReadAllBytes(openFileDialog.FileName);
                    Assembly.Load(fileBuffer);
                }
            }
        }

    }

}
