

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;

[assembly: CommandClass(typeof(GoatFormUtil))]
namespace GoatAutoCAD {

    public class GoatFormUtil {

        //  显示模态对话框
        [CommandMethod("MyGroup", "form1", "form1", CommandFlags.Modal)]
        public void pick2() {
            DocumentLock doclock = BaseData.doc.LockDocument();
            //操作过程
            using (GoatForm form = new GoatForm()) {
                Application.ShowModalDialog(form);
            }
            doclock.Dispose();
        }


        //  显示非模态对话框  程序焦点可以自由的从 AutoCAD 界面到窗体之间切换，主要用于用户与 AutoCAD 环境的即时交互操作
        [CommandMethod("MyGroup", "form2", "form2", CommandFlags.Modal)]
        public void ShowModelessDialog(){
            DocumentLock doclock = BaseData.doc.LockDocument();
            GoatForm form = new GoatForm();
            Application.ShowModelessDialog(form);
            doclock.Dispose();
        }
    }

}
