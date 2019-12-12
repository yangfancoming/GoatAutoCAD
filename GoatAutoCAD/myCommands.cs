
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;


/**
 * .[assembly: CommandClass(typeof(ManagedApp.Commands))]
表示ManagedApp.Commands是定义CommandClass的，就是说能够执行Commands中定义的命令（CommandMethod）如上面的[CommandMethod("kaka")]和[CommandMethod("GetVersion")]，
但是不能执行[CommandMethod("Test")]，因为[CommandMethod("Test")]所在的类Initialize()没有定义CommandClass。

注意： 包含命令方法的命令类 文件必须是3个文件组成的那种  不是能单个的cs类 否则 AutoCAD加载dll后报错！
*/
[assembly: CommandClass(typeof(MyCommands))]
namespace GoatAutoCAD
{

    public class MyCommands
    {

        [CommandMethod("MyGroup", "MyCommand", "MyCommandLocal", CommandFlags.Modal)]
        public void MyCommand() // This method can have any name
        {
            GoatDB.editor.WriteMessage("Hello, this is your first command.");
        }


        [CommandMethod("MyGroup", "MyPickFirst", "MyPickFirstLocal", CommandFlags.Modal | CommandFlags.UsePickSet)]
        public void MyPickFirst()
        {
            PromptSelectionResult result = Application.DocumentManager.MdiActiveDocument.Editor.GetSelection();
            if (result.Status == PromptStatus.OK)
            {
            }

        }

        [CommandMethod("MyGroup", "MySessionCmd", "MySessionCmdLocal", CommandFlags.Modal | CommandFlags.Session)]
        public void MySessionCmd()
        {
        }


        [LispFunction("MyLispFunction", "MyLispFunctionLocal")]
        public int MyLispFunction(ResultBuffer args)
        {
            return 1;
        }

    }

}
