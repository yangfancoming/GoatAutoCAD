
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;


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

        /*
            定义命令使用 CommandMethod 属性。 CommandMethod 属性需要一个字符串值作为要定义的命令的全局名字。
            除了全局命令名外， CommandMethod 属性还可以接受下列参数值：
            • Command Flags 命令标志 - 定义命令的行为；
            • Group Name 组名 - 命令编组名称；
            • Local Name 本地名 - 指定语言的本地命令名称；
            • Help Topic Name 帮助主题名 - 按下 F1 键时将要显示的帮助主题名；
            • Context Menu Type Flags 上下文菜单类型标志 - 定义命令处于活动状态时的上下文菜单行为；
            • Help File Name 帮助文件名 - 帮助文件，含有命令活动状态下按下 F1 时要显示的帮助主题；

            Command Flags 命令标志

            ActionMacro 可以用动作录制器录制命令动作；
            DocReadLock 命令执行时将被只读锁定；
            Interruptible 提示用户输入时可以中断命令；
            Modal 别的命令运行时不能运行此命令；
            NoActionRecording 不能用动作录制器录制命令动作；
            NoBlockEditor 不能从块编辑器使用该命令；
            NoHistory 不能将命令添加到 repeat-last-command（重复上一个命令）历史列表；
            NoPaperSpace 不能从图纸空间使用该命令；
            NoTileMode 当 TILEMODE 置 1 时不能使用该命令；
            NoUndoMarker 命令不支持撤销标记。用于不修改数据库因而也就无需出现在撤销记录中的那些命令；
            Redraw 不清空取回的先选择后执行设置及对象捕捉设置；
            Session 命令运行于应用程序上下文，而不是当前图形文档上下文；
            Transparent 别的命令运行时可以运行此命令；
            Undefined 只能通过全局名使用命令；
            UsePickSet 清空取回的先选择后执行设置；
        */
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
