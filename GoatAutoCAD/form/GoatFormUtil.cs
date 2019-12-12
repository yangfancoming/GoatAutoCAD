

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;

[assembly: CommandClass(typeof(GoatFormUtil))]
namespace GoatAutoCAD
{

    public class GoatFormUtil
    {

        //  显示模态对话框
        [CommandMethod("MyGroup", "form1", "form1", CommandFlags.Modal)]
        public void pick2()
        {
            DocumentLock doclock = BaseData.doc.LockDocument();
            //操作过程
            using (GoatForm form = new GoatForm())
            {
                Application.ShowModalDialog(form);
                //点击“确定”按钮命令行显示窗体文本框中的信息
                BaseData.ed.WriteMessage(form._textBox.Text);
            }
            doclock.Dispose();
        }



    }

}
