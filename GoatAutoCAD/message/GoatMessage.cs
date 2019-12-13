

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatMessage))]
namespace GoatAutoCAD
{

    public class GoatMessage
    {
        // 命令行消息提示
        [CommandMethod("MyGroup", "msg1", "msg1", CommandFlags.Modal)]
        public void msg1()
        {
            GoatMessageUtil.msg("Hello, this is msg1");
        }


        // 弹出警告框提示
        [CommandMethod("MyGroup", "msg2", "msg2", CommandFlags.Modal)]
        public void msg2()
        {
            Application.ShowAlertDialog("Hello, this is msg2.");
        }

    }

}
