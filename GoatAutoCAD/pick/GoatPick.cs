

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.interaction;

[assembly: CommandClass(typeof(GoatPic))]
namespace GoatAutoCAD
{

    public class GoatPic{


        // 对话框获取 用户拾取点
        [CommandMethod("MyGroup", "pickPoint2", "pickPoint2", CommandFlags.Modal)]
        public void pickPoint2(){
            // 打开对话框窗体
            using (GoatForm form = new GoatForm()){
                Application.ShowModalDialog(form);
                //点击“确定”按钮命令行显示窗体文本框中的信息
                BaseData.ed.WriteMessage(form.Text);
            }
        }



    }

}
